using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FishClient
{
    //t_finishedprolist
    public partial class FormFinishedProList : FormMenuBase
    {
        FishEntity.FinishedProListEntity _model = null;
        FishBll.Bll.FinishedProListBll _bll = null;
        bool result = false;
        string strWhere = string.Empty;
        string getname1 = string.Empty;
        DataTable tableView;

        public FormFinishedProList()
        {
            InitializeComponent();

            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Brand, true);
            country.SelectedValueChanged -= country_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            country.SelectedValueChanged += country_SelectedValueChanged;
            MenuCode = "M460"; ControlButtomRoles();
            _model = new FishEntity.FinishedProListEntity();
            _bll = new FishBll.Bll.FinishedProListBll();

            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Brand, true);
        }
        public FormFinishedProList(string name)
        {
            InitializeComponent();
            MenuCode = "M460"; ControlButtomRoles();
            _model = new FishEntity.FinishedProListEntity();
            _bll = new FishBll.Bll.FinishedProListBll();
            getname1 = name;
            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Brand, true);
            if (getname1 != "" && getname1 != null)
            {
                _model = new FishEntity.FinishedProListEntity();
                _bll = new FishBll.Bll.FinishedProListBll();
                _model = _bll.getModel(" plCode= '" + getname1 + "' ");
                if (_model == null)
                {
                    // MessageBox.Show("没有记录了");
                }
                else
                    setValue();
            }
        }

        #region Main
        public override int Query()
        {
            FormFinishedProListQuery form = new FormFinishedProListQuery(this.Text + "查询");
            if (form.ShowDialog() == DialogResult.OK)
            {
                strWhere = form.getWhere;
                _model = _bll.getModel(strWhere);
                if (_model == null)
                {
                    MessageBox.Show("没有记录了");
                    return 0;
                }
                setValue();
            }

            return base.Query();
        }
        public override int Add()
        {
            clearControl();
            tableView = _bll.getTableView(getname1);
            setadd(tableView);
            //code . Text = _bll . getCode ( );
            //CkCode.Text = _bll.getCkCode();
            //fishId.Text = _bll.getFishId();
            txtSaleCompany.Text = "上海旭尧国际贸易有限公司";
            txtSaleLinkman.Text = "林元克";
            return base.Add();
        }
        public void setadd(DataTable tableView) {
            if (tableView!=null)
            {
                plCode.Text = tableView.Rows[0]["code"].ToString();
                fishId.Text= tableView.Rows[0]["fishId"].ToString();
                code.Text= tableView.Rows[0]["codenum"].ToString();
                CkCode.Text= tableView.Rows[0]["codenumcontract"].ToString();
                date.Value=DateTime.Parse(tableView.Rows[0]["productiondate"].ToString());
                qualitySpe.Text= tableView.Rows[0]["qualitySpe"].ToString();
                country.Text = tableView.Rows[0]["country"].ToString();
                brand.Text= tableView.Rows[0]["brand"].ToString();
                tons.Text = tableView.Rows[0]["tons"].ToString();
                price.Text = tableView.Rows[0]["price"].ToString();
                protein.Text = tableView.Rows[0]["protein"].ToString();
                tvn.Text = tableView.Rows[0]["tvn"].ToString();
                histamine.Text = tableView.Rows[0]["histamine"].ToString();
                salt.Text = tableView.Rows[0]["salt"].ToString();
                acid.Text = tableView.Rows[0]["acid"].ToString();
                ash.Text = tableView.Rows[0]["ash"].ToString();
                das.Text = tableView.Rows[0]["das"].ToString();
                las.Text = tableView.Rows[0]["las"].ToString();
            }
        }
        
        public override int Delete ( )
        {
            _model . code = code . Text;

            //TODO:销售申请单是否存在此单号

            result = _bll . Delete ( _model . code );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                clearControl ( );
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
            //TODO:送审给谁
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
        private void plCode_DoubleClick ( object sender ,EventArgs e )
        {
            FormBatchSheet form = new FormBatchSheet ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                _model = form . getModel;
                if ( _model == null )
                    return;
                plCode . Text = _model . plCode;
            }
        }
        private void fishId_DoubleClick ( object sender ,EventArgs e )
        {
           
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
            decimal outResult = 0;
            errorProvider1 . Clear ( );

            if ( string . IsNullOrEmpty ( plCode . Text ) )
            {
                errorProvider1 . SetError ( plCode ,"不可为空" );
                return false;
            }

            if ( string . IsNullOrEmpty ( code . Text ) )
            {
                errorProvider1 . SetError ( code ,"不可为空" );
                return false;
            }
            if ( string . IsNullOrEmpty ( fishId . Text ) )
            {
                errorProvider1 . SetError ( fishId ,"不可为空" );
                return false;
            }

            if ( !string . IsNullOrEmpty ( tons . Text ) && decimal . TryParse ( tons . Text ,out outResult ) ==false)
            {
                errorProvider1 . SetError ( tons ,"请重新填写" );
                return false;
            }
            _model . tons = outResult;
            _model.Number = txtNumber.Text;
            _model.Zidingyi = txtzidingyi.Text;
            _model . code = code . Text;
            _model.CkCode = CkCode.Text;
            _model . fishId = fishId . Text;
            outResult = 0;
            if ( !string . IsNullOrEmpty ( price . Text ) && decimal . TryParse ( price . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( price ,"请重新填写" );
                return false;
            }
            _model . price = outResult;
            _model . plCode = plCode . Text;
            _model . date = date . Value;
            _model . country = country . Text;
            _model . brand = brand . Text;
            _model . qualitySpe = qualitySpe . Text;
            _model . goods = goods . Text;
           
            _model . protein = protein . Text;
            _model.FFA = FFA.Text;
            _model . tvn = tvn . Text;
            _model . salt = salt . Text;
            _model . acid = acid . Text;
            _model . ash = ash . Text;
            _model . histamine = histamine . Text;
            _model . las = las . Text;
            _model . das = das . Text;
            _model . remark = remark . Text;
            _model . zf = zf . Text;
            _model.Ajs = txtajs.Text;
            _model . Shipname = shipname . Text;
            _model . Zjh = zjh . Text;
            _model . BillName = billName . Text;
            _model.saleCompany= txtSaleCompany.Text;
            _model.saleLinkman = txtSaleLinkman.Text;

            return true;
        }
        void setValue ( )
        {
            code . Text = _model . code;
            CkCode.Text = _model.CkCode;
            goods . Text = _model . goods;
            price . Text = _model . price . ToString ( );
            plCode . Text = _model . plCode;
            if ( _model . date > DateTime . MinValue && _model . date < DateTime . MaxValue )
                date . Value = Convert . ToDateTime ( _model . date );
            else
                date . Value = DateTime . Now;
            country . Text = _model . country;
            brand . Text = _model . brand;
            qualitySpe . Text = _model . qualitySpe;
            goods . Text = _model . goods;
            tons . Text = _model . tons . ToString ( );
            txtNumber.Text = _model.Number;
            txtzidingyi.Text = _model.Zidingyi;
            protein . Text = _model . protein;
            FFA.Text = _model.FFA;
            tvn . Text = _model . tvn;
            salt . Text = _model . salt;
            acid . Text = _model . acid;
            ash . Text = _model . ash;
            histamine . Text = _model . histamine;
            las . Text = _model . las;
            das . Text = _model . das;
            remark . Text = _model . remark;
            zf . Text = _model . zf;
            txtajs.Text = _model.Ajs;
            shipname . Text = _model . Shipname;
            zjh . Text = _model . Zjh;
            billName . Text = _model . BillName;
            txtSaleCompany.Text = _model.saleCompany;
            txtSaleLinkman.Text = _model.saleLinkman;
            fishId . Text = _model . fishId;
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
        #endregion
        string getname = string.Empty;
        private void FormFinishedProList_Load(object sender, EventArgs e)
        {

            MenuCode = "M460"; ControlButtomRoles();
            InitDataUtil.BindComboBoxData(country, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(brand, FishEntity.Constant.Brand, true);
            _model = new FishEntity.FinishedProListEntity();
            _bll = new FishBll.Bll.FinishedProListBll();
            if (Megres.oddNum!=null&& Megres.oddNum!="")
            {

                _model = _bll.getModel(" code= '"+ Megres.oddNum + "' ");
                if (_model == null)
                {
                    MessageBox.Show("没有记录了");
                }else
                setValue();
            }
        }

        private void txtzidingyi_Click(object sender, EventArgs e)
        {
            FormCustomStandardTable form = new FormCustomStandardTable();
            if (form.ShowDialog() == DialogResult.OK)
            {
                //fishId.Text = form.getModel.fishId;
                protein.Text = form.getModel.protein;
                qualitySpe.Text = form.getModel.level;
                FFA.Text = form.getModel.ffa;
                histamine.Text = form.getModel.histamine;
                ash.Text = form.getModel.ash;
                zf.Text = form.getModel.fat;
                txtzidingyi.Text = form.getModel.code;
            }
        }

        private void label21_Click(object sender, EventArgs e)
        {
            //fishId.Text = _bll.getFishId();
        }
        void country_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //brand.DataSource = null;
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
    }
    }






