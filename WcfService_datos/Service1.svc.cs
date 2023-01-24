using ClasesNegocio.datos;
using ClasesNegocio.mensaje;
using ClasesNegocio.usuario;
using GestorLogico.datos;
using GestorLogico.usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService_datos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {

        public respuesta_usuarioCN Autenticar(String usuario, String clave)
        {
            respuesta_usuarioCN response = new respuesta_usuarioCN();
            try
            {
                if (usuario.Trim() == "")
                {
                    response.estado = Enumerado.mensaje_advertencia;
                    response.mensaje = "Ingrese nombre de usuario.";
                }
                else if (clave.Trim() == "")
                {
                    response.estado = Enumerado.mensaje_advertencia;
                    response.mensaje = "Ingrese clave de acceso.";
                }
                else
                {
                    usuarioCN cn_usuario = new usuarioGL().autenticar_usuario(usuario, clave);
                    if (cn_usuario.id_usuario == 0)
                    {
                        response.estado = Enumerado.mensaje_advertencia;
                        response.mensaje = "Usuario o clave incorrecto.";
                    }
                    else if(cn_usuario.token == null){
                        response.estado = Enumerado.mensaje_advertencia;
                        response.mensaje = "Usuario o clave incorrecto.";
                    }
                    else if (cn_usuario.token.Trim() == "")
                    {
                        response.estado = Enumerado.mensaje_advertencia;
                        response.mensaje = "Usuario o clave incorrecto.";
                    }
                    else
                    {
                        response.estado = Enumerado.mensaje_ok;
                        response.mensaje = "Bienvenido al sistema.";
                        response.rol = new rolGL().Traer(cn_usuario.id_rol).nombre;
                        response.nick = cn_usuario.nick;
                        response.token  = cn_usuario.token;
                    }
                }
            }
            catch (Exception ex )
            {
                response.estado = Enumerado.mensaje_error;
                response.mensaje = ex.Message;
            }
            return response;
        }

        public respuestaCN RegistrarUsuario(String usuario, String clave, Int64 id_rol)
        {
            respuestaCN response = new respuestaCN();
            try
            {
                if (usuario.Trim() == "")
                {
                    response.estado = Enumerado.mensaje_advertencia;
                    response.mensaje = "Ingrese nombre de usuario.";
                }
                else if (clave.Trim() == "")
                {
                    response.estado = Enumerado.mensaje_advertencia;
                    response.mensaje = "Ingrese clave de acceso.";
                }
                else if (id_rol == 0)
                {
                    response.estado = Enumerado.mensaje_advertencia;
                    response.mensaje = "Indique rol de usuario.";
                }
                else {
                    usuarioCN cn_usuario = new usuarioCN();
                    cn_usuario.id_rol = id_rol;
                    cn_usuario.nick = usuario;
                    cn_usuario.clave = clave;
                    cn_usuario.estado = true;
                    cn_usuario.id_usuario = new usuarioGL().Insertar(cn_usuario);
                    if (cn_usuario.id_usuario == 0)
                    {
                        response.estado = Enumerado.mensaje_advertencia;
                        response.mensaje = "Se presentó un error al ingresar usuario, intente de nuevo.";
                    }
                    else
                    {
                        response.estado = Enumerado.mensaje_ok;
                        response.mensaje = "Usuario registrado.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.estado = Enumerado.mensaje_error;
                response.mensaje = ex.Message;
            }
            return response;
        }

        public bool Verificar_rol_usuario(String usuario, String token, String rol)
        {
            bool response = false;
            try
            {
                if (usuario.Trim() != "" && token.Trim() != "")
                {
                    usuarioGL gl_usuario = new usuarioGL();
                    Int64 id_usuario = gl_usuario.Verificar_token(usuario, token);
                    if (id_usuario != 0)
                    {
                        response = gl_usuario.Verificar_rol_usuario(id_usuario, rol);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
            return response;
        }

        public List<statesCN> Listar_states(String usuario, String token)
        {
            List<statesCN> response = new List<statesCN>();
            try
            {
                if (usuario.Trim() != "" && token.Trim() != "")
                {
                    usuarioGL gl_usuario = new usuarioGL();
                    Int64 id_usuario = gl_usuario.Verificar_token(usuario, token);
                    if (id_usuario != 0)
                    {
                        if (gl_usuario.Verificar_rol_usuario(id_usuario, "ciudadano"))
                        {
                            response = new obtener_datosGL().Obtener_datos_states();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }

        public List<usCN> Listar_us(String usuario, String token)
        {
            List<usCN> response = new List<usCN>();
            try
            {
                if (usuario.Trim() != "" && token.Trim() != "")
                {
                    usuarioGL gl_usuario = new usuarioGL();
                    Int64 id_usuario = gl_usuario.Verificar_token(usuario, token);
                    if (id_usuario != 0)
                    {
                        if (gl_usuario.Verificar_rol_usuario(id_usuario, "buscador"))
                        {
                            response = new obtener_datosGL().Obtener_datos_us();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return response;
        }


    }
}
