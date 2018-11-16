namespace FishClient
{
    partial class FormCallRecordsReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerlevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.communicatecontent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.products = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProducts = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRequired = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtOfficeTel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmobile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLevel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtlinkman = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustmer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.customer,
            this.linkman,
            this.mobile,
            this.telephone,
            this.customerlevel,
            this.currentdate,
            this.communicatecontent,
            this.requiredquantity,
            this.products,
            this.weekestimate,
            this.monthestimate,
            this.address});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 228);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "记录单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 90;
            // 
            // customer
            // 
            this.customer.DataPropertyName = "customer";
            this.customer.HeaderText = "客户名称";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            this.customer.Width = 120;
            // 
            // linkman
            // 
            this.linkman.DataPropertyName = "linkman";
            this.linkman.HeaderText = "联系人";
            this.linkman.Name = "linkman";
            this.linkman.ReadOnly = true;
            this.linkman.Width = 80;
            // 
            // mobile
            // 
            this.mobile.DataPropertyName = "mobile";
            this.mobile.HeaderText = "移动电话";
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = true;
            // 
            // telephone
            // 
            this.telephone.DataPropertyName = "telephone";
            this.telephone.HeaderText = "固定电话";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // customerlevel
            // 
            this.customerlevel.DataPropertyName = "customerlevel";
            this.customerlevel.HeaderText = "客户等级";
            this.customerlevel.Name = "customerlevel";
            this.customerlevel.ReadOnly = true;
            this.customerlevel.Width = 80;
            // 
            // currentdate
            // 
            this.currentdate.DataPropertyName = "currentdate";
            this.currentdate.HeaderText = "日期";
            this.currentdate.Name = "currentdate";
            this.currentdate.ReadOnly = true;
            this.currentdate.Width = 80;
            // 
            // communicatecontent
            // 
            this.communicatecontent.DataPropertyName = "communicatecontent";
            this.communicatecontent.HeaderText = "沟通内容";
            this.communicatecontent.Name = "communicatecontent";
            this.communicatecontent.ReadOnly = true;
            // 
            // requiredquantity
            // 
            this.requiredquantity.DataPropertyName = "requiredquantity";
            this.requiredquantity.HeaderText = "品质要求";
            this.requiredquantity.Name = "requiredquantity";
            this.requiredquantity.ReadOnly = true;
            // 
            // products
            // 
            this.products.DataPropertyName = "products";
            this.products.HeaderText = "主要产品";
            this.products.Name = "products";
            this.products.ReadOnly = true;
            // 
            // weekestimate
            // 
            this.weekestimate.DataPropertyName = "weekestimate";
            this.weekestimate.HeaderText = "估计周用量";
            this.weekestimate.Name = "weekestimate";
            this.weekestimate.ReadOnly = true;
            // 
            // monthestimate
            // 
            this.monthestimate.DataPropertyName = "monthestimate";
            this.monthestimate.HeaderText = "估计月用量";
            this.monthestimate.Name = "monthestimate";
            this.monthestimate.ReadOnly = true;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "地址";
            this.address.Name = "address";
            this.address.ReadOnly = true;
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
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.dtpStart);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtProducts);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtRequired);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtOfficeTel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTelephone);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtmobile);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtLevel);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtlinkman);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCustmer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 110);
            this.panel1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 74);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(220, 70);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(116, 21);
            this.dtpEnd.TabIndex = 20;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(82, 70);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 21);
            this.dtpStart.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "联系时间：";
            // 
            // txtProducts
            // 
            this.txtProducts.Location = new System.Drawing.Point(440, 70);
            this.txtProducts.Name = "txtProducts";
            this.txtProducts.Size = new System.Drawing.Size(100, 21);
            this.txtProducts.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(376, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "主要产品：";
            // 
            // txtRequired
            // 
            this.txtRequired.Location = new System.Drawing.Point(609, 42);
            this.txtRequired.Name = "txtRequired";
            this.txtRequired.Size = new System.Drawing.Size(100, 21);
            this.txtRequired.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(540, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "品质要求：";
            // 
            // txtOfficeTel
            // 
            this.txtOfficeTel.Location = new System.Drawing.Point(440, 42);
            this.txtOfficeTel.Name = "txtOfficeTel";
            this.txtOfficeTel.Size = new System.Drawing.Size(100, 21);
            this.txtOfficeTel.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(371, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "单位电话：";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(261, 42);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(100, 21);
            this.txtTelephone.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(197, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "固定电话：";
            // 
            // txtmobile
            // 
            this.txtmobile.Location = new System.Drawing.Point(82, 42);
            this.txtmobile.Name = "txtmobile";
            this.txtmobile.Size = new System.Drawing.Size(100, 21);
            this.txtmobile.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "移动电话：";
            // 
            // txtLevel
            // 
            this.txtLevel.Location = new System.Drawing.Point(610, 11);
            this.txtLevel.Name = "txtLevel";
            this.txtLevel.Size = new System.Drawing.Size(100, 21);
            this.txtLevel.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(543, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "客户等级：";
            // 
            // txtlinkman
            // 
            this.txtlinkman.Location = new System.Drawing.Point(440, 11);
            this.txtlinkman.Name = "txtlinkman";
            this.txtlinkman.Size = new System.Drawing.Size(100, 21);
            this.txtlinkman.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(376, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "联系人：";
            // 
            // txtCustmer
            // 
            this.txtCustmer.Location = new System.Drawing.Point(261, 11);
            this.txtCustmer.Name = "txtCustmer";
            this.txtCustmer.Size = new System.Drawing.Size(100, 21);
            this.txtCustmer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(192, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "客户名称：";
            // 
            // txtCode
            // 
            this.txtCode.AcceptsReturn = true;
            this.txtCode.Location = new System.Drawing.Point(82, 11);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 21);
            this.txtCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "记录单号：";
            // 
            // FormCallRecordsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 396);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormCallRecordsReport";
            this.Text = "通话记录表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProducts;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRequired;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtOfficeTel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmobile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLevel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtlinkman;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustmer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerlevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn communicatecontent;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn products;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}