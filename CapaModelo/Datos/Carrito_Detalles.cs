using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Carrito_Detalles
    {
        /// <summary>
        /// Definición de parámetros de la clase y table Carrito_Detalles.
        /// </summary>
        private int _Id;
        private string _ProdId;

        /// <summary>
        /// Definición de variables de manejo de datos en base de datos.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Definición de encapsulamiento de parámetros Id y ProdId.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string ProdId
        {
            get { return _ProdId; }
            set { _ProdId = value; }
        }

        public Carrito_Detalles(SqlConnection conexion)
        {
            this.conexion = conexion;
        }

        /// <summary>
        /// Métodos para realizar las transacciones en la base de datos.
        /// </summary>
        /// <returns>Regresa el valor cierto o falso dependiendo de que la transacción SQL se haya realizado.</returns>
        public bool Agregar_Carrito_Detalles()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_CREAR_CARRITO_DETALLES", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@IDCARRITO", SqlDbType.Int).Value = this.Id;
                this.comando.Parameters.Add("@PRODUCTO", SqlDbType.VarChar).Value = this.ProdId;

                
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

        public bool Leer_Carrito_Detalles()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_LEER_CARRITO_DETALLES", this.conexion);
                this.comando.CommandType = CommandType.StoredProcedure;

                this.comando.Parameters.Add("@IDCARRITO", SqlDbType.Int).Value = this.Id;

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

        public bool Todos_Carrito_Detalles()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_TODOS_CARRITOS_DETALLES", this.conexion);
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
            this.ProdId = null;
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


        ~Carrito_Detalles()
        {
            this.Dispose();
        }
    }
}
