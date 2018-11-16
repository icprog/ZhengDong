namespace UILibrary
{
    partial class AvatarControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvatarControl));
            this.tcPicture1 = new UILibrary.TCPicture(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tcPicture1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcPicture1
            // 
            this.tcPicture1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcPicture1.Location = new System.Drawing.Point(8, 4);
            this.tcPicture1.Name = "tcPicture1";
            this.tcPicture1.RoundStyle = UILibrary.RoundStyle.All;
            this.tcPicture1.Size = new System.Drawing.Size(104, 101);
            this.tcPicture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.tcPicture1.TabIndex = 0;
            this.tcPicture1.TabStop = false;
            // 
            // AvatarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tcPicture1);
            this.DoubleBuffered = true;
            this.Name = "AvatarControl";
            this.Padding = new System.Windows.Forms.Padding(8, 4, 8, 11);
            this.Size = new System.Drawing.Size(120, 116);
            ((System.ComponentModel.ISupportInitialize)(this.tcPicture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TCPicture tcPicture1;
    }
}
