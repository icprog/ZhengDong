using System;
using System . Collections . Generic;
using System . Windows . Forms;

//t_presalerequisition  单头
//t_sgsindicators 单身
namespace FishClient
{
    public partial class FormPresaleRequisition : FormMenuBase
    {
        //做加法  现货里面的Query
        FishEntity. PresaleRequisitionHeadEntity _model=null;
        FishEntity . PresaleRequisitionBodyEntity _modelOne=null;

        FishBll.Bll.PresaleRequisitionBll _bll = null;
        
        string _where = string.Empty;
        string _rolewhere = string.Empty;
        string _orderBy = " order by id asc limit 1";
        bool result=false;string state=string.Empty;

        //FishEntity.PresaleRequisitionEntity _Pres = null;    
        //FishBll.Bll.happeningBll _happbll = new FishBll.Bll.happeningBll();
        //FishBll.Bll.sgsindicatorsBll _sgs = new FishBll.Bll.sgsindicatorsBll();


        public string getCode
        {
            get
            {
                return txtcode . Text;
            }
        }

        public FormPresaleRequisition()
        {
            InitializeComponent();
            this.panel1.Enabled = false;


            //InitDataUtil.BindComboBoxData(cmbModeOfTransport, FishEntity.Constant.ModeOfTransport, true);
            //cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;

            //InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            // cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;

            //消除dataErr错误
            this . dataGridView4 . DataError += delegate ( object sender ,DataGridViewDataErrorEventArgs e )
            {
            };
        }

        private void FormPresaleRequisition_Load ( object sender ,EventArgs e )
        {
            InitDataUtil . BindComboBoxData ( cmbtransport ,FishEntity . Constant . Modeoftransport ,true );
            InitDataUtil . BindComboBoxData ( yfCountry ,FishEntity . Constant . CountryType ,true );

            //panel2 . Enabled = false;

            BindCountryBrandData ( );

            menuStrip1 . Visible = true;
            tmiQuery . Visible = true;
            tmiAdd . Visible = true;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiClose . Visible = true;
            tmiCancel . Visible = false;
            tmiSave . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiExport . Visible = false;
            tmiReview . Visible = false;

            _rolewhere = Megres . oddNum;
            //QueryByWhere ( );
        }

        //新增
        public override int Add()
        {
            tmiSave .Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiDelete . Visible = false;
            tmiClose . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            tmiExport . Visible = false;
            tmiReview . Visible = false;

            _model = null;
            //_modelOne = null;

            dataGridView1 . Rows . Clear ( );
            dataGridView2 . Rows . Clear ( );
            dataGridView3 . Rows . Clear ( );
            dataGridView4 . Rows . Clear ( );

            Clear ( );

            codeNum ( );
            //panel2 . Enabled = true;

            dataGridView2 . Rows . Insert ( 0 ,new DataGridViewRow ( ) );
            dataGridView3 . Rows . Insert ( 0 ,new DataGridViewRow ( ) );
            dataGridView4 . Rows . Insert ( 0 ,new DataGridViewRow ( ) );

            state = "add";

            return 1;
        }

        //生成合同号
        protected void codeNum ( )
        {
            _model = new FishEntity . PresaleRequisitionHeadEntity ( );
            _bll = new FishBll . Bll . PresaleRequisitionBll ( );
            DateTime dt = _bll . getDate ( );
            _model . code = _bll . codeNum ( );
            if ( _model . code == string . Empty )
                _model . code = "ZD" + dt . ToString ( "MMdd" ) + "0001";
            else
            {
                if ( _model . code . Substring ( 2 ,4 ) == dt . ToString ( "MMdd" ) )
                    _model . code = "ZD" + ( Convert . ToInt64 ( _model . code . Substring ( 2 ,8 ) ) + 1 ) . ToString ( ) . PadLeft ( 8 ,'0' );
                else
                    _model . code = "ZD" + dt . ToString ( "MMdd" ) + "0001";
            }
            txtcode . Text = _model . code;
        }

