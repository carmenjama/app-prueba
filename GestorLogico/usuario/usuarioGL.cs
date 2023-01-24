using AccesoDatos;
using ClasesNegocio.mensaje;
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
    public class usuarioGL
    {
        private usuarioLN mt_usuario = new usuarioLN();
        public Int64 Insertar(usuarioCN miClase)
        {
            Int64 id_usuario = 0;
            BaseDatos bd = new BaseDatos();
            try
            {
                bd.Conectar();
                bd.ComenzarTransaccion();
                miClase.nick = Encrypt.Encryptar(miClase.nick);
                miClase.clave = Encrypt.Encryptar(miClase.clave);
                id_usuario = mt_usuario.Insertar(miClase,bd);
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
            return id_usuario;
        }


        public usuarioCN autenticar_usuario(String usuario, String clave)
        {
            usuarioCN cn_usuario = new usuarioCN();
            BaseDatos bd = new BaseDatos();
            try
            {
                bd.Conectar();
                bd.ComenzarTransaccion();
                String usuario_encriptado = Encrypt.Encryptar(usuario);
                String clave_encriptada = Encrypt.Encryptar(clave);
                cn_usuario = mt_usuario.Autenticar_usuario(usuario_encriptado, clave_encriptada, bd);
                bd.ConfirmarTransaccion();
                if (cn_usuario.id_usuario > 0)
                {
                    cn_usuario.token = Generar_Token();
                    mt_usuario.Modificar(cn_usuario, bd);
                }
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


        public Int64 Verificar_token(String usuario, String token)
        {
            Int64 respuesta = 0; 
            BaseDatos bd = new BaseDatos();
            try
            {
                bd.Conectar();
                bd.ComenzarTransaccion();
                respuesta = mt_usuario.Verificar_token(usuario, token, bd);
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
            return respuesta;
        }


        public bool Verificar_rol_usuario(Int64 id_usuario, String rol)
        {
            bool respuesta = false;
            BaseDatos bd = new BaseDatos();
            try
            {
                bd.Conectar();
                bd.ComenzarTransaccion();
                respuesta = mt_usuario.Verificar_rol_usuario(id_usuario, rol, bd);
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
            return respuesta;
        }

        private String Generar_Token()
        {
            int longitud = 30;
            Guid miGuid = Guid.NewGuid();
            string token = miGuid.ToString().Replace("-", string.Empty).Substring(0, longitud);
            return token;
        }

    }
}
