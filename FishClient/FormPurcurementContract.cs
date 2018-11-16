
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
//M489
namespace FishClient
{
    //table : t_purchasecontract  
    //pic: t_picinfoall
    //t_purchaseContractfishinfo
    
    public partial class FormPurcurementContract :FormMenuBase
    {
        FishEntity.PurcurementContractEntity _model=null;
        FishEntity.PicInfoAll _pic=null;
        FishEntity. PurchaseContractFishInfo _fishInfo=null;
        FishBll .Bll.PurcurementContractBll _bll=null;
        string getname = string.Empty;
        string jincang = "";
        Dictionary<int,FishEntity . PicInfoAll> dicPic=null;
        int num=0;decimal outResult=0M;bool result=false;string strWhere=string.Empty;
        
        SolidBrush brush = new SolidBrush ( System . Drawing . Color . Black );
        Font DrawFont = new Font ( "Arial" ,22 );
        
        public FormPurcurementContract ( )
        {
            InitializeComponent ( );

            //InitDataUtil.BindComboBoxData(txtproName, FishEntity.Constant.Goods, true);
            _model = new FishEntity . PurcurementContractEntity ( );
            _bll = new FishBll . Bll . PurcurementContractBll ( );
            _pic = new FishEntity . PicInfoAll ( );
            dicPic = new Dictionary<int ,FishEntity . PicInfoAll> ( );
            AddShuiYin.SetWatermark(txtconProtein, "请选取指标或者填写");
        }

