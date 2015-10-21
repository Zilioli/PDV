#region
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using PDVForms.Util;
using VOPDV;
using BOPDV;
#endregion

namespace PDVForms
{
    public partial class ucEndereco : UserControl
    {
        #region ucEndereco
        public ucEndereco()
        {
            InitializeComponent();            
        }
        #endregion

        #region pbCEP_Click
        private void pbCEP_Click(object sender, EventArgs e)
        {
            frmBuscaCEP frmBuscaCEP = new frmBuscaCEP();
            this.Parent.Hide();

            try
            {
                if (frmBuscaCEP.ShowDialog() == DialogResult.OK)
                {

                    if (clsUtil.objCEP != null)
                    {
                        VOCEP objVO = new VOCEP();
                        objVO = clsUtil.objCEP;

                        if (objVO.LOGRADOURO != "")
                        {
                            txtCEP.Text = objVO.CEP;
                            txtLogradouro.Text = objVO.LOGRADOURO;
                            txtBairro.Text = objVO.BAIRRO;

                            cbEstado.SelectedValue = objVO.UF;
                            cbCidade.SelectedValue = objVO.ID_CIDADE;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                frmBuscaCEP = null;
                this.Parent.Show();
            }
        }
        #endregion
        
        #region cbEstado_SelectedIndexChanged
        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex > 0)
                CarregarCidade(((VOUF)cbEstado.SelectedItem));
        }
        #endregion

        #region ValidaForm
        public bool ValidaForm()
        {
            //Se o CEP estiver preenchido, os campos Numero, Logradouro, Bairro, Estado e Cidade são obrigatorios
            if (txtCEP.Text.Replace("-", "").Trim() != "")
            {
                if (txtLogradouro.Text == "" || txtNroLogradouro.Text == "" ||
                    txtBairro.Text == "" || cbEstado.Text == "" || cbCidade.Text == "")
                    return false;
            }

            return true;
        }
        #endregion

        #region ConsultarCEP
        private void ConsultarCEP()
        {
            BOCEP objCEP = new BOCEP();
            VOCEP objVO = new VOCEP();

            try
            {
                if (txtCEP.Text.Length >= 8)
                {
                    objVO.CEP = txtCEP.Text.Replace("-", "");
                    objVO = objCEP.ConsultarCep(objVO);

                    if (objVO.LOGRADOURO != "")
                    {
                        txtLogradouro.Text = objVO.LOGRADOURO;
                        txtBairro.Text = objVO.BAIRRO;

                        cbEstado.SelectedValue = objVO.UF;
                        cbCidade.SelectedValue = objVO.ID_CIDADE;

                        if (cbEstado.SelectedIndex > 0)
                            cbEstado.Enabled = false;

                        if (cbCidade.SelectedIndex > 0)
                            cbCidade.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.clsUtil.ExibirMensagem("ERRO Endereco:  " + ex.Message,
                    "Endereco", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Finaliza os objetos
                objCEP = null;
                objVO = null;
            }
        }
        #endregion

        #region txtCEP_Leave
        private void txtCEP_Leave(object sender, EventArgs e)
        {
            ConsultarCEP();
        }
        #endregion

        #region CarregarEstados
        public void CarregarEstados()
        {
            BOCEP objCEP = new BOCEP();
            List<VOUF> lstUF = new List<VOUF>();
            VOUF objUF = new VOUF();

            try
            {
                //Recupre a lista com todos os estados
                lstUF = objCEP.ListaEstado(objUF);
                lstUF.Insert(0, new VOUF());

                cbEstado.ValueMember = "SIGLA";
                cbEstado.DisplayMember = "NOME";
                cbEstado.DataSource = lstUF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza os objetos
                objCEP = null;
                lstUF = null;
                objUF = null;
            }
        }
        #endregion

        #region CarregarCidade
        private void CarregarCidade(VOUF pUF)
        {
            BOCEP objCEP = new BOCEP();
            List<VOLocalidade> lstLocalidade = new List<VOLocalidade>();

            try
            {
                //Recupre a lista com todos os estados
                lstLocalidade = objCEP.ListaCidades(pUF);
                lstLocalidade.Insert(0, new VOLocalidade());

                cbCidade.ValueMember = "ID_CIDADE";
                cbCidade.DisplayMember = "CIDADE";
                cbCidade.DataSource = lstLocalidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza os objetos
                objCEP = null;
                lstLocalidade = null;
            }
        }
        #endregion

        #region PreencherEndereco
        public VOEndereco PreencherEndereco()
        {
            VOEndereco objVOEndereco = new VOEndereco();
            
            if (txtCEP.Text.Replace("-", "").Trim() != "")
            {               
                objVOEndereco.BAIRRO = txtBairro.Text;
                objVOEndereco.CEP = txtCEP.Text;
                objVOEndereco.CIDADE = cbCidade.Text;
                objVOEndereco.COMPLEMENTO = txtComplemento.Text;
                objVOEndereco.ESTADO = cbEstado.Text;
                objVOEndereco.SIGLA = cbEstado.SelectedValue.ToString(); 
                objVOEndereco.LOGRADOURO = txtLogradouro.Text;
                objVOEndereco.NU_LOGRADOURO = txtNroLogradouro.Text;                
            }

            return objVOEndereco;
        }
        #endregion

        #region CarregarEndereco
        public void CarregarEndereco(VOEndereco pVOEndereco)
        {
            txtCEP.Text = pVOEndereco.CEP;
            txtBairro.Text = pVOEndereco.BAIRRO;
            txtLogradouro.Text = pVOEndereco.LOGRADOURO;
            txtNroLogradouro.Text = pVOEndereco.NU_LOGRADOURO;
            txtComplemento.Text = pVOEndereco.COMPLEMENTO;
            cbEstado.SelectedIndex = cbEstado.FindString(pVOEndereco.ESTADO);
            cbCidade.SelectedIndex = cbCidade.FindString(pVOEndereco.CIDADE);

            if (cbEstado.SelectedIndex > 0)
                cbEstado.Enabled = false;

            if (cbCidade.SelectedIndex > 0)
                cbCidade.Enabled = false;
        }
        #endregion

    }
}
