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

        //public void Eliminar(int idClase, BaseDatos miBD)
        //{
        //    try
        //    {
        //        miBD.CrearComando("exec sis_Eliminar_usuario @id_usuario");
        //        miBD.AsignarParametro("@id_usuario", System.Data.SqlDbType.Int, idClase);
        //        miBD.EjecutarComando();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //}

        //public usuarioCN Traer_usuario(Int64 idClase, BaseDatos miBD)
        //{
        //    usuarioCN clase = new usuarioCN();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_TraerPorId_usuario @id_usuario");
        //        miBD.AsignarParametro("@id_usuario", SqlDbType.BigInt, idClase);
        //        dr = miBD.EjecutarConsulta();
        //        clase = helper.GenericSelectOne<usuarioCN>(dr, new usuarioCN());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return clase;
        //}

        //public bool Verificar_token(String token, BaseDatos miBD)
        //{
        //    bool respuesta = false;
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_VerificarToken @token");
        //        miBD.AsignarParametro("@token", SqlDbType.NVarChar, token);
        //        dr = miBD.EjecutarConsulta();
        //        while (dr.Read())
        //        {
        //            respuesta = Convert.ToBoolean(dr.GetValue(0));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return respuesta;
        //}

        //public bool Verificar_token_usuario(String token, String usuario, BaseDatos miBD)
        //{
        //    bool respuesta = false;
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec SIS.VerificarTokenUsuario @token, @usuario");
        //        miBD.AsignarParametro("@token", SqlDbType.NVarChar, token);
        //        miBD.AsignarParametro("@usuario", SqlDbType.NVarChar, usuario);
        //        dr = miBD.EjecutarConsulta();
        //        while (dr.Read())
        //        {
        //            respuesta = Convert.ToBoolean(dr.GetValue(0));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return respuesta;
        //}

        //public usuarioCN Traer_usuario_token(String token, BaseDatos miBD)
        //{
        //    usuarioCN clase = new usuarioCN();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_TraerPorToken_usuario @token");
        //        miBD.AsignarParametro("@token", SqlDbType.NVarChar, token);
        //        dr = miBD.EjecutarConsulta();
        //        clase = helper.GenericSelectOne<usuarioCN>(dr, new usuarioCN());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return clase;
        //}

        //public List<usuarioCN> Traer_Todos(BaseDatos miBD)
        //{
        //    List<usuarioCN> Lista = new List<usuarioCN>();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_TraerTodos_usuario");
        //        dr = miBD.EjecutarConsulta();
        //        Lista = helper.GenericSelect<usuarioCN>(dr, new usuarioCN());
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return Lista;
        //}

        //public bool Verificar_Existe_Nombre(string nombre, BaseDatos miBD)
        //{
        //    SqlDataReader dr = null;
        //    int cont = 0;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_VerificarExiste_usuario @nick");
        //        miBD.AsignarParametro("@nick", System.Data.SqlDbType.NVarChar, nombre);
        //        dr = miBD.EjecutarConsulta();
        //        while (dr.Read())
        //        {
        //            cont = dr.GetSqlInt32(0).Value;
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }

        //    if (cont > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //public bool Verificar_Eliminar(int idClase, BaseDatos miBD)
        //{
        //    SqlDataReader dr = null;
        //    int cont = 0;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_VerificarEliminar_usuario @id_usuario");
        //        miBD.AsignarParametro("@id_usuario", System.Data.SqlDbType.Int, idClase);
        //        dr = miBD.EjecutarConsulta();
        //        while (dr.Read())
        //        {
        //            cont = dr.GetSqlInt32(0).Value;
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }

        //    if (cont > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //public bool Verificar_permiso(String codigo_grupo, Int64 usuario, BaseDatos miBD)
        //{
        //    SqlDataReader dr = null;
        //    bool cont = false;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_VerificarExistePermiso_usuario @grupo, @id_usuario");
        //        miBD.AsignarParametro("@grupo", System.Data.SqlDbType.NVarChar, codigo_grupo);
        //        miBD.AsignarParametro("@id_usuario", System.Data.SqlDbType.BigInt, usuario);
        //        dr = miBD.EjecutarConsulta();
        //        while (dr.Read())
        //        {
        //            cont = Convert.ToBoolean(dr.GetValue(0));
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }

        //    return cont;
        //}

        //public usuarioCN TraerPorNombre_usuario(String nombre, BaseDatos miBD)
        //{
        //    usuarioCN clase = new usuarioCN();
        //    if (nombre != null)
        //    {
        //        if (nombre.Trim() != "")
        //        {
        //            SqlDataReader dr = null;
        //            try
        //            {
        //                miBD.CrearComando("exec sis_TraerPorNombre_usuario @nombre");
        //                miBD.AsignarParametro("@nombre", System.Data.SqlDbType.NVarChar, nombre);
        //                dr = miBD.EjecutarConsulta();
        //                clase = helper.GenericSelectOne<usuarioCN>(dr, new usuarioCN());
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception(ex.Message);
        //            }
        //            finally
        //            {
        //                if (dr.IsClosed == false)
        //                {
        //                    dr.Close();
        //                }
        //            }
        //        }
        //    }
        //    return clase;
        //}

        //public List<usuarioCN> Traer_TodosPorTipo(Int64 id_tipo, BaseDatos miBD)
        //{
        //    List<usuarioCN> Lista = new List<usuarioCN>();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando(@"Select u.id_usuario, u.nick, u.clave, u.activo, u.token, u.id_tipo_usuario,
        //                            u.nombre, u.apellido, u.cargo, u.firma, u.fecha_creacion, u.fecha_modificacion,
        //                            u.id_usuario_modificador, u.id_usuario_creador from SIS.usuario u
        //                            INNER JOIN SIS.tipo_usuario tu ON tu.id_tipo_usuario = u.id_tipo_usuario AND tu.id_tipo_usuario=@tipo");
        //        miBD.AsignarParametro("@tipo", SqlDbType.BigInt, id_tipo);
        //        dr = miBD.EjecutarConsulta();
        //        Lista = helper.GenericSelect<usuarioCN>(dr, new usuarioCN());
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return Lista;
        //}

        //public List<usuarioCN> Traer_TodosPorArea(Int64 id_Area, BaseDatos miBD)
        //{
        //    List<usuarioCN> Lista = new List<usuarioCN>();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_TraerPorArea_usuario @id_Area");
        //        miBD.AsignarParametro("@id_Area", SqlDbType.BigInt, id_Area);
        //        dr = miBD.EjecutarConsulta();
        //        Lista = helper.GenericSelect<usuarioCN>(dr, new usuarioCN());
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return Lista;
        //}

        //public bool Autenticar_usuario_externo(String usuario, String pass, Int64 id_tipo_usuario, BaseDatos miBD)
        //{
        //    bool respuesta = false;
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_autenticar_usuario_externo @username, @pass, @id_tipo_usuario");
        //        miBD.AsignarParametro("@username", System.Data.SqlDbType.NVarChar, usuario);
        //        miBD.AsignarParametro("@pass", System.Data.SqlDbType.NVarChar, pass);
        //        miBD.AsignarParametro("@id_tipo_usuario", System.Data.SqlDbType.BigInt, id_tipo_usuario);

        //        dr = miBD.EjecutarConsulta();
        //        while (dr.Read())
        //        {
        //            respuesta = Convert.ToBoolean(dr.GetValue(0));
        //        }
        //        dr.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return respuesta;
        //}

        //public grid_usuarioCN Traer_detalle_grid_por_id_usuario(Int64 id_usuario, BaseDatos miBD)
        //{
        //    grid_usuarioCN clase = new grid_usuarioCN();
        //    SqlDataReader dr = null;
        //    try
        //    {
        //        miBD.CrearComando("exec sis_TraerUsuarioGridPorId_usuario @id_usuario");
        //        miBD.AsignarParametro("@id_usuario", SqlDbType.BigInt, id_usuario);
        //        dr = miBD.EjecutarConsulta();
        //        clase = helper.GenericSelectOne<grid_usuarioCN>(dr, new grid_usuarioCN());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dr.IsClosed == false)
        //        {
        //            dr.Close();
        //        }
        //    }
        //    return clase;
        //}

    }
}