        //查询
        public override int Query ( )
        {
            FormPresaleRequisitionCodition form = new FormPresaleRequisitionCodition ( "预售申请单查询" ,"合同编号：" );
            if ( form . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return 0;

            _where = form . GetWhereCondition;
            _rolewhere = string . Empty;
            QueryByWhere ( );

            return 1;
        }

        protected void QueryByWhere ( )
        {
            _bll = new FishBll . Bll . PresaleRequisitionBll ( );
            List<FishEntity . PresaleRequisitionHeadEntity> list = _bll . GetModelList ( _where + _rolewhere + _orderBy );
            if ( list == null || list . Count < 1 )
            {
                MessageBox . Show ( "查无记录。" );
            }
            else
            {
                _model = list [ 0 ];

                dataGridView1 . Rows . Clear ( );
                dataGridView2 . Rows . Clear ( );
                dataGridView3 . Rows . Clear ( );
                dataGridView4 . Rows . Clear ( );

                Clear ( );

                SetPresaleRequisition ( );
                Sethappening ( );
                Setsgsindicators ( );
                SetIndex ( );
                Ship ( );

                tmiModify . Visible = true;
                tmiDelete . Visible = true;
                tmiNext . Visible = true;
                tmiPrevious . Visible = true;
                tmiReview . Visible = true;
            }
            panel1.Enabled = true;
        }

        //单头赋值
        public void SetPresaleRequisition ( )
        {
            txtcode . Text = _model . code;
            txtcode . Tag = _model . id;
            txtsupplier . Text = _model . supplier;
            txtsupplier . Tag = _model . supplierid;
            txtdemand . Text = _model . demand;
            txtdemand . Tag = _model . demandid;
            if ( _model . Signdate != null && _model . Signdate > DateTime . MinValue && _model . Signdate < DateTime . MaxValue )
                dtpSigndate . Value = _model . Signdate;
            txtSignplace . Text = _model . Signplace;
            checkIndex . Checked = _model . testIndex == true ? true : false;
            checkrebateBool . Checked = _model . rebateBool == true ? true : false;
            texrebate . Text = _model . rebate . ToString ( );
            checkPortpriceBool . Checked = _model . PortpriceBool == true ? true : false;
            texPortprice . Text = _model . Portprice . ToString ( );
            checkCountryBool . Checked = _model . CountryBool == true ? true : false;
            //cmbCountry . Text = _model . Country;
            cmbtransport . Text = _model . ModeOfTransport;
            if ( _model . DeliveryDeadline != null && _model . DeliveryDeadline > DateTime . MinValue && _model . DeliveryDeadline < DateTime . MaxValue )
                dtpDeliveryDeadline . Value = _model . DeliveryDeadline;
            texFreight . Text = _model . Freight . ToString ( );
            texDeliveryPlace . Text = _model . DeliveryPlace;
            texTonday . Text = _model . Tonday . ToString ( );
            texTonRMB . Text = _model . TonRMB . ToString ( );
            texInteretDat . Text = _model . InteretDat . ToString ( );
            texInteretRMB . Text = _model . InteretRMB . ToString ( );
            texBanDan . Text = _model . BanDan;
            if ( _model . Signdt != null && _model . Signdt > DateTime . MinValue && _model . Signdt < DateTime . MaxValue )
                dtpSigndt . Value = _model . Signdt;
            txtBond . Text = _model . Bond . ToString ( );
            txtSupAc . Text = _model . SupAc;
            txtSuplimit . Text = _model . Suplimit . ToString ( );
            txtOpenbank . Text = _model . Openbank;
            txtCollectUnit . Text = _model . CollectUnit;
            txAcountNum . Text = _model . AcountNum;
        }

        //产品名称表
        public void Sethappening()
        {
            int productid = _model . id;
            List<FishEntity . PresaleRequisitionBodyEntity> tableOne = _bll . GetTableOne ( productid );
            Sethappening ( tableOne );
        }

        protected void Sethappening(List<FishEntity. PresaleRequisitionBodyEntity> happe)
        {
            dataGridView1.Rows.Clear();
            if (happe == null || happe.Count < 1) return;
            {
                foreach (FishEntity. PresaleRequisitionBodyEntity item in happe)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row . Cells [ "id" ] . Value = item . id;
                    row . Cells [ "codeNum_tre" ] . Value = item . codeNum;
                    row . Cells [ "yfId" ] . Value = item . yfId;
                    row . Cells [ "yfName" ] . Value = item . yfName;
                    row . Cells [ "yfUnit" ] . Value = item . yfUnit;
                    row . Cells [ "yfVarieties" ] . Value = item . yfVarieties;
                    row . Cells [ "yfNum" ] . Value = item . yfNum;
                    row . Cells [ "yfPrice" ] . Value = item . yfPrice;
                    row . Cells [ "weight" ] . Value = item . weight;
                }
            }
        }

        //SGS表
        public void Setsgsindicators()
        {
            int indexid = _model . id;
            List<FishEntity . PresaleRequisitionBodyEntity> tableTwo = _bll . GetTableTwo ( indexid );
            Setsgsindicators ( tableTwo );
        }

        protected void Setsgsindicators(List<FishEntity. PresaleRequisitionBodyEntity> SGSind)
        {
            dataGridView2.Rows.Clear();
            if (SGSind == null || SGSind.Count < 1) return;
            {
                foreach (FishEntity. PresaleRequisitionBodyEntity item in SGSind)
                {
                    int idx = dataGridView2.Rows.Add();
                    DataGridViewRow row = dataGridView2.Rows[idx];
                    row.Cells[ "id_one" ] .Value = item. id;
                    row.Cells[ "codeNum_one" ] .Value = item. codeNum;
                    row.Cells[ "yfId_one" ] .Value = item. yfId;
                    row.Cells[ "yfdb" ] .Value = item. yfdb;
                    row.Cells[ "yftvn" ] .Value = item. yftvn;
                    row.Cells[ "yfza" ] .Value = item. yfza;
                    row.Cells[ "yfFFA" ] .Value = item. yfFFA;
                    row.Cells[ "yfzf" ] .Value = item. yfzf;
                    row.Cells[ "yfsf" ] .Value = item. yfsf;
                    row.Cells[ "yfshy" ] .Value = item. yfshy;
                    row.Cells[ "yfs" ] .Value = item. yfs;
                }

               
            }
        }

