using System;
using System . Windows . Forms;

namespace FishClient
{
    //t_ReturnReceipt
    public partial class FormReturnReceipt :FormMenuBase
    {
        FishEntity.ReturnReceiptEntity _model=null;
        FishBll.Bll.ReturnReceiptBll _bll=null;
        bool result=false;
        string strWhere=string.Empty;
        string getname = string.Empty;
        
        public FormReturnReceipt ( )
        {
            InitializeComponent ( );

            _model = new FishEntity . ReturnReceiptEntity ( );
            _bll = new FishBll . Bll . ReturnReceiptBll ( );
            
            InitDataUtil . BindComboBoxData ( txtcountry ,FishEntity . Constant . CountryType ,true );
            InitDataUtil . BindComboBoxData ( txtbrand ,FishEntity . Constant . Brand ,true );
            InitDataUtil.BindComboBoxData(txtvarieties, FishEntity.Constant.Goods, true);
            panel1.Enabled = false;
        }
        public FormReturnReceipt(string name) {
            InitializeComponent();
            _model = new FishEntity.ReturnReceiptEntity();
            _bll = new FishBll.Bll.ReturnReceiptBll();
            InitDataUtil.BindComboBoxData(txtcountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(txtbrand, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(txtvarieties, FishEntity.Constant.Goods, true);
            getname = name; panel1.Enabled = false;
        }
        #region Main
        public override int Query ( )
        {
            FormOutboundOrderQuery form = new FormOutboundOrderQuery ( this . Text + "查询" );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                strWhere = form . getWhere;
                _model = _bll.GetModel(strWhere);
                if ( _model == null )
                {
                    MessageBox . Show ( "没有记录了" );
                    return 0;
                }
                setValue ( );
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
            clearControl ( );
            txtcode . Text = _bll . getCode ( );
            if (getname!=null&&getname!="")
            {
                FishEntity.SalesRequisitionEntity _model = new FishEntity.SalesRequisitionEntity();
                _bll = new FishBll.Bll.ReturnReceiptBll();
                _model = _bll.getTHD(getname);
                if (_model != null)
                {//22
                    txtcodeNumContract.Text = _model.code;
                    txtreturnParty.Text = _model.demand;
                    txtreturnParty.Tag = _model.demandId;
                    txtreturnPartyJ.Text = _model.DemandAbbreviation;
                    txtreceive.Text = _model.supplier;
                    txtreceiveJ.Text = _model.SupplierAbbreviation;
                    txtreceive.Tag = _model.supplierId;
                    txtfishId.Text = _model.Product_id;
                    txtcodeNum.Text = _model.Numbering;
                    txtcountry.Text = _model.Country;
                    txtbrand.Text = _model.pp;
                    txtspeci.Text =_model.Funit;
                    txtproName.Text = _model.Productname;
                    txtcondb.Text = _model.Db;
                    txtconza.Text = _model.Za;
                    txtcons.Text = _model.Sz;
                    txtcontvn.Text = _model.Tvn;
                    txtconhf.Text = _model.Hf;
                    txtconsf.Text = _model.Sf;
                    txtconshy.Text = _model.Shy;
                    txtconzf.Text = _model.Zf;
                    txtprice.Text = _model.HeTongDanJia;
                    txtdeliAdd.Text = _model.delivery;
                    if (_model.RabZy == true)
                    {
                        rabchengpin.Visible = false;
                    }
                    panel1.Enabled = true;
                }
                if (getname != null && getname != "")
                {
                        FishEntity.OnepoundEntity _modeloo = new FishEntity.OnepoundEntity();
                    _bll = new FishBll.Bll.ReturnReceiptBll();
                    _modeloo = _bll.getjingz(getname);
                    if (_modeloo!=null)
                    {
                        txtShipmentsTons.Text = _modeloo.Competition;
                    }
                }
            }
            tmiSave.Visible = true;
            return base . Add ( );
        }
        public override int Delete ( )
        {
            _model . code = txtcode . Text;
            result = _bll . Delete ( _model . code );
            if ( result )
            {
                MessageBox . Show ( "成功删除数据" );
                clearControl ( );
                Previous ( );
            }
            else
                MessageBox . Show ( "删除数据失败" );

            return base . Delete ( );
        }
        public override int Modify ( )
        {
            if ( getValue ( ) == false )
                return 0;
            result = _bll . Update ( _model );
            if ( result) { 
                MessageBox . Show ( "保存成功" );
                tmiSave.Visible = false;
            }
            else { 
                MessageBox . Show ( "保存失败" );
                tmiSave.Visible = false;
            }
            return base . Modify ( );
        }
        public override void Save ( )
        {
            if ( getValue ( ) == false )
                return ;

            if ( _bll . Exists ( _model . code ) )
                result = _bll . Update ( _model );
            else
                result = _bll . Add ( _model );
            if ( result )
                MessageBox . Show ( "保存成功" );
            else
                MessageBox . Show ( "保存失败" );

            base . Save ( );
        }
        public override void Review ( )
        {
            Review ( this . Name, txtcodeNum.Text, txtcode . Text  );

            base . Review ( );
        }
        #endregion

        #region Event
        private void txtcodeNum_DoubleClick ( object sender ,EventArgs e )
        {
            FormSalesTables Form = new FormSalesTables();
            Form.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (Form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            txtcodeNumContract.Text = Form.fish.code;
            txtreturnParty.Text = Form.fish.demand;
            txtreturnParty.Tag = Form.fish.demandId;
            txtreturnPartyJ.Text = Form.fish.DemandAbbreviation;
            txtreceive.Text = Form.fish.supplier;
            txtreceiveJ.Text = Form.fish.SupplierAbbreviation;
            txtreceive.Tag = Form.fish.supplierId;
            txtfishId.Text = Form.fish.Product_id;
            txtcodeNum.Text = Form.fish.Numbering;
            txtcountry.Text = Form.fish.Country;
            txtbrand.Text = Form.fish.pp;

            txtproName.Text = Form.fish.Productname;
            txtcondb.Text = Form.fish.Db;
            txtconza.Text = Form.fish.Za;
            txtcons.Text = Form.fish.Sz;
            txtcontvn.Text = Form.fish.Tvn;
            txtconhf.Text = Form.fish.Hf;
            txtconsf.Text = Form.fish.Sf;
            txtconshy.Text = Form.fish.Shy;
            txtconzf.Text = Form.fish.Zf;
            txtprice.Text = Form.fish.HeTongDanJia;
            txtdeliAdd.Text = Form.fish.delivery;
        }
        private void txtcode_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtcode . Text ) )
                this . DialogResult = DialogResult . Cancel;
            this . DialogResult = DialogResult . OK;
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
            rabchengpin.Checked = rabziying.Checked = rabzizhi.Checked = false;
        }
        bool getValue ( )
        {
            result = true;
            errorProvider1 . Clear ( );
            _model . code = txtcode . Text;
            _model . codeNum = txtcodeNum . Text;
            _model . codeNumContract = txtcodeNumContract . Text;
            _model . returnParty = txtreturnParty . Text;
            _model . returnPartyJ = txtreturnPartyJ . Text;
            _model . receive = txtreceive . Text;
            _model . receiveJ = txtreceiveJ . Text;
            _model . signDate = txtsignDate . Value;
            _model . varieties = txtvarieties . Text;
            _model . inputDate = txtinputDate . Value;
            _model . proName = txtproName . Text;
            _model . speci = txtspeci . Text;
            if (rabziying.Checked==true)
            {
                _model.duanxuan = "自营";
            }
            else if (rabzizhi.Checked == true)
            {
                _model.duanxuan = "自制";
            }
            else if (rabchengpin.Checked == true)
            {
                _model.duanxuan = "成品";
            }
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txttons . Text ) && decimal . TryParse ( txttons . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txttons ,"请重新输入" );
                result = false;
            }
            _model.tons = outResult;

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtShipmentsTons.Text) && decimal.TryParse(txtShipmentsTons.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtShipmentsTons, "请重新输入");
                result = false;
            }
            _model.ShipmentsTons = outResult;
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtLiNumber.Text)&&decimal.TryParse(txtLiNumber.Text,out outResult)==false)
            {
                errorProvider1.SetError(txtLiNumber, "请重新输入");
                result = false;
            }
            _model.LiNumber = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtprice . Text ) && decimal . TryParse ( txtprice . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtprice ,"请重新输入" );
                result = false;
            }
            _model . price = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtmoney . Text ) && decimal . TryParse ( txtmoney . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtmoney ,"请重新输入" );
                result = false;
            }
            _model . money = outResult;
            _model . country = txtcountry . Text;
            _model . brand = txtbrand . Text;
            _model . deliAdd = txtdeliAdd . Text;
            _model . fishId = txtfishId . Text;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtfreight . Text ) && decimal . TryParse ( txtfreight . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtfreight ,"请重新输入" );
                result = false;
            }
            if (rabchengpin.Checked == true || rabziying.Checked == true || rabzizhi.Checked == true)
            {
                
            }
            else
            {
                errorProvider1.SetError(rabchengpin, "必选一个");
                result = false;
            }
            _model . freight = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtcost . Text ) && decimal . TryParse ( txtcost . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtcost ,"请重新输入" );
                result = false;
            }
            _model . cost = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtloss . Text ) && decimal . TryParse ( txtloss . Text ,out outResult ) == false )
            {
                errorProvider1 . SetError ( txtloss ,"请重新输入" );
                result = false;
            }
            _model . loss = outResult;
            _model . condb = txtcondb . Text;
            _model . conza = txtconza . Text;
            _model . cons = txtcons . Text;
            _model . contvn = txtcontvn . Text;
            _model . conhf = txtconhf . Text;
            _model . consf = txtconsf . Text;
            _model . conshy = txtconshy . Text;
            _model . conzf = txtconzf . Text;
            if (!string.IsNullOrEmpty(txtreturnGoodsAdd.Text) )
            {
                errorProvider1.SetError(txtreturnGoodsAdd, "请重新输入");
                result = false;
            }
            _model . returnGoodsAdd = txtreturnGoodsAdd . Text;
            _model . remark = txtremark . Text;

            return result;
        }
        void setValue ( )
        {
            txtcode . Text = _model . code;
            txtcodeNum . Text = _model . codeNum;
            txtcodeNumContract . Text = _model . codeNumContract;
            txtreturnParty . Text = _model . returnParty;
            txtreturnPartyJ . Text = _model . returnPartyJ;
            txtreceive . Text = _model . receive;
            txtreceiveJ . Text = _model . receiveJ;
            if (_model.duanxuan=="自营")
            {
                rabziying.Checked = true;
            }
            else if (_model.duanxuan == "自制")
            {
                rabzizhi.Checked = true;
            }
            else if (_model.duanxuan == "成品")
            {
                rabchengpin.Checked = true;
            }
            if ( _model . signDate > DateTime . MinValue && _model . signDate < DateTime . MaxValue )
                txtsignDate . Value = Convert . ToDateTime ( _model . signDate );
            _model . varieties = txtvarieties . Text;
            txtproName . Text = _model . proName;
            txtspeci . Text = _model . speci;
            txttons . Text = _model . tons . ToString ( );
            txtShipmentsTons.Text = _model.ShipmentsTons.ToString();
            txtLiNumber.Text = _model.LiNumber.ToString();
            txtprice . Text = _model . price . ToString ( );
            txtmoney . Text = _model . money . ToString ( );
            txtcountry . Text = _model . country;
            txtbrand . Text = _model . brand;
            txtdeliAdd . Text = _model . deliAdd;
            txtfishId . Text = _model . fishId;
            txtfreight . Text = _model . freight . ToString ( );
            txtcost . Text = _model . cost . ToString ( );
            txtloss . Text = _model . loss . ToString ( );
            txtcondb . Text = _model . condb;
            txtconza . Text = _model . conza;
            txtcons . Text = _model . cons;
            txtcontvn . Text = _model . contvn;
            txtconhf . Text = _model . conhf;
            txtconsf . Text = _model . consf;
            txtconshy . Text = _model . conshy;
            txtconzf . Text = _model . conzf;
            txtreturnGoodsAdd . Text = _model . returnGoodsAdd;
            txtremark . Text = _model . remark;
            panel1.Enabled = true;
            if (txtcodeNum.Text!="")
            {
                FishEntity.SalesRequisitionEntity mo = null;
                mo = _bll.GetModelzy(" Numbering = '"+txtcodeNum.Text+"'");
                if (mo!=null)
                {
                    if (mo.RabZy==true)
                    {
                        rabchengpin.Enabled = false; rabchengpin.Checked = false;
                    }
                }
            }
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

            _model = _bll . GetModel ( whereEx );
            if ( _model == null )
            {
                MessageBox . Show ( "已经没有记录了" );
                return;
            }
            setValue ( );
        }
        public string getcode
        {
            get
            {
                return txtcode . Text;
            }
        }
        #endregion
        string _rolewhere = string.Empty;
        private void FormReturnReceipt_Load(object sender, EventArgs e)
        {
            MenuCode = "M462"; ControlButtomRoles();
            if (Megres.oddNum != "")
            {
                _rolewhere = " code='" + Megres.oddNum + "'";
                _model = _bll.GetModel(_rolewhere);
            }
            Megres.oddNum = string.Empty;
            if (_model == null)
            {
                MessageBox.Show("没有记录了");
            }else { 
            setValue();
            }
        }

        private void txttons_TextChanged(object sender, EventArgs e)
        {
            decimal num1 = 0.00M, num2 = 0.00M; bool isok = true;
            if (!string.IsNullOrEmpty(txttons.Text) && decimal.TryParse(txttons.Text, out num2) == false)
            {
                errorProvider1.SetError(txttons, "请重新输入");
                isok = false;
            }
            if (!string.IsNullOrEmpty(txtShipmentsTons.Text) && decimal.TryParse(txtShipmentsTons.Text, out num1) == false)
            {
                errorProvider1.SetError(txtShipmentsTons, "请重新输入");
                isok = false;
            }
            if (isok != false)
            {
                txtloss.Text = Convert.ToDecimal(num1 - num2).ToString();
            }
        }

        private void txtShipmentsTons_TextChanged(object sender, EventArgs e)
        {
            decimal num1 = 0.00M, num2 = 0.00M; bool isok = true;
            if (!string.IsNullOrEmpty(txttons.Text) && decimal.TryParse(txttons.Text, out num2) == false)
            {
                errorProvider1.SetError(txttons, "请重新输入");
                isok = false;
            }
            if (!string.IsNullOrEmpty(txtShipmentsTons.Text) && decimal.TryParse(txtShipmentsTons.Text, out num1) == false)
            {
                errorProvider1.SetError(txtShipmentsTons, "请重新输入");
                isok = false;
            }
            if (isok != false)
            {
                txtloss.Text = Convert.ToDecimal(num1 - num2).ToString();
            }
        }
    }
}
