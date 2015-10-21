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
    public class BOTela : BOPadrao
    {
        #region "Constantes"
        private const string PROC_LISTA_TELAS = "PR_LISTA_TELAS";
        #endregion

        #region ListaTelas
        public List<VOItemMenu> ListaTelas()
        {
            IDataReader objResultado;
            VOItemMenu objITEM_MENU = new VOItemMenu();
            List<VOItemMenu> lstITEM_MENU = new List<VOItemMenu>();
            VOTela objTELA;
            List<VOTela> lstTELA = new List<VOTela>();

            try
            {
                //Abre conexão com o banco e executa procedure de verificação de acesso
                objConnection.OpenConnection();
                objConnection.PROCEDURE_NAME = PROC_LISTA_TELAS;
                objResultado = objConnection.ExecuteDataReader();

                //Percorre a lista de acessos do usuário
                while (objResultado.Read())
                {
                    //Preenche o objeto Item Menu
                    objITEM_MENU = new VOItemMenu();
                    objITEM_MENU.ID_ITEM_MENU = objResultado["ID_ITEM_MENU"].ToString();
                    objITEM_MENU.NM_ITEM_MENU = objResultado["NM_ITEM_MENU"].ToString();
                    objITEM_MENU.ICON = objResultado["ICON_ITEM_MENU"].ToString();

                    //Verifica se o item ja esta cadastrado na lista
                    if (!lstITEM_MENU.Exists(i => i.ID_ITEM_MENU == objResultado["ID_ITEM_MENU"].ToString()))
                        lstITEM_MENU.Add(objITEM_MENU);

                    objTELA = new VOTela();
                    objTELA.ID_TELA = objResultado["ID_TELA"].ToString();
                    objTELA.NM_TELA = objResultado["NM_TELA"].ToString();
                    objTELA.ICON = objResultado["ICON_TELA"].ToString();

                    //Adiciona item na lista
                    lstITEM_MENU.Find(i => i.ID_ITEM_MENU == objResultado["ID_ITEM_MENU"].ToString()).TELAS.Add(objTELA);

                    //Finaliza o objeto
                    objITEM_MENU = null;
                    objTELA = null;
                }

                return lstITEM_MENU;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Fecha conexão
                objConnection.CloseConnection();

                //Finaliza o objeto
                lstITEM_MENU = null;
                lstTELA = null;
                objTELA = null;
                objITEM_MENU = null;
                objResultado = null;
            }
        }
        #endregion
    }
}
