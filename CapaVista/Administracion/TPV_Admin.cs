using System;
using System.Windows.Forms;

namespace CapaVista.Administracion
{

    public partial class TPV_Admin : Form
    {
        public event EventHandler Guardar_Producto;
        public event EventHandler Eliminar_Producto;
        public event EventHandler Guardar_Usuario;
        public event EventHandler Eliminar_Usuario;

        public TPV_Admin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método para cargar los componentes de datos con información de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TPV_Admin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tPVDataSet.Ventas' table. You can move, or remove it, as needed.
            this.tPVDataSet.EnforceConstraints = false;
            this.ventasTableAdapter.Fill(this.tPVDataSet.Ventas);
            this.usuariosTableAdapter.Fill(this.tPVDataSetUsuarios.Usuarios);
            this.productosTableAdapter.Fill(this.tPVDataSetProductos.Productos);
            this.DGVProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGVUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.DGVUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        /// <summary>
        /// Método para cargar los datos de la tabla de productos a los campos para su manejo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVProductos.SelectedRows)
            {
                this.txtSKU.Text = row.Cells[0].Value.ToString();
                this.txtNombreProducto.Text = row.Cells[1].Value.ToString();
                this.txtPresentacion.Text = row.Cells[3].Value.ToString();
                this.txtCategoria.Text = row.Cells[2].Value.ToString();
                this.txtDescripcion.Text = row.Cells[4].Value.ToString();
                this.rtxtDetalles.Text = row.Cells[5].Value.ToString();
                this.txtPrecio.Text = row.Cells[6].Value.ToString();
                this.txtCantidad.Text = row.Cells[7].Value.ToString();
            }
        }

        /// <summary>
        /// Método para cargar los datos de la tabla de usuarios a los campos para su manejo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in this.DGVUsuarios.SelectedRows)
            {
                this.txtIdUsuario.Text = row.Cells[1].Value.ToString();
                this.txtPassword.Text = row.Cells[2].Value.ToString();
                this.txtNivelAcceso.Text = row.Cells[3].Value.ToString();
                this.txtNombreUsuario1.Text = row.Cells[4].Value.ToString();
                this.txtNombreUsuario2.Text = row.Cells[5].Value.ToString();
                this.txtApellido1.Text = row.Cells[6].Value.ToString();
                this.txtApellido2.Text = row.Cells[7].Value.ToString();
                this.txtDireccion1.Text = row.Cells[8].Value.ToString();
                this.txtDireccion2.Text = row.Cells[9].Value.ToString();
                this.txtMunicipio.Text = row.Cells[10].Value.ToString();
                this.txtCiudad.Text = row.Cells[11].Value.ToString();
                this.txtEstado.Text = row.Cells[12].Value.ToString();
                this.txtCP.Text = row.Cells[13].Value.ToString();
            }
        }

        /// <summary>
        /// Método generador de evento para realizar el guardado de la información de un producto en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            int validacionInt;
            double validacionDouble;

            if (int.TryParse(this.txtCantidad.Text, out validacionInt))
            {
                if (double.TryParse(this.txtPrecio.Text, out validacionDouble))
                {
                    EventHandler handler = Guardar_Producto;
                    if (handler != null)
                    {
                        handler(this, e);
                    }
                    this.TPV_Admin_Load(this, EventArgs.Empty);
                }
                else
                {
                    this.Mensaje_Validacion("El precio no es numérico/decimal. Favor de validarlo.");
                }
            }
            else
            {
                this.Mensaje_Validacion("La cantidad no es valor numérico. Favor de validarlo.");
            }
            this.Reset_Campos_Productos();
        }

        /// <summary>
        /// Método generador de evento para la eliminación de la información de un producto de la base de  datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            EventHandler handler = Eliminar_Producto;
            if (handler != null)
            {
                handler(this, e);
            }
            this.TPV_Admin_Load(this, EventArgs.Empty);
            this.Reset_Campos_Productos();
        }

        /// <summary>
        /// Método generador de evento para el guardado de la información de un usuario en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            int validacion;
            if (int.TryParse(this.txtNivelAcceso.Text, out validacion))
            {
                if (int.TryParse(this.txtCP.Text, out validacion))
                {
                    EventHandler handler = Guardar_Usuario;
                    if (handler != null)
                    {
                        handler(this, e);
                    }
                    this.TPV_Admin_Load(this, EventArgs.Empty);
                }
                else
                {
                    this.Mensaje_Validacion("El código postal no es numérico. Favor de validarlo.");
                }
            }
            else
            {
                this.Mensaje_Validacion("El nivel de acceso no es numérico. Favor de validarlo.");
            }
            this.Reset_Campos_Usuarios();
        }

        /// <summary>
        /// Método generador de evento para la eliminación de la información de un usuario en la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            EventHandler handler = Eliminar_Usuario;
            if (handler != null)
            {
                handler(this, e);
            }
            this.TPV_Admin_Load(this, EventArgs.Empty);
            Reset_Campos_Usuarios();
        }

        /// <summary>
        /// Método para reestablecer los campos de la pantalla de administración de productos.
        /// </summary>
        private void Reset_Campos_Productos()
        {
            this.txtSKU.Text = "";
            this.txtNombreProducto.Text = "";
            this.txtPrecio.Text = "";
            this.txtPresentacion.Text = "";
            this.txtCategoria.Text = "";
            this.txtCantidad.Text = "";
            this.txtDescripcion.Text = "";
            this.rtxtDetalles.Text = "";
        }


        private void Reset_Campos_Usuarios()
        {
            this.txtIdUsuario.Text = "";
            this.txtPassword.Text = "";
            this.txtNombreUsuario1.Text = "";
            this.txtNombreUsuario2.Text = "";
            this.txtApellido1.Text = "";
            this.txtApellido2.Text = "";
            this.txtDireccion1.Text = "";
            this.txtDireccion2.Text = "";
            this.txtMunicipio.Text = "";
            this.txtCiudad.Text = "";
            this.txtEstado.Text = "";
            this.txtCP.Text = "";
        }

        private void Mensaje_Validacion(string Mensaje)
        {
            MessageBox.Show(Mensaje);
        }
    }
}
