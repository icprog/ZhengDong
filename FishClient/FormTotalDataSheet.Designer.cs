namespace FishClient
{
    partial class FormTotalDataSheet
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
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfSigni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountOfMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActualPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Billnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Zhuangjiao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Signdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalesContractAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rebate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issuingtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SettlementAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fuKuandate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractHasReceivedPayment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TailMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(846, 363);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numbering,
            this.DateOfSigni,
            this.supplier,
            this.Quantity,
            this.UnitPrice,
            this.AmountOfMoney,
            this.ContractNo,
            this.ActualPayment,
            this.actualnumber,
            this.Shipname,
            this.Billnumber,
            this.Zhuangjiao,
            this.StorageLocation,
            this.code1,
            this.applyDate,
            this.applyMoney,
            this.weight,
            this.Signdate,
            this.demand,
            this.createman,
            this.code,
            this.Quantity1,
            this.unitprice1,
            this.SalesContractAmount,
            this.rebate,
            this.Freight,
            this.Issuingtime,
            this.Quantity2,
            this.SettlementAmount,
            this.fuKuandate,
            this.RMB,
            this.code2,
            this.ContractHasReceivedPayment,
            this.TailMoney});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(846, 296);
            this.dataGridView1.TabIndex = 1;
            // 
            // Numbering
            // 
            this.Numbering.DataPropertyName = "Numbering";
            this.Numbering.HeaderText = "编号";
            this.Numbering.Name = "Numbering";
            this.Numbering.ReadOnly = true;
            // 
            // DateOfSigni
            // 
            this.DateOfSigni.DataPropertyName = "DateOfSigni";
            this.DateOfSigni.HeaderText = "日期";
            this.DateOfSigni.Name = "DateOfSigni";
            this.DateOfSigni.ReadOnly = true;
            // 
            // supplier
            // 
            this.supplier.DataPropertyName = "supplier";
            this.supplier.HeaderText = "采购";
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "重量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // UnitPrice
            // 
            this.UnitPrice.DataPropertyName = "UnitPrice";
            this.UnitPrice.HeaderText = "单价";
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.ReadOnly = true;
            // 
            // AmountOfMoney
            // 
            this.AmountOfMoney.DataPropertyName = "AmountOfMoney";
            this.AmountOfMoney.HeaderText = "合同金额";
            this.AmountOfMoney.Name = "AmountOfMoney";
            this.AmountOfMoney.ReadOnly = true;
            // 
            // ContractNo
            // 
            this.ContractNo.DataPropertyName = "ContractNo";
            this.ContractNo.HeaderText = "合同编号";
            this.ContractNo.Name = "ContractNo";
            this.ContractNo.ReadOnly = true;
            // 
            // ActualPayment
            // 
            this.ActualPayment.DataPropertyName = "ActualPayment";
            this.ActualPayment.HeaderText = "实际付款金额";
            this.ActualPayment.Name = "ActualPayment";
            this.ActualPayment.ReadOnly = true;
            // 
            // actualnumber
            // 
            this.actualnumber.DataPropertyName = "actualnumber";
            this.actualnumber.HeaderText = "实际入库重量";
            this.actualnumber.Name = "actualnumber";
            this.actualnumber.ReadOnly = true;
            // 
            // Shipname
            // 
            this.Shipname.DataPropertyName = "Shipname";
            this.Shipname.HeaderText = "船名";
            this.Shipname.Name = "Shipname";
            this.Shipname.ReadOnly = true;
            // 
            // Billnumber
            // 
            this.Billnumber.DataPropertyName = "Billnumber";
            this.Billnumber.HeaderText = "提单号";
            this.Billnumber.Name = "Billnumber";
            this.Billnumber.ReadOnly = true;
            // 
            // Zhuangjiao
            // 
            this.Zhuangjiao.DataPropertyName = "Zhuangjiao";
            this.Zhuangjiao.HeaderText = "桩角号";
            this.Zhuangjiao.Name = "Zhuangjiao";
            this.Zhuangjiao.ReadOnly = true;
            // 
            // StorageLocation
            // 
            this.StorageLocation.DataPropertyName = "StorageLocation";
            this.StorageLocation.HeaderText = "存放地点";
            this.StorageLocation.Name = "StorageLocation";
            this.StorageLocation.ReadOnly = true;
            // 
            // code1
            // 
            this.code1.DataPropertyName = "code1";
            this.code1.HeaderText = "付款申请单";
            this.code1.Name = "code1";
            this.code1.ReadOnly = true;
            // 
            // applyDate
            // 
            this.applyDate.DataPropertyName = "applyDate";
            this.applyDate.HeaderText = "付款时间";
            this.applyDate.Name = "applyDate";
            this.applyDate.ReadOnly = true;
            // 
            // applyMoney
            // 
            this.applyMoney.DataPropertyName = "applyMoney";
            this.applyMoney.HeaderText = "已付货款";
            this.applyMoney.Name = "applyMoney";
            this.applyMoney.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "付款重量";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            // 
            // Signdate
            // 
            this.Signdate.DataPropertyName = "Signdate";
            this.Signdate.HeaderText = "销售日期";
            this.Signdate.Name = "Signdate";
            this.Signdate.ReadOnly = true;
            // 
            // demand
            // 
            this.demand.DataPropertyName = "demand";
            this.demand.HeaderText = "销售单位";
            this.demand.Name = "demand";
            this.demand.ReadOnly = true;
            // 
            // createman
            // 
            this.createman.DataPropertyName = "createman";
            this.createman.HeaderText = "业务员";
            this.createman.Name = "createman";
            this.createman.ReadOnly = true;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "销售合同编号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // Quantity1
            // 
            this.Quantity1.DataPropertyName = "Quantity1";
            this.Quantity1.HeaderText = "销售重量";
            this.Quantity1.Name = "Quantity1";
            this.Quantity1.ReadOnly = true;
            // 
            // unitprice1
            // 
            this.unitprice1.DataPropertyName = "unitprice1";
            this.unitprice1.HeaderText = "销售单价";
            this.unitprice1.Name = "unitprice1";
            this.unitprice1.ReadOnly = true;
            // 
            // SalesContractAmount
            // 
            this.SalesContractAmount.DataPropertyName = "SalesContractAmount";
            this.SalesContractAmount.HeaderText = "销售合同金额";
            this.SalesContractAmount.Name = "SalesContractAmount";
            this.SalesContractAmount.ReadOnly = true;
            // 
            // rebate
            // 
            this.rebate.DataPropertyName = "rebate";
            this.rebate.HeaderText = "回扣";
            this.rebate.Name = "rebate";
            this.rebate.ReadOnly = true;
            // 
            // Freight
            // 
            this.Freight.DataPropertyName = "Freight";
            this.Freight.HeaderText = "运费";
            this.Freight.Name = "Freight";
            this.Freight.ReadOnly = true;
            // 
            // Issuingtime
            // 
            this.Issuingtime.DataPropertyName = "Issuingtime";
            this.Issuingtime.HeaderText = "提货时间";
            this.Issuingtime.Name = "Issuingtime";
            this.Issuingtime.ReadOnly = true;
            // 
            // Quantity2
            // 
            this.Quantity2.DataPropertyName = "Quantity2";
            this.Quantity2.HeaderText = "过磅数量";
            this.Quantity2.Name = "Quantity2";
            this.Quantity2.ReadOnly = true;
            // 
            // SettlementAmount
            // 
            this.SettlementAmount.DataPropertyName = "SettlementAmount";
            this.SettlementAmount.HeaderText = "结算金额";
            this.SettlementAmount.Name = "SettlementAmount";
            this.SettlementAmount.ReadOnly = true;
            // 
            // fuKuandate
            // 
            this.fuKuandate.DataPropertyName = "fuKuandate";
            this.fuKuandate.HeaderText = "收款日期";
            this.fuKuandate.Name = "fuKuandate";
            this.fuKuandate.ReadOnly = true;
            // 
            // RMB
            // 
            this.RMB.DataPropertyName = "RMB";
            this.RMB.HeaderText = "已收货款";
            this.RMB.Name = "RMB";
            this.RMB.ReadOnly = true;
            // 
            // code2
            // 
            this.code2.DataPropertyName = "code2";
            this.code2.HeaderText = "收款记录单";
            this.code2.Name = "code2";
            this.code2.ReadOnly = true;
            // 
            // ContractHasReceivedPayment
            // 
            this.ContractHasReceivedPayment.DataPropertyName = "ContractHasReceivedPayment";
            this.ContractHasReceivedPayment.HeaderText = "合同已收货款总和";
            this.ContractHasReceivedPayment.Name = "ContractHasReceivedPayment";
            this.ContractHasReceivedPayment.ReadOnly = true;
            // 
            // TailMoney
            // 
            this.TailMoney.DataPropertyName = "TailMoney";
            this.TailMoney.HeaderText = "尾款";
            this.TailMoney.Name = "TailMoney";
            this.TailMoney.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 67);
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
            // FormTotalDataSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 421);
            this.Controls.Add(this.panel1);
            this.Name = "FormTotalDataSheet";
            this.Text = "总数据表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfSigni;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountOfMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActualPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Billnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Zhuangjiao;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn code1;
        private System.Windows.Forms.DataGridViewTextBoxColumn applyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn applyMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Signdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn createman;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalesContractAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn rebate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issuingtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SettlementAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuKuandate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMB;
        private System.Windows.Forms.DataGridViewTextBoxColumn code2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractHasReceivedPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn TailMoney;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}