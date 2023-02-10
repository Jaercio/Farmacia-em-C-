using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

namespace WF
{
    public partial class frmConsultaPedidos : Form
    {
        public frmConsultaPedidos()
        {
            InitializeComponent();
        }


        ClienteBLL _clienteBll;
        Cliente cli;
        Pedido ped;
        Item item;
        int codigoPedido = 0;
        int codigoItem = 0;

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
                        return;
                    }
                    else
                    {
                        lblNomeCliente.Text = cli.clienteNome;
                        carregaPedidos(cli);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o cliente : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void carregaPedidos(Cliente cli)
        {
            PedidoBLL _pedidoBll = new PedidoBLL();
            List<Pedido> lista = _pedidoBll.GetPedidosPorCliente(cli.clienteId);
            if (lista.Count > 0)
            {
                dgvPedidos.DataSource = _pedidoBll.GetPedidosPorCliente(cli.clienteId);
                formataGridViewPedidos();
            }
            else
            {
                MessageBox.Show("Não existem pedidos para este cliente", "Cliente sem pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTelefoneCliente.Clear();
                return;
            }
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvPedidos.RowCount - 1;
            if (e.RowIndex != -1 & e.RowIndex <= i)
            {
                codigoPedido = (int)dgvPedidos.Rows[e.RowIndex].Cells[0].Value;
                Publico.codigoDoPedido = codigoPedido;
                mostrarItensPedidodoCliente(codigoPedido);
            }
        }

        private void mostrarItensPedidodoCliente(int codigoPedido)
        {
            try
            {
                ItemBLL _itemBll = new ItemBLL();
                dgvItensPedido.DataSource = _itemBll.GetItensPorPedidosDoCliente(codigoPedido);
                formataGridViewItens();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvItensPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvItensPedido.RowCount - 1;
            if (e.RowIndex != -1 & e.RowIndex <= i)
            {
                codigoItem = (int)dgvItensPedido.Rows[e.RowIndex].Cells[0].Value;
            }
        }

        private void btnAlterarPedido_Click(object sender, EventArgs e)
        {
            if (codigoPedido == 0 )
            {
                MessageBox.Show("Selecione um pedido para alterar.", "Selecionar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PedidoBLL _pedidoBll = new PedidoBLL();
                ped = _pedidoBll.Localizar(codigoPedido);
                if (ped == null)
                {
                    MessageBox.Show("Pedido não localizado para este código", "Pedido não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    frmPedidoAltera frmPedAlt = new frmPedidoAltera();
                    frmPedAlt.ShowDialog();
                    carregaPedidos(cli);
                }
            }
        }

        private void btnAlterarItem_Click(object sender, EventArgs e)
        {
            if (codigoItem == 0)
            {
                MessageBox.Show("Selecione um pedido para alterar.", "Selecionar Pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ItemBLL _itemBll = new ItemBLL();
                item = _itemBll.Localizar(codigoItem);
                if (item == null)
                {
                    MessageBox.Show("Item não localizado para este código", "Pedido não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    Publico.codigoDoItem = codigoItem;
                    frmItemAltera frmItemAlt = new frmItemAltera();
                    frmItemAlt.ShowDialog();
                    mostrarItensPedidodoCliente(Publico.codigoDoPedido);
                    AlterarValorTotaldoPedido();
                    carregaPedidos(cli);
                }
            }
        }

        private decimal ValorTotal()
        {
            decimal total = 0;
            decimal valor = 0;
            int quant = 0;
            try
            {
                for (int i = 0; i <= dgvItensPedido.Rows.Count - 1; i++)
                {
                    valor = Convert.ToDecimal(dgvItensPedido.Rows[i].Cells["itemValor"].Value);
                    quant = Convert.ToInt32(dgvItensPedido.Rows[i].Cells["itemQuantidade"].Value);
                    total = total + Convert.ToDecimal(valor * quant);
                }
                return total;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AlterarValorTotaldoPedido()
        {
            PedidoBLL _pedidoBll = new PedidoBLL();
            Pedido pedido;

            decimal valorTotalPedido = ValorTotal();

            try
            {
                pedido = _pedidoBll.Localizar(Publico.codigoDoPedido);
                pedido.pedidoValor = valorTotalPedido;
               _pedidoBll.AlterarPedido(pedido);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message , "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formataGridViewItens()
        {
            var dgvip = dgvItensPedido;
            dgvip.AutoGenerateColumns = false;
            dgvip.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvip.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvip.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvip.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;
            dgvip.Columns[0].HeaderText = "Cod.Item";
            dgvip.Columns[1].HeaderText = "Cod.Pedido";
            dgvip.Columns[2].HeaderText = "Cod.Produto";
            dgvip.Columns[3].HeaderText = "Valor";
            dgvip.Columns[4].HeaderText = "Qtde";
            dgvip.Columns[0].Width = 95;
            dgvip.Columns[1].Width = 95;
            dgvip.Columns[2].Width = 90;
            dgvip.Columns[3].Width = 120;
            dgvip.Columns[4].Width = 80;
            dgvip.Columns[5].Visible = false;
            dgvip.Columns[6].Visible = false;
            dgvip.Columns[3].DefaultCellStyle.Format = "c";
            dgvip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvip.MultiSelect = false;
            dgvip.DefaultCellStyle.NullValue = " - ";
            dgvip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvip.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void formataGridViewPedidos()
        {
            var dgvip = dgvPedidos;
            dgvip.AutoGenerateColumns = false;
            dgvip.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgvip.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvip.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            dgvip.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;
            dgvip.Columns[0].HeaderText = "Cod.Pedido";
            dgvip.Columns[1].HeaderText = "Cod.Cliente";
            dgvip.Columns[2].HeaderText = "Data Pedido";
            dgvip.Columns[3].HeaderText = "Entrega";
            dgvip.Columns[4].HeaderText = "Valor";
            dgvip.Columns[5].HeaderText = "Status";
            dgvip.Columns[0].Width = 80;
            dgvip.Columns[1].Width = 80;
            dgvip.Columns[2].Width = 90;
            dgvip.Columns[3].Width = 90;
            dgvip.Columns[4].Width = 90;
            dgvip.Columns[5].Width = 80;
            dgvip.Columns[6].Visible = false;
            dgvip.Columns[7].Visible = false;
            dgvip.Columns[4].DefaultCellStyle.Format = "c";
            dgvip.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvip.MultiSelect = false;
            dgvip.DefaultCellStyle.NullValue = " - ";
            dgvip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvip.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btn_rela_Click(object sender, EventArgs e)
        {
            var Globais = Directory.GetCurrentDirectory()+"\\vendas.pdf";
            string nomeArquivo = Globais;
            FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
            Document doc = new Document(PageSize.A4);
            PdfWriter escritorPDF = PdfWriter.GetInstance(doc, arquivoPDF);

            
            string dados = "";

            Paragraph paragrafo = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("Farmácia ");

            paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Italic);
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("Jaércio - CJ301200X");
            MessageBox.Show("Arquivo PDF gerado em: " + Globais);

            Paragraph paragrafo1 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            paragrafo1.Alignment = Element.ALIGN_CENTER;
            paragrafo1.Add("Relatório de Vendas");

            Paragraph paragrafo2 = new Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, (int)System.Drawing.FontStyle.Bold));

            paragrafo2.Alignment = Element.ALIGN_CENTER;
            paragrafo2.Add(" ");


            PdfPTable tabela = new PdfPTable(3);
            tabela.DefaultCell.FixedHeight = 20;

            tabela.AddCell("ID Venda");
            tabela.AddCell("Produto");
            tabela.AddCell("Valor");

   

            doc.Open();
            doc.Add(paragrafo);
            doc.Add(paragrafo1);
            doc.Add(paragrafo2);
            doc.Add(tabela);

            doc.Close();

        }

        private void dgvPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
