using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Net.Mail;

namespace WF
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        ClienteBLL _clienteBll;

       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncluir_Click(object sender, EventArgs e)
        {

                if (validaControles())
                {
                    try
                    {
                        Cliente cli = new Cliente();
                        _clienteBll = new ClienteBLL();
                        cli.clienteNome = txtNome.Text;
                        cli.clienteEndereco = txtEndereco.Text;
                        cli.clienteTelefone = txtTelefone.Text;
                        cli.clienteEmail = txtEmail.Text;
                        _clienteBll.AdicionarCliente(cli);
                        MessageBox.Show("Cliente incluído com sucesso", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao incluir o cliente : " + ex.Message, "Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dados inválidos. Preencha todos os campos do formulário corretamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
        }

      
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int codigoCliente = 0;
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                frmClientesCadastrados frmclicad = new frmClientesCadastrados();

                frmclicad.ShowDialog();
                codigoCliente = Publico.codigoDoCliente;
                txtID.Text = codigoCliente.ToString();
            }
            
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do cliente", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    _clienteBll = new ClienteBLL();
                    Cliente cli = new Cliente();
                    codigoCliente = Convert.ToInt32(txtID.Text);
                    cli = _clienteBll.Localizar(codigoCliente);
                    if (cli == null)
                    {
                        MessageBox.Show("Cliente não localizado para este código", "Cliente não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        txtNome.Text = cli.clienteNome;
                        txtEndereco.Text = cli.clienteEndereco;
                        txtTelefone.Text = cli.clienteTelefone;
                        txtEmail.Text = cli.clienteEmail;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o cliente : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do cliente", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    _clienteBll = new ClienteBLL();
                    Cliente cli = new Cliente();
                    int codigo = Convert.ToInt32(txtID.Text);
                    cli = _clienteBll.Localizar(codigo);
                    if (cli == null)
                    {
                        MessageBox.Show("Cliente não localizado para este código", "Cliente não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Confirma exclusão deste cliente ?", "Excluir", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _clienteBll.ExcluirCliente(cli);
                            MessageBox.Show("Cliente excluido com sucesso", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            limpaControles();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do cliente", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                try
                {
                    _clienteBll = new ClienteBLL();
                    Cliente cli = new Cliente();
                    int codigo = Convert.ToInt32(txtID.Text);
                    cli = _clienteBll.Localizar(codigo);
                    if (cli == null)
                    {
                        MessageBox.Show("Cliente não localizado para este código", "Cliente não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        cli.clienteNome = txtNome.Text;
                        cli.clienteEndereco = txtEndereco.Text;
                        cli.clienteTelefone = txtTelefone.Text;
                        cli.clienteEmail = txtEmail.Text;
                        _clienteBll.AlterarCliente(cli);
                        MessageBox.Show("Cliente alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o cliente : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void limpaControles()
        {
            foreach (Control LimparControle in this.Controls)
            {
                if (LimparControle is TextBox)
                {
                    ((TextBox)LimparControle).Text = string.Empty;
                }

                if (LimparControle is MaskedTextBox)
                {
                    ((MaskedTextBox)LimparControle).Text = string.Empty;
                }
            }
        }

    
        private bool validaControles()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length  < 5)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEndereco.Text) || txtEndereco.Text.Length < 5)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTelefone.Text) || txtTelefone.Text.Length < 8)
            {
                return false;
            }
            if (!IsEmailValido(txtEmail.Text) || txtEmail.Text.Length < 5 )
            {
                return false;
            }
            return true;
        }

        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

     
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmClientes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaControles();
            txtNome.Focus();
            return;
        }

        public bool IsEmailValido(string enderecoEmail)
        {
            try
            {
                MailAddress m = new MailAddress(enderecoEmail);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
