using System;
using System . Windows . Forms;

//t_ReceiptRecord  表
namespace FishClient
{
    public partial class FormReceiptRecord : FormMenuBase
    {
        /// <summary>
        /// 流程状态表刷新
        /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        FishEntity.ReceiptRecordEntity _list=null;
        FishBll.Bll.ReceiptRecordBll _bll=new FishBll.Bll.ReceiptRecordBll();
        bool isOk=false;string state=string.Empty, _orderBy = " order by id asc limit 1",_where=string.Empty,_rolewhere = string.Empty;
        string getname = string.Empty;
        public FormReceiptRecord (string name)
        {
            InitializeComponent ( );
            getname = name;
            this.panel1.Enabled = false;
            txtDepartMent . DataSource = _bll . getDepart ( );
            txtDepartMent . DisplayMember = "rolename";
            txtDepartMent . ValueMember = "roleid";
        }
        public FormReceiptRecord()
        {
            InitializeComponent();
            this.panel1.Enabled = false;
            txtDepartMent.DataSource = _bll.getDepart();
            txtDepartMent.DisplayMember = "rolename";
            txtDepartMent.ValueMember = "roleid";
        }

        private void FormReceiptRecord_Load ( object sender ,EventArgs e )
        {
            MenuCode = "M427"; ControlButtomRoles();
            if (Megres.oddNum!="")
            {
                _rolewhere = "and code='" + Megres.oddNum + "'";
                queryWhere(_rolewhere);
                Megres.oddNum = string.Empty;
            }
        }
        public override void Review()
        {
            Review(this.Name, txtNumbering.Text, txtOddNum.Text);
            //if (txtNumbering.Text!="")
            //{
            //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //    _Refreshbll.GetFormReceiptRecord(txtNumbering.Text);
            //}
            base.Review();
        }
        public override int Query ( )
        {
            FormPresaleRequisitionCodition form = new FormPresaleRequisitionCodition ( "收款记录单查询" ,"  单号：" );
            if ( form . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return 0;
            _where = form . GetWhereCondition;
            queryWhere ( _where );

            //tmiModify . Visible = true;
            //tmiDelete . Visible = true;
            //tmiNext . Visible = true;
            //tmiPrevious . Visible = true;

            return base . Query ( );
        }

        void queryWhere ( string strwhere )
        {
            _list = _bll . getList ( strwhere );
            if ( _list != null )
            {
                panel1.Enabled = true;
                setValue ( _list );
            }
        }

        public override int Add ( )
        {
            txtOddNum . Text = _bll . GetCode ( );
            panel1.Enabled = true;
            tmiQuery . Visible = false;
            tmiAdd . Visible = false;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiClose . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiExport . Visible = false;
            //tmiNext . Visible = false;
            //tmiPrevious . Visible = false;
            AddSet();
            state = "add";
            if (getname!="")
            {
                FishEntity.SalesRequisitionEntity _model = new FishEntity.SalesRequisitionEntity();
                _bll = new FishBll.Bll.ReceiptRecordBll();
                _model = _bll.getFKSQD(getname);
                if (_model!=null)
                {
                    txtNumbering.Text = _model.Numbering;
                    txtCodeOdd.Text = _model.code;
                    txtDemaUndnit.Text = _model.demand;
                    txtDemaUndnit.Tag = _model.demandId;
                    txtDemandSideContact.Text = _model.DemandContact;
                    txtDemandSideContact.Tag = _model.DemandContactId;
                    txtPrice.Text =_model.Portprice.ToString();
                    txtGoodsPrice.Text=_model.Portprice.ToString(); 
                    txtFreight.Text = _model.Freight.ToString();
                    txtRebate.Text = _model.rebate.ToString();
                    txtCompany.Text = _model.supplier;
                    txtCompany.Tag = _model.supplierId;
                    txtANum.Text = _model.accountnumber;
                    txtFishMealId.Text = _model.Product_id;
                }
            }
            return base . Add ( );
        }
        public void AddSet() {
            txtDepartMent . Text = string . Empty;
            //txtDepartMent .SelectedValue = string.Empty;
            dtpApply.Value = DateTime.Now;
            txtCode.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtFreight.Text = string.Empty;
            txtRebate.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtCompany.Tag = string.Empty;
            txtDemaUndnit.Text = string.Empty;
            txtDemaUndnit.Tag = string.Empty;
            txtDemandSideContact.Text = string.Empty;
            txtDemandSideContact.Tag = string.Empty;
            txtANum.Text = string.Empty;
            txtFishMealId.Text = string.Empty;
            txtWeight.Text = string.Empty;
            txtGoodsPrice.Text = string.Empty;
            rabYuFu.Checked = false;
            rabQuanKuan.Checked = false;
            rabWeiKuan.Checked = false;
            texRMB.Text = string.Empty;
            txtCodeOdd.Text = string.Empty;
            inputRMB.Text = string.Empty;
            rabGongZhang.Checked = false;
            rabSiZhang.Checked = false;
            rabChengDui.Checked = false;
            rabXianJin.Checked = false;
            rabQiTa.Checked = false;
            texOther.Text = string.Empty;
            rabZZSFP.Checked = false;
            rabPTFP.Checked = false;
            rabSJ.Checked = false;
            dtpDate.Value = DateTime.Now;
            txtRemark.Text = string.Empty;
        }
        public override int Modify ( )
        {
            tmiQuery . Visible = false;
            tmiAdd . Visible = false;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiClose . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiExport . Visible = false;

            state = "edit";

            return base . Modify ( );
        }

        public override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( txtOddNum . Text ) )
            {
                MessageBox . Show ( "单号不可为空" );
                return 0;
            }
            //if (_bll.ExistsUpdateOrDelete(_list.code, FishEntity.Variable.User.username) == false)
            //{
            //    MessageBox.Show("不是所属人无法操作！");
            //    return 0;
            //}
            _Refreshbll = new FishBll.Bll.ProcessStateBll();
            if (_Refreshbll.ExistsNumbering(txtNumbering.Text, "skjlExBool") == true)
            {
                MessageBox.Show("已审核无法操作！");
                return 0;
            }
            isOk = _bll . Delete ( txtOddNum . Text );
            if ( isOk == true )
            {
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormReceiptRecord(txtNumbering.Text);
                //}
                MessageBox . Show ( "删除成功" );

                //Next ( );
            }
            else
                MessageBox . Show ( "删除失败" );

