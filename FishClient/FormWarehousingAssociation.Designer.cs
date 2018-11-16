namespace FishClient
{
    partial class FormWarehousingAssociation
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
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.liWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.za = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.db = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thCodeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pileNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualitySpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNumContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(770, 34);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.fishId,
            this.liWeight,
            this.price,
            this.shipName,
            this.country,
            this.billName,
            this.proName,
            this.za,
            this.zf,
            this.sand,
            this.db,
            this.applyDate,
            this.thCodeNum,
            this.supply,
            this.saWeight,
            this.brand,
            this.pileNum,
            this.qualitySpe,
            this.tvn,
            this.hf,
            this.sf,
            this.shy,
            this.remark,
            this.codeNum,
            this.codeNumContract,
            this.jcCode,
            this.createUser});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(770, 360);
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
            // code
            // 
            this.code.HeaderText = "单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // fishId
            // 
            this.fishId.HeaderText = "鱼粉id";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            // 
            // liWeight
            // 
            this.liWeight.HeaderText = "入库吨位";
            this.liWeight.Name = "liWeight";
            this.liWeight.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "采购单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // shipName
            // 
            this.shipName.HeaderText = "船名";
            this.shipName.Name = "shipName";
            this.shipName.ReadOnly = true;
            // 
            // country
            // 
            this.country.HeaderText = "国别";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            // 
            // billName
            // 
            this.billName.HeaderText = "提单号";
            this.billName.Name = "billName";
            this.billName.ReadOnly = true;
            // 
            // proName
            // 
            this.proName.HeaderText = "品名";
            this.proName.Name = "proName";
            this.proName.ReadOnly = true;
            // 
            // za
            // 
            this.za.HeaderText = "组胺";
            this.za.Name = "za";
            this.za.ReadOnly = true;
            // 
            // zf
            // 
            this.zf.HeaderText = "脂肪";
            this.zf.Name = "zf";
            this.zf.ReadOnly = true;
            // 
            // sand
            // 
            this.sand.HeaderText = "沙";
            this.sand.Name = "sand";
            this.sand.ReadOnly = true;
            // 
            // db
            // 
            this.db.HeaderText = "蛋白";
            this.db.Name = "db";
            this.db.ReadOnly = true;
            // 
            // applyDate
            // 
            this.applyDate.HeaderText = "申请日期";
            this.applyDate.Name = "applyDate";
            this.applyDate.ReadOnly = true;
            // 
            // thCodeNum
            // 
            this.thCodeNum.HeaderText = "退货单号";
            this.thCodeNum.Name = "thCodeNum";
            this.thCodeNum.ReadOnly = true;
            // 
            // supply
            // 
            this.supply.HeaderText = "供方";
            this.supply.Name = "supply";
            this.supply.ReadOnly = true;
            // 
            // saWeight
            // 
            this.saWeight.HeaderText = "采购吨位";
            this.saWeight.Name = "saWeight";
            this.saWeight.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.HeaderText = "品牌";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // pileNum
            // 
            this.pileNum.HeaderText = "桩角号";
            this.pileNum.Name = "pileNum";
            this.pileNum.ReadOnly = true;
            // 
            // qualitySpe
            // 
            this.qualitySpe.HeaderText = "品质规格";
            this.qualitySpe.Name = "qualitySpe";
            this.qualitySpe.ReadOnly = true;
            // 
            // tvn
            // 
            this.tvn.HeaderText = "TVN";
            this.tvn.Name = "tvn";
            this.tvn.ReadOnly = true;
            // 
            // hf
            // 
            this.hf.HeaderText = "灰分";
            this.hf.Name = "hf";
            this.hf.ReadOnly = true;
            // 
            // sf
            // 
            this.sf.HeaderText = "水分";
            this.sf.Name = "sf";
            this.sf.ReadOnly = true;
            // 
            // shy
            // 
            this.shy.HeaderText = "沙和盐";
            this.shy.Name = "shy";
            this.shy.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // codeNum
            // 
            this.codeNum.HeaderText = "采购单号";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // codeNumContract
            // 
            this.codeNumContract.HeaderText = "采购合同单号";
            this.codeNumContract.Name = "codeNumContract";
            this.codeNumContract.ReadOnly = true;
            // 
            // jcCode
            // 
            this.jcCode.HeaderText = "进仓单号";
            this.jcCode.Name = "jcCode";
            this.jcCode.ReadOnly = true;
            // 
            // createUser
            // 
            this.createUser.HeaderText = "所属人";
            this.createUser.Name = "createUser";
            this.createUser.ReadOnly = true;
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
            // FormWarehousingAssociation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 452);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormWarehousingAssociation";
            this.Text = "入库关联表";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn liWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn billName;
        private System.Windows.Forms.DataGridViewTextBoxColumn proName;
        private System.Windows.Forms.DataGridViewTextBoxColumn za;
        private System.Windows.Forms.DataGridViewTextBoxColumn zf;
        private System.Windows.Forms.DataGridViewTextBoxColumn sand;
        private System.Windows.Forms.DataGridViewTextBoxColumn db;
        private System.Windows.Forms.DataGridViewTextBoxColumn applyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn thCodeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn supply;
        private System.Windows.Forms.DataGridViewTextBoxColumn saWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn pileNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualitySpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hf;
        private System.Windows.Forms.DataGridViewTextBoxColumn sf;
        private System.Windows.Forms.DataGridViewTextBoxColumn shy;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNumContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn createUser;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}