namespace FishClient
{
    partial class FormBilloftable
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issuingtime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactsunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.species = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ferryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cornerno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packagenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipNotice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Storagecosts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbspecification = new System.Windows.Forms.ComboBox();
            this.cmbspecies = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtlistname = new System.Windows.Forms.TextBox();
            this.txtferryname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtwarehouse = new System.Windows.Forms.TextBox();
            this.txtcontactsunit = new System.Windows.Forms.TextBox();
            this.txtcode = new System.Windows.Forms.TextBox();
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
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(805, 441);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 111);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(805, 330);
            this.panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.Issuingtime,
            this.contactsunit,
            this.warehouse,
            this.species,
            this.specification,
            this.ferryname,
            this.listname,
            this.cornerno,
            this.Ton,
            this.packagenumber,
            this.Remarks,
            this.ShipNotice,
            this.Storagecosts});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(805, 330);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "编号";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // Issuingtime
            // 
            this.Issuingtime.DataPropertyName = "Issuingtime";
            this.Issuingtime.HeaderText = "签发时间";
            this.Issuingtime.Name = "Issuingtime";
            this.Issuingtime.ReadOnly = true;
            // 
            // contactsunit
            // 
            this.contactsunit.DataPropertyName = "contactsunit";
            this.contactsunit.HeaderText = "往来单位";
            this.contactsunit.Name = "contactsunit";
            this.contactsunit.ReadOnly = true;
            // 
            // warehouse
            // 
            this.warehouse.DataPropertyName = "warehouse";
            this.warehouse.HeaderText = "仓库";
            this.warehouse.Name = "warehouse";
            this.warehouse.ReadOnly = true;
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
            // cornerno
            // 
            this.cornerno.DataPropertyName = "cornerno";
            this.cornerno.HeaderText = "桩角号";
            this.cornerno.Name = "cornerno";
            this.cornerno.ReadOnly = true;
            // 
            // Ton
            // 
            this.Ton.DataPropertyName = "Ton";
            this.Ton.HeaderText = "吨数";
            this.Ton.Name = "Ton";
            this.Ton.ReadOnly = true;
            // 
            // packagenumber
            // 
            this.packagenumber.DataPropertyName = "packagenumber";
            this.packagenumber.HeaderText = "包数";
            this.packagenumber.Name = "packagenumber";
            this.packagenumber.ReadOnly = true;
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
            this.ShipNotice.DataPropertyName = "Storagecosts";
            this.ShipNotice.HeaderText = "发货须知";
            this.ShipNotice.Name = "ShipNotice";
            this.ShipNotice.ReadOnly = true;
            // 
            // Storagecosts
            // 
            this.Storagecosts.DataPropertyName = "Storagecosts";
            this.Storagecosts.HeaderText = "仓储费";
            this.Storagecosts.Name = "Storagecosts";
            this.Storagecosts.ReadOnly = true;
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
            // panel2
            // 
            this.panel2.Controls.Add(this.cmbspecification);
            this.panel2.Controls.Add(this.cmbspecies);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txtlistname);
            this.panel2.Controls.Add(this.txtferryname);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtwarehouse);
            this.panel2.Controls.Add(this.txtcontactsunit);
            this.panel2.Controls.Add(this.txtcode);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(805, 111);
            this.panel2.TabIndex = 0;
            // 
            // cmbspecification
            // 
            this.cmbspecification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbspecification.FormattingEnabled = true;
            this.cmbspecification.Location = new System.Drawing.Point(440, 65);
            this.cmbspecification.Name = "cmbspecification";
            this.cmbspecification.Size = new System.Drawing.Size(100, 20);
            this.cmbspecification.TabIndex = 186;
            // 
            // cmbspecies
            // 
            this.cmbspecies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbspecies.FormattingEnabled = true;
            this.cmbspecies.Location = new System.Drawing.Point(261, 65);
            this.cmbspecies.Name = "cmbspecies";
            this.cmbspecies.Size = new System.Drawing.Size(100, 20);
            this.cmbspecies.TabIndex = 185;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(569, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 183;
            this.label7.Text = "船名：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(381, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 182;
            this.label8.Text = "提单号：";
            // 
            // txtlistname
            // 
            this.txtlistname.Location = new System.Drawing.Point(440, 27);
            this.txtlistname.Name = "txtlistname";
            this.txtlistname.Size = new System.Drawing.Size(100, 21);
            this.txtlistname.TabIndex = 181;
            // 
            // txtferryname
            // 
            this.txtferryname.Location = new System.Drawing.Point(616, 27);
            this.txtferryname.Name = "txtferryname";
            this.txtferryname.Size = new System.Drawing.Size(100, 21);
            this.txtferryname.TabIndex = 180;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(214, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 179;
            this.label3.Text = "种类：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(393, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 178;
            this.label6.Text = "规格：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 177;
            this.label5.Text = "提货单位：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 176;
            this.label2.Text = "仓库：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 175;
            this.label1.Text = "编号：";
            // 
            // txtwarehouse
            // 
            this.txtwarehouse.Location = new System.Drawing.Point(87, 65);
            this.txtwarehouse.Name = "txtwarehouse";
            this.txtwarehouse.Size = new System.Drawing.Size(100, 21);
            this.txtwarehouse.TabIndex = 173;
            // 
            // txtcontactsunit
            // 
            this.txtcontactsunit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtcontactsunit.Location = new System.Drawing.Point(261, 27);
            this.txtcontactsunit.Name = "txtcontactsunit";
            this.txtcontactsunit.ReadOnly = true;
            this.txtcontactsunit.Size = new System.Drawing.Size(100, 21);
            this.txtcontactsunit.TabIndex = 172;
            this.txtcontactsunit.Click += new System.EventHandler(this.txtcontactsunit_Click);
            // 
            // txtcode
            // 
            this.txtcode.Location = new System.Drawing.Point(87, 27);
            this.txtcode.Name = "txtcode";
            this.txtcode.Size = new System.Drawing.Size(100, 21);
            this.txtcode.TabIndex = 171;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "code";
            this.dataGridViewTextBoxColumn2.HeaderText = "编号";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Issuingtime";
            this.dataGridViewTextBoxColumn3.HeaderText = "签发时间";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "contactsunit";
            this.dataGridViewTextBoxColumn4.HeaderText = "往来单位";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "warehouse";
            this.dataGridViewTextBoxColumn5.HeaderText = "仓库";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "species";
            this.dataGridViewTextBoxColumn6.HeaderText = "种类";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "specification";
            this.dataGridViewTextBoxColumn7.HeaderText = "规格";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ferryname";
            this.dataGridViewTextBoxColumn8.HeaderText = "船名";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "listname";
            this.dataGridViewTextBoxColumn9.HeaderText = "提单号";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Ton";
            this.dataGridViewTextBoxColumn10.HeaderText = "吨数";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "packagenumber";
            this.dataGridViewTextBoxColumn11.HeaderText = "包数";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Remarks";
            this.dataGridViewTextBoxColumn12.HeaderText = "备注";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Storagecosts";
            this.dataGridViewTextBoxColumn13.HeaderText = "发货须知";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "Storagecosts";
            this.dataGridViewTextBoxColumn14.HeaderText = "仓储费";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // FormBilloftable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 499);
            this.Controls.Add(this.panel1);
            this.Name = "FormBilloftable";
            this.Text = "提货单表";
            this.Load += new System.EventHandler(this.FormBilloftable_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbspecification;
        private System.Windows.Forms.ComboBox cmbspecies;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtlistname;
        private System.Windows.Forms.TextBox txtferryname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtwarehouse;
        private System.Windows.Forms.TextBox txtcontactsunit;
        private System.Windows.Forms.TextBox txtcode;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issuingtime;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactsunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouse;
        private System.Windows.Forms.DataGridViewTextBoxColumn species;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn ferryname;
        private System.Windows.Forms.DataGridViewTextBoxColumn listname;
        private System.Windows.Forms.DataGridViewTextBoxColumn cornerno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ton;
        private System.Windows.Forms.DataGridViewTextBoxColumn packagenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipNotice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Storagecosts;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽toolStripMenuItem;
    }
}