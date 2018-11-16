using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FishEntity;
using System.Data;

namespace FishClient
{
    //t_batchsheet   t_batchsheets

    public partial class FormBatchSheet :FormMenuBase
    {
        FishBll.Bll.BatchSheetBll _bll=null;
        FishEntity.BatchSheetEntity _model=null;
        FishEntity.BatchSheetsEntity _models=null;
        bool result=false;string strWhere="1=1";
        
        FishEntity.FinishedProListEntity _entity=null;
        public FishEntity . FinishedProListEntity getModel
        {
            get
            {
                return _entity;
            }
        }
        //fishid
        public string fishid() {
            _models = new FishEntity.BatchSheetsEntity();
            FishBll.Bll.BatchSheetBll bll = new FishBll.Bll.BatchSheetBll();
            _models.fishId = bll.fishid();
            string str = string.Empty;
            int sum = 0;
            if (_models.fishId == string.Empty)
            {
                str = "CP" + "10000001";
            }
            else
            {
                sum = int.Parse(_models.fishId) + 1;
                str = "CP" + sum;
            }
            return str;
        }
        public string cpcodeNum()
        {
            string str = string.Empty;
            if (_models == null)
            {
                _models = new FishEntity.BatchSheetsEntity();
            }
            DateTime dt = _bll.getDate();
            _models.codeNumContract = _bll.code();
            if (_models.codeNumContract == string.Empty)
                _models.codeNumContract = "CP" + dt.ToString("yyyyMMdd") + "001";
            else
            {
                if (_models.codeNumContract.Substring(2, 8) == dt.ToString("yyyyMMdd"))
                    _models.codeNumContract = "CP" + (Convert.ToInt64(_models.codeNumContract.Substring(2, 11)) + 1).ToString().PadLeft(8, '0');
                else
                    _models.codeNumContract = "CP" + dt.ToString("yyyyMMdd") + "001";
            }
            return _models.codeNumContract;
        }
        public  string Numbering()
        {
            _models = new FishEntity.BatchSheetsEntity();
            FishBll.Bll.BatchSheetBll bll = new FishBll.Bll.BatchSheetBll();
            _models.codeNum = bll.Numbering();
            string str = string.Empty;
            int sum = 0;
            if (_models.codeNum == string.Empty)
            {
                str = DateTime.Now.Year.ToString() + "P" + "0001001";
            }
            else
            {
                sum = int.Parse(_models.codeNum) + 1000;
                _models.codeNum = sum.ToString();
                while (_models.codeNum.Length != 7)
                {
                    _models.codeNum = "0" + _models.codeNum;
                }
                str = DateTime.Now.Year.ToString() + "P" + _models.codeNum;
            }
            return str;
        }
        public FormBatchSheet ( )
        {
            InitializeComponent ( );
            ReadColumnConfig(dataGridView1, "Set_101");
            ReadColumnConfig(dataGridView2, "Set_102");
            MenuCode = "M459"; ControlButtomRoles();
            _bll = new FishBll . Bll . BatchSheetBll ( );
            _model = new FishEntity . BatchSheetEntity ( );
            _models = new FishEntity . BatchSheetsEntity ( );
            //readonlyCol ( );
        }
        public FormBatchSheet(string code)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_101");
            ReadColumnConfig(dataGridView2, "Set_102");
            MenuCode = "M459"; ControlButtomRoles();
            _bll = new FishBll.Bll.BatchSheetBll();
            _model = new FishEntity.BatchSheetEntity();
            _models = new FishEntity.BatchSheetsEntity();
            readonlyCol();
            if (code!=null&&code!="")
            {
                _model = _bll.getModel(" code='"+ code + "' ");
                code = string.Empty;
                if (_model != null)
                {
                    txtCode.Text = _model.code;
                    if (_model.productionDate < DateTime.MaxValue && _model.productionDate > DateTime.MinValue)
                        datePro.Value = Convert.ToDateTime(_model.productionDate);
                    if (string.IsNullOrEmpty(_model.code))
                        return ;
                    List<FishEntity.BatchSheetsEntity> modelList = _bll.modelList(_model.code);
                    if (modelList == null || modelList.Count < 0)
                        return ;
                    setValue(modelList);
                }
                else
                    _model = new FishEntity.BatchSheetEntity();
            }
        }

