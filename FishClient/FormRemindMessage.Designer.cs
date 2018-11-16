namespace FishClient
{
    partial class FormRemindMessage
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
            this.companycode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkmanid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nextlinkdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weixin = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companycode,
            this.companyname,
            this.linkman,
            this.linkmanid,
            this.telephone,
            this.phone1,
            this.phone2,
            this.phone3,
            this.nextlinkdate,
            this.salesman,
            this.qq,
            this.weixin});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(525, 374);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // companycode
            // 
            this.companycode.DataPropertyName = "companycode";
            this.companycode.HeaderText = "单位Id";
            this.companycode.Name = "companycode";
            this.companycode.ReadOnly = true;
            this.companycode.Width = 90;
            // 
            // companyname
            // 
            this.companyname.DataPropertyName = "companyname";
            this.companyname.HeaderText = "客户名称";
            this.companyname.Name = "companyname";
            this.companyname.ReadOnly = true;
            this.companyname.Width = 120;
            // 
            // linkman
            // 
            this.linkman.DataPropertyName = "linkman";
            this.linkman.HeaderText = "联系人";
            this.linkman.Name = "linkman";
            this.linkman.ReadOnly = true;
            this.linkman.Width = 80;
            // 
            // linkmanid
            // 
            this.linkmanid.HeaderText = "linkmanid";
            this.linkmanid.Name = "linkmanid";
            this.linkmanid.ReadOnly = true;
            this.linkmanid.Visible = false;
            // 
            // telephone
            // 
            this.telephone.DataPropertyName = "telephone";
            this.telephone.HeaderText = "固定电话";
            this.telephone.Name = "telephone";
            this.telephone.ReadOnly = true;
            // 
            // phone1
            // 
            this.phone1.DataPropertyName = "phone1";
            this.phone1.HeaderText = "移动电话1";
            this.phone1.Name = "phone1";
            this.phone1.ReadOnly = true;
            // 
            // phone2
            // 
            this.phone2.DataPropertyName = "phone2";
            this.phone2.HeaderText = "移动电话2";
            this.phone2.Name = "phone2";
            this.phone2.ReadOnly = true;
            // 
            // phone3
            // 
            this.phone3.DataPropertyName = "phone3";
            this.phone3.HeaderText = "移动电话3";
            this.phone3.Name = "phone3";
            this.phone3.ReadOnly = true;
            // 
            // nextlinkdate
            // 
            this.nextlinkdate.DataPropertyName = "nextlinkdate";
            this.nextlinkdate.HeaderText = "下次联系时间";
            this.nextlinkdate.Name = "nextlinkdate";
            this.nextlinkdate.ReadOnly = true;
            this.nextlinkdate.Visible = false;
            // 
            // salesman
            // 
            this.salesman.DataPropertyName = "salesman";
            this.salesman.HeaderText = "业务员";
            this.salesman.Name = "salesman";
            this.salesman.ReadOnly = true;
            // 
            // qq
            // 
            this.qq.DataPropertyName = "qq";
            this.qq.HeaderText = "QQ";
            this.qq.Name = "qq";
            this.qq.ReadOnly = true;
            // 
            // weixin
            // 
            this.weixin.DataPropertyName = "weixin";
            this.weixin.HeaderText = "微信";
            this.weixin.Name = "weixin";
            this.weixin.ReadOnly = true;
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
            // FormRemindMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 432);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormRemindMessage";
            this.Text = "提醒列表";
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn companycode;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyname;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkmanid;
        private System.Windows.Forms.DataGridViewTextBoxColumn telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nextlinkdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesman;
        private System.Windows.Forms.DataGridViewTextBoxColumn qq;
        private System.Windows.Forms.DataGridViewTextBoxColumn weixin;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}