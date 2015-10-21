#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace VOPDV
{
    public class VOPessoa
    {

        #region Variáveis 
        private string _ID_PESSOA = "";
        private string _NOME = "";
        private string _TP_PESSOA = "";
        private string _CPF_CNPJ = "";
        private string _EMAIL = "";
        private string _WEB_SITE = "";
        private string _URL_SOCIAL = "";
        private string _DT_EXCLUSAO = "";
        private List<VOTelefone> _LST_TELEFONES = new List<VOTelefone>();
        private List<VOEndereco> _LST_ENDERECO = new List<VOEndereco>();
        #endregion

        #region Atributos
        public string ID_PESSOA
        {
            get { return (_ID_PESSOA == "" ? null : _ID_PESSOA); }
            set { _ID_PESSOA = value; }
        }

        public string NOME
        {
            get { return (_NOME == "" ? null : _NOME); }
            set { _NOME = value; }
        }

        public string TP_PESSOA
        {
            get 
            {
                return (_TP_PESSOA == "" ? null : _TP_PESSOA); 
            }
            set { _TP_PESSOA = value; }
        }

        public string CPF_CNPJ
        {
            get { return (_CPF_CNPJ == "" ? null : _CPF_CNPJ); }
            set { _CPF_CNPJ = value; }
        }

        public string EMAIL
        {
            get { return (_EMAIL == "" ? null : _EMAIL); }
            set { _EMAIL = value; }
        }

        public string WEB_SITE
        {
            get { return (_WEB_SITE == "" ? null : _WEB_SITE); }
            set { _WEB_SITE = value; }
        }

        public string URL_SOCIAL
        {
            get { return (_URL_SOCIAL == "" ? null : _URL_SOCIAL); }
            set { _URL_SOCIAL = value; }
        }

        public string DT_EXCLUSAO
        {
            get { return (_DT_EXCLUSAO == "" ? null : _DT_EXCLUSAO); }
            set { _DT_EXCLUSAO = value; }
        }

        public List<VOTelefone> TELEFONES
        {
            get { return _LST_TELEFONES; }
            set { _LST_TELEFONES = value; }
        }

        public List<VOEndereco> ENDERECOS
        {
            get { return _LST_ENDERECO; }
            set { _LST_ENDERECO = value; }
        }
        #endregion
    }
}
