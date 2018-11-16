namespace FishClient.UIForms
{
    partial class FormBillofladingCondition
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
            this.btnOk = new UILibrary.SkinButtom();
            this.label2 = new System.Windows.Forms.Label();
            this.txtlistname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumbering = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtlistname);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNumbering);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 180);
            this.panel1.TabIndex = 63;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(142, 121);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(91, 25);
            this.btnOk.TabIndex = 67;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 66;
            this.label2.Text = "提货单：";
            // 
            // txtlistname
            // 
            this.txtlistname.Location = new System.Drawing.Point(105, 69);
            this.txtlistname.Name = "txtlistname";
            this.txtlistname.Size = new System.Drawing.Size(128, 21);
            this.txtlistname.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 64;
            this.label1.Text = "编  号：";
            // 
            // txtNumbering
            // 
            this.txtNumbering.Location = new System.Drawing.Point(105, 32);
            this.txtNumbering.Name = "txtNumbering";
            this.txtNumbering.Size = new System.Drawing.Size(128, 21);
            this.txtNumbering.TabIndex = 63;
            // 
            // FormBillofladingCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 213);
            this.Controls.Add(this.panel1);
            this.Name = "FormBillofladingCondition";
            this.Text = "提货单查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UILibrary.SkinButtom btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtlistname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumbering;
    }
}