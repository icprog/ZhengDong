namespace FishClient . UIForms
{
    partial class PurchaseApplicationCondition
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCodNum = new System.Windows.Forms.ComboBox();
            this.btnSure = new UILibrary.SkinButtom();
            this.btnCancel = new UILibrary.SkinButtom();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "编号";
            // 
            // cmbCodNum
            // 
            this.cmbCodNum.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCodNum.FormattingEnabled = true;
            this.cmbCodNum.Location = new System.Drawing.Point(77, 59);
            this.cmbCodNum.Name = "cmbCodNum";
            this.cmbCodNum.Size = new System.Drawing.Size(150, 20);
            this.cmbCodNum.TabIndex = 4;
            // 
            // btnSure
            // 
            this.btnSure.BackColor = System.Drawing.Color.Transparent;
            this.btnSure.ControlState = UILibrary.ControlState.Normal;
            this.btnSure.DownBack = null;
            this.btnSure.Location = new System.Drawing.Point(44, 127);
            this.btnSure.MouseBack = null;
            this.btnSure.Name = "btnSure";
            this.btnSure.NormlBack = null;
            this.btnSure.Size = new System.Drawing.Size(75, 23);
            this.btnSure.TabIndex = 5;
            this.btnSure.Text = "确定";
            this.btnSure.UseVisualStyleBackColor = false;
            this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = UILibrary.ControlState.Normal;
            this.btnCancel.DownBack = null;
            this.btnCancel.Location = new System.Drawing.Point(152, 127);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PurchaseApplicationCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 194);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSure);
            this.Controls.Add(this.cmbCodNum);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseApplicationCondition";
            this.Text = "采购申请单查询";
            this.Load += new System.EventHandler(this.PurchaseApplicationCondition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . ComboBox cmbCodNum;
        private UILibrary . SkinButtom btnSure;
        private UILibrary . SkinButtom btnCancel;
    }
}