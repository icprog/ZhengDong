namespace FishClient
{
    partial class FormSelftStorageFlowingReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storagetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.package = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.techtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arriveportdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agentifcompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customsofcompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_amine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 387);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 42);
            this.panel1.TabIndex = 8;
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
            this.label4.Location = new System.Drawing.Point(271, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "数量合计：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(187, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "重量合计：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productid,
            this.productcode,
            this.productname,
            this.statename,
            this.billtype,
            this.billcode,
            this.date,
            this.storagetype,
            this.weight,
            this.package,
            this.nature,
            this.techtype,
            this.specification,
            this.brand,
            this.ownername,
            this.arriveportdate,
            this.agentifcompany,
            this.customsofcompany,
            this.sgs_protein,
            this.sgs_tvn,
            this.sgs_amine});
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
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
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(902, 283);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dataGridView1_CellPainting);
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "productid";
            this.productid.Name = "productid";
            this.productid.ReadOnly = true;
            this.productid.Visible = false;
            // 
            // productcode
            // 
            this.productcode.DataPropertyName = "productcode";
            this.productcode.HeaderText = "鱼粉ID";
            this.productcode.Name = "productcode";
            this.productcode.ReadOnly = true;
            this.productcode.Width = 80;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            dataGridViewCellStyle1.NullValue = " ";
            this.productname.DefaultCellStyle = dataGridViewCellStyle1;
            this.productname.HeaderText = "品名";
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Width = 120;
            // 
            // statename
            // 
            this.statename.DataPropertyName = "statename";
            this.statename.HeaderText = "状态";
            this.statename.Name = "statename";
            this.statename.ReadOnly = true;
            this.statename.Width = 90;
            // 
            // billtype
            // 
            this.billtype.DataPropertyName = "billtype";
            this.billtype.HeaderText = "单据类型";
            this.billtype.Name = "billtype";
            this.billtype.ReadOnly = true;
            this.billtype.Width = 80;
            // 
            // billcode
            // 
            this.billcode.DataPropertyName = "billcode";
            this.billcode.HeaderText = "单据号码";
            this.billcode.Name = "billcode";
            this.billcode.ReadOnly = true;
            this.billcode.Width = 90;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Visible = false;
            this.date.Width = 80;
            // 
            // storagetype
            // 
            this.storagetype.DataPropertyName = "storagetype";
            this.storagetype.HeaderText = "出/入库存";
            this.storagetype.Name = "storagetype";
            this.storagetype.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.weight.DefaultCellStyle = dataGridViewCellStyle2;
            this.weight.HeaderText = "重量(吨)";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 80;
            // 
            // package
            // 
            this.package.DataPropertyName = "package";
            this.package.HeaderText = "数量(包)";
            this.package.Name = "package";
            this.package.ReadOnly = true;
            this.package.Width = 90;
            // 
            // nature
            // 
            this.nature.DataPropertyName = "nature";
            this.nature.HeaderText = "国别";
            this.nature.Name = "nature";
            this.nature.ReadOnly = true;
            this.nature.Width = 70;
            // 
            // techtype
            // 
            this.techtype.DataPropertyName = "techtype";
            this.techtype.HeaderText = "工艺分类";
            this.techtype.Name = "techtype";
            this.techtype.ReadOnly = true;
            this.techtype.Width = 80;
            // 
            // specification
            // 
            this.specification.DataPropertyName = "specification";
            this.specification.HeaderText = "品质规格";
            this.specification.Name = "specification";
            this.specification.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "品牌";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            this.brand.Width = 90;
            // 
            // ownername
            // 
            this.ownername.DataPropertyName = "ownername";
            this.ownername.HeaderText = "所属货主";
            this.ownername.Name = "ownername";
            this.ownername.ReadOnly = true;
            // 
            // arriveportdate
            // 
            this.arriveportdate.DataPropertyName = "arriveportdate";
            this.arriveportdate.HeaderText = "到港时间";
            this.arriveportdate.Name = "arriveportdate";
            this.arriveportdate.ReadOnly = true;
            // 
            // agentifcompany
            // 
            this.agentifcompany.DataPropertyName = "agentifcompany";
            this.agentifcompany.HeaderText = "代理开证公司";
            this.agentifcompany.Name = "agentifcompany";
            this.agentifcompany.ReadOnly = true;
            // 
            // customsofcompany
            // 
            this.customsofcompany.DataPropertyName = "customsofcompany";
            this.customsofcompany.HeaderText = "货代报关公司";
            this.customsofcompany.Name = "customsofcompany";
            this.customsofcompany.ReadOnly = true;
            // 
            // sgs_protein
            // 
            this.sgs_protein.DataPropertyName = "sgs_protein";
            this.sgs_protein.HeaderText = "SGS(蛋白)";
            this.sgs_protein.Name = "sgs_protein";
            this.sgs_protein.ReadOnly = true;
            // 
            // sgs_tvn
            // 
            this.sgs_tvn.DataPropertyName = "sgs_tvn";
            this.sgs_tvn.HeaderText = "SGS(TVN)";
            this.sgs_tvn.Name = "sgs_tvn";
            this.sgs_tvn.ReadOnly = true;
            // 
            // sgs_amine
            // 
            this.sgs_amine.DataPropertyName = "sgs_amine";
            this.sgs_amine.HeaderText = "SGS(组胺)";
            this.sgs_amine.Name = "sgs_amine";
            this.sgs_amine.ReadOnly = true;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.dtpEnd);
            this.panel2.Controls.Add(this.dtpStart);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(902, 49);
            this.panel2.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(180, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 25;
            this.label11.Text = "至";
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(203, 13);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(116, 21);
            this.dtpEnd.TabIndex = 24;
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(65, 13);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(100, 21);
            this.dtpStart.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "时间端：";
            // 
            // FormSelftStorageFlowingReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormSelftStorageFlowingReport";
            this.Text = "自营自制入库流水账";
            this.Load += new System.EventHandler(this.FormSelftStorageFlowingReport_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn productcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn statename;
        private System.Windows.Forms.DataGridViewTextBoxColumn billtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn billcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn storagetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn package;
        private System.Windows.Forms.DataGridViewTextBoxColumn nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn techtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownername;
        private System.Windows.Forms.DataGridViewTextBoxColumn arriveportdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn agentifcompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn customsofcompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_amine;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}