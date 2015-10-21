#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOPDV;
using BOPDV;
#endregion

namespace PDVForms
{
    public partial class frmManutencaoFornecedor : Form
    {
        #region VOGridContato
        private class VOGridContato
        {
            private string _ID_CONTATO = "";
            private string _NM_CONTATO = "";
            private string _TELEFONE = "";
            private string _CELULAR = "";
            private string _DDD = "";
            private string _NU_TELEFONE = "";
            private string _TP_TELEFONE = "";
            private string _DDD_CELULAR = "";
            private string _NU_TELEFONE_CELULAR = "";
            private string _TP_TELEFONE_CELULAR = "";

            public string ID_CONTATO
            {
                get { return _ID_CONTATO; }
                set { _ID_CONTATO = value; }
            }

            public string NOME
            {
                get { return _NM_CONTATO; }
                set { _NM_CONTATO = value; }
            }

            public string TELEFONE
            {
                get { return _TELEFONE; }
                set { _TELEFONE = value; }
            }

            public string CELULAR
            {
                get { return _CELULAR; }
                set { _CELULAR = value; }
            }

            public string DDD
            {
                get { return _DDD; }
                set { _DDD = value; }
            }
            public string NU_TELEFONE
            {
                get { return _NU_TELEFONE; }
                set { _NU_TELEFONE = value; }
            }

            public string TP_TELEFONE
            {
                get { return _TP_TELEFONE; }
                set { _TP_TELEFONE = value; }
            }

            public string DDD_CELUAR
            {
                get { return _DDD_CELULAR; }
                set { _DDD_CELULAR = value; }
            }
            public string NU_TELEFONE_CELULAR
            {
                get { return _NU_TELEFONE_CELULAR; }
                set { _NU_TELEFONE_CELULAR = value; }
            }

            public string TP_TELEFONE_CELULAR
            {
                get { return _TP_TELEFONE_CELULAR; }
                set { _TP_TELEFONE_CELULAR = value; }
            }
        }
        #endregion

        #region Variáveis e Constantes
        private VOFornecedor objVOFornecedor;
        private PDVForms.Util.clsUtil.ACAO ACAO = Util.clsUtil.ACAO.INCLUIR;
        List<VOGridContato> LISTA_CONTATO = new List<VOGridContato>();
        #endregion

        #region frmManutencaoFornecedor
        public frmManutencaoFornecedor()
        {
            InitializeComponent();
        }

        public frmManutencaoFornecedor(VOFornecedor pVOFornecedor, PDVForms.Util.clsUtil.ACAO pACAO)
        {
            InitializeComponent();
            objVOFornecedor = pVOFornecedor;
            ACAO = pACAO;
        }
        #endregion

        #region frmManutencaoFornecedor_Load
        private void frmManutencaoFornecedor_Load(object sender, EventArgs e)
        {
            CarregarTela();

            if (ACAO == Util.clsUtil.ACAO.DETALHAR)
                Util.clsUtil.ConfiguraTelaDetalhar(this.Controls);
        }
        #endregion

        #region CarregarTela
        private void CarregarTela()
        {
            txtNomeFornecedor.Focus();

            //carrega o combo de estados
            ucEnderecoFornecedor.CarregarEstados();
            
            //Altera os icones dos botões
            btnNovo.Image = new Bitmap(Properties.Resources.plus, new Size(24, 24));
            btnExcluir.Image = new Bitmap(Properties.Resources.less, new Size(24, 24));

            if (ACAO == Util.clsUtil.ACAO.ALTERAR || ACAO == Util.clsUtil.ACAO.DETALHAR)
            {
                CarregarDadosGeraisFornecedor();                
                CarregarContatosFornecedores();
            }
            
            Util.clsUtil.FormataDataGrid(dtgContatos);  
        }
        #endregion

