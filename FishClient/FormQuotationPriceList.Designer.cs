namespace FishClient
{
    partial class FormQuotationPriceList
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
            this.fishId = new System.Windows.Forms.TextBox();
            this.tvn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.las = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.brand = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.das = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ash = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.protein = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.salt = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.histamine = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.qualitySpe = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.remark = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.FFA = new System.Windows.Forms.TextBox();
            this.XNfishId = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.codeNumSales = new System.Windows.Forms.TextBox();
            this.txtdataForm = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.country = new System.Windows.Forms.ComboBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 189);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "鱼粉Id";
            // 
            // fishId
            // 
            this.fishId.Location = new System.Drawing.Point(102, 186);
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            this.fishId.Size = new System.Drawing.Size(118, 21);
            this.fishId.TabIndex = 3;
            this.fishId.DoubleClick += new System.EventHandler(this.fishId_DoubleClick);
            // 
            // tvn
            // 
            this.tvn.Location = new System.Drawing.Point(457, 61);
            this.tvn.Name = "tvn";
            this.tvn.Size = new System.Drawing.Size(118, 21);
            this.tvn.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "TVN";
            // 
            // las
            // 
            this.las.Location = new System.Drawing.Point(651, 142);
            this.las.Name = "las";
            this.las.Size = new System.Drawing.Size(118, 21);
            this.las.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "赖氨酸";
            // 
            // brand
            // 
            this.brand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.brand.FormattingEnabled = true;
            this.brand.Location = new System.Drawing.Point(289, 143);
            this.brand.Name = "brand";
            this.brand.Size = new System.Drawing.Size(118, 20);
            this.brand.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "品牌";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(254, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "国别";
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(289, 22);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(118, 21);
            this.price.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(254, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 24;
            this.label7.Text = "单价";
            // 
            // das
            // 
            this.das.Location = new System.Drawing.Point(651, 101);
            this.das.Name = "das";
            this.das.Size = new System.Drawing.Size(118, 21);
            this.das.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(604, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 30;
            this.label9.Text = "蛋氨酸";
            // 
            // ash
            // 
            this.ash.Location = new System.Drawing.Point(651, 22);
            this.ash.Name = "ash";
            this.ash.Size = new System.Drawing.Size(118, 21);
            this.ash.TabIndex = 37;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(616, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "灰份";
            // 
            // protein
            // 
            this.protein.Location = new System.Drawing.Point(457, 22);
            this.protein.Name = "protein";
            this.protein.Size = new System.Drawing.Size(118, 21);
            this.protein.TabIndex = 35;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(422, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 34;
            this.label13.Text = "蛋白";
            // 
            // salt
            // 
            this.salt.Location = new System.Drawing.Point(457, 142);
            this.salt.Name = "salt";
            this.salt.Size = new System.Drawing.Size(118, 21);
            this.salt.TabIndex = 45;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(422, 145);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "盐份";
            // 
            // histamine
            // 
            this.histamine.Location = new System.Drawing.Point(457, 101);
            this.histamine.Name = "histamine";
            this.histamine.Size = new System.Drawing.Size(118, 21);
            this.histamine.TabIndex = 43;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(422, 104);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 42;
            this.label16.Text = "组胺";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(67, 63);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 40;
            this.label17.Text = "日期";
            // 
            // qualitySpe
            // 
            this.qualitySpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.qualitySpe.FormattingEnabled = true;
            this.qualitySpe.Location = new System.Drawing.Point(289, 102);
            this.qualitySpe.Name = "qualitySpe";
            this.qualitySpe.Size = new System.Drawing.Size(118, 20);
            this.qualitySpe.TabIndex = 39;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(230, 105);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 38;
            this.label18.Text = "品质规格";
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(102, 61);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(118, 21);
            this.date.TabIndex = 46;
            // 
            // remark
            // 
            this.remark.Location = new System.Drawing.Point(102, 236);
            this.remark.Multiline = true;
            this.remark.Name = "remark";
            this.remark.Size = new System.Drawing.Size(667, 154);
            this.remark.TabIndex = 48;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(67, 239);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 47;
            this.label20.Text = "备注";
            // 
            // code
            // 
            this.code.Location = new System.Drawing.Point(102, 22);
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Size = new System.Drawing.Size(118, 21);
            this.code.TabIndex = 50;
            this.code.DoubleClick += new System.EventHandler(this.code_DoubleClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(67, 25);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 49;
            this.label19.Text = "单号";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.FFA);
            this.panel1.Controls.Add(this.XNfishId);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.codeNumSales);
            this.panel1.Controls.Add(this.txtdataForm);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.code);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.fishId);
            this.panel1.Controls.Add(this.remark);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.date);
            this.panel1.Controls.Add(this.salt);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.histamine);
            this.panel1.Controls.Add(this.tvn);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.las);
            this.panel1.Controls.Add(this.qualitySpe);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.country);
            this.panel1.Controls.Add(this.ash);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.brand);
            this.panel1.Controls.Add(this.protein);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.price);
            this.panel1.Controls.Add(this.das);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(788, 425);
            this.panel1.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(581, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 58;
            this.label2.Text = "游离脂肪酸";
            // 
            // FFA
            // 
            this.FFA.Location = new System.Drawing.Point(651, 64);
            this.FFA.Name = "FFA";
            this.FFA.Size = new System.Drawing.Size(118, 21);
            this.FFA.TabIndex = 59;
            // 
            // XNfishId
            // 
            this.XNfishId.Location = new System.Drawing.Point(289, 186);
            this.XNfishId.Name = "XNfishId";
            this.XNfishId.ReadOnly = true;
            this.XNfishId.Size = new System.Drawing.Size(118, 21);
            this.XNfishId.TabIndex = 57;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(220, 189);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(65, 12);
            this.label23.TabIndex = 55;
            this.label23.Text = "虚拟鱼粉Id";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(19, 104);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 12);
            this.label22.TabIndex = 53;
            this.label22.Text = "销售申请单号";
            // 
            // codeNumSales
            // 
            this.codeNumSales.Location = new System.Drawing.Point(102, 101);
            this.codeNumSales.Name = "codeNumSales";
            this.codeNumSales.ReadOnly = true;
            this.codeNumSales.Size = new System.Drawing.Size(118, 21);
            this.codeNumSales.TabIndex = 54;
            // 
            // txtdataForm
            // 
            this.txtdataForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtdataForm.FormattingEnabled = true;
            this.txtdataForm.Location = new System.Drawing.Point(102, 143);
            this.txtdataForm.Name = "txtdataForm";
            this.txtdataForm.Size = new System.Drawing.Size(118, 20);
            this.txtdataForm.TabIndex = 52;
            this.txtdataForm.SelectedValueChanged += new System.EventHandler(this.txtdataForm_SelectedValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(43, 149);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 51;
            this.label21.Text = "数据来源";
            // 
            // country
            // 
            this.country.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.country.FormattingEnabled = true;
            this.country.Location = new System.Drawing.Point(289, 61);
            this.country.Name = "country";
            this.country.Size = new System.Drawing.Size(118, 20);
            this.country.TabIndex = 21;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FormQuotationPriceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 483);
            this.Controls.Add(this.panel1);
            this.Name = "FormQuotationPriceList";
            this.Text = "行情定价单";
            this.Load += new System.EventHandler(this.FormQuotationPriceList_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox fishId;
        private System . Windows . Forms . TextBox tvn;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . TextBox las;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . ComboBox brand;
        private System . Windows . Forms . Label label10;
        private System . Windows . Forms . Label label6;
        private System . Windows . Forms . TextBox price;
        private System . Windows . Forms . Label label7;
        private System . Windows . Forms . TextBox das;
        private System . Windows . Forms . Label label9;
        private System . Windows . Forms . TextBox ash;
        private System . Windows . Forms . Label label12;
        private System . Windows . Forms . TextBox protein;
        private System . Windows . Forms . Label label13;
        private System . Windows . Forms . TextBox salt;
        private System . Windows . Forms . Label label15;
        private System . Windows . Forms . TextBox histamine;
        private System . Windows . Forms . Label label16;
        private System . Windows . Forms . Label label17;
        private System . Windows . Forms . ComboBox qualitySpe;
        private System . Windows . Forms . Label label18;
        private System . Windows . Forms . DateTimePicker date;
        private System . Windows . Forms . TextBox remark;
        private System . Windows . Forms . Label label20;
        private System . Windows . Forms . TextBox code;
        private System . Windows . Forms . Label label19;
        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . Label label21;
        private System . Windows . Forms . ComboBox txtdataForm;
        private System . Windows . Forms . Label label22;
        private System . Windows . Forms . TextBox codeNumSales;
        private System . Windows . Forms . ErrorProvider errorProvider1;
        private System . Windows . Forms . ComboBox country;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox XNfishId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FFA;
    }
}