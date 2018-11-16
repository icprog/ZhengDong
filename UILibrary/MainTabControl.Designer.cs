namespace TCUILibrary
{
    partial class MainTabControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainTabControl));
            this.skinTabControl1 = new TCUILibrary.BubbleTabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.skinTabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinTabControl1
            // 
            this.skinTabControl1.BaseColor = System.Drawing.Color.White;
            this.skinTabControl1.BorderColor = System.Drawing.Color.White;
            this.skinTabControl1.BubbleFillColor = System.Drawing.Color.Red;
            this.skinTabControl1.BubbleFont = new System.Drawing.Font("宋体", 7F);
            this.skinTabControl1.BubbleTabPage = null;
            this.skinTabControl1.BubbleText = "";
            this.skinTabControl1.BubbleTextColor = System.Drawing.Color.White;
            this.skinTabControl1.CloseTabHoverImage = null;
            this.skinTabControl1.CloseTabNormalImage = null;
            this.skinTabControl1.CloseTabPressImage = null;
            this.skinTabControl1.Controls.Add(this.tabPage1);
            this.skinTabControl1.Controls.Add(this.tabPage3);
            this.skinTabControl1.Controls.Add(this.tabPage2);
            this.skinTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinTabControl1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinTabControl1.IsShowBubbleText = false;
            this.skinTabControl1.ItemSize = new System.Drawing.Size(70, 36);
            this.skinTabControl1.Location = new System.Drawing.Point(0, 0);
            this.skinTabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.skinTabControl1.Name = "skinTabControl1";
            this.skinTabControl1.Padding = new System.Drawing.Point(0, 0);
            this.skinTabControl1.PageColor = System.Drawing.Color.White;
            this.skinTabControl1.SelectedIndex = 0;
            this.skinTabControl1.Size = new System.Drawing.Size(330, 354);
            this.skinTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.skinTabControl1.TabDownBack = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.TabDownBack")));
            this.skinTabControl1.TabIndex = 0;
            this.skinTabControl1.TabMouseBack = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.TabMouseBack")));
            this.skinTabControl1.TabNormlBack = ((System.Drawing.Image)(resources.GetObject("skinTabControl1.TabNormlBack")));
            this.skinTabControl1.SelectedIndexChanged += new System.EventHandler(this.skinTabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(322, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "今日接诊";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 40);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(322, 310);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "公告";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(322, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "行业资讯";
            // 
            // MainTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.skinTabControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MainTabControl";
            this.Size = new System.Drawing.Size(330, 354);
            this.Load += new System.EventHandler(this.MainTabControl_Load);
            this.SizeChanged += new System.EventHandler(this.MainTabControl_SizeChanged);
            this.skinTabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BubbleTabControl skinTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
    }
}
