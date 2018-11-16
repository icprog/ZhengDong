using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormDiscWarehouse : FormMenuBase
    {
        FishBll.Bll.DiscWarehouseBll bll = null;
        string strWhere = string.Empty;
        public FormDiscWarehouse()
        {

            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_108");
        }
        public override int Query()
        {

            bll = new FishBll.Bll.DiscWarehouseBll();
            strWhere = " 1=1 ";
            DataTable table=bll.getTable(strWhere);
            huizong.Text = table.Rows.Count.ToString();
            if (table != null && table.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["type"].Value = table.Rows[i]["type"].ToString();
                    row.Cells["CODE"].Value = table.Rows[i]["CODE"].ToString();
                    row.Cells["billofgoods"].Value = table.Rows[i]["billofgoods"].ToString();
                    row.Cells["quotesupplier"].Value = table.Rows[i]["quotesupplier"].ToString();
                    row.Cells["quotelinkman"].Value = table.Rows[i]["quotelinkman"].ToString();

                    row.Cells["nature"].Value = table.Rows[i]["nature"].ToString();
                    row.Cells["specification"].Value = table.Rows[i]["specification"].ToString();
                    row.Cells["quotedate"].Value = table.Rows[i]["quotedate"].ToString();
                    row.Cells["quotesaildatefast"].Value = table.Rows[i]["quotesaildatefast"].ToString();
                    row.Cells["quotesaildatelate"].Value = table.Rows[i]["quotesaildatelate"].ToString();

                    row.Cells["quote_protein"].Value = table.Rows[i]["quote_protein"].ToString();
                    row.Cells["quote_tvn"].Value = table.Rows[i]["quote_tvn"].ToString();
                    row.Cells["quote_amine"].Value = table.Rows[i]["quote_amine"].ToString();
                    row.Cells["confirmagent"].Value = table.Rows[i]["confirmagent"].ToString();
                    row.Cells["confirmlinkman"].Value = table.Rows[i]["confirmlinkman"].ToString();

                    row.Cells["quotedollars"].Value = table.Rows[i]["quotedollars"].ToString();
                    row.Cells["quotermb"].Value = table.Rows[i]["quotermb"].ToString();
                    row.Cells["conProtein"].Value = table.Rows[i]["conProtein"].ToString();
                    row.Cells["conTVN"].Value = table.Rows[i]["conTVN"].ToString();
                    row.Cells["conZA"].Value = table.Rows[i]["conZA"].ToString();

                    row.Cells["PlaceOfDelivery"].Value = table.Rows[i]["PlaceOfDelivery"].ToString();
                    row.Cells["confirmWeight"].Value = table.Rows[i]["confirmWeight"].ToString();
                    //row.Cells["conFFA"].Value = table.Rows[i]["conFFA"].ToString();
                    //row.Cells["conZF"].Value = table.Rows[i]["conZF"].ToString();
                    //row.Cells["conSF"].Value = table.Rows[i]["conSF"].ToString();
                    //row.Cells["conSHY"].Value = table.Rows[i]["conSHY"].ToString();
                    //row.Cells["conS"].Value = table.Rows[i]["conS"].ToString();

                    //row.Cells["conSJ"].Value = table.Rows[i]["conSJ"].ToString();
                    //row.Cells["conHF"].Value = table.Rows[i]["conHF"].ToString();
                    //row.Cells["conLAS"].Value = table.Rows[i]["conLAS"].ToString();
                    //row.Cells["conDAS"].Value = table.Rows[i]["conDAS"].ToString();
                }
            }
            else
            {
                //MessageBox.Show("查无数据！");
            }
            return base.Query();
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_108");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_108");
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
