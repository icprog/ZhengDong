using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormEntry : FormMenuBase
    {
        private FishEntity.ProductEntity _fish = null;
        private FishBll.Bll.ProductBll _bll = new FishBll.Bll.ProductBll();
        private FishEntity.ProductExEntity _fishex = null;
        private FishBll.Bll.ProductExBll _bllex = new FishBll.Bll.ProductExBll();
        protected FishEntity.ProductExEntity _entity = null;
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";
        public event EventHandler ClickGBEvent = null;
        private UIForms.FormEntryContion _queryForm = null;
        public FormEntry()
        {
            InitializeComponent();
            BindData();
        }
        public override int Query()
        {
            if (_queryForm == null)
            {
                _queryForm = new UIForms.FormEntryContion();
                _queryForm.StartPosition = FormStartPosition.CenterParent;
                _queryForm.ShowInTaskbar = false;
            }
            if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where = _queryForm.GetWhere();

            return QueryByWhere(_where, _orderBy);
        }

        protected int QueryByWhere(string where, string orderBy)
        {
            List<FishEntity.ProductEntity> list = _bll.Entry_GetModelList(where + orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                _fishex = null;
                return 0;
            }
            else
            {
                _fish = list[0];

                _fishex = _bllex.Entry_GetModel(_fish.id);

                SetFish();
                panel1.Enabled = true;
                return 1;
            }
        }
        protected void SetFish()
        {
            SetFish(_fish);
            SetFishEx(_fishex);
        }
        public override int Add()
        {
            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiAdd.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            panel1.Enabled = true;

            Clearnum1();
            Clearnum2();

            return 1;
        }
        public override void Save()
        {
            _fish = new FishEntity.ProductEntity();
            Getnum1(_fish);
            _fish.createman = FishEntity.Variable.User.username;
            _fish.modifyman = _fish.createman;
            _fish.code = FishBll.Bll.SequenceUtil.GetFishSequence();
            bool isok = _bll.Exists(_fish.code);
            while (isok)
            {
                _fish.code = FishBll.Bll.SequenceUtil.GetFishSequence();
                isok = _bll.Exists(_fish.code);
            }
            int id = _bll.Entry_Add(_fish);
            if (id > 0)
            {
                _fish.id = id;
                SaveEx(id);
                SetFish(_fish);
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiAdd.Visible = false;
                tmiSave.Visible = true;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");

            }
            else
            {
                MessageBox.Show("添加失败。");
            }
        }
        public override int Modify()
        {
            if (_fish == null)
            {
                MessageBox.Show("请查询需要修改的数据。");
                return 0;
            }
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan)
                && false == FishEntity.Variable.User.username.Equals(_fish.createman))
            {
                MessageBox.Show("对不起，您不能修改别人创建的资料！");
                return 0;
            }
            Getnum1(_fish);
            Getnum2(_fishex);
            _fish.modifyman = FishEntity.Variable.User.username;
            _fish.modifytime = DateTime.Now;
            bool isok = _bll.Entry_Update(_fish);
            if (isok)
            {
                _bllex.Entry_Update(_fishex);

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }

            return 1;
        }
        public void SaveEx(int id)
        {
            _fishex = new FishEntity.ProductExEntity();
            Getnum2(_fishex);
            _fishex.id = id;
            _bllex.Entry_Add(_fishex);
            SetFishEx(_fishex);
            ControlButtomRoles();
        }
        public void Getnum1(FishEntity.ProductEntity entity)
        {
            decimal temp2 = 0;
            entity.code = txtCode.Text;
            entity.specification = entity.specification = cmbSpecification.SelectedValue == null ? string.Empty : cmbSpecification.SelectedValue.ToString();
            if (cmbBand.SelectedValue != null)
            {
                entity.brand = cmbBand.SelectedValue.ToString();
            }
            else
            {
                entity.brand = string.Empty;
            }
            entity.nature = cmbCountry.SelectedValue.ToString();
            entity.type = cmbPort.SelectedValue == null ? string.Empty : cmbPort.SelectedValue.ToString();


            decimal.TryParse(txtquote_protein.Text, out temp2);
            entity.quote_protein = temp2;
            decimal.TryParse(txtquote_tvn.Text, out temp2);
            entity.quote_tvn = temp2;
            decimal.TryParse(txtquote_sand.Text, out temp2);
            entity.quote_sand = temp2;
            decimal.TryParse(txtquote_sandsalt.Text, out temp2);
            entity.quote_sandsalt = temp2;
            decimal.TryParse(txtquote_amine.Text, out temp2);
            entity.quote_amine = temp2;
            decimal.TryParse(txtquote_ffa.Text, out temp2);
            entity.quote_ffa = temp2;
            decimal.TryParse(txtquote_fat.Text, out temp2);
            entity.quote_fat = temp2;
            decimal.TryParse(txtquote_water.Text, out temp2);
            entity.quote_water = temp2;

        }
        public void Getnum2(FishEntity.ProductExEntity entity)
        {
            entity.quotedate = dtpquotedate.Text.Trim();
            decimal weight = 0;
            decimal.TryParse(txtquoteweight.Text, out weight);
            entity.quoteweight = weight;
            int quantity = 0;
            int.TryParse(txtquotequantity.Text, out quantity);
            entity.quotequantity = quantity;
            decimal dollars = 0;
            decimal.TryParse(txtquotedollars.Text, out dollars);
            entity.quotedollars = dollars; decimal rmb = 0;
            decimal.TryParse(txtquotermb.Text, out rmb);
            entity.quotermb = rmb; entity.quotesupplier = txtquotesuppliercode.Text.Trim();
            entity.quotesuppliercode = txtquotesuppliercode.Tag == null ? string.Empty : txtquotesuppliercode.Tag.ToString();
            entity.quotelinkman = txtquotelinkman.Text.Trim();
            entity.quotelinkmancode = txtquotelinkman.Tag == null ? string.Empty : txtquotelinkman.Tag.ToString();
            entity.quoteproductyear = txtquoteproductyear.Text.Trim();
            entity.quoteproductdate = txtquoteproductdate.Text.Trim();
            entity.quotelife = txtquotelife.Text.Trim();
            entity.quotesaildatefast = dtpquotesaildatefast.Text.Trim();
            entity.quotesaildatelate = dtpquotesaildatelate.Text.Trim();

        }
        public void SetFish(FishEntity.ProductEntity entity)
        {
            if (entity == null) return;
            txtCode.Text = entity.code;
            cmbSpecification.SelectedValue = entity.specification;
            cmbCountry.SelectedValue = entity.nature;
            cmbBand.SelectedValue = entity.brand;
            cmbPort.SelectedValue = entity.type;
            _fish = entity;

            txtquote_amine.Text = _fish.quote_amine.ToString();
            txtquote_fat.Text = _fish.quote_fat.ToString();
            txtquote_ffa.Text = _fish.quote_ffa.ToString();
            txtquote_protein.Text = _fish.quote_protein.ToString();
            txtquote_sand.Text = _fish.quote_sand.ToString();
            txtquote_sandsalt.Text = _fish.quote_sandsalt.ToString();
            txtquote_tvn.Text = _fish.quote_tvn.ToString();
            txtquote_water.Text = _fish.quote_water.ToString();
        }
        public void SetFishEx(FishEntity.ProductExEntity entity)
        {
            _entity = entity;
            if (_entity == null)
            {
                txtquoteproductyear.Text = string.Empty;
                txtquotedollars.Text = string.Empty;
                txtquotelife.Text = string.Empty;
                txtquotelinkman.Text = string.Empty;
                txtquotelinkman.Tag = string.Empty;
                txtquoteproductdate.Text = string.Empty;
                txtquotequantity.Text = string.Empty;
                txtquotermb.Text = string.Empty;
                //txtquotesaildatefast.Text = string.Empty;
                //txtquotesaildatelate.Text = string.Empty;
                txtquotesuppliercode.Text = string.Empty;
                txtquotesuppliercode.Tag = string.Empty;
                txtquoteweight.Text = string.Empty;

                dtpquotedate.Text = string.Empty;
                dtpquotedate.CustomFormat = " ";
                dtpquotedate.Format = DateTimePickerFormat.Custom;

                dtpquotesaildatefast.Text = string.Empty;
                dtpquotesaildatefast.CustomFormat = " ";
                dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;

                dtpquotesaildatelate.Text = string.Empty;
                dtpquotesaildatelate.CustomFormat = " ";
                dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                txtquoteproductyear.Text = _entity.quoteproductyear;
                txtquotedollars.Text = _entity.quotedollars.HasValue ? _entity.quotedollars.Value.ToString("f2") : "";
                txtquotelife.Text = _entity.quotelife;
                txtquotelinkman.Text = _entity.quotelinkman;
                txtquotelinkman.Tag = _entity.quotelinkmancode;
                txtquoteproductdate.Text = _entity.quoteproductdate;
                txtquotequantity.Text = _entity.quotequantity.HasValue ? _entity.quotequantity.Value.ToString() : "";
                txtquotermb.Text = _entity.quotermb.HasValue ? _entity.quotermb.Value.ToString("f2") : "";
                //txtquotesaildatefast.Text = _entity.quotesaildatefast;
                //txtquotesaildatelate.Text = _entity.quotesaildatelate;
                txtquotesuppliercode.Text = _entity.quotesupplier;
                txtquotesuppliercode.Tag = _entity.quotesuppliercode;
                txtquoteweight.Text = _entity.quoteweight.HasValue ? _entity.quoteweight.Value.ToString("f2") : "";

                if (string.IsNullOrEmpty(_entity.quotedate.Trim()) == false)
                {
                    try
                    {
                        dtpquotedate.CustomFormat = "yyyy.MM.dd";
                        dtpquotedate.Format = DateTimePickerFormat.Custom;
                        dtpquotedate.Text = _entity.quotedate;
                    }
                    catch (Exception ex) { }

                }
                else
                {
                    dtpquotedate.CustomFormat = " ";
                    dtpquotedate.Format = DateTimePickerFormat.Custom;
                }

                if (string.IsNullOrEmpty(_entity.quotesaildatefast.Trim()) == false)
                {
                    dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
                    dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
                    try
                    {
                        dtpquotesaildatefast.Text = _entity.quotesaildatefast;
                    }
                    catch { }
                }
                else
                {
                    dtpquotesaildatefast.Text = string.Empty;
                    dtpquotesaildatefast.CustomFormat = " ";
                    dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
                }

                if (string.IsNullOrEmpty(_entity.quotesaildatelate.Trim()) == false)
                {
                    dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
                    dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
                    try
                    {
                        dtpquotesaildatelate.Text = _entity.quotesaildatelate;
                    }
                    catch { }
                }
                else
                {
                    dtpquotesaildatelate.Text = string.Empty;
                    dtpquotesaildatelate.CustomFormat = " ";
                    dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
                }

            }
        }
        public void Clearnum1()
        {
            cmbSpecification.SelectedValue = string.Empty;
            txtCode.Text = string.Empty;
            cmbBand.SelectedValue = string.Empty;
            cmbCountry.SelectedValue = string.Empty;
            cmbPort.SelectedValue = string.Empty;

            txtquote_protein.Text = string.Empty;
            txtquote_tvn.Text = string.Empty;
            txtquote_sand.Text = string.Empty;
            txtquote_sandsalt.Text = string.Empty;
            txtquote_amine.Text = string.Empty;
            txtquote_ffa.Text = string.Empty;
            txtquote_fat.Text = string.Empty;
            txtquote_water.Text = string.Empty;
        }
        public void Clearnum2() {
            dtpquotedate.Format = DateTimePickerFormat.Custom;
            dtpquotedate.CustomFormat = " ";
            txtquoteweight.Text = string.Empty;
            txtquotequantity.Text = string.Empty;
            txtquotedollars.Text = string.Empty;
            txtquotermb.Text = string.Empty;
            txtquotesuppliercode.Text = string.Empty;
            txtquotesuppliercode.Tag = string.Empty;
            txtquotelinkman.Text = string.Empty;
            txtquotelinkman.Tag = string.Empty;
            txtquoteproductyear.Text = string.Empty;
            txtquoteproductdate.Text = string.Empty;
            txtquotelife.Text = string.Empty;
            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatefast.CustomFormat = " ";
            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatelate.CustomFormat = " ";
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
                InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
                BindCountryBrandData();

                InitDataUtil.BindComboBoxData(cmbPort, FishEntity.Constant.port, true);

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
                    list = new List<FishEntity.DictEntity> ();
                }
                FishEntity.DictEntity empty = new FishEntity.DictEntity();
                empty.code = string.Empty;
                empty.name = string.Empty;
                list.Insert(0, empty);
            }

            cmbBand.DisplayMember = "name";
            cmbBand.ValueMember = "code";
            cmbBand.DataSource = list;
        }

        private void txtquotesuppliercode_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtquotesuppliercode.Text = form.SelectCompany.fullname;
            txtquotesuppliercode.Tag = form.SelectCompany.code;

            txtquotelinkman.Text = string.Empty;
            txtquotelinkman.Tag = string.Empty;
        }

        private void txtquotelinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtquotesuppliercode.Text) == true)
            {
                MessageBox.Show("请先选择供应商,再操作。");
                return;
            }
            if (txtquotesuppliercode.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtquotesuppliercode.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtquotelinkman.Text = customer.name;
                    txtquotelinkman.Tag = customer.code;
                }
            }
        }
        public override void Cancel()
        {
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            panel1.Enabled = true;
        }

        private void dtpquotedate_ValueChanged(object sender, EventArgs e)
        {
            dtpquotedate.CustomFormat = "yyyy.MM.dd";
            dtpquotedate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpquotesaildatefast_ValueChanged(object sender, EventArgs e)
        {
            dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
        }

        private void dtpquotesaildatelate_ValueChanged(object sender, EventArgs e)
        {
            dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
        }
    }
}
