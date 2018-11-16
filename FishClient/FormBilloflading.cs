using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormBilloflading : FormMenuBase
    {
        /// <summary>
        /// 流程状态表刷新
        /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        bool isOk = false;
        private FishBll.Bll.BillofladingBll _bll = new FishBll.Bll.BillofladingBll();
        FormImage formimage = null;
        private UIForms.FormBillofladingCondition _BillForm = null;
        FishEntity.BillofladingEntity _fish = null;
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        private string _rolewhere = string.Empty;
        string getname = string.Empty;
        FishEntity.SalesRequisitionEntity getfish = null;
        public FormBilloflading()
        {
            InitializeComponent();
            this.panel1.Enabled = false;
            InitDataUtil.BindComboBoxData(cmbspecification, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbspecies, FishEntity.Constant.Goods, true);
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbBrands, FishEntity.Constant.Brand, true);
            BindCountryBrandData();
        }
        bool GetValue()
        {
            errorProvider1.Clear();
            isOk = true;

            if (!string.IsNullOrEmpty(txtTon.Text) && !string.IsNullOrEmpty(txtRedemptionWeight.Text))
            {
                if (decimal.Parse(txtTon.Text.ToString()) > decimal.Parse(txtRedemptionWeight.Text.ToString()))
                {
                    errorProvider1.SetError(txtRedemptionWeight, "磅单净重<=赎单重量");
                    isOk = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtRedemptionWeight, "不能为空");
                errorProvider1.SetError(txtTon, "不能为空");
                isOk = false;
            }

            return isOk;
        }
        public FormBilloflading(string name)
        {
            InitializeComponent();
            getname = name;
            this.panel1.Enabled = false;
            InitDataUtil.BindComboBoxData(cmbspecification, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbspecies, FishEntity.Constant.Goods, true);
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbBrands, FishEntity.Constant.Brand, true);
            BindCountryBrandData();
        }
        public override void Review()
        {
            Review(this.Name, txtNumbering.Text, txtcode.Text);
            //if (txtNumbering.Text != "")
            //{
            //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //    _Refreshbll.GetFormBilloflading(txtNumbering.Text);
            //}
            base.Review();
        }
        private void FormBilloflading_Load ( object sender ,EventArgs e )
        {
            MenuCode = "M403"; ControlButtomRoles();
            if (Megres.oddNum!=null&&Megres.oddNum.ToString()!="")
            {
            _rolewhere = " and code='" + Megres . oddNum + "'";
                List<FishEntity.BillofladingEntityVo> list = _bll.GetModelListVo(_rolewhere);
                if (list == null || list.Count < 1)
                {
                    _fish = null;
                }
                else
                {
                    _fish = list[0];
                    SetOnepound();
                    panel1.Enabled = true;
                }
            }            
            Megres.oddNum = string.Empty;           
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
            txtcode.Text = string.Empty;
            txtFishMealId.Text = string.Empty;
            cmbCountry.SelectedValue = string.Empty;
            cmbBrands.SelectedValue = string.Empty;
            cmbspecies.SelectedValue = string.Empty;
            cmbspecification.SelectedValue = string.Empty;
            dtpIssuingtime.Value = DateTime.Now;
            txtcontactsunit.Text = string.Empty;
            txtcontactsunit.Tag = string.Empty;
            txtwarehouse.Text = string.Empty;
            txtferryname.Text = string.Empty;
            txtlistname.Text = string.Empty;
            txtcornerno.Text = string.Empty;
            txtTon.Text = string.Empty;
            txtRedemptionWeight.Text = string.Empty;
            txtpackagenumber.Text = string.Empty;
            txtRemarks.Text = string.Empty;
            txtSerialNumber.Text = string.Empty;
            txtShipNotice.Text = string.Empty;
            txtStoragecosts.Text = string.Empty;
            txtCodeOdd . Text = string . Empty;
            txtRecipient.Text = string.Empty;
            if (getname!="")
            {
                getfish = _bll.getDHT(getname);
                if (getfish!=null)
                {
                    txtNumbering.Text = getfish.Numbering;
                    txtcontactsunit.Text = getfish.demand;
                    txtcontactsunit.Tag = getfish.demandId;
                    txtlistname.Text = getfish.tdh;
                    txtCodeOdd.Text = getfish.code;
                    txtTon.Text = getfish.Quantity;
                    txtcornerno.Text = getfish.zjh;
                    cmbspecies.SelectedValue= getfish.Variety;
                    txtferryname.Text = getfish.cm;
                    txtFishMealId.Text = getfish.Product_id;
                }
            }
            return 1;
        }
        public override int Query()
        {
            if (_BillForm == null)
            {
                _BillForm = new UIForms.FormBillofladingCondition();
                _BillForm.StartPosition = FormStartPosition.CenterParent;
                _BillForm.ShowInTaskbar = false;
            }
            if (_BillForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = _BillForm.GetWhereCondition;
            List<FishEntity.BillofladingEntityVo> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;                
                return 1;
            }
            else
            {
                _fish = list[0];
                SetOnepound();
                panel1.Enabled = true;
                return 1;
            }
        }

        protected void SetOnepound()
        {
            dtpIssuingtime.Value = _fish.Issuingtime.Value;
            txtcode.Text = _fish.Code.ToString();
            txtcontactsunit.Text = _fish.Contactsunit;
            txtcontactsunit.Tag = _fish.ContactsunitId;
            txtwarehouse.Text = _fish.Warehouse;
            cmbspecies.SelectedValue = _fish.Species;
            cmbspecification.SelectedValue = _fish.Specification;
            txtferryname.Text = _fish.Ferryname;
            cmbCountry.SelectedValue = _fish.Country;
            cmbBrands.SelectedValue=_fish.Brands;
            txtFishMealId.Text = _fish.FishMealId;
            txtlistname.Text = _fish.Listname;
            txtcornerno.Text = _fish.Cornerno;
            txtTon.Text = _fish.Ton;
            txtRedemptionWeight.Text = _fish.RedemptionWeight.ToString();
            txtpackagenumber.Text = _fish.Packagenumber;
            txtRemarks.Text = _fish.Remarks;
            txtSerialNumber.Text = _fish.SerialNumber;
            txtShipNotice.Text = _fish.ShipNotice;
            txtStoragecosts.Text = _fish.Storagecosts;
            txtCodeOdd . Text = _fish . codeContract;
            txtRecipient.Text = _fish.Recipient;
            txtNumbering.Text = _fish.Numbering;
            txtcreateman.Text = _fish.Createman;
            txtmodifyman.Text = _fish.Modifyman;
        }
        public List<FishEntity.ImageEntity> GetSGSImages()
        {
            if (formimage == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (formimage.Image1 != null && formimage.Image1.image != null) images.Add(formimage.Image1);
            if (formimage.Image2 != null && formimage.Image2.image != null) images.Add(formimage.Image2);
            if (formimage.Image3 != null && formimage.Image3.image != null) images.Add(formimage.Image3);

            return images;
        }
        protected void AddImages(FishEntity.BillofladingEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();

            if (fish.Id > 0)
            {
                bll.DeleteByRecordIdAndType(fish.Id, (int)FishEntity.ImageTypeEnum.SGS);
            }

            List<FishEntity.ImageEntity> images = GetSGSImages();

            images = GetSGSImages();
            if (images != null)
            {
                foreach (FishEntity.ImageEntity item in images)
                {
                    item.recordid = fish.Id;
                    item.createman = fish.Createman;
                    item.createtime = fish.Createtime;
                    bll.Add(item);
                }
            }
        }
        public override void Save()
        {
            if (GetValue()==false)
            {
                return;
            }
            FishEntity.BillofladingEntity _fish = new FishEntity.BillofladingEntity();
            if (string.IsNullOrEmpty(txtcontactsunit.Text) == false)
            {
                _fish.Contactsunit = txtcontactsunit.Text.Trim().ToString();
            }
            else
            {
                MessageBox.Show("请选择提货单位。");
                return;
            }
            if ( string . IsNullOrEmpty ( txtCodeOdd . Text ) )
            {
                MessageBox . Show ( "请选择销售合同号" );
                return;
            }
            _fish.Code = FishBll.Bll.SequenceUtil.GetBillofladingnumber();
            _fish.ContactsunitId = txtcontactsunit.Tag.ToString();
            _fish.Issuingtime = dtpIssuingtime.Value;
            _fish.Warehouse = txtwarehouse.Text.ToString();
            _fish.Species = cmbspecies.SelectedValue == null ? string.Empty : cmbspecies.SelectedValue.ToString();
            _fish.Specification = cmbspecification.SelectedValue == null ? string.Empty : cmbspecification.SelectedValue.ToString();
            _fish.Ferryname = txtferryname.Text.ToString();
            _fish.FishMealId = txtFishMealId.Text.ToString();
            _fish.Country = cmbCountry.SelectedValue == null ? string.Empty : cmbCountry.SelectedValue.ToString();
            _fish.Brands = cmbBrands.SelectedValue == null ? string.Empty : cmbBrands.SelectedValue.ToString();
            _fish.Listname = txtlistname.Text.ToString();
            _fish.Cornerno = txtcornerno.Text.ToString();
            _fish.Ton = txtTon.Text;
            decimal temp = 0;
            decimal.TryParse(txtRedemptionWeight.Text, out temp);
            _fish.RedemptionWeight = temp;
            _fish.Packagenumber = txtpackagenumber.Text;
            _fish.Remarks = txtRemarks.Text.ToString().Trim();
            _fish.SerialNumber = txtSerialNumber.Text.ToString();
            _fish.ShipNotice = txtShipNotice.Text.ToString().Trim();
            _fish.Storagecosts = txtStoragecosts.Text;
            _fish.Createtime = DateTime.Now;
            _fish.Createman = FishEntity.Variable.User.username;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = _fish.Createman;
            _fish . codeContract = txtCodeOdd . Text;
            _fish.Recipient = txtRecipient.Text;
            _fish.Numbering = txtNumbering.Text;
            FishBll.Bll.BillofladingBll bll = new FishBll.Bll.BillofladingBll();
            bool isok = bll.Exists(_fish.Code);
            while (isok)
            {
                _fish.Code = FishBll.Bll.SequenceUtil.GetBillofladingnumber();
                isok = bll.Exists(_fish.Code);
            }
            int id = bll . Add ( _fish ,this . Name );
            if (id > 0)
            {
                //if (txtNumbering.Text!="")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormBilloflading(txtNumbering.Text);
                //}
                _fish.Id = id;
                AddImages(_fish);
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = true;
                tmiAdd.Visible = false;
                tmiSave.Visible = false;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");
                txtcode.Text = _fish.Code;
            }
            else
            {
                txtcode.Text = _fish.Code;
                MessageBox.Show("添加失败。");
            }
        }
        public override int Modify()
        {
            if ( string . IsNullOrEmpty ( txtCodeOdd . Text ) )
            {
                MessageBox . Show ( "请选择销售合同号" );
                return 0;
            }
            if (GetValue() == false)
            {
                return 0;
            }
            _fish.Contactsunit = txtcontactsunit.Text.ToString();
            _fish.ContactsunitId = txtcontactsunit.Tag.ToString();
            _fish.Issuingtime = dtpIssuingtime.Value;
            _fish.Warehouse = txtwarehouse.Text.ToString();
            _fish.Species = cmbspecies.SelectedValue == null ? string.Empty : cmbspecies.SelectedValue.ToString();
            _fish.Specification = cmbspecification.SelectedValue == null ? string.Empty : cmbspecification.SelectedValue.ToString();
            _fish.Ferryname = txtferryname.Text.ToString();
            _fish.FishMealId = txtFishMealId.Text.ToString();
            _fish.Country = cmbCountry.SelectedValue == null ? string.Empty : cmbCountry.SelectedValue.ToString();
            _fish.Brands = cmbBrands.SelectedValue == null ? string.Empty : cmbBrands.SelectedValue.ToString();
            _fish.Listname = txtlistname.Text.ToString();
            _fish.Cornerno = txtcornerno.Text.ToString();
            _fish.Ton = txtTon.Text;
            decimal temp = 0;
            decimal.TryParse(txtRedemptionWeight.Text, out temp);
            _fish.RedemptionWeight = temp;
            _fish.Packagenumber = txtpackagenumber.Text;
            _fish.Remarks = txtRemarks.Text.ToString();
            _fish.SerialNumber = txtSerialNumber.Text;
            _fish.ShipNotice = txtShipNotice.Text.ToString();
            _fish.Storagecosts = txtStoragecosts.Text;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;
            _fish . codeContract = txtCodeOdd .Text.ToString();
            _fish.Recipient = txtRecipient.Text.ToString();
            FishBll .Bll.BillofladingBll bll = new FishBll.Bll.BillofladingBll();
            if (bll.ExistsUpdate(_fish.Code,FishEntity.Variable.User.username)!=true)
            {
                MessageBox.Show("不是所属人无法操作！");
                return 0;
            }
            bool isOk = bll.Update(_fish);
            AddImages(_fish);
            if (isOk)
            {
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormBilloflading(txtNumbering.Text);
                //}
                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }
        private void txtcontactsunit_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtcontactsunit.Text = form.SelectCompany.fullname;
            txtcontactsunit.Tag = form.SelectCompany;
        }
        public override void Cancel()
        {
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
        }

        private void btnimage_Click(object sender, EventArgs e)
        {
            if (formimage == null)
            {
                formimage = new FormImage(0, FishEntity.ImageTypeEnum.SGS);
            }

            formimage.SetData(_fish == null ? 0 : _fish.Id, FishEntity.ImageTypeEnum.SGS);

            formimage.StartPosition = FormStartPosition.CenterParent;
            if (formimage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }

        public string bdh
        {
            get
            {
                //返回销售申请单需要的提单号
                return txtcode . Text;
            }
        }

        private void txtcode_DoubleClick ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . OK;
        }

        /// <summary>
        /// 读取现货销售合同的单号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCodeOdd_Click ( object sender ,EventArgs e )
        {
            FormSalesTables from = new FormSalesTables();    
            //from.signOfOpen = this.Name;        
            StartPosition = System . Windows . Forms . FormStartPosition . CenterParent;
            if ( from . ShowDialog ( ) != System . Windows . Forms . DialogResult . OK )
                return ;
            txtCodeOdd . Text = string . Empty;
            txtCodeOdd . Text = from.fish.code;
            txtcontactsunit.Text = from.fish.demand;
            txtcontactsunit.Tag = from.fish.demandId;
            txtNumbering.Text = from.fish.Numbering;
            txtFishMealId.Text = from.fish.Product_id;
            cmbCountry.Text = from.fish.Country;
            cmbBrands.Text = from.fish.pp;
        }

        private void txtlistname_Click(object sender, EventArgs e)
        {
            FormSetPresaleRequisiton from = new FormSetPresaleRequisiton("鱼粉查询");
            DialogResult result = from.ShowDialog();
            if (result == DialogResult.OK) { 
                txtlistname.Text = from.getPerson.billofgoods;
                txtferryname.Text = from.getPerson.shipno;
                txtwarehouse.Text = from.getPerson.warehouse;
                txtcornerno.Text = from.getPerson.cornerno;
            }
        }
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
    }
}
