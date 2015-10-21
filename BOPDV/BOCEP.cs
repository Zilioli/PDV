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
    public class BOCEP : BOPadrao
    {

        #region Variáveis e Constantes
        //Nomes das procedures
        private const string PROC_CONSULTA_CEP = "CEP..PR_CONSULTA_CEP";
        private string[] paramCONSULTA_CEP = { 
                                                "@CEP"
                                              };

        private const string PROC_LISTA_CIDADES = "CEP..PR_LISTA_CIDADES";
        private string[] paramLISTA_CIDADES = { 
                                                "@UF"
                                              };

        private const string PROC_LISTA_ESTADOS = "CEP..PR_LISTA_ESTADOS";
        private string[] paramLISTA_ESTADOS = { 
                                                "@SIGLA",
                                                "@NOME"
                                              };

        private const string PROC_BUSCA_CEP = "CEP..PR_BUSCA_CEP";
        private string[] paramBUSCA_CEP = {
                                              "@LOGRADOURO",
                                              "@UF",
                                              "@CIDADE"
                                          };
        #endregion


        #region "BuscaCep"
        public List<VOCEP> BuscaCEP(VOCEP pVOCEP)
        {
            IDataReader objResultado;
            List<VOCEP> lstVOCEP = new List <VOCEP>();
            VOCEP objCEP;

            try 
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_BUSCA_CEP;
                objConnection.CreateParameter(paramBUSCA_CEP[0], (pVOCEP.LOGRADOURO  == "" ? null : pVOCEP.LOGRADOURO), 250, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramBUSCA_CEP[1], (pVOCEP.UF  == "" ? null : pVOCEP.UF), 2, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramBUSCA_CEP[2], (pVOCEP.CIDADE == "" ? null : pVOCEP.CIDADE), 250, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                // Percorre os registros da tabela
                while (objResultado.Read())
                {
                    objCEP = new VOCEP();
                    objCEP.CEP = objResultado["CEP"].ToString();
                    objCEP.LOGRADOURO = objResultado["LOGRADOURO"].ToString();
                    objCEP.ID_CIDADE = objResultado["ID_CIDADE"].ToString();
                    objCEP.CIDADE = objResultado["CIDADE"].ToString();                                                                                        
                    objCEP.UF = objResultado["UF"].ToString();
                    objCEP.BAIRRO = objResultado["BAIRRO"].ToString();
                    lstVOCEP.Add(objCEP);
                }

                return lstVOCEP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza conexão
                objConnection.CloseConnection();

                //Finaliza os objetos
                objConnection = null;
                objResultado = null;
            }
        }
        #endregion

        #region ConsultarCep
        public VOCEP ConsultarCep(VOCEP pVOCEP)
        {

            IDataReader objResultado;
            VOCEP objCEP = new VOCEP();

            try
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_CONSULTA_CEP;
                objConnection.CreateParameter(paramCONSULTA_CEP[0], (pVOCEP.CEP == "" ? null : pVOCEP.CEP), 20, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                // Percorre os registros da tabela
                while (objResultado.Read())
                {
                    objCEP.CEP = objResultado["CEP"].ToString();
                    objCEP.BAIRRO = objResultado["BAIRRO"].ToString();
                    objCEP.CIDADE = objResultado["CIDADE"].ToString();
                    objCEP.ID_CIDADE = objResultado["ID_CIDADE"].ToString();
                    objCEP.LOGRADOURO = objResultado["LOGRADOURO"].ToString();
                    objCEP.TIPO_LOGRADOURO = objResultado["LOG_TIPO_LOGRADOURO"].ToString();
                    objCEP.UF = objResultado["UF"].ToString();
                }

                return objCEP;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza conexão
                objConnection.CloseConnection();

                //Finaliza os objetos
                objConnection = null;
                objResultado = null;
            }
        }
        #endregion

        #region ListaEstado
        public List<VOUF> ListaEstado(VOUF pVOUF)
        {
            VOUF objVOUF;
            List<VOUF> lstUF = new List<VOUF>();
            IDataReader objResultado;

            try
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_ESTADOS;
                objConnection.CreateParameter(paramLISTA_ESTADOS[0], (pVOUF.SIGLA == "" ? null : pVOUF.SIGLA), 2, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramLISTA_ESTADOS[1], (pVOUF.NOME== "" ? null : pVOUF.NOME), 50, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                // Percorre os registros da tabela
                while (objResultado.Read())
                {
                    objVOUF = new VOUF();
                    objVOUF.NOME = objResultado["NOME"].ToString();
                    objVOUF.SIGLA = objResultado["SIGLA"].ToString();

                    //Adiciona  o estado na lista
                    lstUF.Add(objVOUF);

                    //Finaliza o objetos
                    objVOUF = null;
                }

                return lstUF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Fecha conexão com o banco de dados
                objConnection.CloseConnection();

                //Finaliza os objetos
                objConnection = null;
                objVOUF = null;
                lstUF = null;
                objResultado = null;
            }
        }
        #endregion

        #region ListaCidades
        public List<VOLocalidade> ListaCidades(VOUF pVOUF)
        {
            VOLocalidade objVOLocalidade;
            List<VOLocalidade> lstLocalidade = new List<VOLocalidade>();
            IDataReader objResultado;

            try
            {
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_CIDADES;
                objConnection.CreateParameter(paramLISTA_CIDADES[0], (pVOUF.SIGLA == "" ? null : pVOUF.SIGLA), 2, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                // Percorre os registros da tabela
                while (objResultado.Read())
                {
                    objVOLocalidade = new VOLocalidade();
                    objVOLocalidade.CIDADE = objResultado["CIDADE"].ToString();
                    objVOLocalidade.ID_CIDADE = objResultado["ID_CIDADE"].ToString();

                    //Adiciona  o estado na lista
                    lstLocalidade.Add(objVOLocalidade);

                    //Finaliza o objetos
                    objVOLocalidade = null;
                }

                return lstLocalidade;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Fecha conexão com o banco de dados
                objConnection.CloseConnection();

                //Finaliza os objetos
                objConnection = null;
                objVOLocalidade = null;
                lstLocalidade = null;
                objResultado = null;
            }
        }
        #endregion

        
    }
}
