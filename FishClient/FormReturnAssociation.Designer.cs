namespace FishClient
{
    partial class FormReturnAssociation
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNumContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnPartyJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnGoodsAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.freight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loss = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 39);
            this.panel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(81, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "损耗统计";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fishId,
            this.code,
            this.codeNum,
            this.codeNumContract,
            this.returnPartyJ,
            this.receiveJ,
            this.speci,
            this.tons,
            this.price,
            this.money,
            this.returnGoodsAdd,
            this.freight,
            this.cost,
            this.loss});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 94);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(758, 373);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fishId
            // 
            this.fishId.HeaderText = "鱼粉ID";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // codeNum
            // 
            this.codeNum.HeaderText = "销售编号";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // codeNumContract
            // 
            this.codeNumContract.HeaderText = "销售合同编号";
            this.codeNumContract.Name = "codeNumContract";
            this.codeNumContract.ReadOnly = true;
            // 
            // returnPartyJ
            // 
            this.returnPartyJ.HeaderText = "退货方简称";
            this.returnPartyJ.Name = "returnPartyJ";
            this.returnPartyJ.ReadOnly = true;
            // 
            // receiveJ
            // 
            this.receiveJ.HeaderText = "接收方简称";
            this.receiveJ.Name = "receiveJ";
            this.receiveJ.ReadOnly = true;
            // 
            // speci
            // 
            this.speci.HeaderText = "品质规格";
            this.speci.Name = "speci";
            this.speci.ReadOnly = true;
            // 
            // tons
            // 
            this.tons.HeaderText = "吨位";
            this.tons.Name = "tons";
            this.tons.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // money
            // 
            this.money.HeaderText = "金额";
            this.money.Name = "money";
            this.money.ReadOnly = true;
            // 
            // returnGoodsAdd
            // 
            this.returnGoodsAdd.HeaderText = "退货地址";
            this.returnGoodsAdd.Name = "returnGoodsAdd";
            this.returnGoodsAdd.ReadOnly = true;
            // 
            // freight
            // 
            this.freight.HeaderText = "运费";
            this.freight.Name = "freight";
            this.freight.ReadOnly = true;
            // 
            // cost
            // 
            this.cost.HeaderText = "费用";
            this.cost.Name = "cost";
            this.cost.ReadOnly = true;
            // 
            // loss
            // 
            this.loss.HeaderText = "损耗";
            this.loss.Name = "loss";
            this.loss.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            this.设置列宽toolStripMenuItem.Click += new System.EventHandler(this.设置列宽toolStripMenuItem_Click);
            // 
            // FormReturnAssociation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 470);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormReturnAssociation";
            this.Text = "退货关联表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNumContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnPartyJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn speci;
        private System.Windows.Forms.DataGridViewTextBoxColumn tons;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn money;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnGoodsAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn freight;
        private System.Windows.Forms.DataGridViewTextBoxColumn cost;
        private System.Windows.Forms.DataGridViewTextBoxColumn loss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}