using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Collections.Generic;
using System.Globalization;

namespace WF
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        ClienteBLL _clienteBll;
        Cliente cli;
        List<ProdutoPedido> produtos = new List<ProdutoPedido>();
        List<ProdutoPedido> ItensPedidoFeito;
        bool gravouPedido = false;
        
        int quantidade;
        decimal valorPedido = 0 ;

        private void btnLocalizarCliente_Click(object sender, EventArgs e)
        {
            string telefone = "";
            if (string.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
            {
                frmClientesCadastrados frmclicad = new frmClientesCadastrados();

                frmclicad.ShowDialog();
                telefone = Publico.telefoneDoCliente.Trim();
                txtTelefoneCliente.Text = telefone;
            }

            if(string.IsNullOrWhiteSpace(txtTelefoneCliente.Text))
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
                        return;
                    }
                    else
                    {
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

        private void frmPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                ProdutoBLL _produtoBll = new ProdutoBLL();
                List<Produto> prod = _produtoBll.Get_ProdutoInfo();

                cboPizzas.DataSource = prod;
                cboPizzas.ValueMember = "produtoId";
                cboPizzas.DisplayMember = "produtoNome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnIncluirPizza_Click(object sender, EventArgs e)
        {
            if (cboPizzas.SelectedIndex >= 0)
            {
                quantidade = (int)nupQuantidade.Value;
                int codigoProduto = (int)cboPizzas.SelectedValue;

                try
                {
                    ProdutoBLL _produtoBll = new ProdutoBLL();
                    Produto prod = new Produto();
                    prod = _produtoBll.Localizar(codigoProduto);
                
                    if (prod == null)
                    {
                        MessageBox.Show("Produto não localizado para este código", "Produto não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNome.Focus();
                        return;
                    }
                    else
                    {
                        ItensPedidoFeito = MontaColecaoPedidos(prod);
                        dgvItem.DataSource = ItensPedidoFeito.ToArray();            
                        formataGridView();
                        valorPedido = ValorTotal();
                        txtTotal.Text = valorPedido.ToString("C", CultureInfo.CurrentCulture);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um Remédio ", "Selecionar Remédio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<ProdutoPedido> MontaColecaoPedidos(Produto prod)
        {
            try
            {
                ProdutoPedido prodped = new ProdutoPedido(prod.produtoId, prod.produtoNome, prod.produtoPreco, quantidade);
                produtos.Add(prodped);
                return produtos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
       }

       

        private decimal ValorTotal()
        {
            decimal total = 0;
            decimal valor = 0;
            int quant = 0;
            try
            {
                for (int i = 0; i <= dgvItem.Rows.Count - 1; i++)
                {
                    valor = Convert.ToDecimal(dgvItem.Rows[i].Cells["precovenda"].Value);
                    quant = Convert.ToInt32(dgvItem.Rows[i].Cells["quantidade"].Value);
                    total = total + Convert.ToDecimal(valor * quant);
                }
                return total;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnExcluirItem_Click(object sender, EventArgs e)
        {
            if (dgvItem.RowCount <= 0)
            {
                MessageBox.Show("Selecione um pedido para excluir.", "Dados inválidos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Tem certeza de que deseja deletar este registro ?", "Deletar", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    try
                    {
                        ItensPedidoFeito.RemoveAt(dgvItem.CurrentRow.Index);
                        dgvItem.DataSource = ItensPedidoFeito.ToArray();
                        dgvItem.Refresh();
                        valorPedido = ValorTotal();
                        txtTotal.Text = valorPedido.ToString("C", CultureInfo.CurrentCulture);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        private void btnGravarPedido_Click(object sender, EventArgs e)
        {
            PedidoBLL _pedido;
            ItemBLL _item;

            if (cli != null)
            {
                try
                {
                    var pedido = new Pedido
                    {
                        clienteId = cli.clienteId,
                        pedidoData = DateTime.Today,
                        pedidoEntrega = null,
                        pedidoValor = valorPedido,
                        pedidoStatus = "NOVO"
                    };

                    _pedido = new PedidoBLL();
                    _pedido.AdicionarPedido(pedido);

                    _item = new ItemBLL();
                    foreach (var ped in ItensPedidoFeito)
                    {
                        var item = new Item { produtoId = ped.ProdutoId, itemValor = ped.PrecoVenda, itemQuantidade = ped.Quantidade, Pedido = pedido };
                        _item.AdicionarItem(item);
                    }
                    _item.Salvar();
                    gravouPedido = true;
                    MessageBox.Show("Pedido gravado com sucesso.", "PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpaControles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pedido com dados inválidos", "PEDIDO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

         
        private void limpaControles()
        {
            txtTelefoneCliente.Text = "";
            dgvItem.DataSource = null;
            dgvItem.Rows.Clear();
            dgvItem.Refresh();
            ItensPedidoFeito.Clear();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            if (!gravouPedido)
            {
                if (MessageBox.Show("O pedido não foi gravado, deseja fechar assim mesmo ?", "Fechar", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void formataGridView()
        {
            var grd1 = dgvItem;
            grd1.AutoGenerateColumns = true;
            grd1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            grd1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grd1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            grd1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;
            grd1.Columns[0].HeaderText = "Código";
            grd1.Columns[1].HeaderText = "Produto";
            grd1.Columns[2].HeaderText = "Valor";
            grd1.Columns[0].Width = 70;
            grd1.Columns[1].Width = 180;
            grd1.Columns[2].DefaultCellStyle.Format = "c";
            grd1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grd1.MultiSelect = false;
            grd1.DefaultCellStyle.NullValue = " - ";
            grd1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grd1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
