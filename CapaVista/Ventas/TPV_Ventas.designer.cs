namespace CapaVista.Ventas
{
    partial class TPV_Ventas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TPV_Ventas));
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.Top_Menu = new System.Windows.Forms.MenuStrip();
            this.TSArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.MICerrar_Sesion = new System.Windows.Forms.ToolStripMenuItem();
            this.MISalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TSAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.TSAyuda = new System.Windows.Forms.ToolStripMenuItem();
            this.MIAcerdaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Buscar_Prod = new System.Windows.Forms.TextBox();
            this.btnPagar = new System.Windows.Forms.Button();
            this.DGVProductos = new System.Windows.Forms.DataGridView();
            this.DGVCarrito = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Top_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBienvenida
            // 
            resources.ApplyResources(this.lblBienvenida, "lblBienvenida");
            this.lblBienvenida.Name = "lblBienvenida";
            // 
            // Top_Menu
            // 
            this.Top_Menu.BackColor = System.Drawing.Color.White;
            this.Top_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSArchivo,
            this.TSAdministracion,
            this.TSAyuda});
            resources.ApplyResources(this.Top_Menu, "Top_Menu");
            this.Top_Menu.Name = "Top_Menu";
            this.Top_Menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            // 
            // TSArchivo
            // 
            this.TSArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MICerrar_Sesion,
            this.MISalir});
            this.TSArchivo.Name = "TSArchivo";
            resources.ApplyResources(this.TSArchivo, "TSArchivo");
            // 
            // MICerrar_Sesion
            // 
            this.MICerrar_Sesion.Name = "MICerrar_Sesion";
            resources.ApplyResources(this.MICerrar_Sesion, "MICerrar_Sesion");
            this.MICerrar_Sesion.Click += new System.EventHandler(this.MICerrarSesion_Click);
            // 
            // MISalir
            // 
            this.MISalir.Name = "MISalir";
            resources.ApplyResources(this.MISalir, "MISalir");
            this.MISalir.Click += new System.EventHandler(this.MISalir_Click);
            // 
            // TSAdministracion
            // 
            this.TSAdministracion.Name = "TSAdministracion";
            resources.ApplyResources(this.TSAdministracion, "TSAdministracion");
            this.TSAdministracion.Click += new System.EventHandler(this.MIAdministracion_Click);
            // 
            // TSAyuda
            // 
            this.TSAyuda.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MIAcerdaDe});
            this.TSAyuda.Name = "TSAyuda";
            resources.ApplyResources(this.TSAyuda, "TSAyuda");
            // 
            // MIAcerdaDe
            // 
            this.MIAcerdaDe.Name = "MIAcerdaDe";
            resources.ApplyResources(this.MIAcerdaDe, "MIAcerdaDe");
            this.MIAcerdaDe.Click += new System.EventHandler(this.MIAcercaDe_Click);
            // 
            // lblTotal
            // 
            resources.ApplyResources(this.lblTotal, "lblTotal");
            this.lblTotal.Name = "lblTotal";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Buscar_Prod
            // 
            resources.ApplyResources(this.Buscar_Prod, "Buscar_Prod");
            this.Buscar_Prod.Name = "Buscar_Prod";
            this.Buscar_Prod.TextChanged += new System.EventHandler(this.Buscar_Prod_KeyPress);
            // 
            // btnPagar
            // 
            resources.ApplyResources(this.btnPagar, "btnPagar");
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.UseVisualStyleBackColor = true;
            this.btnPagar.Click += new System.EventHandler(this.btnPagar_Click);
            // 
            // DGVProductos
            // 
            this.DGVProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DGVProductos, "DGVProductos");
            this.DGVProductos.Name = "DGVProductos";
            // 
            // DGVCarrito
            // 
            this.DGVCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.DGVCarrito, "DGVCarrito");
            this.DGVCarrito.Name = "DGVCarrito";
            this.DGVCarrito.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // TPV_Ventas
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            resources.ApplyResources(this, "$this");
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DGVCarrito);
            this.Controls.Add(this.DGVProductos);
            this.Controls.Add(this.btnPagar);
            this.Controls.Add(this.Buscar_Prod);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.Top_Menu);
            this.MainMenuStrip = this.Top_Menu;
            this.Name = "TPV_Ventas";
            this.Top_Menu.ResumeLayout(false);
            this.Top_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.MenuStrip Top_Menu;
        private System.Windows.Forms.ToolStripMenuItem TSArchivo;
        private System.Windows.Forms.ToolStripMenuItem MISalir;
        private System.Windows.Forms.ToolStripMenuItem TSAdministracion;
        private System.Windows.Forms.ToolStripMenuItem TSAyuda;
        private System.Windows.Forms.ToolStripMenuItem MIAcerdaDe;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Buscar_Prod;
        private System.Windows.Forms.ToolStripMenuItem MICerrar_Sesion;
        private System.Windows.Forms.Button btnPagar;
        private System.Windows.Forms.DataGridView DGVProductos;
        private System.Windows.Forms.DataGridView DGVCarrito;
        private System.Windows.Forms.Label label1;
    }
}