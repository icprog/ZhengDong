using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FishEntity;

namespace FishClient
{
    public partial class FormCompany : FormMenuBase
    {
        FishBll.Bll.CompanyBll _bll = new FishBll.Bll.CompanyBll();
        FishBll.Bll.CustomerBll _customerBll = new FishBll.Bll.CustomerBll();
        FishBll.Bll.QuoteProductBll _quoteBll = new FishBll.Bll.QuoteProductBll();
        FishEntity.CompanyEntity _company = null;
        List<FishEntity.QuoteProductEntity> _quoteList = null;
        FormImage _formImage = null;
        string _where = string.Empty;
        string _rolewhere = string.Empty;
        string _orderBy = " order by id asc limit 1";

        public FormCompany()
        {
            InitializeComponent();
            menuStrip1.Items.Remove(tmiprint);
            menuStrip1.Items.Remove(tmiReview);
            ReadColumnConfig(dataGridView1, "Set_CompanyList_1");
            //pnlTop.Enabled = pnlCompany.Enabled = pnlBotton.Enabled = pnlBPS.Enabled=  false;
            pnlAll.Enabled = false;//
            AddMenuItem();
            InitData();
        }

        public FormCompany(int id)
        {
            InitializeComponent();
            menuStrip1.Items.Remove(tmiReview);
            menuStrip1.Items.Remove(tmiprint);
            AddMenuItem();
            InitData();

            _where = "id=" + id ;
            QueryByWhere();
        }
        public FormCompany(string code)
        {
            InitializeComponent();
            menuStrip1.Items.Remove(tmiReview);
            menuStrip1.Items.Remove(tmiprint);
            AddMenuItem();
            InitData();

            _where = "code='" + code+"' ";
            QueryByWhere();
        }
        protected void AddMenuItem()
        {            
            tmiDelete.Visible = false;//
            tmiExport.Visible = false;//
            tmiSave.Visible = false;//
            tmiCancel.Visible = false;  //
        }

        protected void InitData()
        {
            BindCheckBoxComboBoxData( FishEntity.Constant.Type);
            BindCheckBoxComboBoxDatacmbproducts1(FishEntity.Constant.Products);

            BindSpecificationComboxData(FishEntity.Constant.RequiredProduct);

            InitDataUtil.BindComboBoxData(cmbGenerallevel, FishEntity.Constant.GeneralLevel,true );

            InitDataUtil.BindComboBoxData(cmbactivelevel, FishEntity.Constant.ActiveLevel, true);

            InitDataUtil.BindComboBoxData(cmbCreditlevel, FishEntity.Constant.CreditLevel, true);

            InitDataUtil.BindComboBoxData(cmbrequiredlevel, FishEntity.Constant.RequiredLevel, true);

            InitDataUtil.BindComboBoxData(cmbloyalty, FishEntity.Constant.Loyalty, true);

            //InitDataUtil.BindComboBoxData(cmbproducts, FishEntity.Constant.Products, true);

            InitDataUtil.BindComboBoxData(cmbManageSpecificate, FishEntity.Constant.ManageSpecificateDegree, true);

            InitDataUtil.BindComboBoxData(cmbmanageprojects, FishEntity.Constant.ManageProjects, true);

            //cmbNature.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            //InitDataUtil.BindComboBoxData(cmbNature, FishEntity.Constant.CountryType, true);
            //cmbNature.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            //BindCountryBrandData();

            InitDataUtil.BindComboBoxData(cmbNature, FishEntity.Constant.CompanyNature, true);

            InitDataUtil.BindComboBoxData(cmbCustomerProperty, FishEntity.Constant.CustomerProperty, true);

            InitDataUtil.BindComboBoxData(cmbPaymethod, FishEntity.Constant.Paymethod, true);
            //InitDataUtil.BindComboBoxData(cmbRequirdProduct, FishEntity.Constant.RequiredProduct, true);

            InitDataUtil.BindComboBoxData(cmbhzrs, FishEntity.Constant.Cooperation, true);

            cmbProvince.SelectedValueChanged -= cmbProvince_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbProvince, FishEntity.Constant.Province, true);
            cmbProvince.SelectedValueChanged+=cmbProvince_SelectedValueChanged;

            BindNature();
            BindBrand();

            BindAreaData(); 

            cmbValidate.Text = "有效";

            cmbType.DropDownHeight = 170;
            cmbproducts1.DropDownHeight = 170;

            ///<summary >
            ///权限管理
            /// </summary>
            
