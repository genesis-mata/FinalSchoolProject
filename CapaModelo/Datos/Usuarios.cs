using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Usuarios : IDisposable
    {
        /// <summary>
        /// Variables de la clase Usuarios y tablas tblLOGIN y tblUSUARIOS
        /// </summary>
        private int _Id;
        private string _Usuario;
        private string _Password;
        private int _Nivel_Acceso;
        private string _Primer_Nombre;
        private string _Segundo_Nombre;
        private string _Primer_Apellido;
        private string _Segundo_Apellido;
        private string _Direccion1;
        private string _Direccion2;
        private string _Municipio;
        private string _Ciudad;
        private string _Estado;
        private int _Codigo_Postal;

        /// <summary>
        /// Variables para trabajar con la base de datos.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Definición de encapsulamientos de los parámetros Id, Usuario, Password, Primer_Nombre, Segundo_Nombre, Primer_Apellido, Segundo_Apellido, Direccion1, Direccion2, Municipio, Ciudad, Estado y Codigo_Postal.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public int Nivel_Acceso
        {
            get { return _Nivel_Acceso; }
            set { _Nivel_Acceso = value; }
        }

        public string Primer_Nombre
        {
            get { return _Primer_Nombre; }
            set { _Primer_Nombre = value; }
        }

        public string Segundo_Nombre
        {
            get { return _Segundo_Nombre; }
            set { _Segundo_Nombre = value; }
        }

        public string Primer_Apellido
        {
            get { return _Primer_Apellido; }
            set { _Primer_Apellido = value; }
        }

        public string Segundo_Apellido
        {
            get { return _Segundo_Apellido; }
            set { _Segundo_Apellido = value; }
        }

        public string Direccion1
        {
            get { return _Direccion1; }
            set { _Direccion1 = value; }
        }

        public string Direccion2
        {
            get { return _Direccion2; }
            set { _Direccion2 = value; }
        }

        public string Municipio
        {
            get { return _Municipio; }
            set { _Municipio = value; }
        }

        public string Ciudad
        {
            get { return _Ciudad; }
            set { _Ciudad = value; }
        }

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }

        public int Codigo_Postal
        {
            get { return _Codigo_Postal; }
            set { _Codigo_Postal = value; }
        }

        public Usuarios(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Método para agregar un nuevo usuario a la base de datos.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Agregar_Usuario()
        {
            bool Resultado = false;
            try
            {
                if (!this.conexion.State.Equals(ConnectionState.Open))
                {
                    this.conexion.Open();
                }
                this.comando = new SqlCommand("SP_AGREGAR_USUARIO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = this.Usuario;
                this.comando.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = this.Password;
                this.comando.Parameters.Add("@NIVELACCESO", SqlDbType.Int).Value = this.Nivel_Acceso;
                this.comando.Parameters.Add("@PNOMBRE", SqlDbType.VarChar).Value = this.Primer_Nombre;
                this.comando.Parameters.Add("@SNOMBRE", SqlDbType.VarChar).Value = this.Segundo_Nombre;
                this.comando.Parameters.Add("@PAPELLIDO", SqlDbType.VarChar).Value = this.Primer_Apellido;
                this.comando.Parameters.Add("@SAPELLIDO", SqlDbType.VarChar).Value = this.Segundo_Apellido;
                this.comando.Parameters.Add("@DIRECCION1", SqlDbType.VarChar).Value = this.Direccion1;
                this.comando.Parameters.Add("@DIRECCION2", SqlDbType.VarChar).Value = this.Direccion2;
                this.comando.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = this.Municipio;
                this.comando.Parameters.Add("@CIUDAD", SqlDbType.VarChar).Value = this.Ciudad;
                this.comando.Parameters.Add("@EStADO", SqlDbType.VarChar).Value = this.Estado;
                this.comando.Parameters.Add("@CODIGO_POSTAL", SqlDbType.Int).Value = this.Codigo_Postal;

                this.lector = this.comando.ExecuteReader();

                Resultado = true;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Resultado;
        }

        /// <summary>
        /// Método para leer un usuario desde la base de datos y obtener su información.
        /// </summary>
        /// <param name="usuario">Representa el nombre de usuario a buscar en la base de datos.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Leer_Usuario()
        {
            bool Resultado = false;

            try
            {
                if (!this.conexion.State.Equals(ConnectionState.Open))
                {
                    this.conexion.Open();
                }
                this.comando = new SqlCommand("SP_LEER_USUARIO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = this.Usuario;
                
                this.lector = this.comando.ExecuteReader();
                while (lector.Read())
                {
                    this.Primer_Nombre = this.lector.GetValue(2).ToString();
                    this.Segundo_Nombre = this.lector.GetValue(3).ToString();
                    this.Primer_Apellido = this.lector.GetValue(4).ToString();
                    this.Segundo_Apellido = this.lector.GetValue(5).ToString();
                    this.Direccion1 = this.lector.GetValue(6).ToString();
                    this.Direccion2 = this.lector.GetValue(7).ToString();
                    this.Ciudad = this.lector.GetValue(8).ToString();
                    this.Estado = this.lector.GetValue(9).ToString();
                    this.Codigo_Postal = int.Parse(this.lector.GetValue(11).ToString());
                }

                Resultado = true;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Resultado;
        }

        /// <summary>
        /// Método para agregar un nuevo usuario a la base de datos.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Actualizar_Usuario()
        {
            bool Resultado = false;
            try
            {
                if (!this.conexion.State.Equals(ConnectionState.Open))
                {
                    this.conexion.Open();
                }
                this.comando = new SqlCommand("SP_ACTUALIZAR_USUARIO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id;
                this.comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = this.Usuario;
                this.comando.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = this.Password;
                this.comando.Parameters.Add("@PNOMBRE", SqlDbType.VarChar).Value = this.Primer_Nombre;
                this.comando.Parameters.Add("@SNOMBRE", SqlDbType.VarChar).Value = this.Segundo_Nombre;
                this.comando.Parameters.Add("@PAPELLIDO", SqlDbType.VarChar).Value = this.Primer_Apellido;
                this.comando.Parameters.Add("@SAPELLIDO", SqlDbType.VarChar).Value = this.Segundo_Apellido;
                this.comando.Parameters.Add("@DIRECCION1", SqlDbType.VarChar).Value = this.Direccion1;
                this.comando.Parameters.Add("@DIRECCION2", SqlDbType.VarChar).Value = this.Direccion2;
                this.comando.Parameters.Add("@MUNICIPIO", SqlDbType.VarChar).Value = this.Municipio;
                this.comando.Parameters.Add("@CIUAD", SqlDbType.VarChar).Value = this.Ciudad;
                this.comando.Parameters.Add("@EStADO", SqlDbType.VarChar).Value = this.Estado;
                this.comando.Parameters.Add("@CODIGO_POSTAL", SqlDbType.Int).Value = this.Codigo_Postal;

                
                this.lector = this.comando.ExecuteReader();

                Resultado = true;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Resultado;
        }

        /// <summary>
        /// Método para leer un usuario desde la base de datos y obtener su información.
        /// </summary>
        /// <param name="usuario">Representa el nombre de usuario a buscar en la base de datos.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Borrar_Usuario()
        {
            bool Resultado = false;

            try
            {
                if (!this.conexion.State.Equals(ConnectionState.Open))
                {
                    this.conexion.Open();
                }
                this.comando = new SqlCommand("SP_BORRAR_USUARIO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = this.Usuario;
                
                this.lector = this.comando.ExecuteReader();

                Resultado = true;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Resultado;
        }

        /// <summary>
        /// Método que recupera todos los usuarios y su información de la base de datos.
        /// </summary>
        /// <param name="usuario">Repesentación del nombre de usuario a procesar.</param>
        /// <returns></returns>
        public bool Todos_Usuario()
        {
            bool Resultado = false;

            try
            {
                if (!this.conexion.State.Equals(ConnectionState.Open))
                {
                    this.conexion.Open();
                }
                this.comando = new SqlCommand("SP_TODOS_USUARIO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = this.Usuario;

                this.tablas = new SqlDataAdapter(this.comando);
                this.Tabla_Productos = new DataTable();
                this.tablas.Fill(this.Tabla_Productos);

                Resultado = true;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Resultado;
        }


        public bool IngresarApp()
        {
            bool Resultado = false;

            try
            {
                if (!this.conexion.State.Equals(ConnectionState.Open))
                {
                    this.conexion.Open();
                }
                this.comando = new SqlCommand("SP_INGRESAR_APP", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = this.Usuario;
                this.comando.Parameters.Add("@Contrasena", SqlDbType.VarChar).Value = this.Password;

                this.lector = this.comando.ExecuteReader();
                while (lector.Read())
                {
                    this.Id = int.Parse(this.lector.GetSqlInt32(0).ToString());
                    this.Usuario = this.lector.GetString(1);
                    this.Nivel_Acceso = int.Parse(this.lector.GetValue(3).ToString());
                }
                this.lector.Close();
                this.Leer_Usuario();

                Resultado = true;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Resultado;
        }


        public string[] Datos()
        {
            string[] Datos = {this.Primer_Nombre, this.Segundo_Nombre, this.Primer_Apellido, this.Segundo_Apellido, this.Nivel_Acceso.ToString()};
            return Datos;
        }

        /// <summary>
        /// Método para cerrar la conexión a la base de datos que no está siendo utilizada.
        /// </summary>
        private void Cerrar_Conexion()
        {
            if (this.conexion.State == ConnectionState.Open)
            {
                this.conexion.Close();
            }
        }

        /// <summary>
        /// Método para terminar y anular las variables utilizadas en el tiempo de vida de la instancia.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.Usuario = null;
                this.Password = null;
                this.Primer_Nombre = null;
                this.Segundo_Nombre = null;
                this.Primer_Apellido = null;
                this.Segundo_Apellido = null;
                this.Direccion1 = null;
                this.Direccion2 = null;
                this.Municipio = null;
                this.Ciudad = null;
                this.Estado = null;
                this.Codigo_Postal = 0;
                this.comando = null;
                this.lector = null;
                this.conexion = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ~Usuarios()
        {
            this.Dispose();
        }
    }
}
