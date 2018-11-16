namespace FishClient.UIControls
{
    partial class FishSaleControl
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
            this.txtSaleOutDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSaleLinkman = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaleCompany = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaleRmb = new System.Windows.Forms.TextBox();
            this.txtSaleDollars = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSaleWeight = new System.Windows.Forms.TextBox();
            this.txtSaleQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaleDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnQuery = new UILibrary.SkinButtom();
            this.SuspendLayout();
            // 
            // txtSaleOutDate
            // 
            this.txtSaleOutDate.Location = new System.Drawing.Point(123, 211);
            this.txtSaleOutDate.Name = "txtSaleOutDate";
            this.txtSaleOutDate.Size = new System.Drawing.Size(89, 21);
            this.txtSaleOutDate.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(62, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 54;
            this.label9.Text = "售完日期：";
            // 
            // txtSaleLinkman
            // 
            this.txtSaleLinkman.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSaleLinkman.Location = new System.Drawing.Point(123, 182);
            this.txtSaleLinkman.Name = "txtSaleLinkman";
            this.txtSaleLinkman.ReadOnly = true;
            this.txtSaleLinkman.Size = new System.Drawing.Size(89, 21);
            this.txtSaleLinkman.TabIndex = 51;
            this.txtSaleLinkman.Click += new System.EventHandler(this.txtSaleLinkman_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(50, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 50;
            this.label7.Text = "现货联系人：";
            // 
            // txtSaleCompany
            // 
            this.txtSaleCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSaleCompany.Location = new System.Drawing.Point(75, 153);
            this.txtSaleCompany.Name = "txtSaleCompany";
            this.txtSaleCompany.ReadOnly = true;
            this.txtSaleCompany.Size = new System.Drawing.Size(137, 21);
            this.txtSaleCompany.TabIndex = 49;
            this.txtSaleCompany.Click += new System.EventHandler(this.txtSaleCompany_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 48;
            this.label6.Text = "现货货主：";
            // 
            // txtSaleRmb
            // 
            this.txtSaleRmb.Location = new System.Drawing.Point(123, 124);
            this.txtSaleRmb.Name = "txtSaleRmb";
            this.txtSaleRmb.Size = new System.Drawing.Size(89, 21);
            this.txtSaleRmb.TabIndex = 47;
            // 
            // txtSaleDollars
            // 
            this.txtSaleDollars.Location = new System.Drawing.Point(123, 95);
            this.txtSaleDollars.Name = "txtSaleDollars";
            this.txtSaleDollars.Size = new System.Drawing.Size(89, 21);
            this.txtSaleDollars.TabIndex = 46;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 12);
            this.label5.TabIndex = 45;
            this.label5.Text = "市场销售人民币价格：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 44;
            this.label4.Text = "市场销售美元价格：";
            // 
            // txtSaleWeight
            // 
            this.txtSaleWeight.Location = new System.Drawing.Point(123, 37);
            this.txtSaleWeight.Name = "txtSaleWeight";
            this.txtSaleWeight.Size = new System.Drawing.Size(89, 21);
            this.txtSaleWeight.TabIndex = 40;
            // 
            // txtSaleQuantity
            // 
            this.txtSaleQuantity.Location = new System.Drawing.Point(123, 66);
            this.txtSaleQuantity.Name = "txtSaleQuantity";
            this.txtSaleQuantity.Size = new System.Drawing.Size(89, 21);
            this.txtSaleQuantity.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "剩余数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 41;
            this.label2.Text = "剩余重量：";
            // 
            // txtSaleDate
            // 
            this.txtSaleDate.Location = new System.Drawing.Point(123, 8);
            this.txtSaleDate.Name = "txtSaleDate";
            this.txtSaleDate.Size = new System.Drawing.Size(89, 21);
            this.txtSaleDate.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "销售最新信息日期：";
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ControlState = UILibrary.ControlState.Normal;
            this.btnQuery.DownBack = null;
            this.btnQuery.Location = new System.Drawing.Point(64, 251);
            this.btnQuery.MouseBack = null;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.NormlBack = null;
            this.btnQuery.Size = new System.Drawing.Size(112, 23);
            this.btnQuery.TabIndex = 56;
            this.btnQuery.Text = "现货价格货主查询";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // FishSaleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtSaleOutDate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSaleLinkman);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSaleCompany);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSaleRmb);
            this.Controls.Add(this.txtSaleDollars);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaleWeight);
            this.Controls.Add(this.txtSaleQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSaleDate);
            this.Controls.Add(this.label1);
            this.Name = "FishSaleControl";
            this.Size = new System.Drawing.Size(216, 289);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSaleOutDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSaleLinkman;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSaleCompany;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaleRmb;
        private System.Windows.Forms.TextBox txtSaleDollars;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSaleWeight;
        private System.Windows.Forms.TextBox txtSaleQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSaleDate;
        private System.Windows.Forms.Label label1;
        private UILibrary.SkinButtom btnQuery;
    }
}