            //if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            //{
            //    _rolewhere = string.Format(" and salesmancode='{0}' ", FishEntity.Variable.User.id);
            //}
            //else
            //{
            //    _rolewhere = string.Empty;
            //}
        }
        void cmbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (cmbNature.SelectedValue == null) return;
            string pcode = cmbNature.SelectedValue.ToString();
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
                    list = new List<DictEntity>();
                }
                DictEntity empty = new DictEntity();
                empty.code = string.Empty;
                empty.name = string.Empty;
                list.Insert(0, empty);
            }

            brandcol.DisplayMember = "name";
            brandcol.ValueMember = "code";
            brandcol.DataSource = list;
        }
        void cmbProvince_SelectedValueChanged(object sender, EventArgs e)
        {         
            BindAreaData();
        }

        private void BindAreaData(  )
        {
            //cmbArea.DataSource = null;
            if (cmbProvince.SelectedValue == null) return;
            string pcode = cmbProvince.SelectedValue.ToString();
            FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) => { return i.code == pcode && i.pcode.Equals(FishEntity.Constant.Province); });
            int pid = 0;
            if (pModel != null)
            {
                pid = pModel.id;
            }


            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Area); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.code = "";
            empty.name = "";
            list.Insert(0, empty);


            cmbArea.ValueMember = "code";
            cmbArea.DisplayMember = "name";
            cmbArea.DataSource = list;

        }

        protected void BindCheckBoxComboBoxData(string key)
        {
            cmbType.Click += cmbType_Click;
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(key); });
            UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity> listWraper = new UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity>(list, "name");
            cmbType.DataSource = listWraper;
            cmbType.DisplayMember = "nameConcatenated";
            cmbType.DisplayMemberSingleItem = "name";
            cmbType.ValueMember = "Selected";

        }
        protected void BindCheckBoxComboBoxDatacmbproducts1(string key)
        {
            cmbproducts1.Click += cmbproducts1_Click;
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(key); });
            UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity> listWraper = new UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity>(list, "name");
            cmbproducts1.DataSource = listWraper;
            cmbproducts1.DisplayMember = "nameConcatenated";
            cmbproducts1.DisplayMemberSingleItem = "name";
            cmbproducts1.ValueMember = "Selected";

        }
        //cmbproducts1
        protected void BindSpecificationComboxData( string key )
        {
            cmbSpecification.Click += cmbSpecification_Click;
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i)=>{return i.pcode.Equals(key);});
            UILibrary.CheckBoxComboBox.ListSelectionWrapper<FishEntity.DictEntity> listWrapper = new UILibrary.CheckBoxComboBox.ListSelectionWrapper<DictEntity>(list, "name");
            cmbSpecification.DataSource = listWrapper;
            cmbSpecification.DisplayMember = "nameConcatenated";
            cmbSpecification.DisplayMemberSingleItem = "name";
            cmbSpecification.ValueMember = "Selected";

        }

        protected void BindNature()
        {
            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.CountryType); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            naturecol.DataSource = list;
            naturecol.DisplayMember = "name";
            naturecol.ValueMember = "code";
        }

        protected void BindBrand()
        {

            List<DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Brand); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);
            brandcol.DataSource = list;
            brandcol.DisplayMember = "name";
            brandcol.ValueMember = "code";


        }
        
        void cmbSpecification_Click(object sender, EventArgs e)
        {
            cmbSpecification.Focus();
        }

        void cmbType_Click(object sender, EventArgs e)
        {
            cmbType.Focus();
        }
        //cmbproducts1
        void cmbproducts1_Click(object sender, EventArgs e)
        {
            cmbproducts1.Focus();
        }
        public override void Next()
        {
            QueryOne(" > ", " order by id asc limit 1");
        }

        public override void Previous()
        {
            QueryOne(" < ", " order by id desc limit 1");
        }

        protected void QueryOne(string operate, string orderBy)
        {
            errorProvider1.Clear();
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if ( _company != null)
            {
                whereEx += " and code " + operate + _company.code;
            }

            List<FishEntity.CompanyEntity> list = _bll.GetModelList(whereEx + _rolewhere + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _company = list[0];
            _formImage = null;

            SetCompany();
            SetCustomer();
            SetQuote();
        }

        protected void SetQuote()
        {
            int companyId = _company.id;
           _quoteList  = _quoteBll.GetModelList("companyid="+ companyId);
           if (_quoteList == null || _quoteList.Count < 1)
           {
               InitQuote();
           }
           else
           {
               dataGridView2.AutoGenerateColumns = false;
               dataGridView2.DataSource = _quoteList;
           }
        }
        
        private void FormCompanyList_Load(object sender, EventArgs e)
        {
            //AddMenuItem();

            //InitData();
            menuStrip1.Visible = true;
            tmiAdd.Visible = true;
            tmiDelete.Visible = false;
            tmiModify.Visible = true;
            tmiExport.Visible = false;
            tmiNext.Visible = true;
            tmiPrevious.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            pnlHDS.Height = 55;

            pnlBPS.Height = 180;
            dataGridView2.Height = 175; 
            pnlBotton.Height = 180;
        }

        public override int Query()
        {
            FormCondition form = new FormCondition();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where = form.GetWhereCondition;

            QueryByWhere();

            return 1;
        }

        protected void QueryByWhere()
        {
            List<FishEntity.CompanyEntity> list = _bll.GetModelList(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _company = null;
                MessageBox.Show("查无记录。");
            }
            else
            {
                _company = list[0];
                SetCompany();
                SetCustomer();
                SetQuote();
            }
            //
        }

        protected void SetSpecification()
        {  
            cmbSpecification.ClearSelection();

            string[] specifications = null;
            List<string> list = new List<string>();
            if (_company != null && _company.requiredproduct != null)
            {
                specifications = _company.requiredproduct.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                list = new List<string>(specifications);
            }           

            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbSpecification.CheckBoxItems)
            {
                UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity> kvWrapper = (UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem;
                bool isExist = list.Exists((i) => { return i.Equals(kvWrapper.Item.code); });
               if( isExist )
               {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
            }
        }

        protected void SetCompany()
        {
            //pnlTop.Enabled = pnlCompany.Enabled = pnlBotton.Enabled = true;
            pnlAll.Enabled = true;

            txtcode.Text = _company.code;

            SetSpecification();

            cmbType.ClearSelection();
            cmbproducts1.ClearSelection();
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbproducts1.CheckBoxItems)
            {
                UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity> kvWrapper = (UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem;
                if (kvWrapper.Item.code.Equals("鱼料") && _company.Fishmaterial == "1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("虾料") && _company.Shrimpmaterial == "1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("禽料") && _company.Poultrymaterial=="1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("特种") && _company.Special=="1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("特水") && _company.Specialwater=="1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                
            }
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbType.CheckBoxItems)
            {
                UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity> kvWrapper = (UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem;
                if (kvWrapper.Item.code.Equals("供应商") && _company.type_suppliers == "1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("代理商") && _company.type_agents == "1")
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("客户") && _company.type_customer.Equals("1"))
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("贸易商") && _company.type_merchants.Equals("1"))
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("货代商") && _company.type_goods.Equals("1"))
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }

                if (kvWrapper.Item.code.Equals("报盘商") && _company.type_quote.Equals("1"))
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else
                {
                    //kvWrapper.Selected = false;
                    //item.Checked = false;
                }
                if (kvWrapper.Item.code.Equals("物流运输") &&_company.Logistics.Equals("1"))
                {
                    kvWrapper.Selected = true;
                    item.Checked = true;
                }
                else { }
            }

            txtfullname.Text = _company.fullname;
            txtShortName.Text = _company.shortname;
            cmbGenerallevel.SelectedValue = _company.generallevel;
            cmbCreditlevel.SelectedValue = _company.creditlevel;
            cmbrequiredlevel.SelectedValue = _company.requiredlevel;
            cmbManageSpecificate.SelectedValue = _company.managestandard;
            cmbactivelevel.SelectedValue = _company.activelevel;
            cmbloyalty.SelectedValue = _company.loyalty;
            //cmbproducts.SelectedValue = _company.products;
            txtsalesman.Text = _company.salesman;
            txtsalesman.Tag = _company.salesmancode;
            txtarea.Text = _company.area;
            txtaddress.Text = _company.address;
            cmbNature.SelectedValue = _company.nature;
            cmbmanageprojects.SelectedValue = _company.manageprojects;
            txtregistermoney.Text = _company.registermoney;
            dtpRegisterTime.Value = _company.registertime.Value;
            txtpersonnum.Text = _company.personnumber.ToString();
            txtfox.Text = _company.fox;
            txtzip.Text = _company.zipcode;
            txtwebsite.Text = _company.website;
            txtlinkman.Text = _company.linkman;
            txtlinkman.Tag = _company.linkmancode;
            txtcurrentlink.Text = _company.currentlink;
            txtcurrentmonthestimate.Text = _company.currentmonthestimate;
            txtcurrentweekestimate.Text = _company.currentweekestimate;
            dtpnextlinkdate.Value = _company.nextlinkdate.Value;
            ckbFature.Checked = _company.fatures == 1 ? true : false;

            txtbank.Text = _company.bank;
            txtaccount.Text = _company.account;
            txtEstimateBuyDate.Text = _company.estimatepurchasetime;
            txtCustomerGroup.Text = _company.customergroup;
            cmbCustomerProperty.SelectedValue = _company.customerproperty;

            txtdescription.Text = _company.description;

            cmbValidate.Text = _company.validate.Equals(1) ? "有效" : "无效";

            txtmodifyman.Text = _company.modifyman;
            txtcreateman.Text = _company.createman;
            txtmodifytime.Text = _company.modifytime.ToString();

            cmbPaymethod.SelectedValue = _company.paymethod;
            //cmbRequirdProduct.SelectedValue = _company.requiredproduct;
            txtRequire.Text = _company.productrequire;
            txtCashDeposit.Text = _company.cashdeposit;
            txtCompositor.Text = _company.competitors;

            cmbProvince.SelectedValue = _company.province;
            //txtZone.Text = _company.zone;
            cmbhzrs.SelectedValue = _company.cooperation;
            txtRegister.Text = _company.registerman;
            txtFreight.Text = _company.freight.ToString();
            txtTare.Text = _company.tare.ToString();

            cmbArea.SelectedValue = _company.zone;

            txtYearProduct.Text = _company.yearproduct;
            txtYearSales.Text = _company.yearSale;
            txtProductGoods.Text = _company.productgoods;
            txtSupportProduct.Text = _company.supportproduct;
            txtYearSupport.Text = _company.yearsupport;

            txtCashDate.Text = _company.cashdate;
            string cashmethod = _company.cashmethod;
            string[] items = cashmethod.Split( new char[]{ ','} ,  StringSplitOptions.RemoveEmptyEntries);
            chkTT.Checked = chkJJ.Checked = chkYJ.Checked = false;
            if( items !=null && items.Length>0)
            {
                foreach( String i in items){
                    if (i.Equals("1"))
                    {
                        chkTT.Checked = true;
                    }
                    else if (i.Equals("2"))
                    {
                        chkJJ.Checked = true;
                    }
                    else if (i.Equals("3"))
                    {
                        chkYJ.Checked = true;
                    }
                }
            }

            txtAgentRate.Text = _company.agentfeerate;
            txtIssueRate.Text = _company.issuingfeerate;
            txtBillPeriod.Text = _company.billperiod.ToString();
            txtPassRate.Text = _company.passfeerate;

            txtDay1.Text = _company.storageday1;
            txtDay2.Text = _company.storageday2;
            txtDay3.Text = _company.storageday3;
            txtDay4.Text = _company.storageday4;
            txtDay5.Text = _company.storageday5;
            txtPrice1.Text = _company.storagefee1.HasValue? _company.storagefee1.Value.ToString():"";
            txtPrice2.Text =_company.storagefee2.HasValue? _company.storagefee2.Value.ToString():"";
            txtPrice3.Text = _company.storagefee3.HasValue? _company.storagefee3.Value.ToString():"";
            txtPrice4.Text = _company.storagefee4.HasValue? _company.storagefee4.Value.ToString():"";
            txtPrice5.Text = _company.storagefee5.HasValue? _company.storagefee5.Value.ToString():"";

            txtFee1.Text = _company.freight1.HasValue? _company.freight1.Value.ToString():"";
            txtFee2.Text =_company.freight2.HasValue? _company.freight2.Value.ToString():"";
            txtFee3.Text =_company.freight3.HasValue? _company.freight3.Value.ToString():"";
            txtFee4.Text = _company.freight4.HasValue? _company.freight4.Value.ToString():"";
            txtFee5.Text =_company.freight5.HasValue? _company.freight5.Value.ToString():"";
            txtFee6.Text =_company.freight6.HasValue? _company.freight6.Value.ToString():"";

            txtPayDay.Text = _company.paydays.HasValue?  _company.paydays.ToString() :"";
            txtRequireGoods.Text = _company.requiregoods;
        }

        protected void SetCustomer()
        {
            int companyId = _company.id;
            List<CustomerEntity> customers = _customerBll.GetCustomerOfCompany(companyId);
            SetCustomer(customers);
        }

        protected void SetCustomer(List<CustomerEntity> customers)
        {
            dataGridView1.Rows.Clear();
            if (customers == null || customers.Count < 1) return; 
            foreach (CustomerEntity item in customers)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["id"].Value = item.id;
                row.Cells["code"].Value = item.code;
                row.Cells["name"].Value = item.name;
                row.Cells["telephone"].Value = item.telephone;
                row.Cells["phone1"].Value = item.phone1;
                row.Cells["phone2"].Value = item.phone2;
                row.Cells["phone3"].Value = item.phone3;
                row.Cells["qq"].Value = item.qq;
                row.Cells["weixin"].Value = item.weixin;
                row.Cells["email"].Value = item.email;
                row.Cells["remark"].Value = item.remark;
                row.Cells["flag"].Value = item.flag == 1 ? true : false;
                row.Cells["post"].Value = item.post;
                row.Cells["department1"].Value = item.Department1;
                row.Cells["officeaddress"].Value = item.officeaddress;
                row.Cells["fox"].Value = item.fox;
                row.Cells["sex"].Value = item.sex;
            } 
        }

        protected bool Check()
        {
            bool isOk = true;
            errorProvider1.Clear();
            cmbType.HideDropDown();
            cmbproducts1.HideDropDown();
            string fullname = txtfullname.Text.Trim();
            if (string.IsNullOrEmpty(fullname))
            {
                errorProvider1.SetError(txtfullname, "请填写公司全称");
                isOk = false;
            }

            string shortname = txtShortName.Text.Trim();
            if (string.IsNullOrEmpty(shortname))
            {
                errorProvider1.SetError(txtShortName, "请填写公司简称");
                isOk = false;
            }

            string types = string.Empty;
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbType.CheckBoxItems)
            {
                if (string.IsNullOrEmpty(types) == false) types += ",";
                if (item.Checked) types += ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item.code;
            }
            string types1 = string.Empty;
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbproducts1.CheckBoxItems)
            {
                if (string.IsNullOrEmpty(types1) == false) types1 += ",";
                if (item.Checked) types1 += ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item.code;
            }
            if (string.IsNullOrEmpty(types))
            {
                errorProvider1.SetError(cmbType, "请选择往来单位类型");
                isOk = false;
            }

            if (cmbValidate.Text == null || cmbValidate.Text =="")
            {
                errorProvider1.SetError(cmbValidate, "请选择有效性");
                isOk = false;
            }          

            return isOk;
        }

        public override int Add()
        {
            //pnlTop.Enabled = pnlCompany.Enabled = pnlBotton.Enabled = true;
            pnlAll.Enabled = true;

            errorProvider1.Clear();
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;

            _company = null;

            txtaccount.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtarea.Text = string.Empty;
            txtbank.Text = string.Empty;
            txtcode.Text = string.Empty;
            txtcreateman.Text = string.Empty;
            txtcurrentlink.Text = string.Empty;
            txtcurrentmonthestimate.Text = string.Empty;
            txtcurrentweekestimate.Text = string.Empty;
            txtCustomerGroup.Text = string.Empty;
            txtdescription.Text = string.Empty;
            txtEstimateBuyDate.Text = string.Empty;
            txtfox.Text = string.Empty;
            txtfullname.Text = string.Empty;
            txtlinkman.Text = string.Empty;
            txtmodifyman.Text = string.Empty;
            txtmodifytime.Text = string.Empty;
            txtpersonnum.Text = string.Empty;
            txtregistermoney.Text = string.Empty;
            txtsalesman.Text = FishEntity.Variable.User.realname;
            txtsalesman.Tag = FishEntity.Variable.User.id;
            txtShortName.Text = string.Empty;
            txtthreecard.Text = string.Empty;
            txtwebsite.Text = string.Empty;
            txtzip.Text = string.Empty;
            dtpnextlinkdate.Value = DateTime.Now;
            dtpRegisterTime.Value = DateTime.Now;
            cmbactivelevel.SelectedValue = string.Empty;
            cmbCreditlevel.SelectedValue = string.Empty;
            cmbCustomerProperty.SelectedValue = string.Empty;
            cmbGenerallevel.SelectedValue = string.Empty;
            cmbloyalty.SelectedValue = string.Empty;
            cmbmanageprojects.SelectedValue = string.Empty;
            cmbManageSpecificate.SelectedValue = string.Empty;
            cmbNature.SelectedValue = string.Empty;
            //cmbproducts.SelectedValue = string.Empty;
            cmbrequiredlevel.SelectedValue = string.Empty;
            cmbType.HideDropDown();
            cmbType.ClearSelection();
            cmbproducts1.HideDropDown();
            cmbproducts1.ClearSelection();
            cmbValidate.SelectedValue = "有效";
            ckbFature.Checked = false;
            cmbPaymethod.SelectedValue = string.Empty;
            //cmbRequirdProduct.SelectedValue = string.Empty;
            txtCashDeposit.Text = string.Empty;
            txtCompositor.Text = string.Empty;

            //cmbproducts.SelectedValue = string.Empty;
            //txtZone.Text = string.Empty;
            txtRegister.Text = string.Empty;
            cmbhzrs.SelectedValue = string.Empty;
            txtFreight.Text = "0.00";
            txtTare.Text = "0.00";
            txtRequire.Text = string.Empty;


            txtYearSales.Text = string.Empty;
            txtYearSupport.Text = string.Empty;
            txtYearProduct.Text = string.Empty;
            txtSupportProduct.Text = string.Empty;
            txtProductGoods.Text = string.Empty;
            txtCashDate.Text = string.Empty;
            chkTT.Checked = false;
            chkJJ.Checked = false;
            chkYJ.Checked = false;
            txtAgentRate.Text = string.Empty;
            txtIssueRate.Text = string.Empty;
            txtBillPeriod.Text = string.Empty;
            txtPassRate.Text = string.Empty;

            txtDay1.Text = txtDay2.Text = txtDay3.Text = txtDay4.Text = txtDay5.Text = "";
            txtPrice1.Text = txtPrice2.Text = txtPrice3.Text = txtPrice4.Text = txtPrice5.Text = "";
            txtFee1.Text = txtFee2.Text = txtFee3.Text = txtFee4.Text = txtFee5.Text = txtFee6.Text = "";

            dataGridView1.Rows.Clear();

            InitQuote();

            _formImage = null;

            return 1;
        }

        public override void Save()
        {
            if (Check() == false) return ;

            string fullname = txtfullname.Text.Trim();
            if (_bll.ExistsByFullName(fullname))
            {
                errorProvider1.SetError(txtfullname, "公司全称重复，无法保存。");               
                return;
            }

            int id = AddCompany();

            if (id > 0)
            {
                _company.id = id;
                txtcode.Text = _company.code;

                AddImages(_company);

                AddCustomer(_company.id, _company.code, true);

                AddQuote(_company.id, true);

                this.ControlButtomRoles();

                MessageBox.Show("添加成功。");

            }
            else
            {
                MessageBox.Show("添加失败。");
            }
            
        }

        public override void Cancel()
        {
            errorProvider1.Clear();
           
            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;

            ControlButtomRoles();

            //pnlTop.Enabled = pnlCompany.Enabled = pnlBotton.Enabled = false;
            pnlAll.Enabled = false;
        }

        protected string GetSpecification()
        {
            string specification = "";

            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbSpecification.CheckBoxItems)
            {
                if (item.Checked)
                {
                    FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;
                    if (string.IsNullOrEmpty(specification) == false)
                    {
                        specification += ",";
                    }
                    specification += kv.code;                  
                }
            }

            return specification;
        }

        protected int AddCompany()
        {
            _company = new FishEntity.CompanyEntity();
            _company.activelevel = cmbactivelevel.SelectedValue.ToString();
            _company.address = txtaddress.Text.Trim();
            _company.area = txtarea.Text.Trim();

            _company.createman = FishEntity.Variable.User.username;
            _company.createtime = DateTime.Now;
            _company.creditlevel = cmbCreditlevel.SelectedValue.ToString();
            _company.currentlink = txtcurrentlink.Text.Trim();
            _company.currentmonthestimate = txtcurrentmonthestimate.Text.Trim();
            _company.currentweekestimate = txtcurrentweekestimate.Text.Trim();
            _company.description = txtdescription.Text.Trim();
            _company.fox = txtfox.Text.Trim();
            _company.fullname = txtfullname.Text.Trim();
            _company.generallevel = cmbGenerallevel.SelectedValue.ToString();
            _company.isdelete = 0;
            if (txtlinkman.Tag != null)
            {
                _company.linkmancode = txtlinkman.Tag.ToString();
                _company.linkman = txtlinkman.Text.Trim();
            }
            _company.loyalty = cmbloyalty.SelectedValue.ToString();
            _company.manageprojects = cmbmanageprojects.SelectedValue.ToString();
            _company.managestandard = cmbManageSpecificate.SelectedValue.ToString();
            _company.modifyman = _company.createman;
            _company.modifytime = _company.createtime;
            _company.nature = cmbNature.SelectedValue.ToString();
            _company.nextlinkdate = dtpnextlinkdate.Value;
            int number = 0;
            int.TryParse(txtpersonnum.Text, out number);
            _company.personnumber = number;
            //_company.products = cmbproducts.SelectedValue.ToString();
            _company.registermoney = txtregistermoney.Text.Trim();
            _company.registertime = dtpRegisterTime.Value;
            _company.requiredlevel = cmbrequiredlevel.SelectedValue.ToString();
            if (txtsalesman.Tag != null)
            {
                _company.salesmancode = txtsalesman.Tag.ToString();
                _company.salesman = txtsalesman.Text.Trim();
            }
            _company.shortname = txtShortName.Text.Trim();
            _company.type = cmbType.Text.Trim();
            _company.products = cmbproducts1.Text.Trim();
            _company.validate = cmbValidate.Text.Equals("有效") ? 1 : 0;
            _company.website = txtwebsite.Text.Trim();
            _company.zipcode = txtzip.Text.Trim();
            _company.fatures = ckbFature.Checked ? 1 : 0;
            _company.bank = txtbank.Text.Trim();
            _company.account = txtaccount.Text.Trim();
            _company.estimatepurchasetime = txtEstimateBuyDate.Text.Trim();
            _company.customerproperty = cmbCustomerProperty.SelectedValue.ToString();
            _company.customergroup = txtCustomerGroup.Text.Trim();
            _company.paymethod = cmbPaymethod.SelectedValue.ToString();
            //_company.requiredproduct = cmbRequirdProduct.SelectedValue.ToString();
            _company.cashdeposit = txtCashDeposit.Text.Trim();
            _company.competitors = txtCompositor.Text.Trim();

            _company.type_suppliers = "0";
            _company.type_agents = "0";
            _company.type_customer = "0";
            _company.type_merchants = "0";
            _company.type_goods = "0";
            _company.type_quote = "0";
            _company.Logistics = "0";
            _company.Fishmaterial = "0";
            _company.Shrimpmaterial = "0";
            _company.Poultrymaterial = "0";
            _company.Special = "0";
            _company.Specialwater = "0";

            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbType.CheckBoxItems)
            {
                if (item.Checked)
                {
                    FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;

                    if (kv.code.Equals("供应商")) { _company.type_suppliers = "1"; continue; }
                    if (kv.code.Equals("代理商")) { _company.type_agents = "1" ;continue ;}
                    if (kv.code.Equals("客户")) { _company.type_customer = "1"; continue; }
                    if (kv.code.Equals("贸易商")) { _company.type_merchants = "1"; continue; }
                    if (kv.code.Equals("货代商")) { _company.type_goods = "1"; continue; }
                    if (kv.code.Equals("报盘商")) { _company.type_quote = "1"; continue; }
                    if (kv.code.Equals("物流运输")){ _company.Logistics = "1";continue; }
                }
            }
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbproducts1.CheckBoxItems)
            {
                if (item.Checked)
                {
                    FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;

                    if (kv.code.Equals("鱼料")) { _company.Fishmaterial= "1"; continue; }
                    if (kv.code.Equals("虾料")) { _company.Shrimpmaterial = "1"; continue; }
                    if (kv.code.Equals("禽料")) { _company.Poultrymaterial = "1"; continue; }
                    if (kv.code.Equals("特种")) { _company.Special = "1"; continue; }
                    if (kv.code.Equals("特水")) { _company.Specialwater = "1"; continue; }
                }
            }

           _company .requiredproduct = GetSpecification();

            _company.province = cmbProvince.SelectedValue.ToString();
            //_company.zone = txtZone.Text.Trim();
            if (cmbArea.SelectedValue != null)
            {
                _company.zone = cmbArea.SelectedValue.ToString();
            }

            _company.productrequire = txtRequire.Text.Trim();
            decimal temp = 0;
            decimal.TryParse(txtFreight.Text, out temp);
            _company.freight = temp;
            decimal.TryParse(txtTare.Text, out temp);
            _company.tare = temp;
            _company.registerman = txtRegister.Text.Trim();
            _company.cooperation = cmbhzrs.SelectedValue.ToString();

            _company.code = FishBll.Bll.SequenceUtil.GetCompnaySequence(); 
            while(_bll.Exists ( _company.code ))//单位
            {
                _company.code = FishBll.Bll.SequenceUtil.GetCompnaySequence ();
            }

            //--------------------
            _company.yearSale = txtYearSales.Text.Trim();
            _company.productgoods = txtProductGoods.Text.Trim();
            _company.yearproduct = txtYearProduct.Text.Trim();
            _company.supportproduct = txtSupportProduct.Text.Trim();
            _company.yearsupport = txtYearSupport.Text.Trim();
            _company.cashdate = txtCashDate.Text.Trim();
            String cashmethod = "";
            if (chkTT.Checked)
            {
                cashmethod+="1";
            }            
            if (chkJJ.Checked)
            {
                if( cashmethod!="") cashmethod+=",";
                cashmethod+="2";
            }
            if (chkYJ.Checked)
            {
                if (cashmethod != "") cashmethod += ",";
                cashmethod+="3";
            }
            _company.cashmethod = cashmethod;

            _company.agentfeerate = txtAgentRate.Text.Trim();
            _company.issuingfeerate = txtIssueRate.Text.Trim();
            _company.passfeerate = txtPassRate.Text.Trim();

            int period =0;
            int.TryParse( txtBillPeriod.Text , out period);
            _company.billperiod = period;

            _company.storageday1 = txtDay1.Text.Trim();
            _company.storageday2 = txtDay2.Text.Trim();
            _company.storageday3 = txtDay3.Text.Trim();
            _company.storageday4 = txtDay4.Text.Trim();
            _company.storageday5 = txtDay5.Text.Trim();
            decimal tempdec = 0;
            if (decimal.TryParse(txtPrice1.Text, out tempdec))
            {
                _company.storagefee1 = tempdec;
            }
            if (decimal.TryParse(txtPrice2.Text, out tempdec))
            {
                _company.storagefee2 = tempdec;
            }
            if (decimal.TryParse(txtPrice3.Text, out tempdec))
            {
                _company.storagefee3 = tempdec;
            }
            if (decimal.TryParse(txtPrice4.Text, out tempdec))
            {
                _company.storagefee4 = tempdec;
            }
            if (decimal.TryParse(txtPrice5.Text, out tempdec))
            {
                _company.storagefee5 = tempdec;
            }

            if (decimal.TryParse(txtFee1.Text, out tempdec))
            {
                _company.freight1 = tempdec;
            }
            if (decimal.TryParse(txtFee1.Text, out tempdec))
            {
                _company.freight1 = tempdec;
            }
            if (decimal.TryParse(txtFee2.Text, out tempdec))
            {
                _company.freight2 = tempdec;
            }
            if (decimal.TryParse(txtFee3.Text, out tempdec))
            {
                _company.freight3 = tempdec;
            }
            if (decimal.TryParse(txtFee4.Text, out tempdec))
            {
                _company.freight4 = tempdec;
            }
            if (decimal.TryParse(txtFee5.Text, out tempdec))
            {
                _company.freight5 = tempdec;
            }
            if (decimal.TryParse(txtFee6.Text, out tempdec))
            {
                _company.freight6 = tempdec;
            }
            int tempint = 0;
            if (int.TryParse(txtPayDay.Text, out tempint))
            {
                _company.paydays = tempint;
            }
            _company.requiregoods = txtRequireGoods.Text.Trim();


            int id = _bll.Add(_company);//单位
            return id;
        }

        protected void AddImages( FishEntity.CompanyEntity company )
        {
            if( company == null ) return;
            if (_formImage == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();

            if (company.id > 0)
            {
                bll.DeleteByRecordIdAndType(company.id, (int)FishEntity.ImageTypeEnum.CompanyThreeCard); 
            }

            FishEntity.ImageEntity image1 = _formImage.Image1;
            if (image1 != null && image1.image !=null )
            {
                image1.recordid = company.id;
                image1.createman = company.createman;
                image1.createtime = company.createtime;
                image1.type = 0;
                bll.Add(image1);
            }
            FishEntity.ImageEntity image2 = _formImage.Image2;
            if (image2 != null && image2.image !=null )
            {
                image2.recordid = company.id;
                image2.createman = company.createman;
                image2.createtime = company.createtime;
                image2.type = 0;
                bll.Add(image2);
            }
            FishEntity.ImageEntity image3 = _formImage.Image3;
            if (image3 != null && image3.image !=null )
            {
                image3.recordid = company.id;
                image3.createman = company.createman;
                image3.createtime = company.createtime;
                image3.type = 0;
                bll.Add(image3);
            } 
        }

        protected void AddCustomer(int companyid , string companycode , bool isAdd )
        {
            dataGridView1.EndEdit();

            string mainLinkManCode = "";
            string mainLinkMan = "";

            List<FishEntity.CustomerEntity> listNews = new List<FishEntity.CustomerEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.CustomerEntity customer = new FishEntity.CustomerEntity();
                customer.code = row.Cells["code"].Value == null ? string.Empty : row.Cells["code"].Value.ToString();
                customer.company = companycode;
                customer.email = row.Cells["email"].Value == null ? string.Empty : row.Cells["email"].Value.ToString();
                customer.id = row.Cells["id"].Value == null ? 0 : int.Parse ( row.Cells["id"].Value.ToString());
                customer.isdelete = 0;
                customer.name = row.Cells["name"].Value == null ? string.Empty : row.Cells["name"].Value.ToString();
                customer.nextcallrecordid = 0;
                customer.phone1 = row.Cells["phone1"].Value == null ? string.Empty : row.Cells["phone1"].Value.ToString();
                customer.phone2 = row.Cells["phone2"].Value == null ? string.Empty : row.Cells["phone2"].Value.ToString();
                customer.phone3 = row.Cells["phone3"].Value == null ? string.Empty : row.Cells["phone3"].Value.ToString();
                customer.qq = row.Cells["qq"].Value == null ? string.Empty : row.Cells["qq"].Value.ToString();
                customer.remark = row.Cells["remark"].Value == null ? string.Empty : row.Cells["remark"].Value.ToString();
                customer.telephone = row.Cells["telephone"].Value == null ? string.Empty : row.Cells["telephone"].Value.ToString();
                customer.validate = 1;
                customer.weixin = row.Cells["weixin"].Value == null ? string.Empty : row.Cells["weixin"].Value.ToString();
                customer.flag = row.Cells["flag"].Value == null ? 0 : (bool.Parse(row.Cells["flag"].Value.ToString())?1:0);
       
                customer.post =   row.Cells["post"].Value == null ? string.Empty  : row.Cells["post"].Value.ToString();
                customer.Department1 = row.Cells["department1"].Value == null ? string.Empty : row.Cells["department1"].Value.ToString();
                customer.officeaddress = row.Cells["officeaddress"].Value == null ? string.Empty : row.Cells["officeaddress"].Value.ToString();
                customer.fox = row.Cells["fox"].Value == null ? string.Empty : row.Cells["fox"].Value.ToString();
                customer.sex = row.Cells["sex"].Value == null ? "男" : row.Cells["sex"].Value.ToString();

                listNews.Add(customer);
            }

            //FishBll.Bll.CustomerBll customerBll = new FishBll.Bll.CustomerBll();
            FishBll.Bll.CustomerOfCompanyBll customerOfCompanyBll = new FishBll.Bll.CustomerOfCompanyBll();

            if (isAdd == false)
            {
                List<FishEntity.CustomerEntity> listsource = _customerBll.GetCustomerOfCompany(companyid);//右连接
                if (listsource != null)
                {
                    foreach (CustomerEntity item in listsource)
                    {
                        bool isExist = listNews.Exists((i) => { return  i.id == item.id; });
                        if (isExist == false)
                        {
                            bool isDelte = customerOfCompanyBll.Delete(companyid, item.id);//连接表
                        }
                    }
                }
            }


            foreach (CustomerEntity item in listNews)
            {
                if (string.IsNullOrEmpty(item.code))
                {
                    item.code = FishBll.Bll.SequenceUtil.GetCustomerSequence();
                    bool isok = _customerBll.Exists(item.code);//联系人
                    while (isok)
                    {
                        item.code = FishBll.Bll.SequenceUtil.GetCustomerSequence();
                        isok = _customerBll.Exists(item.code);//联系人
                    }

                    item.createman = FishEntity.Variable.User.username;
                    item.createtime = DateTime.Now;
                    item.modifyman = item.createman;
                    item.modifytime = item.createtime;

                    int customerId = _customerBll.Add(item);//联系人
                    if (customerId > 0)
                    {
                        item.id = customerId;
                        FishEntity.CustomerOfCompanyEntity coEntity = new CustomerOfCompanyEntity();
                        coEntity.companyid = companyid ;
                        coEntity.customerid = customerId;  
                        isok = customerOfCompanyBll.Add(coEntity);//连接表
                    }
                }
                else
                {
                    item.modifytime = DateTime.Now;
                    item.modifyman = FishEntity.Variable.User.username;
                    _customerBll.Update(item);//联系人
                }
            }

            SetCustomer(listNews);

            CustomerEntity mainCustomer= listNews.Find((i) => { return i.flag == 1; });
            if (mainCustomer != null)
            {
                _bll.UpdateLinkMan(companyid, mainCustomer.code, mainCustomer.name);//单位
                _company.linkman = mainCustomer.name;
                _company.linkmancode = mainCustomer.code;
                txtlinkman.Text = mainCustomer.name;
                txtlinkman.Tag = mainCustomer.code;
            }
        }
        public override int Modify()
        {
            if (_company == null)
            {
                MessageBox.Show("请查询需要修改的单位。");
                return 0;
            }
            if (Check() == false) return 0;

            string nfullname = txtfullname.Text.Trim();
            if( nfullname.Equals( _company.fullname ) ==false ){
                bool isexist = _bll.ExistsByFullName(nfullname);
                if (isexist)
                {
                    errorProvider1.SetError(txtfullname, "公司全称重复，无法保存。");
                    return 0;
                }
            }
                

            _company.type = cmbType.Text;
            _company.type_suppliers = "0";
            _company.type_agents = "0";
            _company.type_customer = "0";
            _company.type_merchants = "0";
            _company.type_goods = "0";
            _company.type_quote = "0";
            _company.Logistics = "0";
            _company.products = cmbproducts1.Text;
            _company.Fishmaterial = "0";
            _company.Shrimpmaterial = "0";
            _company.Poultrymaterial = "0";
            _company.Special = "0";
            _company.Specialwater = "0";
            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbproducts1.CheckBoxItems)
            {
                FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;

                if (item.Checked && kv.code.Equals("鱼料"))
                {
                    _company.Fishmaterial = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("虾料"))
                {
                    _company.Shrimpmaterial = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("禽料"))
                {
                    _company.Poultrymaterial = "1";
                    continue;
                }
                else
                {
                }

                if (item.Checked && kv.code.Equals("特种"))
                {
                    _company.Special = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("特水"))
                {
                    _company.Specialwater = "1";
                    continue;
                }
                else
                {
                }
              
            }

            foreach (UILibrary.CheckBoxComboBox.CheckBoxComboBoxItem item in cmbType.CheckBoxItems)
            {
                FishEntity.DictEntity kv = ((UILibrary.CheckBoxComboBox.ObjectSelectionWrapper<FishEntity.DictEntity>)item.ComboBoxItem).Item;

                if (item.Checked && kv.code.Equals("供应商"))
                {
                    _company.type_suppliers = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("代理商"))
                {
                    _company.type_agents = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("客户"))
                {
                    _company.type_customer = "1";
                    continue;
                }
                else
                {
                }

                if (item.Checked && kv.code.Equals("贸易商"))
                {
                    _company.type_merchants = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("货代商"))
                {
                    _company.type_goods = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("报盘商"))
                {
                    _company.type_quote = "1";
                    continue;
                }
                else
                {
                }
                if (item.Checked && kv.code.Equals("物流运输"))
                {
                    _company.Logistics = "1";
                    continue;
                }
            }


            _company.fullname = txtfullname.Text.Trim();
            _company.shortname = txtShortName.Text.Trim();
            //_company.generallevel = cmbGenerallevel.SelectedValue.ToString();//
            if (cmbGenerallevel.SelectedValue != null)
            {
                _company.generallevel = cmbGenerallevel.SelectedValue.ToString();//
            }
            _company.creditlevel = cmbCreditlevel.SelectedValue.ToString();
            _company.requiredlevel = cmbrequiredlevel.SelectedValue.ToString();
            _company.managestandard = cmbManageSpecificate.SelectedValue.ToString();
            _company.activelevel = cmbactivelevel.SelectedValue.ToString();
            _company.loyalty = cmbloyalty.SelectedValue.ToString();
            //_company.products = cmbproducts.SelectedValue.ToString();//
            //if (cmbproducts.SelectedValue != null)
            //{
            //    _company.products = cmbproducts.SelectedValue.ToString();//
            //}

            if (txtsalesman.Tag != null)
            {
                _company.salesman = txtsalesman.Text.Trim();
                _company.salesmancode = txtsalesman.Tag.ToString();
            }


            _company.area = txtarea.Text.Trim();
            _company.address = txtaddress.Text.Trim();
            _company.nature = cmbNature.SelectedValue.ToString();

            _company.manageprojects = cmbmanageprojects.SelectedValue.ToString();
            _company.registermoney = txtregistermoney.Text.Trim();
            _company.registertime = dtpRegisterTime.Value;
            int num = 0;
            int.TryParse(txtpersonnum.Text, out num);
            _company.personnumber = num;
            _company.zipcode = txtzip.Text.Trim();
            _company.fox = txtfox.Text.Trim();
            _company.website = txtwebsite.Text.Trim();

            if (txtlinkman.Tag != null)
            {
                _company.linkman = txtlinkman.Text.Trim();
                _company.linkmancode = txtlinkman.Tag.ToString();
            }

            _company.fatures = ckbFature.Checked ? 1 : 0;
            _company.bank = txtbank.Text.Trim();
            _company.account = txtaccount.Text.Trim();
            _company.customerproperty = cmbCustomerProperty.SelectedValue.ToString();
            _company.customergroup = txtCustomerGroup.Text.Trim();
            _company.description = txtdescription.Text.Trim();
            //_company.paymethod = cmbPaymethod.SelectedValue.ToString();
            if (cmbPaymethod.SelectedValue != null)
            {
                _company.paymethod = cmbPaymethod.SelectedValue.ToString();
            }
            //_company.requiredproduct = cmbRequirdProduct.SelectedValue.ToString();
            _company.requiredproduct = GetSpecification();

            _company.cashdeposit = txtCashDeposit.Text.Trim();
            _company.competitors = txtCompositor.Text.Trim();

            _company.validate = cmbValidate.Text.ToString().Equals("有效")?1:0;
            _company.modifyman = FishEntity.Variable.User.username;
            _company.modifytime = DateTime.Now;

            _company.province = cmbProvince.SelectedValue ==null ? string.Empty : cmbProvince.SelectedValue.ToString();
            //_company.zone = txtZone.Text.Trim();
            if (cmbArea.SelectedValue != null)
            {
                _company.zone = cmbArea.SelectedValue.ToString();
            }

            _company.registerman = txtRegister.Text.Trim();
            _company.cooperation = cmbhzrs.SelectedValue.ToString();
            _company.productrequire = txtRequire.Text.Trim();
            decimal temp =0;
            decimal.TryParse ( txtFreight.Text , out temp );
            _company.freight = temp;
            decimal.TryParse(txtTare.Text, out temp);
            _company.tare = temp;

            _company.currentmonthestimate = txtcurrentmonthestimate.Text.Trim();
            _company.currentweekestimate = txtcurrentweekestimate.Text.Trim();


            _company.yearSale = txtYearSales.Text.Trim();
            _company.productgoods = txtProductGoods.Text.Trim();
            _company.yearproduct = txtYearProduct.Text.Trim();
            _company.supportproduct = txtSupportProduct.Text.Trim();
            _company.yearsupport = txtYearSupport.Text.Trim();
            _company.cashdate = txtCashDate.Text.Trim();
            String cashmethod = "";
            if (chkTT.Checked)
            {
                cashmethod += "1";
            }
            if (chkJJ.Checked)
            {
                if (cashmethod != "") cashmethod += ",";
                cashmethod += "2";
            }
            if (chkYJ.Checked)
            {
                if (cashmethod != "") cashmethod += ",";
                cashmethod += "3";
            }
            _company.cashmethod = cashmethod;

            _company.agentfeerate = txtAgentRate.Text.Trim();
            _company.issuingfeerate = txtIssueRate.Text.Trim();
            _company.passfeerate = txtPassRate.Text.Trim();

            int period = 0;
            int.TryParse(txtBillPeriod.Text, out period);
            _company.billperiod = period;

            _company.storageday1 = txtDay1.Text.Trim();
            _company.storageday2 = txtDay2.Text.Trim();
            _company.storageday3 = txtDay3.Text.Trim();
            _company.storageday4 = txtDay4.Text.Trim();
            _company.storageday5 = txtDay5.Text.Trim();
            decimal tempdec = 0;
            if (decimal.TryParse(txtPrice1.Text, out tempdec))
            {
                _company.storagefee1 = tempdec;
            }
            if (decimal.TryParse(txtPrice2.Text, out tempdec))
            {
                _company.storagefee2 = tempdec;
            }
            if (decimal.TryParse(txtPrice3.Text, out tempdec))
            {
                _company.storagefee3 = tempdec;
            }
            if (decimal.TryParse(txtPrice4.Text, out tempdec))
            {
                _company.storagefee4 = tempdec;
            }
            if (decimal.TryParse(txtPrice5.Text, out tempdec))
            {
                _company.storagefee5 = tempdec;
            }

            if (decimal.TryParse(txtFee1.Text, out tempdec))
            {
                _company.freight1 = tempdec;
            }
            if (decimal.TryParse(txtFee1.Text, out tempdec))
            {
                _company.freight1 = tempdec;
            }
            if (decimal.TryParse(txtFee2.Text, out tempdec))
            {
                _company.freight2 = tempdec;
            }
            if (decimal.TryParse(txtFee3.Text, out tempdec))
            {
                _company.freight3 = tempdec;
            }
            if (decimal.TryParse(txtFee4.Text, out tempdec))
            {
                _company.freight4 = tempdec;
            }
            if (decimal.TryParse(txtFee5.Text, out tempdec))
            {
                _company.freight5 = tempdec;
            }
            if (decimal.TryParse(txtFee6.Text, out tempdec))
            {
                _company.freight6 = tempdec;
            }

            int tempint = 0;
            if (int.TryParse(txtPayDay.Text, out tempint))
            {
                _company.paydays = tempint;
            }
            _company.requiregoods = txtRequireGoods.Text.Trim();


            bool isok =_bll.Update(_company);
            if (isok)
            {
                AddImages(_company);


                AddCustomer(_company.id, _company.code, false);

                AddQuote(_company.id, false);

                MessageBox.Show("修改成功。");

                SetCompany();
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }

        private void txtsalesman_Click(object sender, EventArgs e)
        {
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                MessageBox.Show("对不起，您无权修改业务员。");
                return;
            }

            FormUserList form = new FormUserList( true );
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.PersonEntity person = form.SelectedPersion;
                if (person != null)
                {
                    txtsalesman.Text = person.realname;
                    txtsalesman.Tag = person.id;
                }
            }
        }

        private void txtlinkman_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["sex"].Value = "男";
        }

        private void ckbFature_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void InitQuote()
        {
            _quoteList = new List<QuoteProductEntity>();
            for (int i = 0; i < 8; i++)
            {
                QuoteProductEntity item = new QuoteProductEntity();
                item.no = i + 1;
                item.name = "";
                item.brand = "-1";
                item.nature = "-1";
                item.remark="";
                item.id = 0;
                _quoteList.Add(item);
            }
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = _quoteList;
        }

        protected void AddQuote( int companyid , bool isAdd )
        {
            dataGridView2.EndEdit();

            List<FishEntity.QuoteProductEntity> listNews = new List<FishEntity.QuoteProductEntity>();
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.QuoteProductEntity item = new FishEntity.QuoteProductEntity();
                int id = 0;
                int.TryParse(row.Cells["idcol"].Value == null ? "0" : row.Cells["idcol"].Value.ToString(), out id);
                item.id = id;
                int no = 0;
                int.TryParse(row.Cells["nocol"].Value == null ? "0" : row.Cells["nocol"].Value.ToString(), out no);
                item.no = no;
                item.name = row.Cells["namecol"].Value == null ? string.Empty : row.Cells["namecol"].Value.ToString();
                item.nature = row.Cells["naturecol"].Value == null ? string.Empty : row.Cells["naturecol"].Value.ToString();
                item.brand = row.Cells["brandcol"].Value == null ? string.Empty : row.Cells["brandcol"].Value.ToString();
                item.remark = row.Cells["remarkcol"].Value == null ? string.Empty : row.Cells["remarkcol"].Value.ToString();
      
                item.companyid = companyid;              
                        
                listNews.Add(item);
            }


            if (isAdd == false)
            {
                List<FishEntity.QuoteProductEntity> listsource = _quoteBll.GetModelList(" companyid =" + companyid );//报盘
                if (listsource != null)
                {
                    foreach (FishEntity.QuoteProductEntity item in listsource)
                    {
                        bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                        if (isExist == false)
                        {
                            bool isDelete = _quoteBll.Delete(item.id);//报盘
                        }
                    }
                }
            }

            foreach (FishEntity.QuoteProductEntity item in listNews)
            {
                if (item.id == 0)
                {
                    int id = _quoteBll.Add(item);
                    if (id > 0)
                    {
                        item.id = id;
                    }
                }
                else
                {
                    _quoteBll.Update(item);
                }
            }

            _quoteList = listNews;

            dataGridView2.DataSource = _quoteList;
        
        
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_CompanyList_1");
            form.ShowDialog();
            ReadColumnConfig(dataGridView1, "Set_CompanyList_1");
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

        private void txtthreecard_Click(object sender, EventArgs e)
        {
            if (_formImage == null)
            {
                _formImage = new FormImage(0, FishEntity.ImageTypeEnum.CompanyThreeCard);
            }

            _formImage.SetData(_company == null ? 0 : _company.id, 0);
            _formImage.ShowInTaskbar = false;
            _formImage.StartPosition = FormStartPosition.CenterParent;
            if (_formImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
