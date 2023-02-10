using System;
using System.Windows.Forms;
using Model;
using BLL;

namespace WF
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Usuario/Senha inválidos...","Dados Inválidos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsuario.Focus();
                return;
            }
            else
            {
                UsuarioBLL _usuarioBll = new UsuarioBLL();
                Usuario _usuario = new Usuario();
                string usuario = txtUsuario.Text;
                string senha = txtSenha.Text;

                Criptografia Cry = new Criptografia();
                string cript = Cry.EncodeToBase64(senha);
                
                
                _usuario = _usuarioBll.LoginUsuario(usuario, cript);
                

                if (_usuario == null)
                {
                    MessageBox.Show("Usuario/Senha inválidos...", "Dados Inválidos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Publico.UsuarioLogadoPerfil = _usuario.usuarioPerfil.Trim();
                    Publico.UsuarioLogadoNome = _usuario.usuarioNome.Trim();
                    this.Hide();
                    frmMenu _fmenu = new frmMenu();
                    _fmenu.Show();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja encerrar o programa ?", "Encerrar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                txtUsuario.Focus();
            }
        }
    }
}
