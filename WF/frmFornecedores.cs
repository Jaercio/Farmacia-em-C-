using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Net.Mail;
using System.Collections.Generic;

namespace WF
{
    public partial class frmFornecedores : Form
    {
        public frmFornecedores()
        {
            InitializeComponent();
        }

        FornecedorBLL _fornecedorBll;

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do Fornecedor", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _fornecedorBll = new FornecedorBLL();
                    Fornecedor forn = new Fornecedor();
                    int codigo = Convert.ToInt32(txtID.Text);
                    forn = _fornecedorBll.Localizar(codigo);
                    if (forn == null)
                    {
                        MessageBox.Show("Fornecedor não localizado para este código", "Fornecedor não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        txtNome.Text = forn.fornecedorNome;
                        txtEndereco.Text = forn.fornecedorEndereco;
                        txtTelefone.Text = forn.fornecedorTelefone;
                        txtEmail.Text = forn.fornecedorEmail;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o Fornecedor : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
                if (validaControles())
                {
                    try
                    {
                        Fornecedor forn = new Fornecedor();
                        _fornecedorBll = new FornecedorBLL();
                        forn.fornecedorNome = txtNome.Text;
                        forn.fornecedorEndereco = txtEndereco.Text;
                        forn.fornecedorTelefone = txtTelefone.Text;
                        forn.fornecedorEmail = txtEmail.Text;
                        forn.fornecedorHome = txtSite.Text;
                        forn.categoriaId =  (int)cboCategorias.SelectedValue;
                        _fornecedorBll.AdicionarFornecedor(forn);
                        MessageBox.Show("Fornecedor incluído com sucesso", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao incluir o Fornecedor : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dados inválidos. Preencha todos os campos do formulário ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtNome.Focus();
                }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do Fornecedor", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _fornecedorBll = new FornecedorBLL();
                    Fornecedor forn = new Fornecedor();
                    int codigo = Convert.ToInt32(txtID.Text);
                    forn = _fornecedorBll.Localizar(codigo);
                    if (forn == null)
                    {
                        MessageBox.Show("Fornecedor não localizado para este código", "Fornecedor não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Confirma exclusão deste Fornecedor ?", "Excluir", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _fornecedorBll.ExcluirFornecedor(forn);
                            MessageBox.Show("Fornecedor excluido com sucesso", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do Fornecedor", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _fornecedorBll = new FornecedorBLL();
                    Fornecedor forn = new Fornecedor();
                    int codigo = Convert.ToInt32(txtID.Text);
                    forn = _fornecedorBll.Localizar(codigo);
                    if (forn == null)
                    {
                        MessageBox.Show("Fornecedor não localizado para este código", "Fornecedor não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        forn.fornecedorNome = txtNome.Text;
                        forn.fornecedorEndereco = txtEndereco.Text;
                        forn.fornecedorTelefone = txtTelefone.Text;
                        forn.fornecedorEmail = txtEmail.Text;
                        forn.fornecedorHome = txtSite.Text;
                        forn.categoriaId = (int)cboCategorias.SelectedValue;
                        _fornecedorBll.AlterarFornecedor(forn);
                        MessageBox.Show("Fornecedor alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o Fornecedor : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSair_Click_1(object sender, EventArgs e)
        {
            this.Close();
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

        
        /// <returns></returns>
        private bool validaControles()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length < 5)
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
            if (!IsEmailValido(txtEmail.Text) || txtEmail.Text.Length < 5)
            {
                return false;
            }
            if (cboCategorias.SelectedIndex < 0 )
            {
                return false;
            }
            return true;
        }

        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFornecedores_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void frmFornecedores_Load(object sender, EventArgs e)
        {
            carregaCategorias();
        }

        private void carregaCategorias()
        {
            try
            {
                CategoriaBLL _categoriaBll = new CategoriaBLL();
                List<Categoria> cat = _categoriaBll.Get_CategoriaInfo();

                cboCategorias.DataSource = cat;
                cboCategorias.ValueMember = "categoriaId";
                cboCategorias.DisplayMember = "categoriaNome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
