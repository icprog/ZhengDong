namespace TCUILibrary.Controls
{
    partial class ShellSettingControl
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
            this.chkShowJSError = new System.Windows.Forms.CheckBox();
            this.chkOpenInShell = new System.Windows.Forms.CheckBox();
            this.columnControl1 = new TCUILibrary.ColumnControl();
            this.SuspendLayout();
            // 
            // chkShowJSError
            // 
            this.chkShowJSError.AutoSize = true;
            this.chkShowJSError.Location = new System.Drawing.Point(28, 38);
            this.chkShowJSError.Name = "chkShowJSError";
            this.chkShowJSError.Size = new System.Drawing.Size(108, 16);
            this.chkShowJSError.TabIndex = 1;
            this.chkShowJSError.Text = "壳显示JS错误框";
            this.chkShowJSError.UseVisualStyleBackColor = true;
            // 
            // chkOpenInShell
            // 
            this.chkOpenInShell.AutoSize = true;
            this.chkOpenInShell.Location = new System.Drawing.Point(28, 72);
            this.chkOpenInShell.Name = "chkOpenInShell";
            this.chkOpenInShell.Size = new System.Drawing.Size(102, 16);
            this.chkOpenInShell.TabIndex = 2;
            this.chkOpenInShell.Text = "壳打开His系统";
            this.chkOpenInShell.UseVisualStyleBackColor = true;
            // 
            // columnControl1
            // 
            this.columnControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.columnControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.columnControl1.LineColor = System.Drawing.SystemColors.ControlLight;
            this.columnControl1.LineWidth = 1F;
            this.columnControl1.Location = new System.Drawing.Point(0, 0);
            this.columnControl1.Name = "columnControl1";
            this.columnControl1.Padding = new System.Windows.Forms.Padding(5);
            this.columnControl1.Size = new System.Drawing.Size(316, 22);
            this.columnControl1.TabIndex = 3;
            this.columnControl1.Title = "IE设置";
            // 
            // ShellSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.columnControl1);
            this.Controls.Add(this.chkOpenInShell);
            this.Controls.Add(this.chkShowJSError);
            this.Name = "ShellSettingControl";
            this.Size = new System.Drawing.Size(316, 222);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox chkShowJSError;
        private System.Windows.Forms.CheckBox chkOpenInShell;
        private ColumnControl columnControl1;
    }
}
