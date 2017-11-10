using System;
using System.Data;

namespace CapaVista
{
    public class Vista
    {
        /// <summary>
        /// Controlador para manejar el flujo de datos de la aplicación.
        /// </summary>
        private CapaControlador.Negocios Negocios;
        private DataSet _Datos_Remision;
        private bool Sesion = false;
        private bool _Cerrar = false;

        /// <summary>
        /// Definición de las vistas de Ventas de la aplicación.
        /// </summary>
        private Ventas.TPV_Cobro Cobro;
        private Ventas.TPV_Ingreso Ingreso;
        private Ventas.TPV_Ventas Ventas;

        /// <summary>
        /// Definición de vistas de Administración de la aplicación.
        /// </summary>
        private Administracion.Configuracion_BD Configuracion_DB;
        private Administracion.TPV_Admin Administracion;

        private Testing testing;
        
        /// <summary>
        /// Constructor estándar para inicializar los procesos internos del software.
        /// </summary>
        public Vista()
        {
            this.Negocios = new CapaControlador.Negocios();
        }

        public bool Cerrar
        {
            get { return _Cerrar; }
            set { _Cerrar = value; }
        }

        public DataSet Datos_Remision
        {
            get { return _Datos_Remision; }
            set { _Datos_Remision = value; }
        }

        /// <summary>
        /// Método para iniciar la aplicación desde la configuración de la base de datos.
        /// </summary>
        public void Iniciar()
        {
        Login:
            if (Cerrar != true)
            {
                if (this.Negocios.Estado_BD().Equals(true))
                {
                    if (Sesion.Equals(false))
                    {
                        this.Ingreso = new Ventas.TPV_Ingreso();
                        this.Ingreso.Vista_Login += this.IngresarApp;
                        this.Ingreso._Salir += this.Salir;
                        this.Ingreso.ShowDialog();
                        if (this.Sesion.Equals(true))
                        {
                            this.Iniciar_Ventas();
                        }
                        else
                        {
                            goto Login;
                        }
                    }
                }
                else
                {
                    this.Configuracion_DB = new Administracion.Configuracion_BD();
                    this.Configuracion_DB.Evento_Configurar_DB += this.Configurar_Base_Datos;
                    this.Configuracion_DB.Evento_Cancelar_DB += this.Cancelar_Base_Datos;
                    this.Configuracion_DB.ShowDialog();
                    goto Login;
                }
            }
        }

        /// <summary>
        /// Método para el inicio del punto de ventas.
        /// </summary>
        private void Iniciar_Ventas()
        {
            string[] datos = this.Negocios.Datos_Usuario();
            this.Ventas = new Ventas.TPV_Ventas(datos);
            this.Ventas.Configurar_Productos(this.Negocios.Todos_Productos());

            //Implementación de eventos de la Vista de Ventas.
            this.Ventas._Cerrar_Sesion += this.Cerrar_Sesion;
            this.Ventas._Salir += this.Salir;
            this.Ventas._Administracion += this.Abrir_Administracion;
            this.Ventas._Cobrar_Productos += Ventas_Cobrar_Productos;
            this.Ventas._Carrito_Pagado += Ventas_Carrito_Pagado;

            //Implementar los eventos para administración.
            this.Ventas.ShowDialog();
        }

        private void Ventas_Carrito_Pagado(object sender, EventArgs e)
        {
            //TO-DO: Desarrollar el registro de las ventas.
            DataTable Carrito = this.Ventas.Obtener_Carrito();
            this.Negocios.Insertar_Venta(Carrito, this.Ventas.Usuario, this.Ventas.Precio);
        }

        /// <summary>
        /// Método para realizar el cobro del carrito de compras.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Ventas_Cobrar_Productos(object sender, EventArgs e)
        {
            this.Cobro = new Ventas.TPV_Cobro(this.Ventas.Precio);
            this.Cobro.Disposed += Pagado;
            this.Cobro.ShowDialog();
        }

        /// <summary>
        /// Método para realizar las acciones de un carrito pagado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pagado(object sender, EventArgs e)
        {
            this.Ventas.Pagado(this.Cobro.Pagado);
        }

        /// <summary>
        /// Método para abrir la pantalla de adminisración.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Abrir_Administracion(object sender, EventArgs e)
        {
            this.Administracion = new Administracion.TPV_Admin();

            //Configuración de eventos para la administración.
            this.Administracion.Guardar_Producto += Guardar_Producto;
            this.Administracion.Eliminar_Producto += Eliminar_Producto;
            this.Administracion.Guardar_Usuario += Guardar_Usuario;
            this.Administracion.Eliminar_Usuario += Eliminar_Usuario;

            //Iniciar la vista de Administración.
            this.Administracion.ShowDialog();
        }

