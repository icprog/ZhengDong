namespace TCUILibrary.Controls
{
    partial class CallNumberSettingControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CallNumberSettingControl));
            this.btnTestUrl = new TCUILibrary.TCButton();
            this.textBoxCallServiceUrlPort = new TCUILibrary.TCTextBox();
            this.textBoxCallServiceUrl = new TCUILibrary.TCTextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtDisplayIP = new TCUILibrary.TCTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDisplayPort = new TCUILibrary.TCTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDisplayPeriod = new TCUILibrary.TCTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.columnControl1 = new TCUILibrary.ColumnControl();
            this.columnControl2 = new TCUILibrary.ColumnControl();
            this.btnStart = new TCUILibrary.TCButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDisplayArea = new TCUILibrary.TCTextBox();
            this.txtDisplayOffice = new TCUILibrary.TCTextBox();
            this.tcPanel1 = new TCUILibrary.TCPanel();
            this.tcPanel2 = new TCUILibrary.TCPanel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tcPanel1.SuspendLayout();
            this.tcPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTestUrl
            // 
            this.btnTestUrl.BackColor = System.Drawing.Color.Transparent;
            this.btnTestUrl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestUrl.BackgroundImage")));
            this.btnTestUrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTestUrl.FlatAppearance.BorderSize = 0;
            this.btnTestUrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestUrl.Location = new System.Drawing.Point(227, 61);
            this.btnTestUrl.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnTestUrl.MouseDownImage")));
            this.btnTestUrl.MouseHoverImage = ((System.Drawing.Image)(resources.GetObject("btnTestUrl.MouseHoverImage")));
            this.btnTestUrl.MouseNormalImage = ((System.Drawing.Image)(resources.GetObject("btnTestUrl.MouseNormalImage")));
            this.btnTestUrl.Name = "btnTestUrl";
            this.btnTestUrl.Padding = new System.Windows.Forms.Padding(3);
            this.btnTestUrl.Size = new System.Drawing.Size(75, 28);
            this.btnTestUrl.TabIndex = 14;
            this.btnTestUrl.Text = "测试叫号";
            this.btnTestUrl.UseVisualStyleBackColor = false;
            this.btnTestUrl.Click += new System.EventHandler(this.btnTestUrl_Click);
            // 
            // textBoxCallServiceUrlPort
            // 
            this.textBoxCallServiceUrlPort.BackColor = System.Drawing.Color.Transparent;
            this.textBoxCallServiceUrlPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCallServiceUrlPort.Location = new System.Drawing.Point(79, 61);
            this.textBoxCallServiceUrlPort.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCallServiceUrlPort.MinimumSize = new System.Drawing.Size(0, 28);
            this.textBoxCallServiceUrlPort.MouseHoverImage = null;
            this.textBoxCallServiceUrlPort.MouseNormalImage = null;
            this.textBoxCallServiceUrlPort.Name = "textBoxCallServiceUrlPort";
            this.textBoxCallServiceUrlPort.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxCallServiceUrlPort.PasswordChar = '\0';
            this.textBoxCallServiceUrlPort.Size = new System.Drawing.Size(145, 28);
            this.textBoxCallServiceUrlPort.TabIndex = 13;
            this.textBoxCallServiceUrlPort.WaterColor = System.Drawing.Color.DarkGray;
            this.textBoxCallServiceUrlPort.WaterText = "";
            // 
            // textBoxCallServiceUrl
            // 
            this.textBoxCallServiceUrl.BackColor = System.Drawing.Color.Transparent;
            this.textBoxCallServiceUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCallServiceUrl.Location = new System.Drawing.Point(79, 20);
            this.textBoxCallServiceUrl.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCallServiceUrl.MinimumSize = new System.Drawing.Size(0, 28);
            this.textBoxCallServiceUrl.MouseHoverImage = null;
            this.textBoxCallServiceUrl.MouseNormalImage = null;
            this.textBoxCallServiceUrl.Name = "textBoxCallServiceUrl";
            this.textBoxCallServiceUrl.Padding = new System.Windows.Forms.Padding(5);
            this.textBoxCallServiceUrl.PasswordChar = '\0';
            this.textBoxCallServiceUrl.Size = new System.Drawing.Size(227, 28);
            this.textBoxCallServiceUrl.TabIndex = 12;
            this.textBoxCallServiceUrl.WaterColor = System.Drawing.Color.DarkGray;
            this.textBoxCallServiceUrl.WaterText = "";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 27);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(65, 12);
            this.label25.TabIndex = 7;
            this.label25.Text = "叫号服务IP";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(19, 70);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 9;
            this.label26.Text = "叫号端口";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "IP地址";
            // 
            // txtDisplayIP
            // 
            this.txtDisplayIP.BackColor = System.Drawing.Color.Transparent;
            this.txtDisplayIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisplayIP.Location = new System.Drawing.Point(78, 9);
            this.txtDisplayIP.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplayIP.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDisplayIP.MouseHoverImage = null;
            this.txtDisplayIP.MouseNormalImage = null;
            this.txtDisplayIP.Name = "txtDisplayIP";
            this.txtDisplayIP.Padding = new System.Windows.Forms.Padding(5);
            this.txtDisplayIP.PasswordChar = '\0';
            this.txtDisplayIP.Size = new System.Drawing.Size(227, 28);
            this.txtDisplayIP.TabIndex = 16;
            this.txtDisplayIP.WaterColor = System.Drawing.Color.DarkGray;
            this.txtDisplayIP.WaterText = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "端口";
            // 
            // txtDisplayPort
            // 
            this.txtDisplayPort.BackColor = System.Drawing.Color.Transparent;
            this.txtDisplayPort.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisplayPort.Location = new System.Drawing.Point(78, 44);
            this.txtDisplayPort.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplayPort.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDisplayPort.MouseHoverImage = null;
            this.txtDisplayPort.MouseNormalImage = null;
            this.txtDisplayPort.Name = "txtDisplayPort";
            this.txtDisplayPort.Padding = new System.Windows.Forms.Padding(5);
            this.txtDisplayPort.PasswordChar = '\0';
            this.txtDisplayPort.Size = new System.Drawing.Size(227, 28);
            this.txtDisplayPort.TabIndex = 18;
            this.txtDisplayPort.WaterColor = System.Drawing.Color.DarkGray;
            this.txtDisplayPort.WaterText = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 19;
            this.label4.Text = "刷新周期";
            // 
            // txtDisplayPeriod
            // 
            this.txtDisplayPeriod.BackColor = System.Drawing.Color.Transparent;
            this.txtDisplayPeriod.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisplayPeriod.Location = new System.Drawing.Point(78, 79);
            this.txtDisplayPeriod.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplayPeriod.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDisplayPeriod.MouseHoverImage = null;
            this.txtDisplayPeriod.MouseNormalImage = null;
            this.txtDisplayPeriod.Name = "txtDisplayPeriod";
            this.txtDisplayPeriod.Padding = new System.Windows.Forms.Padding(5);
            this.txtDisplayPeriod.PasswordChar = '\0';
            this.txtDisplayPeriod.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDisplayPeriod.Size = new System.Drawing.Size(227, 28);
            this.txtDisplayPeriod.TabIndex = 20;
            this.txtDisplayPeriod.WaterColor = System.Drawing.Color.DarkGray;
            this.txtDisplayPeriod.WaterText = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(308, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "秒";
            // 
            // columnControl1
            // 
            this.columnControl1.BackColor = System.Drawing.Color.Transparent;
            this.columnControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.columnControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.columnControl1.LineColor = System.Drawing.Color.LightGray;
            this.columnControl1.LineWidth = 1.8F;
            this.columnControl1.Location = new System.Drawing.Point(0, 140);
            this.columnControl1.Name = "columnControl1";
            this.columnControl1.Padding = new System.Windows.Forms.Padding(5);
            this.columnControl1.Size = new System.Drawing.Size(685, 23);
            this.columnControl1.TabIndex = 22;
            this.columnControl1.Text = "显示屏设置";
            this.columnControl1.Title = "显示屏设置";
            // 
            // columnControl2
            // 
            this.columnControl2.BackColor = System.Drawing.Color.Transparent;
            this.columnControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.columnControl2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.columnControl2.LineColor = System.Drawing.Color.LightGray;
            this.columnControl2.LineWidth = 1.5F;
            this.columnControl2.Location = new System.Drawing.Point(0, 0);
            this.columnControl2.Name = "columnControl2";
            this.columnControl2.Padding = new System.Windows.Forms.Padding(5);
            this.columnControl2.Size = new System.Drawing.Size(685, 23);
            this.columnControl2.TabIndex = 23;
            this.columnControl2.Text = "语音叫号设置";
            this.columnControl2.Title = "语音叫号设置";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Transparent;
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Location = new System.Drawing.Point(226, 197);
            this.btnStart.MouseDownImage = ((System.Drawing.Image)(resources.GetObject("btnStart.MouseDownImage")));
            this.btnStart.MouseHoverImage = ((System.Drawing.Image)(resources.GetObject("btnStart.MouseHoverImage")));
            this.btnStart.MouseNormalImage = ((System.Drawing.Image)(resources.GetObject("btnStart.MouseNormalImage")));
            this.btnStart.Name = "btnStart";
            this.btnStart.Padding = new System.Windows.Forms.Padding(3);
            this.btnStart.Size = new System.Drawing.Size(75, 28);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 25;
            this.label1.Text = "设置诊区";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "设置科室";
            // 
            // txtDisplayArea
            // 
            this.txtDisplayArea.BackColor = System.Drawing.Color.Transparent;
            this.txtDisplayArea.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisplayArea.Location = new System.Drawing.Point(78, 115);
            this.txtDisplayArea.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplayArea.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDisplayArea.MouseHoverImage = null;
            this.txtDisplayArea.MouseNormalImage = null;
            this.txtDisplayArea.Name = "txtDisplayArea";
            this.txtDisplayArea.Padding = new System.Windows.Forms.Padding(5);
            this.txtDisplayArea.PasswordChar = '\0';
            this.txtDisplayArea.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDisplayArea.Size = new System.Drawing.Size(227, 28);
            this.txtDisplayArea.TabIndex = 27;
            this.txtDisplayArea.WaterColor = System.Drawing.Color.DarkGray;
            this.txtDisplayArea.WaterText = "";
            // 
            // txtDisplayOffice
            // 
            this.txtDisplayOffice.BackColor = System.Drawing.Color.Transparent;
            this.txtDisplayOffice.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDisplayOffice.Location = new System.Drawing.Point(78, 153);
            this.txtDisplayOffice.Margin = new System.Windows.Forms.Padding(0);
            this.txtDisplayOffice.MinimumSize = new System.Drawing.Size(0, 28);
            this.txtDisplayOffice.MouseHoverImage = null;
            this.txtDisplayOffice.MouseNormalImage = null;
            this.txtDisplayOffice.Name = "txtDisplayOffice";
            this.txtDisplayOffice.Padding = new System.Windows.Forms.Padding(5);
            this.txtDisplayOffice.PasswordChar = '\0';
            this.txtDisplayOffice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDisplayOffice.Size = new System.Drawing.Size(227, 28);
            this.txtDisplayOffice.TabIndex = 28;
            this.txtDisplayOffice.WaterColor = System.Drawing.Color.DarkGray;
            this.txtDisplayOffice.WaterText = "";
            // 
            // tcPanel1
            // 
            this.tcPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tcPanel1.Controls.Add(this.btnTestUrl);
            this.tcPanel1.Controls.Add(this.label26);
            this.tcPanel1.Controls.Add(this.label25);
            this.tcPanel1.Controls.Add(this.textBoxCallServiceUrl);
            this.tcPanel1.Controls.Add(this.textBoxCallServiceUrlPort);
            this.tcPanel1.ControlState = TCUILibrary.ControlState.Normal;
            this.tcPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcPanel1.Location = new System.Drawing.Point(0, 23);
            this.tcPanel1.MouseDownImg = null;
            this.tcPanel1.MouseHoverImg = null;
            this.tcPanel1.MouseNormalImg = null;
            this.tcPanel1.Name = "tcPanel1";
            this.tcPanel1.Radius = 0;
            this.tcPanel1.Size = new System.Drawing.Size(685, 117);
            this.tcPanel1.TabIndex = 29;
            // 
            // tcPanel2
            // 
            this.tcPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tcPanel2.Controls.Add(this.txtDisplayPeriod);
            this.tcPanel2.Controls.Add(this.txtDisplayOffice);
            this.tcPanel2.Controls.Add(this.label2);
            this.tcPanel2.Controls.Add(this.txtDisplayArea);
            this.tcPanel2.Controls.Add(this.txtDisplayIP);
            this.tcPanel2.Controls.Add(this.label6);
            this.tcPanel2.Controls.Add(this.label3);
            this.tcPanel2.Controls.Add(this.label1);
            this.tcPanel2.Controls.Add(this.txtDisplayPort);
            this.tcPanel2.Controls.Add(this.btnStart);
            this.tcPanel2.Controls.Add(this.label4);
            this.tcPanel2.Controls.Add(this.label5);
            this.tcPanel2.ControlState = TCUILibrary.ControlState.Normal;
            this.tcPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcPanel2.Location = new System.Drawing.Point(0, 163);
            this.tcPanel2.MouseDownImg = null;
            this.tcPanel2.MouseHoverImg = null;
            this.tcPanel2.MouseNormalImg = null;
            this.tcPanel2.Name = "tcPanel2";
            this.tcPanel2.Radius = 0;
            this.tcPanel2.Size = new System.Drawing.Size(685, 242);
            this.tcPanel2.TabIndex = 30;
            // 
            // CallNumberSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tcPanel2);
            this.Controls.Add(this.columnControl1);
            this.Controls.Add(this.tcPanel1);
            this.Controls.Add(this.columnControl2);
            this.Name = "CallNumberSettingControl";
            this.Size = new System.Drawing.Size(685, 485);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tcPanel1.ResumeLayout(false);
            this.tcPanel1.PerformLayout();
            this.tcPanel2.ResumeLayout(false);
            this.tcPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private TCTextBox textBoxCallServiceUrlPort;
        private TCTextBox textBoxCallServiceUrl;
        private TCButton btnTestUrl;
        private TCTextBox txtDisplayPort;
        private System.Windows.Forms.Label label3;
        private TCTextBox txtDisplayIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private TCTextBox txtDisplayPeriod;
        private System.Windows.Forms.Label label4;
        private ColumnControl columnControl2;
        private ColumnControl columnControl1;
        private TCTextBox txtDisplayOffice;
        private TCTextBox txtDisplayArea;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private TCButton btnStart;
        private TCPanel tcPanel1;
        private TCPanel tcPanel2;
    }
}
