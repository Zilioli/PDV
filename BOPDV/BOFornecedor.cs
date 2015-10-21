#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAConnection;
using VOPDV;
#endregion

namespace BOPDV
{
    public class BOFornecedor : BOPadrao
    {

        #region Variáveis e Constantes
        //Nomes das procedures
        private const string PROC_LISTA_FORNECEDORES = "PR_LISTA_FORNECEDORES";
        private string[] paramLISTA_FORNECEDORES = { 
                                                    "@ID_FORNECEDOR", 
                                                    "@ID_PESSOA" , 
                                                    "@NM_FORNECEDOR"
                                                   };

        private const string PROC_MANUTENCAO_FORNECEDOR = "PR_MANUTENCAO_FORNECEDOR";
        private string[] paramMANUTENCAO_FORNECEDOR = { 
                                                        "@OPCAO",
                                                        "@ID_PESSOA",
                                                        "@NM_PESSOA",
                                                        "@TP_PESSOA",
                                                        "@CPF_CNPJ",
                                                        "@EMAIL",
                                                        "@WEBSITE",
                                                        "@URL_SOCIAL",
                                                        "NM_LOGRADOURO",
                                                        "@NM_BAIRRO",
                                                        "@NM_CIDADE",
                                                        "@NM_ESTADO",
                                                        "@NM_SIGLA",
                                                        "@CEP",
                                                        "@NU_LOGRADOURO",
                                                        "@COMPLEMENTO",
                                                        "@TELEFONES",
                                                        "@ID_FORNECEDOR",  
                                                        "@C_ERRO",
                                                        "@MSG_ERRO"
                                                   };
        private const string PROC_INCLUIR_CONTATOS = "PR_INCLUIR_CONTATOS";
        private string[] paramINCLUIR_CONTATOS = { 
                                                    "@ID_FORNECEDOR", 
                                                    "@XML_CONTATOS" , 
                                                    "@C_ERRO",
                                                    "@MSG_ERRO"
                                                   };
        #endregion

