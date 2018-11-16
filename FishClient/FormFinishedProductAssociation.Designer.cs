namespace FishClient
{
    partial class FormFinishedProductAssociation
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
            this.CkCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualitySpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.histamine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.las = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.das = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zjh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 27);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CkCode,
            this.CODE,
            this.plCode,
            this.fishId,
            this.date,
            this.country,
            this.brand,
            this.price,
            this.qualitySpe,
            this.goods,
            this.tons,
            this.protein,
            this.tvn,
            this.salt,
            this.FFA,
            this.acid,
            this.ash,
            this.histamine,
            this.las,
            this.das,
            this.remark,
            this.zf,
            this.billName,
            this.zjh,
            this.shipname,
            this.id});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(622, 244);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // CkCode
            // 
            this.CkCode.HeaderText = "出库合同号";
            this.CkCode.Name = "CkCode";
            this.CkCode.ReadOnly = true;
            // 
            // CODE
            // 
            this.CODE.HeaderText = "编号";
            this.CODE.Name = "CODE";
            this.CODE.ReadOnly = true;
            // 
            // plCode
            // 
            this.plCode.HeaderText = "配料单号";
            this.plCode.Name = "plCode";
            this.plCode.ReadOnly = true;
            // 
            // fishId
            // 
            this.fishId.HeaderText = "鱼粉ID";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            // 
            // date
            // 
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // country
            // 
            this.country.HeaderText = "国别";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.HeaderText = "品牌";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // qualitySpe
            // 
            this.qualitySpe.HeaderText = "品质规格";
            this.qualitySpe.Name = "qualitySpe";
            this.qualitySpe.ReadOnly = true;
            // 
            // goods
            // 
            this.goods.HeaderText = "产品名称";
            this.goods.Name = "goods";
            this.goods.ReadOnly = true;
            // 
            // tons
            // 
            this.tons.HeaderText = "重量";
            this.tons.Name = "tons";
            this.tons.ReadOnly = true;
            // 
            // protein
            // 
            this.protein.HeaderText = "蛋白";
            this.protein.Name = "protein";
            this.protein.ReadOnly = true;
            // 
            // tvn
            // 
            this.tvn.HeaderText = "Tvn";
            this.tvn.Name = "tvn";
            this.tvn.ReadOnly = true;
            // 
            // salt
            // 
            this.salt.HeaderText = "盐分";
            this.salt.Name = "salt";
            this.salt.ReadOnly = true;
            // 
            // FFA
            // 
            this.FFA.HeaderText = "FFA";
            this.FFA.Name = "FFA";
            this.FFA.ReadOnly = true;
            // 
            // acid
            // 
            this.acid.HeaderText = "酸价";
            this.acid.Name = "acid";
            this.acid.ReadOnly = true;
            // 
            // ash
            // 
            this.ash.HeaderText = "灰份";
            this.ash.Name = "ash";
            this.ash.ReadOnly = true;
            // 
            // histamine
            // 
            this.histamine.HeaderText = "组胺";
            this.histamine.Name = "histamine";
            this.histamine.ReadOnly = true;
            // 
            // las
            // 
            this.las.HeaderText = "蛋氨酸";
            this.las.Name = "las";
            this.las.ReadOnly = true;
            // 
            // das
            // 
            this.das.HeaderText = "赖氨酸";
            this.das.Name = "das";
            this.das.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // zf
            // 
            this.zf.HeaderText = "脂肪";
            this.zf.Name = "zf";
            this.zf.ReadOnly = true;
            // 
            // billName
            // 
            this.billName.HeaderText = "提单号";
            this.billName.Name = "billName";
            this.billName.ReadOnly = true;
            // 
            // zjh
            // 
            this.zjh.HeaderText = "桩角号";
            this.zjh.Name = "zjh";
            this.zjh.ReadOnly = true;
            // 
            // shipname
            // 
            this.shipname.HeaderText = "船名";
            this.shipname.Name = "shipname";
            this.shipname.ReadOnly = true;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 设置列宽ToolStripMenuItem
            // 
            this.设置列宽ToolStripMenuItem.Name = "设置列宽ToolStripMenuItem";
            this.设置列宽ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽ToolStripMenuItem.Text = "设置列宽";
            this.设置列宽ToolStripMenuItem.Click += new System.EventHandler(this.设置列宽ToolStripMenuItem_Click);
            // 
            // FormFinishedProductAssociation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 329);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormFinishedProductAssociation";
            this.Text = "成品出库关联表";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn CkCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn plCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualitySpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn tons;
        private System.Windows.Forms.DataGridViewTextBoxColumn protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salt;
        private System.Windows.Forms.DataGridViewTextBoxColumn FFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn acid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ash;
        private System.Windows.Forms.DataGridViewTextBoxColumn histamine;
        private System.Windows.Forms.DataGridViewTextBoxColumn las;
        private System.Windows.Forms.DataGridViewTextBoxColumn das;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn zf;
        private System.Windows.Forms.DataGridViewTextBoxColumn billName;
        private System.Windows.Forms.DataGridViewTextBoxColumn zjh;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipname;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}