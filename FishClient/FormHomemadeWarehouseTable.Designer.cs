namespace FishClient
{
    partial class FormHomemadeWarehouseTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storagetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.outtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storagequantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.selfprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.storageman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_graypart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_sandsalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_amine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_ffa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_water = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_sand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_methionine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_lysine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_graypart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_sandsalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_sour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_methionine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domestic_lysine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtSeq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFishCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(646, 330);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(646, 280);
            this.panel3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.productid,
            this.seq,
            this.storagetime,
            this.intime,
            this.outtime,
            this.storageweight,
            this.storagequantity,
            this.selfprice,
            this.saleprice,
            this.purchaseman,
            this.storageman,
            this.sgs_protein,
            this.sgs_tvn,
            this.sgs_graypart,
            this.sgs_sandsalt,
            this.sgs_amine,
            this.sgs_ffa,
            this.sgs_fat,
            this.sgs_water,
            this.sgs_sand,
            this.label_methionine,
            this.label_lysine,
            this.domestic_protein,
            this.domestic_tvn,
            this.domestic_graypart,
            this.domestic_sandsalt,
            this.domestic_sour,
            this.domestic_methionine,
            this.domestic_lysine});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(646, 280);
            this.dataGridView1.TabIndex = 0;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "入库单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // productid
            // 
            this.productid.DataPropertyName = "productid";
            this.productid.HeaderText = "鱼粉ID";
            this.productid.Name = "productid";
            this.productid.ReadOnly = true;
            // 
            // seq
            // 
            this.seq.DataPropertyName = "seq";
            this.seq.HeaderText = "序号";
            this.seq.Name = "seq";
            this.seq.ReadOnly = true;
            // 
            // storagetime
            // 
            this.storagetime.DataPropertyName = "storagetime";
            this.storagetime.HeaderText = "入库时间";
            this.storagetime.Name = "storagetime";
            this.storagetime.ReadOnly = true;
            // 
            // intime
            // 
            this.intime.DataPropertyName = "intime";
            this.intime.HeaderText = "进厂时间";
            this.intime.Name = "intime";
            this.intime.ReadOnly = true;
            // 
            // outtime
            // 
            this.outtime.DataPropertyName = "outtime";
            this.outtime.HeaderText = "出厂时间";
            this.outtime.Name = "outtime";
            this.outtime.ReadOnly = true;
            // 
            // storageweight
            // 
            this.storageweight.DataPropertyName = "storageweight";
            this.storageweight.HeaderText = "自制仓入库重量";
            this.storageweight.Name = "storageweight";
            this.storageweight.ReadOnly = true;
            // 
            // storagequantity
            // 
            this.storagequantity.DataPropertyName = "storagequantity";
            this.storagequantity.HeaderText = "自制仓入库数量";
            this.storagequantity.Name = "storagequantity";
            this.storagequantity.ReadOnly = true;
            // 
            // selfprice
            // 
            this.selfprice.DataPropertyName = "selfprice";
            this.selfprice.HeaderText = "自制采购单价";
            this.selfprice.Name = "selfprice";
            this.selfprice.ReadOnly = true;
            // 
            // saleprice
            // 
            this.saleprice.DataPropertyName = "saleprice";
            this.saleprice.HeaderText = "销售采购单价";
            this.saleprice.Name = "saleprice";
            this.saleprice.ReadOnly = true;
            // 
            // purchaseman
            // 
            this.purchaseman.DataPropertyName = "purchaseman";
            this.purchaseman.HeaderText = "采购员";
            this.purchaseman.Name = "purchaseman";
            this.purchaseman.ReadOnly = true;
            // 
            // storageman
            // 
            this.storageman.DataPropertyName = "storageman";
            this.storageman.HeaderText = "发货人员";
            this.storageman.Name = "storageman";
            this.storageman.ReadOnly = true;
            // 
            // sgs_protein
            // 
            this.sgs_protein.DataPropertyName = "sgs_protein";
            this.sgs_protein.HeaderText = "SGS报告指标：蛋白";
            this.sgs_protein.Name = "sgs_protein";
            this.sgs_protein.ReadOnly = true;
            // 
            // sgs_tvn
            // 
            this.sgs_tvn.DataPropertyName = "sgs_tvn";
            this.sgs_tvn.HeaderText = "SGS报告指标：TVN";
            this.sgs_tvn.Name = "sgs_tvn";
            this.sgs_tvn.ReadOnly = true;
            // 
            // sgs_graypart
            // 
            this.sgs_graypart.DataPropertyName = "sgs_graypart";
            this.sgs_graypart.HeaderText = "SGS报告指标：灰份";
            this.sgs_graypart.Name = "sgs_graypart";
            this.sgs_graypart.ReadOnly = true;
            // 
            // sgs_sandsalt
            // 
            this.sgs_sandsalt.DataPropertyName = "sgs_sandsalt";
            this.sgs_sandsalt.HeaderText = "SGS报告指标：沙和盐";
            this.sgs_sandsalt.Name = "sgs_sandsalt";
            this.sgs_sandsalt.ReadOnly = true;
            // 
            // sgs_amine
            // 
            this.sgs_amine.DataPropertyName = "sgs_amine";
            this.sgs_amine.HeaderText = "SGS报告指标：组胺";
            this.sgs_amine.Name = "sgs_amine";
            this.sgs_amine.ReadOnly = true;
            // 
            // sgs_ffa
            // 
            this.sgs_ffa.DataPropertyName = "sgs_ffa";
            this.sgs_ffa.HeaderText = "SGS报告指标：FFA";
            this.sgs_ffa.Name = "sgs_ffa";
            this.sgs_ffa.ReadOnly = true;
            // 
            // sgs_fat
            // 
            this.sgs_fat.DataPropertyName = "sgs_fat";
            this.sgs_fat.HeaderText = "SGS报告指标：脂肪";
            this.sgs_fat.Name = "sgs_fat";
            this.sgs_fat.ReadOnly = true;
            // 
            // sgs_water
            // 
            this.sgs_water.DataPropertyName = "sgs_water";
            this.sgs_water.HeaderText = "SGS报告指标：水份";
            this.sgs_water.Name = "sgs_water";
            this.sgs_water.ReadOnly = true;
            // 
            // sgs_sand
            // 
            this.sgs_sand.DataPropertyName = "sgs_sand";
            this.sgs_sand.HeaderText = "SGS报告指标：沙";
            this.sgs_sand.Name = "sgs_sand";
            this.sgs_sand.ReadOnly = true;
            // 
            // label_methionine
            // 
            this.label_methionine.DataPropertyName = "label_methionine";
            this.label_methionine.HeaderText = "标签指标：蛋氨酸";
            this.label_methionine.Name = "label_methionine";
            this.label_methionine.ReadOnly = true;
            // 
            // label_lysine
            // 
            this.label_lysine.DataPropertyName = "label_lysine";
            this.label_lysine.HeaderText = "标签指标：赖氨酸";
            this.label_lysine.Name = "label_lysine";
            this.label_lysine.ReadOnly = true;
            // 
            // domestic_protein
            // 
            this.domestic_protein.DataPropertyName = "domestic_protein";
            this.domestic_protein.HeaderText = "国内实测指标：蛋白";
            this.domestic_protein.Name = "domestic_protein";
            this.domestic_protein.ReadOnly = true;
            // 
            // domestic_tvn
            // 
            this.domestic_tvn.DataPropertyName = "domestic_tvn";
            this.domestic_tvn.HeaderText = "国内实测指标：TVN";
            this.domestic_tvn.Name = "domestic_tvn";
            this.domestic_tvn.ReadOnly = true;
            // 
            // domestic_graypart
            // 
            this.domestic_graypart.DataPropertyName = "domestic_graypart";
            this.domestic_graypart.HeaderText = "国内实测指标：灰份";
            this.domestic_graypart.Name = "domestic_graypart";
            this.domestic_graypart.ReadOnly = true;
            // 
            // domestic_sandsalt
            // 
            this.domestic_sandsalt.DataPropertyName = "domestic_sandsalt";
            this.domestic_sandsalt.HeaderText = "国内实测指标：沙和盐";
            this.domestic_sandsalt.Name = "domestic_sandsalt";
            this.domestic_sandsalt.ReadOnly = true;
            // 
            // domestic_sour
            // 
            this.domestic_sour.DataPropertyName = "domestic_sour";
            this.domestic_sour.HeaderText = "国内实测指标：酸价";
            this.domestic_sour.Name = "domestic_sour";
            this.domestic_sour.ReadOnly = true;
            // 
            // domestic_methionine
            // 
            this.domestic_methionine.DataPropertyName = "domestic_methionine";
            this.domestic_methionine.HeaderText = "国内实测指标：蛋氨酸";
            this.domestic_methionine.Name = "domestic_methionine";
            this.domestic_methionine.ReadOnly = true;
            // 
            // domestic_lysine
            // 
            this.domestic_lysine.DataPropertyName = "domestic_lysine";
            this.domestic_lysine.HeaderText = "国内实测指标：赖氨酸";
            this.domestic_lysine.Name = "domestic_lysine";
            this.domestic_lysine.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtSeq);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtFishCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(646, 50);
            this.panel2.TabIndex = 2;
            // 
            // txtSeq
            // 
            this.txtSeq.Location = new System.Drawing.Point(413, 15);
            this.txtSeq.Name = "txtSeq";
            this.txtSeq.Size = new System.Drawing.Size(164, 21);
            this.txtSeq.TabIndex = 149;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(370, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 148;
            this.label4.Text = "序号：";
            // 
            // txtFishCode
            // 
            this.txtFishCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFishCode.Location = new System.Drawing.Point(302, 14);
            this.txtFishCode.Name = "txtFishCode";
            this.txtFishCode.Size = new System.Drawing.Size(60, 21);
            this.txtFishCode.TabIndex = 147;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 146;
            this.label2.Text = "鱼粉ID：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(77, 14);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(164, 21);
            this.txtCode.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 93;
            this.label1.Text = "入库单号：";
            // 
            // FormHomemadeWarehouseTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 388);
            this.Controls.Add(this.panel1);
            this.Name = "FormHomemadeWarehouseTable";
            this.Text = "自制仓入库表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFishCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn productid;
        private System.Windows.Forms.DataGridViewTextBoxColumn seq;
        private System.Windows.Forms.DataGridViewTextBoxColumn storagetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn intime;
        private System.Windows.Forms.DataGridViewTextBoxColumn outtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn storageweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn storagequantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn selfprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseman;
        private System.Windows.Forms.DataGridViewTextBoxColumn storageman;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_graypart;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_sandsalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_amine;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_ffa;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_water;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_sand;
        private System.Windows.Forms.DataGridViewTextBoxColumn label_methionine;
        private System.Windows.Forms.DataGridViewTextBoxColumn label_lysine;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_graypart;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_sandsalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_sour;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_methionine;
        private System.Windows.Forms.DataGridViewTextBoxColumn domestic_lysine;
    }
}