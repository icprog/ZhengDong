using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FishClient
{
    public partial class PurchaseRequisitionEdit : FormMenuBase
    {
        FishEntity.PurchaseRequisitionEntity _model = null;
        public PurchaseRequisitionEdit(string title, FishEntity.PurchaseRequisitionEntity model)
        {
            InitializeComponent();
            menuStrip1.Visible = false;
            BindData();
            this.Text = title;
            _model = model;
            if (_model != null)
            {
                //txtContractNo.ReadOnly = true;
                txtContractNo.Text = _model.ContractNo;
                txtNumbering.Text = _model.Numbering;
                txtsupplier.Text = _model.Supplier;
                txtsupplier.Tag = _model.SupplierId;
                txtPurchasingcontacts.Text = _model.Purchasingcontacts;
                txtPurchasingcontacts.Tag = _model.PurchasingcontactsId;
                txtDemandSide.Text = _model.DemandSide;
                txtDemandSide.Tag = _model.DemandSideId;
                dtpDateOfSigni.Value = _model.DateOfSigni.Value;
                dtpdeliverytime.Value = _model.Deliverytime.Value;
                txtPlaceOfSign.Text = _model.PlaceOfSign;
                txtProductName.Text = _model.ProductName;
                txtUnit.Text = _model.Unit;
                txtFishmealId.Text = _model.FishmealId;
                txtOpenbank.Text = _model.Openbank;
                txtaccountnumber.Text = _model.Accountnumber;
                //txtVariety.Text = _model.Variety;
                txtQuantity.Text = _model.Quantity;
                txtNameOfTheShip.Text = _model.NameOfTheShip;
                txtBillOfLadingNumber.Text = _model.BillOfLadingNumber;
                txtDemandSideShort.Text = _model.DemandSideShort;
                txtSupplierAbbreviation.Text = _model.SupplierAbbreviation;
                txtHTprotein.Text = _model.HTprotein;
                txtAsh.Text = _model.Ash;
                txtHTTVB.Text = _model.HTTVB;
                txtHTHistamine.Text = _model.HTHistamine;
                txtHTFFA.Text = _model.HTFFA;
                txtHTFat.Text = _model.HTFat;
                txtHTMoisture.Text = _model.HTMoisture;
                txtHTSandAndSalt.Text = _model.HTSandAndSalt;
                txtHTSand.Text = _model.HTSand;
                txtHTUnit.Text = _model.HTUnit;
                txtHTAsh.Text = _model.HTAsh;
                txtLysine.Text = _model.Lysine;
                txtMethionine.Text = _model.Methionine;
                txtUnitPrice.Text = _model.UnitPrice.ToString();
                txtAmountOfMoney.Text = _model.AmountOfMoney.ToString();
                txtProtein.Text = _model.Protein.ToString();
                txtTVN.Text = _model.TVN.ToString();
                txtHistamine.Text = _model.Histamine.ToString();
                txtFFA.Text = _model.FFA.ToString();
                txtFat.Text = _model.Fat.ToString();
                txtMoisture.Text = _model.Moisture.ToString();
                txtSandAndSalt.Text = _model.SandAndSalt.ToString();
                txtSand.Text = _model.Sand.ToString();
                txtRebate.Text = _model.Rebate.ToString();
                txtUSDollarPrice.Text = _model.USDollarPrice.ToString();
                txtMJAmount.Text = _model.MJAmount;
                cmbSpecification.SelectedValue = _model.Specification == null ? string.Empty : _model.Specification;
                cmbvalidate.SelectedItem = _model.validate == null ? string.Empty : _model.validate;
                cmbCountry.SelectedValue = _model.Country == null ? string.Empty : _model.Country;
                cmbBrand.SelectedValue = _model.Brand == null ? string.Empty : _model.Brand;
                cmbVariety.SelectedValue = _model.Variety == null ? string.Empty : _model.Variety;
                txtTradingLocations.Text = _model.TradingLocations;
                dtpTimeOfShipment.Value = _model.TimeOfShipment.Value;
                dtpExpectedDate.Value = _model.ExpectedDate.Value;
                txtRemarks.Text = _model.Remarks.ToString();
            }
            else {
                //txtContractNo.ReadOnly = false;
                Numbering();
                codeNum();
                cmbvalidate.Text = "有效";
                _model = null;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Check() == false) return;
            bool isAdd = false;
            if (_model == null)
            {
                _model = new FishEntity.PurchaseRequisitionEntity();
                isAdd = true;
            }
            PurchaseRequisition();
            FishBll.Bll.PurchaseRequisitionBll bll = new FishBll.Bll.PurchaseRequisitionBll();
            if (isAdd)
            {
                bool isok = bll.Exists(txtContractNo.Text);
                while (isok)
                {
                    MessageBox.Show("合同编号已存在！");
                    break;
                }
                if (!isok)
                {
                    _model.ContractNo = txtContractNo.Text;
                    _model.Modifyman = FishEntity.Variable.User.username;
                    _model.Modifytime = DateTime.Now;
                    _model.Createman = _model.Modifyman;
                    _model.Createtime = DateTime.Now;
                    FishBll.Bll.PurchaseRequisitionBll _bll = new FishBll.Bll.PurchaseRequisitionBll();
                    int id = _bll.Add(_model);
                    if (id > 0)
                        MessageBox.Show("添加成功！");
                    OnRefresh();
                }
                _model = null;
            }
            else
            {
                _model.ContractNo = txtContractNo.Text;
                _model.Modifyman = FishEntity.Variable.User.username;
                _model.Modifytime = DateTime.Now;
                FishBll.Bll.PurchaseRequisitionBll _bll = new FishBll.Bll.PurchaseRequisitionBll();
                bool isOk = _bll.Update(_model);
                if (isOk)
                    MessageBox.Show("编辑成功");
                OnRefresh();
            }
            //this.Close();
        }
        public event Action<EventArgs> RefreshEvent = null;
        protected void OnRefresh()
        {
            if (RefreshEvent != null)
            {
                RefreshEvent(EventArgs.Empty);
            }
        }
        protected void codeNum()
        {
            _model = new FishEntity.PurchaseRequisitionEntity();
            FishBll.Bll.PurchaseRequisitionBll bll = new FishBll.Bll.PurchaseRequisitionBll();
            DateTime dt = bll.getDate();
            _model.ContractNo = bll.ContractNo();
            if (_model.ContractNo == string.Empty)
                _model.ContractNo = "ZD" + dt.ToString("MMdd") + "0001";
            else
            {
                if (_model.ContractNo.Substring(2, 4) == dt.ToString("MMdd"))
                    _model.ContractNo = "ZD" + (Convert.ToInt64(_model.ContractNo.Substring(2, 8)) + 1).ToString().PadLeft(8, '0');
                else
                    _model.ContractNo = "ZD" + dt.ToString("MMdd") + "0001";
            }
            txtContractNo.Text = _model.ContractNo;
        }
        public string getMax(List<FishEntity.PurchaseRequisitionEntity> strList)
        {
            string maxValue = string.Empty;
            string value = string.Empty;
            string maxStr = string.Empty;
            foreach (FishEntity.PurchaseRequisitionEntity str in strList)
            {
                value = string.Empty;
                foreach (char c in str.Numbering)
                {
                    if (c >= 48 && c <= 57)
                    {
                        value = value + c.ToString();
                    }
                    else
                    {
                        value = value + ((int)c).ToString();
                    }
                }
                if (maxValue == string.Empty)
                {
                    maxValue = value;
                    maxStr = str.Numbering;
                }
                else
                {
                    if (Convert.ToDouble(maxValue) < Convert.ToDouble(value))
                    {
                        maxValue = value;
                        maxStr = str.Numbering;
                    }
                }
            }

            return maxStr;
        }
        protected void Numbering()
        {
            _model = new FishEntity.PurchaseRequisitionEntity();
            List<FishEntity.PurchaseRequisitionEntity> model = new List<FishEntity.PurchaseRequisitionEntity>();
            FishBll.Bll.PurchaseRequisitionBll bll = new FishBll.Bll.PurchaseRequisitionBll();   
            _model.Numbering =bll.code();
            string str = string.Empty;
            int sum = 0;
            if (_model.Numbering == string.Empty)
            {
                str = DateTime.Now.Year.ToString() + "C" + "0001001";
            }
            else {
                    sum = int.Parse(_model.Numbering) + 1000;
                    _model.Numbering = sum.ToString();
                    while (_model.Numbering.Length != 7)
                    {
                        _model.Numbering = "0" + _model.Numbering;
                    }
                    str = DateTime.Now.Year.ToString() + "C" + _model.Numbering;
            }
            txtNumbering.Text = str;
        }
        protected bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            if (string.IsNullOrEmpty(txtContractNo.Text))
            {
                errorProvider1.SetError(txtContractNo, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                errorProvider1.SetError(txtQuantity, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtHTTVB.Text))
            {
                errorProvider1.SetError(txtHTTVB, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtTVN.Text))
            {
                errorProvider1.SetError(txtTVN, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtHTSandAndSalt.Text))
            {
                errorProvider1.SetError(txtHTSandAndSalt, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtAmountOfMoney.Text))
            {
                errorProvider1.SetError(txtAmountOfMoney, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtProtein.Text))
            {
                errorProvider1.SetError(txtProtein, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtTVN.Text))
            {
                errorProvider1.SetError(txtTVN, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtHistamine.Text))
            {
                errorProvider1.SetError(txtHistamine, "不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtsupplier.Text))
            {
                errorProvider1.SetError(txtsupplier, "请选择供方！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtPurchasingcontacts.Text))
            {
                errorProvider1.SetError(txtPurchasingcontacts, "请选择联系人！");
                isok = false;
            }

            if (string.IsNullOrEmpty(txtDemandSide.Text))
            {
                errorProvider1.SetError(txtDemandSide, "请选择需方！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtFishmealId.Text))
            {
                errorProvider1.SetError(txtFishmealId, "鱼粉Id不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtHTprotein.Text))
            {
                errorProvider1.SetError(txtHTprotein, "鱼粉Id不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtPlaceOfSign.Text))
            {
                errorProvider1.SetError(txtPlaceOfSign, "鱼粉Id不能为空！");
            }
            if (string.IsNullOrEmpty(txtHTTVB.Text))
            {
                errorProvider1.SetError(txtHTTVB, "鱼粉Id不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtHTSandAndSalt.Text))
            {
                errorProvider1.SetError(txtHTSandAndSalt, "鱼粉Id不能为空！");
                isok = false;
            }
            if (string.IsNullOrEmpty(txtTradingLocations.Text))
            {
                errorProvider1.SetError(txtTradingLocations, "交货地点不能为空！");
                isok = false;
            }
            if (!string.IsNullOrEmpty(txtUnitPrice.Text) || !string.IsNullOrEmpty(txtUSDollarPrice.Text))
            {
            }
            else
            {
                errorProvider1.SetError(txtUnitPrice, "单价和美金价必填一个！");
                errorProvider1.SetError(txtUSDollarPrice, "单价和美金价必填一个！");
                isok = false;
            }

            return isok;
        }
        public void PurchaseRequisition()
        {
            _model.Supplier = txtsupplier.Text;
            if (txtsupplier.Tag != null)
            {
                _model.SupplierId = txtsupplier.Tag.ToString();
            }
            else {
                _model.SupplierId = string.Empty;
            }
            _model.Purchasingcontacts = txtPurchasingcontacts.Text;
            if (txtPurchasingcontacts.Tag != null)
            {
                _model.PurchasingcontactsId = txtPurchasingcontacts.Tag.ToString();
            }
            else {
                _model.PurchasingcontactsId = string.Empty;
            }

            _model.Numbering = txtNumbering.Text;
            _model.DemandSide = txtDemandSide.Text;
            if (txtDemandSide.Tag != null)
            {
                _model.DemandSideId = txtDemandSide.Tag.ToString();
            }
            else {
                _model.DemandSideId = string.Empty;
            }
            _model.DateOfSigni = dtpDateOfSigni.Value;
            _model.Deliverytime = dtpdeliverytime.Value;
            _model.PlaceOfSign = txtPlaceOfSign.Text;
            _model.ProductName = txtProductName.Text;
            _model.Unit = txtUnit.Text;
            _model.FishmealId = txtFishmealId.Text;
            _model.Openbank = txtOpenbank.Text;
            _model.Accountnumber = txtaccountnumber.Text;
            //_model.Variety = txtVariety.Text;
            _model.Quantity = txtQuantity.Text;
            _model.NameOfTheShip = txtNameOfTheShip.Text;
            _model.BillOfLadingNumber = txtBillOfLadingNumber.Text;
            _model.DemandSideShort = txtDemandSideShort.Text;
            _model.SupplierAbbreviation = txtSupplierAbbreviation.Text;
            _model.HTprotein = txtHTprotein.Text;
            _model.Ash = txtAsh.Text;
            _model.HTTVB = txtHTTVB.Text;
            _model.HTHistamine = txtHTHistamine.Text;
            _model.HTFFA = txtHTFFA.Text;
            _model.HTFat = txtHTFat.Text;
            _model.HTMoisture = txtHTMoisture.Text;
            _model.HTSandAndSalt = txtHTSandAndSalt.Text;
            _model.HTSand = txtHTSand.Text;
            _model.HTUnit = txtHTUnit.Text;
            _model.HTAsh = txtHTAsh.Text;
            _model.Lysine = txtLysine.Text;
            _model.Methionine = txtMethionine.Text;
            _model.UnitPrice = txtUnitPrice.Text;
            _model.AmountOfMoney = txtAmountOfMoney.Text;
            _model.Protein = txtProtein.Text;
            _model.TVN = txtTVN.Text;
            _model.Histamine = txtHistamine.Text;
            _model.FFA = txtFFA.Text;
            _model.Fat = txtFat.Text;
            _model.Moisture = txtMoisture.Text;
            _model.SandAndSalt = txtSandAndSalt.Text;
            _model.Sand = txtSand.Text;
            _model.Rebate = txtRebate.Text;
            _model.USDollarPrice = txtUSDollarPrice.Text;
            _model.MJAmount= txtMJAmount.Text;
            _model.Specification = cmbSpecification.SelectedValue == null ? string.Empty : cmbSpecification.SelectedValue.ToString();
            _model.validate = cmbvalidate.SelectedItem == null ? string.Empty : cmbvalidate.SelectedItem.ToString();
            _model.Country = cmbCountry.SelectedValue == null ? string.Empty : cmbCountry.SelectedValue.ToString();
            _model.Brand = cmbBrand.SelectedValue == null ? string.Empty : cmbBrand.SelectedValue.ToString();
            _model.Variety = cmbVariety.SelectedValue == null ? string.Empty : cmbVariety.SelectedValue.ToString();
            _model.TradingLocations = txtTradingLocations.Text;
            _model.TimeOfShipment = dtpTimeOfShipment.Value;
            _model.ExpectedDate = dtpExpectedDate.Value;
            _model.Remarks = txtRemarks.Text;
        }
        protected void BindData()
        {
            try
            {
                if (this.DesignMode) return;
                cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
                InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
                cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
                InitDataUtil.BindComboBoxData(cmbBrand, FishEntity.Constant.Brand, true);
                InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
                InitDataUtil.BindComboBoxData(cmbVariety, FishEntity.Constant.Goods, true);
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
        private void txtsupplier_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtsupplier.Text = form.SelectCompany.fullname;
            txtsupplier.Tag = form.SelectCompany.code;
            txtSupplierAbbreviation.Text = form.SelectCompany.shortname;
            txtPurchasingcontacts.Text = form.SelectCompany.linkman;
            txtPurchasingcontacts.Tag = form.SelectCompany.linkmancode;
        }

        private void txtDemandSide_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtDemandSide.Text = form.SelectCompany.fullname;
            txtDemandSide.Tag = form.SelectCompany.code;
            txtDemandSideShort.Text = form.SelectCompany.shortname;
        }

        private void txtPurchasingcontacts_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtsupplier.Text) == true)
            {
                MessageBox.Show("请先选择供方单位,再操作。");
                return;
            }
            if (txtsupplier.Tag == null) return;

            int companyId = 0;
            int.TryParse(txtsupplier.Tag.ToString(), out companyId);

            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companyId);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtPurchasingcontacts.Text = customer.name;
                    txtPurchasingcontacts.Tag = customer.code;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSpot_Click(object sender, EventArgs e)
        {
            FormSpot from = new FormSpot();
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (from.fish.saletrader != null && from.fish.saletrader.ToString() != "" && from.fish.salelinkman != null && from.fish.salelinkman.ToString() != "")
            {
                txtFishmealId.Text = from.fish.code;
                txtsupplier.Text = from.fish.saletrader;
                txtPurchasingcontacts.Text = from.fish.salelinkman;
                txtProtein.Text = from.fish.sgs_protein.ToString();
                txtTVN.Text = from.fish.sgs_tvn.ToString();
                txtHistamine.Text = from.fish.sgs_amine.ToString();
                txtFFA.Text = from.fish.sgs_ffa.ToString();
                txtFat.Text = from.fish.sgs_fat.ToString();
                txtMoisture.Text = from.fish.sgs_water.ToString();
                txtSandAndSalt.Text = from.fish.sgs_sandsalt.ToString();
                txtUnit.Text = from.fish.domestic_sour.ToString();
                txtBillOfLadingNumber.Text = from.fish.billofgoods.ToString();
            }
            else {
                MessageBox.Show("往来单位或联系人不能为空！");
            }
        }

        private void btnSelfSale_Click(object sender, EventArgs e)
        {
            FormSelfSale from = new FormSelfSale();
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (from.fish.confirmagent != null && from.fish.confirmagent.ToString() != "" && from.fish.confirmlinkman != null && from.fish.confirmlinkman.ToString() != "")
            {
                txtFishmealId.Text = from.fish.code;
                txtsupplier.Text = from.fish.confirmagent;
                txtPurchasingcontacts.Text = from.fish.confirmlinkman;
                txtProtein.Text = from.fish.sgs_protein.ToString();
                txtTVN.Text = from.fish.sgs_tvn.ToString();
                txtHistamine.Text = from.fish.sgs_amine.ToString();
                txtFFA.Text = from.fish.sgs_ffa.ToString();
                txtFat.Text = from.fish.sgs_fat.ToString();
                txtMoisture.Text = from.fish.sgs_water.ToString();
                txtSandAndSalt.Text = from.fish.sgs_sandsalt.ToString();
                txtUnit.Text = from.fish.domestic_sour.ToString();
                txtBillOfLadingNumber.Text = from.fish.billofgoods;
                txtNameOfTheShip.Text = from.fish.shipno;
            }
            else {
                MessageBox.Show("往来单位或联系人不能为空！");
            }
        }

        private void btnSelfMake_Click(object sender, EventArgs e)
        {
            FormSelfMake from = new FormSelfMake();
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (from.fish.code != null && from.fish.code.ToString() != "")
            {
                txtFishmealId.Text = from.fish.code;
                txtProtein.Text = from.fish.domestic_protein.ToString();
                txtTVN.Text = from.fish.domestic_tvn.ToString();
                txtHistamine.Text = from.fish.domestic_amine.ToString();
                txtUnit.Text = from.fish.domestic_sour.ToString();
                txtBillOfLadingNumber.Text = from.fish.billofgoods;
                txtNameOfTheShip.Text = from.fish.shipno;
            }
            else {
                MessageBox.Show("鱼粉不能为空！");
            }
        }
        public decimal sum(string num1, string num2)
        {
            bool decimalNum1 = Regex.IsMatch(num1, "^[0-9]+([.]{1}[0-9]+){0,1}$");
            bool decimalNum2 = Regex.IsMatch(num2, "^[0-9]+([.]{1}[0-9]+){0,1}$");
            if (decimalNum1 == true && decimalNum2 == true)
            {
                return decimal.Parse(num1.ToString()) * decimal.Parse(num2.ToString());
            }
            else {
                return 0;
            }
            
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "" && txtUnitPrice.Text != "")
            {
                txtAmountOfMoney.Text = sum(txtQuantity.Text, txtUnitPrice.Text).ToString();
            }
        }
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtQuantity.Text != "" && txtUnitPrice.Text != "")
            {
                txtAmountOfMoney.Text = sum(txtQuantity.Text, txtUnitPrice.Text).ToString();
            }
        }
    }
}
