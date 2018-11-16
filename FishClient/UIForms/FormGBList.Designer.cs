namespace FishClient.UIForms
{
    partial class FormGBList
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
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
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
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
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(607, 345);
            this.dataGridView1.TabIndex = 8;
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
            this.code.HeaderText = "鱼粉ID";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 80;
            // 
            // goods
            // 
            this.goods.DataPropertyName = "goods";
            this.goods.HeaderText = "货品";
            this.goods.Name = "goods";
            this.goods.ReadOnly = true;
            this.goods.Width = 120;
            // 
            // tons
            // 
            this.tons.DataPropertyName = "tons";
            this.tons.HeaderText = "吨位";
            this.tons.Name = "tons";
            this.tons.ReadOnly = true;
            this.tons.Width = 70;
            // 
            // packages
            // 
            this.packages.DataPropertyName = "packages";
            this.packages.HeaderText = "包数";
            this.packages.Name = "packages";
            this.packages.ReadOnly = true;
            // 
            // quote_protein
            // 
            this.quote_protein.DataPropertyName = "quote_protein";
            this.quote_protein.HeaderText = "蛋白";
            this.quote_protein.Name = "quote_protein";
            this.quote_protein.ReadOnly = true;
            this.quote_protein.Width = 70;
            // 
            // quote_tvn
            // 
            this.quote_tvn.DataPropertyName = "quote_tvn";
            this.quote_tvn.HeaderText = "TVN";
            this.quote_tvn.Name = "quote_tvn";
            this.quote_tvn.ReadOnly = true;
            this.quote_tvn.Width = 60;
            // 
            // quote_graypart
            // 
            this.quote_graypart.DataPropertyName = "quote_graypart";
            this.quote_graypart.HeaderText = "灰份";
            this.quote_graypart.Name = "quote_graypart";
            this.quote_graypart.ReadOnly = true;
            this.quote_graypart.Width = 70;
            // 
            // quote_sandsalt
            // 
            this.quote_sandsalt.DataPropertyName = "quote_sandsalt";
            this.quote_sandsalt.HeaderText = "沙和盐";
            this.quote_sandsalt.Name = "quote_sandsalt";
            this.quote_sandsalt.ReadOnly = true;
            this.quote_sandsalt.Width = 70;
            // 
            // quote_amine
            // 
            this.quote_amine.DataPropertyName = "quote_amine";
            this.quote_amine.HeaderText = "SGS组胺";
            this.quote_amine.Name = "quote_amine";
            this.quote_amine.ReadOnly = true;
            this.quote_amine.Width = 70;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "SGS(FFA)";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Visible = false;
            // 
            // quality
            // 
            this.quality.DataPropertyName = "quality";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.quality.DefaultCellStyle = dataGridViewCellStyle1;
            this.quality.HeaderText = "酸价";
            this.quality.Name = "quality";
            this.quality.ReadOnly = true;
            this.quality.Width = 70;
            // 
            // statename
            // 
            this.statename.DataPropertyName = "statename";
            this.statename.HeaderText = "赖安酸";
            this.statename.Name = "statename";
            this.statename.ReadOnly = true;
            this.statename.Width = 60;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "蛋安酸";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "自制入库单价";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
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
            this.latestquote.ReadOnly = true;
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
            // FormGBList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 378);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormGBList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检测记录";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}