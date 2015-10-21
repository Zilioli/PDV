namespace PDVForms
{
    partial class frmManutencaoFornecedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManutencaoFornecedor));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnIncluir = new System.Windows.Forms.Button();
            this.tabManutencaoFornecedor = new System.Windows.Forms.TabControl();
            this.tabFornecedor = new System.Windows.Forms.TabPage();
            this.gbTelefones = new System.Windows.Forms.GroupBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtDDDCelular = new System.Windows.Forms.MaskedTextBox();
            this.lblCelular = new System.Windows.Forms.Label();
            this.txtTelefone = new System.Windows.Forms.MaskedTextBox();
            this.txtDDDTelefone = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbDadosFornecedor = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCNPJ = new System.Windows.Forms.TextBox();
            this.lblCNPJ = new System.Windows.Forms.Label();
            this.txtNomeFornecedor = new System.Windows.Forms.TextBox();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.txtWebSite = new System.Windows.Forms.TextBox();
            this.lblWebSite = new System.Windows.Forms.Label();
            this.lblSocial = new System.Windows.Forms.Label();
            this.txtSocial = new System.Windows.Forms.TextBox();
            this.tabContatos = new System.Windows.Forms.TabPage();
            this.gbListagem = new System.Windows.Forms.GroupBox();
            this.dtgContatos = new System.Windows.Forms.DataGridView();
            this.gbContato = new System.Windows.Forms.GroupBox();
            this.btnCancelarContato = new System.Windows.Forms.Button();
            this.btnConfirmarContato = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.txtNuCelularContato = new System.Windows.Forms.MaskedTextBox();
            this.txtDDDCelularContato = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnNovo = new System.Windows.Forms.Button();
            this.txtNuTelefoneContato = new System.Windows.Forms.MaskedTextBox();
            this.txtDDDContato = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContato = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ucEnderecoFornecedor = new PDVForms.ucEndereco();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabManutencaoFornecedor.SuspendLayout();
            this.tabFornecedor.SuspendLayout();
            this.gbTelefones.SuspendLayout();
            this.gbDadosFornecedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabContatos.SuspendLayout();
            this.gbListagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgContatos)).BeginInit();
            this.gbContato.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PDVForms.Properties.Resources.supplier;
            this.pictureBox1.Location = new System.Drawing.Point(24, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 76;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitulo.Location = new System.Drawing.Point(71, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(245, 25);
            this.lblTitulo.TabIndex = 72;
            this.lblTitulo.Text = "Cadastro de Fornecedor";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelar.Image = global::PDVForms.Properties.Resources.cancelar;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(552, 532);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 35);
            this.btnCancelar.TabIndex = 71;
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
            this.btnIncluir.Location = new System.Drawing.Point(444, 532);
            this.btnIncluir.Name = "btnIncluir";
            this.btnIncluir.Size = new System.Drawing.Size(102, 35);
            this.btnIncluir.TabIndex = 70;
            this.btnIncluir.Text = "Confirmar";
            this.btnIncluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIncluir.UseVisualStyleBackColor = true;
            this.btnIncluir.Click += new System.EventHandler(this.btnIncluir_Click);
            // 
            // tabManutencaoFornecedor
            // 
            this.tabManutencaoFornecedor.Controls.Add(this.tabFornecedor);
            this.tabManutencaoFornecedor.Controls.Add(this.tabContatos);
            this.tabManutencaoFornecedor.Location = new System.Drawing.Point(23, 43);
            this.tabManutencaoFornecedor.Name = "tabManutencaoFornecedor";
            this.tabManutencaoFornecedor.SelectedIndex = 0;
            this.tabManutencaoFornecedor.Size = new System.Drawing.Size(626, 480);
            this.tabManutencaoFornecedor.TabIndex = 52;
            this.tabManutencaoFornecedor.SelectedIndexChanged += new System.EventHandler(this.tabManutencaoFornecedor_SelectedIndexChanged);
            this.tabManutencaoFornecedor.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabManutencaoFornecedor_Selecting);
            // 
            // tabFornecedor
            // 
            this.tabFornecedor.Controls.Add(this.ucEnderecoFornecedor);
            this.tabFornecedor.Controls.Add(this.gbTelefones);
            this.tabFornecedor.Controls.Add(this.gbDadosFornecedor);
            this.tabFornecedor.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tabFornecedor.Location = new System.Drawing.Point(4, 22);
            this.tabFornecedor.Name = "tabFornecedor";
            this.tabFornecedor.Padding = new System.Windows.Forms.Padding(3);
            this.tabFornecedor.Size = new System.Drawing.Size(618, 454);
            this.tabFornecedor.TabIndex = 0;
            this.tabFornecedor.Text = "Fornecedor";
            this.tabFornecedor.UseVisualStyleBackColor = true;
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
            this.gbTelefones.Location = new System.Drawing.Point(6, 377);
            this.gbTelefones.Name = "gbTelefones";
            this.gbTelefones.Size = new System.Drawing.Size(607, 61);
            this.gbTelefones.TabIndex = 78;
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
            this.txtCelular.TabIndex = 15;
            // 
            // txtDDDCelular
            // 
            this.txtDDDCelular.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDDDCelular.Location = new System.Drawing.Point(390, 18);
            this.txtDDDCelular.Mask = "(999)";
            this.txtDDDCelular.Name = "txtDDDCelular";
            this.txtDDDCelular.Size = new System.Drawing.Size(60, 20);
            this.txtDDDCelular.TabIndex = 14;
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
            this.txtTelefone.TabIndex = 13;
            // 
            // txtDDDTelefone
            // 
            this.txtDDDTelefone.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDDDTelefone.Location = new System.Drawing.Point(106, 20);
            this.txtDDDTelefone.Mask = "(999)";
            this.txtDDDTelefone.Name = "txtDDDTelefone";
            this.txtDDDTelefone.Size = new System.Drawing.Size(60, 20);
            this.txtDDDTelefone.TabIndex = 12;
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
            // gbDadosFornecedor
            // 
            this.gbDadosFornecedor.Controls.Add(this.pictureBox2);
            this.gbDadosFornecedor.Controls.Add(this.txtEmail);
            this.gbDadosFornecedor.Controls.Add(this.lblEmail);
            this.gbDadosFornecedor.Controls.Add(this.txtCNPJ);
            this.gbDadosFornecedor.Controls.Add(this.lblCNPJ);
            this.gbDadosFornecedor.Controls.Add(this.txtNomeFornecedor);
            this.gbDadosFornecedor.Controls.Add(this.lblNomeCliente);
            this.gbDadosFornecedor.Controls.Add(this.txtWebSite);
            this.gbDadosFornecedor.Controls.Add(this.lblWebSite);
            this.gbDadosFornecedor.Controls.Add(this.lblSocial);
            this.gbDadosFornecedor.Controls.Add(this.txtSocial);
            this.gbDadosFornecedor.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbDadosFornecedor.Location = new System.Drawing.Point(5, 16);
            this.gbDadosFornecedor.Name = "gbDadosFornecedor";
            this.gbDadosFornecedor.Size = new System.Drawing.Size(608, 190);
            this.gbDadosFornecedor.TabIndex = 76;
            this.gbDadosFornecedor.TabStop = false;
            this.gbDadosFornecedor.Text = "Dados Gerais";
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
            // txtCNPJ
            // 
            this.txtCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCNPJ.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtCNPJ.Location = new System.Drawing.Point(84, 57);
            this.txtCNPJ.Name = "txtCNPJ";
            this.txtCNPJ.Size = new System.Drawing.Size(217, 23);
            this.txtCNPJ.TabIndex = 2;
            // 
            // lblCNPJ
            // 
            this.lblCNPJ.AutoSize = true;
            this.lblCNPJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNPJ.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCNPJ.Location = new System.Drawing.Point(16, 59);
            this.lblCNPJ.Name = "lblCNPJ";
            this.lblCNPJ.Size = new System.Drawing.Size(47, 17);
            this.lblCNPJ.TabIndex = 45;
            this.lblCNPJ.Text = "CNPJ:";
            // 
            // txtNomeFornecedor
            // 
            this.txtNomeFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeFornecedor.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNomeFornecedor.Location = new System.Drawing.Point(84, 23);
            this.txtNomeFornecedor.Name = "txtNomeFornecedor";
            this.txtNomeFornecedor.Size = new System.Drawing.Size(500, 23);
            this.txtNomeFornecedor.TabIndex = 1;
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
            // txtSocial
            // 
            this.txtSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSocial.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtSocial.Location = new System.Drawing.Point(84, 154);
            this.txtSocial.Name = "txtSocial";
            this.txtSocial.Size = new System.Drawing.Size(500, 23);
            this.txtSocial.TabIndex = 5;
            // 
            // tabContatos
            // 
            this.tabContatos.Controls.Add(this.gbListagem);
            this.tabContatos.Controls.Add(this.gbContato);
            this.tabContatos.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tabContatos.Location = new System.Drawing.Point(4, 22);
            this.tabContatos.Name = "tabContatos";
            this.tabContatos.Padding = new System.Windows.Forms.Padding(3);
            this.tabContatos.Size = new System.Drawing.Size(618, 454);
            this.tabContatos.TabIndex = 1;
            this.tabContatos.Text = "Contatos";
            this.tabContatos.UseVisualStyleBackColor = true;
            // 
            // gbListagem
            // 
            this.gbListagem.Controls.Add(this.dtgContatos);
            this.gbListagem.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbListagem.Location = new System.Drawing.Point(4, 108);
            this.gbListagem.Name = "gbListagem";
            this.gbListagem.Size = new System.Drawing.Size(608, 306);
            this.gbListagem.TabIndex = 81;
            this.gbListagem.TabStop = false;
            this.gbListagem.Text = "Listagem";
            // 
            // dtgContatos
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dtgContatos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgContatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgContatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dtgContatos.BackgroundColor = System.Drawing.Color.White;
            this.dtgContatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgContatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgContatos.Location = new System.Drawing.Point(6, 19);
            this.dtgContatos.MultiSelect = false;
            this.dtgContatos.Name = "dtgContatos";
            this.dtgContatos.ReadOnly = true;
            this.dtgContatos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dtgContatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgContatos.Size = new System.Drawing.Size(596, 285);
            this.dtgContatos.TabIndex = 0;
            this.dtgContatos.DoubleClick += new System.EventHandler(this.dtgContatos_DoubleClick);
            // 
            // gbContato
            // 
            this.gbContato.Controls.Add(this.btnCancelarContato);
            this.gbContato.Controls.Add(this.btnConfirmarContato);
            this.gbContato.Controls.Add(this.btnExcluir);
            this.gbContato.Controls.Add(this.txtNuCelularContato);
            this.gbContato.Controls.Add(this.txtDDDCelularContato);
            this.gbContato.Controls.Add(this.label7);
            this.gbContato.Controls.Add(this.btnNovo);
            this.gbContato.Controls.Add(this.txtNuTelefoneContato);
            this.gbContato.Controls.Add(this.txtDDDContato);
            this.gbContato.Controls.Add(this.label8);
            this.gbContato.Controls.Add(this.txtContato);
            this.gbContato.Controls.Add(this.label9);
            this.gbContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.gbContato.Location = new System.Drawing.Point(4, 6);
            this.gbContato.Name = "gbContato";
            this.gbContato.Size = new System.Drawing.Size(608, 96);
            this.gbContato.TabIndex = 77;
            this.gbContato.TabStop = false;
            this.gbContato.Text = "Contato";
            // 
            // btnCancelarContato
            // 
            this.btnCancelarContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnCancelarContato.Image = global::PDVForms.Properties.Resources.cancelar;
            this.btnCancelarContato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarContato.Location = new System.Drawing.Point(548, 52);
            this.btnCancelarContato.Name = "btnCancelarContato";
            this.btnCancelarContato.Size = new System.Drawing.Size(36, 36);
            this.btnCancelarContato.TabIndex = 76;
            this.btnCancelarContato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarContato.UseVisualStyleBackColor = true;
            this.btnCancelarContato.Visible = false;
            this.btnCancelarContato.Click += new System.EventHandler(this.btnCancelarContato_Click);
            // 
            // btnConfirmarContato
            // 
            this.btnConfirmarContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmarContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnConfirmarContato.Image = global::PDVForms.Properties.Resources.confirma;
            this.btnConfirmarContato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmarContato.Location = new System.Drawing.Point(508, 52);
            this.btnConfirmarContato.Name = "btnConfirmarContato";
            this.btnConfirmarContato.Size = new System.Drawing.Size(36, 36);
            this.btnConfirmarContato.TabIndex = 75;
            this.btnConfirmarContato.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmarContato.UseVisualStyleBackColor = true;
            this.btnConfirmarContato.Visible = false;
            this.btnConfirmarContato.Click += new System.EventHandler(this.btnConfirmarContato_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluir.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnExcluir.Image = global::PDVForms.Properties.Resources.less;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluir.Location = new System.Drawing.Point(548, 52);
            this.btnExcluir.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(36, 36);
            this.btnExcluir.TabIndex = 73;
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // txtNuCelularContato
            // 
            this.txtNuCelularContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNuCelularContato.Location = new System.Drawing.Point(389, 59);
            this.txtNuCelularContato.Mask = "999999999";
            this.txtNuCelularContato.Name = "txtNuCelularContato";
            this.txtNuCelularContato.Size = new System.Drawing.Size(93, 20);
            this.txtNuCelularContato.TabIndex = 72;
            // 
            // txtDDDCelularContato
            // 
            this.txtDDDCelularContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDDDCelularContato.Location = new System.Drawing.Point(322, 59);
            this.txtDDDCelularContato.Mask = "(999)";
            this.txtDDDCelularContato.Name = "txtDDDCelularContato";
            this.txtDDDCelularContato.Size = new System.Drawing.Size(60, 20);
            this.txtDDDCelularContato.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label7.Location = new System.Drawing.Point(255, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 70;
            this.label7.Text = "Celular:";
            // 
            // btnNovo
            // 
            this.btnNovo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovo.ForeColor = System.Drawing.Color.MidnightBlue;
            this.btnNovo.Image = global::PDVForms.Properties.Resources.plus;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(508, 52);
            this.btnNovo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(36, 36);
            this.btnNovo.TabIndex = 69;
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // txtNuTelefoneContato
            // 
            this.txtNuTelefoneContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtNuTelefoneContato.Location = new System.Drawing.Point(153, 59);
            this.txtNuTelefoneContato.Mask = "999999999";
            this.txtNuTelefoneContato.Name = "txtNuTelefoneContato";
            this.txtNuTelefoneContato.Size = new System.Drawing.Size(96, 20);
            this.txtNuTelefoneContato.TabIndex = 68;
            // 
            // txtDDDContato
            // 
            this.txtDDDContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtDDDContato.Location = new System.Drawing.Point(84, 59);
            this.txtDDDContato.Mask = "(999)";
            this.txtDDDContato.Name = "txtDDDContato";
            this.txtDDDContato.Size = new System.Drawing.Size(60, 20);
            this.txtDDDContato.TabIndex = 67;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label8.Location = new System.Drawing.Point(6, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 45;
            this.label8.Text = "Telefone:";
            // 
            // txtContato
            // 
            this.txtContato.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContato.ForeColor = System.Drawing.Color.MidnightBlue;
            this.txtContato.Location = new System.Drawing.Point(84, 23);
            this.txtContato.Name = "txtContato";
            this.txtContato.Size = new System.Drawing.Size(500, 23);
            this.txtContato.TabIndex = 44;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label9.Location = new System.Drawing.Point(6, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "Nome:";
            // 
            // ucEnderecoFornecedor
            // 
            this.ucEnderecoFornecedor.Location = new System.Drawing.Point(-2, 209);
            this.ucEnderecoFornecedor.Name = "ucEnderecoFornecedor";
            this.ucEnderecoFornecedor.Size = new System.Drawing.Size(622, 166);
            this.ucEnderecoFornecedor.TabIndex = 79;
            // 
            // frmManutencaoFornecedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 579);
            this.Controls.Add(this.tabManutencaoFornecedor);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnIncluir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(680, 567);
            this.Name = "frmManutencaoFornecedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manutenção de Fornecedor";
            this.Load += new System.EventHandler(this.frmManutencaoFornecedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabManutencaoFornecedor.ResumeLayout(false);
            this.tabFornecedor.ResumeLayout(false);
            this.gbTelefones.ResumeLayout(false);
            this.gbTelefones.PerformLayout();
            this.gbDadosFornecedor.ResumeLayout(false);
            this.gbDadosFornecedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabContatos.ResumeLayout(false);
            this.gbListagem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgContatos)).EndInit();
            this.gbContato.ResumeLayout(false);
            this.gbContato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnIncluir;
        private System.Windows.Forms.TabControl tabManutencaoFornecedor;
        private System.Windows.Forms.TabPage tabFornecedor;
        private System.Windows.Forms.GroupBox gbTelefones;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.MaskedTextBox txtDDDCelular;
        private System.Windows.Forms.Label lblCelular;
        private System.Windows.Forms.MaskedTextBox txtTelefone;
        private System.Windows.Forms.MaskedTextBox txtDDDTelefone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbDadosFornecedor;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCNPJ;
        private System.Windows.Forms.Label lblCNPJ;
        private System.Windows.Forms.TextBox txtNomeFornecedor;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.TextBox txtWebSite;
        private System.Windows.Forms.Label lblWebSite;
        private System.Windows.Forms.Label lblSocial;
        private System.Windows.Forms.TextBox txtSocial;
        private System.Windows.Forms.TabPage tabContatos;
        private System.Windows.Forms.GroupBox gbContato;
        private System.Windows.Forms.TextBox txtContato;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtNuTelefoneContato;
        private System.Windows.Forms.MaskedTextBox txtDDDContato;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.GroupBox gbListagem;
        private System.Windows.Forms.DataGridView dtgContatos;
        private System.Windows.Forms.MaskedTextBox txtNuCelularContato;
        private System.Windows.Forms.MaskedTextBox txtDDDCelularContato;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnCancelarContato;
        private System.Windows.Forms.Button btnConfirmarContato;
        private ucEndereco ucEnderecoFornecedor;
    }
}