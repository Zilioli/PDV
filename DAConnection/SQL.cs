#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
#endregion

namespace DAConnection
{

    public class SQL : Util
    {

        #region Variáveis
        //Data Source=CZILIOLI\SQLEXPRESS;Initial Catalog=PDV;Persist Security Info=True;User ID=db_pdv;Password=pdv
        private string _CONNECTION_STRING = "Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}";
        private string _PROCEDURE_NAME = "";

        private SqlConnection objConnection;
        private SqlCommand objCommand;
        private List<VOParameter> lstParameters = new List<VOParameter>();
        private SqlParameter objParameter;

        #endregion

        #region Atributos
        public string PROCEDURE_NAME
        {
            get { return _PROCEDURE_NAME; }
            set { _PROCEDURE_NAME = value; }
        }
        #endregion

        #region Construtor
        public SQL(string CONNECTION_STRING)
        {
            _CONNECTION_STRING = CONNECTION_STRING;
        }

        public SQL(string pSERVER, string pUSER, string pPASSWORD ,string pCATALOG )
        {
            this.CATALOG = pCATALOG ;
            this.DATA_SOURCE = pSERVER;
            this.PASSWORD = pPASSWORD;
            this.SERVER = pSERVER;
            this.USER = pUSER;
            VerificarAtributosConexao();
            MontarConnectionString();
        }

        public SQL(Util objUtil)
        {
            this.CATALOG = objUtil.CATALOG;
            this.DATA_SOURCE = objUtil.DATA_SOURCE;
            this.PASSWORD = objUtil.PASSWORD;
            this.SERVER = objUtil.SERVER;
            this.USER = objUtil.USER;
            VerificarAtributosConexao();
            MontarConnectionString();
        }

        public SQL()
        {
            VerificarAtributosConexao();
            MontarConnectionString();
        }
        #endregion

        #region VerificarAtributosConexao
        private void VerificarAtributosConexao()
        {
            if (this.SERVER == "")
                throw new Exception("ERRO NA CONEXAO, ATRIBUTO SERVER NAO INFORMADO!");
            if (this.CATALOG == "")
                throw new Exception("ERRO NA CONEXAO, ATRIBUTO CATALOG NAO INFORMADO!");
            if (this.PASSWORD == "")
                throw new Exception("ERRO NA CONEXAO, ATRIBUTO PASSWORD NAO INFORMADO!");
            if (this.USER == "")
                throw new Exception("ERRO NA CONEXAO, ATRIBUTO USER NAO INFORMADO!");
        }
        #endregion

        #region ConnectionState
        private ConnectionState  ConnectionState()
        {
            if (objConnection == null)
                return System.Data.ConnectionState.Closed;

            return objConnection.State;
        }
        #endregion

        #region MontarConnectionString
        private void MontarConnectionString()
        {
            _CONNECTION_STRING = string.Format(_CONNECTION_STRING, this.SERVER, this.CATALOG, this.USER, this.PASSWORD);
        }
        #endregion

        #region getConnectionString
        public string getConnectionString()
        {
            return _CONNECTION_STRING;
        }
        #endregion

        #region OpenConnection
        public bool OpenConnection()
        {
            try
            {
                //Verifica se ja existe uma instância do objeto Conexao
                if (objConnection == null)
                    objConnection = new SqlConnection(_CONNECTION_STRING);

                //Verifica se já existe conexão aberta com o servidor
                if (objConnection.State != System.Data.ConnectionState.Open)
                    objConnection.Open();

                return true;

            }
            catch (Exception ex)
            {
                this.ERROR = "ERRO AO ABRIR CONEXAO: " + ex.Message;
                return false;
            }
        }
        #endregion

        #region CloseConnection
        public bool CloseConnection()
        {
            try
            {
                //Verifica se existe conexão aberta para poder fecha-la
                if (objConnection != null && objConnection.State == System.Data.ConnectionState.Open)
                    objConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                this.ERROR = "ERRO AO FECHAR CONEXÂO: " + ex.Message;
                return false;
            }
        }
        #endregion

        #region ExecuteNonQuery
        public bool ExecuteNonQuery(string pSQL)
        {
            try
            {
                //Verifica se a conexão esta aberta
                if (this.ConnectionState() != System.Data.ConnectionState.Open)
                    throw new Exception("ERRO NA EXECUÇÃO DO COMANDO: Não existe conexão aberta com o Banco de Dados.");

                //Verifica se o objeto já foi instanciado
                if (objCommand == null)
                    objCommand = new SqlCommand();

                //Atribui valor para os atributos
                objCommand.CommandText = pSQL;
                objCommand.CommandType = CommandType.Text;
                objCommand.Connection = objConnection;

                //Executa o comando SQL
                objCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
                return false;
            }
            finally
            {
                //Finaliza o objeto
                objCommand = null;
            }
        }

