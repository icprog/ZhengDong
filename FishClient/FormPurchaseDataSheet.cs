using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPurchaseDataSheet : FormMenuBase
    {
        FishBll.Bll.PurchaseApplicationBll _bll = null;
        string strWhere = string.Empty;
        public FormPurchaseDataSheet()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_134");
            comboBox1.Items.Add("");
            comboBox1.Items.Add("采购流程1");
            comboBox1.Items.Add("采购流程2");
            User();
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";
        }
        public void User()
        {
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();

            List<FishEntity.PersonEntity> list1 = bll.id_name();
            if (list1 == null)
            {
                list1 = new List<FishEntity.PersonEntity>();
            }
            FishEntity.PersonEntity tmep = new FishEntity.PersonEntity();

            tmep.id = 0;
            tmep.username = " ";
            list1.Insert(0, tmep);

            cmbCodeNumUser.DataSource = list1;
            cmbCodeNumUser.DisplayMember = "username";
            cmbCodeNumUser.ValueMember = "username";
        }
        public override int Query()
        {
            _bll = new FishBll.Bll.PurchaseApplicationBll();
            strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(txtcodenum.Text))
            {
                strWhere += " and codeNum like '%" + txtcodenum.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(txtcodeNumContract.Text))
            {
                strWhere += " and codeNumContract like '%" + txtcodeNumContract.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(txtsupplier.Text))
            {
                strWhere += " and supplier like '%" + txtsupplier.Text + "%' ";
            }
            if (comboBox1.Text.Equals("采购流程1"))
            {
                strWhere += " and process like '%" + comboBox1.Text + "%' ";
            }
            else if (comboBox1.Text.Equals("采购流程2"))
            {
                strWhere += " and process like '%" + comboBox1.Text + "%' ";
            }
            if (!string.IsNullOrEmpty(cmbCodeNumUser.Text.Trim()))
            {
                strWhere += " and a.createUser='" + cmbCodeNumUser.Text + "'";
            }
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim())) { 
                strWhere += " AND a.signDate>='" + dtpStart.Text + "'"; }
            if (!string.IsNullOrEmpty(dtpEnd.Text.Trim())) { 
                strWhere += " AND a.Signdate<='" + dtpEnd.Text + "'";}
            //supplier
            DataTable table = _bll.getTable(strWhere);
            strWhere = string.Empty;
            if (table != null && table.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["codeNum"].Value = table.Rows[i]["codeNum"].ToString();
                    row.Cells["codeNumContract"].Value = table.Rows[i]["codeNumContract"].ToString();
                    row.Cells["supplier"].Value = table.Rows[i]["supplier"].ToString();
                    row.Cells["supplierAbb"].Value = table.Rows[i]["supplierAbb"].ToString();
                    row.Cells["supplierUser"].Value = table.Rows[i]["supplierUser"].ToString();
                    row.Cells["buyer"].Value = table.Rows[i]["buyer"].ToString();
                    row.Cells["buyerAbb"].Value = table.Rows[i]["buyerAbb"].ToString();
                    row.Cells["buyerUser"].Value = table.Rows[i]["buyerUser"].ToString();
                    row.Cells["signDate"].Value = table.Rows[i]["signDate"].ToString();
                    row.Cells["signAdd"].Value = table.Rows[i]["signAdd"].ToString();
                    row.Cells["proName"].Value = table.Rows[i]["proName"].ToString();
                    row.Cells["bondPro"].Value = table.Rows[i]["bondPro"].ToString();
                    row.Cells["varieties"].Value = table.Rows[i]["varieties"].ToString();
                    row.Cells["rebate"].Value = table.Rows[i]["rebate"].ToString();
                    row.Cells["priceMY"].Value = table.Rows[i]["priceMY"].ToString();

                    row.Cells["purchase"].Value = table.Rows[i]["purchase"].ToString();
                    row.Cells["purchaseAbb"].Value = table.Rows[i]["purchaseAbb"].ToString();
                    row.Cells["purchaseUser"].Value = table.Rows[i]["purchaseUser"].ToString();

                    row.Cells["conProtein"].Value = table.Rows[i]["conProtein"].ToString();
                    row.Cells["conTVN"].Value = table.Rows[i]["conTVN"].ToString();
                    row.Cells["conZA"].Value = table.Rows[i]["conZA"].ToString();
                    row.Cells["conFFA"].Value = table.Rows[i]["conFFA"].ToString();
                    row.Cells["conZF"].Value = table.Rows[i]["conZF"].ToString();
                    row.Cells["conSF"].Value = table.Rows[i]["conSF"].ToString();
                    row.Cells["conSHY"].Value = table.Rows[i]["conSHY"].ToString();
                    row.Cells["conS"].Value = table.Rows[i]["conS"].ToString();
                    row.Cells["conSJ"].Value = table.Rows[i]["conSJ"].ToString();
                    row.Cells["conHF"].Value = table.Rows[i]["conHF"].ToString();
                    row.Cells["conLAS"].Value = table.Rows[i]["conLAS"].ToString();
                    row.Cells["conDAS"].Value = table.Rows[i]["conDAS"].ToString();
                    row.Cells["createUser"].Value = table.Rows[i]["createUser"].ToString();
                    row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                    row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                    row.Cells["specifications"].Value = table.Rows[i]["specifications"].ToString();
                    row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();
                    row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                    row.Cells["shipName"].Value = table.Rows[i]["shipName"].ToString();
                    row.Cells["billName"].Value = table.Rows[i]["billName"].ToString();

                    row.Cells["Money"].Value = table.Rows[i]["Money"].ToString(); 
                    row.Cells["createUser"].Value = table.Rows[i]["createUser"].ToString(); 

                    row.Cells["money"].Value = table.Rows[i]["money"].ToString();
                    row.Cells["num"].Value = table.Rows[i]["num"].ToString();
                    row.Cells["danjia"].Value = table.Rows[i]["danjia"].ToString();

                    row.Cells["process"].Value = table.Rows[i]["process"].ToString();
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_134");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_134");
        }
        protected void ReadColumnConfig(DataGridView dgv, string section)
        {
            string path = Application.StartupPath + "\\listconfig.ini";
            if (System.IO.File.Exists(path) == true)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string wstr = Utility.IniUtil.ReadIniValue(path, section, col.HeaderText);
                    int w = 0;
                    if (int.TryParse(wstr, out w))
                    {
                        col.Width = w;
                    }
                }
            }
        }
    }
}
