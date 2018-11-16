using System;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormPaymentRequisition:FormMenuBase
    { 
        /// <summary>
             /// 流程状态表刷新
             /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        FishEntity.SalesRequisitionEntity _model = null;
        string _getname = string.Empty;
        string XCNumbering = string.Empty;
        //t_paymentrequisition
        FishEntity.PaymentRequisitionEntity _list=null;
        FishBll.Bll.PaymentRequisitionBll _bll= new FishBll.Bll.PaymentRequisitionBll();
        
        bool isOk=false; string state=string.Empty, _orderBy = " order by id asc limit 1",_where=string.Empty,_rolewhere = string.Empty;
        public FormPaymentRequisition() {
            InitializeComponent();
            this.panel1.Enabled = false;
            tmiQuery.Visible = true;
            tmiAdd.Visible = true;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiClose.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;

            txtDepartMent.DataSource = _bll.getDepart();
            txtDepartMent.DisplayMember = "rolename";
            txtDepartMent.ValueMember = "roleid";
        }
        public FormPaymentRequisition(string getname,string XC)
        {
            InitializeComponent();
            this.panel1.Enabled = false;
            tmiQuery . Visible = true;
            tmiAdd . Visible = true;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiClose . Visible = true;
            tmiSave . Visible = false;
            tmiCancel . Visible = false;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;
            _getname = getname;
            if (XC=="C")
            {
                this.Text = "采购付款申请单";
            }
            else if (XC == "X")
            {
                this.Text = "销售付款申请单";
            }
            XCNumbering = XC;
            txtDepartMent . DataSource = _bll . getDepart ( );
            txtDepartMent . DisplayMember = "rolename";
            txtDepartMent . ValueMember = "roleid";

        }

        private void FormPaymentRequisition_Load ( object sender ,EventArgs e )
        {
            MenuCode = "M308"; ControlButtomRoles();
            if (Megres.oddNum!="")
            {
                _rolewhere = " and code='" + Megres.oddNum + "'";
                queryWhere(_rolewhere);
                Megres.oddNum = string.Empty;
            }
        }
        public override void Review ( )
        {
            if (txtCNumbering.Text!=""&&txtNumbering.Text!="")
            {
                 Review(this.Name, txtNumbering.Text, txtOddNum.Text);
            }
            else if(txtNumbering.Text == "" && txtCNumbering.Text != "")
            {
                Review(this.Name, txtCNumbering.Text, txtOddNum.Text);
            }
            //if ( txtNumbering . Text != "" )
            //{
            //    _Refreshbll = new FishBll . Bll . ProcessStateBll ( );
            //    _Refreshbll . GetFormPaymentRequisition ( txtOddNum . Text );
            //}

            base . Review ( );
        }
        public override int Query ( )
        {
            FormPresaleRequisitionCodition form = new FormPresaleRequisitionCodition ( "付款申请单查询" ,"  单号：" );
            if ( form . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return 0;
            _where = form . GetWhereCondition;
            queryWhere ( _where );

            tmiModify . Visible = true;
            tmiDelete . Visible = true;
            tmiNext . Visible = true;
            tmiPrevious . Visible = true;

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

        void setValue ( FishEntity . PaymentRequisitionEntity _list )
        {
            txtOddNum . Text = _list . code;
            txtDepartMent . Text = _list . applyDepart;
            txtPayUnit.Text = _list.unit;
            txtPayUnit.Tag = _list . applyDepartId;
            if ( _list . applyDate != null )
                dtpDate . Value = Convert . ToDateTime ( _list . applyDate . ToString ( ) );
            txtPayCode . Text = _list . applyCode;
            txtNumbering.Text = _list.Numbering;
            txtpurchasecode.Text = _list.Purchasecode;
            txtPayAcount . Text = _list . AcountNum;
            txtCNumbering.Text = _list.CNumbering;
            txtPurchasingUnit.Text = _list.PurchasingUnit;
            txtPurchasingUnit.Tag = _list.PurchasingUnitId;
            txtcontacts . Text = _list . contacts;
            txtcontacts.Tag = _list.ContactsId;
            txtbackDeposit . Text = _list . backDeposit;
            txtprice . Text = _list . price . ToString ( );
            txtweight . Text = _list . weight . ToString ( );
            txtmodifyman.Text = _list.modifyMan;
            txtcreateman.Text = _list.createMan;
            txtFishMealId.Text = _list.FishMealId;
            txtBond . Text = _list . bond . ToString ( );

            if (_list.paymentType != null)
            {
                if (_list.paymentType.Trim().Equals(rabYuFu.Text))
                    rabYuFu.Checked = true;
                else if (_list.paymentType.Trim().Equals(rabQuanKuan.Text))
                    rabQuanKuan.Checked = true;
                else if (_list.paymentType.Trim().Equals(rabWeiKuan.Text))
                    rabWeiKuan.Checked = true;
                else
                    rabQuanKuan.Checked = rabWeiKuan.Checked = false;
            }
            else
            {
                rabQuanKuan.Checked = rabWeiKuan.Checked = false;
            }
            if (_list.PricingType != null)
            {
                 if (_list.PricingType.Trim().Equals(rabBaoZheng.Text))
                    rabBaoZheng.Checked = true;
                else if (_list.PricingType.Trim().Equals(rabHuoKuan.Text))
                    rabHuoKuan.Checked = true;
                else
                    rabBaoZheng.Checked = rabHuoKuan.Checked =  false;
            }
            else {
                rabBaoZheng.Checked = rabHuoKuan.Checked = false;
            }
            txtapplyMoney . Text = _list . applyMoney . ToString ( );
            inputRMB . Text = Utility . MoneyToRMB . ConvertSum ( _list . applyMoney . ToString ( ) );

            if ( _list . paymentMethod != null )
            {
                if ( _list . paymentMethod . Trim ( ) . Equals ( rabGongZhang . Text ) )
                    rabGongZhang . Checked = true;
                else if ( _list . paymentMethod . Trim ( ) . Equals ( rabSiZhang . Text ) )
                    rabSiZhang . Checked = true;
                else if ( _list . paymentMethod . Trim ( ) . Equals ( rabChengDui . Text ) )
                    rabChengDui . Checked = true;
                else if ( _list . paymentMethod . Trim ( ) . Equals ( rabXianJin . Text ) )
                    rabXianJin . Checked = true;
                else if ( _list . paymentMethod . Trim ( ) . Equals ( rabQiTa . Text ) )
                {
                    rabQiTa . Checked = true;
                    texOther . Text = _list . paymentMethodOther;
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

            if ( !string . IsNullOrEmpty ( _list . paymentDate . ToString ( ) ) )
                dtpDate . Value = Convert . ToDateTime ( _list . paymentDate . ToString ( ) );
            txtRemark . Text = _list . remark;
        }

        public override int Add ( )
        {
            panel1.Enabled = true;
            txtOddNum . Text = _bll . getCode ( );
            txtDepartMent.SelectedValue = false;
            txtPayCode.Text = string.Empty;
            txtNumbering.Text = string.Empty;
            dtpPayment.Value = DateTime.Now;
            txtPayAcount.Text = string.Empty;
            txtPayUnit.Text = string.Empty;
            txtPayUnit.Tag = string.Empty;
            txtcontacts.Text = string.Empty;
            txtcontacts.Tag = string.Empty;
            txtbackDeposit.Text = string.Empty;
            txtprice.Text = string.Empty;
            txtweight.Text = string.Empty;
            txtFishMealId.Text = string.Empty;
            txtPurchasingUnit.Text = string.Empty;
            txtPurchasingUnit.Tag = string.Empty;
            txtapplyMoney.Text = string.Empty;
            inputRMB.Text = string.Empty;
            dtpDate.Value = DateTime.Now;
            txtRemark.Text = string.Empty;
            texOther.Text = string.Empty;
            txtpurchasecode.Text = string.Empty;
            txtCNumbering . Text = string . Empty;
            txtBond . Text = string . Empty;
            rabBaoZheng.Checked=rabHuoKuan.Checked=rabYuFu.Checked = rabQuanKuan.Checked = rabWeiKuan.Checked = rabGongZhang.Checked = rabSiZhang.Checked = rabChengDui.Checked = rabXianJin.Checked = rabQiTa.Checked = rabZZSFP.Checked = rabPTFP.Checked = rabSJ.Checked = false;

            tmiQuery . Visible = false;
            tmiAdd . Visible = false;
            tmiModify . Visible = false;
            tmiDelete . Visible = false;
            tmiClose . Visible = false;
            tmiSave . Visible = true;
            tmiCancel . Visible = true;
            tmiExport . Visible = false;
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;

            state = "add";
            if (XCNumbering=="X")
            {
                _model = _bll.getXSSQD(_getname);
                if (_model != null)
                {
                    txtPayCode.Text = _model.code;
                    txtFishMealId.Text = _model.Product_id;
                    txtNumbering.Text = _model.Numbering;
                    txtPayUnit.Text = _model.demand;
                    txtPayUnit.Tag = _model.demandId;
                    txtcontacts.Text = _model.DemandContact;
                    txtcontacts.Tag = _model.DemandContactId;
                    txtpurchasecode.Text = _model.Purchasecontractnumber;
                    txtPurchasingUnit.Text = _model.Purchasingunits;
                    txtPurchasingUnit.Tag = _model.PurchasingunitsId;
                    txtPayAcount.Text = _model.accountnumber.ToString();
                    txtbackDeposit.Text = _model.Bank;
                    txtCNumbering.Text = _model.CNumbering;
                }
            }
            else if (XCNumbering=="C")
            {
                FishEntity.PurcurementContractEntity getmodel = new FishEntity.PurcurementContractEntity();
                FishBll.Bll.PurchaseApplicationBll getbll = new FishBll.Bll.PurchaseApplicationBll();
                getmodel = getbll.getCGSQD(" where a.codenum='"+_getname+"' ");
                    if (getmodel != null)
                    {
                    //txtFishMealId.Text=getmodel.
                    txtBond.Text = getmodel.bondPro.ToString();
                        txtpurchasecode.Text = getmodel.codeNumContract;
                        txtPurchasingUnit.Text = getmodel.supplier;
                        txtCNumbering.Text = getmodel.codeNum;
                    txtPayAcount.Text = getmodel.Account;
                    txtbackDeposit.Text = getmodel.Bank;
                    }
            }
            return base . Add ( );
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
            tmiNext . Visible = false;
            tmiPrevious . Visible = false;

            state = "edit";

            return base . Modify ( );
        }

        public override int Delete ( )
        {
            if ( string . IsNullOrEmpty ( txtOddNum . Text ) )
            {
                MessageBox . Show ( "清选择需要删除的内容" );
                return 0;
            }
            _Refreshbll = new FishBll.Bll.ProcessStateBll();
            if (_Refreshbll.ExistsNumbering(txtNumbering.Text, "fksqExBool") == true)
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
                //    _Refreshbll.GetFormPaymentRequisition(txtNumbering.Text);
                //}
                MessageBox . Show ( "成功删除" );

                Next ( );
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
            if ( getValue ( ) == false )
                return;

            if (state == "add")
            {
                isOk = _bll.Add(_list);
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormPaymentRequisition(txtNumbering.Text);
                //}
            }
            else
            {
                if (_bll.Exists(_list.code) == false)
                {
                    MessageBox.Show("不存在此记录");
                    return;
                }
                _Refreshbll = new FishBll.Bll.ProcessStateBll();
                if (_Refreshbll.ExistsNumbering(txtNumbering.Text, "fksqExBool") == true)
                {
                    MessageBox.Show("已审核无法操作！");
                    return;
                }
                //if (_bll.ExistsUpdate(_list.code,FishEntity.Variable.User.username)!=true)
                //{
                //    MessageBox.Show("不是所属人无法操作！");
                //    return;
                //}
                else
                    isOk = _bll.Edit(_list);
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormPaymentRequisition(txtNumbering.Text);
                //}
            }

            if ( isOk == true )
            {
                MessageBox . Show ( "保存成功" );

                tmiQuery . Visible = true;
                tmiAdd . Visible = true;
                tmiModify . Visible = true;
                tmiDelete . Visible = false;
                tmiClose . Visible = true;
                tmiSave . Visible = false;
                tmiCancel . Visible = true;
                tmiExport . Visible = false;
                tmiNext . Visible = false;
                tmiPrevious . Visible = false;

            }
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }

        bool getValue ( )
        {
            errorProvider1 . Clear ( );
            isOk = true;

            if (string.IsNullOrEmpty(txtpurchasecode.Text))
            {
                errorProvider1.SetError(txtpurchasecode, "不能为空");
            }
            if (string.IsNullOrEmpty(txtCNumbering.Text))
            {
                errorProvider1.SetError(txtCNumbering, "不能为空");
            }
            if ( string . IsNullOrEmpty ( txtOddNum . Text ) )
            {
                errorProvider1 . SetError ( txtOddNum ,"不可为空" );
                isOk = false;
            }
            decimal outPut = 0M;
            if ( !string . IsNullOrEmpty ( txtprice . Text . Trim ( ) ) && decimal . TryParse ( txtprice . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( txtprice ,"清输入数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( txtweight . Text . Trim ( ) ) && decimal . TryParse ( txtweight . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( txtweight ,"清输入数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( txtapplyMoney . Text . Trim ( ) ) && decimal . TryParse ( txtapplyMoney . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( txtapplyMoney ,"清输入数字" );
                isOk = false;
            }
            outPut = 0M;
            if ( !string . IsNullOrEmpty ( txtBond . Text . Trim ( ) ) && decimal . TryParse ( txtBond . Text ,out outPut ) == false )
            {
                errorProvider1 . SetError ( txtBond ,"清输入数字" );
                isOk = false;
            }
            if ( isOk == false )
                return isOk;
            if (rabQuanKuan.Checked==true||rabWeiKuan.Checked ==true || rabYuFu .Checked == true)
            {

            }
            else
            {
                errorProvider1.SetError(groupBox1, "必选一个"); isOk = false;
            }
            _list = new FishEntity . PaymentRequisitionEntity ( );
            _list . createMan = _list . modifyMan = FishEntity . Variable . User . username;
            _list . code = txtOddNum . Text;
            _list . applyDepart = txtDepartMent . Text;
            _list . applyDate = dtpDate . Value;
            _list . applyCode = txtPayCode . Text;
            _list.Numbering = txtNumbering.Text;
            _list.Purchasecode = txtpurchasecode.Text;
            _list . AcountNum = txtPayAcount . Text;
            _list . unit = txtPayUnit . Text;
            _list.PurchasingUnit = txtPurchasingUnit.Text;
            _list.PurchasingUnitId = txtPurchasingUnit.Tag.ToString();
            if (txtPayUnit.Tag!=null)
            {
                _list.applyDepartId = txtPayUnit.Tag.ToString();
            }
            _list . contacts = txtcontacts . Text;
            _list.ContactsId = txtcontacts.Tag.ToString();
            _list . backDeposit = txtbackDeposit . Text;
            _list.FishMealId = txtFishMealId.Text;
            _list . price = string . IsNullOrEmpty ( txtprice . Text . Trim ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( txtprice . Text ) ,2 );
            _list . weight = string . IsNullOrEmpty ( txtweight . Text . Trim ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( txtweight . Text ) ,2 );
            _list . bond = string . IsNullOrEmpty ( txtBond . Text . Trim ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( txtBond . Text ) ,2 );
            _list .CNumbering = txtCNumbering . Text;
            if (rabQuanKuan.Checked == true)
                _list.paymentType = rabQuanKuan.Text;
            else if (rabWeiKuan.Checked == true)
                _list.paymentType = rabWeiKuan.Text;
            else if (rabYuFu.Checked == true)
                _list.paymentType = rabYuFu.Text;
            else
                _list.paymentType = string.Empty;

            if (rabBaoZheng.Checked == true)
                _list.PricingType = rabBaoZheng.Text;
            else if (rabHuoKuan.Checked == true)
                _list.PricingType = rabHuoKuan.Text;
            else
                _list.PricingType = string.Empty;
                _list . applyMoney = string . IsNullOrEmpty ( txtapplyMoney . Text . Trim ( ) ) == true ? 0 : Math . Round ( Convert . ToDecimal ( txtapplyMoney . Text ) ,2 );

            if ( rabGongZhang . Checked == true )
                _list . paymentMethod = rabGongZhang . Text;
            else if ( rabSiZhang . Checked == true )
                _list . paymentMethod = rabSiZhang . Text;
            else if ( rabChengDui . Checked == true )
                _list . paymentMethod = rabChengDui . Text;
            else if ( rabXianJin . Checked == true )
                _list . paymentMethod = rabXianJin . Text;
            else if ( rabQiTa . Checked == true )
            {
                _list . paymentMethod = rabQiTa . Text;
                _list . paymentMethodOther = texOther . Text;
            }
            else
            {
                _list . paymentMethod = string . Empty;
                _list . paymentMethodOther = string . Empty;
            }
            if ( rabZZSFP . Checked == true )
                _list . invoiceType = rabZZSFP . Text;
            else if ( rabPTFP . Checked == true )
                _list . invoiceType = rabPTFP . Text;
            else if ( rabSJ . Checked == true )
                _list . invoiceType = rabSJ . Text;
            else
                _list . invoiceType = string . Empty;
            _list . paymentDate = dtpDate . Value;
            _list . remark = txtRemark . Text;

            return isOk;
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
            tmiNext . Visible = true;
            tmiPrevious . Visible = true;

            base . Cancel ( );
        }

        private void txtPayCode_Click ( object sender ,EventArgs e )
        { 
            FormSalesTables from = new FormSalesTables( );
            from . StartPosition = FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != DialogResult . OK )
                return;
            txtPayCode . Text = from . fish.code;
            txtNumbering.Text = from.fish.Numbering;
            txtPayUnit.Text = from.fish.demand;
            txtPayUnit.Tag = from.fish.demandId;
            txtFishMealId.Text = from.fish.Product_id;
            txtcontacts.Text = from.fish.DemandContact;
            txtcontacts.Tag = from.fish.DemandContactId;
            txtpurchasecode.Text = from.fish.Purchasecontractnumber;
            txtPurchasingUnit.Text = from.fish.Purchasingunits;
            txtPurchasingUnit.Tag = from.fish.PurchasingunitsId;
            txtPayAcount.Text = from.fish.accountnumber.ToString();
            txtbackDeposit.Text = from.fish.Bank;
            txtCNumbering.Text = from.fish.CNumbering;
            txtNumbering.Text = from.fish.Numbering;
            //采购单位Purchasingunits
        }

        private void txtPayUnit_Click ( object sender ,EventArgs e )
        {
            FormCompanyList form = new FormCompanyList ( );
            form . StartPosition = FormStartPosition . CenterParent;
            if ( form . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return;
            if ( form . SelectCompany == null )
                return;
            txtPayUnit . Text = form . SelectCompany . fullname;
            txtPayUnit . Tag = form . SelectCompany . code;
            txtcontacts.Text = form.SelectCompany.linkman;
            txtcontacts.Tag = form.SelectCompany.linkman;
        }

        private void txtpurchasecode_Click(object sender, EventArgs e)
        {
            //FormPurchaseRequisition from = new FormPurchaseRequisition ( );
            //from . StartPosition = FormStartPosition . CenterParent;
            //if ( from . ShowDialog ( ) != DialogResult . OK )
            //    return;
            //txtpurchasecode . Text = from . fish . ContractNo;
            //txtPurchasingUnit . Text = from . fish . Supplier;
            //txtbackDeposit . Text = from . fish . Openbank;
            //txtPayAcount . Text = from . fish . Accountnumber;
            FormPurcurementContract form = new FormPurcurementContract ( );
            if ( form . ShowDialog ( ) != DialogResult . OK )
                return;
            FishEntity . PurcurementContractEntity model = form . getModel;
            if ( model == null )
                return;
            txtpurchasecode . Text = model . codeNumContract;
            txtCNumbering . Text = model .codeNum;
        }

        private void txtcontacts_Click ( object sender ,EventArgs e )
        {
            if (string.IsNullOrEmpty(txtPayUnit.Text) == true)
            {
                MessageBox.Show("请先选择单位,再操作。");
                return;
            }
            if (txtPayUnit.Tag == null) return;

            int companyId = 0;
            int.TryParse(txtPayUnit.Tag.ToString(), out companyId);

            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companyId);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtcontacts.Text = customer.name;
                    txtcontacts.Tag = customer.code;
                }
            }
        }

        private void txtPurchasingUnit_Click(object sender, EventArgs e)
        {

        }

        private void txtFishMealId_Click(object sender, EventArgs e)
        {
            FishBll.Bll.PurcurementContractBll bll = new FishBll.Bll.PurcurementContractBll();
            if (bll.Exists(txtCNumbering.Text))
            {
                FormPurchaseAppFishInfo form = new FormPurchaseAppFishInfo(txtCNumbering.Text);
                if (form.ShowDialog() != DialogResult.OK)
                    return;
                FishEntity.PurchaseAppFishInfoEntity Caig = form.getModel;
                if (Caig == null) return;
                txtFishMealId.Text = Caig.fishId;
            }
            else
            {
                MessageBox.Show("采购申请单，订单明细无数据!");
            }
        }

        private void FormPaymentRequisition_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void txtapplyMoney_TextChanged ( object sender ,EventArgs e )
        {
            if (txtapplyMoney.Text.LastIndexOf(".") == txtapplyMoney.Text.Length - 1)
                return;
            inputRMB.Text = Utility.MoneyToRMB.ConvertSum(txtapplyMoney.Text);
        }

        private void txtapplyMonry_LostFocus ( object sender ,EventArgs e )
        {

        }

        private void txtcodeNum_Click ( object sender ,EventArgs e )
        {
            FormSalesRequisition form = new FormSalesRequisition ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                txtCNumbering . Text = form . getCodes;
            }
        }

    }
}