        //国内检测指标
        public void SetIndex ( )
        {
            List<FishEntity . PresaleRequisitionBodyEntity> tableTre = _bll . GetTableTre ( _model . id );
            SetIndex ( tableTre );
        }

        protected void SetIndex ( List<FishEntity . PresaleRequisitionBodyEntity> Index )
        {
            dataGridView3 . Rows . Clear ( );
            if ( Index == null || Index . Count < 1 )
                return;
            {
                foreach ( FishEntity . PresaleRequisitionBodyEntity item in Index )
                {
                    int idx = dataGridView3 . Rows . Add ( );
                    DataGridViewRow row = dataGridView3 . Rows [ idx ];
                    row . Cells [ "id_two" ] . Value = item . id;
                    row . Cells [ "codeNum_two" ] . Value = item . codeNum;
                    row . Cells [ "yfId_tre" ] . Value = item . yfId;
                    row . Cells [ "yfcdb" ] . Value = item . yfcdb;
                    row . Cells [ "yftvntwo" ] . Value = item . yftvntwo;
                    row . Cells [ "yfhf" ] . Value = item . yfhf;
                }

                
            }
        }

        //船
        public void Ship ( )
        {
            List<FishEntity . PresaleRequisitionBodyEntity> tableFor = _bll . GetTableFor ( _model . id );
            Ship ( tableFor );
        }

        protected void Ship ( List<FishEntity . PresaleRequisitionBodyEntity> ShipIndex )
        {
            dataGridView4 . Rows . Clear ( );
            if ( ShipIndex == null || ShipIndex . Count < 1 )
                return;
            {
                foreach ( FishEntity . PresaleRequisitionBodyEntity item in ShipIndex )
                {
                    int idx = dataGridView4 . Rows . Add ( );
                    DataGridViewRow row = dataGridView4 . Rows [ idx ];
                    row . Cells [ "id_for" ] . Value = item . id;
                    row . Cells [ "codeNum_for" ] . Value = item . codeNum;
                    row . Cells [ "yfId_for" ] . Value = item . yfId;
                    row . Cells [ "yfcm" ] . Value = item . yfcm;
                    row . Cells [ "yfzjh" ] . Value = item . yfzjh;
                    row . Cells [ "yftdh" ] . Value = item . yftdh;
                    row . Cells [ "yfCountry" ] . Value = item . yfCountry;
                    row . Cells [ "yfpp" ] . Value = item . yfpp;
                }               
            }
        }

        // 送审
        public override void Review ( )
        {
            Review ( this . Name ,txtcode . Text, txtcode.Text);

            base . Review ( );
        }

