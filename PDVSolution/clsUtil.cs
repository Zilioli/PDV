using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VOPDV;

namespace PDVForms.Util
{
    public class clsUtil
    {

        //=============================================================================
        // Variáveis Globais da Aplicação
        //=============================================================================
        public static VOUsuario objUSUARIO;
        public static VOCEP objCEP;

        public enum ACAO
        {
            ALTERAR,
            INCLUIR,
            EXCLUIR,
            DETALHAR
        }

        public enum TIPO_PESSOA
        {
            FISICA,
            JURIDICA,
            CONTATO
        }

        public static string GetTipoPessoa(TIPO_PESSOA pTipoPessoa)
        {
            switch ((int)pTipoPessoa)
            {
                case 1:
                    return "J";
                case 2:
                    return "C";
                default:
                    return "F";
            }

        }

        public enum TIPO_TELEFONE
        {
            RESIDENCIAL,
            CELULAR,
            EMPRESARIAL,
            FAX
        }

        public static string GetTipoTelefone(TIPO_TELEFONE pTipoTelefone)
        {
            switch ((int)pTipoTelefone)
            {
                case 1:
                    return "C";
                case 2:
                    return "E";
                case 3:
                    return "F";
                default:
                    return "R";
            }
        }

        //=============================================================================
        // Memsagens aplicação
        //=============================================================================
        public const string NOME_APLCACAO = "{0} - PDV";
        public const string MSG_LOGIN_INVALIDO = "";
        public const string MSG_CAMPOS_OBRIGATORIOS = "Campo(s) Obrigatório(s) não preenchido(s)";
        public const string MSG_CONFIRMACAO_EXCLUSAO = "Deseja realmente excluir o(s) registro(s)?";
        public const string MSG_EXCLUSAO = "Registro(s) Excluído(s).";
        public const string MSG_INCLUSAO = "Registro(s) Incluído(s).";
        public const string MSG_ALTERACAO = "Registro(s) Alterado(s).";
        public const string MSG_ACESSO_ATRIBUIDO = "Acesso(s) atribuído(s) com sucesso.";


        public static void InsereToolTip(Control pControle, string pTextoToolTip, bool pShowAlways = true)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ShowAlways = pShowAlways;
            toolTip.SetToolTip(pControle, pTextoToolTip);
        }

        public static void AbreFormulario(Form pFormFilho, Form pFormPai)
        {
            pFormFilho.ShowDialog(pFormPai);
        }

