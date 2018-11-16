using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPurchaseContractTable : FormMenuBase
    {
        FishBll.Bll.PurcurementContractBll _bll = null;
        string strWhere = string.Empty;
        public FormPurchaseContractTable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_133");
        }
        public override int Query()
        {
            _bll = new FishBll.Bll.PurcurementContractBll();
            strWhere = " 1=1 ";
            DataTable table = _bll.getTable(strWhere);
            strWhere = string.Empty;
            if (table != null && table.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                    row.Cells["codeNum"].Value = table.Rows[i]["codeNum"].ToString();
                    row.Cells["codeNumContract"].Value = table.Rows[i]["codeNumContract"].ToString();
                    row.Cells["supplier"].Value = table.Rows[i]["supplier"].ToString();
                    row.Cells["supplierUser"].Value = table.Rows[i]["supplierUser"].ToString();
                    row.Cells["signDate"].Value = table.Rows[i]["signDate"].ToString();
                    row.Cells["signAdd"].Value = table.Rows[i]["signAdd"].ToString();
                    row.Cells["bondPro"].Value = table.Rows[i]["bondPro"].ToString();
                    row.Cells["quaSpe"].Value = table.Rows[i]["quaSpe"].ToString();
                    row.Cells["conutry"].Value = table.Rows[i]["conutry"].ToString();
                    row.Cells["height"].Value = table.Rows[i]["height"].ToString();
                    row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                    row.Cells["priceMY"].Value = table.Rows[i]["priceMY"].ToString();
                    row.Cells["shipDate"].Value = table.Rows[i]["shipDate"].ToString();
                    row.Cells["UnitPrice"].Value = table.Rows[i]["UnitPrice"].ToString();
                    row.Cells["Dollar"].Value = table.Rows[i]["Dollar"].ToString();
                    row.Cells["deliveryDate"].Value = table.Rows[i]["deliveryDate"].ToString();
                    row.Cells["deliveryAdd"].Value = table.Rows[i]["deliveryAdd"].ToString();
                    row.Cells["conProtein"].Value = table.Rows[i]["conProtein"].ToString();
                    row.Cells["conTVN"].Value = table.Rows[i]["conTVN"].ToString();
                    row.Cells["conZA"].Value = table.Rows[i]["conZA"].ToString();
                    row.Cells["conFFA"].Value = table.Rows[i]["conFFA"].ToString();
                    row.Cells["conSHY"].Value = table.Rows[i]["conSHY"].ToString();
                    row.Cells["conHF"].Value = table.Rows[i]["conHF"].ToString();
                    row.Cells["conLAS"].Value = table.Rows[i]["conLAS"].ToString();
                    row.Cells["conDAS"].Value = table.Rows[i]["conDAS"].ToString();
                    row.Cells["brands"].Value = table.Rows[i]["brands"].ToString();
                    row.Cells["money"].Value = table.Rows[i]["money"].ToString();
                    row.Cells["num"].Value = table.Rows[i]["num"].ToString();
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_133");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_133");
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
