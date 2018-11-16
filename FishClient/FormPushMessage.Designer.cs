namespace FishClient
{
    partial class FormPushMessage
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.columnControl1 = new UILibrary.ColumnControl();
            this.lklSeeAll = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.columnControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(286, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // columnControl1
            // 
            this.columnControl1.BackColor = System.Drawing.Color.Transparent;
            this.columnControl1.Controls.Add(this.lblTime);
            this.columnControl1.Controls.Add(this.lklSeeAll);
            this.columnControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.columnControl1.Font = new System.Drawing.Font("宋体", 3F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.columnControl1.LineColor = System.Drawing.Color.Gray;
            this.columnControl1.LineWidth = 1F;
            this.columnControl1.Location = new System.Drawing.Point(0, 116);
            this.columnControl1.Name = "columnControl1";
            this.columnControl1.Size = new System.Drawing.Size(286, 36);
            this.columnControl1.TabIndex = 1;
            this.columnControl1.Title = "";
            // 
            // lklSeeAll
            // 
            this.lklSeeAll.Dock = System.Windows.Forms.DockStyle.Right;
            this.lklSeeAll.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lklSeeAll.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lklSeeAll.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lklSeeAll.Location = new System.Drawing.Point(211, 0);
            this.lklSeeAll.Name = "lklSeeAll";
            this.lklSeeAll.Size = new System.Drawing.Size(75, 36);
            this.lklSeeAll.TabIndex = 0;
            this.lklSeeAll.TabStop = true;
            this.lklSeeAll.Text = "查看详情";
            this.lklSeeAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lklSeeAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklSeeAll_LinkClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(17, 38);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Size = new System.Drawing.Size(252, 69);
            this.label1.TabIndex = 0;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblTitle);
            this.panel2.Controls.Add(this.columnControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 152);
            this.panel2.TabIndex = 3;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTime.Location = new System.Drawing.Point(7, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 14);
            this.lblTime.TabIndex = 1;
            // 
            // FormPushMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.CaptionFont = new System.Drawing.Font("宋体", 10F);
            this.ClientSize = new System.Drawing.Size(292, 185);
            this.ControlBoxOffset = new System.Drawing.Point(5, 4);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPushMessage";
            this.Radius = 5;
            this.ShowIcon = false;
            this.SysBottomSize = new System.Drawing.Size(28, 25);
            this.Text = "提示信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPushMessage_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormPushMessage_FormClosed);
            this.Load += new System.EventHandler(this.FormPushMessage_Load);
            this.columnControl1.ResumeLayout(false);
            this.columnControl1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private UILibrary.ColumnControl columnControl1;
        private System.Windows.Forms.LinkLabel lklSeeAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTime;
    }
}