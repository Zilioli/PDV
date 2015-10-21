#region "using"
using System;
using System.Windows.Forms;
using PDVForms.Util;
#endregion

namespace PDVForms
{
    public partial class frmSelecionaModulo : Form
    {
        public frmSelecionaModulo()
        {
            InitializeComponent();

            clsUtil.InsereToolTip(pbModuloAdmin, "Módulo Administrativo");
            clsUtil.InsereToolTip(pbModuloVendas, "Módulo de Vendas");
        }

        private void PB_MOD_ADM_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form mdiModuloAdministrativo = new mdiModuloAdministrativo();
            mdiModuloAdministrativo.Show();
        }
    }
}
