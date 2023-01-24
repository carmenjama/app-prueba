using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static WebApplication_datos.Pages.IndexModel;
using WebApplication_datos;
using ServiceReference_dt;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Linq;

namespace WebApplication_datos.Pages
{
    public class Consulta_usModel : PageModel
    {


        [BindProperty]
        public List<usCN> Lista_us { get; set; }

        public void onLoad()
        {
            try
            {
                String usuario = "";
                String token = "";
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    usuario = identity.Name.ToString().Trim();
                    token = identity.Claims.ToList().FirstOrDefault(x => x.Type.Contains("hash")).Value.ToString().Trim();
                }
                if (usuario != "" && token != "")
                {
                    Service1Client client = new Service1Client();
                    var response = client.Verificar_rol_usuarioAsync(usuario, token, "buscador");
                    if (response != null)
                    {

                        if (response.Result == false)
                        {
                            Redirect("/Index");
                        }
                    }
                }
                else
                {
                    Redirect("/Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void OnGet()
        {
            this.Lista_us = new List<usCN> {};
            String usuario = "";
            String token = "";
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                usuario = identity.Name.ToString().Trim();
                token = identity.Claims.ToList().FirstOrDefault(x => x.Type.Contains("hash")).Value.ToString().Trim();
            }
            if (usuario != "" && token != "")
            {
                Service1Client client = new Service1Client();
                var response = client.Listar_usAsync(usuario, token);
                if (response != null)
                {

                    Lista_us = response.Result.ToList().GetRange(0, 10).ToList(); ;
                }
            }
            
        }


    }
}
