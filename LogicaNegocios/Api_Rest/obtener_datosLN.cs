using ClasesNegocio.datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Api_Rest
{
    [DataContract]
    public class obtener_datosLN
    {
        private static readonly HttpClient client = new HttpClient();
        private static string host = "https://jsonplaceholder.typicode.com/todos/1";
        private static string host_states = "https://api.covidtracking.com/v1/states/daily.json";
        private static string host_us = "https://api.covidtracking.com/v1/us/daily.json";
        ///private String responseBody = "";

        public List<statesCN> Obtener_datos_states()
        {
            List<statesCN> Lista = new List<statesCN>();

            try
            {
                Task<String> respuesta = GetHttp(host_states);
                if (respuesta != null)
                {
                    if (respuesta.Result != null)
                    {
                        Lista = JsonConvert.DeserializeObject<List<statesCN>>(respuesta.Result.ToString());
                    }
                }
            }
            catch (Exception ex)
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
                Task<String> respuesta = GetHttp(host_us);
                if (respuesta != null)
                {
                    if (respuesta.Result != null)
                    {
                        Lista = JsonConvert.DeserializeObject<List<usCN>>(respuesta.Result.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Lista;
        }


        private static async Task<String> GetHttp(String url)
        {
            string respuesta = "";
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                respuesta = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                //Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {

            }
            return respuesta;
        }
    }
}