        /// <summary>
        /// Evento para salir del punto de ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Salir(object sender, EventArgs e)
        {
            this.Cerrar = true;
            if (this.Ingreso != null)
            {
                this.Ingreso.Dispose();
            }
            if (this.Ventas != null)
            {
                this.Ventas.Dispose();
            }
        }

        /// <summary>
        /// Evento para cerrar la sesión del punto de ventas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cerrar_Sesion(object sender, EventArgs e)
        {
            this.Sesion = false;
            this.Ventas.Dispose();
        }

        /// <summary>
        /// Método para probar la conexión a la base de datos.
        /// </summary>
        /// <param name="sender">Objeto que genera el mensaje.</param>
        /// <param name="args">Argumentos del evento.</param>
        public void Probar_Conexion(object sender, EventArgs args)
        {
            if (this.Negocios.Prueba_Conexion().Equals(true))
            {
                this.testing.Test_Con("Conexión establecida correctamente.");
            }
            else
            {
                this.testing.Test_Con("Conexión no pudo ser establecida.");
            }
        }

        /// <summary>
        /// Método para ingresar nuevas categorías.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Ingresar_Categoría(object sender, EventArgs args)
        {
            if (this.Negocios.Insertar_Categoría("Malteadas").Equals(true))
            {
                this.testing.Test_Con("Categoría ingresada correcttamente.");
            }
            else
            {
                this.testing.Test_Con("Categoría no ingresada correcttamente.");
            }
        }

        /// <summary>
        /// Método para obtener todoss los productos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void Todos_Productos(object sender, EventArgs args)
        {
            this.Negocios.Todos_Productos();
        }

        /// <summary>
        /// Método para configurar la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Configurar_Base_Datos(object sender, EventArgs args)
        {
            if (this.Configuracion_DB.SQL_Servidor == "")
            {
                if (this.Negocios.Configurar_BD())
                {
                    this.Configuracion_DB.Desplegar_Mensaje("Base de datos de prueba ha sido configurada.");
                }
            }
            else
            {
                if (this.Negocios.Configurar_BD(this.Configuracion_DB.SQL_Servidor, this.Configuracion_DB.SQL_Puerto, this.Configuracion_DB.SQL_Usuario, this.Configuracion_DB.SQL_Password, this.Configuracion_DB.SQL_BD))
                {
                    this.Configuracion_DB.Desplegar_Mensaje("Base de datos configurada correctamente.");
                }
                else
                {
                    this.Configuracion_DB.Desplegar_Mensaje("Base de datos no pudo ser configurada.");
                }
            }
            this.Configuracion_DB.Dispose();
        }

        /// <summary>
        /// Método para ingresar a la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IngresarApp(object sender, EventArgs e)
        {
            if (this.Negocios.IngresarApp(this.Ingreso.Usuario, this.Ingreso.Contrasena))
            {
                this.Sesion = true;
            }
        }

        /// <summary>
        /// Método para guardar nuevos productos agregados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Guardar_Producto(object sender, EventArgs e)
        {
            this.Negocios.Insertar_Producto(this.Administracion.txtSKU.Text, this.Administracion.txtNombreProducto.Text, this.Administracion.txtCategoria.Text, this.Administracion.txtPresentacion.Text, this.Administracion.txtDescripcion.Text, this.Administracion.rtxtDetalles.Text, double.Parse(this.Administracion.txtPrecio.Text), int.Parse(this.Administracion.txtCantidad.Text));
        }

        /// <summary>
        /// Método para eliminar un producto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eliminar_Producto(object sender, EventArgs e)
        {
            this.Negocios.Eliminar_Producto(this.Administracion.txtSKU.Text);
        }

        /// <summary>
        /// Método para guardar nuevos usuarios agregados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Guardar_Usuario(object sender, EventArgs e)
        {
            this.Negocios.Insertar_Usuario(this.Administracion.txtIdUsuario.Text, this.Administracion.txtPassword.Text, int.Parse(this.Administracion.txtNivelAcceso.Text), this.Administracion.txtNombreUsuario1.Text, this.Administracion.txtNombreUsuario2.Text, this.Administracion.txtApellido1.Text, this.Administracion.txtApellido2.Text, this.Administracion.txtDireccion1.Text, this.Administracion.txtDireccion2.Text, this.Administracion.txtMunicipio.Text, this.Administracion.txtCiudad.Text, this.Administracion.txtEstado.Text, int.Parse(this.Administracion.txtCP.Text));
        }

        /// <summary>
        /// Método para eliminar un usuario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Eliminar_Usuario(object sender, EventArgs e)
        {
            this.Negocios.Eliminar_Usuario(this.Administracion.txtIdUsuario.Text);
        }

        /// <summary>
        /// Evento para cancelar la configuración de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelar_Base_Datos(object sender, EventArgs e)
        {
            this.Configuracion_DB.Dispose();
            this.Cerrar = true;
        }
    }
}
