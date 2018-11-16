using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    //t_WarehouseReceipt
    //t_picinfoall
    public partial class FormWarehouseReceipt :FormMenuBase
    {
        FishEntity.WarehouseReceiptEntity _model=null;
        FishBll.Bll.WarehouseReceiptBll _bll=null;
        FishEntity.PicInfoAll _pic=null;
        string getname = string.Empty;
        bool result=false;
        string strWhere="1=1";
        int selectIdx=0;
        
        public FormWarehouseReceipt ()
        {
            InitializeComponent ( );

            _model = new FishEntity . WarehouseReceiptEntity ( );
            _bll = new FishBll . Bll . WarehouseReceiptBll ( );
            _pic = new FishEntity . PicInfoAll ( );
            InitDataUtil.BindComboBoxData(cmbStartingCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbDestinationCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbcountryOfOrigin, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(txtcommodityTons, FishEntity.Constant.Goods, true);
            InitDataUtil.BindComboBoxData(txtProductionProcess, FishEntity.Constant.TechClass, true);
            this.dtpReportingTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportingTime.CustomFormat = "  ";
            this.dtpTestTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTestTime.CustomFormat = "  ";
            this.dtpFumigationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFumigationDate.CustomFormat = "  ";
        }
        public FormWarehouseReceipt(string name)
        {
            InitializeComponent();
            getname = name;
            _model = new FishEntity.WarehouseReceiptEntity();
            _bll = new FishBll.Bll.WarehouseReceiptBll();
            _pic = new FishEntity.PicInfoAll();
            InitDataUtil.BindComboBoxData(cmbStartingCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbDestinationCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbcountryOfOrigin, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(txtcommodityTons, FishEntity.Constant.Goods, true);
            InitDataUtil.BindComboBoxData(txtProductionProcess, FishEntity.Constant.TechClass, true);
        }
        private void FormWarehouseReceipt_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                MenuCode = "M499"; ControlButtomRoles();
                strWhere = " codeNum='" + Megres . oddNum + "'";
                _model = _bll.GetModel(strWhere);
                if (_model == null)
                {
                    MessageBox.Show("没有记录了");
                }
                else {
                    setValue();
                    //List<FishEntity.PicInfoAll> dicPic = _bll.GetModel(_model.id, this.Name);
                    //if (dicPic == null || dicPic.Count < 1)
                    //{

                    //}
                    //else {
                    //    //setValue(dicPic);
                    //}
                }
            }
            else
                strWhere = string . Empty;
            //权限控制功能。
            Megres . oddNum = string . Empty;
        }

        #region Main
        public override int Query ( )
        {
            FormWarehouseReceiptQuery form = new FormWarehouseReceiptQuery ( this . Text + "查询" );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                strWhere = form . getWhere;
                _model = _bll . GetModel ( strWhere );
                if ( _model == null )
                {
                    MessageBox . Show ( "没有记录了" );
                    return 0;
                }
                setValue ( );
                //List<FishEntity . PicInfoAll> dicPic = _bll . GetModel ( _model . id ,this . Name );
                //if ( dicPic == null || dicPic . Count < 1 )
                //    return 0;
                //setValue ( dicPic );
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
            dtpReportingTime.Value = dtpTestTime.Value = dtpFumigationDate.Value =  DateTime.Now;
            //clearControl ( );
            txtcode . Text = _bll . getCode ( );
            _bll = new FishBll.Bll.WarehouseReceiptBll();
            _model = new FishEntity.WarehouseReceiptEntity();//select codeNum,codeNumContract from t_purchaseApplication
            if (getname!=""&&getname!=null)
            {
                _model = _bll.ADDModel(" codenum='"+getname+"' ");
                if (_model != null)
                {
                    txtcodeNum.Text = _model.codeNum;
                    txtcodeNumContract.Text = _model.codeNumContract;
                }
            }

            return base . Add ( );
        }
        public override int Delete ( )
        {
            _model . id = txtcode . Tag == null ? 0 : Convert . ToInt32 ( txtcode . Tag );
            _model . code = txtcode . Text;
            
            if ( _bll . Exists_rksqd ( _model . code ) )
            {
                MessageBox . Show ( "此单据的数据已经被入库申请单引用,不允许删除" );
                return 0;
            }

            result = _bll . Delete ( _model . id ,this . Name ,_model . code );
            if ( result )
            {
                //MessageBox . Show ( "成功删除" );
                //clearControl ( );
                Previous ( );
            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        public override int Modify ( )
        {
            if ( getValue ( ) == false )
                return 0;
            //List<FishEntity . PicInfoAll> dicPic = getValueView ( );
            int id = _bll . Update ( _model ,this . Name );
            if ( id > 0 )
                MessageBox . Show ( "成功保存" );
            else
                MessageBox . Show ( "保存失败" );

            return base . Modify ( );
        }
        public override void Save ( )
        {
            if ( getValue ( ) == false )
                return;

            if ( _bll . Exists ( _model . code ) )
            {
                MessageBox . Show ( "此单已经存在,请编辑" );
                return;
            }

            //List<FishEntity . PicInfoAll> dicPic = getValueView ( );

            _model . id = _bll . Add ( _model  ,this . Name );
            if ( _model . id > 0 )
            {
                MessageBox . Show ( "成功保存" );
                txtcode . Tag = _model . id;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }
        public override void Review ( )
        {
            //TODO：送给谁？
            Review ( this . Name ,txtcodeNum.Text,txtcode . Text);
            base . Review ( );
        }
        #endregion

        #region Event
        private void txtcodeNumContract_DoubleClick ( object sender ,EventArgs e )
        {
            FormPurcurementContract form = new FormPurcurementContract ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                txtcodeNumContract . Text = form . getCode;
                txtcodeNum . Text = form . getCodeNum;
            }
        }
        private void txtfishId_DoubleClick ( object sender ,EventArgs e )
        {
            //FormFish form = new FormFish ( );
            //if ( form . ShowDialog ( ) == DialogResult . OK )
            //{
            //    txtfishId . Text = form . getCode;
            //}
            if (_bll.ExistsCaigou(txtcodeNum.Text))
            {
                FormPurchaseAppFishInfo form = new FormPurchaseAppFishInfo(txtcodeNum.Text);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    txtfishId.Text = form.getModel.fishId;
                }
            }
            else
            {
                MessageBox.Show("请添加基础数据！");

            }
        }
        private void txtcode_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtcode . Text ) )
            {
                MessageBox . Show ( "请查询" );
                return;
            }
            this . DialogResult = DialogResult . OK;
        }
        //private void btnAdd_Click ( object sender ,EventArgs e )
        //{
        //    errorProvider1 . Clear ( );
        //    if ( string . IsNullOrEmpty ( txtLeiBie . Text ) )
        //    {
        //        errorProvider1 . SetError ( txtLeiBie ,"请选择类别" );
        //        return;
        //    }

        //    _pic = new FishEntity . PicInfoAll ( );
        //    _pic . tableId = txtcode . Tag == null ? 0 : Convert . ToInt32 ( txtcode . Tag );
        //    _pic . picInfo = PictureOpreation . ReadPicture ( pic );
        //    _pic . tableName = this . Name;
        //    _pic . categroy = txtLeiBie . Text;
        //    _pic . remark = txtBeiZhu . Text;
        //    int idx = dataGridView1 . Rows . Add ( );
        //    dataGridView1 . Rows [ idx ] . Cells [ "tableId" ] . Value = _pic . tableId;
        //    dataGridView1 . Rows [ idx ] . Cells [ "tableName" ] . Value = _pic . tableName;
        //    dataGridView1 . Rows [ idx ] . Cells [ "picInfo" ] . Value = _pic . picInfo;
        //    dataGridView1 . Rows [ idx ] . Cells [ "categroy" ] . Value = _pic . categroy;
        //    dataGridView1 . Rows [ idx ] . Cells [ "remark" ] . Value = _pic . remark;
        //}
        //private void btnEdit_Click ( object sender ,EventArgs e )
        //{
        //    errorProvider1 . Clear ( );
        //    if ( string . IsNullOrEmpty ( txtLeiBie . Text ) )
        //    {
        //        errorProvider1 . SetError ( txtLeiBie ,"请选择类别" );
        //        return;
        //    }
        //    _pic = new FishEntity . PicInfoAll ( );
        //    _pic . tableId = txtcode . Tag == null ? 0 : Convert . ToInt32 ( txtcode . Tag );
        //    _pic . picInfo = PictureOpreation . ReadPictureToByte ( pic );
        //    _pic . tableName = this . Name;
        //    _pic . categroy = txtLeiBie . Text;
        //    _pic . remark = txtBeiZhu . Text;

        //    dataGridView1 . Rows [ selectIdx ] . Cells [ "picInfo" ] . Value = _pic . picInfo;
        //    dataGridView1 . Rows [ selectIdx ] . Cells [ "categroy" ] . Value = _pic . categroy;
        //    dataGridView1 . Rows [ selectIdx ] . Cells [ "remark" ] . Value = _pic . remark;
        //}
        //private void btnDelete_Click ( object sender ,EventArgs e )
        //{
        //    dataGridView1 . Rows . RemoveAt ( selectIdx );
        //    pic . Image = null;
        //    txtBeiZhu . Text = txtLeiBie . Text = string . Empty;
        //}
        //private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        //{
        //    if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
        //        return;
        //    selectIdx = e . RowIndex;
        //    txtLeiBie . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "categroy" ] . Value . ToString ( );
        //    txtBeiZhu . Text = dataGridView1 . Rows [ e . RowIndex ] . Cells [ "remark" ] . Value . ToString ( );
        //    pic . Image = PictureOpreation . ReadPicture ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "picInfo" ] . Value == null ? null : ( byte [ ] ) dataGridView1 . Rows [ e . RowIndex ] . Cells [ "picInfo" ] . Value );
        //}
        #endregion

        #region Method
        //void clearControl ( )
        //{
        //    foreach ( Control tc in panel3 . Controls )
        //    {
        //        if ( tc . GetType ( ) == typeof ( TextBox ) )
        //        {
        //            TextBox tb = tc as TextBox;
        //            tb . Text = string . Empty;
        //        }
        //        if ( tc . GetType ( ) == typeof ( PictureBox ) )
        //        {
        //            PictureBox pc = tc as PictureBox;
        //            pc . Image = null;
        //        }
        //    }
        //    dataGridView1 . Rows . Clear ( );
        //}
        bool getValue ( )
        {
            _model = new FishEntity . WarehouseReceiptEntity ( );
            decimal outResult = 0M;
            //int outResult = 0;

            errorProvider1 . Clear ( );

            if ( string . IsNullOrEmpty ( txtcodeNumContract . Text ) )
            {
                errorProvider1 . SetError ( txtcodeNumContract ,"不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( txtfishId . Text ) )
            {
                errorProvider1 . SetError ( txtfishId ,"不可为空" );
                return false;
            }

            _model . id = txtcode . Tag == null ? 0 : Convert . ToInt32 ( txtcode . Tag );
            _model . code = txtcode . Text;
            _model . codeNumContract = txtcodeNumContract . Text;
            _model . codeNum = txtcodeNum . Text;
            _model . fishId = txtfishId . Text;
            //_model . quaIden = txtquaIden . Text;
            _model . commodityTons = txtcommodityTons.Text;
            if ( !string . IsNullOrEmpty ( txtcommodityPack . Text ) && decimal . TryParse ( txtcommodityPack . Text ,out outResult) == false )
            {
                errorProvider1 . SetError ( txtcommodityPack ,"请重新填写" );
                return false;
            }
            _model . commodityPack = outResult;
            _model . commodity = txtcommodity . Text;
            //_model . speci = txtspeci . Text;
            _model . countryOfOrigin = cmbcountryOfOrigin . Text;
            _model . billName = txtbillName . Text;
            //_model . sign = txtsign . Text;
            _model . shipMent = txtshipMent . Text;
            _model . shipMentUser = txtshipMentUser . Text;
            //_model . checkAddDate = txtcheckAddDate . Text;
            //_model . sampling = txtsampling . Text;
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtdb.Text) && decimal.TryParse(txtdb.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtdb, "请重新填写");
                return false;
            }
            _model.db = outResult;
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtwater.Text) && decimal.TryParse(txtwater.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtwater, "请重新填写");
                return false;
            }
            _model.water = outResult;
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtzf.Text) && decimal.TryParse(txtzf.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtzf, "请重新填写");
                return false;
            }
            _model.zf = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtfreshness.Text) && decimal.TryParse(txtfreshness.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtfreshness, "请重新填写");
                return false;
            }
            _model.freshness = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtsy.Text) && decimal.TryParse(txtsy.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtsy, "请重新填写");
                return false;
            }
            _model.sy = outResult;
            
            _model . oxi = txtoxi . Text;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtweight . Text ) && decimal . TryParse ( txtweight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtweight ,"请重新填写" );
                return false;
            }
            _model . weight = outResult;
            //_model . package = txtpackage . Text;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtavgWeight . Text ) && decimal . TryParse ( txtavgWeight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtavgWeight ,"请重新填写" );
                return false;
            }
            _model . avgWeight = outResult;
            _model . shipper = txtshipper . Text;
            _model . shipperNum = txtshipperNum . Text;
            _model . billNames = txtbillNames . Text;
            _model . contractNum = txtcontractNum . Text;
            _model . goodsNum = txtgoodsNum . Text;
            _model . consi = txtconsi . Text;
            _model . preShip = txtpreShip . Text;
            _model . oceanShip = txtoceanShip . Text;
            //_model . navNum = txtnavNum . Text;
            //_model . agent = txtagent . Text;
            _model . receipt = txtreceipt . Text;
            //_model . shipHar = txtshipHar . Text;
            //_model . unShopHar = txtunShopHar . Text;
            //_model . desTi = txtdesTi . Text;
            _model . lastDesTi = txtlastDesTi . Text;
            outResult = 0M;
            //if ( !string . IsNullOrEmpty ( txtnum . Text ) && decimal . TryParse ( txtnum . Text ,out outResult ) == false )
            //{
            //    errorProvider1 . SetError ( txtnum ,"请重新填写" );
            //    return false;
            //}
            _model . num = outResult;
            _model . containNum = txtcontainNum . Text;
            _model . paper = txtpaper . Text;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtconWeight . Text ) && decimal . TryParse ( txtconWeight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtconWeight ,"请重新填写" );
                return false;
            }
            _model . conWeight = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtpakeWeight . Text ) && decimal . TryParse ( txtpakeWeight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtpakeWeight ,"请重新填写" );
                return false;
            }
            _model . pakeWeight = outResult;
            //_model . seal = txtseal . Text;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtfreight . Text ) && decimal . TryParse ( txtfreight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtfreight ,"请重新填写" );
                return false;
            }
            _model . freight = outResult;
            _model . freightAdd = txtfreightAdd . Text;
            _model . shipName = txtshipname . Text;
            outResult = 0M;
            //if ( !string . IsNullOrEmpty ( txtprice . Text ) && decimal . TryParse ( txtprice . Text ,out outResult ) == false )
            //{
            //    errorProvider1 . SetError ( txtprice ,"请重新填写" );
            //    return false;
            //}
            _model . price = outResult;
            _model . ForUnit = txtforUnit . Text;
            _model . SupCom = txtsupCom . Text;
            _model . Receive = txtreceive . Text;
            _model . ReceiveAdd = txtreceiveAdd . Text;
            //_model . QuaIndex = txtquaIndex . Text;
            _model . ContractNums = txtcontractNums . Text;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtpriceMJ . Text ) && decimal . TryParse ( txtpriceMJ . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtpriceMJ ,"请重新填写" );
                return false;
            }
            _model . PriceMJ = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtFOB . Text ) && decimal . TryParse ( txtFOB . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtFOB ,"请重新填写" );
                return false;
            }
            _model . FOB = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtCFR . Text ) && decimal . TryParse ( txtCFR . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtCFR ,"请重新填写" );
                return false;
            }
            _model . CFR = outResult;

            _model.AnalysisUnit= txtAnalysisUnit.Text;
            _model.AnalysisAddress= txtAnalysisAddress.Text;
            _model.AnalysisWebsite= txtAnalysisWebsite.Text;
            _model.ReportingTime= dtpReportingTime.Value;
            _model.Telephone= txtTelephone.Text;
            _model.Mailbox= txtMailbox.Text;
            _model.ReportAddress= txtReportAddress.Text;
            _model.Fax= txtFax.Text;
            _model.ProductionProcess= txtProductionProcess.Text;
            _model.StartingCountry= cmbStartingCountry.Text;
            _model.StartingCity= txtStartingCity.Text;
            _model.DestinationCountry= cmbDestinationCountry.Text;
            _model.DestinationCity= txtDestinationCity.Text;
            _model.ForwardingUnit= txtforwardingUnit.Text;
            _model.TestTime= dtpTestTime.Value;
            _model.CheckAddress=txtCheckAddress.Text;
            _model.SamplingContent= txtSamplingContent.Text;
            _model.InspectionUnit= txtInspectionUnit.Text;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtSGS_TVN.Text) && decimal.TryParse(txtSGS_TVN.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtSGS_TVN, "请重新填写");
                return false;
            }
            _model.SGS_TVN = outResult;
            
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtSGS_Sand.Text) && decimal.TryParse(txtSGS_Sand.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtSGS_Sand, "请重新填写");
                return false;
            }
            _model.SGS_Sand = outResult;
            
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtSGS_Histamine.Text) && decimal.TryParse(txtSGS_Histamine.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtSGS_Histamine, "请重新填写");
                return false;
            }
            _model.SGS_Histamine = outResult;

            _model.WeighingMethod= txtWeighingMethod.Text;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtAverageNetWeight.Text) && decimal.TryParse(txtAverageNetWeight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtAverageNetWeight, "请重新填写");
                return false;
            }
            _model.AverageNetWeight = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtAverageSkinWeight.Text) && decimal.TryParse(txtAverageSkinWeight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtAverageSkinWeight, "请重新填写");
                return false;
            }
            _model.AverageSkinWeight = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtTotalWeight.Text) && decimal.TryParse(txtTotalWeight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtTotalWeight, "请重新填写");
                return false;
            }
            _model.TotalWeight = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtTotalSkinWeight.Text) && decimal.TryParse(txtTotalSkinWeight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtTotalSkinWeight, "请重新填写");
                return false;
            }
            _model.TotalSkinWeight = outResult;



            _model.FumigationAddress= txtFumigationAddress.Text;
            _model.ChemicalConcentration= txtChemicalConcentration.Text;
            _model.FumigationDate= dtpFumigationDate.Value;
            _model.FumigationTime= dtpFumigationTime.Text;
            _model.FumigatingTemperature= txtFumigatingTemperature.Text;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLabel_Antioxidant.Text) && decimal.TryParse(txtLabel_Antioxidant.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtLabel_Antioxidant, "请重新填写");
                return false;
            }
            _model.Label_Antioxidant = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtQuote_FFA.Text) && decimal.TryParse(txtQuote_FFA.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtQuote_FFA, "请重新填写");
                return false;
            }
            _model.Quote_FFA = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtQuote_SandSalt.Text) && decimal.TryParse(txtQuote_SandSalt.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtQuote_SandSalt, "请重新填写");
                return false;
            }
            _model.Quote_SandSalt = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtQuote_Sand.Text) && decimal.TryParse(txtQuote_Sand.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtQuote_Sand, "请重新填写");
                return false;
            }
            _model.Quote_Sand = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtContractAntioxidant.Text) && decimal.TryParse(txtContractAntioxidant.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtContractAntioxidant, "请重新填写");
                return false;
            }
            _model.ContractAntioxidant = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLabel_Protein.Text) && decimal.TryParse(txtLabel_Protein.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtLabel_Protein, "请重新填写");
                return false;
            }
            _model.Label_Protein = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLabel_Water.Text) && decimal.TryParse(txtLabel_Water.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtLabel_Water, "请重新填写");
                return false;
            }
            _model.Label_Water = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLabel_Fat.Text) && decimal.TryParse(txtLabel_Fat.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtLabel_Fat, "请重新填写");
                return false;
            }
            _model.Label_Fat = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLabel_FFA.Text) && decimal.TryParse(txtLabel_FFA.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtLabel_FFA, "请重新填写");
                return false;
            }
            _model.Label_FFA = outResult;
            

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLabel_SandSalt.Text) && decimal.TryParse(txtLabel_SandSalt.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtLabel_SandSalt, "请重新填写"); 
                return false;
            }
            _model.Label_SandSalt = outResult;

            return true;
        }
        //List<FishEntity . PicInfoAll> getValueView ( )
        //{
        //    List<FishEntity . PicInfoAll> dicpic = new List<FishEntity . PicInfoAll> ( );
        //    dataGridView1 . EndEdit ( );
        //    for ( int i = 0 ; i < dataGridView1 . Rows . Count ; i++ )
        //    {
        //        FishEntity . PicInfoAll entity = new FishEntity . PicInfoAll ( );
        //        entity . tableId = txtcode . Tag == null ? 0 : Convert . ToInt32 ( txtcode . Tag );
        //        entity . tableName = this . Name;
        //        entity . picInfo = dataGridView1 . Rows [ i ] . Cells [ "picInfo" ] . Value == null ? new byte [ 0 ] : ( byte [ ] ) dataGridView1 . Rows [ i ] . Cells [ "picInfo" ] . Value;
        //        entity . categroy = dataGridView1 . Rows [ i ] . Cells [ "categroy" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "categroy" ] . Value . ToString ( );
        //        entity . remark = dataGridView1 . Rows [ i ] . Cells [ "remark" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "remark" ] . Value . ToString ( );
        //        dicpic . Add ( entity );
        //    }

        //    return dicpic;
        //}
        void setValue ( )
        {
            txtcode . Tag = _model . id;
            txtcode . Text = _model . code;
            txtcodeNumContract . Text = _model . codeNumContract;
            txtcodeNum . Text = _model . codeNum;
            txtfishId . Text = _model . fishId;
            //txtquaIden . Text = _model . quaIden;
            txtcommodityTons . Text = _model . commodityTons . ToString ( );
            txtcommodityPack . Text = _model . commodityPack . ToString ( );
            txtcommodity . Text = _model . commodity;
            //txtspeci . Text = _model . speci;
            cmbcountryOfOrigin . Text = _model . countryOfOrigin;
            txtbillName . Text = _model . billName;
            //txtsign . Text = _model . sign;
            txtshipMent . Text = _model . shipMent;
            txtshipMentUser . Text = _model . shipMentUser;
            //txtcheckAddDate . Text = _model . checkAddDate;
            //txtsampling . Text = _model . sampling;
            txtdb . Text = _model . db.ToString();
            txtwater . Text = _model . water.ToString();
            txtzf . Text = _model . zf.ToString();
            txtfreshness . Text = _model . freshness.ToString();
            txtsy . Text = _model . sy.ToString();
            txtoxi . Text = _model . oxi;
            txtweight . Text = _model . weight . ToString ( );
            //txtpackage . Text = _model . package;
            txtavgWeight . Text = _model . avgWeight . ToString ( );
            txtshipper . Text = _model . shipper;
            txtshipperNum . Text = _model . shipperNum;
            txtbillNames . Text = _model . billNames;
            txtcontractNum . Text = _model . contractNum;
            txtgoodsNum . Text = _model . goodsNum;
            txtconsi . Text = _model . consi;
            txtpreShip . Text = _model . preShip;
            txtoceanShip . Text = _model . oceanShip;
            //txtnavNum . Text = _model . navNum;
            //txtagent . Text = _model . agent;
            txtreceipt . Text = _model . receipt;
            //txtshipHar . Text = _model . shipHar;
            //txtunShopHar . Text = _model . unShopHar;
            //txtdesTi . Text = _model . desTi;
            txtlastDesTi . Text = _model . lastDesTi;
            //txtnum . Text = _model . num . ToString ( );
            txtcontainNum . Text = _model . containNum;
            txtpaper . Text = _model . paper;
            txtconWeight . Text = _model . conWeight . ToString ( );
            txtpakeWeight . Text = _model . pakeWeight . ToString ( );
            //txtseal . Text = _model . seal;
            txtfreight . Text = _model . freight . ToString ( );
            txtfreightAdd . Text = _model . freightAdd;
            txtshipname . Text = _model . shipName;
            //txtprice . Text = _model . price . ToString ( );
            txtforUnit . Text = _model . ForUnit;
            txtsupCom . Text = _model . SupCom;
            txtreceive . Text = _model . Receive;
            txtreceiveAdd . Text = _model . ReceiveAdd;
            //txtquaIndex . Text = _model . QuaIndex;
            txtcontractNums . Text = _model . ContractNums;
            txtpriceMJ . Text = _model . PriceMJ . ToString ( );
            txtFOB . Text = _model . FOB . ToString ( );
            txtCFR . Text = _model . CFR . ToString ( );
            //////
            txtAnalysisUnit.Text = _model.AnalysisUnit.ToString() ;
            txtAnalysisAddress.Text = _model.AnalysisAddress.ToString();
            txtAnalysisWebsite.Text = _model.AnalysisWebsite.ToString();
            if (_model.ReportingTime == null)
            {
                dtpReportingTime.CustomFormat = " ";
            }
            else
            {
                dtpReportingTime.Value = Convert.ToDateTime(_model.ReportingTime.Value.ToString());
            }
            
            txtTelephone.Text = _model.Telephone.ToString();
            txtMailbox.Text = _model.Mailbox.ToString();
            txtReportAddress.Text = _model.ReportAddress.ToString();
            txtFax.Text = _model.Fax.ToString();
            txtProductionProcess.Text = _model.ProductionProcess.ToString();
            cmbStartingCountry.Text = _model.StartingCountry.ToString();
            txtStartingCity.Text = _model.StartingCity.ToString();
            cmbDestinationCountry.Text = _model.DestinationCountry.ToString();
            txtDestinationCity.Text = _model.DestinationCity.ToString();
            txtforwardingUnit.Text = _model.ForwardingUnit.ToString();
            if (_model.TestTime == null)
            {
                dtpTestTime.CustomFormat = " ";
            }
            else
            {
                dtpTestTime.Value = Convert.ToDateTime(_model.TestTime.Value.ToString());
            }
            txtCheckAddress.Text = _model.CheckAddress.ToString();
            txtSamplingContent.Text = _model.SamplingContent.ToString();
            txtInspectionUnit.Text = _model.InspectionUnit.ToString();
            txtSGS_TVN.Text = _model.SGS_TVN.ToString();
            txtSGS_Sand.Text = _model.SGS_Sand.ToString();
            txtSGS_Histamine.Text = _model.SGS_Histamine.ToString();
            txtWeighingMethod.Text = _model.WeighingMethod;
            txtAverageNetWeight.Text = _model.AverageNetWeight.ToString();
            txtAverageSkinWeight.Text = _model.AverageSkinWeight.ToString();
            txtTotalWeight.Text = _model.TotalWeight.ToString();
            txtTotalSkinWeight.Text = _model.TotalSkinWeight.ToString();
            txtFumigationAddress.Text = _model.FumigationAddress;
            txtChemicalConcentration.Text = _model.ChemicalConcentration.ToString();
            if (_model.FumigationDate == null)
            {
                dtpFumigationDate.CustomFormat = " ";
            }
            else
            {
                dtpFumigationDate.Value = Convert.ToDateTime(_model.FumigationDate.Value.ToString());
            }
            dtpFumigationTime.Text= _model.FumigationTime;
            
            txtFumigatingTemperature.Text = _model.FumigatingTemperature.ToString();
            txtLabel_Antioxidant.Text = _model.Label_Antioxidant.ToString();
            txtQuote_FFA.Text = _model.Quote_FFA.ToString();
            txtQuote_SandSalt.Text = _model.Quote_SandSalt.ToString();
            txtQuote_Sand.Text = _model.Quote_Sand.ToString();
            txtContractAntioxidant.Text = _model.ContractAntioxidant.ToString();
            txtLabel_Protein.Text = _model.Label_Protein.ToString();
            txtLabel_Water.Text = _model.Label_Water.ToString();
            txtLabel_Fat.Text = _model.Label_Fat.ToString();
            txtLabel_FFA.Text = _model.Label_FFA.ToString();
            txtLabel_SandSalt.Text = _model.Label_SandSalt.ToString();
        }
        //void setValue ( List<FishEntity . PicInfoAll> dicPic )
        //{
        //    dataGridView1 . Rows . Clear ( );
        //    foreach ( FishEntity . PicInfoAll entity in dicPic )
        //    {
        //        int idx = dataGridView1 . Rows . Add ( );
        //        dataGridView1 . Rows [ idx ] . Cells [ "tableId" ] . Value = entity . tableId;
        //        dataGridView1 . Rows [ idx ] . Cells [ "tableName" ] . Value = entity . tableName;
        //        dataGridView1 . Rows [ idx ] . Cells [ "picInfo" ] . Value = entity . picInfo;
        //        dataGridView1 . Rows [ idx ] . Cells [ "categroy" ] . Value = entity . categroy;
        //        dataGridView1 . Rows [ idx ] . Cells [ "remark" ] . Value = entity . remark;
        //    }
        //}
        void QueryOne ( string operate ,string orderBy )
        {
            string whereEx = string . Empty;
            if ( string . IsNullOrEmpty ( strWhere ) )
                whereEx = "1=1";
            else
                whereEx = strWhere;
            if ( _model != null )
                whereEx = whereEx + " AND codeNumContract " + operate + orderBy;

            _model = _bll . GetModel ( whereEx );
            if ( _model == null )
            {
                MessageBox . Show ( "已经没有记录了" );
                return;
            }
            setValue ( );
            List<FishEntity . PicInfoAll> dicPic = _bll . GetModel ( _model . id ,this . Name );
            if ( dicPic . Count < 1 )
                return;
            //setValue ( dicPic );
        }
        /// <summary>
        /// 入库申请单需要的数据
        /// </summary>
        public FishEntity . WarehouseReceiptEntity getModel
        {
            get
            {
                return _model;
            }
        }
        #endregion

        private void txtAnalysisUnit_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModelWare;
                txtAnalysisUnit.Text = _model.AnalysisUnit;
            }
        }

        private void txtshipMent_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModelWare;
                txtshipMent.Text = _model.shipMent;
                txtshipMentUser.Text = _model.shipMentUser;
            }
        }

        private void txtreceive_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModelWare;
                txtreceive.Text = _model.Receive;
            }
        }

        private void txtsupCom_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                _model = form.getModelWare;
                txtsupCom.Text = _model.SupCom;
            }
        }

        private void dtpReportingTime_ValueChanged(object sender, EventArgs e)
        {
            this.dtpReportingTime.CustomFormat = null;
        }

        private void dtpTestTime_ValueChanged(object sender, EventArgs e)
        {
            this.dtpTestTime.CustomFormat = null;
        }

        private void dtpFumigationDate_ValueChanged(object sender, EventArgs e)
        {
            this.dtpFumigationDate.CustomFormat = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtcode.Text != "" && txtfishId.Text != "")
            {
                FormPackingWeightList form = new FormPackingWeightList(txtcode.Text, txtfishId.Text);
                form.Show();
            }
            else {
                MessageBox.Show("先新增进仓单！");
            }
        }

        private void btn_Annex_Click(object sender, EventArgs e)
        {
            FormWarehouseReceiptAnnex form = new FormWarehouseReceiptAnnex(txtcode.Text,_model.id,this.Name);
            form.ShowDialog();
        }

        private void label144_Click(object sender, EventArgs e)
        {
            FormNewWarehouseReceipt form = new FormNewWarehouseReceipt();
           form.ShowDialog();
        }
    }
}
