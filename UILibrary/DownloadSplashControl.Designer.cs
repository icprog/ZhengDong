namespace UILibrary
{
    partial class DownloadSplashControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadSplashControl));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new UILibrary.SkinButtom();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.avatarControl1 = new UILibrary.AvatarControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "正在初始化数据,请稍等";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(55, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(15, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(192, 163);
            this.panel1.TabIndex = 22;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.ControlState = UILibrary.ControlState.Normal;
            this.btnCancel.DownBack = global::UILibrary.Properties.Resources.button_login_down;
            this.btnCancel.DrawType = UILibrary.DrawStyle.Img;
            this.btnCancel.Location = new System.Drawing.Point(54, 116);
            this.btnCancel.MouseBack = global::UILibrary.Properties.Resources.button_login_hover;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormlBack = global::UILibrary.Properties.Resources.button_login_normal;
            this.btnCancel.Size = new System.Drawing.Size(85, 31);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 17);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(143, 23);
            this.progressBar1.TabIndex = 21;
            // 
            // avatarControl1
            // 
            this.avatarControl1.BackColor = System.Drawing.Color.Transparent;
            this.avatarControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("avatarControl1.BackgroundImage")));
            this.avatarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarControl1.Location = new System.Drawing.Point(54, 33);
            this.avatarControl1.Name = "avatarControl1";
            this.avatarControl1.Padding = new System.Windows.Forms.Padding(8, 6, 8, 11);
            this.avatarControl1.Size = new System.Drawing.Size(114, 114);
            this.avatarControl1.TabIndex = 21;
            // 
            // DownloadSplashControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.avatarControl1);
            this.Name = "DownloadSplashControl";
            this.Size = new System.Drawing.Size(223, 339);
            this.SizeChanged += new System.EventHandler(this.DownloadSplashControl_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AvatarControl avatarControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private SkinButtom btnCancel;
    }
}
