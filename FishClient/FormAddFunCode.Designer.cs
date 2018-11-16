namespace FishClient
{
    partial class FormAddFunCode
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
            this.cmbMenus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbbutton = new System.Windows.Forms.RadioButton();
            this.rdbmenu = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.ckbenable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new UILibrary.SkinButtom();
            this.btnOk = new UILibrary.SkinButtom();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFunName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbMenus);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.rdbbutton);
            this.panel1.Controls.Add(this.rdbmenu);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ckbenable);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtcode);
            this.panel1.Controls.Add(this.txtRemark);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFunName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 336);
            this.panel1.TabIndex = 0;
            // 
            // cmbMenus
            // 
            this.cmbMenus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMenus.FormattingEnabled = true;
            this.cmbMenus.Location = new System.Drawing.Point(86, 126);
            this.cmbMenus.Name = "cmbMenus";
            this.cmbMenus.Size = new System.Drawing.Size(261, 20);
            this.cmbMenus.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 16;
            this.label5.Text = "上级菜单：";
            // 
            // rdbbutton
            // 
            this.rdbbutton.AutoSize = true;
            this.rdbbutton.Location = new System.Drawing.Point(147, 96);
            this.rdbbutton.Name = "rdbbutton";
            this.rdbbutton.Size = new System.Drawing.Size(47, 16);
            this.rdbbutton.TabIndex = 4;
            this.rdbbutton.Text = "按钮";
            this.rdbbutton.UseVisualStyleBackColor = true;
            // 
            // rdbmenu
            // 
            this.rdbmenu.AutoSize = true;
            this.rdbmenu.Checked = true;
            this.rdbmenu.Location = new System.Drawing.Point(86, 96);
            this.rdbmenu.Name = "rdbmenu";
            this.rdbmenu.Size = new System.Drawing.Size(47, 16);
            this.rdbmenu.TabIndex = 3;
            this.rdbmenu.TabStop = true;
            this.rdbmenu.Text = "菜单";
            this.rdbmenu.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "功能类型：";
            // 
            // ckbenable
            // 
            this.ckbenable.AutoSize = true;
            this.ckbenable.Checked = true;
            this.ckbenable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbenable.Location = new System.Drawing.Point(299, 98);
            this.ckbenable.Name = "ckbenable";
            this.ckbenable.Size = new System.Drawing.Size(48, 16);
            this.ckbenable.TabIndex = 5;
            this.ckbenable.Text = "启用";
            this.ckbenable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "功能代码：";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(86, 20);
            this.txtcode.MaxLength = 200;
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(261, 21);
            this.txtcode.TabIndex = 1;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(86, 158);
            this.txtRemark.MaxLength = 200;
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(261, 60);
            this.txtRemark.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "备注：";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = UILibrary.ControlState.Normal;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DownBack = null;
            this.btnCancel.Location = new System.Drawing.Point(219, 266);
            this.btnCancel.MouseBack = null;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(119, 266);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "功能名称：";
            // 
            // txtFunName
            // 
            this.txtFunName.Location = new System.Drawing.Point(86, 57);
            this.txtFunName.MaxLength = 200;
            this.txtFunName.Name = "txtFunName";
            this.txtFunName.Size = new System.Drawing.Size(261, 21);
            this.txtFunName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 237);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "排序号：";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(86, 231);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(261, 21);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FormAddFunCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 369);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddFunCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加功能点";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private UILibrary.SkinButtom btnCancel;
        private UILibrary.SkinButtom btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFunName;
        private System.Windows.Forms.CheckBox ckbenable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.RadioButton rdbbutton;
        private System.Windows.Forms.RadioButton rdbmenu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMenus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label6;

    }
}