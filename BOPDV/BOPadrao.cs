using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DAConnection;
using VOPDV;

namespace BOPDV
{
    public class BOPadrao
    {

        #region Variáveis
        private int _C_ERR;
        private string _MSG_ERR;        
        #endregion

        #region Atributos
        public int C_ERR
        {
            get { return _C_ERR; }
            set { _C_ERR = value; }
        }
        public string MSG_ERR
        {
            get { return _MSG_ERR; }
            set { _MSG_ERR = value; }
        }
    
        #endregion

        public SQL objConnection;
        
        public BOPadrao()
        {
            objConnection = new SQL(ConfigurationManager.AppSettings["SERVER"].ToString(),
                ConfigurationManager.AppSettings["USER"].ToString(),
                ConfigurationManager.AppSettings["PASSWORD"].ToString() ,
                ConfigurationManager.AppSettings["CATALOG"].ToString());
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

    }
}
