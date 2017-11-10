using System;
using CapaModelo.Datos;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Data;

namespace CapaModelo
{
    [Serializable]
    public class Transacciones
    {
        /// <summary>
        /// Parámetros con los que trabajaremos las transacciones.
        /// </summary>
        private ConexionDatos BaseDatos;
        private string Serializado;
        private Carrito carrito;
        private Carrito_Detalles carrito_detalles;
        private Categorias categoria;
        private Presentaciones presentacion;
        private Productos productos;
        private Usuarios usuario;
        private Ventas venta;
        private Ventas_Detalles venta_detalles;
        private DataTable _DatosActuales;
        private string[] Datos;


        /// <summary>
        /// Setter  y Getter para la tabla de trabajo actual.
        /// </summary>
        public DataTable DatosActuales
        {
            get { return _DatosActuales; }
            set { _DatosActuales = value; }
        }

        /// <summary>
        /// Contructor principal para la generación o recuperación de la base de datos.
        /// </summary>
        public Transacciones()
        {
            this.Serializado = "ConexionDatos.dbx";
            BinaryFormatter br = new BinaryFormatter();
            if(File.Exists(Serializado)){
                FileStream Archivo = new FileStream(Serializado, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                try{
                    using (Archivo){
                        this.BaseDatos = new ConexionDatos();
                        this.BaseDatos = (ConexionDatos) br.Deserialize(Archivo);
                        this.BaseDatos.ConfigurarConexionDatos();
                    }
                }catch(FileLoadException fileEx){
                    throw fileEx;
                }
                Archivo.Close();
            }
            else
            {
                this.BaseDatos = new ConexionDatos();
            }

            this.DatosActuales = new DataTable();
        }
        /// <summary>
        /// Método para la realización de transacciones relacionadas con los carritos.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool Trasaccion_Carrito(int opcion, int Id = 0)
        {
            bool Resultado = false;

            try
            {
                this.carrito = new Carrito(this.BaseDatos.Obtener_Conexion());
                this.carrito.Id = Id;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.carrito.Agregar_Carrito();
                            break;
                    case 2: /*this.DatosActuales = */this.carrito.Leer_Carrito();
                            break;
                    case 3: /*this.DatosActuales = */this.carrito.Borrar_Carrito();
                            break;
                    case 4: /*this.DatosActuales = */this.carrito.Todos_Carritos();
                            break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
            return Resultado;
        }

        /// <summary>
        /// Método para la realización de transacciones con los detalles de los carritos.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <param name="ProdId"></param>
        /// <returns></returns>
        public bool Trasaccion_Carrito_Detalles(int opcion, int Id = 0, string ProdId = "")
        {
            bool Resultado = false;

            try
            {
                this.carrito_detalles = new Carrito_Detalles(this.BaseDatos.Obtener_Conexion());
                this.carrito_detalles.Id = Id;
                this.carrito_detalles.ProdId = ProdId;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.carrito_detalles.Agregar_Carrito_Detalles();
                            break;
                    case 2: /*this.DatosActuales = */this.carrito_detalles.Leer_Carrito_Detalles();
                            break;
                    case 3: /*this.DatosActuales = */this.carrito_detalles.Todos_Carrito_Detalles();
                            break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }

        /// <summary>
        /// Método para la realización de las transacciones con las categorías.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public bool Trasaccion_Categorias(int opcion, int Id = 0, string Nombre = "")
        {
            bool Resultado = false;

            try
            {
                this.categoria = new Categorias(this.BaseDatos.Obtener_Conexion());
                this.categoria.Id = Id;
                this.categoria.Nombre = Nombre;

                switch(opcion){
                    case 1: /*this.DatosActuales = */this.categoria.Agregar_Categoría();
                            break;
                    case 2: /*this.DatosActuales = */this.categoria.Leer_Categoría();
                            break;
                    case 3: /*this.DatosActuales = */this.categoria.Actualizar_Categoría();
                            break;
                    case 4: /*this.DatosActuales = */this.categoria.Borrar_Categoría();
                            break;
                    case 5: /*this.DatosActuales = */this.categoria.Todas_Categoría();
                            break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }

        /// <summary>
        /// Método para la realización de las transacciones con las presentaciones.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public bool Trasaccion_Presentacion(int opcion, int Id = 0, string Nombre = "")
        {
            bool Resultado = false;

            try
            {
                this.presentacion = new Presentaciones(this.BaseDatos.Obtener_Conexion());
                this.presentacion.Id = Id;
                this.presentacion.Nombre = Nombre;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.presentacion.Agregar_Presentacion();
                            break;
                    case 2: /*this.DatosActuales = */this.presentacion.Leer_Presentacion();
                            break;
                    case 3: /*this.DatosActuales = */this.presentacion.Actualizar_Presentacion();
                            break;
                    case 4: /*this.DatosActuales = */this.presentacion.Borrar_Presentacion();
                            break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }

        /// <summary>
        /// Método para la realización de las transacciones relacionadas con los usuarios.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <param name="Usuario"></param>
        /// <param name="Password"></param>
        /// <param name="Primer_Nombre"></param>
        /// <param name="Segundo_Nombre"></param>
        /// <param name="Primer_Apellido"></param>
        /// <param name="Segundo_Apellido"></param>
        /// <param name="Direccion1"></param>
        /// <param name="Direccion2"></param>
        /// <param name="Municipio"></param>
        /// <param name="Ciudad"></param>
        /// <param name="Estado"></param>
        /// <param name="Codigo_Postal"></param>
        /// <returns></returns>
        public bool Transaccion_Usuarios(int opcion, int Id = 0, string Usuario = "", string Password = "", int Nivel_Acceso = 4, string Primer_Nombre = "", string Segundo_Nombre = "",string Primer_Apellido = "", string Segundo_Apellido = "", string Direccion1 = "", string Direccion2 = "", string Municipio = "", string Ciudad = "", string Estado = "", int Codigo_Postal = 0)
        {
            bool Resultado = false;

            try
            {
                this.usuario = new Usuarios(this.BaseDatos.Obtener_Conexion());
                this.usuario.Id = Id;
                this.usuario.Usuario = Usuario;
                this.usuario.Password = Password;
                this.usuario.Nivel_Acceso = Nivel_Acceso;
                this.usuario.Primer_Nombre = Primer_Nombre;
                this.usuario.Segundo_Nombre = Segundo_Nombre;
                this.usuario.Primer_Apellido = Primer_Apellido;
                this.usuario.Segundo_Apellido = Segundo_Apellido;
                this.usuario.Direccion1 = Direccion1;
                this.usuario.Direccion2 = Direccion2;
                this.usuario.Municipio = Municipio;
                this.usuario.Ciudad = Ciudad;
                this.usuario.Estado = Estado;
                this.usuario.Codigo_Postal = Codigo_Postal;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.usuario.Agregar_Usuario();
                        break;
                    case 2: /*this.DatosActuales = */this.usuario.Leer_Usuario();
                        break;
                    case 3: /*this.DatosActuales = */this.usuario.Actualizar_Usuario();
                        break;
                    case 4: /*this.DatosActuales = */this.usuario.Borrar_Usuario();
                        break;
                    case 5: /*this.DatosActuales = */this.usuario.IngresarApp();
                        break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }
        
        /// <summary>
        /// Método para la realización de las transacciones relacionadas con los productos.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <param name="SKU"></param>
        /// <param name="Nombre"></param>
        /// <param name="Descripcion_Corta"></param>
        /// <param name="Descripcion_Larga"></param>
        /// <param name="Categoria"></param>
        /// <param name="Precio"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool Trasaccion_Productos(int opcion, int Id = 0, string SKU = "", string Nombre = "", string Categoria = "", string Presentacion = "", string Descripcion_Corta = "", string Descripcion_Larga = "", double Precio = 0.00, int Cantidad = 0)
        {
            bool Resultado = false;

            try
            {
                this.productos = new Productos(this.BaseDatos.Obtener_Conexion());
                this.productos.Id = Id;
                this.productos.SKU = SKU;
                this.productos.Nombre = Nombre;
                this.productos.Categoria = Categoria;
                this.productos.Presentacion = Presentacion;
                this.productos.Descripcion_Corta = Descripcion_Corta;
                this.productos.Descripcion_Larga = Descripcion_Larga;
                this.productos.Precio = Precio;
                this.productos.Cantidad = Cantidad;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.productos.Agregar_Producto();
                            break;
                    case 2: /*this.DatosActuales = */this.productos.Leer_Producto();
                            break;
                    case 3: /*this.DatosActuales = */this.productos.Actualizar_Producto();
                            break;
                    case 4: /*this.DatosActuales = */this.productos.Borrar_Producto();
                            break;
                    case 5: /*this.DatosActuales = */this.productos.Todos_Productos();
                            break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }


        public DataTable Todos_Productos()
        {
            this.productos = new Productos(this.BaseDatos.Obtener_Conexion());
            return this.productos.Todos_Productos();
        }

        /// <summary>
        /// Método para la realización de las transacciones relacionadas con las ventas.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="Id"></param>
        /// <param name="IdUsuario"></param>
        /// <param name="Fecha"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool Trasaccion_Ventas(int opcion, string IdUsuario, double Cantidad)
        {
            bool Resultado = false;

            try
            {
                this.venta = new Ventas(this.BaseDatos.Obtener_Conexion());
                this.venta.IdUsuario = IdUsuario;
                this.venta.Cantidad = Cantidad;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.venta.Agregar_Venta();
                            break;
                    case 2: /*this.DatosActuales = */this.venta.Leer_Venta();
                            break;
                    case 3: /*this.DatosActuales = */this.venta.Todas_Venta();
                            break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }

        /// <summary>
        /// Método para la realización de las transacciones relacionadas con los detalles de las transacciones.
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="IdVenta"></param>
        /// <param name="Producto"></param>
        /// <param name="Presentacion"></param>
        /// <param name="Cantidad"></param>
        /// <returns></returns>
        public bool Trasaccion_Ventas_Detalles(int opcion,int IdVenta = 0, string Producto = "", string Presentacion = "", int Cantidad = 0)
        {
            bool Resultado = false;

            try
            {
                this.venta_detalles = new Ventas_Detalles(this.BaseDatos.Obtener_Conexion());
                this.venta_detalles.IdVenta = IdVenta;
                this.venta_detalles.Producto = Producto;
                this.venta_detalles.Presentacion = Presentacion;
                this.venta_detalles.Cantidad = Cantidad;

                switch (opcion)
                {
                    case 1: /*this.DatosActuales = */this.venta_detalles.Agregar_Venta_Detalles();
                        break;
                    case 2: /*this.DatosActuales = */this.venta_detalles.Leer_Venta_Detalles();
                        break;
                    case 3: /*this.DatosActuales = */this.venta_detalles.Todas_Venta_Detalles();
                        break;
                }

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return Resultado;
        }

        /// <summary>
        /// Método para la revisión del estado de la base de datos.
        /// </summary>
        /// <returns></returns>
        public bool Estado_BaseDatos()
        {
            bool Resultado = false;
            if (this.BaseDatos.Vacio.Equals(false))
            {
                Resultado = true;
            }
            
            return Resultado;
        }

        /// <summary>
        /// Método para realización de pruebas de la base de datos.
        /// </summary>
        /// <returns></returns>
        public bool Probar_Conexion()
        {
            return this.BaseDatos.PruebaConexion();
        }

        public bool Configurar_Base_Datos(string Servidor, string Puerto, string Usuario, string Password, string DB)
        {
            bool Resultado = false;
            try
            {
                this.BaseDatos.ConfigurarConexionDatos(Servidor, Puerto, Usuario, Password, DB);
                this.BaseDatos.PruebaConexion();

                Resultado = true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Resultado;
        }

        /// <summary>
        /// Método para la obtención de los datos del usuario que se encuentra utilizando el punto de ventas.
        /// </summary>
        /// <returns></returns>
        public string[] Usuario_Actual()
        {
            this.Datos = this.usuario.Datos();
            return this.Datos;
        }

        public void Insertar_Producto(string p1, string p2, string p3, string p4, string p5, string p6, double p7, int p8)
        {
            this.Trasaccion_Categorias(1, 0, p3);
            this.Trasaccion_Productos(1, 0, p1, p2, p3, p4, p5, p6, p7, p8);
        }

        public void Eliminar_Producto(string p)
        {
            this.Trasaccion_Productos(4, 0, p);
        }

        public void Insertar_Usuario(string Usuario, string Password, int NivelAcceso, string Nombre1, string Nombre2, string Apellido1, string Apellido2, string Direccion1, string Direccion2, string Municipio, string Ciudad, string Estado, int CP)
        {
            this.Transaccion_Usuarios(1, 0, Usuario, Password, NivelAcceso, Nombre1, Nombre2, Apellido1, Apellido2, Direccion1, Direccion2, Municipio, Ciudad, Estado, CP);
        }

        public void Eliminar_Usuario(string p)
        {
            this.Transaccion_Usuarios(4, 0, p);
        }

        public void Insertar_Venta(DataTable Carrito, string Usuario, double Precio)
        {
            this.Trasaccion_Ventas(1, Usuario, Precio);
            foreach (DataRow fila in Carrito.Rows)
            {
                this.Trasaccion_Ventas_Detalles(1, this.venta.Id, fila.ItemArray[2].ToString(), fila.ItemArray[3].ToString(), 1);
            }
        }
    }
}
