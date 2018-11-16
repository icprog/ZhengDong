namespace FishClient
{
    partial class FormQuotePricingTable
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XNfishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceMY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualitySpe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ffa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.histamine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.las = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.das = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 35);
            this.panel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.fishId,
            this.XNfishId,
            this.priceMY,
            this.price,
            this.country,
            this.brand,
            this.qualitySpe,
            this.weight,
            this.tvn,
            this.ffa,
            this.acid,
            this.protein,
            this.ash,
            this.histamine,
            this.las,
            this.das,
            this.salt});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 90);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(679, 295);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // code
            // 
            this.code.HeaderText = "单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // fishId
            // 
            this.fishId.HeaderText = "鱼粉Id";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            // 
            // XNfishId
            // 
            this.XNfishId.HeaderText = "虚拟鱼粉Id";
            this.XNfishId.Name = "XNfishId";
            this.XNfishId.ReadOnly = true;
            // 
            // priceMY
            // 
            this.priceMY.HeaderText = "美元单价";
            this.priceMY.Name = "priceMY";
            this.priceMY.ReadOnly = true;
            this.priceMY.Visible = false;
            // 
            // price
            // 
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // country
            // 
            this.country.HeaderText = "国别";
            this.country.Name = "country";
            this.country.ReadOnly = true;
            // 
            // brand
            // 
            this.brand.HeaderText = "品牌";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            // 
            // qualitySpe
            // 
            this.qualitySpe.HeaderText = "品质规格";
            this.qualitySpe.Name = "qualitySpe";
            this.qualitySpe.ReadOnly = true;
            // 
            // weight
            // 
            this.weight.HeaderText = "重量";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Visible = false;
            // 
            // tvn
            // 
            this.tvn.HeaderText = "tvn";
            this.tvn.Name = "tvn";
            this.tvn.ReadOnly = true;
            // 
            // ffa
            // 
            this.ffa.HeaderText = "FFA";
            this.ffa.Name = "ffa";
            this.ffa.ReadOnly = true;
            // 
            // acid
            // 
            this.acid.HeaderText = "酸价";
            this.acid.Name = "acid";
            this.acid.ReadOnly = true;
            // 
            // protein
            // 
            this.protein.HeaderText = "蛋白";
            this.protein.Name = "protein";
            this.protein.ReadOnly = true;
            // 
            // ash
            // 
            this.ash.HeaderText = "灰份";
            this.ash.Name = "ash";
            this.ash.ReadOnly = true;
            // 
            // histamine
            // 
            this.histamine.HeaderText = "组胺";
            this.histamine.Name = "histamine";
            this.histamine.ReadOnly = true;
            // 
            // las
            // 
            this.las.HeaderText = "赖氨酸";
            this.las.Name = "las";
            this.las.ReadOnly = true;
            // 
            // das
            // 
            this.das.HeaderText = "蛋氨酸";
            this.das.Name = "das";
            this.das.ReadOnly = true;
            // 
            // salt
            // 
            this.salt.HeaderText = "盐份";
            this.salt.Name = "salt";
            this.salt.ReadOnly = true;
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
            // FormQuotePricingTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 388);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormQuotePricingTable";
            this.Text = "行情定价表";
            this.Load += new System.EventHandler(this.FormQuotePricingTable_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn XNfishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceMY;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn country;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn qualitySpe;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ffa;
        private System.Windows.Forms.DataGridViewTextBoxColumn acid;
        private System.Windows.Forms.DataGridViewTextBoxColumn protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn ash;
        private System.Windows.Forms.DataGridViewTextBoxColumn histamine;
        private System.Windows.Forms.DataGridViewTextBoxColumn las;
        private System.Windows.Forms.DataGridViewTextBoxColumn das;
        private System.Windows.Forms.DataGridViewTextBoxColumn salt;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}