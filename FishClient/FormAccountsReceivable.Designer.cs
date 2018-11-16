namespace FishClient
{
    partial class FormAccountsReceivable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnQuery = new System.Windows.Forms.Button();
            this.txtSaleman = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYfId = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.yfId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.province = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearArrears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthReceivable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthNetreceipts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearReceivable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yearNetreceipts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qmqk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.yfId_one = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.htje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer_one = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesman_one = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fhje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.settlementNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jsje = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivablesDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivablesMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivablesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receuvablesAcountNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark_one = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 55);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnQuery);
            this.splitContainer1.Panel1.Controls.Add(this.txtSaleman);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtUnit);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.cmbYfId);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1246, 446);
            this.splitContainer1.SplitterDistance = 36;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(604, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 6;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtSaleman
            // 
            this.txtSaleman.Location = new System.Drawing.Point(438, 8);
            this.txtSaleman.Name = "txtSaleman";
            this.txtSaleman.ReadOnly = true;
            this.txtSaleman.Size = new System.Drawing.Size(128, 21);
            this.txtSaleman.TabIndex = 5;
            this.txtSaleman.Click += new System.EventHandler(this.textBox2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(379, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "业务员：";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(245, 8);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(128, 21);
            this.txtUnit.TabIndex = 3;
            this.txtUnit.Click += new System.EventHandler(this.txtUnit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "单位：";
            // 
            // cmbYfId
            // 
            this.cmbYfId.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbYfId.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbYfId.FormattingEnabled = true;
            this.cmbYfId.Location = new System.Drawing.Point(71, 8);
            this.cmbYfId.Name = "cmbYfId";
            this.cmbYfId.Size = new System.Drawing.Size(121, 20);
            this.cmbYfId.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "鱼粉ID：";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer2.Size = new System.Drawing.Size(1246, 406);
            this.splitContainer2.SplitterDistance = 275;
            this.splitContainer2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yfId,
            this.province,
            this.region,
            this.customer,
            this.salesman,
            this.yearArrears,
            this.monthReceivable,
            this.monthNetreceipts,
            this.yearReceivable,
            this.yearNetreceipts,
            this.qmqk,
            this.remark,
            this.count});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1246, 275);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // yfId
            // 
            this.yfId.DataPropertyName = "yfId";
            this.yfId.HeaderText = "鱼粉ID";
            this.yfId.Name = "yfId";
            this.yfId.ReadOnly = true;
            // 
            // province
            // 
            this.province.DataPropertyName = "province";
            this.province.HeaderText = "省份";
            this.province.Name = "province";
            this.province.ReadOnly = true;
            // 
            // region
            // 
            this.region.DataPropertyName = "region";
            this.region.HeaderText = "地区";
            this.region.Name = "region";
            this.region.ReadOnly = true;
            // 
            // customer
            // 
            this.customer.DataPropertyName = "customer";
            this.customer.HeaderText = "客户";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            // 
            // salesman
            // 
            this.salesman.DataPropertyName = "salesman";
            this.salesman.HeaderText = "业务员";
            this.salesman.Name = "salesman";
            this.salesman.ReadOnly = true;
            // 
            // yearArrears
            // 
            this.yearArrears.DataPropertyName = "yearArrears";
            this.yearArrears.HeaderText = "年初欠款";
            this.yearArrears.Name = "yearArrears";
            this.yearArrears.ReadOnly = true;
            // 
            // monthReceivable
            // 
            this.monthReceivable.DataPropertyName = "monthReceivable";
            this.monthReceivable.HeaderText = "本月应收账款";
            this.monthReceivable.Name = "monthReceivable";
            this.monthReceivable.ReadOnly = true;
            // 
            // monthNetreceipts
            // 
            this.monthNetreceipts.DataPropertyName = "monthNetreceipts";
            this.monthNetreceipts.HeaderText = "本月实收金额";
            this.monthNetreceipts.Name = "monthNetreceipts";
            this.monthNetreceipts.ReadOnly = true;
            // 
            // yearReceivable
            // 
            this.yearReceivable.DataPropertyName = "yearReceivable";
            this.yearReceivable.HeaderText = "本年应收账款";
            this.yearReceivable.Name = "yearReceivable";
            this.yearReceivable.ReadOnly = true;
            // 
            // yearNetreceipts
            // 
            this.yearNetreceipts.DataPropertyName = "yearNetreceipts";
            this.yearNetreceipts.HeaderText = "本年实收金额";
            this.yearNetreceipts.Name = "yearNetreceipts";
            this.yearNetreceipts.ReadOnly = true;
            // 
            // qmqk
            // 
            this.qmqk.DataPropertyName = "qmqk";
            this.qmqk.HeaderText = "期末欠款金额";
            this.qmqk.Name = "qmqk";
            this.qmqk.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // count
            // 
            this.count.DataPropertyName = "count";
            this.count.HeaderText = "计数";
            this.count.Name = "count";
            this.count.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.yfId_one,
            this.code,
            this.date,
            this.num,
            this.price,
            this.htje,
            this.paymentDate,
            this.quality,
            this.customer_one,
            this.salesman_one,
            this.deliveryDay,
            this.deliveryMonth,
            this.deliveryNum,
            this.fhje,
            this.settlementNum,
            this.jsje,
            this.receivablesDay,
            this.receivablesMonth,
            this.receivablesAmount,
            this.receuvablesAcountNum,
            this.remark_one});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 45;
            this.dataGridView2.Size = new System.Drawing.Size(1246, 127);
            this.dataGridView2.TabIndex = 1;
            // 
            // yfId_one
            // 
            this.yfId_one.DataPropertyName = "yfId";
            this.yfId_one.HeaderText = "鱼粉Id";
            this.yfId_one.Name = "yfId_one";
            this.yfId_one.ReadOnly = true;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "业务单编号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // num
            // 
            this.num.DataPropertyName = "num";
            this.num.HeaderText = "数量";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // htje
            // 
            this.htje.DataPropertyName = "htje";
            this.htje.HeaderText = "合同金额";
            this.htje.Name = "htje";
            this.htje.ReadOnly = true;
            // 
            // paymentDate
            // 
            this.paymentDate.DataPropertyName = "paymentDate";
            this.paymentDate.HeaderText = "预计收款日";
            this.paymentDate.Name = "paymentDate";
            this.paymentDate.ReadOnly = true;
            // 
            // quality
            // 
            this.quality.DataPropertyName = "quality";
            this.quality.HeaderText = "品质";
            this.quality.Name = "quality";
            this.quality.ReadOnly = true;
            // 
            // customer_one
            // 
            this.customer_one.DataPropertyName = "customer";
            this.customer_one.HeaderText = "客户";
            this.customer_one.Name = "customer_one";
            this.customer_one.ReadOnly = true;
            // 
            // salesman_one
            // 
            this.salesman_one.DataPropertyName = "salesman";
            this.salesman_one.HeaderText = "业务员";
            this.salesman_one.Name = "salesman_one";
            this.salesman_one.ReadOnly = true;
            // 
            // deliveryDay
            // 
            this.deliveryDay.DataPropertyName = "deliveryDay";
            this.deliveryDay.HeaderText = "发货日";
            this.deliveryDay.Name = "deliveryDay";
            this.deliveryDay.ReadOnly = true;
            // 
            // deliveryMonth
            // 
            this.deliveryMonth.DataPropertyName = "deliveryMonth";
            this.deliveryMonth.HeaderText = "发货月";
            this.deliveryMonth.Name = "deliveryMonth";
            this.deliveryMonth.ReadOnly = true;
            // 
            // deliveryNum
            // 
            this.deliveryNum.DataPropertyName = "deliveryNum";
            this.deliveryNum.HeaderText = "发货数量";
            this.deliveryNum.Name = "deliveryNum";
            this.deliveryNum.ReadOnly = true;
            // 
            // fhje
            // 
            this.fhje.DataPropertyName = "fhje";
            this.fhje.HeaderText = "发货金额";
            this.fhje.Name = "fhje";
            this.fhje.ReadOnly = true;
            // 
            // settlementNum
            // 
            this.settlementNum.DataPropertyName = "settlementNum";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = "0";
            this.settlementNum.DefaultCellStyle = dataGridViewCellStyle1;
            this.settlementNum.HeaderText = "结算数量";
            this.settlementNum.Name = "settlementNum";
            // 
            // jsje
            // 
            this.jsje.DataPropertyName = "jsje";
            this.jsje.HeaderText = "结算金额";
            this.jsje.Name = "jsje";
            this.jsje.ReadOnly = true;
            // 
            // receivablesDay
            // 
            this.receivablesDay.DataPropertyName = "receivablesDay";
            this.receivablesDay.HeaderText = "收款日";
            this.receivablesDay.Name = "receivablesDay";
            this.receivablesDay.ReadOnly = true;
            // 
            // receivablesMonth
            // 
            this.receivablesMonth.DataPropertyName = "receivablesMonth";
            this.receivablesMonth.HeaderText = "收款月";
            this.receivablesMonth.Name = "receivablesMonth";
            this.receivablesMonth.ReadOnly = true;
            // 
            // receivablesAmount
            // 
            this.receivablesAmount.DataPropertyName = "receivablesAmount";
            this.receivablesAmount.HeaderText = "收款金额";
            this.receivablesAmount.Name = "receivablesAmount";
            this.receivablesAmount.ReadOnly = true;
            // 
            // receuvablesAcountNum
            // 
            this.receuvablesAcountNum.DataPropertyName = "receuvablesAcountNum";
            this.receuvablesAcountNum.HeaderText = "收款帐号";
            this.receuvablesAcountNum.Name = "receuvablesAcountNum";
            this.receuvablesAcountNum.ReadOnly = true;
            // 
            // remark_one
            // 
            this.remark_one.DataPropertyName = "remark";
            this.remark_one.HeaderText = "备注";
            this.remark_one.Name = "remark_one";
            this.remark_one.ReadOnly = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenu});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(125, 26);
            this.contextMenuStrip2.Click += new System.EventHandler(this.contextMenuStrip2_Click);
            // 
            // 设置列宽toolStripMenu
            // 
            this.设置列宽toolStripMenu.Name = "设置列宽toolStripMenu";
            this.设置列宽toolStripMenu.Size = new System.Drawing.Size(124, 22);
            this.设置列宽toolStripMenu.Text = "设置列宽";
            // 
            // FormAccountsReceivable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1252, 504);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormAccountsReceivable";
            this.Text = "应收账款表";
            this.Load += new System.EventHandler(this.FormAccountsReceivable_Load);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . ComboBox cmbYfId;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . TextBox txtUnit;
        private System . Windows . Forms . TextBox txtSaleman;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . SplitContainer splitContainer2;
        private System . Windows . Forms . DataGridView dataGridView1;
        private System . Windows . Forms . DataGridView dataGridView2;
        private System . Windows . Forms . ContextMenuStrip contextMenuStrip1;
        private System . Windows . Forms . ToolStripMenuItem 设置列宽toolStripMenuItem;
        private System . Windows . Forms . ContextMenuStrip contextMenuStrip2;
        private System . Windows . Forms . ToolStripMenuItem 设置列宽toolStripMenu;
        private System . Windows . Forms . DataGridViewTextBoxColumn yfId;
        private System . Windows . Forms . DataGridViewTextBoxColumn province;
        private System . Windows . Forms . DataGridViewTextBoxColumn region;
        private System . Windows . Forms . DataGridViewTextBoxColumn customer;
        private System . Windows . Forms . DataGridViewTextBoxColumn salesman;
        private System . Windows . Forms . DataGridViewTextBoxColumn yearArrears;
        private System . Windows . Forms . DataGridViewTextBoxColumn monthReceivable;
        private System . Windows . Forms . DataGridViewTextBoxColumn monthNetreceipts;
        private System . Windows . Forms . DataGridViewTextBoxColumn yearReceivable;
        private System . Windows . Forms . DataGridViewTextBoxColumn yearNetreceipts;
        private System . Windows . Forms . DataGridViewTextBoxColumn qmqk;
        private System . Windows . Forms . DataGridViewTextBoxColumn remark;
        private System . Windows . Forms . DataGridViewTextBoxColumn count;
        private System . Windows . Forms . DataGridViewTextBoxColumn yfId_one;
        private System . Windows . Forms . DataGridViewTextBoxColumn code;
        private System . Windows . Forms . DataGridViewTextBoxColumn date;
        private System . Windows . Forms . DataGridViewTextBoxColumn num;
        private System . Windows . Forms . DataGridViewTextBoxColumn price;
        private System . Windows . Forms . DataGridViewTextBoxColumn htje;
        private System . Windows . Forms . DataGridViewTextBoxColumn paymentDate;
        private System . Windows . Forms . DataGridViewTextBoxColumn quality;
        private System . Windows . Forms . DataGridViewTextBoxColumn customer_one;
        private System . Windows . Forms . DataGridViewTextBoxColumn salesman_one;
        private System . Windows . Forms . DataGridViewTextBoxColumn deliveryDay;
        private System . Windows . Forms . DataGridViewTextBoxColumn deliveryMonth;
        private System . Windows . Forms . DataGridViewTextBoxColumn deliveryNum;
        private System . Windows . Forms . DataGridViewTextBoxColumn fhje;
        private System . Windows . Forms . DataGridViewTextBoxColumn settlementNum;
        private System . Windows . Forms . DataGridViewTextBoxColumn jsje;
        private System . Windows . Forms . DataGridViewTextBoxColumn receivablesDay;
        private System . Windows . Forms . DataGridViewTextBoxColumn receivablesMonth;
        private System . Windows . Forms . DataGridViewTextBoxColumn receivablesAmount;
        private System . Windows . Forms . DataGridViewTextBoxColumn receuvablesAcountNum;
        private System . Windows . Forms . DataGridViewTextBoxColumn remark_one;
        private System . Windows . Forms . Button btnQuery;
    }
}