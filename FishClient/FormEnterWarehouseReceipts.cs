using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    //table:t_enterwarehousereceipts
    public partial class FormEnterWarehouseReceipts : FormMenuBase
    {
        FishEntity.EnterWarehouseReceipts _entity = null;
        private UIForms.FormEnterWarehouseReceiptsCodition _Form = null;
        private FishBll.Bll.EnterWarehouseReceiptsBll _bll = new FishBll.Bll.EnterWarehouseReceiptsBll();
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        private string _rolewhere = string.Empty;
        public FormEnterWarehouseReceipts()
        {
            InitializeComponent();

            InitDataUtil . BindComboBoxData ( cmbproName ,FishEntity . Constant . Goods ,true );
            InitDataUtil . BindComboBoxData ( cmbqualitySpe ,FishEntity . Constant . Specification ,true );
            InitDataUtil . BindComboBoxData ( cmbcountry ,FishEntity . Constant . CountryType ,true );
            InitDataUtil . BindComboBoxData ( cmbbrand ,FishEntity . Constant . Brand ,true );
        }
        public override int Query()
        {
            panel1.Enabled = true;
            if (_Form == null)
            {
                _Form = new UIForms.FormEnterWarehouseReceiptsCodition();
                _Form.StartPosition = FormStartPosition.CenterParent;
                _Form.ShowInTaskbar = false;
            }
            if (_Form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = _Form.GetWhereCondition;
            List<FishEntity.EnterWarehouseReceipts> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _entity = null;
                return 1;
            }
            else
            {
                _entity = list[0];
                SetOnepound();
            }
                return 1;
        }
        protected void SetOnepound()
        {
            txtanti . Text = _entity . anti;
            txtCode . Text = _entity . code;
            txtcodeNum . Text = _entity . codeNum;
            txtcodeNumContract . Text = _entity . codeNumContract;
            txtdeliverybills . Text = _entity . deliverybills;
            txtenUntil . Text = _entity . enUntil;
            txtfat . Text = _entity . fat;
            txtfax . Text = _entity . fax;
            txtfishId . Text = _entity . fishId;
            txthf . Text = _entity . hf;
            txtlocation . Text = _entity . location;
            txtlocationDis . Text = _entity . locationDis;
            txtnumber . Text = _entity . number . ToString ( );
            txtnumOfPack . Text = _entity . numOfPack . ToString ( );
            txtprotein . Text = _entity . protein;
            txtremark . Text = _entity . remark;
            txtsand . Text = _entity . sand;
            txtshipno . Text = _entity . shipno;
            txtshy . Text = _entity . shy;
            txtTEL . Text = _entity . TEL;
            txtTO . Text = _entity . TO;
            txtTVN . Text = _entity . TVN;
            txtwater . Text = _entity . water;
            txtza . Text = _entity . za;
            cmbbrand . Text = _entity . brand;
            cmbcountry . Text = _entity . country;
            cmbproName . Text = _entity . proName;
            cmbqualitySpe . Text = _entity . qualitySpe;
            if ( _entity . downDate >= DateTime . MinValue || _entity . downDate <= DateTime . MaxValue )
                dtdownDate . Value = Convert . ToDateTime ( _entity . downDate );
            txtHeight . Text = _entity . height . ToString ( );
        }
        public override int Add()
        {
            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiAdd.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            panel1.Enabled = true;

            txtCode.Text= FishBll . Bll . SequenceUtil . GetEnterWarehouseReceipts ( );

            errorProvider1 . Clear ( );
            txtanti . Text = string . Empty;
            //txtCode . Text = string . Empty;
            txtcodeNum . Text = string . Empty;
            txtcodeNumContract . Text = string . Empty;
            txtdeliverybills . Text = string . Empty;
            txtenUntil . Text = string . Empty;
            txtfat . Text = string . Empty;
            txtfax . Text = string . Empty;
            txtfishId . Text = string . Empty;
            txthf . Text = string . Empty;
            txtlocation . Text = string . Empty;
            txtlocationDis . Text = string . Empty;
            txtnumber . Text = string . Empty;
            txtnumOfPack . Text = string . Empty;
            txtprotein . Text = string . Empty;
            txtremark . Text = string . Empty;
            txtsand . Text = string . Empty;
            txtshipno . Text = string . Empty;
            txtshy . Text = string . Empty;
            txtTEL . Text = string . Empty;
            txtTO . Text = string . Empty;
            txtTVN . Text = string . Empty;
            txtwater . Text = string . Empty;
            txtza . Text = string . Empty;
            cmbbrand . Text = string . Empty;
            cmbcountry . Text = string . Empty;
            cmbproName . Text = string . Empty;
            cmbqualitySpe . Text = string . Empty;
            dtdownDate . Value = DateTime . Now;
            txtHeight . Text = string . Empty;

            return 1;
        }
        public override void Save()
        {
            if ( Check ( ) == false )
                return;

            FishEntity .EnterWarehouseReceipts _fish = new FishEntity.EnterWarehouseReceipts();
           
            int temp = 0;
            _entity . anti = txtanti . Text;
            //_entity . code = txtCode . Text;
            _entity . codeNum = txtcodeNum . Text;
            _entity . codeNumContract = txtcodeNumContract . Text;
            _entity . deliverybills = txtdeliverybills . Text;
            _entity . enUntil = txtenUntil . Text;
            _entity . fat = txtfat . Text;
            _entity . fax = txtfax . Text;
            _entity . fishId = txtfishId . Text;
            _entity . hf = txthf . Text;
            _entity . location = txtlocation . Text;
            _entity . locationDis = txtlocationDis . Text;
            int . TryParse ( txtnumber . Text ,out temp );
            _entity . number = temp;
            temp = 0;
            int . TryParse ( txtnumOfPack . Text ,out temp );
            _entity . numOfPack = temp;
            _entity . protein = txtprotein . Text;
            _entity . remark = txtremark . Text;
            _entity . sand = txtsand . Text;
            _entity . shipno = txtshipno . Text;
            _entity . shy = txtshy . Text;
            _entity . TEL = txtTEL . Text;
            _entity . TO = txtTO . Text;
            _entity . TVN = txtTVN . Text;
            _entity . water = txtwater . Text;
            _entity . za = txtza . Text;
            _entity . brand = cmbbrand . Text;
            _entity . country = cmbcountry . Text;
            _entity . proName = cmbproName . Text;
            _entity . qualitySpe = cmbqualitySpe . Text;
            _entity . downDate = dtdownDate . Value;

            decimal te = 0;
            decimal . TryParse ( txtHeight . Text ,out te );
            _entity . height = te;

            FishBll .Bll.EnterWarehouseReceiptsBll bll = new FishBll.Bll.EnterWarehouseReceiptsBll();

            bool isok = bll.Exists(_entity.code);
            while (isok)
            {
                _entity . code = FishBll.Bll.SequenceUtil.GetEnterWarehouseReceipts();
                isok = bll.Exists( _entity . code );
            }
            int id = bll.Add(_fish);
            if (id > 0)
            {
                _entity.id = id;
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiAdd.Visible = false;
                tmiSave.Visible = true;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");
                txtCode.Text = _entity.code.ToString();
            }
            else
            {
                // txtCode.Text = _fish.Code;
                MessageBox.Show("添加失败。");
            }
        }
        public override int Modify()
        {
            if (_entity == null)
            {
                MessageBox.Show("请查询需要修改的进仓单。");
                return 0;
            }
            int temp = 0;
            _entity . anti = txtanti . Text;
            _entity . code = txtCode . Text;
            _entity . codeNum = txtcodeNum . Text;
            _entity . codeNumContract = txtcodeNumContract . Text;
            _entity . deliverybills = txtdeliverybills . Text;
            _entity . enUntil = txtenUntil . Text;
            _entity . fat = txtfat . Text;
            _entity . fax = txtfax . Text;
            _entity . fishId = txtfishId . Text;
            _entity . hf = txthf . Text;
            _entity . location = txtlocation . Text;
            _entity . locationDis = txtlocationDis . Text;
            int . TryParse ( txtnumber . Text ,out temp );
            _entity . number = temp;
            temp = 0;
            int . TryParse ( txtnumOfPack . Text ,out temp );
            _entity . numOfPack = temp;
            _entity . protein = txtprotein . Text;
            _entity . remark = txtremark . Text;
            _entity . sand = txtsand . Text;
            _entity . shipno = txtshipno . Text;
            _entity . shy = txtshy . Text;
            _entity . TEL = txtTEL . Text;
            _entity . TO = txtTO . Text;
            _entity . TVN = txtTVN . Text;
            _entity . water = txtwater . Text;
            _entity . za = txtza . Text;
            _entity . brand = cmbbrand . Text;
            _entity . country = cmbcountry . Text;
            _entity . proName = cmbproName . Text;
            _entity . qualitySpe = cmbqualitySpe . Text;
            _entity . downDate = dtdownDate . Value;
            decimal te = 0;
            decimal . TryParse ( txtHeight . Text ,out te );
            _entity . height = te;


            FishBll . Bll.EnterWarehouseReceiptsBll bll = new FishBll.Bll.EnterWarehouseReceiptsBll();

            bool isOk = bll.Update(_entity);
            if (isOk)
            {
                MessageBox.Show("修改成功。");
            }
            else
            {
                //txtcode.Text = string.Empty;
                MessageBox.Show("修改失败。");
            }
            return 1;
        }
        public override void Cancel()
        {
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            panel1.Enabled = true;
        }
        protected bool Check ( )
        {
            errorProvider1 . Clear ( );
            bool isok = true;
            int intResult = 0;
            if ( !string . IsNullOrEmpty ( txtnumOfPack . Text ) && int . TryParse ( txtnumOfPack . Text ,out intResult ) == false )
            {
                errorProvider1 . SetError ( txtnumOfPack ,"请填写数字" );
                isok = false;
            }
            if ( !string . IsNullOrEmpty ( txtnumber . Text ) && int . TryParse ( txtnumber . Text ,out intResult ) == false )
            {
                errorProvider1 . SetError ( txtnumber ,"请填写数字" );
                isok = false;
            }

            return isok;
        }
        public override void Previous ( )
        {
            QueryOne ( "<" ," order by id desc limit 1" );

            base . Previous ( );
        }
        public override void Next ( )
        {
            QueryOne ( ">" ," order by id asc limit 1" );

            base . Next ( );
        }
        protected void QueryOne ( string operate ,string orderBy )
        {
            string whereEx = string . Empty;
            if ( string . IsNullOrEmpty ( _where ) )
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if ( _entity != null )
            {
                whereEx += " and code " + operate + _entity . code;
            }

            List<FishEntity . EnterWarehouseReceipts> list = _bll . GetModelListVo ( whereEx + orderBy );
            if ( list == null || list . Count < 1 )
            {
                MessageBox . Show ( "已经没有记录了!" );
                return;
            }

            _entity = list [ 0 ];

            SetOnepound ( );
        }

        private void txtContractNo_Click(object sender, EventArgs e)
        {
            //FormPurchaseRequisition from = new FormPurchaseRequisition();
            ////from.signOfOpen = this.Name;        
            //StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            //if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            //    return;
            //txtContractNo.Text = string.Empty;
            //txtContractNo.Text = from.GetContractNo;
        }

        private void txtcodeNum_DoubleClick ( object sender ,EventArgs e )
        {
            FormPurchaseApplication form = new FormPurchaseApplication ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                FishEntity . PurchaseApplicationEntity model = form . getModel;
                txtcodeNum . Text = model . codeNum;
                txtcodeNumContract . Text = model . codeNumContract;
            }
        }

        private void txtcodeNumContract_DoubleClick ( object sender ,EventArgs e )
        {
            FormPurcurementContract form = new FormPurcurementContract ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                FishEntity . PurcurementContractEntity _model = form . getModel;
                txtTVN . Text = _model . conTVN;
                txtsand . Text = _model . conS;
                txtprotein . Text = _model . conProtein;
                txtfat . Text = _model . conZF;
                txtwater . Text = _model . conSF;
                txtza . Text = _model . conZA;
                txthf . Text = _model . conHF;
                txtshy . Text = _model . conSHY;
            }
        }

        private void txtenUntil_Click ( object sender ,EventArgs e )
        {
            FormCompanyList form = new FormCompanyList ( );
            form . StartPosition = FormStartPosition . CenterParent;
            if ( form . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return;
            if ( form . SelectCompany == null )
                return;
            txtenUntil . Text = form . SelectCompany . fullname;
            txtenUntil . Tag = form . SelectCompany;
        }

    }
}
