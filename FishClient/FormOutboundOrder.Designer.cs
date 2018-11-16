namespace FishClient
{
    partial class FormOutboundOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtseNumber = new System.Windows.Forms.TextBox();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtunit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtshipName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtweight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtpileNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtcodeNumContract = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtcodeNum = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.txtpageNum = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbillName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtwaseHouse = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtremark = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtware = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtnotice = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtreceive = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnimage = new UILibrary.SkinButtom();
            this.txtFishMealId = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cmbBrands = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtspeci = new System.Windows.Forms.TextBox();
            this.txttype = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "出库单序号";
            // 
            // txtseNumber
            // 
            this.txtseNumber.Location = new System.Drawing.Point(91, 36);
            this.txtseNumber.Name = "txtseNumber";
            this.txtseNumber.Size = new System.Drawing.Size(132, 21);
            this.txtseNumber.TabIndex = 2;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(91, 63);
            this.txtcode.Name = "txtcode";
            this.txtcode.ReadOnly = true;
            this.txtcode.Size = new System.Drawing.Size(132, 21);
            this.txtcode.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "单号";
            // 
            // txtunit
            // 
            this.txtunit.Location = new System.Drawing.Point(91, 90);
            this.txtunit.Name = "txtunit";
            this.txtunit.ReadOnly = true;
            this.txtunit.Size = new System.Drawing.Size(132, 21);
            this.txtunit.TabIndex = 6;
            this.txtunit.DoubleClick += new System.EventHandler(this.txtunit_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "需方";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "产品种类";
            // 
            // txtshipName
            // 
            this.txtshipName.Location = new System.Drawing.Point(91, 144);
            this.txtshipName.Name = "txtshipName";
            this.txtshipName.Size = new System.Drawing.Size(132, 21);
            this.txtshipName.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "船名";
            // 
            // txtweight
            // 
            this.txtweight.Location = new System.Drawing.Point(91, 171);
            this.txtweight.Name = "txtweight";
            this.txtweight.Size = new System.Drawing.Size(132, 21);
            this.txtweight.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(56, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "重量";
            // 
            // txtpileNum
            // 
            this.txtpileNum.Location = new System.Drawing.Point(91, 198);
            this.txtpileNum.Name = "txtpileNum";
            this.txtpileNum.Size = new System.Drawing.Size(132, 21);
            this.txtpileNum.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(45, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "桩角号";
            // 
            // txtcodeNumContract
            // 
            this.txtcodeNumContract.Location = new System.Drawing.Point(375, 63);
            this.txtcodeNumContract.Name = "txtcodeNumContract";
            this.txtcodeNumContract.ReadOnly = true;
            this.txtcodeNumContract.Size = new System.Drawing.Size(132, 21);
            this.txtcodeNumContract.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(304, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "销售合同号";
            // 
            // txtcodeNum
            // 
            this.txtcodeNum.Location = new System.Drawing.Point(375, 36);
            this.txtcodeNum.Name = "txtcodeNum";
            this.txtcodeNum.ReadOnly = true;
            this.txtcodeNum.Size = new System.Drawing.Size(132, 21);
            this.txtcodeNum.TabIndex = 16;
            this.txtcodeNum.DoubleClick += new System.EventHandler(this.txtcodeNum_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(316, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "销售编号";
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(375, 90);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(132, 21);
            this.txtdate.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(316, 93);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "签约时间";
            // 
            // txtpageNum
            // 
            this.txtpageNum.Location = new System.Drawing.Point(375, 198);
            this.txtpageNum.Name = "txtpageNum";
            this.txtpageNum.Size = new System.Drawing.Size(132, 21);
            this.txtpageNum.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(340, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 27;
            this.label11.Text = "包数";
            // 
            // txtbillName
            // 
            this.txtbillName.Location = new System.Drawing.Point(375, 171);
            this.txtbillName.Name = "txtbillName";
            this.txtbillName.Size = new System.Drawing.Size(132, 21);
            this.txtbillName.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(328, 174);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "提单号";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(340, 147);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "品质";
            // 
            // txtwaseHouse
            // 
            this.txtwaseHouse.Location = new System.Drawing.Point(375, 117);
            this.txtwaseHouse.Name = "txtwaseHouse";
            this.txtwaseHouse.Size = new System.Drawing.Size(132, 21);
            this.txtwaseHouse.TabIndex = 22;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(340, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 21;
            this.label14.Text = "仓库";
            // 
            // txtremark
            // 
            this.txtremark.Location = new System.Drawing.Point(91, 250);
            this.txtremark.Multiline = true;
            this.txtremark.Name = "txtremark";
            this.txtremark.Size = new System.Drawing.Size(416, 121);
            this.txtremark.TabIndex = 30;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(56, 253);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 29;
            this.label15.Text = "备注";
            // 
            // txtware
            // 
            this.txtware.Location = new System.Drawing.Point(375, 377);
            this.txtware.Name = "txtware";
            this.txtware.Size = new System.Drawing.Size(132, 21);
            this.txtware.TabIndex = 34;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(328, 380);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "仓储费";
            // 
            // txtnotice
            // 
            this.txtnotice.Location = new System.Drawing.Point(91, 377);
            this.txtnotice.Name = "txtnotice";
            this.txtnotice.Size = new System.Drawing.Size(132, 21);
            this.txtnotice.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(32, 380);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 31;
            this.label17.Text = "发货须知";
            // 
            // txtreceive
            // 
            this.txtreceive.Location = new System.Drawing.Point(91, 404);
            this.txtreceive.Name = "txtreceive";
            this.txtreceive.Size = new System.Drawing.Size(132, 21);
            this.txtreceive.TabIndex = 36;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(44, 407);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(41, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "接受人";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnimage);
            this.panel1.Controls.Add(this.txtFishMealId);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.cmbBrands);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.cmbCountry);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.txtspeci);
            this.panel1.Controls.Add(this.txttype);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtreceive);
            this.panel1.Controls.Add(this.txtseNumber);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtware);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtnotice);
            this.panel1.Controls.Add(this.txtunit);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtremark);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtpageNum);
            this.panel1.Controls.Add(this.txtshipName);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtbillName);
            this.panel1.Controls.Add(this.txtweight);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtpileNum);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtwaseHouse);
            this.panel1.Controls.Add(this.txtcodeNum);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtcodeNumContract);
            this.panel1.Controls.Add(this.txtdate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 444);
            this.panel1.TabIndex = 37;
            // 
            // btnimage
            // 
            this.btnimage.BackColor = System.Drawing.Color.Transparent;
            this.btnimage.ControlState = UILibrary.ControlState.Normal;
            this.btnimage.DownBack = null;
            this.btnimage.Location = new System.Drawing.Point(375, 402);
            this.btnimage.MouseBack = null;
            this.btnimage.Name = "btnimage";
            this.btnimage.NormlBack = null;
            this.btnimage.Size = new System.Drawing.Size(132, 23);
            this.btnimage.TabIndex = 489;
            this.btnimage.Text = "出库单贴粘处(附件)";
            this.btnimage.UseVisualStyleBackColor = false;
            this.btnimage.Click += new System.EventHandler(this.btnimage_Click);
            // 
            // txtFishMealId
            // 
            this.txtFishMealId.Location = new System.Drawing.Point(91, 9);
            this.txtFishMealId.Name = "txtFishMealId";
            this.txtFishMealId.ReadOnly = true;
            this.txtFishMealId.Size = new System.Drawing.Size(132, 21);
            this.txtFishMealId.TabIndex = 488;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(44, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 487;
            this.label23.Text = "鱼粉ID";
            // 
            // cmbBrands
            // 
            this.cmbBrands.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrands.FormattingEnabled = true;
            this.cmbBrands.Location = new System.Drawing.Point(375, 225);
            this.cmbBrands.Name = "cmbBrands";
            this.cmbBrands.Size = new System.Drawing.Size(132, 20);
            this.cmbBrands.TabIndex = 486;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(340, 228);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 485;
            this.label25.Text = "品牌";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(91, 225);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(132, 20);
            this.cmbCountry.TabIndex = 484;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(56, 228);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(29, 12);
            this.label24.TabIndex = 483;
            this.label24.Text = "国别";
            // 
            // txtspeci
            // 
            this.txtspeci.Location = new System.Drawing.Point(375, 144);
            this.txtspeci.Name = "txtspeci";
            this.txtspeci.Size = new System.Drawing.Size(132, 21);
            this.txtspeci.TabIndex = 39;
            // 
            // txttype
            // 
            this.txttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txttype.FormattingEnabled = true;
            this.txttype.Location = new System.Drawing.Point(91, 117);
            this.txttype.Name = "txttype";
            this.txttype.Size = new System.Drawing.Size(132, 20);
            this.txttype.TabIndex = 38;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormOutboundOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 502);
            this.Controls.Add(this.panel1);
            this.Name = "FormOutboundOrder";
            this.Text = "出库单";
            this.Load += new System.EventHandler(this.FormOutboundOrder_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox txtseNumber;
        private System . Windows . Forms . TextBox txtcode;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . TextBox txtunit;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . TextBox txtshipName;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . TextBox txtweight;
        private System . Windows . Forms . Label label6;
        private System . Windows . Forms . TextBox txtpileNum;
        private System . Windows . Forms . Label label7;
        private System . Windows . Forms . TextBox txtcodeNumContract;
        private System . Windows . Forms . Label label8;
        private System . Windows . Forms . TextBox txtcodeNum;
        private System . Windows . Forms . Label label9;
        private System . Windows . Forms . DateTimePicker txtdate;
        private System . Windows . Forms . Label label10;
        private System . Windows . Forms . TextBox txtpageNum;
        private System . Windows . Forms . Label label11;
        private System . Windows . Forms . TextBox txtbillName;
        private System . Windows . Forms . Label label12;
        private System . Windows . Forms . Label label13;
        private System . Windows . Forms . TextBox txtwaseHouse;
        private System . Windows . Forms . Label label14;
        private System . Windows . Forms . TextBox txtremark;
        private System . Windows . Forms . Label label15;
        private System . Windows . Forms . TextBox txtware;
        private System . Windows . Forms . Label label16;
        private System . Windows . Forms . TextBox txtnotice;
        private System . Windows . Forms . Label label17;
        private System . Windows . Forms . TextBox txtreceive;
        private System . Windows . Forms . Label label18;
        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . ComboBox txttype;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . Windows . Forms . TextBox txtspeci;
        private System.Windows.Forms.ComboBox cmbBrands;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFishMealId;
        private System.Windows.Forms.Label label23;
        private UILibrary.SkinButtom btnimage;
    }
}