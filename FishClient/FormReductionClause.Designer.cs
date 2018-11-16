namespace FishClient
{
    partial class FormReductionClause
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.speci = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ratio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceMY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceBase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.priceDiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceRMB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 413);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeNum,
            this.proName,
            this.country,
            this.brand,
            this.speci,
            this.ratio,
            this.priceMY,
            this.priceBase,
            this.priceDiff,
            this.exRate,
            this.priceRMB,
            this.id});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1157, 413);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // codeNum
            // 
            this.codeNum.HeaderText = "采购编号";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // proName
            // 
            this.proName.DataPropertyName = "proName";
            this.proName.HeaderText = "产品名称";
            this.proName.Name = "proName";
            this.proName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.proName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // country
            // 
            this.country.DataPropertyName = "country";
            this.country.HeaderText = "国别";
            this.country.Name = "country";
            this.country.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.country.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "品质规格";
            this.brand.Name = "brand";
            this.brand.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.brand.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // speci
            // 
            this.speci.DataPropertyName = "speci";
            this.speci.HeaderText = "规格范围";
            this.speci.Name = "speci";
            this.speci.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.speci.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ratio
            // 
            this.ratio.DataPropertyName = "ratio";
            this.ratio.HeaderText = "比例";
            this.ratio.Name = "ratio";
            // 
            // priceMY
            // 
            this.priceMY.DataPropertyName = "priceMY";
            this.priceMY.HeaderText = "美金单价";
            this.priceMY.Name = "priceMY";
            // 
            // priceBase
            // 
            this.priceBase.DataPropertyName = "priceBase";
            this.priceBase.HeaderText = "基价";
            this.priceBase.Name = "priceBase";
            this.priceBase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.priceBase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // priceDiff
            // 
            this.priceDiff.DataPropertyName = "priceDiff";
            this.priceDiff.HeaderText = "美元差价";
            this.priceDiff.Name = "priceDiff";
            // 
            // exRate
            // 
            this.exRate.DataPropertyName = "exRate";
            this.exRate.HeaderText = "汇率";
            this.exRate.Name = "exRate";
            // 
            // priceRMB
            // 
            this.priceRMB.DataPropertyName = "priceRMB";
            this.priceRMB.HeaderText = "人民币单价";
            this.priceRMB.Name = "priceRMB";
            // 
            // id
            // 
            this.id.HeaderText = "编号";
            this.id.Name = "id";
            this.id.Visible = false;
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
            // FormReductionClause
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 471);
            this.Controls.Add(this.panel1);
            this.Name = "FormReductionClause";
            this.Text = "减价条款";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewComboBoxColumn proName;
        private System.Windows.Forms.DataGridViewComboBoxColumn country;
        private System.Windows.Forms.DataGridViewComboBoxColumn brand;
        private System.Windows.Forms.DataGridViewCheckBoxColumn speci;
        private System.Windows.Forms.DataGridViewTextBoxColumn ratio;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceMY;
        private System.Windows.Forms.DataGridViewCheckBoxColumn priceBase;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn exRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceRMB;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}