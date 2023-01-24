using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceReference_dt;
using System.Security.Claims;
using System.Security.Policy;

namespace WebApplication_datos.Pages
{
    public class Consulta_statesModel : PageModel
    {

        [BindProperty]
        public List<statesCN> Lista_states { get; set; }

        public void onLoad() {
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
                    var response = client.Verificar_rol_usuarioAsync(usuario, token, "ciudadano");
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
            this.Lista_states = new List<statesCN> { };
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
                var response = client.Listar_statesAsync(usuario, token);
                if (response != null)
                {

                    Lista_states = response.Result.ToList().GetRange(0, 10).ToList();
                }
            }
        }
    }
}
