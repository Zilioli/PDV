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
    public class BOUsuario : BOPadrao
    {

        #region CONSTANTES

        //Nomes das procedures
        private const string PROC_VALIDAR_USUARIO = "PR_VERIFICA_ACESSO_USUARIO";
        private string[] paramVALIDAR_USUARIO = { 
                                                    "@LOGIN", 
                                                    "@SENHA" , 
                                                    "@AUTORIZADO", 
                                                    "@NOME",
                                                    "@ID_USUARIO",
                                                    "@ERRO"
                                                };

        private const string PROC_LISTA_TELAS_USUARIO = "PR_LISTA_TELAS_USUARIO";
        private string[] paramLISTA_TELAS_USUARIO = {
                                                        "@ID_USUARIO"
                                                    };

        private const string PROC_MANTER_USUARIO = "PR_MANTER_USUARIO";
        private string[] paramMANTER_USUARIO = {
                                                   "@ACAO", 
                                                   "@IDUSUARIO", 
                                                   "@NMUSUARIO", 
                                                   "@LOGIN",
                                                   "@SENHA",
                                                   "@XML_ACESSOS",
                                                   "@IDUSUARIO_RET",
                                                   "@C_ERRO",
                                                   "@MSG_ERRO"
                                               };

        private const string PROC_LISTA_USUARIOS = "PR_LISTA_USUARIOS";
        private string[] paramLISTA_USUARIOS = {
                                                   "@ID_USUARIO", 
                                                   "@NM_USUARIO",
                                                   "@LOGIN"
                                               };

        #endregion

        #region ValidaUsuario
        public bool ValidaUsuario(ref VOUsuario pUSUARIO, ref string pMensagem)
        {

            IDataReader objResultado;
            VOItemMenu objITEM_MENU = new VOItemMenu();
            List<VOItemMenu> lstITEM_MENU = new List<VOItemMenu>();
            VOTela objTELA;
            List<VOTela> lstTELA = new List<VOTela>();
            int idItemMenuAux = 0;

            try
            {
                //Abre conexão com o banco e executa procedure de verificação de acesso
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_VALIDAR_USUARIO;
                objConnection.CreateParameter(paramVALIDAR_USUARIO[0], pUSUARIO.LOGIN, 50, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramVALIDAR_USUARIO[1], pUSUARIO.SENHA, 50, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramVALIDAR_USUARIO[2], "", 1, System.Data.ParameterDirection.Output, System.Data.DbType.String);
                objConnection.CreateParameter(paramVALIDAR_USUARIO[3], "", 150, System.Data.ParameterDirection.Output, System.Data.DbType.String);
                objConnection.CreateParameter(paramVALIDAR_USUARIO[4], 0, 3, System.Data.ParameterDirection.Output, System.Data.DbType.Int16);
                objConnection.CreateParameter(paramVALIDAR_USUARIO[5], "", 250, System.Data.ParameterDirection.Output, System.Data.DbType.String);
                objConnection.ExecuteNonQuery();

                //Verifica se o usuário poussui acesso
                if (objConnection.GetParameter(paramVALIDAR_USUARIO[2]).ToString() == "S")
                {
                    //Recupre as informacoes do usuário
                    pUSUARIO.IDUSUARIO = objConnection.GetParameter(paramVALIDAR_USUARIO[4]).ToString();
                    pUSUARIO.NMUSUARIO = objConnection.GetParameter(paramVALIDAR_USUARIO[3]).ToString();

                    //Recupera Lista das telas que o usuário possui acesso
                    objConnection.ClearParameters();
                    objConnection.PROCEDURE_NAME = PROC_LISTA_TELAS_USUARIO;
                    objConnection.CreateParameter(paramLISTA_TELAS_USUARIO[0], pUSUARIO.IDUSUARIO, 3, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                    objResultado = objConnection.ExecuteDataReader();

                    //Percorre a lista de acessos do usuário
                    while (objResultado.Read())
                    {
                        //Verifica se houve mudança no item no menu
                        if (idItemMenuAux != int.Parse(objResultado["ID_ITEM_MENU"].ToString()))
                        {
                            //Adiciona informações do Item do Menu
                            objITEM_MENU = null;
                            objITEM_MENU = new VOItemMenu();
                            objITEM_MENU.ICON = objResultado["ICON_ITEM_MENU"].ToString();
                            objITEM_MENU.ID_ITEM_MENU = objResultado["ID_ITEM_MENU"].ToString();
                            objITEM_MENU.NM_ITEM_MENU = objResultado["NM_ITEM_MENU"].ToString();

                            //Adiciona Informações das telas referente ao item
                            objTELA = new VOTela();
                            objTELA.ICON = objResultado["ICON_TELA"].ToString();
                            objTELA.ID_TELA = objResultado["ID_TELA"].ToString();
                            objTELA.NM_FISICO = objResultado["NM_FISICO"].ToString();
                            objTELA.NM_TELA = objResultado["NM_TELA"].ToString();
                            objTELA.FLAG = objResultado["FLAG"].ToString();

                            //Adiciona tela no Item do Menu atual
                            objITEM_MENU.TELAS.Add(objTELA);

                            //Adiciona o Item do Menu na lista
                            lstITEM_MENU.Add(objITEM_MENU);

                            //Finaliza o objeto
                            objTELA = null;

                            //Atribui valor para a variável de controle
                            idItemMenuAux = int.Parse(objResultado["ID_ITEM_MENU"].ToString());
                        }
                        else
                        {
                            //Adiciona Informações das telas referente ao item
                            objTELA = new VOTela();
                            objTELA.ICON = objResultado["ICON_TELA"].ToString();
                            objTELA.ID_TELA = objResultado["ID_TELA"].ToString();
                            objTELA.NM_FISICO = objResultado["NM_FISICO"].ToString();
                            objTELA.NM_TELA = objResultado["NM_TELA"].ToString();
                            objTELA.FLAG = objResultado["FLAG"].ToString();

                            //Adiciona tela no Item do Menu atual
                            if (objITEM_MENU != null)
                                objITEM_MENU.TELAS.Add(objTELA);

                            //Finaliza o objeto
                            objTELA = null;
                        }
                    }

                }
                else
                {
                    //Significa que o usuário não pode acessar o sistema, a variável mensagem irá indicar o motivo
                    pMensagem = objConnection.GetParameter(paramVALIDAR_USUARIO[5]).ToString();
                    return false;
                }

                //Adiciona a lista de acessos do usuário
                pUSUARIO.ITENS_MENU = lstITEM_MENU;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Fecha Conexão
                objConnection.CloseConnection();

                //Finaliza os objetos
                objConnection = null;
                objResultado = null;
                objITEM_MENU = null;
                objTELA = null;
            }
        }
        #endregion

        #region ListaUsuario
        public List<VOUsuario> ListaUsuario(VOUsuario pVOUsuario)
        {
            IDataReader objResultado;
            VOUsuario objVOUsuario;
            List<VOUsuario> lstUsuario = new List<VOUsuario>();

            try
            {
                //Abre conexão com o banco e executa procedure de verificação de acesso
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_USUARIOS;
                objConnection.CreateParameter(paramLISTA_USUARIOS[0], (pVOUsuario.IDUSUARIO == "" ? null : pVOUsuario.IDUSUARIO), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int64);
                objConnection.CreateParameter(paramLISTA_USUARIOS[1], (pVOUsuario.NMUSUARIO == "" ? null : pVOUsuario.NMUSUARIO), 150, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramLISTA_USUARIOS[2], (pVOUsuario.LOGIN == "" ? null : pVOUsuario.LOGIN), 150, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objResultado = objConnection.ExecuteDataReader();

                //Percorre a lista de acessos do usuário
                while (objResultado.Read())
                {
                    objVOUsuario = new VOUsuario();
                    objVOUsuario.LOGIN = objResultado["LOGIN"].ToString();
                    objVOUsuario.NMUSUARIO = objResultado["NM_USUARIO"].ToString();
                    objVOUsuario.IDUSUARIO = objResultado["ID_USUARIO"].ToString();

                    //Adiciona o item na lista
                    lstUsuario.Add(objVOUsuario);

                    //Finaliza o objeto
                    objVOUsuario = null;
                }

                return lstUsuario;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConnection.CloseConnection();

                objConnection = null;
                objVOUsuario = null;
                lstUsuario = null;
            }
        }
        #endregion

        #region ListaAcessosUsuario
        public List<VOItemMenu> ListaAcessosUsuario(ref VOUsuario pUSUARIO)
        {

            IDataReader objResultado;
            VOItemMenu objITEM_MENU = new VOItemMenu();
            List<VOItemMenu> lstITEM_MENU = new List<VOItemMenu>();
            VOTela objTELA;
            List<VOTela> lstTELA = new List<VOTela>();
            int idItemMenuAux = 0;

            try
            {
                //Abre conexão com o banco e executa procedure de verificação de acesso
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_TELAS_USUARIO;
                objConnection.CreateParameter(paramLISTA_TELAS_USUARIO[0], pUSUARIO.IDUSUARIO, 3, System.Data.ParameterDirection.Input, System.Data.DbType.Int16);
                objResultado = objConnection.ExecuteDataReader();

                //Percorre a lista de acessos do usuário
                while (objResultado.Read())
                {
                    //Verifica se houve mudança no item no menu
                    if (idItemMenuAux != int.Parse(objResultado["ID_ITEM_MENU"].ToString()))
                    {
                        //Adiciona informações do Item do Menu
                        objITEM_MENU = null;
                        objITEM_MENU = new VOItemMenu();
                        objITEM_MENU.ICON = objResultado["ICON_ITEM_MENU"].ToString();
                        objITEM_MENU.ID_ITEM_MENU = objResultado["ID_ITEM_MENU"].ToString();
                        objITEM_MENU.NM_ITEM_MENU = objResultado["NM_ITEM_MENU"].ToString();

                        //Adiciona Informações das telas referente ao item
                        objTELA = new VOTela();
                        objTELA.ICON = objResultado["ICON_TELA"].ToString();
                        objTELA.ID_TELA = objResultado["ID_TELA"].ToString();
                        objTELA.NM_FISICO = objResultado["NM_FISICO"].ToString();
                        objTELA.NM_TELA = objResultado["NM_TELA"].ToString();
                        objTELA.FLAG = objResultado["FLAG"].ToString();

                        //Adiciona tela no Item do Menu atual
                        objITEM_MENU.TELAS.Add(objTELA);

                        //Adiciona o Item do Menu na lista
                        lstITEM_MENU.Add(objITEM_MENU);

                        //Finaliza o objeto
                        objTELA = null;

                        //Atribui valor para a variável de controle
                        idItemMenuAux = int.Parse(objResultado["ID_ITEM_MENU"].ToString());
                    }
                    else
                    {
                        //Adiciona Informações das telas referente ao item
                        objTELA = new VOTela();
                        objTELA.ICON = objResultado["ICON_TELA"].ToString();
                        objTELA.ID_TELA = objResultado["ID_TELA"].ToString();
                        objTELA.NM_FISICO = objResultado["NM_FISICO"].ToString();
                        objTELA.NM_TELA = objResultado["NM_TELA"].ToString();
                        objTELA.FLAG = objResultado["FLAG"].ToString();

                        //Adiciona tela no Item do Menu atual
                        if (objITEM_MENU != null)
                            objITEM_MENU.TELAS.Add(objTELA);

                        //Finaliza o objeto
                        objTELA = null;
                    }
                }

                //Adiciona a lista de acessos do usuário
                return lstITEM_MENU;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Fecha Conexão
                objConnection.CloseConnection();

                //Finaliza os objetos
                objConnection = null;
                objResultado = null;
                objITEM_MENU = null;
                objTELA = null;
            }
        }
        #endregion

        #region ManutencaoUsuario
        public bool ManutencaoUsuario(VOUsuario pVOUsuario, char pAcao)
        {
            try
            {
                //Abre conexão com o banco e executa procedure de verificação de acesso
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_MANTER_USUARIO;
                objConnection.CreateParameter(paramMANTER_USUARIO[0], pAcao, 1, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramMANTER_USUARIO[1], (pVOUsuario.IDUSUARIO == "" ? null : pVOUsuario.IDUSUARIO), 5, System.Data.ParameterDirection.Input, System.Data.DbType.Int64);
                objConnection.CreateParameter(paramMANTER_USUARIO[2], pVOUsuario.NMUSUARIO, 150, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramMANTER_USUARIO[3], pVOUsuario.LOGIN, 50, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramMANTER_USUARIO[4], pVOUsuario.SENHA, 50, System.Data.ParameterDirection.Input, System.Data.DbType.String);
                objConnection.CreateParameter(paramMANTER_USUARIO[5], this.MontarXmlAcessos(pVOUsuario), 2500, System.Data.ParameterDirection.Input, System.Data.DbType.Xml);
                objConnection.CreateParameter(paramMANTER_USUARIO[6], "", 5, System.Data.ParameterDirection.Output, System.Data.DbType.Int32);
                objConnection.CreateParameter(paramMANTER_USUARIO[7], "", 5, System.Data.ParameterDirection.Output, System.Data.DbType.Int32);
                objConnection.CreateParameter(paramMANTER_USUARIO[8], "", 250, System.Data.ParameterDirection.Output, System.Data.DbType.String);
                objConnection.ExecuteNonQuery();

                if (objConnection.GetParameter(paramMANTER_USUARIO[8]).ToString() == "")
                {
                    //Se for inclusão, recupera o código do novo usuário
                    if (pAcao == 'I')
                        pVOUsuario.IDUSUARIO = objConnection.GetParameter(paramMANTER_USUARIO[6]).ToString();

                    return true;
                }
                else
                    throw new Exception(objConnection.GetParameter(paramMANTER_USUARIO[8]).ToString());

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConnection.CloseConnection();
                objConnection = null;
            }
        }
        #endregion

        #region MontarXmlAcessos
        private string MontarXmlAcessos(VOUsuario pVOUsuario)
        {
            //Exemplo de XML
            //<ACESSOS>
            //  <ACESSO>
            //		<ID_TELA>1</ID_TELA>								
            //  	<ID_USUARIO>4</ID_USUARIO>
            //  </ACESSO>			
            //</ACESSOS>			
            StringBuilder strXML = new StringBuilder();
            try
            {

                foreach (VOItemMenu objItemMenu in pVOUsuario.ITENS_MENU)
                {
                    foreach (VOTela objTela in objItemMenu.TELAS)
                    {
                        strXML.Append("<ACESSO>");
                        strXML.Append("<ID_TELA>" + objTela.ID_TELA + "</ID_TELA>");
                        strXML.Append("<ID_USUARIO>" + pVOUsuario.IDUSUARIO + "</ID_USUARIO>");
                        strXML.Append("</ACESSO>");
                    }
                }

                if (strXML.ToString().Length > 0)
                    return "<ACESSOS>" + strXML.ToString() + "</ACESSOS>";

                return strXML.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Finaliza os objetos
                strXML = null;
            }
        }
        #endregion
    }
}