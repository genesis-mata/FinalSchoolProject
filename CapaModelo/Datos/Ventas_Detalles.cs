using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Ventas_Detalles
    {
        /// <summary>
        /// Parámetros de la clase y tabla en la base de datos.
        /// </summary>
        private int _IdVenta;
        private string _Producto;
        private string _Presentacion;
        private int _Cantidad;

        /// <summary>
        /// Parámetros para la manipulación de datos en la base de datos. 
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Encapsulamiento de parámetros 
        /// </summary>
        public int IdVenta
        {
            get { return _IdVenta; }
            set { _IdVenta = value; }
        }

        public string Producto
        {
            get { return _Producto; }
            set { _Producto = value; }
        }

        public string Presentacion
        {
            get { return _Presentacion; }
            set { _Presentacion = value; }
        }

        public int Cantidad
        {
            get { return _Cantidad; }
            set { _Cantidad = value; }
        }

        public Ventas_Detalles(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Método para agregar los detalles de las ventas realizadas.
        /// </summary>
        /// <param name="idVenta">Id de la venta realizada.</param>
        /// <param name="producto">Nombre del producto que se adquirió.</param>
        /// <param name="presentacion">Representación de la presentación del producto que se adquirió.</param>
        /// <param name="cantidad">Representación de la cantidad de productos que se adquirieron en la compra.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Agregar_Venta_Detalles()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_AGREGAR_VENTAS_DETALLES", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@IDVENTA", SqlDbType.VarChar).Value = this.IdVenta;
                this.comando.Parameters.Add("@PRODUCTO", SqlDbType.VarChar).Value = this.Producto;
                this.comando.Parameters.Add("@PRESENTACION", SqlDbType.VarChar).Value = this.Presentacion;
                this.comando.Parameters.Add("@CANTIDAD", SqlDbType.VarChar).Value = this.Cantidad;

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
        /// <param name="id">Representación de la id de la venta a leer.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Leer_Venta_Detalles()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_LEER_VENTA_DETALLES", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@ID", SqlDbType.VarChar).Value = this.IdVenta;

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
        public bool Todas_Venta_Detalles()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_TODAS_VENTAS_DETALLES", this.conexion);
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
                this.IdVenta = 0;
                this.Producto = "";
                this.Presentacion = "";
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

        /// <summary>
        /// Destructor por default.
        /// 
        /// </summary>
        ~Ventas_Detalles()
        {
            this.Dispose();
        }
    }
}
