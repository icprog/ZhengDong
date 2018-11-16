namespace FishClient
{
    partial class FormLoadingBillList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packages = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置列宽ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.signdate,
            this.nature,
            this.specification,
            this.tons,
            this.packages,
            this.sgs_protein,
            this.sgs_tvn,
            this.unitprice,
            this.brand});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(3, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(701, 396);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // signdate
            // 
            this.signdate.DataPropertyName = "signdate";
            this.signdate.HeaderText = "销售时间";
            this.signdate.Name = "signdate";
            this.signdate.ReadOnly = true;
            this.signdate.Width = 90;
            // 
            // nature
            // 
            this.nature.DataPropertyName = "nature";
            this.nature.HeaderText = "国别";
            this.nature.Name = "nature";
            this.nature.ReadOnly = true;
            this.nature.Width = 60;
            // 
            // specification
            // 
            this.specification.DataPropertyName = "specification";
            this.specification.HeaderText = "品质规格";
            this.specification.Name = "specification";
            this.specification.ReadOnly = true;
            this.specification.Width = 80;
            // 
            // tons
            // 
            this.tons.DataPropertyName = "tons";
            this.tons.HeaderText = "重量(吨)";
            this.tons.Name = "tons";
            this.tons.ReadOnly = true;
            this.tons.Width = 80;
            // 
            // packages
            // 
            this.packages.DataPropertyName = "packages";
            this.packages.HeaderText = "数量(包)";
            this.packages.Name = "packages";
            this.packages.ReadOnly = true;
            this.packages.Width = 80;
            // 
            // sgs_protein
            // 
            this.sgs_protein.DataPropertyName = "sgs_protein";
            this.sgs_protein.HeaderText = "SGS(蛋白)";
            this.sgs_protein.Name = "sgs_protein";
            this.sgs_protein.ReadOnly = true;
            this.sgs_protein.Width = 90;
            // 
            // sgs_tvn
            // 
            this.sgs_tvn.DataPropertyName = "sgs_tvn";
            this.sgs_tvn.HeaderText = "TVN";
            this.sgs_tvn.Name = "sgs_tvn";
            this.sgs_tvn.ReadOnly = true;
            this.sgs_tvn.Width = 60;
            // 
            // unitprice
            // 
            this.unitprice.DataPropertyName = "unitprice";
            this.unitprice.HeaderText = "单价";
            this.unitprice.Name = "unitprice";
            this.unitprice.ReadOnly = true;
            this.unitprice.Width = 60;
            // 
            // brand
            // 
            this.brand.DataPropertyName = "brand";
            this.brand.HeaderText = "品牌";
            this.brand.Name = "brand";
            this.brand.ReadOnly = true;
            this.brand.Width = 70;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置列宽ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // 设置列宽ToolStripMenuItem
            // 
            this.设置列宽ToolStripMenuItem.Name = "设置列宽ToolStripMenuItem";
            this.设置列宽ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.设置列宽ToolStripMenuItem.Text = "设置列宽";
            this.设置列宽ToolStripMenuItem.Click += new System.EventHandler(this.设置列宽ToolStripMenuItem_Click);
            // 
            // FormLoadingBillList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 429);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormLoadingBillList";
            this.Text = "销售记录简表";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn signdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn nature;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn tons;
        private System.Windows.Forms.DataGridViewTextBoxColumn packages;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn brand;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置列宽ToolStripMenuItem;
    }
}