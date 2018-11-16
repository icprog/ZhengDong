using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCallRecords : FormMenuBase
    {
        FishBll.Bll.CallRecordsBll _bll = new FishBll.Bll.CallRecordsBll();
        private UIForms.FormCallRecordsCondition Call = null;
        FishEntity.CallRecordsEntity _entity = null;
        string _where = string.Empty;
        FishBll.Bll.CallRecordsDetailBll _detailBll = new FishBll.Bll.CallRecordsDetailBll();
        List<FishEntity.CallRecordsDetailEntnty> _detail = null;
        UILibrary.TwoDimenDataGridView dgvUtil = null;
        public event EventHandler RefreshDataEvent = null;
        //private string _orderBy = " order by id asc limit 1";
        string _rolewhere = string.Empty;

        public FormCallRecords()
        {
            InitializeComponent();
            menuStrip1.Items.Remove(tmiprint);
            menuStrip1.Items.Remove(tmiReview);
            ReadColumnConfig(dataGridView1, "Set_CallRecords_1");
            ReadColumnConfig(dataGridView2, "Set_CallRecords_2");
            this.panel1.Enabled = false; 
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere = string.Format(" and createman ='{0}' ", FishEntity.Variable.User.username );
            }
            else
            {
                _rolewhere = string.Empty;
            }

        }

        public FormCallRecords(int companyid , bool isControlRole): this()
        {
            Add();

            this._isControlRole = isControlRole;

            FishBll.Bll.CompanyBll bll = new FishBll.Bll.CompanyBll();
            FishEntity.CompanyEntity model =  bll.GetModel(companyid);
            SetCompanyData(model);
        }
        public FishEntity.CallRecordsEntity GetCallRecordsEntity
        {
            get
            {
                return _entity;
            }
        }
        protected bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;
            if (true == string.IsNullOrEmpty(txtCompanyCode.Text))
            {
                errorProvider1.SetError(txtCompanyName, "请选择客户");
                isok = false;
            }
            if (true == string.IsNullOrEmpty(txtLinkManCode.Text))
            {
                isok = false;
                errorProvider1.SetError(txtLinkMan, "请选择联系人");
                
            }

            decimal temp = 0;
            if (false == string.IsNullOrEmpty(txtWeek.Text))
            {
                if (decimal.TryParse(txtWeek.Text, out temp) == false)
                {
                    errorProvider1.SetError(txtWeek, "请输入正确的数字");
                    isok = false;
                }
            }
            if (false == string.IsNullOrEmpty(txtMonth.Text))
            {
                if (decimal.TryParse(txtMonth.Text, out temp) == false)
                {
                    errorProvider1.SetError(txtMonth, "请输入正确的数字");
                    isok = false;
                }
            }

            if (true  == string.IsNullOrEmpty(txtContent.Text))
            {
                isok = false;
                errorProvider1.SetError(txtContent, "请输入沟通内容");
            }

            return isok;
        }

        public override void Save()
        {
            if (Check() == false) return ;

            _entity = new FishEntity.CallRecordsEntity();
            GetCallRecordFromUI();
            _entity.createman = FishEntity.Variable.User.username;
            _entity.modifyman = _entity.createman;
            _entity.createtime = DateTime.Now;
            _entity.modifytime = _entity.createtime;
            _entity.code = FishBll.Bll.SequenceUtil.GetCallRecordSequence();
            while (_bll.Exists(_entity.code))
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetCallRecordSequence();
            }

            int id = _bll.Add(_entity);

            if (id > 0)
            {
                _entity.id = id;
                txtCode.Text = _entity.code;
                FishBll.Bll.CompanyBll companyBll = new FishBll.Bll.CompanyBll();
                 //更新 往来单位 表的 最近联系时间，下次联系时间
                companyBll.UpdateCompnayLinkDate(_entity.customercode, _entity.weekestimate, _entity.monthestimate, _entity.currentdate.Value, _entity.BuyDate, _entity.nextdate.Value );
                FishBll.Bll.CustomerBll customerBll = new FishBll.Bll.CustomerBll();
                //更新 联系人 表的 当前联系时间，下次联系时间和 通话记录ID字段
                customerBll.UpdateLinkDate(_entity.linkmancode, _entity.currentdate.Value, _entity.id, _entity.nextdate.Value);

                AddDetail(id, true);

                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                //tmiDelete.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiSave.Visible = false;
                //tmiCancel.Visible = false;

                ControlButtomRoles();

                MessageBox.Show("添加成功。");
               
                //System.Diagnostics.Process.Start("FormCallRecordsTable.cs");
                

                if (RefreshDataEvent != null)
                {
                    RefreshDataEvent(this, EventArgs.Empty);
                    
                }
            }
            else
            {
                MessageBox.Show("添加失败。");
            }           
        }

        protected decimal GetDecimal(object temp)
        {
            if ( temp  == null)
            {
                return  0;
            }
            else
            {
                decimal t = 0;
                decimal.TryParse( temp.ToString(), out t);
                return t;
            }
        }

        protected void AddDetail(int callrecordid, bool isAdd)
        {
            dataGridView1.EndEdit();

            List<FishEntity.CallRecordsDetailEntnty> listNews = new List<FishEntity.CallRecordsDetailEntnty>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.CallRecordsDetailEntnty item = new FishEntity.CallRecordsDetailEntnty();
                int id = 0;
                int.TryParse(row.Cells["id"].Value == null ? "0" : row.Cells["id"].Value.ToString(), out id);
                item.id = id;
                int no = 0;
                int.TryParse(row.Cells["no"].Value == null ? "0" : row.Cells["no"].Value.ToString(), out no);
                item.no = no;
          
                item.nature = row.Cells["nature"].Value == null ? string.Empty : row.Cells["nature"].Value.ToString();
                item.brand = row.Cells["brand"].Value == null ? string.Empty : row.Cells["brand"].Value.ToString();
                item.specification = row.Cells["specification"].Value == null ? string.Empty : row.Cells["specification"].Value.ToString();
                item.orderstate = row.Cells["orderstate"].Value == null ? string.Empty : row.Cells["orderstate"].Value.ToString();
                item.callrecordid = callrecordid;
                
                item.domestic_amine = GetDecimal(row.Cells["domestic_amine"].Value);
                item.domestic_aminototal = GetDecimal(row.Cells["domestic_aminototal"].Value);
                item.domestic_fat = GetDecimal(row.Cells["domestic_fat"].Value);
                item.domestic_graypart = GetDecimal(row.Cells["domestic_graypart"].Value);
                item.domestic_lysine = GetDecimal(row.Cells["domestic_lysine"].Value);
                item.domestic_methionine = GetDecimal(row.Cells["domestic_methionine"].Value);
                item.domestic_protein = GetDecimal(row.Cells["domestic_protein"].Value);
                item.domestic_sandsalt = GetDecimal(row.Cells["domestic_sandsalt"].Value);
                item.domestic_sour = GetDecimal(row.Cells["domestic_sour"].Value);
                item.domestic_tvn = GetDecimal(row.Cells["domestic_tvn"].Value);
                item.paymethod = row.Cells["paymethod"].Value == null ? string.Empty : row.Cells["paymethod"].Value.ToString();
                item.payperiod = row.Cells["payperiod"].Value == null ? string.Empty : row.Cells["payperiod"].Value.ToString();
                item.quoteprice = GetDecimal(row.Cells["quoteprice"].Value);
                item.saleprice = GetDecimal(row.Cells["saleprice"].Value);
                item.weight = GetDecimal(row.Cells["weight"].Value);
                
                listNews.Add(item);
            }


            if (isAdd == false)
            {
                List<FishEntity.CallRecordsDetailEntnty> listsource = _detailBll.GetModelList(" callrecordid=" + callrecordid);
                if (listsource != null)
                {
                    foreach (FishEntity.CallRecordsDetailEntnty item in listsource)
                    {
                        bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                        if (isExist == false)
                        {
                            bool isDelete = _detailBll.Delete(item.id);
                        }
                    }
                }
            }

            foreach (FishEntity.CallRecordsDetailEntnty item in listNews)
            {
                if (item.id == 0)
                {
                    int id = _detailBll.Add(item);
                    if (id > 0)
                    {
                        item.id = id;
                    }
                }
                else
                {
                    _detailBll.Update(item);
                }
            }

            _detail = listNews;

            dataGridView1.DataSource = _detail;
        }
        
        public override int Add()
        {
            tmiCancel.Visible = true;
            tmiSave.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiExport.Visible = false;
            panel1.Enabled = true;
            errorProvider1.Clear();
            txtAddress.Text = string.Empty;
            txtCode.Text = string.Empty;
            txtCompanyCode.Text = string.Empty;
            txtCompanyCode.Tag = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtContent.Text = string.Empty;
            txtLevel.Text = string.Empty;
            txtLinkMan.Text = string.Empty;
            txtLinkManCode.Text = string.Empty;
            txtLinkManCode.Tag = string.Empty;
            txtMobile.Text = string.Empty;
            txtMonth.Text = string.Empty;
            txtOfficeTel.Text = string.Empty;
            txtProducts.Text = string.Empty;
            txtQuality.Text = string.Empty;
            txtWeek.Text = string.Empty;
            dtpBuyDate.Value = DateTime.Now;
            dtpCurrentDate.Value = DateTime.Now;
            dtpNextLinkDate.Value = DateTime.Now;

            txtspecifacation.Text = string.Empty;
            txtSaleman.Text = string.Empty;
            txttransportfee.Text = string.Empty;
            txtweight.Text = string.Empty;
            txtCustomerNature.Text = string.Empty;
            txtcompetitors.Text = string.Empty;

            _entity = null;

            InitDetail();
           

            return 1;
        }

        private void InitDetail()
        {
            _detail = new List<FishEntity.CallRecordsDetailEntnty>();
            for (int i = 0; i < 4; i++)
            {
                FishEntity.CallRecordsDetailEntnty item = new FishEntity.CallRecordsDetailEntnty();
                item.no = i + 1;
                item.id = 0;
                item.callrecordid = 0;
                _detail.Add(item);
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _detail;
        }

        public override void Cancel()
        {
            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiDelete.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;

            ControlButtomRoles();

            errorProvider1.Clear();
        }

        private void GetCallRecordFromUI()
        {
            _entity.address = txtAddress.Text.Trim();
            _entity.BuyDate = dtpBuyDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            _entity.communicatecontent = txtContent.Text.Trim();
            _entity.currentdate = dtpCurrentDate.Value;
            _entity.customer = txtCompanyName.Text.Trim();
            _entity.customercode = txtCompanyCode.Text.Trim();
            _entity.customerlevel = txtLevel.Text.Trim();
            _entity.linkman = txtLinkMan.Text.Trim();
            _entity.linkmancode = txtLinkManCode.Text.Trim(); 
            _entity.mobile = txtMobile.Text.Trim();  
            //_entity.createtime = DateTime.Now;
            //_entity.createman = FishEntity.Variable.User.username;
            //_entity.modifyman = FishEntity.Variable.User.username;
            //_entity.modifytime = _entity.createtime;
            if (false == string.IsNullOrEmpty(txtMonth.Text))
            {
                decimal  temp = 0;
                decimal.TryParse(txtMonth.Text, out temp);
                _entity.monthestimate = temp.ToString();
            }
            else
            {
                _entity.monthestimate = string.Empty;
            }
            _entity.nextdate = dtpNextLinkDate.Value;
            _entity.officetel = txtOfficeTel.Text.Trim();
            _entity.products = txtProducts.Text.Trim();
            _entity.requiredquantity = txtQuality.Text.Trim();
            _entity.telephone = string.Empty;
            if (false == string.IsNullOrEmpty(txtWeek.Text))
            {
                decimal temp;
                decimal.TryParse(txtWeek.Text, out temp);
                _entity.weekestimate = temp.ToString();
            }
            else
            {
                _entity.weekestimate = string.Empty;
            }
            _entity.isdelete = 0;   
        }

        private void GetDetailFromUI()
        {

        }

        public override int Modify()
        {
            if ( _entity == null)
            {
                MessageBox.Show("请先查询需要修改的记录。");
                return 0;
            }
            if (Check() == false) return 0; 
            GetCallRecordFromUI(); 
            _entity.modifytime = DateTime.Now;
            _entity.modifyman = FishEntity.Variable.User.username;

            bool isok = _bll.Update(_entity);
            if (isok)
            {
                FishBll.Bll.CompanyBll companyBll = new FishBll.Bll.CompanyBll();
                companyBll.UpdateCompnayLinkDate(_entity.customercode, _entity.weekestimate, _entity.monthestimate, _entity.currentdate.Value, _entity.BuyDate, _entity.nextdate.Value );
                FishBll.Bll.CustomerBll customerBll = new FishBll.Bll.CustomerBll();
                customerBll.UpdateLinkDate(_entity.linkmancode, _entity.currentdate.Value, _entity.id, _entity.nextdate.Value);

                AddDetail(_entity.id, false);

                MessageBox.Show("修改成功。");
              
                if (RefreshDataEvent != null)
                {
                    RefreshDataEvent(this, EventArgs.Empty);
                   
                }

            }
            else
            {
                MessageBox.Show("修改失败。");
            }   
            return 1;
        }

        public override int Delete()
        {
            if (_entity == null) return 0;

            string msg =string.Format( "你确定要删除通话记录编号为【{0}】的记录吗?", _entity.code );
            if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return 0;

            int id = _entity.id;
            bool isok = _bll.Delete(_entity.id);  
            if (isok == false) return 0;

            _detailBll.DeleteByCallRecordId(id);

            Query();

            return 1;
        }

        public override void Previous()
        {
            //MessageBox.Show("1");
            QueryOne(" < ", " order by id desc limit 1");
        }

        public override void Next()
        {//修改后的下一个功能
            QueryOne(">", "  order by CONVERT(customer using gbk) collate gbk_chinese_ci  asc  limit 1");
        }

        protected void QueryOne(string operate, string orderBy)
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

            if ( _entity != null)
            {
                whereEx += " and code " + operate + _entity.code;
            }

            List<FishEntity.CallRecordsEntity> list = _bll.GetModelList(whereEx  + _rolewhere + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了！");
                return;
            }
            panel1.Enabled = true;
            _entity = list[0];
                       
           
            SetCallRecord();

            _detail = _detailBll.GetModelList("callrecordid=" + _entity.id);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _detail;

        }

        public override int Query()
        {
            // _where = "1=1";
            //QueryOne(">", " order by CONVERT(customer using gbk) collate gbk_chinese_ci  asc  limit 1");
            if (Call==null)
            {
                Call = new UIForms.FormCallRecordsCondition();
                Call.StartPosition = FormStartPosition.CenterParent;
                Call.ShowInTaskbar = false;
            }
            if (Call.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = Call.GetWhereCondition;
            List<FishEntity.CallRecordsEntity> list = _bll.GetModelList(_where + _rolewhere);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了！");
                return 1;
            }
            panel1.Enabled = true;
            _entity = list[0];


            SetCallRecord();

            _detail = _detailBll.GetModelList("callrecordid=" + _entity.id);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _detail;
            return 1;
        }

        protected void SetCallRecord()
        {
            if (_entity == null) return;

            txtCode.Text = _entity.code;
            txtAddress.Text = _entity.address;
            txtCompanyCode.Text = _entity.customercode;
            txtCompanyName.Text = _entity.customer;
            txtContent.Text = _entity.communicatecontent;
            txtLevel.Text = _entity.customerlevel;
            txtLinkMan.Text = _entity.linkman;
            txtLinkManCode.Text = _entity.linkmancode;
            txtMobile.Text = _entity.mobile;
            txtMonth.Text = _entity.monthestimate;
            txtOfficeTel.Text = _entity.officetel;
            txtProducts.Text = _entity.products;
            txtQuality.Text = _entity.requiredquantity;
            txtWeek.Text = _entity.weekestimate;

            DateTime temp =DateTime.Now;
            if (_entity.BuyDate != null && string.IsNullOrEmpty(_entity.BuyDate) != false&& _entity.BuyDate.ToString()!="") 
            {
                DateTime.TryParse(_entity.BuyDate, out temp);
            }
            dtpBuyDate.Value = temp;

            if (_entity.currentdate != null)
            {
                dtpCurrentDate.Value = _entity.currentdate.Value;
            }

            if (_entity.nextdate != null)
            {
                dtpNextLinkDate.Value = _entity.nextdate.Value;
            }

            FishBll.Bll.CompanyBll companybll = new FishBll.Bll.CompanyBll();
            FishEntity.CompanyEntity company = companybll.GetModelByCode(_entity.customercode);
            if (company != null)
            {
                string requiredproduct = "";
                FishEntity.DictEntity dic = FishEntity.Variable.DictList.Find ( (i)=>{ return i.pcode == FishEntity.Constant.RequiredProduct  &&i.code == company.requiredproduct;});
               if( dic !=null )  requiredproduct = dic.name;

                txtspecifacation.Text =requiredproduct;
                txtQuality.Text = company.productrequire;
                string products = "";
                dic= FishEntity.Variable.DictList.Find( (i)=>{ return i.pcode==FishEntity.Constant.Products && i.code == company.products;});
                if( dic !=null) products = dic.name;
                txtProducts.Text = products;
                txtcompetitors.Text = company.competitors;
                txttransportfee.Text = company.freight.ToString("f2");
                txtweight.Text = company.tare.ToString("f2");
                txtSaleman.Text = company.salesman;
                string property = "";
                dic = FishEntity.Variable.DictList.Find( (i)=>{ return i.pcode== FishEntity.Constant.CustomerProperty && i.code==company.customerproperty;});
                if( dic !=null) property=dic.name;
                txtCustomerNature.Text = property;

                txtWeek.Text = company.currentweekestimate;
                txtMonth.Text = company.currentmonthestimate;

                dic = FishEntity.Variable.DictList.Find((i) => { return i.pcode == FishEntity.Constant.GeneralLevel && i.code == company.generallevel; });
                if (dic != null) txtLevel.Text = dic.name;

            }

        }

        private void txtCompanyName_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;

            SetCompanyData(form.SelectCompany);
        }

        protected void SetCompanyData(FishEntity.CompanyEntity company)
        {
            if (company == null) return;

            txtCompanyName.Text = company.fullname;
            txtCompanyCode.Text = company.code;
            txtCompanyCode.Tag = company.id;
            txtLevel.Text = company.generallevel;
            txtAddress.Text = company.address;

            txtLinkMan.Text = string.Empty;
            txtLinkManCode.Text = string.Empty;

            txtCustomerNature.Text = company.customerproperty;
            txtSaleman.Text = company.salesman;
            txttransportfee.Text = company.freight.ToString();
            txtweight.Text = company.tare.ToString();
            txtspecifacation.Text = company.requiredproduct;
            txtQuality.Text = company.productrequire;
            txtProducts.Text = company.products;
            txtcompetitors.Text = company.competitors;
            txtWeek.Text = company.currentweekestimate.ToString();
            txtMonth.Text = company.currentmonthestimate.ToString();

            FishBll.Bll.CustomerBll customerBll = new FishBll.Bll.CustomerBll();
            List<FishEntity.CustomerEntity> customers = customerBll.GetCustomerOfCompany(company.id);
            if (customers != null && customers.Count > 0)
            {
                FishEntity.CustomerEntity customer = customers.Find((i) => { return i.flag == 1; });
                if (customer != null)
                {
                    txtLinkMan.Text = customer.name;
                    txtLinkManCode.Text = customer.code;
                    txtLinkMan.Tag = customer.id;
                    string phone = string.IsNullOrEmpty(customer.phone1) ? "" : customer.phone1;
                    if (!string.IsNullOrEmpty(customer.phone2))
                    {
                        phone += string.IsNullOrEmpty(phone) ? customer.phone2 : " , " + customer.phone2;
                    }
                    if (!string.IsNullOrEmpty(customer.phone3))
                    {
                        phone += string.IsNullOrEmpty(phone) ? customer.phone3 : " , " + customer.phone3;
                    }
                    txtMobile.Text = phone;
                    txtOfficeTel.Text = customer.telephone;
                }
            }
        }

        private void txtLinkManCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCompanyCode.Text) == true)
            {
                MessageBox.Show("请先选择客户,再操作。");
                return;
            }

            //FormLinkmanList form = new FormLinkmanList();
            //form.StartPosition = FormStartPosition.CenterParent;
            //DialogResult result = form.ShowDialog();
            if( txtCompanyCode.Tag ==null ) return;

            int companyId =0;
            int.TryParse( txtCompanyCode.Tag.ToString () , out companyId );

            UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companyId);
            form.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.CustomerEntity customer = form.SelectedCustomer;
                if (customer != null)
                {
                    txtLinkMan.Text = customer.name;
                    txtLinkManCode.Text = customer.code;
                    string temp = string.Empty;
                    if (string.IsNullOrEmpty(customer.phone1) == false)
                    {
                        temp += customer.phone1;
                    }
                    if (string.IsNullOrEmpty(customer.phone2) == false)
                    {
                        if (string.IsNullOrEmpty(temp) == false)
                        {
                            temp += ",";
                        }
                        temp += customer.phone2;
                    }
                    if (string.IsNullOrEmpty(customer.phone3) == false)
                    {
                        if (string.IsNullOrEmpty(temp) == false)
                        {
                            temp += ",";
                        }
                        temp += customer.phone3;
                    }

                    txtMobile.Text = temp;
                    txtOfficeTel.Text = customer.telephone;
                }
            }
        }

        private void FormCallRecords_Load(object sender, EventArgs e)
        {
            dgvUtil = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header = new UILibrary.TwoDimenDataGridView.TopHeader (10,10,"保证实测指标");
            dgvUtil.Headers.Add(header);

            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.CountryType); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            nature.DataSource = list;
            nature.DisplayMember = "name";
            nature.ValueMember = "code";

            list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Specification); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            specification.DataSource = list;
            specification.DisplayMember = "name";
            specification.ValueMember = "code";

            list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Brand); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            brand.DataSource = list;
            brand.DisplayMember = "name";
            brand.ValueMember = "code";

            list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Paymethod ); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            paymethod.DataSource = list;
            paymethod.DisplayMember = "name";
            paymethod.ValueMember = "code";                       

        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        private void FormCallRecords_Activated(object sender, EventArgs e)
        {
            txtContent.Focus();
        }

        private void txtLinkMan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContent_Load(object sender, EventArgs e)
        {

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_CallRecords_1");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_CallRecords_1");
        }
        protected void ReadColumnConfig(DataGridView dgv, string section)
        {
            string path = Application.StartupPath + "\\listconfig.ini";
            if (System.IO.File.Exists(path) == true)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    string wstr = Utility.IniUtil.ReadIniValue(path, section, col.HeaderText);
                    int w = 0;
                    if (int.TryParse(wstr, out w))
                    {
                        col.Width = w;
                    }
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_CallRecords_2");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_CallRecords_2");
        }
    }
}
