using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FishClient
{
    //t_StorageOfRequisition
    public partial class FormStorageOfRequisition : FormMenuBase
    {
        FishEntity.StorageOfRequisitionEntity _model = null;
        FishBll.Bll.StorageOfRequisitionBll _bll = null;
        string getname = string.Empty;
        bool result = false; decimal outResult = 0M;
        string strWhere = string.Empty;

        public FormStorageOfRequisition()
        {
            InitializeComponent();

            _model = new FishEntity.StorageOfRequisitionEntity();
            _bll = new FishBll.Bll.StorageOfRequisitionBll();
        }
        public FormStorageOfRequisition(string codenum)
        {
            InitializeComponent();
            getname = codenum;
            _model = new FishEntity.StorageOfRequisitionEntity();
            _bll = new FishBll.Bll.StorageOfRequisitionBll();
            InitDataUtil.BindComboBoxData(txtcountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(txtbrand, FishEntity.Constant.Brand, true);
            txtcountry.SelectedValueChanged -= country_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(txtcountry, FishEntity.Constant.CountryType, true);
            txtcountry.SelectedValueChanged += country_SelectedValueChanged;
        }

        private void FormStorageOfRequisition_Load(object sender, EventArgs e)
        {
            if (Megres.oddNum != "")
            {
                MenuCode = "M450"; ControlButtomRoles();
                strWhere = "1=1";
                strWhere = strWhere + " and code='" + Megres.oddNum + "'";
                if (Megres.fishId != "")
                    strWhere = strWhere + " and fishId='" + Megres.fishId + "'";
                _model = _bll.getModel(strWhere);
                if (_model == null)
                {
                    MessageBox.Show("查无记录");
                    return;
                }
                setValue();
            }
            else
                strWhere = "";
            Megres.oddNum = Megres.fishId = string.Empty;
        }

        #region Main
        public override int Query()
        {
            FormStorageOfRequisitionQuery form = new FormStorageOfRequisitionQuery(this.Text + "查询");
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
        public override void Previous()
        {
            QueryOne("<", "'order by id asc limit 1'");

            base.Previous();
        }
        public override void Next()
        {
            QueryOne(">", "'order by id asc limit 1'");

            base.Next();
        }
        void country_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (txtcountry.SelectedValue == null) return;
            string pcode = txtcountry.SelectedValue.ToString();
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

            txtbrand.DisplayMember = "name";
            txtbrand.ValueMember = "code";
            txtbrand.DataSource = list;
        }
        public override int Add()
        {
            controlClear();
            txtcode.Text = _bll.getCode();
            FishEntity.PriWarehouseEntity addmodel = new FishEntity.PriWarehouseEntity();
            if (getname != null && getname != "")
            {
                addmodel = _bll.addRK(" where a.codeNum = '" + getname + "' ");
                if (addmodel != null)
                {
                    txtfishId.Text = addmodel.FishId;
                    txtcodeNum.Text = addmodel.CodeNum;
                    txtcodeNumContract.Text = addmodel.CodeNumContract;
                    txtsaWeight.Text = addmodel.Confirmsgsweight;
                    txtprice.Text = addmodel.Confirmrmb;
                    txtshipName.Text = addmodel.ShipName;
                    txtcountry.Text = addmodel.Conutry;
                    txtsupply .Text= addmodel.gongfang;
                    txtbrand.Text = addmodel.Brand;
                    txtbillName.Text = addmodel.BillName;
                    txtpileNum.Text = addmodel.Cornerno;
                    txtproName.Text = addmodel.Name;
                    txtqualitySpe.Text = addmodel.QuaSpe;
                    txtza.Text = addmodel.Sgs_amine;
                    txttvn.Text = addmodel.Sgs_tvn;
                    txtzf.Text = addmodel.Sgs_fat;
                    txthf.Text = addmodel.Sgs_graypart;
                    txtsand.Text = addmodel.Sgs_sand;
                    txtsf.Text = addmodel.Sgs_water;
                    txtdb.Text = addmodel.Sgs_protein;
                    txtshy.Text = addmodel.Sgs_sandsalt;
                }
            }
            return base.Add();
        }
        public override int Modify()
        {
            if (getValue() == false)
                return 0;

            result = _bll.Edit(_model);
            if (result)
                MessageBox.Show("保存成功");
            else
                MessageBox.Show("保存失败");

            return base.Modify();
        }
        public override int Delete()
        {

            _model.code = txtcode.Text;

            if (_bll.Exists_isDel(_model.code))
            {
                MessageBox.Show("配料单已经领取,不允许删除");
                return 0;
            }

            result = _bll.Delete(this.Name, _model.code);
            if (result == false)
                MessageBox.Show("删除失败");
            else
                controlClear();

            return base.Delete();
        }
        public override void Save()
        {
            if (getValue() == false)
                return;

            if (_bll.Exists(_model.code))
            {
                MessageBox.Show("请修改");
                return;
            }
            _model.id = _bll.Add(_model, this.Name);
            if (_model.id > 0)
            {
                MessageBox.Show("保存成功");
                txtcode.Tag = _model.id;
            }
            else
                MessageBox.Show("保存失败");

            base.Save();
        }
        public override void Review()
        {
            //TODO:自动审核送给谁？
            Review(this.Name, txtcodeNum.Text, txtcode.Text);

            base.Review();
        }
        #endregion

        #region Event
        private void txtcode_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcode.Text))
                this.DialogResult = DialogResult.Cancel;
            this.DialogResult = DialogResult.OK;
        }
        private void txtfishId_DoubleClick(object sender, EventArgs e)
        {
            //FormWarehouseReceipt form = new FormWarehouseReceipt ( );
            //if ( form . ShowDialog ( ) == DialogResult . OK )
            //{
            //    FishEntity . WarehouseReceiptEntity model = form . getModel;
            //    if ( model == null )
            //        return;
            //    txtfishId . Text = model . fishId;
            //    txtjcCode . Text = model . code;
            //    txtcodeNum . Text = model . codeNum;
            //    txtliWeight . Text = model . weight . ToString ( );
            //    txtcodeNumContract . Text = model . codeNumContract;
            //    txtprice . Text = model . price . ToString ( );
            //    txtsupply . Text = model . shipMentUser;
            //    txtshipName . Text = model . shipName;

            //}

            //FormPriWarehouse form = new FormPriWarehouse();
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    FishEntity.QuotationPriceListEntity model = form.getModel;
            //    if (model == null)
            //        return;
            //    txtfishId.Text = model.fishId;
            //    //txtjcCode . Text = model . code;
            //    txtcodeNum.Text = model.code;
            //    txtliWeight.Text = model.weight.ToString();
            //    txtcodeNumContract.Text = model.CodeNumSales;
            //    txtprice.Text = model.price.ToString();
            //    //txtsupply . Text = model . shipMentUser;
            //    txtshipName.Text = model.ShipName;
            //}
            FormNewFish from = new FormNewFish(txtfishId.Text);
            from.Show();

        }
        private void txtcountry_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtfishId.Text))
            {
                MessageBox.Show("请选择鱼粉ID");
                return;
            }
            FormFish form = new FormFish(txtfishId.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                FishEntity.ProductEntity _fish = form.getEntity;
                if (_fish == null)
                    return;
                txtcountry.Text = _fish.nature;
                txtbrand.Text = _fish.brand;
                txtpileNum.Text = _fish.cornerno;
                txtproName.Text = _fish.name;
                txtqualitySpe.Text = _fish.specification;
                txtza.Text = _fish.sgs_amine.ToString("f2");
                txttvn.Text = _fish.sgs_tvn.ToString("f2");
                txtzf.Text = _fish.sgs_fat.ToString();
                txthf.Text = _fish.sgs_graypart.ToString();
                txtsand.Text = _fish.sgs_sand.ToString();
                txtbillName.Text = _fish.billofgoods;
                txtsf.Text = _fish.sgs_water.ToString();
                txtdb.Text = _fish.sgs_protein.ToString();
                txtshy.Text = _fish.sgs_sandsalt.ToString();
            }
        }
        private void txtthCodeNum_DoubleClick(object sender, EventArgs e)
        {
            //获取退货单单号
            FormReturnReceipt form = new FormReturnReceipt();
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtthCodeNum.Text = form.getcode;
            }
        }
        #endregion

        #region Method
        void controlClear()
        {
            foreach (Control con in panel1.Controls)
            {
                if (con.GetType() == typeof(TextBox))
                {
                    TextBox tb = con as TextBox;
                    tb.Text = string.Empty;
                }
                if (con.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker tb = con as DateTimePicker;
                    tb.Value = DateTime.Now;
                }
            }
        }
        void setValue()
        {
            //_model = new FishEntity . StorageOfRequisitionEntity ( );
            //PropertyInfo [ ] properties = _model . GetType ( ) . GetProperties ( );

            //foreach ( Control con in panel1 . Controls )
            //{
            //    foreach ( var item in properties )
            //    {
            //        if ( con . Name . Contains ( item . Name ) )
            //        {
            //            if ( con . GetType ( ) == typeof ( TextBox ) )
            //            {
            //                TextBox tb = con as TextBox;
            //                tb . Text = item . ToString ( );
            //                if ( tb . Name . Equals ( txtcode ) )
            //                {
            //                    tb . Tag = _model . id;
            //                }
            //            }
            //            if ( con . GetType ( ) == typeof ( DateTimePicker ) )
            //            {
            //                DateTimePicker dt = con as DateTimePicker;
            //                if ( !string . IsNullOrEmpty ( item . ToString ( ) ) )
            //                {
            //                    dt . Value = Convert . ToDateTime ( item . ToString ( ) );
            //                }
            //            }
            //        }
            //    }
            //}

            txtcode.Tag = _model.id;
            txtcode.Text = _model.code;
            txtfishId.Text = _model.fishId;
            txtliWeight.Text = _model.liWeight.ToString();
            txtliNumber.Text = _model.LiNumber.ToString();
            txtprice.Text = _model.price.ToString();
            txtshipName.Text = _model.shipName;
            txtcountry.Text = _model.country;
            txtbillName.Text = _model.billName;
            txtproName.Text = _model.proName;
            txtza.Text = _model.za;
            txtzf.Text = _model.zf;
            txtsand.Text = _model.sand;
            txtdb.Text = _model.db;
            if (_model.applyDate > DateTime.MinValue && _model.applyDate < DateTime.MaxValue)
                txtapplyDate.Value = Convert.ToDateTime(_model.applyDate);
            else
                txtapplyDate.Value = DateTime.Now;
            txtthCodeNum.Text = _model.thCodeNum;
            txtsupply.Text = _model.supply;
            txtsaWeight.Text = _model.saWeight.ToString();
            txtbrand.Text = _model.brand;
            txtpileNum.Text = _model.pileNum;
            txtqualitySpe.Text = _model.qualitySpe;
            txttvn.Text = _model.tvn;
            txthf.Text = _model.hf;
            txtsf.Text = _model.sf;
            txtshy.Text = _model.shy;
            txtremark.Text = _model.remark;
            txtcode.Text = _model.code;
            txtcodeNumContract.Text = _model.codeNumContract;
            txtjcCode.Text = _model.jcCode;
            txtcodeNum.Text = _model.codeNum;
        }
        bool getValue()
        {
            if (_model == null)
                _model = new FishEntity.StorageOfRequisitionEntity();
            errorProvider1.Clear();

            if (string.IsNullOrEmpty(txtcode.Text))
            {
                errorProvider1.SetError(txtcode, "不可为空");
                return false;
            }
            if (string.IsNullOrEmpty(txtfishId.Text))
            {
                errorProvider1.SetError(txtfishId, "不可为空");
                return false;
            }

            outResult = 0M;
            if (!string.IsNullOrEmpty(txtthCodeNum.Text) && decimal.TryParse(txtthCodeNum.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtthCodeNum, "请重新输入");
                return false;
            }
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtliWeight.Text) && decimal.TryParse(txtliWeight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtliWeight, "请重新输入");
                return false;
            }
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtliNumber.Text) && decimal.TryParse(txtliNumber.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtliNumber, "请重新输入");
                return false;
            }
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtprice.Text) && decimal.TryParse(txtprice.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtprice, "请重新输入");
                return false;
            }
            outResult = 0M;
            if (!string.IsNullOrEmpty(txtsaWeight.Text) && decimal.TryParse(txtsaWeight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtsaWeight, "请重新输入");
                return false;
            }

            if (txtcode.Tag == null)
                _model.id = 0;
            else
                _model.id = Convert.ToInt32(txtcode.Tag);

            _model.code = txtcode.Text;
            _model.fishId = txtfishId.Text;
            _model.liWeight = string.IsNullOrEmpty(txtliWeight.Text) == true ? 0 : Convert.ToDecimal(txtliWeight.Text);
            _model.LiNumber = string.IsNullOrEmpty(txtliNumber.Text) == true ? 0 : Convert.ToDecimal(txtliNumber.Text);
            _model.price = string.IsNullOrEmpty(txtprice.Text) == true ? 0 : Convert.ToDecimal(txtprice.Text);
            _model.shipName = txtshipName.Text;
            _model.country = txtcountry.Text;
            _model.billName = txtbillName.Text;
            _model.proName = txtproName.Text;
            _model.za = txtza.Text;
            _model.zf = txtzf.Text;
            _model.sand = txtsand.Text;
            _model.db = txtdb.Text;
            _model.applyDate = txtapplyDate.Value;
            _model.thCodeNum = txtthCodeNum.Text;
            _model.supply = txtsupply.Text;
            _model.saWeight = string.IsNullOrEmpty(txtsaWeight.Text) == true ? 0 : Convert.ToDecimal(txtsaWeight.Text);
            _model.brand = txtbrand.Text;
            _model.pileNum = txtpileNum.Text;
            _model.qualitySpe = txtqualitySpe.Text;
            _model.tvn = txttvn.Text;
            _model.hf = txthf.Text;
            _model.sf = txtsf.Text;
            _model.shy = txtshy.Text;
            _model.remark = txtremark.Text;
            _model.codeNum = txtcodeNum.Text;
            _model.codeNumContract = txtcodeNumContract.Text;
            _model.jcCode = txtjcCode.Text;

            return true;
        }
        public FishEntity.StorageOfRequisitionEntity getModel
        {
            get
            {
                return _model;
            }
        }
        void QueryOne(string operate, string orderBy)
        {
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(strWhere))
                whereEx = "1=1";
            else
                whereEx = strWhere;
            if (_model != null)
                whereEx = whereEx + " AND code " + operate + orderBy;

            _model = _bll.getModel(whereEx);
            if (_model == null)
            {
                MessageBox.Show("已经没有记录了");
                return;
            }
            setValue();
        }

        #endregion

        private void txtsupply_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                FishEntity.PurchaseApplicationEntity _model = new FishEntity.PurchaseApplicationEntity();
                _model = form.getModel;
                txtsupply.Text = _model.buyer;
            }
        }
    }
}
