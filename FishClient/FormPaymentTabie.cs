using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;


namespace FishClient
{
    public partial class FormPaymentTabie : FormMenuBase
    {
        string getname,XCNumbering,num = string.Empty;
        string bill = string.Empty, billNum = string.Empty, path = string.Empty;
        FishBll.Bll.ProcessStateBll _bll = new FishBll.Bll.ProcessStateBll();
        FishEntity.ProcessStateEntity _list =new FishEntity.ProcessStateEntity();
        public FormPaymentTabie()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView2, "Set_121");
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
        }
        public FormPaymentTabie(string name,string XC)
        {
            InitializeComponent(); ReadColumnConfig(dataGridView2, "Set_121");
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
                XCNumbering = XC;
                view_one();
            }
        }
        public override void Cancel()
        {


            base.Cancel();
        }

        private void FormPaymentTabie_FormClosed(object sender, FormClosedEventArgs e)
        {

            return;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView2.Columns, "Set_121");
            form.ShowDialog();

            ReadColumnConfig(dataGridView2, "Set_121");
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
        public override int Add()
        {
            FormPaymentRequisition form = new FormPaymentRequisition(getname,XCNumbering);
            form.ShowDialog();
            view_one();
            return 0;  
        }
        public void view_one()
        {
            dataGridView2.Rows.Clear();
            if (XCNumbering == "X")
            {
                num = " a.Numbering='" + getname + "' ";
            }
            else if (XCNumbering == "C")
            {
                num = " a.CNumbering='" + getname + "' ";
            }
            List<FishEntity.PaymentRequisitionEntity> modelList = _bll.GetListOne(num);
            if (modelList != null)
            {
                decimal Sumweight = 0; decimal jine = 0,baozheng=0, huok = 0;
                foreach (FishEntity.PaymentRequisitionEntity model in modelList)
                {
                    int idx = dataGridView2.Rows.Add();
                    DataGridViewRow row = dataGridView2.Rows[idx];
                    row.Cells["Numbering"].Value = model.Numbering;
                    row.Cells["applyCode"].Value = model.applyCode;
                    row.Cells["code"].Value = model.code;
                    row.Cells["purchasecode"].Value = model.Purchasecode;
                    row.Cells["applyDate"].Value = model.applyDate;
                    row.Cells["acountNum"].Value = model.AcountNum;
                    row.Cells["unit"].Value = model.unit;
                    row.Cells["contacts"].Value = model.contacts;
                    row.Cells["backDeposit"].Value = model.backDeposit;
                    row.Cells["price"].Value = model.price;
                    row.Cells["weight"].Value = model.weight;
                    Sumweight += decimal.Parse(model.weight.ToString());
                    jine += decimal.Parse(model.applyMoney.ToString());
                    row.Cells["applyMoney"].Value = model.applyMoney;
                    row.Cells["jine"].Value = model.price * model.weight; row.Cells["bond"].Value = model.bond;
                    row.Cells["paymentMethod"].Value = model.paymentMethod;
                    row.Cells["paymentType"].Value = model.paymentType;
                    row.Cells["paymentDate"].Value = model.paymentDate;
                    row.Cells["invoiceType"].Value = model.invoiceType;
                    row.Cells["remark"].Value = model.remark;
                    row.Cells["state"].Value = model.paymentMethodOther;
                    row.Cells["createMan"].Value = model.createMan;
                    row.Cells["FishMealId"].Value = model.FishMealId;
                    if (model.PricingType == "保证金")
                    {
                        baozheng += decimal.Parse(row.Cells["applyMoney"].Value.ToString());
                    }
                    else if (model.PricingType == "货款") {
                        huok  += decimal.Parse(row.Cells["applyMoney"].Value.ToString());
                    }
                        row.Cells["PricingType"].Value = model.PricingType;
                    row.Cells["CNumbering"].Value = model.CNumbering;
                    row.Cells["PurchasingUnit"].Value = model.PurchasingUnit;
                }
                txtweight.Text = Sumweight.ToString();

                txtjine.Text = jine.ToString();
                textBox1.Text = huok.ToString();
                textBox2.Text = baozheng.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            billNum = dataGridView2.Rows[e.RowIndex].Cells["code"].Value.ToString();
            Reflected("FishClient.FormPaymentRequisition");
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
