using System;
using System . Collections . Generic;
using System . Windows . Forms;
using FishEntity;
using System . Data;

//t_salesorder  单头
//t_happening  单身

namespace FishClient
{
    public partial class FormSalesRequisition : FormMenuBase
    {
        FishEntity.SalesRequisitionEntity _head = null;
        FishEntity.SalesRequisitionBodyEntity _body = null;
        /// <summary>
        /// 流程状态表刷新
        /// </summary>
        FishBll.Bll.ProcessStateBll _Refreshbll = null;
        FishBll.Bll.SalerequisitionBll _bll = new FishBll.Bll.SalerequisitionBll();
        FishBll.Bll.happeningBll _happbll = new FishBll.Bll.happeningBll();
        string _where = string.Empty;
        string FishmealId = string.Empty;
        string _rolewhere = string.Empty;
        string _orderBy = " order by id asc limit 1";
        string state = string.Empty;
        bool isOk = false;
        string funname = string.Empty;
        public string signOfOpen = string.Empty;
        //
        public FormSalesRequisition()
        {
            InitializeComponent();
            this.panel2.Enabled = false;
            if (FishEntity.Variable.User == null) return;
            //消除dataErr错误
            this.dataGridView4.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e)
                {
                };
        }
        public FormSalesRequisition(string code,string Title)
        {
            InitializeComponent();
            MenuCode = "M306"; ControlButtomRoles();
            panel2.Enabled = false;
            if (Title == "one")
            {
                rabZy.Checked = true;
            }
            else if(Title == "two")
            {
                rabZz.Checked = true;
            }
        }
        public FormSalesRequisition(string Numbering)
        {
            InitializeComponent();
            MenuCode = "M306"; ControlButtomRoles();
            panel2.Enabled = false;
            this.dataGridView4.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e)
            {
            };
            if (FishEntity.Variable.User == null) return;
            //InitDataUtil.BindComboBoxData(cmbtransport, FishEntity.Constant.Modeoftransport, true);
            //InitDataUtil.BindComboBoxData(Country, FishEntity.Constant.CountryType, true);
            if (Numbering != "")
            {
                _rolewhere = " Numbering='" + Numbering + "'";
                QueryByWhere();
            }
            else {
                _rolewhere = string.Empty;
            }
            //权限控制功能。
            Megres.oddNum = string.Empty;
        }
        //送审
        public override void Review()
        {
            Review(this.Name, txtNumbering.Text,txtcode.Text);
            //if (txtNumbering.Text != "")
            //{
            //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
            //    _Refreshbll.GetFormSalesRequisition(txtNumbering.Text);
            //}
            base.Review();
        }
        private void FormSalesRequisition_Load(object sender, EventArgs e)
        {
            MenuCode = "M306"; ControlButtomRoles();
            InitDataUtil.BindComboBoxData(cmbtransport, FishEntity.Constant.Modeoftransport, true);
            InitDataUtil.BindComboBoxData(Country, FishEntity.Constant.CountryType, true);
            if (Megres.oddNum != "")
            {
                _rolewhere = " Numbering='" + Megres.oddNum + "'";
                QueryByWhere();
            }
            else {
                _rolewhere = string.Empty;
            }
            //权限控制功能。
            Megres.oddNum = string.Empty;
        }
        //查询
        public override int Query()
        {
            FormSalesRequisitionCondition form = new FormSalesRequisitionCondition();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;
            _where = form.GetWhereCondition;
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _where += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
            }
            SalesRequisitionEntity _list = _bll.GetList(_where);
            if (_list == null)
            {
                _head = null;
            }
            else
            {
                _head = _list;
                Clear();

                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                SetSalesRequisition();
                Sethappening();
                txtNumbering.ReadOnly = true;
                panel2.Enabled = true;
            }
            _where = string.Empty;
            return 1;
        }
        protected void QueryByWhere()
        {
            if (_where != "")
            {
                _where += "or";
            }
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
            }
            SalesRequisitionEntity _list = _bll.GetList(_where + _rolewhere);
            if (_list == null)
            {
                _head = null;
            }
            else
            {
                _head = _list;
                Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                SetSalesRequisition();
                Sethappening();
                txtNumbering.ReadOnly = true;
                panel2.Enabled = true;                
            }
            _where = string.Empty;
        }
        public void SetSalesRequisition()
        {
            //txtNumbering. = false;
            txtcode.Text = _head.code;
            txtsupplier.Text = _head.supplier;
            txtsupplier.Tag = _head.supplierId;
            txtsupplierContact.Text = _head.SupplierContact;
            txtsupplierContact.Tag = _head.SupplierContactId;
            txtPurchasingunits.Text = _head.Purchasingunits;
            txtPurchasingunits.Tag = _head.PurchasingunitsId;
            txtPurchasingcontacts.Text = _head.Purchasingcontacts;
            txtPurchasingcontacts.Tag = _head.PurchasingcontactsId;
            txtPurchasecontractnumber.Text = _head.Purchasecontractnumber;
            rabsupplier.Checked = _head.Supplierbool == true ? true : false;
            rabdemand.Checked = _head.Demandbool == true ? true : false;
            txtNumbering.Text = _head.Numbering;
            txtdemand.Text = _head.demand;
            txtdemand.Tag = _head.demandId;
            txtdemandContact.Text = _head.DemandContact;
            txtdemandContact.Tag = _head.DemandContactId;
            txtSignplace.Text = _head.Signplace;
            txtsupplierAbbreviation.Text = _head.SupplierAbbreviation;
            txtdemandAbbreviation.Text = _head.DemandAbbreviation;
            if (_head.Signdate != null)
                dtpSigndate.Value = DateTime.Parse(_head.Signdate.ToString());
            txtSalesman.Text = _head.createman;
            txtcreateman.Text = _head.createman;
            txtmodifyman.Text = _head.modifyman;
            txtRequiredAccount.Text = _head.RequiredAccount;
            txtPaymentUnit.Text = _head.PaymentUnit;
            txtDemandSideBank.Text = _head.DemandSideBank;
            checkdeIndex.Checked = _head.deIndex == true ? true : false;
            checkrebateBool.Checked = _head.rebateBool == true ? true : false;
            checkWithSkinBool.Checked = _head.WithSkinbool == true ? true : false;
            rabsupplier.Checked = _head.Supplierbool == true ? true : false;
            chesupplier.Checked = _head.Supplierbool == true ? true : false;
            rabdemand.Checked = _head.Demandbool == true ? true : false;
            chedemand.Checked = _head.Demandbool == true ? true : false;
            chedb.Checked = _head.Dbbool == true ? true : false;
            chetvn.Checked = _head.Tvnbool == true ? true : false;
            cheza.Checked = _head.Zabool == true ? true : false;
            cheFFA.Checked = _head.Ffabool == true ? true : false;
            chezf.Checked = _head.Zfbool == true ? true : false;
            chesf.Checked = _head.Sfbool == true ? true : false;
            cheshy.Checked = _head.Shybool == true ? true : false;
            chesz.Checked = _head.Szbool == true ? true : false;
            checdb.Checked = _head.Cdbbool == true ? true : false;
            chetvnOne.Checked = _head.TvnOnebool == true ? true : false;
            chehf.Checked = _head.Hfbool == true ? true : false;
            chezaOne.Checked = _head.ZaOnebool == true ? true : false;
            cheffaOne.Checked = _head.FfaOnebool == true ? true : false;
            chezfOne.Checked = _head.ZfOnebool == true ? true : false;
            chesfOne.Checked = _head.SfOnebool == true ? true : false;
            cheshyOne.Checked = _head.ShyOnebool == true ? true : false;
            cheszOne.Checked = _head.SzOnebool == true ? true : false;
            cheinformation.Checked = _head.Informationbool == true ? true : false;
            checkFreightbool.Checked = _head.Freightbool == true ? true : false;
            checkStockpilebool.Checked = _head.Stockpilebool == true ? true : false;
            checkFreightSumbool.Checked = _head.FreightSumbool == true ? true : false;
            checkPortpriceSumbool.Checked = _head.PortpriceSumBool == true ? true : false;
            checkrebateSumBool.Checked = _head.RebateSumBool == true ? true : false;
            checkWithSkinSumbool.Checked = _head.WithSkinSumbool == true ? true : false;
            txtrebate.Text = _head.rebate.ToString();
            txtoverflow.Text = _head.overflow.ToString();
            txtWithSkin.Text = _head.WithSkin;
            checkPortpriceBool.Checked = _head.PortpriceBool == true ? true : false;
            txtPortprice.Text = _head.Portprice.ToString();
            checkCountryBool.Checked = _head.CountryBool == true ? true : false;
            //comCountry . Text = _head . Country;
            cmbtransport.Text = _head.transport;
            if (_head.deadline != null)
                dtpDeliveryDeadline.Value = DateTime.Parse(_head.deadline.ToString());
            txtFreight.Text = _head.Freight.ToString();
            txtCNumbering.Text = _head.CNumbering.ToString();
            texdelivery.Text = _head.delivery;
            texdt.Text = _head.dt.ToString();
            texdty.Text = _head.dty.ToString();
            texlx.Text = _head.lxt.ToString();
            texlxy.Text = _head.lxty.ToString();
            texSettlementmethod.Text = _head.Settlementmethod;
            if (_head.payment != null)
                dtppayment.Value = DateTime.Parse(_head.payment.ToString());
            texBank.Text = _head.Bank;
            txtReceipt.Text = _head.Receipt;
            txtaccountnumber.Text = _head.accountnumber.ToString();
            texRemark.Text = _head.remart;
            rabZy . Checked = _head . RabZy;
            rabZz . Checked = _head . RabZz;
            //if (rabZy.Checked==true)
            //{
            //    rabHq.Checked = true;
            //}
            //if (rabZz.Checked == true)
            //{
            //    rabZdi.Checked = true;
            //}
            ///MoneyYFK//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////不清楚
            ///txtMoneyYFK. Text = _head . MoneyYFK . ToString ( );
        }
        public void Sethappening()
        {
            List<SalesRequisitionBodyEntity> happe = _happbll.getList(_head.Numbering);
            Sethappening(happe);
        }
        protected void Sethappening(List<SalesRequisitionBodyEntity> happe)
        {

            if (happe == null || happe.Count < 1)
                return;
            {
                int idx = 0;
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Clear();
                foreach (SalesRequisitionBodyEntity item in happe)
                {
                    idx = dataGridView1.Rows.Add();
                    row = dataGridView1.Rows[idx];
                    row.Cells["product_id"].Value = item.product_id;
                    row.Cells["productname"].Value = item.productname;
                    row.Cells["Funit"].Value = item.Funit;
                    row.Cells["Variety"].Value = item.Variety;
                    row.Cells["Quantity"].Value = item.Quantity;
                    row.Cells["unitprice"].Value = item.unitprice;
                    row.Cells["Amonut"].Value = item.Amonut;
                    row . Cells [ "codeNumZdi" ] . Value = item . CodeNumZdi;
                    row . Cells [ "codeNumHq" ] . Value = item . CodeNumHq;
                    _head .Product_id= item.product_id;
                }
                idx = 0;
                row = new DataGridViewRow();
                dataGridView2.Rows.Clear();
                foreach (SalesRequisitionBodyEntity item in happe)
                {
                    idx = dataGridView2.Rows.Add();
                    row = dataGridView2.Rows[idx];
                    row.Cells["product_id_one"].Value = item.product_id;
                    row.Cells["db"].Value = item.db;
                    row.Cells["tvn"].Value = item.tvn;
                    row.Cells["za"].Value = item.za;
                    row.Cells["ffa"].Value = item.ffa;
                    row.Cells["zf"].Value = item.zf;
                    row.Cells["sf"].Value = item.sf;
                    row.Cells["shy"].Value = item.shy;
                    row.Cells["sz"].Value = item.sz;
                }
                idx = 0;
                row = new DataGridViewRow();
                dataGridView3.Rows.Clear();
                foreach (SalesRequisitionBodyEntity item in happe)
                {
                    idx = dataGridView3.Rows.Add();
                    row = dataGridView3.Rows[idx];
                    row.Cells["product_id_two"].Value = item.product_id;
                    row.Cells["cdb"].Value = item.cdb;
                    row.Cells["tvnOne"].Value = item.tvnOne;
                    row.Cells["hf"].Value = item.hf;
                    row.Cells["zaOne"].Value = item.ZaOne;
                    row.Cells["ffaOne"].Value = item.FfaOne;
                    row.Cells["zfOne"].Value = item.ZfOne;
                    row.Cells["sfOne"].Value = item.SfOne;
                    row.Cells["shyOne"].Value = item.ShyOne;
                    row.Cells["szOne"].Value = item.SzOne;
                }
                idx = 0;
                row = new DataGridViewRow();
                dataGridView4.Rows.Clear();
                foreach (SalesRequisitionBodyEntity item in happe)
                {
                    idx = dataGridView4.Rows.Add();
                    row = dataGridView4.Rows[idx];
                    row.Cells["product_id_tre"].Value = item.product_id;
                    row.Cells["cm"].Value = item.cm;
                    row.Cells["zjh"].Value = item.zjh;
                    row.Cells["tdh"].Value = item.tdh;
                    row.Cells["pp"].Value = item.pp;
                    row.Cells["Country"].Value = item.Country;
                }
            }
        }
        //新增
        public override int Add()
        {
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiClose.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiExport.Visible = false;
            tmiReview.Visible = false;
            panel2.Enabled = true;

            txtNumbering.ReadOnly = false;
            _head = null;
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();

            Clear();
            Numbering();
            dataGridView2.Rows.Insert(0, new DataGridViewRow());
            dataGridView3.Rows.Insert(0, new DataGridViewRow());
            dataGridView4.Rows.Insert(0, new DataGridViewRow());

            state = "add";

            return 1;
        }
        //生成合同号
        protected void codeNum()
        {
            if (_head == null)
            {
                _head = new SalesRequisitionEntity();
            }
            DateTime dt = _bll.getDate();
            _head.code = _bll.code();
            if (_head.code == string.Empty)
                _head.code = "ZD" + dt.ToString("yyyyMMdd") + "001";
            else
            {
                if (_head.code.Substring(2, 8) == dt.ToString("yyyyMMdd"))
                {
                    if (decimal.Parse(_head.code.Substring(2, 11)).GetType() == typeof(decimal))
                    {
                        _head.code = "ZD" + (Convert.ToInt64(_head.code.Substring(2, 11)) + 1).ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        _head.code = "ZD" + dt.ToString("yyyyMMdd") + "001";
                    }
                }
                else
                    _head.code = "ZD" + dt.ToString("yyyyMMdd") + "001";
            }
            txtcode.Text = _head.code;
        }
        //清空
        protected void Clear()
        {
            errorProvider1.Clear();
            txtNumbering.Text = string.Empty;
            txtcode.Text = string.Empty;
            txtsupplier.Text = string.Empty;
            txtsupplier.Tag = string.Empty;
            txtRequiredAccount.Text = string.Empty;
            txtPaymentUnit.Text = string.Empty;
            txtDemandSideBank.Text = string.Empty;

            rabdemand.Checked = rabsupplier.Checked = false;
            txtNumbering.Text = string.Empty;
            txtdemand.Text = string.Empty;
            txtdemand.Tag = string.Empty;
            txtdemandContact.Text = string.Empty;
            txtdemandContact.Tag = string.Empty;
            txtSignplace.Text = "上海/传真";
            txtsupplierAbbreviation.Text =string.Empty;
            txtdemandAbbreviation.Text =string.Empty;
            dtpSigndate.Value = DateTime.Now;
            checkdeIndex.Checked = false;
            checkrebateBool.Checked = false;
            checkWithSkinBool.Checked = false;
            txtSalesman.Text = string.Empty;
            chesupplier.Checked = false;
            chedemand.Checked = false;
            txtrebate.Text= txtoverflow.Text = string.Empty;
            txtWithSkin.Text = string.Empty;
            checkPortpriceBool.Checked = false;
            txtPortprice.Text = string.Empty;
            txtPurchasingunits.Text = string.Empty;
            txtPurchasingunits.Tag = string.Empty;
            txtPurchasingcontacts.Text = string.Empty;
            txtPurchasingcontacts.Tag = string.Empty;
            txtPurchasecontractnumber.Text = string.Empty;
            checkCountryBool.Checked = false;
            //comCountry . Text = string . Empty;
            cmbtransport.Text = string.Empty;
            dtpDeliveryDeadline.Value = DateTime.Now;
            txtFreight.Text = string.Empty;
            txtCNumbering.Text = string.Empty;
            texdelivery.Text = string.Empty;
            texdt.Text = string.Empty;
            texdty.Text = string.Empty;
            texlx.Text = string.Empty;
            texlxy.Text = string.Empty;
            texSettlementmethod.Text = string.Empty;
            dtppayment.Value = DateTime.Now;
            texBank.Text = string.Empty;
            txtReceipt.Text = string.Empty;
            txtaccountnumber.Text = string.Empty;
            texRemark.Text = string.Empty;
        }
        //编辑
        public override int Modify()
        {
            if (_head == null)
            {
                MessageBox.Show("请查询需要编辑的内容");
                return 0;
            }
            tmiQuery.Visible = false;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiClose.Visible = false;
            tmiReview.Visible = false;
            if (_bll.ExistsUpdateOrDelete(txtNumbering.Text, FishEntity.Variable.User.username) != true)
            {
                MessageBox.Show("不是所属人无法操作！");
                return 0;
            }

            bool Exists_code = _bll.Exists_code(_head.Numbering);
            if (Exists_code)
            {
                MessageBox.Show("已审核无法操作！");
                tmiAdd.Visible = false;
                tmiDelete.Visible = false;
                tmiSave.Visible = false;
                tmiModify.Visible = false;
                tmiClose.Visible = true;
                tmiReview.Visible = true;
                tmiQuery.Visible = true;
                return 0;
            }
            //panel2 . Enabled = true;

            state = "edit";

            dataGridView2.Rows.Insert(dataGridView2.Rows.Count, new DataGridViewRow());
            dataGridView3.Rows.Insert(dataGridView3.Rows.Count, new DataGridViewRow());
            dataGridView4.Rows.Insert(dataGridView4.Rows.Count, new DataGridViewRow());

            return 1;
        }
        //删除
        public override int Delete()
        {
            if (string.IsNullOrEmpty(txtcode.Text))
            {
                MessageBox.Show("请查询需要删除的内容");
                return 0;
            }
            if (_bll.ExistsUpdateOrDelete(txtNumbering.Text, FishEntity.Variable.User.username) != true)
            {
                MessageBox.Show("不是所属人无法操作！");
                tmiSave.Visible = false;
                return 0;
            }
            bool Exists_code = _bll.Exists_code(_head.code);
            if (Exists_code)
            {
                MessageBox.Show("已审核无法操作！");
                return 0;
            }
            isOk = _bll.Delete(txtcode.Text,txtNumbering.Text);
            if (isOk == true)
            {
                //if (txtNumbering.Text != "")
                //{
                //    _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //    _Refreshbll.GetFormSalesRequisition(txtNumbering.Text);
                //}
                MessageBox.Show("成功删除");

                _head = null;
                _body = null;
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();
                Clear();

                Next();
            }
            else
                MessageBox.Show("删除失败");

            return base.Delete();
        }
        //下一个
        //public override void Next()
        //{
        //    QueryOne(">", _orderBy);

        //    base.Next();
        //}
        //上一个
        //public override void Previous()
        //{
        //    QueryOne("<", _orderBy);

        //    base.Previous();
        //}
        protected void QueryOne(string operate, string orderBy)
        {
            _rolewhere = string.Empty;
            if (string.IsNullOrEmpty(_where))
            {
                _rolewhere = " 1=1 ";
            }
            else
            {
                _rolewhere = _where;
            }
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
            }
            if (_head != null)
            {
                _rolewhere += " AND code " + operate + "'" + _head.code + "'";
            }
            FishEntity.SalesRequisitionEntity list = _bll.GetList(_rolewhere + _orderBy);
            if (list == null)
            {
                //_Pres = null;
                MessageBox.Show("查无记录。");
            }
            else
            {
                _head = list;

                Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                dataGridView3.Rows.Clear();
                dataGridView4.Rows.Clear();

                SetSalesRequisition();
                Sethappening();
                txtNumbering.ReadOnly = true;
                panel2.Enabled = true;
            }
        }
        /// <summary>
        /// 销售申请单编号
        /// </summary>
        protected void Numbering()
        {
            _head = new FishEntity.SalesRequisitionEntity();
            FishBll.Bll.SalerequisitionBll bll = new FishBll.Bll.SalerequisitionBll();
            _head.Numbering = bll.Numbering();
            string str = string.Empty;
            int sum = 0;
            if (_head.Numbering == string.Empty)
            {
                str = DateTime.Now.Year.ToString() + "X" + "0001001";
            }
            else {
                sum = int.Parse(_head.Numbering) + 1000;
                _head.Numbering = sum.ToString();
                while (_head.Numbering.Length != 7)
                {
                    _head.Numbering = "0" + _head.Numbering;
                }
                str = DateTime.Now.Year.ToString() + "X" + _head.Numbering;
            }
            txtNumbering.Text = str;
        }
        //保存
        public override void Save()
        {
            if (FishmealId.ToString()!="")
            {
                if (dataGridView1.Rows[0].Cells["product_id"].Value.ToString() != FishmealId.ToString())
                {
                    if (MessageBox.Show("销售申请单与采购汇总表,鱼粉Id不一样是否添加！", "提示！", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {

                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (getValu() == false)
                return;
            _head.createtime = _head.modifytime = _bll.getDate();
            _head.createman = _head.modifyman = FishEntity.Variable.User.username;

            List<FishEntity.SalesRequisitionBodyEntity> modelList = new List<FishEntity.SalesRequisitionBodyEntity>();
            DataViewOne(modelList);
            if (state == "add")
            {
                //bool isok = _bll.Exists(_head.code);
                //if (isok)
                //{
                //    MessageBox.Show("合同编号已存在！");
                //    return;
                //}
                bool isok = _bll.ExistsNumbering(_head.Numbering);
                if (isok)
                {
                    MessageBox.Show("编号已存在！");
                    return;
                }
                else {
                    isOk = _bll.Add(_head, modelList);
                    //if (txtNumbering.Text != "")
                    //{
                    //    if (rabHq.Checked!=false||rabZz.Checked!=false||rabZdi.Checked !=false|| rabZy.Checked!=false)
                    //    {
                    //        _Refreshbll = new FishBll.Bll.ProcessStateBll();
                    //        _Refreshbll.GetFormSalesRequisition(txtNumbering.Text);
                    //    }
                    //}
                }
            }
            else if (state == "edit")
            {
                if (_bll.ExistsUpdateOrDelete(txtNumbering.Text, FishEntity.Variable.User.username)!=true)
                {
                    MessageBox.Show("不是所属人无法操作！");
                    tmiSave.Visible = false;
                    return;
                }
                isOk = _bll.Update(_head, modelList);

                //if (txtNumbering.Text != "")
                //{
                //    if (rabHq.Checked != false || rabZz.Checked != false || rabZdi.Checked != false || rabZy.Checked != false)
                //    {
                //        _Refreshbll = new FishBll.Bll.ProcessStateBll();
                //        _Refreshbll.GetFormSalesRequisition(txtNumbering.Text);
                //    }
                //}
            }
            if (isOk == true)
            {
                tmiSave.Visible = false;
                tmiCancel.Visible = false;
                tmiAdd.Visible = true;
                tmiModify.Visible = true;
                tmiQuery.Visible = true;
                tmiDelete.Visible = true;
                tmiClose.Visible = true;
                tmiReview.Visible = true;
                txtNumbering.Visible = false;
                if (state == "add") {
                    txtSalesman.Text = _head.createman;
                    txtcreateman.Text = _head.createman;
                    txtmodifyman.Text = _head.modifyman;
                }

                txtNumbering.ReadOnly = true;
                MessageBox.Show("保存成功");
            }
            else
                MessageBox.Show("保存失败");

        }
        bool getValu()
        {
            errorProvider1.Clear();
            isOk = true;
            if (string.IsNullOrEmpty(txtcode.Text))
            {
                errorProvider1.SetError(txtcode, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtsupplier.Text))
            {
                errorProvider1.SetError(txtsupplier, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtdemand.Text))
            {
                errorProvider1.SetError(txtdemand, "不可为空");
                isOk = false;
            }
            if (string.IsNullOrEmpty(txtSignplace.Text))
            {
                errorProvider1.SetError(txtSignplace, "不可为空");
                isOk = false;
            }
            if (rabZz.Checked==true||rabZy.Checked== true)
            {
                if (string.IsNullOrEmpty(txtPurchasingunits.Text))//
                {
                    errorProvider1.SetError(txtPurchasingunits, "不可为空");
                    isOk = false;
                }
                if (string.IsNullOrEmpty(txtPurchasingcontacts.Text))//
                {
                    errorProvider1.SetError(txtPurchasingcontacts, "不可为空");
                    isOk = false;
                }
                if (string.IsNullOrEmpty(txtPurchasecontractnumber.Text))//
                {
                    errorProvider1.SetError(txtPurchasecontractnumber, "不可为空");
                    isOk = false;
                }
                if (string.IsNullOrEmpty(txtCNumbering.Text))//
                {
                    errorProvider1.SetError(txtCNumbering, "不可为空");
                    isOk = false;
                }
            }
            


            decimal de = 0M;
            if (!string.IsNullOrEmpty(txtFreight.Text) && decimal.TryParse(txtFreight.Text, out de) == false)
            {
                errorProvider1.SetError(txtFreight, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(texdt.Text) && decimal.TryParse(texdt.Text, out de) == false)
            {
                errorProvider1.SetError(texdt, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(texdty.Text) && decimal.TryParse(texdty.Text, out de) == false)
            {
                errorProvider1.SetError(texdty, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(texlx.Text) && decimal.TryParse(texlx.Text, out de) == false)
            {
                errorProvider1.SetError(texlx, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(texlxy.Text) && decimal.TryParse(texlxy.Text, out de) == false)
            {
                errorProvider1.SetError(texlxy, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(txtrebate.Text) && decimal.TryParse(txtrebate.Text, out de) == false)
            {
                errorProvider1.SetError(txtrebate, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(txtPortprice.Text) && decimal.TryParse(txtPortprice.Text, out de) == false)
            {
                errorProvider1.SetError(txtPortprice, "请填写数字");
                isOk = false;
            }
            de = 0M;
            if ( !string . IsNullOrEmpty ( txtMoneyYFK . Text ) && decimal . TryParse ( txtMoneyYFK . Text ,out de ) == false )
            {
                errorProvider1 . SetError ( txtMoneyYFK ,"请填写数字" );
                isOk = false;
            }
            de = 0M;
            if (!string.IsNullOrEmpty(txtoverflow.Text) && decimal.TryParse(txtoverflow.Text, out de) == false)
            {
                errorProvider1.SetError(txtoverflow, "请填写数字");
                isOk = false;
            }
            
            Int64 xs = 0;
            if (!string.IsNullOrEmpty(txtaccountnumber.Text) && Int64.TryParse(txtaccountnumber.Text, out xs) == false)
            {
                errorProvider1.SetError(txtaccountnumber, "请填写数字");
                isOk = false;
            }


            //_head . MoneyYFK = string . IsNullOrEmpty ( txtMoneyYFK . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( txtMoneyYFK . Text ) ,2 );
            //if ( _head . MoneyYFK > _bll . getMoneyYFK ( txtPurchasecontractnumber . Text ) )
            //{
            //    errorProvider1 . SetError ( txtMoneyYFK ,"预付款多余剩余预付款,应为" + _bll . getMoneyYFK ( txtPurchasecontractnumber . Text ) + "" );
            //    isOk = false;
            //}

            if ( isOk == false )
                return isOk;

            _head .code = txtcode.Text;
            _head.supplier = txtsupplier.Text;
            _head.PaymentUnit = txtPaymentUnit.Text;
            _head.DemandSideBank = txtDemandSideBank.Text;
            _head.RequiredAccount = txtRequiredAccount.Text;
            _head.Purchasingunits = txtPurchasingunits.Text;
            if (rabdemand.Checked == true || rabsupplier.Checked == true)
            {

            }
            else
            {
                errorProvider1.SetError(rabdemand, "二选一");
                isOk = false;
            }
            if (txtPurchasingunits.Tag != null)
            {
                _head.PurchasingunitsId = txtPurchasingunits.Tag.ToString();
            }
            else {
                txtPurchasingunits.Tag = string.Empty;
            }
            _head.Purchasingcontacts = txtPurchasingcontacts.Text;
            if (txtPurchasingcontacts.Tag != null)
            {
                _head.PurchasingcontactsId = txtPurchasingcontacts.Tag.ToString();
            }
            else {
                txtPurchasingcontacts.Tag = string.Empty;
            }
            _head.Purchasecontractnumber = txtPurchasecontractnumber.Text;
            if (txtsupplier.Tag != null)
            {
                _head.supplierId = txtsupplier.Tag.ToString();
            }
            else {
                txtsupplier.Tag = string.Empty;
            }
            _head.Numbering = txtNumbering.Text.ToString();
            _head.demand = txtdemand.Text;
            if (txtdemand.Tag != null)
            {
                _head.demandId = txtdemand.Tag.ToString();
            }
            else {
                txtdemand.Tag = string.Empty;
            }
            _head.DemandContact = txtdemandContact.Text;
            if (txtdemandContact.Tag != null)
            {
                _head.DemandContactId = txtdemandContact.Tag.ToString();
            }
            else {
                txtdemandContact.Tag = string.Empty;
            }
            _head.Signplace = txtSignplace.Text;
            _head.SupplierAbbreviation=txtsupplierAbbreviation.Text ;
           _head.DemandAbbreviation =txtdemandAbbreviation.Text;
            _head.SupplierContact = txtsupplierContact.Text;
            if (txtsupplierContact.Tag != null)
            {
                _head.SupplierContactId = txtsupplierContact.Tag.ToString();
            }
            else {
                txtsupplierContact.Tag = string.Empty;
            }
            _head.Signdate = dtpSigndate.Value;
            _head.deIndex = checkdeIndex.Checked == true ? true : false;
            _head.rebateBool = checkrebateBool.Checked == true ? true : false;
            _head.WithSkinbool = checkWithSkinBool.Checked == true ? true : false;
            _head.WithSkinSumbool = checkWithSkinSumbool.Checked == true ? true : false;
            _head.Supplierbool = rabsupplier.Checked == true ? true : false;
            _head.Demandbool = rabdemand.Checked == true ? true : false;
            _head.Dbbool = chedb.Checked == true ? true : false;
            _head.Tvnbool = chetvn.Checked == true ? true : false;
            _head.Zabool = cheza.Checked == true ? true : false;
            _head.Ffabool = cheFFA.Checked == true ? true : false;
            _head.Zfbool = chezf.Checked == true ? true : false;
            _head.Sfbool = chesf.Checked == true ? true : false;
            _head.Shybool = cheshy.Checked == true ? true : false;
            _head.Szbool = chesz.Checked == true ? true : false;
            _head.Cdbbool = checdb.Checked == true ? true : false;
            _head.TvnOnebool = chetvnOne.Checked == true ? true : false;
            _head.Hfbool = chehf.Checked == true ? true : false;
            _head.ZaOnebool = chezaOne.Checked == true ? true : false;
            _head.FfaOnebool = cheffaOne.Checked == true ? true : false;
            _head.ZfOnebool = chezfOne.Checked == true ? true : false;
            _head.SfOnebool = chesfOne.Checked == true ? true : false;

            _head.Supplierbool = rabsupplier.Checked == true ? true : false;
            _head.ShyOnebool = cheshyOne.Checked == true ? true : false;
            _head.SzOnebool = cheszOne.Checked == true ? true : false;
            _head.Informationbool = cheinformation.Checked == true ? true : false;
            _head.rebate = string.IsNullOrEmpty(txtrebate.Text) == true ? 0 : Math.Round(Convert.ToDecimal(txtrebate.Text), 2);
            _head.overflow = string.IsNullOrEmpty(txtoverflow.Text) == true ? 0 : Math.Round(Convert.ToDecimal(txtoverflow.Text),2);
            _head.WithSkin = string.IsNullOrEmpty(txtWithSkin.Text) == true ? string.Empty : txtWithSkin.Text;
            _head.PortpriceBool = checkPortpriceBool.Checked == true ? true : false;
            _head.Stockpilebool = checkStockpilebool.Checked == true ? true : false;
            _head.PortpriceSumBool = checkPortpriceSumbool.Checked == true ? true : false;
            _head.Freightbool = checkFreightbool.Checked == true ? true : false;
            _head.FreightSumbool = checkFreightSumbool.Checked == true ? true : false;
            _head.RebateSumBool = checkrebateSumBool.Checked == true ? true : false;
            _head.Portprice = string.IsNullOrEmpty(txtPortprice.Text) == true ? 0 : Math.Round(Convert.ToDecimal(txtPortprice.Text), 2);
            _head.CountryBool = checkCountryBool.Checked == true ? true : false;
            _head.transport = cmbtransport.Text;
            _head.deadline = dtpDeliveryDeadline.Value;
            _head.Freight = string.IsNullOrEmpty(txtFreight.Text) == true ? 0 : Math.Round(Convert.ToDecimal(txtFreight.Text), 2);
            _head.delivery = texdelivery.Text;
            _head.CNumbering = txtCNumbering.Text;
            _head.dt = string.IsNullOrEmpty(texdt.Text) == true ? 0 : Math.Round(Convert.ToDecimal(texdt.Text), 2);
            _head.dty = string.IsNullOrEmpty(texdty.Text) == true ? 0 : Math.Round(Convert.ToDecimal(texdty.Text), 2);
            _head.lxt = string.IsNullOrEmpty(texlx.Text) == true ? 0 : Math.Round(Convert.ToDecimal(texlx.Text), 2);
            _head.lxty = string.IsNullOrEmpty(texlxy.Text) == true ? 0 : Math.Round(Convert.ToDecimal(texlxy.Text), 2);
           
            _head .Settlementmethod = texSettlementmethod.Text;
            _head.payment = dtppayment.Value;
            _head.Bank = texBank.Text;
            _head.Receipt = txtReceipt.Text;
            _head.accountnumber = txtaccountnumber.Text;
            _head.remart = texRemark.Text;
            _head.transport = cmbtransport.Text;
            _head . RabZy = rabZy . Checked;
            _head . RabZz = rabZz . Checked;

            return isOk;
        }
        public void DataViewOne ( List<FishEntity . SalesRequisitionBodyEntity> modelList )
        {
            dataGridView1 . EndEdit ( );

            foreach ( DataGridViewRow row in dataGridView1 . Rows )
            {
                //if (row.IsNewRow)
                //    continue;
                if (row == null)
                    continue;
                if (row.Cells["product_id"].Value==null)
                {
                    continue;
                }
                _body = new FishEntity.SalesRequisitionBodyEntity();
                _body.code = _head.code;
                _body.NumberingOne = _head.Numbering;
                _body.product_id = row.Cells["product_id"].Value == null ? string.Empty : row.Cells["product_id"].Value.ToString();
                _body . productname = row . Cells [ "productname" ] . Value == null ? string . Empty : row . Cells [ "productname" ] . Value . ToString ( );
                _body . Funit = row . Cells [ "Funit" ] . Value == null ? string . Empty : row . Cells [ "Funit" ] . Value . ToString ( );
                _body . Variety = row . Cells [ "Variety" ] . Value == null ? string . Empty : row . Cells [ "Variety" ] . Value . ToString ( );
                _body . Quantity = row . Cells [ "Quantity" ] . Value == null ? 0 : Math . Round ( decimal . Parse ( row . Cells [ "Quantity" ] . Value . ToString ( ) ) ,2 );
                _body . unitprice = row . Cells [ "unitprice" ] . Value == null ? 0 : Math . Round ( decimal . Parse ( row . Cells [ "unitprice" ] . Value . ToString ( ) ) ,2 );
                _body . Amonut = row . Cells [ "Amonut" ] . Value == null ? 0 : Math . Round ( decimal . Parse ( row . Cells [ "Amonut" ] . Value . ToString ( ) ) ,2 );
                _body . CodeNumZdi = row . Cells [ "codeNumZdi" ] . Value == null ? string.Empty : row . Cells [ "codeNumZdi" ] . Value . ToString ( );
                _body . CodeNumHq = row . Cells [ "codeNumHq" ] . Value == null ? string . Empty : row . Cells [ "codeNumHq" ] . Value . ToString ( );
                modelList . Add ( _body );
            }

            dataGridView2 . EndEdit ( );
            foreach ( DataGridViewRow row in dataGridView2 . Rows )
            {
                if ( row . IsNewRow )
                    continue;
                _body = new FishEntity . SalesRequisitionBodyEntity ( );
                _body . code = _head . code;
                _body . NumberingOne = _head . Numbering;
                _body . product_id = row . Cells [ "product_id_one" ] . Value == null ? string . Empty : row . Cells [ "product_id_one" ] . Value . ToString ( );
                _body = modelList . Find ( ( i ) =>
                    {
                        return i . product_id . Equals ( _body . product_id );
                    } );
                if ( _body == null )
                    break;
                _body . db = row . Cells [ "db" ] . Value == null ? "" : row . Cells [ "db" ] . Value . ToString ( );
                _body . tvn = row . Cells [ "tvn" ] . Value == null ? "" : row . Cells [ "tvn" ] . Value . ToString ( );
                _body . za = row . Cells [ "za" ] . Value == null ? "" : row . Cells [ "za" ] . Value . ToString ( );
                _body . ffa = row . Cells [ "ffa" ] . Value == null ? "" : row . Cells [ "ffa" ] . Value . ToString ( );
                _body . zf = row . Cells [ "zf" ] . Value == null ? "" : row . Cells [ "zf" ] . Value . ToString ( );
                _body . sf = row . Cells [ "sf" ] . Value == null ? "" : row . Cells [ "sf" ] . Value . ToString ( );
                _body . shy = row . Cells [ "shy" ] . Value == null ? "" : row . Cells [ "shy" ] . Value . ToString ( );
                _body . sz = row . Cells [ "sz" ] . Value == null ? "" : row . Cells [ "sz" ] . Value . ToString ( );
            }

            dataGridView3 . EndEdit ( );
            foreach ( DataGridViewRow row in dataGridView3 . Rows )
            {
                _body = new FishEntity . SalesRequisitionBodyEntity ( );
                _body . code = _head . code;
                _body . NumberingOne = _head . Numbering;
                _body . product_id = row . Cells [ "product_id_two" ] . Value == null ? string . Empty : row . Cells [ "product_id_two" ] . Value . ToString ( );
                _body = modelList . Find ( ( i ) =>
                {
                    return i . product_id . Equals ( _body . product_id );
                } );
                if ( _body == null )
                    break;
                _body . cdb = row . Cells [ "cdb" ] . Value == null ? "" : row . Cells [ "cdb" ] . Value . ToString ( );
                _body . tvnOne = row . Cells [ "tvnOne" ] . Value == null ? "" : row . Cells [ "tvnOne" ] . Value . ToString ( );
                _body . hf = row . Cells [ "hf" ] . Value == null ? "" : row . Cells [ "hf" ] . Value . ToString ( );
                _body . ZaOne = row . Cells [ "zaOne" ] . Value == null ? "" : row . Cells [ "zaOne" ] . Value . ToString ( );
                _body . FfaOne = row . Cells [ "ffaOne" ] . Value == null ? "" : row . Cells [ "ffaOne" ] . Value . ToString ( );
                _body . ZfOne = row . Cells [ "zfOne" ] . Value == null ? "" : row . Cells [ "zfOne" ] . Value . ToString ( );
                _body . SfOne = row . Cells [ "sfOne" ] . Value == null ? "" : row . Cells [ "sfOne" ] . Value . ToString ( );
                _body . ShyOne = row . Cells [ "shyOne" ] . Value == null ? "" : row . Cells [ "shyOne" ] . Value . ToString ( );
                _body . SzOne = row . Cells [ "szOne" ] . Value == null ? "" : row . Cells [ "szOne" ] . Value . ToString ( );
            }

            dataGridView4 . EndEdit ( );
            foreach ( DataGridViewRow row in dataGridView4 . Rows )
            {
                _body = new FishEntity . SalesRequisitionBodyEntity ( );
                _body . code = _head . code;
                _body . NumberingOne = _head . Numbering;
                _body . product_id = row . Cells [ "product_id_tre" ] . Value == null ? string . Empty : row . Cells [ "product_id_tre" ] . Value . ToString ( );
                _body = modelList . Find ( ( i ) =>
                {
                    return i . product_id . Equals ( _body . product_id );
                } );
                if ( _body == null )
                    break;
                _body . cm = row . Cells [ "cm" ] . Value == null ? string . Empty : row . Cells [ "cm" ] . Value . ToString ( );
                _body . zjh = row . Cells [ "zjh" ] . Value == null ? string . Empty : row . Cells [ "zjh" ] . Value . ToString ( );
                _body . tdh = row . Cells [ "tdh" ] . Value == null ? string . Empty : row . Cells [ "tdh" ] . Value . ToString ( );
                _body . Country = row . Cells [ "Country" ] . Value == null ? string . Empty : row . Cells [ "Country" ] . Value . ToString ( );
                _body . pp = row . Cells [ "pp" ] . Value == null ? string . Empty : row . Cells [ "pp" ] . Value . ToString ( );
            }
        }
        //取消
        public override void Cancel()
        {
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiAdd.Visible = true;
            tmiModify.Visible = true;
            tmiQuery.Visible = true;
            tmiDelete.Visible = true;
            tmiClose.Visible = true;
            tmiNext.Visible = true;
            tmiPrevious.Visible = true;
            tmiExport.Visible = true;
            tmiReview.Visible = true;

        }
        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dataGridView2);
            row.Cells[2].Value = string.Empty;
            dataGridView2.Rows.Add(row);
            row = new DataGridViewRow();
            row.CreateCells(dataGridView3);
            row.Cells[2].Value = string.Empty;
            dataGridView3.Rows.Add(row);
            row = new DataGridViewRow();
            row.CreateCells(dataGridView4);
            row.Cells[2].Value = string.Empty;
            dataGridView4.Rows.Add(row);
        }
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView2.Rows.Count > 0)
            {
                dataGridView2.Rows.RemoveAt(e.RowIndex);
                dataGridView3.Rows.RemoveAt(e.RowIndex);
                dataGridView4.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("Quantity", StringComparison.OrdinalIgnoreCase) == true || dataGridView1.Columns[e.ColumnIndex].Name.Equals("unitprice", StringComparison.OrdinalIgnoreCase) == true)
            {
                _body = new SalesRequisitionBodyEntity();
                if (dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value != null)
                    _body.Quantity = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value.ToString());
                else
                    _body.Quantity = 0;
                if (dataGridView1.Rows[e.RowIndex].Cells["unitprice"].Value != null)
                    _body.unitprice = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["unitprice"].Value.ToString());
                else
                    _body.unitprice = 0;
                dataGridView1.Rows[e.RowIndex].Cells["amonut"].Value = _body.Quantity * _body.unitprice;
            }
        }        
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex < 0 || e.RowIndex < 0)
            //    return;

            //if (dataGridView4.Columns[e.ColumnIndex].Name.Equals("tdh", StringComparison.OrdinalIgnoreCase) == true)
            //{
            //    FormBilloftable form = new FormBilloftable();
            //    DialogResult result = form.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        bool isOk = true;
            //        FishEntity.BillofladingEntity _model = form.bil;
            //        for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            //        {
            //            if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()))// && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.Code
            //            {
            //                if (i != e.RowIndex)
            //                {
            //                    isOk = false;
            //                    break;
            //                }
            //            }
            //        }
            //        if (isOk == false)
            //            return;
            //        dataGridView4.Rows[e.RowIndex].Cells["cm"].Value = _model.Ferryname;
            //        dataGridView4.Rows[e.RowIndex].Cells["tdh"].Value = _model.Listname;
            //    }
            //}
        }
        private void dataGridView4_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (dataGridView4.Columns[e.ColumnIndex].Name.Equals("Country", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (dataGridView4.Rows[e.RowIndex].Cells["Country"].Value != null && dataGridView4.Rows[e.RowIndex].Cells["Country"].Value.ToString().Trim() != "")
                {
                    string pcode = dataGridView4.Rows[e.RowIndex].Cells["Country"].Value.ToString();
                    FishEntity.DictEntity pModel = InitDataUtil.DictList.Find((i) =>
            {
                return i.code == pcode && i.pcode.Equals(FishEntity.Constant.CountryType);
            });
                    int pid = 0;
                    if (pModel != null)
                    {
                        pid = pModel.id;
                    }

                    List<FishEntity.DictEntity> list = InitDataUtil.DictList.FindAll((i) =>
            {
                return i.pid == pid && i.pcode.Equals(FishEntity.Constant.Brand);
            });
                    if (true)
                    {
                        if (list == null)
                        {
                            list = new List<FishEntity.DictEntity>();
                        }
                        FishEntity.DictEntity empty = new FishEntity.DictEntity();
                        empty.code = "-1";
                        empty.name = "";
                        list.Insert(0, empty);
                    }

                    //pp . DataSource = list;
                    //pp . DisplayMember = "name";

                    if (list != null)
                    {
                        //pp . Items . Clear ( );
                        foreach (FishEntity.DictEntity em in list)
                        {
                            pp.Items.Add(em.name);
                        }
                    }


                }
            }
        }
        private void dataGridView4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dataGridView4_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView4.IsCurrentCellDirty)
            {
                dataGridView4.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        //国别
        private void comCountry_TextChanged(object sender, EventArgs e)
        {
            BindCountryBrand();
        }
        /// <summary>
        /// 无效
        /// </summary>
        #region
        private void BindCountryBrand()
        {
        }
        #endregion
        private void txtsupplier_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtsupplier.Text = form.SelectCompany.fullname;
            txtsupplier.Tag = form.SelectCompany.code;
            txtsupplierContact.Text = form.SelectCompany.linkman;
            txtsupplierContact.Tag = form.SelectCompany.linkmancode;
            texBank.Text = form.SelectCompany.bank;
            txtaccountnumber.Text = form.SelectCompany.account;
            txtReceipt.Text = form.SelectCompany.fullname;
            txtsupplierAbbreviation.Text = form.SelectCompany.shortname;
        }
        private void txtdemand_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtdemand.Text = form.SelectCompany.fullname;
            txtdemand.Tag = form.SelectCompany.code;
            txtdemandContact.Text = form.SelectCompany.linkman;
            txtdemandContact.Tag = form.SelectCompany.linkmancode;
            txtRequiredAccount.Text = form.SelectCompany.account;
            txtPaymentUnit.Text = form.SelectCompany.fullname;
            txtDemandSideBank.Text = form.SelectCompany.bank;
            txtdemandAbbreviation.Text = form.SelectCompany.shortname;
        }
        public string getCode
        {
            get
            {
                return txtcode.Text;
            }
        }
        private void txtcode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        //采购合同
        private void txtPurchasecontractnumber_Click(object sender, EventArgs e)
        {
            //FormPurchaseRequisition from = new FormPurchaseRequisition();
            //from.StartPosition = FormStartPosition.CenterParent;
            //if (from.ShowDialog() != DialogResult.OK)
            //    return;
            //txtPurchasecontractnumber.Text = from.fish.ContractNo;
            //txtPurchasingunits.Text = from.fish.Supplier;
            //txtPurchasingunits.Tag = from.fish.SupplierId;
            //txtPurchasingcontacts.Text = from.fish.Purchasingcontacts;
            //txtPurchasingcontacts.Tag = from.fish.PurchasingcontactsId;
            //FishmealId = from.fish.FishmealId;

            //txtbackDeposit.Text = from.fish.Openbank;
            //txtPayAcount.Text = from.fish.Accountnumber;

            if ( rabZy . Checked == false && rabZz . Checked == false )
            {
                MessageBox . Show ( "请选择自营仓库或自制仓库" );
                return;
            }

            if ( rabZy . Checked )
            {
                FormPriWarehouse form = new FormPriWarehouse ( );
                if ( form . ShowDialog ( ) != DialogResult . OK )
                    return;
                FishEntity . QuotationPriceListEntity model = form . getModel;
                if ( model == null )
                    return;
                txtPurchasecontractnumber . Text = model . CodeNumSales;
                txtCNumbering . Text = model . code;
                txtPurchasingunits.Text = model.unit;
                txtPurchasingcontacts.Text = model.contract;
            }
            else if ( rabZz . Checked )
            {//成品
                FormFinishedInventoryTable form = new FormFinishedInventoryTable( );
                if ( form . ShowDialog ( ) != DialogResult . OK )
                    return;
                FishEntity .FinishedProListEntity _models = form . getModel;
                if ( _models == null )
                    return;
                txtPurchasecontractnumber . Text = _models . CkCode;
                txtCNumbering . Text = _models . code;
            }

            //获取剩余预付款
            //if ( !string . IsNullOrEmpty ( txtPurchasecontractnumber . Text ) )
            //{
            //    txtMoneyYFK . Text = _bll . getMoneyYFK ( txtPurchasecontractnumber . Text ) . ToString ( );
            //}

        }
        private void txtPurchasingcontacts_Click(object sender, EventArgs e)
        {

        }
        private void txtPurchasingunits_Click(object sender, EventArgs e)
        {

        }
        private void checkrebateSumBool_Click(object sender, EventArgs e)
        {
            if (checkrebateSumBool.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtrebate.Text.ToString() != "" && txtrebate.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) + (decimal.Parse(txtrebate.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) + decimal.Parse(txtrebate.Text.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtrebate.Text.ToString() != "" && txtrebate.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) - (decimal.Parse(txtrebate.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) - decimal.Parse(txtrebate.Text.ToString());
                    }
                }
            }
        }
        private void checkFreightSumbool_Click(object sender, EventArgs e)
        {
            if (checkFreightSumbool.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtFreight.Text.ToString() != "" && txtFreight.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) + (decimal.Parse(txtFreight.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) + decimal.Parse(txtFreight.Text.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtFreight.Text.ToString() != "" && txtFreight.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) - (decimal.Parse(txtFreight.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) - decimal.Parse(txtFreight.Text.ToString());
                    }
                }
            }
        }
        private void checkPortpriceSumbool_Click(object sender, EventArgs e)
        {
            checkPortpriceSumbool.Checked = false;
            if (checkPortpriceSumbool.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtPortprice.Text.ToString() != "" && txtPortprice.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) + (decimal.Parse(txtPortprice.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) + decimal.Parse(txtPortprice.Text.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtPortprice.Text.ToString() != "" && txtPortprice.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) + (decimal.Parse(txtPortprice.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) - decimal.Parse(txtPortprice.Text.ToString());
                    }
                }
            }
        }
        private void checkWithSkinSumbool_Click(object sender, EventArgs e)
        {
            if (checkWithSkinSumbool.Checked == true)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtWithSkin.Text.ToString() != "" && txtWithSkin.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) + (decimal.Parse(txtWithSkin.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) + decimal.Parse(txtWithSkin.Text.ToString());
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells["amonut"].Value != null && dataGridView1.Rows[i].Cells["amonut"].Value.ToString() != "" && txtWithSkin.Text.ToString() != "" && txtWithSkin.Text != "")
                    {
                        dataGridView1.Rows[i].Cells["amonut"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["amonut"].Value.ToString()) + (decimal.Parse(txtWithSkin.Text.ToString()) * decimal.Parse(dataGridView1.Rows[i].Cells["Quantity"].Value.ToString()));
                        dataGridView1.Rows[i].Cells["unitprice"].Value = decimal.Parse(dataGridView1.Rows[i].Cells["unitprice"].Value.ToString()) - decimal.Parse(txtWithSkin.Text.ToString());
                    }
                }
            }
        }
        public string getCodes
        {
            get
            {
                return txtNumbering . Text;
            }
        }
        private void txtNumbering_DoubleClick ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtNumbering . Text ) )
                return;
            _head . Numbering = txtNumbering . Text;
            _head . code = txtcode . Text;

            this . DialogResult = DialogResult . OK;
        }
        public SalesRequisitionEntity getMo
        {
            get
            {
                return _head;
            }
        }
        FishEntity.ReturnReceiptEntity _model=null;
        public ReturnReceiptEntity getModel
        {
            get
            {
                return _model;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            isOk = true;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("product_id", StringComparison.OrdinalIgnoreCase) == true)
            {
                //if (rabZz.Checked == false && rabZy.Checked == false)
                //{
                //    MessageBox.Show("请选择数据来源是自定义标准表或者行情定价单");
                //    return;
                //}
                if (rabZdi.Checked)
                {
                    FormCustomStandardTable form = new FormCustomStandardTable();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    FishEntity.CustomStandardTableEntity _model = form.getModel;
                    if (_model == null)
                        return;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()) && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.fishId)
                        {
                            if (i != e.RowIndex)
                            {
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if (isOk == false)
                        return;
                    dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = _model.level;
                    dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = _model.fishId; 
                    dataGridView1.Rows[e.RowIndex].Cells["productname"].Value = "鱼粉";
                    dataGridView1.Rows[e.RowIndex].Cells["codeNumZdi"].Value = _model.code;
                    dataGridView2.Rows[e.RowIndex].Cells["db"].Value = _model.protein;
                    dataGridView2.Rows[e.RowIndex].Cells["shy"].Value = _model.shy;
                    dataGridView2.Rows[e.RowIndex].Cells["tvn"].Value = _model.TVN;
                    dataGridView2.Rows[e.RowIndex].Cells["ffa"].Value = _model.ffa;

                    dataGridView2.Rows[e.RowIndex].Cells["za"].Value = _model.histamine;
                    dataGridView2.Rows[e.RowIndex].Cells["zf"].Value = _model.fat;
                    dataGridView2.Rows[e.RowIndex].Cells["sf"].Value = _model.water;
                    dataGridView2.Rows[e.RowIndex].Cells["product_id_one"].Value = _model.fishId;
                    dataGridView3.Rows[e.RowIndex].Cells["product_id_two"].Value = _model.fishId;
                    dataGridView4.Rows[e.RowIndex].Cells["product_id_tre"].Value = _model.fishId;

                    dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = _model.level;
                    dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = _model.fishId;
                }
                else if (rabHq.Checked)
                {
                    FormQuotePricingTable form = new FormQuotePricingTable();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    FishEntity.QuotationPriceListEntity _model = form.getModel;
                    if (_model == null)
                        return;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()) && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.fishId)
                        {
                            if (i != e.RowIndex)
                            {
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if (isOk == false)
                        return;
                    dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = _model.qualitySpe;
                    dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = _model.fishId;
                    dataGridView2.Rows[e.RowIndex].Cells["product_id_one"].Value = _model.fishId;
                    dataGridView3.Rows[e.RowIndex].Cells["product_id_two"].Value = _model.fishId;
                    dataGridView4.Rows[e.RowIndex].Cells["product_id_tre"].Value = _model.fishId;
                    dataGridView1.Rows[e.RowIndex].Cells["codeNumHq"].Value = _model.code;
                    dataGridView2.Rows[e.RowIndex].Cells["db"].Value = _model.protein;
                    dataGridView2.Rows[e.RowIndex].Cells["tvn"].Value = _model.tvn;
                    dataGridView2.Rows[e.RowIndex].Cells["ffa"].Value = _model.FFA;

                    dataGridView2.Rows[e.RowIndex].Cells["za"].Value = _model.histamine;
                    dataGridView3.Rows[e.RowIndex].Cells["hf"].Value = _model.ash;
                    dataGridView4.Rows[e.RowIndex].Cells["Country"].Value = _model.country;
                    dataGridView4.Rows[e.RowIndex].Cells["pp"].Value = _model.brand;

                    DataTable dt = _happbll.getTable(_model.fishId, _model.code);
                    if (dt == null || dt.Rows.Count < 1)
                        return;

                    _model.fishId = dt.Rows[0]["name"].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells["productname"].Value = _model.fishId;
                    _model.fishId = dt.Rows[0]["price"].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells["unitprice"].Value = _model.fishId;
                    _model.fishId = dt.Rows[0]["weight"].ToString();
                    dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value = _model.fishId;
                    _model.protein = dt.Rows[0]["protein"].ToString();
                    dataGridView2.Rows[e.RowIndex].Cells["db"].Value = _model.protein;
                    _model.tvn = dt.Rows[0]["tvn"].ToString();
                    dataGridView2.Rows[e.RowIndex].Cells["tvn"].Value = _model.tvn;
                    _model.histamine = dt.Rows[0]["histamine"].ToString();
                    dataGridView2.Rows[e.RowIndex].Cells["za"].Value = _model.histamine;
                    _model.protein = dt.Rows[0]["domestic_protein"].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["cdb"].Value = _model.protein;
                    _model.tvn = dt.Rows[0]["domestic_tvn"].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["tvnOne"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["domestic_graypart"].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["hf"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["domestic_amine"].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["zaOne"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["domestic_fat"].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["zfOne"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["domestic_sandsalt"].ToString();
                    dataGridView3.Rows[e.RowIndex].Cells["shyOne"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["shipno"].ToString();
                    dataGridView4.Rows[e.RowIndex].Cells["cm"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["cornerno"].ToString();
                    dataGridView4.Rows[e.RowIndex].Cells["zjh"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["billofgoods"].ToString();
                    dataGridView4.Rows[e.RowIndex].Cells["tdh"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["country"].ToString();
                    dataGridView4.Rows[e.RowIndex].Cells["Country"].Value = _model.tvn;
                    _model.tvn = dt.Rows[0]["brand"].ToString();
                    dataGridView4.Rows[e.RowIndex].Cells["pp"].Value = _model.tvn;
                }

                //FormPurchaseRequisition from = new FormPurchaseRequisition();
                //DialogResult result = from.ShowDialog();
                //if (result == DialogResult.OK)
                //{
                //    bool isOk = true;
                //    FishEntity.PurchaseRequisitionEntity _model = from.fish;
                //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                //    {
                //        if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()) && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.FishmealId)
                //        {
                //            if (i != e.RowIndex)
                //            {
                //                isOk = false;
                //                break;
                //            }
                //        }
                //    }
                //    if (isOk == false)
                //        return;
                //    dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = _model.FishmealId;
                //    dataGridView1.Rows[e.RowIndex].Cells["productname"].Value = _model.Variety;
                //    //dataGridView1.Rows[e.RowIndex].Cells["Variety"].Value = _model.specification;
                //    dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = _model.Country + _model.Specification;

                //    dataGridView2.Rows[e.RowIndex].Cells["db"].Value = _model.Protein;
                //    dataGridView2.Rows[e.RowIndex].Cells["tvn"].Value = _model.TVN;
                //    dataGridView2.Rows[e.RowIndex].Cells["shy"].Value = _model.SandAndSalt;
                //    dataGridView2.Rows[e.RowIndex].Cells["za"].Value = _model.Histamine;
                //    dataGridView2.Rows[e.RowIndex].Cells["ffa"].Value = _model.FFA;
                //    dataGridView2.Rows[e.RowIndex].Cells["zf"].Value = _model.Fat;
                //    dataGridView2.Rows[e.RowIndex].Cells["sf"].Value = _model.Moisture;
                //    dataGridView2.Rows[e.RowIndex].Cells["sz"].Value = _model.Sand;

                //    dataGridView2.Rows[e.RowIndex].Cells["product_id_one"].Value = _model.FishmealId;
                //    dataGridView3.Rows[e.RowIndex].Cells["product_id_two"].Value = _model.FishmealId;
                //    dataGridView4.Rows[e.RowIndex].Cells["product_id_tre"].Value = _model.FishmealId;
                //    dataGridView4.Rows[e.RowIndex].Cells["Country"].Value = _model.Country;
                //    dataGridView4.Rows[e.RowIndex].Cells["pp"].Value = _model.Brand;
                //    dataGridView4.Rows[e.RowIndex].Cells["tdh"].Value = _model.BillOfLadingNumber;
                //    dataGridView4.Rows[e.RowIndex].Cells["cm"].Value = _model.NameOfTheShip;
                //    txtPurchasecontractnumber.Text = _model.ContractNo;
                //    txtPurchasingunits.Text = _model.Supplier;
                //    txtPurchasingunits.Tag = _model.SupplierId;
                //    txtPurchasingcontacts.Text = _model.Purchasingcontacts;
                //    txtPurchasingcontacts.Tag = _model.PurchasingcontactsId;
                //    txtCNumbering.Text = _model.Numbering;
                //    FishmealId = _model.FishmealId;
                //dataGridView4.Rows[e.RowIndex].Cells["zjh"].Value = _model.cornerno;
                //}
            }
        }
        private void dataGridView1_CellDoubleClick ( object sender ,DataGridViewCellEventArgs e )
        {
            if ( e . ColumnIndex < 0 || e . RowIndex < 0 )
                return;
            isOk = true;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("productname", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (rabZz.Checked == false && rabZy.Checked == false)
                {
                    MessageBox.Show("请选择数据来源是成品出库或者自营仓库");
                    return;
                }
                if (rabZz.Checked)
                {
                    FormNewFinish form = new FormNewFinish();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    FishEntity.ProductQuoteVo _model = form.getModel;
                    if (_model == null)
                        return;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()) && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.code)
                        {
                            if (i != e.RowIndex)
                            {
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if (isOk == false)
                        return;
                    dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = _model.code;

                    dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = _model.specification;
                    dataGridView1.Rows[e.RowIndex].Cells["productname"].Value = "鱼粉";
                    dataGridView1.Rows[e.RowIndex].Cells["Quantity"].Value = _model.finisheWeight;
                    dataGridView3.Rows[e.RowIndex].Cells["cdb"].Value = _model.domestic_protein;
                    dataGridView3.Rows[e.RowIndex].Cells["tvnOne"].Value = _model.domestic_ffa;
                    dataGridView3.Rows[e.RowIndex].Cells["zaOne"].Value = _model.domestic_amine;
                    dataGridView3.Rows[e.RowIndex].Cells["zfOne"].Value = _model.domestic_fat;
                    dataGridView3.Rows[e.RowIndex].Cells["hf"].Value = _model.domestic_graypart;
                    dataGridView3.Rows[e.RowIndex].Cells["ffaOne"].Value = _model.domestic_ffa;
                    dataGridView3.Rows[e.RowIndex].Cells["shyOne"].Value = _model.domestic_sandsalt;
                    
                    dataGridView2.Rows[e.RowIndex].Cells["product_id_one"].Value = _model.code;
                    dataGridView3.Rows[e.RowIndex].Cells["product_id_two"].Value = _model.code;
                    dataGridView4.Rows[e.RowIndex].Cells["product_id_tre"].Value = _model.code;
                    txtCNumbering.Text = _model.codeNum;
                    txtPurchasecontractnumber.Text = _model.codeNumContract;

                    dataGridView4.Rows[e.RowIndex].Cells["Country"].Value = _model.nature;
                    dataGridView4.Rows[e.RowIndex].Cells["pp"].Value = _model.brand;

                    //txtPurchasingunits.Text = _model.supplier;
                    //txtPurchasingcontacts.Text = _model.Supplieruser;
                }
                else if (rabZy.Checked)
                {
                    FormNewPriWarehouse form = new FormNewPriWarehouse();
                    if (form.ShowDialog() != DialogResult.OK)
                        return;
                    FishEntity.ProductQuoteVo _model = form.getModel;
                    if (_model == null)
                        return;
                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        if (!string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["product_id"].Value.ToString()) && dataGridView1.Rows[i].Cells["product_id"].Value.ToString() == _model.code)
                        {
                            if (i != e.RowIndex)
                            {
                                isOk = false;
                                break;
                            }
                        }
                    }
                    if (isOk == false)
                        return;

                    dataGridView1.Rows[e.RowIndex].Cells["product_id"].Value = _model.code;

                    dataGridView1.Rows[e.RowIndex].Cells["Funit"].Value = _model.specification;
                    dataGridView2.Rows[e.RowIndex].Cells["product_id_one"].Value = _model.code;
                    dataGridView2.Rows[e.RowIndex].Cells["db"].Value = _model.sgs_protein;
                    dataGridView2.Rows[e.RowIndex].Cells["tvn"].Value = _model.sgs_tvn;
                    dataGridView2.Rows[e.RowIndex].Cells["za"].Value = _model.sgs_amine;
                    dataGridView2.Rows[e.RowIndex].Cells["ffa"].Value = _model.sgs_ffa;
                    dataGridView2.Rows[e.RowIndex].Cells["zf"].Value = _model.sgs_fat;
                    dataGridView2.Rows[e.RowIndex].Cells["sf"].Value = _model.sgs_water;
                    dataGridView2.Rows[e.RowIndex].Cells["shy"].Value = _model.sgs_sandsalt;

                    dataGridView3.Rows[e.RowIndex].Cells["cdb"].Value = _model.domestic_protein;
                    dataGridView3.Rows[e.RowIndex].Cells["tvnOne"].Value = _model.domestic_tvn;
                    dataGridView3.Rows[e.RowIndex].Cells["hf"].Value = _model.domestic_graypart;
                    dataGridView3.Rows[e.RowIndex].Cells["zaOne"].Value = _model.domestic_amine;
                    dataGridView3.Rows[e.RowIndex].Cells["zfOne"].Value = _model.domestic_fat;
                    dataGridView3.Rows[e.RowIndex].Cells["shyOne"].Value = _model.domestic_sandsalt;
                    dataGridView3.Rows[e.RowIndex].Cells["product_id_two"].Value = _model.code;

                    dataGridView4.Rows[e.RowIndex].Cells["product_id_tre"].Value = _model.code;
                    dataGridView4.Rows[e.RowIndex].Cells["cm"].Value = _model.shipno;
                    dataGridView4.Rows[e.RowIndex].Cells["zjh"].Value = _model.cornerno;
                    dataGridView4.Rows[e.RowIndex].Cells["tdh"].Value = _model.billofgoods;
                    dataGridView4.Rows[e.RowIndex].Cells["Country"].Value = _model.nature;
                    dataGridView4.Rows[e.RowIndex].Cells["pp"].Value = _model.brand;
                    txtCNumbering.Text = _model.codeNum;
                    txtPurchasecontractnumber.Text = _model.codeNumContract;
                    txtPurchasingunits.Text = _model.supplier;
                    txtPurchasingcontacts.Text = _model.Supplieruser;
                }

                //this.DialogResult = DialogResult.OK;
            }
        }
        private void rabZdi_Click(object sender, EventArgs e)
        {
            if (rabZdi.Checked==true)
            {
                //rabZz.Checked = true;
            }
        }
        private void rabHq_Click(object sender, EventArgs e)
        {
            if (rabHq.Checked == true)
            {
                //rabZy.Checked = true;
            }
        }
        private void rabZy_Click(object sender, EventArgs e)
        {
            if (rabZy.Checked == true)
            {
                //rabHq.Checked = true;
            }
        }
        private void rabZz_Click(object sender, EventArgs e)
        {
            if (rabZz.Checked == true)
            {
                //rabZdi.Checked = true;
            }
        }
        private void txtPurchasingunits_Click_1(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtPurchasingunits.Text = form.SelectCompany.fullname;
            txtPurchasingunits.Tag = form.SelectCompany.code;
            txtPurchasingcontacts.Text = form.SelectCompany.linkman;
            txtPurchasingcontacts.Tag = form.SelectCompany.linkmancode;
        }
        private void txtPurchasingcontacts_Click_1(object sender, EventArgs e)
        {

        }

        private void txtrebate_TextChanged ( object sender ,EventArgs e )
        {

        }

        private void chesupplier_Click(object sender, EventArgs e)
        {

        }

        private void chedemand_Click(object sender, EventArgs e)
        {

        }

        private void rabdemand_Click(object sender, EventArgs e)
        {
            if (rabdemand.Checked == true)
            {
                txtcode.Text = string.Empty;
            }
        }

        private void rabsupplier_Click(object sender, EventArgs e)
        {
            if (rabsupplier.Checked == true)
            {
                codeNum();
            }
        }
    }
}