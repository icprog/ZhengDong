namespace FishClient
{
    partial class FormCustomerAnalysisReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operate1 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.operate2 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shortname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cashdeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manageprojects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.products = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredproduct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.competitors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estimatepurchasetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerproperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fatures = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customergroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdbgoods = new System.Windows.Forms.RadioButton();
            this.rdbquote = new System.Windows.Forms.RadioButton();
            this.rdbcustomer = new System.Windows.Forms.RadioButton();
            this.rdbmy = new System.Windows.Forms.RadioButton();
            this.rdbSuppliers = new System.Windows.Forms.RadioButton();
            this.rdbAgent = new System.Windows.Forms.RadioButton();
            this.txtshortname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtfullname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckbGoods = new System.Windows.Forms.CheckBox();
            this.ckbQuote = new System.Windows.Forms.CheckBox();
            this.ckbCustomer = new System.Windows.Forms.CheckBox();
            this.ckbmy = new System.Windows.Forms.CheckBox();
            this.ckbSupplier = new System.Windows.Forms.CheckBox();
            this.ckbAgent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.operate1,
            this.operate2,
            this.code,
            this.fullname,
            this.shortname,
            this.type,
            this.cashdeposit,
            this.manageprojects,
            this.paymethod,
            this.products,
            this.requiredproduct,
            this.competitors,
            this.estimatepurchasetime,
            this.salesman,
            this.customerproperty,
            this.fatures,
            this.customergroup});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 123);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(878, 306);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // operate1
            // 
            dataGridViewCellStyle1.NullValue = "月预计用量表";
            this.operate1.DefaultCellStyle = dataGridViewCellStyle1;
            this.operate1.HeaderText = "操作";
            this.operate1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.operate1.Name = "operate1";
            this.operate1.ReadOnly = true;
            this.operate1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operate1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // operate2
            // 
            dataGridViewCellStyle2.NullValue = "销售记录简表";
            this.operate2.DefaultCellStyle = dataGridViewCellStyle2;
            this.operate2.HeaderText = "操作";
            this.operate2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.operate2.Name = "operate2";
            this.operate2.ReadOnly = true;
            this.operate2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.operate2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "单位ID";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 70;
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.fullname.DefaultCellStyle = dataGridViewCellStyle3;
            this.fullname.HeaderText = "公司全称";
            this.fullname.Name = "fullname";
            this.fullname.ReadOnly = true;
            this.fullname.Width = 120;
            // 
            // shortname
            // 
            this.shortname.DataPropertyName = "shortname";
            this.shortname.HeaderText = "公司简称";
            this.shortname.Name = "shortname";
            this.shortname.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "类别";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // cashdeposit
            // 
            this.cashdeposit.DataPropertyName = "cashdeposit";
            this.cashdeposit.HeaderText = "保证金比例";
            this.cashdeposit.Name = "cashdeposit";
            this.cashdeposit.ReadOnly = true;
            // 
            // manageprojects
            // 
            this.manageprojects.DataPropertyName = "manageprojects";
            this.manageprojects.HeaderText = "经营产品";
            this.manageprojects.Name = "manageprojects";
            this.manageprojects.ReadOnly = true;
            // 
            // paymethod
            // 
            this.paymethod.DataPropertyName = "paymethod";
            this.paymethod.HeaderText = "付款方式";
            this.paymethod.Name = "paymethod";
            this.paymethod.ReadOnly = true;
            // 
            // products
            // 
            this.products.DataPropertyName = "products";
            this.products.HeaderText = "生产产品";
            this.products.Name = "products";
            this.products.ReadOnly = true;
            // 
            // requiredproduct
            // 
            this.requiredproduct.DataPropertyName = "requiredproduct";
            this.requiredproduct.HeaderText = "需求商品";
            this.requiredproduct.Name = "requiredproduct";
            this.requiredproduct.ReadOnly = true;
            // 
            // competitors
            // 
            this.competitors.DataPropertyName = "competitors";
            this.competitors.HeaderText = "竞争对手";
            this.competitors.Name = "competitors";
            this.competitors.ReadOnly = true;
            // 
            // estimatepurchasetime
            // 
            this.estimatepurchasetime.DataPropertyName = "estimatepurchasetime";
            this.estimatepurchasetime.HeaderText = "预计采购时间";
            this.estimatepurchasetime.Name = "estimatepurchasetime";
            this.estimatepurchasetime.ReadOnly = true;
            this.estimatepurchasetime.Width = 80;
            // 
            // salesman
            // 
            this.salesman.DataPropertyName = "salesman";
            this.salesman.HeaderText = "业务员";
            this.salesman.Name = "salesman";
            this.salesman.ReadOnly = true;
            // 
            // customerproperty
            // 
            this.customerproperty.DataPropertyName = "customerproperty";
            this.customerproperty.HeaderText = "客户性质";
            this.customerproperty.Name = "customerproperty";
            this.customerproperty.ReadOnly = true;
            // 
            // fatures
            // 
            this.fatures.DataPropertyName = "fatures";
            this.fatures.HeaderText = "是否购买期货";
            this.fatures.Name = "fatures";
            this.fatures.ReadOnly = true;
            this.fatures.Width = 90;
            // 
            // customergroup
            // 
            this.customergroup.DataPropertyName = "customergroup";
            this.customergroup.HeaderText = "客户分组";
            this.customergroup.Name = "customergroup";
            this.customergroup.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 设置列宽ToolStripMenuItem
            // 
            this.设置列宽ToolStripMenuItem.Name = "设置列宽ToolStripMenuItem";
            this.设置列宽ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置列宽ToolStripMenuItem.Text = "设置列宽";
            this.设置列宽ToolStripMenuItem.Click += new System.EventHandler(this.设置列宽ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtshortname);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtfullname);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ckbGoods);
            this.panel1.Controls.Add(this.ckbQuote);
            this.panel1.Controls.Add(this.ckbCustomer);
            this.panel1.Controls.Add(this.ckbmy);
            this.panel1.Controls.Add(this.ckbSupplier);
            this.panel1.Controls.Add(this.ckbAgent);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(878, 68);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.rdbgoods);
            this.panel2.Controls.Add(this.rdbquote);
            this.panel2.Controls.Add(this.rdbcustomer);
            this.panel2.Controls.Add(this.rdbmy);
            this.panel2.Controls.Add(this.rdbSuppliers);
            this.panel2.Controls.Add(this.rdbAgent);
            this.panel2.Location = new System.Drawing.Point(74, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 32);
            this.panel2.TabIndex = 13;
            // 
            // rdbgoods
            // 
            this.rdbgoods.AutoSize = true;
            this.rdbgoods.Location = new System.Drawing.Point(329, 7);
            this.rdbgoods.Name = "rdbgoods";
            this.rdbgoods.Size = new System.Drawing.Size(59, 16);
            this.rdbgoods.TabIndex = 17;
            this.rdbgoods.TabStop = true;
            this.rdbgoods.Text = "货代商";
            this.rdbgoods.UseVisualStyleBackColor = true;
            this.rdbgoods.Visible = false;
            this.rdbgoods.CheckedChanged += new System.EventHandler(this.rdbgoods_CheckedChanged);
            // 
            // rdbquote
            // 
            this.rdbquote.AutoSize = true;
            this.rdbquote.Location = new System.Drawing.Point(262, 7);
            this.rdbquote.Name = "rdbquote";
            this.rdbquote.Size = new System.Drawing.Size(59, 16);
            this.rdbquote.TabIndex = 16;
            this.rdbquote.TabStop = true;
            this.rdbquote.Text = "报盘商";
            this.rdbquote.UseVisualStyleBackColor = true;
            this.rdbquote.Visible = false;
            this.rdbquote.CheckedChanged += new System.EventHandler(this.rdbquote_CheckedChanged);
            // 
            // rdbcustomer
            // 
            this.rdbcustomer.AutoSize = true;
            this.rdbcustomer.Location = new System.Drawing.Point(207, 7);
            this.rdbcustomer.Name = "rdbcustomer";
            this.rdbcustomer.Size = new System.Drawing.Size(47, 16);
            this.rdbcustomer.TabIndex = 15;
            this.rdbcustomer.TabStop = true;
            this.rdbcustomer.Text = "客户";
            this.rdbcustomer.UseVisualStyleBackColor = true;
            this.rdbcustomer.CheckedChanged += new System.EventHandler(this.rdbcustomer_CheckedChanged);
            // 
            // rdbmy
            // 
            this.rdbmy.AutoSize = true;
            this.rdbmy.Location = new System.Drawing.Point(140, 7);
            this.rdbmy.Name = "rdbmy";
            this.rdbmy.Size = new System.Drawing.Size(59, 16);
            this.rdbmy.TabIndex = 14;
            this.rdbmy.TabStop = true;
            this.rdbmy.Text = "贸易商";
            this.rdbmy.UseVisualStyleBackColor = true;
            this.rdbmy.CheckedChanged += new System.EventHandler(this.rdbmy_CheckedChanged);
            // 
            // rdbSuppliers
            // 
            this.rdbSuppliers.AutoSize = true;
            this.rdbSuppliers.Location = new System.Drawing.Point(73, 7);
            this.rdbSuppliers.Name = "rdbSuppliers";
            this.rdbSuppliers.Size = new System.Drawing.Size(59, 16);
            this.rdbSuppliers.TabIndex = 1;
            this.rdbSuppliers.TabStop = true;
            this.rdbSuppliers.Text = "供应商";
            this.rdbSuppliers.UseVisualStyleBackColor = true;
            this.rdbSuppliers.CheckedChanged += new System.EventHandler(this.rdbSuppliers_CheckedChanged);
            // 
            // rdbAgent
            // 
            this.rdbAgent.AutoSize = true;
            this.rdbAgent.Location = new System.Drawing.Point(6, 7);
            this.rdbAgent.Name = "rdbAgent";
            this.rdbAgent.Size = new System.Drawing.Size(59, 16);
            this.rdbAgent.TabIndex = 0;
            this.rdbAgent.TabStop = true;
            this.rdbAgent.Text = "代理商";
            this.rdbAgent.UseVisualStyleBackColor = true;
            this.rdbAgent.CheckedChanged += new System.EventHandler(this.rdbAgent_CheckedChanged);
            // 
            // txtshortname
            // 
            this.txtshortname.Location = new System.Drawing.Point(443, 38);
            this.txtshortname.Name = "txtshortname";
            this.txtshortname.Size = new System.Drawing.Size(124, 21);
            this.txtshortname.TabIndex = 12;
            this.txtshortname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(382, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "公司简称：";
            // 
            // txtfullname
            // 
            this.txtfullname.Location = new System.Drawing.Point(223, 38);
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.Size = new System.Drawing.Size(150, 21);
            this.txtfullname.TabIndex = 10;
            this.txtfullname.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(162, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "公司全称：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(74, 38);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(83, 21);
            this.txtCode.TabIndex = 8;
            this.txtCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCode_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "单位ID：";
            // 
            // ckbGoods
            // 
            this.ckbGoods.AutoSize = true;
            this.ckbGoods.Location = new System.Drawing.Point(382, 13);
            this.ckbGoods.Name = "ckbGoods";
            this.ckbGoods.Size = new System.Drawing.Size(60, 16);
            this.ckbGoods.TabIndex = 6;
            this.ckbGoods.Text = "货代商";
            this.ckbGoods.UseVisualStyleBackColor = true;
            // 
            // ckbQuote
            // 
            this.ckbQuote.AutoSize = true;
            this.ckbQuote.Location = new System.Drawing.Point(316, 13);
            this.ckbQuote.Name = "ckbQuote";
            this.ckbQuote.Size = new System.Drawing.Size(60, 16);
            this.ckbQuote.TabIndex = 5;
            this.ckbQuote.Text = "报盘商";
            this.ckbQuote.UseVisualStyleBackColor = true;
            // 
            // ckbCustomer
            // 
            this.ckbCustomer.AutoSize = true;
            this.ckbCustomer.Location = new System.Drawing.Point(267, 13);
            this.ckbCustomer.Name = "ckbCustomer";
            this.ckbCustomer.Size = new System.Drawing.Size(48, 16);
            this.ckbCustomer.TabIndex = 4;
            this.ckbCustomer.Text = "客户";
            this.ckbCustomer.UseVisualStyleBackColor = true;
            this.ckbCustomer.CheckedChanged += new System.EventHandler(this.ckbCustomer_CheckedChanged);
            // 
            // ckbmy
            // 
            this.ckbmy.AutoSize = true;
            this.ckbmy.Location = new System.Drawing.Point(202, 13);
            this.ckbmy.Name = "ckbmy";
            this.ckbmy.Size = new System.Drawing.Size(60, 16);
            this.ckbmy.TabIndex = 3;
            this.ckbmy.Text = "贸易商";
            this.ckbmy.UseVisualStyleBackColor = true;
            this.ckbmy.CheckedChanged += new System.EventHandler(this.ckbmy_CheckedChanged);
            // 
            // ckbSupplier
            // 
            this.ckbSupplier.AutoSize = true;
            this.ckbSupplier.Location = new System.Drawing.Point(137, 13);
            this.ckbSupplier.Name = "ckbSupplier";
            this.ckbSupplier.Size = new System.Drawing.Size(60, 16);
            this.ckbSupplier.TabIndex = 2;
            this.ckbSupplier.Text = "供应商";
            this.ckbSupplier.UseVisualStyleBackColor = true;
            this.ckbSupplier.CheckedChanged += new System.EventHandler(this.ckbSupplier_CheckedChanged);
            // 
            // ckbAgent
            // 
            this.ckbAgent.AutoSize = true;
            this.ckbAgent.Location = new System.Drawing.Point(74, 13);
            this.ckbAgent.Name = "ckbAgent";
            this.ckbAgent.Size = new System.Drawing.Size(60, 16);
            this.ckbAgent.TabIndex = 1;
            this.ckbAgent.Text = "代理商";
            this.ckbAgent.UseVisualStyleBackColor = true;
            this.ckbAgent.CheckedChanged += new System.EventHandler(this.ckbAgent_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "类别：";
            // 
            // FormCustomerAnalysisReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormCustomerAnalysisReport";
            this.Text = "客户分析表";
            this.Load += new System.EventHandler(this.FormCustomerAnalysisReport_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckbGoods;
        private System.Windows.Forms.CheckBox ckbQuote;
        private System.Windows.Forms.CheckBox ckbCustomer;
        private System.Windows.Forms.CheckBox ckbmy;
        private System.Windows.Forms.CheckBox ckbSupplier;
        private System.Windows.Forms.CheckBox ckbAgent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtshortname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtfullname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdbgoods;
        private System.Windows.Forms.RadioButton rdbquote;
        private System.Windows.Forms.RadioButton rdbcustomer;
        private System.Windows.Forms.RadioButton rdbmy;
        private System.Windows.Forms.RadioButton rdbSuppliers;
        private System.Windows.Forms.RadioButton rdbAgent;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewLinkColumn operate1;
        private System.Windows.Forms.DataGridViewLinkColumn operate2;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn shortname;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cashdeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn manageprojects;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn products;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredproduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn competitors;
        private System.Windows.Forms.DataGridViewTextBoxColumn estimatepurchasetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerproperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn fatures;
        private System.Windows.Forms.DataGridViewTextBoxColumn customergroup;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}