        #region CarregarDadosGeraisFornecedor
        private void CarregarDadosGeraisFornecedor()
        {
            txtNomeFornecedor.Text = objVOFornecedor.NOME;
            txtCNPJ.Text = objVOFornecedor.CPF_CNPJ;
            txtEmail.Text = objVOFornecedor.EMAIL;
            txtWebSite.Text = objVOFornecedor.WEB_SITE;
            txtSocial.Text = objVOFornecedor.URL_SOCIAL;

            //carrega o endereco do fornecedor
            if (objVOFornecedor.ENDERECOS.Count > 0)
                ucEnderecoFornecedor.CarregarEndereco(objVOFornecedor.ENDERECOS[0]);  

            //Verifica se o fornecedor possui numero de telefones cadastrados
            if (objVOFornecedor.TELEFONES.Count > 0)
            {
                if (objVOFornecedor.TELEFONES.Exists(t => t.TP_TELEFONE == Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1)))
                {
                    txtTelefone.Text = objVOFornecedor.TELEFONES.Find(t => t.TP_TELEFONE == Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1)).NU_TELEFONE;
                    txtDDDTelefone.Text = objVOFornecedor.TELEFONES.Find(t => t.TP_TELEFONE == Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1)).DDD;
                }

                if (objVOFornecedor.TELEFONES.Exists(t => t.TP_TELEFONE == Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1)))
                {
                    txtCelular.Text = objVOFornecedor.TELEFONES.Find(t => t.TP_TELEFONE == Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1)).NU_TELEFONE;
                    txtDDDCelular.Text = objVOFornecedor.TELEFONES.Find(t => t.TP_TELEFONE == Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1)).DDD;
                }
            }
        }
        #endregion

        #region CarregarContatosFornecedores
        private void CarregarContatosFornecedores()
        {
            VOGridContato objGrid;

            foreach (VOPessoa objContato in objVOFornecedor.CONTATOS)
            {
                objGrid = new VOGridContato();
                objGrid.ID_CONTATO = objContato.ID_PESSOA;
                objGrid.NOME = objContato.NOME;

                foreach (VOTelefone objTelefone in objContato.TELEFONES)
                {
                    if (objTelefone.NU_TELEFONE != "" && objTelefone.TP_TELEFONE == "C")
                    {
                        objGrid.CELULAR = "(" + objTelefone.DDD.PadLeft(3, '0') + ")" + objTelefone.NU_TELEFONE;
                        objGrid.DDD_CELUAR = objTelefone.DDD.PadLeft(3, '0');
                        objGrid.NU_TELEFONE_CELULAR = objTelefone.NU_TELEFONE;
                        objGrid.TP_TELEFONE_CELULAR = objTelefone.TP_TELEFONE;
                    }
                    else if (objTelefone.NU_TELEFONE != "")
                    {
                        objGrid.TELEFONE = "(" + objTelefone.DDD.PadLeft(3, '0') + ")" + objTelefone.NU_TELEFONE;
                        objGrid.DDD = objTelefone.DDD.PadLeft(3, '0');
                        objGrid.NU_TELEFONE = objTelefone.NU_TELEFONE;
                        objGrid.TP_TELEFONE = objTelefone.TP_TELEFONE;
                    }

                }

                LISTA_CONTATO.Add(objGrid);
            }

            dtgContatos.DataSource = LISTA_CONTATO;
            dtgContatos.ClearSelection();

            dtgContatos.Columns["ID_CONTATO"].Visible = false;
            dtgContatos.Columns["DDD"].Visible = false;
            dtgContatos.Columns["NU_TELEFONE"].Visible = false;
            dtgContatos.Columns["TP_TELEFONE"].Visible = false;
            dtgContatos.Columns["DDD_CELUAR"].Visible = false;
            dtgContatos.Columns["NU_TELEFONE_CELULAR"].Visible = false;
            dtgContatos.Columns["TP_TELEFONE_CELULAR"].Visible = false;
        }
        #endregion

        #region tabManutencaoFornecedor_SelectedIndexChanged
        private void tabManutencaoFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se o usuário estiver incluindo um novo fornecedor a aba Contato não poderá estar ativa
            if (((TabControl)sender).SelectedTab == tabContatos && ACAO == Util.clsUtil.ACAO.INCLUIR)
            {
                Util.clsUtil.ExibirMensagem("Contatos não podem ser incluídos enquanto o fornecedor não for cadastrado",
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabManutencaoFornecedor.SelectedTab = tabFornecedor;
            }
        }
        #endregion

        #region btnCancelar_Click
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region btnIncluir_Click
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (tabManutencaoFornecedor.SelectedTab == tabFornecedor)
                this.IncluirFornecedor();
            else
                this.IncluirContatos();

        }
        #endregion

        #region PreencherObjeto
        private void PreencherObjeto(ref VOFornecedor pFornecedor)
        {
            VOTelefone objVOTelefone;
            VOEndereco objVOEndereco = new VOEndereco();

            //Preenche as informações básicas do fornecedor
            pFornecedor.NOME = txtNomeFornecedor.Text;
            pFornecedor.CPF_CNPJ = txtCNPJ.Text;
            pFornecedor.EMAIL = txtEmail.Text;
            pFornecedor.WEB_SITE = txtWebSite.Text;
            pFornecedor.URL_SOCIAL = txtSocial.Text;

            //adiciona os dados do endereco
            pFornecedor.ENDERECOS[0] = ucEnderecoFornecedor.PreencherEndereco() ;

            //Preenche as informações contendo os telefones
            if (pFornecedor.TELEFONES.Count > 0)
                pFornecedor.TELEFONES.Clear();

            //Verifica se o número do telefone foi informado
            if (txtTelefone.Text != "" && txtDDDTelefone.Text != "")
            {
                objVOTelefone = new VOTelefone();
                objVOTelefone.NU_TELEFONE = txtTelefone.Text;
                objVOTelefone.DDD = txtDDDTelefone.Text;
                objVOTelefone.TP_TELEFONE = Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1);
                pFornecedor.TELEFONES.Add(objVOTelefone);
                objVOTelefone = null;

            }

            if (txtCelular.Text != "" && txtDDDCelular.Text != "")
            {
                objVOTelefone = new VOTelefone();
                objVOTelefone.NU_TELEFONE = txtCelular.Text;
                objVOTelefone.DDD = txtDDDCelular.Text;
                objVOTelefone.TP_TELEFONE = Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1);
                pFornecedor.TELEFONES.Add(objVOTelefone);
                objVOTelefone = null;
            }
        }
        #endregion

        #region ValidaForm
        private bool ValidaForm()
        {
            bool validou = true;

            //Verifica se o nome do fornecedor foi preenchido
            if (txtNomeFornecedor.Text == "")
                validou = false;

            //valida endereco
            validou = ucEnderecoFornecedor.ValidaForm();

            //Os campos DDD e numero precisam estar preenchidos
            if ((txtNuTelefoneContato.Text != "" && txtDDDContato.Text.Replace("(", "").Replace(")", "").Trim() == "") ||
                (txtNuTelefoneContato.Text == "" && txtDDDContato.Text.Replace("(", "").Replace(")", "").Trim() != ""))
                validou = false;

            //Os campos DDD e numero precisam estar preenchidos
            if ((txtCelular.Text != "" && txtDDDCelular.Text.Replace("(", "").Replace(")", "").Trim() == "") ||
                (txtCelular.Text == "" && txtDDDCelular.Text.Replace("(", "").Replace(")", "").Trim() != ""))
                validou = false;

            //Verifica se algum campo obrigatório deixou de ser preenchido
            if (!validou)
                Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_CAMPOS_OBRIGATORIOS,
                                       "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return validou;
        }
        #endregion
                
        #region IncluirFornecedor
        private void IncluirFornecedor()
        {
            VOFornecedor objVO;
            BOFornecedor objFornecedor = new BOFornecedor();
            try
            {
                //Verifica se ao menos o campo Nome foi preenchido corretamente
                if (ValidaForm())
                {
                    objVO = new VOFornecedor();

                    if (ACAO == Util.clsUtil.ACAO.ALTERAR)
                        objVO = objVOFornecedor;

                    PreencherObjeto(ref objVO);

                    if (objFornecedor.ManutencaoFornecedor(ref objVO, (ACAO == Util.clsUtil.ACAO.ALTERAR ? 'A' : 'I')))
                    {

                        Util.clsUtil.ExibirMensagem((ACAO == Util.clsUtil.ACAO.ALTERAR ? Util.clsUtil.MSG_ALTERACAO : Util.clsUtil.MSG_INCLUSAO),
                                "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Recupera o valor do ultimo registro incluído
                        objVOFornecedor = new VOFornecedor();
                        objVOFornecedor.ID_FORNECEDOR = objVO.ID_FORNECEDOR;

                        //Se a ação for de inclusão, verificar se o usuário deseja cadastrar contatos do fornecedor
                        if (ACAO == Util.clsUtil.ACAO.INCLUIR)
                        {
                            if (Util.clsUtil.ExibirMensagemConfirmacao("Deseja cadastrar contatos para esse fornecedor?"))
                            {
                                ACAO = Util.clsUtil.ACAO.ALTERAR;
                                tabManutencaoFornecedor.SelectedTab = tabContatos;
                            }
                            else
                                this.Close();
                        }
                        else
                            this.Close();
                    }
                    else
                        Util.clsUtil.ExibirMensagem("Problemas ao " + (ACAO == Util.clsUtil.ACAO.ALTERAR ? "alterar" : "incluir") + " o registro",
                            "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Manutenção de Fornecedores: " + ex.Message,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Finaliza os objetos
                objVO = null;
                objFornecedor = null;
            }
        }
        #endregion

        #region IncluirContatos
        private void IncluirContatos()
        {
            VOFornecedor objVO = new VOFornecedor();
            VOPessoa objPessoa;
            VOTelefone objTelefone;
            BOFornecedor objBOFornecedor = new BOFornecedor();
            VOGridContato objItem;

            try
            {
                //Verifica se o grid possui algum item inlcuido
                if (dtgContatos.Rows.Count > 0)
                {
                    objVO.ID_FORNECEDOR = objVOFornecedor.ID_FORNECEDOR;

                    foreach (DataGridViewRow objRow in dtgContatos.Rows)
                    {
                        objItem = (VOGridContato)objRow.DataBoundItem;
                        objPessoa = new VOPessoa();
                        objPessoa.NOME = objItem.NOME;

                        if (objItem.DDD.Replace("(", "").Replace(")", "").Trim() != "" && objItem.NU_TELEFONE != "")
                        {
                            objTelefone = new VOTelefone();
                            objTelefone.DDD = objItem.DDD.Replace("(", "").Replace(")", "");
                            objTelefone.NU_TELEFONE = objItem.NU_TELEFONE;
                            objTelefone.TP_TELEFONE = Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1);
                            objPessoa.TELEFONES.Add(objTelefone);
                            objTelefone = null;
                        }

                        if (objItem.DDD_CELUAR.Replace("(", "").Replace(")", "").Trim() != "" && objItem.CELULAR != "")
                        {
                            objTelefone = new VOTelefone();
                            objTelefone.DDD = objItem.DDD_CELUAR.Replace("(", "").Replace(")", "");
                            objTelefone.NU_TELEFONE = objItem.NU_TELEFONE_CELULAR;
                            objTelefone.TP_TELEFONE = Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1);
                            objPessoa.TELEFONES.Add(objTelefone);
                            objTelefone = null;
                        }

                        objVO.CONTATOS.Add(objPessoa);
                    }

                    if (objBOFornecedor.IncluirContatos(objVO))
                    {
                        Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_INCLUSAO,
                            "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }

                }
                else
                    Util.clsUtil.ExibirMensagem("O Grid de Contatos não possui nenhum item a ser incluído.",
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Manutenção de Fornecedores: " + ex.Message,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Finaliza o objetos
                objVO = null;
            }
        }
        #endregion
       
        #region btnNovo_Click
        private void btnNovo_Click(object sender, EventArgs e)
        {
            VOGridContato objVO = new VOGridContato();

            try
            {
                if (txtContato.Text.Trim() != "")
                {
                    objVO.NOME = txtContato.Text;

                    //Verifica se os telefones foram infomados
                    if (txtDDDContato.Text != "" && txtNuTelefoneContato.Text != "")
                    {
                        objVO.DDD = txtDDDContato.Text;
                        objVO.NU_TELEFONE = txtNuTelefoneContato.Text;
                        objVO.TP_TELEFONE = Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1);
                        objVO.TELEFONE =  txtDDDContato.Text.PadLeft(3, '0') +  objVO.NU_TELEFONE;
                    }

                    //Verifica se os telefones foram infomados
                    if (txtDDDCelularContato.Text != "" && txtNuCelularContato.Text != "")
                    {
                        objVO.DDD_CELUAR = txtDDDCelularContato.Text;
                        objVO.NU_TELEFONE_CELULAR = txtNuCelularContato.Text;
                        objVO.TP_TELEFONE_CELULAR = Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1);
                        objVO.CELULAR =  txtDDDCelularContato.Text.PadLeft(3, '0') +objVO.NU_TELEFONE_CELULAR;
                    }

                    //Adiciona no grid
                    LISTA_CONTATO.Add(objVO);

                    dtgContatos.DataSource = null;
                    dtgContatos.DataSource = LISTA_CONTATO;
                    dtgContatos.ClearSelection();

                    dtgContatos.Columns["ID_CONTATO"].Visible = false;
                    dtgContatos.Columns["DDD"].Visible = false;
                    dtgContatos.Columns["NU_TELEFONE"].Visible = false;
                    dtgContatos.Columns["TP_TELEFONE"].Visible = false;
                    dtgContatos.Columns["DDD_CELUAR"].Visible = false;
                    dtgContatos.Columns["NU_TELEFONE_CELULAR"].Visible = false;
                    dtgContatos.Columns["TP_TELEFONE_CELULAR"].Visible = false;

                    txtContato.Text = "";
                    txtDDDContato.Text = "";
                    txtNuTelefoneContato.Text = "";
                    txtDDDCelularContato.Text = "";
                    txtNuCelularContato.Text = "";
                    txtContato.Focus();
                }
                else
                    Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_CAMPOS_OBRIGATORIOS,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Manutenção de Fornecedores: " + ex.Message,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Finaliza os objetos
                objVO = null;
            }
        }
        #endregion

        #region btnExcluir_Click
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgContatos.Rows.Count > 0)
                {
                    LISTA_CONTATO.RemoveAt(dtgContatos.SelectedRows[0].Index);
                    dtgContatos.DataSource = null;
                    dtgContatos.DataSource = LISTA_CONTATO;
                    dtgContatos.ClearSelection();

                    dtgContatos.Columns["ID_CONTATO"].Visible = false;
                    dtgContatos.Columns["DDD"].Visible = false;
                    dtgContatos.Columns["NU_TELEFONE"].Visible = false;
                    dtgContatos.Columns["TP_TELEFONE"].Visible = false;
                    dtgContatos.Columns["DDD_CELUAR"].Visible = false;
                    dtgContatos.Columns["NU_TELEFONE_CELULAR"].Visible = false;
                    dtgContatos.Columns["TP_TELEFONE_CELULAR"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Manutenção de Fornecedores: " + ex.Message,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region dtgContatos_DoubleClick
        private void dtgContatos_DoubleClick(object sender, EventArgs e)
        {
            VOGridContato objVO = new VOGridContato();

            try
            {
                objVO = (VOGridContato)dtgContatos.SelectedRows[0].DataBoundItem;
                txtContato.Text = objVO.NOME;
                txtDDDContato.Text = objVO.DDD.Trim().PadLeft(3, '0');
                txtNuTelefoneContato.Text = objVO.NU_TELEFONE;
                txtDDDCelularContato.Text = objVO.DDD_CELUAR.Trim().PadLeft(3, '0');
                txtNuCelularContato.Text = objVO.NU_TELEFONE_CELULAR;

                btnNovo.Visible = false;
                btnExcluir.Visible = false;
                btnConfirmarContato.Visible = true;
                btnCancelarContato.Visible = true;

            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Manutenção de Fornecedores: " + ex.Message,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Finaliza os objetos
                objVO = null;
            }
        }
        #endregion

        #region btnConfirmarContato_Click
        private void btnConfirmarContato_Click(object sender, EventArgs e)
        {
            VOGridContato objVO;

            try
            {

                if (txtContato.Text.Trim() != "")
                {
                    objVO = (VOGridContato)dtgContatos.Rows[dtgContatos.SelectedRows[0].Index].DataBoundItem;

                    objVO.NOME = txtContato.Text;

                    //Verifica se os telefones foram infomados
                    if (txtDDDContato.Text != "" && txtNuTelefoneContato.Text != "")
                    {
                        objVO.DDD = txtDDDContato.Text;
                        objVO.NU_TELEFONE = txtNuTelefoneContato.Text;
                        objVO.TP_TELEFONE = Util.clsUtil.TIPO_TELEFONE.EMPRESARIAL.ToString().Substring(0, 1);
                        objVO.TELEFONE = txtDDDContato.Text.PadLeft(3, '0') + objVO.NU_TELEFONE;
                    }

                    //Verifica se os telefones foram infomados
                    if (txtDDDCelularContato.Text != "" && txtNuCelularContato.Text != "")
                    {
                        objVO.DDD_CELUAR = txtDDDCelularContato.Text;
                        objVO.NU_TELEFONE_CELULAR = txtNuCelularContato.Text;
                        objVO.TP_TELEFONE_CELULAR = Util.clsUtil.TIPO_TELEFONE.CELULAR.ToString().Substring(0, 1);
                        objVO.CELULAR = txtDDDCelularContato.Text.PadLeft(3, '0') + objVO.NU_TELEFONE_CELULAR;
                    }

                    //Remove o item antigo
                    LISTA_CONTATO.RemoveAt(dtgContatos.SelectedRows[0].Index);

                    //Insere o novo objeto com os valores atualizados
                    LISTA_CONTATO.Insert(dtgContatos.SelectedRows[0].Index, objVO);

                    dtgContatos.DataSource = null;
                    dtgContatos.DataSource = LISTA_CONTATO;
                    dtgContatos.ClearSelection();

                    dtgContatos.Columns["ID_CONTATO"].Visible = false;
                    dtgContatos.Columns["DDD"].Visible = false;
                    dtgContatos.Columns["NU_TELEFONE"].Visible = false;
                    dtgContatos.Columns["TP_TELEFONE"].Visible = false;
                    dtgContatos.Columns["DDD_CELUAR"].Visible = false;
                    dtgContatos.Columns["NU_TELEFONE_CELULAR"].Visible = false;
                    dtgContatos.Columns["TP_TELEFONE_CELULAR"].Visible = false;

                    btnNovo.Visible = true;
                    btnExcluir.Visible = true;
                    btnConfirmarContato.Visible = false;
                    btnCancelarContato.Visible = false;

                    txtContato.Text = "";
                    txtDDDContato.Text = "";
                    txtNuTelefoneContato.Text = "";
                    txtDDDCelularContato.Text = "";
                    txtNuCelularContato.Text = "";
                    txtContato.Focus();
                }
                else
                    Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_CAMPOS_OBRIGATORIOS,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Manutenção de Fornecedores: " + ex.Message,
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnCancelarContato_Click
        private void btnCancelarContato_Click(object sender, EventArgs e)
        {
            btnNovo.Visible = true;
            btnExcluir.Visible = true;
            btnConfirmarContato.Visible = false;
            btnCancelarContato.Visible = false;

            txtContato.Text = "";
            txtDDDContato.Text = "";
            txtNuTelefoneContato.Text = "";
            txtDDDCelularContato.Text = "";
            txtNuCelularContato.Text = "";
            txtContato.Focus();
        }
        #endregion

        #region tabManutencaoFornecedor_Selecting
        private void tabManutencaoFornecedor_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //Se o usuário estiver incluindo um novo fornecedor a aba Contato não poderá estar ativa
            if (((TabControl)sender).SelectedTab == tabContatos && ACAO == Util.clsUtil.ACAO.INCLUIR)
            {
                Util.clsUtil.ExibirMensagem("Contatos não podem ser incluídos enquanto o fornecedor não for cadastrado",
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabManutencaoFornecedor.SelectedTab = tabFornecedor;
            }
        }
        #endregion
    }
}