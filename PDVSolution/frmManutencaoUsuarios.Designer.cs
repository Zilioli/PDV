namespace PDVForms
{
    partial class frmManutencaoUsuarios
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManutencaoUsuarios));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabManutencaoUsuario = new System.Windows.Forms.TabControl();
            this.tabUsuario = new System.Windows.Forms.TabPage();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.tabAcesso = new System.Windows.Forms.TabPage();
            this.treeViewAcessos = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabManutencaoUsuario.SuspendLayout();
            this.tabUsuario.SuspendLayout();
            this.tabAcesso.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PDVForms.Properties.Resources.login_user;
            this.pictureBox1.Location = new System.Drawing.Point(9, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 80;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(56, 14);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(252, 25);
            this.lblTitulo.TabIndex = 79;
            this.lblTitulo.Text = "Manutenção de Usuários";
            // 
            // tabManutencaoUsuario
            // 
            this.tabManutencaoUsuario.Controls.Add(this.tabUsuario);
            this.tabManutencaoUsuario.Controls.Add(this.tabAcesso);
            this.tabManutencaoUsuario.Location = new System.Drawing.Point(12, 48);
            this.tabManutencaoUsuario.Name = "tabManutencaoUsuario";
            this.tabManutencaoUsuario.SelectedIndex = 0;
            this.tabManutencaoUsuario.Size = new System.Drawing.Size(613, 249);
            this.tabManutencaoUsuario.TabIndex = 81;
            this.tabManutencaoUsuario.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabManutencaoUsuario_Selecting);
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.txtConfirmarSenha);
            this.tabUsuario.Controls.Add(this.label2);
            this.tabUsuario.Controls.Add(this.txtSenha);
            this.tabUsuario.Controls.Add(this.lblSenha);
            this.tabUsuario.Controls.Add(this.txtLogin);
            this.tabUsuario.Controls.Add(this.label1);
            this.tabUsuario.Controls.Add(this.txtNomeUsuario);
            this.tabUsuario.Controls.Add(this.lblNomeCliente);
            this.tabUsuario.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tabUsuario.Location = new System.Drawing.Point(4, 22);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuario.Size = new System.Drawing.Size(605, 223);
            this.tabUsuario.TabIndex = 0;
            this.tabUsuario.Text = "Usuário";
            this.tabUsuario.UseVisualStyleBackColor = true;
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarSenha.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtConfirmarSenha.Location = new System.Drawing.Point(162, 131);
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(130, 23);
            this.txtConfirmarSenha.TabIndex = 50;
            this.txtConfirmarSenha.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(38, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 51;
            this.label2.Text = "Confirmar Senha:";
            // 
            // txtSenha
            // 
            this.txtSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenha.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSenha.Location = new System.Drawing.Point(162, 99);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(130, 23);
            this.txtSenha.TabIndex = 48;
            this.txtSenha.UseSystemPasswordChar = true;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenha.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSenha.Location = new System.Drawing.Point(38, 105);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(53, 17);
            this.lblSenha.TabIndex = 49;
            this.lblSenha.Text = "Senha:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtLogin.Location = new System.Drawing.Point(162, 70);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(130, 23);
            this.txtLogin.TabIndex = 46;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(38, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 47;
            this.label1.Text = "Login:";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeUsuario.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNomeUsuario.Location = new System.Drawing.Point(162, 41);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.Size = new System.Drawing.Size(321, 23);
            this.txtNomeUsuario.TabIndex = 44;
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblNomeCliente.Location = new System.Drawing.Point(38, 47);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(49, 17);
            this.lblNomeCliente.TabIndex = 45;
            this.lblNomeCliente.Text = "Nome:";
            // 
            // tabAcesso
            // 
            this.tabAcesso.Controls.Add(this.treeViewAcessos);
            this.tabAcesso.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tabAcesso.Location = new System.Drawing.Point(4, 22);
            this.tabAcesso.Name = "tabAcesso";
            this.tabAcesso.Padding = new System.Windows.Forms.Padding(3);
            this.tabAcesso.Size = new System.Drawing.Size(605, 223);
            this.tabAcesso.TabIndex = 1;
            this.tabAcesso.Text = "Acessos";
            this.tabAcesso.UseVisualStyleBackColor = true;
            // 
            // treeViewAcessos
            // 
            this.treeViewAcessos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.treeViewAcessos.ImageIndex = 0;
            this.treeViewAcessos.ImageList = this.imageList;
            this.treeViewAcessos.Location = new System.Drawing.Point(6, 6);
            this.treeViewAcessos.Name = "treeViewAcessos";
            this.treeViewAcessos.SelectedImageIndex = 0;
            this.treeViewAcessos.Size = new System.Drawing.Size(593, 211);
            this.treeViewAcessos.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "check.png");
            this.imageList.Images.SetKeyName(1, "admin.png");
            this.imageList.Images.SetKeyName(2, "Aha-Soft-Security-Secrecy.ico");
            this.imageList.Images.SetKeyName(3, "Application.ico");
            this.imageList.Images.SetKeyName(4, "Application.png");
            this.imageList.Images.SetKeyName(5, "cadastro_icon.png");
            this.imageList.Images.SetKeyName(6, "cadastroCliente.png");
            this.imageList.Images.SetKeyName(7, "cancelar.png");
            this.imageList.Images.SetKeyName(8, "check.ico");
            this.imageList.Images.SetKeyName(9, "confirma.png");
            this.imageList.Images.SetKeyName(10, "edit.ico");
            this.imageList.Images.SetKeyName(11, "edit.png");
            this.imageList.Images.SetKeyName(12, "exit.png");
            this.imageList.Images.SetKeyName(13, "facebook.png");
            this.imageList.Images.SetKeyName(14, "less.ico");
            this.imageList.Images.SetKeyName(15, "less.png");
            this.imageList.Images.SetKeyName(16, "login_user.ico");
            this.imageList.Images.SetKeyName(17, "login_user.png");
            this.imageList.Images.SetKeyName(18, "management.gif");
            this.imageList.Images.SetKeyName(19, "new_record.png");
            this.imageList.Images.SetKeyName(20, "plus.ico");
            this.imageList.Images.SetKeyName(21, "plus.png");
            this.imageList.Images.SetKeyName(22, "products.ico");
            this.imageList.Images.SetKeyName(23, "products.png");
            this.imageList.Images.SetKeyName(24, "search.ico");
            this.imageList.Images.SetKeyName(25, "search.png");
            this.imageList.Images.SetKeyName(26, "secrecy-icon.png");
            this.imageList.Images.SetKeyName(27, "supplier.ico");
            this.imageList.Images.SetKeyName(28, "supplier.png");
            this.imageList.Images.SetKeyName(29, "vendas.png");
            this.imageList.Images.SetKeyName(30, "web_management_icon.ico");
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Image = global::PDVForms.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(524, 303);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 35);
            this.btnCancelar.TabIndex = 83;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnIncluir
            // 
            this.btnIncluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluir.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnIncluir.Image = global::PDVForms.Properties.Resources.confirma;
            this.btnIncluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluir.Location = new System.Drawing.Point(416, 303);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(102, 35);
            this.btnIncluir.TabIndex = 82;
            this.btnIncluir.Text = "Confirmar";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // frmManutencaoUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 353);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIncluir);
            this.Controls.Add(this.tabManutencaoUsuario);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(653, 392);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(653, 392);
            this.Name = "frmManutencaoUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manutenção de Usuários";
            this.Load += new System.EventHandler(this.frmManutencaoUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabManutencaoUsuario.ResumeLayout(false);
            this.tabUsuario.ResumeLayout(false);
            this.tabUsuario.PerformLayout();
            this.tabAcesso.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabManutencaoUsuario;
        private System.Windows.Forms.TabPage tabUsuario;
        private System.Windows.Forms.TabPage tabAcesso;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TreeView treeViewAcessos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.ImageList imageList;
    }
}