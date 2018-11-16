namespace FishClient
{
    partial class FormJinCangTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TEL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ANTI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Requester = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Shipname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tonnage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Billnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfPieces = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unpackingdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actualnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StorageLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtRequester = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpRear = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpbefore = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 320);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 47);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(697, 273);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
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
            this.TO,
            this.TEL,
            this.ANTI,
            this.FAX,
            this.Requester,
            this.code,
            this.Shipname,
            this.tonnage,
            this.tName,
            this.Billnumber,
            this.NumberOfPieces,
            this.Unpackingdate,
            this.actualnumber,
            this.StorageLocation,
            this.position,
            this.Remarks});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(697, 273);
            this.dataGridView1.TabIndex = 0;
            // 
            // TO
            // 
            this.TO.DataPropertyName = "TO";
            this.TO.HeaderText = "TO";
            this.TO.Name = "TO";
            // 
            // TEL
            // 
            this.TEL.DataPropertyName = "TEL";
            this.TEL.HeaderText = "TEL";
            this.TEL.Name = "TEL";
            // 
            // ANTI
            // 
            this.ANTI.DataPropertyName = "ANTI";
            this.ANTI.HeaderText = "ANTI";
            this.ANTI.Name = "ANTI";
            // 
            // FAX
            // 
            this.FAX.DataPropertyName = "FAX";
            this.FAX.HeaderText = "FAX";
            this.FAX.Name = "FAX";
            // 
            // Requester
            // 
            this.Requester.DataPropertyName = "Requester";
            this.Requester.HeaderText = "委托单位";
            this.Requester.Name = "Requester";
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "操作编号";
            this.code.Name = "code";
            // 
            // Shipname
            // 
            this.Shipname.DataPropertyName = "Shipname";
            this.Shipname.HeaderText = "船名";
            this.Shipname.Name = "Shipname";
            // 
            // tonnage
            // 
            this.tonnage.DataPropertyName = "tonnage";
            this.tonnage.HeaderText = "吨位";
            this.tonnage.Name = "tonnage";
            // 
            // tName
            // 
            this.tName.DataPropertyName = "tName";
            this.tName.HeaderText = "品名";
            this.tName.Name = "tName";
            // 
            // Billnumber
            // 
            this.Billnumber.DataPropertyName = "Billnumber";
            this.Billnumber.HeaderText = "提单号";
            this.Billnumber.Name = "Billnumber";
            // 
            // NumberOfPieces
            // 
            this.NumberOfPieces.DataPropertyName = "NumberOfPieces";
            this.NumberOfPieces.HeaderText = "件数";
            this.NumberOfPieces.Name = "NumberOfPieces";
            // 
            // Unpackingdate
            // 
            this.Unpackingdate.DataPropertyName = "Unpackingdate";
            this.Unpackingdate.HeaderText = "拆箱日期";
            this.Unpackingdate.Name = "Unpackingdate";
            // 
            // actualnumber
            // 
            this.actualnumber.DataPropertyName = "actualnumber";
            this.actualnumber.HeaderText = "实际件数";
            this.actualnumber.Name = "actualnumber";
            // 
            // StorageLocation
            // 
            this.StorageLocation.DataPropertyName = "StorageLocation";
            this.StorageLocation.HeaderText = "存放地点";
            this.StorageLocation.Name = "StorageLocation";
            // 
            // position
            // 
            this.position.DataPropertyName = "position";
            this.position.HeaderText = "库场存放位置";
            this.position.Name = "position";
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtRequester);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpRear);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpbefore);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtcode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(697, 47);
            this.panel2.TabIndex = 3;
            // 
            // txtRequester
            // 
            this.txtRequester.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtRequester.Location = new System.Drawing.Point(527, 15);
            this.txtRequester.Name = "txtRequester";
            this.txtRequester.ReadOnly = true;
            this.txtRequester.Size = new System.Drawing.Size(120, 21);
            this.txtRequester.TabIndex = 7;
            this.txtRequester.Click += new System.EventHandler(this.txtRequester_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "委托单位：";
            // 
            // dtpRear
            // 
            this.dtpRear.Location = new System.Drawing.Point(354, 15);
            this.dtpRear.Name = "dtpRear";
            this.dtpRear.Size = new System.Drawing.Size(108, 21);
            this.dtpRear.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "至：";
            // 
            // dtpbefore
            // 
            this.dtpbefore.Location = new System.Drawing.Point(218, 15);
            this.dtpbefore.Name = "dtpbefore";
            this.dtpbefore.Size = new System.Drawing.Size(108, 21);
            this.dtpbefore.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "日期：";
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(77, 15);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(100, 21);
            this.txtcode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "操作编号：";
            // 
            // FormJinCangTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 378);
            this.Controls.Add(this.panel1);
            this.Name = "FormJinCangTable";
            this.Text = "进仓表";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.DateTimePicker dtpRear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpbefore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRequester;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn TO;
        private System.Windows.Forms.DataGridViewTextBoxColumn TEL;
        private System.Windows.Forms.DataGridViewTextBoxColumn ANTI;
        private System.Windows.Forms.DataGridViewTextBoxColumn FAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn Requester;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Shipname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tonnage;
        private System.Windows.Forms.DataGridViewTextBoxColumn tName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Billnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfPieces;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unpackingdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn actualnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn StorageLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
    }
}