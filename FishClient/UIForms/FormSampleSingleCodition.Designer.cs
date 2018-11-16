namespace FishClient.UIForms
{
    partial class FormSampleSingleCodition
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
            this.txtBillOfLadingNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new UILibrary.SkinButtom();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtBillOfLadingNumber);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 243);
            this.panel1.TabIndex = 0;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(98, 58);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(131, 21);
            this.txtcode.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "编号";
            // 
            // txtBillOfLadingNumber
            // 
            this.txtBillOfLadingNumber.Location = new System.Drawing.Point(98, 96);
            this.txtBillOfLadingNumber.Name = "txtBillOfLadingNumber";
            this.txtBillOfLadingNumber.Size = new System.Drawing.Size(131, 21);
            this.txtBillOfLadingNumber.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "提单号";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(130, 134);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(99, 25);
            this.btnOk.TabIndex = 62;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // FormSampleSingleCodition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 276);
            this.Controls.Add(this.panel1);
            this.Name = "FormSampleSingleCodition";
            this.Text = "查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBillOfLadingNumber;
        private System.Windows.Forms.Label label3;
        private UILibrary.SkinButtom btnOk;
    }
}