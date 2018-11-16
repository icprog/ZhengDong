namespace FishClient
{
    partial class FormReview
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
            this.label2 = new System.Windows.Forms.Label();
            this.richOpinion = new System.Windows.Forms.RichTextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioInform = new System.Windows.Forms.RadioButton();
            this.radioAdopt = new System.Windows.Forms.RadioButton();
            this.rabExamine = new System.Windows.Forms.RadioButton();
            this.texReview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "送审意见";
            // 
            // richOpinion
            // 
            this.richOpinion.Location = new System.Drawing.Point(18, 175);
            this.richOpinion.Name = "richOpinion";
            this.richOpinion.Size = new System.Drawing.Size(317, 105);
            this.richOpinion.TabIndex = 5;
            this.richOpinion.Text = "";
            // 
            // btnOk
            // 
            this.btnOk.AutoSize = true;
            this.btnOk.Location = new System.Drawing.Point(20, 302);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 30);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Location = new System.Drawing.Point(182, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioInform);
            this.panel1.Controls.Add(this.radioAdopt);
            this.panel1.Controls.Add(this.rabExamine);
            this.panel1.Controls.Add(this.texReview);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.richOpinion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 343);
            this.panel1.TabIndex = 8;
            // 
            // radioInform
            // 
            this.radioInform.AutoSize = true;
            this.radioInform.Location = new System.Drawing.Point(210, 144);
            this.radioInform.Name = "radioInform";
            this.radioInform.Size = new System.Drawing.Size(47, 16);
            this.radioInform.TabIndex = 12;
            this.radioInform.TabStop = true;
            this.radioInform.Text = "告知";
            this.radioInform.UseVisualStyleBackColor = true;
            this.radioInform.Visible = false;
            // 
            // radioAdopt
            // 
            this.radioAdopt.AutoSize = true;
            this.radioAdopt.Location = new System.Drawing.Point(86, 144);
            this.radioAdopt.Name = "radioAdopt";
            this.radioAdopt.Size = new System.Drawing.Size(47, 16);
            this.radioAdopt.TabIndex = 11;
            this.radioAdopt.TabStop = true;
            this.radioAdopt.Text = "通过";
            this.radioAdopt.UseVisualStyleBackColor = true;
            this.radioAdopt.Visible = false;
            // 
            // rabExamine
            // 
            this.rabExamine.AutoSize = true;
            this.rabExamine.Location = new System.Drawing.Point(268, 110);
            this.rabExamine.Name = "rabExamine";
            this.rabExamine.Size = new System.Drawing.Size(47, 16);
            this.rabExamine.TabIndex = 10;
            this.rabExamine.TabStop = true;
            this.rabExamine.Text = "审核";
            this.rabExamine.UseVisualStyleBackColor = true;
            // 
            // texReview
            // 
            this.texReview.Location = new System.Drawing.Point(75, 15);
            this.texReview.Multiline = true;
            this.texReview.Name = "texReview";
            this.texReview.ReadOnly = true;
            this.texReview.Size = new System.Drawing.Size(260, 74);
            this.texReview.TabIndex = 9;
            this.texReview.Click += new System.EventHandler(this.texReview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "送审对象";
            // 
            // FormReview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 401);
            this.Controls.Add(this.panel1);
            this.Name = "FormReview";
            this.Text = "送审";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . RichTextBox richOpinion;
        private System . Windows . Forms . Button btnOk;
        private System . Windows . Forms . Button btnCancel;
        private System . Windows . Forms . Panel panel1;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox texReview;
        private System . Windows . Forms . RadioButton rabExamine;
        private System . Windows . Forms . RadioButton radioInform;
        private System . Windows . Forms . RadioButton radioAdopt;
    }
}