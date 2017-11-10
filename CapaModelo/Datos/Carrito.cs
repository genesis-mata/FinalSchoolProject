using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Carrito : IDisposable
    {
        /// <summary>
        /// Parámetros para la clase y tabla Categoría
        /// </summary>
        private int _id;
        private DateTime _fecha;

        /// <summary>
        /// Manejadores de datos de la base de datos.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Definición de encapsulamiento de los parámetros Id y Fecha.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        /// <summary>
        /// Constructor por defecto para configurar la conexión y realizar transacciones.
        /// </summary>
        /// <param name="conexion">Contiene la información del servidor SQL para la conexión al mismo.</param>
        public Carrito(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Método para agregar un carrito de compras.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Agregar_Carrito(){
            bool Resultado = false;
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_AGREGAR_CARRITO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                
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
        /// Método para leer la información de un carrito de compras.
        /// </summary>
        /// <param name="id">Parámetro utilizado para localizar el carrito deseado</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Leer_Carrito()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_LEER_CARRITO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id;

                
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
        /// Método que borra un carrito seleccionado.
        /// </summary>
        /// <param name="id">Parámetro para localizar el carrito a borrar</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Borrar_Carrito()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_BORRAR_CARRITO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@ID", SqlDbType.Int).Value = this.Id;

                
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
        /// Método que retorna todos los carritos registrados.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado/returns>
        public bool Todos_Carritos()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_TODOS_CARRITOS", this.conexion);
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
        /// Método disposable para anular toda la información y desechar la instancia de la clase.
        /// </summary>
        public void Dispose()
        {
            this.Id = 0;
            this.Fecha = DateTime.Parse(null);
            this.comando = null;
            this.lector = null;
            this.conexion = null;
        }

        private void Cerrar_Conexion()
        {
            if (this.conexion.State == ConnectionState.Open)
            {
                this.conexion.Close();
            }
        }


        ~Carrito()
        {
            this.Dispose();
        }
    }
}
