namespace FishClient
{
    partial class FormPurchaseAppFishInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceMY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EexchangeRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conProtein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conTVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conFFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conZF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conSF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conSHY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conSJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conHF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conLAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conDAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delPort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fastShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastShipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specifications = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.choise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.priceMY,
            this.EexchangeRate,
            this.fishId,
            this.country,
            this.brand,
            this.shipName,
            this.billName,
            this.price,
            this.conProtein,
            this.conTVN,
            this.conZA,
            this.conFFA,
            this.conZF,
            this.conSF,
            this.conSHY,
            this.conS,
            this.conSJ,
            this.conHF,
            this.conLAS,
            this.conDAS,
            this.num,
            this.Money,
            this.delPort,
            this.fastShipDate,
            this.lastShipDate,
            this.specifications,
            this.choise});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1240, 378);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "采购编号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // priceMY
            // 
            this.priceMY.HeaderText = "priceMY";
            this.priceMY.Name = "priceMY";
            this.priceMY.ReadOnly = true;
            this.priceMY.Visible = false;
            // 
            // EexchangeRate
            // 
            this.EexchangeRate.HeaderText = "EexchangeRate";
            this.EexchangeRate.Name = "EexchangeRate";
            this.EexchangeRate.ReadOnly = true;
            this.EexchangeRate.Visible = false;
            // 
            // fishId
            // 
            this.fishId.DataPropertyName = "fishId";
            this.fishId.HeaderText = "鱼粉ID";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            // 
            // country
            // 
            this.country.DataPropertyName = "country";
            this.country.HeaderText = "国别";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            this.country.Width = 80;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "品牌";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            this.brand.Width = 80;
            // 
            // shipName
            // 
            this.shipName.DataPropertyName = "shipName";
            this.shipName.HeaderText = "船名";
            this.shipName.Name = "shipName";
            this.shipName.ReadOnly = true;
            // 
            // billName
            // 
            this.billName.DataPropertyName = "billName";
            this.billName.HeaderText = "提单号";
            this.billName.Name = "billName";
            this.billName.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // conProtein
            // 
            this.conProtein.DataPropertyName = "conProtein";
            this.conProtein.HeaderText = "蛋白";
            this.conProtein.Name = "conProtein";
            this.conProtein.ReadOnly = true;
            this.conProtein.Visible = false;
            // 
            // conTVN
            // 
            this.conTVN.DataPropertyName = "conTVN";
            this.conTVN.HeaderText = "TVN";
            this.conTVN.Name = "conTVN";
            this.conTVN.ReadOnly = true;
            this.conTVN.Visible = false;
            // 
            // conZA
            // 
            this.conZA.DataPropertyName = "conZA";
            this.conZA.HeaderText = "组胺";
            this.conZA.Name = "conZA";
            this.conZA.ReadOnly = true;
            this.conZA.Visible = false;
            // 
            // conFFA
            // 
            this.conFFA.DataPropertyName = "conFFA";
            this.conFFA.HeaderText = "FFA";
            this.conFFA.Name = "conFFA";
            this.conFFA.ReadOnly = true;
            this.conFFA.Visible = false;
            // 
            // conZF
            // 
            this.conZF.DataPropertyName = "conZF";
            this.conZF.HeaderText = "脂肪";
            this.conZF.Name = "conZF";
            this.conZF.ReadOnly = true;
            this.conZF.Visible = false;
            // 
            // conSF
            // 
            this.conSF.DataPropertyName = "conSF";
            this.conSF.HeaderText = "水分";
            this.conSF.Name = "conSF";
            this.conSF.ReadOnly = true;
            this.conSF.Visible = false;
            // 
            // conSHY
            // 
            this.conSHY.DataPropertyName = "conSHY";
            this.conSHY.HeaderText = "沙和盐";
            this.conSHY.Name = "conSHY";
            this.conSHY.ReadOnly = true;
            this.conSHY.Visible = false;
            // 
            // conS
            // 
            this.conS.DataPropertyName = "conS";
            this.conS.HeaderText = "沙";
            this.conS.Name = "conS";
            this.conS.ReadOnly = true;
            this.conS.Visible = false;
            // 
            // conSJ
            // 
            this.conSJ.DataPropertyName = "conSJ";
            this.conSJ.HeaderText = "酸价";
            this.conSJ.Name = "conSJ";
            this.conSJ.ReadOnly = true;
            this.conSJ.Visible = false;
            // 
            // conHF
            // 
            this.conHF.DataPropertyName = "conHF";
            this.conHF.HeaderText = "灰份";
            this.conHF.Name = "conHF";
            this.conHF.ReadOnly = true;
            this.conHF.Visible = false;
            // 
            // conLAS
            // 
            this.conLAS.DataPropertyName = "conLAS";
            this.conLAS.HeaderText = "赖氨酸";
            this.conLAS.Name = "conLAS";
            this.conLAS.ReadOnly = true;
            this.conLAS.Visible = false;
            // 
            // conDAS
            // 
            this.conDAS.DataPropertyName = "conDAS";
            this.conDAS.HeaderText = "蛋氨酸";
            this.conDAS.Name = "conDAS";
            this.conDAS.ReadOnly = true;
            this.conDAS.Visible = false;
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "重量";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // Money
            // 
            this.Money.DataPropertyName = "Money";
            this.Money.HeaderText = "金额";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            // 
            // delPort
            // 
            this.delPort.DataPropertyName = "delPort";
            this.delPort.HeaderText = "交货港口";
            this.delPort.Name = "delPort";
            this.delPort.ReadOnly = true;
            this.delPort.Visible = false;
            // 
            // fastShipDate
            // 
            this.fastShipDate.DataPropertyName = "fastShipDate";
            this.fastShipDate.HeaderText = "最快船期";
            this.fastShipDate.Name = "fastShipDate";
            this.fastShipDate.ReadOnly = true;
            // 
            // lastShipDate
            // 
            this.lastShipDate.DataPropertyName = "lastShipDate";
            this.lastShipDate.HeaderText = "最慢船期";
            this.lastShipDate.Name = "lastShipDate";
            this.lastShipDate.ReadOnly = true;
            // 
            // specifications
            // 
            this.specifications.DataPropertyName = "specifications";
            this.specifications.HeaderText = "品质规格";
            this.specifications.Name = "specifications";
            this.specifications.ReadOnly = true;
            this.specifications.Visible = false;
            // 
            // choise
            // 
            this.choise.HeaderText = "鱼粉来源";
            this.choise.Name = "choise";
            this.choise.ReadOnly = true;
            this.choise.Visible = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 55);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1240, 425);
            this.splitContainer1.SplitterDistance = 43;
            this.splitContainer1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "总重量：";
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
            // FormPurchaseAppFishInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 483);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormPurchaseAppFishInfo";
            this.Text = "订单拆分明细";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System . Windows . Forms . DataGridView dataGridView1;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceMY;
        private System.Windows.Forms.DataGridViewTextBoxColumn EexchangeRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn billName;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn conProtein;
        private System.Windows.Forms.DataGridViewTextBoxColumn conTVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn conZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn conFFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn conZF;
        private System.Windows.Forms.DataGridViewTextBoxColumn conSF;
        private System.Windows.Forms.DataGridViewTextBoxColumn conSHY;
        private System.Windows.Forms.DataGridViewTextBoxColumn conS;
        private System.Windows.Forms.DataGridViewTextBoxColumn conSJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn conHF;
        private System.Windows.Forms.DataGridViewTextBoxColumn conLAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn conDAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.DataGridViewTextBoxColumn delPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn fastShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastShipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn specifications;
        private System.Windows.Forms.DataGridViewTextBoxColumn choise;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}