        #region ListarFornecedores
        public List<VOFornecedor> ListarFornecedores(VOFornecedor pFornecedor)
        {
            VOFornecedor objVOFornecedor = new VOFornecedor();
            VOPessoa objVOContato = new VOPessoa();
            VOTelefone objVOTelefone;
            VOTelefone objVOTelefoneFornecedor;
            VOEndereco objVOEndereco;
            List<VOFornecedor> lstFornecedores = new List<VOFornecedor>();
            IDataReader objResultado;

            try
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_FORNECEDORES;
                objConnection.CreateParameter(paramLISTA_FORNECEDORES[0], (pFornecedor.ID_FORNECEDOR == "" ? null : pFornecedor.ID_FORNECEDOR), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramLISTA_FORNECEDORES[1], (pFornecedor.ID_PESSOA == "" ? null : pFornecedor.ID_PESSOA), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramLISTA_FORNECEDORES[2], (pFornecedor.NOME == "" ? null : pFornecedor.NOME), 150, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                // Percorre os registros da tabela
                while (objResultado.Read())
                {
                    //Preenche objeto Fornecedor
                    objVOFornecedor = new VOFornecedor();
                    objVOFornecedor.ID_PESSOA = objResultado["ID_PESSOA"].ToString();
                    objVOFornecedor.ID_FORNECEDOR = objResultado["ID_FORNECEDOR"].ToString();
                    objVOFornecedor.NOME = objResultado["NOME"].ToString();
                    objVOFornecedor.TP_PESSOA = objResultado["TIPO"].ToString();
                    objVOFornecedor.CPF_CNPJ = objResultado["CNPJ"].ToString();
                    objVOFornecedor.EMAIL = objResultado["EMAIL"].ToString();
                    objVOFornecedor.WEB_SITE = objResultado["WEBSITE"].ToString();
                    objVOFornecedor.URL_SOCIAL = objResultado["URL"].ToString();
                    //Preenche os telefones
                    objVOTelefoneFornecedor = new VOTelefone();
                    objVOTelefoneFornecedor.DDD = objResultado["DDD"].ToString();
                    objVOTelefoneFornecedor.ID_TELEFONE = objResultado["ID_TELEFONE"].ToString();
                    objVOTelefoneFornecedor.NU_TELEFONE = objResultado["NU_TELEFONE"].ToString();
                    objVOTelefoneFornecedor.TP_TELEFONE = objResultado["TIPO_TELEFONE"].ToString();
                    //Preenche os endereços
                    objVOEndereco = new VOEndereco();
                    objVOEndereco.BAIRRO = objResultado["BAIRRO"].ToString();
                    objVOEndereco.CEP = objResultado["CEP"].ToString();
                    objVOEndereco.CIDADE = objResultado["CIDADE"].ToString();
                    objVOEndereco.COMPLEMENTO = objResultado["COMPLEMENTO"].ToString();
                    objVOEndereco.ESTADO = objResultado["ESTADO"].ToString();
                    objVOEndereco.ID_ENDERECO = objResultado["ID_ENDERECO"].ToString();
                    objVOEndereco.LOGRADOURO = objResultado["LOGRADOURO"].ToString();
                    objVOEndereco.NU_LOGRADOURO = objResultado["NU_LOGRADOURO"].ToString();

                    //Verifica se o fornecedor já esta na lista, senão tiver inclui
                    if (!lstFornecedores.Exists(f => f.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()))
                    {
                        objVOFornecedor.TELEFONES.Add(objVOTelefoneFornecedor);
                        objVOFornecedor.ENDERECOS.Add(objVOEndereco);
                        lstFornecedores.Add(objVOFornecedor);
                    }
                    //Verifica se o telefone do fornecedor foi adicionada, senão foi adicioná no objto Forncedor
                    else
                    {
                        //Verifica se o telefone ja esta cadastrado na lista
                        if (!lstFornecedores.Find(f => f.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).
                        TELEFONES.Exists(t => t.ID_TELEFONE == objResultado["ID_TELEFONE"].ToString()))
                            lstFornecedores.Find(f => f.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).TELEFONES.Add(objVOTelefoneFornecedor);

                        //Verifica se o endereço ja esta cadastrado na lista
                        if (!lstFornecedores.Find(f => f.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).
                                                ENDERECOS.Exists(t => t.ID_ENDERECO == objResultado["ID_ENDERECO"].ToString()))
                            lstFornecedores.Find(f => f.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).ENDERECOS.Add(objVOEndereco);
                    }

                    //Verifica se existe contato cadastrado para o fornecedor atual
                    if (objResultado["TIPO_CONTATO"].ToString() == "CONTATOS_FORNECEDOR")
                    {
                        //Adicona contatos no objeto
                        objVOContato = new VOPessoa();
                        objVOTelefone = new VOTelefone();

                        //Preenche dados básicos do contato
                        objVOContato.NOME = objResultado["NM_CONTATO"].ToString();
                        objVOContato.ID_PESSOA = objResultado["ID_PESSOA_CONTATO"].ToString();

                        //Preenche informações do telefone do contato
                        objVOTelefone.DDD = objResultado["DDD_CONTATO"].ToString();
                        objVOTelefone.NU_TELEFONE = objResultado["NU_TELEFONE_CONTATO"].ToString();
                        objVOTelefone.TP_TELEFONE = objResultado["TIPO_TELEFONE_CONTATO"].ToString();

                        //Verifica se o contato já esta na lista para o fornecedor atual
                        if (lstFornecedores.Find(e => e.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).CONTATOS != null)
                        {
                            if (lstFornecedores.Find(e => e.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).CONTATOS.Exists(
                                    c => c.ID_PESSOA == objResultado["ID_PESSOA_CONTATO"].ToString()))
                                //Se o contato ja estiver cadastrado, inclui apenas os dados do telefone de contato
                                lstFornecedores.Find(e => e.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).CONTATOS.Find(
                                    c => c.ID_PESSOA == objResultado["ID_PESSOA_CONTATO"].ToString()).TELEFONES.Add(objVOTelefone);
                            else
                            {
                                //Se o contato ainda não estiver cadastrado para o fornecedor, adicionar o contato e o telefone do mesmo na lista
                                objVOContato.TELEFONES.Add(objVOTelefone);
                                lstFornecedores.Find(e => e.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).CONTATOS.Add(objVOContato);
                            }
                        }
                        else
                        {
                            //Se o contato ainda não estiver cadastrado para o fornecedor, adicionar o contato e o telefone do mesmo na lista
                            objVOContato.TELEFONES.Add(objVOTelefone);
                            lstFornecedores.Find(e => e.ID_FORNECEDOR == objResultado["ID_FORNECEDOR"].ToString()).CONTATOS.Add(objVOContato);
                        }

                        objVOTelefone = null;
                    }

                    //Finaliza o objeto
                    objVOFornecedor = null;
                }

                //Retorna lista de fornecedores
                return lstFornecedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza os objetos
                objVOFornecedor = null;
                lstFornecedores = null;
                objResultado = null;
            }
        }

