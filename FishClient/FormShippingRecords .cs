using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormShippingRecords : FormMenuBase
    {
        public event Action<EventArgs> RefreshEvent = null;
        List<FishEntity.ShippingRecordsEntity> _list = null;
        FishBll.Bll.ShippingRecordsBll _bll = new FishBll.Bll.ShippingRecordsBll();
        string where = string.Empty;

        void form_RefreshEvent(EventArgs obj)
        {
            Query();
        }
        public FormShippingRecords()
        {
            InitializeComponent();
            BindData();

        }
        public override int Query()
        {
            where = GetWhereCondition;
            _list =_bll.GetQuery(where);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;
            if (_list == null || _list.Count < 1)
            {
                MessageBox.Show("查无数据");
            }
            return base.Query();
        }
        public string GetWhereCondition
        {
            get
            {
                 where = string.Format(" 1 = 1 ");
                if (false==string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like'%{0}%'", txtcode.Text.Trim());
                }
                if (false==string.IsNullOrEmpty(txtShippingUnit.Text))
                {
                    where += string.Format(" and ShippingUnit like'%{0}%'", txtShippingUnit.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtFreight.Text))
                {
                    where += string.Format(" and Freight like'%{0}%'", txtFreight.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtArrivalUnit.Text))
                {
                    where += string.Format(" and ArrivalUnit like'%{0}%'", txtArrivalUnit.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtCarNumber.Text))
                {
                    where += string.Format(" and CarNumber like'%{0}%'", txtCarNumber.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtShipName.Text))
                {
                    where += string.Format(" and ShipName like'%{0}%'", txtShipName.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtBillOfLadingNumber.Text))
                {
                    where += string.Format(" and BillOfLadingNumber like'%{0}%'", txtBillOfLadingNumber.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(cmbCountry.Text))
                {
                    where += string.Format(" and Country ='{0}'", cmbCountry.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(cmbBrand.Text))
                {
                    where += string.Format(" and Brand ='{0}'", cmbBrand.Text.Trim());
                }
                //if (false == string.IsNullOrEmpty(dtppickuptime.Text))
                //{
                //    where += string.Format(" and pickuptime like'%{0}%'", dtppickuptime.Text.Trim());
                //}
                return where;
            }
        }
        public override int Add()
        {
            FormShippingRecordsedit form = new FormShippingRecordsedit("新增数据", null);
            form.ShowInTaskbar = false;
            form.RefreshEvent += form_RefreshEvent;
            form.ShowDialog();
            return 0;
        }
        public override int Modify()
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择要编辑的行");
                return 0;
            }
            FishEntity.ShippingRecordsEntity entity = dataGridView1.CurrentRow.DataBoundItem as FishEntity.ShippingRecordsEntity;
            if (entity == null)
            {
                MessageBox.Show("请选择需要编辑的行");
                return 0;
            }

            FormShippingRecordsedit inven = new FormShippingRecordsedit("编辑数据", entity);
            inven.RefreshEvent += form_RefreshEvent;
            inven.ShowDialog();

            return 0;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)return;Modify();
        }

        private void txtArrivalUnit_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtArrivalUnit.Text = form.SelectCompany.fullname;
            txtArrivalUnit.Tag = form.SelectCompany.code;
        }
        protected void BindData()
        {
            try
            {
                if (this.DesignMode) return;

                //InitDataUtil.BindComboBoxData(cmbBand, FishEntity.Constant.Brand, true);
                cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
                InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
                cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
                BindCountryBrandData();

            }
            catch { }
        }
        void cmbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (cmbCountry.SelectedValue == null) return;
            string pcode = cmbCountry.SelectedValue.ToString();
            FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) => { return i.code == pcode && i.pcode.Equals(FishEntity.Constant.CountryType); });
            int pid = 0;
            if (pModel != null)
            {
                pid = pModel.id;
            }


            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Brand); });
            if (true)
            {
                if (list == null)
                {
                    list = new List<FishEntity.DictEntity>();
                }
                FishEntity.DictEntity empty = new FishEntity.DictEntity();
                empty.code = string.Empty;
                empty.name = string.Empty;
                list.Insert(0, empty);
            }

            cmbBrand.DisplayMember = "name";
            cmbBrand.ValueMember = "code";
            cmbBrand.DataSource = list;
        }
    }
}
