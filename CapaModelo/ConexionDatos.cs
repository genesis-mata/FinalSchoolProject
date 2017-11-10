using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace CapaModelo
{
    [Serializable]
    class ConexionDatos : IDisposable
    {
        /// <summary>
        /// Parámetros de  conexión de base de datos.
        /// </summary>
        private string Servidor;
        private string Puerto;
        private string Usuario;
        private string Password;
        private string BaseDatos;
        private string Conexion;
        private string Serializado;
        private bool _Vacio;
        [NonSerialized]
        private SqlConnection ConexionSQL;

        public ConexionDatos()
        {
            this.Serializado = "ConexionDatos.dbx";
            this.Vacio = true;
        }

        public bool Vacio
        {
            get { return _Vacio; }
            set { _Vacio = value; }
        }

        public void ConfigurarConexionDatos()
        {
            this.Conexion = "Data Source = " + this.Servidor + "," + this.Puerto + ";Initial Catalog = " + this.BaseDatos + ";User Id = " + this.Usuario + ";Password = " + this.Password + ";";
            this.ConexionSQL = new SqlConnection(this.Conexion);
            if (this.PruebaConexion().Equals(true))
            {
                Console.WriteLine("Conexión correcta");
                this.Vacio = false;
            }
        }
        
        /// <summary>
        /// Constructor de la clase "ConexionDatos" que genera la cadena de conexión para ser utilizada posteriormente.
        /// </summary>
        /// <param name="Servidor"></param>
        /// <param name="Puerto"></param>
        /// <param name="Usuario"></param>
        /// <param name="Password"></param>
        /// <param name="BaseDatos"></param>
        public void ConfigurarConexionDatos(string Servidor, string Puerto, string Usuario, string Password, string BaseDatos)
        {
            this.Servidor = Servidor;
            if (Puerto == null || Puerto == "")
            {
                this.Puerto = "1433";
            }
            else
            {
                this.Puerto = Puerto;
            }
            this.Usuario = Usuario;
            this.Password = Password;
            this.BaseDatos = BaseDatos;

            ConfigurarConexionDatos();
            this.Serializar();
        }

        /// <summary>
        /// Implementación de la interface Disposable para realizar la serialización de la información y guardarla en un archivo para reutilizarla en las siguientes ejecuciones.
        /// </summary>
        private void Serializar()
        {
            IFormatter Formato = new BinaryFormatter();
            Stream Flujo = new FileStream(Serializado, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            Formato.Serialize(Flujo, this);
            Flujo.Close();
        }

        /// <summary>
        /// Método para realizar pruebas de conexión de la base de datos.
        /// </summary>
        /// <returns></returns>
        public bool PruebaConexion()
        {
            bool Resultado = false;
            try
            {
                ConexionSQL.ConnectionString = Conexion;
                ConexionSQL.Open();
                if (ConexionSQL.State == ConnectionState.Open)
                {
                    Resultado = true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                ConexionSQL.Close();
            }
            return Resultado;
        }

        /// <summary>
        /// Método para cerrar la conexión de la base de datos.
        /// </summary>
        public void Cerrar()
        {
            if (this.ConexionSQL.State == ConnectionState.Open)
            {
                ConexionSQL.Close();
            }
        }

        /// <summary>
        /// Método para obtener la conexión a la base de datos.
        /// </summary>
        /// <returns></returns>
        public SqlConnection Obtener_Conexion()
        {
            return this.ConexionSQL;
        }

        /// <summary>
        /// Destructor default de la clase.
        /// </summary>
        public void Dispose()
        {
            this.Servidor = null;
            this.Puerto = null;
            this.Usuario = null;
            this.Password = null;
            this.BaseDatos = null;
            this.Conexion = null;
            this.Serializado = null;
        }
    }
}
