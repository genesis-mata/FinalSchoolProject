using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Ventas
    {
        /// <summary>
        /// Parámetros de la clase y tabla Ventas
        /// </summary>
        private int _Id;
        private string _IdUsuario;
        private DateTime _Fecha;
        private double _Cantidad;

        /// <summary>
        /// Parámetros de manipulación de datos en la base de datos.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Definición de encapsulamiento de parámetros Id, IdUsuario, Fecha y Cantidad.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        public double Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        /// <summary>
        /// Contructor para la inicialización de las transacciones de la clase.
        /// </summary>
        /// <param name="conexion">Representación de los parámetros necesarios para realizar la conexión a la base de datos especificada.</param>
        public Ventas(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Método para agregar una venta en la base de datos.
        /// </summary>
        /// <param name="idUsuario">Representación de la id del usuario realizando la venta.</param>
        /// <param name="cantidad">Representación de la cantidad del precio.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Agregar_Venta()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_AGREGAR_VENTA", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@USUARIO", SqlDbType.VarChar).Value = this.IdUsuario;
                this.comando.Parameters.Add("@CANTIDAD", SqlDbType.VarChar).Value = this.Cantidad;
                
                
                this.lector = this.comando.ExecuteReader();
                this.lector.Read();
                this.Id = int.Parse(this.lector.GetValue(0).ToString());

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
        /// Método para agregar una venta en la base de datos.
        /// </summary>
        /// <param name="id">Representación de la id de la venta a leer.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Leer_Venta()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_LEER_VENTAS", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@ID", SqlDbType.VarChar).Value = this.Id;

                
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
        /// Método para agregar una venta en la base de datos.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Todas_Venta()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_TODAS_VENTAS", this.conexion);
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
                this.Id = 0;
                this.IdUsuario = null;
                this.Cantidad = 0;
                this.comando = null;
                this.lector = null;
                this.conexion = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ~Ventas()
        {
            this.Dispose();
        }
    }
}
