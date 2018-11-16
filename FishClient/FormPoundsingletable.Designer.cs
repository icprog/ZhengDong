namespace FishClient
{
    partial class FormPoundsingletable
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serialnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buyers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sellers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qualit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pileangle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BillOfLadingid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntothefactoryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dateofmanufacture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Carnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grossweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tareweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Competition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Goods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSellers = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtBuyers = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.cmbSpecification = new System.Windows.Forms.ComboBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtGoods = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.txtSerialnumber = new System.Windows.Forms.TextBox();
            this.txtCarnumber = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 591);
            this.panel1.TabIndex = 500;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 100);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(986, 491);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.Serialnumber,
            this.Buyers,
            this.Sellers,
            this.Country,
            this.Qualit,
            this.PName,
            this.Quantity,
            this.Pileangle,
            this.Shipno,
            this.BillOfLadingid,
            this.IntothefactoryDate,
            this.Dateofmanufacture,
            this.Carnumber,
            this.Grossweight,
            this.Tareweight,
            this.Competition,
            this.Goods,
            this.Owner,
            this.Address,
            this.id,
            this.Remarks});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(986, 491);
            this.dataGridView1.TabIndex = 95;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "Code";
            this.Code.HeaderText = "序号";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 80;
            // 
            // Serialnumber
            // 
            this.Serialnumber.DataPropertyName = "Serialnumber";
            this.Serialnumber.HeaderText = "磅单序号";
            this.Serialnumber.Name = "Serialnumber";
            this.Serialnumber.ReadOnly = true;
            // 
            // Buyers
            // 
            this.Buyers.DataPropertyName = "Buyers";
            this.Buyers.HeaderText = "采购商";
            this.Buyers.Name = "Buyers";
            this.Buyers.ReadOnly = true;
            // 
            // Sellers
            // 
            this.Sellers.DataPropertyName = "Sellers";
            this.Sellers.HeaderText = "销售商";
            this.Sellers.Name = "Sellers";
            this.Sellers.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国别";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Qualit
            // 
            this.Qualit.DataPropertyName = "Qualit";
            this.Qualit.HeaderText = "品质规格";
            this.Qualit.Name = "Qualit";
            this.Qualit.ReadOnly = true;
            // 
            // PName
            // 
            this.PName.DataPropertyName = "PName";
            this.PName.HeaderText = "品名";
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "数量";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            // 
            // Pileangle
            // 
            this.Pileangle.DataPropertyName = "Pileangle";
            this.Pileangle.HeaderText = "桩角号";
            this.Pileangle.Name = "Pileangle";
            this.Pileangle.ReadOnly = true;
            // 
            // Shipno
            // 
            this.Shipno.DataPropertyName = "Shipno";
            this.Shipno.HeaderText = "船名";
            this.Shipno.Name = "Shipno";
            this.Shipno.ReadOnly = true;
            // 
            // BillOfLadingid
            // 
            this.BillOfLadingid.DataPropertyName = "BillOfLadingid";
            this.BillOfLadingid.HeaderText = "提单号";
            this.BillOfLadingid.Name = "BillOfLadingid";
            this.BillOfLadingid.ReadOnly = true;
            // 
            // IntothefactoryDate
            // 
            this.IntothefactoryDate.DataPropertyName = "IntothefactoryDate";
            this.IntothefactoryDate.HeaderText = "进厂日期";
            this.IntothefactoryDate.Name = "IntothefactoryDate";
            this.IntothefactoryDate.ReadOnly = true;
            this.IntothefactoryDate.Width = 120;
            // 
            // Dateofmanufacture
            // 
            this.Dateofmanufacture.DataPropertyName = "Dateofmanufacture";
            this.Dateofmanufacture.HeaderText = "出厂日期";
            this.Dateofmanufacture.Name = "Dateofmanufacture";
            this.Dateofmanufacture.ReadOnly = true;
            this.Dateofmanufacture.Width = 120;
            // 
            // Carnumber
            // 
            this.Carnumber.DataPropertyName = "Carnumber";
            this.Carnumber.HeaderText = "车号";
            this.Carnumber.Name = "Carnumber";
            this.Carnumber.ReadOnly = true;
            this.Carnumber.Width = 60;
            // 
            // Grossweight
            // 
            this.Grossweight.DataPropertyName = "Grossweight";
            this.Grossweight.HeaderText = "毛重";
            this.Grossweight.Name = "Grossweight";
            this.Grossweight.ReadOnly = true;
            this.Grossweight.Width = 60;
            // 
            // Tareweight
            // 
            this.Tareweight.DataPropertyName = "Tareweight";
            this.Tareweight.HeaderText = "皮重";
            this.Tareweight.Name = "Tareweight";
            this.Tareweight.ReadOnly = true;
            this.Tareweight.Width = 60;
            // 
            // Competition
            // 
            this.Competition.DataPropertyName = "Competition";
            this.Competition.HeaderText = "净重";
            this.Competition.Name = "Competition";
            this.Competition.ReadOnly = true;
            this.Competition.Width = 60;
            // 
            // Goods
            // 
            this.Goods.DataPropertyName = "Goods";
            this.Goods.HeaderText = "货品";
            this.Goods.Name = "Goods";
            this.Goods.ReadOnly = true;
            this.Goods.Width = 60;
            // 
            // Owner
            // 
            this.Owner.DataPropertyName = "Owner";
            this.Owner.HeaderText = "货主";
            this.Owner.Name = "Owner";
            this.Owner.ReadOnly = true;
            this.Owner.Width = 60;
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "地址";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
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
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtSellers);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.txtBuyers);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.cmbName);
            this.panel2.Controls.Add(this.cmbSpecification);
            this.panel2.Controls.Add(this.cmbCountry);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.txtCode);
            this.panel2.Controls.Add(this.txtGoods);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtOwner);
            this.panel2.Controls.Add(this.txtSerialnumber);
            this.panel2.Controls.Add(this.txtCarnumber);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(986, 100);
            this.panel2.TabIndex = 500;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 164;
            this.label3.Text = "清空";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtSellers
            // 
            this.txtSellers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSellers.Location = new System.Drawing.Point(239, 60);
            this.txtSellers.Name = "txtSellers";
            this.txtSellers.ReadOnly = true;
            this.txtSellers.Size = new System.Drawing.Size(100, 21);
            this.txtSellers.TabIndex = 163;
            this.txtSellers.Click += new System.EventHandler(this.txtSellers_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(191, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 162;
            this.label17.Text = "销售商：";
            // 
            // txtBuyers
            // 
            this.txtBuyers.AccessibleDescription = "";
            this.txtBuyers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtBuyers.Location = new System.Drawing.Point(62, 60);
            this.txtBuyers.Name = "txtBuyers";
            this.txtBuyers.ReadOnly = true;
            this.txtBuyers.Size = new System.Drawing.Size(100, 21);
            this.txtBuyers.TabIndex = 161;
            this.txtBuyers.Click += new System.EventHandler(this.txtBuyers_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(15, 63);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 160;
            this.label16.Text = "采购商：";
            // 
            // cmbName
            // 
            this.cmbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Location = new System.Drawing.Point(869, 26);
            this.cmbName.Name = "cmbName";
            this.cmbName.Size = new System.Drawing.Size(100, 20);
            this.cmbName.TabIndex = 158;
            this.cmbName.Visible = false;
            // 
            // cmbSpecification
            // 
            this.cmbSpecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecification.FormattingEnabled = true;
            this.cmbSpecification.Location = new System.Drawing.Point(407, 60);
            this.cmbSpecification.Name = "cmbSpecification";
            this.cmbSpecification.Size = new System.Drawing.Size(100, 20);
            this.cmbSpecification.TabIndex = 159;
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(558, 60);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(100, 20);
            this.cmbCountry.TabIndex = 157;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(349, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 156;
            this.label12.Text = "品质规格：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(835, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 155;
            this.label13.Text = "品名：";
            this.label13.Visible = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(523, 63);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 154;
            this.label14.Text = "国别：";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(62, 25);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 21);
            this.txtCode.TabIndex = 99;
            // 
            // txtGoods
            // 
            this.txtGoods.Location = new System.Drawing.Point(558, 25);
            this.txtGoods.Name = "txtGoods";
            this.txtGoods.Size = new System.Drawing.Size(100, 21);
            this.txtGoods.TabIndex = 96;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(172, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 98;
            this.label2.Text = "磅单序号：";
            // 
            // txtOwner
            // 
            this.txtOwner.Location = new System.Drawing.Point(407, 25);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(100, 21);
            this.txtOwner.TabIndex = 96;
            // 
            // txtSerialnumber
            // 
            this.txtSerialnumber.Location = new System.Drawing.Point(239, 25);
            this.txtSerialnumber.Name = "txtSerialnumber";
            this.txtSerialnumber.Size = new System.Drawing.Size(100, 21);
            this.txtSerialnumber.TabIndex = 97;
            // 
            // txtCarnumber
            // 
            this.txtCarnumber.Location = new System.Drawing.Point(698, 25);
            this.txtCarnumber.Name = "txtCarnumber";
            this.txtCarnumber.Size = new System.Drawing.Size(100, 21);
            this.txtCarnumber.TabIndex = 96;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(523, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 96;
            this.label8.Text = "货名：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(372, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "货主：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(664, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "车号：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "序号：";
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
            // FormPoundsingletable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 649);
            this.Controls.Add(this.panel1);
            this.Name = "FormPoundsingletable";
            this.Text = "磅单表";
            this.Load += new System.EventHandler(this.FormPoundsingletable_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtGoods;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOwner;
        private System.Windows.Forms.TextBox txtSerialnumber;
        private System.Windows.Forms.TextBox txtCarnumber;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.ComboBox cmbSpecification;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSellers;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtBuyers;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serialnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Buyers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sellers;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qualit;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pileangle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipno;
        private System.Windows.Forms.DataGridViewTextBoxColumn BillOfLadingid;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntothefactoryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dateofmanufacture;
        private System.Windows.Forms.DataGridViewTextBoxColumn Carnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grossweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tareweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Competition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}