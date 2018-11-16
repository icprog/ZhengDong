namespace FishClient
{
    partial class FormOutboundAssociation
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FishMealId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pileNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNumContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waseHouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speci = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pageNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ware = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 25);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.FishMealId,
            this.seNumber,
            this.code,
            this.unit,
            this.type,
            this.shipName,
            this.weight,
            this.pileNum,
            this.codeNum,
            this.codeNumContract,
            this.date,
            this.waseHouse,
            this.speci,
            this.billName,
            this.pageNum,
            this.remark,
            this.notice,
            this.ware,
            this.receive,
            this.Country,
            this.Brands});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 80);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(748, 312);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // FishMealId
            // 
            this.FishMealId.HeaderText = "鱼粉Id";
            this.FishMealId.Name = "FishMealId";
            this.FishMealId.ReadOnly = true;
            // 
            // seNumber
            // 
            this.seNumber.HeaderText = "序号";
            this.seNumber.Name = "seNumber";
            this.seNumber.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // unit
            // 
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            // 
            // type
            // 
            this.type.HeaderText = "种类";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // shipName
            // 
            this.shipName.HeaderText = "船名";
            this.shipName.Name = "shipName";
            this.shipName.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.HeaderText = "重量";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            // 
            // pileNum
            // 
            this.pileNum.HeaderText = "提单号";
            this.pileNum.Name = "pileNum";
            this.pileNum.ReadOnly = true;
            // 
            // codeNum
            // 
            this.codeNum.HeaderText = "销售编号";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // codeNumContract
            // 
            this.codeNumContract.HeaderText = "销售合同号";
            this.codeNumContract.Name = "codeNumContract";
            this.codeNumContract.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "签发时间";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // waseHouse
            // 
            this.waseHouse.HeaderText = "仓库";
            this.waseHouse.Name = "waseHouse";
            this.waseHouse.ReadOnly = true;
            // 
            // speci
            // 
            this.speci.HeaderText = "规格";
            this.speci.Name = "speci";
            this.speci.ReadOnly = true;
            // 
            // billName
            // 
            this.billName.HeaderText = "提单号";
            this.billName.Name = "billName";
            this.billName.ReadOnly = true;
            // 
            // pageNum
            // 
            this.pageNum.HeaderText = "包数";
            this.pageNum.Name = "pageNum";
            this.pageNum.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // notice
            // 
            this.notice.HeaderText = "发货须知";
            this.notice.Name = "notice";
            this.notice.ReadOnly = true;
            // 
            // ware
            // 
            this.ware.HeaderText = "仓储费";
            this.ware.Name = "ware";
            this.ware.ReadOnly = true;
            // 
            // receive
            // 
            this.receive.HeaderText = "接收人";
            this.receive.Name = "receive";
            this.receive.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.HeaderText = "国别";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Brands
            // 
            this.Brands.HeaderText = "品牌";
            this.Brands.Name = "Brands";
            this.Brands.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            // 
            // FormOutboundAssociation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormOutboundAssociation";
            this.Text = "出库关联表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FishMealId;
        private System.Windows.Forms.DataGridViewTextBoxColumn seNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn pileNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNumContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn waseHouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn speci;
        private System.Windows.Forms.DataGridViewTextBoxColumn billName;
        private System.Windows.Forms.DataGridViewTextBoxColumn pageNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn notice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ware;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brands;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}