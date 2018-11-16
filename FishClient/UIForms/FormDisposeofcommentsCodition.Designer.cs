namespace FishClient.UIForms
{
    partial class FormDisposeofcommentsCodition
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
            this.txtFilenumber = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.btnOk = new UILibrary.SkinButtom();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFilenumber);
            this.panel1.Controls.Add(this.label58);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.label56);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 229);
            this.panel1.TabIndex = 0;
            // 
            // txtFilenumber
            // 
            this.txtFilenumber.Location = new System.Drawing.Point(94, 95);
            this.txtFilenumber.Name = "txtFilenumber";
            this.txtFilenumber.Size = new System.Drawing.Size(144, 21);
            this.txtFilenumber.TabIndex = 144;
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(29, 98);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(65, 12);
            this.label58.TabIndex = 143;
            this.label58.Text = "档案编号：";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(147, 147);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(91, 25);
            this.btnOk.TabIndex = 142;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(94, 56);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(144, 21);
            this.txtcode.TabIndex = 141;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(53, 59);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(41, 12);
            this.label56.TabIndex = 140;
            this.label56.Text = "编号：";
            // 
            // FormDisposeofcommentsCodition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Name = "FormDisposeofcommentsCodition";
            this.Text = "处理意见查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFilenumber;
        private System.Windows.Forms.Label label58;
        private UILibrary.SkinButtom btnOk;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label56;
    }
}