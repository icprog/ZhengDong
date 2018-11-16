namespace FishClient
{
    partial class FormSetPresaleRequisiton
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_graypart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_sandsalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_amine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_ffa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_water = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_sand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billofgoods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cornerno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.nature,
            this.specification,
            this.brand,
            this.sgs_protein,
            this.sgs_tvn,
            this.sgs_graypart,
            this.sgs_sandsalt,
            this.sgs_amine,
            this.sgs_ffa,
            this.sgs_fat,
            this.sgs_water,
            this.sgs_sand,
            this.billofgoods,
            this.shipno,
            this.cornerno,
            this.warehouse});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 55;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(561, 315);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 315);
            this.panel1.TabIndex = 2;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "鱼粉ID";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "鱼粉名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // nature
            // 
            this.nature.HeaderText = "国别";
            this.nature.Name = "nature";
            this.nature.ReadOnly = true;
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
            // 
            // sgs_protein
            // 
            this.sgs_protein.DataPropertyName = "sgs_protein";
            this.sgs_protein.HeaderText = "蛋白";
            this.sgs_protein.Name = "sgs_protein";
            this.sgs_protein.ReadOnly = true;
            // 
            // sgs_tvn
            // 
            this.sgs_tvn.DataPropertyName = "sgs_tvn";
            this.sgs_tvn.HeaderText = "TVN";
            this.sgs_tvn.Name = "sgs_tvn";
            this.sgs_tvn.ReadOnly = true;
            // 
            // sgs_graypart
            // 
            this.sgs_graypart.DataPropertyName = "sgs_graypart";
            this.sgs_graypart.HeaderText = "灰份";
            this.sgs_graypart.Name = "sgs_graypart";
            this.sgs_graypart.ReadOnly = true;
            // 
            // sgs_sandsalt
            // 
            this.sgs_sandsalt.DataPropertyName = "sgs_sandsalt";
            this.sgs_sandsalt.HeaderText = "沙和盐";
            this.sgs_sandsalt.Name = "sgs_sandsalt";
            this.sgs_sandsalt.ReadOnly = true;
            // 
            // sgs_amine
            // 
            this.sgs_amine.DataPropertyName = "sgs_amine";
            this.sgs_amine.HeaderText = "组胺";
            this.sgs_amine.Name = "sgs_amine";
            this.sgs_amine.ReadOnly = true;
            // 
            // sgs_ffa
            // 
            this.sgs_ffa.DataPropertyName = "sgs_ffa";
            this.sgs_ffa.HeaderText = "FFA";
            this.sgs_ffa.Name = "sgs_ffa";
            this.sgs_ffa.ReadOnly = true;
            // 
            // sgs_fat
            // 
            this.sgs_fat.DataPropertyName = "sgs_fat";
            this.sgs_fat.HeaderText = "脂肪";
            this.sgs_fat.Name = "sgs_fat";
            this.sgs_fat.ReadOnly = true;
            // 
            // sgs_water
            // 
            this.sgs_water.DataPropertyName = "sgs_water";
            this.sgs_water.HeaderText = "水份";
            this.sgs_water.Name = "sgs_water";
            this.sgs_water.ReadOnly = true;
            // 
            // sgs_sand
            // 
            this.sgs_sand.DataPropertyName = "sgs_sand";
            this.sgs_sand.HeaderText = "沙";
            this.sgs_sand.Name = "sgs_sand";
            this.sgs_sand.ReadOnly = true;
            // 
            // billofgoods
            // 
            this.billofgoods.DataPropertyName = "billofgoods";
            this.billofgoods.HeaderText = "提单号";
            this.billofgoods.Name = "billofgoods";
            this.billofgoods.ReadOnly = true;
            // 
            // shipno
            // 
            this.shipno.DataPropertyName = "shipno";
            this.shipno.HeaderText = "船名";
            this.shipno.Name = "shipno";
            this.shipno.ReadOnly = true;
            // 
            // cornerno
            // 
            this.cornerno.DataPropertyName = "cornerno";
            this.cornerno.HeaderText = "桩角号";
            this.cornerno.Name = "cornerno";
            this.cornerno.ReadOnly = true;
            // 
            // warehouse
            // 
            this.warehouse.DataPropertyName = "warehouse";
            this.warehouse.HeaderText = "仓库";
            this.warehouse.Name = "warehouse";
            this.warehouse.ReadOnly = true;
            // 
            // FormSetPresaleRequisiton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 373);
            this.Controls.Add(this.panel1);
            this.Name = "FormSetPresaleRequisiton";
            this.Text = "FormSetPresaleRequisiton";
            this.Load += new System.EventHandler(this.FormSetPresaleRequisiton_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . DataGridView dataGridView1;
        private System . Windows . Forms . Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_graypart;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_sandsalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_amine;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_ffa;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_water;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_sand;
        private System.Windows.Forms.DataGridViewTextBoxColumn billofgoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipno;
        private System.Windows.Forms.DataGridViewTextBoxColumn cornerno;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse;
    }
}