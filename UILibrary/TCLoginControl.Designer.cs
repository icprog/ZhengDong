namespace UILibrary
{
    partial class TCLoginControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TCLoginControl));
            this.menuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tcLabelPWD = new UILibrary.TCLabel();
            this.tcLabelUSER = new UILibrary.TCLabel();
            this.lblHelp = new UILibrary.TCLabel();
            this.lblSetting = new UILibrary.TCLabel();
            this.lblFindPwd = new UILibrary.TCLabel();
            this.lblRegister = new UILibrary.TCLabel();
            this.txtPwd = new UILibrary.SkinTextBox();
            this.chkAuto = new UILibrary.TCCheckBox();
            this.chkRemember = new UILibrary.TCCheckBox();
            this.txtUser = new UILibrary.SkinTextBox();
            this.btnLogin = new UILibrary.SkinButtom();
            this.avatarControl1 = new UILibrary.AvatarControl();
            this.pnlTipUser = new System.Windows.Forms.Panel();
            this.lblTipUser = new System.Windows.Forms.Label();
            this.pnlTipPwd = new System.Windows.Forms.Panel();
            this.lblTipPwd = new System.Windows.Forms.Label();
            this.pnlTipUser.SuspendLayout();
            this.pnlTipPwd.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuUser
            // 
            this.menuUser.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuUser.MaximumSize = new System.Drawing.Size(200, 400);
            this.menuUser.Name = "menuUser";
            this.menuUser.Size = new System.Drawing.Size(61, 4);
            // 
            // tcLabelPWD
            // 
            this.tcLabelPWD.AutoSize = true;
            this.tcLabelPWD.BackColor = System.Drawing.Color.Transparent;
            this.tcLabelPWD.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcLabelPWD.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcLabelPWD.LineDistance = 5;
            this.tcLabelPWD.Location = new System.Drawing.Point(63, 290);
            this.tcLabelPWD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tcLabelPWD.Name = "tcLabelPWD";
            this.tcLabelPWD.ShowGlass = false;
            this.tcLabelPWD.Size = new System.Drawing.Size(78, 23);
            this.tcLabelPWD.TabIndex = 12;
            this.tcLabelPWD.Text = "用户密码";
            this.tcLabelPWD.Visible = false;
            // 
            // tcLabelUSER
            // 
            this.tcLabelUSER.AutoSize = true;
            this.tcLabelUSER.BackColor = System.Drawing.Color.Transparent;
            this.tcLabelUSER.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.tcLabelUSER.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tcLabelUSER.LineDistance = 5;
            this.tcLabelUSER.Location = new System.Drawing.Point(60, 219);
            this.tcLabelUSER.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tcLabelUSER.Name = "tcLabelUSER";
            this.tcLabelUSER.ShowGlass = false;
            this.tcLabelUSER.Size = new System.Drawing.Size(78, 23);
            this.tcLabelUSER.TabIndex = 11;
            this.tcLabelUSER.Text = "用户账号";
            this.tcLabelUSER.Visible = false;
            // 
            // lblHelp
            // 
            this.lblHelp.AutoSize = true;
            this.lblHelp.BackColor = System.Drawing.Color.Transparent;
            this.lblHelp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblHelp.LineDistance = 5;
            this.lblHelp.Location = new System.Drawing.Point(172, 528);
            this.lblHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHelp.Name = "lblHelp";
            this.lblHelp.ShowGlass = false;
            this.lblHelp.Size = new System.Drawing.Size(67, 15);
            this.lblHelp.TabIndex = 10;
            this.lblHelp.Text = "使用帮助";
            // 
            // lblSetting
            // 
            this.lblSetting.AutoSize = true;
            this.lblSetting.BackColor = System.Drawing.Color.Transparent;
            this.lblSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSetting.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblSetting.LineDistance = 5;
            this.lblSetting.Location = new System.Drawing.Point(72, 528);
            this.lblSetting.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSetting.Name = "lblSetting";
            this.lblSetting.ShowGlass = false;
            this.lblSetting.Size = new System.Drawing.Size(67, 15);
            this.lblSetting.TabIndex = 9;
            this.lblSetting.Text = "网络配置";
            this.lblSetting.Click += new System.EventHandler(this.lblSetting_Click);
            // 
            // lblFindPwd
            // 
            this.lblFindPwd.AutoSize = true;
            this.lblFindPwd.BackColor = System.Drawing.Color.Transparent;
            this.lblFindPwd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblFindPwd.LineDistance = 5;
            this.lblFindPwd.Location = new System.Drawing.Point(172, 491);
            this.lblFindPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFindPwd.Name = "lblFindPwd";
            this.lblFindPwd.ShowGlass = false;
            this.lblFindPwd.Size = new System.Drawing.Size(67, 15);
            this.lblFindPwd.TabIndex = 8;
            this.lblFindPwd.Text = "忘记密码";
            // 
            // lblRegister
            // 
            this.lblRegister.AutoSize = true;
            this.lblRegister.BackColor = System.Drawing.Color.Transparent;
            this.lblRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblRegister.LineDistance = 5;
            this.lblRegister.Location = new System.Drawing.Point(71, 491);
            this.lblRegister.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.ShowGlass = false;
            this.lblRegister.Size = new System.Drawing.Size(67, 15);
            this.lblRegister.TabIndex = 7;
            this.lblRegister.Text = "注册账号";
            // 
            // txtPwd
            // 
            this.txtPwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPwd.BackColor = System.Drawing.Color.Transparent;
            this.txtPwd.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPwd.Icon = null;
            this.txtPwd.IconIsButton = false;
            this.txtPwd.IsPasswordChat = '*';
            this.txtPwd.IsSystemPasswordChar = false;
            this.txtPwd.LeftIcon = null;
            this.txtPwd.Lines = new string[0];
            this.txtPwd.Location = new System.Drawing.Point(60, 312);
            this.txtPwd.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtPwd.MaxLength = 32767;
            this.txtPwd.MinimumSize = new System.Drawing.Size(133, 28);
            this.txtPwd.MouseBack = null;
            this.txtPwd.Multiline = false;
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.NormlBack = null;
            this.txtPwd.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtPwd.ReadOnly = false;
            this.txtPwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPwd.Size = new System.Drawing.Size(217, 35);
            this.txtPwd.TabIndex = 3;
            this.txtPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPwd.WaterColor = System.Drawing.Color.DarkGray;
            this.txtPwd.WaterText = "请输入密码";
            this.txtPwd.WordWrap = true;
            this.txtPwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPwd_KeyDown);
            // 
            // chkAuto
            // 
            this.chkAuto.AutoSize = true;
            this.chkAuto.BaseColor = System.Drawing.Color.Green;
            this.chkAuto.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.chkAuto.ControlState = UILibrary.ControlState.Normal;
            this.chkAuto.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkAuto.Location = new System.Drawing.Point(196, 362);
            this.chkAuto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(100, 27);
            this.chkAuto.TabIndex = 5;
            this.chkAuto.Text = "自动登录";
            this.chkAuto.UseVisualStyleBackColor = true;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // chkRemember
            // 
            this.chkRemember.AutoSize = true;
            this.chkRemember.BaseColor = System.Drawing.Color.Green;
            this.chkRemember.BorderColor = System.Drawing.Color.DarkGray;
            this.chkRemember.Checked = true;
            this.chkRemember.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemember.ControlState = UILibrary.ControlState.Normal;
            this.chkRemember.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chkRemember.Location = new System.Drawing.Point(52, 362);
            this.chkRemember.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.Size = new System.Drawing.Size(100, 27);
            this.chkRemember.TabIndex = 4;
            this.chkRemember.Text = "记住密码";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            this.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUser.BackColor = System.Drawing.Color.Transparent;
            this.txtUser.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.txtUser.Icon = null;
            this.txtUser.IconIsButton = false;
            this.txtUser.IsPasswordChat = '\0';
            this.txtUser.IsSystemPasswordChar = false;
            this.txtUser.LeftIcon = null;
            this.txtUser.Lines = new string[0];
            this.txtUser.Location = new System.Drawing.Point(60, 241);
            this.txtUser.Margin = new System.Windows.Forms.Padding(0);
            this.txtUser.MaxLength = 32767;
            this.txtUser.MinimumSize = new System.Drawing.Size(0, 35);
            this.txtUser.MouseBack = null;
            this.txtUser.Multiline = false;
            this.txtUser.Name = "txtUser";
            this.txtUser.NormlBack = null;
            this.txtUser.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.txtUser.ReadOnly = false;
            this.txtUser.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUser.Size = new System.Drawing.Size(217, 35);
            this.txtUser.TabIndex = 1;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.WaterColor = System.Drawing.Color.Gray;
            this.txtUser.WaterText = "请输入用户名";
            this.txtUser.WordWrap = false;
            this.txtUser.IconClick += new System.EventHandler(this.txtUser_IconClick);
            this.txtUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUser_KeyDown);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.ControlState = UILibrary.ControlState.Normal;
            this.btnLogin.DownBack = global::UILibrary.Properties.Resources.button_login_down;
            this.btnLogin.DrawType = UILibrary.DrawStyle.Img;
            this.btnLogin.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(108, 418);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.MouseBack = global::UILibrary.Properties.Resources.button_login_hover;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NormlBack = global::UILibrary.Properties.Resources.button_login_normal;
            this.btnLogin.Size = new System.Drawing.Size(113, 39);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "登 录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // avatarControl1
            // 
            this.avatarControl1.BackColor = System.Drawing.Color.Transparent;
            this.avatarControl1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("avatarControl1.BackgroundImage")));
            this.avatarControl1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avatarControl1.Location = new System.Drawing.Point(60, 34);
            this.avatarControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.avatarControl1.Name = "avatarControl1";
            this.avatarControl1.Padding = new System.Windows.Forms.Padding(11, 8, 11, 14);
            this.avatarControl1.Size = new System.Drawing.Size(152, 142);
            this.avatarControl1.TabIndex = 15;
            // 
            // pnlTipUser
            // 
            this.pnlTipUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(236)))));
            this.pnlTipUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipUser.Controls.Add(this.lblTipUser);
            this.pnlTipUser.Location = new System.Drawing.Point(61, 276);
            this.pnlTipUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTipUser.Name = "pnlTipUser";
            this.pnlTipUser.Size = new System.Drawing.Size(214, 31);
            this.pnlTipUser.TabIndex = 16;
            this.pnlTipUser.Visible = false;
            // 
            // lblTipUser
            // 
            this.lblTipUser.AutoSize = true;
            this.lblTipUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(36)))), ((int)(((byte)(57)))));
            this.lblTipUser.Location = new System.Drawing.Point(12, 9);
            this.lblTipUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipUser.Name = "lblTipUser";
            this.lblTipUser.Size = new System.Drawing.Size(0, 15);
            this.lblTipUser.TabIndex = 0;
            // 
            // pnlTipPwd
            // 
            this.pnlTipPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(236)))));
            this.pnlTipPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTipPwd.Controls.Add(this.lblTipPwd);
            this.pnlTipPwd.Location = new System.Drawing.Point(61, 348);
            this.pnlTipPwd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlTipPwd.Name = "pnlTipPwd";
            this.pnlTipPwd.Size = new System.Drawing.Size(214, 31);
            this.pnlTipPwd.TabIndex = 17;
            this.pnlTipPwd.Visible = false;
            // 
            // lblTipPwd
            // 
            this.lblTipPwd.AutoSize = true;
            this.lblTipPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(36)))), ((int)(((byte)(57)))));
            this.lblTipPwd.Location = new System.Drawing.Point(12, 9);
            this.lblTipPwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipPwd.Name = "lblTipPwd";
            this.lblTipPwd.Size = new System.Drawing.Size(0, 15);
            this.lblTipPwd.TabIndex = 0;
            // 
            // TCLoginControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.pnlTipPwd);
            this.Controls.Add(this.pnlTipUser);
            this.Controls.Add(this.avatarControl1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tcLabelPWD);
            this.Controls.Add(this.tcLabelUSER);
            this.Controls.Add(this.lblHelp);
            this.Controls.Add(this.lblSetting);
            this.Controls.Add(this.lblFindPwd);
            this.Controls.Add(this.lblRegister);
            this.Controls.Add(this.txtPwd);
            this.Controls.Add(this.chkAuto);
            this.Controls.Add(this.chkRemember);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TCLoginControl";
            this.Size = new System.Drawing.Size(333, 609);
            this.Load += new System.EventHandler(this.TCLoginControl_Load);
            this.SizeChanged += new System.EventHandler(this.TCLoginControl_SizeChanged);
            this.pnlTipUser.ResumeLayout(false);
            this.pnlTipUser.PerformLayout();
            this.pnlTipPwd.ResumeLayout(false);
            this.pnlTipPwd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TCCheckBox chkRemember;
        private TCCheckBox chkAuto;
        private SkinTextBox txtPwd;
        private TCLabel lblRegister;
        private TCLabel lblFindPwd;
        private TCLabel lblSetting;
        private TCLabel lblHelp;
        private SkinTextBox txtUser;
        private System.Windows.Forms.ContextMenuStrip menuUser;
        private TCLabel tcLabelPWD;
        private TCLabel tcLabelUSER;
        private SkinButtom btnLogin;
        private AvatarControl avatarControl1;
        private System.Windows.Forms.Panel pnlTipPwd;
        private System.Windows.Forms.Label lblTipPwd;
        private System.Windows.Forms.Panel pnlTipUser;
        private System.Windows.Forms.Label lblTipUser;
    }
}
