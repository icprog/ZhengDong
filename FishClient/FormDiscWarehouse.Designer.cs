namespace FishClient
{
    partial class FormDiscWarehouse
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.huizong = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billofgoods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotesupplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotelinkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotesaildatefast = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotesaildatelate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quote_amine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmagent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmlinkman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conProtein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conTVN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conZA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.confirmdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotedollars = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotermb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceOfDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.huizong);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(979, 38);
            this.panel1.TabIndex = 1;
            // 
            // huizong
            // 
            this.huizong.Location = new System.Drawing.Point(68, 9);
            this.huizong.Name = "huizong";
            this.huizong.Size = new System.Drawing.Size(45, 21);
            this.huizong.TabIndex = 163;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 162;
            this.label13.Text = "数据汇总";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(979, 397);
            this.panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.code,
            this.billofgoods,
            this.quotesupplier,
            this.quotelinkman,
            this.nature,
            this.specification,
            this.confirmWeight,
            this.quotedate,
            this.quotesaildatefast,
            this.quotesaildatelate,
            this.quote_protein,
            this.quote_tvn,
            this.quote_amine,
            this.confirmagent,
            this.confirmlinkman,
            this.conProtein,
            this.conTVN,
            this.conZA,
            this.confirmdate,
            this.quotedollars,
            this.quotermb,
            this.PlaceOfDelivery});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(979, 397);
            this.dataGridView1.TabIndex = 6;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "港口";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 80;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "鱼粉id";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 70;
            // 
            // billofgoods
            // 
            this.billofgoods.DataPropertyName = "billofgoods";
            this.billofgoods.HeaderText = "提单号";
            this.billofgoods.Name = "billofgoods";
            this.billofgoods.ReadOnly = true;
            this.billofgoods.Visible = false;
            // 
            // quotesupplier
            // 
            this.quotesupplier.DataPropertyName = "quotesupplier";
            this.quotesupplier.HeaderText = "报盘单位";
            this.quotesupplier.Name = "quotesupplier";
            this.quotesupplier.ReadOnly = true;
            this.quotesupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quotesupplier.Width = 130;
            // 
            // quotelinkman
            // 
            this.quotelinkman.DataPropertyName = "quotelinkman";
            this.quotelinkman.HeaderText = "联系人";
            this.quotelinkman.Name = "quotelinkman";
            this.quotelinkman.ReadOnly = true;
            this.quotelinkman.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quotelinkman.Width = 70;
            // 
            // nature
            // 
            this.nature.DataPropertyName = "nature";
            this.nature.HeaderText = "国别";
            this.nature.Name = "nature";
            this.nature.ReadOnly = true;
            this.nature.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.nature.Width = 70;
            // 
            // specification
            // 
            this.specification.DataPropertyName = "specification";
            this.specification.HeaderText = "品质";
            this.specification.Name = "specification";
            this.specification.ReadOnly = true;
            this.specification.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.specification.Width = 70;
            // 
            // confirmWeight
            // 
            this.confirmWeight.DataPropertyName = "confirmWeight";
            this.confirmWeight.HeaderText = "确盘重量";
            this.confirmWeight.Name = "confirmWeight";
            this.confirmWeight.ReadOnly = true;
            this.confirmWeight.Width = 80;
            // 
            // quotedate
            // 
            this.quotedate.DataPropertyName = "quotedate";
            this.quotedate.HeaderText = "最新报盘日期";
            this.quotedate.Name = "quotedate";
            this.quotedate.ReadOnly = true;
            this.quotedate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quotedate.Width = 105;
            // 
            // quotesaildatefast
            // 
            this.quotesaildatefast.DataPropertyName = "quotesaildatefast";
            this.quotesaildatefast.FillWeight = 55F;
            this.quotesaildatefast.HeaderText = "最快";
            this.quotesaildatefast.Name = "quotesaildatefast";
            this.quotesaildatefast.ReadOnly = true;
            this.quotesaildatefast.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quotesaildatefast.Width = 70;
            // 
            // quotesaildatelate
            // 
            this.quotesaildatelate.DataPropertyName = "quotesaildatelate";
            this.quotesaildatelate.FillWeight = 55F;
            this.quotesaildatelate.HeaderText = "最晚";
            this.quotesaildatelate.Name = "quotesaildatelate";
            this.quotesaildatelate.ReadOnly = true;
            this.quotesaildatelate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quotesaildatelate.Width = 70;
            // 
            // quote_protein
            // 
            this.quote_protein.HeaderText = "报盘蛋白";
            this.quote_protein.Name = "quote_protein";
            this.quote_protein.ReadOnly = true;
            this.quote_protein.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quote_protein.Width = 60;
            // 
            // quote_tvn
            // 
            this.quote_tvn.HeaderText = "报盘TVN";
            this.quote_tvn.Name = "quote_tvn";
            this.quote_tvn.ReadOnly = true;
            this.quote_tvn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quote_tvn.Width = 60;
            // 
            // quote_amine
            // 
            this.quote_amine.HeaderText = "报盘组胺";
            this.quote_amine.Name = "quote_amine";
            this.quote_amine.ReadOnly = true;
            this.quote_amine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quote_amine.Width = 60;
            // 
            // confirmagent
            // 
            this.confirmagent.DataPropertyName = "confirmagent";
            this.confirmagent.HeaderText = "开证单位";
            this.confirmagent.Name = "confirmagent";
            this.confirmagent.ReadOnly = true;
            this.confirmagent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // confirmlinkman
            // 
            this.confirmlinkman.DataPropertyName = "confirmlinkman";
            this.confirmlinkman.HeaderText = "联系人";
            this.confirmlinkman.Name = "confirmlinkman";
            this.confirmlinkman.ReadOnly = true;
            this.confirmlinkman.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.confirmlinkman.Width = 70;
            // 
            // conProtein
            // 
            this.conProtein.DataPropertyName = "conProtein";
            this.conProtein.HeaderText = "合同蛋白";
            this.conProtein.Name = "conProtein";
            this.conProtein.ReadOnly = true;
            this.conProtein.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.conProtein.Width = 60;
            // 
            // conTVN
            // 
            this.conTVN.DataPropertyName = "conTVN";
            this.conTVN.HeaderText = "合同TVN";
            this.conTVN.Name = "conTVN";
            this.conTVN.ReadOnly = true;
            this.conTVN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.conTVN.Width = 60;
            // 
            // conZA
            // 
            this.conZA.DataPropertyName = "conZA";
            this.conZA.HeaderText = "合同组胺";
            this.conZA.Name = "conZA";
            this.conZA.ReadOnly = true;
            this.conZA.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.conZA.Width = 60;
            // 
            // confirmdate
            // 
            this.confirmdate.HeaderText = "日期";
            this.confirmdate.Name = "confirmdate";
            this.confirmdate.ReadOnly = true;
            this.confirmdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.confirmdate.Width = 90;
            // 
            // quotedollars
            // 
            this.quotedollars.DataPropertyName = "quotedollars";
            this.quotedollars.HeaderText = "美金价";
            this.quotedollars.Name = "quotedollars";
            this.quotedollars.ReadOnly = true;
            this.quotedollars.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // quotermb
            // 
            this.quotermb.DataPropertyName = "quotermb";
            this.quotermb.HeaderText = "人民币价";
            this.quotermb.Name = "quotermb";
            this.quotermb.ReadOnly = true;
            this.quotermb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlaceOfDelivery
            // 
            this.PlaceOfDelivery.DataPropertyName = "PlaceOfDelivery";
            this.PlaceOfDelivery.HeaderText = "交货港口";
            this.PlaceOfDelivery.Name = "PlaceOfDelivery";
            this.PlaceOfDelivery.ReadOnly = true;
            this.PlaceOfDelivery.Width = 80;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            this.设置列宽toolStripMenuItem.Click += new System.EventHandler(this.设置列宽toolStripMenuItem_Click);
            // 
            // FormDiscWarehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 493);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormDiscWarehouse";
            this.Text = "确盘仓库";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn billofgoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotesupplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotelinkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotesaildatefast;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotesaildatelate;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quote_amine;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmagent;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmlinkman;
        private System.Windows.Forms.DataGridViewTextBoxColumn conProtein;
        private System.Windows.Forms.DataGridViewTextBoxColumn conTVN;
        private System.Windows.Forms.DataGridViewTextBoxColumn conZA;
        private System.Windows.Forms.DataGridViewTextBoxColumn confirmdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotedollars;
        private System.Windows.Forms.DataGridViewTextBoxColumn quotermb;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceOfDelivery;
        private System.Windows.Forms.TextBox huizong;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}