using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Security;

namespace WF
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();

            AplicarEventos(txtPreco);
            AplicarEventos(txtDesconto);
        }

        
        ProdutoBLL _produtoBll;
        static string caminhoNomeImagem = "";

        private void btnLocalizarProduto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do produto", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _produtoBll = new ProdutoBLL();
                    Produto prod = new Produto();
                    int codigo = Convert.ToInt32(txtID.Text);
                    prod = _produtoBll.Localizar(codigo);
                    if (prod == null)
                    {
                        MessageBox.Show("Produto não localizado para este código", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        txtNome.Text = prod.produtoNome;
                        txtPreco.Text = prod.produtoPreco.ToString("C",CultureInfo.CurrentCulture);
                        txtDesconto.Text = prod.produtoDesconto.ToString("C", CultureInfo.CurrentCulture);
                        cboCategorias.SelectedValue = prod.produtoCategoriaId;
                        if (prod.produtoImagem != null)
                        {
                            using (MemoryStream stream = new MemoryStream(prod.produtoImagem))
                            {
                                Bitmap imagemDb = new Bitmap(stream);
                                picImagemProduto.Image = imagemDb;
                            }
                        }
                        else
                        {
                            Image imagem = Image.FromFile(@"C:\Users\user\Documents\Visual Studio 2013\Projects\Control_Napole\WF\Imagens\ProdutoSemImagem.jpg");
                            picImagemProduto.Image = imagem;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o produto : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

      
        private void limpaControles()
        {
            foreach (Control limparTexto in this.Controls)
            {
                if (limparTexto is TextBox)
                {
                    ((TextBox)limparTexto).Text = string.Empty;
                }
            }
            cboCategorias.SelectedIndex = -1;
        }

        
        private bool validaControles()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || txtNome.Text.Length < 5)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPreco.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDesconto.Text))
            {
                txtDesconto.Text = "0";
            }
            if (cboCategorias.SelectedIndex < 0)
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

        private void btnIncluir_Click(object sender, EventArgs e)
        {
                if (validaControles())
                {
                    try
                    {
                        Produto prod = new Produto();
                        _produtoBll = new ProdutoBLL();
                        prod.produtoNome = txtNome.Text;
                        prod.produtoPreco = Convert.ToDecimal(txtPreco.Text.Replace("R$",""));
                        prod.produtoDesconto = Convert.ToDecimal(txtDesconto.Text.Replace("R$",""));
                        prod.produtoCategoriaId = (int)cboCategorias.SelectedValue;
                        prod.produtoImagem = File.ReadAllBytes(caminhoNomeImagem);
                        _produtoBll.AdicionarProduto(prod);
                        MessageBox.Show("Produto incluído com sucesso", "Incluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao incluir o produto : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Dados inválidos. Preencha todos os campos do formulário ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                MessageBox.Show("Informe o código do produto", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _produtoBll = new ProdutoBLL();
                    Produto prd = new Produto();
                    int codigo = Convert.ToInt32(txtID.Text);
                    prd = _produtoBll.Localizar(codigo);
                    if (prd == null)
                    {
                        MessageBox.Show("Produto não localizado para este código", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Confirma exclusão deste Produto ?", "Excluir", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            _produtoBll.ExcluirProduto(prd);
                            MessageBox.Show("Produto excluido com sucesso", "Excluir", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Informe o código do produto", "Dado inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Focus();
                return;
            }
            else
            {
                try
                {
                    _produtoBll = new ProdutoBLL();
                    Produto prd = new Produto();
                    int codigo = Convert.ToInt32(txtID.Text);
                    prd = _produtoBll.Localizar(codigo);
                    if (prd == null)
                    {
                        MessageBox.Show("Produto não localizado para este código", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpaControles();
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        prd.produtoNome = txtNome.Text;
                        prd.produtoPreco = Convert.ToDecimal(txtPreco.Text.Replace("R$",""));
                        prd.produtoDesconto = Convert.ToDecimal(txtDesconto.Text.Replace("R$",""));
                        prd.produtoCategoriaId = (int)cboCategorias.SelectedValue;
                        prd.produtoImagem = File.ReadAllBytes(caminhoNomeImagem);
                        _produtoBll.AlterarProduto(prd);
                        MessageBox.Show("Produto alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o Produto : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaControles();
            txtNome.Focus();
            return;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProdutos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo((char)Keys.Return)) == 0)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void RetornarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = double.Parse(txt.Text).ToString("C2");
        }

        private void TirarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.SelectAll();
            txt.Text = txt.Text.Replace("R$", "").Trim();
        }

        private void ApenasValorNumerico(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                if (e.KeyChar == ',')
                {
                    e.Handled = (txt.Text.Contains(","));
                }
                else
                    e.Handled = true;
            }
        }

        private void AplicarEventos(TextBox txt)
        {
            txt.Enter += TirarMascara;
            txt.Leave += RetornarMascara;
            txt.KeyPress += ApenasValorNumerico;
        }

        private void frmProdutos_Load(object sender, EventArgs e)
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

        private void btnProcurarImagem_Click(object sender, EventArgs e)
        {
            
            this.ofd1.Title = "Selecionar Imagem";
            ofd1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
            ofd1.CheckFileExists = true;
            ofd1.CheckPathExists = true;
            ofd1.FilterIndex = 2;
            ofd1.RestoreDirectory = true;
            ofd1.ReadOnlyChecked = true;
            ofd1.ShowReadOnly = true;

            DialogResult dr = this.ofd1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                
                   caminhoNomeImagem = ofd1.FileName;
                    try
                    {
                       
                        Image Imagem = Image.FromFile(caminhoNomeImagem);
                        picImagemProduto.SizeMode = PictureBoxSizeMode.StretchImage;
                      
                        picImagemProduto.Image = Imagem;
                    }
                    catch (SecurityException ex)
                    {
                        
                        MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                    "Mensagem : " + ex.Message + "\n\n" +
                                                    "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        
                        MessageBox.Show("Não é possível exibir a imagem : " + caminhoNomeImagem.Substring(caminhoNomeImagem.LastIndexOf('\\'))
                                                   + ". Você pode não ter permissão para ler o arquivo , ou " +
                                                   " ele pode estar corrompido.\n\nErro reportado : " + ex.Message);
                    }
               
            }
        }

        private void picImagemProduto_Click(object sender, EventArgs e)
        {

        }

        private void cboCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
