using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Collections.Generic;
using System.Globalization;
namespace WF
{
    public partial class frmItemAltera : Form
    {
        public frmItemAltera()
        {
            InitializeComponent();
        }

        ItemBLL _itemBll;
        Item _item;

        private void frmItemAltera_Load(object sender, EventArgs e)
        { 
            try
            {
                carregaProdutos();

                _itemBll = new ItemBLL();
                _item = new Item();
                _item = _itemBll.Localizar(Publico.codigoDoItem);
                if (_item == null)
                {
                    MessageBox.Show("Item não localizado para este código", "Item não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    txtCodigoItem.Text = _item.itemId.ToString();
                    txtCodigoPedido.Text = _item.pedidoId.ToString();
                    cboProdutos.SelectedValue = _item.produtoId;
                    txtValorItem.Text = _item.itemValor.ToString();
                    txtQuantidade.Text = _item.itemQuantidade.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao localizar o Item : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_item == null)
                {
                    MessageBox.Show("Item inválido para este código", "Item inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    _item.itemId = Convert.ToInt32(txtCodigoItem.Text);
                    _item.pedidoId = Convert.ToInt32(txtCodigoPedido.Text);
                    _item.produtoId = Convert.ToInt32(cboProdutos.SelectedValue);
                    _item.itemValor = Convert.ToDecimal(txtValorItem.Text);
                    _item.itemQuantidade = Convert.ToInt32(txtQuantidade.Text);
                    _itemBll.AlterarItem(_item);
                    MessageBox.Show("Item alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao localizar o item : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void carregaProdutos()
        {
            try
            {
                ProdutoBLL _produtoBll = new ProdutoBLL();
                List<Produto> prod = _produtoBll.Get_ProdutoInfo();

                cboProdutos.DataSource = prod;
                cboProdutos.ValueMember = "produtoId";
                cboProdutos.DisplayMember = "produtoNome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Produto prod = new Produto();
            try
            {
                ProdutoBLL _produtoBll = new ProdutoBLL();
                int codProd = Convert.ToInt32(cboProdutos.SelectedValue);
                prod = _produtoBll.Localizar(codProd);
                txtValorItem.Text = prod.produtoPreco.ToString();
            }
            catch (Exception)
            {}
        }

        private void txtValorItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