        private void FormPurcurementContract_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                MenuCode = "M471"; ControlButtomRoles();
                strWhere = " codeNum='" + Megres . oddNum + "'";
                getname = Megres.oddNum;
                QueryOne ( string . Empty ,string . Empty );
            }
            else { 
                strWhere = string . Empty;
                panel1.Enabled = false;
            }
            //权限控制功能。
            Megres . oddNum = string . Empty;
        }

        #region Main
        public override int Query ( )
        {
            UIForms . PurchaseApplicationCondition form = new UIForms . PurchaseApplicationCondition ( this . Text + "查询" );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                strWhere = form . getStrWhere;
                _model = _bll . getModel ( strWhere );
                if ( _model == null )
                {
                    MessageBox . Show ( "请重新查询" );
                    return 0;
                }
                panel1.Enabled = true;
                setValue ( _model );
                dicPic = _bll . getImages ( _model . id ,this . Name );
                if (dicPic!=null && dicPic . Count > 0 )
                {
                    _pic = dicPic [ 0 ];
                    pic . Image = PictureOpreation . ReadPicture ( _pic . picInfo );
                    pic . Tag = 0;
                    num++;
                }
                //FishBll . Bll . PurchaseApplicationBll bll = new FishBll . Bll . PurchaseApplicationBll ( );
                //List<FishEntity . PurchaseOtherInfo> listOtherInfo = bll . getOtherInfoList ( _model . codeNum );
                //if ( listOtherInfo != null && listOtherInfo . Count > 0 )
                //    setValue ( listOtherInfo );
                //List<FishEntity . PurchaseContractFishInfo> listFishInfo = _bll . getFishInfoList ( _model . codeNum );
                //if ( listFishInfo != null && listFishInfo . Count > 0 )
                //    setValue ( listFishInfo );
            }

            return base . Query ( );
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
        public override int Add ( )
        {
            panel1.Enabled = true;
            ControlClear ( );
            //txtcodeNumContract . Text = _bll . getCodeNum ( );
            if (getname !=""&&getname !=null)
            {
                FishEntity.PurchaseApplicationEntity fish = new FishEntity.PurchaseApplicationEntity();
                FishBll.Bll.PurchaseApplicationBll _Addbll = new FishBll.Bll.PurchaseApplicationBll();
                fish = _Addbll.getModel(" codeNum='"+getname+"' ");
                if (fish!=null)
                {
                    yincang(fish.choise);
                    jincang = fish.choise;
                    txtCodeNum.Text = fish.codeNum;
                    txtsupplier.Text = fish.supplier;
                    txtsupplierUser.Text = fish.supplierUser;
                    txtbuyer.Text = fish.buyer;
                    txtbuyerUser.Text = fish.buyerUser;
                    txtsigndate.Text = fish.signDate.ToString();
                    txtsignAdd.Text = fish.signAdd;
                    txtpurchase.Text = fish.purchase;
                    txtpurchaseUser.Text = fish.purchaseUser;
                    txtvarieties.Text = fish.varieties;
                    txtheight.Text = fish.Weight.ToString();
                    txtMoney.Text =fish.AmountOfMoney.ToString();
                    txtUnitPrice.Text = fish.danjia.ToString();
                    txtDollar.Text = fish.priceMY.ToString();
                    txtMoneyMJ.Text = fish.Dollarjine.ToString();
                    txtproName.Text = fish.proName;
                    //FishBll.Bll.PurchaseApplicationBll bll = new FishBll.Bll.PurchaseApplicationBll();
                    //List<FishEntity.PurchaseOtherInfo> listOtherInfo = bll.getOtherInfoList(_model.codeNum);
                    //if (listOtherInfo != null && listOtherInfo.Count > 0)
                    //    setValue(listOtherInfo);
                    //List<FishEntity.PurchaseContractFishInfo> listFishInfo = _bll.getFishInfoList(_model.codeNum);
                    //if (listFishInfo != null && listFishInfo.Count > 0)
                    //    setValue(listFishInfo);
                }
            }
            return base . Add ( );
        }
        public void yincang(string choise) {
            if (choise == "报盘")
            {
                txtDollar.Visible = false;
                txtdeliveryAdd.Visible = false;
                txtbondPro.Visible = false;
                txtdatedeliveryDate.Visible = false;
                txtdateshipDate.Visible = false;

                txtpurchase.Visible = false;
                txtdeliveryLast.Visible = false;
                txtpurchaseUser.Visible = false;
                txtdeliveryLastUse.Visible = false;
                txtMoneyMJ.Visible = false;

                label11.Visible = false;
                label38.Visible = false;
                label27.Visible = false;
                label4.Visible = false;
                label7.Visible = false;

                label20.Visible = false;
                label12.Visible = false;
                label25.Visible = false;
                label39.Visible = false;
                label26.Visible = false;
            }
        }
        public override int Delete ( )
        {
            getValue ( );
            result = _bll . Delete ( _model . id ,this . Name );
            if ( result )
            {
                MessageBox . Show ( "删除成功" );
                ControlClear ( );
            }
            else
                MessageBox . Show ( "删除失败,请重试" );

            return base . Delete ( );
        }
        public override int Modify ( )
        {
            if ( getValue ( ) == false )
                return 0;
            //codeNumContract
            if (_bll.Exists(_model)==false)
            {
                MessageBox.Show("请新增");
                return 0;
            }
            int id = _bll . Edit ( _model ,dicPic ,this . Name );
            if ( id == 0 )
                MessageBox . Show ( "保存失败,请重试" );
            else if ( _model . id == -1 )
                MessageBox . Show ( "附件保存失败,请重新保存" );
            else
            {
                MessageBox . Show ( "保存成功" );
            }

            return base . Modify ( );
        }
        public override void Save ( )
        {
            if ( getValue ( ) == false )
                return ;

            if ( _bll . Exists ( _model ) )
            {
                MessageBox . Show ( "请修改" );
                return;
            }

            _model . id = _bll . Save ( _model ,dicPic );

            if ( _model . id == 0 )
                MessageBox . Show ( "保存失败,请重试" );
            else if ( _model . id == -1 )
                MessageBox . Show ( "附件保存失败,请重新保存" );
            else
            {
                MessageBox . Show ( "保存成功" );
            }

            base . Save ( );
        }
        public override void Review ( )
        {
            Review ( this . Name, txtCodeNum.Text, txtcodeNumContract . Text  );

            base . Review ( );
        }
        public override int Print ( )
        {
           

            return base . Print ( );
        }
        public override int Export ( )
        {
            PrintPreviewDialog pt = new PrintPreviewDialog ( );
            //PrintDialog pr = new PrintDialog ( );
            pt . Document = printDocument1;
            //printDocument1 . PrinterSettings . PrinterName = "HP LaserJet Professional M1213nf MFP";
            printDocument1 . Print ( );

            return base . Export ( );
        }
        #endregion

        #region Event
        private void btnPreview_Click ( object sender ,EventArgs e )
        {
            if ( dicPic == null )
            dicPic = new Dictionary<int ,FishEntity . PicInfoAll> ( );
            num++;
            _pic = new FishEntity . PicInfoAll ( );
            _pic . picInfo = PictureOpreation . ReadPicture ( pic );
            if (_pic.picInfo.Length==0)//是否有图片
            {
                return;
            }
            _pic . tableName = this . Name;
            dicPic . Add ( num ,_pic );
            pic . Tag = num;
        }
        private void btnDel_Click ( object sender ,EventArgs e )
        {
            PictureOpreation . ClearPicture ( pic );
            dicPic . Remove ( Convert . ToInt32 ( pic . Tag ) );
            if ( dicPic . Count > 0 )
            {
                for ( int i = 1 ; i <= dicPic . Count ; i++ )
                {
                    if (dicPic. ContainsKey (Convert. ToInt32 ( this.pic . Tag ) + i ) )
                    {
                        _pic = dicPic[Convert. ToInt32 ( this.pic . Tag ) + i ];
                        this.pic . Image = PictureOpreation. ReadPicture (_pic. picInfo );
                        this.pic . Tag = Convert. ToInt32 ( this.pic . Tag ) + i;
                        break;
                    }
                }
            }
        }
        private void btnPrevious_Click ( object sender ,EventArgs e )
        {
            if ( dicPic . Count > 0 )
            {
                for ( int i = 1; i <= dicPic . Count ; i++ )
                {
                    if (dicPic. ContainsKey (Convert. ToInt32 ( this.pic . Tag ) - i ) )
                    {
                        _pic = dicPic[Convert. ToInt32 ( this.pic . Tag ) - i ];
                        this.pic . Image = PictureOpreation. ReadPicture (_pic. picInfo );
                        this.pic . Tag = Convert. ToInt32 ( this.pic . Tag ) - i;
                        break;
                    }
                }
            }
        }
        private void btnNext_Click ( object sender ,EventArgs e )
        {
            if (dicPic == null) return;
            if ( dicPic . Count > 0 )
            {
                for ( int i = 1 ; i <= dicPic . Count ; i++ )
                {
                    if (dicPic. ContainsKey (Convert. ToInt32 ( this.pic . Tag ) + i ) )
                    {
                        _pic = dicPic[Convert. ToInt32 ( this.pic . Tag ) + i ];
                        this.pic . Image = PictureOpreation. ReadPicture (_pic. picInfo );
                        this.pic . Tag = Convert. ToInt32 ( this.pic . Tag ) + i;
                        break;
                    }
                }
            }
        }
        private void txtCodeNum_DoubleClick ( object sender ,EventArgs e )
        {
            FormPurchaseApplication form = new FormPurchaseApplication ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                FishEntity . PurchaseApplicationEntity _model = form . getModel;
                List<FishEntity . PurchaseOtherInfo> getOtherInfo = form . getOtherInfo;
                List<FishEntity . PurchaseFishInfo> getFishInfo = form . getFishInfo;
                setValue ( _model ,getOtherInfo ,getFishInfo );
            }
        }
        private void panel1_DoubleClick ( object sender ,EventArgs e )
        {
            getValue ( );
            this . DialogResult = DialogResult . OK;
        }
        private void printDocument1_PrintPage ( object sender ,System . Drawing . Printing . PrintPageEventArgs e )
        {
            e . Graphics . DrawImage ( pic.Image ,0 ,0 );  //img大小
            e . Graphics . DrawString ( "图片" ,DrawFont ,brush ,600 ,600 ); //绘制字符串
            e . HasMorePages = false;
        }
        private void txtcodeNumContract_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtcodeNumContract . Text ) )
                return;
            this . DialogResult = DialogResult . OK;
        }
        //private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        //{
        //    if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
        //        return;
        //    if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "fishId" ,StringComparison . OrdinalIgnoreCase ) )
        //    {
        //        FormFish form = new FormFish ( );
        //        if ( form . ShowDialog ( ) == DialogResult . OK )
        //        {
        //            bool result = true;
        //            FishEntity . ProductEntity _fish = form . getEntity;
        //            FishEntity . ProductExEntity _fishex = form . getExEntity;

        //            foreach ( DataGridViewRow row in dataGridView1 . Rows )
        //            {
        //                if ( row . Cells [ "fishId" ] . Value != null )
        //                {
        //                    if ( _fish . code . Equals ( row . Cells [ "fishId" ] . Value . ToString ( ) ) )
        //                        result = false;
        //                }
        //            }

        //            if ( result == false )
        //                return;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "fishId" ] . Value = _fish . code;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "price" ] . Value = _fishex . quotermb;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "weight" ] . Value = _fishex . quoteweight;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "priceUSA" ] . Value = _fishex . quotedollars;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "specifications" ] . Value = _fish . specification;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "brand" ] . Value = _fish . brand;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "country" ] . Value = _fish . nature;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "shipName" ] . Value = _fish . shipno;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "billName" ] . Value = _fish . billofgoods;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "money" ] . Value = _fishex . quotermb * _fishex . quoteweight;
        //            dataGridView1 . Rows [ e . RowIndex ] . Cells [ "moneyUSA" ] . Value = _fishex . quotedollars * _fishex . quoteweight;


        //            //int index = 0;
        //            //if (  dataGridView1 . Rows [ dataGridView1 . Rows . Count - 1 ] . Cells [ "fishId" ] . Value ==null || string.IsNullOrEmpty ( dataGridView1 . Rows [ dataGridView1 . Rows . Count - 1 ] . Cells [ "fishId" ] . Value .ToString()) )
        //            //    index = this . dataGridView1 . Rows . Count - 1;
        //            //else
        //            //    index = this . dataGridView1 . Rows . Add ( );

        //            //dataGridView1.Rows[index].Cells["fishId"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["price"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["weight"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["priceUSA"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["specifications"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["brand"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["country"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["shipName"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["billName"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["money"].Value = string.Empty;
        //            //dataGridView1.Rows[index].Cells["moneyUSA"].Value = string.Empty;

        //        }
        //    }
        //}
        #endregion

        #region Method
        void ControlClear ( )
        {
            foreach ( Control tc in panel1 . Controls )
            {
                if ( tc . GetType ( ) == typeof ( TextBox ) )
                {
                    TextBox tb = tc as TextBox;
                    tb . Text = string . Empty;
                }

            }
            if ( dicPic != null )
                dicPic . Clear ( );
            pic . Image = null;
            pic . Tag = null;
            txtCodeNum . Tag = null;
            //dataGridView2 . Rows . Clear ( );
            //dataGridView1.Rows.Clear();
            //this.dataGridView2.Rows.Add();
        }
        void setValue ( FishEntity . PurchaseApplicationEntity _model ,List<FishEntity . PurchaseOtherInfo> listOtherInfo ,List<FishEntity . PurchaseFishInfo> getFishInfo )
        {
            txtsupplier . Text = _model . supplier;
            txtsupplierUser . Text = _model . supplierUser;
            txtbuyer . Text = _model . buyer;
            txtbuyerUser . Text = _model . buyerUser;
            txtCodeNum . Text = _model . codeNum;
            txtsignAdd . Text = _model . signAdd;
            txtsigndate . Text = _model . signDate . ToString ( );
            txtvarieties . Text = _model . varieties;
            txtheight . Text = Convert . ToDecimal ( _model . height ) . ToString ( "f2" );
            txtMoney . Text = Convert . ToDecimal ( _model . price ) . ToString ( "f2" );
            txtMoneyMJ . Text = Convert . ToDecimal ( _model . billNum ) . ToString ( "f2" );
            txtdateshipDate . Text = _model . shipDate . ToString ( );
            txtdatedeliveryDate . Text = _model . deliveryDate . ToString ( );
            txtdeliveryAdd . Text = _model . deliveryAdd;
            jincang = _model.choise;
            txtconDAS . Text = _model . conDAS;
            txtconFFA . Text = _model . conFFA;
            txtconHF . Text = _model . conHF;
            txtconLAS . Text = _model . conLAS;
            txtconProtein . Text = _model . conProtein;
            txtconS . Text = _model . conS;
            txtconSF . Text = _model . conSF;
            txtconSHY . Text = _model . conSHY;
            txtconSJ . Text = _model . conSJ;
            txtconTVN . Text = _model . conTVN;
            txtconZA . Text = _model . conZA;
            txtconZF . Text = _model . conZF;
            txtpurchase . Text = _model . purchase;
            txtpurchaseUser . Text = _model . purchaseUser;
            yincang(_model.choise);
            //dataGridView2 . Rows . Clear ( );
            //foreach ( FishEntity . PurchaseOtherInfo otherInfo in listOtherInfo )
            //{
            //    int idx = dataGridView2 . Rows . Add ( );
            //    DataGridViewRow row = dataGridView2 . Rows [ idx ];
            //    row . Cells [ "idx" ] . Value = otherInfo . id;
            //    row . Cells [ "brands" ] . Value = otherInfo . brand;
            //    row . Cells [ "moneys" ] . Value = otherInfo . money;
            //    row . Cells [ "nums" ] . Value = otherInfo . num;
            //}

            //dataGridView1 . Rows . Clear ( );
            //foreach ( FishEntity . PurchaseFishInfo fishInfo in getFishInfo )
            //{
            //    int idx = dataGridView1 . Rows . Add ( );
            //    DataGridViewRow row = dataGridView1 . Rows [ idx ];
            //    row . Cells [ "id" ] . Value = fishInfo . id;
            //    row . Cells [ "fishId" ] . Value = fishInfo . fishId;
            //    row . Cells [ "price" ] . Value = fishInfo . price;
            //    row . Cells [ "weight" ] . Value = fishInfo . weight;
            //    row . Cells [ "priceUSA" ] . Value = fishInfo . priceUSA;
            //    row . Cells [ "specifications" ] . Value = fishInfo . specifications;
            //    row . Cells [ "brand" ] . Value = fishInfo . brand;
            //    row . Cells [ "country" ] . Value = fishInfo . country;
            //    row . Cells [ "shipName" ] . Value = fishInfo . shipName;
            //    row . Cells [ "billName" ] . Value = fishInfo . billName;
            //    row . Cells [ "money" ] . Value = fishInfo . price * fishInfo . weight;
            //    row . Cells [ "moneyUSA" ] . Value = fishInfo . priceUSA * fishInfo . weight;
            //}

            //int index = this . dataGridView1 . Rows . Add ( );
            //dataGridView1 . Rows [ index ] . Cells [ "fishId" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "price" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "weight" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "priceUSA" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "specifications" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "brand" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "country" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "shipName" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "billName" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "money" ] . Value = string . Empty;
            //dataGridView1 . Rows [ index ] . Cells [ "moneyUSA" ] . Value = string . Empty;

        }
        void setValue ( FishEntity . PurcurementContractEntity _model )
        {
            txtcodeNumContract . Text = _model . codeNumContract;
            txtCodeNum . Tag = _model . id;
            txtbondPro . Text = Convert . ToDecimal ( _model . bondPro ) . ToString ( "f3" );
            txtproName.Text = _model.ProName;
            txtbuyer . Text = _model . buyer;
            txtbuyerUser . Text = _model . buyerUser;
            txtCodeNum . Text = _model . codeNum;
            txtconDAS . Text = _model . conDAS;
            txtconFFA . Text = _model . conFFA;
            txtconHF . Text = _model . conHF;
            txtconLAS . Text = _model . conLAS;
            txtconProtein . Text = _model . conProtein;
            txtconS . Text = _model . conS;
            txtconSF . Text = _model . conSF;
            txtconSHY . Text = _model . conSHY;
            txtconSJ . Text = _model . conSJ;
            txtconTVN . Text = _model . conTVN;
            txtconZA . Text = _model . conZA;
            txtconZF . Text = _model . conZF;
            txtdeliveryAdd . Text = _model . deliveryAdd;
            jincang = _model.Choise;
            txtheight . Text = Convert . ToDecimal ( _model . height ) . ToString ( "f2" );
            txtMoney . Text = Convert . ToDecimal ( _model . price ) . ToString ( "f2" );
            txtMoneyMJ . Text = Convert . ToDecimal ( _model . priceMY ) . ToString ( "f2" );
            txtUnitPrice.Text = _model.UnitPrice;
            txtDollar.Text = _model.Dollar;
            txtsignAdd . Text = _model . signAdd;
            txtsigndate . Text = _model . signDate . ToString ( );
            txtsupplier . Text = _model . supplier;
            txtsupplierUser . Text = _model . supplierUser;
            txtvarieties . Text = _model . varieties;
            txtdateshipDate . Text = _model . shipdate . ToString ( );
            txtdatedeliveryDate . Text = _model . deliveryDate . ToString ( );
            txtdeliveryLast . Text = _model . quaSpe;
            txtdeliveryLastUse . Text = _model . conutry;
            txtpurchase . Text = _model . purchase;
            txtpurchaseUser . Text = _model . purchaseUser;
            if (_model.gongfang == "供方")
            {
                rabgongfang.Checked = true;
            }
            else if (_model.xufang == "需方")
            {
                rabxufang.Checked = true;
            }
            else
            {
                rabgongfang.Checked = rabxufang.Checked = false;
            }

            panel1.Enabled = true;
            yincang(_model.Choise);
        }
        //void setValue ( List<FishEntity . PurchaseOtherInfo> listOtherInfo )
        //{
        //    dataGridView2 . Rows . Clear ( );
        //    foreach ( FishEntity . PurchaseOtherInfo otherInfo in listOtherInfo )
        //    {
        //        int idx = dataGridView2 . Rows . Add ( );
        //        DataGridViewRow row = dataGridView2 . Rows [ idx ];
        //        row . Cells [ "idx" ] . Value = otherInfo . id;
        //        row . Cells [ "brands" ] . Value = otherInfo . brand;
        //        row . Cells [ "moneys" ] . Value = otherInfo . money;
        //        row . Cells [ "nums" ] . Value = otherInfo . num;
        //    }
        //}
        //void setValue ( List<FishEntity . PurchaseContractFishInfo> listFishInfo )
        //{
        //    dataGridView1 . Rows . Clear ( );
        //    foreach ( FishEntity . PurchaseContractFishInfo fishInfo in listFishInfo )
        //    {
        //        int idx = dataGridView1 . Rows . Add ( );
        //        DataGridViewRow row = dataGridView1 . Rows [ idx ];
        //        row . Cells [ "id" ] . Value = fishInfo . id;
        //        row . Cells [ "fishId" ] . Value = fishInfo . fishId;
        //        row . Cells [ "price" ] . Value = fishInfo . price;
        //        row . Cells [ "weight" ] . Value = fishInfo . weight;
        //        row . Cells [ "priceUSA" ] . Value = fishInfo . priceUSA;
        //        row . Cells [ "specifications" ] . Value = fishInfo . specifications;
        //        row . Cells [ "brand" ] . Value = fishInfo . brand;
        //        row . Cells [ "country" ] . Value = fishInfo . country;
        //        row . Cells [ "shipName" ] . Value = fishInfo . shipName;
        //        row . Cells [ "billName" ] . Value = fishInfo . billName;
        //        row . Cells [ "money" ] . Value = fishInfo . price * fishInfo . weight;
        //        row . Cells [ "moneyUSA" ] . Value = fishInfo . priceUSA * fishInfo . weight;
        //    }

        //    int index = dataGridView1 . Rows . Add ( );
        //    dataGridView1 . Rows [ index ] . Cells [ "fishId" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "price" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "weight" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "priceUSA" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "specifications" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "brand" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "country" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "shipName" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "billName" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "money" ] . Value = string . Empty;
        //    dataGridView1 . Rows [ index ] . Cells [ "moneyUSA" ] . Value = string . Empty;
        //}
        bool getValue ( )
        {
            if ( _model == null )
                _model = new FishEntity . PurcurementContractEntity ( );
            errorProvider1 . Clear ( );
            if ( string . IsNullOrEmpty ( txtCodeNum . Text ) )
            {
                errorProvider1 . SetError ( txtCodeNum ,"不可为空" );
                return false;
            }
            if (string.IsNullOrEmpty(txtcodeNumContract.Text))
            {
                errorProvider1.SetError(txtcodeNumContract, "不可为空");
                return false;
            }
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtbondPro . Text ) && decimal . TryParse ( txtbondPro . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtbondPro ,"请重新输入" );
                return false;
            }
            if (txtproName.Text==null|| txtproName.Text=="")
            {
                errorProvider1.SetError(txtproName, "请选择");
                return false;
            }
            if (rabxufang.Checked == true)
            {
                _model.xufang = "需方";
            }
            else if (rabgongfang.Checked == true)
            {
                _model.gongfang = "供方";
            }
            else
            {
                _model.gongfang = _model.xufang = string.Empty;
            }
            _model.ProName = txtproName.Text;
            _model . bondPro = outResult;
            _model . id = txtCodeNum . Tag == null ? 0 : Convert . ToInt32 ( txtCodeNum . Tag . ToString ( ) );
            _model . codeNumContract = txtcodeNumContract . Text;
            _model . buyer = txtbuyer . Text;
            _model . buyerUser = txtbuyerUser . Text;
            _model . codeNum = txtCodeNum . Text;
            _model . conDAS = txtconDAS . Text;
            _model . conFFA = txtconFFA . Text;
            _model . conHF = txtconHF . Text;
            _model . conLAS = txtconLAS . Text;
            _model . conProtein = txtconProtein . Text;
            _model . conS = txtconS . Text;
            _model . conSF = txtconSF . Text;
            _model . conSHY = txtconSHY . Text;
            _model . conSJ = txtconSJ . Text;
            _model . conTVN = txtconTVN . Text;
            _model . conZA = txtconZA . Text;
            _model . conZF = txtconZF . Text;
            _model . deliveryAdd = txtdeliveryAdd . Text;
            _model.Choise = jincang;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtheight . Text ) && decimal . TryParse ( txtheight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtheight ,"请重新输入" );
                return false;
            }
            _model . height = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtMoney . Text ) && decimal . TryParse ( txtMoney . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtMoney ,"请重新输入" );
                return false;
            }
            _model . price = outResult;
            outResult = 0M;
            if (jincang =="报盘")
            {
                if (!string.IsNullOrEmpty(txtMoneyMJ.Text) && decimal.TryParse(txtMoneyMJ.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtMoneyMJ, "请重新输入");
                    return false;
                }
            }
            if (jincang == "报盘")
            {
                if (!string.IsNullOrEmpty(txtDollar.Text) && decimal.TryParse(txtDollar.Text, out outResult) == false)
                {
                    errorProvider1.SetError(txtDollar, "请重新输入");
                    return false;
                }
            }
            _model.UnitPrice = txtUnitPrice.Text;
            _model.Dollar = txtDollar.Text;
            _model . priceMY = outResult;
            _model . signAdd = txtsignAdd . Text;
            _model . supplier = txtsupplier . Text;
            _model . supplierUser = txtsupplierUser . Text;
            if ( string . IsNullOrEmpty ( txtsigndate . Text ) )
                _model . signDate = null;
            else
                _model . signDate = Convert . ToDateTime ( txtsigndate . Text );
            _model . varieties = txtvarieties . Text;
            if ( string . IsNullOrEmpty ( txtdateshipDate . Text ) )
                _model . shipdate = null;
            else
                _model . shipdate = Convert . ToDateTime ( txtdateshipDate . Text );
            if ( string . IsNullOrEmpty ( txtdatedeliveryDate . Text ) )
                _model . deliveryDate = null;
            else
                _model . deliveryDate = Convert . ToDateTime ( txtdatedeliveryDate . Text );
            _model . quaSpe = txtdeliveryLast . Text;
            _model . conutry = txtdeliveryLastUse . Text;
            _model . purchase = txtpurchase . Text;
            _model . purchaseUser = txtpurchaseUser . Text;
            _model.createUser = _model.modifyUser = FishEntity.Variable.User.username;
            _model.createDate = _model.modifyDate = DateTime.Now;
            

            return true;
        }
        //void saveFishOtherInfo ( )
        //{
        //    dataGridView1 . EndEdit ( );
        //    List<FishEntity . PurchaseContractFishInfo> listFishInfo = new List<FishEntity . PurchaseContractFishInfo> ( );
        //    foreach ( DataGridViewRow row in dataGridView1 . Rows )
        //    {
        //        if ( row . IsNewRow )
        //            continue;
        //        _fishInfo = new FishEntity . PurchaseContractFishInfo ( );
        //        _fishInfo . code = _model . codeNum;
        //        _fishInfo . fishId = row . Cells [ "fishId" ] . Value . ToString ( );
        //        decimal outResult = 0;
        //        if ( row . Cells [ "price" ] . Value != null )
        //        {
        //            decimal . TryParse ( row . Cells [ "price" ] . Value . ToString ( ) ,out outResult );
        //        }
        //        _fishInfo . price = outResult;
        //        outResult = 0;
        //        if ( row . Cells [ "weight" ] . Value != null )
        //        {
        //            decimal . TryParse ( row . Cells [ "weight" ] . Value . ToString ( ) ,out outResult );
        //        }
        //        _fishInfo . weight = outResult;
        //        outResult = 0;
        //        if ( row . Cells [ "priceUSA" ] . Value != null )
        //        {
        //            decimal . TryParse ( row . Cells [ "priceUSA" ] . Value . ToString ( ) ,out outResult );
        //        }
        //        _fishInfo . priceUSA = outResult;
        //        _fishInfo . specifications = row . Cells [ "specifications" ] . Value . ToString ( );
        //        _fishInfo . brand = row . Cells [ "brand" ] . Value . ToString ( );
        //        _fishInfo . country = row . Cells [ "country" ] . Value . ToString ( );
        //        _fishInfo . shipName = row . Cells [ "shipName" ] . Value . ToString ( );
        //        _fishInfo . billName = row . Cells [ "billName" ] . Value . ToString ( );
        //        listFishInfo . Add ( _fishInfo );
        //    }

        //    bool result = false;
        //    if ( listFishInfo != null && listFishInfo . Count > 0 )
        //    {
        //        result = _bll . SaveFishInfo ( listFishInfo );
        //        if ( result == false )
        //            MessageBox . Show ( "鱼粉资料保存失败,请重试" );
        //    }
        //}
        void QueryOne ( string operate ,string orderBy )
        {
            string whereEx = string . Empty;
            if ( string . IsNullOrEmpty ( strWhere ) )
                whereEx = "1=1";
            else
                whereEx = strWhere;
            if (_model != null)
                if (operate!=null&& operate!=""&& orderBy!=""&& orderBy!=null)
                {
                    whereEx = whereEx + " AND codeNum " + operate + orderBy;
                }
            _model = _bll . getModel ( whereEx );
            if ( _model == null )
            {
                //MessageBox . Show ( "已经没有记录了" );
                return;
            }
            setValue ( _model );
            panel1.Enabled = true;
            dicPic = new Dictionary<int, FishEntity.PicInfoAll>();
            dicPic = _bll . getImages ( _model . id ,this . Name );
            if ( dicPic!=null)//dicPic.Count
            {
                _pic = dicPic [ 0 ];
                pic . Image = PictureOpreation . ReadPicture ( _pic . picInfo );
                pic . Tag = 0;
            }
            //FishBll . Bll . PurchaseApplicationBll bll = new FishBll . Bll . PurchaseApplicationBll ( );
            //List<FishEntity . PurchaseOtherInfo> listOtherInfo = bll . getOtherInfoList ( _model . codeNum );
            //if ( listOtherInfo != null && listOtherInfo . Count > 0 )
            //    setValue ( listOtherInfo );
            //List<FishEntity.PurchaseContractFishInfo> listFishInfo = _bll.getFishInfoList(_model.codeNum);
            //if (listFishInfo != null && listFishInfo.Count > 0)
            //    setValue(listFishInfo);

            panel1.Enabled = true;
        }
        public FishEntity . PurcurementContractEntity getModel
        {
            get
            {
                return _model;
            }
        }
        public string getCode
        {
            get
            {
                return txtcodeNumContract . Text;
            }
        }
        public string getCodeNum
        {
            get
            {
                return txtCodeNum . Text;
            }
        }
        #endregion

        private void txtdeliveryLast_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            FishEntity.PurchaseApplicationEntity get1 = new FishEntity.PurchaseApplicationEntity();
            if (form.ShowDialog() == DialogResult.OK)
            {
                get1 = form.getModel;
                txtdeliveryLast.Text = get1.buyer;
                txtdeliveryLastUse.Text = get1.buyerUser;
            }
        }

        private void txtconProtein_Click(object sender, EventArgs e)
        {
            if (_bll.Exists(txtCodeNum.Text))
            {
                FormPurchaseAppFishInfo form = new FormPurchaseAppFishInfo(txtCodeNum.Text);
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                FishEntity.PurchaseAppFishInfoEntity Caig = form.getModel;
                if (Caig == null) return;
                txtconProtein.Text = Caig.conProtein;
                txtconTVN.Text = Caig.conTVN;
                txtconFFA.Text = Caig.conFFA;
                txtconZF.Text = Caig.conZF;
                txtconSHY.Text = Caig.conSHY;
                txtconS.Text = Caig.conS;
                txtconSF.Text = Caig.conSF;
                txtconZA.Text = Caig.conZA;
                txtconHF.Text = Caig.conHF;
                txtconSJ.Text = Caig.conSJ;
                txtconLAS.Text = Caig.conLAS;
                txtconDAS.Text = Caig.conDAS;
                txtDollar.Text = Caig.priceMY.ToString();
                AddShuiYin.ClearWatermark(txtconProtein);
            }
            else
            {
                MessageBox.Show("采购申请单，订单明细无数据!");
            }
        }

        private void rabgongfang_Click(object sender, EventArgs e)
        {
            if (rabgongfang.Checked == true) {
                txtcodeNumContract.Text = string.Empty;
            }
        }
        private void rabxufang_Click(object sender, EventArgs e)
        {
            if (rabxufang.Checked == true)
            {
                txtcodeNumContract.Text = _bll.getCodeNum();
            }
        }

        private void pic_Click(object sender, EventArgs e)
        {
            UIForms.FormZoomImage form = new UIForms.FormZoomImage(pic.Image);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            form.ShowDialog();
        }
    }

}