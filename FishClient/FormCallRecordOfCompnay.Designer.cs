namespace FishClient
{
    partial class FormCallRecordOfCompnay
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
            this.currentdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weekestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monthestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerlevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.communicatecontent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.products = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Silver;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.customer,
            this.linkman,
            this.mobile,
            this.telephone,
            this.currentdate,
            this.weekestimate,
            this.monthestimate,
            this.customerlevel,
            this.communicatecontent,
            this.requiredquantity,
            this.products,
            this.address});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1103, 484);
            this.dataGridView1.TabIndex = 2;
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
            this.customer.Width = 150;
            // 
            // linkman
            // 
            this.linkman.DataPropertyName = "linkman";
            this.linkman.HeaderText = "联系人";
            this.linkman.Name = "linkman";
            this.linkman.ReadOnly = true;
            this.linkman.Width = 70;
            // 
            // mobile
            // 
            this.mobile.DataPropertyName = "mobile";
            this.mobile.HeaderText = "移动电话";
            this.mobile.Name = "mobile";
            this.mobile.ReadOnly = true;
            this.mobile.Width = 80;
            // 
            // telephone
            // 
            this.telephone.DataPropertyName = "telephone";
            this.telephone.HeaderText = "固定电话";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            this.telephone.Width = 80;
            // 
            // currentdate
            // 
            this.currentdate.DataPropertyName = "currentdate";
            this.currentdate.HeaderText = "日期";
            this.currentdate.Name = "currentdate";
            this.currentdate.ReadOnly = true;
            this.currentdate.Width = 150;
            // 
            // weekestimate
            // 
            this.weekestimate.DataPropertyName = "weekestimate";
            this.weekestimate.HeaderText = "估计周用量";
            this.weekestimate.Name = "weekestimate";
            this.weekestimate.ReadOnly = true;
            this.weekestimate.Width = 90;
            // 
            // monthestimate
            // 
            this.monthestimate.DataPropertyName = "monthestimate";
            this.monthestimate.HeaderText = "估计月用量";
            this.monthestimate.Name = "monthestimate";
            this.monthestimate.ReadOnly = true;
            this.monthestimate.Width = 90;
            // 
            // customerlevel
            // 
            this.customerlevel.DataPropertyName = "customerlevel";
            this.customerlevel.HeaderText = "客户等级";
            this.customerlevel.Name = "customerlevel";
            this.customerlevel.ReadOnly = true;
            this.customerlevel.Width = 80;
            // 
            // communicatecontent
            // 
            this.communicatecontent.DataPropertyName = "communicatecontent";
            this.communicatecontent.HeaderText = "沟通内容";
            this.communicatecontent.Name = "communicatecontent";
            this.communicatecontent.ReadOnly = true;
            this.communicatecontent.Width = 400;
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
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "地址";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 200;
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
            // FormCallRecordOfCompnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 517);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormCallRecordOfCompnay";
            this.Text = "通话记录";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn weekestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn monthestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerlevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn communicatecontent;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn products;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}