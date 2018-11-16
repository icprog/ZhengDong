namespace FishClient
{
    partial class FormPurchaseContractTable
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
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNumContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bondPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quaSpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conutry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dollar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.height = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceMY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conProtein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conTVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conFFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conSHY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conHF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conLAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conDAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.panel1.Size = new System.Drawing.Size(873, 36);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.codeNum,
            this.codeNumContract,
            this.supplier,
            this.supplierUser,
            this.signDate,
            this.signAdd,
            this.bondPro,
            this.quaSpe,
            this.conutry,
            this.UnitPrice,
            this.Dollar,
            this.height,
            this.price,
            this.priceMY,
            this.shipDate,
            this.deliveryDate,
            this.deliveryAdd,
            this.conProtein,
            this.conTVN,
            this.conZA,
            this.conFFA,
            this.conSHY,
            this.conHF,
            this.conLAS,
            this.conDAS,
            this.brands,
            this.money,
            this.num});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 91);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(873, 363);
            this.dataGridView1.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // codeNum
            // 
            this.codeNum.HeaderText = "采购编号";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // codeNumContract
            // 
            this.codeNumContract.HeaderText = "采购合同编号";
            this.codeNumContract.Name = "codeNumContract";
            this.codeNumContract.ReadOnly = true;
            // 
            // supplier
            // 
            this.supplier.HeaderText = "供方";
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            // 
            // supplierUser
            // 
            this.supplierUser.HeaderText = "供方联系人";
            this.supplierUser.Name = "supplierUser";
            this.supplierUser.ReadOnly = true;
            // 
            // signDate
            // 
            this.signDate.HeaderText = "签约日期";
            this.signDate.Name = "signDate";
            this.signDate.ReadOnly = true;
            // 
            // signAdd
            // 
            this.signAdd.HeaderText = "签约地点";
            this.signAdd.Name = "signAdd";
            this.signAdd.ReadOnly = true;
            // 
            // bondPro
            // 
            this.bondPro.HeaderText = "保证金";
            this.bondPro.Name = "bondPro";
            this.bondPro.ReadOnly = true;
            // 
            // quaSpe
            // 
            this.quaSpe.HeaderText = "开证单位";
            this.quaSpe.Name = "quaSpe";
            this.quaSpe.ReadOnly = true;
            // 
            // conutry
            // 
            this.conutry.HeaderText = "开证联系人";
            this.conutry.Name = "conutry";
            this.conutry.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "单价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // Dollar
            // 
            this.Dollar.HeaderText = "美元单价";
            this.Dollar.Name = "Dollar";
            this.Dollar.ReadOnly = true;
            // 
            // height
            // 
            this.height.HeaderText = "总重量";
            this.height.Name = "height";
            this.height.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "总金额";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Visible = false;
            // 
            // priceMY
            // 
            this.priceMY.HeaderText = "美元总金额";
            this.priceMY.Name = "priceMY";
            this.priceMY.ReadOnly = true;
            // 
            // shipDate
            // 
            this.shipDate.HeaderText = "裝船时间";
            this.shipDate.Name = "shipDate";
            this.shipDate.ReadOnly = true;
            // 
            // deliveryDate
            // 
            this.deliveryDate.HeaderText = "交货时间";
            this.deliveryDate.Name = "deliveryDate";
            this.deliveryDate.ReadOnly = true;
            // 
            // deliveryAdd
            // 
            this.deliveryAdd.HeaderText = "交货地点";
            this.deliveryAdd.Name = "deliveryAdd";
            this.deliveryAdd.ReadOnly = true;
            // 
            // conProtein
            // 
            this.conProtein.HeaderText = "合同蛋白";
            this.conProtein.Name = "conProtein";
            this.conProtein.ReadOnly = true;
            // 
            // conTVN
            // 
            this.conTVN.HeaderText = "合同TVN";
            this.conTVN.Name = "conTVN";
            this.conTVN.ReadOnly = true;
            // 
            // conZA
            // 
            this.conZA.HeaderText = "合同组胺";
            this.conZA.Name = "conZA";
            this.conZA.ReadOnly = true;
            // 
            // conFFA
            // 
            this.conFFA.HeaderText = "合同FFA";
            this.conFFA.Name = "conFFA";
            this.conFFA.ReadOnly = true;
            // 
            // conSHY
            // 
            this.conSHY.HeaderText = "合同沙和盐";
            this.conSHY.Name = "conSHY";
            this.conSHY.ReadOnly = true;
            // 
            // conHF
            // 
            this.conHF.HeaderText = "合同灰分";
            this.conHF.Name = "conHF";
            this.conHF.ReadOnly = true;
            // 
            // conLAS
            // 
            this.conLAS.HeaderText = "合同赖氨酸";
            this.conLAS.Name = "conLAS";
            this.conLAS.ReadOnly = true;
            // 
            // conDAS
            // 
            this.conDAS.HeaderText = "合同蛋氨酸";
            this.conDAS.Name = "conDAS";
            this.conDAS.ReadOnly = true;
            // 
            // brands
            // 
            this.brands.HeaderText = "到货品质规格";
            this.brands.Name = "brands";
            this.brands.ReadOnly = true;
            // 
            // money
            // 
            this.money.HeaderText = "减价金额";
            this.money.Name = "money";
            this.money.ReadOnly = true;
            this.money.Visible = false;
            // 
            // num
            // 
            this.num.HeaderText = "减价数量";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Visible = false;
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
            // FormPurchaseContractTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 457);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormPurchaseContractTable";
            this.Text = "采购合同表";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNumContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn signDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn signAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn bondPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn quaSpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn conutry;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dollar;
        private System.Windows.Forms.DataGridViewTextBoxColumn height;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceMY;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn conProtein;
        private System.Windows.Forms.DataGridViewTextBoxColumn conTVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn conZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn conFFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn conSHY;
        private System.Windows.Forms.DataGridViewTextBoxColumn conHF;
        private System.Windows.Forms.DataGridViewTextBoxColumn conLAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn conDAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn brands;
        private System.Windows.Forms.DataGridViewTextBoxColumn money;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}