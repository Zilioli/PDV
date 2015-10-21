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
using BOPDV;
using VOPDV;
using PDVForms.Util;
#endregion

namespace PDVForms
{
    public partial class frmListaFornecedores : Form
    {
        #region Variáveis
        private List<VOFornecedor> LISTA_FORNECEDORES;
        #endregion

        #region Classe VO do Gird Fornecedores
        private class VOGrid
        {
            private string _ID_PESSOA = "";
            private string _ID_FORNECEDOR = "";
            private string _NOME = "";
            private string _TELEFONES = "";
            private string _CNJP = "";
            private string _EMAIL = "";

            public string ID_PESSOA
            {
                get { return _ID_PESSOA; }
                set { _ID_PESSOA = value; }
            }

            public string ID_FORNECEDOR
            {
                get { return _ID_FORNECEDOR; }
                set { _ID_FORNECEDOR = value; }
            }

            public string NOME
            {
                get { return _NOME; }
                set { _NOME = value; }
            }

            public string TELEFONES
            {
                get { return _TELEFONES; }
                set { _TELEFONES = value; }
            }

            public string CNJP
            {
                get { return _CNJP; }
                set { _CNJP = value; }
            }

            public string EMAIL
            {
                get { return _EMAIL; }
                set { _EMAIL = value; }
            }
        }
        #endregion

        #region frmListaFornecedores
        public frmListaFornecedores()
        {
            InitializeComponent();
        }
        #endregion

        #region frmListaFornecedores_Load
        private void frmListaFornecedores_Load(object sender, EventArgs e)
        {
            //Redimensiona o  tamanho os ícones dos botões
            btnNovo.Image = new Bitmap(Properties.Resources.new_record, new Size(24, 24));
            btnPesquisar.Image = new Bitmap(Properties.Resources.search, new Size(24, 24));
            btnAlterar.Image = new Bitmap(Properties.Resources.edit1,  new Size(24, 24));
            btnExcluir.Image = new Bitmap(Properties.Resources.less, new Size(24, 24));

            ListarFornecedores(new VOFornecedor());

            Util.clsUtil.FormataDataGrid(dtgFornecedores);  
        }
        #endregion

        #region ListarFornecedores
        private void ListarFornecedores(VOFornecedor pFornecedor)
        {
            //Realiza a pesquisa de fornecedores
            BOFornecedor objFornecedor = new BOFornecedor();
            LISTA_FORNECEDORES = objFornecedor.ListarFornecedores(pFornecedor);
            dtgFornecedores.DataSource = this.PreencherVOGrid(LISTA_FORNECEDORES);
            dtgFornecedores.ClearSelection();

            //Formata o grid
            dtgFornecedores.Columns["ID_PESSOA"].Visible = false;
            dtgFornecedores.Columns["ID_FORNECEDOR"].Visible = false;
        }
        #endregion

        #region txtFiltro_KeyDown
        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                VOFornecedor objVO = new VOFornecedor();
                objVO.NOME = txtFiltro.Text;

                ListarFornecedores(objVO);

                objVO = null;
            }
        }
        #endregion

        #region PreencherVOGrid
        private List<VOGrid> PreencherVOGrid(List<VOFornecedor> pListaFornecedores)
        {
            VOGrid objVO;
            List<VOGrid> lstGrid = new List<VOGrid>();

            try
            {
                //Percorre a lista de Fornecedores e preenche a Lista que irá preencher o Grid
                foreach (VOFornecedor objFornecedor in pListaFornecedores)
                {
                    //Instancia e preenche o objeto
                    objVO = new VOGrid();
                    objVO.CNJP = objFornecedor.CPF_CNPJ;
                    objVO.EMAIL = objFornecedor.EMAIL;
                    objVO.ID_FORNECEDOR = objFornecedor.ID_FORNECEDOR;
                    objVO.ID_PESSOA = objFornecedor.ID_PESSOA;
                    objVO.NOME = objFornecedor.NOME;

                    //Percorre a lista de telefones do fornecedor
                    foreach (VOTelefone objTelefone in objFornecedor.TELEFONES)
                        if (objTelefone.NU_TELEFONE != "")
                            objVO.TELEFONES += "(" + objTelefone.DDD.PadLeft(3, '0') + ")" + objTelefone.NU_TELEFONE + "/";

                    //Formata o atributo telefones
                    if (objVO.TELEFONES != "")
                        objVO.TELEFONES = objVO.TELEFONES.Remove(objVO.TELEFONES.Length - 1, 1);

                    //Adiciona o item na lista
                    lstGrid.Add(objVO);

                    //Finaliza o objeto
                    objVO = null;
                }

                //Retorna a lista de fornecedores que irá preencher o grid
                return lstGrid;
            }
            catch (Exception ex)
            {
                //Tratamento de Erro
                throw ex;
            }
            finally
            {
                //Finaliza os objetos
                objVO = null;
                lstGrid = null;
            }
        }
        #endregion

        #region btnPesquisar_Click
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            VOFornecedor objVO = new VOFornecedor();
            objVO.NOME = txtFiltro.Text;

            ListarFornecedores(objVO);

            objVO = null;
        }
        #endregion

        #region btnNovo_Click
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmManutencaoFornecedor objFormManutencao = new frmManutencaoFornecedor();
            objFormManutencao.ShowDialog(this);
            ListarFornecedores(new VOFornecedor());
        }
        #endregion

        #region btnCancelar_Click
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ExcluirFornecedor
        private void ExcluirFornecedor(VOFornecedor pVOFornecedor)
        {
            BOFornecedor objFornecedor = new BOFornecedor();
            try
            {
                if (objFornecedor.ManutencaoFornecedor(ref pVOFornecedor, 'E'))
                {
                    clsUtil.ExibirMensagem(clsUtil.MSG_EXCLUSAO, "Manter Fornecedores");
                    ListarFornecedores(new VOFornecedor());
                }

            }
            catch (Exception ex)
            {
                clsUtil.ExibirMensagem(ex.Message, "Manter Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnAlterar_Click
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            frmManutencaoFornecedor objForm = new frmManutencaoFornecedor(LISTA_FORNECEDORES.Find(
                       f => f.ID_FORNECEDOR == ((VOGrid)(dtgFornecedores.SelectedRows[0].DataBoundItem)).ID_FORNECEDOR),
                       Util.clsUtil.ACAO.ALTERAR);

            clsUtil.AbreFormulario(objForm, this);

            ListarFornecedores(new VOFornecedor());
        }
        #endregion

        #region btnExcluir_Click
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (clsUtil.ExibirMensagemConfirmacao(clsUtil.MSG_CONFIRMACAO_EXCLUSAO))
                this.ExcluirFornecedor(LISTA_FORNECEDORES.Find(
                    f => f.ID_FORNECEDOR == ((VOGrid)(dtgFornecedores.SelectedRows[0].DataBoundItem)).ID_FORNECEDOR));
        }
        #endregion

        #region dtgFornecedores_DoubleClick
        private void dtgFornecedores_DoubleClick(object sender, EventArgs e)
        {
            frmManutencaoFornecedor objForm = new frmManutencaoFornecedor(LISTA_FORNECEDORES.Find(
                      f => f.ID_FORNECEDOR == ((VOGrid)(dtgFornecedores.SelectedRows[0].DataBoundItem)).ID_FORNECEDOR),
                      Util.clsUtil.ACAO.DETALHAR);

            clsUtil.AbreFormulario(objForm, this);
        }
        #endregion 

    }
}