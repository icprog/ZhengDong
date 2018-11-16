namespace FishClient
{
    partial class FormInventoryAccount
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnAccount = new UILibrary.SkinButtom();
            this.btnNotAccount = new UILibrary.SkinButtom();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "当前年月：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(111, 100);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(114, 21);
            this.dateTimePicker1.TabIndex = 2;
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnAccount.ControlState = UILibrary.ControlState.Normal;
            this.btnAccount.DownBack = null;
            this.btnAccount.Location = new System.Drawing.Point(88, 155);
            this.btnAccount.MouseBack = null;
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.NormlBack = null;
            this.btnAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAccount.TabIndex = 3;
            this.btnAccount.Text = "月结";
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnNotAccount
            // 
            this.btnNotAccount.BackColor = System.Drawing.Color.Transparent;
            this.btnNotAccount.ControlState = UILibrary.ControlState.Normal;
            this.btnNotAccount.DownBack = null;
            this.btnNotAccount.Location = new System.Drawing.Point(234, 154);
            this.btnNotAccount.MouseBack = null;
            this.btnNotAccount.Name = "btnNotAccount";
            this.btnNotAccount.NormlBack = null;
            this.btnNotAccount.Size = new System.Drawing.Size(75, 23);
            this.btnNotAccount.TabIndex = 4;
            this.btnNotAccount.Text = "反月结";
            this.btnNotAccount.UseVisualStyleBackColor = false;
            this.btnNotAccount.Click += new System.EventHandler(this.btnNotAccount_Click);
            // 
            // FormInventoryAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 432);
            this.Controls.Add(this.btnNotAccount);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "FormInventoryAccount";
            this.Text = "FormInventoryAccount";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dateTimePicker1, 0);
            this.Controls.SetChildIndex(this.btnAccount, 0);
            this.Controls.SetChildIndex(this.btnNotAccount, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private UILibrary.SkinButtom btnAccount;
        private UILibrary.SkinButtom btnNotAccount;
    }
}