            return base . Delete ( );
        }

        public override void Next ( )
        {
            QueryOne ( " > " ,_orderBy );

            base . Next ( );
        }

        public override void Previous ( )
        {
            QueryOne ( " < " ,_orderBy );

            base . Previous ( );
        }

        protected void QueryOne ( string operate ,string orderBy )
        {
            _rolewhere = string . Empty;
            panel1.Enabled = true;
            if ( string . IsNullOrEmpty ( _where ) )
            {
                _rolewhere = "1=1";
            }
            else
            {
                _rolewhere = _where;
            }
            if ( _list != null )
            {
                _rolewhere += " AND code " + operate + _list . code;
            }
            _list = _bll . getList ( _rolewhere + orderBy );
            if ( _list != null )
            {
                setValue ( _list );
            }
        }

        public override void Save ( )
        {
            errorProvider1 . Clear ( );
            isOk = true;
            if ( string . IsNullOrEmpty ( txtOddNum . Text ) )
            {
                errorProvider1 . SetError ( txtOddNum ,"不可为空" );
                isOk = false;
            }
            //if ( string . IsNullOrEmpty ( txtCode . Text ) )
            //{
            //    errorProvider1 . SetError ( txtCode ,"不可为空" );
            //    isOk = false;
            //}
            decimal vaildate = 0M;
            if ( !string . IsNullOrEmpty ( txtWeight . Text ) && decimal . TryParse ( txtWeight . Text ,out vaildate ) == false )
            {
                errorProvider1 . SetError ( txtWeight ,"请输入数字" );
                isOk = false;
            }
            vaildate = 0M;
            if ( !string . IsNullOrEmpty ( txtGoodsPrice . Text ) && decimal . TryParse ( txtGoodsPrice . Text ,out vaildate ) == false )
            {
                errorProvider1 . SetError ( txtGoodsPrice ,"请输入数字" );
                isOk = false;
            }
            vaildate = 0M;
            if ( !string . IsNullOrEmpty ( texRMB . Text ) && decimal . TryParse ( texRMB . Text ,out vaildate ) == false )
            {
                errorProvider1 . SetError ( texRMB ,"请输入数字" );
                isOk = false;
            }
            if ( isOk == false )
                return;

            getValue ( );

            if ( state == "add" )
            {
                txtOddNum . Text = _bll . GetCode ( );
                _list . code = txtOddNum . Text;
                isOk = _bll . Add ( _list );
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormReceiptRecord(txtNumbering.Text);
                //}
            }
            else if ( state == "edit" )
            {
                //if (_bll.ExistsUpdateOrDelete(_list.code, FishEntity.Variable.User.username) == false)
                //{
                //    MessageBox.Show("不是所属人无法操作！");
                //    return;
                //}
                _Refreshbll = new FishBll.Bll.ProcessStateBll();
                if (_Refreshbll.ExistsNumbering(txtNumbering.Text, "skjlExBool") == true)
                {
                    MessageBox.Show("已审核无法操作！");
                    return ;
                }
                if ( _bll . Exists ( _list . code ) == true )
                {
                    MessageBox . Show ( "此单号不存在" );
                    return;
                }
                isOk = _bll . Edit ( _list );
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormReceiptRecord(txtNumbering.Text);
                //}
            }

            if ( isOk == true )
            {
                MessageBox . Show ( "保存成功" );

                tmiQuery . Visible = true;
                tmiAdd . Visible = true;
                tmiModify . Visible = false;
                tmiDelete . Visible = false;
                tmiClose . Visible = true;
                tmiSave . Visible = false;
                tmiCancel . Visible = false;
                tmiExport . Visible = false;
                //tmiNext . Visible = false;
                //tmiPrevious . Visible = false;

            }
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }

