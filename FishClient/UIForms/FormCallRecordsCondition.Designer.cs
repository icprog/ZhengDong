namespace FishClient.UIForms
{
    partial class FormCallRecordsCondition
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
            this.txtCode = new UILibrary.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 121);
            this.panel1.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(139, 80);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(99, 25);
            this.btnOk.TabIndex = 65;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // txtCode
            // 
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCode.BackColor = System.Drawing.Color.Transparent;
            this.txtCode.Icon = null;
            this.txtCode.IconIsButton = false;
            this.txtCode.IsPasswordChat = '\0';
            this.txtCode.IsSystemPasswordChar = false;
            this.txtCode.LeftIcon = null;
            this.txtCode.Lines = new string[0];
            this.txtCode.Location = new System.Drawing.Point(99, 15);
            this.txtCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtCode.MaxLength = 32767;
            this.txtCode.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtCode.MouseBack = null;
            this.txtCode.Multiline = false;
            this.txtCode.Name = "txtCode";
            this.txtCode.NormlBack = null;
            this.txtCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtCode.ReadOnly = false;
            this.txtCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtCode.Size = new System.Drawing.Size(139, 28);
            this.txtCode.TabIndex = 64;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCode.WaterColor = System.Drawing.Color.DarkGray;
            this.txtCode.WaterText = "";
            this.txtCode.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 63;
            this.label1.Text = "记录单号：";
            // 
            // FormCallRecordsCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 154);
            this.Controls.Add(this.panel1);
            this.Name = "FormCallRecordsCondition";
            this.Text = "销售记录查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UILibrary.SkinButtom btnOk;
        private UILibrary.SkinTextBox txtCode;
        private System.Windows.Forms.Label label1;
    }
}