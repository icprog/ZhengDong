namespace FishClient
{
    partial class FormRequredForecastReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generallevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredlevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.managestandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.activelevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.products = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentlink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentweekestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currentmonthestimate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.fullname,
            this.type,
            this.generallevel,
            this.requiredlevel,
            this.managestandard,
            this.activelevel,
            this.year,
            this.products,
            this.salesman,
            this.linkman,
            this.currentlink,
            this.currentweekestimate,
            this.currentmonthestimate});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(525, 332);
            this.dataGridView1.TabIndex = 6;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "客户编码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 80;
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.fullname.DefaultCellStyle = dataGridViewCellStyle1;
            this.fullname.HeaderText = "名称";
            this.fullname.Name = "fullname";
            this.fullname.ReadOnly = true;
            this.fullname.Width = 130;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "类别";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 120;
            // 
            // generallevel
            // 
            this.generallevel.DataPropertyName = "generallevel";
            this.generallevel.HeaderText = "综合等级";
            this.generallevel.Name = "generallevel";
            this.generallevel.ReadOnly = true;
            this.generallevel.Width = 80;
            // 
            // requiredlevel
            // 
            this.requiredlevel.DataPropertyName = "requiredlevel";
            this.requiredlevel.HeaderText = "需求量等级";
            this.requiredlevel.Name = "requiredlevel";
            this.requiredlevel.ReadOnly = true;
            this.requiredlevel.Width = 90;
            // 
            // managestandard
            // 
            this.managestandard.DataPropertyName = "managestandard";
            this.managestandard.HeaderText = "管理规范";
            this.managestandard.Name = "managestandard";
            this.managestandard.ReadOnly = true;
            this.managestandard.Visible = false;
            this.managestandard.Width = 80;
            // 
            // activelevel
            // 
            this.activelevel.DataPropertyName = "activelevel";
            this.activelevel.HeaderText = "活跃程度";
            this.activelevel.Name = "activelevel";
            this.activelevel.ReadOnly = true;
            this.activelevel.Width = 80;
            // 
            // year
            // 
            this.year.DataPropertyName = "loyalty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.year.DefaultCellStyle = dataGridViewCellStyle2;
            this.year.HeaderText = "忠诚度";
            this.year.Name = "year";
            this.year.ReadOnly = true;
            this.year.Width = 70;
            // 
            // products
            // 
            this.products.DataPropertyName = "products";
            this.products.HeaderText = "主要产品";
            this.products.Name = "products";
            this.products.ReadOnly = true;
            this.products.Width = 90;
            // 
            // salesman
            // 
            this.salesman.DataPropertyName = "salesman";
            this.salesman.HeaderText = "业务员";
            this.salesman.Name = "salesman";
            this.salesman.ReadOnly = true;
            this.salesman.Width = 70;
            // 
            // linkman
            // 
            this.linkman.DataPropertyName = "linkman";
            this.linkman.HeaderText = "联系人";
            this.linkman.Name = "linkman";
            this.linkman.ReadOnly = true;
            this.linkman.Width = 70;
            // 
            // currentlink
            // 
            this.currentlink.DataPropertyName = "currentlink";
            this.currentlink.HeaderText = "最近联系日期";
            this.currentlink.Name = "currentlink";
            this.currentlink.ReadOnly = true;
            this.currentlink.Width = 120;
            // 
            // currentweekestimate
            // 
            this.currentweekestimate.DataPropertyName = "currentweekestimate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.currentweekestimate.DefaultCellStyle = dataGridViewCellStyle3;
            this.currentweekestimate.HeaderText = "最近周预估";
            this.currentweekestimate.Name = "currentweekestimate";
            this.currentweekestimate.ReadOnly = true;
            this.currentweekestimate.Width = 90;
            // 
            // currentmonthestimate
            // 
            this.currentmonthestimate.DataPropertyName = "currentmonthestimate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.currentmonthestimate.DefaultCellStyle = dataGridViewCellStyle4;
            this.currentmonthestimate.HeaderText = "最近月预估";
            this.currentmonthestimate.Name = "currentmonthestimate";
            this.currentmonthestimate.ReadOnly = true;
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
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 42);
            this.panel1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "label5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "最近月预估合计：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "最近周预估合计：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(38, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "小计：";
            // 
            // FormRequredForecastReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormRequredForecastReport";
            this.Text = "需求预测表";
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn generallevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredlevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn managestandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn activelevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn year;
        private System.Windows.Forms.DataGridViewTextBoxColumn products;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentlink;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentweekestimate;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentmonthestimate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}