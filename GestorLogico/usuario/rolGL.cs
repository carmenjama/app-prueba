using AccesoDatos;
using ClasesNegocio.usuario;
using GestorLogico.seguridad;
using LogicaNegocios.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorLogico.usuario
{
    public  class rolGL
    {
        private rolLN mt_rol = new rolLN();

        public rolCN Traer(Int64 id_rol)
        {
            rolCN cn_usuario = new rolCN();
            BaseDatos bd = new BaseDatos();
            try
            {
                bd.Conectar();
                bd.ComenzarTransaccion();
                cn_usuario = mt_rol.Traer(id_rol, bd);
                bd.ConfirmarTransaccion();
            }
            catch (Exception ex)
            {
                bd.CancelarTransaccion();
                throw new Exception(ex.Message);
            }
            finally
            {
                bd.Desconectar();
            }
            return cn_usuario;
        }
    }
}
