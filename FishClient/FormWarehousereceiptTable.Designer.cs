namespace FishClient
{
    partial class FormWarehousereceiptTable
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeNumContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commodityTons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commodityPack = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commodity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartingCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartingCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationCountry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forwardingUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipMent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipMentUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_Protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_Water = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_Fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_FFA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_SandSalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label_Antioxidant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receiveAdd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractNums = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceMJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FOB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CFR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(866, 502);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 80);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(866, 422);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeNumContract,
            this.codeNum,
            this.fishId,
            this.code,
            this.commodityTons,
            this.commodityPack,
            this.commodity,
            this.shipname,
            this.billName,
            this.StartingCountry,
            this.StartingCity,
            this.DestinationCountry,
            this.DestinationCity,
            this.forwardingUnit,
            this.shipMent,
            this.shipMentUser,
            this.Label_Protein,
            this.Label_Water,
            this.Label_Fat,
            this.Label_FFA,
            this.Label_SandSalt,
            this.Label_Antioxidant,
            this.supCom,
            this.receive,
            this.receiveAdd,
            this.contractNums,
            this.priceMJ,
            this.FOB,
            this.CFR});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(866, 422);
            this.dataGridView1.TabIndex = 0;
            // 
            // codeNumContract
            // 
            this.codeNumContract.HeaderText = "采购合同编号";
            this.codeNumContract.Name = "codeNumContract";
            this.codeNumContract.ReadOnly = true;
            // 
            // codeNum
            // 
            this.codeNum.HeaderText = "采购编号";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // fishId
            // 
            this.fishId.HeaderText = "鱼粉Id";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            // 
            // code
            // 
            this.code.HeaderText = "进仓单单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // commodityTons
            // 
            this.commodityTons.HeaderText = "产品名称";
            this.commodityTons.Name = "commodityTons";
            this.commodityTons.ReadOnly = true;
            // 
            // commodityPack
            // 
            this.commodityPack.HeaderText = "重量";
            this.commodityPack.Name = "commodityPack";
            this.commodityPack.ReadOnly = true;
            // 
            // commodity
            // 
            this.commodity.HeaderText = "包数";
            this.commodity.Name = "commodity";
            this.commodity.ReadOnly = true;
            // 
            // shipname
            // 
            this.shipname.HeaderText = "船名";
            this.shipname.Name = "shipname";
            this.shipname.ReadOnly = true;
            // 
            // billName
            // 
            this.billName.HeaderText = "提单号";
            this.billName.Name = "billName";
            this.billName.ReadOnly = true;
            // 
            // StartingCountry
            // 
            this.StartingCountry.HeaderText = "起运港国别";
            this.StartingCountry.Name = "StartingCountry";
            this.StartingCountry.ReadOnly = true;
            // 
            // StartingCity
            // 
            this.StartingCity.HeaderText = "起运港城市";
            this.StartingCity.Name = "StartingCity";
            this.StartingCity.ReadOnly = true;
            // 
            // DestinationCountry
            // 
            this.DestinationCountry.HeaderText = "目的港国别";
            this.DestinationCountry.Name = "DestinationCountry";
            this.DestinationCountry.ReadOnly = true;
            // 
            // DestinationCity
            // 
            this.DestinationCity.HeaderText = "目的港城市";
            this.DestinationCity.Name = "DestinationCity";
            this.DestinationCity.ReadOnly = true;
            // 
            // forwardingUnit
            // 
            this.forwardingUnit.HeaderText = "工厂/贸易商";
            this.forwardingUnit.Name = "forwardingUnit";
            this.forwardingUnit.ReadOnly = true;
            // 
            // shipMent
            // 
            this.shipMent.HeaderText = "装运单位";
            this.shipMent.Name = "shipMent";
            this.shipMent.ReadOnly = true;
            // 
            // shipMentUser
            // 
            this.shipMentUser.HeaderText = "装运人";
            this.shipMentUser.Name = "shipMentUser";
            this.shipMentUser.ReadOnly = true;
            // 
            // Label_Protein
            // 
            this.Label_Protein.HeaderText = "标签蛋白";
            this.Label_Protein.Name = "Label_Protein";
            this.Label_Protein.ReadOnly = true;
            // 
            // Label_Water
            // 
            this.Label_Water.HeaderText = "标签水分";
            this.Label_Water.Name = "Label_Water";
            this.Label_Water.ReadOnly = true;
            // 
            // Label_Fat
            // 
            this.Label_Fat.HeaderText = "标签脂肪";
            this.Label_Fat.Name = "Label_Fat";
            this.Label_Fat.ReadOnly = true;
            // 
            // Label_FFA
            // 
            this.Label_FFA.HeaderText = "标签FFA";
            this.Label_FFA.Name = "Label_FFA";
            this.Label_FFA.ReadOnly = true;
            // 
            // Label_SandSalt
            // 
            this.Label_SandSalt.HeaderText = "标签沙盐";
            this.Label_SandSalt.Name = "Label_SandSalt";
            this.Label_SandSalt.ReadOnly = true;
            // 
            // Label_Antioxidant
            // 
            this.Label_Antioxidant.HeaderText = "标签抗氧化剂";
            this.Label_Antioxidant.Name = "Label_Antioxidant";
            this.Label_Antioxidant.ReadOnly = true;
            // 
            // supCom
            // 
            this.supCom.HeaderText = "供应方公司";
            this.supCom.Name = "supCom";
            this.supCom.ReadOnly = true;
            // 
            // receive
            // 
            this.receive.HeaderText = "接收方";
            this.receive.Name = "receive";
            this.receive.ReadOnly = true;
            // 
            // receiveAdd
            // 
            this.receiveAdd.HeaderText = "接收方地址";
            this.receiveAdd.Name = "receiveAdd";
            this.receiveAdd.ReadOnly = true;
            // 
            // contractNums
            // 
            this.contractNums.HeaderText = "合同号";
            this.contractNums.Name = "contractNums";
            this.contractNums.ReadOnly = true;
            // 
            // priceMJ
            // 
            this.priceMJ.HeaderText = "美金单价";
            this.priceMJ.Name = "priceMJ";
            this.priceMJ.ReadOnly = true;
            // 
            // FOB
            // 
            this.FOB.HeaderText = "F.O.B金额";
            this.FOB.Name = "FOB";
            this.FOB.ReadOnly = true;
            // 
            // CFR
            // 
            this.CFR.HeaderText = "CFR金额";
            this.CFR.Name = "CFR";
            this.CFR.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(866, 80);
            this.panel2.TabIndex = 0;
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
            // FormWarehousereceiptTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 560);
            this.Controls.Add(this.panel1);
            this.Name = "FormWarehousereceiptTable";
            this.Text = "进仓单表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNumContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodityTons;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodityPack;
        private System.Windows.Forms.DataGridViewTextBoxColumn commodity;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipname;
        private System.Windows.Forms.DataGridViewTextBoxColumn billName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartingCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartingCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationCountry;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn forwardingUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipMent;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipMentUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label_Protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label_Water;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label_Fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label_FFA;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label_SandSalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label_Antioxidant;
        private System.Windows.Forms.DataGridViewTextBoxColumn supCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn receive;
        private System.Windows.Forms.DataGridViewTextBoxColumn receiveAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractNums;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceMJ;
        private System.Windows.Forms.DataGridViewTextBoxColumn FOB;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFR;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}