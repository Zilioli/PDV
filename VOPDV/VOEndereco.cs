#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace VOPDV
{
    public class VOEndereco
    {
        private string _ID_ENDERECO = "";
        private string _CEP = "";
        private string _BAIRRO = "";
        private string _CIDADE = "";
        private string _ESTADO = "";
        private string _SIGLA = "";
        private string _LOGRADOURO = "";
        private string _NU_LOGRADOUTO = "";
        private string _COMPLEMENTO = "";

        public string ID_ENDERECO
        {
            get { return _ID_ENDERECO; }
            set { _ID_ENDERECO = value; }
        }

        public string CEP
        {
            get { return _CEP; }
            set { _CEP = value; }
        }

        public string BAIRRO
        {
            get { return _BAIRRO; }
            set { _BAIRRO = value; }
        }

        public string CIDADE
        {
            get { return _CIDADE; }
            set { _CIDADE = value; }
        }

        public string ESTADO
        {
            get { return _ESTADO; }
            set { _ESTADO = value; }
        }

        public string SIGLA
        {
            get { return _SIGLA; }
            set { _SIGLA = value; }
        }

        public string LOGRADOURO
        {
            get { return _LOGRADOURO; }
            set { _LOGRADOURO = value; }
        }

        public string NU_LOGRADOURO
        {
            get { return _NU_LOGRADOUTO; }
            set { _NU_LOGRADOUTO = value; }
        }

        public string COMPLEMENTO
        {
            get { return _COMPLEMENTO; }
            set { _COMPLEMENTO = value; }
        }
    }
}
