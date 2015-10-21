#region using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace VOPDV
{
    public class VOFornecedor : VOPessoa
    {
        #region Variáveis
        private string _ID_FORNECEDOR;
        private List<VOPessoa> _LST_CONTATOS = new List<VOPessoa>();
        #endregion

        #region Atributos
        public string ID_FORNECEDOR
        {
            get { return _ID_FORNECEDOR; }
            set { _ID_FORNECEDOR = value; }
        }

        public List<VOPessoa> CONTATOS
        {
            get { return _LST_CONTATOS; }
            set { _LST_CONTATOS = value; }
        }
        #endregion
    }
}