        public static Boolean ExibirMensagemConfirmacao(string pMensagem)
        {

            if (MessageBox.Show(pMensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                return true;
            else
                return false;
        }

        public static void ExibirMensagem(string pMensagem, string pNomeTela)
        {
            MessageBox.Show(pMensagem, string.Format(NOME_APLCACAO, pNomeTela), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ExibirMensagem(string pMensagem, string pNomeTela, MessageBoxButtons pTipoBotoes, MessageBoxIcon pIcone)
        {
            MessageBox.Show(pMensagem, string.Format(NOME_APLCACAO, pNomeTela), pTipoBotoes, pIcone);
        }

        public static void LimparCampos(Control pControl)
        {
            foreach (Control c in pControl.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Text = string.Empty;
                else if (c is MaskedTextBox)
                    ((MaskedTextBox)c).Text = string.Empty;
                else if (c is ComboBox)
                    ((ComboBox)c).SelectedIndex = -1;

                if (c.Controls.Count > 0)
                    LimparCampos(c);
            }
        }

        public static string MontaXMLTelefones(List<VOTelefone> pListaTelefone)
        {

            string STR_XML = "<TELEFONE><DDD>{0}</DDD><NUTELEFONE>{1}</NUTELEFONE><TPTELEFONE>{2}</TPTELEFONE></TELEFONE>";
            StringBuilder sbXml = new StringBuilder();

            try
            {
                //verifica se existem linhas na lista de telefone
                if (pListaTelefone.Count > 0)
                {
                    //varre a lista de telefones
                    foreach (VOTelefone objTelefone in pListaTelefone)
                        sbXml.Append(string.Format(STR_XML, objTelefone.DDD, objTelefone.NU_TELEFONE, objTelefone.TP_TELEFONE));

                    //retorna o xml
                    return sbXml.ToString().Replace(")", "").Replace("(", "");
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sbXml = null;
            }
        }

        public static void ConfiguraTelaDetalhar(Control.ControlCollection pControle)
        {
            foreach (Control c in pControle)
            {


                if (c is Button)
                    c.Visible = false;
                else
                    if (!(c is TabControl))
                        c.Enabled = false;

                if (c.Controls.Count > 0)
                    ConfiguraTelaDetalhar(c.Controls);
            }
        }

        public static void FormataDataGrid(DataGridView pDataGrid)
        {

            //configura o grid
            pDataGrid.GridColor = Color.LightSteelBlue;
            pDataGrid.BackgroundColor = Color.White;
            pDataGrid.BorderStyle = BorderStyle.Fixed3D;
            pDataGrid.RowHeadersVisible = false;
            pDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            pDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            pDataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            pDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            pDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            pDataGrid.EnableHeadersVisualStyles = false;

            //formta o cabecalho            
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            headerStyle.BackColor = Color.Lavender;
            headerStyle.Font = new Font("Verdana", 10);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            headerStyle.ForeColor = Color.MidnightBlue;
            headerStyle.SelectionBackColor = Color.Lavender;
            headerStyle.SelectionForeColor = Color.MidnightBlue;
            pDataGrid.ColumnHeadersDefaultCellStyle = headerStyle;

            //formata as linhas
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.White;
            cellStyle.Font = new Font("Verdana", 8);
            cellStyle.ForeColor = Color.MidnightBlue;
            cellStyle.SelectionBackColor = Color.LightSteelBlue;
            cellStyle.SelectionForeColor = Color.MidnightBlue;
            pDataGrid.RowsDefaultCellStyle = cellStyle;

            //formata as linhas alternadas
            DataGridViewCellStyle alternateCellStyle = new DataGridViewCellStyle();
            alternateCellStyle.BackColor = Color.Lavender;
            alternateCellStyle.Font = new Font("Verdana", 8);
            alternateCellStyle.ForeColor = Color.MidnightBlue;
            alternateCellStyle.SelectionBackColor = Color.LightSteelBlue;
            alternateCellStyle.SelectionForeColor = Color.MidnightBlue;
            pDataGrid.AlternatingRowsDefaultCellStyle = alternateCellStyle;
        }
    }

}

public class clsCriptografia
{
    /// <summary>     
    /// Vetor de bytes utilizados para a criptografia (Chave Externa)     
    /// </summary>     
    private static byte[] bIV = 
        { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18,
        0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

    /// <summary>     
    /// Representação de valor em base 64 (Chave Interna)    
    /// O Valor representa a transformação para base64 de     
    /// um conjunto de 32 caracteres (8 * 32 = 256bits)    
    /// A chave é: "Criptografias com Rijndael / AES"     
    /// </summary>     
    private const string cryptoKey = "Q3JpcHRvZ3JhZmlhcyBjb20gUmluamRhZWwgLyBBRVM=";

    /// <summary>     
    /// Metodo de criptografia de valor     
    /// </summary>     
    /// <param name="text">valor a ser criptografado</param>     
    /// <returns>valor criptografado</returns>
    public static string Encrypt(string text)
    {
        try
        {
            // Se a string não está vazia, executa a criptografia
            if (!string.IsNullOrEmpty(text))
            {
                // Cria instancias de vetores de bytes com as chaves                
                byte[] bKey = Convert.FromBase64String(cryptoKey);
                byte[] bText = new UTF8Encoding().GetBytes(text);

                // Instancia a classe de criptografia Rijndael
                Rijndael rijndael = new RijndaelManaged();

                // Define o tamanho da chave "256 = 8 * 32"                
                // Lembre-se: chaves possíves:                
                // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                rijndael.KeySize = 256;

                // Cria o espaço de memória para guardar o valor criptografado:                
                MemoryStream mStream = new MemoryStream();
                // Instancia o encriptador                 
                CryptoStream encryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateEncryptor(bKey, bIV),
                    CryptoStreamMode.Write);

                // Faz a escrita dos dados criptografados no espaço de memória
                encryptor.Write(bText, 0, bText.Length);
                // Despeja toda a memória.                
                encryptor.FlushFinalBlock();
                // Pega o vetor de bytes da memória e gera a string criptografada                
                return Convert.ToBase64String(mStream.ToArray());
            }
            else
            {
                // Se a string for vazia retorna nulo                
                return null;
            }
        }
        catch (Exception ex)
        {
            // Se algum erro ocorrer, dispara a exceção            
            throw new ApplicationException("Erro ao criptografar", ex);
        }
    }

    /// <summary>     
    /// Pega um valor previamente criptografado e retorna o valor inicial 
    /// </summary>     
    /// <param name="text">texto criptografado</param>     
    /// <returns>valor descriptografado</returns>     
    public static string Decrypt(string text)
    {
        try
        {
            // Se a string não está vazia, executa a criptografia           
            if (!string.IsNullOrEmpty(text))
            {
                // Cria instancias de vetores de bytes com as chaves                
                byte[] bKey = Convert.FromBase64String(cryptoKey);
                byte[] bText = Convert.FromBase64String(text);

                // Instancia a classe de criptografia Rijndael                
                Rijndael rijndael = new RijndaelManaged();

                // Define o tamanho da chave "256 = 8 * 32"                
                // Lembre-se: chaves possíves:                
                // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)                
                rijndael.KeySize = 256;

                // Cria o espaço de memória para guardar o valor DEScriptografado:               
                MemoryStream mStream = new MemoryStream();

                // Instancia o Decriptador                 
                CryptoStream decryptor = new CryptoStream(
                    mStream,
                    rijndael.CreateDecryptor(bKey, bIV),
                    CryptoStreamMode.Write);

                // Faz a escrita dos dados criptografados no espaço de memória   
                decryptor.Write(bText, 0, bText.Length);
                // Despeja toda a memória.                
                decryptor.FlushFinalBlock();
                // Instancia a classe de codificação para que a string venha de forma correta         
                UTF8Encoding utf8 = new UTF8Encoding();
                // Com o vetor de bytes da memória, gera a string descritografada em UTF8       
                return utf8.GetString(mStream.ToArray());
            }
            else
            {
                // Se a string for vazia retorna nulo                
                return null;
            }
        }
        catch (Exception ex)
        {
            // Se algum erro ocorrer, dispara a exceção            
            throw new ApplicationException("Erro ao descriptografar", ex);
        }
    }
}
