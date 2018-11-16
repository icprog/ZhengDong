using FishEntity;
using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace FishClient
{
    //t_OutboundOrder
    public partial class FormOutboundOrder : FormMenuBase
    {
        FishEntity.OutboundOrderEntity _model = null;
        FishBll.Bll.OutboundOrderBll _bll = null;
        FishEntity.SalesRequisitionEntity getfish = null;
        string getname = string.Empty;
        FormImage formimage = null;
        bool result = false;
        string strWhere = "1=1";
        int recordid_1 = 0;


        public FormOutboundOrder()
        {
            InitializeComponent();

            _model = new FishEntity.OutboundOrderEntity();
            _bll = new FishBll.Bll.OutboundOrderBll();

            InitDataUtil.BindComboBoxData(txttype, FishEntity.Constant.FishClass, true);
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbBrands, FishEntity.Constant.Brand, true);
            BindCountryBrandData();
        }
        public FormOutboundOrder(string name)
        {
            InitializeComponent();
            getname = name;
            _model = new FishEntity.OutboundOrderEntity();
            _bll = new FishBll.Bll.OutboundOrderBll();

            InitDataUtil.BindComboBoxData(txttype, FishEntity.Constant.FishClass, true);
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbBrands, FishEntity.Constant.Brand, true);
            BindCountryBrandData();
        }

        #region Main
        public override int Query()
        {
            FormOutboundOrderQuery form = new FormOutboundOrderQuery(this.Text + "查询");
            if (form.ShowDialog() == DialogResult.OK)
            {
                strWhere = form.getWhere;
                _model = _bll.GetModel(strWhere);
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
            txtcode.Text = _bll.getCode();
            if (getname != "" && getname != null)
            {
                getfish = new SalesRequisitionEntity();
                getfish = _bll.getCKD(" a.Numbering='" + getname + "' ");
                if (getfish != null)
                {
                    txtcodeNum.Text = getfish.Numbering;
                    txtcodeNumContract.Text = getfish.code;
                    txtFishMealId.Text = getfish.Product_id;
                    txtunit.Text = getfish.demand;
                    txtunit.Tag = getfish.demandId;
                    txtdate.Text = getfish.Signdate.ToString();
                    txtshipName.Text = getfish.cm;
                    txtspeci.Text = getfish.Funit;
                    txtweight.Text = getfish.Quantity;
                    txtbillName.Text = getfish.tdh;
                    txtpileNum.Text = getfish.zjh;
                    cmbCountry.Text = getfish.Country;
                    cmbBrands.Text = getfish.pp;
                }
            }
            return base.Add();
        }
        public override int Delete()
        {
            _model.code = txtcode.Text;
            result = _bll.Delete(_model.code);
            if (result)
            {
                MessageBox.Show("删除成功");
                clearControl();
                Previous();
            }
            else
                MessageBox.Show("删除失败");

            return base.Delete();
        }
        public override void Save()
        {
            if (getValue() == false)
                return;

            if (_bll.Exists(_model.code))
            {
                result = _bll.Update(_model);
                AddImages(_model);
            }
            else
            {
                result = _bll.Add(_model, this.Name);
                AddImages(_model);
            }
            if (result)
                MessageBox.Show("保存成功");
            else
                MessageBox.Show("保存失败");

            base.Save();
        }
        public override void Review()
        {
            Review(this.Name, txtcodeNum.Text, txtcode.Text);

            base.Review();
        }
        public override int Modify()
        {
            if (getValue() == false)
                return 0;
            result = _bll.Update(_model);
            if (result)
            {
                AddImages(_model);
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
            return base.Modify();
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
        #endregion

        #region Event
        private void txtunit_DoubleClick(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            if (form.ShowDialog() == DialogResult.OK)
            {
                PurchaseApplicationEntity _model = new PurchaseApplicationEntity();
                _model = form.getModel;
                txtunit.Text = _model.buyer;
            }
        }
        private void txtcodeNum_DoubleClick(object sender, EventArgs e)
        {
            FormSalesRequisition form = new FormSalesRequisition();
            if (form.ShowDialog() == DialogResult.OK)
            {
                SalesRequisitionEntity model = form.getMo;
                txtcodeNum.Text = model.Numbering;
                txtcodeNumContract.Text = model.code;
                txtFishMealId.Text = model.Product_id;
            }
        }
        #endregion

        #region Method
        void clearControl()
        {
            foreach (Control tc in panel1.Controls)
            {
                if (tc.GetType() == typeof(TextBox))
                {
                    TextBox tb = tc as TextBox;
                    tb.Text = string.Empty;
                }
                if (tc.GetType() == typeof(ComboBox))
                {
                    ComboBox tb = tc as ComboBox;
                    tb.Text = string.Empty;
                }
                if (tc.GetType() == typeof(DateTimePicker))
                {
                    DateTimePicker tb = tc as DateTimePicker;
                    tb.Value = DateTime.Now;
                }
            }
        }
        bool getValue()
        {
            errorProvider1.Clear();
            result = true;
            _model = new OutboundOrderEntity();
            _model.id = recordid_1;
            _model.code = txtcode.Text;
            _model.codeNum = txtcodeNum.Text;
            _model.codeNumContract = txtcodeNumContract.Text;
            if (string.IsNullOrEmpty(txtseNumber.Text))
            {
                errorProvider1.SetError(txtseNumber, "必填");
                result = false;
            }
            _model.codeNumContract = txtcodeNumContract.Text;
            if (string.IsNullOrEmpty(txtunit.Text))
            {
                errorProvider1.SetError(txtunit, "必填");
                result = false;
            }
            _model.seNumber = txtseNumber.Text;
            _model.unit = txtunit.Text;
            if (string.IsNullOrEmpty(txttype.Text))
            {
                errorProvider1.SetError(txttype, "必填");
                result = false;
            }
            _model.type = txttype.Text;
            if (string.IsNullOrEmpty(cmbCountry.Text))
            {
                errorProvider1.SetError(cmbCountry, "必填");
                result = false;
            }
            _model.Country = cmbCountry.Text;
            if (string.IsNullOrEmpty(cmbBrands.Text))
            {
                errorProvider1.SetError(cmbBrands, "必填");
                result = false;
            }
            _model.Brands = cmbBrands.Text;
            _model.FishMealId = txtFishMealId.Text;
            if (string.IsNullOrEmpty(txtshipName.Text))
            {
                errorProvider1.SetError(txtshipName, "必填");
                result = false;
            }
            _model.shipName = txtshipName.Text;
            decimal outResult = 0M;
            if (string.IsNullOrEmpty(txtweight.Text) && decimal.TryParse(txtweight.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtweight, "请重新输入");
                result = false;
            }

            _model.weight = outResult;
            if (string.IsNullOrEmpty(txtpileNum.Text))
            {
                errorProvider1.SetError(txtpileNum, "必填");
                result = false;
            }
            _model.pileNum = txtpileNum.Text;
            _model.date = txtdate.Value;
            if (string.IsNullOrEmpty(txtwaseHouse.Text))
            {
                errorProvider1.SetError(txtwaseHouse, "必填");
                result = false;
            }
            _model.waseHouse = txtwaseHouse.Text;
            if (string.IsNullOrEmpty(txtspeci.Text))
            {
                errorProvider1.SetError(txtspeci, "必填");
                result = false;
            }
            _model.speci = txtspeci.Text;
            if (string.IsNullOrEmpty(txtbillName.Text))
            {
                errorProvider1.SetError(txtbillName, "必填");
                result = false;
            }
            _model.billName = txtbillName.Text;
            int outRe = 0;
            if (string.IsNullOrEmpty(txtpageNum.Text) && int.TryParse(txtpageNum.Text, out outRe) == false)
            {
                errorProvider1.SetError(txtpageNum, "请重新输入");
                result = false;
            }
            _model.pageNum = outRe;
            if (string.IsNullOrEmpty(txtremark.Text))
            {
                errorProvider1.SetError(txtremark, "必填");
                result = false;
            }
            _model.remark = txtremark.Text;
            _model.notice = txtnotice.Text;
            outResult = 0M;
            if (string.IsNullOrEmpty(txtware.Text) && decimal.TryParse(txtware.Text, out outResult) == false)
            {
                errorProvider1.SetError(txtware, "请重新输入");
                result = false;
            }
            _model.ware = outResult;
            _model.receive = txtreceive.Text;

            return result;
        }
        void setValue()
        {
            recordid_1 = _model.id;
            txtcode.Text = _model.code;
            txtcodeNum.Text = _model.codeNum;
            txtcodeNumContract.Text = _model.codeNumContract;
            txtseNumber.Text = _model.seNumber;
            txtunit.Text = _model.unit;
            txttype.Text = _model.type;
            cmbCountry.Text = _model.Country;
            cmbBrands.Text = _model.Brands;
            txtFishMealId.Text = _model.FishMealId;
            txtshipName.Text = _model.shipName;
            txtweight.Text = _model.weight.ToString();
            txtpileNum.Text = _model.pileNum;
            if (_model.date > DateTime.MinValue && _model.date < DateTime.MaxValue)
                txtdate.Value = Convert.ToDateTime(_model.date);
            txtwaseHouse.Text = _model.waseHouse;
            txtspeci.Text = _model.speci;
            txtbillName.Text = _model.billName;
            txtpageNum.Text = _model.pageNum.ToString();
            txtremark.Text = _model.remark;
            txtnotice.Text = _model.notice;
            txtware.Text = _model.ware.ToString();
            txtreceive.Text = _model.receive;
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

            _model = _bll.GetModel(whereEx);
            if (_model == null)
            {
                MessageBox.Show("已经没有记录了");
                return;
            }
            setValue();
        }

        #endregion

        void cmbCountry_SelectedValueChanged(object sender, EventArgs e)
        {
            BindCountryBrandData();
        }
        private void BindCountryBrandData()
        {
            //cmbBand.DataSource = null;
            if (cmbCountry.SelectedValue == null) return;
            string pcode = cmbCountry.SelectedValue.ToString();
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

            cmbBrands.DisplayMember = "name";
            cmbBrands.ValueMember = "code";
            cmbBrands.DataSource = list;
        }

        private void btnimage_Click(object sender, EventArgs e)
        {
            if (formimage == null)
            {
                formimage = new FormImage(0, FishEntity.ImageTypeEnum.CHUKUDAN);
            }
            formimage.SetData(_model == null ? 0 : _model.id, FishEntity.ImageTypeEnum.CHUKUDAN);
            formimage.StartPosition = FormStartPosition.CenterParent;
            if (formimage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
        public List<FishEntity.ImageEntity> GetCKDImages()
        {
            if (formimage == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (formimage.Image1 != null && formimage.Image1.image != null) images.Add(formimage.Image1);
            if (formimage.Image2 != null && formimage.Image2.image != null) images.Add(formimage.Image2);
            if (formimage.Image3 != null && formimage.Image3.image != null) images.Add(formimage.Image3);

            return images;
        }
        protected void AddImages(FishEntity.OutboundOrderEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();

            if (fish.id > 0)
            {
                bll.DeleteByRecordIdAndType(fish.id, (int)FishEntity.ImageTypeEnum.CHUKUDAN);
            }

            List<FishEntity.ImageEntity> images = GetCKDImages();

            images = GetCKDImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.id;
                    item.createman = FishEntity.Variable.User.username;
                    item.createtime = DateTime.Now;
                    item.remark = this.Name;
                    item.title = "出库单";
                    bll.Add(item);
                }
            }
        }

        private void FormOutboundOrder_Load(object sender, EventArgs e)
        {
            MenuCode = "M455"; ControlButtomRoles();
            if (Megres.oddNum != null && Megres.oddNum.ToString() != "")
            {
                _model = _bll.GetModel("code='"+Megres.oddNum+"' ");
                if (_model == null)
                {
                    MessageBox.Show("没有记录了");
                }
                else
                {
                    setValue();
                }
                Megres.oddNum = string.Empty;
            }            
        }
    }
}
