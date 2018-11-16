namespace TCUILibrary
{
    partial class TCSplashControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCSplashControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.avatarControl1 = new TCUILibrary.AvatarControl();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(25, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 159);
            this.panel1.TabIndex = 19;
            // 
            // avatarControl1
            // 
            this.avatarControl1.BackColor = System.Drawing.Color.Transparent;
            this.avatarControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("avatarControl1.BackgroundImage")));
            this.avatarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarControl1.Location = new System.Drawing.Point(46, 15);
            this.avatarControl1.Name = "avatarControl1";
            this.avatarControl1.Padding = new System.Windows.Forms.Padding(8, 6, 8, 11);
            this.avatarControl1.Size = new System.Drawing.Size(114, 114);
            this.avatarControl1.TabIndex = 20;
            this.avatarControl1.Load += new System.EventHandler(this.avatarControl1_Load);
            // 
            // TCSplashControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.avatarControl1);
            this.Controls.Add(this.panel1);
            this.Name = "TCSplashControl";
            this.Size = new System.Drawing.Size(231, 464);
            this.Load += new System.EventHandler(this.TCSplashControl_Load);
            this.SizeChanged += new System.EventHandler(this.TCSplashControl_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private AvatarControl avatarControl1;
        //private TCPicture tcPicture1;
    }
}
