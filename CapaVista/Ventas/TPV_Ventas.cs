using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Ventas
{
    public partial class TPV_Ventas : Form
    {
        /// <summary>
        /// Variables auxiliares de ventana de ventas.
        /// </summary>
        private DataRow datos;
        private string _Nombre;
        private string[] Sesion;
        private string _usuario;
        private string _Apellido;
        private DataTable Carrito;
        private DataTable Productos;
        public DataSet _datos_ticket;
        private string _Nombre_Completo;

        /// <summary>
        /// Eventos de la clase.
        /// </summary>
        public event EventHandler _Cambio_Nombre_Apellido;
        public event EventHandler _Cobrar_Productos;
        public event EventHandler _Carrito_Pagado;
        public event EventHandler _Administracion;
        public event EventHandler _Cerrar_Sesion;
        public event EventHandler _Salir;

        /// <summary>
        /// Setters y Getters de las variables implementadas.
        /// </summary>
        public string Nombre
        {
            get {
                    return _Nombre; 
                }

            set { 
                    _Nombre = value;
                }
        }

        public string Apellido
        {
            get {
                    return _Apellido;
                }

            set {
                    _Apellido = value;
                }
        }

        public string Usuario
        {
            get { return _usuario; }
            private set {
                            _usuario = value;
                        }
        }

        public string Nombre_Completo
        {
            get {
                    return _Nombre_Completo;
                }

            private set {
                            _Nombre_Completo = value;
                        }
        }

        public double Precio
        {
            get
            {
                return double.Parse(this.lblTotal.Text);
            }

            set
            {
                this.lblTotal.Text = value.ToString();
            }
        }

        public DataSet Datos_Remision
        {
            get
            {
                this._datos_ticket = new DataSet();
                this._datos_ticket.Tables.Add(this.Carrito);
                return this._datos_ticket;
            }
        }

        public DataTable Obtener_Carrito()
        {
            return this.Carrito;
        }

        /// <summary>
        /// Constructor inicial con información del usuario.
        /// </summary>
        /// <param name="datos">Contiene los datos del usuario, como son: nombre y apellido</param>
        public TPV_Ventas(string[] datos)
        {
            InitializeComponent();
            this.Sesion = datos;
            this.Nombre = datos[0];
            this.Apellido = datos[2];
            this.Cambio_Nombre();
            this.Usuario = this.Nombre + "_" + this.Apellido;
            lblBienvenida.Text = "Bienvenid@, " + this.Nombre_Completo;
            this.ControlBox = false;
            this.MaximizeBox = false;
            if (int.Parse(datos[4]) > 1)
            {
                this.TSAdministracion.Enabled = false;
            }
        }

        /// <summary>
        /// Método para configurar los productos de la base de datos a la vista principal de ventas.
        /// </summary>
        /// <param name="Productos"></param>
        public void Configurar_Productos(DataTable Productos){
            this.Productos = new DataTable();
            this.Productos = Productos;
            this.Carrito = new DataTable();
            
            this.DGVProductos.DataSource = this.Productos;
            this.DGVProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductos.DoubleClick += this.Agregar_Carrito;

            this.Carrito.Columns.Add("ID");
            this.Carrito.Columns.Add("SKU");
            this.Carrito.Columns.Add("Producto");
            this.Carrito.Columns.Add("Presentación");
            this.Carrito.Columns.Add("Categoría");
            this.Carrito.Columns.Add("Precio");
            //Carrito.Columns.Add("Cantidad");
            
            this.DGVCarrito.DataSource = this.Carrito;
            this.DGVCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVCarrito.DoubleClick += this.Remover_Carrito;
        }

        /// <summary>
        /// Método para agregar los productos seleccionados al carrito.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Agregar_Carrito(object sender, EventArgs e)
        {
            double Precio_Total = 0.00;
            datos = this.Carrito.NewRow();
            foreach (DataGridViewRow row in this.DGVProductos.SelectedRows)
            {
                Int32 id = (Int32) row.Cells[0].Value;
                string SKU = (string) row.Cells[1].Value;
                string Producto = (string) row.Cells[2].Value;
                string Presentacion = (string) row.Cells[3].Value;
                string Categoria = (string) row.Cells[4].Value;
                Decimal Precio = (Decimal) row.Cells[7].Value;
                
                object[] data = {id, SKU, Producto, Presentacion, Categoria, Precio};
                datos.ItemArray = data;
                this.Carrito.Rows.Add(datos);

                foreach (DataRow fila in this.Carrito.Rows)
                {
                    Precio_Total += double.Parse(fila.ItemArray[5].ToString());
                }
            }
            string Total = string.Format("{0:0.00}", Precio_Total);
            this.lblTotal.Text = Total;
        }

        /// <summary>
        /// Método para remover productos del carrito.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remover_Carrito(object sender, EventArgs e)
        {
            double Precio_Total = 0.00;

            if (this.DGVCarrito.SelectedRows.Count > 0)
            {
                this.Carrito.Rows.RemoveAt(this.DGVCarrito.SelectedRows[0].Index);
            }

            foreach (DataRow fila in this.Carrito.Rows)
            {
                Precio_Total += double.Parse(fila.ItemArray[5].ToString());
            }

            string Total = string.Format("{0:0.00}", Precio_Total);
            this.lblTotal.Text = Total;
        }

        /// <summary>
        /// Método de cambio de nombre completo.
        /// </summary>
        public void Cambio_Nombre()
        {
            this.Nombre_Completo = this.Nombre + " " + this.Apellido;
        }

        /// <summary>
        /// Método de evento para salir de la aplicación.
        /// </summary>
        /// <param name="sender">parámetro de qué objeto es el que manda el evento.</param>
        /// <param name="e">parámetro que contiene los argumentos del evento.</param>
        private void MISalir_Click(object sender, EventArgs e)
        {
            EventHandler handler = _Salir;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Método de evento para realizar la búsqueda de productos en una ventana adicional.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buscar_Prod_KeyPress(object sender, EventArgs e)
        {
            if (this.Buscar_Prod.TextLength >= 2)
            {
                DataTable filtro = this.Productos;
                DataView vista = new DataView(filtro);
                vista.RowFilter = string.Format("Producto like '%{0}%'", this.Buscar_Prod.Text);
                this.DGVProductos.DataSource = vista;
            }
            else
            {
                this.DGVProductos.DataSource = this.Productos;
            }
        }

        /// <summary>
        /// Método de evento para desplegar la sección de Administración de la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que envía el evento.</param>
        /// <param name="e">Argumentos de evento iniciado.</param>
        private void MIAdministracion_Click(object sender, EventArgs e)
        {
            EventHandler handler = _Administracion;
            if(handler != null){
                handler(this, e);
            }
        }
        
        /// <summary>
        /// Método de evento para desplegar la ventana de Acerca de... de la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que envía el evento.</param>
        /// <param name="e">Argumentos de evento iniciado.</param>
        private void MIAcercaDe_Click(object sender, EventArgs e)
        {
            Ventas.TPV_Ayuda Ayuda = new Ventas.TPV_Ayuda();
            Ayuda.ShowDialog();
        }

        /// <summary>
        /// Método de evento de cambio de nombre que activa el método para cambiar de nombre completo al usuario en ejecución.
        /// </summary>
        /// <param name="sender">Objeto que envía el evento.</param>
        /// <param name="e">Argumentos de evento iniciado.</param>
        protected virtual void Cambio_Nombre_Apellido(object sender, EventArgs e)
        {
            EventHandler handler = _Cambio_Nombre_Apellido;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Evento de evento para realizar el cierre de sesión de la aplicación.
        /// </summary>
        /// <param name="sender">Objeto que envía el evento.</param>
        /// <param name="e">Argumentos de evento iniciado.</param>
        private void MICerrarSesion_Click(object sender, EventArgs e)
        {
            EventHandler handler = _Cerrar_Sesion;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Evento que accionar la forma de pago para ingresar la cantidad pagada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPagar_Click(object sender, EventArgs e)
        {
            EventHandler handler = _Cobrar_Productos;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void Pagado(bool pagado)
        {
            if (pagado.Equals(true))
            {
                EventHandler handler = _Carrito_Pagado;
                if (handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
                this.Carrito.Clear();
                this.lblTotal.Text = "0.00";
            }
        }
    }
}
