namespace FishClient
{
    partial class FormSpotGoodsQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new FishClient.UIControls.CalendarColumn();
            this.time = new FishClient.UIControls.TimeColumn();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companycode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customercode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dollars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rmb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.puttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.man = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isdelete = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.no,
            this.date,
            this.time,
            this.company,
            this.companycode,
            this.companyid,
            this.customer,
            this.customerid,
            this.customercode,
            this.weight,
            this.quantity,
            this.dollars,
            this.rate,
            this.rmb,
            this.puttime,
            this.createman,
            this.man,
            this.isdelete});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(828, 374);
            this.dataGridView1.TabIndex = 7;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "序号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            this.no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.no.Width = 55;
            // 
            // date
            // 
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // time
            // 
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            this.time.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.time.Width = 70;
            // 
            // company
            // 
            this.company.HeaderText = "单位";
            this.company.Name = "company";
            this.company.ReadOnly = true;
            this.company.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // companycode
            // 
            this.companycode.HeaderText = "companycode";
            this.companycode.Name = "companycode";
            this.companycode.Visible = false;
            // 
            // companyid
            // 
            this.companyid.HeaderText = "companyid";
            this.companyid.Name = "companyid";
            this.companyid.Visible = false;
            // 
            // customer
            // 
            this.customer.HeaderText = "联系人";
            this.customer.Name = "customer";
            this.customer.ReadOnly = true;
            this.customer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.customer.Width = 80;
            // 
            // customerid
            // 
            this.customerid.HeaderText = "customerid";
            this.customerid.Name = "customerid";
            this.customerid.Visible = false;
            // 
            // customercode
            // 
            this.customercode.HeaderText = "customercode";
            this.customercode.Name = "customercode";
            this.customercode.Visible = false;
            // 
            // weight
            // 
            this.weight.HeaderText = "重量";
            this.weight.Name = "weight";
            this.weight.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.weight.Width = 60;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "数量";
            this.quantity.Name = "quantity";
            this.quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantity.Visible = false;
            this.quantity.Width = 60;
            // 
            // dollars
            // 
            this.dollars.HeaderText = "美金价";
            this.dollars.Name = "dollars";
            this.dollars.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dollars.Width = 80;
            // 
            // rate
            // 
            this.rate.HeaderText = "汇率";
            this.rate.Name = "rate";
            this.rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rate.Width = 60;
            // 
            // rmb
            // 
            this.rmb.HeaderText = "人民币价";
            this.rmb.Name = "rmb";
            this.rmb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.rmb.Width = 80;
            // 
            // puttime
            // 
            this.puttime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.puttime.DefaultCellStyle = dataGridViewCellStyle1;
            this.puttime.HeaderText = "录入时间";
            this.puttime.Name = "puttime";
            this.puttime.ReadOnly = true;
            this.puttime.Visible = false;
            // 
            // createman
            // 
            this.createman.HeaderText = "createman";
            this.createman.Name = "createman";
            this.createman.Visible = false;
            // 
            // man
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.man.DefaultCellStyle = dataGridViewCellStyle2;
            this.man.HeaderText = "录入人";
            this.man.Name = "man";
            this.man.ReadOnly = true;
            this.man.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.man.Visible = false;
            this.man.Width = 70;
            // 
            // isdelete
            // 
            this.isdelete.HeaderText = "有效性";
            this.isdelete.Name = "isdelete";
            this.isdelete.Width = 80;
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
            // FormSpotGoodsQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 432);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormSpotGoodsQuery";
            this.Text = "现货价格查询";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private UIControls.CalendarColumn date;
        private UIControls.TimeColumn time;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewTextBoxColumn companycode;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyid;
        private System.Windows.Forms.DataGridViewTextBoxColumn customer;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerid;
        private System.Windows.Forms.DataGridViewTextBoxColumn customercode;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dollars;
        private System.Windows.Forms.DataGridViewTextBoxColumn rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn rmb;
        private System.Windows.Forms.DataGridViewTextBoxColumn puttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn createman;
        private System.Windows.Forms.DataGridViewTextBoxColumn man;
        private System.Windows.Forms.DataGridViewTextBoxColumn isdelete;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}