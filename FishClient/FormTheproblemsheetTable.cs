using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormTheproblemsheetTable : FormMenuBase
    {
        string getname = string.Empty;
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        FishBll.Bll.ProcessStateBll _bll = new FishBll.Bll.ProcessStateBll();
        public FormTheproblemsheetTable()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_144");
        }
        public FormTheproblemsheetTable(string code)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_144");
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
            if (code != "")
            {
                getname = code;
                ViewOne();
            }
        }
        public void ViewOne()
        {
            dataGridView1.Rows.Clear();
            List<FishEntity.TheproblemsheetEntity> modelList = _bll.GetTheproblemsheetList(getname);
            if (modelList != null)
            {
                decimal koukuang = 0;
                foreach (FishEntity.TheproblemsheetEntity model in modelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["id"].Value = model.Id;
                    row.Cells["code"].Value = model.Code;
                    row.Cells["codeContract"].Value = model.codeContract;
                    row.Cells["occurDate"].Value = model.OccurDate;
                    row.Cells["EventName"].Value = model.EventName;
                    row.Cells["SolvTtheProblem"].Value = model.SolvTtheProblem;
                    row.Cells["Remarks"].Value = model.Remarks;
                    koukuang += model.Chargeback;
                    row.Cells["Chargeback"].Value = model.Chargeback;
                    row.Cells["createman"].Value = model.Createman;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                }
                txtkoukuan.Text = koukuang.ToString();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            Reflected("FishClient.FormTheproblemsheet");
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_144");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_144");
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
            doc.Owner = this;
            doc.Show();
        }
        public override int Add()
        {
            FormTheproblemsheet form = new FormTheproblemsheet(getname);
            form.ShowDialog();
            ViewOne();
            return 0;
        }
    }
}
