using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    internal class Conexion
    {
        private String server = "bd-desarrollo.database.windows.net";
        private String bd = "app_desarrollo";
        private String user = "admin-desarrollo";
        private String pass = "98-Ytxd-6Hq";

        public String cadena_conexion = "";
        public Conexion() {
            this.cadena_conexion = @"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";
            this.cadena_conexion = string.Format(this.cadena_conexion, server, bd, user, pass);
        }
    }
}