        #endregion

        #region ManutencaoFornecedor
        public bool ManutencaoFornecedor(ref VOFornecedor pVOFornecedor, char pACAO)
        {

            try
            {
                //Abre Conexão com o Banco de Dados e Adiciona os atributos da procedure
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_MANUTENCAO_FORNECEDOR;
                this.AdicionarParametrosProcManutencao(objConnection, pVOFornecedor, pACAO);

                if (objConnection.ExecuteNonQuery())
                {
                    if (pACAO == 'I' )
                        pVOFornecedor.ID_FORNECEDOR = objConnection.GetParameter(paramMANUTENCAO_FORNECEDOR[17]).ToString();

                    return true;
                }
                else
                    throw new Exception("ERRO ManutencaoFornecedor: " + objConnection.ERROR);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Finaliza conexão
                objConnection.CloseConnection();
                objConnection = null;
            }
        }
        #endregion

        #region AdicionarParametrosProcManutencao
        private void AdicionarParametrosProcManutencao(SQL pConnection, VOFornecedor pVOFornecedor, char pACAO)
        {
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[0], pACAO, 1, ParameterDirection.Input, DbType.String);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[1], (pVOFornecedor.ID_PESSOA == "" ? null : pVOFornecedor.ID_PESSOA), 10, ParameterDirection.Input, DbType.Int64);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[2], (pVOFornecedor.NOME == "" ? null : pVOFornecedor.NOME), 250, ParameterDirection.Input, DbType.String);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[3], (pVOFornecedor.TP_PESSOA == "" ? null : pVOFornecedor.TP_PESSOA), 1, ParameterDirection.Input, DbType.String);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[4], (pVOFornecedor.CPF_CNPJ == "" ? null : pVOFornecedor.CPF_CNPJ), 250, ParameterDirection.Input, DbType.String);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[5], (pVOFornecedor.EMAIL == "" ? null : pVOFornecedor.EMAIL), 250, ParameterDirection.Input, DbType.String);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[6], (pVOFornecedor.WEB_SITE == "" ? null : pVOFornecedor.WEB_SITE), 250, ParameterDirection.Input, DbType.String);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[7], (pVOFornecedor.URL_SOCIAL == "" ? null : pVOFornecedor.URL_SOCIAL), 250, ParameterDirection.Input, DbType.String);

            if (pVOFornecedor.ENDERECOS.Count > 0)
            {
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[8], (pVOFornecedor.ENDERECOS[0].LOGRADOURO == "" ? null : pVOFornecedor.ENDERECOS[0].LOGRADOURO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[9], (pVOFornecedor.ENDERECOS[0].BAIRRO == "" ? null : pVOFornecedor.ENDERECOS[0].BAIRRO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[10], (pVOFornecedor.ENDERECOS[0].CIDADE == "" ? null : pVOFornecedor.ENDERECOS[0].CIDADE), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[11], (pVOFornecedor.ENDERECOS[0].ESTADO == "" ? null : pVOFornecedor.ENDERECOS[0].ESTADO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[12], (pVOFornecedor.ENDERECOS[0].ESTADO == "" ? null : pVOFornecedor.ENDERECOS[0].ESTADO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[13], (pVOFornecedor.ENDERECOS[0].CEP == "" ? null : pVOFornecedor.ENDERECOS[0].CEP), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[14], (pVOFornecedor.ENDERECOS[0].NU_LOGRADOURO == "" ? null : pVOFornecedor.ENDERECOS[0].NU_LOGRADOURO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[15], (pVOFornecedor.ENDERECOS[0].COMPLEMENTO == "" ? null : pVOFornecedor.ENDERECOS[0].COMPLEMENTO), 250, ParameterDirection.Input, DbType.String);
            }

            if (pVOFornecedor.TELEFONES.Count > 0)
                pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[16], MontaXMLTelefones(pVOFornecedor.TELEFONES), 2500, ParameterDirection.Input, DbType.Xml);

            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[17], null, null, ParameterDirection.Output, DbType.Int16);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[18], null, 3, ParameterDirection.Output, DbType.Int16);
            pConnection.CreateParameter(paramMANUTENCAO_FORNECEDOR[19], null, 250, ParameterDirection.Output, DbType.String);
        }
        #endregion

        #region IncluirContatos
        public bool IncluirContatos(VOFornecedor pFornecedor)
        {
            try
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_INCLUIR_CONTATOS;
                objConnection.CreateParameter(paramINCLUIR_CONTATOS[0], (pFornecedor.ID_FORNECEDOR == "" ? null : pFornecedor.ID_FORNECEDOR), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramINCLUIR_CONTATOS[1], this.MontaXmlContatos(pFornecedor), 2500, System.Data.ParameterDirection.Input, System.Data.DbType.Xml);
                objConnection.CreateParameter(paramINCLUIR_CONTATOS[2], null, 5, System.Data.ParameterDirection.Output, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramINCLUIR_CONTATOS[3], null, 250, System.Data.ParameterDirection.Output, System.Data.DbType.String);

                return objConnection.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region MontaXmlContatos
        private string MontaXmlContatos(VOFornecedor pFornecedor)
        {
                        //--<CONTATOS>
            //--	<CONTATO>
            //--		<ID>1</ID>								
            //--		<NOME>CARLOS</NOME>
            //--		<DDD>11</DDD>
            //--		<NUTELEFONE>38952966</NUTELEFONE>
            //--		<TPTELEFONE>R</TPTELEFONE>
            //--	</CONTATO>
            //--	<CONTATO>	
            //--		<ID>1</ID>								
            //--		<NOME>CARLOS</NOME>
            //--		<DDD>11</DDD>
            //--		<NUTELEFONE>38952966</NUTELEFONE>
            //--		<TPTELEFONE>R</TPTELEFONE>
            //--	</CONTATO>
            //--	<CONTATO>	
            //--		<ID>2</ID>								
            //--		<NOME>CARLOS</NOME>
            //--		<DDD>11</DDD>
            //--		<NUTELEFONE>38952966</NUTELEFONE>
            //--		<TPTELEFONE>R</TPTELEFONE>
            //--	</CONTATO>
            //--</CONTATOS>'

            StringBuilder objXML = new StringBuilder();

            try
            {

                objXML.Append("<CONTATOS>");
                int cont = 0;


                foreach (VOPessoa objContato in pFornecedor.CONTATOS)
                {
                    cont++;
                    foreach (VOTelefone objTelefone in objContato.TELEFONES)
                    {
                        objXML.Append("<CONTATO>");
                        objXML.Append("<ID>" + cont + "</ID>");
                        objXML.Append("<NOME>" + objContato.NOME + "</NOME>");
                        objXML.Append("<DDD>" + objTelefone.DDD + "</DDD>");
                        objXML.Append("<NUTELEFONE>" + objTelefone.NU_TELEFONE + "</NUTELEFONE>");
                        objXML.Append("<TPTELEFONE>" + objTelefone.TP_TELEFONE + "</TPTELEFONE>");
                        objXML.Append("</CONTATO>");
                    }
                }

                objXML.Append("</CONTATOS>");

                return objXML.ToString();
            }
            catch  (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}