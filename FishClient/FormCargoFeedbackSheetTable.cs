using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCargoFeedbackSheetTable : FormMenuBase
    {
        string getname = string.Empty; string getcode = string.Empty;
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        FishBll.Bll.ProcessStateBll _bll = new FishBll.Bll.ProcessStateBll();
        public FormCargoFeedbackSheetTable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_106");
        }
        public FormCargoFeedbackSheetTable(string name)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_106");
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
            if (name != "")
            {
                getname = name;
                ViewOne();
            }
        }
        public void ViewOne()
        {
            dataGridView1.Rows.Clear();
            List<FishEntity.CargoFeedbackSheetEntity> modelList = _bll.GetCargoFeedbackSheetList(getname);
            if (modelList!=null)
            {
                decimal SumConfirmTheWeight = 0;
                foreach (FishEntity.CargoFeedbackSheetEntity model in modelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["id"].Value = model.Id;
                    row.Cells["code"].Value = model.Code;
                    row.Cells["codeContract"].Value = model.codeContract;
                    row.Cells["sponsor"].Value = model.Sponsor;
                    row.Cells["acceptor"].Value = model.Acceptor;
                    row.Cells["processresult"].Value = model.Processresult;
                    row.Cells["evaluation"].Value = model.Evaluation;
                    row.Cells["ConfirmTheWeight"].Value = model.ConfirmTheWeight;
                    if (model.ConfirmTheWeight!=null&& model.ConfirmTheWeight!="")
                    {
                        SumConfirmTheWeight += decimal.Parse(model.ConfirmTheWeight.ToString());
                    }
                    row.Cells["remarks"].Value = model.Remarks;
                    row.Cells["createman"].Value = model.Createman;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                    row.Cells["PoundDifference"].Value = model.PoundDifference;
                    row.Cells["NetWeight"].Value = model.NetWeight;
                    row.Cells["PoundBillNumber"].Value = model.PoundBillNumber;
                }
                txtCompetition.Text = SumConfirmTheWeight.ToString();
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

                billNum = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                Reflected("FishClient.FormCargoFeedbackSheet");
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_106");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_106");
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
            FormCargoFeedbackSheet form = new FormCargoFeedbackSheet(getname);
            form.ShowDialog();
            ViewOne();
            return 0;
        }
    }
}
