using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Server.Kestrel;
using ServiceReference_dt;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.ServiceModel;
using System.Text;
using WebApplication_datos;

namespace WebApplication_datos.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public Credenciales credenciales { get; set; }




        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this.credenciales = new Credenciales();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            if (credenciales.usuario != "" && credenciales.clave != "")
            {
                Service1Client client = new Service1Client();
                var response = client.AutenticarAsync(credenciales.usuario, credenciales.clave).Result;
                if (response != null)
                {
                    string url = "" ;
                    switch (response.estado)
                    {
                        case "OK" when response.rol == "ciudadano":
                            url = "/Consulta_states";
                            break;
                        case "OK" when response.rol == "buscador":
                            url = "/Consulta_us";
                            break;
                    }
                    if (url == "")
                    {
                        return Page();
                    }
                    else
                    {
                        ClaimsPrincipal cl_principal = new ClaimsPrincipal(
                                new ClaimsIdentity(new List<Claim> { 
                                new Claim(ClaimTypes.Name, response.nick), 
                                new Claim(ClaimTypes.Hash, response.token), 
                                new Claim(ClaimTypes.Role, response.rol) }, 
                                "token")); 
                        await HttpContext.SignInAsync("token", cl_principal);
                        return Redirect(url);
                    }
                    
                }
            }
            return Page();
        }


        public class Credenciales
        {
            [Required]
            [Display(Name = "Usuario requerido")]
            public String usuario { get; set; }
            [Required]
            [Display(Name = "Clave requerida")]
            public String clave { get; set; }

            public Credenciales() {
                this.usuario = String.Empty; this.clave = String.Empty;
            }
        }


    }
}