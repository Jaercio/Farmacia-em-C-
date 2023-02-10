using System;
using System.Windows.Forms;
using Model;
using BLL;

namespace WF
{
    public partial class frmConsultaClientes : Form
    {
        public frmConsultaClientes()
        {
            InitializeComponent();
        }

        ClienteBLL _clienteBll;
        Cliente cli;

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            string telefone = "";
            if (string.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
            {
                frmClientesCadastrados frmclicad = new frmClientesCadastrados();

                frmclicad.ShowDialog();
                telefone = Publico.telefoneDoCliente.Trim();
                txtTelefoneCliente.Text = telefone;
            }

            if (string.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
            {
                MessageBox.Show("Informe o telefone do cliente", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    _clienteBll = new ClienteBLL();
                    cli = new Cliente();
                    telefone = txtTelefoneCliente.Text;
                    cli = _clienteBll.LocalizarPorTelefone(telefone);
                    if (cli == null)
                    {
                        MessageBox.Show("Cliente não localizado para este telefone", "Cliente não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTelefoneCliente.Focus();
                        return;
                    }
                    else
                    {
                        txtID.Text = cli.clienteId.ToString();
                        txtNome.Text = cli.clienteNome;
                        txtEndereco.Text = cli.clienteEndereco;
                        txtEmail.Text = cli.clienteEmail;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o cliente : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
