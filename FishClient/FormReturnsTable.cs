using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormReturnsTable : FormMenuBase
    {
        FishBll.Bll.ReturnReceiptBll _bll = null;
        string strWhere = string.Empty;
        public FormReturnsTable()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_141");
        }
        public override int Query()
        {
            if (Megres.oddNum != "" && Megres.oddNum != null)
            {
                strWhere += " codeNum= '" + Megres.oddNum + "' ";
            }
            else {
                strWhere = string.Empty;
            }
            _bll = new FishBll.Bll.ReturnReceiptBll();
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
                    row.Cells["CODE"].Value = table.Rows[i]["CODE"].ToString();
                    row.Cells["returnPartyJ"].Value = table.Rows[i]["returnPartyJ"].ToString();
                    row.Cells["receiveJ"].Value = table.Rows[i]["receiveJ"].ToString();
                    row.Cells["speci"].Value = table.Rows[i]["speci"].ToString();
                    row.Cells["tons"].Value = table.Rows[i]["tons"].ToString();
                    row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                    row.Cells["money"].Value = table.Rows[i]["money"].ToString();
                    row.Cells["returnGoodsAdd"].Value = table.Rows[i]["returnGoodsAdd"].ToString();
                    row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                    row.Cells["freight"].Value = table.Rows[i]["freight"].ToString();
                    row.Cells["cost"].Value = table.Rows[i]["cost"].ToString();
                    row.Cells["loss"].Value = table.Rows[i]["loss"].ToString();
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }

        private void FormReturnsTable_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                Query ( );
            }
            Megres . oddNum = string . Empty;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_141");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_141");
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