        //删除
        public override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( txtcode . Tag . ToString ( ) ) )
            {
                MessageBox . Show ( "请选择删除的内容" );
                return 0;
            }
            if ( string . IsNullOrEmpty ( txtcode . Text . ToString ( ) ) )
            {
                MessageBox . Show ( "请选择删除的内容" );
                return 0;
            }
            if ( MessageBox . Show ( "确定删除此单内容?" ,"询问" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return 0;

            _model . id = ( int ) txtcode . Tag;
            _model . code = txtcode . Text;

            result = _bll . Delete ( _model . id ,_model . code );
            if ( result == true )
            {
                MessageBox . Show ( "删除成功" );

                _model = null;
                dataGridView1 . Rows . Clear ( );
                dataGridView2 . Rows . Clear ( );
                dataGridView3 . Rows . Clear ( );
                dataGridView4 . Rows . Clear ( );

                Clear ( );

                //panel2 . Enabled = false;

                Next ( );
            }
            else
                MessageBox . Show ( "删除失败" );

            return 0;
        }

        //清空
        protected void Clear ( )
        {
            errorProvider1 . Clear ( );

            txtcode . Text = string . Empty;
            txtcode . Tag = string . Empty;
            txtsupplier . Text = string . Empty;
            txtsupplier . Tag = string . Empty;
            txtdemand . Text = string . Empty;
            txtdemand . Tag = string . Empty;
            dtpSigndate . Value = DateTime . Now;
            txtSignplace.Text = "上海/传真";
            checkIndex . Checked = false;
            checkrebateBool . Checked = false;
            texrebate . Text = string . Empty;
            checkPortpriceBool . Checked = false;
            texPortprice . Text = string . Empty;
            checkCountryBool . Checked = false;
            //cmbCountry . Text = string . Empty;
            cmbtransport . Text = string . Empty;
            dtpDeliveryDeadline . Value = DateTime . Now;
            texFreight . Text = string . Empty;
            texDeliveryPlace . Text = string . Empty;
            texTonday . Text = string . Empty;
            texTonRMB . Text = string . Empty;
            texInteretDat . Text = string . Empty;
            texInteretRMB . Text = string . Empty;
            texBanDan . Text = string . Empty;
            dtpSigndt . Value = DateTime . Now;
            txtBond . Text = string . Empty;
            txtSupAc . Text = string . Empty;
            txtSuplimit . Text = string . Empty;
            txtOpenbank . Text = string . Empty;
            txtCollectUnit . Text = string . Empty;
            txAcountNum . Text = string . Empty;
        }

        protected void QueryOne ( string operate ,string orderBy )
        {
            panel1.Enabled = true;
            _rolewhere = string . Empty;
            if ( string . IsNullOrEmpty ( _where ) )
            {
                _rolewhere = "1=1";
            }
            else
            {
                _rolewhere = _where;
            }
            if ( _model != null )
            {
                _rolewhere += " AND code " + operate + "'" + _model . code + "'";
            }
            List<FishEntity . PresaleRequisitionHeadEntity> list = _bll . GetModelList ( _rolewhere + _orderBy );
            if ( list == null || list . Count < 1 )
            {
                //_Pres = null;
                MessageBox . Show ( "查无记录。" );
            }
            else
            {
                _model = list [ 0 ];

                dataGridView1 . Rows . Clear ( );
                dataGridView2 . Rows . Clear ( );
                dataGridView3 . Rows . Clear ( );
                dataGridView4 . Rows . Clear ( );

                Clear ( );

                SetPresaleRequisition ( );
                Sethappening ( );
                Setsgsindicators ( );
                SetIndex ( );
                Ship ( );

                tmiSave . Visible = false;
                tmiCancel . Visible = false;
                tmiAdd . Visible = true;
                tmiModify . Visible = true;
                tmiQuery . Visible = true;
                tmiDelete . Visible = true;
                tmiClose . Visible = true;
                tmiNext . Visible = true;
                tmiPrevious . Visible = true;
                tmiExport . Visible = true;
            }
        }

        //下一个
        public override void Next ( )
        {
            QueryOne ( " > " ,_orderBy );
        }

        //上一个
        public override void Previous ( )
        {
            QueryOne ( " < " ,_orderBy );

            base . Previous ( );
        }

        //取消
        public override void Cancel ( )
        {
            ControlButtomRoles ( );

            tmiSave . Visible = false;
            tmiCancel . Visible = false;
            tmiAdd . Visible = true;
            tmiModify . Visible = true;
            tmiQuery . Visible = true;
            tmiDelete . Visible = true;
            tmiClose . Visible = true;
            tmiNext . Visible = true;
            tmiPrevious . Visible = true;
            tmiExport . Visible = true;
            tmiReview . Visible = true;
        }

        //保存
        public override void Save ( )
        {
            _model = new FishEntity . PresaleRequisitionHeadEntity ( );
            _modelOne = new FishEntity . PresaleRequisitionBodyEntity ( );

            if ( GetPresaleRequisition ( ) == false )
                return;
            _model . createman = FishEntity . Variable . User . username;
            _model . createtime = _bll . getDate ( );
            _model . modifyman = _model . createman;
            _model . modifytime = _model . createtime;

            List<FishEntity . PresaleRequisitionBodyEntity> modelList = new List<FishEntity . PresaleRequisitionBodyEntity> ( );
            DataViewOne ( modelList );

            _bll = new FishBll . Bll . PresaleRequisitionBll ( );

            if ( state == "add" )
                result = _bll . Add ( _model ,modelList );
            else if ( state == "edit" )
                result = _bll . Edit ( _model ,modelList );

            if ( result == true )
            {
                MessageBox . Show ( "保存成功" );

                tmiSave . Visible = false;
                tmiCancel . Visible = false;
                tmiAdd . Visible = true;
                tmiModify . Visible = true;
                tmiQuery . Visible = true;
                tmiDelete . Visible = true;
                tmiClose . Visible = true;
                tmiReview . Visible = true;

                //panel2 . Enabled = false;
            }
            else
                MessageBox . Show ( "保存失败,请重试" );

            base . Save ( );
        }

        //编辑
        public override int Modify ( )
        {
            if ( _model==null )
            {
                MessageBox . Show ( "请查询需要编辑的内容" );
                return 0;
            }

            tmiQuery . Visible = false;
            tmiAdd . Visible = false;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiClose . Visible = false;
            tmiReview . Visible = false;

            //panel2 . Enabled = true;

            state = "edit";

            dataGridView2 . Rows . Insert ( dataGridView2 . Rows . Count ,new DataGridViewRow ( ) );
            dataGridView3 . Rows . Insert ( dataGridView3 . Rows . Count ,new DataGridViewRow ( ) );
            dataGridView4 . Rows . Insert ( dataGridView4 . Rows . Count ,new DataGridViewRow ( ) );

            return base . Modify ( );
        }

        //获取值
        public bool GetPresaleRequisition ( )
        {
            errorProvider1 . Clear ( );
            result = true;
            if ( string . IsNullOrEmpty ( txtcode.Text ) )
            {
                errorProvider1 . SetError ( txtcode ,"不可为空" );
                result = false;
            }
            if ( string . IsNullOrEmpty ( txtsupplier . Text ) )
            {
                errorProvider1 . SetError ( txtsupplier ,"不可为空" );
                result = false;
            }
            if ( string . IsNullOrEmpty ( txtdemand . Text ) )
            {
                errorProvider1 . SetError ( txtdemand ,"不可为空" );
                result = false;
            }
            if ( string . IsNullOrEmpty ( txtSignplace . Text ) )
            {
                errorProvider1 . SetError ( txtSignplace ,"不可为空" );
                result = false;
            }
            decimal de = 0M;
            if ( !string . IsNullOrEmpty ( texrebate . Text ) && decimal . TryParse ( texrebate . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texrebate ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( texPortprice . Text ) && decimal . TryParse ( texPortprice . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texPortprice ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( texFreight . Text ) && decimal . TryParse ( texFreight . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texFreight ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( texTonday . Text ) && decimal . TryParse ( texTonday . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texTonday ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( texTonRMB . Text ) && decimal . TryParse ( texTonRMB . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texTonRMB ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( texInteretDat . Text ) && decimal . TryParse ( texInteretDat . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texInteretDat ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( texInteretRMB . Text ) && decimal . TryParse ( texInteretRMB . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( texInteretRMB ,"请填写数字" );
                result = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( txtBond . Text ) && decimal . TryParse ( txtBond . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( txtBond ,"请填写数字" );
                result = false;
            }
            int it = 0;
            if ( !string . IsNullOrEmpty ( txtSuplimit . Text ) && int . TryParse ( txtSuplimit . Text ,out it ) == false )
            {
                errorProvider1 . SetError ( txtSuplimit ,"请填写数字" );
                result = false;
            }

            if ( result == false )
                return result;

            _model . code = txtcode . Text;
            _model . supplier = txtsupplier . Text;
            _model . supplierid = txtsupplier . Tag . ToString ( );
            _model . demand = txtdemand . Text;
            _model . demandid = txtdemand . Tag . ToString ( );
            _model . Signdate = dtpSigndate . Value;
            _model . Signplace = txtSignplace . Text;
            _model . testIndex = checkIndex . Checked == true ? true : false;
            _model . rebateBool = checkrebateBool . Checked == true ? true : false;
            _model . rebate = string . IsNullOrEmpty ( texrebate . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texrebate . Text ) ,2 );
            _model . PortpriceBool = checkPortpriceBool . Checked == true ? true : false;
            _model . Portprice = string . IsNullOrEmpty ( texPortprice . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texPortprice . Text ) ,2 );
            _model . CountryBool = checkCountryBool . Checked == true ? true : false;
            //_model . Country = cmbCountry . Text;
            _model . ModeOfTransport = cmbtransport . Text;
            _model . DeliveryDeadline = dtpDeliveryDeadline . Value;
            _model . Freight = string . IsNullOrEmpty ( texFreight . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texFreight . Text ) ,2 );
            _model . DeliveryPlace = texDeliveryPlace . Text;
            _model . Tonday = string . IsNullOrEmpty ( texTonday . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texTonday . Text ) );
            _model . TonRMB = string . IsNullOrEmpty ( texTonRMB . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texTonRMB . Text ) );
            _model . InteretDat = string . IsNullOrEmpty ( texInteretDat . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texInteretDat . Text ) );
            _model . InteretRMB = string . IsNullOrEmpty ( texInteretRMB . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( texInteretRMB . Text ) );
            _model . BanDan = texBanDan . Text;
            _model . Signdt = dtpSigndt . Value;
            _model . Bond = string . IsNullOrEmpty ( txtBond . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( txtBond . Text ) );
            _model . SupAc = txtSupAc . Text;
            _model . Suplimit = string . IsNullOrEmpty ( txtSuplimit . Text ) == true ? 0 : Convert . ToInt32 ( txtSuplimit . Text );
            _model . Openbank = txtOpenbank . Text;
            _model . CollectUnit = txtCollectUnit . Text;
            _model . AcountNum = txAcountNum . Text;

            return result;
        }

        public void DataViewOne ( List<FishEntity . PresaleRequisitionBodyEntity> modelList )
        {
            dataGridView1 . EndEdit ( );
          
            foreach ( DataGridViewRow row in dataGridView1 . Rows )
            {
                if ( row . IsNewRow )
                    continue;
                _modelOne = new FishEntity . PresaleRequisitionBodyEntity ( );
                _modelOne . codeNum = _model . code;
                _modelOne . yfId = row . Cells [ "yfId" ] . Value == null ? string . Empty : row . Cells [ "yfId" ] . Value . ToString ( );
                _modelOne . yfName = row . Cells [ "yfName" ] . Value == null ? string . Empty : row . Cells [ "yfName" ] . Value . ToString ( );
                _modelOne . yfUnit = row . Cells [ "yfUnit" ] . Value == null ? string . Empty : row . Cells [ "yfUnit" ] . Value . ToString ( );
                _modelOne . yfVarieties = row . Cells [ "yfVarieties" ] . Value == null ? string . Empty : row . Cells [ "yfVarieties" ] . Value . ToString ( );
                _modelOne . yfNum = row . Cells [ "yfNum" ] . Value == null ? 0 : Math . Round ( decimal . Parse ( row . Cells [ "yfNum" ] . Value . ToString ( ) ) ,2 );
                _modelOne . yfPrice = row . Cells [ "yfPrice" ] . Value == null ? 0 : Math . Round ( decimal . Parse ( row . Cells [ "yfPrice" ] . Value . ToString ( ) ) ,2 );
                modelList . Add ( _modelOne );
            }

            dataGridView2 . EndEdit ( );
            foreach ( DataGridViewRow row in dataGridView2 . Rows )
            {
                if ( row . IsNewRow )
                    continue;
                _modelOne = new FishEntity . PresaleRequisitionBodyEntity ( );
                _modelOne . codeNum = _model . code;
                _modelOne . yfId = row . Cells [ "yfId_one" ] . Value == null ? string . Empty : row . Cells [ "yfId_one" ] . Value . ToString ( );
                _modelOne = modelList . Find ( ( i ) =>
                {
                    return i . yfId . Equals ( _modelOne . yfId );
                } );
                if ( _modelOne == null )
                    break;
                _modelOne . yfdb = row . Cells [ "yfdb" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfdb" ] . Value . ToString ( ) ) );
                _modelOne . yftvn = row . Cells [ "yftvn" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yftvn" ] . Value . ToString ( ) ) );
                _modelOne . yfza = row . Cells [ "yfza" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfza" ] . Value . ToString ( ) ) );
                _modelOne . yfFFA = row . Cells [ "yfFFA" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfFFA" ] . Value . ToString ( ) ) );
                _modelOne . yfzf = row . Cells [ "yfzf" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfzf" ] . Value . ToString ( ) ) );
                _modelOne . yfsf = row . Cells [ "yfsf" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfsf" ] . Value . ToString ( ) ) );
                _modelOne . yfshy = row . Cells [ "yfshy" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfshy" ] . Value . ToString ( ) ) );
                _modelOne . yfs = row . Cells [ "yfs" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfs" ] . Value . ToString ( ) ) );
            }

            dataGridView3 . EndEdit ( );
            foreach ( DataGridViewRow row in dataGridView3 . Rows )
            {
                _modelOne = new FishEntity . PresaleRequisitionBodyEntity ( );
                _modelOne . codeNum = _model . code;
                _modelOne . yfId = row . Cells [ "yfId_tre" ] . Value == null ? string . Empty : row . Cells [ "yfId_tre" ] . Value . ToString ( );
                _modelOne = modelList . Find ( ( i ) =>
                {
                    return i . yfId . Equals ( _modelOne . yfId );
                } );
                if ( _modelOne == null )
                    break;
                _modelOne . yfcdb = row . Cells [ "yfcdb" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfcdb" ] . Value . ToString ( ) ) );
                _modelOne . yftvntwo = row . Cells [ "yftvntwo" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yftvntwo" ] . Value . ToString ( ) ) );
                _modelOne . yfhf = row . Cells [ "yfhf" ] . Value == null ? 0 : Math . Round ( Convert . ToDecimal ( row . Cells [ "yfhf" ] . Value . ToString ( ) ) );
            }

            dataGridView4 . EndEdit ( );
            foreach ( DataGridViewRow row in dataGridView4 . Rows )
            {
                _modelOne = new FishEntity . PresaleRequisitionBodyEntity ( );
                _modelOne . codeNum = _model . code;
                _modelOne . yfId = row . Cells [ "yfId_for" ] . Value == null ? string . Empty : row . Cells [ "yfId_for" ] . Value . ToString ( );
                _modelOne = modelList . Find ( ( i ) =>
                {
                    return i . yfId . Equals ( _modelOne . yfId );
                } );
                if ( _modelOne == null )
                    break;
                _modelOne . yfcm = row . Cells [ "yfcm" ] . Value == null ? string . Empty : row . Cells [ "yfcm" ] . Value . ToString ( );
                _modelOne . yfzjh = row . Cells [ "yfzjh" ] . Value == null ? string . Empty : row . Cells [ "yfzjh" ] . Value . ToString ( );
                _modelOne . yftdh = row . Cells [ "yftdh" ] . Value == null ? string . Empty : row . Cells [ "yftdh" ] . Value . ToString ( );
                _modelOne . yfpp = row . Cells [ "yfpp" ] . Value == null ? string . Empty : row . Cells [ "yfpp" ] . Value . ToString ( );
                _modelOne . yfCountry = row . Cells [ "yfCountry" ] . Value == null ? string . Empty : row . Cells [ "yfCountry" ] . Value . ToString ( );
            }
        }

        //供方  
        private void txtsupplier_Click ( object sender ,EventArgs e )
        {
            FormCompanyList from = new FormCompanyList ( );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                if ( from . SelectCompany == null )
                    return;
                txtsupplier . Text = from . SelectCompany . fullname;
                txtsupplier . Tag = from . SelectCompany . code;
            }

        }
        //需方
        private void txtdemand_Click ( object sender ,EventArgs e )
        {
            FormCompanyList from = new FormCompanyList ( );
            DialogResult result = from . ShowDialog ( );
            if ( result == DialogResult . OK )
            {
                if ( from . SelectCompany == null )
                    return;
                txtdemand . Text = from . SelectCompany . fullname;
                txtdemand . Tag = from . SelectCompany . code;
            }
        }
        //
        private void dataGridView1_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "yfId" ,StringComparison . OrdinalIgnoreCase ) == true )
            {
                FormSetPresaleRequisiton from = new FormSetPresaleRequisiton ( "预售采购申请单鱼粉查询" );
                DialogResult result = from . ShowDialog ( );
                if ( result == DialogResult . OK )
                {
                    bool isOk = true;
                    FishEntity . ProductEntity _model = from . getPerson;
                    for ( int i = 0 ; i < dataGridView1 . Rows . Count - 1 ; i++ )
                    {
                        if ( !string . IsNullOrEmpty ( dataGridView1 . Rows [ i ] . Cells [ "yfId" ] . Value . ToString ( ) ) && dataGridView1 . Rows [ i ] . Cells [ "yfId" ] . Value . ToString ( ) == _model . code )
                        {
                            if ( i != e . RowIndex )
                            {
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if ( isOk == false )
                        return;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfId" ] . Value = _model . code;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfName" ] . Value = _model . name;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfVarieties" ] . Value = _model . specification;
                    dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfUnit" ] . Value = _model . nature + _model . specification;

                    dataGridView2.Rows[e.RowIndex].Cells["yfdb"].Value = _model.sgs_protein;
                    dataGridView2.Rows[e.RowIndex].Cells["yftvn"].Value = _model.sgs_tvn;
                    //dataGridView2.Rows[e.RowIndex].Cells["sgs_graypart"].Value = _model.sgs_graypart;
                    dataGridView2.Rows[e.RowIndex].Cells["yfshy"].Value = _model.sgs_sandsalt;
                    dataGridView2.Rows[e.RowIndex].Cells["yfza"].Value = _model.sgs_amine;
                    dataGridView2.Rows[e.RowIndex].Cells["yfffa"].Value = _model.sgs_ffa;
                    dataGridView2.Rows[e.RowIndex].Cells["yfzf"].Value = _model.sgs_fat;
                    dataGridView2.Rows[e.RowIndex].Cells["yfsf"].Value = _model.sgs_water;
                    dataGridView2.Rows[e.RowIndex].Cells["yfs"].Value = _model.sgs_sand;

                    dataGridView2 . Rows [ e . RowIndex ] . Cells [ "yfId_one" ] . Value = _model . code;

                    dataGridView3 . Rows [ e . RowIndex ] . Cells [ "yfId_tre" ] . Value = _model . code;

                    dataGridView4 . Rows [ e . RowIndex ] . Cells [ "yfId_for" ] . Value = _model . code;
                    //dataGridView4 . Rows [ e . RowIndex ] . Cells [ "yfpp" ] . Value = _model . brand;

                }
            }

            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "yfName" ,StringComparison . OrdinalIgnoreCase ) == true )
            {
                _list = new FishEntity . ReceiptRecordEntity ( );
                _list . codeHuiKou = string . IsNullOrEmpty ( texrebate . Text ) == true ? 0 : Convert . ToDecimal ( texrebate . Text );
                _list . codeOfYu = txtcode . Text;
                _list . codePrice = string . IsNullOrEmpty ( dataGridView1 . Rows [ e.RowIndex ] . Cells [ "yfPrice" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfPrice" ] . Value . ToString ( ) );
                _list . codeYunFei = string . IsNullOrEmpty ( texFreight . Text ) == true ? 0 : Convert . ToDecimal ( texFreight . Text );
                this . DialogResult = DialogResult . OK;
            }
        }
        private void dataGridView1_RowsAdded ( object sender ,DataGridViewRowsAddedEventArgs e )
        {
            DataGridViewRow row = new DataGridViewRow ( );
            row . CreateCells ( dataGridView2 );
            row . Cells [ 2 ] . Value = string . Empty;
            dataGridView2 . Rows . Add ( row );
            row = new DataGridViewRow ( );
            row . CreateCells ( dataGridView3 );
            row . Cells [ 2 ] . Value = string . Empty;
            dataGridView3 . Rows . Add ( row );
            row = new DataGridViewRow ( );
            row . CreateCells ( dataGridView4 );
            row . Cells [ 2 ] . Value = string . Empty;
            //row . Cells [ 6 ] . Value = string . Empty;
            dataGridView4 . Rows . Add ( row );
        }
        private void dataGridView1_RowsRemoved ( object sender ,DataGridViewRowsRemovedEventArgs e )
        {
            if ( dataGridView2 . Rows . Count > 0 )
            {
                dataGridView2 . Rows . RemoveAt ( e . RowIndex );
                dataGridView3 . Rows . RemoveAt ( e . RowIndex );
                dataGridView4 . Rows . RemoveAt ( e . RowIndex );
            }
        }
        private void dataGridView1_CellValueChanged ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "yfNum" ,StringComparison . OrdinalIgnoreCase ) == true || dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "yfPrice" ,StringComparison . OrdinalIgnoreCase ) == true )
            {
                _modelOne = new FishEntity . PresaleRequisitionBodyEntity ( );
                if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfNum" ] . Value != null )
                    _modelOne . yfNum = decimal . Parse ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfNum" ] . Value . ToString ( ) );
                else
                    _modelOne . yfNum = 0;
                if ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfPrice" ] . Value != null )
                    _modelOne . yfPrice = decimal . Parse ( dataGridView1 . Rows [ e . RowIndex ] . Cells [ "yfPrice" ] . Value . ToString ( ) );
                else
                    _modelOne . yfPrice = 0;

                dataGridView1 . Rows [ e . RowIndex ] . Cells [ "weight" ] . Value = _modelOne . yfNum * _modelOne . yfPrice;
            }
        }

        private void dataGridView4_CellClick ( object sender ,DataGridViewCellEventArgs e )
        {
            //if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
            //    return;

            //if ( dataGridView4 . Columns [ e . ColumnIndex ] . Name . Equals ( "yftdh" ,StringComparison . OrdinalIgnoreCase ) == true )
            //{
            //    FormBilloflading from = new FormBilloflading ( );
            //    DialogResult result = from . ShowDialog ( );
            //    if ( result == DialogResult . OK )
            //    {
            //        dataGridView4 . Rows [ e . RowIndex ] . Cells [ "yftdh" ] . Value = from . bdh;
            //    }
            //}
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (dataGridView4.Columns[e.ColumnIndex].Name.Equals("yftdh", StringComparison.OrdinalIgnoreCase) == true)
            {
                FormBilloftable form = new FormBilloftable();
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    bool isOk = true;
                    FishEntity.BillofladingEntity _model = form.bil;
                    for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()))// && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.Code
                        {
                            if (i != e.RowIndex)
                            {
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if (isOk == false)
                        return;
                    dataGridView4.Rows[e.RowIndex].Cells["yfcm"].Value = _model.Ferryname;
                    dataGridView4.Rows[e.RowIndex].Cells["yftdh"].Value = _model.Listname;
                }
            }
        }

        private void dataGridView4_CellValueChanged ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;

            if ( dataGridView4 . Columns [ e . ColumnIndex ] . Name . Equals ( "yfCountry" ,StringComparison . OrdinalIgnoreCase ) == true )
            {
                string pcode = dataGridView4 . Rows [ e . RowIndex ] . Cells [ "yfCountry" ] . Value . ToString ( );
                FishEntity . DictEntity pModel = InitDataUtil . DictList . Find ( ( i ) =>
                {
                    return i . code == pcode && i . pcode . Equals ( FishEntity . Constant . CountryType );
                } );
                int pid = 0;
                if ( pModel != null )
                {
                    pid = pModel . id;
                }

                List<FishEntity . DictEntity> list = InitDataUtil . DictList . FindAll ( ( i ) =>
                {
                    return i . pid == pid && i . pcode . Equals ( FishEntity . Constant . Brand );
                } );
                if ( true )
                {
                    if ( list == null )
                    {
                        list = new List<FishEntity . DictEntity> ( );
                    }
                    FishEntity . DictEntity empty = new FishEntity . DictEntity ( );
                    empty . code = "-1";
                    empty . name = "";
                    list . Insert ( 0 ,empty );
                }

                //pp . DataSource = list;
                //pp . DisplayMember = "name";

                if ( list != null )
                {
                    //pp . Items . Clear ( );
                    foreach ( FishEntity . DictEntity em in list )
                    {
                        yfpp . Items . Add ( em . name );
                    }
                }
            }
        }

        //国别
        private void cmbCountry_TextChanged ( object sender ,EventArgs e )
        {
            //BindCountryBrandData ( );
        }
        private void BindCountryBrandData()
        {
            //if ( yfpp . DataSource != null )
            //{
            //    dataGridView4 . CausesValidation = false;//取消验证格式 
            //}
            //yfpp . DataSource = null;
            //if (cmbCountry.Text == string.Empty) return;
            //string pcode = cmbCountry.Text.ToString();
            //FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) => { return i.code == pcode && i.pcode.Equals(FishEntity.Constant.CountryType); });
            //int pid = 0;
            //if (pModel != null)
            //{
            //    pid = pModel.id;
            //}

            //List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Brand); });
            //if (true)
            //{
            //    if (list == null)
            //    {
            //        list = new List<FishEntity.DictEntity>();
            //    }
            //    FishEntity.DictEntity empty = new FishEntity.DictEntity();
            //    empty . code = "-1";
            //    empty . name = "";
            //    list.Insert(0, empty);
            //}
            
            //yfpp . DataSource = list;
            //yfpp . DisplayMember = "name";
            //yfpp . ValueMember = "code";          
        }

        //生成预售合同
        private void txtcode_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( this . txtcode . Text ) )
            {
                this . DialogResult = DialogResult . None;
            }
            this . DialogResult = DialogResult . OK;
        }

        //双击
        FishEntity . ReceiptRecordEntity _list;
        private void dataGridView1_CellDoubleClick ( object sender ,DataGridViewCellEventArgs e )
        {
            //if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
            //    return;
            //if ( dataGridView1 . Columns [ e . ColumnIndex ] . Name . Equals ( "yfId" ,StringComparison . OrdinalIgnoreCase ) == true )
            //{
            //    _list = new FishEntity . ReceiptRecordEntity ( );
            //    _list . codeHuiKou = string . IsNullOrEmpty ( texrebate . Text ) == true ? 0 : Convert . ToDecimal ( texrebate . Text );
            //    _list . codeOfYu = txtcode . Text;
            //    _list . codePrice = string . IsNullOrEmpty ( dataGridView1 . Rows [ 5 ] . Cells [ "yfPrice" ] . Value . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dataGridView1 . Rows [ 5 ] . Cells [ "yfPrice" ] . Value . ToString ( ) );
            //    _list . codeYunFei = string . IsNullOrEmpty ( texFreight . Text ) == true ? 0 : Convert . ToDecimal ( texFreight . Text );
            //    this . DialogResult = DialogResult . OK;
            //}
        }

        public FishEntity . ReceiptRecordEntity getList
        {
            get
            {

                return _list;
            }
        }

    }
}
