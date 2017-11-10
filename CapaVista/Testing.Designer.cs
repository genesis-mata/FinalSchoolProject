namespace CapaVista
{
    partial class Testing
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
            this.TestCon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestCon
            // 
            this.TestCon.Location = new System.Drawing.Point(90, 102);
            this.TestCon.Name = "TestCon";
            this.TestCon.Size = new System.Drawing.Size(98, 23);
            this.TestCon.TabIndex = 0;
            this.TestCon.Text = "Probar Conexión";
            this.TestCon.UseVisualStyleBackColor = true;
            this.TestCon.Click += new System.EventHandler(this.TestCon_Click);
            // 
            // Testing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TestCon);
            this.Name = "Testing";
            this.Text = "Testing";
            this.ResumeLayout(true);

        }

        #endregion

        private System.Windows.Forms.Button TestCon;
    }
}