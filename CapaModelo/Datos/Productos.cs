using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Productos : IDisposable
    {
        /// <summary>
        /// Variables de la clase y tabla de datos Productos
        /// </summary>
        private int _id;
        private string _SKU;
        private string _Nombre;
        private string _Descripcion_Corta;
        private string _Descripcion_Larga;
        private string _Categoria;
        private double _Precio;
        private string _Presentacion;
        private int _Cantidad;

        /// <summary>
        /// Manejadores de datos de la base de datos.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;


        /// <summary>
        /// Definición de encapsulamientos de los parámetros Id, SKU, Nombre, Descripcion_Corta, Descripcion_Larga, Categoría, Precio, Presentacion y Cantidad.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string SKU
        {
            get { return _SKU; }
            set { _SKU = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Descripcion_Corta
        {
            get { return _Descripcion_Corta; }
            set { _Descripcion_Corta = value; }
        }

        public string Descripcion_Larga
        {
            get { return _Descripcion_Larga; }
            set { _Descripcion_Larga = value; }
        }

        public string Categoria
        {
            get { return _Categoria; }
            set { _Categoria = value; }
        }

        public double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
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

        /// <summary>
        /// Constructor que define la conexión para las transacciones a realizar para productos.
        /// </summary>
        /// <param name="conexion">Es la información de conexión al servidor SQL asignado a esta aplicación</param>
        public Productos(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Método para agregar un nuevo producto
        /// </summary>
        /// <param name="SKU">Parámetro que representa el identificador único universal del producto.</param>
        /// <param name="Nombre">Parámetro representante del nomnbre del producto.</param>
        /// <param name="Descripcion_C">Parámetro representante de la descripción corta del producto.</param>
        /// <param name="Descripcion_L">Parámetro representante de la descripción larga del producto.</param>
        /// <param name="Categoria"¨>Parámetro que representa, por nombre, la categoría a la que pertenece.</param>
        /// <param name="Precio">Parámetro que representa el precio del producto en tienda.</param>
        /// <param name="Presentacion">Parámetro que representa, por nombre, la presentación del producto.</param>
        /// <param name="Cantidad">Parámetro que representa la cantidad de articulos del mismo que se adquirieron.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Agregar_Producto()
        {
            bool Resultado = false;
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_AGREGAR_PRODUCTO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@SKU", SqlDbType.VarChar).Value = this.SKU;
                this.comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = this.Nombre;
                this.comando.Parameters.Add("@DESCRIPCION_CORTA", SqlDbType.VarChar).Value = this.Descripcion_Corta;
                this.comando.Parameters.Add("@DESCRIPCION_LARGA", SqlDbType.VarChar).Value = this.Descripcion_Larga;
                this.comando.Parameters.Add("@CATEGORIA", SqlDbType.VarChar).Value = this.Categoria;
                this.comando.Parameters.Add("@PRECIO", SqlDbType.VarChar).Value = this.Precio;
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
        /// Método para adquirir los productos de acuerdo con parcialidades del nombre.
        /// </summary>
        /// <param name="Nombre">Parámetro parcial o total del nombre del producto.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Leer_Producto()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_LEER_PRODUCTO", this.conexion);
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
        /// Método para actualizar un producto existente.
        /// </summary>
        /// <param name="SKU">Parámetro que representa el identificador único universal del producto.</param>
        /// <param name="Nombre">Parámetro representante del nomnbre del producto.</param>
        /// <param name="Descripcion_C">Parámetro representante de la descripción corta del producto.</param>
        /// <param name="Descripcion_L">Parámetro representante de la descripción larga del producto.</param>
        /// <param name="Categoria"¨>Parámetro que representa, por nombre, la categoría a la que pertenece.</param>
        /// <param name="Precio">Parámetro que representa el precio del producto en tienda.</param>
        /// <param name="Presentacion">Parámetro que representa, por nombre, la presentación del producto.</param>
        /// <param name="Cantidad">Parámetro que representa la cantidad de articulos del mismo que se adquirieron.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Actualizar_Producto()
        {
            bool Resultado = false;
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_ACTUALIZAR_PRODUCTO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@SKU", SqlDbType.VarChar).Value = this.SKU;
                this.comando.Parameters.Add("@NOMBRE", SqlDbType.VarChar).Value = this.Nombre;
                this.comando.Parameters.Add("@DESCCRIPCION_CORTA", SqlDbType.VarChar).Value = this.Descripcion_Corta;
                this.comando.Parameters.Add("@DESCRIPCION_LARGA", SqlDbType.VarChar).Value = this.Descripcion_Larga;
                this.comando.Parameters.Add("@CATEGORIA", SqlDbType.VarChar).Value = this.Categoria;
                this.comando.Parameters.Add("@PRECIO", SqlDbType.VarChar).Value = this.Precio;
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
        /// Método para eliminar un producto.
        /// </summary>
        /// <param name="SKU">Parámetro representante dek número identificador del producto.</param>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public bool Borrar_Producto()
        {
            bool Resultado = false;
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_BORRAR_PRODUCTO", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@SKU", SqlDbType.VarChar).Value = SKU;

                
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
        /// Método que lee todos los productos en la base de datos.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado</returns>
        public DataTable Todos_Productos()
        {
            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_TODOS_PRODUCTOS", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.tablas = new SqlDataAdapter(this.comando);
                this.Tabla_Productos = new DataTable();
                this.tablas.Fill(this.Tabla_Productos);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            finally
            {
                this.Cerrar_Conexion();
            }

            return Tabla_Productos;
        }

        /// <summary>
        /// Método para terminar y anular las variables utilizadas en el tiempo de vida de la instancia.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.Id = 0;
                this.SKU = string.Empty;
                this.Nombre = string.Empty;
                this.Descripcion_Corta = string.Empty;
                this.Descripcion_Larga = string.Empty;
                this.Categoria = string.Empty;
                this.Precio = 0.0;
                this.Presentacion = string.Empty;
                this.Cantidad = 0;
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


        ~Productos()
        {
            this.Dispose();
        }
    }
}
