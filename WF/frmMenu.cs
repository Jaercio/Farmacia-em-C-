using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            clienteToolStripMenuItem.Enabled = Publico.UsuarioLogadoPerfil.Equals("ADM");
            fornecedorToolStripMenuItem.Enabled = Publico.UsuarioLogadoPerfil.Equals("ADM");
            produtoToolStripMenuItem.Enabled = Publico.UsuarioLogadoPerfil.Equals("ADM");
            usuarioToolStripMenuItem.Enabled = Publico.UsuarioLogadoPerfil.Equals("ADM");
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmClientes frmCli = new frmClientes();
            frmCli.ShowDialog();
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedores frmForn = new frmFornecedores();
            frmForn.ShowDialog();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos frmProd = new frmProdutos();
            frmProd.ShowDialog();
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios frmUsu = new frmUsuarios();
            frmUsu.ShowDialog();
        }

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPedidos frmPed = new frmPedidos();
            frmPed.ShowDialog();
        }

        private void consultaPeddosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaPedidos frmConsPed = new frmConsultaPedidos();
            frmConsPed.ShowDialog();
        }

        private void consultaClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaClientes frmConsCli = new frmConsultaClientes();
            frmConsCli.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar o programa ?", "Encerrar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)            {
                Application.Exit();
            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSobre frmsobre = new frmSobre();
            frmsobre.ShowDialog();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string caminho = AppDomain.CurrentDomain.BaseDirectory; 

            string arquivo = Publico.retornaCaminhoApp(caminho) + "\\Manual\\ControlNapole.txt";

            if ((File.Exists(arquivo)))
            {
                System.Diagnostics.Process.Start("notepad.exe", arquivo);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
