using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.Contract
{
    public partial class FormProductContract2 : FormMenuBase
    {
        protected FishEntity.ContractEntity _contract = null;
        protected List<FishEntity.ContractDetailEntity> _details = null;
        protected FishBll.Bll.ContractBll _contractbll = new FishBll.Bll.ContractBll();
        protected FishBll.Bll.ContractDetailBll _detailbll = new FishBll.Bll.ContractDetailBll();
        protected string _orderBy = " order by contractid asc limit 1";
        protected string _where = " type="+(int)FishEntity.ContractTypeEnum.ProductContract2;
        UIControls.ToolStripMenuItemEx loadingdetail;
        UIControls.ToolStripMenuItemEx finishContract;
        UIControls.ToolStripMenuItemEx tsmPrint;

        public FormProductContract2()
        {
            InitializeComponent();

            AddMenu();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name.Equals("weight"))
            {
                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    DataGridViewTextBoxEditingControl ctlWeight = e.Control as DataGridViewTextBoxEditingControl;
                    ctlWeight.TextChanged += ctlWeight_TextChanged;
                }
            }
            else if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name.Equals("unitprice"))
            {
                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    DataGridViewTextBoxEditingControl ctlPrice = e.Control as DataGridViewTextBoxEditingControl;
                    ctlPrice.TextChanged += ctlPrice_TextChanged;
                }
            }
        }

        private void CalcTotalMoney()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                decimal money = 0;
                string str = row.Cells["money"].Value == null ? "0.00" : row.Cells["money"].Value.ToString();
                decimal.TryParse(str, out money);
                total += money;
            }
            ctlmoney.Text = Utility.MoneyToRMB.ConvertSum(total.ToString("f2"));
        }

        void ctlPrice_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl ctl = sender as DataGridViewTextBoxEditingControl;
            if (ctl == null) return;
            string txt = ctl.Text;
            decimal price = 0;
            decimal.TryParse(txt, out price);
            decimal weight = 0;
            string weightstr = dataGridView1.CurrentRow.Cells["weight"].Value == null ? "0.00" : dataGridView1.CurrentRow.Cells["weight"].Value.ToString();
            decimal.TryParse(weightstr, out weight);
            decimal money = weight * price;
            dataGridView1.CurrentRow.Cells["money"].Value = money;

            CalcTotalMoney();
        }

        void ctlWeight_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl ctl = sender as DataGridViewTextBoxEditingControl;
            if (ctl == null) return;
            string txt = ctl.Text;
            decimal weight = 0;
            decimal.TryParse(txt, out weight);
            decimal price = 0;
            string pricestr = dataGridView1.CurrentRow.Cells["unitprice"].Value == null ? "0.00" : dataGridView1.CurrentRow.Cells["unitprice"].Value.ToString();
            decimal.TryParse(pricestr, out price);
            decimal money = weight * price;
            dataGridView1.CurrentRow.Cells["money"].Value = money;
           

            CalcTotalMoney();
        }
        
        public override void Next()
        {
            QueryOne(" > ", " order by contractid asc limit 1");
        }

        public override void Previous()
        {
            QueryOne(" < ", " order by contractid desc limit 1");
        }
        protected void QueryOne(string operate, string orderBy)
        {
            errorProvider1.Clear();
            string whereEx = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                whereEx = " 1=1 ";
            }
            else
            {
                whereEx = _where;
            }

            if (_contract != null)
            {
                whereEx += string.Format( " and contractno {0} '{1}'" , operate , _contract.contractno);
            }

            List<FishEntity.ContractEntity> list = _contractbll.GetModelList(whereEx + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _contract = list[0];

            SetContract();
            SetDetail();
        }

        protected void SetContract()
        {
            if (_contract == null) return;
            ctladdress.Text = _contract.address;
            ctlbank.Text = _contract.bank;
            ctlbankaccount.Text = _contract.bankaccount;
            ctlcheck1.Text = _contract.check1;
            ctlcheck2.Text = _contract.check2;
            ctlcheck3.Text = _contract.check3;
            ctlcontractno.Text = _contract.contractno;
            ctldate1.Text = _contract.date1;
            ctldate2.Text = _contract.date2;
            ctldate3.Text = _contract.date3;
            ctldeliverytime.Text = _contract.deliverytime;
            ctlmaifang.Text = _contract.maifang;
            ctlmaifang.Tag = _contract.maifangcode;
            ctlmaifangaddress.Text = _contract.maifangaddress;
            ctlmaifangfox.Text = _contract.maifangfox;
            ctlmaifangname.Text = _contract.maifang;
            ctlmaifangname.Tag = _contract.maifangcode;
            ctlmaifangtelephone.Text = _contract.maifangtelephone;
            ctlmoney.Text = Utility.MoneyToRMB.ConvertSum(_contract.money.ToString("f2"));
            ctlpackage.Text = _contract.package;
            ctlsignaddress.Text = _contract.signaddress;
            ctlsigndate.Text = _contract.signdate;
            ctltime1.Text = _contract.time1;
            ctltime2.Text = _contract.time2;
            ctltime3.Text = _contract.time3;
            ctltime4.Text = _contract.time4;
            ctlresolve.Text = _contract.resolve;
            ctlyiduanzhuang.Text = _contract.yiduanzhuang;
            ctlyifang.Text = _contract.yifang;
            ctlyifang.Tag = _contract.yifangcode;
            ctlyifangaddress.Text = _contract.yifangaddress;
            ctlyifangfox.Text = _contract.yifangfox;
            ctlyifangname.Text = _contract.yifang;
            ctlyifangname.Tag = _contract.yifangcode;
            ctlyifangtelephone.Text = _contract.yifangtelephone;
        }
        protected void SetDetail()
        {
            int contractid = _contract.contractid;
            _details = _detailbll.GetModelList("contractid=" + contractid);

            dataGridView1.Rows.Clear();
            if (_details == null || _details.Count < 1) return;
            foreach (FishEntity.ContractDetailEntity item in _details)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["id"].Value = item.id;
                row.Cells["no"].Value = item.no;
                row.Cells["productid"].Value = item.productid;
                row.Cells["productno"].Value = item.productno;
                row.Cells["productname"].Value = item.productname;
                row.Cells["specification"].Value = item.specification;
                row.Cells["nature"].Value = item.nature;
                row.Cells["weight"].Value = item.weight;
                row.Cells["quantity"].Value = item.quantity;
                row.Cells["unitprice"].Value = item.unitprice;
                row.Cells["money"].Value = item.money;
                row.Cells["ctlremark"].Value = item.remark;
                row.Cells["contractid"].Value = item.contractid;
            }
            CalcTotalMoney();
        }

        public override int Query()
        {
            UIForms.FormContractCondition form = new UIForms.FormContractCondition ();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where =  form.GetWhereCondition;
            if (string.IsNullOrEmpty(_where)==false )
            {
                _where += " and ";
            }
            _where += " type=" + (int)FishEntity.ContractTypeEnum.ProductContract2;


            List<FishEntity.ContractEntity> list = _contractbll.GetModelList(_where + _orderBy);
            if (list == null || list.Count < 1)
            {
                _contract = null;
                _details = null;
                return 1;
            }
            else
            {
                _contract = list[0];
                SetContract();
                SetDetail();
            }
            return 1;
        }

        protected bool Check()
        {
            errorProvider1.Clear();
            string maifang = ctlmaifang.Text;
            string yifang = ctlyifang.Text;
            if (string.IsNullOrEmpty(maifang))
            {
                errorProvider1.SetError(ctlmaifang, "请填写卖方信息");
                return false;
            }
            if (string.IsNullOrEmpty(yifang))
            {
                errorProvider1.SetError(ctlyifang, "请填写买方信息");
                return false;
            }

            bool hasrow = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                hasrow = true;
            }
            if (hasrow == false)
            {
                errorProvider1.SetError(dataGridView1, "请填写鱼粉信息");
                return false;
            }

            return true;
        }


        public override int Add()
        {
            errorProvider1.Clear();
            tmiSave.Visible = true;
            tmiCancel.Visible = true;

            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            loadingdetail.Visible = false;
            finishContract.Visible = false;
            tsmPrint.Visible = false;

            _contract = null;
            _details = null;

            ctladdress.Text = string.Empty;
            ctlbank.Text = string.Empty;
            ctlcheck1.Text = string.Empty;
            ctlcheck2.Text = string.Empty;
            ctlcheck3.Text = "≤≥";//string.Empty;
            ctlcontractno.Text = string.Empty;
            ctldate1.Text = string.Empty;
            ctldate2.Text = string.Empty;
            ctldate3.Text = string.Empty;
            ctldeliverytime.Text = string.Empty;
            ctlmaifang.Text = string.Empty;//"上海正东饲料有限公司";
            ctlmaifang.Tag = string.Empty;
            ctlmaifangaddress.Text = string.Empty;
            ctlmaifangfox.Text = string.Empty;
            ctlmaifangname.Text = string.Empty;
            ctlmaifangname.Tag = string.Empty;
            ctlmaifangtelephone.Text = string.Empty;
            ctlmoney.Text = string.Empty;
            ctlpackage.Text = string.Empty;
            ctlsignaddress.Text = "传真/上海";
            ctlsigndate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            ctlresolve.Text = string.Empty;
            ctltime1.Text = string.Empty;
            ctltime2.Text = string.Empty;
            ctltime3.Text = string.Empty;
            ctltime4.Text = string.Empty;
            ctlyiduanzhuang.Text = string.Empty;
            ctlyifang.Text = string.Empty;
            ctlyifang.Tag = string.Empty;
            ctlyifangaddress.Text = string.Empty;
            ctlyifangfox.Text = string.Empty;
            ctlyifangname.Text = string.Empty;
            ctlyifangname.Tag = string.Empty;
            ctlyifangtelephone.Text = string.Empty;
            dataGridView1.Rows.Clear();

            return 1;
        }
        
        public override void Save()
        {
            if (Check() == false) return;

            GetContract();

            _contract.contractno = FishBll.Bll.SequenceUtil.GetContractSequence();
            while (_contractbll.Exists(_contract.contractno))
            {
                _contract.contractno = FishBll.Bll.SequenceUtil.GetContractSequence();
            }

            int id = _contractbll.Add(_contract);
            if (id > 0)
            {
                _contract.contractid = id;
                ctlcontractno.Text = _contract.contractno;
                AddDetail(id, true);

                //tmiSave.Visible = false;
                //tmiCancel.Visible = false;

                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiNext.Visible = true;
                ControlButtomRoles();

                MessageBox.Show("添加成功。");
            }
            else
            {
                MessageBox.Show("添加失败。");
            }
        }

        protected void AddDetail(int contractid, bool isAdd)
        {
            dataGridView1.EndEdit();

            List<FishEntity.ContractDetailEntity> listNews = new List<FishEntity.ContractDetailEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.ContractDetailEntity item = new FishEntity.ContractDetailEntity();
                int id = 0;
                int.TryParse(row.Cells["id"].Value == null ? "0" : row.Cells["id"].Value.ToString(), out id);
                item.id = id;
                int no = 0;
                int.TryParse(row.Cells["no"].Value == null ? "0" : row.Cells["no"].Value.ToString(), out no);
                item.no = no;
                int productid = 0;
                int.TryParse(row.Cells["productid"].Value == null ? "0" : row.Cells["productid"].Value.ToString(), out productid);
                item.productid = productid;
                item.productno = row.Cells["productno"].Value == null ? string.Empty : row.Cells["productno"].Value.ToString();
                item.productname = row.Cells["productname"].Value == null ? string.Empty : row.Cells["productname"].Value.ToString();
                item.specification = row.Cells["specification"].Value == null ? string.Empty : row.Cells["specification"].Value.ToString();
                item.remark = row.Cells["ctlremark"].Value == null ? string.Empty : row.Cells["ctlremark"].Value.ToString();
                item.nature = row.Cells["nature"].Value == null ? string.Empty : row.Cells["nature"].Value.ToString();
                decimal weight = 0;
                if (row.Cells["weight"].Value == null)
                {
                    weight = 0;
                }
                else
                {
                    decimal.TryParse(row.Cells["weight"].Value.ToString(), out weight);
                }
                item.weight = weight;

                int quantity = 0;
                if (row.Cells["quantity"].Value == null)
                {
                    quantity = 0;
                }
                else
                {
                    int.TryParse(row.Cells["quantity"].Value.ToString(), out quantity);
                }
                item.quantity = quantity; 
                
                decimal unitprice = 0;
                decimal.TryParse(row.Cells["unitprice"].Value == null ? "0.00" : row.Cells["unitprice"].Value.ToString(), out unitprice);
                item.unitprice = unitprice;                
                decimal money = 0;
                decimal.TryParse(row.Cells["money"].Value == null ? "0.00" : row.Cells["money"].Value.ToString(), out money);
                item.money = money;
                item.contractid = contractid;

                listNews.Add(item);
            }


            if (isAdd == false)
            {
                List<FishEntity.ContractDetailEntity> listsource = _detailbll.GetModelList(" contractid=" + contractid);
                if (listsource != null)
                {
                    foreach (FishEntity.ContractDetailEntity item in listsource)
                    {
                        bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                        if (isExist == false)
                        {
                            bool isDelete = _detailbll.Delete(item.id);
                        }
                    }
                }
            }

            foreach (FishEntity.ContractDetailEntity item in listNews)
            {
                if (item.id == 0)
                {
                    int id = _detailbll.Add(item);
                    if (id > 0)
                    {
                        item.id = id;
                    }
                }
                else
                {
                    _detailbll.Update(item);
                }
            }

            _details = listNews;
            SetDetail();
        }

        public override void Cancel()
        {
            errorProvider1.Clear();

            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            ControlButtomRoles();
        }
        //给大家看我的宝贝http://dwz.cn/2YoVfs
        protected void GetContract()
        {
            if (_contract == null)
            {
                _contract = new FishEntity.ContractEntity();
            }

            _contract.address = ctladdress.Text;
            _contract.bank = ctlbank.Text;
            _contract.bankaccount = ctlbankaccount.Text;
            _contract.check1 = ctlcheck1.Text;
            _contract.check2 = ctlcheck2.Text;
            _contract.check3 = ctlcheck3.Text;
            _contract.contractno = ctlcontractno.Text;
            _contract.date1 = ctldate1.Text;
            _contract.date2 = ctldate2.Text;
            _contract.date3 = ctldate3.Text;
            _contract.deliverytime = ctldeliverytime.Text;
            _contract.maifang = ctlmaifang.Text;
            _contract.maifangaddress = ctlmaifangaddress.Text;
            _contract.maifangcode = ctlmaifang.Tag == null ? string.Empty : ctlmaifang.Tag.ToString();
            _contract.maifangfox = ctlmaifangfox.Text;
            _contract.maifangtelephone = ctlmaifangtelephone.Text;

            decimal money = 0;
            decimal.TryParse(ctlmoney.Tag == null ? "0.00" : ctlmoney.Tag.ToString(), out money);
            _contract.money = money;
            
            _contract.package = ctlpackage.Text;
            _contract.signaddress = ctlsignaddress.Text;
            _contract.signdate = ctlsigndate.Text;
            _contract.time1 = ctltime1.Text;
            _contract.time2 = ctltime2.Text;
            _contract.time3 = ctltime3.Text;
            _contract.time4 = ctltime4.Text;
            _contract.resolve = ctlresolve.Text;
            _contract.type = (int)FishEntity.ContractTypeEnum.ProductContract2;
            _contract.yiduanzhuang = ctlyiduanzhuang.Text;
            _contract.yifang = ctlyifang.Text;
            _contract.yifangaddress = ctlyifangaddress.Text;
            _contract.yifangcode = ctlyifang.Tag == null ? string.Empty : ctlyifang.Tag.ToString();
            _contract.yifangfox = ctlyifangfox.Text;
            _contract.yifangtelephone = ctlyifangtelephone.Text;

        }

        public override int Modify()
         {
            if (_contract == null)
            {
                MessageBox.Show("请查询需要修改的合同。");
                return 0;
            }
            if (Check() == false) return 0;

            GetContract();

            bool isok = _contractbll.Update(_contract);
            if (isok)
            {
                AddDetail(_contract.contractid, false);

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }

        private void AddMenu()
        {
            loadingdetail = new UIControls.ToolStripMenuItemEx();
            loadingdetail.Text = "预提明细录入";
            loadingdetail.FunCode = "50";
            loadingdetail.Click += loadingdetail_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), loadingdetail);

            finishContract = new UIControls.ToolStripMenuItemEx();
            finishContract.Text = "结束合同";
            finishContract.FunCode = "51";
            finishContract.Click += finishContract_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), finishContract);

            tsmPrint = new UIControls.ToolStripMenuItemEx();
            tsmPrint.Text = "打印";
            tsmPrint.FunCode = "52";
            tsmPrint.Click += tsmPrint_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tsmPrint);
        }

        void loadingdetail_Click(object sender, EventArgs e)
        {
            if (_contract == null || _details == null)
            {
                MessageBox.Show("请查询出合同信息再操作。");
                return;
            }

            FormContractTakeDetail form = new FormContractTakeDetail(_contract.contractid, _contract.contractno);
            form.ShowDialog();

        }

        void tsmPrint_Click(object sender, EventArgs e)
        {
            if (_contract == null || _details == null)
            {
                MessageBox.Show("请查询出合同信息再打印。");
                return;
            }

            _contract.moneydaxie = ctlmoney.Text;
            PrintUtil.PrintContract3(_contract, _details);
        }

        void finishContract_Click(object sender, EventArgs e)
        {
            if (_contract == null)
            {
                MessageBox.Show("请查询出一条合同记录，再进行操作。");
                return;
            }

            int rowcount = _contractbll.UpdateContractStatus(_contract.contractid, (int)FishEntity.ContractStatusEnum.FINISH);
            if (rowcount > 0)
            {
                MessageBox.Show("合同结束。");
            }
            else
            {
                MessageBox.Show("结束合同失败。");
            }
        }

        private void FormProductContract1_Load(object sender, EventArgs e)
        {
            //tmiDelete.Visible = false;
            //tmiExport.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;

            //AddMenu();

            List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.Goods); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            FishEntity.DictEntity empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            productname.DataSource = list;
            productname.DisplayMember = "name";
            productname.ValueMember = "code";

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

            list = InitDataUtil.DictList.FindAll((i) => { return i.pcode.Equals(FishEntity.Constant.CountryType); });
            if (list == null)
            {
                list = new List<FishEntity.DictEntity>();
            }

            empty = new FishEntity.DictEntity();
            empty.name = "";
            empty.code = "-1";
            list.Insert(0, empty);

            nature.DataSource = list;
            nature.DisplayMember = "name";
            nature.ValueMember = "code";
        }

        private void ctlyifang_ClickEvent(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            ctlyifang.Tag = form.SelectCompany.code;
            ctlyifang.Text = form.SelectCompany.fullname;
            ctlyifangname.Tag = form.SelectCompany.code;
            ctlyifangname.Text = form.SelectCompany.fullname;
            ctlyifangaddress.Text = form.SelectCompany.address;
            ctlyifangfox.Text = form.SelectCompany.fox;
            ctlyifangtelephone.Text = form.SelectCompany.fox;
        }

        private void ctlmaifang_ClickEvent(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            ctlmaifang.Tag = form.SelectCompany.code;
            ctlmaifang.Text = form.SelectCompany.fullname;
            ctlmaifangname.Text = form.SelectCompany.fullname;
            ctlmaifangname.Tag = form.SelectCompany.code;
            ctlmaifangaddress.Text = form.SelectCompany.address;
            ctlmaifangfox.Text = form.SelectCompany.fox;
            ctlmaifangtelephone.Text = form.SelectCompany.fox;
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView1.Rows[e.RowIndex].Cells["no"].Value = e.RowIndex + 1;
            }
        }
    }
}
