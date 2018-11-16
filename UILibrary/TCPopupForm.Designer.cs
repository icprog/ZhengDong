namespace TCUILibrary
{
    partial class TCPopupForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.tcLabel2 = new TCUILibrary.TCLabel();
            this.tcLabel1 = new TCUILibrary.TCLabel();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // tcLabel2
            // 
            this.tcLabel2.AutoSize = true;
            this.tcLabel2.BackColor = System.Drawing.Color.Transparent;
            this.tcLabel2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcLabel2.Location = new System.Drawing.Point(25, 119);
            this.tcLabel2.Name = "tcLabel2";
            this.tcLabel2.ShowGlass = false;
            this.tcLabel2.Size = new System.Drawing.Size(53, 12);
            this.tcLabel2.TabIndex = 1;
            this.tcLabel2.Text = "tcLabel2";
            // 
            // tcLabel1
            // 
            this.tcLabel1.AutoSize = true;
            this.tcLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tcLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcLabel1.Location = new System.Drawing.Point(23, 73);
            this.tcLabel1.Name = "tcLabel1";
            this.tcLabel1.ShowGlass = false;
            this.tcLabel1.Size = new System.Drawing.Size(53, 12);
            this.tcLabel1.TabIndex = 0;
            this.tcLabel1.Text = "tcLabel1";
            // 
            // TCPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tcLabel2);
            this.Controls.Add(this.tcLabel1);
            this.Name = "TCPopupForm";
            this.Text = "TCPopupForm";
            this.Load += new System.EventHandler(this.TCPopupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private TCLabel tcLabel1;
        private TCLabel tcLabel2;
    }
}