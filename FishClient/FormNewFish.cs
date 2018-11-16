using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FishClient
{
    public partial class FormNewFish : FormMenuBase
    {
        private FishEntity.ProductEntity _fish = null;
        private FishEntity.ProductExEntity _fishex = null;
        private FishBll.Bll.ProductBll _bll = null;
        private FishBll.Bll.ProductExBll _bllex =null;
        private string _where = string.Empty;
        string _orderBy = "  ";//" order by id asc limit 1";
        public event EventHandler ClickGBEvent = null;
        private UIForms.FormFishCondition _queryForm = null;
        FormImage _formSGS = null;
        FormImage _formLabel = null;
        FormImage _formGJ = null;
        FormImage _formQuote = null;
        public event EventHandler RefreshDataEvent = null;
        public FormNewFish()
        {
            InitializeComponent();
            InitDataUtil.BindComboBoxData(cmbPort, FishEntity.Constant.port, true);
            InitDataUtil.BindComboBoxData(cmbFishType, FishEntity.Constant.FishClass, true);
            InitDataUtil.BindComboBoxData(cmborigin, FishEntity.Constant.Origin, true);
            InitDataUtil.BindComboBoxData(cmbTechClass, FishEntity.Constant.TechClass, true);
            InitDataUtil.BindComboBoxData(cmbpack, FishEntity.Constant.packk, true);
            InitDataUtil.BindComboBoxData(cmbName, FishEntity.Constant.Goods, true);
            InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbmanufacturers, FishEntity.Constant.Manufacturers, true);
            InitDataUtil.BindComboBoxData(cmbgoodsinfo, FishEntity.Constant.GoodsInfo, true);
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbBand, FishEntity.Constant.Brand, true);

            CheQuotation.Tag = FishEntity.Variable.StateList;
            Checommodity.Tag = FishEntity.Variable.StateList;
            CheFirm.Tag= FishEntity.Variable.StateList;
            CheCautotrophy.Tag = FishEntity.Variable.StateList;
            CheRestraint.Tag = FishEntity.Variable.StateList;
            CheArticles.Tag = FishEntity.Variable.StateList;

            cmbvalidate.Text = "有效";
            cmbvalidate1.Text = "有效";
            cmbvalidate2.Text = "有效";
            cmbvalidate3.Text = "有效";
            cmbvalidate4.Text = "有效";
            cmbvalidate5.Text = "有效";

            dtpquotedate.CustomFormat = "yyyy.MM.dd";
            dtpquotedate.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            dtpArriveDate.CustomFormat = "yyyy.MM.dd";
            dtpArriveDate.Format = DateTimePickerFormat.Custom;
            dtpconfirmsaildate.CustomFormat = "yyyy.MM.dd";
            dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
            dtpConfirmDate.CustomFormat = "yyyy.MM.dd";
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;
            dtpdate.CustomFormat = "yyyy.MM.dd";
            dtpdate.Format = DateTimePickerFormat.Custom;
            dtpSaletime.CustomFormat = "yyyy.MM.dd";
            dtpSaletime.Format = DateTimePickerFormat.Custom;
            dtpfinishedtime.CustomFormat = "yyyy.MM.dd";
            dtpfinishedtime.Format = DateTimePickerFormat.Custom;
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            BindCountryBrandData();
            checklable();
            LoadImage();
            panel1.Enabled = false;
        }
        public FormNewFish(string fishId) : this ( )
        {
            _where = " code= '" + fishId+"'";
            QueryByWhere(_where, _orderBy);
        }
        public FormNewFish(int productid) : this()
        {
            _where = " id=" + productid;
            QueryByWhere(_where, _orderBy);
        }
        public override int Query()
        {
            if (_queryForm == null)
            {
                _queryForm = new UIForms.FormFishCondition();
                _queryForm.StartPosition = FormStartPosition.CenterParent;
                _queryForm.ShowInTaskbar = false;
            }
            if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where = _queryForm.GetWhere();

            return QueryByWhere(_where, _orderBy);
        }
        protected int QueryByWhere(string where, string orderBy)
        {
            _bll = new FishBll.Bll.ProductBll();
            List<FishEntity.ProductEntity> list = _bll.GetModelList(where + orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                _fishex = null;
                return 0;
            }
            else
            {
                panel1.Enabled = true;
                _fish = list[0];
                _bllex = new FishBll.Bll.ProductExBll();
                _fishex = new FishEntity.ProductExEntity();
                _fishex = _bllex.GetModel(_fish.id);

                SetFish();  checkTrueOrFalse(); checklable();

                return 1;
            }
        }
        public void ReadOnlytxt()
        {
            txtCode.ReadOnly= txtshipno.ReadOnly= txtbillofgoods .ReadOnly= txtcornerno .ReadOnly= txtSaleCompany.Enabled = txtSaleLinkman.Enabled = txtfinisheWeight.ReadOnly= txtfinisheNumber.ReadOnly= txtdomestic_protein.ReadOnly= txtdomestic_tvn.ReadOnly= txtdomestic_amine.ReadOnly= txtdomestic_sour.ReadOnly= txtdomestic_ffa.ReadOnly= 
                txtdomestic_fat.ReadOnly= txtdomestic_graypart.ReadOnly= txtdomestic_lysine.ReadOnly= txtdomestic_methionine.ReadOnly= txtdomestic_aminototal.ReadOnly = true;
            cmbSpecification.Enabled = false;
            cmbCountry.Enabled = false;
            cmbBand.Enabled = false;
            dtpfinishedtime.Enabled = false;
         }
        public override void Save()
        {
            if (Check()==false)
            {
                return;
            }
            GetFish();
            _fish.code = FishBll.Bll.SequenceUtil.GetFishSequence();
            bool isok = _bll.Exists(_fish.code);
            while (isok)
            {
                _fish.code = FishBll.Bll.SequenceUtil.GetFishSequence();
                isok = _bll.Exists(_fish.code);
            }
            checkTrueOrFalse();
            if (CheQuotation.Checked == true)
            {
                _fish.Display = 1;
            }
            else
            {
                _fish.Display = 0;
            }
            int id = _bll.Add(_fish);
            if (id > 0)
            {
                _fish.id = id;

                AddImages(_fish);
                AddImages1(_fish);

                SaveEx(id);
                SetFish();
                ControlButtomRoles();
                checklable(); 
                panel1.Enabled = true;
                MessageBox.Show("添加成功。");
            }
            else
            {
                checkTrueOrFalse(); checklable(); 
                MessageBox.Show("添加失败。");
                panel1.Enabled = false;
            }
            base.Save();
        }
        public override int Modify()
        {
            Check();
            if (_fish == null)
            {
                MessageBox.Show("请查询需要修改的鱼粉。");
                return 0;
            }


            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan)
                && false == FishEntity.Variable.User.username.Equals(_fish.createman))
            {
                MessageBox.Show("对不起，您不能修改别人创建的鱼粉资料！");
                return 0;
            }

            GetFish();
            if(Check() == false) return 0;

            //fishInfoControl1.GetFish(_fish);
            //fishCompositionControl1.GetFish(_fish);
            //fishSummaryControl1.GetFish(_fish);
            if (_fishex == null)
            {
                _fishex = new FishEntity.ProductExEntity();
            }
            GetFishex();
            //fishQuoteControl1.GetFishEx(_fishex);
            //fishComfirmControl1.GetFishEx(_fishex);
            //fishSpotGoodsControl1.GetFishEx(_fishex);
            //fishSelfControl1.GetFishEx(_fishex);
            //fishSaleControl1.GetFishEx(_fishex);

            _fish.modifyman = FishEntity.Variable.User.username;
            _fish.modifytime = DateTime.Now;

            bool isok = _bll.Update(_fish);
            if (isok)
            {
                AddImages(_fish);
                AddImages1(_fish);
                _bllex.Update(_fishex);
                checkTrueOrFalse(); checklable();
                MessageBox.Show("修改成功。");
            }
            else
            {
                checkTrueOrFalse(); checklable();
                MessageBox.Show("修改失败。");
            }

            return 1;
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

            cmbBand.DisplayMember = "name";
            cmbBand.ValueMember = "code";
            cmbBand.DataSource = list;
        }
        public void GetFish()//添加
        {
            if (_fish==null)
            {
                _fish = new FishEntity.ProductEntity();
            }
            _bll = new FishBll.Bll.ProductBll();
            _fish.code = txtCode.Text;
            _fish.createman = txtsalesman.Text;
            _fish.name = cmbName.SelectedValue == null ? string.Empty : cmbName.SelectedValue.ToString();
            _fish.goodsinfo = cmbgoodsinfo.SelectedValue == null ? string.Empty : cmbgoodsinfo.SelectedValue.ToString();
            _fish.nature = cmbCountry.SelectedValue.ToString();
            _fish.specification = cmbSpecification.SelectedValue == null ? string.Empty : cmbSpecification.SelectedValue.ToString();
            _fish.techtype = cmbTechClass.SelectedValue.ToString();
            _fish.type = cmbFishType.SelectedValue == null ? string.Empty : cmbFishType.SelectedValue.ToString();
            _fish.Pack = cmbpack.SelectedValue.ToString();
            _fish.getinfotime = dtpgetinfotime.Value;
            _fish.endinfotime = dtpendinfotime.Value;
            if (cmbBand.SelectedValue != null)
            {
                _fish.brand = cmbBand.SelectedValue.ToString();
            }
            else
            {
                _fish.brand = string.Empty;
            }

            if (CheQuotation.Checked != false)
            {
                _fish.state = "1";//CheQuotation.Text.ToString();
                
            }
            else
            {
                _fish.state = string.Empty;
            }
            if (CheFirm.Checked != false)
            {
                _fish.State1 = "2";//CheQuotation.Text.ToString();
            }
            else
            {
                _fish.State1 = string.Empty;
            }
            
            if (Checommodity.Checked != false)
            {
                _fish.State2 = "3";//Checommodity.Text.ToString();
            }
            else
            {
                _fish.State2 = string.Empty;
            }

            if (CheCautotrophy.Checked != false)
            {
                _fish.State3 = "4";//CheCautotrophy.Text.ToString();
            }
            else
            {
                _fish.State3 = string.Empty;
            }

            if (CheRestraint.Checked != false)
            {
                _fish.State4 = "5";//CheRestraint.Text.ToString();
            }
            else
            {
                _fish.State4 = string.Empty;
            }

            if (CheArticles.Checked != false)
            {
                _fish.State5 = "6";//CheArticles.Text.ToString();
            }
            else
            {
                _fish.State5 = string.Empty;
            }
            _fish.port = cmbPort.SelectedValue == null ? string.Empty : cmbPort.SelectedValue.ToString();
            _fish.isdelete = cmbvalidate.Text.Equals("有效") ? 1 : 0;
            _fish.Isdelete1 = cmbvalidate1.Text.Equals("有效") ? 1 : 0;
            _fish.Isdelete2 = cmbvalidate2.Text.Equals("有效") ? 1 : 0;
            _fish.Isdelete3 = cmbvalidate3.Text.Equals("有效") ? 1 : 0;
            _fish.Isdelete4 = cmbvalidate4.Text.Equals("有效") ? 1 : 0;
            _fish.Isdelete5 = cmbvalidate5.Text.Equals("有效") ? 1 : 0;

            _fish.warehouse = txtwarehouse.Text.Trim();
            _fish.origin = cmborigin.SelectedValue.ToString();
            decimal temp = 0;
            decimal.TryParse(txtrate.Text, out temp);
            _fish.tariffrate = temp;
            _fish.manufacturers = cmbmanufacturers.SelectedValue == null ? string.Empty : cmbmanufacturers.SelectedValue.ToString();
            _fish.factoryaddress = txtfactoryaddress.Text;
            _fish.shipno = txtshipno.Text.Trim();
            _fish.billofgoods=txtbillofgoods.Text.Trim();
            _fish.cornerno=txtcornerno.Text.Trim();
            _fish.quality = txtquality.Text;
            ///----------------------------------------------------------
            decimal temp2 = 0;
            decimal.TryParse(txtquote_protein.Text, out temp2);
            _fish.quote_protein = temp2;
            decimal.TryParse(txtquote_tvn.Text, out temp2);
            _fish.quote_tvn = temp2;
            decimal.TryParse(txtquote_sandsalt.Text, out temp2);
            _fish.quote_sandsalt = temp2;
            decimal.TryParse(txtquote_amine.Text, out temp2);
            _fish.quote_amine = temp2;
            decimal.TryParse(txtquote_ffa.Text, out temp2);
            _fish.quote_ffa = temp2;
            decimal.TryParse(txtquote_fat.Text, out temp2);
            _fish.quote_fat = temp2;
            decimal.TryParse(txtquote_water.Text, out temp2);
            _fish.quote_water = temp2;
            decimal.TryParse(txtquote_sand.Text, out temp2);
            _fish.quote_sand = temp2;
            decimal.TryParse(txtquote_graypart.Text, out temp2);
            _fish.quote_graypart = temp2;
            _fish.remark = txtRemarks.Text.ToString();
            //--------------------------------------------------
            decimal.TryParse(txtsgs_amine.Text, out temp2);
            _fish.sgs_amine = temp2;

            decimal.TryParse(txtsgs_ffa.Text, out temp2);
            _fish.sgs_ffa = temp2;

            decimal.TryParse(txtsgs_fat.Text, out temp2);
            _fish.sgs_fat = temp2;

            decimal.TryParse(txtsgs_graypart.Text, out temp2);
            _fish.sgs_graypart = temp2;

            decimal.TryParse(txtsgs_protein.Text, out temp2);
            _fish.sgs_protein = temp2;

            decimal.TryParse(txtsgs_sand.Text, out temp2);
            _fish.sgs_sand = temp2;

            decimal.TryParse(txtsgs_sandsalt.Text, out temp2);
            _fish.sgs_sandsalt = temp2;

            decimal.TryParse(txtsgs_tvn.Text, out temp2);
            _fish.sgs_tvn = temp2;

            decimal.TryParse(txtsgs_water.Text, out temp2);
            _fish.sgs_water = temp2;

            //----------------------------------------------------

            decimal.TryParse(txtlabe_water.Text, out temp2);
            _fish.labe_water = temp2;

            decimal.TryParse(txtlabel_amine.Text, out temp2);
            _fish.label_amine = temp2;

            decimal.TryParse(txtlabel_fat.Text, out temp2);
            _fish.label_fat = temp2;

            decimal.TryParse(txtlabel_ffa.Text, out temp2);
            _fish.label_ffa = temp2;

            decimal.TryParse(txtlabel_graypart.Text, out temp2);
            _fish.label_graypart = temp2;

            decimal.TryParse(txtlabel_lysine.Text, out temp2);
            _fish.label_lysine = temp2;

            decimal.TryParse(txtlabel_methionine.Text, out temp2);
            _fish.label_methionine = temp2;

            decimal.TryParse(txtlabel_protein.Text, out temp2);
            _fish.label_protein = temp2;

            decimal.TryParse(txtlabel_sand.Text, out temp2);
            _fish.label_sand = temp2;

            decimal.TryParse(txtlabel_sandsalt.Text, out temp2);
            _fish.label_sandsalt = temp2;

            decimal.TryParse(txtlabel_tvn.Text, out temp2);
            _fish.label_tvn = temp2;

            decimal.TryParse(txtlabel_aminototal.Text, out temp2);
            _fish.label_aminototal = temp2;
            

            //----------------------------------------------------

            decimal.TryParse(txtdomestic_graypart.Text, out temp2);
            _fish.domestic_graypart = temp2;

            decimal.TryParse(txtdomestic_lysine.Text, out temp2);
            _fish.domestic_lysine = temp2;

            decimal.TryParse(txtdomestic_methionine.Text, out temp2);
            _fish.domestic_methionine = temp2;

            decimal.TryParse(txtdomestic_protein.Text, out temp2);
            _fish.domestic_protein = temp2;

            decimal.TryParse(txtdomestic_sandsalt.Text, out temp2);
            _fish.domestic_sandsalt = temp2;

            decimal.TryParse(txtdomestic_sour.Text, out temp2);
            _fish.domestic_sour = temp2;

            decimal.TryParse(txtdomestic_tvn.Text, out temp2);
            _fish.domestic_tvn = temp2;

            decimal.TryParse(txtdomestic_amine.Text, out temp2);
            _fish.domestic_amine = temp2;

            decimal.TryParse(txtdomestic_aminototal.Text, out temp2);
            _fish.domestic_aminototal = temp2;

            decimal.TryParse(txtdomestic_fat.Text, out temp2);
            _fish.domestic_fat = temp2;
            decimal.TryParse(txtdomestic_water.Text, out temp2);
            _fish.domestic_water = temp2;
            decimal.TryParse(txtdomestic_sand.Text, out temp2);
            _fish.domestic_sand = temp2;
            decimal.TryParse(txtdomestic_ffa.Text, out temp2);
            _fish.domestic_ffa = temp2;
            _fish.createman = _fish.modifyman = FishEntity.Variable.User.username;
            _fish.createtime=_fish.modifytime = DateTime.Now;

            if (rabDMS.Checked==true)
            {
                _fish.FishMealState = rabDMS.Text;
            }
            else if (rabKS.Checked==true)
            {
                _fish.FishMealState = rabKS.Text;
            }

            if (rabXK.Checked == true)
            {
                _fish.shrimpshell = rabXK.Text;
            }
            else {
                _fish.shrimpshell = string.Empty; ;
            }

            if (rabSC.Checked == true)
            {
                _fish.chromaticberration = rabSC.Text;
            }
            else
            {
                _fish.chromaticberration = string.Empty; ;
            }

            if (rabQW.Checked == true)
            {
                _fish.smell = rabQW.Text;
            }
            else
            {
                _fish.smell = string.Empty; ;
            }

            if (rabHD.Checked == true)
            {
                _fish.blackspot = rabHD.Text;
            }
            else
            {
                _fish.blackspot = string.Empty; ;
            }
        }
        public void GetFishex() {
            if (_fishex==null)
            {
                txtquoteproductyear.Text = string.Empty;
                txtquotedollars.Text = string.Empty;
                txtquotelinkman.Text = string.Empty;
                txtquotelinkman.Tag = string.Empty;
                txtquoteproductdate.Text = string.Empty;
                txtquotermb.Text = string.Empty;
                //txtquotesaildatefast.Text = string.Empty;
                //txtquotesaildatelate.Text = string.Empty;
                txtquotesuppliercode.Text = string.Empty;
                txtquotesuppliercode.Tag = string.Empty;
                txtquoteweight.Text = string.Empty;

                dtpquotesaildatefast.Text = string.Empty;
                dtpquotesaildatefast.CustomFormat = " ";
                dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;

                dtpquotesaildatelate.Text = string.Empty;
                dtpquotesaildatelate.CustomFormat = " ";
                dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            }else { 
            ///-------------------------------------------------------------------------------------------
           
                _fishex.quotedate = dtpquotedate.Text.ToString();

            decimal weight = 0;
            decimal.TryParse(txtquoteweight.Text, out weight);
            _fishex.quoteweight = weight;
            decimal dollars = 0;
            decimal.TryParse(txtquotedollars.Text, out dollars);
            _fishex.quotedollars = dollars;
            _fishex.quotEexchangeRate = txtquotEexchangeRate.Text;
            decimal rmb = 0;
            decimal.TryParse(txtquotermb.Text, out rmb);
            _fishex.quotermb = rmb;
            _fishex.quotesupplier = txtquotesuppliercode.Text.Trim();
            _fishex.quotesuppliercode = txtquotesuppliercode.Tag == null ? string.Empty : txtquotesuppliercode.Tag.ToString();
            _fishex.quotelinkman = txtquotelinkman.Text.Trim();
            _fishex.quotelinkmancode = txtquotelinkman.Tag == null ? string.Empty : txtquotelinkman.Tag.ToString();
            _fishex.quoteproductyear = txtquoteproductyear.Text.Trim();
            _fishex.quoteproductdate = txtquoteproductdate.Text.Trim();
            _fishex.quotesaildatefast = dtpquotesaildatefast.Text.Trim();
            _fishex.quotesaildatelate = dtpquotesaildatelate.Text.Trim();
            _fishex.confirmarrivedate = dtpArriveDate.Text.Trim();
            _fishex.confirmsaildate = dtpconfirmsaildate.Text.Trim();
            _fishex.confirmdate = dtpConfirmDate.Text.Trim();
            _fishex.confirmWeight = txtconfirmWeight.Text.Trim();

            _fishex.spotproductyear= txtproductyear1.Text;
            _fishex.spotproductdate= txtproductdate1.Text;
            dollars = 0;
            decimal.TryParse(txtConfirmdollars.Text, out dollars);
            _fishex.confirmdollars = dollars;
            _fishex.confirmEexchangeRate = txtConfirmEexchangeRate.Text.Trim();
            rmb = 0;
            decimal.TryParse(txtConfirmrmb.Text, out rmb);
            _fishex.confirmrmb = rmb;
            _fishex.PlaceOfDelivery = txtPlaceOfDelivery.Text;
            _fishex.spotstoragedate = dtpdate.Text.Trim();
                _fishex.Saletime = dtpSaletime.Text.Trim();
                _fishex.finishedtime = dtpfinishedtime.Text.Trim();
                weight = 0;
            decimal.TryParse(txtweight.Text, out weight);
            _fishex.spotweight = weight;
            dollars = 0;
            decimal.TryParse(txtdollars.Text, out dollars);
            _fishex.spotdollars = dollars;
            _fishex.spotEexchangeRate = txtspotEexchangeRate.Text.Trim();
            rmb = 0;
            decimal.TryParse(txtrmb.Text, out rmb);
            _fishex.spotrmb = rmb;
            weight = 0;
            decimal.TryParse(txtSaleWeight.Text, out weight);
            _fishex.saleremainweight = weight;
            rmb = 0;
            decimal.TryParse(txtSaleRmb.Text, out rmb);
            _fishex.salermb = rmb;
                rmb = 0;
                decimal.TryParse(txtSaleNumWeight.Text, out rmb);
                _fishex.SaleNumWeight = rmb;
                weight = 0;
                decimal.TryParse(txtfinisheWeight.Text, out weight);
                _fishex.finisheWeight = weight;
                weight = 0;
            decimal.TryParse(txtSgsWeight.Text, out weight);
            _fishex.confirmsgsweight = weight;
            int quantity=0;
            _fishex.finisheNumber = txtfinisheNumber.Text;
            _fishex.confirmsgsquantity = txtSgsQuantity.Text;
            _fishex.spotlife=txtlife.Text;
            _fishex.spotagent = txtspotagent.Text.Trim();
            _fishex.spotagentcode = txtspotagent.Tag == null ? string.Empty : txtspotagent.Tag.ToString();
            _fishex.spotlinkman = txtspotagentcode.Text.Trim();
            _fishex.spotlinkmancode = txtspotagentcode.Tag == null ? string.Empty : txtspotagentcode.Tag.ToString();
            _fishex.saletrader = txtSaleCompany.Text.Trim();
            _fishex.saletradercode = txtSaleCompany.Tag == null ? string.Empty : txtSaleCompany.Tag.ToString();
            _fishex.salelinkman = txtSaleLinkman.Text.Trim();
            _fishex.salelinkmancode = txtSaleLinkman.Tag == null ? string.Empty : txtSaleLinkman.Tag.ToString();
            _fishex.confirmagent = txtconfirmagent.Text.Trim();
            _fishex.confirmagentcode = txtconfirmagent.Tag == null ? string.Empty : txtconfirmagent.Tag.ToString();
            _fishex.confirmlinkman = txtconfirmagentcode.Text.Trim();
            _fishex.confirmlinkmancode = txtconfirmagentcode.Tag == null ? string.Empty : txtconfirmagentcode.Tag.ToString();

            _fishex.confirmproductyear = txtproductyear.Text;
            _fishex.confirmproductdate = txtproductdate.Text.Trim();
            _fishex.confirmlife = txtconfirmlife.Text.Trim();
            }
        }
        public void SaveEx(int id)
        {
            _fishex = new FishEntity.ProductExEntity();
            _bllex = new FishBll.Bll.ProductExBll();
            GetFishex();
            _fishex.id = id;
            if( _bllex.Add(_fishex)==true)
            SetFishEX();
        }
        public void SetFish() {
            if (_fish==null)
            {
                return;
            }
            txtCode.Text= _fish.code;
            txtsalesman.Text= _fish.createman;
            cmbName.Text = _fish.name;
            cmbgoodsinfo.Text= _fish.goodsinfo;
            cmbCountry.Text= _fish.nature;
            cmbSpecification.Text = _fish.specification;
            cmbTechClass.Text= _fish.techtype;
            cmbFishType.Text = _fish.type;
            cmbpack.Text= _fish.Pack;
            cmbPort.SelectedValue = _fish.port;
            if (_fish.getinfotime!=null)
            {
                dtpgetinfotime.Value = DateTime.Parse(_fish.getinfotime.ToString());
            }
            if (_fish.endinfotime!=null)
            {
                dtpendinfotime.Value = DateTime.Parse(_fish.endinfotime.ToString());
            }
            cmbBand.Text = _fish.brand;
            txtwarehouse.Text = _fish.warehouse;
            cmborigin.Text = _fish.origin;
            txtrate.Text =_fish.tariffrate.ToString();
            cmbmanufacturers.Text = _fish.manufacturers.ToString();
            txtfactoryaddress.Text = _fish.factoryaddress.ToString();
            txtshipno.Text = _fish.shipno.ToString();
            txtbillofgoods.Text = _fish.billofgoods.ToString();
            txtcornerno.Text = _fish.cornerno.ToString();

            if (_fish.state != "" && _fish.state.ToString() == "1") { CheQuotation.Checked = true; } else { CheQuotation.Checked = false; };
            if (_fish.State1 != "" && _fish.State1.ToString() == "2") { CheFirm.Checked = true; } else { CheFirm.Checked = false; };
            if (_fish.State2 != "" && _fish.State2.ToString() == "3") { Checommodity.Checked = true; } else { Checommodity.Checked = false; };
            if (_fish.State3 != "" && _fish.State3.ToString() == "4") { CheCautotrophy.Checked = true; } else { CheCautotrophy.Checked = false; };
            if (_fish.State4 != "" && _fish.State4.ToString() == "5") { CheRestraint.Checked = true; } else { CheRestraint.Checked = false; };
            if (_fish.State5 != "" && _fish.State5.ToString() == "6") { CheArticles.Checked = true; } else { CheArticles.Checked = false; };

            cmbvalidate.Text = _fish.isdelete == 1 ? "有效" : "无效";
            cmbvalidate1.Text = _fish.Isdelete1 == 1 ? "有效" : "无效";
            cmbvalidate2.Text = _fish.Isdelete2 == 1 ? "有效" : "无效";
            cmbvalidate3.Text = _fish.Isdelete3 == 1 ? "有效" : "无效";
            cmbvalidate4.Text = _fish.Isdelete4 == 1 ? "有效" : "无效";
            cmbvalidate5.Text = _fish.Isdelete5 == 1 ? "有效" : "无效";

            ///----------------------------------------------------------
            ///
            ///
            if (_fish.FishMealState == rabDMS.Text)
            {
                rabDMS.Checked = true;
            }
            else if (_fish.FishMealState == rabKS.Text)
            {
                rabKS.Checked = true;
            }

            if (_fish.shrimpshell == rabXK.Text)
            {
                rabXK.Checked = true;
            }
            else
            {
                rabXK.Checked = false;
            }

            if (_fish.chromaticberration == rabSC.Text)
            {
                rabSC.Checked = true;
            }
            else
            {
                rabSC.Checked = false;
            }

            if (_fish.smell == rabQW.Text)
            {
                rabQW.Checked = true;
            }
            else
            {
                rabQW.Checked = false;
            }

            if (_fish.blackspot == rabHD.Text)
            {
                rabHD.Checked = true;
            }
            else
            {
                rabHD.Checked = false;
            }

            txtquote_protein.Text = _fish.quote_protein.ToString();
            txtquote_tvn.Text = _fish.quote_tvn.ToString();
            txtquote_sandsalt.Text = _fish.quote_sandsalt.ToString();
            txtquote_amine.Text = _fish.quote_amine.ToString();
            txtquote_ffa.Text = _fish.quote_ffa.ToString();
            txtquote_fat.Text = _fish.quote_fat.ToString();
            txtquote_water.Text = _fish.quote_water.ToString();
            txtquote_sand.Text = _fish.quote_sand.ToString();
            txtquote_graypart.Text = _fish.quote_graypart.ToString();
            txtRemarks.Text = _fish.remark.ToString();

            txtquality.Text = _fish.quality;
            txtsgs_amine.Text = _fish.sgs_amine.ToString();
            txtsgs_ffa.Text = _fish.sgs_ffa.ToString();
            txtsgs_fat.Text = _fish.sgs_fat.ToString();
            txtsgs_graypart.Text = _fish.sgs_graypart.ToString();
            txtsgs_protein.Text = _fish.sgs_protein.ToString();
            txtsgs_sand.Text = _fish.sgs_sand.ToString();
            txtsgs_sandsalt.Text = _fish.sgs_sandsalt.ToString();
            txtsgs_tvn.Text = _fish.sgs_tvn.ToString();
            txtsgs_water.Text = _fish.sgs_water.ToString();
            //----------------------------------------------------

            txtlabe_water.Text = _fish.labe_water.ToString();
            txtlabel_amine.Text = _fish.label_amine.ToString();
            txtlabel_fat.Text = _fish.label_fat.ToString();
            txtlabel_ffa.Text = _fish.label_ffa.ToString();
            txtlabel_graypart.Text = _fish.label_graypart.ToString();
            txtlabel_lysine.Text = _fish.label_lysine.ToString();
            txtlabel_methionine.Text = _fish.label_methionine.ToString();
            txtlabel_protein.Text = _fish.label_protein.ToString();
            txtlabel_sand.Text = _fish.label_sand.ToString();
            txtlabel_sandsalt.Text = _fish.label_sandsalt.ToString();
            txtlabel_tvn.Text = _fish.label_tvn.ToString();
            txtlabel_aminototal.Text = _fish.label_aminototal.ToString();
            //----------------------------------------------------

            txtdomestic_graypart.Text = _fish.domestic_graypart.ToString();
            txtdomestic_lysine.Text = _fish.domestic_lysine.ToString();
            txtdomestic_methionine.Text = _fish.domestic_methionine.ToString();
            txtdomestic_protein.Text = _fish.domestic_protein.ToString();
            txtdomestic_sandsalt.Text = _fish.domestic_sandsalt.ToString();
            txtdomestic_sour.Text = _fish.domestic_sour.ToString();
            txtdomestic_tvn.Text = _fish.domestic_tvn.ToString();
            txtdomestic_amine.Text = _fish.domestic_amine.ToString();
            txtdomestic_aminototal.Text = _fish.domestic_aminototal.ToString();
            txtdomestic_fat.Text = _fish.domestic_fat.ToString();
            txtdomestic_water.Text = _fish.domestic_water.ToString();
            txtdomestic_sand.Text = _fish.domestic_sand.ToString();
            txtdomestic_ffa.Text = _fish.domestic_ffa.ToString();
            SetFishEX();
        }
        public void SetFishEX() {
            if (_fishex==null)
            {
                return;
            }
            if (string.IsNullOrEmpty(_fishex.quotedate.Trim()) == false )
            {
                try
                {
                    dtpquotedate.CustomFormat = "yyyy.MM.dd";
                    dtpquotedate.Format = DateTimePickerFormat.Custom;
                    dtpquotedate.Text = _fishex.quotedate;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpquotedate.CustomFormat = " ";
                dtpquotedate.Format = DateTimePickerFormat.Custom;
            }
            if (string.IsNullOrEmpty(_fishex.quotesaildatefast.Trim()) == false)
            {
                try
                {
                    dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
                    dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
                    dtpquotesaildatefast.Text = _fishex.quotesaildatefast;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpquotesaildatefast.CustomFormat = " ";
                dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
            }

            txtquoteweight.Text = _fishex.quoteweight.ToString();
            txtquotedollars.Text = _fishex.quotedollars.ToString();
            txtquotEexchangeRate.Text = _fishex.quotEexchangeRate.ToString();
            txtquotermb.Text = _fishex.quotermb.ToString();
            txtquotesuppliercode.Text = _fishex.quotesupplier.ToString();
            txtquotesuppliercode.Tag = _fishex.quotesuppliercode.ToString();
            txtquotelinkman.Text = _fishex.quotelinkman.ToString();
            txtquotelinkman.Tag = _fishex.quotelinkmancode.ToString();
            txtquoteproductyear.Text = _fishex.quoteproductyear.ToString();
            txtquoteproductdate.Text = _fishex.quoteproductdate.ToString();
            if (string.IsNullOrEmpty(_fishex.quotesaildatelate.Trim()) == false)
            {
                try
                {
                    dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
                    dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
                    dtpquotesaildatelate.Text = _fishex.quotesaildatelate;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpquotesaildatelate.CustomFormat = " ";
                dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            }
            if (string.IsNullOrEmpty(_fishex.confirmarrivedate.Trim()) == false)
            {
                try
                {
                    dtpArriveDate.CustomFormat = "yyyy.MM.dd";
                    dtpArriveDate.Format = DateTimePickerFormat.Custom;
                    dtpArriveDate.Text = _fishex.confirmarrivedate;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpArriveDate.CustomFormat = " ";
                dtpArriveDate.Format = DateTimePickerFormat.Custom;
            }
            if (string.IsNullOrEmpty(_fishex.confirmsaildate.Trim()) == false)
            {
                try
                {
                    dtpconfirmsaildate.CustomFormat = "yyyy.MM.dd";
                    dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
                    dtpconfirmsaildate.Text = _fishex.confirmsaildate;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpconfirmsaildate.CustomFormat = " ";
                dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
            }
            if (string.IsNullOrEmpty(_fishex.confirmdate.Trim()) == false)
            {
                try
                {
                    dtpConfirmDate.CustomFormat = "yyyy.MM.dd";
                    dtpConfirmDate.Format = DateTimePickerFormat.Custom;
                    dtpConfirmDate.Text = _fishex.confirmdate;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpConfirmDate.CustomFormat = " ";
                dtpConfirmDate.Format = DateTimePickerFormat.Custom;
            }
            txtconfirmWeight.Text = _fishex.confirmWeight.ToString();
            txtConfirmdollars.Text = _fishex.confirmdollars.ToString();
            txtConfirmEexchangeRate.Text = _fishex.confirmEexchangeRate.ToString();
            txtConfirmrmb.Text = _fishex.confirmrmb.ToString();
            txtPlaceOfDelivery.Text = _fishex.PlaceOfDelivery;
            txtSgsWeight.Text = _fishex.confirmsgsweight.ToString();

            txtSgsQuantity.Text = _fishex.confirmsgsquantity;
            txtlife.Text = _fishex.spotlife;
            txtproductyear1.Text = _fishex.spotproductyear;
            txtproductdate1.Text = _fishex.spotproductdate;
            if (string.IsNullOrEmpty(_fishex.spotstoragedate.Trim()) == false)
            {
                try
                {
                    dtpdate.CustomFormat = "yyyy.MM.dd";
                    dtpdate.Format = DateTimePickerFormat.Custom;
                    dtpdate.Text = _fishex.spotstoragedate;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpdate.CustomFormat = " ";
                dtpdate.Format = DateTimePickerFormat.Custom;
            }
            if (string.IsNullOrEmpty(_fishex.Saletime.Trim()) == false)
            {
                try
                {
                    dtpSaletime.CustomFormat = "yyyy.MM.dd";
                    dtpSaletime.Format = DateTimePickerFormat.Custom;
                    dtpSaletime.Text = _fishex.Saletime;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpSaletime.CustomFormat = " ";
                dtpSaletime.Format = DateTimePickerFormat.Custom;
            }
            if (string.IsNullOrEmpty(_fishex.finishedtime.Trim()) == false)
            {
                try
                {
                    dtpfinishedtime.CustomFormat = "yyyy.MM.dd";
                    dtpfinishedtime.Format = DateTimePickerFormat.Custom;
                    dtpfinishedtime.Text = _fishex.finishedtime;
                }
                catch (Exception ex) { }

            }
            else
            {
                dtpfinishedtime.CustomFormat = " ";
                dtpfinishedtime.Format = DateTimePickerFormat.Custom;
            }
            dtpdate.Text = _fishex.spotstoragedate.ToString();
            dtpSaletime.Text = _fishex.Saletime.ToString();
            dtpfinishedtime.Text = _fishex.finishedtime.ToString();
            txtweight.Text = _fishex.spotweight.ToString();
            txtdollars.Text = _fishex.spotdollars.ToString();
            txtspotEexchangeRate.Text = _fishex.spotEexchangeRate.ToString();
            txtrmb.Text = _fishex.spotrmb.ToString();
            txtSaleWeight.Text = _fishex.saleremainweight.HasValue ? _fishex.saleremainweight.Value.ToString("f2") : "0.00";
            txtSaleRmb.Text = _fishex.salermb.ToString();
            txtSaleNumWeight.Text = _fishex.SaleNumWeight.ToString();
            txtfinisheNumber.Text = _fishex.finisheNumber.ToString();
            txtfinisheWeight.Text = _fishex.finisheWeight.ToString();
            txtspotagent.Text = _fishex.spotagent.ToString();
            txtspotagent.Tag = _fishex.spotagentcode.ToString();
            txtspotagentcode.Text = _fishex.spotlinkman.ToString();
            txtspotagentcode.Tag = _fishex.spotlinkmancode.ToString();
            txtSaleCompany.Text = _fishex.saletrader.ToString();
            txtSaleCompany.Tag = _fishex.saletradercode.ToString();
            txtSaleLinkman.Text = _fishex.salelinkman.ToString();
            txtSaleLinkman.Tag = _fishex.salelinkmancode.ToString();
            txtconfirmagent.Text = _fishex.confirmagent.ToString();
            txtconfirmagent.Tag = _fishex.confirmagentcode;
            txtconfirmagentcode.Text = _fishex.confirmlinkman;
            txtconfirmagentcode.Tag = _fishex.confirmlinkmancode;
            txtproductyear.Text = _fishex.confirmproductyear;
            txtproductdate.Text= _fishex.confirmproductdate;
            txtconfirmlife.Text = _fishex.confirmlife;
            //saletrader
           
            if (txtCode.Text.Contains("CP"))
            {
                ReadOnlytxt();
            }
        }
        public override int Add()
        {
            Clear();
            panel1.Enabled = true;
            return base.Add();
        }
        /// <summary>
        /// 清空
        /// </summary>
        public void Clear()
        {

            cmbvalidate.Text = "有效";
            cmbvalidate1.Text = "有效";
            cmbvalidate2.Text = "有效";
            cmbvalidate3.Text = "有效";
            cmbvalidate4.Text = "有效";
            cmbvalidate5.Text = "有效";

            txtCode.Text = cmbPort .Text=
                txtsalesman.Text =
                cmbName.Text =
                cmbgoodsinfo.Text =
                cmbCountry.Text =
                cmbSpecification.Text =
                cmbTechClass.Text =
                cmbFishType.Text =
                cmbpack.Text =
                txtquoteweight.Text=
                txtquotedollars.Text=
                txtquotEexchangeRate.Text=
                txtquotermb.Text=
                txtquotesuppliercode.Text=
                txtquotelinkman.Text=
                txtquoteproductyear.Text=
                txtquoteproductdate.Text=
                cmbBand.Text=
                txtwarehouse.Text=
                cmborigin.Text=
                txtrate.Text=
                cmbmanufacturers.Text=
                txtfactoryaddress.Text =
                txtshipno.Text =
                txtbillofgoods.Text=
                txtcornerno.Text=
                txtRemarks.Text=
                txtquote_protein.Text=
                txtquote_tvn.Text=
                txtquote_sandsalt.Text=
                txtquote_amine.Text=
                txtquote_ffa.Text=
                txtquote_fat.Text=
                txtquote_water.Text=
                txtquote_sand.Text=
                txtquote_graypart.Text=

                txtsgs_protein.Text=
                txtsgs_tvn.Text=
                txtsgs_sandsalt.Text=
                txtsgs_amine.Text=
                txtsgs_ffa.Text=
                txtsgs_fat.Text=
                txtconfirmlife.Text=
                txtsgs_water.Text=
                txtsgs_sand.Text=
                txtsgs_graypart.Text=
                txtSgsWeight.Text=
                txtSgsQuantity.Text=
                txtproductyear.Text=
                txtproductdate.Text=

                txtlabel_protein.Text=
                txtlabel_tvn.Text=
                txtlabel_sandsalt.Text=
                txtlabel_amine.Text=
                txtlabel_ffa.Text=
                txtlabel_fat.Text=
                txtlife.Text=
                txtlabe_water.Text=
                txtlabel_sand.Text=
                txtlabel_graypart.Text=
                txtlabel_lysine.Text=
                txtlabel_methionine.Text=
                txtlabel_aminototal.Text=
                txtproductyear1.Text=
                txtproductdate1.Text=

                txtdomestic_protein.Text=
                txtdomestic_tvn.Text=
                txtdomestic_sandsalt.Text=
                txtdomestic_amine.Text=
                txtdomestic_ffa.Text=
                txtdomestic_fat.Text=
                txtdomestic_sour.Text=
                txtdomestic_water.Text=
                txtdomestic_sand.Text=
                txtdomestic_graypart.Text=
                txtdomestic_lysine.Text=
                txtdomestic_methionine.Text=
                txtdomestic_aminototal.Text=
                txtconfirmWeight.Text=
                txtConfirmdollars.Text=
                txtConfirmEexchangeRate.Text=
                txtConfirmrmb.Text= 
                txtPlaceOfDelivery.Text=
                txtweight.Text=
                txtdollars.Text=
                txtspotEexchangeRate.Text=
                txtrmb.Text=
                txtSaleWeight.Text=
                txtSaleRmb.Text=
                txtSaleNumWeight.Text= txtfinisheWeight.Text= txtfinisheNumber.Text=
                txtquality.Text=
                txtconfirmagent.Text=
                txtconfirmagentcode.Text=
                txtspotagent.Text=
                txtspotagentcode.Text=
                txtSaleCompany.Text=
                txtSaleLinkman.Text=
                string.Empty;
            cmbCountry.SelectedValue = string.Empty;
            cmbBand.DataSource = null;
            cmbBand.SelectedValue = string.Empty;
            dtpgetinfotime.Text =
            dtpdate.Text =
            dtpSaletime.Text=
            dtpConfirmDate.Text =
            dtpArriveDate.Text =
            dtpconfirmsaildate.Text =
            dtpendinfotime.Text =
            dtpquotedate.Text =
            dtpquotesaildatefast.Text =
            dtpquotesaildatelate.Text =string.Empty;
            dtpquotedate.CustomFormat = "yyyy.MM.dd";
            dtpquotedate.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatefast.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatefast.Format = DateTimePickerFormat.Custom;
            dtpquotesaildatelate.CustomFormat = "yyyy.MM.dd";
            dtpquotesaildatelate.Format = DateTimePickerFormat.Custom;
            dtpArriveDate.CustomFormat = "yyyy.MM.dd";
            dtpArriveDate.Format = DateTimePickerFormat.Custom;
            dtpconfirmsaildate.CustomFormat = "yyyy.MM.dd";
            dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
            dtpConfirmDate.CustomFormat = "yyyy.MM.dd";
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;
            dtpdate.CustomFormat = "yyyy.MM.dd";
            dtpdate.Format = DateTimePickerFormat.Custom;
            dtpSaletime.CustomFormat = "yyyy.MM.dd";
            dtpSaletime.Format = DateTimePickerFormat.Custom;
            dtpfinishedtime.CustomFormat = "yyyy.MM.dd";
            dtpfinishedtime.Format = DateTimePickerFormat.Custom;
            rabDMS.Checked =
                rabKS.Checked =
                rabXK.Checked=
                rabSC.Checked=
                rabQW.Checked=
                rabHD.Checked=
                false;

            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiDelete.Visible = false;

            _formSGS = null;
            _formLabel = null;
            _formGJ = null;
            _formQuote = null;

            panel1.Enabled = true;
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
                MessageBox.Show("请先选择单位,再操作。");
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

        private void txtconfirmagent_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtconfirmagent.Text = form.SelectCompany.fullname;
            txtconfirmagent.Tag = form.SelectCompany.code;

            txtconfirmagentcode.Text = string.Empty;
            txtconfirmagentcode.Tag = string.Empty;
        }

        private void txtconfirmagentcode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtconfirmagent.Text) == true)
            {
                MessageBox.Show("请先选择开证代理商,再操作。");
                return;
            }
            if (txtconfirmagentcode.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtconfirmagent.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtconfirmagentcode.Text = customer.name;
                    txtconfirmagentcode.Tag = customer.code;
                }
            }
        }

        private void txtspotagent_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtspotagent.Text = form.SelectCompany.fullname;
            txtspotagent.Tag = form.SelectCompany.code;

            txtspotagentcode.Text = string.Empty;
            txtspotagentcode.Tag = string.Empty;
        }

        private void txtspotagentcode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtspotagent.Text) == true)
            {
                MessageBox.Show("请先选择开证单位,再操作。");
                return;
            }
            if (txtspotagent.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtspotagent.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtspotagentcode.Text = customer.name;
                    txtspotagentcode.Tag = customer.code;
                }
            }
        }

        private void txtSelfCompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSaleCompany.Text = form.SelectCompany.fullname;
            txtSaleCompany.Tag = form.SelectCompany.code;

            txtSaleLinkman.Text = string.Empty;
            txtSaleLinkman.Tag = string.Empty;
        }

        private void txtSelfLinkman_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSaleCompany.Text) == true)
            {
                MessageBox.Show("请先选择现货货主,再操作。");
                return;
            }
            if (txtSaleCompany.Tag == null) return;
            string companycode = string.Empty;
            companycode = txtSaleCompany.Tag.ToString();
            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companycode);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtSaleLinkman.Text = customer.name;
                    txtSaleLinkman.Tag = customer.code;
                }
            }
        }
        public override int Delete()
        {
            _bll = new FishBll.Bll.ProductBll();
            _bllex = new FishBll.Bll.ProductExBll();
            if (_fish == null) return 0;

            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan)
             && false == FishEntity.Variable.User.username.Equals(_fish.createman))
            {
                MessageBox.Show("对不起，您不能删除别人创建的鱼粉资料！");
                return 0;
            }

            string fishid = _fish.code;
            if (MessageBox.Show("您确定要删除的【" + fishid + "】鱼粉信息吗?", "询问", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.Cancel) return 0;

            bool isok1 = _bll.Delete(_fish.id);
            bool isok2 = _bllex.Delete(_fish.id);
            if (isok1 == false && isok2 == false)
            {
                MessageBox.Show("删除鱼粉信息失败。");
            }
            else
            {
                MessageBox.Show("删除鱼粉信息成功。");

                _fish = null;

                Next();
            }

            return base.Delete();
        }
        public override void Next()
        {
            QueryOne(" > ", " order by id asc limit 1");
            checkTrueOrFalse(); checklable(); 
        }

        public override void Previous()
        {
            QueryOne(" < ", " order by id desc limit 1");
            checkTrueOrFalse(); checklable();
        }
        public bool Check()
        {
            errorProvider1.Clear();

            bool isok = true;
            //if (checkBox7.Checked == true)
            //{
            //    if (txtSelfCompany.Text == null || string.IsNullOrEmpty(txtSelfCompany.Text.ToString()))
            //    {
            //        errorProvider1.SetError(txtSelfCompany, "单位必填");
            //        isok = false;
            //    }
            //    if (txtSelfCompany.Text == null || string.IsNullOrEmpty(txtSelfCompany.Text.ToString()))
            //    {
            //        errorProvider1.SetError(txtSelfCompany, "单位必填");
            //        isok = false;
            //    }
            //}
            //bool iss = true;
            if (cmbName.SelectedValue == null || string.IsNullOrEmpty(cmbName.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbName, "请选择品名");
                isok = false;
            }

            if (cmbCountry.SelectedValue == null || string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbCountry, "请选择国别");
                isok = false;
            }
            //if (cmbPort.SelectedValue == null || string.IsNullOrEmpty(cmbPort.SelectedValue.ToString()))
            //{
            //    errorProvider1.SetError(cmbPort, "请选择港口");
            //    isok = false;
            //}
            //if (cmbBand.SelectedValue == null||string.IsNullOrEmpty(cmbBand.SelectedValue.ToString()))
            //{
            //    errorProvider1.SetError(cmbBand, "请选择品牌");
            //    isok = false;
            //}
            if (cmbSpecification.SelectedValue == null || string.IsNullOrEmpty(cmbSpecification.SelectedValue.ToString()))
            {
                errorProvider1.SetError(cmbSpecification, "请选择品质");
                isok = false;
            }

            return isok;
        }
        public override void Cancel()
        {
            errorProvider1.Clear();
            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiDelete.Visible = true;

            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;

            ControlButtomRoles();

            panel1.Enabled = false;
        }
        protected void QueryOne(string operate, string orderBy)
        {
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if (_fish != null)
            {
                whereEx += " and code " + operate + _fish.code;
            }
            _bll = new FishBll.Bll.ProductBll();
            List<FishEntity.ProductEntity> list = _bll.GetModelList(whereEx + orderBy);
            if (list == null && list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _fish = list[0];
            _bllex = new FishBll.Bll.ProductExBll();
            _fishex = _bllex.GetModel(_fish.id);
            SetFish();
            panel1.Enabled = true;
        }
        
        private void btnquotequery_Click(object sender, EventArgs e)
        {
            if (_fishex == null) return;
            FormQuoteDetail form = new FormQuoteDetail(_fishex.id);
            form.ShowMenu(true);
            form.Text = "报盘价格查询";
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }
        protected void AddImages(FishEntity.ProductEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();

            if (fish.id > 0)
            {
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.SGS);
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.Label);
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.GJ);
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.QUOTE);
            }

            List<FishEntity.ImageEntity> images = GetQuoteImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }

            images = GetSGSImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }

            images = GetLabelImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }

            images = GetGJImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = fish.createman;
                    item.createtime = fish.createtime;
                    bll.Add(item);
                }
            }
        }


        protected void AddImages1(FishEntity.ProductEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageS_Bll bll = new FishBll.Bll.ImageS_Bll();

            //if (fish.id > 0)
            //{
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.SGS);
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.Label);
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.GJ);
            //    bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.QUOTE);
            //}

            List<FishEntity.t_image_S> images = GetQuoteImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;

                    //item.createman = fish.createman;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }

            images = GetSGSImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;
                    //item.createman = fish.createman;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }

            images = GetLabelImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }

            images = GetGJImages1();
            if (images != null)
            {
                foreach (FishEntity.t_image_S item in images)
                {
                    item.Fid1 = fish.id;
                    //item.createman = fish.createman;
                    item.Date_ = fish.createtime;
                    bll.Add(item);
                }
            }
        }
        public List<FishEntity.ImageEntity> GetQuoteImages()
        {
            if (_formQuote == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formQuote.Image1 != null && _formQuote.Image1.image != null) images.Add(_formQuote.Image1);
            if (_formQuote.Image2 != null && _formQuote.Image2.image != null) images.Add(_formQuote.Image2);
            if (_formQuote.Image3 != null && _formQuote.Image3.image != null) images.Add(_formQuote.Image3);

            return images;
        }

        public List<FishEntity.ImageEntity> GetSGSImages()
        {
            if (_formSGS == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formSGS.Image1 != null && _formSGS.Image1.image != null) images.Add(_formSGS.Image1);
            if (_formSGS.Image2 != null && _formSGS.Image2.image != null) images.Add(_formSGS.Image2);
            if (_formSGS.Image3 != null && _formSGS.Image3.image != null) images.Add(_formSGS.Image3);

            return images;
        }

        public List<FishEntity.ImageEntity> GetLabelImages()
        {
            if (_formLabel == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formLabel.Image1 != null && _formLabel.Image1.image != null) images.Add(_formLabel.Image1);
            if (_formLabel.Image2 != null && _formLabel.Image2.image != null) images.Add(_formLabel.Image2);
            if (_formLabel.Image3 != null && _formLabel.Image3.image != null) images.Add(_formLabel.Image3);

            return images;
        }

        public List<FishEntity.ImageEntity> GetGJImages()
        {
            if (_formGJ == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (_formGJ.Image1 != null && _formGJ.Image1.image != null) images.Add(_formGJ.Image1);
            if (_formGJ.Image2 != null && _formGJ.Image2.image != null) images.Add(_formGJ.Image2);
            if (_formGJ.Image3 != null && _formGJ.Image3.image != null) images.Add(_formGJ.Image3);

            return images;
        }

        public List<FishEntity.t_image_S> GetQuoteImages1()
        {
            if (_formQuote == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formQuote.img1 != null && _formQuote.img1.Image_name1 != null) images.Add(_formQuote.img1);
            if (_formQuote.img2 != null && _formQuote.img2.Image_name1 != null) images.Add(_formQuote.img2);
            if (_formQuote.img3 != null && _formQuote.img3.Image_name1 != null) images.Add(_formQuote.img3);

            return images;
        }

        public List<FishEntity.t_image_S> GetSGSImages1()
        {////////////////////////////////////////////////////////////////
            if (_formSGS == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formSGS.img1 != null && _formSGS.img1.Image_name1 != null) images.Add(_formSGS.img1);
            if (_formSGS.img2 != null && _formSGS.img2.Image_name1 != null) images.Add(_formSGS.img2);
            if (_formSGS.img3 != null && _formSGS.img3.Image_name1 != null) images.Add(_formSGS.img3);

            return images;
        }

        public List<FishEntity.t_image_S> GetLabelImages1()
        {
            if (_formLabel == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formLabel.img1 != null && _formLabel.img1.Image_name1 != null) images.Add(_formLabel.img1);
            if (_formLabel.img2 != null && _formLabel.img2.Image_name1 != null) images.Add(_formLabel.img2);
            if (_formLabel.img3 != null && _formLabel.img3.Image_name1 != null) images.Add(_formLabel.img3);

            return images;
        }

        public List<FishEntity.t_image_S> GetGJImages1()
        {
            if (_formGJ == null) return null;
            List<FishEntity.t_image_S> images = new List<FishEntity.t_image_S>();

            if (_formGJ.img1 != null && _formGJ.img1.Image_name1 != null) images.Add(_formGJ.img1);
            if (_formGJ.img2 != null && _formGJ.img2.Image_name1 != null) images.Add(_formGJ.img2);
            if (_formGJ.img3 != null && _formGJ.img3.Image_name1 != null) images.Add(_formGJ.img3);

            return images;
        }
        private void LoadImage()
        {
            btnquotequery.DrawType = UILibrary.DrawStyle.Img;


            string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            if (File.Exists(imagePath))
            {
                btnquotequery.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            if (File.Exists(downPath))
            {
                btnquotequery.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            if (File.Exists(hoverPath))
            {
                btnquotequery.MouseBack = Image.FromFile(hoverPath);
            }
        }

        private void btnQuote_Click(object sender, EventArgs e)
        {
            if (_formQuote == null)
            {
                _formQuote = new FormImage(0, FishEntity.ImageTypeEnum.QUOTE);
            }

            _formQuote.SetData(_fish == null ? 0 : _fish.id, FishEntity.ImageTypeEnum.QUOTE);

            _formQuote.StartPosition = FormStartPosition.CenterParent;
            if (_formQuote.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btnSGS_Click(object sender, EventArgs e)
        {
            if (_formSGS == null)
            {
                _formSGS = new FormImage(0, FishEntity.ImageTypeEnum.SGS);
            }

            _formSGS.SetData(_fish == null ? 0 : _fish.id, FishEntity.ImageTypeEnum.SGS);

            _formSGS.StartPosition = FormStartPosition.CenterParent;
            if (_formSGS.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btnlabel_Click(object sender, EventArgs e)
        {
            if (_formLabel == null)
            {
                _formLabel = new FormImage(0, FishEntity.ImageTypeEnum.Label);
            }

            _formLabel.SetData(_fish == null ? 0 : _fish.id, FishEntity.ImageTypeEnum.Label);

            _formLabel.StartPosition = FormStartPosition.CenterParent;
            if (_formLabel.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void btncheck_Click(object sender, EventArgs e)
        {
            if (_fish == null && _fish.id < 1)
            {
                MessageBox.Show("还没有检测数据。");
                return;
            }
            FormCheck formcheck = new FormCheck(_fish.id, _fish.code, _fish.name);
            formcheck.MenuCode = "M112";
            formcheck.RefreshDataEvent += formcheck_RefreshDataEvent;
            formcheck.ShowInTaskbar = false;
            formcheck.ShowDialog();
            return;
            UIForms.FormGBList form = new UIForms.FormGBList(_fish.id);
            form.ShowDialog();
            return;
            if (ClickGBEvent != null)
            {
                ClickGBEvent(this, EventArgs.Empty);
            }
        }
        void formcheck_RefreshDataEvent(object sender, EventArgs e)
        {
            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, EventArgs.Empty);
            }
        }

        private void btngj_Click(object sender, EventArgs e)
        {
            if (_formGJ == null)
            {
                _formGJ = new FormImage(0, FishEntity.ImageTypeEnum.GJ);
            }

            _formGJ.SetData(_fish == null ? 0 : _fish.id, FishEntity.ImageTypeEnum.GJ);

            _formGJ.StartPosition = FormStartPosition.CenterParent;
            if (_formGJ.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                panel11.Visible = true;
            }
            else if(checkBox1.Checked==false)
            {
                panel11.Visible = false;
            }
        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                panel13.Visible = true;
            }
            else if (checkBox2.Checked == false)
            {
                panel13.Visible = false;
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                panel14.Visible = true;
            }
            else if (checkBox3.Checked == false)
            {
                panel14.Visible = false;
            }
        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                panel15.Visible = true;
            }
            else if (checkBox4.Checked == false)
            {
                panel15.Visible = false;
            }
        }

        private void checkBox5_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                panel16.Visible = true;
            }
            else if (checkBox5.Checked == false)
            {
                panel16.Visible = false;
            }
        }

        private void checkBox6_Click(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                panel17.Visible = true;
            }
            else if (checkBox6.Checked == false)
            {
                panel17.Visible = false;
            }
        }

        private void checkBox7_Click(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                panel19.Visible = true;
            }
            else if (checkBox7.Checked == false)
            {
                panel19.Visible = false;
            }
        }

        private void checkBox8_Click(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                panel20.Visible = true;
            }
            else if (checkBox8.Checked == false)
            {
                panel20.Visible = false;
            }
        }
        public void checklable() {
            if (checkBox1.Checked == true)
            {
                panel11.Visible = true;
            }
            else if (checkBox1.Checked == false)
            {
                panel11.Visible = false;
            }
            if (checkBox2.Checked == true)
            {
                panel13.Visible = true;
            }
            else if (checkBox2.Checked == false)
            {
                panel13.Visible = false;
            }
            if (checkBox3.Checked == true)
            {
                panel14.Visible = true;
            }
            else if (checkBox3.Checked == false)
            {
                panel14.Visible = false;
            }
            if (checkBox4.Checked == true)
            {
                panel15.Visible = true;
            }
            else if (checkBox4.Checked == false)
            {
                panel15.Visible = false;
            }
            if (checkBox5.Checked == true)
            {
                panel16.Visible = true;
            }
            else if (checkBox5.Checked == false)
            {
                panel16.Visible = false;
            }
            if (checkBox6.Checked == true)
            {
                panel17.Visible = true;
            }
            else if (checkBox6.Checked == false)
            {
                panel17.Visible = false;
            }
            if (checkBox7.Checked == true)
            {
                panel19.Visible = true;
            }
            else if (checkBox7.Checked == false)
            {
                panel19.Visible = false;
            }
            if (checkBox8.Checked == true)
            {
                panel20.Visible = true;
            }
            else if (checkBox8.Checked == false)
            {
                panel20.Visible = false;
            }
            if (!FishEntity.Variable.User.roletype.Contains("业务主管"))
            {
                panel9.Visible = false;
                panel17.Visible = false;

                panel10.Visible = false;
                panel19.Visible = false;

                panel18.Visible = false;
                panel20.Visible = false;

                panel12.Visible = false;
                panel21.Visible = false;
            }
        }

        public void checkTrueOrFalse() {
            checkBox1.Checked = false;
            checkBox1.ForeColor = Color.Black;
            if (txtquoteweight.Text!=""&& txtquoteweight.Text!=null&& decimal.Parse(txtquoteweight.Text)!=0)
            {
                checkBox1.Checked = true; 
                checkBox1.ForeColor = Color.Blue;
            }
            else if (txtquotedollars.Text != "" && txtquotedollars.Text != null && decimal.Parse(txtquotedollars.Text) != 0) 
            {
                checkBox1.Checked = true; 
                checkBox1.ForeColor = Color.Blue;
            }
            else if (txtquotEexchangeRate.Text != "" && txtquotEexchangeRate.Text != null&& decimal.Parse(txtquotEexchangeRate.Text) != 0) 
            {
                checkBox1.Checked = true; 
                checkBox1.ForeColor = Color.Blue;
            }
            else if (txtquotermb.Text != "" && txtquotermb.Text != null && decimal.Parse(txtquotermb.Text) != 0) 
            {
                checkBox1.Checked = true; 
                checkBox1.ForeColor = Color.Blue;
            }
            else if (txtquoteproductdate.Text != "" && txtquoteproductdate.Text != null)
            {
                checkBox1.Checked = true; 
                checkBox1.ForeColor = Color.Blue;
            }
            ///////////////////////////////////////////////////////////
            checkBox2.Checked = false;
            checkBox2.ForeColor = Color.Black;
            if (cmbBand.Text != "" && cmbBand.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtwarehouse.Text != "" && txtwarehouse.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (cmborigin.Text != "" && cmborigin.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtrate.Text != "" && txtrate.Text != null && decimal.Parse(txtrate.Text) != 0) 
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (cmbmanufacturers.Text != "" && cmbmanufacturers.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtfactoryaddress.Text != "" && txtfactoryaddress.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtshipno.Text != "" && txtshipno.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtbillofgoods.Text != "" && txtbillofgoods.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtcornerno.Text != "" && txtcornerno.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            else if (txtquality.Text != "" && txtquality.Text != null)
            {
                checkBox2.Checked = true;  
                checkBox2.ForeColor = Color.Blue;
            }
            ////////////////////////////////////////////////////////////////////////
            checkBox3.Checked = false;
            checkBox3.ForeColor = Color.Black;
            if (txtsgs_protein.Text != "" && txtsgs_protein.Text != null && decimal.Parse(txtsgs_protein.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_tvn.Text != "" && txtsgs_tvn.Text != null && decimal.Parse(txtsgs_tvn.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_sandsalt.Text != "" && txtsgs_sandsalt.Text != null && decimal.Parse(txtsgs_sandsalt.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_amine.Text != "" && txtsgs_amine.Text != null && decimal.Parse(txtsgs_amine.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_ffa.Text != "" && txtsgs_ffa.Text != null && decimal.Parse(txtsgs_ffa.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_fat.Text != "" && txtsgs_fat.Text != null && decimal.Parse(txtsgs_fat.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtconfirmlife.Text != "" && txtconfirmlife.Text != null && decimal.Parse(txtconfirmlife.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_water.Text != "" && txtsgs_water.Text != null && decimal.Parse(txtsgs_water.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_sand.Text != "" && txtsgs_sand.Text != null && decimal.Parse(txtsgs_sand.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtsgs_graypart.Text != "" && txtsgs_graypart.Text != null && decimal.Parse(txtsgs_graypart.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtSgsWeight.Text != "" && txtSgsWeight.Text != null && decimal.Parse(txtSgsWeight.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtSgsQuantity.Text != "" && txtSgsQuantity.Text != null && decimal.Parse(txtSgsQuantity.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtproductyear.Text != "" && txtproductyear.Text != null )
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            else if (txtproductdate.Text != "" && txtproductdate.Text != null && decimal.Parse(txtproductdate.Text) != 0)
            {
                checkBox3.Checked = true;
                checkBox3.ForeColor = Color.Blue;
            }
            ////////////////////////////////////////////////////////////////////////////////
            checkBox4.Checked = false;
            checkBox4.ForeColor = Color.Black;
            if (txtlabel_protein.Text != "" && txtlabel_protein.Text != null && decimal.Parse(txtlabel_protein.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_tvn.Text != "" && txtlabel_tvn.Text != null && decimal.Parse(txtlabel_tvn.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_sandsalt.Text != "" && txtlabel_sandsalt.Text != null && decimal.Parse(txtlabel_sandsalt.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_amine.Text != "" && txtlabel_amine.Text != null && decimal.Parse(txtlabel_amine.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_ffa.Text != "" && txtlabel_ffa.Text != null && decimal.Parse(txtlabel_ffa.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_fat.Text != "" && txtlabel_fat.Text != null && decimal.Parse(txtlabel_fat.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlife.Text != "" && txtlife.Text != null)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabe_water.Text != "" && txtlabe_water.Text != null && decimal.Parse(txtlabe_water.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_sand.Text != "" && txtlabel_sand.Text != null && decimal.Parse(txtlabel_sand.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_graypart.Text != "" && txtlabel_graypart.Text != null && decimal.Parse(txtlabel_graypart.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_lysine.Text != "" && txtlabel_lysine.Text != null && decimal.Parse(txtlabel_lysine.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_methionine.Text != "" && txtlabel_methionine.Text != null && decimal.Parse(txtlabel_methionine.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtlabel_aminototal.Text != "" && txtlabel_aminototal.Text != null && decimal.Parse(txtlabel_aminototal.Text) != 0)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtproductyear1.Text != "" && txtproductyear1.Text != null)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            else if (txtproductdate1.Text != "" && txtproductdate1.Text != null)
            {
                checkBox4.Checked = true;
                checkBox4.ForeColor = Color.Blue;
            }
            ///////////////////////////////////////////////////////////////////////////////////////
            checkBox5.Checked = false;
            checkBox5.ForeColor = Color.Black;
            if (txtdomestic_protein.Text != "" && txtdomestic_protein.Text != null && decimal.Parse(txtdomestic_protein.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_tvn.Text != "" && txtdomestic_tvn.Text != null && decimal.Parse(txtdomestic_tvn.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_sandsalt.Text != "" && txtdomestic_sandsalt.Text != null && decimal.Parse(txtdomestic_sandsalt.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_amine.Text != "" && txtdomestic_amine.Text != null && decimal.Parse(txtdomestic_amine.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_ffa.Text != "" && txtdomestic_ffa.Text != null && decimal.Parse(txtdomestic_ffa.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_fat.Text != "" && txtdomestic_fat.Text != null && decimal.Parse(txtdomestic_fat.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_sour.Text != "" && txtdomestic_sour.Text != null && decimal.Parse(txtdomestic_sour.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_water.Text != "" && txtdomestic_water.Text != null && decimal.Parse(txtdomestic_water.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_sand.Text != "" && txtdomestic_sand.Text != null && decimal.Parse(txtdomestic_sand.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_graypart.Text != "" && txtdomestic_graypart.Text != null && decimal.Parse(txtdomestic_graypart.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_lysine.Text != "" && txtdomestic_lysine.Text != null && decimal.Parse(txtdomestic_lysine.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_methionine.Text != "" && txtdomestic_methionine.Text != null && decimal.Parse(txtdomestic_methionine.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            else if (txtdomestic_aminototal.Text != "" && txtdomestic_aminototal.Text != null && decimal.Parse(txtdomestic_aminototal.Text) != 0)
            {
                checkBox5.Checked = true;
                checkBox5.ForeColor = Color.Blue;
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            checkBox6.Checked = false;
            checkBox6.ForeColor = Color.Black;
            if (txtconfirmWeight.Text != "" && txtconfirmWeight.Text != null && decimal.Parse(txtconfirmWeight.Text) != 0)
            {
                checkBox6.Checked = true;
                checkBox6.ForeColor = Color.Blue;
            }
            else if (txtConfirmdollars.Text != "" && txtConfirmdollars.Text != null && decimal.Parse(txtConfirmdollars.Text) != 0)
            {
                checkBox6.Checked = true;
                checkBox6.ForeColor = Color.Blue;
            }
            else if (txtConfirmEexchangeRate.Text != "" && txtConfirmEexchangeRate.Text != null && decimal.Parse(txtConfirmEexchangeRate.Text) != 0)
            {
                checkBox6.Checked = true;
                checkBox6.ForeColor = Color.Blue;
            }
            else if (txtConfirmrmb.Text != "" && txtConfirmrmb.Text != null && decimal.Parse(txtConfirmrmb.Text) != 0)
            {
                checkBox6.Checked = true;
                checkBox6.ForeColor = Color.Blue;
            }
            else if (txtPlaceOfDelivery.Text != "" && txtPlaceOfDelivery.Text != "")
            {
                checkBox6.Checked = true;
                checkBox6.ForeColor = Color.Blue;
            }
            /////////////////////////////////////////////////////////////////////////
            checkBox7.Checked = false;
            checkBox7.ForeColor = Color.Black;
            if (txtweight.Text != "" && txtweight.Text != null && decimal.Parse(txtweight.Text) != 0)
            {
                checkBox7.Checked = true;
                checkBox7.ForeColor = Color.Blue;
            }
            else if (txtdollars.Text != "" && txtdollars.Text != null && decimal.Parse(txtdollars.Text) != 0)
            {
                checkBox7.Checked = true;
                checkBox7.ForeColor = Color.Blue;
            }
            else if (txtspotEexchangeRate.Text != "" && txtspotEexchangeRate.Text != null && decimal.Parse(txtspotEexchangeRate.Text) != 0)
            {
                checkBox7.Checked = true;
                checkBox7.ForeColor = Color.Blue;
            }
            else if (txtrmb.Text != "" && txtrmb.Text != null && decimal.Parse(txtrmb.Text) != 0)
            {
                checkBox7.Checked = true;
                checkBox7.ForeColor = Color.Blue;
            }
            ////////////////////////////////////////////////////////////////
            checkBox8.Checked = false;
            checkBox8.ForeColor = Color.Black;
            if (txtSaleWeight.Text != "" && txtSaleWeight.Text != null && decimal.Parse(txtSaleWeight.Text) != 0)
            {
                checkBox8.Checked = true;
                checkBox8.ForeColor = Color.Blue;
            }
            else if (txtSaleRmb.Text != "" && txtSaleRmb.Text != null && decimal.Parse(txtSaleRmb.Text) != 0)
            {
                checkBox8.Checked = true;
                checkBox8.ForeColor = Color.Blue;
            }
            else if (txtSaleNumWeight.Text != "" && txtSaleNumWeight.Text != null && decimal.Parse(txtSaleNumWeight.Text) != 0)
            {
                checkBox8.Checked = true;
                checkBox8.ForeColor = Color.Blue;
            }
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

        private void dtpArriveDate_ValueChanged(object sender, EventArgs e)
        {
            dtpArriveDate.CustomFormat = "yyyy.MM.dd";
            dtpArriveDate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpconfirmsaildate_ValueChanged(object sender, EventArgs e)
        {
            dtpconfirmsaildate.CustomFormat = "yyyy.MM.dd";
            dtpconfirmsaildate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpConfirmDate_ValueChanged(object sender, EventArgs e)
        {
            dtpConfirmDate.CustomFormat = "yyyy.MM.dd";
            dtpConfirmDate.Format = DateTimePickerFormat.Custom;
        }

        private void dtpdate_ValueChanged(object sender, EventArgs e)
        {
            dtpdate.CustomFormat = "yyyy.MM.dd";
            dtpdate.Format = DateTimePickerFormat.Custom;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void skinButtom1_Click(object sender, EventArgs e)
        {
            if (_fishex == null) return;
            FormSaleDetail form = new FormSaleDetail(_fishex.id);
            //form.ShowMenu(true);
            form.Text = "销售价格查询";
            form.ShowInTaskbar = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void dtpSaletime_ValueChanged(object sender, EventArgs e)
        {
            dtpSaletime.CustomFormat = "yyyy.MM.dd";
            dtpSaletime.Format = DateTimePickerFormat.Custom;
        }

        private void dtpfinishedtime_ValueChanged(object sender, EventArgs e)
        {
            dtpfinishedtime.CustomFormat = "yyyy.MM.dd";
            dtpfinishedtime.Format = DateTimePickerFormat.Custom;
        }
    }
}
