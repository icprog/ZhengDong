namespace TCUILibrary.Controls
{
    partial class BaseSettingPanel
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
            this.btnUrlSet = new System.Windows.Forms.Button();
            this.btnShellIESet = new System.Windows.Forms.Button();
            this.btnCallNumberSet = new System.Windows.Forms.Button();
            this.btnHotKeySet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUrlSet
            // 
            this.btnUrlSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUrlSet.FlatAppearance.BorderSize = 0;
            this.btnUrlSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUrlSet.Location = new System.Drawing.Point(0, 0);
            this.btnUrlSet.Name = "btnUrlSet";
            this.btnUrlSet.Size = new System.Drawing.Size(150, 28);
            this.btnUrlSet.TabIndex = 0;
            this.btnUrlSet.Text = "导航地址";
            this.btnUrlSet.UseVisualStyleBackColor = true;
            this.btnUrlSet.Click += new System.EventHandler(this.btnUrlSet_Click);
            // 
            // btnShellIESet
            // 
            this.btnShellIESet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShellIESet.FlatAppearance.BorderSize = 0;
            this.btnShellIESet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShellIESet.Location = new System.Drawing.Point(0, 28);
            this.btnShellIESet.Name = "btnShellIESet";
            this.btnShellIESet.Size = new System.Drawing.Size(150, 28);
            this.btnShellIESet.TabIndex = 1;
            this.btnShellIESet.Text = "壳设置";
            this.btnShellIESet.UseVisualStyleBackColor = true;
            this.btnShellIESet.Click += new System.EventHandler(this.btnShellIESet_Click);
            // 
            // btnCallNumberSet
            // 
            this.btnCallNumberSet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCallNumberSet.FlatAppearance.BorderSize = 0;
            this.btnCallNumberSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCallNumberSet.Location = new System.Drawing.Point(0, 56);
            this.btnCallNumberSet.Name = "btnCallNumberSet";
            this.btnCallNumberSet.Size = new System.Drawing.Size(150, 28);
            this.btnCallNumberSet.TabIndex = 2;
            this.btnCallNumberSet.Text = "叫号设置";
            this.btnCallNumberSet.UseVisualStyleBackColor = true;
            this.btnCallNumberSet.Click += new System.EventHandler(this.btnCallNumberSet_Click);
            // 
            // btnHotKeySet
            // 
            this.btnHotKeySet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHotKeySet.FlatAppearance.BorderSize = 0;
            this.btnHotKeySet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHotKeySet.Location = new System.Drawing.Point(0, 84);
            this.btnHotKeySet.Name = "btnHotKeySet";
            this.btnHotKeySet.Size = new System.Drawing.Size(150, 28);
            this.btnHotKeySet.TabIndex = 3;
            this.btnHotKeySet.Text = "热键设置";
            this.btnHotKeySet.UseVisualStyleBackColor = true;
            this.btnHotKeySet.Click += new System.EventHandler(this.btnHotKeySet_Click);
            // 
            // BaseSettingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnHotKeySet);
            this.Controls.Add(this.btnCallNumberSet);
            this.Controls.Add(this.btnShellIESet);
            this.Controls.Add(this.btnUrlSet);
            this.Name = "BaseSettingPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUrlSet;
        private System.Windows.Forms.Button btnShellIESet;
        private System.Windows.Forms.Button btnCallNumberSet;
        private System.Windows.Forms.Button btnHotKeySet;
    }
}
