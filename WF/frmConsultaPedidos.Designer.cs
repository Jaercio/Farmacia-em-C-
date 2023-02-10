namespace WF
{
    partial class frmConsultaPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaPedidos));
            this.btnLocalizar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvItensPedido = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnAlterarPedido = new System.Windows.Forms.Button();
            this.txtTelefoneCliente = new System.Windows.Forms.MaskedTextBox();
            this.btnAlterarItem = new System.Windows.Forms.Button();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.btn_rela = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLocalizar
            // 
            this.btnLocalizar.Image = ((System.Drawing.Image)(resources.GetObject("btnLocalizar.Image")));
            this.btnLocalizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLocalizar.Location = new System.Drawing.Point(292, 57);
            this.btnLocalizar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLocalizar.Name = "btnLocalizar";
            this.btnLocalizar.Size = new System.Drawing.Size(40, 34);
            this.btnLocalizar.TabIndex = 18;
            this.btnLocalizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLocalizar.UseVisualStyleBackColor = true;
            this.btnLocalizar.Click += new System.EventHandler(this.btnLocalizar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Telefone";
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(32, 132);
            this.dgvPedidos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.RowHeadersWidth = 51;
            this.dgvPedidos.Size = new System.Drawing.Size(733, 230);
            this.dgvPedidos.TabIndex = 19;
            this.dgvPedidos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellClick);
            this.dgvPedidos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPedidos_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "PEDIDOS";
            // 
            // dgvItensPedido
            // 
            this.dgvItensPedido.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvItensPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItensPedido.Location = new System.Drawing.Point(32, 415);
            this.dgvItensPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvItensPedido.Name = "dgvItensPedido";
            this.dgvItensPedido.RowHeadersWidth = 51;
            this.dgvItensPedido.Size = new System.Drawing.Size(733, 185);
            this.dgvItensPedido.TabIndex = 21;
            this.dgvItensPedido.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItensPedido_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 395);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "ITENS DO PEDIDO";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.White;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.Image = ((System.Drawing.Image)(resources.GetObject("btnFechar.Image")));
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFechar.Location = new System.Drawing.Point(601, 607);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(132, 36);
            this.btnFechar.TabIndex = 23;
            this.btnFechar.Text = "        Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnAlterarPedido
            // 
            this.btnAlterarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarPedido.Image")));
            this.btnAlterarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterarPedido.Location = new System.Drawing.Point(255, 369);
            this.btnAlterarPedido.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAlterarPedido.Name = "btnAlterarPedido";
            this.btnAlterarPedido.Size = new System.Drawing.Size(183, 36);
            this.btnAlterarPedido.TabIndex = 36;
            this.btnAlterarPedido.Text = "   Alterar Pedido";
            this.btnAlterarPedido.UseVisualStyleBackColor = true;
            this.btnAlterarPedido.Click += new System.EventHandler(this.btnAlterarPedido_Click);
            // 
            // txtTelefoneCliente
            // 
            this.txtTelefoneCliente.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTelefoneCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelefoneCliente.Location = new System.Drawing.Point(104, 58);
            this.txtTelefoneCliente.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefoneCliente.Mask = "(99) 0000-0000";
            this.txtTelefoneCliente.Name = "txtTelefoneCliente";
            this.txtTelefoneCliente.Size = new System.Drawing.Size(188, 30);
            this.txtTelefoneCliente.TabIndex = 37;
            this.txtTelefoneCliente.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // btnAlterarItem
            // 
            this.btnAlterarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAlterarItem.Image")));
            this.btnAlterarItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlterarItem.Location = new System.Drawing.Point(255, 607);
            this.btnAlterarItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAlterarItem.Name = "btnAlterarItem";
            this.btnAlterarItem.Size = new System.Drawing.Size(183, 36);
            this.btnAlterarItem.TabIndex = 36;
            this.btnAlterarItem.Text = "   Alterar Item";
            this.btnAlterarItem.UseVisualStyleBackColor = true;
            this.btnAlterarItem.Click += new System.EventHandler(this.btnAlterarItem_Click);
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCliente.ForeColor = System.Drawing.Color.Blue;
            this.lblNomeCliente.Location = new System.Drawing.Point(128, 105);
            this.lblNomeCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(0, 20);
            this.lblNomeCliente.TabIndex = 38;
            // 
            // btn_rela
            // 
            this.btn_rela.Location = new System.Drawing.Point(513, 49);
            this.btn_rela.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_rela.Name = "btn_rela";
            this.btn_rela.Size = new System.Drawing.Size(160, 50);
            this.btn_rela.TabIndex = 39;
            this.btn_rela.Text = "IMPRIMIR RELATÓRIO";
            this.btn_rela.UseVisualStyleBackColor = true;
            this.btn_rela.Click += new System.EventHandler(this.btn_rela_Click);
            // 
            // frmConsultaPedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(807, 657);
            this.Controls.Add(this.btn_rela);
            this.Controls.Add(this.lblNomeCliente);
            this.Controls.Add(this.txtTelefoneCliente);
            this.Controls.Add(this.btnAlterarItem);
            this.Controls.Add(this.btnAlterarPedido);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvItensPedido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnLocalizar);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmConsultaPedidos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CONSULTA - PEDIDOS";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItensPedido)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLocalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvItensPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnAlterarPedido;
        private System.Windows.Forms.MaskedTextBox txtTelefoneCliente;
        private System.Windows.Forms.Button btnAlterarItem;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.Button btn_rela;
    }
}