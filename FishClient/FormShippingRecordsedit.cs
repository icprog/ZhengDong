using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormShippingRecordsedit : FormBase
    {
        FishEntity.ShippingRecordsEntity _entity=null;
        public FormShippingRecordsedit(string title, FishEntity.ShippingRecordsEntity entity)
        {
            InitializeComponent();            
            BindData();
            _entity = entity;
            if (_entity!=null)
            {
                //cmbPort.SelectedValue == null ? string.Empty : cmbPort.SelectedValue.ToString()
                dtppickuptime.Value = _entity.Pickuptime.Value;
                txttonnage.Text = _entity.Tonnage.ToString();
                txtNumberOfPacks.Text = _entity.NumberOfPacks.ToString();
                txtShippingUnit.Text = _entity.ShippingUnit;
                txtArrivalUnit.Text = _entity.ArrivalUnit;
                txtFreight.Text = _entity.Freight;
                txtCarNumber.Text = _entity.CarNumber;
                txtShipName.Text = _entity.ShipName;
                txtBillOfLadingNumber.Text = _entity.BillOfLadingNumber;
                cmbCountry.SelectedValue = _entity.Country.ToString();
                cmbBrand.SelectedValue = _entity.Brand.ToString();
                cmbquality.SelectedValue = _entity.Quality == null ? string.Empty : _entity.Quality.ToString();
                dtpProductionDate.Value = _entity.ProductionDate.Value;
                txtRemarks.Text = _entity.Remarks;
            }
            this.Text = title;
        }
        public event Action<EventArgs> RefreshEvent = null;

        public void ShippingRecordsset()
        {
            decimal temp = 0;
            _entity.Pickuptime= dtppickuptime.Value;
            decimal.TryParse(txttonnage.Text, out temp);
            _entity.Tonnage = temp;
            _entity.NumberOfPacks = int.Parse(txtNumberOfPacks.Text.Trim());
            _entity.ShippingUnit = txtShippingUnit.Text.Trim();
            _entity.ArrivalUnit = txtArrivalUnit.Text.Trim();
            _entity.Freight = txtFreight.Text.Trim();
            _entity.CarNumber = txtCarNumber.Text.Trim();
            _entity.ShipName = txtShipName.Text.Trim();
            _entity.BillOfLadingNumber = txtBillOfLadingNumber.Text.Trim();
            _entity.Country = cmbCountry.SelectedValue == null ? string.Empty : cmbCountry.SelectedValue.ToString(); 
            _entity.Brand = cmbBrand.SelectedValue == null ? string.Empty : cmbBrand.SelectedValue.ToString();
            _entity.Quality = cmbquality.SelectedValue == null ? string.Empty : cmbquality.SelectedValue.ToString();
            _entity.ProductionDate = dtpProductionDate.Value;
            _entity.Remarks = txtRemarks.Text.Trim();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool isAdd = false;
            if (_entity == null)
            {
                _entity = new FishEntity.ShippingRecordsEntity();
                isAdd = true;
            }
            ShippingRecordsset();
            FishBll.Bll.ShippingRecordsBll bll = new FishBll.Bll.ShippingRecordsBll();
            if (_entity.Code != "" && _entity.Code != null)
            {

            }
            else
            {
                _entity.Code = FishBll.Bll.SequenceUtil.GerShippingRecords();
            }
            bool isok = bll.Exists(_entity.Code);
            while (isok)
            {
                _entity.Code = FishBll.Bll.SequenceUtil.GerShippingRecords();
                isok = bll.Exists(_entity.Code);
            }
            if (isAdd)
            {
                _entity.Modifyman = FishEntity.Variable.User.username;
                _entity.Modifytime = DateTime.Now;
                _entity.Createman = _entity.Modifyman;
                _entity.Createtime = DateTime.Now;
                FishBll.Bll.ShippingRecordsBll _bll = new FishBll.Bll.ShippingRecordsBll();
                int id = _bll.add(_entity);
                if (id > 0)
                    OnRefresh();
                MessageBox.Show("添加成功");
            }
            else {
                _entity.Modifyman = FishEntity.Variable.User.username;
                _entity.Modifytime = DateTime.Now;
                FishBll.Bll.ShippingRecordsBll _bll = new FishBll.Bll.ShippingRecordsBll();
                bool isOk = _bll.Update(_entity);
                if (isOk)
                    OnRefresh();
                MessageBox.Show("编辑成功");
            }
            this.Close();
        }
        protected void OnRefresh()
        {
            if (RefreshEvent != null)
            {
                RefreshEvent(EventArgs.Empty);
            }
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
                InitDataUtil.BindComboBoxData(cmbquality, FishEntity.Constant.Specification, true);
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

        private void txtArrivalUnit_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtArrivalUnit.Text = form.SelectCompany.fullname;
            txtArrivalUnit.Tag = form.SelectCompany.code;
        }
    }
}
