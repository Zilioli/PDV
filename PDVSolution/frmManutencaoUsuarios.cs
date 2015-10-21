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

#endregion

namespace PDVForms
{
    public partial class frmManutencaoUsuarios : Form
    {
        #region Variáveis

        private Util.clsUtil.ACAO ACAO = Util.clsUtil.ACAO.INCLUIR;
        private VOUsuario objVO;

        #endregion

        #region Construtores
        public frmManutencaoUsuarios()
        {
            InitializeComponent();
        }

        public frmManutencaoUsuarios(VOUsuario pVOUsuario, Util.clsUtil.ACAO pACAO)
        {
            InitializeComponent();
            ACAO = pACAO;
            objVO = pVOUsuario;
        }

        #endregion

        #region frmManutencaoUsuarios_Load
        private void frmManutencaoUsuarios_Load(object sender, EventArgs e)
        {
            CarregaListaTelas();

            if (ACAO == Util.clsUtil.ACAO.ALTERAR || ACAO == Util.clsUtil.ACAO.DETALHAR)
            {
                txtNomeUsuario.Text = objVO.NMUSUARIO;
                txtLogin.Text = objVO.LOGIN;
                RecuperaAcessosUsuario(ref objVO);
                treeViewAcessos.ExpandAll();
                PreecherTreeViewAcesso();

                if (ACAO == Util.clsUtil.ACAO.DETALHAR)
                    Util.clsUtil.ConfiguraTelaDetalhar(this.Controls);  
   
            }

        }
        #endregion

