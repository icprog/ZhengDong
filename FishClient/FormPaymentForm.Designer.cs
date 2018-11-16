namespace FishClient
{
    partial class FormPaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.applyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchasecode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.acountNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contacts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.backDeposit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applyMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricingType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paymentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textunit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpdateRear = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpdateBefore = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtapplyCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(738, 317);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 51);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(738, 266);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeight = 45;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.applyCode,
            this.code,
            this.state,
            this.applyDate,
            this.purchasecode,
            this.acountNum,
            this.unit,
            this.contacts,
            this.backDeposit,
            this.price,
            this.weight,
            this.applyMoney,
            this.paymentMethod,
            this.PricingType,
            this.paymentType,
            this.paymentDate,
            this.invoiceType,
            this.remark});
            this.dataGridView2.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.EnableHeadersVisualStyles = false;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 30;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(738, 266);
            this.dataGridView2.TabIndex = 208;
            // 
            // applyCode
            // 
            this.applyCode.DataPropertyName = "applyCode";
            this.applyCode.HeaderText = "销售合同号";
            this.applyCode.Name = "applyCode";
            this.applyCode.ReadOnly = true;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "单号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 60;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "审核";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.state.Visible = false;
            this.state.Width = 60;
            // 
            // applyDate
            // 
            this.applyDate.DataPropertyName = "applyDate";
            dataGridViewCellStyle7.Format = "d";
            dataGridViewCellStyle7.NullValue = null;
            this.applyDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.applyDate.HeaderText = "申请日期";
            this.applyDate.Name = "applyDate";
            this.applyDate.ReadOnly = true;
            this.applyDate.Width = 80;
            // 
            // purchasecode
            // 
            this.purchasecode.DataPropertyName = "purchasecode";
            this.purchasecode.HeaderText = "采购合同号";
            this.purchasecode.Name = "purchasecode";
            this.purchasecode.ReadOnly = true;
            // 
            // acountNum
            // 
            this.acountNum.DataPropertyName = "acountNum";
            this.acountNum.HeaderText = "帐号";
            this.acountNum.Name = "acountNum";
            this.acountNum.ReadOnly = true;
            this.acountNum.Width = 60;
            // 
            // unit
            // 
            this.unit.DataPropertyName = "unit";
            this.unit.HeaderText = "单位名称";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 80;
            // 
            // contacts
            // 
            this.contacts.DataPropertyName = "contacts";
            this.contacts.HeaderText = "联系人";
            this.contacts.Name = "contacts";
            this.contacts.ReadOnly = true;
            this.contacts.Width = 70;
            // 
            // backDeposit
            // 
            this.backDeposit.DataPropertyName = "backDeposit";
            this.backDeposit.HeaderText = "开户行";
            this.backDeposit.Name = "backDeposit";
            this.backDeposit.ReadOnly = true;
            this.backDeposit.Width = 70;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "货品单价";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 80;
            // 
            // weight
            // 
            this.weight.DataPropertyName = "weight";
            this.weight.HeaderText = "货品重量";
            this.weight.Name = "weight";
            this.weight.ReadOnly = true;
            this.weight.Width = 80;
            // 
            // applyMoney
            // 
            this.applyMoney.DataPropertyName = "applyMoney";
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.applyMoney.DefaultCellStyle = dataGridViewCellStyle8;
            this.applyMoney.HeaderText = "申请金额";
            this.applyMoney.Name = "applyMoney";
            this.applyMoney.ReadOnly = true;
            this.applyMoney.Width = 80;
            // 
            // paymentMethod
            // 
            this.paymentMethod.DataPropertyName = "paymentMethod";
            this.paymentMethod.HeaderText = "付款方式";
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.ReadOnly = true;
            this.paymentMethod.Width = 80;
            // 
            // PricingType
            // 
            this.PricingType.HeaderText = "定价类型";
            this.PricingType.Name = "PricingType";
            this.PricingType.ReadOnly = true;
            // 
            // paymentType
            // 
            this.paymentType.DataPropertyName = "paymentType";
            this.paymentType.HeaderText = "款项";
            this.paymentType.Name = "paymentType";
            this.paymentType.ReadOnly = true;
            this.paymentType.Width = 60;
            // 
            // paymentDate
            // 
            this.paymentDate.DataPropertyName = "paymentDate";
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.paymentDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.paymentDate.HeaderText = "付款日期";
            this.paymentDate.Name = "paymentDate";
            this.paymentDate.ReadOnly = true;
            this.paymentDate.Width = 80;
            // 
            // invoiceType
            // 
            this.invoiceType.DataPropertyName = "invoiceType";
            this.invoiceType.HeaderText = "发票类型";
            this.invoiceType.Name = "invoiceType";
            this.invoiceType.ReadOnly = true;
            this.invoiceType.Width = 80;
            // 
            // remark
            // 
            this.remark.DataPropertyName = "remark";
            this.remark.HeaderText = "备注";
            this.remark.Name = "remark";
            this.remark.ReadOnly = true;
            this.remark.Width = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textunit);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dtpdateRear);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtpdateBefore);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtapplyCode);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 51);
            this.panel2.TabIndex = 0;
            // 
            // textunit
            // 
            this.textunit.Location = new System.Drawing.Point(505, 16);
            this.textunit.Name = "textunit";
            this.textunit.ReadOnly = true;
            this.textunit.Size = new System.Drawing.Size(120, 21);
            this.textunit.TabIndex = 9;
            this.textunit.Click += new System.EventHandler(this.textunit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(472, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "单位：";
            // 
            // dtpdateRear
            // 
            this.dtpdateRear.Location = new System.Drawing.Point(360, 16);
            this.dtpdateRear.Name = "dtpdateRear";
            this.dtpdateRear.Size = new System.Drawing.Size(106, 21);
            this.dtpdateRear.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(334, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "至：";
            // 
            // dtpdateBefore
            // 
            this.dtpdateBefore.Location = new System.Drawing.Point(222, 16);
            this.dtpdateBefore.Name = "dtpdateBefore";
            this.dtpdateBefore.Size = new System.Drawing.Size(106, 21);
            this.dtpdateBefore.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "日期：";
            // 
            // txtapplyCode
            // 
            this.txtapplyCode.Location = new System.Drawing.Point(71, 16);
            this.txtapplyCode.Name = "txtapplyCode";
            this.txtapplyCode.Size = new System.Drawing.Size(100, 21);
            this.txtapplyCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合同号：";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽toolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            this.contextMenuStrip1.Click += new System.EventHandler(this.contextMenuStrip1_Click);
            // 
            // 设置列宽toolStripMenuItem
            // 
            this.设置列宽toolStripMenuItem.Name = "设置列宽toolStripMenuItem";
            this.设置列宽toolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽toolStripMenuItem.Text = "设置列宽";
            // 
            // FormPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 375);
            this.Controls.Add(this.panel1);
            this.Name = "FormPaymentForm";
            this.Text = "付款申请表";
            this.Load += new System.EventHandler(this.FormPaymentForm_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox txtapplyCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpdateBefore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpdateRear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn applyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn applyDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchasecode;
        private System.Windows.Forms.DataGridViewTextBoxColumn acountNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn contacts;
        private System.Windows.Forms.DataGridViewTextBoxColumn backDeposit;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn applyMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricingType;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn paymentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn remark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}