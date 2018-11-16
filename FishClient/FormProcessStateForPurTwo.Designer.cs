namespace FishClient
{
    partial class FormProcessStateForPurTwo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components . Dispose ( );
            }
            base . Dispose ( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ( )
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCodeNumUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtsupplier = new System.Windows.Forms.TextBox();
            this.txtCodeNumContract = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodeNum = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comfishId = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.product_id = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.demand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createman2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coun1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coun2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coun4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(3, 55);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCodeNumUser);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtsupplier);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodeNumContract);
            this.splitContainer1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodeNum);
            this.splitContainer1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.comfishId);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1417, 439);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 286;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(908, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 283;
            this.label6.Text = "至";
            // 
            // cmbCodeNumUser
            // 
            this.cmbCodeNumUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodeNumUser.FormattingEnabled = true;
            this.cmbCodeNumUser.Location = new System.Drawing.Point(1091, 11);
            this.cmbCodeNumUser.Name = "cmbCodeNumUser";
            this.cmbCodeNumUser.Size = new System.Drawing.Size(99, 20);
            this.cmbCodeNumUser.TabIndex = 271;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1044, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 270;
            this.label4.Text = "所属人";
            // 
            // txtsupplier
            // 
            this.txtsupplier.Location = new System.Drawing.Point(656, 10);
            this.txtsupplier.Name = "txtsupplier";
            this.txtsupplier.Size = new System.Drawing.Size(100, 21);
            this.txtsupplier.TabIndex = 285;
            // 
            // txtCodeNumContract
            // 
            this.txtCodeNumContract.Location = new System.Drawing.Point(491, 11);
            this.txtCodeNumContract.Name = "txtCodeNumContract";
            this.txtCodeNumContract.Size = new System.Drawing.Size(100, 21);
            this.txtCodeNumContract.TabIndex = 269;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(931, 10);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(107, 21);
            this.dtpEnd.TabIndex = 282;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(408, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 268;
            this.label3.Text = "销售合同号";
            // 
            // txtCodeNum
            // 
            this.txtCodeNum.Location = new System.Drawing.Point(302, 11);
            this.txtCodeNum.Name = "txtCodeNum";
            this.txtCodeNum.Size = new System.Drawing.Size(100, 21);
            this.txtCodeNum.TabIndex = 267;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(795, 10);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(107, 21);
            this.dtpStart.TabIndex = 281;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(219, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "销售申请单号";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(760, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 280;
            this.label7.Text = "日期";
            // 
            // comfishId
            // 
            this.comfishId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comfishId.FormattingEnabled = true;
            this.comfishId.Location = new System.Drawing.Point(114, 12);
            this.comfishId.Name = "comfishId";
            this.comfishId.Size = new System.Drawing.Size(99, 20);
            this.comfishId.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(597, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 284;
            this.label5.Text = "需方单位";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "鱼粉ID";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.product_id,
            this.Numbering,
            this.ContractCode,
            this.demand,
            this.signDate,
            this.createman,
            this.code1,
            this.createman2,
            this.code2,
            this.Numbering1,
            this.coun,
            this.Numbering2,
            this.Numbering3,
            this.Numbering4,
            this.coun1,
            this.Numbering5,
            this.coun2,
            this.code3,
            this.Numbering6,
            this.coun4});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1417, 394);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // product_id
            // 
            this.product_id.DataPropertyName = "product_id";
            this.product_id.HeaderText = "鱼粉ID";
            this.product_id.Name = "product_id";
            this.product_id.ReadOnly = true;
            this.product_id.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.product_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Numbering
            // 
            this.Numbering.DataPropertyName = "Numbering";
            this.Numbering.HeaderText = "销售申请单";
            this.Numbering.Name = "Numbering";
            this.Numbering.ReadOnly = true;
            // 
            // ContractCode
            // 
            this.ContractCode.DataPropertyName = "ContractCode";
            this.ContractCode.HeaderText = "销售合同号";
            this.ContractCode.Name = "ContractCode";
            this.ContractCode.ReadOnly = true;
            // 
            // demand
            // 
            this.demand.DataPropertyName = "demand";
            this.demand.HeaderText = "需方";
            this.demand.Name = "demand";
            this.demand.ReadOnly = true;
            this.demand.Width = 150;
            // 
            // signDate
            // 
            this.signDate.DataPropertyName = "Signdate";
            this.signDate.HeaderText = "日期";
            this.signDate.Name = "signDate";
            this.signDate.ReadOnly = true;
            this.signDate.Width = 120;
            // 
            // createman
            // 
            this.createman.DataPropertyName = "createman";
            this.createman.HeaderText = "单据";
            this.createman.Name = "createman";
            this.createman.ReadOnly = true;
            this.createman.Width = 60;
            // 
            // code1
            // 
            this.code1.DataPropertyName = "code1";
            this.code1.HeaderText = "审核";
            this.code1.Name = "code1";
            this.code1.ReadOnly = true;
            this.code1.Width = 60;
            // 
            // createman2
            // 
            this.createman2.DataPropertyName = "createman2";
            this.createman2.HeaderText = "单据";
            this.createman2.Name = "createman2";
            this.createman2.ReadOnly = true;
            this.createman2.Width = 60;
            // 
            // code2
            // 
            this.code2.DataPropertyName = "code2";
            this.code2.HeaderText = "审核";
            this.code2.Name = "code2";
            this.code2.ReadOnly = true;
            this.code2.Width = 60;
            // 
            // Numbering1
            // 
            this.Numbering1.DataPropertyName = "Numbering1";
            this.Numbering1.HeaderText = "Numbering1";
            this.Numbering1.Name = "Numbering1";
            this.Numbering1.ReadOnly = true;
            this.Numbering1.Visible = false;
            // 
            // coun
            // 
            this.coun.DataPropertyName = "coun";
            this.coun.HeaderText = "coun";
            this.coun.Name = "coun";
            this.coun.ReadOnly = true;
            this.coun.Visible = false;
            // 
            // Numbering2
            // 
            this.Numbering2.DataPropertyName = "Numbering2";
            this.Numbering2.HeaderText = "出库单";
            this.Numbering2.Name = "Numbering2";
            this.Numbering2.ReadOnly = true;
            this.Numbering2.Width = 70;
            // 
            // Numbering3
            // 
            this.Numbering3.DataPropertyName = "Numbering3";
            this.Numbering3.HeaderText = "磅单";
            this.Numbering3.Name = "Numbering3";
            this.Numbering3.ReadOnly = true;
            this.Numbering3.Width = 60;
            // 
            // Numbering4
            // 
            this.Numbering4.DataPropertyName = "Numbering4";
            this.Numbering4.HeaderText = "单据";
            this.Numbering4.Name = "Numbering4";
            this.Numbering4.ReadOnly = true;
            this.Numbering4.Width = 60;
            // 
            // coun1
            // 
            this.coun1.DataPropertyName = "coun1";
            this.coun1.HeaderText = "审核";
            this.coun1.Name = "coun1";
            this.coun1.ReadOnly = true;
            this.coun1.Width = 60;
            // 
            // Numbering5
            // 
            this.Numbering5.DataPropertyName = "Numbering5";
            this.Numbering5.HeaderText = "单据";
            this.Numbering5.Name = "Numbering5";
            this.Numbering5.ReadOnly = true;
            this.Numbering5.Width = 60;
            // 
            // coun2
            // 
            this.coun2.DataPropertyName = "coun2";
            this.coun2.HeaderText = "审核";
            this.coun2.Name = "coun2";
            this.coun2.ReadOnly = true;
            this.coun2.Width = 60;
            // 
            // code3
            // 
            this.code3.DataPropertyName = "code3";
            this.code3.HeaderText = "退货单";
            this.code3.Name = "code3";
            this.code3.ReadOnly = true;
            this.code3.Width = 70;
            // 
            // Numbering6
            // 
            this.Numbering6.DataPropertyName = "Numbering6";
            this.Numbering6.HeaderText = "单据";
            this.Numbering6.Name = "Numbering6";
            this.Numbering6.ReadOnly = true;
            this.Numbering6.Width = 60;
            // 
            // coun4
            // 
            this.coun4.DataPropertyName = "coun4";
            this.coun4.HeaderText = "审核";
            this.coun4.Name = "coun4";
            this.coun4.ReadOnly = true;
            this.coun4.Width = 60;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            this.设置列宽toolStripMenuItem.Click += new System.EventHandler(this.设置列宽toolStripMenuItem_Click);
            // 
            // FormProcessStateForPurTwo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 497);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormProcessStateForPurTwo";
            this.Text = "销售流程状态表2(销售申请单--出库单--收款记录单)";
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System . Windows . Forms . SplitContainer splitContainer1;
        private System . Windows . Forms . ComboBox cmbCodeNumUser;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . TextBox txtCodeNumContract;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . TextBox txtCodeNum;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . ComboBox comfishId;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . DataGridView dataGridView1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsupplier;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewLinkColumn product_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn demand;
        private System.Windows.Forms.DataGridViewTextBoxColumn signDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn createman;
        private System.Windows.Forms.DataGridViewTextBoxColumn code1;
        private System.Windows.Forms.DataGridViewTextBoxColumn createman2;
        private System.Windows.Forms.DataGridViewTextBoxColumn code2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering1;
        private System.Windows.Forms.DataGridViewTextBoxColumn coun;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering4;
        private System.Windows.Forms.DataGridViewTextBoxColumn coun1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering5;
        private System.Windows.Forms.DataGridViewTextBoxColumn coun2;
        private System.Windows.Forms.DataGridViewTextBoxColumn code3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering6;
        private System.Windows.Forms.DataGridViewTextBoxColumn coun4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}