namespace FishClient
{
    partial class FormSalesRContract
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHeTong = new UILibrary.SkinButtom();
            this.txtNumbering = new FishClient.UIControls.InputControl();
            this.label9 = new System.Windows.Forms.Label();
            this.txtdemand = new FishClient.UIControls.InputControl();
            this.txtsupplier = new FishClient.UIControls.InputControl();
            this.txtSignplace = new FishClient.UIControls.InputControl();
            this.txtcode = new FishClient.UIControls.InputControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Funit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Variety = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amonut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new FishClient.UIControls.CalendarColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpSigndate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.btnHeTong);
            this.panel1.Controls.Add(this.txtNumbering);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtdemand);
            this.panel1.Controls.Add(this.txtsupplier);
            this.panel1.Controls.Add(this.txtSignplace);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpSigndate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 286);
            this.panel1.TabIndex = 1;
            // 
            // btnHeTong
            // 
            this.btnHeTong.BackColor = System.Drawing.Color.Transparent;
            this.btnHeTong.ControlState = UILibrary.ControlState.Normal;
            this.btnHeTong.DownBack = null;
            this.btnHeTong.Location = new System.Drawing.Point(654, 240);
            this.btnHeTong.MouseBack = null;
            this.btnHeTong.Name = "btnHeTong";
            this.btnHeTong.NormlBack = null;
            this.btnHeTong.Size = new System.Drawing.Size(134, 23);
            this.btnHeTong.TabIndex = 268;
            this.btnHeTong.Text = "合同贴粘处(附件)";
            this.btnHeTong.UseVisualStyleBackColor = false;
            this.btnHeTong.Click += new System.EventHandler(this.btnHeTong_Click);
            // 
            // txtNumbering
            // 
            this.txtNumbering.Location = new System.Drawing.Point(71, 8);
            this.txtNumbering.Name = "txtNumbering";
            this.txtNumbering.ReadOnly = true;
            this.txtNumbering.Size = new System.Drawing.Size(150, 21);
            this.txtNumbering.TabIndex = 267;
            this.txtNumbering.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtNumbering.UnderlineColor = System.Drawing.Color.Black;
            this.txtNumbering.UnderlineWidth = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 266;
            this.label9.Text = "销售编号：";
            // 
            // txtdemand
            // 
            this.txtdemand.Location = new System.Drawing.Point(71, 62);
            this.txtdemand.Name = "txtdemand";
            this.txtdemand.ReadOnly = false;
            this.txtdemand.Size = new System.Drawing.Size(150, 21);
            this.txtdemand.TabIndex = 253;
            this.txtdemand.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtdemand.UnderlineColor = System.Drawing.Color.Black;
            this.txtdemand.UnderlineWidth = 1;
            // 
            // txtsupplier
            // 
            this.txtsupplier.Location = new System.Drawing.Point(71, 35);
            this.txtsupplier.Name = "txtsupplier";
            this.txtsupplier.ReadOnly = false;
            this.txtsupplier.Size = new System.Drawing.Size(150, 21);
            this.txtsupplier.TabIndex = 252;
            this.txtsupplier.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtsupplier.UnderlineColor = System.Drawing.Color.Black;
            this.txtsupplier.UnderlineWidth = 1;
            // 
            // txtSignplace
            // 
            this.txtSignplace.Location = new System.Drawing.Point(592, 62);
            this.txtSignplace.Name = "txtSignplace";
            this.txtSignplace.ReadOnly = false;
            this.txtSignplace.Size = new System.Drawing.Size(150, 21);
            this.txtSignplace.TabIndex = 251;
            this.txtSignplace.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtSignplace.UnderlineColor = System.Drawing.Color.Black;
            this.txtSignplace.UnderlineWidth = 1;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(592, 8);
            this.txtcode.Name = "txtcode";
            this.txtcode.ReadOnly = true;
            this.txtcode.Size = new System.Drawing.Size(150, 21);
            this.txtcode.TabIndex = 250;
            this.txtcode.TextColor = System.Drawing.SystemColors.WindowText;
            this.txtcode.UnderlineColor = System.Drawing.Color.Black;
            this.txtcode.UnderlineWidth = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 25;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.productname,
            this.Funit,
            this.Variety,
            this.Quantity,
            this.unitprice,
            this.amonut,
            this.date});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(632, 110);
            this.dataGridView1.TabIndex = 206;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.HeaderText = "鱼粉ID";
            this.product_id.Name = "product_id";
            this.product_id.ReadOnly = true;
            // 
            // productname
            // 
            this.productname.DataPropertyName = "productname";
            this.productname.HeaderText = "产品名称";
            this.productname.Name = "productname";
            this.productname.ReadOnly = true;
            this.productname.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Funit
            // 
            this.Funit.DataPropertyName = "Funit";
            this.Funit.HeaderText = "品质";
            this.Funit.Name = "Funit";
            this.Funit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Variety
            // 
            this.Variety.DataPropertyName = "Variety";
            this.Variety.HeaderText = "品种";
            this.Variety.Name = "Variety";
            this.Variety.ReadOnly = true;
            this.Variety.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Variety.Visible = false;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Quantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.Quantity.HeaderText = "重量（吨）";
            this.Quantity.Name = "Quantity";
            // 
            // unitprice
            // 
            this.unitprice.DataPropertyName = "unitprice";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.unitprice.DefaultCellStyle = dataGridViewCellStyle3;
            this.unitprice.HeaderText = "单价（元）";
            this.unitprice.Name = "unitprice";
            // 
            // amonut
            // 
            this.amonut.DataPropertyName = "Amonut";
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.amonut.DefaultCellStyle = dataGridViewCellStyle4;
            this.amonut.HeaderText = "金额（元）";
            this.amonut.Name = "amonut";
            this.amonut.ReadOnly = true;
            this.amonut.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // date
            // 
            this.date.HeaderText = "交货日期";
            this.date.Name = "date";
            this.date.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 12);
            this.label7.TabIndex = 205;
            this.label7.Text = "一、产品情况：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(809, 12);
            this.label6.TabIndex = 104;
            this.label6.Text = "根据《中华人民共和国合同法》及其他有关法律法规的规定，甲乙双方在平等、自愿、公平、诚实信用的基础上，就鱼粉定购的有关事宜达成如下协议。";
            // 
            // dtpSigndate
            // 
            this.dtpSigndate.Location = new System.Drawing.Point(592, 35);
            this.dtpSigndate.Name = "dtpSigndate";
            this.dtpSigndate.Size = new System.Drawing.Size(150, 21);
            this.dtpSigndate.TabIndex = 77;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 75;
            this.label4.Text = "需方：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 73;
            this.label5.Text = "供方：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "签约地点：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "签订日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(530, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 69;
            this.label1.Text = "合同编号：";
            // 
            // FormSalesRContract
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 344);
            this.Controls.Add(this.panel1);
            this.Name = "FormSalesRContract";
            this.Text = "现货销售合同";
            this.Load += new System.EventHandler(this.FormSalesRContract_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . DateTimePicker dtpSigndate;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . Label label5;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . Label label6;
        private System . Windows . Forms . DataGridView dataGridView1;
        private System . Windows . Forms . Label label7;
        private UIControls.InputControl txtcode;
        private UIControls.InputControl txtSignplace;
        private UIControls.InputControl txtdemand;
        private UIControls.InputControl txtsupplier;
        private UIControls.InputControl txtNumbering;
        private System.Windows.Forms.Label label9;
        private UILibrary.SkinButtom btnHeTong;
        private System.Windows.Forms.DataGridViewTextBoxColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn productname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Funit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Variety;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn amonut;
        private UIControls.CalendarColumn date;
    }
}