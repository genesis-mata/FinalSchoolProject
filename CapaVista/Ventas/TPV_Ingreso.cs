using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Ventas
{
    public partial class TPV_Ingreso : Form
    {
        /// <summary>
        /// Parámetros de uso de las forma de ingreso.
        /// </summary>
        string _Usuario;
        string _Contrasena;

        /// <summary>
        /// Eventos de uso para la forma de ingreso.
        /// </summary>
        public event EventHandler _Salir;
        public event EventHandler Vista_Login;


        /// <summary>
        /// Setters y Getters de la forma.
        /// </summary>
        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Contrasena
        {
            get { return _Contrasena; }
            set { _Contrasena = value; }
        }

        /// <summary>
        /// Constructor predeterminado de la forma.
        /// </summary>
        public TPV_Ingreso()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        /// <summary>
        /// Evento para ingresar a la aplicación.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void AlIngresar(EventArgs e)
        {
            EventHandler handler = Vista_Login;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        /// <summary>
        /// Evento de ingreso a la aplicación utilizando el botón de Ingresar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            this.IngresarApp();
        }

        /// <summary>
        /// Evento de ingreso a la aplicación utilizando la tecla "Enter" en la caja de contraseña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtContrasena_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                this.IngresarApp();
            }
        }

        /// <summary>
        /// Método para ingresar a la aplicación.
        /// </summary>
        private void IngresarApp()
        {
            this.Usuario = this.txtUsuario.Text;
            this.Contrasena = this.txtContrasena.Text;
            AlIngresar(EventArgs.Empty);
            this.Dispose();
        }
        
        /// <summary>
        /// Evento para salir de la aplicación al utilizar el botón "Cancelar".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            EventHandler handler = _Salir;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void TPV_Ingreso_Load(object sender, EventArgs e)
        {

        }
    }
}
