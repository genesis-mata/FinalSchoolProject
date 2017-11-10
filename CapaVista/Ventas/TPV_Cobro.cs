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
    public partial class TPV_Cobro : Form
    {
        private bool _pagado = false;

        public bool Pagado
        {
            get { return _pagado; }
            set { _pagado = value; }
        }

        public TPV_Cobro(double TotalPagar)
        {
            InitializeComponent();
            string Total = string.Format("{0:0.00}", TotalPagar);
            this.txtTotalPagar.Text = Total;
        }

        private void txtCantidadPagada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(Convert.ToChar(Keys.Enter)))
            {
                double faltante = double.Parse(this.txtTotalPagar.Text);
                double pagado = double.Parse(this.txtCantidadPagada.Text);
                double resultado;
                string cambio;
                
                resultado = faltante - pagado;
                if (resultado < 0)
                {
                    this.lblResultado.Text = "Cambio:";
                    cambio = string.Format("{0:0.00}", (resultado * (-1)));
                    this.txtCantidadPagada.Text = cambio;
                    this.Pagado = true;
                }
            }
        }

        private void btnCobrado_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
