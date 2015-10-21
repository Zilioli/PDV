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
using PDVForms.Util;
using BOPDV;
using VOPDV;
#endregion

namespace PDVForms
{
    public partial class frmLogin : Form
    {
        #region Construtor
        public frmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region frmLogin_Load
        private void frmLogin_Load(object sender, EventArgs e)
        {
            PDVForms.Util.clsUtil.InsereToolTip(btnLogin, "Clique aqui  para entrar no sistema.", true);
        }
        #endregion

        #region btnLogin_Click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            RealizarLogin();
        }
        #endregion

        #region txtSenha_KeyDown
        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                RealizarLogin();

        }
        #endregion

        #region RealizarLogin
        private void RealizarLogin()
        {
            BOUsuario objUsuario = new BOUsuario();
            VOUsuario objVO = new VOUsuario();

            try
            {
                //Veriifia se o usuário preencheu os campos do formulário
                if (txtSenha.Text == "" || txtUsuario.Text == "")
                    clsUtil.ExibirMensagem(clsUtil.MSG_CAMPOS_OBRIGATORIOS, "LOGIN");
                else
                {
                    //Preenche o objeto usuário
                    objVO.LOGIN = txtUsuario.Text;
                    objVO.SENHA = clsCriptografia.Encrypt(txtSenha.Text);
                    string strMensagem = "";

                    //Verifica se o usuário digitou usuário e senhas corretamente
                    if (objUsuario.ValidaUsuario(ref objVO, ref strMensagem))
                    {
                        //Armazena as informações do usuário logado na variável global
                        clsUtil.objUSUARIO = objVO;

                        frmSelecionaModulo objFormSelecionaModulo = new frmSelecionaModulo();
                        objFormSelecionaModulo.Show();
                        this.Visible = false;
                    }
                    else
                        clsUtil.ExibirMensagem(strMensagem, "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                clsUtil.ExibirMensagem("ERRO NO LOGIN: " + ex.Message, "LOGIN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //finaliza os objetos
                objVO = null;
                objUsuario = null;
            }
        }
        #endregion

    }
}
