using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormOnepound : FormMenuBase
    {
        /// <summary>
        /// 流程状态表刷新
        /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        private FishBll.Bll.OnepoundBll _bll = new FishBll.Bll.OnepoundBll();
        FormImage formbangdan = null;
        FishEntity.OnepoundEntity _fish = null;
        private UIForms.FormOnepoundCondition _queryForm = null;
        private string _where = string.Empty;
        string _orderBy = " order by id asc limit 1";//limit 1
        private string _rolewhere = string.Empty;
        string getname = string.Empty;
        FishEntity.SalesRequisitionEntity model = null;
        bool isOk = false;
        bool getnum = false;
        public FormOnepound()
        {
            InitializeComponent();
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbName, FishEntity.Constant.Brand, true);
            BindCountryBrandData();
            InitDataUtil.BindComboBoxData(cmbspecies, FishEntity.Constant.Goods, true);
            this.panel1.Enabled = false;
            tmiReview.Visible = true;
        }
        public FormOnepound(string name,bool num)
        {
            InitializeComponent();
            getname = name;
            getnum = num;

            tmiReview.Visible = true;
            cmbCountry.SelectedValueChanged -= cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            cmbCountry.SelectedValueChanged += cmbCountry_SelectedValueChanged;
            InitDataUtil.BindComboBoxData(cmbName, FishEntity.Constant.Brand, true);

            BindCountryBrandData();
            InitDataUtil.BindComboBoxData(cmbspecies, FishEntity.Constant.Goods, true);
            this.panel1.Enabled = false;
        }
        public override void Review()
        {
            Review(this.Name, txtNumbering.Text, txtCode.Text);

            //if (txtNumbering.Text != "")
            //{
            //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //    _Refreshbll.GetFormOnepound(txtNumbering.Text);
            //}
            base.Review();
        }
        private void FormOnepound_Load(object sender, EventArgs e)
        {
            MenuCode = "M402"; ControlButtomRoles();
            if (Megres.oddNum != null && Megres.oddNum != "")
            {
                _rolewhere = " and code='" + Megres.oddNum + "'";
                getname = Megres.oddNum;
                List<FishEntity.OnepoundEntityVo> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
                Megres.oddNum = string.Empty;
                if (list == null || list.Count < 1)
                {
                    _fish = null;
                }
                else
                {
                    _fish = list[0];
                    SetOnepound();
                    this.panel1.Enabled = true;
                    menuStrip1.Visible = true;
                    tmiQuery.Visible = true;
                    tmiPrevious.Visible = false;
                    tmiExport.Visible = false;
                    tmiReview.Visible = false;
                    tmiAdd.Visible = true;
                    tmiModify.Visible = true;
                    tmiDelete.Visible = false;
                    tmiClose.Visible = true;
                    tmiCancel.Visible = false;
                    tmiSave.Visible = false;
                    tmiNext.Visible = false;
                    tmiprint.Visible = false;
                }
            }
        }

        public override int Query()
        {
            panel1.Enabled = true;
            if (_queryForm == null)
            {
                _queryForm = new UIForms.FormOnepoundCondition();
                _queryForm.StartPosition = FormStartPosition.CenterParent;
                _queryForm.ShowInTaskbar = false;
            }
            if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where = _queryForm.GetWhereCondition;
            List<FishEntity.OnepoundEntityVo> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
            if (list == null || list.Count < 1)
            {
                _fish = null;
                MessageBox.Show("查无数据！");
                return 1;
            }
            else
            {
                _fish = list[0];
                SetOnepound();
                return 1;

            }
            //return base.Query();
        }

        protected void SetOnepound()
        {
            txtCode.Text = _fish.Code.ToString();
            dtpfactureDate.Value = _fish.Dateofmanufacture.Value;
            dtpfactoryDate.Value = _fish.IntothefactoryDate.Value;
            txtCarnumber.Text = _fish.Carnumber.ToString();
            txtGrossweight.Text = _fish.Grossweight.ToString();
            txtTareweight.Text = _fish.Tareweight.ToString();
            txtCompetition.Text = _fish.Competition.ToString();
            txtTiDanCode.Text = _fish.TiDanCode.ToString();
            txtRedemptionWeight.Text = _fish.RedemptionWeight.ToString();
            cmbspecies.SelectedValue = _fish.Goods;
            txtRemarks.Text = _fish.Remarks;
            txtshipno.Text = _fish.Shipno;
            txtOwner.Text = _fish.Owner;
            txtOwner.Tag = _fish.OwnerId;
            txtAddress.Text = _fish.Address;
            Serialnumber.Text = _fish.Serialnumber;
            txtFishMealId.Text = _fish.FishMealId;
            Buyers.Text = _fish.Buyers;
            Buyers.Tag = _fish.BuyersId;
            Quantity.Text = _fish.Quantity;
            Sellers.Text = _fish.Sellers;
            Sellers.Tag = _fish.SellersId;
            BillOfLadingid.Text = _fish.BillOfLadingid;
            Pileangle.Text = _fish.Pileangle;
            cmbCountry.SelectedValue = _fish.Country;
            cmbName.SelectedValue = _fish.PName;
            txtSpecification.Text = _fish.Qualit;
            txtCodeOdd.Text = _fish.codeContract;
            txtNumbering.Text = _fish.Numbering;
            txtcreateman.Text = _fish.Createman;
            txtmodifyman.Text = _fish.Modifyman;
            imgae(_fish.Id);
        }
        public void imgae(int id) {
            if (id < 0) return ;
            FishBll.Bll.OnepoundBll bll = new FishBll.Bll.OnepoundBll();
            bool isok = bll.image_Exists(" recordid = " + id + " and type = 5");
            if (isok == true)
            {
                btnbangdan.ForeColor = Color.Red;
            }
            else
            {
                btnbangdan.ForeColor = Color.Black;
            }
        }
        private void btnbangdan_Click(object sender, EventArgs e)
        {
            if (formbangdan == null)
            {
                formbangdan = new FormImage(0, FishEntity.ImageTypeEnum.Onepoundcode);
            }

            formbangdan.SetData(_fish == null ? 0 : _fish.Id, FishEntity.ImageTypeEnum.Onepoundcode);

            formbangdan.StartPosition = FormStartPosition.CenterParent;
            if (formbangdan.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

            }
        }
        private void LoadImage()
        {
            btnbangdan.DrawType = UILibrary.DrawStyle.Img;

            string imagePath = Application.StartupPath + "\\Images\\blue_button_normal.png";
            if (File.Exists(imagePath))
            {
                btnbangdan.NormlBack = Image.FromFile(imagePath);
            }
            string downPath = Application.StartupPath + "\\Images\\blue_button_down.png";
            if (File.Exists(downPath))
            {
                btnbangdan.DownBack = Image.FromFile(downPath);
            }
            string hoverPath = Application.StartupPath + "\\Images\\blue_button_hover.png";
            if (File.Exists(hoverPath))
            {
                btnbangdan.MouseBack = Image.FromFile(hoverPath);
                btnbangdan.MouseBack = Image.FromFile(hoverPath);

            }
        }
        //protected byte[] CloneImage()
        //{
        //    byte[] buffer = null;
        //    if (formbangdan.Image != null)
        //    {
        //        using (MemoryStream mem = new MemoryStream())
        //        {
        //            克隆Bitmap对象
        //            Bitmap bmp = new Bitmap(formbangdan.Image);
        //            bmp.Save(mem, formbangdan.Image.RawFormat);
        //            buffer = mem.ToArray();
        //            bmp.Dispose();
        //        }
        //    }
        //    return buffer;
        //}
        public List<FishEntity.ImageEntity> GetSGSImages()
        {
            if (formbangdan == null) return null;
            List<FishEntity.ImageEntity> images = new List<FishEntity.ImageEntity>();

            if (formbangdan.Image1 != null && formbangdan.Image1.image != null) images.Add(formbangdan.Image1);
            if (formbangdan.Image2 != null && formbangdan.Image2.image != null) images.Add(formbangdan.Image2);
            if (formbangdan.Image3 != null && formbangdan.Image3.image != null) images.Add(formbangdan.Image3);

            return images;
        }
        public override int Add()
        {

            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiReview.Visible = false;
            tmiAdd.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            cmbspecies.SelectedValue = string.Empty;
            txtRemarks.Text = string.Empty;
            txtshipno.Text = string.Empty;
            txtCode.Text = string.Empty;
            dtpfactureDate.Value = DateTime.Now;//出
            dtpfactoryDate.Value = DateTime.Now;
            txtCarnumber.Text = string.Empty;
            txtGrossweight.Text = string.Empty;
            txtTareweight.Text = string.Empty;
            txtCompetition.Text = string.Empty;
            txtTiDanCode.Text = string.Empty;
            txtRedemptionWeight.Text = string.Empty;
            txtOwner.Text = string.Empty;
            txtAddress.Text = string.Empty;
            Serialnumber.Text = string.Empty;
            txtFishMealId.Text = string.Empty;
            cmbCountry.SelectedValue = string.Empty;
            cmbName.SelectedValue = string.Empty;
            txtSpecification.Text = string.Empty;
            Buyers.Text = string.Empty;
            Sellers.Text = string.Empty;
            txtOwner.Tag = string.Empty;
            Buyers.Tag = string.Empty;
            Sellers.Tag = string.Empty;
            Quantity.Text = string.Empty;
            Pileangle.Text = string.Empty;
            BillOfLadingid.Text = string.Empty;
            txtCodeOdd.Text = string.Empty;
            if (getname != "")
            {
                if (getnum == false)
                {
                    model = _bll.getBT(getname);//磅单
                }
                else if(getnum==true)
                {
                    model = _bll.getCKD(getname);//出库单
                }
                if (model != null)
                {
                    txtNumbering.Text = model.Numbering;
                    txtCodeOdd.Text = model.code;
                    Buyers.Text = model.Purchasingunits;
                    Buyers.Tag = model.PurchasingunitsId;
                    Sellers.Text = model.demand;
                    Sellers.Tag = model.demandId;
                    BillOfLadingid.Text = model.tdh;
                    Pileangle.Text = model.zjh;
                    txtshipno.Text = model.cm;
                    //cmbspecies.SelectedValue = model.Goods;
                    cmbCountry.SelectedValue = model.Country;
                    cmbName.SelectedValue = model.pp;
                    txtFishMealId.Text = model.Product_id;
                    txtSpecification.Text = model.Pinzhi;
                    Quantity.Text = model.baoshu;
                }
                else
                {
                    tmiReview.Visible = false;
                    tmiAdd.Visible = false;
                    tmiSave.Visible = false;
                    tmiCancel.Visible = false;
                }
            }
            panel1.Enabled = true;
            return 1;
        }
        public override void 
            Save()
        {
            FishEntity.OnepoundEntity _fish = new FishEntity.OnepoundEntity();
            _fish.Buyers = Buyers.Text;
            if (string.IsNullOrEmpty(Sellers.Text) == false)
            {
                FishEntity.CompanyEntity company = Sellers.Tag as FishEntity.CompanyEntity;
                _fish.Sellers = Sellers.Text.ToString();
            }
            else
            {

                MessageBox.Show("请选择销售商。");
                return;
            }
            if (string.IsNullOrEmpty(txtCodeOdd.Text))
            {
                MessageBox.Show("请选择销售合同号");
                return;
            }
            if (GetValue() == false)
            {
                return;
            }
            decimal temp = 0;
            _fish.Code = FishBll.Bll.SequenceUtil.GerLadingNumber();
            _fish.OwnerId = txtOwner.Tag.ToString();
            _fish.BuyersId = Buyers.Tag.ToString();
            _fish.SellersId = Sellers.Tag.ToString();
            _fish.Dateofmanufacture = dtpfactureDate.Value;
            _fish.IntothefactoryDate = dtpfactoryDate.Value;
            _fish.Carnumber = txtCarnumber.Text.Trim();
            _fish.Goods = cmbspecies.SelectedValue == null ? string.Empty : cmbspecies.SelectedValue.ToString();
            _fish.Remarks = txtRemarks.Text;
            _fish.Shipno = txtshipno.Text;
            _fish.Grossweight = txtGrossweight.Text;
            _fish.Tareweight = txtTareweight.Text;
            _fish.Competition = txtCompetition.Text;
            _fish.TiDanCode = txtTiDanCode.Text;

            decimal.TryParse(txtRedemptionWeight.Text, out temp);
            _fish.RedemptionWeight = temp;

            _fish.Owner = txtOwner.Text.Trim();
            _fish.Quantity = Quantity.Text.Trim();
            _fish.Pileangle = Pileangle.Text.Trim();
            _fish.BillOfLadingid = BillOfLadingid.Text.Trim();
            _fish.PName = cmbName.SelectedValue == null ? string.Empty : cmbName.SelectedValue.ToString();
            _fish.Country = cmbCountry.SelectedValue == null ? string.Empty : cmbCountry.SelectedValue.ToString();
            _fish.Qualit = txtSpecification.Text;
            _fish.Serialnumber = Serialnumber.Text.Trim();
            _fish.FishMealId = txtFishMealId.Text.Trim();
            _fish.Address = txtAddress.Text.Trim();
            _fish.Createtime = DateTime.Now;
            _fish.Createman = FishEntity.Variable.User.username;
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = _fish.Createman;
            _fish.codeContract = txtCodeOdd.Text;
            _fish.Numbering = txtNumbering.Text;

            FishBll.Bll.OnepoundBll bll = new FishBll.Bll.OnepoundBll();

            bool isok = bll.Exists(_fish.Code);
            while (isok)
            {
                _fish.Code = FishBll.Bll.SequenceUtil.GerLadingNumber();
                isok = bll.Exists(_fish.Code);
            }
            int id = bll . Add ( _fish ,this . Name );
            if (id > 0)
            {
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormOnepound(txtNumbering.Text);
                //}
                _fish.Id = id;
                AddImages(_fish);
                imgae(_fish.Id);
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiReview.Visible = false;
                tmiAdd.Visible = true;
                tmiSave.Visible = false;
                tmiCancel.Visible = true;
                MessageBox.Show("添加成功。");
                txtCode.Text = _fish.Code.ToString();
            }
            else
            {
                // txtCode.Text = _fish.Code;
                MessageBox.Show("添加失败。");
            }
        }
        public override int Modify()
        {
            if (GetValue() == false)
            {
                return 0;
            }
            if (txtCode == null && txtCode.Text == "")
            {
                MessageBox.Show("请查询需要修改的磅单。");
                return 0;
            }
            if (string.IsNullOrEmpty(txtCodeOdd.Text))
            {
                MessageBox.Show("请选择销售合同号");
                return 0;
            }
            _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //if (_Refreshbll.ExistsNumbering(txtNumbering.Text, "bdExBool") == true)
            //{
            //    MessageBox.Show("已审核无法操作！");
            //    return 0;
            //}
            decimal temp = 0;
            _fish.Buyers = Buyers.Text.ToString();
            _fish.OwnerId = txtOwner.Tag.ToString();
            _fish.BuyersId = Buyers.Tag.ToString();
            _fish.SellersId = Sellers.Tag.ToString();
            _fish.Sellers = Sellers.Text;
            _fish.Code = txtCode.Text;
            _fish.Dateofmanufacture = dtpfactureDate.Value;//chu
            _fish.IntothefactoryDate = dtpfactoryDate.Value;
            _fish.Carnumber = txtCarnumber.Text.Trim();
            _fish.Grossweight = txtGrossweight.Text;
            _fish.Tareweight = txtTareweight.Text;
            _fish.Competition = txtCompetition.Text;
            _fish.TiDanCode = txtTiDanCode.Text;
            decimal.TryParse(txtRedemptionWeight.Text, out temp);
            _fish.RedemptionWeight = temp;
            _fish.Goods = cmbspecies.SelectedValue == null ? string.Empty : cmbspecies.SelectedValue.ToString();
            _fish.Remarks = txtRemarks.Text;
            _fish.Shipno = txtshipno.Text;
            _fish.Owner = txtOwner.Text.Trim();
            _fish.Address = txtAddress.Text.Trim();
            _fish.Modifytime = DateTime.Now;
            _fish.Modifyman = FishEntity.Variable.User.username;
            _fish.Quantity = Quantity.Text.Trim();
            _fish.Pileangle = Pileangle.Text.Trim();
            _fish.BillOfLadingid = BillOfLadingid.Text.Trim();
            _fish.PName = cmbName.SelectedValue == null ? string.Empty : cmbName.SelectedValue.ToString();
            _fish.Country = cmbCountry.SelectedValue == null ? string.Empty : cmbCountry.SelectedValue.ToString();
            _fish.Qualit = txtSpecification.Text;
            _fish.Serialnumber = Serialnumber.Text.Trim();
            _fish.FishMealId = txtFishMealId.Text.Trim();
            _fish.codeContract = txtCodeOdd.Text;
            FishBll.Bll.OnepoundBll bll = new FishBll.Bll.OnepoundBll();
            if (bll.ExistsUpdate(_fish.Code, FishEntity.Variable.User.username) != true)
            {
                MessageBox.Show("不是所属人无法操作！");
                return 0;
            }
            bool isOk = bll.Update(_fish);
            if (isOk)
            {
                AddImages(_fish);
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormOnepound(txtNumbering.Text);
                //}
                MessageBox.Show("修改成功。");
            }
            else
            {
                txtCode.Text = string.Empty;
                MessageBox.Show("修改失败。");
            }
            imgae(_fish.Id);
            return 1;
        }
        protected void AddImages(FishEntity.OnepoundEntity fish)
        {
            if (fish == null) return;

            FishBll.Bll.ImageBll bll = new FishBll.Bll.ImageBll();

            if (fish.Id > 0)
            {
                bll.DeleteByRecordIdAndType(fish.Id, (int)FishEntity.ImageTypeEnum.Onepoundcode);
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
        public override void Cancel()
        {
            tmiReview.Visible = false;
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            panel1.Enabled = true;
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

            cmbName.DisplayMember = "name";
            cmbName.ValueMember = "code";
            cmbName.DataSource = list;
        }

        private void Buyers_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            Buyers.Text = form.SelectCompany.fullname;
            Buyers.Tag = form.SelectCompany;
        }

        private void Sellers_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            Sellers.Text = form.SelectCompany.fullname;
            Sellers.Tag = form.SelectCompany;
        }

        //获取现货销售单号
        private void txtCodeOdd_Click(object sender, EventArgs e)
        {
            FormSalesTables from = new FormSalesTables();
            from.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            txtCodeOdd.Text = string.Empty;
            txtCodeOdd.Text = from.fish.code;
            Sellers.Text = from.fish.demand;
            Sellers.Tag = from.fish.demandId;
            Buyers.Text = from.fish.Purchasingunits;
            Buyers.Tag = from.fish.PurchasingunitsId;
            txtFishMealId.Text = from.fish.Product_id;
            txtNumbering.Text = from.fish.Numbering;
            cmbCountry.Text = from.fish.Country;
            cmbName.Text=from.fish.pp;
        }
        private void txtOwner_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtOwner.Text = form.SelectCompany.fullname;
            txtOwner.Tag = form.SelectCompany.code;
        }

        private void BillOfLadingid_Click(object sender, EventArgs e)
        {
            //FormBilloftable from = new FormBilloftable();
            //from.StartPosition = FormStartPosition.CenterParent;
            //if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            //if (from.bil == null) return;
            //txtshipno.Text = from.bil.Ferryname;
            //BillOfLadingid.Text = from.bil.Listname;
            //Pileangle.Text = from.bil.Cornerno;
            //txtAddress.Text = from.bil.Warehouse;
            //Sellers.Text = from.bil.Contactsunit;
            //Quantity.Text = from.bil.Packagenumber.ToString();
        }
        bool GetValue() {
            errorProvider1.Clear();
            isOk = true;
            if (string.IsNullOrEmpty(txtNumbering.Text))
            {
                errorProvider1.SetError(txtNumbering, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(Serialnumber.Text))
            {
                errorProvider1.SetError(Serialnumber, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtCarnumber.Text))
            {
                errorProvider1.SetError(txtCarnumber, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtGrossweight.Text))
            {
                errorProvider1.SetError(txtGrossweight, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtTareweight.Text))
            {
                errorProvider1.SetError(txtTareweight, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtCompetition.Text))
            {
                errorProvider1.SetError(txtCompetition, "不可为空");
                isOk = false;
            }
            if (cmbCountry.Text == ""||cmbCountry.Text==null)
            {
                errorProvider1.SetError(cmbCountry, "不可为空");
                isOk = false;
            }
            if (cmbName.Text == "" || cmbName.Text == null)
            {
                errorProvider1.SetError(cmbName, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(Quantity.Text))
            {
                errorProvider1.SetError(Quantity, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtOwner.Text))
            {
                errorProvider1.SetError(txtOwner, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtCodeOdd.Text))
            {
                errorProvider1.SetError(txtCodeOdd, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(dtpfactureDate.Text))
            {
                errorProvider1.SetError(dtpfactureDate, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(Buyers.Text))
            {
                errorProvider1.SetError(Buyers, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtSpecification.Text))
            {
                errorProvider1.SetError(txtSpecification, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(Pileangle.Text))
            {
                errorProvider1.SetError(Pileangle, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtshipno.Text))
            {
                errorProvider1.SetError(txtshipno, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(BillOfLadingid.Text))
            {
                errorProvider1.SetError(BillOfLadingid, "不可为空");
                isOk = false;
            }
            if (!string.IsNullOrEmpty(txtCompetition.Text) && !string.IsNullOrEmpty(txtRedemptionWeight.Text))
            {
                if (decimal.Parse(txtCompetition.Text.ToString()) > decimal.Parse(txtRedemptionWeight.Text.ToString()))
                {
                    errorProvider1.SetError(txtRedemptionWeight, "磅单净重<=赎单重量");
                    isOk = false;
                }
            }
            else
            {
                errorProvider1.SetError(txtRedemptionWeight, "不能为空");
                isOk = false;
            }

            return isOk;
        }

        private void txtTiDanCode_Click(object sender, EventArgs e)
        {
            FormBillofladingTable from = new FormBillofladingTable(txtNumbering.Text);
            from.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            if (from.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            txtTiDanCode.Text = from.getModel.Code;
            txtRedemptionWeight.Text = from.getModel.RedemptionWeight.ToString();
            txtSpecification.Text = from.getModel.Specification.ToString();
            Pileangle.Text = from.getModel.Cornerno.ToString();
            txtshipno.Text = from.getModel.Ferryname.ToString();
            BillOfLadingid.Text = from.getModel.Listname.ToString();
            txtAddress.Text = from.getModel.Warehouse.ToString();
            cmbCountry.Text = from.getModel.Country.ToString();
            cmbName.Text = from.getModel.Brands.ToString();
        }
    }
}