        public override void Cancel ( )
        {
            tmiQuery . Visible = true;
            tmiAdd . Visible = true;
            tmiModify . Visible = true;
            tmiDelete . Visible = true;
            tmiClose . Visible = true;
            tmiSave . Visible = false;
            tmiCancel . Visible = false;
            tmiExport . Visible = true;
            //tmiNext . Visible = true;
            //tmiPrevious . Visible = true;

            base . Cancel ( );
        }

        void setValue ( FishEntity . ReceiptRecordEntity _list )
        {
            txtOddNum . Text = _list . code;
            txtDepartMent . Text = _list . departName;
            //txtDepartMent . ValueMember = _list . departNum;
            if ( _list . date != null )
                dtpApply . Value = _list . date;
            txtCode . Text = _list . codeOfYu;
            txtFreight . Text = _list . codeYunFei . ToString ( );
            txtRebate . Text = _list . codeHuiKou . ToString ( );
            txtCompany . Text = _list . fuKuanDanWei;
            txtCompany . Tag = _list . fuKuanDanWeiId;
            txtDemandSideContact.Text = _list.DemandSideContact;
            txtDemandSideContact.Tag = _list.DemandSideContactId;
            txtDemaUndnit.Text = _list.DemaUndnit;
            txtDemaUndnit.Tag = _list.DemaUndnitId;
            txtANum . Text = _list . fuKuanZhangHao;
            txtFishMealId.Text = _list.FishMealId;
            txtPrice . Text = _list . codePrice . ToString ( );
            txtWeight . Text = _list . weight . ToString ( );
            txtGoodsPrice . Text = _list . price . ToString ( );
            txtNumbering.Text = _list.Numbering;
            if ( _list . fuKuanType != null )
            {
                if ( _list . fuKuanType . Trim ( ) . Equals ( rabYuFu . Text ) )
                    rabYuFu . Checked = true;
                else if ( _list . fuKuanType . Trim ( ) . Equals ( rabQuanKuan . Text ) )
                    rabQuanKuan . Checked = true;
                else if ( _list . fuKuanType . Trim ( ) . Equals ( rabWeiKuan . Text ) )
                    rabWeiKuan . Checked = true;
                else
                    rabYuFu . Checked = rabQuanKuan . Checked = rabWeiKuan . Checked = false;
            }
            else
                rabYuFu . Checked = rabQuanKuan . Checked = rabWeiKuan . Checked = false;


            texRMB . Text = _list . RMB . ToString ( );
            inputRMB . Text = Utility . MoneyToRMB . ConvertSum ( _list . RMB . ToString ( ) );

            if ( _list . fuKuanMethod != null )
            {
                if ( _list . fuKuanMethod . Trim ( ) . Equals ( rabGongZhang . Text ) )
                    rabGongZhang . Checked = true;
                else if ( _list . fuKuanMethod . Trim ( ) . Equals ( rabSiZhang . Text ) )
                    rabSiZhang . Checked = true;
                else if ( _list . fuKuanMethod . Trim ( ) . Equals ( rabChengDui . Text ) )
                    rabChengDui . Checked = true;
                else if ( _list . fuKuanMethod . Trim ( ) . Equals ( rabXianJin . Text ) )
                    rabXianJin . Checked = true;
                else if ( _list . fuKuanMethod . Trim ( ) . Equals ( rabQiTa . Text ) )
                {
                    rabQiTa . Checked = true;
                    texOther . Text = _list . fuKuanOther;
                }
                else
                {
                    rabGongZhang . Checked = rabSiZhang . Checked = rabChengDui . Checked = rabXianJin . Checked = rabQiTa . Checked = false;
                    texOther . Text = string . Empty;
                }
            }
            else
            {
                rabGongZhang . Checked = rabSiZhang . Checked = rabChengDui . Checked = rabXianJin . Checked = rabQiTa . Checked = false;
                texOther . Text = string . Empty;
            }

            if ( _list . invoiceType != null )
            {
                if ( _list . invoiceType . Trim ( ) . Equals ( rabZZSFP . Text ) )
                    rabZZSFP . Checked = true;
                else if ( _list . invoiceType . Trim ( ) . Equals ( rabPTFP . Text ) )
                    rabPTFP . Checked = true;
                else if ( _list . invoiceType . Trim ( ) . Equals ( rabSJ . Text ) )
                    rabSJ . Checked = true;
                else
                    rabZZSFP . Checked = rabPTFP . Checked = rabSJ . Checked = false;
            }
            else
                rabZZSFP . Checked = rabPTFP . Checked = rabSJ . Checked = false;

            if ( !string . IsNullOrEmpty ( _list . fuKuandate . ToString ( ) ) )
                dtpDate . Value = _list . fuKuandate;
            txtRemark . Text = _list . remark;
            txtCodeOdd . Text = _list . codeContract;
            txtmodifyman.Text = _list.modeifyMan;
            txtcreateman.Text = _list.createMan;
        }

