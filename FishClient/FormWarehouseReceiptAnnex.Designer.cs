namespace FishClient
{
    partial class FormWarehouseReceiptAnnex
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtLeiBie = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnEdit = new FishClient.UIControls.ButtonEx();
            this.btnDelete = new FishClient.UIControls.ButtonEx();
            this.btnAdd = new FishClient.UIControls.ButtonEx();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categroy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 1042);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 45);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1022, 997);
            this.panel3.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtLeiBie);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.btnEdit);
            this.splitContainer1.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pic);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 997);
            this.splitContainer1.SplitterDistance = 257;
            this.splitContainer1.TabIndex = 0;
            // 
            // txtLeiBie
            // 
            this.txtLeiBie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtLeiBie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtLeiBie.FormattingEnabled = true;
            this.txtLeiBie.Items.AddRange(new object[] {
            "质量报告",
            "三氯氰胺检测报告",
            "重量证明",
            "装箱单/重量备忘录",
            "熏蒸报告",
            "气味与结块的检验证书",
            "货船公司",
            "卫生证书",
            "产地证明",
            "发票",
            "清单",
            "无木字",
            "(MSDS)技术报告",
            "(IMO)危险品技术报告",
            "账单检查",
            "商检报告"});
            this.txtLeiBie.Location = new System.Drawing.Point(335, 16);
            this.txtLeiBie.Name = "txtLeiBie";
            this.txtLeiBie.Size = new System.Drawing.Size(300, 20);
            this.txtLeiBie.TabIndex = 150;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(20, 247);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 143;
            this.label13.Text = "预览";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(297, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 149;
            this.label14.Text = "类别";
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.ControlState = UILibrary.ControlState.Normal;
            this.btnEdit.DownBack = null;
            this.btnEdit.FormType = null;
            this.btnEdit.FunctionCode = "";
            this.btnEdit.Location = new System.Drawing.Point(78, 14);
            this.btnEdit.MouseBack = null;
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.NormlBack = null;
            this.btnEdit.Size = new System.Drawing.Size(51, 23);
            this.btnEdit.TabIndex = 148;
            this.btnEdit.Text = "编辑";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.ControlState = UILibrary.ControlState.Normal;
            this.btnDelete.DownBack = null;
            this.btnDelete.FormType = null;
            this.btnDelete.FunctionCode = "";
            this.btnDelete.Location = new System.Drawing.Point(135, 14);
            this.btnDelete.MouseBack = null;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.NormlBack = null;
            this.btnDelete.Size = new System.Drawing.Size(51, 23);
            this.btnDelete.TabIndex = 147;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.ControlState = UILibrary.ControlState.Normal;
            this.btnAdd.DownBack = null;
            this.btnAdd.FormType = null;
            this.btnAdd.FunctionCode = "";
            this.btnAdd.Location = new System.Drawing.Point(21, 14);
            this.btnAdd.MouseBack = null;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NormlBack = null;
            this.btnAdd.Size = new System.Drawing.Size(51, 23);
            this.btnAdd.TabIndex = 146;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tableId,
            this.tableName,
            this.categroy,
            this.picInfo,
            this.remark});
            this.dataGridView1.Location = new System.Drawing.Point(21, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(614, 199);
            this.dataGridView1.TabIndex = 145;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick_1);
            // 
            // tableId
            // 
            this.tableId.HeaderText = "表ID";
            this.tableId.Name = "tableId";
            this.tableId.ReadOnly = true;
            this.tableId.Visible = false;
            // 
            // tableName
            // 
            this.tableName.HeaderText = "表名";
            this.tableName.Name = "tableName";
            this.tableName.ReadOnly = true;
            this.tableName.Visible = false;
            // 
            // categroy
            // 
            this.categroy.HeaderText = "类别";
            this.categroy.Name = "categroy";
            this.categroy.ReadOnly = true;
            this.categroy.Width = 150;
            // 
            // picInfo
            // 
            this.picInfo.HeaderText = "图片";
            this.picInfo.Name = "picInfo";
            this.picInfo.ReadOnly = true;
            // 
            // remark
            // 
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 320;
            // 
            // pic
            // 
            this.pic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pic.Location = new System.Drawing.Point(0, 0);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(1022, 736);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 144;
            this.pic.TabStop = false;
            this.pic.Click += new System.EventHandler(this.pic_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtid);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtcode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1022, 45);
            this.panel2.TabIndex = 0;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(249, 11);
            this.txtid.Name = "txtid";
            this.txtid.ReadOnly = true;
            this.txtid.Size = new System.Drawing.Size(100, 21);
            this.txtid.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "id";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(91, 11);
            this.txtcode.Name = "txtcode";
            this.txtcode.ReadOnly = true;
            this.txtcode.Size = new System.Drawing.Size(100, 21);
            this.txtcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "进仓单单号";
            // 
            // FormWarehouseReceiptAnnex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 1100);
            this.Controls.Add(this.panel1);
            this.Name = "FormWarehouseReceiptAnnex";
            this.Text = "进仓单附件";
            this.Controls.SetChildIndex(this.panel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox txtLeiBie;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private UIControls.ButtonEx btnEdit;
        private UIControls.ButtonEx btnDelete;
        private UIControls.ButtonEx btnAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableId;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableName;
        private System.Windows.Forms.DataGridViewTextBoxColumn categroy;
        private System.Windows.Forms.DataGridViewTextBoxColumn picInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label2;
    }
}