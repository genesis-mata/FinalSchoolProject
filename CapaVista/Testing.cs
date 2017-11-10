using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVista
{
    public partial class Testing : Form
    {
        private CapaVista.Vista Vistas;

        public event EventHandler Test_Conexion;
        public event EventHandler Ingresar_Categoria;

        public Testing()
        {
            InitializeComponent();
        }

        public void Test_Con(string mensaje)
        {
            MessageBox.Show(mensaje);
        }

        private void TestCon_Click(object sender, EventArgs e)
        {
            EventHandler handler = Ingresar_Categoria;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
