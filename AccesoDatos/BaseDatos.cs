using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class BaseDatos
    {
        private SqlConnection conexion = new SqlConnection();
        private SqlCommand comando = new SqlCommand();
        private SqlTransaction transaccion = null;
        private static SqlClientFactory factory = null;
        private static Conexion conexion_bd = new Conexion();

        public BaseDatos()
        {
            Configurar();
        }


        private void Configurar()
        {
            try
            {
                factory = SqlClientFactory.Instance;
                this.conexion = (SqlConnection)factory.CreateConnection();
                this.conexion.ConnectionString = conexion_bd.cadena_conexion;
            }
            catch (ConfigurationException ex)
            {
                throw new BaseDatosException("Error al cargar la configuración del acceso a datos.", ex);
            }
        }


        public void Desconectar()
        {
            this.conexion.Close();
        }

        public void Conectar()
        {
            if (this.conexion != null && !this.conexion.State.Equals(ConnectionState.Closed))
            {
                throw new BaseDatosException("La conexión ya se encuentra abierta.");
            }
            try
            {
                this.conexion.Open();
            }
            catch (DataException ex)
            {
                throw new BaseDatosException("Error al conectarse a la Base de Datos.", ex);
            }
        }

        public void CrearComando(string sentenciaSQL)
        {
            this.comando = (SqlCommand)factory.CreateCommand();
            this.comando.Transaction = this.transaccion;
            this.comando.CommandTimeout = 8000;
            this.comando.Connection = conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = sentenciaSQL;
        }

        public void AsignarParametro(string nombre, System.Data.SqlDbType tipo, object valor)
        {
            SqlParameter elParametro = new SqlParameter();
            elParametro.ParameterName = nombre;
            elParametro.SqlDbType = tipo;
            elParametro.Value = valor;
            comando.Parameters.Add(elParametro);
        }

        public void AsignarParametro_Tamaño(string nombre, System.Data.SqlDbType tipo, int tamaño, object valor)
        {
            SqlParameter elParametro = new SqlParameter();
            elParametro.ParameterName = nombre;
            elParametro.SqlDbType = tipo;
            elParametro.Value = valor;
            elParametro.Size = tamaño;
            comando.Parameters.Add(elParametro);
        }

        public void AsignarParametro_TypeName(string nombre, System.Data.SqlDbType tipo, object valor, string typeName)
        {
            SqlParameter elParametro = new SqlParameter();
            elParametro.ParameterName = nombre;
            elParametro.SqlDbType = tipo;
            elParametro.TypeName = typeName;
            elParametro.Value = valor;
            comando.Parameters.Add(elParametro);
        }

        public SqlDataReader EjecutarConsulta()
        {
            SqlDataReader Consulta = this.comando.ExecuteReader();
            return Consulta;
        }

        public int EjecutarEscalar()
        {
            int escalar = 0;
            try
            {
                escalar = int.Parse(this.comando.ExecuteScalar().ToString());
            }
            catch (InvalidCastException ex)
            {
                throw new BaseDatosException("Error al ejecutar un escalar.", ex);
            }
            return escalar;
        }

        public void EjecutarComando()
        {
            this.comando.ExecuteNonQuery();
        }

        public void ComenzarTransaccion()
        {
            this.transaccion = this.conexion.BeginTransaction();
        }

        public void CancelarTransaccion()
        {
            if (this.transaccion != null)
            {
                this.transaccion.Rollback();
            }
        }

        public void ConfirmarTransaccion()
        {
            if (this.transaccion != null)
            {
                this.transaccion.Commit();
            }
        }
    }
}
