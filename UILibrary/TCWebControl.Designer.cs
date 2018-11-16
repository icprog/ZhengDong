namespace UILibrary
{
    partial class TCWebControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCWebControl));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tSMIBack = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIForword = new System.Windows.Forms.ToolStripMenuItem();
            this.tSMIRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tSTBUrl = new System.Windows.Forms.ToolStripTextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslUrl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslHotInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsslHotKey = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslMore = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMIBack,
            this.tSMIForword,
            this.tSMIRefresh,
            this.tSTBUrl});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 0);
            this.menuStrip1.Size = new System.Drawing.Size(627, 30);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.SizeChanged += new System.EventHandler(this.menuStrip1_SizeChanged);
            // 
            // tSMIBack
            // 
            this.tSMIBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIBack.Image = ((System.Drawing.Image)(resources.GetObject("tSMIBack.Image")));
            this.tSMIBack.Name = "tSMIBack";
            this.tSMIBack.Padding = new System.Windows.Forms.Padding(4);
            this.tSMIBack.Size = new System.Drawing.Size(28, 28);
            this.tSMIBack.Text = "后退";
            this.tSMIBack.ToolTipText = "后退";
            this.tSMIBack.Click += new System.EventHandler(this.tSMIBack_Click);
            // 
            // tSMIForword
            // 
            this.tSMIForword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIForword.Image = ((System.Drawing.Image)(resources.GetObject("tSMIForword.Image")));
            this.tSMIForword.Name = "tSMIForword";
            this.tSMIForword.Padding = new System.Windows.Forms.Padding(4);
            this.tSMIForword.Size = new System.Drawing.Size(28, 28);
            this.tSMIForword.Text = "前进";
            this.tSMIForword.ToolTipText = "前进";
            this.tSMIForword.Click += new System.EventHandler(this.tSMIForword_Click);
            // 
            // tSMIRefresh
            // 
            this.tSMIRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSMIRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tSMIRefresh.Image")));
            this.tSMIRefresh.Name = "tSMIRefresh";
            this.tSMIRefresh.Padding = new System.Windows.Forms.Padding(4);
            this.tSMIRefresh.Size = new System.Drawing.Size(28, 28);
            this.tSMIRefresh.Text = "刷新";
            this.tSMIRefresh.ToolTipText = "刷新";
            this.tSMIRefresh.Click += new System.EventHandler(this.tSMIRefresh_Click);
            // 
            // tSTBUrl
            // 
            this.tSTBUrl.AutoSize = false;
            this.tSTBUrl.Name = "tSTBUrl";
            this.tSTBUrl.Size = new System.Drawing.Size(100, 28);
            this.tSTBUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tSTBUrl_KeyDown);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 30);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(627, 454);
            this.webBrowser1.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslUrl,
            this.tsslHotInfo,
            this.tspbar,
            this.tsslHotKey,
            this.tsslMore});
            this.statusStrip1.Location = new System.Drawing.Point(0, 484);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(627, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslUrl
            // 
            this.tsslUrl.Name = "tsslUrl";
            this.tsslUrl.Size = new System.Drawing.Size(85, 17);
            this.tsslUrl.Text = "11111111111";
            // 
            // tsslHotInfo
            // 
            this.tsslHotInfo.Name = "tsslHotInfo";
            this.tsslHotInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // tspbar
            // 
            this.tspbar.Name = "tspbar";
            this.tspbar.Size = new System.Drawing.Size(200, 16);
            // 
            // tsslHotKey
            // 
            this.tsslHotKey.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsslHotKey.ForeColor = System.Drawing.Color.Blue;
            this.tsslHotKey.Name = "tsslHotKey";
            this.tsslHotKey.Size = new System.Drawing.Size(293, 17);
            this.tsslHotKey.Spring = true;
            this.tsslHotKey.Text = "toolStripStatusLabel1";
            this.tsslHotKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslMore
            // 
            this.tsslMore.IsLink = true;
            this.tsslMore.Name = "tsslMore";
            this.tsslMore.Size = new System.Drawing.Size(32, 17);
            this.tsslMore.Text = "更多";
            // 
            // TCWebControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "TCWebControl";
            this.Size = new System.Drawing.Size(627, 506);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tSMIBack;
        private System.Windows.Forms.ToolStripMenuItem tSMIForword;
        private System.Windows.Forms.ToolStripMenuItem tSMIRefresh;
        private System.Windows.Forms.ToolStripTextBox tSTBUrl;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslUrl;
        private System.Windows.Forms.ToolStripStatusLabel tsslHotInfo;
        private System.Windows.Forms.ToolStripProgressBar tspbar;
        private System.Windows.Forms.ToolStripStatusLabel tsslHotKey;
        private System.Windows.Forms.ToolStripStatusLabel tsslMore;
    }
}