        #region CarregaListaTelas
        private void CarregaListaTelas()
        {
            BOTela objTela = new BOTela();
            List<VOItemMenu> lstItemMenu = new List<VOItemMenu>();
            TreeNode objNode;
            TreeNode objNodeTela;

            try
            {
                lstItemMenu = objTela.ListaTelas();
                //treeViewAcessos.ImageList = Properties.Resources;

                treeViewAcessos.CheckBoxes = true;
                foreach (VOItemMenu objItem in lstItemMenu)
                {
                    objNode = new TreeNode();
                    objNode.Text = objItem.NM_ITEM_MENU;
                    objNode.Name = "IM_" + objItem.ID_ITEM_MENU;
                    objNode.ImageKey = objItem.ICON + ".png";
                    treeViewAcessos.Nodes.Add(objNode);

                    foreach (VOTela objTelas in objItem.TELAS)
                    {
                        objNodeTela = new TreeNode();
                        objNodeTela.Text = objTelas.NM_TELA;
                        objNodeTela.Name = "T_" + objTelas.ID_TELA;
                        objNodeTela.ImageKey = objTelas.ICON + ".png";
                        objNode.Nodes.Add(objNodeTela);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objTela = null;
                lstItemMenu = null;
                objNode = null;
                objNodeTela = null;
            }
        }
        #endregion

        #region btnCancelar_Click
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region tabManutencaoUsuario_Selecting
        private void tabManutencaoUsuario_Selecting(object sender, TabControlCancelEventArgs e)
        {
            //Se o usuário estiver incluindo um novo fornecedor a aba Contato não poderá estar ativa
            if (((TabControl)sender).SelectedTab == tabAcesso && ACAO == Util.clsUtil.ACAO.INCLUIR)
            {
                Util.clsUtil.ExibirMensagem("Acessos não podem ser atribuídos enquanto o usuário não for cadastrado",
                    "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabManutencaoUsuario.SelectedTab = tabUsuario;
            }
        }
        #endregion

        #region btnIncluir_Click
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            IncluirUsuario();
        }

        #endregion

        #region RecuperaAcessosUsuario
        private void RecuperaAcessosUsuario(ref VOUsuario pVOUsuario)
        {
            BOUsuario objUsuario = new BOUsuario();
            try
            {
                pVOUsuario.ITENS_MENU.AddRange(objUsuario.ListaAcessosUsuario(ref pVOUsuario));
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO - " + ex.Message, "Manutenção de Usuários",
                        MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
            finally
            {
                objUsuario = null;
            }
        }
        #endregion

        #region PreecherTreeViewAcesso

        private void PreecherTreeViewAcesso()
        {
            foreach (VOItemMenu objItemMenu in objVO.ITENS_MENU)
                foreach (VOTela objTela in objItemMenu.TELAS)
                    treeViewAcessos.Nodes.Find("T_" + objTela.ID_TELA, true)[0].Checked = true;
        }

        #endregion

        #region IncluirUsuario
        private void IncluirUsuario()
        {
            BOUsuario objUsuario = new BOUsuario();
            VOItemMenu objVOItemMenu;
            VOTela objVOTela;

            try
            {
                //Inclusão de usuário 
                if (
                    (ACAO == Util.clsUtil.ACAO.INCLUIR && tabManutencaoUsuario.SelectedTab == tabUsuario && objVO == null) ||
                    (ACAO == Util.clsUtil.ACAO.ALTERAR && tabManutencaoUsuario.SelectedTab == tabUsuario && objVO != null)
                    )
                {
                    if (txtNomeUsuario.Text == "" || txtLogin.Text == "" || txtSenha.Text == "" || txtConfirmarSenha.Text == "")
                        Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_CAMPOS_OBRIGATORIOS, "Manutenção de Usuários",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (txtSenha.Text != txtConfirmarSenha.Text)
                            Util.clsUtil.ExibirMensagem("As senhas não são identicas!", "Manutenção de Usuários",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                        {
                            if(ACAO == Util.clsUtil.ACAO.INCLUIR)
                                objVO = new VOUsuario();

                            objVO.NMUSUARIO = txtNomeUsuario.Text;
                            objVO.LOGIN = txtLogin.Text;
                            objVO.SENHA = clsCriptografia.Encrypt(txtSenha.Text);

                            if (objUsuario.ManutencaoUsuario(objVO, (ACAO == Util.clsUtil.ACAO.INCLUIR ? 'I' : 'A')))
                            {
                                Util.clsUtil.ExibirMensagem((ACAO == Util.clsUtil.ACAO.INCLUIR ? Util.clsUtil.MSG_INCLUSAO : Util.clsUtil.MSG_ALTERACAO), 
                                    "Manutenção de Usuários",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ACAO = Util.clsUtil.ACAO.ALTERAR;
                                tabManutencaoUsuario.SelectedTab = tabAcesso;
                            }
                        }
                    }
                }
                else if (tabManutencaoUsuario.SelectedTab == tabAcesso)
                {

                    //Limpa os acessos antigos armazenados na memória
                    objVO.ITENS_MENU.Clear();

                    foreach (TreeNode objNode in treeViewAcessos.Nodes)
                    {
                        objVOItemMenu = new VOItemMenu();

                        foreach (TreeNode objNodeFilho in objNode.Nodes)
                        {

                            if (objNodeFilho.Checked)
                            {
                                objVOTela = new VOTela();
                                objVOTela.ID_TELA = objNodeFilho.Name.Replace("T_", "");
                                objVOItemMenu.TELAS.Add(objVOTela);
                            }
                        }

                        //Verifica se possui alguma tela para ser atribuido valor
                        if (objVOItemMenu.TELAS.Count > 0)
                            objVO.ITENS_MENU.Add(objVOItemMenu);

                        objVOItemMenu = null;
                    }

                    //Verifica se foi adicionado acessos ao usuário
                    if (objVO.ITENS_MENU.Count == 0)
                        Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_CAMPOS_OBRIGATORIOS, "Manutenção de Usuários",
                           MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                    {
                        if (objUsuario.ManutencaoUsuario(objVO, 'T'))
                        {
                            Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_ACESSO_ATRIBUIDO, "Manutenção de Usuários",
                                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO - " + ex.Message, "Manutenção de Usuários",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objUsuario = null;
            }

        }
        #endregion
    }
}