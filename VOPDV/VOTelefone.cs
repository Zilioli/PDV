#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace VOPDV
{
    public class VOTelefone
    {
        #region Variaveis
        private string _ID_TELEFONE = "";
        private string _DDD = "";
        private string _NU_TELEFONE = "";
        private string _TP_TELEFONE = "";
        #endregion

        #region Atributos
        public string ID_TELEFONE
        {
            get { return _ID_TELEFONE; }
            set { _ID_TELEFONE = value; }
        }

        public string DDD
        {
            get { return _DDD; }
            set { _DDD = value; }
        }

        public string NU_TELEFONE
        {
            get { return _NU_TELEFONE; }
            set { _NU_TELEFONE = value; }
        }

        public string TP_TELEFONE
        {
            get { return _TP_TELEFONE; }
            set { _TP_TELEFONE = value; }
        }
        #endregion
    }
}
