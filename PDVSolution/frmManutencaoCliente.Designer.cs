namespace PDVForms
{
    partial class frmManutencaoCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManutencaoCliente));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.txtSocial = new System.Windows.Forms.TextBox();
            this.lblSocial = new System.Windows.Forms.Label();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.lblWebSite = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbDadosPessoais = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtRG = new System.Windows.Forms.TextBox();
            this.lblRG = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtNomeCLiente = new System.Windows.Forms.TextBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.gbTelefones = new System.Windows.Forms.GroupBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtDDDCelular = new System.Windows.Forms.MaskedTextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtDDDTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ucEnderecoCliente = new PDVForms.ucEndereco();
            this.gbDadosPessoais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbTelefones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Image = global::PDVForms.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(540, 481);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 35);
            this.btnCancelar.TabIndex = 60;
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
            this.btnIncluir.Location = new System.Drawing.Point(453, 481);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(81, 35);
            this.btnIncluir.TabIndex = 59;
            this.btnIncluir.Text = "Incluir";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // txtSocial
            // 
            this.txtSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSocial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSocial.Location = new System.Drawing.Point(84, 154);
            this.txtSocial.Name = "txtSocial";
            this.txtSocial.Size = new System.Drawing.Size(500, 23);
            this.txtSocial.TabIndex = 5;
            // 
            // lblSocial
            // 
            this.lblSocial.AutoSize = true;
            this.lblSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSocial.Location = new System.Drawing.Point(16, 158);
            this.lblSocial.Name = "lblSocial";
            this.lblSocial.Size = new System.Drawing.Size(50, 17);
            this.lblSocial.TabIndex = 45;
            this.lblSocial.Text = "Social:";
            // 
            // txtWebSite
            // 
            this.txtWebSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebSite.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtWebSite.Location = new System.Drawing.Point(84, 120);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Size = new System.Drawing.Size(500, 23);
            this.txtWebSite.TabIndex = 4;
            // 
            // lblWebSite
            // 
            this.lblWebSite.AutoSize = true;
            this.lblWebSite.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebSite.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblWebSite.Location = new System.Drawing.Point(16, 125);
            this.lblWebSite.Name = "lblWebSite";
            this.lblWebSite.Size = new System.Drawing.Size(69, 17);
            this.lblWebSite.TabIndex = 43;
            this.lblWebSite.Text = "Web Site:";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(76, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(213, 25);
            this.lblTitulo.TabIndex = 65;
            this.lblTitulo.Text = "Cadastro de Clientes";
            // 
            // gbDadosPessoais
            // 
            this.gbDadosPessoais.Controls.Add(this.pictureBox2);
            this.gbDadosPessoais.Controls.Add(this.txtEmail);
            this.gbDadosPessoais.Controls.Add(this.lblEmail);
            this.gbDadosPessoais.Controls.Add(this.txtRG);
            this.gbDadosPessoais.Controls.Add(this.lblRG);
            this.gbDadosPessoais.Controls.Add(this.txtCPF);
            this.gbDadosPessoais.Controls.Add(this.lblCPF);
            this.gbDadosPessoais.Controls.Add(this.txtNomeCLiente);
            this.gbDadosPessoais.Controls.Add(this.lblNomeCliente);
            this.gbDadosPessoais.Controls.Add(this.txtWebSite);
            this.gbDadosPessoais.Controls.Add(this.lblWebSite);
            this.gbDadosPessoais.Controls.Add(this.lblSocial);
            this.gbDadosPessoais.Controls.Add(this.txtSocial);
            this.gbDadosPessoais.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbDadosPessoais.Location = new System.Drawing.Point(28, 46);
            this.gbDadosPessoais.Name = "gbDadosPessoais";
            this.gbDadosPessoais.Size = new System.Drawing.Size(608, 190);
            this.gbDadosPessoais.TabIndex = 66;
            this.gbDadosPessoais.TabStop = false;
            this.gbDadosPessoais.Text = "Dados Pessoais";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PDVForms.Properties.Resources.facebook;
            this.pictureBox2.Location = new System.Drawing.Point(563, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtEmail.Location = new System.Drawing.Point(84, 91);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(500, 23);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblEmail.Location = new System.Drawing.Point(16, 92);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(51, 17);
            this.lblEmail.TabIndex = 49;
            this.lblEmail.Text = "E-mail:";
            // 
            // txtRG
            // 
            this.txtRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRG.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtRG.Location = new System.Drawing.Point(362, 57);
            this.txtRG.Name = "txtRG";
            this.txtRG.Size = new System.Drawing.Size(222, 23);
            this.txtRG.TabIndex = 2;
            // 
            // lblRG
            // 
            this.lblRG.AutoSize = true;
            this.lblRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRG.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblRG.Location = new System.Drawing.Point(323, 59);
            this.lblRG.Name = "lblRG";
            this.lblRG.Size = new System.Drawing.Size(33, 17);
            this.lblRG.TabIndex = 47;
            this.lblRG.Text = "RG:";
            // 
            // txtCPF
            // 
            this.txtCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtCPF.Location = new System.Drawing.Point(84, 57);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(217, 23);
            this.txtCPF.TabIndex = 1;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPF.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCPF.Location = new System.Drawing.Point(16, 59);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(38, 17);
            this.lblCPF.TabIndex = 45;
            this.lblCPF.Text = "CPF:";
            // 
            // txtNomeCLiente
            // 
            this.txtNomeCLiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeCLiente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNomeCLiente.Location = new System.Drawing.Point(84, 23);
            this.txtNomeCLiente.Name = "txtNomeCLiente";
            this.txtNomeCLiente.Size = new System.Drawing.Size(500, 23);
            this.txtNomeCLiente.TabIndex = 0;
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblNomeCliente.Location = new System.Drawing.Point(16, 26);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(49, 17);
            this.lblNomeCliente.TabIndex = 43;
            this.lblNomeCliente.Text = "Nome:";
            // 
            // gbTelefones
            // 
            this.gbTelefones.Controls.Add(this.txtCelular);
            this.gbTelefones.Controls.Add(this.txtDDDCelular);
            this.gbTelefones.Controls.Add(this.lblCelular);
            this.gbTelefones.Controls.Add(this.txtTelefone);
            this.gbTelefones.Controls.Add(this.txtDDDTelefone);
            this.gbTelefones.Controls.Add(this.label5);
            this.gbTelefones.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbTelefones.Location = new System.Drawing.Point(29, 407);
            this.gbTelefones.Name = "gbTelefones";
            this.gbTelefones.Size = new System.Drawing.Size(607, 61);
            this.gbTelefones.TabIndex = 68;
            this.gbTelefones.TabStop = false;
            this.gbTelefones.Text = "Telefones";
            // 
            // txtCelular
            // 
            this.txtCelular.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtCelular.Location = new System.Drawing.Point(457, 18);
            this.txtCelular.Mask = "999999999";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(111, 20);
            this.txtCelular.TabIndex = 16;
            // 
            // txtDDDCelular
            // 
            this.txtDDDCelular.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDDDCelular.Location = new System.Drawing.Point(390, 18);
            this.txtDDDCelular.Mask = "(999)";
            this.txtDDDCelular.Name = "txtDDDCelular";
            this.txtDDDCelular.Size = new System.Drawing.Size(60, 20);
            this.txtDDDCelular.TabIndex = 15;
            // 
            // lblCelular
            // 
            this.lblCelular.AutoSize = true;
            this.lblCelular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCelular.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCelular.Location = new System.Drawing.Point(323, 21);
            this.lblCelular.Name = "lblCelular";
            this.lblCelular.Size = new System.Drawing.Size(56, 17);
            this.lblCelular.TabIndex = 67;
            this.lblCelular.Text = "Celular:";
            // 
            // txtTelefone
            // 
            this.txtTelefone.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtTelefone.Location = new System.Drawing.Point(175, 20);
            this.txtTelefone.Mask = "999999999";
            this.txtTelefone.Name = "txtTelefone";
            this.txtTelefone.Size = new System.Drawing.Size(111, 20);
            this.txtTelefone.TabIndex = 14;
            // 
            // txtDDDTelefone
            // 
            this.txtDDDTelefone.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDDDTelefone.Location = new System.Drawing.Point(106, 20);
            this.txtDDDTelefone.Mask = "(999)";
            this.txtDDDTelefone.Name = "txtDDDTelefone";
            this.txtDDDTelefone.Size = new System.Drawing.Size(60, 20);
            this.txtDDDTelefone.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label5.Location = new System.Drawing.Point(11, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 64;
            this.label5.Text = "Telefone:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PDVForms.Properties.Resources.cadastroCliente;
            this.pictureBox1.Location = new System.Drawing.Point(29, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 69;
            this.pictureBox1.TabStop = false;
            // 
            // ucEnderecoCliente
            // 
            this.ucEnderecoCliente.Location = new System.Drawing.Point(23, 242);
            this.ucEnderecoCliente.Name = "ucEnderecoCliente";
            this.ucEnderecoCliente.Size = new System.Drawing.Size(622, 166);
            this.ucEnderecoCliente.TabIndex = 70;
            // 
            // frmManutencaoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 528);
            this.Controls.Add(this.ucEnderecoCliente);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbTelefones);
            this.Controls.Add(this.gbDadosPessoais);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIncluir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManutencaoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmCadastroCliente";
            this.Load += new System.EventHandler(this.frmManutencaoCliente_Load);
            this.gbDadosPessoais.ResumeLayout(false);
            this.gbDadosPessoais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbTelefones.ResumeLayout(false);
            this.gbTelefones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.TextBox txtSocial;
        private System.Windows.Forms.Label lblSocial;
        private System.Windows.Forms.TextBox txtWebSite;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbDadosPessoais;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtRG;
        private System.Windows.Forms.Label lblRG;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.TextBox txtNomeCLiente;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.GroupBox gbTelefones;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.MaskedTextBox txtDDDCelular;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.MaskedTextBox txtDDDTelefone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ucEndereco ucEnderecoCliente;        
    }
}