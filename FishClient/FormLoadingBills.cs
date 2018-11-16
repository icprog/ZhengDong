using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    /// <summary>
    /// 提货单
    /// </summary>
    public partial class FormLoadingBills : FormMenuBase
    {
        protected FishBll.Bll.LoadingBillsBll _bll = new FishBll.Bll.LoadingBillsBll();
        protected FishEntity.LoadingBillsEntity _entity = null;
        protected string _where = string.Empty;

        public FormLoadingBills()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_L oadingBills");
            //tmiExport.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;

            dataGridView1.BackgroundColor = this.BackColor;
            
            UIControls.ToolStripMenuItemEx tmiPrint = new UIControls.ToolStripMenuItemEx();
            tmiPrint.Text = "打印";
            tmiPrint.FunCode = "50";
            tmiPrint.Name = "tmiPrint";
            tmiPrint.Click += tmiPrint_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiPrint);
        }

        void tmiPrint_Click(object sender, EventArgs e)
        {
            if (_entity == null) return;

            FishBll.Bll.LoadingDetailBll detailBll= new FishBll.Bll.LoadingDetailBll();
            List<FishEntity.LoadingDetailEntity> details = detailBll.GetDetailOfBill ( _entity.id );

            PrintUtil.PrintLoadingBills(_entity, details);
        }
        
        public override int Query()
        {
            //TODO

            QueryOne(">", " order by id asc limit 1");
            return 1;
        }

        public override void Previous()
        {
            QueryOne(" < ", " order by id desc limit 1");
        }

        public override void Next()
        {
            QueryOne(" > ", " order by id asc limit 1");
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

            if (_entity != null)
            {
                whereEx += " and code " + operate + _entity.code;
            }

            List<FishEntity.LoadingBillsEntity> list = _bll.GetModelList(whereEx + orderBy);
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("已经没有记录了!");
                return;
            }

            _entity = list[0];

            SetEntity();
            SetDetail();
        }

        protected void SetEntity()
        {
            if (_entity == null) return;

            txtCode.Text = _entity.code;
            txtCompany.Text = _entity.company;
            txtCompanyCode.Text = _entity.companycode;
            txtCompanyCode.Tag = _entity.companyid;

            txtMan.Text = _entity.billman;
            txtMan.Tag = _entity.billmanid;
            txtSignDate.Text = _entity.signdate.Value.ToString("yyy-MM-dd HH:mm:ss");
            txtStorage.Text = _entity.warehouse;
            txtStorageFee.Text = _entity.storagefee.ToString();                
        }
        
        protected bool Check()
        {
            errorProvider1.Clear();
           
            bool isok = true;
            if (string.IsNullOrEmpty(txtCompany.Text))
            {
                errorProvider1.SetError(txtCompany, "请选择提货单位。");
                isok = false;
            }

            decimal fee=0;
            if (false == string.IsNullOrEmpty(txtStorageFee.Text))
            {
                if (false == decimal.TryParse(txtStorageFee.Text, out fee))
                {
                    isok = false;
                    errorProvider1.SetError(txtStorageFee, "请输入正确的数字。");
                }
            }

            dataGridView1.EndEdit();

            if (dataGridView1.Rows.Count < 1)
            {
                isok = false;
                errorProvider1.SetError(dataGridView1,"请输入明细。");
            }

            bool hasrows=false;
            bool numisok = true ;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }
                else
                {
                    hasrows = true;
                    if (row.Cells["contractnoseq"].Value == null|| string.IsNullOrEmpty( row.Cells["contractnoseq"].Value.ToString()) )
                    {
                        row.Cells["contractnoseq"].ErrorText = "请选择合同中的鱼粉";
                        numisok = false;
                    }
                    decimal w = 0;
                    if (row.Cells["tons"].FormattedValue != null)
                    {
                        decimal.TryParse(row.Cells["tons"].FormattedValue.ToString(), out w);
                        if (w <= 0)
                        {
                            row.Cells["tons"].ErrorText = "请输入正确的吨位";
                            numisok  = false;
                        }
                    }
                    else
                    {
                        row.Cells["tons"].ErrorText = "请输入吨位";
                        numisok = false;
                    }
                }
            }

            if (hasrows==false)
            {
                MessageBox.Show("请选择需要提取的鱼粉");
                isok = false;
            }
            if (numisok == false)
            {
                isok = false;
            }

            return isok;
        }

        protected void GetEntity()
        {
            if (_entity == null) return;

            _entity.company = txtCompany.Text;
            _entity.companycode = txtCompanyCode.Text;
            int cid = 0;
            if (txtCompanyCode.Tag != null)
            {
                int.TryParse(txtCompanyCode.Tag.ToString(), out cid);
            }

            _entity.companyid = cid;

            decimal fee =0;
            decimal.TryParse(txtStorageFee.Text, out fee);
            _entity.storagefee = fee;
            _entity.warehouse = txtStorage.Text.Trim();


        }

        protected List<FishEntity.LoadingDetailEntity> GetDetails( int billId)
        {
            dataGridView1.EndEdit();

            List<FishEntity.LoadingDetailEntity> listNews = new List<FishEntity.LoadingDetailEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.LoadingDetailEntity product = new FishEntity.LoadingDetailEntity();
                product.billofgoods = row.Cells["billofgoods"].Value == null ? string.Empty : row.Cells["billofgoods"].Value.ToString().Trim();
                product.mid = billId;

                int did = 0;
                if (row.Cells["id"].Value != null)
                {
                    int.TryParse(row.Cells["id"].Value.ToString(), out did);
                }
                product.id = did;

                int packageInt = 0;

                if (row.Cells["packages"].Value != null)
                {
                    int.TryParse(row.Cells["packages"].Value.ToString(), out packageInt);
                }
                product.packages = packageInt;

                product.product = row.Cells["productname"].Value == null ? string.Empty : row.Cells["productname"].Value.ToString();
                product.productcode = row.Cells["code"].Value == null ? string.Empty : row.Cells["code"].Value.ToString();
                int pid = 0;
                if (row.Cells["productid"].Value != null)
                {
                    int.TryParse(row.Cells["productid"].Value.ToString(), out pid);
                }
                product.productid = pid;
                product.remark = row.Cells["remark"].Value == null ? string.Empty : row.Cells["remark"].Value.ToString();
                product.shipname = row.Cells["shipno"].Value == null ? string.Empty : row.Cells["shipno"].Value.ToString();
                product.specification = row.Cells["specification"].Value == null ? string.Empty : row.Cells["specification"].Value.ToString();
                decimal tonsDec = 0;
                if (row.Cells["tons"].Value != null)
                {
                    decimal.TryParse(row.Cells["tons"].Value.ToString(), out tonsDec);
                }
                product.tons = tonsDec;

                decimal unitpriceDec = 0.00M;
                if (row.Cells["unitprice"].Value != null)
                {
                    decimal.TryParse(row.Cells["unitprice"].Value.ToString(), out unitpriceDec);
                }
                product.unitprice = unitpriceDec;


                int contractid = 0;
                if (row.Cells["contractid"].Value != null)
                {
                    int.TryParse(row.Cells["contractid"].Value.ToString(), out contractid);
                }
                product.contractid = contractid;

                //product.contractno = row.Cells["contractno"].Value.ToString();

                int no = 0;
                if (row.Cells["no"].Value != null)
                {
                    int.TryParse(row.Cells["no"].Value.ToString(), out no);
                }
                product.contractseq = no;

                int detailid = 0;
                if (row.Cells["contractdetailid"].Value != null)
                {
                    int.TryParse(row.Cells["contractdetailid"].Value.ToString(), out detailid);
                }
                product.contractdetailid = detailid;

                listNews.Add(product);
            }

            return listNews;
        }

        protected void AddProducts(int billId , bool isAdd)
        {
            List<FishEntity.LoadingDetailEntity> listNews = GetDetails(billId);
            List<FishEntity.LoadingDetailEntity> listsource =null;
            FishBll.Bll.LoadingDetailBll detailBll = new FishBll.Bll.LoadingDetailBll();
            FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();

            if (isAdd == false)
            {
                listsource = detailBll.GetDetailOfBill( billId );
                if (listsource != null)
                {
                    foreach ( FishEntity.LoadingDetailEntity item in listsource)
                    {
                        bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                        if (isExist == false)
                        {
                            UpdateProductCount(item.productid , -item.tons, -item.packages );
                            UpdateContract(item.contractid, item.contractdetailid , -item.tons,-item.packages);
                            bool isDelte = detailBll.Delete( item.id);
                        }
                    }
                }
            }

            foreach (FishEntity.LoadingDetailEntity item in listNews)
            {
                if (  item.id == 0 )
                {                        
                    int detailId = detailBll.Add(item);
                    if (detailId > 0)
                    {
                        UpdateProductCount(item.productid, -item.tons , -item.packages );
                        UpdateContract(item.contractid, item.contractdetailid, item.tons, item.packages);
                        item.id = detailId;
                    }
                }
                else
                {
                     decimal sWeight =0;
                     int sPackage =0;
                    if( listsource !=null )
                    {
                        FishEntity.LoadingDetailEntity sRecord = listsource.Find ( (i)=>{return i.id == item.id; });
                        if( sRecord !=null )
                        {
                            sWeight = sRecord.tons;
                            sPackage = sRecord.packages;
                        }
                    }

                    decimal dWeight = item.tons;
                    int dPackage = item.packages ;

                    decimal weight = dWeight - sWeight;
                    int package = dPackage - sPackage;

                    UpdateProductCount(item.productid, weight, package);
                    UpdateContract(item.contractid, item.contractdetailid, weight, package);

                    detailBll.Update(item);
                }
            }

            SetDetail(listNews);
        }

        protected void SetDetail()
        {
            int mid = _entity.id;
            FishBll.Bll.LoadingDetailBll detailbll = new FishBll.Bll.LoadingDetailBll();
            List<FishEntity.LoadingDetailEntity> details = detailbll.GetDetailOfBill(mid);
            SetDetail(details);
        }

        protected void SetDetail(List<FishEntity.LoadingDetailEntity> products )
        {
            dataGridView1.Rows.Clear();
            if (products == null || products.Count < 1) return;
            foreach ( FishEntity.LoadingDetailEntity item in products)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["id"].Value = item.id;
                row.Cells["productname"].Value = item.product;
                row.Cells["code"].Value = item.productcode;
                row.Cells["productid"].Value = item.productid;
                row.Cells["billofgoods"].Value = item.billofgoods;
                row.Cells["packages"].Value = item.packages;
                row.Cells["remark"].Value = item.remark;
                row.Cells["shipno"].Value = item.shipname;
                row.Cells["specification"].Value = item.specification;
                row.Cells["tons"].Value = item.tons;
                row.Cells["unitprice"].Value = item.unitprice;
                row.Cells["tons"].Value = item.tons;
                row.Cells["packages"].Value = item.packages; 

                row.Cells["contractid"].Value = item.contractid;
                row.Cells["contractno"].Value = item.contractno;
                row.Cells["no"].Value = item.contractseq;
                row.Cells["contractdetailid"].Value = item.contractdetailid;
                row.Cells["contractnoseq"].Value = item.contractno + item.contractseq;
                row.Cells["contractweight"].Value = item.contractweight;
                row.Cells["contractquantity"].Value = item.contractquantity;
                row.Cells["getweight"].Value = item.getweight;
                row.Cells["getquantity"].Value = item.getquantity;

            }
        }
        
        public override void Save()
        {
            if (Check() == false) return ;

            _entity = new FishEntity.LoadingBillsEntity();
           
            GetEntity();

            _entity.signdate = DateTime.Now;
            _entity.billmanid = FishEntity.Variable.User.id;
            _entity.billman = FishEntity.Variable.User.username;
            _entity.createman = FishEntity.Variable.User.username;
            _entity.createtime = DateTime.Now;
            _entity.modifyman = _entity.createman;
            _entity.modifytime = _entity.createtime;

            _entity.code = FishBll.Bll.SequenceUtil.GetLoadingBillSequence();
            while (_bll.Exists(_entity.code))
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetLoadingBillSequence();
            }

            int id = _bll.Add(_entity);
            if (id > 0)
            {
                AddProducts(id, true);

                _entity.id = id;
                txtCode.Text = _entity.code;
                txtSignDate.Text = _entity.signdate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                txtMan.Text = _entity.billman;
                txtMan.Tag = _entity.billmanid;

                //tmiCancel.Visible = false;
                //tmiSave.Visible = false;
                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                //tmiDelete.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiNext.Visible = true;
                ControlButtomRoles();

                MessageBox.Show("新增成功。");
            }   
            else
            {
                MessageBox.Show("新增失败。");
            }

            return;
        }

        public override int Add()
        {
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiDelete.Visible = false;
            tmiAdd.Visible = false;
            tmiModify.Visible = false;

            ClearText();

            return 1;
        }

        public override void Cancel()
        {
            //tmiModify.Visible = true;
            //tmiAdd.Visible = true;
            //tmiDelete.Visible = true;
            //tmiQuery.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            ControlButtomRoles();
        }

        public override int Modify()
        {
            if (_entity == null)
            {
                MessageBox.Show("请查询,在操作");
                return 0;
            }
            if (Check() == false) return 0;

            GetEntity();
                      

            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = DateTime.Now;

            bool isok =_bll.Update(_entity);
            if (isok)
            {
                AddProducts( _entity.id , false );

                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }


            return 1;
        }

        protected void UpdateProductCount( int productId , decimal weight , int quanity )
        {
            //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
            //FishEntity.ProductEntity product = productBll.GetModel(productId);
            //if (product.state == FishEntity.Constant.STATE_SELFMAKE.ToString())
            //{
            //    productBll.UpdateHomemadeWeightQuantity(productId, weight, quanity);
            //}
            //else
            //{
            //    productBll.UpdateRemainWeightQuantity(productId, weight, quanity); 
            //}


            FishBll.Bll.ProductExBll productexbll = new FishBll.Bll.ProductExBll();
            productexbll.UpdateSaleInfo(productId, weight, quanity);
        }

        protected void UpdateContract(int contractid, int detailid, decimal weight, int quantity)
        {
            FishBll.Bll.ContractDetailBll bll = new FishBll.Bll.ContractDetailBll();
           bool isok = bll.UpdateContractWeight(contractid, detailid, weight, quantity);
        }

        public override int Delete()
        {
            if (_entity == null) return 0;

            string msg = string.Format("你确定要删除提货单号为【{0}】的记录吗?", _entity.code);
            if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return 0;

            _bll.Delete(_entity.id);
            FishBll.Bll.LoadingDetailBll detailbll = new FishBll.Bll.LoadingDetailBll();
            List<FishEntity.LoadingDetailEntity> details = detailbll.GetDetailOfBill(_entity.id);
            if (details != null)
            {
                FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                foreach (FishEntity.LoadingDetailEntity item in details)
                {
                    //FishEntity.ProductEntity product = productBll.GetModel(item.productid);
                    //if (product == null) continue;
                    //if (product.state == FishEntity.Constant.STATE_SELFMAKE.ToString ())
                    //{
                    //    productBll.UpdateHomemadeWeightQuantity(item.productid , item.tons, item.packages );
                    //}
                    //else
                    //{
                    //    productBll.UpdateRemainWeightQuantity(item.productid , item.tons, item.packages);
                    //}

                    FishBll.Bll.ProductExBll productexbll = new FishBll.Bll.ProductExBll();
                    productexbll.UpdateSaleInfo(item.productid, -item.tons, -item.packages);
                    FishBll.Bll.ContractDetailBll contractdetailbll = new FishBll.Bll.ContractDetailBll();
                    contractdetailbll.UpdateContractWeight(item.contractid, item.contractdetailid, -item.tons, -item.packages);
                }
            }
            detailbll.DeleteByMid(_entity.id);

            ClearText();

            Query();

            return 1;
        }

        protected void ClearText()
        {
            errorProvider1.Clear();
            txtCode.Text = string.Empty;
            txtCompany.Text = string.Empty;
            txtCompanyCode.Text = string.Empty;
            txtCompanyCode.Tag = string.Empty;
            txtMan.Text = string.Empty;
            txtMan.Tag = string.Empty;
            txtSignDate.Text = string.Empty;
            txtStorage.Text = string.Empty;
            txtStorageFee.Text = string.Empty;
            dataGridView1.Rows.Clear();
            _entity = null;
        }

        private void txtCompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;      
            txtCompany.Text = form.SelectCompany.fullname;
            txtCompanyCode.Text = form.SelectCompany.code;
            txtCompanyCode.Tag = form.SelectCompany.id;         
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("operate", StringComparison.OrdinalIgnoreCase))
            {
                //SelectFish( e.RowIndex );
                SelectContract(e.RowIndex);
            }
            //else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("contractno", StringComparison.OrdinalIgnoreCase))
            //{
                //SelectContract ( e.RowIndex );
            //}
        }

        private void SelectContract(int rowidx)
        {
            Contract.FormContractList form = new Contract.FormContractList();
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            dataGridView1.Rows[rowidx].Cells["contractid"].Value = form.SelectedProduct.contractid;
            dataGridView1.Rows[rowidx].Cells["contractdetailid"].Value = form.SelectedProduct.contractdetailid;
            dataGridView1.Rows[rowidx].Cells["contractno"].Value = form.SelectedProduct.contractno;
            dataGridView1.Rows[rowidx].Cells["no"].Value = form.SelectedProduct.no;
            dataGridView1.Rows[rowidx].Cells["code"].Value = form.SelectedProduct.code;
            dataGridView1.Rows[rowidx].Cells["contractnoseq"].Value = form.SelectedProduct.contractno + "" + form.SelectedProduct.no;
            dataGridView1.Rows[rowidx].Cells["productname"].Value = form.SelectedProduct.name;
            dataGridView1.Rows[rowidx].Cells["specification"].Value = form.SelectedProduct.specification;
            dataGridView1.Rows[rowidx].Cells["code"].Value = form.SelectedProduct.code;
            dataGridView1.Rows[rowidx].Cells["shipno"].Value = form.SelectedProduct.shipno;
            dataGridView1.Rows[rowidx].Cells["billofgoods"].Value = form.SelectedProduct.billofgoods;
            dataGridView1.Rows[rowidx].Cells["contractweight"].Value = form.SelectedProduct.contractweight;
            dataGridView1.Rows[rowidx].Cells["contractquantity"].Value = form.SelectedProduct.contractquantity;
            dataGridView1.Rows[rowidx].Cells["getweight"].Value = form.SelectedProduct.getweight;            
            dataGridView1.Rows[rowidx].Cells["getquantity"].Value = form.SelectedProduct.getquantity;
            dataGridView1.Rows[rowidx].Cells["productid"].Value = form.SelectedProduct.id;

            dataGridView1.Rows[rowidx].Cells["tons"].Value = 0;
        }

        private void SelectFish( int rowidx )
        {
            string condition = string.Format(" state={0} or state={1}", FishEntity.Constant.STATE_SELFMAKE, FishEntity.Constant.STATE_SELFBUY);
            UIForms.FormSelectFish form = new UIForms.FormSelectFish(-1, condition);
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            dataGridView1.Rows[ rowidx ].Cells["productname"].Value = form.SelectedProduct.name;
            dataGridView1.Rows[rowidx].Cells["productcode"].Value = form.SelectedProduct.code;
            dataGridView1.Rows[rowidx].Cells["productid"].Value = form.SelectedProduct.id;
            dataGridView1.Rows[rowidx].Cells["specification"].Value = form.SelectedProduct.specification;
            dataGridView1.Rows[rowidx].Cells["goodbill"].Value = form.SelectedProduct.billofgoods;

            int state = int.Parse(form.SelectedProduct.state);
            if (state == FishEntity.Constant.STATE_SELFMAKE)
            {
                dataGridView1.Rows[rowidx].Cells["unitprice"].Value = form.SelectedProduct.homemadeunitprice;
            }
            else
            {
                dataGridView1.Rows[rowidx].Cells["unitprice"].Value = form.SelectedProduct.price;
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["operate"].Value = "选择";
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dataGridView1.Rows[e.RowIndex].Cells["operate"].Value = "选择";
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_LoadingBills");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_LoadingBills");
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

    }
}
