using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOPDV
{
    public class VOTela
    {
        private string _ID_TELA = "";
        private string _NM_TELA = "";
        private string _NM_FISICO = "";
        private string _ICON = "";
        private string _FLAG = "";

        public string ID_TELA
        {
            get{return _ID_TELA;}
            set{_ID_TELA = value;}
        }

        public string NM_TELA
        {
            get{return _NM_TELA;}
            set{_NM_TELA = value;}
        }

        public string NM_FISICO
        {
            get{return _NM_FISICO;}
            set{_NM_FISICO = value;}
        }

        public string ICON
        {
            get { return _ICON; }
            set { _ICON = value; }
        }

        public string FLAG
        {
            get { return _FLAG; }
            set { _FLAG = value; }
        }
    }

    public class VOItemMenu
    {
        private string _ID_ITEM_MENU = "";
        private string _NM_ITEM_MENU = "";
        private string _ICON = "";
        private List<VOTela>_TELAS = new List<VOTela>();

        public string ID_ITEM_MENU
        {
            get { return _ID_ITEM_MENU; }
            set { _ID_ITEM_MENU = value; }
        }

        public string NM_ITEM_MENU
        {
            get { return _NM_ITEM_MENU; }
            set { _NM_ITEM_MENU = value; }
        }

        public string ICON
        {
            get { return _ICON; }
            set { _ICON = value; }
        }

        public  List<VOTela> TELAS
        {
            get{return _TELAS;}
            set { _TELAS = value; }
        }
    }
}
