namespace FishClient
{
    partial class FormBillofladingTable
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRedemptionWeight = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codeOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issuingtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RedemptionWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packagenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cornerno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ferryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Storagecosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numbering = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.species = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipNotice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recipient = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactsunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactsunitId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FishMealId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brands = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifyman = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtRedemptionWeight);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 40);
            this.panel1.TabIndex = 1;
            // 
            // txtRedemptionWeight
            // 
            this.txtRedemptionWeight.Location = new System.Drawing.Point(235, 11);
            this.txtRedemptionWeight.Name = "txtRedemptionWeight";
            this.txtRedemptionWeight.Size = new System.Drawing.Size(100, 21);
            this.txtRedemptionWeight.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "赎单重量：";
            // 
            // txtTon
            // 
            this.txtTon.Location = new System.Drawing.Point(58, 11);
            this.txtTon.Name = "txtTon";
            this.txtTon.Size = new System.Drawing.Size(100, 21);
            this.txtTon.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "吨数：";
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
            this.codeOne,
            this.createman,
            this.Issuingtime,
            this.warehouse,
            this.Ton,
            this.RedemptionWeight,
            this.packagenumber,
            this.cornerno,
            this.ferryname,
            this.listname,
            this.Storagecosts,
            this.Numbering,
            this.codeContract,
            this.species,
            this.specification,
            this.Remarks,
            this.ShipNotice,
            this.Recipient,
            this.SerialNumber,
            this.contactsunit,
            this.id,
            this.ContactsunitId,
            this.FishMealId,
            this.Country,
            this.Brands,
            this.createtime,
            this.modifyman});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridView1.Location = new System.Drawing.Point(3, 95);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(698, 319);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // codeOne
            // 
            this.codeOne.DataPropertyName = "codeOne";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.codeOne.DefaultCellStyle = dataGridViewCellStyle2;
            this.codeOne.HeaderText = "单号";
            this.codeOne.Name = "codeOne";
            this.codeOne.ReadOnly = true;
            this.codeOne.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // createman
            // 
            this.createman.DataPropertyName = "createman";
            this.createman.HeaderText = "所属人";
            this.createman.Name = "createman";
            this.createman.ReadOnly = true;
            // 
            // Issuingtime
            // 
            this.Issuingtime.DataPropertyName = "Issuingtime";
            this.Issuingtime.HeaderText = "签发时间";
            this.Issuingtime.Name = "Issuingtime";
            this.Issuingtime.ReadOnly = true;
            // 
            // warehouse
            // 
            this.warehouse.DataPropertyName = "warehouse";
            this.warehouse.HeaderText = "仓库";
            this.warehouse.Name = "warehouse";
            this.warehouse.ReadOnly = true;
            // 
            // Ton
            // 
            this.Ton.DataPropertyName = "Ton";
            this.Ton.HeaderText = "吨数";
            this.Ton.Name = "Ton";
            this.Ton.ReadOnly = true;
            // 
            // RedemptionWeight
            // 
            this.RedemptionWeight.DataPropertyName = "RedemptionWeight";
            this.RedemptionWeight.HeaderText = "赎单重量";
            this.RedemptionWeight.Name = "RedemptionWeight";
            this.RedemptionWeight.ReadOnly = true;
            // 
            // packagenumber
            // 
            this.packagenumber.DataPropertyName = "packagenumber";
            this.packagenumber.HeaderText = "包数";
            this.packagenumber.Name = "packagenumber";
            this.packagenumber.ReadOnly = true;
            // 
            // cornerno
            // 
            this.cornerno.DataPropertyName = "cornerno";
            this.cornerno.HeaderText = "桩角号";
            this.cornerno.Name = "cornerno";
            this.cornerno.ReadOnly = true;
            // 
            // ferryname
            // 
            this.ferryname.DataPropertyName = "ferryname";
            this.ferryname.HeaderText = "船名";
            this.ferryname.Name = "ferryname";
            this.ferryname.ReadOnly = true;
            // 
            // listname
            // 
            this.listname.DataPropertyName = "listname";
            this.listname.HeaderText = "提单号";
            this.listname.Name = "listname";
            this.listname.ReadOnly = true;
            // 
            // Storagecosts
            // 
            this.Storagecosts.DataPropertyName = "Storagecosts";
            this.Storagecosts.HeaderText = "仓储费";
            this.Storagecosts.Name = "Storagecosts";
            this.Storagecosts.ReadOnly = true;
            // 
            // Numbering
            // 
            this.Numbering.DataPropertyName = "Numbering";
            this.Numbering.HeaderText = "编号";
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
            // species
            // 
            this.species.DataPropertyName = "species";
            this.species.HeaderText = "种类";
            this.species.Name = "species";
            this.species.ReadOnly = true;
            // 
            // specification
            // 
            this.specification.DataPropertyName = "specification";
            this.specification.HeaderText = "规格";
            this.specification.Name = "specification";
            this.specification.ReadOnly = true;
            // 
            // Remarks
            // 
            this.Remarks.DataPropertyName = "Remarks";
            this.Remarks.HeaderText = "备注";
            this.Remarks.Name = "Remarks";
            this.Remarks.ReadOnly = true;
            // 
            // ShipNotice
            // 
            this.ShipNotice.DataPropertyName = "ShipNotice";
            this.ShipNotice.HeaderText = "发货须知";
            this.ShipNotice.Name = "ShipNotice";
            this.ShipNotice.ReadOnly = true;
            // 
            // Recipient
            // 
            this.Recipient.DataPropertyName = "Recipient";
            this.Recipient.HeaderText = "接受人";
            this.Recipient.Name = "Recipient";
            this.Recipient.ReadOnly = true;
            // 
            // SerialNumber
            // 
            this.SerialNumber.DataPropertyName = "SerialNumber";
            this.SerialNumber.HeaderText = "序号";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.ReadOnly = true;
            // 
            // contactsunit
            // 
            this.contactsunit.DataPropertyName = "contactsunit";
            this.contactsunit.HeaderText = "提货单位";
            this.contactsunit.Name = "contactsunit";
            this.contactsunit.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ContactsunitId
            // 
            this.ContactsunitId.DataPropertyName = "ContactsunitId";
            this.ContactsunitId.HeaderText = "提货单位Id";
            this.ContactsunitId.Name = "ContactsunitId";
            this.ContactsunitId.ReadOnly = true;
            this.ContactsunitId.Visible = false;
            // 
            // FishMealId
            // 
            this.FishMealId.DataPropertyName = "FishMealId";
            this.FishMealId.HeaderText = "鱼粉Id";
            this.FishMealId.Name = "FishMealId";
            this.FishMealId.ReadOnly = true;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "国别";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // Brands
            // 
            this.Brands.DataPropertyName = "Brands";
            this.Brands.HeaderText = "品牌";
            this.Brands.Name = "Brands";
            this.Brands.ReadOnly = true;
            // 
            // createtime
            // 
            this.createtime.DataPropertyName = "createtime";
            this.createtime.HeaderText = "createtime";
            this.createtime.Name = "createtime";
            this.createtime.ReadOnly = true;
            this.createtime.Visible = false;
            // 
            // modifyman
            // 
            this.modifyman.DataPropertyName = "modifyman";
            this.modifyman.HeaderText = "modifyman";
            this.modifyman.Name = "modifyman";
            this.modifyman.ReadOnly = true;
            this.modifyman.Visible = false;
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
            // FormBillofladingTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 417);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormBillofladingTable";
            this.Text = "提货单关联表";
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
        private System.Windows.Forms.TextBox txtTon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRedemptionWeight;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn createman;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issuingtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ton;
        private System.Windows.Forms.DataGridViewTextBoxColumn RedemptionWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn packagenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn cornerno;
        private System.Windows.Forms.DataGridViewTextBoxColumn ferryname;
        private System.Windows.Forms.DataGridViewTextBoxColumn listname;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storagecosts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numbering;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn species;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipNotice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recipient;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactsunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactsunitId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FishMealId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brands;
        private System.Windows.Forms.DataGridViewTextBoxColumn createtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifyman;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}