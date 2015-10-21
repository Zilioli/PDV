using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOPDV
{
    public class VOUsuario
    {
        private string _IDUSUARIO = "";
        private string _NMUSUARIO = "";
        private string _LOGIN = "";
        private string _SENHA = "";
        public List<VOItemMenu> _ITENS_MENU = new List<VOItemMenu>();

        public string IDUSUARIO
        {
            get { return _IDUSUARIO; }
            set { _IDUSUARIO = value; }
        }

        public string NMUSUARIO
        {
            get { return _NMUSUARIO; }
            set { _NMUSUARIO = value; }
        }

        public string LOGIN
        {
            get { return _LOGIN; }
            set { _LOGIN = value; }
        }

        public string SENHA
        {
            get { return _SENHA; }
            set { _SENHA = value; }
        }

        public List<VOItemMenu> ITENS_MENU
        {
            get { return _ITENS_MENU; }
            set { _ITENS_MENU = value; }
        }

    }

}
