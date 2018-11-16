using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormLinkman : FormMenuBase
    {
        private FishBll.Bll.CustomerBll _bll = new FishBll.Bll.CustomerBll();
        private FishEntity.CustomerEntity _customer = null;
        private string _where = string.Empty;
        private string _orderBy = " order by id asc limit 1";
        private string _rolewhere = string.Empty;
        private UIForms.FormCustomerCondition _queryForm = null;
  
        public FishEntity.CustomerEntity Customer
        {
            get
            {
                return _customer;
            }
        }
        
        public FormLinkman()
        {
            InitializeComponent();
            this.panel1.Enabled = false;
            pictureBox1.Image =  Utility.ImageUtil.GetImage("DefaultHead.gif");
        }

        protected void AddMenuItem()
        {
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
        }

        public override void Next()
        {             
            QueryOne(" > ", " order by id asc limit 1");
        }

        public override void Previous()
        {
            QueryOne(" < ", " order by id desc limit 1");

        }

        protected void QueryOne( string operate , string orderBy)
        {
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if (_customer != null)
            {
                whereEx  += " and code " + operate + _customer.code;
            }

            List<FishEntity.CustomerEntityVo> list = _bll.GetModelListVo(whereEx + _rolewhere + orderBy );
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }
            this.panel1.Enabled = true;
            _customer = list[0];

            SetCustomer();
        }

        public void SetCustomer(FishEntity.CustomerEntity entity)
        {
            _customer = entity;
            SetCustomer();
        }

        protected void SetCustomer()
        {
            txtCode.Text = _customer.code;
            txtName.Text = _customer.name;
            dtpCurrentDate.Value = _customer.currentlinkDate.Value;
            txtTelephone.Text = _customer.telephone;
            txtPhone1.Text = _customer.phone1;
            txtPhone2.Text = _customer.phone2;
            txtPhone3.Text = _customer.phone3;
            txtPost.Text = _customer.post;
            txtdepartment1.Text = Customer.Department1;
            txtEmail.Text = _customer.email;
            txtQQ.Text = _customer.qq;
            cmbValidate.Text = _customer.validate == 1 ? "有效" : "无效";
            txtWeixin.Text = _customer.weixin;
            txtRemark.Text = _customer.remark;
            if (_customer.nextlinkdate != null)
            {
                txtNextLinkDate.Text = _customer.nextlinkdate.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                txtNextLinkDate.Text = string.Empty;
            }
            FishBll.Bll.CompanyBll bll = new FishBll.Bll.CompanyBll();
            if (string.IsNullOrEmpty(_customer.company) == false)
            {
                FishEntity.CompanyEntity company = bll.GetModelByCode(_customer.company);
                if (company != null)
                {
                    _customer.companyId = company.id;
                    txtCompany.Text = company.fullname;
                    txtCompany.Tag = company;
                    txtCompanyCode.Text = company.code;
                }
            }
            else
            {
                txtCompany.Tag = null;
                txtCompany.Text = string.Empty;
                txtCompanyCode.Text = string.Empty;
            }

            txtHomeAddress.Text = _customer.homeaddress;
            txtOfficeAddress.Text = _customer.officeaddress;
            rdbMan.Checked = _customer.sex.Equals("男");
            rdbWoman.Checked = _customer.sex.Equals("女");

            pictureBox1.Image = GetHeadPicture(_customer.id);

            txtfox.Text = _customer.fox;
        }

        /// <summary>
        /// 获得头像
        /// </summary>
        /// <param name="recordid"></param>
        /// <returns></returns>
        protected Image GetHeadPicture(int recordid )
        {
            if (recordid  < 1)
            {
                return Utility.ImageUtil.GetImage("DefaultHead.gif");
            }

            FishBll.Bll.ImageBll imagebll = new FishBll.Bll.ImageBll();
            string where="recordid=" + recordid + " and type="+ (int) FishEntity.ImageTypeEnum.Header;
           List<FishEntity.ImageEntity> list=   imagebll.GetModelList(where);
           if (list == null || list.Count < 1)
           {
               return Utility.ImageUtil.GetImage("DefaultHead.gif");
           }

           Image tempImage = Image.FromStream(new MemoryStream(list[0].image));
           return tempImage;
        }
      
        protected bool Check()
        {
            errorProvider1.Clear();
            bool isOk = true;
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name) == true )
            {
                errorProvider1.SetError(txtName, "请输入姓名!");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtCompanyCode.Text) == true)
            {
                errorProvider1.SetError(txtCompany, "请选择往来单位。");
                isOk = false;
            }                

            return isOk;
        }

        public override int Add()
        {
            panel1.Enabled = true;
            errorProvider1.Clear();
            _customer = null;

            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiModify.Visible = false;
            tmiAdd.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;

            txtCode.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtCompanyCode.Text = string.Empty;
            txtCompanyCode.Tag = string.Empty;
            //txtCurrentLinkDate.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNextLinkDate.Text = string.Empty;
            txtPhone1.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtPhone3.Text = string.Empty;
            txtPost.Text = string.Empty;
            txtdepartment1.Text = string.Empty;
            txtQQ.Text = string.Empty;
            txtRemark.Text = string.Empty;
            txtTelephone.Text = string.Empty;
            txtWeixin.Text = string.Empty;
            cmbValidate.Text = "有效";
            txtHomeAddress.Text = string.Empty;
            txtOfficeAddress.Text = string.Empty;
            rdbMan.Checked = true;
            
            pictureBox1.Image = Utility.ImageUtil.GetImage("DefaultHead.gif");

            txtfox.Text = string.Empty;

            return 1;
        }
            
        public override void Save()
        {
            if (Check() == false) return ;
            _customer = new FishEntity.CustomerEntity();
            _customer.code = FishBll.Bll.SequenceUtil.GetCustomerSequence();
            int companyId = 0;
            if (string.IsNullOrEmpty(txtCompany.Text) == false && txtCompany.Tag != null && txtCompany.Tag is FishEntity.CompanyEntity)
            {
                FishEntity.CompanyEntity company = txtCompany.Tag as FishEntity.CompanyEntity;
                _customer.company = company.code;
                companyId = company.id;
                _customer.companyId = company.id;
            }
            _customer.createman = FishEntity.Variable.User.username;
            _customer.createtime = DateTime.Now;
            _customer.currentlinkDate = dtpCurrentDate.Value;
            _customer.department = string.Empty;
            _customer.email = txtEmail.Text;
            _customer.isdelete = 0;
            _customer.modifyman = _customer.createman;
            _customer.modifytime = _customer.createtime;
            _customer.name = txtName.Text;

            DateTime nextlinkdate;
            if (DateTime.TryParse(txtNextLinkDate.Text, out nextlinkdate))
            {
                _customer.nextlinkdate = DateTime.Parse(txtNextLinkDate.Text);
            }
            else
            {
                _customer.nextlinkdate = null;
            }

            _customer.phone1 = txtPhone1.Text;
            _customer.phone2 = txtPhone2.Text;
            _customer.phone3 = txtPhone3.Text;
            _customer.post = txtPost.Text;
            _customer.Department1 = txtdepartment1.Text;
            _customer.qq = txtQQ.Text;
            _customer.remark = txtRemark.Text;
            _customer.telephone = txtTelephone.Text;
            _customer.validate = cmbValidate.Text.Equals("有效") ? 1 : 0;
            _customer.weixin = txtWeixin.Text;

            _customer.homeaddress = txtHomeAddress.Text.Trim();
            _customer.officeaddress = txtOfficeAddress.Text.Trim();
            _customer.sex = rdbMan.Checked?"男":"女";
            _customer.fox = txtfox.Text.Trim();

            FishBll.Bll.CustomerBll bll = new FishBll.Bll.CustomerBll();

            bool isok = bll.Exists(_customer.code);
            while (isok)
            {
                _customer.code = FishBll.Bll.SequenceUtil.GetCustomerSequence();
                isok = bll.Exists(_customer.code);
            }

            bool isExistName = bll.ExistsName(_customer.name);
            if (isExistName)
            {
                MessageBox.Show("数据库中存在相同的联系人名称。");
            }

            int id = bll.Add(_customer);
            if (id > 0)
            {
                _customer.id = id;
                txtCode.Text = _customer.code;

                FishBll.Bll.CustomerOfCompanyBll ccbll = new FishBll.Bll.CustomerOfCompanyBll();
                if (false == string.IsNullOrEmpty(_customer.company))
                {
                    FishEntity.CustomerOfCompanyEntity ccEntity = new FishEntity.CustomerOfCompanyEntity();
                    ccEntity.companyid = companyId;
                    ccEntity.customerid = _customer.id;
                    ccbll.Add(ccEntity);
                }

                SaveHeaderPicture(id);

                tmiAdd.Visible = true;
                tmiModify.Visible = true;
                tmiQuery.Visible = true;
                tmiPrevious.Visible = true;
                tmiNext.Visible = true;
                tmiSave.Visible = false;
                tmiCancel.Visible = false;

                MessageBox.Show("添加成功。");
            }
            else
            {
                txtCode.Text = string.Empty;
                MessageBox.Show("添加失败。");
            }
        }

        protected void SaveHeaderPicture( int recordid )
        {
            FishEntity.ImageEntity entity = new FishEntity.ImageEntity();
            entity.createman = FishEntity.Variable.User.username;
            entity.createtime = DateTime.Now;
            entity.recordid = recordid;
            entity.type = (int)FishEntity.ImageTypeEnum.Header;

            string format = "";
            
            entity.extension = format;
            entity.sort = 1;
            entity.title = "头像";

            
            FishBll.Bll.ImageBll imageBll = new FishBll.Bll.ImageBll();
            string where = "recordid="+ recordid+" and type="+ (int) FishEntity.ImageTypeEnum.Header;
            List<FishEntity.ImageEntity> list= imageBll.GetModelList(where);
            if (list == null || list.Count < 1)
            {
                entity.image = CloneImage(); //Utility.ImageUtil.ImageToBytes(pictureBox1.Image.Clone() as Image , ref format);
                imageBll.Add(entity);
            }
            else
            {
                entity = list[0];
                entity.image = CloneImage(); //Utility.ImageUtil.ImageToBytes( pictureBox1.Image.Clone() as Image , ref format );
                entity.extension = format;
                entity.createtime = DateTime.Now;
                imageBll.Update(entity);
            }
        }

        protected byte[] CloneImage()
        {
            byte[] buffer = null;
            if (pictureBox1.Image != null)
            {
                using (MemoryStream mem = new MemoryStream())
                {
                    //克隆Bitmap对象
                    Bitmap bmp = new Bitmap(pictureBox1.Image);
                    bmp.Save(mem, pictureBox1.Image.RawFormat);
                    buffer = mem.ToArray();
                    bmp.Dispose();
                }
            }
            return buffer;
        }

        public override void Cancel()
        {
            errorProvider1.Clear();
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiPrevious.Visible = true;
            tmiNext.Visible = true;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
        }

        public override int Modify()
        {         
            if (Check() == false) return 0;

            int sourceCompanyId = _customer.companyId;

            _customer.code = txtCode.Text;
            int companyId = 0;
            if (string.IsNullOrEmpty(txtCompany.Text) == false && txtCompany.Tag !=null && txtCompany.Tag is FishEntity.CompanyEntity )
            {
                FishEntity.CompanyEntity company = txtCompany.Tag as FishEntity.CompanyEntity;
                _customer.company = company.code;
                companyId = company.id;
                _customer.companyId = company.id;
            }
            else
            {
                _customer.companyId = 0;
                _customer.company = string.Empty;                
            }

            _customer.currentlinkDate = dtpCurrentDate.Value;
            _customer.department = string.Empty;
            _customer.email = txtEmail.Text;
            _customer.modifyman = FishEntity.Variable.User.username;
            _customer.modifytime = DateTime.Now;
            _customer.name = txtName.Text;
            _customer.phone1 = txtPhone1.Text;
            _customer.phone2 = txtPhone2.Text;
            _customer.phone3 = txtPhone3.Text;
            _customer.post = txtPost.Text;
            _customer.Department1 = txtdepartment1.Text;
            _customer.qq = txtQQ.Text;
            _customer.remark = txtRemark.Text;
            _customer.telephone = txtTelephone.Text;
            _customer.validate = cmbValidate.Text.Equals("有效")?1:0;
            _customer.weixin = txtWeixin.Text;

            _customer.homeaddress = txtHomeAddress.Text.Trim();
            _customer.officeaddress = txtOfficeAddress.Text.Trim();
            _customer.sex = rdbMan.Checked?"男":"女";
            _customer.fox = txtfox.Text.Trim();

            DateTime nextlinkDate;
            if (DateTime.TryParse(txtNextLinkDate.Text, out nextlinkDate))
            {
                _customer.nextlinkdate = nextlinkDate;     
            }
            else
            {
                _customer.nextlinkdate = null;
            }

            FishBll.Bll.CustomerBll bll = new FishBll.Bll.CustomerBll();
           bool isOk =  bll.Update(_customer);

           if (isOk)
           {
               FishBll.Bll.CustomerOfCompanyBll ccBll = new FishBll.Bll.CustomerOfCompanyBll();
               if (_customer.companyId == 0 && sourceCompanyId > 0)
               {
                   ccBll.Delete(sourceCompanyId, _customer.id);
               }
               else if (_customer.companyId > 0 && sourceCompanyId == 0)
               {
                   FishEntity.CustomerOfCompanyEntity ccEntity = new FishEntity.CustomerOfCompanyEntity();
                   ccEntity.companyid = _customer.companyId;
                   ccEntity.customerid = _customer.id;
                   ccBll.Add(ccEntity);
               }
               else if (_customer.companyId > 0 && sourceCompanyId > 0)
               {
                   ccBll.Update(sourceCompanyId, _customer.id, _customer.companyId, _customer.id);
               }

               SaveHeaderPicture(_customer.id);

               MessageBox.Show("修改成功。");
           }
           else
           {
               MessageBox.Show("修改失败。");
           }

            return 1;
        }

        public override int Query()
        {
            if (_queryForm == null)
            {
                _queryForm = new UIForms.FormCustomerCondition();
                _queryForm.StartPosition = FormStartPosition.CenterParent;
                _queryForm.ShowInTaskbar = false;
            }
            if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            panel1.Enabled = true;
            _where = _queryForm.GetWhereCondition; //GetQueryCondition();
            //FishBll.Bll.CustomerBll bll = new FishBll.Bll.CustomerBll();
            List<FishEntity.CustomerEntityVo> list = _bll.GetModelListVo(_where + _rolewhere +  _orderBy );
            if (list == null || list.Count < 1)
            {
                _customer = null;
                return 1;
            }
            else
            {
                _customer = list[0];
                SetCustomer();
            }

            return 1;
        }

        protected string GetQueryCondition()
        {
            string where = "1=1";
            if (string.IsNullOrEmpty(txtName.Text) == false)
            {
                where += string.Format( " and name like '%{0}%'", txtName.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtTelephone.Text ) == false)
            {
                where += string.Format(" and telephone like'%{0}%'", txtTelephone.Text.Trim() );
            }
            if (string.IsNullOrEmpty(txtQQ.Text) == false)
            {
                where += string.Format(" and qq like '%{0}%'", txtQQ.Text.Trim() );
            }
            if (string.IsNullOrEmpty(txtWeixin.Text) == false)
            {
                where += string.Format(" and weixin like '%{0}%'", txtWeixin.Text.Trim () );
            }

            //where += string.Format(" limit 1 order by id asc");

            return where;
        }
        
        private void FormLinkman_Load(object sender, EventArgs e)
        {
            AddMenuItem();

            cmbValidate.Text = "有效";

            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere = string.Format(" and salesmancode='{0}' ", FishEntity.Variable.User.id);
            }
            else
            {
                _rolewhere = string.Empty;
            }
        }

        private void txtCompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtCompany.Text = form.SelectCompany.fullname;
            txtCompany.Tag = form.SelectCompany;
            txtCompanyCode.Text = form.SelectCompany.code;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            txtCompany.Text = string.Empty;
            txtCompany.Tag = null;
            txtCompanyCode.Text = string.Empty;
        }

        /// <summary>
        /// 检测 图片文件大小 是否超过最大值，如果超过，则压缩图片大小，
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        protected static string ZoomImage(string path)
        {
            if (Utility.ImageZoomByQuality.JudgeImageSize(path, 1) == false) return path;

            Image sourceImage = Image.FromFile(path);
            string resultPath = Application.StartupPath + "\\Temp\\" + Guid.NewGuid().ToString() + ".jpg";
            int quality = 60;
            Utility.ImageZoomByQuality.Zoom(sourceImage, resultPath, quality, "image/jpeg");
            while (Utility.ImageZoomByQuality.JudgeImageSize(resultPath, 1) == true)
            {
                quality -= 10;
                if (quality < 0) quality = 0;
                Utility.ImageZoomByQuality.Zoom(sourceImage, resultPath, quality, "image/jpeg");
                if (quality <= 0) break;
            }
            sourceImage.Dispose();
            return resultPath;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.Filter = "图片文件|*.bmp;*.jpg;*.png;*.jpeg|*.bmp|*.bmp|*.png|*.png|*.jpg|*.jpg|*.jpeg|*jpeg";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = ZoomImage(dlg.FileName);

                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {          
                    pictureBox1.Image = Image.FromStream(fs);
                    fs.Close();
                }
            } 
        }
    }
}
