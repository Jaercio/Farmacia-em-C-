using System;
using System.Windows.Forms;
using Model;
using BLL;
using System.Collections.Generic;
using System.Globalization;

namespace WF
{
    public partial class frmPedidoAltera : Form
    {
        public frmPedidoAltera()
        {
            InitializeComponent();
        }

        PedidoBLL _pedidoBll;
        Pedido _pedido;

        private void frmPedidoAltera_Load(object sender, EventArgs e)
        {
            try
            {
                 carregaClientes();
                _pedidoBll = new PedidoBLL();
                _pedido = new Pedido();
                _pedido = _pedidoBll.Localizar(Publico.codigoDoPedido);
                if (_pedido == null)
                {
                    MessageBox.Show("Pedido não localizado para este código", "Pedido não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    txtCodigoPedido.Text = _pedido.pedidoId.ToString();
                    cboClientes.SelectedValue = _pedido.clienteId;
                    
                    dtpDataPedido.Value = _pedido.pedidoData;

                    if (_pedido.pedidoEntrega == null )
                    {
                        dtpDataEntrega.Value = DateTime.Today; 
                    }
                    else
                    {
                        dtpDataEntrega.Value = Convert.ToDateTime(_pedido.pedidoEntrega);
                    }
                    txtValorPedido.Text = _pedido.pedidoValor.ToString();
                    cboStatusPedido.Text = _pedido.pedidoStatus;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao localizar o pedido : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
                try
                {
                    if (_pedido == null)
                    {
                        MessageBox.Show("Pedido inválido para este código", "Pedido inválido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        _pedido.pedidoId = Convert.ToInt32(txtCodigoPedido.Text);
                        _pedido.clienteId = Convert.ToInt32(cboClientes.SelectedValue);
                        _pedido.pedidoData = dtpDataPedido.Value;
                        _pedido.pedidoEntrega = dtpDataEntrega.Value;
                        _pedido.pedidoValor = Convert.ToDecimal(txtValorPedido.Text);
                        _pedido.pedidoStatus =cboStatusPedido.Text;
                        _pedidoBll.AlterarPedido(_pedido);
                        MessageBox.Show("Pedido alterado com sucesso", "Alterar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao localizar o pedido : " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void carregaClientes()
        {
            try
            {
                ClienteBLL _clienteBll = new ClienteBLL();
                List<Cliente> prod = _clienteBll.Get_ClienteInfo();

                cboClientes.DataSource = prod;
                cboClientes.ValueMember = "clienteId";
                cboClientes.DisplayMember = "clienteNome";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpDataEntrega_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigoPedido_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
