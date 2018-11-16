namespace FishClient.UIForms
{
    partial class FormContractCondition
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
            this.btnOk = new UILibrary.SkinButtom();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtcontractno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsignaddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtsigndate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtyifang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.Transparent;
            this.btnOk.ControlState = UILibrary.ControlState.Normal;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.DownBack = null;
            this.btnOk.Location = new System.Drawing.Point(217, 139);
            this.btnOk.MouseBack = null;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormlBack = null;
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 61;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtcontractno);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtsignaddress);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtsigndate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtyifang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 188);
            this.panel1.TabIndex = 68;
            // 
            // txtcontractno
            // 
            this.txtcontractno.Location = new System.Drawing.Point(90, 97);
            this.txtcontractno.Name = "txtcontractno";
            this.txtcontractno.Size = new System.Drawing.Size(202, 21);
            this.txtcontractno.TabIndex = 75;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 74;
            this.label4.Text = "合同编号：";
            // 
            // txtsignaddress
            // 
            this.txtsignaddress.Location = new System.Drawing.Point(90, 69);
            this.txtsignaddress.Name = "txtsignaddress";
            this.txtsignaddress.Size = new System.Drawing.Size(202, 21);
            this.txtsignaddress.TabIndex = 73;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 72;
            this.label3.Text = "签约地点：";
            // 
            // txtsigndate
            // 
            this.txtsigndate.Location = new System.Drawing.Point(90, 41);
            this.txtsigndate.Name = "txtsigndate";
            this.txtsigndate.Size = new System.Drawing.Size(202, 21);
            this.txtsigndate.TabIndex = 71;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 70;
            this.label2.Text = "签约日期：";
            // 
            // txtyifang
            // 
            this.txtyifang.Location = new System.Drawing.Point(90, 13);
            this.txtyifang.Name = "txtyifang";
            this.txtyifang.Size = new System.Drawing.Size(202, 21);
            this.txtyifang.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 68;
            this.label1.Text = "买方：";
            // 
            // FormContractCondition
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 221);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormContractCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 合同查询条件";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UILibrary.SkinButtom btnOk;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtcontractno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtsignaddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtsigndate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtyifang;
        private System.Windows.Forms.Label label1;
    }
}