using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormProcurementAssociation :FormMenuBase
    {
        FishBll.Bll.PurchaseApplicationBll _bll = null;
        string CodeNum = string.Empty;
        public FormProcurementAssociation()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_131");
        }
        public override int Add()
        {
            return base.Add();
        }
        public override int Query()
        {
            _bll = new FishBll.Bll.PurchaseApplicationBll();
            DataTable table = _bll.getTable(CodeNum);
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
                    row.Cells["shipDate"].Value = table.Rows[i]["shipDate"].ToString();
                    row.Cells["arriveDate"].Value = table.Rows[i]["arriveDate"].ToString();
                    row.Cells["deliveryDate"].Value = table.Rows[i]["deliveryDate"].ToString();
                    row.Cells["deliveryAdd"].Value = table.Rows[i]["deliveryAdd"].ToString();
                    row.Cells["deliveryLast"].Value = table.Rows[i]["deliveryLast"].ToString();
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
                    row.Cells["remark"].Value = table.Rows[i]["remark"].ToString();
                    row.Cells["createUser"].Value = table.Rows[i]["createUser"].ToString();
                    row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                    row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                    row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                    row.Cells["weight"].Value = table.Rows[i]["weight"].ToString();
                    row.Cells["priceUSA"].Value = table.Rows[i]["priceUSA"].ToString();
                    row.Cells["specifications"].Value = table.Rows[i]["specifications"].ToString();
                    row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();
                    row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                    row.Cells["shipName"].Value = table.Rows[i]["shipName"].ToString();
                    row.Cells["billName"].Value = table.Rows[i]["billName"].ToString();
                    row.Cells["brand1"].Value = table.Rows[i]["brand1"].ToString();
                    row.Cells["money"].Value = table.Rows[i]["money"].ToString();
                    row.Cells["num"].Value = table.Rows[i]["num"].ToString();
                    row.Cells["jine"].Value = table.Rows[i]["jine"].ToString();
                    row.Cells["danjia"].Value = table.Rows[i]["danjia"].ToString();
                }
            }
            else
            {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }
        #region
        //SELECT a.id, a.codeNum, a.codeNumContract, a.supplier, a.supplierAbb, a.supplierUser, a.buyer, a.buyerAbb, a.buyerUser, a.signDate, a.signAdd, a.proName, a.bondPro, a.varieties, a.rebate, a.priceMY, a.shipDate, a.arriveDate, a.deliveryDate, a.deliveryAdd, a.deliveryLast, a.conProtein, a.conTVN, a.conZA, a.conFFA, a.conZF, a.conSF, a.conSHY, a.conS, a.conSJ, a.conHF, a.conLAS, a.conDAS, a.remark, a.createUser, a.purchase, a.purchaseAbb, a.purchaseUser, b.`code`, b.fishId, b.price, b.weight, b.priceUSA, b.specifications, b.brand, b.country, b.shipName, b.billName from t_purchaseapplication a left join t_purchasefishinfo b on a.codeNum= b.code
        #endregion

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_131");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_131");
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