        void getValue ( )
        {
            _list = new FishEntity . ReceiptRecordEntity ( );
            _list.Numbering = txtNumbering.Text;
            _list . code = txtOddNum . Text;
            _list . departName = txtDepartMent . Text;
            _list . departNum = txtDepartMent . ValueMember . ToString ( );
            _list . date = dtpApply . Value;
            _list . codeOfYu = txtCode . Text;
            _list . codeYunFei = string . IsNullOrEmpty ( txtFreight . Text ) == true ? 0 : Convert . ToDecimal ( txtFreight . Text );
            _list . codeHuiKou = string . IsNullOrEmpty ( txtRebate . Text ) == true ? 0 : Convert . ToDecimal ( txtRebate . Text );
            _list . fuKuanDanWei = txtCompany . Text;
            _list . fuKuanDanWeiId = txtCompany . Tag == null ? string . Empty : txtCompany . Tag . ToString ( );
            _list.DemaUndnit = txtDemaUndnit.Text;
            _list.DemaUndnitId = txtDemaUndnit.Tag == null ? string.Empty : txtDemaUndnit.Tag.ToString();
            _list.DemandSideContact = txtDemandSideContact.Text;
            _list.DemandSideContactId = txtDemandSideContact.Tag == null ? string.Empty : txtDemandSideContact.Tag.ToString();
            _list . fuKuanZhangHao = txtANum . Text;
            _list.FishMealId = txtFishMealId.Text;
            _list . codePrice = string . IsNullOrEmpty ( txtPrice . Text ) == true ? 0 : Convert . ToDecimal ( txtPrice . Text );
            _list . weight = string . IsNullOrEmpty ( txtWeight . Text ) == true ? 0 : Convert . ToDecimal ( txtWeight . Text );
            _list . price = string . IsNullOrEmpty ( txtGoodsPrice . Text ) == true ? 0 : Convert . ToDecimal ( txtGoodsPrice . Text );
            if ( rabYuFu . Checked == true )
                _list . fuKuanType = rabYuFu . Text;
            else if ( rabQuanKuan . Checked == true )
                _list . fuKuanType = rabQuanKuan . Text;
            else if ( rabWeiKuan . Checked == true )
                _list . fuKuanType = rabWeiKuan . Text;
            else
                _list . fuKuanType = string . Empty;
            _list . RMB = string . IsNullOrEmpty ( texRMB . Text ) == true ? 0 : Convert . ToDecimal ( texRMB . Text );
            if ( rabGongZhang . Checked == true )
                _list . fuKuanMethod = rabGongZhang . Text;
            else if ( rabSiZhang . Checked == true )
                _list . fuKuanMethod = rabSiZhang . Text;
            else if ( rabChengDui . Checked == true )
                _list . fuKuanMethod = rabChengDui . Text;
            else if ( rabXianJin . Checked == true )
                _list . fuKuanMethod = rabXianJin . Text;
            else if ( rabQiTa . Checked == true )
            {
                _list . fuKuanMethod = rabQiTa . Text;
                _list . fuKuanOther = texOther . Text;
            }
            else
            {
                _list . fuKuanMethod = string . Empty;
                _list . fuKuanOther = string . Empty;
            }
            if ( rabZZSFP . Checked == true )
                _list . invoiceType = rabZZSFP . Text;
            else if ( rabPTFP . Checked == true )
                _list . invoiceType = rabPTFP . Text;
            else if ( rabSJ . Checked == true )
                _list . invoiceType = rabSJ . Text;
            else
                _list . invoiceType = string . Empty;
            _list . fuKuandate = dtpDate . Value;
            _list . remark = txtRemark . Text;
            _list . createMan = FishEntity . Variable . User . username;
            _list . modeifyMan = FishEntity . Variable . User . username;
            _list . codeContract = txtCodeOdd . Text;
        }
        private void txtDepartMent_Click ( object sender ,EventArgs e )
        {
            //FormCompanyList from = new FormCompanyList ( );
            //from . StartPosition = FormStartPosition . CenterParent;
            //if ( from . ShowDialog ( ) != DialogResult . OK )
            //    return;
            //txtDepartMent . Text = from . SelectCompany . fullname;
            //txtDepartMent . Tag = from . SelectCompany . code;
        }
        private void txtCompany_Click ( object sender ,EventArgs e )
        {
            FormCompanyList from = new FormCompanyList ( );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtCompany . Text = from . SelectCompany . fullname;
            txtCompany . Tag = from . SelectCompany . code;
        }
        private void txtCode_Click ( object sender ,EventArgs e )
        {
            FormPresaleRequisition from = new FormPresaleRequisition ( );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            FishEntity . ReceiptRecordEntity _list = from . getList;
            txtCode . Text = _list .codeOfYu.ToString();
            txtPrice . Text = _list . codePrice . ToString ( );
            txtFreight . Text = _list . codeYunFei . ToString ( );
            txtRebate . Text = _list . codeHuiKou . ToString ( );
        }

