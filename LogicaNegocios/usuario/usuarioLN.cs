using AccesoDatos;
using ClasesNegocio.usuario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace LogicaNegocios.usuario
{
    [DataContract]
    public class usuarioLN
    {
        
        public Int64 Insertar(usuarioCN miClase, BaseDatos miBD)
        {
            try
            {
                helper.GenericInsertar(miClase, ref miBD, "SIS.Insertar_usuario");
                miClase.id_usuario = miBD.EjecutarEscalar();
                return miClase.id_usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public usuarioCN Autenticar_usuario(String usuario, String clave, BaseDatos miBD)
        {
            usuarioCN clase = new usuarioCN();
            SqlDataReader dr = null;
            try
            {
                miBD.CrearComando("exec SIS.Autenticar_usuario @usuario, @clave");
                miBD.AsignarParametro("@usuario", System.Data.SqlDbType.NVarChar, usuario);
                miBD.AsignarParametro("@clave", System.Data.SqlDbType.NVarChar, clave);

                dr = miBD.EjecutarConsulta();
                clase = helper.GenericSelectOne<usuarioCN>(dr, new usuarioCN());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return clase;
        }

        public void Modificar(usuarioCN miClase, BaseDatos miBD)
        {
            try
            {
                helper.GenericModificar(miClase, ref miBD, "SIS.Modificar_usuario");
                miBD.EjecutarComando();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Int64 Verificar_token(String usuario, String token, BaseDatos miBD)
        {
            Int64 respuesta = 0;
            SqlDataReader dr = null;
            try
            {
                miBD.CrearComando("exec SIS.Verificar_token_usuario @usuario, @token");
                miBD.AsignarParametro("@token", SqlDbType.NVarChar, token);
                miBD.AsignarParametro("@usuario", SqlDbType.NVarChar, usuario);
                dr = miBD.EjecutarConsulta();
                while (dr.Read())
                {
                    respuesta = Convert.ToInt64(dr.GetValue(0));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dr.IsClosed == false)
                {
                    dr.Close();
                }
            }
            return respuesta;
        }

        public bool Verificar_rol_usuario(Int64 id_usuario, String rol, BaseDatos miBD)
        {
            bool respuesta = false;
            SqlDataReader dr = null;
            try
            {
                miBD.CrearComando("exec SIS.Verificar_rol_usuario @id_usuario, @rol");
                miBD.AsignarParametro("@id_usuario", SqlDbType.BigInt, id_usuario);
                miBD.AsignarParametro("@rol", SqlDbType.NVarChar, rol);
                dr = miBD.EjecutarConsulta();
                while (dr.Read())
                {
                    respuesta = Convert.ToBoolean(dr.GetValue(0));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dr.IsClosed == false)
                {
                    dr.Close();
                }
            }
            return respuesta;
        }


    }
}
