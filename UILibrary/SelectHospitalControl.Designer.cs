namespace TCUILibrary
{
    partial class SelectHospitalControl
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tcLabel1 = new TCUILibrary.TCLabel();
            this.pnlBotton = new System.Windows.Forms.Panel();
            this.btnGo = new TCUILibrary.TCButton();
            this.btnCancel = new TCUILibrary.TCButton();
            this.pnlBotton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 43);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(320, 130);
            this.panel1.TabIndex = 1;
            this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // tcLabel1
            // 
            this.tcLabel1.AutoSize = true;
            this.tcLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tcLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcLabel1.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tcLabel1.LineDistance = 5;
            this.tcLabel1.Location = new System.Drawing.Point(0, 0);
            this.tcLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tcLabel1.Name = "tcLabel1";
            this.tcLabel1.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.tcLabel1.ShowGlass = false;
            this.tcLabel1.Size = new System.Drawing.Size(202, 43);
            this.tcLabel1.TabIndex = 2;
            this.tcLabel1.Text = "请选择登录院区和科室";
            this.tcLabel1.Visible = false;
            // 
            // pnlBotton
            // 
            this.pnlBotton.Controls.Add(this.btnGo);
            this.pnlBotton.Controls.Add(this.btnCancel);
            this.pnlBotton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotton.Location = new System.Drawing.Point(0, 173);
            this.pnlBotton.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBotton.Name = "pnlBotton";
            this.pnlBotton.Size = new System.Drawing.Size(320, 65);
            this.pnlBotton.TabIndex = 0;
            this.pnlBotton.SizeChanged += new System.EventHandler(this.pnlBotton_SizeChanged);
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Transparent;
            this.btnGo.BackgroundImage = global::TCUILibrary.Properties.Resources.button_login_normal;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGo.FlatAppearance.BorderSize = 0;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGo.Location = new System.Drawing.Point(64, 18);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.MouseDownImage = global::TCUILibrary.Properties.Resources.button_login_down;
            this.btnGo.MouseHoverImage = global::TCUILibrary.Properties.Resources.button_login_hover;
            this.btnGo.MouseNormalImage = global::TCUILibrary.Properties.Resources.button_login_normal;
            this.btnGo.Name = "btnGo";
            this.btnGo.Padding = new System.Windows.Forms.Padding(4);
            this.btnGo.Size = new System.Drawing.Size(107, 39);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "登 录 ";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            this.btnGo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rdb_KeyDown);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BackgroundImage = global::TCUILibrary.Properties.Resources.button_login_normal;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(188, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.MouseDownImage = global::TCUILibrary.Properties.Resources.button_login_down;
            this.btnCancel.MouseHoverImage = global::TCUILibrary.Properties.Resources.button_login_hover;
            this.btnCancel.MouseNormalImage = global::TCUILibrary.Properties.Resources.button_login_normal;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(4);
            this.btnCancel.Size = new System.Drawing.Size(107, 39);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取 消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SelectHospitalControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBotton);
            this.Controls.Add(this.tcLabel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SelectHospitalControl";
            this.Size = new System.Drawing.Size(320, 238);
            this.Enter += new System.EventHandler(this.SelectHospitalControl_Enter);
            this.pnlBotton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TCLabel tcLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlBotton;
        private TCButton btnGo;
        private TCButton btnCancel;
    }
}
