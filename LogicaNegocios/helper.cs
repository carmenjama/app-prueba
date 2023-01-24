using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class helper
    {
        public static bool GenericInsertar(Object miClase, ref BaseDatos miBD, string comando)
        {
            int atributos = miClase.GetType().GetProperties().GetLength(0);
            comando = "exec " + comando + " ";
            for (int i = 1; i < atributos; i++)
            {
                if ((miClase.GetType().GetProperties()[i].Name.ToString() != "id_usuario_modificador") && (miClase.GetType().GetProperties()[i].Name.ToString() != "fecha_modificacion"))
                    comando += "@" + miClase.GetType().GetProperties()[i].Name.ToString() + ",";
            }
            comando = comando.Substring(0, comando.Length - 1);
            miBD.CrearComando(comando);

            foreach (PropertyInfo propertyInfo in miClase.GetType().GetProperties())
            {
                if ((propertyInfo.Name != "fecha_modificacion") && (propertyInfo.Name != "id_usuario_modificador"))
                {
                    String tipo = propertyInfo.PropertyType.ToString();
                    switch (tipo)
                    {
                        case "System.String":
                            String lolete = miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString();
                            if (lolete != null)
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.NVarChar, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            }
                            else
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.NVarChar, DBNull.Value);
                            }
                            break;
                        case "System.Int32":
                            Int32 int32 = Int32.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Int, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());

                            //if (int32 != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Int, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Int, DBNull.Value);
                            //}
                            break;
                        case "System.Int64":
                            Int64 int64 = Int64.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.BigInt, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //if (int64 != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.BigInt, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.BigInt, DBNull.Value);
                            //}
                            break;
                        case "System.Single":
                            Single single = Single.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Float, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //if (single != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Float, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Float, DBNull.Value);
                            //}
                            break;
                        case "System.Decimal":
                            Decimal deci = Decimal.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Decimal, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //if (deci != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Decimal, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Decimal, DBNull.Value);
                            //}
                            break;
                        case "System.DateTime":
                            DateTime datetime = DateTime.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            if (datetime != null)
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.DateTime, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            }
                            else
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.DateTime, DBNull.Value);
                            }
                            break;
                        case "System.Boolean":
                            //Boolean boolean = Boolean.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //if(boolean != null)
                            //{

                            //}
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Bit, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            break;
                        case "System.Byte[]":
                            object archiv = miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null);
                            //if (archiv != null )
                            //{ miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.VarBinary, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null)); }
                            if (archiv != null)
                            { miBD.AsignarParametro_Tamaño("@" + propertyInfo.Name, System.Data.SqlDbType.VarBinary, Int32.MaxValue, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null)); }
                            else
                            { miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.VarBinary, DBNull.Value); }
                            break;
                        case "System.TimeSpan":
                            TimeSpan timespan = TimeSpan.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Time, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            break;
                        default:
                            break;
                    }
                }
            }
            return true;
        }


        public static bool GenericModificar(Object miClase, ref BaseDatos miBD, string comando)
        {
            int atributos = miClase.GetType().GetProperties().GetLength(0);
            comando = "exec " + comando + " ";
            for (int i = 0; i < atributos; i++)
            {
                if ((miClase.GetType().GetProperties()[i].Name.ToString() != "id_usuario_creador") && (miClase.GetType().GetProperties()[i].Name.ToString() != "fecha_creacion"))
                    comando += "@" + miClase.GetType().GetProperties()[i].Name.ToString() + ",";
            }
            comando = comando.Substring(0, comando.Length - 1);
            miBD.CrearComando(comando);

            foreach (PropertyInfo propertyInfo in miClase.GetType().GetProperties())
            {
                if ((propertyInfo.Name != "fecha_creacion") && (propertyInfo.Name != "id_usuario_creador"))
                {
                    String tipo = propertyInfo.PropertyType.ToString();
                    switch (tipo)
                    {
                        case "System.String":
                            string cadena = miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString();

                            if (cadena != null)
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.NVarChar, cadena == null ? "NONE" : cadena);
                            }
                            else
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.NVarChar, DBNull.Value);
                            }
                            break;
                        case "System.Int32":
                            Int32 int32 = Int32.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Int, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //if (int32 != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Int, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Int, DBNull.Value);
                            //}
                            break;
                        case "System.Int64":
                            Int64 int64 = Int64.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.BigInt, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //if (int64 != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.BigInt, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.BigInt, DBNull.Value);
                            //}
                            break;
                        case "System.Single":
                            Single single = Single.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Float, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //if (single != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Float, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Float, DBNull.Value);
                            //}
                            break;
                        case "System.Decimal":
                            Decimal deci = Decimal.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Decimal, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //if (deci != 0)
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Decimal, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            //}
                            //else
                            //{
                            //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Decimal, DBNull.Value);
                            //}
                            break;
                        case "System.DateTime":
                            DateTime datetime = DateTime.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            if (datetime != null)
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.DateTime, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            }
                            else
                            {
                                miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.DateTime, DBNull.Value);
                            }
                            break;
                        case "System.Boolean":
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Bit, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            break;
                        case "System.Byte[]":
                            object archiv = miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null);
                            if (archiv != null)
                            { miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.VarBinary, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null)); }
                            else
                            { miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.VarBinary, DBNull.Value); }
                            break;
                        case "System.TimeSpan":
                            TimeSpan timespan = TimeSpan.Parse(miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null).ToString());
                            miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.Time, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                            break;
                        //case "System.Byte[]":
                        //    miBD.AsignarParametro("@" + propertyInfo.Name, System.Data.SqlDbType.VarBinary, miClase.GetType().GetProperty(propertyInfo.Name).GetValue(miClase, null));
                        //    break;

                        default:
                            break;
                    }
                }
            }
            return true;
        }

        //metodo generico para selects//

        public static List<T> GenericSelect<T>(SqlDataReader dr, T estructura)
        {
            int cnt = 0;
            Int64 tantos = 0;
            List<T> TClases = new List<T>();
            while (dr.Read())
            {
                tantos += 1;
                T miClase = (T)Activator.CreateInstance(typeof(T));
                cnt = 0;
                foreach (PropertyInfo propertyInfo in estructura.GetType().GetProperties())
                {
                    miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, null, null);
                    String tipo = propertyInfo.PropertyType.ToString();
                    //var sjx = dr.GetValue(cnt);
                    switch (tipo)
                    {
                        case "System.String":
                            object t = dr.GetSqlValue(cnt).ToString();
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetValue(cnt).ToString() == "" ? " " : dr.GetSqlValue(cnt).ToString()), null);
                            break;
                        case "System.Int64":
                            Object a = dr.GetSqlValue(cnt);
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlInt64(cnt).IsNull ? 0 : dr.GetSqlInt64(cnt).Value), null);
                            break;
                        case "System.Int32":
                            var s = dr.GetValue(cnt);
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlInt32(cnt).IsNull ? 0 : dr.GetSqlInt32(cnt).Value), null);
                            break;
                        case "System.Single":
                            object l = dr.GetSqlValue(cnt);
                            string xa = l.GetType().ToString();
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDouble(cnt).IsNull ? 0 : Convert.ToSingle(dr.GetSqlDouble(cnt).Value)), null);
                            break;
                        case "System.Decimal":
                            object ll = dr.GetValue(cnt);
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDecimal(cnt).IsNull ? 0 : Convert.ToDecimal(dr.GetSqlDecimal(cnt).Value)), null);
                            break;
                        case "System.DateTime":
                            object lll = dr.GetValue(cnt);
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDateTime(cnt).IsNull ? new DateTime(1900, 1, 1) : dr.GetSqlDateTime(cnt).Value), null);
                            break;
                        case "System.Boolean":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlBoolean(cnt).IsNull ? false : Convert.ToBoolean(dr.GetSqlBoolean(cnt).Value)), null);
                            break;
                        case "System.Byte[]":
                            if (dr.GetValue(cnt) != DBNull.Value)
                            {
                                byte[] bytes = (byte[])dr.GetValue(cnt);
                                miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, bytes, null);
                            }
                            break;
                        case "System.TimeSpan":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (TimeSpan.Parse(dr.GetSqlValue(cnt).ToString()).Equals(null) ? new TimeSpan() : TimeSpan.Parse(dr.GetSqlValue(cnt).ToString())), null);
                            break;
                        default:
                            break;
                    }
                    cnt++;
                }
                TClases.Add(miClase);
            }
            dr.Close();
            return TClases;
        }

        public static T GenericSelectOne<T>(SqlDataReader dr, T estructura)
        {
            int cnt = 0;
            T miClase = (T)Activator.CreateInstance(typeof(T));
            while (dr.Read())
            {
                cnt = 0;
                foreach (PropertyInfo propertyInfo in estructura.GetType().GetProperties())
                {
                    miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, null, null);
                    String tipo = propertyInfo.PropertyType.ToString();
                    switch (tipo)
                    {
                        case "System.String":
                            object t = dr.GetSqlValue(cnt).ToString();
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetValue(cnt).ToString() == "" ? " " : dr.GetSqlValue(cnt).ToString()), null);
                            break;
                        case "System.Int64":
                            Object a = dr.GetSqlValue(cnt);
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlInt64(cnt).IsNull ? 0 : dr.GetSqlInt64(cnt).Value), null);
                            break;
                        case "System.Int32":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlInt32(cnt).IsNull ? 0 : dr.GetSqlInt32(cnt).Value), null);
                            break;
                        case "System.Single":
                            object l = dr.GetSqlValue(cnt);
                            string xa = l.GetType().ToString();
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDouble(cnt).IsNull ? 0 : Convert.ToSingle(dr.GetSqlDouble(cnt).Value)), null);
                            break;
                        case "System.Decimal":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDecimal(cnt).IsNull ? 0 : Convert.ToDecimal(dr.GetSqlDecimal(cnt).Value)), null);
                            break;
                        case "System.DateTime":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDateTime(cnt).IsNull ? new DateTime(1900, 1, 1) : dr.GetSqlDateTime(cnt).Value), null);
                            break;
                        case "System.Boolean":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlBoolean(cnt).IsNull ? false : Convert.ToBoolean(dr.GetSqlBoolean(cnt).Value)), null);
                            ///miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlBoolean(cnt).IsNull ? false : Convert.ToBoolean(dr.GetSqlBoolean(cnt).Value)), null);
                            break;
                        case "System.Byte[]":
                            if (dr.GetValue(cnt) != DBNull.Value)
                            {
                                byte[] bytes = (byte[])dr.GetValue(cnt);
                                miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, bytes, null);
                            }
                            break;
                        case "System.TimeSpan":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (TimeSpan.Parse(dr.GetSqlValue(cnt).ToString()).Equals(null) ? new TimeSpan() : TimeSpan.Parse(dr.GetSqlValue(cnt).ToString())), null);
                            break;
                    }
                    cnt++;
                }
            }
            dr.Close();
            return miClase;
        }

        public static void GenericSelectLote(ref List<Object> TClases, Object miClase, SqlDataReader dr)
        {
            int cnt = 0;
            while (dr.Read())
            {
                cnt = 0;
                foreach (PropertyInfo propertyInfo in miClase.GetType().GetProperties())
                {
                    miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, null, null);
                    String tipo = propertyInfo.PropertyType.ToString();
                    switch (tipo)
                    {
                        case "System.String":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlString(cnt).IsNull ? " " : dr.GetSqlString(cnt).Value), null);
                            break;
                        case "System.Int64":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlInt64(cnt).IsNull ? 0 : dr.GetSqlInt64(cnt).Value), null);
                            break;
                        case "System.Single":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDouble(cnt).IsNull ? 0 : dr.GetSqlDouble(cnt).Value), null);
                            break;
                        case "System.DateTime":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDateTime(cnt).IsNull ? new DateTime(1900, 1, 1) : dr.GetSqlDateTime(cnt).Value), null);
                            break;
                        case "System.Boolean":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlBoolean(cnt).IsNull ? false : Convert.ToBoolean(dr.GetSqlBoolean(cnt).Value)), null);
                            break;
                        case "System.Decimal":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDecimal(cnt).IsNull ? 0 : Convert.ToDecimal(dr.GetSqlDecimal(cnt).Value)), null);
                            break;
                        case "System.TimeSpan":
                            miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (TimeSpan.Parse(dr.GetSqlValue(cnt).ToString()).Equals(null) ? new TimeSpan() : TimeSpan.Parse(dr.GetSqlValue(cnt).ToString())), null);
                            break;
                        default:
                            break;
                    }
                    cnt++;
                }
                TClases.Add(miClase);
            }
        }

        //metodo generico para selects individuales//
        public static void GenericSelect(ref Object miClase, SqlDataReader dr)
        {
            int cnt = 0;
            dr.Read();
            cnt = 0;
            foreach (PropertyInfo propertyInfo in miClase.GetType().GetProperties())
            {
                miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, null, null);
                String tipo = propertyInfo.PropertyType.ToString();
                switch (tipo)
                {
                    case "System.String":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlString(cnt).IsNull ? " " : dr.GetSqlString(cnt).Value), null);
                        break;
                    case "System.Int64":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlInt64(cnt).IsNull ? 0 : dr.GetSqlInt64(cnt).Value), null);
                        break;
                    case "System.Single":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDouble(cnt).IsNull ? 0 : dr.GetSqlDouble(cnt).Value), null);
                        break;
                    case "System.DateTime":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDateTime(cnt).IsNull ? new DateTime(1900, 1, 1) : dr.GetSqlDateTime(cnt).Value), null);
                        break;
                    case "System.Boolean":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlBoolean(cnt).IsNull ? false : Convert.ToBoolean(dr.GetSqlBoolean(cnt).Value)), null);
                        break;
                    case "System.Decimal":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (dr.GetSqlDecimal(cnt).IsNull ? 0 : Convert.ToDecimal(dr.GetSqlDecimal(cnt).Value)), null);
                        break;
                    case "System.TimeSpan":
                        miClase.GetType().GetProperty(propertyInfo.Name).SetValue(miClase, (TimeSpan.Parse(dr.GetSqlValue(cnt).ToString()).Equals(null) ? new TimeSpan() : TimeSpan.Parse(dr.GetSqlValue(cnt).ToString())), null);
                        break;
                    default:
                        break;
                }
                cnt++;
            }
        }
    }
}
