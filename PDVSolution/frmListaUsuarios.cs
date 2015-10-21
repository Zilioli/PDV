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
using PDVForms.Util;
#endregion

namespace PDVForms
{
    public partial class frmListaUsuarios : Form
    {
        #region Variáveis
        private List<VOUsuario> LISTA_USUARIO = new List<VOUsuario>();
        #endregion

        #region frmListaUsuarios
        public frmListaUsuarios()
        {
            InitializeComponent();
        }
        #endregion

        #region btnNovo_Click
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmManutencaoUsuarios objForm = new frmManutencaoUsuarios();
            objForm.ShowDialog(this);
            this.ListarUsuarios(new VOUsuario()) ;
        }
        #endregion

        #region frmListaUsuarios_Load
        private void frmListaUsuarios_Load(object sender, EventArgs e)
        {
            //Redimensiona o  tamanho os ícones dos botões
            btnNovo.Image = new Bitmap(Properties.Resources.new_record, new Size(24, 24));
            btnPesquisar.Image = new Bitmap(Properties.Resources.search, new Size(24, 24));
            btnAlterar.Image = new Bitmap(Properties.Resources.edit1, new Size(24, 24));
            btnExcluir.Image = new Bitmap(Properties.Resources.less, new Size(24, 24));
            Util.clsUtil.FormataDataGrid(dtgUsuarios);

            ListarUsuarios(new VOUsuario());
        }
        #endregion

        #region ListarUsuarios
        private void ListarUsuarios(VOUsuario pVOUsuario)
        {

            BOUsuario objUsuario = new BOUsuario();
            try
            {
                LISTA_USUARIO = objUsuario.ListaUsuario(pVOUsuario);
                dtgUsuarios.DataSource = LISTA_USUARIO;
                dtgUsuarios.Columns["IDUSUARIO"].Visible = false;
                dtgUsuarios.Columns["SENHA"].Visible = false;
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO: " + ex.Message, "Lista Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                objUsuario = null;
            }
        }
        #endregion

        #region btnPesquisar_Click
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            VOUsuario objVO = new VOUsuario();
            objVO.NMUSUARIO = txtFiltro.Text;
            ListarUsuarios(objVO);
            objVO = null;
        }
        #endregion

        #region txtFiltro_KeyDown
        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VOUsuario objVO = new VOUsuario();
                objVO.NMUSUARIO = txtFiltro.Text;
                ListarUsuarios(objVO);
                objVO = null; 
            }
        }
        #endregion

        #region btnExcluir_Click
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (Util.clsUtil.ExibirMensagemConfirmacao(Util.clsUtil.MSG_CONFIRMACAO_EXCLUSAO))
                this.ExcluirUsuario(LISTA_USUARIO.Find(
                    f => f.IDUSUARIO == ((VOUsuario)(dtgUsuarios.SelectedRows[0].DataBoundItem)).IDUSUARIO));
        }
        #endregion

        #region ExcluirUsuario
        private void ExcluirUsuario(VOUsuario pVOUsuario)
        {
            BOUsuario objUsuario = new BOUsuario();
            try
            {
                if (objUsuario.ManutencaoUsuario(pVOUsuario, 'E'))
                {
                    Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_EXCLUSAO, "Lista Usuarios");
                    ListarUsuarios(new VOUsuario());
                }

            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem(ex.Message, "Manter Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region btnCancelar_Click
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region btnAlterar_Click
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dtgUsuarios.SelectedRows.Count > 0)
            {
                frmManutencaoUsuarios objForm = new frmManutencaoUsuarios(LISTA_USUARIO.Find(
                           f => f.IDUSUARIO == ((VOUsuario)(dtgUsuarios.SelectedRows[0].DataBoundItem)).IDUSUARIO),
                           Util.clsUtil.ACAO.ALTERAR);

                clsUtil.AbreFormulario(objForm, this);

                ListarUsuarios(new VOUsuario());
            }
        }
        #endregion

        #region dtgUsuarios_CellDoubleClick
        private void dtgUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgUsuarios.SelectedRows.Count > 0)
            {
                frmManutencaoUsuarios objForm = new frmManutencaoUsuarios(LISTA_USUARIO.Find(
                           f => f.IDUSUARIO == ((VOUsuario)(dtgUsuarios.SelectedRows[0].DataBoundItem)).IDUSUARIO),
                           Util.clsUtil.ACAO.DETALHAR);

                clsUtil.AbreFormulario(objForm, this);
            }
        }
        #endregion
    }
}