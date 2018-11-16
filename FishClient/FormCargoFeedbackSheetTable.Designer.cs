namespace FishClient
{
    partial class FormCargoFeedbackSheetTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCompetition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.code = new System.Windows.Forms.DataGridViewLinkColumn();
            this.createman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FishMealId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoundBillNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sponsor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acceptor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PoundDifference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConfirmTheWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.processresult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.evaluation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCompetition);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(744, 40);
            this.panel1.TabIndex = 1;
            // 
            // txtCompetition
            // 
            this.txtCompetition.Location = new System.Drawing.Point(75, 10);
            this.txtCompetition.Name = "txtCompetition";
            this.txtCompetition.Size = new System.Drawing.Size(100, 21);
            this.txtCompetition.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "确认重量：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.createman,
            this.FishMealId,
            this.PoundBillNumber,
            this.id,
            this.Numbering,
            this.codeContract,
            this.sponsor,
            this.acceptor,
            this.PoundDifference,
            this.NetWeight,
            this.ConfirmTheWeight,
            this.processresult,
            this.evaluation,
            this.remarks});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(744, 334);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // createman
            // 
            this.createman.HeaderText = "所属人";
            this.createman.Name = "createman";
            this.createman.ReadOnly = true;
            // 
            // FishMealId
            // 
            this.FishMealId.DataPropertyName = "FishMealId";
            this.FishMealId.HeaderText = "鱼粉Id";
            this.FishMealId.Name = "FishMealId";
            this.FishMealId.ReadOnly = true;
            // 
            // PoundBillNumber
            // 
            this.PoundBillNumber.DataPropertyName = "PoundBillNumber";
            this.PoundBillNumber.HeaderText = "磅单单号";
            this.PoundBillNumber.Name = "PoundBillNumber";
            this.PoundBillNumber.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Numbering
            // 
            this.Numbering.DataPropertyName = "Numbering";
            this.Numbering.HeaderText = "销售编号";
            this.Numbering.Name = "Numbering";
            this.Numbering.ReadOnly = true;
            // 
            // codeContract
            // 
            this.codeContract.DataPropertyName = "codeContract";
            this.codeContract.HeaderText = "销售合同号";
            this.codeContract.Name = "codeContract";
            this.codeContract.ReadOnly = true;
            // 
            // sponsor
            // 
            this.sponsor.DataPropertyName = "sponsor";
            this.sponsor.HeaderText = "发起人";
            this.sponsor.Name = "sponsor";
            this.sponsor.ReadOnly = true;
            this.sponsor.Visible = false;
            this.sponsor.Width = 70;
            // 
            // acceptor
            // 
            this.acceptor.DataPropertyName = "acceptor";
            this.acceptor.HeaderText = "受理人";
            this.acceptor.Name = "acceptor";
            this.acceptor.ReadOnly = true;
            this.acceptor.Visible = false;
            this.acceptor.Width = 70;
            // 
            // PoundDifference
            // 
            this.PoundDifference.DataPropertyName = "PoundDifference";
            this.PoundDifference.HeaderText = "磅差";
            this.PoundDifference.Name = "PoundDifference";
            this.PoundDifference.ReadOnly = true;
            // 
            // NetWeight
            // 
            this.NetWeight.DataPropertyName = "NetWeight";
            this.NetWeight.HeaderText = "磅单净重";
            this.NetWeight.Name = "NetWeight";
            this.NetWeight.ReadOnly = true;
            // 
            // ConfirmTheWeight
            // 
            this.ConfirmTheWeight.DataPropertyName = "ConfirmTheWeight";
            this.ConfirmTheWeight.HeaderText = "确认磅单重量";
            this.ConfirmTheWeight.Name = "ConfirmTheWeight";
            this.ConfirmTheWeight.ReadOnly = true;
            // 
            // processresult
            // 
            this.processresult.DataPropertyName = "processresult";
            this.processresult.HeaderText = "客户处理结果";
            this.processresult.Name = "processresult";
            this.processresult.ReadOnly = true;
            this.processresult.Visible = false;
            // 
            // evaluation
            // 
            this.evaluation.DataPropertyName = "evaluation";
            this.evaluation.HeaderText = "财务评估";
            this.evaluation.Name = "evaluation";
            this.evaluation.ReadOnly = true;
            this.evaluation.Visible = false;
            // 
            // remarks
            // 
            this.remarks.DataPropertyName = "remarks";
            this.remarks.HeaderText = "备注";
            this.remarks.Name = "remarks";
            this.remarks.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            this.设置列宽toolStripMenuItem.Click += new System.EventHandler(this.设置列宽toolStripMenuItem_Click);
            // 
            // FormCargoFeedbackSheetTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormCargoFeedbackSheetTable";
            this.Text = "货物反馈单关联表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtCompetition;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewLinkColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn createman;
        private System.Windows.Forms.DataGridViewTextBoxColumn FishMealId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoundBillNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn sponsor;
        private System.Windows.Forms.DataGridViewTextBoxColumn acceptor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PoundDifference;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConfirmTheWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn processresult;
        private System.Windows.Forms.DataGridViewTextBoxColumn evaluation;
        private System.Windows.Forms.DataGridViewTextBoxColumn remarks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}