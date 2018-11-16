using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormTotalDataSheet : FormMenuBase
    {
        FishBll.Bll.TotalDataSheetbll _bll = new FishBll.Bll.TotalDataSheetbll();
        public FormTotalDataSheet()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_145");
            Query();
        }
        public override int Query()
        {
            string strWhere = " 1=1";
            DataTable queryTable = _bll.getTable(strWhere);
            if (queryTable != null && queryTable.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < queryTable.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = queryTable.Rows[i]["Numbering"].ToString();
                    row.Cells["DateOfSigni"].Value = queryTable.Rows[i]["DateOfSigni"].ToString();
                    row.Cells["supplier"].Value = queryTable.Rows[i]["supplier"].ToString();
                    row.Cells["Quantity"].Value = queryTable.Rows[i]["Quantity"].ToString();
                    row.Cells["UnitPrice"].Value = queryTable.Rows[i]["UnitPrice"].ToString();
                    row.Cells["AmountOfMoney"].Value = queryTable.Rows[i]["AmountOfMoney"].ToString();
                    row.Cells["ContractNo"].Value = queryTable.Rows[i]["ContractNo"].ToString();
                    row.Cells["Signdate"].Value = queryTable.Rows[i]["Signdate"].ToString();
                    row.Cells["demand"].Value = queryTable.Rows[i]["demand"].ToString();
                    row.Cells["code"].Value = queryTable.Rows[i]["code"].ToString();
                    row.Cells["rebate"].Value = queryTable.Rows[i]["rebate"].ToString();
                    row.Cells["Freight"].Value = queryTable.Rows[i]["Freight"].ToString();
                    row.Cells["Quantity1"].Value = queryTable.Rows[i]["Quantity1"].ToString();
                    row.Cells["unitprice1"].Value = queryTable.Rows[i]["unitprice1"].ToString();
                    row.Cells["Issuingtime"].Value = queryTable.Rows[i]["Issuingtime"].ToString();
                    row.Cells["Quantity2"].Value = queryTable.Rows[i]["Quantity2"].ToString();
                    row.Cells["code1"].Value = queryTable.Rows[i]["code1"].ToString();
                    row.Cells["applyDate"].Value = queryTable.Rows[i]["applyDate"].ToString();
                    row.Cells["weight"].Value = queryTable.Rows[i]["weight"].ToString();
                    row.Cells["applyMoney"].Value = queryTable.Rows[i]["applyMoney"].ToString();
                    row.Cells["fuKuandate"].Value = queryTable.Rows[i]["fuKuandate"].ToString();
                    row.Cells["RMB"].Value = queryTable.Rows[i]["RMB"].ToString();
                    row.Cells["code2"].Value = queryTable.Rows[i]["code2"].ToString();
                    row.Cells["actualnumber"].Value = queryTable.Rows[i]["actualnumber"].ToString();
                    row.Cells["Billnumber"].Value = queryTable.Rows[i]["Billnumber"].ToString();
                    row.Cells["Zhuangjiao"].Value = queryTable.Rows[i]["Zhuangjiao"].ToString();
                    row.Cells["StorageLocation"].Value = queryTable.Rows[i]["StorageLocation"].ToString();
                    row.Cells["Shipname"].Value = queryTable.Rows[i]["Shipname"].ToString();
                    row.Cells["createman"].Value = queryTable.Rows[i]["createman"].ToString();
                    if (queryTable.Rows[i]["UnitPrice"].ToString()!=""&& queryTable.Rows[i]["actualnumber"].ToString()!="")
                    {
                        row.Cells["ActualPayment"].Value = decimal.Parse(queryTable.Rows[i]["UnitPrice"].ToString()) * decimal.Parse(queryTable.Rows[i]["actualnumber"].ToString());
                    }
                    if (queryTable.Rows[i]["Quantity1"].ToString() != "" && queryTable.Rows[i]["unitprice1"].ToString() != "")
                    {
                        row.Cells["SalesContractAmount"].Value = decimal.Parse(queryTable.Rows[i]["Quantity1"].ToString()) * decimal.Parse(queryTable.Rows[i]["unitprice1"].ToString());
                    }
                    if (queryTable.Rows[i]["unitprice1"].ToString() != "" && queryTable.Rows[i]["Quantity2"].ToString() != "")
                    {
                        row.Cells["SettlementAmount"].Value = decimal.Parse(queryTable.Rows[i]["unitprice1"].ToString()) * decimal.Parse(queryTable.Rows[i]["Quantity2"].ToString());
                    }                    
                    row.Cells["ContractHasReceivedPayment"].Value= queryTable.Rows[i]["RMB"].ToString();
                    if (queryTable.Rows[i]["unitprice1"].ToString() != "" && queryTable.Rows[i]["RMB"].ToString() != ""&& queryTable.Rows[i]["Quantity2"].ToString()!="")
                    {
                        row.Cells["TailMoney"].Value = decimal.Parse(queryTable.Rows[i]["unitprice1"].ToString()) * decimal.Parse(queryTable.Rows[i]["Quantity2"].ToString()) - decimal.Parse(queryTable.Rows[i]["RMB"].ToString());
                    }                    
                }
            }
            return base.Query();
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_145");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_145");
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
