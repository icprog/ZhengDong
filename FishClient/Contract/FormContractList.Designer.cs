namespace FishClient.Contract
{
    partial class FormContractList
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
            this.btnQuery = new UILibrary.SkinButtom();
            this.txtyifang = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtjiafang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtcontractno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contractid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contracttypename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yifangcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yifang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billofgoods = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contractquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.getweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleremainweight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cornerno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_protein = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_tvn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_fat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_water = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_amine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_ffa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_sandsalt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sgs_graypart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnQuery);
            this.panel1.Controls.Add(this.txtyifang);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtjiafang);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtcontractno);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 52);
            this.panel1.TabIndex = 1;
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.Transparent;
            this.btnQuery.ControlState = UILibrary.ControlState.Normal;
            this.btnQuery.DownBack = null;
            this.btnQuery.Location = new System.Drawing.Point(705, 18);
            this.btnQuery.MouseBack = null;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.NormlBack = null;
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 127;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtyifang
            // 
            this.txtyifang.Location = new System.Drawing.Point(233, 19);
            this.txtyifang.Name = "txtyifang";
            this.txtyifang.Size = new System.Drawing.Size(184, 21);
            this.txtyifang.TabIndex = 5;
            this.txtyifang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontractno_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "买方";
            // 
            // txtjiafang
            // 
            this.txtjiafang.Location = new System.Drawing.Point(485, 19);
            this.txtjiafang.Name = "txtjiafang";
            this.txtjiafang.Size = new System.Drawing.Size(194, 21);
            this.txtjiafang.TabIndex = 3;
            this.txtjiafang.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontractno_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(437, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "卖方";
            // 
            // txtcontractno
            // 
            this.txtcontractno.Location = new System.Drawing.Point(80, 19);
            this.txtcontractno.Name = "txtcontractno";
            this.txtcontractno.Size = new System.Drawing.Size(100, 21);
            this.txtcontractno.TabIndex = 1;
            this.txtcontractno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcontractno_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "合同编号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeight = 45;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contractid,
            this.contractno,
            this.contracttypename,
            this.yifangcode,
            this.yifang,
            this.signdate,
            this.no,
            this.code,
            this.shipno,
            this.billofgoods,
            this.contractweight,
            this.contractquantity,
            this.getweight,
            this.saleremainweight,
            this.cornerno,
            this.sgs_protein,
            this.sgs_tvn,
            this.sgs_fat,
            this.sgs_water,
            this.sgs_amine,
            this.sgs_ffa,
            this.specification,
            this.sgs_sandsalt,
            this.sgs_graypart,
            this.id,
            this.state});
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
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(3, 82);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(831, 347);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // contractid
            // 
            this.contractid.DataPropertyName = "contractid";
            this.contractid.HeaderText = "contractid";
            this.contractid.Name = "contractid";
            this.contractid.ReadOnly = true;
            this.contractid.Visible = false;
            // 
            // contractno
            // 
            this.contractno.DataPropertyName = "contractno";
            this.contractno.HeaderText = "合同编号";
            this.contractno.Name = "contractno";
            this.contractno.ReadOnly = true;
            // 
            // contracttypename
            // 
            this.contracttypename.DataPropertyName = "contracttypename";
            this.contracttypename.HeaderText = "合同类型";
            this.contracttypename.Name = "contracttypename";
            this.contracttypename.ReadOnly = true;
            // 
            // yifangcode
            // 
            this.yifangcode.DataPropertyName = "yifangcode";
            this.yifangcode.HeaderText = "买方编号";
            this.yifangcode.Name = "yifangcode";
            this.yifangcode.ReadOnly = true;
            // 
            // yifang
            // 
            this.yifang.DataPropertyName = "yifang";
            this.yifang.HeaderText = "买方";
            this.yifang.Name = "yifang";
            this.yifang.ReadOnly = true;
            // 
            // signdate
            // 
            this.signdate.DataPropertyName = "signdate";
            this.signdate.HeaderText = "签约日期";
            this.signdate.Name = "signdate";
            this.signdate.ReadOnly = true;
            // 
            // no
            // 
            this.no.DataPropertyName = "no";
            this.no.HeaderText = "合同序号";
            this.no.Name = "no";
            this.no.ReadOnly = true;
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "鱼粉ID";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // shipno
            // 
            this.shipno.DataPropertyName = "shipno";
            this.shipno.HeaderText = "船名";
            this.shipno.Name = "shipno";
            this.shipno.ReadOnly = true;
            // 
            // billofgoods
            // 
            this.billofgoods.DataPropertyName = "billofgoods";
            this.billofgoods.HeaderText = "提单号";
            this.billofgoods.Name = "billofgoods";
            this.billofgoods.ReadOnly = true;
            // 
            // contractweight
            // 
            this.contractweight.DataPropertyName = "contractweight";
            this.contractweight.HeaderText = "合同重量";
            this.contractweight.Name = "contractweight";
            this.contractweight.ReadOnly = true;
            this.contractweight.Width = 90;
            // 
            // contractquantity
            // 
            this.contractquantity.DataPropertyName = "contractquantity";
            this.contractquantity.HeaderText = "合同数量";
            this.contractquantity.Name = "contractquantity";
            this.contractquantity.ReadOnly = true;
            this.contractquantity.Width = 90;
            // 
            // getweight
            // 
            this.getweight.DataPropertyName = "getweight";
            this.getweight.HeaderText = "已提重量";
            this.getweight.Name = "getweight";
            this.getweight.ReadOnly = true;
            this.getweight.Width = 110;
            // 
            // saleremainweight
            // 
            this.saleremainweight.DataPropertyName = "getquantity";
            this.saleremainweight.HeaderText = "已提数量";
            this.saleremainweight.Name = "saleremainweight";
            this.saleremainweight.ReadOnly = true;
            // 
            // cornerno
            // 
            this.cornerno.DataPropertyName = "cornerno";
            this.cornerno.HeaderText = "桩脚号";
            this.cornerno.Name = "cornerno";
            this.cornerno.ReadOnly = true;
            // 
            // sgs_protein
            // 
            this.sgs_protein.DataPropertyName = "sgs_protein";
            this.sgs_protein.HeaderText = "蛋白";
            this.sgs_protein.Name = "sgs_protein";
            this.sgs_protein.ReadOnly = true;
            this.sgs_protein.Width = 60;
            // 
            // sgs_tvn
            // 
            this.sgs_tvn.DataPropertyName = "sgs_tvn";
            this.sgs_tvn.HeaderText = "TVN";
            this.sgs_tvn.Name = "sgs_tvn";
            this.sgs_tvn.ReadOnly = true;
            this.sgs_tvn.Width = 60;
            // 
            // sgs_fat
            // 
            this.sgs_fat.DataPropertyName = "sgs_fat";
            this.sgs_fat.HeaderText = "脂肪";
            this.sgs_fat.Name = "sgs_fat";
            this.sgs_fat.ReadOnly = true;
            this.sgs_fat.Width = 60;
            // 
            // sgs_water
            // 
            this.sgs_water.DataPropertyName = "sgs_water";
            this.sgs_water.HeaderText = "水分";
            this.sgs_water.Name = "sgs_water";
            this.sgs_water.ReadOnly = true;
            // 
            // sgs_amine
            // 
            this.sgs_amine.DataPropertyName = "sgs_amine";
            this.sgs_amine.HeaderText = "组胺";
            this.sgs_amine.Name = "sgs_amine";
            this.sgs_amine.ReadOnly = true;
            this.sgs_amine.Width = 60;
            // 
            // sgs_ffa
            // 
            this.sgs_ffa.DataPropertyName = "sgs_ffa";
            this.sgs_ffa.HeaderText = "FFA";
            this.sgs_ffa.Name = "sgs_ffa";
            this.sgs_ffa.ReadOnly = true;
            // 
            // specification
            // 
            this.specification.DataPropertyName = "specification";
            this.specification.HeaderText = "品质";
            this.specification.Name = "specification";
            this.specification.ReadOnly = true;
            this.specification.Width = 70;
            // 
            // sgs_sandsalt
            // 
            this.sgs_sandsalt.DataPropertyName = "sgs_sandsalt";
            this.sgs_sandsalt.HeaderText = "盐和砂";
            this.sgs_sandsalt.Name = "sgs_sandsalt";
            this.sgs_sandsalt.ReadOnly = true;
            this.sgs_sandsalt.Width = 60;
            // 
            // sgs_graypart
            // 
            this.sgs_graypart.DataPropertyName = "sgs_graypart";
            this.sgs_graypart.HeaderText = "灰份";
            this.sgs_graypart.Name = "sgs_graypart";
            this.sgs_graypart.ReadOnly = true;
            this.sgs_graypart.Width = 60;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "state";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Visible = false;
            // 
            // FormContractList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 432);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormContractList";
            this.Text = "合同查询";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtjiafang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtcontractno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyifang;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private UILibrary.SkinButtom btnQuery;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractid;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractno;
        private System.Windows.Forms.DataGridViewTextBoxColumn contracttypename;
        private System.Windows.Forms.DataGridViewTextBoxColumn yifangcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn yifang;
        private System.Windows.Forms.DataGridViewTextBoxColumn signdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn no;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipno;
        private System.Windows.Forms.DataGridViewTextBoxColumn billofgoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn contractquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn getweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleremainweight;
        private System.Windows.Forms.DataGridViewTextBoxColumn cornerno;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_protein;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_tvn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_fat;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_water;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_amine;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_ffa;
        private System.Windows.Forms.DataGridViewTextBoxColumn specification;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_sandsalt;
        private System.Windows.Forms.DataGridViewTextBoxColumn sgs_graypart;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
    }
}