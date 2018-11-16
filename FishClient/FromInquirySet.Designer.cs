namespace FishClient
{
    partial class FromInquirySet
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
            this.labelWeight = new System.Windows.Forms.Label();
            this.labelNumber = new System.Windows.Forms.Label();
            this.texWeight = new System.Windows.Forms.TextBox();
            this.texNumber = new System.Windows.Forms.TextBox();
            this.labelRemark = new System.Windows.Forms.Label();
            this.richRemark = new System.Windows.Forms.RichTextBox();
            this.texExchangerate = new System.Windows.Forms.TextBox();
            this.labelExchangerate = new System.Windows.Forms.Label();
            this.texRmb = new System.Windows.Forms.TextBox();
            this.labelRmb = new System.Windows.Forms.Label();
            this.texDollarprice = new System.Windows.Forms.TextBox();
            this.labelDollarprice = new System.Windows.Forms.Label();
            this.labelDatetime = new System.Windows.Forms.Label();
            this.dateTimeP = new System.Windows.Forms.DateTimePicker();
            this.butOk = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelWeight
            // 
            this.labelWeight.AutoSize = true;
            this.labelWeight.Location = new System.Drawing.Point(26, 17);
            this.labelWeight.Name = "labelWeight";
            this.labelWeight.Size = new System.Drawing.Size(41, 12);
            this.labelWeight.TabIndex = 0;
            this.labelWeight.Text = "重量：";
            // 
            // labelNumber
            // 
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(26, 54);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(41, 12);
            this.labelNumber.TabIndex = 1;
            this.labelNumber.Text = "数量：";
            // 
            // texWeight
            // 
            this.texWeight.Location = new System.Drawing.Point(73, 14);
            this.texWeight.Name = "texWeight";
            this.texWeight.Size = new System.Drawing.Size(161, 21);
            this.texWeight.TabIndex = 2;
            // 
            // texNumber
            // 
            this.texNumber.Location = new System.Drawing.Point(73, 51);
            this.texNumber.Name = "texNumber";
            this.texNumber.Size = new System.Drawing.Size(161, 21);
            this.texNumber.TabIndex = 3;
            // 
            // labelRemark
            // 
            this.labelRemark.AutoSize = true;
            this.labelRemark.Location = new System.Drawing.Point(26, 239);
            this.labelRemark.Name = "labelRemark";
            this.labelRemark.Size = new System.Drawing.Size(41, 12);
            this.labelRemark.TabIndex = 4;
            this.labelRemark.Text = "备注：";
            // 
            // richRemark
            // 
            this.richRemark.Location = new System.Drawing.Point(73, 236);
            this.richRemark.Name = "richRemark";
            this.richRemark.Size = new System.Drawing.Size(161, 96);
            this.richRemark.TabIndex = 5;
            this.richRemark.Text = "";
            // 
            // texExchangerate
            // 
            this.texExchangerate.Location = new System.Drawing.Point(73, 88);
            this.texExchangerate.Name = "texExchangerate";
            this.texExchangerate.Size = new System.Drawing.Size(161, 21);
            this.texExchangerate.TabIndex = 7;
            // 
            // labelExchangerate
            // 
            this.labelExchangerate.AutoSize = true;
            this.labelExchangerate.Location = new System.Drawing.Point(26, 91);
            this.labelExchangerate.Name = "labelExchangerate";
            this.labelExchangerate.Size = new System.Drawing.Size(41, 12);
            this.labelExchangerate.TabIndex = 6;
            this.labelExchangerate.Text = "汇率：";
            // 
            // texRmb
            // 
            this.texRmb.Location = new System.Drawing.Point(73, 125);
            this.texRmb.Name = "texRmb";
            this.texRmb.Size = new System.Drawing.Size(161, 21);
            this.texRmb.TabIndex = 9;
            // 
            // labelRmb
            // 
            this.labelRmb.AutoSize = true;
            this.labelRmb.Location = new System.Drawing.Point(14, 128);
            this.labelRmb.Name = "labelRmb";
            this.labelRmb.Size = new System.Drawing.Size(53, 12);
            this.labelRmb.TabIndex = 8;
            this.labelRmb.Text = "人名币：";
            // 
            // texDollarprice
            // 
            this.texDollarprice.Location = new System.Drawing.Point(73, 162);
            this.texDollarprice.Name = "texDollarprice";
            this.texDollarprice.Size = new System.Drawing.Size(161, 21);
            this.texDollarprice.TabIndex = 11;
            // 
            // labelDollarprice
            // 
            this.labelDollarprice.AutoSize = true;
            this.labelDollarprice.Location = new System.Drawing.Point(14, 165);
            this.labelDollarprice.Name = "labelDollarprice";
            this.labelDollarprice.Size = new System.Drawing.Size(53, 12);
            this.labelDollarprice.TabIndex = 10;
            this.labelDollarprice.Text = "美元价：";
            // 
            // labelDatetime
            // 
            this.labelDatetime.AutoSize = true;
            this.labelDatetime.Location = new System.Drawing.Point(26, 205);
            this.labelDatetime.Name = "labelDatetime";
            this.labelDatetime.Size = new System.Drawing.Size(41, 12);
            this.labelDatetime.TabIndex = 12;
            this.labelDatetime.Text = "日期：";
            // 
            // dateTimeP
            // 
            this.dateTimeP.Location = new System.Drawing.Point(73, 199);
            this.dateTimeP.Name = "dateTimeP";
            this.dateTimeP.Size = new System.Drawing.Size(161, 21);
            this.dateTimeP.TabIndex = 13;
            // 
            // butOk
            // 
            this.butOk.AutoSize = true;
            this.butOk.Location = new System.Drawing.Point(28, 347);
            this.butOk.Name = "butOk";
            this.butOk.Size = new System.Drawing.Size(70, 28);
            this.butOk.TabIndex = 14;
            this.butOk.Text = "确定";
            this.butOk.UseVisualStyleBackColor = true;
            this.butOk.Click += new System.EventHandler(this.butOk_Click);
            // 
            // butCancel
            // 
            this.butCancel.AutoSize = true;
            this.butCancel.Location = new System.Drawing.Point(164, 347);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(70, 28);
            this.butCancel.TabIndex = 15;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // FromInquirySet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 384);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOk);
            this.Controls.Add(this.dateTimeP);
            this.Controls.Add(this.labelDatetime);
            this.Controls.Add(this.texDollarprice);
            this.Controls.Add(this.labelDollarprice);
            this.Controls.Add(this.texRmb);
            this.Controls.Add(this.labelRmb);
            this.Controls.Add(this.texExchangerate);
            this.Controls.Add(this.labelExchangerate);
            this.Controls.Add(this.richRemark);
            this.Controls.Add(this.labelRemark);
            this.Controls.Add(this.texNumber);
            this.Controls.Add(this.texWeight);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.labelWeight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FromInquirySet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FromInquirySet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Label labelWeight;
        private System . Windows . Forms . Label labelNumber;
        private System . Windows . Forms . TextBox texWeight;
        private System . Windows . Forms . TextBox texNumber;
        private System . Windows . Forms . Label labelRemark;
        private System . Windows . Forms . RichTextBox richRemark;
        private System . Windows . Forms . TextBox texExchangerate;
        private System . Windows . Forms . Label labelExchangerate;
        private System . Windows . Forms . TextBox texRmb;
        private System . Windows . Forms . Label labelRmb;
        private System . Windows . Forms . TextBox texDollarprice;
        private System . Windows . Forms . Label labelDollarprice;
        private System . Windows . Forms . Label labelDatetime;
        private System . Windows . Forms . DateTimePicker dateTimeP;
        private System . Windows . Forms . Button butOk;
        private System . Windows . Forms . Button butCancel;
        private System . Windows . Forms . ErrorProvider errorProvider1;
    }
}