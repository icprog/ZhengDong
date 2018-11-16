using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormReceiptRecordtable : FormMenuBase
    {
        string getname = string.Empty;
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        FishBll.Bll.ProcessStateBll _bll = new FishBll.Bll.ProcessStateBll();
        FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();
        public override int Add()
        {
            FormReceiptRecord form = new FormReceiptRecord(getname);
            form.ShowDialog();
            view_two();
            return 0;
        }
        public FormReceiptRecordtable(string name)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView3, "Set_137");
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
                view_two();
            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView3.Rows[e.RowIndex].Cells["codeTwo"].Value.ToString();
            Reflected("FishClient.FormReceiptRecord");
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView3.Columns, "Set_137");
            form.ShowDialog();

            ReadColumnConfig(dataGridView3, "Set_137");
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
        void view_two()
        {
            dataGridView3.Rows.Clear();

            List<FishEntity.ReceiptRecordEntity> modelList = _bll.GetListTwo(getname);
            if (modelList != null)
            {
                decimal SumweightOne = 0; decimal RMB = 0;
                foreach (FishEntity.ReceiptRecordEntity model in modelList)
                {
                    int idx = dataGridView3.Rows.Add();
                    DataGridViewRow row = dataGridView3.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["codeContract"].Value = model.codeContract;
                    row.Cells["codeTwo"].Value = model.code;
                    row.Cells["fuKuandate"].Value = model.fuKuandate;
                    row.Cells["codePrice"].Value = model.codePrice;
                    row.Cells["codeYunFei"].Value = model.codeYunFei;
                    row.Cells["codeHuiKou"].Value = model.codeHuiKou;
                    row.Cells["fuKuanDanWei"].Value = model.fuKuanDanWei;
                    row.Cells["fuKuanZhangHao"].Value = model.fuKuanZhangHao;
                    row.Cells["weightOne"].Value = model.weight;
                    SumweightOne += decimal.Parse(model.weight.ToString());
                    row.Cells["priceOne"].Value = model.price;
                    row.Cells["jiner"].Value = model.price * model.weight;
                    row.Cells["fuKuanType"].Value = model.fuKuanType;
                    row.Cells["fuKuanMethod"].Value = model.fuKuanMethod;
                    row.Cells["RMB"].Value = model.RMB;
                    RMB += decimal.Parse(model.RMB.ToString());
                    row.Cells["invoiceTypeOne"].Value = model.invoiceType;
                    row.Cells["remarkOne"].Value = model.remark;
                    row.Cells["ShouKuanZhuangTai"].Value = model.ShouKuanZhuangTai;
                    row.Cells["DemaUndnit"].Value = model.DemaUndnit;
                    row.Cells["DemaUndnitId"].Value = model.DemaUndnitId;
                    row.Cells["DemandSideContact"].Value = model.DemandSideContact;
                    row.Cells["DemandSideContactId"].Value = model.DemandSideContactId;
                    row.Cells["createMan"].Value = model.createMan;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                }
                txtweightOne.Text = SumweightOne.ToString();
                txtRMB.Text = RMB.ToString();
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
    }
}
