using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FishClient
{
    //t_QuotationPriceList
    public partial class FormQuotationPriceList :FormMenuBase
    {
        FishEntity.QuotationPriceListEntity _model=null;
        FishBll.Bll.QuotationPriceListBll _bll=null;
        bool result=false;string strWhere=string.Empty;
        public FormQuotationPriceList(string code) {
            InitializeComponent();
            _model = new FishEntity.QuotationPriceListEntity();
            _bll = new FishBll.Bll.QuotationPriceListBll();

            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(qualitySpe, FishEntity.Constant.Specification, true);
            country.SelectedValueChanged -= country_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            country.SelectedValueChanged += country_SelectedValueChanged;
            txtdataForm.Items.Add("报盘");
            txtdataForm.Items.Add("确盘");
            txtdataForm.Items.Add("现货");
            txtdataForm.Items.Add("自营仓库");
            txtdataForm.Items.Add("自制仓库");
            if (code!="")
            {
                _model = _bll.getModel(" code='"+code+"' ");
                if (_model == null)
                {
                    MessageBox.Show("已经没有记录了");
                    return ;
                }
                setValue();
            
        }
        }
        public FormQuotationPriceList ( )
        {
            InitializeComponent ( );

            _model = new FishEntity . QuotationPriceListEntity ( );
            _bll = new FishBll . Bll . QuotationPriceListBll ( );

            InitDataUtil . BindComboBoxData ( country ,FishEntity . Constant . CountryType ,true );
            InitDataUtil . BindComboBoxData ( brand ,FishEntity . Constant . Brand ,true );
            InitDataUtil . BindComboBoxData ( qualitySpe ,FishEntity . Constant . Specification ,true );
            country.SelectedValueChanged -= country_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            country.SelectedValueChanged += country_SelectedValueChanged;
            txtdataForm.Items.Add("报盘");
            txtdataForm.Items.Add("确盘");
            txtdataForm.Items.Add("现货");
            txtdataForm . Items . Add ( "自营仓库" );
            txtdataForm . Items . Add ( "自制仓库" );
        }
        void country_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (country.SelectedValue == null) return;
            string pcode = country.SelectedValue.ToString();
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

            brand.DisplayMember = "name";
            brand.ValueMember = "code";
            brand.DataSource = list;
        }
        #region Main
        public override int Query ( )
        {
            FormQuotationPriceListQuery form = new FormQuotationPriceListQuery ( this . Text + "查询" );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                strWhere = form . getWhere;
                _model = _bll . getModel ( strWhere );
                if ( _model == null )
                {
                    MessageBox . Show ( "已经没有记录了" );
                    return 0;
                }
                setValue ( );
            }

            return base . Query ( );
        }
        public override int Delete ( )
        {

            result = _bll . Delete ( code . Text );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                Previous ( );
            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        public override int Add ( )
        {
            clearControl ( );
            code . Text = _bll . getCode ( );
            XNfishId.Text = _bll.getfishId();
            return base . Add ( );
        }
        public override int Modify ( )
        {
            if ( getValue ( ) == false )
                return 0;

            result = _bll . Edit ( _model );
            if ( result )
                MessageBox . Show ( "保存成功" );
            else
                MessageBox . Show ( "保存失败" );

            return base . Modify ( );
        }
        public override void Save ( )
        {
            if ( getValue ( ) == false )
                return;

            if ( _bll . Exists ( _model . code ) )
                result = _bll . Edit ( _model );
            else
                result = _bll . Add ( _model ,this . Name );
            if ( result )
                MessageBox . Show ( "保存成功" );
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }
        public override void Review ( )
        {
            Review ( this . Name ,code . Text ,code . Text );

            base . Review ( );
        }
        public override void Previous ( )
        {
            QueryOne ( "<" ,"'order by id asc limit 1'" );

            base . Previous ( );
        }
        public override void Next ( )
        {
            QueryOne ( ">" ,"'order by id asc limit 1'" );

            base . Next ( );
        }
        #endregion

        #region Event
        private void fishId_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtdataForm . Text ) )
            {
                MessageBox . Show ( "请选择数据来源" );
                return;
            }

            if ( txtdataForm . Text . Equals ( "自制仓库" ) )
            {
                FormNewSelfcontrolWare form = new FormNewSelfcontrolWare( );//FormSelfcontrolWare
                if ( form . ShowDialog ( ) == DialogResult . OK )
                {
                    FishEntity .BatchSheetsEntity _model = form .getModel;
                    fishId . Text = _model . fishId;
                    price . Text = _model . price . ToString ( );
                    tvn . Text = _model . tvn;
                    protein . Text = _model .protein;
                    ash . Text = _model .ash;
                    histamine . Text = _model .histamine;
                    salt . Text = _model .salt;
                    las.Text = _model.las;
                    das.Text = _model.das;
                    country.Text = _model.country;
                    qualitySpe.Text = _model.qualitySpe;
                    brand.Text = _model.brand;
                }
            }
            else if ( txtdataForm . Text . Equals ( "自营仓库" ) )
            {
                FormNewPriWarehouse form = new FormNewPriWarehouse();//
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FishEntity.ProductQuoteVo _model = form.getModel;
                    fishId.Text = _model.code;
                    price.Text = _model.confirmrmb.ToString();
                    tvn.Text = _model.sgs_tvn.ToString();
                    protein.Text = _model.sgs_protein.ToString();
                    ash.Text = _model.sgs_graypart.ToString();
                    histamine.Text = _model.sgs_amine.ToString();
                    FFA.Text = _model.sgs_ffa.ToString(); ;
                    salt.Text = _model.domestic_sandsalt.ToString();
                    las.Text = _model.domestic_lysine.ToString();
                    das.Text = _model.domestic_methionine.ToString();
                    qualitySpe.Text = _model.specification;
                    country.Text = _model.nature;
                    brand.Text = _model.brand;
                }
            }
            else if (txtdataForm.Text.Equals("报盘"))
            {
                FormQuote form = new FormQuote();//
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FishEntity.ProductQuoteVo _model = form.getModel;
                    fishId.Text = _model.code;
                    tvn.Text = _model.quote_tvn.ToString();
                    protein.Text = _model.quote_protein.ToString();
                    ash.Text = _model.quote_graypart.ToString();
                    histamine.Text = _model.quote_amine.ToString();
                    FFA.Text = _model.quote_ffa.ToString(); ;
                    salt.Text = _model.quote_sandsalt.ToString();
                    qualitySpe.Text = _model.specification;
                    brand.Text = _model.brand;
                    country.Text = _model.nature;
                }
            }
            else if (txtdataForm.Text.Equals("现货"))
            {
                FormSpot form = new FormSpot();//
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FishEntity.ProductQuoteVo _model = form.getModel;
                    fishId.Text = _model.code;
                    price.Text = _model.quotermb.ToString();
                    tvn.Text = _model.sgs_tvn.ToString();
                    protein.Text = _model.sgs_protein.ToString();
                    ash.Text = _model.sgs_graypart.ToString();
                    histamine.Text = _model.sgs_amine.ToString();
                    FFA.Text = _model.sgs_ffa.ToString(); ;
                    salt.Text = _model.sgs_sandsalt.ToString();
                    qualitySpe.Text = _model.specification;
                    brand.Text = _model.brand;
                    country.Text = _model.nature;
                }
            }
            else if (txtdataForm.Text.Equals("确盘"))
            {
                FormConfirm form = new FormConfirm();//
                if (form.ShowDialog() == DialogResult.OK)
                {
                    FishEntity.ProductQuoteVo _model = form.getModel;
                    fishId.Text = _model.code;
                    price.Text = _model.quotermb.ToString();
                    tvn.Text = _model.quote_tvn.ToString();
                    protein.Text = _model.quote_protein.ToString();
                    ash.Text = _model.quote_graypart.ToString();
                    histamine.Text = _model.quote_amine.ToString();
                    FFA.Text = _model.quote_ffa.ToString(); ;
                    salt.Text = _model.quote_sandsalt.ToString();
                    qualitySpe.Text = _model.specification;
                    brand.Text = _model.brand;
                    country.Text = _model.nature;
                }
            }
        }
        private void txtdataForm_SelectedValueChanged ( object sender ,EventArgs e )
        {
        }
        private void code_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( code . Text ) )
                this . DialogResult = DialogResult . Cancel;
            if (fishId.Text != "" && fishId.Text != null)
            {
                _model.fishId = fishId.Text;
                _model.qualitySpe = qualitySpe.Text;
                _model.FFA = FFA.Text;
                _model.ash = ash.Text;
                _model.histamine = histamine.Text;
                _model.country = country.Text;
                _model.brand = brand.Text;
            }
            else
            {
                _model.fishId = XNfishId.Text;
                _model.protein = protein.Text;
                _model.qualitySpe = qualitySpe.Text;
                _model.FFA = FFA.Text;
                _model.ash = ash.Text;
                _model.histamine = histamine.Text;
                _model.country = country.Text;
                _model.brand = brand.Text;
            }
            _model . code = code . Text;
            this . DialogResult = DialogResult . OK;
        }
        #endregion

        #region Method
        void clearControl ( )
        {
            foreach ( Control tc in panel1 . Controls )
            {
                if ( tc . GetType ( ) == typeof ( TextBox ) )
                {
                    TextBox tb = tc as TextBox;
                    tb . Text = string . Empty;
                }
                if ( tc . GetType ( ) == typeof ( ComboBox ) )
                {
                    ComboBox tb = tc as ComboBox;
                    tb . Text = string . Empty;
                }
                if ( tc . GetType ( ) == typeof ( DateTimePicker ) )
                {
                    DateTimePicker tb = tc as DateTimePicker;
                    tb . Value = DateTime . Now;
                }
            }
        }
        bool getValue ( )
        {
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( txtdataForm . Text ) )
            {
                errorProvider1 . SetError ( txtdataForm ,"请选择" );
                return false;
            }
            if ( string . IsNullOrEmpty ( code . Text ) )
            {
                errorProvider1 . SetError ( code ,"不可为空" );
                return false;
            }

            _model = new FishEntity . QuotationPriceListEntity ( );
            _model . code = code . Text;
            _model . fishId = fishId . Text;
            decimal outResult = 0M;
            _model . priceMY = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( price . Text ) && decimal . TryParse ( price . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( price ,"请重新输入" );
                return false;
            }
            _model . price = outResult;
            _model . country = country . Text;
            _model . brand = brand . Text;
            _model . qualitySpe = qualitySpe . Text;
            outResult = 0M;
            _model . weight = outResult;
            _model . date = date . Value;
            _model . tvn = tvn . Text;
            _model.XNfishId= XNfishId.Text;
            _model.FFA = FFA.Text;
            _model . salt = salt . Text;
            _model . protein = protein . Text;
            _model . ash = ash . Text;
            _model . histamine = histamine . Text;
            _model . las = las . Text;
            _model . das = das . Text;
            _model . remark = remark . Text;
            _model . dataForm = txtdataForm . Text;
            _model . CodeNumSales = codeNumSales . Text;

            return true;
        }
        void setValue ( )
        {
            code . Text = _model . code;
            fishId . Text = _model . fishId;
            price . Text = _model . price . ToString ( );
            country . Text = _model . country;
            brand . Text = _model . brand;
            qualitySpe . Text = _model . qualitySpe;
            if ( _model . date > DateTime . MinValue && _model . date < DateTime . MaxValue )
                date . Value = Convert . ToDateTime ( _model . date );
            else
                date . Value = DateTime . Now;
            tvn . Text = _model . tvn;
            XNfishId.Text = _model.XNfishId;
            FFA.Text = _model.FFA;
            salt . Text = _model . salt;
            protein . Text = _model . protein;
            ash . Text = _model . ash;
            histamine . Text = _model . histamine;
            las . Text = _model . las;
            das . Text = _model . das;
            remark . Text = _model . remark;
            txtdataForm . Text = _model . dataForm;
            codeNumSales . Text = _model . CodeNumSales;
        }
        void QueryOne ( string operate ,string orderBy )
        {
            string whereEx = string . Empty;
            if ( string . IsNullOrEmpty ( strWhere ) )
                whereEx = "1=1";
            else
                whereEx = strWhere;
            if ( _model != null )
                whereEx = whereEx + " AND code " + operate + orderBy;

            _model = _bll . getModel ( whereEx );
            if ( _model == null )
            {
                MessageBox . Show ( "已经没有记录了" );
                return;
            }
            setValue ( );
        }
        public FishEntity . QuotationPriceListEntity getModel
        {
            get
            {
                return _model;
            }
        }
        #endregion

        private void FormQuotationPriceList_Load(object sender, EventArgs e)
        {
            MenuCode = "M452"; ControlButtomRoles();
            if (Megres.oddNum != null && Megres.oddNum != "")
            {
                _model = new FishEntity.QuotationPriceListEntity();
                _bll = new FishBll.Bll.QuotationPriceListBll();
                InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
                InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Brand, true);
                InitDataUtil.BindComboBoxData(qualitySpe, FishEntity.Constant.Specification, true);
                txtdataForm.Items.Add("自营仓库");
                txtdataForm.Items.Add("入库申请单");
                _model = _bll.getModel(" code = '"+Megres.oddNum+"' ");
                if (_model == null)
                {
                    MessageBox.Show("已经没有记录了");
                }
                else
                    setValue();
            }
        }
    }
}
