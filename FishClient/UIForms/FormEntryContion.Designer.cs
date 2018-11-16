namespace FishClient.UIForms
{
    partial class FormEntryContion
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
            this.txtquotesuppliercode = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbBand = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuery = new UILibrary.SkinButtom();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtquotesuppliercode);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.cmbCountry);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cmbBand);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 149);
            this.panel1.TabIndex = 0;
            // 
            // txtquotesuppliercode
            // 
            this.txtquotesuppliercode.Location = new System.Drawing.Point(262, 31);
            this.txtquotesuppliercode.Name = "txtquotesuppliercode";
            this.txtquotesuppliercode.ReadOnly = true;
            this.txtquotesuppliercode.Size = new System.Drawing.Size(100, 21);
            this.txtquotesuppliercode.TabIndex = 135;
            this.txtquotesuppliercode.Click += new System.EventHandler(this.txtquotesuppliercode_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(191, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 12);
            this.label14.TabIndex = 134;
            this.label14.Text = "报盘供应商";
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(82, 67);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(100, 20);
            this.cmbCountry.TabIndex = 133;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 132;
            this.label4.Text = "国别";
            // 
            // cmbBand
            // 
            this.cmbBand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBand.FormattingEnabled = true;
            this.cmbBand.Location = new System.Drawing.Point(262, 67);
            this.cmbBand.Name = "cmbBand";
            this.cmbBand.Size = new System.Drawing.Size(100, 20);
            this.cmbBand.TabIndex = 131;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 130;
            this.label3.Text = "品牌";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(82, 31);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 21);
            this.txtCode.TabIndex = 129;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 128;
            this.label2.Text = "鱼粉ID";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ControlState = UILibrary.ControlState.Normal;
            this.btnQuery.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnQuery.DownBack = null;
            this.btnQuery.Location = new System.Drawing.Point(262, 112);
            this.btnQuery.MouseBack = null;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.NormlBack = null;
            this.btnQuery.Size = new System.Drawing.Size(100, 23);
            this.btnQuery.TabIndex = 127;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = false;
            // 
            // FormEntryContion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 182);
            this.Controls.Add(this.panel1);
            this.Name = "FormEntryContion";
            this.Text = "查询条件";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private UILibrary.SkinButtom btnQuery;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbBand;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtquotesuppliercode;
        private System.Windows.Forms.Label label14;
    }
}