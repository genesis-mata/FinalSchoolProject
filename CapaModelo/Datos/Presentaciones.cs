using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Presentaciones : IDisposable
    {
        /// <summary>
        /// Variables de la clase y tabla Presentación.
        /// </summary>
        private int _id;
        private string _nombre;

        /// <summary>
        /// Variables de manejo de datos SQL.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Definición de encapsulamiento de los parámetros Id y Nombre.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Constructor principal que recibe la conexión SQL para realizar las actividades requeridas.
        /// </summary>
        /// <param name="conexion">Contiene los parámetros necesarios para realizar la conexión a la base de datos.</param>
        public Presentaciones(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Método para agregar una nueva presentación a la lista  de disponibles.
        /// </summary>
        /// <param name="Nombre">Representación de la presentación seleccionada a ser agregada.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Agregar_Presentacion()
        {
            bool Resultado = false;

            try
            {
                this.comando = new SqlCommand("SP_AGREGAR_PRESENTACION", conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = this.Nombre;

                
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
        /// Método para leer la información de una presentación en la base de datos.
        /// </summary>
        /// <param name="Nombre">Representación alphanumérica de una presentación de producto.</param>
        /// <returns></returns>
        public bool Leer_Presentacion()
        {
            bool Resultado = false;

            try
            {
                this.comando = new SqlCommand("SP_LEER_PRESENTACION", conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = this.Nombre;

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
        /// Método para actualizar una presentación a la lista disponible.
        /// </summary>
        /// <param name="id">Parámetro para identificar la presentación a actualizar.</param>
        /// <param name="Nombre">Nombre de la presentación actualizado.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado></returns>
        public bool Actualizar_Presentacion()
        {
            bool Resultado = false;

            try
            {
                this.comando = new SqlCommand("SP_AGREGAR_PRESENTACION", conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id;
                this.comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = this.Nombre;

                
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
        /// Método para borrar una presentación existente.
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Borrar_Presentacion()
        {
            bool Resultado = false;

            try
            {
                this.comando = new SqlCommand("SP_BORRAR_PRESENTACION", conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = this.Nombre;

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

        public bool Todas_Presentaciones()
        {
            bool Resultado = false;

            try
            {
                this.comando = new SqlCommand("SP_TODAS_PRESENTACIONES", conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

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

        /// <summary>
        /// Método para terminar y anular las variables utilizadas en el tiempo de vida de la instancia.
        /// </summary>
        public void Dispose()
        {
            try{
                this.Id = 0;
                this.Nombre = null;
                this.comando = null;
                this.lector = null;
                this.conexion = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
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


        ~Presentaciones()
        {
            this.Dispose();
        }
    }
}
