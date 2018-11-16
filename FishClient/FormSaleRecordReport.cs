using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSaleRecordReport : FormMenuBase
    {
        FishBll.Bll.CallRecordsVoBll _bll = new FishBll.Bll.CallRecordsVoBll();
        //FishEntity.CallRecordsEntity _entity = null;
        List<FishEntity.CallRecordsEntity> _entity = null;
        string _where = string.Empty;
        FishBll.Bll.CallRecordsDetailBll _detailBll = new FishBll.Bll.CallRecordsDetailBll();
        List<FishEntity.CallRecordsDetailEntnty> _detail = null;
        UILibrary.TwoDimenDataGridView dgvUtil = null;
        public event EventHandler RefreshDataEvent = null;
        //private string _orderBy = " order by id asc limit 1";
        string _rolewhere = string.Empty;
        public FormSaleRecordReport()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SaleRecordReport");
            FishEntity.SystemDataType item = new FishEntity.SystemDataType(string.Empty, string.Empty);
            List<FishEntity.SystemDataType> list = FishEntity.Variable.ProductDataTypeList.GetRange(0, FishEntity.Variable.ProductDataTypeList.Count);
            list.Insert(0, item);
            cmbCountry.DataSource = list;
            cmbCountry.DisplayMember = "name";
            cmbCountry.ValueMember = "code";
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);//
            InitDataUtil.BindComboBoxData(cmbPZ, FishEntity.Constant.Specification, true);
            //dtpStart.Value = DateTime.Now.AddYears(-1);
            //dtpEnd.Value = DateTime.Now.AddYears(1);
        }
        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtCustomer.Text))
            {
                where += string.Format(" and customer like '%{0}%' ", txtCustomer.Text.Trim() );
            }
            if (false == string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                where += string.Format(" and nature like '%{0}%' ", cmbCountry.SelectedValue.ToString().Trim());
            }
            if (cmbPZ.SelectedValue != null && string.IsNullOrEmpty(cmbPZ.SelectedValue.ToString()) == false)
            {
                where += string.Format(" and specification like '%{0}%' ", cmbPZ.SelectedValue.ToString()) ;
            }
            if (false==string.IsNullOrEmpty(txtMan.Text))
            {
                where += string.Format(" and createman like '%{0}%' ", txtMan.Text.Trim());
            }
            where += string.Format(" and currentdate>='{0}' and currentdate<='{1}'",
            dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
            dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
            return where;
        }
        public override int Query()
        {
            decimal sum = 0;
            menuStrip1.Focus();
            string where = GetWhereCondition();
            //List<FishEntity.CallRecordsEntity> list = _bll.GetSpot(where);
            _entity = _bll.GetSpot(where);

            //AddGroupRow(_list);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _entity;
            // MessageBox.Show(this.dataGridView1.SelectedCells[10].Value.ToString());this.dataGridView1.Rows[i].Cells[10].Value.ToString()
            //this.dataGridView1.SelectedCells[5].Value.ToString();length
            //MessageBox.Show(dataGridView1.RowCount.ToString());
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                sum += decimal.Parse(this.dataGridView1.Rows[i].Cells[10].Value.ToString());
            }
            txtTotal.Text = sum.ToString();
            if (_entity == null ) return 0;

            Add();

            return 1;
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SaleRecordReport");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SaleRecordReport");
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

        private void txtCustomer_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtCustomer.Text = form.SelectCompany.fullname;
            txtCustomer.Tag = form.SelectCompany.code;
        }
    }
}
