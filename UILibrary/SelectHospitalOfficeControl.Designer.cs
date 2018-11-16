namespace TCUILibrary
{
    partial class SelectHospitalOfficeControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbHospitals = new TCUILibrary.TCComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbOffices = new TCUILibrary.TCComboBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbHospitals
            // 
            this.cmbHospitals.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(88)))), ((int)(((byte)(128)))));
            this.cmbHospitals.BackColor = System.Drawing.Color.White;
            this.cmbHospitals.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(185)))), ((int)(((byte)(195)))));
            this.cmbHospitals.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbHospitals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHospitals.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbHospitals.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbHospitals.FormattingEnabled = true;
            this.cmbHospitals.ItemBorderColor = System.Drawing.Color.Gray;
            this.cmbHospitals.ItemHeight = 24;
            this.cmbHospitals.ItemSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(195)))));
            this.cmbHospitals.Location = new System.Drawing.Point(41, 28);
            this.cmbHospitals.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmbHospitals.Name = "cmbHospitals";
            this.cmbHospitals.Size = new System.Drawing.Size(155, 30);
            this.cmbHospitals.TabIndex = 1;
            this.cmbHospitals.TextPadding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmbHospitals.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHospitals_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 30);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(5, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 30);
            this.label2.TabIndex = 3;
            // 
            // cmbOffices
            // 
            this.cmbOffices.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(88)))), ((int)(((byte)(128)))));
            this.cmbOffices.BackColor = System.Drawing.Color.White;
            this.cmbOffices.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(185)))), ((int)(((byte)(195)))));
            this.cmbOffices.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbOffices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOffices.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbOffices.FormattingEnabled = true;
            this.cmbOffices.ItemBorderColor = System.Drawing.Color.Gray;
            this.cmbOffices.ItemHeight = 24;
            this.cmbOffices.ItemSelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(195)))));
            this.cmbOffices.Location = new System.Drawing.Point(41, 81);
            this.cmbOffices.Name = "cmbOffices";
            this.cmbOffices.Size = new System.Drawing.Size(155, 30);
            this.cmbOffices.TabIndex = 4;
            this.cmbOffices.TextPadding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.cmbOffices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbHospitals_KeyDown);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Location = new System.Drawing.Point(12, 120);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(0, 14);
            this.lblMsg.TabIndex = 5;
            // 
            // SelectHospitalOfficeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.cmbOffices);
            this.Controls.Add(this.cmbHospitals);
            this.Name = "SelectHospitalOfficeControl";
            this.Size = new System.Drawing.Size(198, 136);
            this.SizeChanged += new System.EventHandler(this.SelectHospitalOfficeControl_SizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TCComboBox cmbHospitals;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private TCComboBox cmbOffices;
        private System.Windows.Forms.Label lblMsg;
    }
}
