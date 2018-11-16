namespace UILibrary.UserDropDownControl
{
    partial class UserInfoControl
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
            this.tcPicture2 = new UILibrary.TCPicture(this.components);
            this.tcPicture1 = new UILibrary.TCPicture(this.components);
            this.tcPanel1 = new UILibrary.TCPanel();
            this.lblName = new UILibrary.TCLabel();
            this.lblUserID = new UILibrary.TCLabel();
            ((System.ComponentModel.ISupportInitialize)(this.tcPicture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcPicture1)).BeginInit();
            this.tcPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcPicture2
            // 
            this.tcPicture2.Image = global::UILibrary.Properties.Resources.close_normal;
            this.tcPicture2.Location = new System.Drawing.Point(133, 6);
            this.tcPicture2.Name = "tcPicture2";
            this.tcPicture2.RoundStyle = UILibrary.RoundStyle.None;
            this.tcPicture2.Size = new System.Drawing.Size(25, 25);
            this.tcPicture2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.tcPicture2.TabIndex = 3;
            this.tcPicture2.TabStop = false;
            this.tcPicture2.Click += new System.EventHandler(this.tcPicture2_Click);
            this.tcPicture2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tcPicture2_MouseDown);
            this.tcPicture2.MouseEnter += new System.EventHandler(this.tcPicture2_MouseEnter);
            this.tcPicture2.MouseLeave += new System.EventHandler(this.tcPicture2_MouseLeave);
            this.tcPicture2.MouseHover += new System.EventHandler(this.tcPicture2_MouseHover);
            // 
            // tcPicture1
            // 
            this.tcPicture1.Location = new System.Drawing.Point(4, 6);
            this.tcPicture1.Name = "tcPicture1";
            this.tcPicture1.RoundStyle = UILibrary.RoundStyle.None;
            this.tcPicture1.Size = new System.Drawing.Size(25, 25);
            this.tcPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tcPicture1.TabIndex = 2;
            this.tcPicture1.TabStop = false;
            this.tcPicture1.Click += new System.EventHandler(this.tcPanel1_Click);
            this.tcPicture1.MouseEnter += new System.EventHandler(this.tcPicture1_MouseEnter);
            this.tcPicture1.MouseLeave += new System.EventHandler(this.tcPicture1_MouseLeave);
            // 
            // tcPanel1
            // 
            this.tcPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tcPanel1.Controls.Add(this.lblName);
            this.tcPanel1.Controls.Add(this.lblUserID);
            this.tcPanel1.ControlState = UILibrary.ControlState.Normal;
            this.tcPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPanel1.Location = new System.Drawing.Point(0, 0);
            this.tcPanel1.MouseDownImg = null;
            this.tcPanel1.MouseHoverImg = null;
            this.tcPanel1.MouseNormalImg = null;
            this.tcPanel1.Name = "tcPanel1";
            this.tcPanel1.Radius = 0;
            this.tcPanel1.Size = new System.Drawing.Size(160, 40);
            this.tcPanel1.TabIndex = 4;
            this.tcPanel1.Click += new System.EventHandler(this.tcPanel1_Click);
            this.tcPanel1.MouseEnter += new System.EventHandler(this.tcPanel1_MouseEnter);
            this.tcPanel1.MouseLeave += new System.EventHandler(this.tcPanel1_MouseLeave);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblName.Location = new System.Drawing.Point(33, 5);
            this.lblName.Name = "lblName";
            this.lblName.ShowGlass = false;
            this.lblName.Size = new System.Drawing.Size(53, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "UserName";
            this.lblName.Click += new System.EventHandler(this.tcPanel1_Click);
            this.lblName.MouseEnter += new System.EventHandler(this.tcPanel1_MouseEnter);
            this.lblName.MouseLeave += new System.EventHandler(this.tcPanel1_MouseLeave);
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.BackColor = System.Drawing.Color.Transparent;
            this.lblUserID.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblUserID.Location = new System.Drawing.Point(33, 20);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.ShowGlass = false;
            this.lblUserID.Size = new System.Drawing.Size(41, 12);
            this.lblUserID.TabIndex = 0;
            this.lblUserID.Text = "Userid";
            this.lblUserID.Click += new System.EventHandler(this.tcPanel1_Click);
            this.lblUserID.MouseEnter += new System.EventHandler(this.tcPanel1_MouseEnter);
            this.lblUserID.MouseLeave += new System.EventHandler(this.tcPanel1_MouseLeave);
            // 
            // UserInfoControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tcPicture2);
            this.Controls.Add(this.tcPicture1);
            this.Controls.Add(this.tcPanel1);
            this.Name = "UserInfoControl";
            this.Size = new System.Drawing.Size(160, 40);
            ((System.ComponentModel.ISupportInitialize)(this.tcPicture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tcPicture1)).EndInit();
            this.tcPanel1.ResumeLayout(false);
            this.tcPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TCPicture tcPicture1;
        private TCPicture tcPicture2;
        private TCPanel tcPanel1;
        private TCLabel lblName;
        private TCLabel lblUserID;

    }
}
