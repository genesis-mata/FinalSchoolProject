namespace CapaVista.Ventas
{
    partial class TPV_Cobro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotalPagar = new System.Windows.Forms.TextBox();
            this.txtCantidadPagada = new System.Windows.Forms.TextBox();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCobrado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(25, 44);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(121, 20);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Total a Pagar:";
            // 
            // txtTotalPagar
            // 
            this.txtTotalPagar.Enabled = false;
            this.txtTotalPagar.Location = new System.Drawing.Point(179, 46);
            this.txtTotalPagar.Name = "txtTotalPagar";
            this.txtTotalPagar.Size = new System.Drawing.Size(100, 20);
            this.txtTotalPagar.TabIndex = 1;
            // 
            // txtCantidadPagada
            // 
            this.txtCantidadPagada.Location = new System.Drawing.Point(179, 96);
            this.txtCantidadPagada.Name = "txtCantidadPagada";
            this.txtCantidadPagada.Size = new System.Drawing.Size(100, 20);
            this.txtCantidadPagada.TabIndex = 2;
            this.txtCantidadPagada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadPagada_KeyPress);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultado.Location = new System.Drawing.Point(25, 96);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(152, 20);
            this.lblResultado.TabIndex = 3;
            this.lblResultado.Text = "Cantidad Pagada:";
            // 
            // btnCobrado
            // 
            this.btnCobrado.Location = new System.Drawing.Point(112, 145);
            this.btnCobrado.Name = "btnCobrado";
            this.btnCobrado.Size = new System.Drawing.Size(75, 23);
            this.btnCobrado.TabIndex = 4;
            this.btnCobrado.Text = "OK";
            this.btnCobrado.UseVisualStyleBackColor = true;
            this.btnCobrado.Click += new System.EventHandler(this.btnCobrado_Click);
            // 
            // TPV_Cobro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 180);
            this.Controls.Add(this.btnCobrado);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.txtCantidadPagada);
            this.Controls.Add(this.txtTotalPagar);
            this.Controls.Add(this.lblTotal);
            this.Name = "TPV_Cobro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotalPagar;
        private System.Windows.Forms.TextBox txtCantidadPagada;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnCobrado;
    }
}