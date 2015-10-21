namespace PDVForms
{
    partial class frmSelecionaModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionaModulo));
            this.lblModAdmin = new System.Windows.Forms.Label();
            this.lblModVendas = new System.Windows.Forms.Label();
            this.pbModuloVendas = new System.Windows.Forms.PictureBox();
            this.pbModuloAdmin = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbModuloVendas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModuloAdmin)).BeginInit();
            this.SuspendLayout();
            // 
            // lblModAdmin
            // 
            this.lblModAdmin.AutoSize = true;
            this.lblModAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModAdmin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblModAdmin.Location = new System.Drawing.Point(86, 365);
            this.lblModAdmin.Name = "lblModAdmin";
            this.lblModAdmin.Size = new System.Drawing.Size(216, 24);
            this.lblModAdmin.TabIndex = 2;
            this.lblModAdmin.Text = "Módulo Administrativo";
            // 
            // lblModVendas
            // 
            this.lblModVendas.AutoSize = true;
            this.lblModVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModVendas.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblModVendas.Location = new System.Drawing.Point(440, 365);
            this.lblModVendas.Name = "lblModVendas";
            this.lblModVendas.Size = new System.Drawing.Size(187, 24);
            this.lblModVendas.TabIndex = 3;
            this.lblModVendas.Text = "Módulo de Vendas";
            // 
            // pbModuloVendas
            // 
            this.pbModuloVendas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbModuloVendas.Image = global::PDVForms.Properties.Resources.vendas;
            this.pbModuloVendas.Location = new System.Drawing.Point(402, 76);
            this.pbModuloVendas.Name = "pbModuloVendas";
            this.pbModuloVendas.Size = new System.Drawing.Size(286, 278);
            this.pbModuloVendas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbModuloVendas.TabIndex = 1;
            this.pbModuloVendas.TabStop = false;
            // 
            // pbModuloAdmin
            // 
            this.pbModuloAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbModuloAdmin.Image = global::PDVForms.Properties.Resources.admin;
            this.pbModuloAdmin.Location = new System.Drawing.Point(56, 76);
            this.pbModuloAdmin.Name = "pbModuloAdmin";
            this.pbModuloAdmin.Size = new System.Drawing.Size(286, 278);
            this.pbModuloAdmin.TabIndex = 0;
            this.pbModuloAdmin.TabStop = false;
            this.pbModuloAdmin.Click += new System.EventHandler(this.PB_MOD_ADM_Click);
            // 
            // frmSelecionaModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 456);
            this.Controls.Add(this.lblModVendas);
            this.Controls.Add(this.lblModAdmin);
            this.Controls.Add(this.pbModuloVendas);
            this.Controls.Add(this.pbModuloAdmin);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSelecionaModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Módulo";
            ((System.ComponentModel.ISupportInitialize)(this.pbModuloVendas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbModuloAdmin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbModuloAdmin;
        private System.Windows.Forms.PictureBox pbModuloVendas;
        private System.Windows.Forms.Label lblModAdmin;
        private System.Windows.Forms.Label lblModVendas;
    }
}