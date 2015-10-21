using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOPDV
{
    public class VOUF
    {
        private string _SIGLA = "";
        private string _NOME = "";

        public string SIGLA
        {
            get { return _SIGLA; }
            set { _SIGLA = value; }
        }

        public string NOME
        {
            get { return _NOME; }
            set { _NOME = value; }
        }

    }

    public class VOLocalidade
    {
        private string _ID_CIDADE = "";
        private string _CIDADE = "";

        public string CIDADE
        {
            get { return _CIDADE; }
            set { _CIDADE = value; }
        }

        public string ID_CIDADE
        {
            get { return _ID_CIDADE; }
            set { _ID_CIDADE = value; }
        }
    }

    public class VOCEP
    {

        private string _TIPO_LOGRADOURO = "";
        private string _LOGRADOURO = "";
        private string _BAIRRO = "";
        private string _ID_CIDADE = "";
        private string _CIDADE = "";       
        private string _UF = "";
        private string _CEP = "";

        public string ID_CIDADE
        {
            get { return _ID_CIDADE; }
            set { _ID_CIDADE = value; }
        }

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string UF
        {
            get { return _UF; }
            set { _UF = value; }
        }
        
        public string CIDADE
        {
            get { return _CIDADE; }
            set { _CIDADE = value; }
        }

        public string BAIRRO
        {
            get { return _BAIRRO; }
            set { _BAIRRO = value; }
        }

        public string LOGRADOURO
        {
            get { return _LOGRADOURO; }
            set { _LOGRADOURO = value; }
        }

        public string TIPO_LOGRADOURO
        {
            get { return _TIPO_LOGRADOURO; }
            set { _TIPO_LOGRADOURO = value; }
        }
    }
}