        #region Main
        public override int Query ( )
        {
            FormBatchSheetQuery form = new FormBatchSheetQuery ( this . Text + "查询" );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                strWhere = form . getWhere;
                _model = _bll . getModel ( strWhere );
                if ( _model != null )
                {
                    txtCode . Text = _model . code;
                    if ( _model . productionDate < DateTime . MaxValue && _model . productionDate > DateTime . MinValue )
                        datePro . Value = Convert . ToDateTime ( _model . productionDate );
                    if ( string . IsNullOrEmpty ( _model . code ) )
                        return 0;
                    List<FishEntity . BatchSheetsEntity> modelList = _bll . modelList ( _model . code );
                    if ( modelList == null || modelList . Count < 0 )
                        return 0;
                    readonlyCol();
                    setValue ( modelList );
                }
                else
                    _model = new FishEntity . BatchSheetEntity ( );
            }

            return base . Query ( );
        }
        public override int Add ( )
        {
            readonlyCol ( );
            txtCode . Text = _bll . getCode ( );
            dataGridView2.Rows[0].Cells["sfishId"].Value = fishid();
            dataGridView2.Rows[0].Cells["scodeNum"].Value = Numbering();
            dataGridView2.Rows[0].Cells["scodeNumContract"].Value = cpcodeNum();

            return base . Add ( );
        }
        public override int Delete ( )
        {
            _model . code = txtCode . Text;

            if ( _bll . Exists_isDel ( _model . code ) )
            {
                MessageBox . Show ( "成品出库单已经引用此表数据,不允许删除" );
                return 0;
            }

            result = _bll . Delete ( _model . code );
            if ( result )
            {
                readonlyCol ( );
                Previous ( );
            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }
        public override int Modify ( )
        {
            _model . code = txtCode . Text;
            _model . productionDate = datePro . Value;
            List<FishEntity . BatchSheetsEntity> _modelsList = getValue ( );

            result = _bll . Edit ( _model ,_modelsList );
            if ( result )
                MessageBox . Show ( "保存成功" );
            else
                MessageBox . Show ( "保存失败,请重试" );

            return base . Modify ( );
        }
        public override void Save ( )
        {
            _model . code = txtCode . Text;
            _model . productionDate = datePro . Value;
            List<FishEntity . BatchSheetsEntity> _modelsList = getValue ( );

            if ( _bll . Exists ( _model . code ) )
            {
                MessageBox . Show ( "数据已经存在,请修改" );
                return ;
            }

            result = _bll . Add ( _model ,_modelsList ,this . Name );
            if ( result )
                MessageBox . Show ( "保存成功" );
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . Save ( );
        }
        public override void Review ( )
        {
            Review ( this . Name ,txtCode . Text ,txtCode . Text );

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
        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ("fishId1", StringComparison . OrdinalIgnoreCase ) )
            {
                FormNewSelfcontrolWare form = new FormNewSelfcontrolWare( );
                if ( form . ShowDialog ( ) == DialogResult . OK )
                {
                    _models = form . getModel;
                    int idx = dataGridView1 . Rows . Add ( );
                    dataGridView1 . Rows [ idx ] . Cells [ "fishId1" ] . Value = _models . fishId;
                    dataGridView1 . Rows [ idx ] . Cells [ "codeNum" ] . Value = _models . codeNum;
                    dataGridView1 . Rows [ idx ] . Cells [ "codeNumContract" ] . Value = _models . codeNumContract;
                    dataGridView1.Rows[idx].Cells["qualitySpe"].Value = _models.qualitySpe;
                    dataGridView1 . Rows [ idx ] . Cells [ "country" ] . Value = _models . country;
                    dataGridView1.Rows[idx].Cells["price"].Value = _models.price;
                    dataGridView1 . Rows [ idx ] . Cells [ "brand" ] . Value = _models . brand;
                    dataGridView1 . Rows [ idx ] . Cells [ "protein" ] . Value = _models . protein;
                    dataGridView1 . Rows [ idx ] . Cells [ "tvn" ] . Value = _models . tvn;
                    dataGridView1 . Rows [ idx ] . Cells [ "salt" ] . Value = _models . salt;
                    dataGridView1 . Rows [ idx ] . Cells [ "acid" ] . Value = _models . acid;
                    dataGridView1 . Rows [ idx ] . Cells [ "ash" ] . Value = _models . ash;
                    dataGridView1 . Rows [ idx ] . Cells [ "histamine" ] . Value = _models . histamine;
                    dataGridView1 . Rows [ idx ] . Cells [ "las" ] . Value = _models . las;
                    dataGridView1 . Rows [ idx ] . Cells [ "das" ] . Value = _models . das;
                    dataGridView1 . Rows [ idx ] . Cells [ "tons" ] . Value = _models . tons;
                    dataGridView1 . Rows [ idx ] . Cells [ "rkCode" ] . Value = _models . rkCode;

                    dataGridView1.Rows[idx].Cells["goods"].Value = "鱼粉";
                    
                    setValueToSum ( );
                }
            }
        }
        private void txtCode_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtCode . Text ) )
                return;
            _entity = new FishEntity . FinishedProListEntity ( );
            _entity . plCode = txtCode . Text;
            this . DialogResult = DialogResult . OK;
        }
        #endregion

        #region Method
        void readonlyCol ( )
        {
            dataGridView1 . Rows . Clear ( );
            dataGridView2 . Rows . Clear ( );
            dataGridView2 . Rows . Add ( );
            //fishId . ReadOnly = codeNum . ReadOnly = codeNumContract . ReadOnly = qualitySpe . ReadOnly = country . ReadOnly = brand . ReadOnly = tons . ReadOnly = protein . ReadOnly = tvn . ReadOnly = salt . ReadOnly = acid . ReadOnly = ash . ReadOnly = histamine . ReadOnly = las . ReadOnly = das . ReadOnly = stons . ReadOnly = true;

            //txtCode . Text = string . Empty;
            datePro . Value = DateTime . Now;
        }
        void setValue ( List<FishEntity . BatchSheetsEntity> _modelsList )
        {
            dataGridView1 . Rows . Clear ( );
            foreach ( FishEntity . BatchSheetsEntity _entity in _modelsList )
            {
                if ( _entity . isSum == false )
                {
                    int idx = dataGridView1 . Rows . Add ( );
                    dataGridView1 . Rows [ idx ] . Cells [ "fishId1" ] . Value = _entity . fishId;
                    dataGridView1 . Rows [ idx ] . Cells [ "codeNum" ] . Value = _entity . codeNum;
                    dataGridView1 . Rows [ idx ] . Cells [ "codeNumContract" ] . Value = _entity . codeNumContract;
                    dataGridView1 . Rows [ idx ] . Cells [ "qualitySpe" ] . Value = _entity . qualitySpe;
                    dataGridView1 . Rows [ idx ] . Cells [ "country" ] . Value = _entity . country;
                    dataGridView1 . Rows [ idx ] . Cells [ "brand" ] . Value = _entity . brand;
                    dataGridView1 . Rows [ idx ] . Cells [ "goods" ] . Value = _entity . goods;
                    dataGridView1 . Rows [ idx ] . Cells [ "tons" ] . Value = _entity . tons;
                    dataGridView1 . Rows [ idx ] . Cells [ "protein" ] . Value = _entity . protein;
                    dataGridView1 . Rows [ idx ] . Cells [ "tvn" ] . Value = _entity . tvn;
                    dataGridView1 . Rows [ idx ] . Cells [ "salt" ] . Value = _entity . salt;
                    dataGridView1 . Rows [ idx ] . Cells [ "acid" ] . Value = _entity . acid;
                    dataGridView1 . Rows [ idx ] . Cells [ "ash" ] . Value = _entity . ash;
                    dataGridView1 . Rows [ idx ] . Cells [ "histamine" ] . Value = _entity . histamine;
                    dataGridView1 . Rows [ idx ] . Cells [ "las" ] . Value = _entity . las;
                    dataGridView1 . Rows [ idx ] . Cells [ "das" ] . Value = _entity . das;
                    dataGridView1 . Rows [ idx ] . Cells [ "price" ] . Value = _entity . price;
                    dataGridView1 . Rows [ idx ] . Cells [ "cost" ] . Value = _entity . cost;
                }
                else
                {
                    
                    dataGridView2 . Rows [ 0 ] . Cells [ "sfishId" ] . Value = _entity . fishId;
                    dataGridView2 . Rows [ 0 ] . Cells [ "scodeNum" ] . Value = _entity . codeNum;
                    dataGridView2 . Rows [ 0 ] . Cells [ "scodeNumContract" ] . Value = _entity . codeNumContract;
                    dataGridView2 . Rows [ 0 ] . Cells [ "squalitySpe" ] . Value = _entity . qualitySpe;
                    dataGridView2 . Rows [ 0 ] . Cells [ "scountry" ] . Value = _entity . country;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sbrand" ] . Value = _entity . brand;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sgoods" ] . Value = _entity . goods;
                    dataGridView2 . Rows [ 0 ] . Cells [ "stons" ] . Value = _entity . tons;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sprotein" ] . Value = _entity . protein;
                    dataGridView2 . Rows [ 0 ] . Cells [ "stvn" ] . Value = _entity . tvn;
                    dataGridView2 . Rows [ 0 ] . Cells [ "ssalt" ] . Value = _entity . salt;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sacid" ] . Value = _entity . acid;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sash" ] . Value = _entity . ash;
                    dataGridView2 . Rows [ 0 ] . Cells [ "shistamine" ] . Value = _entity . histamine;
                    dataGridView2 . Rows [ 0 ] . Cells [ "slas" ] . Value = _entity . las;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sdas" ] . Value = _entity . das;
                    dataGridView2 . Rows [ 0 ] . Cells [ "sprice" ] . Value = _entity . price;
                    dataGridView2 . Rows [ 0 ] . Cells [ "scost" ] . Value = _entity . cost;
                }
            }

            setValueToSum ( );
        }
        List<FishEntity . BatchSheetsEntity> getValue ( )
        {
            List<FishEntity . BatchSheetsEntity> _modelsList = new List<FishEntity . BatchSheetsEntity> ( );
            dataGridView1 . EndEdit ( );
            for ( int i = 0 ; i < dataGridView1 . Rows . Count ; i++ )
            {
                FishEntity . BatchSheetsEntity _eneity = new FishEntity . BatchSheetsEntity ( );
                _eneity . code = txtCode . Text;
                _eneity . fishId = dataGridView1 . Rows [ i ] . Cells [ "fishId1" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "fishId1" ] . Value . ToString ( );
                if ( !string . IsNullOrEmpty ( _eneity . fishId ) )
                {
                    _eneity . codeNum = dataGridView1 . Rows [ i ] . Cells [ "codeNum" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "codeNum" ] . Value . ToString ( );
                    _eneity . codeNumContract = dataGridView1 . Rows [ i ] . Cells [ "codeNumContract" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "codeNumContract" ] . Value . ToString ( );
                    _eneity . qualitySpe = dataGridView1 . Rows [ i ] . Cells [ "qualitySpe" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "qualitySpe" ] . Value . ToString ( );
                    _eneity . country = dataGridView1 . Rows [ i ] . Cells [ "country" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "country" ] . Value . ToString ( );
                    _eneity . brand = dataGridView1 . Rows [ i ] . Cells [ "brand" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "brand" ] . Value . ToString ( );
                    _eneity . goods = dataGridView1 . Rows [ i ] . Cells [ "goods" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "goods" ] . Value . ToString ( );
                    _eneity . tons = dataGridView1 . Rows [ i ] . Cells [ "tons" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ i ] . Cells [ "tons" ] . Value . ToString ( ) );
                    _eneity . protein = dataGridView1 . Rows [ i ] . Cells [ "protein" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "protein" ] . Value . ToString ( );
                    _eneity . tvn = dataGridView1 . Rows [ i ] . Cells [ "tvn" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "tvn" ] . Value . ToString ( );
                    _eneity . salt = dataGridView1 . Rows [ i ] . Cells [ "salt" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "salt" ] . Value . ToString ( );
                    _eneity . acid = dataGridView1 . Rows [ i ] . Cells [ "acid" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "acid" ] . Value . ToString ( );
                    _eneity . ash = dataGridView1 . Rows [ i ] . Cells [ "ash" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "ash" ] . Value . ToString ( );
                    _eneity . histamine = dataGridView1 . Rows [ i ] . Cells [ "histamine" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "histamine" ] . Value . ToString ( );
                    _eneity . las = dataGridView1 . Rows [ i ] . Cells [ "las" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "las" ] . Value . ToString ( );
                    _eneity . das = dataGridView1 . Rows [ i ] . Cells [ "das" ] . Value == null ? string . Empty : dataGridView1 . Rows [ i ] . Cells [ "das" ] . Value . ToString ( );
                    _eneity . price = dataGridView1 . Rows [ i ] . Cells [ "price" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ i ] . Cells [ "price" ] . Value );
                    _eneity . cost = dataGridView1 . Rows [ i ] . Cells [ "cost" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ i ] . Cells [ "cost" ] . Value );
                    _eneity . isSum = false;
                    _modelsList . Add ( _eneity );
                }
            }
            dataGridView2 . EndEdit ( );

            FishEntity . BatchSheetsEntity _eneitys = new FishEntity . BatchSheetsEntity ( );
            _eneitys . code = txtCode . Text;
            _eneitys . fishId = dataGridView2 . Rows [ 0 ] . Cells [ "sfishId" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sfishId" ] . Value . ToString ( );
            _eneitys . codeNum = dataGridView2 . Rows [ 0 ] . Cells [ "scodeNum" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "scodeNum" ] . Value . ToString ( );
            _eneitys . codeNumContract = dataGridView2 . Rows [ 0 ] . Cells [ "scodeNumContract" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "scodeNumContract" ] . Value . ToString ( );
            _eneitys . qualitySpe = dataGridView2 . Rows [ 0 ] . Cells [ "squalitySpe" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "squalitySpe" ] . Value . ToString ( );
            _eneitys . country = dataGridView2 . Rows [ 0 ] . Cells [ "scountry" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "scountry" ] . Value . ToString ( );
            _eneitys . brand = dataGridView2 . Rows [ 0 ] . Cells [ "sbrand" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sbrand" ] . Value . ToString ( );
            _eneitys . goods = dataGridView2 . Rows [ 0 ] . Cells [ "sgoods" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sgoods" ] . Value . ToString ( );
            _eneitys . tons = dataGridView2 . Rows [ 0 ] . Cells [ "stons" ] . Value == null ? 0 : Convert . ToDecimal ( dataGridView2 . Rows [ 0 ] . Cells [ "stons" ] . Value . ToString ( ) );
            _eneitys . protein = dataGridView2 . Rows [ 0 ] . Cells [ "sprotein" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sprotein" ] . Value . ToString ( );
            _eneitys . tvn = dataGridView2 . Rows [ 0 ] . Cells [ "stvn" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "stvn" ] . Value . ToString ( );
            _eneitys . salt = dataGridView2 . Rows [ 0 ] . Cells [ "ssalt" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "ssalt" ] . Value . ToString ( );
            _eneitys . acid = dataGridView2 . Rows [ 0 ] . Cells [ "sacid" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sacid" ] . Value . ToString ( );
            _eneitys . ash = dataGridView2 . Rows [ 0 ] . Cells [ "sash" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sash" ] . Value . ToString ( );
            _eneitys . histamine = dataGridView2 . Rows [ 0 ] . Cells [ "shistamine" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "shistamine" ] . Value . ToString ( );
            _eneitys . las = dataGridView2 . Rows [ 0 ] . Cells [ "slas" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "slas" ] . Value . ToString ( );
            _eneitys . das = dataGridView2 . Rows [ 0 ] . Cells [ "sdas" ] . Value == null ? string . Empty : dataGridView2 . Rows [ 0 ] . Cells [ "sdas" ] . Value . ToString ( );
            _eneitys . price = dataGridView2 . Rows [ 0 ] . Cells [ "sprice" ] . Value == null ? 0 : string . IsNullOrEmpty ( dataGridView2 . Rows [ 0 ] . Cells [ "sprice" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView2 . Rows [ 0 ] . Cells [ "sprice" ] . Value . ToString ( ) );
            _eneitys . cost = dataGridView2 . Rows [ 0 ] . Cells [ "scost" ] . Value == null ? 0 : string . IsNullOrEmpty ( dataGridView2 . Rows [ 0 ] . Cells [ "scost" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView2 . Rows [ 0 ] . Cells [ "scost" ] . Value . ToString ( ) );
            _eneitys . isSum = true;
            _modelsList . Add ( _eneitys );

            return _modelsList;
        }
        void setValueToSum ( )
        {
            dataGridView1 . EndEdit ( );
            int nums = 0;
            object str = null;
            for ( int i = 0 ; i < dataGridView1 . Rows . Count ; i++ )
            {
                //str = dataGridView1 . Rows [ i ] . Cells [ "goods" ] . Value;
                //nums += str == null ? 0 : string . IsNullOrEmpty ( str . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( str );
            }
            //dataGridView2 . Rows [ 0 ] . Cells [ "sgoods" ] . Value = nums;
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
                _model = new FishEntity . BatchSheetEntity ( );
                return;
            }
            txtCode . Text = _model . code;
            if ( _model . productionDate < DateTime . MaxValue && _model . productionDate > DateTime . MinValue )
                datePro . Value = Convert . ToDateTime ( _model . productionDate );
            if ( string . IsNullOrEmpty ( _model . code ) )
                return ;
            List<FishEntity . BatchSheetsEntity> modelList = _bll . modelList ( _model . code );
            if ( modelList != null && modelList . Count < 0 )
                return ;
            setValue ( modelList );
        }
        #endregion

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            decimal tonsSUM = 0M;
            decimal proteinSUM=0M,tvnSUM = 0M, saltSUM=0M, acidSUM=0M, ashSUM=0M, histamineSUM=0M, dasSUM=0M, lasSUM=0M, priceSUM=0M, costSUM=0;
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                if (row == null)
                    continue;
                if (row.Cells["tons"].Value != null && row.Cells["price"].Value != null && row.Cells["tons"].Value.ToString() != "" && row.Cells["price"].Value.ToString() != "")
                {
                    //cost
                    row.Cells["cost"].Value = Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["price"].Value.ToString());
                    costSUM+= Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["price"].Value.ToString());
                }
                else
                {
                    row.Cells["cost"].Value = 0;
                    costSUM += 0;
                }
                if (row.Cells["tons"].Value!=null)
                {
                    tonsSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString());
                }
                else
                {
                    tonsSUM += 0;
                }
                if (row.Cells["price"].Value != null)
                {
                    priceSUM += Convert.ToDecimal(row.Cells["price"].Value.ToString());
                }
                else
                {
                    priceSUM += 0;
                }
                if (row.Cells["protein"].Value != null && row.Cells["protein"].Value.ToString() != ""&& row.Cells["tons"].Value != null&& row.Cells["tons"].Value.ToString() != "")
                {
                    proteinSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["protein"].Value.ToString());
                }
                else
                {
                    proteinSUM += 0;
                }
                if (row.Cells["tvn"].Value != null && row.Cells["tvn"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    tvnSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["tvn"].Value.ToString());
                }
                else
                {
                    tvnSUM += 0;
                }
                if (row.Cells["salt"].Value != null && row.Cells["salt"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    saltSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["salt"].Value.ToString());
                }
                else
                {
                    saltSUM += 0;
                }
                if (row.Cells["acid"].Value != null && row.Cells["acid"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    acidSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["acid"].Value.ToString());
                }
                else
                {
                    acidSUM += 0;
                }
                if (row.Cells["ash"].Value != null && row.Cells["ash"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    ashSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["ash"].Value.ToString());
                }
                else
                {
                    ashSUM += 0;
                }
                if (row.Cells["histamine"].Value != null && row.Cells["histamine"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    histamineSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["histamine"].Value.ToString());
                }
                else
                {
                    histamineSUM += 0;
                }
                if (row.Cells["las"].Value != null && row.Cells["las"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    lasSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["las"].Value.ToString());
                }
                else
                {
                    lasSUM += 0;
                }
                if (row.Cells["das"].Value != null && row.Cells["das"].Value.ToString() != "" && row.Cells["tons"].Value != null && row.Cells["tons"].Value.ToString() != "")
                {
                    dasSUM += Convert.ToDecimal(row.Cells["tons"].Value.ToString()) * Convert.ToDecimal(row.Cells["das"].Value.ToString());
                }
                else
                {
                    dasSUM += 0;
                }
                //protein
            }
            int i = dataGridView1.Rows.Count;
            i--;
            dataGridView2.Rows[0].Cells["stons"].Value = tonsSUM;
            if (proteinSUM !=0&& tonsSUM!=0)
            {
                dataGridView2.Rows[0].Cells["sprotein"].Value = (Math.Truncate(proteinSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["sprotein"].Value = 0;
            }
            if (tvnSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["stvn"].Value = (Math.Truncate(tvnSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["stvn"].Value = 0;
            }
            if (saltSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["ssalt"].Value = (Math.Truncate(saltSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["ssalt"].Value = 0;
            }
            if (acidSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["sacid"].Value = (Math.Truncate(acidSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["sacid"].Value = 0;
            }
            if (ashSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["sash"].Value = (Math.Truncate(ashSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["sash"].Value = 0;
            }
            if (histamineSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["shistamine"].Value = (Math.Truncate(histamineSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["shistamine"].Value = 0;
            }
            if (lasSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["slas"].Value = (Math.Truncate(lasSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["slas"].Value = 0;
            }
            if (dasSUM != 0 && tonsSUM != 0)
            {
                dataGridView2.Rows[0].Cells["sdas"].Value =  (Math.Truncate(dasSUM / tonsSUM * 100) / 100.00m).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["sdas"].Value = 0;
            }
            decimal num1= (Math.Truncate(priceSUM / i * 100) / 100.00m);
            if (costSUM!=0&& tonsSUM!=0)
            {
                dataGridView2.Rows[0].Cells["scost"].Value = (Math.Truncate(tonsSUM * num1)).ToString("0.00");
            }
            else
            {
                dataGridView2.Rows[0].Cells["scost"].Value = 0;
            }
            dataGridView2.Rows[0].Cells["sprice"].Value = (Math.Truncate(priceSUM / i * 100) / 100.00m).ToString("0.00");
            dataGridView2.Rows[0].Cells["sgoods"].Value = "鱼粉";
            
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_101");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_101");
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView2.Columns, "Set_102");
            form.ShowDialog();

            ReadColumnConfig(dataGridView2, "Set_102");
        }
    }

}
