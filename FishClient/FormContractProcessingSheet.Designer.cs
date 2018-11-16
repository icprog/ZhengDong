namespace FishClient
{
    partial class FormContractProcessingSheet
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
            this.txtProcessing = new System.Windows.Forms.TextBox();
            this.dtptdate = new System.Windows.Forms.DateTimePicker();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTheReason = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcontractcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtProcessing);
            this.panel1.Controls.Add(this.dtptdate);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTheReason);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtcontractcode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 251);
            this.panel1.TabIndex = 1;
            // 
            // txtProcessing
            // 
            this.txtProcessing.Location = new System.Drawing.Point(99, 170);
            this.txtProcessing.Multiline = true;
            this.txtProcessing.Name = "txtProcessing";
            this.txtProcessing.Size = new System.Drawing.Size(205, 62);
            this.txtProcessing.TabIndex = 22;
            // 
            // dtptdate
            // 
            this.dtptdate.Location = new System.Drawing.Point(99, 75);
            this.dtptdate.Name = "dtptdate";
            this.dtptdate.Size = new System.Drawing.Size(100, 21);
            this.dtptdate.TabIndex = 21;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(99, 19);
            this.txtcode.Name = "txtcode";
            this.txtcode.ReadOnly = true;
            this.txtcode.Size = new System.Drawing.Size(100, 21);
            this.txtcode.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "编号日期：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "处理过程：";
            // 
            // txtTheReason
            // 
            this.txtTheReason.Location = new System.Drawing.Point(99, 102);
            this.txtTheReason.Multiline = true;
            this.txtTheReason.Name = "txtTheReason";
            this.txtTheReason.Size = new System.Drawing.Size(205, 62);
            this.txtTheReason.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "合同原因：";
            // 
            // txtcontractcode
            // 
            this.txtcontractcode.Location = new System.Drawing.Point(99, 48);
            this.txtcontractcode.Name = "txtcontractcode";
            this.txtcontractcode.Size = new System.Drawing.Size(100, 21);
            this.txtcontractcode.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "合同编号：";
            // 
            // FormContractProcessingSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 309);
            this.Controls.Add(this.panel1);
            this.Name = "FormContractProcessingSheet";
            this.Text = "问题处理结果记录单";
            this.Load += new System.EventHandler(this.FormContractProcessingSheet_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtProcessing;
        private System.Windows.Forms.DateTimePicker dtptdate;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTheReason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcontractcode;
        private System.Windows.Forms.Label label1;
    }
}