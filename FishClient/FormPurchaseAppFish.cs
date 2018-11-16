using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormPurchaseAppFish :FormMenuBase
    {
        FishEntity.PurchaseAppFishInfoEntity model=null;
        FishBll.Bll.PurchaseAppFishInfoBll _bll=null;
        bool chead = true;
        string strWhere="1=1";

        public FormPurchaseAppFish ( FishEntity . PurchaseAppFishInfoEntity entity )
        {
            InitializeComponent ( );

            this . model = entity;
            setValue ( );

            tmiQuery . Visible = tmiAdd . Visible = tmiCancel . Visible = tmiClose . Visible = tmiDelete . Visible = tmiExport . Visible = tmiModify . Visible = tmiNext . Visible = tmiPrevious . Visible = tmiprint . Visible = tmiReview . Visible = false;
        }

        public override void Save ( )
        {
            if ( getValue ( ) == false )
                return;
            _bll = new FishBll.Bll.PurchaseAppFishInfoBll();
            bool result = _bll . Save ( model );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                this . DialogResult = DialogResult . OK;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }

        void controlClear ( )
        {
            txtmoney . Text =txtEexchangeRate.Text=txtpriceMY.Text= txtweight . Text = txtconDAS . Text = txtconFFA . Text = txtconHF . Text = txtconLAS . Text = txtconProtein . Text = txtconS . Text = txtconSF . Text = txtconSHY . Text = txtconSJ . Text = txtconTVN . Text = txtconZA . Text = txtconZF . Text = txtFishid . Text = txtspecifications . Text = txtcountry . Text = txtshipName . Text = txtbillName . Text = txtbrand . Text = string . Empty;
        }
        bool getValue ( )
        {
            errorProvider1 . Clear ( );            
            model . code = txtCode . Text;
            model . fishId = txtFishid . Text;
            model . specifications = txtspecifications . Text;
            model . country = txtcountry . Text;
            model . shipName = txtshipName . Text;
            model . billName = txtbillName . Text;
            model . brand = txtbrand . Text;
            model . choise = rabBP . Checked == true ? rabBP . Text : ( rabXH . Checked == true ? rabXH . Text : rabZY . Text );
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtmoney . Text ) && decimal . TryParse ( txtmoney . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtmoney ,"请输入数字" );
                return false;
            }
            model . money = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtweight . Text ) && decimal . TryParse ( txtweight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtweight ,"请输入数字" );
                return false;
            }
            model . num = outResult;
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtEexchangeRate.Text) && decimal.TryParse(txtEexchangeRate.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtEexchangeRate, "请输入数字");
                return false;
            }
            model.EexchangeRate = outResult;
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtpriceMY.Text) && decimal.TryParse(txtpriceMY.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtpriceMY, "请输入数字");
                return false;
            }
            model.priceMY = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtprice . Text ) && decimal . TryParse ( txtprice . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtprice ,"请输入数字" );
                return false;
            }
            model.price = outResult;
            model . conProtein = txtconProtein . Text;
            model . conTVN = txtconTVN . Text;
            model . conZA = txtconZA . Text;
            model . conFFA = txtconFFA . Text;
            model . conZF = txtconZF . Text;
            model . conSF = txtconSF . Text;
            model . conSHY = txtconSHY . Text;
            model . conS = txtconS . Text;
            model . conSJ = txtconSJ . Text;
            model . conHF = txtconHF . Text;
            model . conLAS = txtconLAS . Text;
            model . conDAS = txtconDAS . Text;
            model . delPort = txtdelPort . Text;
            model . fastshipdate = txtFast . Value;
            model . lastshipdate = txtLast . Value;

            return true;
        }
        void setValue ( )
        {
            txtCode . Text = model . code;
            txtFishid . Text = model . fishId;
            txtspecifications . Text = model . specifications;
            txtcountry . Text = model . country;
            txtshipName . Text = model . shipName;
            txtbillName . Text = model . billName;
            txtbrand . Text = model . brand;
            if ( string . IsNullOrEmpty ( model . choise ) )
                rabBP . Checked = rabXH . Checked = rabZY . Checked = false;
            else if ( model . choise . Equals ( rabBP . Text ) )
                rabBP . Checked = true;
            else if ( model . choise . Equals ( rabXH . Text ) )
                rabXH . Checked = true;
            else
                rabZY . Checked = true;
            txtmoney . Text = model . money . ToString ( );
            txtweight . Text = model . num . ToString ( );
            txtpriceMY.Text = model.priceMY.ToString();
            txtEexchangeRate.Text = model.EexchangeRate.ToString();
            txtprice . Text = model . price . ToString ( );
            txtconProtein . Text = model . conProtein;
            txtconTVN . Text = model . conTVN;
            txtconZA . Text = model . conZA;
            txtconFFA . Text = model . conFFA;
            txtconZF . Text = model . conZF;
            txtconSF . Text = model . conSF;
            txtconSHY . Text = model . conSHY;
            txtconS . Text = model . conS;
            txtconSJ . Text = model . conSJ;
            txtconHF . Text = model . conHF;
            txtconLAS . Text = model . conLAS;
            txtconDAS . Text = model . conDAS;
            txtdelPort . Text = model . delPort;
            txtFast . Value = model . fastshipdate == null ? DateTime . Now : Convert . ToDateTime ( model . fastshipdate );
            txtLast . Value = model . lastshipdate == null ? DateTime . Now : Convert . ToDateTime ( model . lastshipdate );
        }
        public void QueryFishid() {
            
            if (_bll.ExistsFishId(txtFishid.Text))
            {
                MessageBox.Show("采购申请单已有鱼粉id ！"); chead = false;
                return;
            }
            else if (_bll.ExistsFishId1(txtFishid.Text))
            {
                MessageBox.Show("订单明细已有鱼粉id ！"); chead = false;
                return;
            }
            else
            {
                chead = true;
            }
            
        }
        private void txtFishid_DoubleClick ( object sender ,EventArgs e )
        {
            if ( rabBP . Checked == false && rabXH . Checked == false && rabZY . Checked == false )
            {
                MessageBox . Show ( "请选择数据来源" );
                return;
            }
            _bll = new FishBll.Bll.PurchaseAppFishInfoBll();
            if ( rabBP . Checked == true )
            {
                FormQuote form = new FormQuote ( );
                if ( form . ShowDialog ( ) != DialogResult . OK )
                    return;
                FishEntity . ProductQuoteVo Quote = form . getModel;
                if ( Quote == null )
                    return;

                //if ( !Quote . code . Equals ( txtFishid . Text ) )
                //{
                //    MessageBox . Show ( "请选择鱼粉ID是:"+txtFishid.Text+"的内容" );
                //    return;
                //}
                txtFishid . Text = Quote . code;
                txtspecifications . Text = Quote . specification;
                txtcountry . Text = Quote . nature;
                txtbrand . Text = Quote . brand;
                txtbillName . Text = Quote . billofgoods;
                txtshipName . Text = Quote . shipno;
                txtconProtein . Text = Quote . quote_protein . ToString ( );
                txtconTVN . Text = Quote . quote_tvn . ToString ( );
                txtconZA . Text = Quote . quote_amine . ToString ( );
                txtconFFA . Text = Quote . quote_ffa . ToString ( );
                txtconSHY . Text = Quote . quote_sandsalt . ToString ( );
                txtconHF . Text = Quote . quote_graypart . ToString ( );
                txtconZF . Text = Quote . quote_fat . ToString ( );
                txtconSF . Text = Quote . quote_water . ToString ( );
                txtconS . Text = Quote . quote_sand . ToString ( );
                txtconSJ . Text = txtconLAS . Text = txtconDAS . Text = string . Empty;
                QueryFishid();
            }
            else if ( rabXH . Checked == true )
            {
                FormSpot form = new FormSpot ( );
                if ( form . ShowDialog ( ) != DialogResult . OK )
                    return;
                FishEntity . ProductQuoteVo Spot = form . getModel;
                if ( Spot == null )
                    return;
                //if ( !Spot . code . Equals ( txtFishid . Text ) )
                //{
                //    MessageBox . Show ( "请选择鱼粉ID是:" + txtFishid . Text + "的内容" );
                //    return;
                //}
                txtFishid . Text = Spot . code;
                txtspecifications . Text = Spot . specification;
                txtcountry . Text = Spot . nature;
                txtbrand . Text = Spot . brand;
                txtbillName . Text = Spot . billofgoods;
                txtshipName . Text = Spot . shipno;
                txtconProtein . Text = Spot .sgs_protein. ToString ( );
                txtconTVN . Text = Spot . sgs_tvn . ToString ( );
                txtconZA . Text = Spot . sgs_amine . ToString ( );
                txtconFFA . Text = Spot . sgs_ffa . ToString ( );
                txtconSHY . Text = Spot . sgs_sandsalt . ToString ( );
                txtconHF . Text = Spot . sgs_graypart . ToString ( );
                txtconZF . Text = Spot . sgs_fat . ToString ( );
                txtconSF . Text = Spot . sgs_water . ToString ( );
                txtconS . Text = txtconSJ . Text =txtconLAS . Text = txtconDAS . Text = string . Empty;
                QueryFishid();
            }
            else if ( rabZY . Checked == true )
            {
                FormSelfSale form = new FormSelfSale ( );
                if ( form . ShowDialog ( ) != DialogResult . OK )
                    return;
                FishEntity . ProductQuoteVo SelfSale = form . getModel;
                if ( SelfSale == null )
                    return;
                //if ( !SelfSale . code . Equals ( txtFishid . Text ) )
                //{
                //    MessageBox . Show ( "请选择鱼粉ID是:" + txtFishid . Text + "的内容" );
                //    return;
                //}
                txtFishid . Text = SelfSale . code;
                txtspecifications . Text = SelfSale . specification;
                txtcountry . Text = SelfSale . nature;
                txtbrand . Text = SelfSale . brand;
                txtbillName . Text = SelfSale . billofgoods;
                txtshipName . Text = SelfSale . shipno;
                txtconProtein . Text = SelfSale . sgs_protein . ToString ( );
                txtconTVN . Text = SelfSale . sgs_tvn . ToString ( );
                txtconZA . Text = SelfSale . sgs_amine . ToString ( );
                txtconFFA . Text = SelfSale . sgs_ffa . ToString ( );
                txtconSHY . Text = SelfSale . sgs_sandsalt . ToString ( );
                txtconHF . Text = SelfSale . sgs_graypart . ToString ( );
                txtconZF . Text = SelfSale . sgs_fat . ToString ( );
                txtconSF . Text = SelfSale . sgs_water . ToString ( );
                txtconS . Text = txtconSJ . Text = txtconLAS . Text = txtconDAS . Text = string . Empty;
                QueryFishid();
            }

        }

        public FishEntity . PurchaseAppFishInfoEntity getModel
        {
            get
            {
                return model;
            }
        }
        public event Action<EventArgs> RefreshEvent = null;
        protected void OnRefresh()
        {
            if (RefreshEvent != null)
            {
                RefreshEvent(EventArgs.Empty);
            }
        }
    }
}
