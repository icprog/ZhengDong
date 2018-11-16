namespace FishClient
{
    partial class FormProcessStateForSaleOne
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
            this.txtsupplier = new System.Windows.Forms.TextBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCodeNumUser = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodeNumContract = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCodeNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comfishId = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.fishId = new System.Windows.Forms.DataGridViewLinkColumn();
            this.codeNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNumContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createUser1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeNum2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shenhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jindan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.splitContainer1.Panel1.Controls.Add(this.txtsupplier);
            this.splitContainer1.Panel1.Controls.Add(this.dtpEnd);
            this.splitContainer1.Panel1.Controls.Add(this.dtpStart);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.cmbCodeNumUser);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodeNumContract);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txtCodeNum);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comfishId);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(1186, 438);
            this.splitContainer1.SplitterDistance = 41;
            this.splitContainer1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button1.Location = new System.Drawing.Point(7, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 274;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(887, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "至";
            // 
            // txtsupplier
            // 
            this.txtsupplier.Location = new System.Drawing.Point(635, 12);
            this.txtsupplier.Name = "txtsupplier";
            this.txtsupplier.Size = new System.Drawing.Size(100, 21);
            this.txtsupplier.TabIndex = 273;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(910, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(107, 21);
            this.dtpEnd.TabIndex = 12;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(774, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(107, 21);
            this.dtpStart.TabIndex = 11;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(576, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 272;
            this.label5.Text = "供方单位";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(739, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "日期";
            // 
            // cmbCodeNumUser
            // 
            this.cmbCodeNumUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodeNumUser.FormattingEnabled = true;
            this.cmbCodeNumUser.Location = new System.Drawing.Point(1078, 13);
            this.cmbCodeNumUser.Name = "cmbCodeNumUser";
            this.cmbCodeNumUser.Size = new System.Drawing.Size(99, 20);
            this.cmbCodeNumUser.TabIndex = 271;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1031, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 270;
            this.label4.Text = "所属人";
            // 
            // txtCodeNumContract
            // 
            this.txtCodeNumContract.Location = new System.Drawing.Point(470, 12);
            this.txtCodeNumContract.Name = "txtCodeNumContract";
            this.txtCodeNumContract.Size = new System.Drawing.Size(100, 21);
            this.txtCodeNumContract.TabIndex = 269;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(399, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 268;
            this.label3.Text = "采购合同号";
            // 
            // txtCodeNum
            // 
            this.txtCodeNum.Location = new System.Drawing.Point(293, 12);
            this.txtCodeNum.Name = "txtCodeNum";
            this.txtCodeNum.Size = new System.Drawing.Size(100, 21);
            this.txtCodeNum.TabIndex = 267;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "采购申请单号";
            // 
            // comfishId
            // 
            this.comfishId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comfishId.FormattingEnabled = true;
            this.comfishId.Location = new System.Drawing.Point(105, 13);
            this.comfishId.Name = "comfishId";
            this.comfishId.Size = new System.Drawing.Size(99, 20);
            this.comfishId.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 16);
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
            this.fishId,
            this.codeNum,
            this.codeNumContract,
            this.supplier,
            this.signDate,
            this.weight,
            this.proName,
            this.createUser,
            this.Numbering,
            this.createUser1,
            this.Numbering1,
            this.codeNum2,
            this.shenhe,
            this.jindan1,
            this.code2});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1186, 393);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // fishId
            // 
            this.fishId.DataPropertyName = "fishId";
            this.fishId.HeaderText = "鱼粉ID";
            this.fishId.Name = "fishId";
            this.fishId.ReadOnly = true;
            this.fishId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fishId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // codeNum
            // 
            this.codeNum.DataPropertyName = "codeNum";
            this.codeNum.HeaderText = "采购申请单";
            this.codeNum.Name = "codeNum";
            this.codeNum.ReadOnly = true;
            // 
            // codeNumContract
            // 
            this.codeNumContract.DataPropertyName = "codeNumContract";
            this.codeNumContract.HeaderText = "采购合同";
            this.codeNumContract.Name = "codeNumContract";
            this.codeNumContract.ReadOnly = true;
            // 
            // supplier
            // 
            this.supplier.DataPropertyName = "supplier";
            this.supplier.HeaderText = "供方";
            this.supplier.Name = "supplier";
            this.supplier.ReadOnly = true;
            this.supplier.Width = 150;
            // 
            // signDate
            // 
            this.signDate.DataPropertyName = "signDate";
            this.signDate.HeaderText = "日期";
            this.signDate.Name = "signDate";
            this.signDate.ReadOnly = true;
            this.signDate.Width = 120;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "采购重量";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 45;
            // 
            // proName
            // 
            this.proName.DataPropertyName = "proName";
            this.proName.HeaderText = "产品名称";
            this.proName.Name = "proName";
            this.proName.ReadOnly = true;
            this.proName.Width = 78;
            // 
            // createUser
            // 
            this.createUser.DataPropertyName = "createUser";
            this.createUser.HeaderText = "单据";
            this.createUser.Name = "createUser";
            this.createUser.ReadOnly = true;
            this.createUser.Width = 60;
            // 
            // Numbering
            // 
            this.Numbering.DataPropertyName = "Numbering";
            this.Numbering.HeaderText = "审核";
            this.Numbering.Name = "Numbering";
            this.Numbering.ReadOnly = true;
            this.Numbering.Width = 60;
            // 
            // createUser1
            // 
            this.createUser1.DataPropertyName = "createUser1";
            this.createUser1.HeaderText = "单据";
            this.createUser1.Name = "createUser1";
            this.createUser1.ReadOnly = true;
            this.createUser1.Width = 60;
            // 
            // Numbering1
            // 
            this.Numbering1.DataPropertyName = "Numbering1";
            this.Numbering1.HeaderText = "审核";
            this.Numbering1.Name = "Numbering1";
            this.Numbering1.ReadOnly = true;
            this.Numbering1.Width = 60;
            // 
            // codeNum2
            // 
            this.codeNum2.DataPropertyName = "codeNum2";
            this.codeNum2.HeaderText = "单据";
            this.codeNum2.Name = "codeNum2";
            this.codeNum2.ReadOnly = true;
            this.codeNum2.Width = 60;
            // 
            // shenhe
            // 
            this.shenhe.DataPropertyName = "shenhe";
            this.shenhe.HeaderText = "审核";
            this.shenhe.Name = "shenhe";
            this.shenhe.ReadOnly = true;
            this.shenhe.Width = 60;
            // 
            // jindan1
            // 
            this.jindan1.DataPropertyName = "jindan1";
            this.jindan1.HeaderText = "进仓单";
            this.jindan1.Name = "jindan1";
            this.jindan1.ReadOnly = true;
            this.jindan1.Width = 70;
            // 
            // code2
            // 
            this.code2.DataPropertyName = "code2";
            this.code2.HeaderText = "行情定价单";
            this.code2.Name = "code2";
            this.code2.ReadOnly = true;
            this.code2.Visible = false;
            this.code2.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "fishId";
            this.dataGridViewTextBoxColumn1.HeaderText = "鱼粉ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codeNum";
            this.dataGridViewTextBoxColumn2.HeaderText = "采购申请单";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "codeNumContract";
            this.dataGridViewTextBoxColumn3.HeaderText = "采购合同";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "supplier";
            this.dataGridViewTextBoxColumn4.HeaderText = "供方";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "signDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "日期";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "createUser";
            this.dataGridViewTextBoxColumn6.HeaderText = "采购申请单";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "code";
            this.dataGridViewTextBoxColumn7.HeaderText = "采购合同";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "createUser1";
            this.dataGridViewTextBoxColumn8.HeaderText = "付款申请单";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "code1";
            this.dataGridViewTextBoxColumn9.HeaderText = "进仓单";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "coun";
            this.dataGridViewTextBoxColumn10.HeaderText = "行情定价单";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "weight";
            this.dataGridViewTextBoxColumn11.HeaderText = "进仓单";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "行情定价单";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
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
            // FormProcessStateForSaleOne
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 496);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormProcessStateForSaleOne";
            this.Text = "采购流程状态表1（采购申请单-->行情定价单）";
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
        private System . Windows . Forms . DataGridView dataGridView1;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System . Windows . Forms . ComboBox comfishId;
        private System . Windows . Forms . Label label2;
        private System . Windows . Forms . Label label1;
        private System . Windows . Forms . TextBox txtCodeNumContract;
        private System . Windows . Forms . Label label3;
        private System . Windows . Forms . TextBox txtCodeNum;
        private System . Windows . Forms . ComboBox cmbCodeNumUser;
        private System . Windows . Forms . Label label4;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System . Windows . Forms . DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.TextBox txtsupplier;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewLinkColumn fishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNumContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn signDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn proName;
        private System.Windows.Forms.DataGridViewTextBoxColumn createUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn createUser1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeNum2;
        private System.Windows.Forms.DataGridViewTextBoxColumn shenhe;
        private System.Windows.Forms.DataGridViewTextBoxColumn jindan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn code2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}