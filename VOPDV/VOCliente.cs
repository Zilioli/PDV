
using System.Xml;
namespace VOPDV
{
    public class VOCliente : VOPessoa 
    {
        #region Variáveis
        private string _ID_CLIENTE;
        private string _RG;
        private string _XML_TELEFONES;
        #endregion

        #region Atributos
        public string ID_CLIENTE
        {
            get { return _ID_CLIENTE; }
            set { _ID_CLIENTE = value; }
        }
        public string RG
        {
            get { return _RG; }
            set { _RG = value; }
        }

        public string XML_TELEFONES
        {
            get { return _XML_TELEFONES; }
            set { _XML_TELEFONES = value; }
        }

        #endregion
    }
}
