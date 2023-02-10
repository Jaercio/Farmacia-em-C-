namespace WF
{
    partial class frmPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidos));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocalizarCliente = new System.Windows.Forms.Button();
            this.grpCliente = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEndereco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPizzas = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.btnIncluirPizza = new System.Windows.Forms.Button();
            this.btnExcluirItem = new System.Windows.Forms.Button();
            this.btnGravarPedido = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.nupQuantidade = new System.Windows.Forms.NumericUpDown();
            this.txtTelefoneCliente = new System.Windows.Forms.MaskedTextBox();
            this.grpCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupQuantidade)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(197, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Telefone";
            // 
            // btnLocalizarCliente
            // 
            this.btnLocalizarCliente.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizarCliente.Image")));
            this.btnLocalizarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalizarCliente.Location = new System.Drawing.Point(340, 40);
            this.btnLocalizarCliente.Name = "btnLocalizarCliente";
            this.btnLocalizarCliente.Size = new System.Drawing.Size(30, 28);
            this.btnLocalizarCliente.TabIndex = 15;
            this.btnLocalizarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocalizarCliente.UseVisualStyleBackColor = true;
            this.btnLocalizarCliente.Click += new System.EventHandler(this.btnLocalizarCliente_Click);
            // 
            // grpCliente
            // 
            this.grpCliente.Controls.Add(this.txtEmail);
            this.grpCliente.Controls.Add(this.label5);
            this.grpCliente.Controls.Add(this.txtEndereco);
            this.grpCliente.Controls.Add(this.label3);
            this.grpCliente.Controls.Add(this.txtNome);
            this.grpCliente.Controls.Add(this.label2);
            this.grpCliente.Enabled = false;
            this.grpCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCliente.Location = new System.Drawing.Point(40, 77);
            this.grpCliente.Name = "grpCliente";
            this.grpCliente.Size = new System.Drawing.Size(497, 140);
            this.grpCliente.TabIndex = 16;
            this.grpCliente.TabStop = false;
            this.grpCliente.Text = "Cliente";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(97, 99);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(355, 26);
            this.txtEmail.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Email";
            // 
            // txtEndereco
            // 
            this.txtEndereco.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndereco.Location = new System.Drawing.Point(97, 61);
            this.txtEndereco.Name = "txtEndereco";
            this.txtEndereco.Size = new System.Drawing.Size(355, 26);
            this.txtEndereco.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Endereço";
            // 
            // txtNome
            // 
            this.txtNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(97, 27);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(355, 26);
            this.txtNome.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Nome";
            // 
            // cboPizzas
            // 
            this.cboPizzas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPizzas.FormattingEnabled = true;
            this.cboPizzas.Location = new System.Drawing.Point(80, 240);
            this.cboPizzas.Name = "cboPizzas";
            this.cboPizzas.Size = new System.Drawing.Size(305, 28);
            this.cboPizzas.TabIndex = 17;
            this.cboPizzas.SelectedIndexChanged += new System.EventHandler(this.cboPizzas_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-1, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Remédio";
            // 
            // dgvItem
            // 
            this.dgvItem.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Location = new System.Drawing.Point(40, 285);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.RowHeadersWidth = 51;
            this.dgvItem.Size = new System.Drawing.Size(497, 163);
            this.dgvItem.TabIndex = 19;
            this.dgvItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellContentClick);
            // 
            // btnIncluirPizza
            // 
            this.btnIncluirPizza.BackColor = System.Drawing.Color.White;
            this.btnIncluirPizza.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncluirPizza.Image = ((System.Drawing.Image)(resources.GetObject("btnIncluirPizza.Image")));
            this.btnIncluirPizza.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIncluirPizza.Location = new System.Drawing.Point(460, 233);
            this.btnIncluirPizza.Name = "btnIncluirPizza";
            this.btnIncluirPizza.Size = new System.Drawing.Size(77, 36);
            this.btnIncluirPizza.TabIndex = 20;
            this.btnIncluirPizza.Text = "     Incluir";
            this.btnIncluirPizza.UseVisualStyleBackColor = false;
            this.btnIncluirPizza.Click += new System.EventHandler(this.btnIncluirPizza_Click);
            // 
            // btnExcluirItem
            // 
            this.btnExcluirItem.BackColor = System.Drawing.Color.White;
            this.btnExcluirItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcluirItem.Image = ((System.Drawing.Image)(resources.GetObject("btnExcluirItem.Image")));
            this.btnExcluirItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcluirItem.Location = new System.Drawing.Point(40, 454);
            this.btnExcluirItem.Name = "btnExcluirItem";
            this.btnExcluirItem.Size = new System.Drawing.Size(82, 37);
            this.btnExcluirItem.TabIndex = 21;
            this.btnExcluirItem.Text = "Excluir";
            this.btnExcluirItem.UseVisualStyleBackColor = false;
            this.btnExcluirItem.Click += new System.EventHandler(this.btnExcluirItem_Click);
            // 
            // btnGravarPedido
            // 
            this.btnGravarPedido.BackColor = System.Drawing.Color.White;
            this.btnGravarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGravarPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnGravarPedido.Image")));
            this.btnGravarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGravarPedido.Location = new System.Drawing.Point(441, 454);
            this.btnGravarPedido.Name = "btnGravarPedido";
            this.btnGravarPedido.Size = new System.Drawing.Size(96, 37);
            this.btnGravarPedido.TabIndex = 21;
            this.btnGravarPedido.Text = "   Gravar";
            this.btnGravarPedido.UseVisualStyleBackColor = false;
            this.btnGravarPedido.Click += new System.EventHandler(this.btnGravarPedido_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(306, 461);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTotal.Size = new System.Drawing.Size(100, 29);
            this.txtTotal.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(259, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 24);
            this.label7.TabIndex = 23;
            this.label7.Text = "Total";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.White;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(137, 454);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(82, 37);
            this.btnFechar.TabIndex = 24;
            this.btnFechar.Text = "        Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // nupQuantidade
            // 
            this.nupQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nupQuantidade.Location = new System.Drawing.Point(404, 242);
            this.nupQuantidade.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nupQuantidade.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupQuantidade.Name = "nupQuantidade";
            this.nupQuantidade.Size = new System.Drawing.Size(40, 26);
            this.nupQuantidade.TabIndex = 25;
            this.nupQuantidade.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtTelefoneCliente
            // 
            this.txtTelefoneCliente.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTelefoneCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefoneCliente.Location = new System.Drawing.Point(199, 41);
            this.txtTelefoneCliente.Mask = "(99) 0000-0000";
            this.txtTelefoneCliente.Name = "txtTelefoneCliente";
            this.txtTelefoneCliente.Size = new System.Drawing.Size(142, 30);
            this.txtTelefoneCliente.TabIndex = 26;
            this.txtTelefoneCliente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // frmPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(570, 502);
            this.Controls.Add(this.txtTelefoneCliente);
            this.Controls.Add(this.nupQuantidade);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnGravarPedido);
            this.Controls.Add(this.btnExcluirItem);
            this.Controls.Add(this.btnIncluirPizza);
            this.Controls.Add(this.dgvItem);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPizzas);
            this.Controls.Add(this.grpCliente);
            this.Controls.Add(this.btnLocalizarCliente);
            this.Controls.Add(this.label1);
            this.Name = "frmPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PEDIDOS";
            this.Load += new System.EventHandler(this.frmPedidos_Load);
            this.grpCliente.ResumeLayout(false);
            this.grpCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupQuantidade)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocalizarCliente;
        private System.Windows.Forms.GroupBox grpCliente;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEndereco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPizzas;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Button btnIncluirPizza;
        private System.Windows.Forms.Button btnExcluirItem;
        private System.Windows.Forms.Button btnGravarPedido;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.NumericUpDown nupQuantidade;
        private System.Windows.Forms.MaskedTextBox txtTelefoneCliente;
    }
}