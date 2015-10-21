using DAConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VOPDV;

namespace BOPDV
{
    public class BOCliente : BOPadrao 
    {
        #region Variáveis e Constantes
        //Nomes das procedures
        private const string PROC_MANUTENCAO_CLIENTE = "PR_MANUTENCAO_CLIENTE";
        private string[] paramPR_MANUTENCAO_CLIENTE = {
                                                   "@OPCAO",
                                                   "@ID_PESSOA",
                                                   "@NM_PESSOA",
                                                   "@TP_PESSOA",
                                                   "@CPF_CNPJ",
                                                   "@EMAIL",
                                                   "@WEBSITE",
                                                   "@URL_SOCIAL",
                                                   "@RG",
                                                   "@NM_LOGRADOURO",
                                                   "@NM_BAIRRO",
                                                   "@NM_CIDADE",
                                                   "@NM_ESTADO",
                                                   "@NM_SIGLA",
                                                   "@CEP",
                                                   "@NU_LOGRADOURO",
                                                   "@COMPLEMENTO",
                                                   "@TELEFONES",
                                                   "@C_ERRO",
                                                   "@MSG_ERRO"
                                                   };

        private const string PROC_LISTA_CLIENTE = "PR_LISTA_CLIENTEs";
        private string[] paramPR_LISTA_CLIENTE = {   "@ID_CLIENTE", 
                                                     "@ID_PESSOA" , 
                                                     "@NM_CLIENTE"};
        #endregion
        public bool ManutencaoCliente(VOCliente pObjCliente, char pACAO)
        {

            try
            {
                //Abre Conexão com o Banco de Dados e Adiciona os atributos da procedure
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_MANUTENCAO_CLIENTE;
                this.AdicionarParametrosProcManutencao(objConnection, pObjCliente, pACAO);

                if (objConnection.ExecuteNonQuery())
                    return true;
                else
                    throw new Exception("ERRO ManutencaoCliente: " + objConnection.ERROR);
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




        #region ListarFornecedores
        public List<VOCliente> ListarClientes(VOCliente pCliente)
        {
            VOCliente objVOCliente = new VOCliente();            
            VOTelefone objVOTelefone;            
            VOEndereco objVOEndereco;
            List<VOCliente> lstClientes = new List<VOCliente>();
            IDataReader objResultado;

            try
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_CLIENTE ;
                objConnection.CreateParameter(paramPR_LISTA_CLIENTE[0], (pCliente.ID_CLIENTE == "" ? null : pCliente.ID_CLIENTE), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramPR_LISTA_CLIENTE[1], (pCliente.ID_PESSOA == "" ? null : pCliente.ID_PESSOA), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramPR_LISTA_CLIENTE[2], (pCliente.NOME == "" ? null : pCliente.NOME), 150, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                // Percorre os registros da tabela
                while (objResultado.Read())
                {
                    //Preenche objeto Fornecedor
                    objVOCliente = new VOCliente();
                    objVOCliente.ID_PESSOA = objResultado["ID_PESSOA"].ToString();
                    objVOCliente.ID_CLIENTE = objResultado["ID_CLIENTE"].ToString();
                    objVOCliente.NOME = objResultado["NOME"].ToString();
                    objVOCliente.RG = objResultado["RG"].ToString();
                    objVOCliente.TP_PESSOA = objResultado["TIPO"].ToString();
                    objVOCliente.CPF_CNPJ = objResultado["CPF"].ToString();
                    objVOCliente.EMAIL = objResultado["EMAIL"].ToString();
                    objVOCliente.WEB_SITE = objResultado["WEBSITE"].ToString();
                    objVOCliente.URL_SOCIAL = objResultado["URL"].ToString();
                    //Preenche os telefones
                    objVOTelefone = new VOTelefone();
                    objVOTelefone.DDD = objResultado["DDD"].ToString();
                    objVOTelefone.ID_TELEFONE = objResultado["ID_TELEFONE"].ToString();
                    objVOTelefone.NU_TELEFONE = objResultado["NU_TELEFONE"].ToString();
                    objVOTelefone.TP_TELEFONE = objResultado["TIPO_TELEFONE"].ToString();
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

                    //Verifica se o cliente já esta na lista, senão estiver inclui
                    if (!lstClientes.Exists(f => f.ID_CLIENTE == objResultado["ID_CLIENTE"].ToString()))
                    {
                        objVOCliente.TELEFONES.Add(objVOTelefone);
                        objVOCliente.ENDERECOS.Add(objVOEndereco);
                        lstClientes.Add(objVOCliente);
                    }
                    //Verifica se o telefone do fornecedor foi adicionada, senão foi adicioná no objeto Cliente
                    else
                    {
                        //Verifica se o telefone ja esta cadastrado na lista
                        if (!lstClientes.Find(f => f.ID_CLIENTE == objResultado["ID_CLIENTE"].ToString()).
                        TELEFONES.Exists(t => t.ID_TELEFONE == objResultado["ID_TELEFONE"].ToString()))
                            lstClientes.Find(f => f.ID_CLIENTE == objResultado["ID_CLIENTE"].ToString()).TELEFONES.Add(objVOTelefone);

                        //Verifica se o endereço ja esta cadastrado na lista
                        if (!lstClientes.Find(f => f.ID_CLIENTE == objResultado["ID_CLIENTE"].ToString()).
                                                ENDERECOS.Exists(t => t.ID_ENDERECO == objResultado["ID_ENDERECO"].ToString()))
                            lstClientes.Find(f => f.ID_CLIENTE == objResultado["ID_CLIENTE"].ToString()).ENDERECOS.Add(objVOEndereco);
                    }

                    //Finaliza o objeto
                    objVOCliente = null;
                }

                //Retorna lista de clientes
                return lstClientes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza os objetos
                objVOCliente = null;
                lstClientes = null;
                objResultado = null;
            }
        }
        #endregion


        #region AdicionarParametrosProcManutencao
        private void AdicionarParametrosProcManutencao(SQL pConnection, VOCliente pObjCliente, char pACAO)
        {
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[0], pACAO, 1, ParameterDirection.Input, DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[1], pObjCliente.ID_PESSOA, 15, System.Data.ParameterDirection.Input, System.Data.DbType.Int32);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[2], pObjCliente.NOME, 250, System.Data.ParameterDirection.Input, System.Data.DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[3], pObjCliente.TP_PESSOA, 1, System.Data.ParameterDirection.Input, System.Data.DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[4], pObjCliente.CPF_CNPJ, 20, System.Data.ParameterDirection.Input, System.Data.DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[5], pObjCliente.EMAIL, 250, System.Data.ParameterDirection.Input, System.Data.DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[6], pObjCliente.WEB_SITE, 250, System.Data.ParameterDirection.Input, System.Data.DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[7], pObjCliente.URL_SOCIAL, 250, System.Data.ParameterDirection.Input, System.Data.DbType.String);
            objConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[8], pObjCliente.RG, 20, System.Data.ParameterDirection.Input, System.Data.DbType.String);

