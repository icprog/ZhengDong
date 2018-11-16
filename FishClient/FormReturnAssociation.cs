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
    public partial class FormReturnAssociation : FormMenuBase
    {
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        FishBll.Bll.ReturnReceiptBll _bll = null;
        string getname = string.Empty;
        string name = string.Empty;
        public FormReturnAssociation()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_140");
        }
        public FormReturnAssociation(string Numbering) {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_140");
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
            _bll = new FishBll.Bll.ReturnReceiptBll();
            if (Numbering != "" && Numbering != null)
            {
                name = Numbering;Query();
                getname = Numbering;
            }
        }
        public override int Query()
        {
                DataTable table = _bll.getTable(" codeNum= '" + name + "' ");
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                decimal num1 = 0.00M;
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
                    if (table.Rows[i]["loss"].ToString()!=null&& table.Rows[i]["loss"].ToString()!="")
                    {
                        num1 += decimal.Parse(table.Rows[i]["loss"].ToString());
                    }
                    }
                textBox1.Text = num1.ToString();
                }     
            return base.Query();
        }
        public override int Add()
        {
            FormReturnReceipt form = new FormReturnReceipt(getname);
            form.ShowDialog();
            Query();
            return base.Add();
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_140");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_140");
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            Reflected("FishClient.FormReturnReceipt");
        }
        void Reflected(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Form doc = (Form)asm.CreateInstance(path);
            Megres.oddNum = billNum;
            doc.Owner = this;
            doc.Show();
        }
    }
}
