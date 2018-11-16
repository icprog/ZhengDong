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
    public partial class FormOutboundAssociation : FormMenuBase
    {
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        string getname =string.Empty;
        FishBll.Bll.OutboundOrderBll _bll = null;
        string name = string.Empty;
        public FormOutboundAssociation()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_117");
        }
        public FormOutboundAssociation(string Numbering)
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_117");
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
            _bll = new FishBll.Bll.OutboundOrderBll();
            name = Numbering; Query();
            getname = Numbering;
        }
        public override int Query()
        {
            if (name != "" && name != null)
            {
                DataTable table = _bll.getTable(" codeNum= '" + name + "' ");
                if (table != null && table.Rows.Count > 0)
                {
                    dataGridView1.Rows.Clear();
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        int idx = dataGridView1.Rows.Add();
                        DataGridViewRow row = dataGridView1.Rows[idx];
                        row.Cells["seNumber"].Value = table.Rows[i]["seNumber"].ToString();
                        row.Cells["code"].Value = table.Rows[i]["code"].ToString();
                        row.Cells["unit"].Value = table.Rows[i]["unit"].ToString();

                        row.Cells["type"].Value = table.Rows[i]["type"].ToString();
                        row.Cells["shipName"].Value = table.Rows[i]["shipName"].ToString();
                        row.Cells["weight"].Value = table.Rows[i]["weight"].ToString();

                        row.Cells["pileNum"].Value = table.Rows[i]["pileNum"].ToString();
                        row.Cells["codeNum"].Value = table.Rows[i]["codeNum"].ToString();
                        row.Cells["codeNumContract"].Value = table.Rows[i]["codeNumContract"].ToString();

                        row.Cells["date"].Value = table.Rows[i]["date"].ToString();
                        row.Cells["waseHouse"].Value = table.Rows[i]["waseHouse"].ToString();
                        row.Cells["speci"].Value = table.Rows[i]["speci"].ToString();

                        row.Cells["billName"].Value = table.Rows[i]["billName"].ToString();
                        row.Cells["pageNum"].Value = table.Rows[i]["pageNum"].ToString();
                        row.Cells["remark"].Value = table.Rows[i]["remark"].ToString();

                        row.Cells["notice"].Value = table.Rows[i]["notice"].ToString();
                        row.Cells["ware"].Value = table.Rows[i]["ware"].ToString();
                        row.Cells["receive"].Value = table.Rows[i]["receive"].ToString();

                        row.Cells["FishMealId"].Value = table.Rows[i]["FishMealId"].ToString();
                        row.Cells["Country"].Value = table.Rows[i]["Country"].ToString();
                        row.Cells["Brands"].Value = table.Rows[i]["Brands"].ToString();
                        row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                    }
                }
            }
            else {
            }
            return base.Query();
        }
        public override int Add()
        {
            FormOutboundOrder form = new FormOutboundOrder(getname);
            form.ShowDialog();
            Query();
            return 0;
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_117");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_117");
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
            //
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            Reflected("FishClient.FormOutboundOrder");
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
