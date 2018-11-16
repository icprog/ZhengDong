using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPricingAssociation : FormMenuBase
    {
        FishBll.Bll.QuotationPriceListBll _bll = null;
        string name = string.Empty;
        public FormPricingAssociation()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_124");
        }
        public FormPricingAssociation(string CodeNum)
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_124");
            tmiQuery.Visible = false;
            tmiSave.Visible = false;
            tmiReview.Visible = false;
            tmiprint.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiModify.Visible = false;
            tmiExport.Visible = false;
            tmiDelete.Visible = false;
            tmiClose.Visible = false;
            tmiCancel.Visible = false;
            tmiAdd.Visible = true;
            _bll = new FishBll.Bll.QuotationPriceListBll();
            name = CodeNum;
            Query();
        }
        public override int Add()
        {
            FormQuotationPriceList form = new FormQuotationPriceList();
            form.ShowDialog();
            Query();
            return base.Add();
        }
        public override int Query()
        {
            if (name != "" && name != null)
            {
                DataTable table = _bll.getTable(" 1=1 ");
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int idx = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[idx];
                        row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                        row.Cells["CODE"].Value = table.Rows[i]["CODE"].ToString();
                        row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                        row.Cells["priceMY"].Value = table.Rows[i]["priceMY"].ToString();
                        row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                        row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                        row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();
                        row.Cells["qualitySpe"].Value = table.Rows[i]["qualitySpe"].ToString();
                        row.Cells["weight"].Value = table.Rows[i]["weight"].ToString();
                        row.Cells["tvn"].Value = table.Rows[i]["tvn"].ToString();
                        row.Cells["acid"].Value = table.Rows[i]["acid"].ToString();
                        row.Cells["protein"].Value = table.Rows[i]["protein"].ToString();
                        row.Cells["ash"].Value = table.Rows[i]["ash"].ToString();
                        row.Cells["histamine"].Value = table.Rows[i]["histamine"].ToString();
                        row.Cells["las"].Value = table.Rows[i]["las"].ToString();
                        row.Cells["das"].Value = table.Rows[i]["das"].ToString();
                        row.Cells["salt"].Value = table.Rows[i]["salt"].ToString();
                        row.Cells["XNfishId"].Value = table.Rows[i]["XNfishId"].ToString();
                        row.Cells["ffa"].Value = table.Rows[i]["ffa"].ToString();
                    }
                }
                else
                {
                    MessageBox.Show("查无数据！");
                }
            }
            else {
                MessageBox.Show("鱼粉id没有带入");
            }
            return base.Query();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["CODE"].Value.ToString();
            Reflected("FishClient.FormQuotationPriceList");
        }
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_124");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_124");
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

        void Reflected(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Form doc = (Form)asm.CreateInstance(path);
            Megres.oddNum = billNum;
            doc.Show();
        }
    }
}