        #endregion

        #region ExecuteDataReader
        public IDataReader ExecuteDataReader(string pSQL)
        {
            try
            {
                //Verifica se a conexão esta aberta
                if (this.ConnectionState() != System.Data.ConnectionState.Open)
                    throw new Exception("ERRO NA EXECUÇÃO DO COMANDO: Não existe conexão aberta com o Banco de Dados.");

                //Verifica se o objeto já foi instanciado
                if (objCommand == null)
                    objCommand = new SqlCommand();

                //Atribui valor para os atributos
                objCommand.CommandText = pSQL;
                objCommand.CommandType = CommandType.Text;
                objCommand.Connection = objConnection;

                //Executa o comando SQL
                return objCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
                throw ex;
            }
            finally
            {
                //Finaliza o objeto
                objCommand = null;
            }
        }
        #endregion

        #region ExecuteDataReader
        public IDataReader ExecuteDataReader()
        {
            IDataReader objResultado;
            SqlParameter paramAux;
            try
            {
                //Verifica se a conexão esta aberta
                if (this.ConnectionState() != System.Data.ConnectionState.Open)
                    throw new Exception("ERRO NA EXECUÇÃO DO COMANDO: Não existe conexão aberta com o Banco de Dados.");

                //Verifica se foi informado o nome da procedure
                if (_PROCEDURE_NAME == "")
                    throw new Exception("ERRO NA EXECUÇÃO DO COMANDO: Nome da procedure não informado.");

                //Verifica se o objeto já foi instanciado
                if (objCommand == null)
                    objCommand = new SqlCommand();

                //Atribui valor para os atributos
                objCommand.CommandText = _PROCEDURE_NAME;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = objConnection;

                //Adiciona os parametros na procedure
                foreach (VOParameter parameter in lstParameters)
                        objCommand.Parameters.Add(parameter.PARAMETER);

                //Executa a procedure
                objResultado = objCommand.ExecuteReader();

                return objResultado;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
                throw ex;
            }
            finally
            {
                //Finaliza o objeto
                objCommand = null;
                objResultado = null;
            }
        }
        #endregion

        #region ExecuteNonQuery
        public bool ExecuteNonQuery()
        {
            try
            {
                //Verifica se a conexão esta aberta
                if (this.ConnectionState() != System.Data.ConnectionState.Open)
                    throw new Exception("ERRO NA EXECUÇÃO DO COMANDO: Não existe conexão aberta com o Banco de Dados.");

                //Verifica se foi informado o nome da procedure
                if (_PROCEDURE_NAME == "")
                    throw new Exception("ERRO NA EXECUÇÃO DO COMANDO: Nome da procedure não informado.");

                //Verifica se o objeto já foi instanciado
                if (objCommand == null)
                    objCommand = new SqlCommand();

                //Atribui valor para os atributos
                objCommand.CommandText = _PROCEDURE_NAME;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Connection = objConnection;

                //Adiciona os parametros na procedure
                foreach (VOParameter param in lstParameters)
                    objCommand.Parameters.Add(param.PARAMETER);

                //Executa a procedure
                objCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                ERROR = ex.Message;
                return false;
            }
            finally
            {
                //Finaliza o objeto
                objCommand = null;
            }
        }
        #endregion

        #region CreateParameter
        public void CreateParameter(string pParameterName, 
                                    object pParameterValue, 
                                    object pParameterSize ,
                                    ParameterDirection pParameterDirection,
                                    DbType pParameterType)
        {
            VOParameter objVO = new VOParameter();
            try
            {
                //Instancia e atribui valor para os parametros
                objParameter = new SqlParameter();
                objParameter.ParameterName = pParameterName;
                
                if (pParameterValue != null)
                    objParameter.Value = pParameterValue;

                objParameter.DbType = pParameterType;

                if (pParameterSize != null)
                    objParameter.Size = int.Parse(pParameterSize.ToString());

                objParameter.Direction = pParameterDirection;
                objVO.NAME_PARAMETER = pParameterName;
                objVO.PARAMETER = objParameter;

                //Adiciona parametro na lista
                lstParameters.Add(objVO);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Finaliza os objetos
                objParameter = null;
                objVO = null;
            }
        }
        #endregion

        #region RemoveParameter
        public void RemoveParameter(string pParameterName)
        {
            lstParameters.Remove(lstParameters.Find(e => e.NAME_PARAMETER == pParameterName));
        }
        #endregion

        #region ClearParameters
        public void ClearParameters()
        {
            lstParameters.Clear();
        }

        #endregion

        #region GetParameter
        public object GetParameter(string pName)
        {
            if (lstParameters.Exists(e => e.NAME_PARAMETER == pName))
                return lstParameters.Find(e => e.NAME_PARAMETER == pName).PARAMETER.SqlValue;

            return "";
        }
        #endregion
    }
}