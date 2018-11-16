namespace FishClient
{
    partial class FormSampleSingle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPileAngle = new System.Windows.Forms.TextBox();
            this.txtBillOfLadingNumber = new System.Windows.Forms.TextBox();
            this.txtferryName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtptdate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPileAngle);
            this.panel1.Controls.Add(this.txtBillOfLadingNumber);
            this.panel1.Controls.Add(this.txtferryName);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 280);
            this.panel1.TabIndex = 1;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(152, 108);
            this.txtcode.Name = "txtcode";
            this.txtcode.ReadOnly = true;
            this.txtcode.Size = new System.Drawing.Size(131, 21);
            this.txtcode.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(117, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 34;
            this.label6.Text = "编号";
            // 
            // dtptdate
            // 
            this.dtptdate.Location = new System.Drawing.Point(63, 196);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(127, 21);
            this.dtptdate.TabIndex = 33;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(422, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "南信国际物流（上海）有限公司";
            // 
            // txtPileAngle
            // 
            this.txtPileAngle.Location = new System.Drawing.Point(364, 146);
            this.txtPileAngle.Name = "txtPileAngle";
            this.txtPileAngle.Size = new System.Drawing.Size(131, 21);
            this.txtPileAngle.TabIndex = 14;
            // 
            // txtBillOfLadingNumber
            // 
            this.txtBillOfLadingNumber.Location = new System.Drawing.Point(152, 146);
            this.txtBillOfLadingNumber.Name = "txtBillOfLadingNumber";
            this.txtBillOfLadingNumber.Size = new System.Drawing.Size(131, 21);
            this.txtBillOfLadingNumber.TabIndex = 13;
            // 
            // txtferryName
            // 
            this.txtferryName.Location = new System.Drawing.Point(364, 108);
            this.txtferryName.Name = "txtferryName";
            this.txtferryName.Size = new System.Drawing.Size(131, 21);
            this.txtferryName.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "库场桩角号";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "提单号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(329, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "船名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "龙吴营运操作部：\r\n\r\n       由我南信代理的客户来贵公司仓库看货，取样，请予以协助。";
            // 
            // FormSampleSingle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 338);
            this.Controls.Add(this.panel1);
            this.Name = "FormSampleSingle";
            this.Text = "取样单";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPileAngle;
        private System.Windows.Forms.TextBox txtBillOfLadingNumber;
        private System.Windows.Forms.TextBox txtferryName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtptdate;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label6;
    }
}