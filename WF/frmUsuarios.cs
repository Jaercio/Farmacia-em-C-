using System;
using System.Windows.Forms;
using Model;
using BLL;

namespace WF
{
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }

        UsuarioBLL _usuarioBll;

        private void btnLocalizar_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do Usuário", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _usuarioBll = new UsuarioBLL();
                    Usuario usu = new Usuario();
                    int codigo = Convert.ToInt32(txtID.Text);
                    usu = _usuarioBll.Localizar(codigo);
                    if (usu == null)
                    {
                        MessageBox.Show("Usuário não localizado para este código", "Usuário não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        txtNome.Text = usu.usuarioNome;
                        txtSenha.Text = usu.usuarioSenha;
                        cboPerfil.SelectedIndex = usu.usuarioPerfil.Trim().Equals("ADM") ? 0 : 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o Usuário : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        
        private void limpaControles()
        {
            foreach (Control Cleartext in this.Controls)
            {
                if (Cleartext is TextBox)
                {
                    ((TextBox)Cleartext).Text = string.Empty;
                }
                cboPerfil.SelectedIndex = -1;
            }
        }

       
        private bool validaControles()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length  < 5)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSenha.Text) || txtSenha.Text.Length < 6 )
            {
                return false;
            }
            if(cboPerfil.SelectedIndex == -1)
            {
                return true;
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

        private void btnIncluir_Click(object sender, System.EventArgs e)
        {


                if (validaControles())
                {
                    try
                    {
                        Usuario usu = new Usuario();
                        _usuarioBll = new UsuarioBLL();
                    usu.usuarioNome = txtNome.Text;
                        usu.usuarioSenha = txtSenha.Text;
                        usu.usuarioPerfil = cboPerfil.Text.Equals("Administrador") ? "ADM" : "USR";
                        
                        _usuarioBll.AdicionarUsuario(usu);
                        MessageBox.Show("Usuário incluído com sucesso", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao incluir o Usuário : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Informe o código do Usuario", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _usuarioBll = new UsuarioBLL();
                    Usuario usu = new Usuario();
                    int codigo = Convert.ToInt32(txtID.Text);
                    usu = _usuarioBll.Localizar(codigo);
                    if (usu == null)
                    {
                        MessageBox.Show("Usuario não localizado para este código", "Usuario não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Confirma exclusão deste Usuario ?", "Excluir", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _usuarioBll.ExcluirUsuario(usu);
                            MessageBox.Show("Usuario excluido com sucesso", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Informe o código do Usuario", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _usuarioBll = new UsuarioBLL();
                    Usuario usu = new Usuario();
                    int codigo = Convert.ToInt32(txtID.Text);
                    usu = _usuarioBll.Localizar(codigo);
                    if (usu == null)
                    {
                        MessageBox.Show("Usuario não localizado para este código", "Usuario não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        usu.usuarioNome = txtNome.Text;
                        usu.usuarioSenha = txtSenha.Text;
                        usu.usuarioPerfil = cboPerfil.Text.Equals("Administrador") ? "ADM" : "USR";
                        //altera usuario
                        _usuarioBll.AlterarUsuario(usu);
                        MessageBox.Show("Usuario alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o Usuario : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaControles();
            txtNome.Focus();
            return;
        }

        
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmUsuarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
