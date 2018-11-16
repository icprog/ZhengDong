namespace TCUILibrary
{
    partial class TCHeadControl
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCHeadControl));
            this.lblUserName = new TCUILibrary.TCLabel();
            this.signControl1 = new TCUILibrary.SignControl();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblHospital = new System.Windows.Forms.Label();
            this.pnlTags = new System.Windows.Forms.Panel();
            this.picHead = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlUser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblUserName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.Location = new System.Drawing.Point(1, 2);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.ShowGlass = false;
            this.lblUserName.Size = new System.Drawing.Size(58, 21);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "奥巴马";
            // 
            // signControl1
            // 
            this.signControl1.BackColor = System.Drawing.Color.Transparent;
            this.signControl1.Location = new System.Drawing.Point(79, 28);
            this.signControl1.Name = "signControl1";
            this.signControl1.SignContext = "";
            this.signControl1.Size = new System.Drawing.Size(182, 18);
            this.signControl1.TabIndex = 2;
            // 
            // pnlUser
            // 
            this.pnlUser.Controls.Add(this.lblHospital);
            this.pnlUser.Controls.Add(this.lblUserName);
            this.pnlUser.Location = new System.Drawing.Point(77, 2);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(174, 25);
            this.pnlUser.TabIndex = 3;
            // 
            // lblHospital
            // 
            this.lblHospital.AutoSize = true;
            this.lblHospital.Location = new System.Drawing.Point(106, 6);
            this.lblHospital.Name = "lblHospital";
            this.lblHospital.Size = new System.Drawing.Size(53, 12);
            this.lblHospital.TabIndex = 2;
            this.lblHospital.Text = "hospital";
            this.lblHospital.Visible = false;
            // 
            // pnlTags
            // 
            this.pnlTags.Location = new System.Drawing.Point(78, 49);
            this.pnlTags.Name = "pnlTags";
            this.pnlTags.Size = new System.Drawing.Size(200, 16);
            this.pnlTags.TabIndex = 4;
            // 
            // picHead
            // 
            this.picHead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picHead.BackgroundImage")));
            this.picHead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picHead.Image = ((System.Drawing.Image)(resources.GetObject("picHead.Image")));
            this.picHead.Location = new System.Drawing.Point(6, 3);
            this.picHead.Name = "picHead";
            this.picHead.Padding = new System.Windows.Forms.Padding(4);
            this.picHead.Size = new System.Drawing.Size(64, 64);
            this.picHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHead.TabIndex = 0;
            this.picHead.TabStop = false;
            this.picHead.Click += new System.EventHandler(this.picHead_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // TCHeadControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pnlTags);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.signControl1);
            this.Controls.Add(this.picHead);
            this.Name = "TCHeadControl";
            this.Size = new System.Drawing.Size(266, 78);
            this.SizeChanged += new System.EventHandler(this.TCHeadControl_SizeChanged);
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picHead)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picHead;
        private TCLabel lblUserName;
        private SignControl signControl1;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblHospital;
        private System.Windows.Forms.Panel pnlTags;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
