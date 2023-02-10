using System;
using System.Windows.Forms;
using Model;
using BLL;

namespace WF
{
    public partial class frmClientesCadastrados : Form
    {
        public frmClientesCadastrados()
        {
            InitializeComponent();
        }

        ClienteBLL _clienteBll;

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmClientesCadastrados_Load(object sender, EventArgs e)
        {
            _clienteBll = new ClienteBLL();
            dgvClientes.DataSource = _clienteBll.Get_ClienteInfo();
            formataGridView();
        }
        private void formataGridView()
        {
            var _with1 = dgvClientes;
            _with1.AutoGenerateColumns = false;
            _with1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            _with1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            _with1.RowsDefaultCellStyle.BackColor = System.Drawing.Color.White;
            _with1.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.Aquamarine;
            _with1.Columns[0].HeaderText = "Código";
            _with1.Columns[1].HeaderText = "Nome";
            _with1.Columns[2].HeaderText = "Endereço";
            _with1.Columns[3].HeaderText = "Telefone";
            _with1.Columns[4].HeaderText = "Email";
            _with1.Columns[0].Width = 70;
            _with1.Columns[1].Width = 120;
            _with1.Columns[2].Width = 120;
            _with1.Columns[3].Width = 80;
            _with1.Columns[4].Width = 120;
            _with1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _with1.MultiSelect = false;
            _with1.DefaultCellStyle.NullValue = " - ";
            _with1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            _with1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            _with1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvClientes.RowCount - 1;
            if (e.RowIndex != -1 & e.RowIndex <= i)
            {
                int codigo = Convert.ToInt32(dgvClientes.Rows[e.RowIndex].Cells[0].Value);
                string telefone = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                Publico.telefoneDoCliente = telefone;
                Publico.codigoDoCliente = codigo;
                this.Close();
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
