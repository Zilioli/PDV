#region Using
using BOPDV;
using PDVForms.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VOPDV;
#endregion

namespace PDVForms
{

    public partial class frmManutencaoCliente : Form
    {

        #region Variáveis e Constantes
        private VOCliente objVOCliente;
        private PDVForms.Util.clsUtil.ACAO ACAO = Util.clsUtil.ACAO.INCLUIR;
        #endregion

        #region frmManutencaoCliente
        public frmManutencaoCliente()
        {
            InitializeComponent();            
        }
        #endregion

        #region frmManutencaoCliente
        public frmManutencaoCliente(VOCliente pVOCliente, PDVForms.Util.clsUtil.ACAO pACAO)
        {
            InitializeComponent();
            objVOCliente = pVOCliente;
            ACAO = pACAO;
        }
        #endregion

        #region btnIncluir_Click
        private void btnIncluir_Click(object sender, EventArgs e)
        {
            VOCliente objCliente;
            BOCliente objBOCliente = new BOCliente();

            try
            {
                //Verifica se ao menos o campo Nome foi preenchido corretamente
                if (ValidaForm())
                {
                    objCliente = new VOCliente();

                    if (ACAO == Util.clsUtil.ACAO.ALTERAR)
                        objCliente = objVOCliente;

                    PreencherObjeto(ref objCliente);

                    if (objBOCliente.ManutencaoCliente(objCliente, (ACAO == Util.clsUtil.ACAO.ALTERAR ? 'A' : 'I')))
                    {
                        Util.clsUtil.ExibirMensagem((ACAO == Util.clsUtil.ACAO.ALTERAR ? Util.clsUtil.MSG_ALTERACAO : Util.clsUtil.MSG_INCLUSAO),
                            "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();
                    }
                    else
                        Util.clsUtil.ExibirMensagem("Problemas ao " + (ACAO == Util.clsUtil.ACAO.ALTERAR ? "alterar" : "incluir") + " o registro",
                            "Manutenção de Fornecedores", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                clsUtil.ExibirMensagem(ex.Message, "Manutenção Cliente");
            }
        }
        #endregion

        #region ValidaForm
        private bool ValidaForm()
        {
            bool validou = true;

            //Verifica se o nome do fornecedor foi preenchido
            if (txtNomeCLiente.Text == "")
                validou = false;

            //valida endereco
            validou = ucEnderecoCliente.ValidaForm();
            
            //Os campos DDD e numero precisam estar preenchidos
            if ((txtCelular.Text != "" && txtDDDCelular.Text.Replace("(", "").Replace(")", "").Trim() == "") ||
                (txtCelular.Text == "" && txtDDDCelular.Text.Replace("(", "").Replace(")", "").Trim() != ""))
                validou = false;

            //Verifica se algum campo obrigatório deixou de ser preenchido
            if (!validou)
                Util.clsUtil.ExibirMensagem(Util.clsUtil.MSG_CAMPOS_OBRIGATORIOS,
                                       "Manutenção de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return validou;
        }
        #endregion

        #region PreencherObjeto
        private void PreencherObjeto(ref VOCliente pCliente)
        {
            VOTelefone objTelefone;            
            
            //limpa lista de endereco
            pCliente.TELEFONES.Clear();
            //limpa lista de telefone
            pCliente.ENDERECOS.Clear();

            //adiciona os dados do cliente            
            pCliente.TP_PESSOA = clsUtil.GetTipoPessoa(clsUtil.TIPO_PESSOA.FISICA);
            pCliente.NOME = txtNomeCLiente.Text;
            pCliente.CPF_CNPJ = txtCPF.Text;
            pCliente.RG = txtRG.Text;
            pCliente.EMAIL = txtEmail.Text;
            pCliente.WEB_SITE = txtWebSite.Text;
            pCliente.URL_SOCIAL = txtSocial.Text;

            //adiciona os dados do endereco
            pCliente.ENDERECOS.Add(ucEnderecoCliente.PreencherEndereco());

            //adiciona os dados do telefone
            if (!string.IsNullOrEmpty(txtDDDTelefone.Text)
                & !string.IsNullOrEmpty(txtTelefone.Text))
            {
                objTelefone = new VOTelefone();
                objTelefone.DDD = txtDDDTelefone.Text;
                objTelefone.NU_TELEFONE = txtTelefone.Text;
                objTelefone.TP_TELEFONE = clsUtil.GetTipoTelefone(clsUtil.TIPO_TELEFONE.RESIDENCIAL);
                pCliente.TELEFONES.Add(objTelefone);
            }

            if (!string.IsNullOrEmpty(txtDDDCelular.Text)
                & !string.IsNullOrEmpty(txtCelular.Text))
            {
                objTelefone = new VOTelefone();
                objTelefone.DDD = txtDDDCelular.Text;
                objTelefone.NU_TELEFONE = txtCelular.Text;
                objTelefone.TP_TELEFONE = clsUtil.GetTipoTelefone(clsUtil.TIPO_TELEFONE.CELULAR);
                pCliente.TELEFONES.Add(objTelefone);
            }             
        }
        #endregion

        #region btnCancelar_Click
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (ACAO == clsUtil.ACAO.ALTERAR)
                this.Close();
            else
            {
                clsUtil.LimparCampos(this);
                this.Close();
            }
        }
        #endregion

        #region CarregarTela
        private void CarregarTela()
        {            
            txtNomeCLiente.Focus();

            //carrega o combo de estados
            ucEnderecoCliente.CarregarEstados();            

            if (ACAO == Util.clsUtil.ACAO.ALTERAR)
            {
                btnIncluir.Text = "Alterar"; 
                CarregarDadosGeraisCliente();                                               
            }           
        }
        #endregion

        #region CarregarDadosGeraisCliente
        private void CarregarDadosGeraisCliente()
        {
            txtNomeCLiente.Text = objVOCliente.NOME;
            txtCPF.Text = objVOCliente.CPF_CNPJ;
            txtEmail.Text = objVOCliente.EMAIL;
            txtWebSite.Text = objVOCliente.WEB_SITE;
            txtSocial.Text = objVOCliente.URL_SOCIAL;

            //verifica se o cliente possui enderecos cadastrados
            if (objVOCliente.ENDERECOS.Count > 0)
                ucEnderecoCliente.CarregarEndereco(objVOCliente.ENDERECOS[0]);
                           
            //Verifica se o cliente possui numero de telefones cadastrados
            if (objVOCliente.TELEFONES.Count > 0)
            {
                if (objVOCliente.TELEFONES[0] != null)
                {
                    txtTelefone.Text = objVOCliente.TELEFONES[0].NU_TELEFONE;
                    txtDDDTelefone.Text = objVOCliente.TELEFONES[0].DDD;
                }

                if (objVOCliente.TELEFONES.Count > 1)
                {
                    if (objVOCliente.TELEFONES[1] != null)
                    {
                        txtCelular.Text = objVOCliente.TELEFONES[1].NU_TELEFONE;
                        txtDDDCelular.Text = objVOCliente.TELEFONES[1].DDD;
                    }
                }
            }
        }
        #endregion

        #region frmManutencaoCliente_Load
        private void frmManutencaoCliente_Load(object sender, EventArgs e)
        {
            CarregarTela();            
        }
        #endregion

       

    }
}
