namespace Test
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点0");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("节点4");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("节点5");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("节点6");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("节点7");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("节点8");
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.pushPanel1 = new UILibrary.PushPanel.PushPanel();
            this.pushPanelItem1 = new UILibrary.PushPanel.PushPanelItem();
            this.skinButtom5 = new UILibrary.SkinButtom();
            this.skinButtom4 = new UILibrary.SkinButtom();
            this.skinButtom3 = new UILibrary.SkinButtom();
            this.skinButtom2 = new UILibrary.SkinButtom();
            this.skinButtom1 = new UILibrary.SkinButtom();
            this.pushPanelItem2 = new UILibrary.PushPanel.PushPanelItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeViewEx1 = new Test.TreeViewEx();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).BeginInit();
            this.pushPanel1.SuspendLayout();
            this.pushPanelItem1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开启10个线程，获得编号";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(13, 58);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(104, 184);
            this.listBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(267, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(162, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 40);
            this.panel1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(162, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "fg",
            "g"});
            this.comboBox1.Location = new System.Drawing.Point(150, 180);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 5;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(244, 98);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "YYYY-MM-DD HH:mm:ss";
            this.dateTimePicker1.Location = new System.Drawing.Point(150, 245);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(150, 297);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pushPanel1
            // 
            this.pushPanel1.Items.AddRange(new UILibrary.PushPanel.PushPanelItem[] {
            this.pushPanelItem1,
            this.pushPanelItem2});
            this.pushPanel1.Location = new System.Drawing.Point(407, 53);
            this.pushPanel1.Name = "pushPanel1";
            this.pushPanel1.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanel1.Size = new System.Drawing.Size(200, 323);
            this.pushPanel1.TabIndex = 9;
            // 
            // pushPanelItem1
            // 
            this.pushPanelItem1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem1.Controls.Add(this.skinButtom5);
            this.pushPanelItem1.Controls.Add(this.skinButtom4);
            this.pushPanelItem1.Controls.Add(this.skinButtom3);
            this.pushPanelItem1.Controls.Add(this.skinButtom2);
            this.pushPanelItem1.Controls.Add(this.skinButtom1);
            this.pushPanelItem1.Name = "pushPanelItem1";
            this.pushPanelItem1.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanelItem1.Text = "pushPanelItem1";
            // 
            // skinButtom5
            // 
            this.skinButtom5.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom5.ControlState = UILibrary.ControlState.Normal;
            this.skinButtom5.DownBack = null;
            this.skinButtom5.DrawType = UILibrary.DrawStyle.None;
            this.skinButtom5.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom5.Image")));
            this.skinButtom5.Location = new System.Drawing.Point(26, 211);
            this.skinButtom5.MouseBack = null;
            this.skinButtom5.Name = "skinButtom5";
            this.skinButtom5.NormlBack = null;
            this.skinButtom5.Size = new System.Drawing.Size(138, 35);
            this.skinButtom5.TabIndex = 4;
            this.skinButtom5.Text = "鱼粉资料";
            this.skinButtom5.UseVisualStyleBackColor = false;
            // 
            // skinButtom4
            // 
            this.skinButtom4.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom4.ControlState = UILibrary.ControlState.Normal;
            this.skinButtom4.DownBack = null;
            this.skinButtom4.DrawType = UILibrary.DrawStyle.None;
            this.skinButtom4.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom4.Image")));
            this.skinButtom4.Location = new System.Drawing.Point(26, 170);
            this.skinButtom4.MouseBack = null;
            this.skinButtom4.Name = "skinButtom4";
            this.skinButtom4.NormlBack = null;
            this.skinButtom4.Size = new System.Drawing.Size(122, 35);
            this.skinButtom4.TabIndex = 3;
            this.skinButtom4.Text = "联系人";
            this.skinButtom4.UseVisualStyleBackColor = false;
            // 
            // skinButtom3
            // 
            this.skinButtom3.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom3.ControlState = UILibrary.ControlState.Normal;
            this.skinButtom3.DownBack = null;
            this.skinButtom3.DrawType = UILibrary.DrawStyle.None;
            this.skinButtom3.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom3.Image")));
            this.skinButtom3.Location = new System.Drawing.Point(26, 129);
            this.skinButtom3.MouseBack = null;
            this.skinButtom3.Name = "skinButtom3";
            this.skinButtom3.NormlBack = null;
            this.skinButtom3.Size = new System.Drawing.Size(138, 35);
            this.skinButtom3.TabIndex = 2;
            this.skinButtom3.Text = "往来单位";
            this.skinButtom3.UseVisualStyleBackColor = false;
            // 
            // skinButtom2
            // 
            this.skinButtom2.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom2.ControlState = UILibrary.ControlState.Normal;
            this.skinButtom2.DownBack = null;
            this.skinButtom2.DrawType = UILibrary.DrawStyle.None;
            this.skinButtom2.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom2.Image")));
            this.skinButtom2.Location = new System.Drawing.Point(26, 84);
            this.skinButtom2.MouseBack = null;
            this.skinButtom2.Name = "skinButtom2";
            this.skinButtom2.NormlBack = null;
            this.skinButtom2.Size = new System.Drawing.Size(138, 35);
            this.skinButtom2.TabIndex = 1;
            this.skinButtom2.Text = "业务数据";
            this.skinButtom2.UseVisualStyleBackColor = false;
            // 
            // skinButtom1
            // 
            this.skinButtom1.BackColor = System.Drawing.Color.Transparent;
            this.skinButtom1.ControlState = UILibrary.ControlState.Normal;
            this.skinButtom1.DownBack = null;
            this.skinButtom1.DrawType = UILibrary.DrawStyle.None;
            this.skinButtom1.Image = ((System.Drawing.Image)(resources.GetObject("skinButtom1.Image")));
            this.skinButtom1.Location = new System.Drawing.Point(26, 43);
            this.skinButtom1.MouseBack = null;
            this.skinButtom1.Name = "skinButtom1";
            this.skinButtom1.NormlBack = null;
            this.skinButtom1.Size = new System.Drawing.Size(138, 35);
            this.skinButtom1.TabIndex = 0;
            this.skinButtom1.Text = "系统数据";
            this.skinButtom1.UseVisualStyleBackColor = false;
            // 
            // pushPanelItem2
            // 
            this.pushPanelItem2.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem2.Name = "pushPanelItem2";
            this.pushPanelItem2.RoundStyle = UILibrary.RoundStyle.All;
            this.pushPanelItem2.Text = "pushPanelItem2";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "damotouicon.ico");
            this.imageList1.Images.SetKeyName(1, "logo.jpg");
            // 
            // treeViewEx1
            // 
            this.treeViewEx1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewEx1.ImageIndex = 0;
            this.treeViewEx1.ImageList = this.imageList1;
            this.treeViewEx1.Location = new System.Drawing.Point(70, 351);
            this.treeViewEx1.Name = "treeViewEx1";
            treeNode1.Name = "节点0";
            treeNode1.Text = "节点0";
            treeNode2.Name = "节点1";
            treeNode2.Text = "节点1";
            treeNode3.Name = "节点2";
            treeNode3.Text = "节点2";
            treeNode4.Name = "节点3";
            treeNode4.Text = "节点3";
            treeNode5.Name = "节点4";
            treeNode5.Text = "节点4";
            treeNode6.Name = "节点5";
            treeNode6.Text = "节点5";
            treeNode7.Name = "节点6";
            treeNode7.Text = "节点6";
            treeNode8.Name = "节点7";
            treeNode8.Text = "节点7";
            treeNode9.Name = "节点8";
            treeNode9.Text = "节点8";
            this.treeViewEx1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            this.treeViewEx1.SelectedImageIndex = 0;
            this.treeViewEx1.Size = new System.Drawing.Size(187, 225);
            this.treeViewEx1.TabIndex = 10;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(283, 490);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 11;
            this.button6.Text = "导出Excel";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 626);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.treeViewEx1);
            this.Controls.Add(this.pushPanel1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).EndInit();
            this.pushPanel1.ResumeLayout(false);
            this.pushPanelItem1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button5;
        private UILibrary.PushPanel.PushPanel pushPanel1;
        private UILibrary.PushPanel.PushPanelItem pushPanelItem1;
        private UILibrary.PushPanel.PushPanelItem pushPanelItem2;
        private TreeViewEx treeViewEx1;
        private System.Windows.Forms.ImageList imageList1;
        private UILibrary.SkinButtom skinButtom5;
        private UILibrary.SkinButtom skinButtom4;
        private UILibrary.SkinButtom skinButtom3;
        private UILibrary.SkinButtom skinButtom2;
        private UILibrary.SkinButtom skinButtom1;
        private System.Windows.Forms.Button button6;
    }
}