        private void texRMB_TextChanged ( object sender ,EventArgs e )
        {
            if ( texRMB . Text . LastIndexOf ( "." ) == texRMB . Text . Length - 1 )
                return;

            inputRMB . Text = Utility . MoneyToRMB . ConvertSum ( texRMB . Text );
        }

        private void txtCodeOdd_Click ( object sender ,EventArgs e )
        {
            FormSalesTables from = new FormSalesTables( );
            from . StartPosition = System . Windows . Forms . FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return;

            txtCodeOdd . Text = string . Empty;
            txtCodeOdd . Text = from . fish.code;
            txtRebate.Text = from.fish.rebate.ToString();
            txtFreight.Text = from.fish.Freight.ToString();
            txtPrice.Text = from.fish.HeTongDanJia.ToString();
            txtCompany.Text = from.fish.supplier;
            txtCompany.Tag = from.fish.supplierId;
            txtDemaUndnit.Text = from.fish.demand;
            txtDemaUndnit.Tag = from.fish.demandId;
            txtDemandSideContact.Text = from.fish.DemandContact;
            txtDemandSideContact.Tag = from.fish.DemandContactId;
            txtFishMealId.Text = from.fish.Product_id;
            txtNumbering.Text = from.fish.Numbering;
        }

    }
}
