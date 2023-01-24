using AccesoDatos;
using ClasesNegocio.usuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.usuario
{
    public  class rolLN
    {
        public rolCN Traer(Int64 id_rol, BaseDatos miBD)
        {
            rolCN clase = new rolCN();
            SqlDataReader dr = null;
            try
            {
                miBD.CrearComando("exec SIS.Traer_rol @id_rol");
                miBD.AsignarParametro("@id_rol", System.Data.SqlDbType.BigInt, id_rol);
                dr = miBD.EjecutarConsulta();
                clase = helper.GenericSelectOne<rolCN>(dr, new rolCN());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clase;
        }
    }
}
