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
    public partial class frmListaClientes : Form
    {

        #region Variáveis
        private List<VOCliente> LISTA_CLIENTES;
        #endregion

        #region Classe VO do Grid de Clientes
        private class VOGrid
        {
            private string _ID_PESSOA = "";
            private string _ID_CLIENTE = "";
            private string _NOME = "";
            private string _TELEFONES = "";
            private string _CPF = "";
            private string _EMAIL = "";

            public string ID_PESSOA
            {
                get { return _ID_PESSOA; }
                set { _ID_PESSOA = value; }
            }

            public string ID_CLIENTE
            {
                get { return _ID_CLIENTE; }
                set { _ID_CLIENTE = value; }
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

            public string CPF
            {
                get { return _CPF; }
                set { _CPF = value; }
            }

            public string EMAIL
            {
                get { return _EMAIL; }
                set { _EMAIL = value; }
            }
        }
        #endregion

        #region frmListaFornecedores
        public frmListaClientes()
        {
            InitializeComponent();
        }
        #endregion

        #region frmListaFornecedores_Load
        private void frmListaClientes_Load(object sender, EventArgs e)
        {
            //Redimensiona o  tamanho os ícones dos botões
            btnNovo.Image = new Bitmap(Properties.Resources.new_record, new Size(24, 24));
            btnPesquisar.Image = new Bitmap(Properties.Resources.search, new Size(24, 24));
            btnAlterar.Image = new Bitmap(Properties.Resources.edit1, new Size(24, 24));
            btnExcluir.Image = new Bitmap(Properties.Resources.less, new Size(24, 24));

            ListarClientes(new VOCliente());
        }
        #endregion

        #region ListarClientes
        private void ListarClientes(VOCliente pCliente)
        {
            //Realiza a pesquisa de fornecedores
            BOCliente objCliente = new BOCliente();
            LISTA_CLIENTES = objCliente.ListarClientes(pCliente);
            dtgClientes.DataSource = this.PreencherVOGrid(LISTA_CLIENTES);
            dtgClientes.ClearSelection();

            //Formata o grid
            dtgClientes.Columns["ID_PESSOA"].Visible = false;
            dtgClientes.Columns["ID_CLIENTE"].Visible = false;
        }
        #endregion

        #region txtFiltro_KeyDown
        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                VOCliente objVO = new VOCliente();
                objVO.NOME = txtFiltro.Text;

                ListarClientes(objVO);

                objVO = null;
            }
        }
        #endregion

        #region PreencherVOGrid
        private List<VOGrid> PreencherVOGrid(List<VOCliente> pListaClientes)
        {
            VOGrid objVO;
            List<VOGrid> lstGrid = new List<VOGrid>();

            try
            {
                //Percorre a lista de Clientes e preenche a Lista que irá preencher o Grid
                foreach (VOCliente objCliente in pListaClientes)
                {
                    //Instancia e preenche o objeto
                    objVO = new VOGrid();
                    objVO.CPF = objCliente.CPF_CNPJ;
                    objVO.EMAIL = objCliente.EMAIL;
                    objVO.ID_CLIENTE = objCliente.ID_CLIENTE;
                    objVO.ID_PESSOA = objCliente.ID_PESSOA;
                    objVO.NOME = objCliente.NOME;

                    //Percorre a lista de telefones do fornecedor
                    foreach (VOTelefone objTelefone in objCliente.TELEFONES)
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
            VOCliente objVO = new VOCliente();
            objVO.NOME = txtFiltro.Text;

            ListarClientes(objVO);

            objVO = null;
        }
        #endregion

        #region btnNovo_Click
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmManutencaoCliente objFormManutencao = new frmManutencaoCliente();
            objFormManutencao.ShowDialog(this);
            ListarClientes(new VOCliente());
        }
        #endregion

        #region btnCancelar_Click
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ExcluirCliente
        private void ExcluirCliente(VOCliente pVOCliente)
        {
            BOCliente objCliente = new BOCliente();
            try
            {
                if (objCliente.ManutencaoCliente(pVOCliente, 'E'))
                {
                    clsUtil.ExibirMensagem(clsUtil.MSG_EXCLUSAO, "Manter Clientes");
                    ListarClientes(new VOCliente());
                }

            }
            catch (Exception ex)
            {
                clsUtil.ExibirMensagem(ex.Message, "Manter Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnAlterar_Click
        private void btnAlterar_Click(object sender, EventArgs e)
        {

            if (dtgClientes.SelectedRows.Count > 0)
            {
                frmManutencaoCliente objForm = new frmManutencaoCliente(LISTA_CLIENTES.Find(
                           f => f.ID_CLIENTE == ((VOGrid)(dtgClientes.SelectedRows[0].DataBoundItem)).ID_CLIENTE),
                           Util.clsUtil.ACAO.ALTERAR);

                clsUtil.AbreFormulario(objForm, this);

                ListarClientes(new VOCliente());
            }

        }
        #endregion

        #region btnExcluir_Click
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dtgClientes.SelectedRows.Count > 0)
            {
                if (clsUtil.ExibirMensagemConfirmacao(clsUtil.MSG_CONFIRMACAO_EXCLUSAO))
                    this.ExcluirCliente(LISTA_CLIENTES.Find(
                        f => f.ID_CLIENTE == ((VOGrid)(dtgClientes.SelectedRows[0].DataBoundItem)).ID_CLIENTE));
            }
        }
        #endregion


    }
}