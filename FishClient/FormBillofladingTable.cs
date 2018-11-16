using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormBillofladingTable : FormMenuBase
    {
        string getname = string.Empty;
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        FishEntity.ProcessStateEntity _list = new FishEntity.ProcessStateEntity();
        FishBll.Bll.ProcessStateBll _bll = new FishBll.Bll.ProcessStateBll();
        public FormBillofladingTable(string name)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_103");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("codeOne", StringComparison.OrdinalIgnoreCase) != true)
            {
                billNum = dataGridView1.Rows[e.RowIndex].Cells["codeOne"].Value.ToString();
                Reflected("FishClient.FormBilloflading");
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
        FishEntity.BillofladingEntity _model = null;
        public FishEntity.BillofladingEntity getModel
        {
            get
            {
                return _model;
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("codeOne", StringComparison.OrdinalIgnoreCase) == true)
            {
                _model = new FishEntity.BillofladingEntity();
                if (dataGridView1.Rows[e.RowIndex].Cells["RedemptionWeight"].Value!=null&& dataGridView1.Rows[e.RowIndex].Cells["RedemptionWeight"].Value.ToString()!="")
                {
                    _model.RedemptionWeight =decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["RedemptionWeight"].Value.ToString());
                }
                else
                {
                    _model.RedemptionWeight = 0;
                }
                _model.Code = dataGridView1.Rows[e.RowIndex].Cells["codeOne"].Value.ToString();
                _model.Specification= dataGridView1.Rows[e.RowIndex].Cells["specification"].Value.ToString();
                _model.Ferryname = dataGridView1.Rows[e.RowIndex].Cells["ferryname"].Value.ToString();
                _model.Cornerno = dataGridView1.Rows[e.RowIndex].Cells["cornerno"].Value.ToString();
                _model.Listname = dataGridView1.Rows[e.RowIndex].Cells["listname"].Value.ToString();
                _model.Warehouse = dataGridView1.Rows[e.RowIndex].Cells["warehouse"].Value.ToString();
                _model.Country = dataGridView1.Rows[e.RowIndex].Cells["Country"].Value.ToString();
                _model.Brands = dataGridView1.Rows[e.RowIndex].Cells["Brands"].Value.ToString();

                this.DialogResult = DialogResult.OK;
            }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_103");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_103");
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

        public void ViewOne()
        {
            dataGridView1.Rows.Clear();
            List<FishEntity.BillofladingEntity> modelList = _bll.GetBillofladingListOne(getname);
            if (modelList != null)
            {
                decimal SumTon = 0;
                decimal sumRedemptionWeight = 0;
                foreach (FishEntity.BillofladingEntity model in modelList)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["id"].Value = model.Id;
                    row.Cells["codeOne"].Value = model.Code;
                    row.Cells["Issuingtime"].Value = model.Issuingtime;
                    row.Cells["codeContract"].Value = model.codeContract;
                    row.Cells["contactsunit"].Value = model.Contactsunit;
                    row.Cells["ContactsunitId"].Value = model.ContactsunitId;
                    row.Cells["warehouse"].Value = model.Warehouse;
                    row.Cells["species"].Value = model.Species;
                    row.Cells["specification"].Value = model.Specification;
                    row.Cells["cornerno"].Value = model.Cornerno;
                    row.Cells["ferryname"].Value = model.Ferryname;
                    row.Cells["listname"].Value = model.Listname;
                    row.Cells["Ton"].Value = model.Ton;
                    SumTon +=decimal.Parse(model.Ton.ToString());
                    row.Cells["RedemptionWeight"].Value = model.RedemptionWeight;
                    if (model.RedemptionWeight != null && model.RedemptionWeight.ToString() != "")
                    {
                        sumRedemptionWeight += decimal.Parse(model.RedemptionWeight.ToString());
                    }
                    row.Cells["packagenumber"].Value = model.Packagenumber;
                    row.Cells["Remarks"].Value = model.Remarks;
                    row.Cells["ShipNotice"].Value = model.ShipNotice;
                    row.Cells["Storagecosts"].Value = model.Storagecosts;
                    row.Cells["Recipient"].Value = model.Recipient;
                    row.Cells["SerialNumber"].Value = model.SerialNumber;
                    row.Cells["createman"].Value = model.Createman;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                    row.Cells["Country"].Value = model.Country;
                    row.Cells["Brands"].Value = model.Brands;
                }
                txtTon.Text = SumTon.ToString();
                txtRedemptionWeight.Text = sumRedemptionWeight.ToString();
            }
        }
        public override int Add()
        {
            FormBilloflading form = new FormBilloflading(getname);
            form.ShowDialog();
            ViewOne();
            return 0;
        }
    }
}
