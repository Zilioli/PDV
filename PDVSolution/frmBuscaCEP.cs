using BOPDV;
using PDVForms.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VOPDV;

namespace PDVForms
{
    public partial class frmBuscaCEP : Form
    {
        public frmBuscaCEP()
        {
            InitializeComponent();
        }

        private void frmBuscaCEPcs_Load(object sender, EventArgs e)
        {
            btnBuscaCEP.Image = new Bitmap(Properties.Resources.search, new Size(24, 24));
            this.CarregarEstados();            
        }
         
        #region CarregarEstados
        private void CarregarEstados()
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
                cbEstado.Focus();
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

            private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
            {
                if (cbEstado.SelectedIndex > 0)
                    CarregarCidade(((VOUF)cbEstado.SelectedItem));
            }

            private void btnBuscaCEP_Click(object sender, EventArgs e)
            {
                VOCEP objCep = new VOCEP();
                List<VOCEP> lstVOCEP = new List<VOCEP>();
                BOCEP boCEP = new BOCEP();

                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    //valida se todos os campos foram preenchidos
                    if (cbCidade.SelectedIndex < 0 & cbEstado.SelectedIndex < 0 & string.IsNullOrEmpty(txtLogradouro.Text))
                    {
                        clsUtil.ExibirMensagem(clsUtil.MSG_CAMPOS_OBRIGATORIOS, this.Name);
                        return;
                    }

                    //armazena o UF
                    if (cbCidade.SelectedIndex > 0)
                        objCep.CIDADE = cbCidade.Text;

                    //armazena o UF
                    if (cbEstado.SelectedIndex > 0)
                        objCep.UF = cbEstado.SelectedValue.ToString();

                    // armazena o logradouro
                    if (!string.IsNullOrEmpty(txtLogradouro.Text))
                        objCep.LOGRADOURO = txtLogradouro.Text.Trim();

                    //executa a chamada da procedure e preenche a lista
                    lstVOCEP = boCEP.BuscaCEP(objCep);

                    if (lstVOCEP.Count > 0)
                    {
                        //preenche o grid
                        dgCEP.DataSource = lstVOCEP;

                        //formata o grid
                        clsUtil.FormataDataGrid(dgCEP);
                        dgCEP.Visible = true;
                        dgCEP.Refresh();
                        dgCEP.ClearSelection();

                        foreach (DataGridViewColumn c in dgCEP.Columns)
                            c.Visible = false;

                        dgCEP.Columns["CEP"].Visible = true;
                        dgCEP.Columns["CEP"].DisplayIndex = 0;
                        dgCEP.Columns["LOGRADOURO"].Visible = true;
                        dgCEP.Columns["LOGRADOURO"].DisplayIndex = 1;
                        dgCEP.Columns["CIDADE"].Visible = true;
                        dgCEP.Columns["CIDADE"].DisplayIndex = 2;
                        dgCEP.Columns["UF"].Visible = true;
                        dgCEP.Columns["UF"].DisplayIndex = 3;
                        dgCEP.Columns["BAIRRO"].Visible = true;
                        dgCEP.Columns["BAIRRO"].DisplayIndex = 4;

                        clsUtil.InsereToolTip(dgCEP, "Clique duas vezes no endereço desejado!");
                    }
                    else
                        clsUtil.ExibirMensagem("Nenhum registro encontrado.",
                        "Busca CEP", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    clsUtil.ExibirMensagem("ERRO Busca CEP:  " + ex.Message,
                        "Busca CEP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //finaliza os objetos
                    objCep = null;
                    lstVOCEP = null;
                    boCEP = null;
                }
            }

            private void dgCEP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                //instancia um novo objetoCEP
                VOCEP objCEP = new VOCEP();
                
                if (e.RowIndex != -1)
                { 
                    //recupera os dados do VOCEP armazenado na linha selecionada do grid
                    objCEP = (VOCEP)dgCEP.Rows[e.RowIndex].DataBoundItem;

                    //armazena no objeto CEP global
                    clsUtil.objCEP = objCEP;          
  
                    //fecha o form
                    this.Close();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;            
                }
        }

    }
}
