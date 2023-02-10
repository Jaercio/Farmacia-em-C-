using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF
{
    public partial class frmCarrega : Form
    {
        public frmCarrega()
        {
            InitializeComponent();
        }

        private void frmCarrega_Load(object sender, EventArgs e)
        {
            
            this.progressBar1.Maximum = 100;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value >= 100)
            {
                this.timer1.Enabled = false;
            }
            if(this.progressBar1.Value == 100)
            {
                this.Visible = false;
                frmLogin frm = new frmLogin();
                frm.ShowDialog();
            }
            else
                this.progressBar1.Value += 2;
           
            
            
        }
    }
}
