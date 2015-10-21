#region using
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDVForms.Util;
using VOPDV;
using System.Reflection;
using System.Resources;
#endregion

namespace PDVForms 
{
    public partial class mdiModuloAdministrativo : Form
    {
        #region Construtor
        public mdiModuloAdministrativo()
        {
            InitializeComponent();
        }
        #endregion

        #region clientesToolStripMenuItem_Click
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtil.AbreFormulario(new frmManutencaoCliente(), this);
        }
        #endregion

        #region mdiModuloAdministrativo_Load
        private void mdiModuloAdministrativo_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarTela();
            }
            catch (Exception ex)
            {
                clsUtil.ExibirMensagem("ERRO AO CARREGAR A TELA: " + ex.Message, "Modulo Adminsitrativo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CarregarTela
        private void CarregarTela()
        {
            ToolStripMenuItem objItem;
            ToolStripMenuItem objSubItem;
            ResourceManager rm;

            try
            {
                //Percorre todos os itens do menu
                foreach (VOItemMenu item_menu in clsUtil.objUSUARIO.ITENS_MENU)
                {
                    //Adiciona os itens do Menu
                    objItem = new ToolStripMenuItem();
                    objItem.Text = item_menu.NM_ITEM_MENU;

                    //Verifica se o item do menu possui imagem cadastrada
                    if (item_menu.ICON != "")
                    {
                        //Adiciona icone no item do menu
                        rm = Properties.Resources.ResourceManager;
                        if (rm.GetObject(item_menu.ICON) != null)
                            objItem.Image = (Image)rm.GetObject(item_menu.ICON);
                        rm = null;
                    }

                    //Percorre as telas do item do menu
                    foreach (VOTela tela in item_menu.TELAS)
                    {
                        //Cria o SubItem
                        objSubItem = new ToolStripMenuItem();
                        objSubItem.Text = tela.NM_TELA;
                        objSubItem.Click += ClickItemMenu;
                        objSubItem.Name = tela.NM_FISICO;

                        //Verifica se o SubItem possui imagem cadastrada
                        if (tela.ICON != "")
                        {
                            //Adiciona icone no subitem do menu
                            rm = Properties.Resources.ResourceManager;
                            if (rm.GetObject(tela.ICON) != null)
                                objSubItem.Image = (Image)rm.GetObject(tela.ICON);
                            rm = null;
                        }

                        //Adiciona os SubItens no Menu Item
                        objItem.DropDownItems.Add(objSubItem);

                        //Finaliza o objeto
                        objSubItem = null;
                    }

                    //Adiciona o item no Menu
                    msMenu.Items.Add(objItem);

                    //Finaliza o objeto
                    objItem = null;
                }

                objItem = new ToolStripMenuItem();
                objItem.Text = "Sair";
                objItem.Name = "Sair";
                objItem.Image = Properties.Resources.exit;
                objItem.Click += ClickItemMenu;

                //Adiciona o Sair no Menu
                msMenu.Items.Add(objItem);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //Finaliza os objetos
                objItem = null;
                objSubItem = null;
                rm = null;
            }

        }

        #endregion

        #region ClickItemMenu
        private void ClickItemMenu(object sender, EventArgs e)
        {
            Form objForm;

            switch (((ToolStripMenuItem)sender).Name)
            {
                case "frmManutencaoCliente":
                    objForm = new frmManutencaoCliente();
                    objForm.ShowDialog(this);
                    break;

                case "frmManutencaoFornecedor":
                    objForm = new frmManutencaoFornecedor();
                    objForm.ShowDialog(this);
                    break;

                case "frmListaFornecedores":
                    objForm = new frmListaFornecedores();
                    objForm.ShowDialog(this);
                    break;

                case "frmListaClientes":
                    objForm = new frmListaClientes();
                    objForm.ShowDialog(this);
                    break;

                case "frmManutencaoUsuarios":
                    objForm = new frmManutencaoUsuarios();
                    objForm.ShowDialog(this);
                    break;

                case "frmListaUsuarios":
                    objForm = new frmListaUsuarios();
                    objForm.ShowDialog(this);
                    break;

                case "Sair":
                    Environment.Exit(0);
                    break;

                default:
                    clsUtil.ExibirMensagem("Tela não cadastrada.", "Modulo Administrativo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        #endregion

        #region mdiModuloAdministrativo_FormClosing
        private void mdiModuloAdministrativo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
