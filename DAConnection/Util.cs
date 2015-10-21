namespace DAConnection
{
    public class Util
    {
        #region Variáveis
        private string _SERVER = "";
        private string _USER = "";
        private string _PASSWORD = "";
        private string _DATA_SOURCE = "";
        private string _CATALOG = "";
        private string _ERROR = "";
        #endregion

        #region Atributos
        public string SERVER
        {
            get { return _SERVER; }
            set { _SERVER = value; }
        }

        public string DATA_SOURCE
        {
            get { return _DATA_SOURCE; }
            set { _DATA_SOURCE = value; }
        }

        public string USER
        {
            get { return _USER; }
            set { _USER = value; }
        }

        public string CATALOG
        {
            get { return _CATALOG; }
            set { _CATALOG = value; }
        }

        public string PASSWORD
        {
            get { return _PASSWORD; }
            set { _PASSWORD = value; }
        }

        public string ERROR
        {
            get { return _ERROR; }
            set { _ERROR = value; }
        }
        #endregion

    }

    public class VOParameter
    {
        private string _NAME_PARAMETER = "";
        private System.Data.SqlClient.SqlParameter _PARAMETER;

        public string NAME_PARAMETER
        {
            get { return _NAME_PARAMETER; }
            set { _NAME_PARAMETER = value; }
        }

        public System.Data.SqlClient.SqlParameter PARAMETER
        {
            get { return _PARAMETER; }
            set { _PARAMETER = value; }
        }
    }
}
