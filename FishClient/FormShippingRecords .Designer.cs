namespace FishClient
{
    partial class FormShippingRecords
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pickuptime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonnage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfPacks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippingUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArrivalUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Freight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillOfLadingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quality = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.dtppickuptime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBillOfLadingNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShipName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCarNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFreight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArrivalUnit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShippingUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1.Size = new System.Drawing.Size(881, 485);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 77);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(881, 408);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.pickuptime,
            this.tonnage,
            this.NumberOfPacks,
            this.ShippingUnit,
            this.ArrivalUnit,
            this.Freight,
            this.CarNumber,
            this.ShipName,
            this.BillOfLadingNumber,
            this.Country,
            this.Brand,
            this.quality,
            this.ProductionDate,
            this.Remarks});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(881, 408);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
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
            this.code.HeaderText = "编号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // pickuptime
            // 
            this.pickuptime.DataPropertyName = "pickuptime";
            this.pickuptime.HeaderText = "提货时间";
            this.pickuptime.Name = "pickuptime";
            this.pickuptime.ReadOnly = true;
            // 
            // tonnage
            // 
            this.tonnage.DataPropertyName = "tonnage";
            this.tonnage.HeaderText = "吨位";
            this.tonnage.Name = "tonnage";
            this.tonnage.ReadOnly = true;
            // 
            // NumberOfPacks
            // 
            this.NumberOfPacks.DataPropertyName = "NumberOfPacks";
            this.NumberOfPacks.HeaderText = "包数(件)";
            this.NumberOfPacks.Name = "NumberOfPacks";
            this.NumberOfPacks.ReadOnly = true;
            // 
            // ShippingUnit
            // 
            this.ShippingUnit.DataPropertyName = "ShippingUnit";
            this.ShippingUnit.HeaderText = "发货位置";
            this.ShippingUnit.Name = "ShippingUnit";
            this.ShippingUnit.ReadOnly = true;
            // 
            // ArrivalUnit
            // 
            this.ArrivalUnit.DataPropertyName = "ArrivalUnit";
            this.ArrivalUnit.HeaderText = "到货单位";
            this.ArrivalUnit.Name = "ArrivalUnit";
            this.ArrivalUnit.ReadOnly = true;
            // 
            // Freight
            // 
            this.Freight.DataPropertyName = "Freight";
            this.Freight.HeaderText = "货运";
            this.Freight.Name = "Freight";
            this.Freight.ReadOnly = true;
            // 
            // CarNumber
            // 
            this.CarNumber.DataPropertyName = "CarNumber";
            this.CarNumber.HeaderText = "车号";
            this.CarNumber.Name = "CarNumber";
            this.CarNumber.ReadOnly = true;
            // 
            // ShipName
            // 
            this.ShipName.DataPropertyName = "ShipName";
            this.ShipName.HeaderText = "船名";
            this.ShipName.Name = "ShipName";
            this.ShipName.ReadOnly = true;
            // 
            // BillOfLadingNumber
            // 
            this.BillOfLadingNumber.DataPropertyName = "BillOfLadingNumber";
            this.BillOfLadingNumber.HeaderText = "提货单";
            this.BillOfLadingNumber.Name = "BillOfLadingNumber";
            this.BillOfLadingNumber.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国别";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Brand
            // 
            this.Brand.DataPropertyName = "Brand";
            this.Brand.HeaderText = "品牌";
            this.Brand.Name = "Brand";
            this.Brand.ReadOnly = true;
            // 
            // quality
            // 
            this.quality.DataPropertyName = "quality";
            this.quality.HeaderText = "品质";
            this.quality.Name = "quality";
            this.quality.ReadOnly = true;
            // 
            // ProductionDate
            // 
            this.ProductionDate.DataPropertyName = "ProductionDate";
            this.ProductionDate.HeaderText = "生产日期";
            this.ProductionDate.Name = "ProductionDate";
            this.ProductionDate.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cmbBrand);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.cmbCountry);
            this.panel2.Controls.Add(this.dtppickuptime);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBillOfLadingNumber);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtShipName);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtCarNumber);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtFreight);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtArrivalUnit);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtShippingUnit);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtcode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(881, 77);
            this.panel2.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(653, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 67;
            this.label11.Text = "品牌";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(688, 43);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(100, 20);
            this.cmbBrand.TabIndex = 66;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(512, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 65;
            this.label10.Text = "国别";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(547, 43);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(100, 20);
            this.cmbCountry.TabIndex = 64;
            // 
            // dtppickuptime
            // 
            this.dtppickuptime.Location = new System.Drawing.Point(855, 43);
            this.dtppickuptime.Name = "dtppickuptime";
            this.dtppickuptime.Size = new System.Drawing.Size(100, 21);
            this.dtppickuptime.TabIndex = 63;
            this.dtppickuptime.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(796, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 62;
            this.label1.Text = "出货记录";
            this.label1.Visible = false;
            // 
            // txtBillOfLadingNumber
            // 
            this.txtBillOfLadingNumber.Location = new System.Drawing.Point(547, 13);
            this.txtBillOfLadingNumber.Name = "txtBillOfLadingNumber";
            this.txtBillOfLadingNumber.Size = new System.Drawing.Size(100, 21);
            this.txtBillOfLadingNumber.TabIndex = 61;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 60;
            this.label9.Text = "提货单";
            // 
            // txtShipName
            // 
            this.txtShipName.Location = new System.Drawing.Point(382, 40);
            this.txtShipName.Name = "txtShipName";
            this.txtShipName.Size = new System.Drawing.Size(100, 21);
            this.txtShipName.TabIndex = 59;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(347, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 58;
            this.label8.Text = "船名";
            // 
            // txtCarNumber
            // 
            this.txtCarNumber.Location = new System.Drawing.Point(382, 13);
            this.txtCarNumber.Name = "txtCarNumber";
            this.txtCarNumber.Size = new System.Drawing.Size(100, 21);
            this.txtCarNumber.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(347, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 56;
            this.label7.Text = "车号";
            // 
            // txtFreight
            // 
            this.txtFreight.Location = new System.Drawing.Point(237, 13);
            this.txtFreight.Name = "txtFreight";
            this.txtFreight.Size = new System.Drawing.Size(100, 21);
            this.txtFreight.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(202, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 52;
            this.label6.Text = "货运";
            // 
            // txtArrivalUnit
            // 
            this.txtArrivalUnit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtArrivalUnit.Location = new System.Drawing.Point(237, 40);
            this.txtArrivalUnit.Name = "txtArrivalUnit";
            this.txtArrivalUnit.ReadOnly = true;
            this.txtArrivalUnit.Size = new System.Drawing.Size(100, 21);
            this.txtArrivalUnit.TabIndex = 51;
            this.txtArrivalUnit.Click += new System.EventHandler(this.txtArrivalUnit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(178, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 50;
            this.label5.Text = "到货单位";
            // 
            // txtShippingUnit
            // 
            this.txtShippingUnit.Location = new System.Drawing.Point(71, 40);
            this.txtShippingUnit.Name = "txtShippingUnit";
            this.txtShippingUnit.Size = new System.Drawing.Size(100, 21);
            this.txtShippingUnit.TabIndex = 49;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 48;
            this.label4.Text = "发货位置";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(71, 13);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(100, 21);
            this.txtcode.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 44;
            this.label2.Text = "编号";
            // 
            // FormShippingRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(887, 543);
            this.Controls.Add(this.panel1);
            this.Name = "FormShippingRecords";
            this.Text = "出货记录";
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn pickuptime;
        private System.Windows.Forms.DataGridViewTextBoxColumn tonnage;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfPacks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippingUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArrivalUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Freight;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillOfLadingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brand;
        private System.Windows.Forms.DataGridViewTextBoxColumn quality;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtShippingUnit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtArrivalUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFreight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtShipName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCarNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBillOfLadingNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtppickuptime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbCountry;
    }
}