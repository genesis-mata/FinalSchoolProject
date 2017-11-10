using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista.Administracion
{
    public partial class Configuracion_BD : Form
    {
        /// <summary>
        /// Variables para la configuración de la base de datos.
        /// </summary>
        private string _SQL_Servidor;
        private string _SQL_Puerto;
        private string _SQL_Usuario;
        private string _SQL_Password;
        private string _SQL_BD;

        /// <summary>
        /// Eventos de la forma para el manejo de la información en la vista.
        /// </summary>
        public event EventHandler Evento_Configurar_DB;
        public event EventHandler Evento_Cancelar_DB;


        /// <summary>
        /// Getters y Setters de las variables a utilizar.
        /// </summary>
        public string SQL_Servidor
        {
            get { return _SQL_Servidor; }
            set { _SQL_Servidor = value; }
        }

        public string SQL_Puerto
        {
            get { return _SQL_Puerto; }
            private set { _SQL_Puerto = value; }
        }

        public string SQL_Usuario
        {
            get { return _SQL_Usuario; }
            private set { _SQL_Usuario = value; }
        }

        public string SQL_Password
        {
            get { return _SQL_Password; }
            private set { _SQL_Password = value; }
        }

        public string SQL_BD
        {
            get { return _SQL_BD; }
            private set { _SQL_BD = value; }
        }

        /// <summary>
        /// Métodos para la utilización de la forma correspondiente.
        /// </summary>
        public Configuracion_BD()
        {
            InitializeComponent();
        }

        public void Evento_Configurar(object sender, EventArgs args)
        {
            this.SQL_Servidor = this.tbxServidor.Text;
            this.SQL_Puerto = this.tbxPuerto.Text;
            this.SQL_Usuario = this.tbxUsuario.Text;
            this.SQL_Password = this.tbxPassword.Text;
            this.SQL_BD = this.tbxBD.Text;

            Evento_Configurar_DB(this, EventArgs.Empty);
        }

        public void Evento_Cancelar(object sender, EventArgs args)
        {
            EventHandler handler = Evento_Cancelar_DB;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public void Desplegar_Mensaje(string Mensaje)
        {
            MessageBox.Show(Mensaje);
        }
    }
}