            if (pObjCliente.ENDERECOS.Count > 0)
            {
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[9], (pObjCliente.ENDERECOS[0].LOGRADOURO == "" ? null : pObjCliente.ENDERECOS[0].LOGRADOURO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[10], (pObjCliente.ENDERECOS[0].BAIRRO == "" ? null : pObjCliente.ENDERECOS[0].BAIRRO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[11], (pObjCliente.ENDERECOS[0].CIDADE == "" ? null : pObjCliente.ENDERECOS[0].CIDADE), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[12], (pObjCliente.ENDERECOS[0].ESTADO == "" ? null : pObjCliente.ENDERECOS[0].ESTADO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[13], (pObjCliente.ENDERECOS[0].SIGLA == "" ? null : pObjCliente.ENDERECOS[0].SIGLA), 2, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[14], (pObjCliente.ENDERECOS[0].CEP == "" ? null : pObjCliente.ENDERECOS[0].CEP), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[15], (pObjCliente.ENDERECOS[0].NU_LOGRADOURO == "" ? null : pObjCliente.ENDERECOS[0].NU_LOGRADOURO), 250, ParameterDirection.Input, DbType.String);
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[16], (pObjCliente.ENDERECOS[0].COMPLEMENTO == "" ? null : pObjCliente.ENDERECOS[0].COMPLEMENTO), 250, ParameterDirection.Input, DbType.String);               
            }

            if (pObjCliente.TELEFONES.Count > 0)
                pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[17], MontaXMLTelefones(pObjCliente.TELEFONES), 2500, ParameterDirection.Input, DbType.Xml);

            pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[18], null, 3, ParameterDirection.Output, DbType.Int16);
            pConnection.CreateParameter(paramPR_MANUTENCAO_CLIENTE[19], null, 250, ParameterDirection.Output, DbType.String);
        }
        #endregion 
    }
}
