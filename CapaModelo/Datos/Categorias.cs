using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo.Datos
{
    class Categorias
    {
        /// <summary>
        /// Definición de parámetros de la clase y tabla.
        /// </summary>
        private int _Id;
        private string _Nombre;

        /// <summary>
        /// Parámetros de conexión y manejo de datos en base de datos.
        /// </summary>
        private SqlCommand comando;
        private SqlDataReader lector;
        private SqlDataAdapter tablas;
        private SqlConnection conexion;
        private DataTable Tabla_Productos;

        /// <summary>
        /// Definición de encapsulamiento de parámetros de la clase.
        /// </summary>
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public Categorias(SqlConnection conexion)
        {
            this.conexion = new SqlConnection();
            this.conexion = conexion;
        }

        /// <summary>
        /// Métodos para la manipulación de datos en la base de datos.
        /// </summary>
        /// <returns></returns>
        public bool Agregar_Categoría()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_AGREGAR_CATEGORIA", this.conexion);
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
        
        public bool Leer_Categoría()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_LEER_CATEGORIA", this.conexion);
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

        public bool Actualizar_Categoría()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_ACTUALIZAR_CATEGORIA", this.conexion);
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

        public bool Borrar_Categoría()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_BORRAR_CATEGORIA", this.conexion);
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

        public bool Todas_Categoría()
        {
            bool Resultado = false;

            try
            {
                this.conexion.Open();
                this.comando = new SqlCommand("SP_TODAS_CATEGORIA", this.conexion);
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
            this.Nombre = null;
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

        ~Categorias()
        {
            this.Dispose();
        }
    }
}
