using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FishClient
{
    //table:t_purchaseApplication/t_purchaseFishInfo/t_purchaseOtherInfo
    //M488
    public partial class FormPurchaseApplication : FormMenuBase
    {
        FishEntity.PurchaseApplicationEntity _model = null;
        FishEntity.PurchaseFishInfo _fishInfo = null;
        FishEntity.PurchaseOtherInfo _otherInfo = null;
        FishBll.Bll.PurchaseApplicationBll _bll = null;
        List<FishEntity.PurchaseOtherInfo> listOtherInfo = null;
        List<FishEntity.PurchaseFishInfo> listfishInfo = null;
        bool result = false; decimal outResult = 0M;
        string strWhere = string.Empty;
        
        bool isOk = false;
        public FormPurchaseApplication()
        {
            InitializeComponent();
            this.tmiPrevious.Visible = false;
            this.tmiNext.Visible = false;
            this.panel1.Enabled = false;

            //InitDataUtil.BindComboBoxData(txtproName, FishEntity.Constant.Goods, true);
            InitDataUtil . BindComboBoxData ( txtbrands ,FishEntity . Constant . Specification ,true );
            InitDataUtil . BindComboBoxData ( txtvarieties ,FishEntity . Constant . Goods ,true );
            InitDataUtil . BindComboBoxData ( txtcountry ,FishEntity . Constant . CountryType ,true );
        }
        string getname = string.Empty;
        public FormPurchaseApplication(string name)
        {
            InitializeComponent();
            this.tmiPrevious.Visible = false;
            this.tmiNext.Visible = false;
            this.panel1.Enabled = false;
            getname = name;
            //InitDataUtil.BindComboBoxData(txtproName, FishEntity.Constant.Goods, true);
            InitDataUtil.BindComboBoxData(txtbrands, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(txtvarieties, FishEntity.Constant.Goods, true);
            InitDataUtil.BindComboBoxData(txtcountry, FishEntity.Constant.CountryType, true);

        }

        private void FormPurchaseApplication_Load(object sender, EventArgs e)
        {
            this.tmiPrevious.Visible = false;
            this.tmiNext.Visible = false;
            if (Megres.oddNum != "")
            {
                _model = new FishEntity.PurchaseApplicationEntity();
                _bll = new FishBll.Bll.PurchaseApplicationBll();
                _fishInfo = new FishEntity.PurchaseFishInfo();
                _otherInfo = new FishEntity.PurchaseOtherInfo();
                strWhere = " codeNum='" + Megres.oddNum + "'";
                _model = _bll.getModel(strWhere);
                if (_model == null)
                {
                    MessageBox.Show("请重新查询");
                    this.panel1.Enabled = false;
                    return ;
                }
                setValue();
                //if (string.IsNullOrEmpty(_model.codeNum))
                //    return ;
                //List<FishEntity.PurchaseFishInfo> listFishInfo = _bll.getFishInfoList(_model.codeNum);
                //if (listFishInfo != null && listFishInfo.Count > 0)
                //    setValueFishInfo(listFishInfo);
                this.panel1.Enabled = true;
            }
            else
                strWhere = string.Empty;
            //权限控制功能。
            Megres.oddNum = string.Empty;
        }

        #region Main
        public override int Query()
        {
            UIForms.PurchaseApplicationCondition form = new UIForms.PurchaseApplicationCondition(this.Text + "查询");
            this.panel1.Enabled = true;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = new FishEntity.PurchaseApplicationEntity();_bll = new FishBll.Bll.PurchaseApplicationBll();
                strWhere = form.getStrWhere;
                _model = _bll.getModel(strWhere);
                if (_model == null)
                {
                    MessageBox.Show("请重新查询");
                    this.panel1.Enabled = false;
                    return 0;
                }
                setValue();
                //if (string.IsNullOrEmpty(_model.codeNum))
                //    return 0;
                //List<FishEntity.PurchaseFishInfo> listFishInfo = _bll.getFishInfoList(_model.codeNum);
                //if (listFishInfo != null && listFishInfo.Count > 0)
                //    setValueFishInfo(listFishInfo);
                //List<FishEntity . PurchaseOtherInfo> listOtherInfo = _bll . getOtherInfoList ( _model . codeNum );
                //if ( listOtherInfo != null && listOtherInfo . Count > 0 )
                //    setValueOtherInfo ( listOtherInfo );
            }

            return base.Query();
        }
        public override int Add()
        {
            controlClear();
            this.panel1.Enabled = true;
            _bll = new FishBll.Bll.PurchaseApplicationBll();
            string code = string.Empty;
            code = _bll.getCodeNum();
            if (code!="")
            {
                string str = string.Empty;
                int sum = 0;
                if (code == string.Empty)
                {
                    str = DateTime.Now.Year.ToString() + "C" + "0001001";
                }
                else
                {
                    sum = int.Parse(code) + 1000;
                    code = sum.ToString();
                    while (code.Length != 7)
                    {
                        code = "0" + code;
                    }
                    str = DateTime.Now.Year.ToString() + "C" + code;
                }
                txtCodeNum.Text = str;
            }
            tmiSave.Visible = true;
            if (getname != string.Empty)
            {
                if (getname == "采购流程1")
                {
                    rabProOne.Checked = true;
                }
                else if (getname == "采购流程2")
                {
                    rabProTwo.Checked = true;
                }
            }
            return base.Add();
        }
        public override int Delete()
        {
            _model.id = txtCodeNum.Tag == null ? 0 : Convert.ToInt32(txtCodeNum.Tag);
            _model.codeNum = txtCodeNum.Text;
            if (_bll.ExistsCodeNumContract(_model.id))
            {
                MessageBox.Show("该采购申请单已经被采购合同引用,不允许删除");
                return 0;
            }
            result = _bll.Delete(_model.id, _model.codeNum);
            if (result)
            {
                MessageBox.Show("成功删除");
                controlClear();
            }
            else
                MessageBox.Show("删除失败,请重试");

            return base.Delete();
        }
        public override int Modify()
        {
            if (check() == false)
                return 0;
            if ( getValue ( ) == false )
                return 0;
            int id = _bll.Edit(_model);
            if (id > 0)
                MessageBox.Show("保存成功");
            else
                MessageBox.Show("保存失败");

            return base.Modify();
        }
        public void QueryFishiId() {

            if (_bll.ExistsFishId(txtfishId.Text))
            {
                MessageBox.Show("鱼粉id录入重复 ！");
                return;
            }
        }
        public override void Save()
        {
           // QueryFishiId();
            //if (_bll.ExistsFishId(txtfishId.Text))
            //{
            //    MessageBox.Show("鱼粉id录入重复 ！");
            //    return;
            //}
            if (check() == false)
                return;

            if ( getValue ( ) == false )
                return;

            if (_bll.Exists(_model.codeNum))
            {
                MessageBox.Show("请修改");
                return;
            }
            _model.id = _bll.Add(_model);
            if (_model.id > 0)
            {
                MessageBox.Show("保存成功");
                txtCodeNum.Tag = _model.id;
                tmiSave.Visible = false;
            }
            else
                MessageBox.Show("保存失败");

            base.Save();
        }
        public override void Review()
        {
            Review(this.Name, txtCodeNum.Text, txtCodeNum.Text);

            base.Review();
        }
        public override void Previous()
        {
            QueryOne("<", "'order by a.id asc limit 0'");

            base.Previous();
        }
        public override void Next()
        {
            QueryOne(">", "'order by a.id asc limit 1'");

            base.Next();
        }
        #endregion

        #region Method
        void controlClear ( )
        {
            txtCodeNum . Text = txtcodeNumContract . Text = txtsupplier . Text = txtsupplierUser . Text = txtbuyer . Text =  txtbuyerUser . Text = txtpurchase . Text =  txtpurchaseUser . Text = danjia . Text = txtweight . Text=txtEexchangeRate.Text = txtfishId . Text = txtrebate . Text = txtbrands . Text = txtcountry . Text = txtproName . Text = txtbondPro . Text = txtvarieties . Text =
            txtsignAdd . Text = txtamountOfMoney . Text= txtDollarjine.Text = txtpriceMY . Text = textRemarkOf . Text=txtaccount.Text=txtBank.Text = string . Empty;
            rabProOne . Checked = rabProTwo . Checked =rabMJ.Checked=rabRMB.Checked= false;
            datesignDate . Value = DateTime . Now;
        }
        bool getValue()
        {
            errorProvider1 . Clear ( );
            _model . id = txtCodeNum . Tag == null ? 0 : Convert . ToInt32 ( txtCodeNum . Tag );
            _model . codeNum = txtCodeNum . Text;
            _model . codeNumContract = txtcodeNumContract . Text;
            _model . supplier = txtsupplier . Text;
            //_model . supplierAbb = txtsupplierAbb . Text;
            _model . supplierUser = txtsupplierUser . Text;
            _model . buyer = txtbuyer . Text;
            //_model . buyerAbb = txtbuyerAbb . Text;
            _model . buyerUser = txtbuyerUser . Text;
            _model . purchase = txtpurchase . Text;
            //_model . purchaseAbb = txtpurchaseAbb . Text;
            _model . purchaseUser = txtpurchaseUser . Text;
            _model.choise = rabBP.Checked == true ? rabBP.Text : (rabXH.Checked == true ? rabXH.Text : rabZY.Text);
            decimal outResult = 0M;
            if (danjia.Text != "")
            {
                if (!string.IsNullOrEmpty(danjia.Text) && decimal.TryParse(danjia.Text, out outResult) == false)
                {
                    errorProvider1.SetError(danjia, "请输入数字");
                    return false;
                }
            }
            else {
                errorProvider1.SetError(danjia, "必填");
                return false;
            }

            _model . danjia = outResult;
            outResult = 0M;
            if (txtweight.Text != "")
            {
                if (!string.IsNullOrEmpty(txtweight.Text) && decimal.TryParse(txtweight.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtweight, "请输入数字");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtweight, "必填");
                return false;
            }
            _model.Weight = outResult;
            _model . FishId = txtfishId . Text;
            outResult = 0M;
            if (txtrebate.Text != "")
            {
                if (!string.IsNullOrEmpty(txtrebate.Text) && decimal.TryParse(txtrebate.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtrebate, "请输入数字");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtrebate, "必填");
                return false;
            }
            _model . rebate = outResult;
            outResult = 0M;
            if (txtEexchangeRate.Text != "")
            {
                if (!string.IsNullOrEmpty(txtEexchangeRate.Text) && decimal.TryParse(txtEexchangeRate.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtEexchangeRate, "请输入数字");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtEexchangeRate, "必填");
                return false;
            }
            _model.EexchangeRate = outResult;
            _model . brands = txtbrands . Text;
            _model . conutry = txtcountry . Text;
            _model . proName = txtproName . Text;
            outResult = 0M;
            if (txtbondPro.Text != "")
            {
                if (!string.IsNullOrEmpty(txtbondPro.Text) && decimal.TryParse(txtbondPro.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtbondPro, "请输入数字");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtbondPro, "必填");
                return false;
            }
            _model . bondPro = outResult;
            _model . varieties = txtvarieties . Text;
            _model . signDate = datesignDate . Value;
            _model . signAdd = txtsignAdd . Text;
            outResult = 0M;
            if (txtamountOfMoney.Text != "")
            {
                if (!string.IsNullOrEmpty(txtamountOfMoney.Text) && decimal.TryParse(txtamountOfMoney.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtamountOfMoney, "请输入数字");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtamountOfMoney, "必填");
                return false;
            }
            _model . AmountOfMoney = outResult;
            outResult = 0M;
            if (txtDollarjine.Text != "")
            {
                if (!string.IsNullOrEmpty(txtDollarjine.Text) && decimal.TryParse(txtDollarjine.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtDollarjine, "请输入数字"); return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtDollarjine, "必填");
                return false;
            }

            _model.Dollarjine = outResult;
            outResult = 0M;
            if (txtpriceMY.Text != "")
            {
                if (!string.IsNullOrEmpty(txtpriceMY.Text) && decimal.TryParse(txtpriceMY.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtpriceMY, "请输入数字");
                    return false;
                }
            }
            else
            {
                errorProvider1.SetError(txtpriceMY, "必填");
                return false;
            }
            _model . priceMY = outResult;
            _model . remark = textRemarkOf . Text;
            _model.account = txtaccount.Text;
            _model.Bank = txtBank.Text;
            _model . Process = rabProOne . Checked == true ? rabProOne . Text : rabProTwo . Text;
            _model.Money = rabMJ.Checked == true ? rabMJ.Text : rabRMB.Text;
            _model . createDate =_model.modifyDate= DateTime . Now;
            _model . createUser =_model.modifyUser= FishEntity . Variable . User . username;
            if (txtfishId.Text==""||txtfishId.Text==null)
            {
                errorProvider1.SetError(txtfishId, "请选择鱼粉id");
                return false;
            }

            return true;
        }
        void setValue()
        {
            txtCodeNum.Tag = _model.id;
            txtCodeNum.Text = _model.codeNum;
            txtcodeNumContract.Text = _model.codeNumContract;
            txtsupplier.Text = _model.supplier;
            //txtsupplierAbb.Text = _model.supplierAbb;
            txtsupplierUser.Text = _model.supplierUser;
            txtbuyer.Text = _model.buyer;
            //txtbuyerAbb.Text = _model.buyerAbb;
            txtbuyerUser.Text = _model.buyerUser;
            txtpurchase . Text = _model . purchase;
            //txtpurchaseAbb . Text = _model . purchaseAbb;
            txtpurchaseUser . Text = _model . purchaseUser;
            danjia . Text = _model . danjia . ToString ( );
            txtweight . Text = _model . Weight . ToString ( );
            txtEexchangeRate.Text = _model.EexchangeRate.ToString();
            txtfishId . Text = _model . FishId;
            txtrebate . Text = _model . rebate . ToString ( );
            txtbrands . Text = _model . brands;
            txtcountry . Text = _model . conutry;
            txtproName . Text = _model . proName;
            txtbondPro . Text = _model . bondPro . ToString ( );
            txtvarieties . Text = _model . varieties;
            datesignDate .Value = Convert.ToDateTime(_model.signDate);
            txtsignAdd.Text = _model.signAdd;
            txtamountOfMoney . Text = Convert . ToDecimal ( _model .AmountOfMoney ) . ToString ( "f2" );

            txtDollarjine.Text = Convert.ToDecimal(_model.Dollarjine).ToString("f2");
            txtpriceMY . Text = _model . priceMY . ToString ( );
            textRemarkOf .Text = _model.remark;
            txtBank.Text = _model.Bank.ToString();
            txtaccount.Text = _model.account.ToString();
            if ( string . IsNullOrEmpty ( _model . Process ) )
                rabProOne . Checked = rabProTwo . Checked = false;
            else if ( _model . Process . Equals ( rabProOne . Text ) )
                rabProOne . Checked = true;
            else
                rabProTwo . Checked = true;

            if (string.IsNullOrEmpty(_model.Money))
                rabMJ.Checked = rabRMB.Checked = false;
            else if (_model.Money.Equals(rabMJ.Text))
                rabMJ.Checked = true;
            else
                rabRMB.Checked = true;

            if (string.IsNullOrEmpty(_model.choise))
                rabBP.Checked = rabXH.Checked = rabZY.Checked = false;
            else if (_model.choise.Equals(rabBP.Text))
                rabBP.Checked = true;
            else if (_model.choise.Equals(rabXH.Text))
                rabXH.Checked = true;
            else
                rabZY.Checked = true;
        }
        void QueryOne(string operate, string orderBy)
        {
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(strWhere))
                whereEx = "1=1";
            else
                whereEx = strWhere;
            if (_model != null)
                whereEx = whereEx + " AND a.id " + operate + orderBy;
            if (operate != "" && orderBy != "")
            {
                _model = new FishEntity.PurchaseApplicationEntity();
                _bll = new FishBll.Bll.PurchaseApplicationBll();
                _model = _bll.getModel(whereEx);
            }
            else
            {
                _model = _bll.getModel(strWhere);
            }

            if (_model == null)
            {
                MessageBox.Show("已经没有记录了");
                this.panel1.Enabled = false;
                return;
            }
            setValue();
            //if (string.IsNullOrEmpty(_model.codeNum))
            //    return;
            //List<FishEntity.PurchaseFishInfo> listFishInfo = _bll.getFishInfoList(_model.codeNum);
            //if (listFishInfo != null && listFishInfo.Count > 0)
            //    setValueFishInfo(listFishInfo);
            this.panel1.Enabled = true;
            whereEx = string.Empty;
            //List<FishEntity . PurchaseOtherInfo> listOtherInfo = _bll . getOtherInfoList ( _model . codeNum );
            //if ( listOtherInfo != null && listOtherInfo . Count > 0 )
            //    setValueOtherInfo ( listOtherInfo );
        }
        public FishEntity.PurchaseApplicationEntity getModel
        {
            get
            {
                return _model;
            }
        }
        public List<FishEntity.PurchaseOtherInfo> getOtherInfo
        {
            get
            {
                return listOtherInfo;
            }
        }
        public List<FishEntity.PurchaseFishInfo> getFishInfo
        {
            get
            {
                return listfishInfo;
            }
        }
        bool check()
        {
            result = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtCodeNum.Text))
            {
                errorProvider1.SetError(txtCodeNum, "不可为空");
                result = false;
            }
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtbondPro.Text) && decimal.TryParse(txtbondPro.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtbondPro, "请重新填写");
                result = false;
            }
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtrebate.Text) && decimal.TryParse(txtrebate.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtrebate, "请重新填写");
                result = false;
            }
            if (string.IsNullOrEmpty(txtsupplier.Text))
            {
                errorProvider1.SetError(txtsupplier, "不可为空");
                result = false;
            }
            if (rabProTwo.Checked==true||rabProOne.Checked == true)
            {

            }else
            {
                errorProvider1.SetError(groupBox1, "二选一！");
                result = false;
            }
            if (rabMJ.Checked == true || rabRMB.Checked == true)
            {

            }
            else
            {
                errorProvider1.SetError(groupBox3, "二选一！");
                result = false;
            }
            return result;
        }
        #endregion

        #region Event
        //供方 
        private void txtsupplier_DoubleClick(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModel;
                txtsupplier.Text = _model.buyer;
                //txtsupplierAbb.Text = _model.buyerAbb;
                txtsupplierUser.Text = _model.buyerUser;
                txtaccount.Text = form.getModel.account.ToString();
                txtBank.Text = form.getModel.Bank.ToString();
            }
        }
        //需方
        private void txtbuyer_DoubleClick(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModel;
                txtbuyer.Text = _model.buyer;
                //txtbuyerAbb.Text = _model.buyerAbb;
                txtbuyerUser.Text = _model.buyerUser;
            }
        }
        //采购方
        private void txtpurchase_DoubleClick(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModel;
                txtpurchase.Text = _model.buyer;
                //txtpurchaseAbb.Text = _model.buyerAbb;
                txtpurchaseUser.Text = _model.buyerUser;
            }
        }
        private void txtCodeNum_DoubleClick(object sender, EventArgs e)
        {
            if (_model != null)
            {
                getValue();
                this.DialogResult = DialogResult.OK;
            }
        }
        //订单拆分明细
        private void btnFishId_Click ( object sender ,EventArgs e )
        {
            if (_bll.Exists(txtCodeNum.Text))
            {
                FormPurchaseAppFishInfo form = new FormPurchaseAppFishInfo(txtCodeNum.Text);
                form.Show();
            }
            else
            {
                MessageBox.Show("请添加基础数据！");

            }
        }

        private void txtfishId_DoubleClick ( object sender ,EventArgs e )
        {
            if (rabBP.Checked == false && rabXH.Checked == false && rabZY.Checked == false)
            {
                MessageBox.Show("请选择数据来源");
                return;
            }

            if (rabBP.Checked == true)
            {
                FormQuote form = new FormQuote();
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                FishEntity.ProductQuoteVo Quote = form.getModel;
                if (Quote == null)
                    return;
                txtcountry.Text = Quote.nature;
                txtsupplier.Text = Quote.quotesupplier;
                txtsupplierUser.Text = Quote.linkman;
                danjia.Text = Quote.quotermb.ToString();
                txtpriceMY.Text = Quote.quotedollars.ToString();
                txtbrands.Text = Quote.specification;
                txtfishId.Text = Quote.code;
                txtEexchangeRate.Text = Quote.QuotEexchangeRate;
            }
            else if (rabXH.Checked == true)
            {
                FormSpot form = new FormSpot();
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                FishEntity.ProductQuoteVo Spot = form.getModel;
                if (Spot == null)
                    return;
                txtcountry.Text = Spot.nature;
                txtsupplier.Text = Spot.quotesupplier;
                txtsupplierUser.Text = Spot.linkman;
                danjia.Text = Spot.quotermb.ToString();
                txtbrands.Text = Spot.specification;
                txtfishId.Text = Spot.code;
            }
            else if (rabZY.Checked == true)
            {
                FormNewPriWarehouse form = new FormNewPriWarehouse();
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                FishEntity.ProductQuoteVo SelfSale = form.getModel;
                if (SelfSale == null)
                    return;
                txtcountry.Text = SelfSale.nature;
                txtsupplier.Text = SelfSale.supplier;
                txtsupplierUser.Text = SelfSale.Supplieruser;
                danjia.Text = SelfSale.confirmrmb.ToString();
                txtbrands.Text = SelfSale.specification;
                txtfishId.Text = SelfSale.code;
            }
        }
        //减价条款
        private void button1_Click ( object sender ,EventArgs e )
        {
            if (_bll.Exists(txtCodeNum.Text))
            {
                FormReductionClause form = new FormReductionClause(txtCodeNum.Text);
                form.Show();
            }
            else
            {
                MessageBox.Show("请添加基础数据！");

            }
        }

        private void rabBP_Click(object sender, EventArgs e)
        {
            if (rabProOne.Checked == true)
            {
                rabBP.Checked = true;
            }
            else
            {
                rabBP.Checked = false;
            }
        }

        private void rabXH_Click(object sender, EventArgs e)
        {
            if (rabProOne.Checked == true)
            {
                rabXH.Checked = true;
            }
            else
            {
                rabXH.Checked = false;
            }
        }

        private void rabZY_Click(object sender, EventArgs e)
        {
            if (rabProTwo.Checked == true)
            {
                rabZY.Checked = true;
            }
            else
            {
                rabZY.Checked = false;
            }
        }

        private void rabProOne_Click(object sender, EventArgs e)
        {
            if (rabProOne.Checked==true)
            {
                rabZY.Checked = false;
            }
        }

        private void rabProTwo_Click(object sender, EventArgs e)
        {
            if (rabProTwo.Checked==true)
            {
                rabBP.Checked = rabXH.Checked = false;
            }
        }
    }
}
#endregion