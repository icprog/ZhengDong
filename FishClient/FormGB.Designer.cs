namespace FishClient
{
    partial class FormGB
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
            this.txtCheckUnitCode = new System.Windows.Forms.TextBox();
            this.dtpCheckDate = new System.Windows.Forms.DateTimePicker();
            this.txtFishName = new System.Windows.Forms.TextBox();
            this.txtCheckFee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFishCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCheckUnit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_graypart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_sandsalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_amine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.latestquote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCheckUnitCode);
            this.panel1.Controls.Add(this.dtpCheckDate);
            this.panel1.Controls.Add(this.txtFishName);
            this.panel1.Controls.Add(this.txtCheckFee);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFishCode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtCheckUnit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(753, 145);
            this.panel1.TabIndex = 1;
            // 
            // txtCheckUnitCode
            // 
            this.txtCheckUnitCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCheckUnitCode.Location = new System.Drawing.Point(92, 43);
            this.txtCheckUnitCode.Name = "txtCheckUnitCode";
            this.txtCheckUnitCode.ReadOnly = true;
            this.txtCheckUnitCode.Size = new System.Drawing.Size(100, 21);
            this.txtCheckUnitCode.TabIndex = 15;
            this.txtCheckUnitCode.Click += new System.EventHandler(this.txtCheckUnit_Click);
            // 
            // dtpCheckDate
            // 
            this.dtpCheckDate.Location = new System.Drawing.Point(277, 16);
            this.dtpCheckDate.Name = "dtpCheckDate";
            this.dtpCheckDate.Size = new System.Drawing.Size(161, 21);
            this.dtpCheckDate.TabIndex = 14;
            // 
            // txtFishName
            // 
            this.txtFishName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFishName.Location = new System.Drawing.Point(92, 106);
            this.txtFishName.Name = "txtFishName";
            this.txtFishName.ReadOnly = true;
            this.txtFishName.Size = new System.Drawing.Size(100, 21);
            this.txtFishName.TabIndex = 11;
            this.txtFishName.Click += new System.EventHandler(this.textBox6_Click);
            // 
            // txtCheckFee
            // 
            this.txtCheckFee.Location = new System.Drawing.Point(277, 77);
            this.txtCheckFee.Name = "txtCheckFee";
            this.txtCheckFee.Size = new System.Drawing.Size(161, 21);
            this.txtCheckFee.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(205, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "检测费用：";
            // 
            // txtFishCode
            // 
            this.txtFishCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtFishCode.Location = new System.Drawing.Point(92, 77);
            this.txtFishCode.Name = "txtFishCode";
            this.txtFishCode.ReadOnly = true;
            this.txtFishCode.Size = new System.Drawing.Size(100, 21);
            this.txtFishCode.TabIndex = 7;
            this.txtFishCode.Click += new System.EventHandler(this.textBox6_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "鱼粉ID：";
            // 
            // txtCheckUnit
            // 
            this.txtCheckUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtCheckUnit.Location = new System.Drawing.Point(199, 45);
            this.txtCheckUnit.Name = "txtCheckUnit";
            this.txtCheckUnit.ReadOnly = true;
            this.txtCheckUnit.Size = new System.Drawing.Size(239, 21);
            this.txtCheckUnit.TabIndex = 5;
            this.txtCheckUnit.Click += new System.EventHandler(this.txtCheckUnit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "检测单位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "检测日期：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(92, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(100, 21);
            this.txtCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "检测单号：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.goods,
            this.tons,
            this.packages,
            this.quote_protein,
            this.quote_tvn,
            this.quote_graypart,
            this.quote_sandsalt,
            this.quote_amine,
            this.state,
            this.quality,
            this.statename,
            this.remark,
            this.brand,
            this.latestquote});
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 200);
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
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(753, 229);
            this.dataGridView1.TabIndex = 7;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "鱼粉ID";
            this.code.Name = "code";
            this.code.Width = 80;
            // 
            // goods
            // 
            this.goods.DataPropertyName = "goods";
            this.goods.HeaderText = "货品";
            this.goods.Name = "goods";
            this.goods.Width = 120;
            // 
            // tons
            // 
            this.tons.DataPropertyName = "tons";
            this.tons.HeaderText = "吨位";
            this.tons.Name = "tons";
            this.tons.Width = 70;
            // 
            // packages
            // 
            this.packages.DataPropertyName = "packages";
            this.packages.HeaderText = "包数";
            this.packages.Name = "packages";
            // 
            // quote_protein
            // 
            this.quote_protein.DataPropertyName = "quote_protein";
            this.quote_protein.HeaderText = "蛋白";
            this.quote_protein.Name = "quote_protein";
            this.quote_protein.Width = 70;
            // 
            // quote_tvn
            // 
            this.quote_tvn.DataPropertyName = "quote_tvn";
            this.quote_tvn.HeaderText = "TVN";
            this.quote_tvn.Name = "quote_tvn";
            this.quote_tvn.Width = 60;
            // 
            // quote_graypart
            // 
            this.quote_graypart.DataPropertyName = "quote_graypart";
            this.quote_graypart.HeaderText = "灰份";
            this.quote_graypart.Name = "quote_graypart";
            this.quote_graypart.Width = 70;
            // 
            // quote_sandsalt
            // 
            this.quote_sandsalt.DataPropertyName = "quote_sandsalt";
            this.quote_sandsalt.HeaderText = "沙和盐";
            this.quote_sandsalt.Name = "quote_sandsalt";
            this.quote_sandsalt.Width = 70;
            // 
            // quote_amine
            // 
            this.quote_amine.DataPropertyName = "quote_amine";
            this.quote_amine.HeaderText = "SGS组胺";
            this.quote_amine.Name = "quote_amine";
            this.quote_amine.Width = 70;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "SGS(FFA)";
            this.state.Name = "state";
            this.state.Visible = false;
            // 
            // quality
            // 
            this.quality.DataPropertyName = "quality";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.quality.DefaultCellStyle = dataGridViewCellStyle1;
            this.quality.HeaderText = "酸价";
            this.quality.Name = "quality";
            this.quality.Width = 70;
            // 
            // statename
            // 
            this.statename.DataPropertyName = "statename";
            this.statename.HeaderText = "赖安酸";
            this.statename.Name = "statename";
            this.statename.Width = 60;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "蛋安酸";
            this.remark.Name = "remark";
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "自制入库单价";
            this.brand.Name = "brand";
            // 
            // latestquote
            // 
            this.latestquote.DataPropertyName = "latestquote";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = "0.00";
            this.latestquote.DefaultCellStyle = dataGridViewCellStyle2;
            this.latestquote.HeaderText = "成本";
            this.latestquote.Name = "latestquote";
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormGB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormGB";
            this.Text = "国际检测";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpCheckDate;
        private System.Windows.Forms.TextBox txtFishName;
        private System.Windows.Forms.TextBox txtCheckFee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFishCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCheckUnit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn tons;
        private System.Windows.Forms.DataGridViewTextBoxColumn packages;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_graypart;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_sandsalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_amine;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn quality;
        private System.Windows.Forms.DataGridViewTextBoxColumn statename;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn latestquote;
        private System.Windows.Forms.TextBox txtCheckUnitCode;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}