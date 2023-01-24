using ClasesNegocio.datos;
using LogicaNegocios.Api_Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLogico.datos
{
    public class obtener_datosGL
    {
        private obtener_datosLN mt_states = new obtener_datosLN();


        public List<statesCN> Obtener_datos_states()
        {            
            List<statesCN> Lista = new List<statesCN>();
            String respuesta = String.Join("--", Lista.OrderByDescending(x => x.negative).ToList());
            try
            {
                Lista = mt_states.Obtener_datos_states();

            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }

        public List<usCN> Obtener_datos_us()
        {

            List<usCN> Lista = new List<usCN>();
            try
            {
                Lista = mt_states.Obtener_datos_us();

            }
            catch (Exception)
            {

                throw;
            }
            return Lista;
        }
    }
}
