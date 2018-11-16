using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class Formingredients : FormMenuBase
    {
        protected FishBll.Bll.FoodOutBll _bll = new FishBll.Bll.FoodOutBll();
        protected FishBll.Bll.FoodOutDetailBll _detailBll = new FishBll.Bll.FoodOutDetailBll();
        protected FishEntity.FoodOutEntity _entity = null;
        protected List<FishEntity.FoodOutDetailEntityVO> _details = null;
        protected string _where = string.Empty;
        UILibrary.TwoDimenDataGridView _dgvHelper = null;
        //private int FinishNo = 8;

        public Formingredients()
        {
            InitializeComponent();
            InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbBrand, FishEntity.Constant.Brand, true);
        }
        public override int Query()
        {
            //TODO
            _entity = null;

            QueryOne(">", " order by id asc limit 1");
            return 1;
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

            if (_entity != null)
            {
                whereEx += " and code " + operate + "'" + _entity.code + "'";
            }

            List<FishEntity.FoodOutEntity> list = _bll.GetModelList(whereEx + orderBy);
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

            txtcode.Text = _entity.code;
            dtpProductionDate.Value = _entity.productdate.Value;
            dtpOutoftime.Value = _entity.outdate.Value;
            txtFishLabel.Text = _entity.productlabel;
            cmbBrand.Text = _entity.Quality;
            txtRemark.Text = _entity.remark;
            cmbSpecification.Text = _entity.Quality;
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
        public override int Add()
        {
            tmiQuery.Visible = false;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiAdd.Visible = false;
            tmiSave.Visible = true;
            tmiCancel.Visible = true;

            txtcode.Text = string.Empty;
            dtpProductionDate.Value = DateTime.Now;
            dtpOutoftime.Value = DateTime.Now;
            cmbBrand.SelectedValue = string.Empty;
            cmbBrand.SelectedValue = string.Empty;
            txtFishLabel.Text = string.Empty;
            txtRemark.Text = string.Empty;
            dataGridView1.Rows.Clear();
            panel2.Enabled = true;
            panel3.Enabled = true;

            dataGridView1.EndEdit();
            dataGridView1.DataSource = _details;
            int idx = dataGridView1.Rows.Add();
            return 1;
        }
        public override void Save()
        {
            _entity = new FishEntity.FoodOutEntity();
            _entity.createman = FishEntity.Variable.User.username;
            _entity.createtime = DateTime.Now;
            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = _entity.createtime;
            _entity.indate = DateTime.Now;
            _entity.productdate = dtpProductionDate.Value;
            _entity.outdate = dtpOutoftime.Value;
            _entity.Brand = cmbBrand.SelectedValue == null ? string.Empty : cmbBrand.SelectedValue.ToString();
            _entity.productlabel = txtFishLabel.Text;
            _entity.Quality = cmbSpecification.SelectedValue == null ? string.Empty : cmbSpecification.SelectedValue.ToString();
            _entity.remark = txtRemark.Text;
            _entity.code = FishBll.Bll.SequenceUtil.GetFoodOutSequence();
            bool isok = _bll.Exists(_entity.code);
            while (isok)
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetFoodOutSequence();
                isok = _bll.Exists(_entity.code);
            }
            int id = _bll.Add(_entity);
            if (id > 0)
            {
                _entity.id = id;
                decimal cost_hj = 0;
                txtcode.Text = _entity.code;
                AddDetails(id, true, out cost_hj, _entity.solutionid, 0);
                tmiQuery.Visible = false;
                tmiDelete.Visible = false;
                tmiModify.Visible = false;
                tmiAdd.Visible = false;
                tmiSave.Visible = true;
                tmiCancel.Visible = true;
                ControlButtomRoles();
                MessageBox.Show("添加成功。");

            }
            else
            {
                MessageBox.Show("添加失败。");
            }
        }
        protected void AddDetails(int mid, bool isAdd, out decimal cost_hj, int n_solutionid, int s_solutionid)
        {
            cost_hj = 0;
            List<FishEntity.FoodOutDetailEntityVO> listNews = GetDetails(mid);
            List<FishEntity.FoodOutDetailEntityVO> listsource = null;
            FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
            FishBll.Bll.ProductExBll productExBll = new FishBll.Bll.ProductExBll();

            if (isAdd == false)
            {
                listsource = _detailBll.GetDetailByMid(mid);
                if (listsource != null)
                {
                    //foreach (FishEntity.FoodOutDetailEntityVO item in listsource)
                    //{
                    //    bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                    //    if (isExist) continue;

                    //    productBll.UpdateHomemadeWeightQuantityCost(item.productid, item.tons, item.package , item.tons * item.homemadeunitprice );
                    //    bool isDelte = _detailBll.Delete(item.id);  
                    //}

                    List<FishEntity.FoodOutDetailEntityVO> solution = listsource.FindAll((i) => { return i.solutionid == s_solutionid; });
                    if (solution != null)
                    {
                        foreach (FishEntity.FoodOutDetailEntityVO detail in solution)
                        {
                            if (/*detail.no < FinishNo &&*/ detail.productid > 0)
                            {
                                productExBll.UpdateHomeMadeInfo(detail.productid, detail.tons, detail.package);
                            }
                            else if (/*detail.no == FinishNo &&*/ detail.productid > 0)
                            {
                                productExBll.UpdateHomeMadeInfo(detail.productid, -detail.tons, -detail.package);
                            }
                        }
                        _detailBll.DeleteByMid(mid);
                    }
                }
            }

            foreach (FishEntity.FoodOutDetailEntityVO item in listNews)
            {
                cost_hj += item.cost;

                //if (item.id == 0)
                //{
                int detailId = _detailBll.Add(item);
                if (detailId > 0 && item.solutionid == n_solutionid)
                {
                    //减少 明细中鱼粉自制仓 吨位，包数,成本
                    //productBll.UpdateHomemadeWeightQuantityCost(item.productid, -item.tons, -item.package , -item.tons * item.homemadeunitprice );
                    item.id = detailId;
                    if (/*item.no < FinishNo &&*/ item.productid > 0)
                    {
                        productExBll.UpdateHomeMadeInfo(item.productid, -item.tons, -item.package);
                    }
                    else if (/*item.no == FinishNo &&*/ item.productid > 0)
                    {
                        productExBll.UpdateHomeMadeInfo(item.productid, item.tons, item.package);
                    }
                }
            }

            SetDetail(listNews);
        }
        protected void SetDetail()
        {
            int mid = _entity.id;
            _details = _detailBll.GetDetailByMid(mid);
            SetDetail(_details);
        }

        protected void SetDetail(List<FishEntity.FoodOutDetailEntityVO> details)
        {
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;

            if (details == null || details.Count < 1) return;

            _details = details;

            dataGridView1.DataSource = details;


            
        }
        protected void UpdateProductCount(int productId, decimal weight, int quanity)
        {
            FishBll.Bll.ProductExBll productexbll = new FishBll.Bll.ProductExBll();
            productexbll.UpdateSaleInfo(productId, weight, quanity);
        }
        public override int Modify()
        {


            decimal s_tons = _entity.weight;
            int s_package = _entity.package;
            decimal s_cost = _entity.cost;
            int s_solutionid = _entity.solutionid;
            if (_entity == null)
            {
                MessageBox.Show("请查询,在操作");
                return 0;
            }
            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = DateTime.Now;
            bool isok = _bll.Update(_entity);
            if (isok)
            {
                decimal cost_hj = 0;
                AddDetails(_entity.id, false, out cost_hj, _entity.solutionid, s_solutionid);
                txtcode.Text = _entity.code;
                MessageBox.Show("修改成功。");
            }
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }
        protected List<FishEntity.FoodOutDetailEntityVO> GetDetails(int billId)
        {
            dataGridView1.EndEdit();

            List<FishEntity.FoodOutDetailEntityVO> listNews = new List<FishEntity.FoodOutDetailEntityVO>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.FoodOutDetailEntityVO product = new FishEntity.FoodOutDetailEntityVO();
                product.mid = billId;

                int solutionid = 0;
                if (row.Cells["solutionid"].Value != null)
                {
                    int.TryParse(row.Cells["solutionid"].Value.ToString(), out solutionid);
                }
                product.solutionid = solutionid;
                //int no = 0;
                //if (row.Cells["no"].Value != null)
                //{
                //    int.TryParse(row.Cells["no"].Value.ToString(), out no);
                //}
                //product.no = no;

                int pid = 0;
                if (row.Cells["productid"].Value != null)
                {
                    int.TryParse(row.Cells["productid"].Value.ToString(), out pid);
                }
                product.productid = pid;
                product.productname = row.Cells["productname"].Value == null ? string.Empty : row.Cells["productname"].Value.ToString();
                product.productcode = row.Cells["productcode"].Value == null ? string.Empty : row.Cells["productcode"].Value.ToString();
                product.nature = row.Cells["nature"].Value == null ? string.Empty : row.Cells["nature"].Value.ToString();
                product.brand = row.Cells["brand"].Value == null ? string.Empty : row.Cells["brand"].Value.ToString();
                product.remark = row.Cells["remark"].Value == null ? string.Empty : row.Cells["remark"].Value.ToString();
                product.shipno = row.Cells["shipno"].Value == null ? string.Empty : row.Cells["shipno"].Value.ToString();
                product.billofgoods = row.Cells["billofgoods"].Value == null ? string.Empty : row.Cells["billofgoods"].Value.ToString();

                decimal selfrmb = 0;
                if (row.Cells["selfrmb"].Value != null)
                {
                    decimal.TryParse(row.Cells["selfrmb"].Value.ToString(), out selfrmb);
                }
                product.selfrmb = selfrmb;
                decimal salermb = 0;
                if (row.Cells["salermb"].Value != null)
                {
                    decimal.TryParse(row.Cells["salermb"].Value.ToString(), out salermb);
                }
                product.salermb = salermb;

                product.domestic_graypart = row.Cells["domestic_graypart"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_graypart"].Value.ToString().Trim());
                product.domestic_lysine = row.Cells["domestic_lysine"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_lysine"].Value.ToString().Trim());
                product.domestic_methionine = row.Cells["domestic_methionine"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_methionine"].Value.ToString().Trim());
                product.domestic_protein = row.Cells["domestic_protein"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_protein"].Value.ToString().Trim());
                product.domestic_sandsalt = row.Cells["domestic_sandsalt"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_sandsalt"].Value.ToString().Trim());
                product.domestic_sour = row.Cells["domestic_sour"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_sour"].Value.ToString().Trim());
                product.domestic_tvn = row.Cells["domestic_tvn"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_tvn"].Value.ToString().Trim());
                product.domestic_fat = row.Cells["domestic_fat"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_fat"].Value.ToString().Trim());
                product.domestic_amine = row.Cells["domestic_amine"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_amine"].Value.ToString().Trim());
                product.domestic_aminototal = row.Cells["domestic_aminototal"].Value == null ? 0 : decimal.Parse(row.Cells["domestic_aminototal"].Value.ToString().Trim());

                //product.sgs_ffa = row.Cells["sgs_ffa"].Value == null ? 0 : decimal.Parse(row.Cells["sgs_ffa"].Value.ToString().Trim());
                //product.sgs_amine = row.Cells["sgs_amine"].Value == null ? 0 : int.Parse(row.Cells["sgs_amine"].Value.ToString().Trim());

                //product.homemadeunitprice = row.Cells["homemadeunitprice"].Value == null ? 0 : decimal.Parse(row.Cells["homemadeunitprice"].Value.ToString().Trim());

                int did = 0;
                if (row.Cells["id"].Value != null)
                {
                    int.TryParse(row.Cells["id"].Value.ToString(), out did);
                }
                product.id = did;

                int packageInt = 0;

                if (row.Cells["package"].Value != null)
                {
                    int.TryParse(row.Cells["package"].Value.ToString(), out packageInt);
                }
                product.package = packageInt;

                decimal tonsDec = 0;
                if (row.Cells["tons"].Value != null)
                {
                    decimal.TryParse(row.Cells["tons"].Value.ToString(), out tonsDec);
                }
                product.tons = tonsDec;

                //decimal costDec = 0;
                //costDec = GetDecimal(row.Cells["cost"].Value);
                //product.cost = costDec;

                listNews.Add(product);
            }

            return listNews;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("solutionid")) return;

            //int no = 0;
            //if (dataGridView1.Rows[e.RowIndex].Cells["no"].Value == null) no = 0;
            //else
            //{
            //    int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["no"].Value.ToString(), out no);
            //}
            //if (no == FinishNo)
            //{
            //    // dataGridView1.Rows[e.RowIndex].Cells[e..DefaultCellStyle.BackColor = SystemColors.Control;
            //    e.CellStyle.BackColor = SystemColors.ControlDark;
            //}
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("productcode", StringComparison.OrdinalIgnoreCase) == false) return;

            //int no = 0;
            //if (dataGridView1.Rows[e.RowIndex].Cells["no"].Value == null) no = 0;
            //int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["no"].Value.ToString(), out no);

            int state = FishEntity.Constant.STATE_SELFMAKE;
            /*if (no == FinishNo)*/ state = FishEntity.Constant.STATE_SELFMAKE;

            UIForms.FormSelectFish form = new UIForms.FormSelectFish(state);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;

            //int no =0;
            // int.TryParse ( dataGridView1.Rows[e.RowIndex].Cells["no"].Value .ToString (), out no );
            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;

            dataGridView1.Rows[e.RowIndex].Cells["productname"].Value = form.SelectedProduct.name;
            dataGridView1.Rows[e.RowIndex].Cells["productcode"].Value = form.SelectedProduct.code;
            dataGridView1.Rows[e.RowIndex].Cells["productid"].Value = form.SelectedProduct.id;
            dataGridView1.Rows[e.RowIndex].Cells["nature"].Value = form.SelectedProduct.nature;
            dataGridView1.Rows[e.RowIndex].Cells["brand"].Value = form.SelectedProduct.brand;
            dataGridView1.Rows[e.RowIndex].Cells["remark"].Value = form.SelectedProduct.remark;
            dataGridView1.Rows[e.RowIndex].Cells["shipno"].Value = form.SelectedProduct.shipno;
            dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value = form.SelectedProduct.billofgoods;
            dataGridView1.Rows[e.RowIndex].Cells["salermb"].Value = form.SelectedProduct.salermb;
            dataGridView1.Rows[e.RowIndex].Cells["selfrmb"].Value = form.SelectedProduct.selfrmb;

            //if (no == FinishNo) return;

            dataGridView1.Rows[e.RowIndex].Cells["domestic_protein"].Value = form.SelectedProduct.domestic_protein;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_tvn"].Value = form.SelectedProduct.domestic_tvn;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_graypart"].Value = form.SelectedProduct.domestic_graypart;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_sandsalt"].Value = form.SelectedProduct.domestic_sandsalt;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value = form.SelectedProduct.domestic_sour;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_lysine"].Value = form.SelectedProduct.domestic_lysine;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_methionine"].Value = form.SelectedProduct.domestic_methionine;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_amine"].Value = form.SelectedProduct.domestic_amine;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_aminototal"].Value = form.SelectedProduct.domestic_aminototal;
            dataGridView1.Rows[e.RowIndex].Cells["domestic_fat"].Value = form.SelectedProduct.domestic_fat;

            //decimal unitprice = 0;
            //if (form.SelectedProduct.homemadeweight == 0) unitprice = 0;
            //else
            //{
            //    unitprice = form.SelectedProduct.homemadecost.Value / form.SelectedProduct.homemadeweight.Value;
            //}

            //dataGridView1.Rows[e.RowIndex].Cells["homemadeunitprice"].Value = unitprice;
            //decimal costDec = 0;
            //decimal tonsDec= 0;   
            //if (dataGridView1.Rows[e.RowIndex].Cells["tons"].Value != null)
            //{
            //    decimal.TryParse(dataGridView1.Rows[e.RowIndex].Cells["tons"].Value.ToString(), out tonsDec);
            //    costDec = unitprice * tonsDec;
            //}
            //dataGridView1.Rows[e.RowIndex].Cells["cost"].Value = costDec;

            //dataGridView1.Rows[e.RowIndex].Cells["tons"].Value = form.SelectedProduct.
            //dataGridView1.Rows[e.RowIndex].Cells["tons"].Selected = true;



            Calc();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("remark", StringComparison.OrdinalIgnoreCase) == false
                && dataGridView1.Columns[e.ColumnIndex].Name.Equals("shipno", StringComparison.OrdinalIgnoreCase) == false
                && dataGridView1.Columns[e.ColumnIndex].Name.Equals("billofgoods", StringComparison.OrdinalIgnoreCase) == false) return;

            //int no = 0;
            //if (dataGridView1.Rows[e.RowIndex].Cells["no"].Value == null) { no = 0; }
            //else { int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["no"].Value.ToString(), out no); }
            //if (no == FinishNo)
            //{
            //    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            //}
        }
        void ctlWeight_TextChanged(object sender, EventArgs e)
        {
            DataGridViewTextBoxEditingControl ctl = sender as DataGridViewTextBoxEditingControl;
            if (ctl == null) return;

            Calc();
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell == null) return;
            if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name.Equals("tons"))
            {
                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    DataGridViewTextBoxEditingControl ctlWeight = e.Control as DataGridViewTextBoxEditingControl;
                    ctlWeight.TextChanged += ctlWeight_TextChanged;
                }
            }
            else if (dataGridView1.Columns[dataGridView1.CurrentCell.ColumnIndex].Name.Equals("package"))
            {
                if (e.Control is DataGridViewTextBoxEditingControl)
                {
                    DataGridViewTextBoxEditingControl ctlQuantity = e.Control as DataGridViewTextBoxEditingControl;
                    ctlQuantity.TextChanged += ctlWeight_TextChanged;
                }
            }
        }
        protected int GetInt(object obj)
        {
            if (obj == null) return 0;
            int temp = 0;
            int.TryParse(obj.ToString(), out temp);
            return temp;
        }
        protected void Calc()
        {
            decimal tons = 0;
            decimal tons_hj = 0;
            int packages = 0;
            decimal graypart = 0;
            decimal lysine = 0;
            decimal methionine = 0;
            decimal protein = 0;
            decimal sandsalt = 0;
            decimal sour = 0;
            decimal ffa = 0;
            decimal tvn = 0;
            decimal amine = 0;
            decimal unitprice = 0;
            decimal cost = 0;
            decimal cost_hj = 0;
            decimal salermb = 0;
            decimal selfrmb = 0;

            //foreach (FishEntity.FoodOutDetailEntityVO d in _details)
            //{
            //    decimal a = d.domestic_graypart.Value;
            //}
            IDictionary<int, FishEntity.FoodOutDetailEntityVO> groups = new Dictionary<int, FishEntity.FoodOutDetailEntityVO>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                object obj = row.Cells["solutionid"].Value;
                int solutionid = GetInt(obj);
                FishEntity.FoodOutDetailEntityVO finishM = null;
                if (groups.ContainsKey(solutionid))
                {
                    finishM = groups[solutionid];
                }
                else
                {
                    finishM = new FishEntity.FoodOutDetailEntityVO();
                    groups.Add(solutionid, finishM);
                }

                //int no = GetInt(row.Cells["no"].Value);
                //if (no == FinishNo) { continue; }

                tons = GetDecimal(row.Cells["tons"].EditedFormattedValue);
                tons_hj += tons;
                finishM.tons += tons;

                packages = GetInt(row.Cells["package"].EditedFormattedValue);
                finishM.package += packages;

                decimal idx = 0;
                idx = GetDecimal(row.Cells["domestic_graypart"].Value);
                graypart += tons * idx;
                finishM.domestic_graypart += tons * idx;

                //row.Cells["domestic_graypart_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["domestic_lysine"].Value);
                lysine += tons * idx;
                finishM.domestic_lysine += tons * idx;
                //row.Cells["domestic_lysine_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["domestic_methionine"].Value);
                methionine += tons * idx;
                finishM.domestic_methionine += tons * idx;
                //row.Cells["domestic_methionine_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["domestic_protein"].Value);
                protein += tons * idx;
                finishM.domestic_protein += tons * idx;

                //row.Cells["domestic_protein_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["domestic_sandsalt"].Value);
                sandsalt += tons * idx;
                finishM.domestic_sandsalt += tons * idx;
                //row.Cells["domestic_sandsalt_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["domestic_sour"].Value);
                sour += tons * idx;
                finishM.domestic_sour += tons * idx;
                // row.Cells["domestic_sour_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["domestic_tvn"].Value);
                tvn += tons * idx;
                finishM.domestic_tvn += tons * idx;

                idx = GetDecimal(row.Cells["domestic_amine"].Value);
                finishM.domestic_amine += tons * idx;

                idx = GetDecimal(row.Cells["domestic_aminototal"].Value);
                finishM.domestic_aminototal += tons * idx;

                idx = GetDecimal(row.Cells["domestic_fat"].Value);
                finishM.domestic_fat += tons * idx;
                //row.Cells["domestic_tvn_hj"].Value = tons * idx;

                idx = GetDecimal(row.Cells["salermb"].Value);
                finishM.salermb += tons * idx;

                idx = GetDecimal(row.Cells["selfrmb"].Value);
                finishM.selfrmb += tons * idx;

                //idx = GetDecimal(row.Cells["sgs_ffa"].Value);
                // ffa += tons * idx;
                //row.Cells["sgs_ffa_hj"].Value = tons * idx;

                //idx = GetDecimal(row.Cells["sgs_amine"].Value);
                //amine += tons * idx;
                //row.Cells["sgs_amine_hj"].Value = tons * idx;

                //unitprice = GetDecimal(row.Cells["homemadeunitprice"].Value);
                //cost = unitprice * tons;
                //cost_hj += cost;
                //row.Cells["cost"].Value = cost.ToString("f2");    

                //FishEntity.FoodOutDetailEntityVO temp = row.DataBoundItem as FishEntity.FoodOutDetailEntityVO;
                //temp.domestic_fat = idx;
            }

            foreach (System.Collections.Generic.KeyValuePair<int, FishEntity.FoodOutDetailEntityVO> pair in groups)
            {
                FishEntity.FoodOutDetailEntityVO f = _details.Find((i) => { return i.solutionid == pair.Key /*&& i.no == FinishNo*/; });
                if (f == null) continue;

                f.tons = pair.Value.tons;
                f.package = pair.Value.package;

                f.domestic_amine = pair.Value.tons == 0 ? 0 : pair.Value.domestic_amine / pair.Value.tons;
                f.domestic_aminototal = pair.Value.tons == 0 ? 0 : pair.Value.domestic_aminototal / pair.Value.tons;
                f.domestic_fat = pair.Value.tons == 0 ? 0 : pair.Value.domestic_fat / pair.Value.tons;
                f.domestic_graypart = pair.Value.tons == 0 ? 0 : pair.Value.domestic_graypart / pair.Value.tons; ;
                f.domestic_lysine = pair.Value.tons == 0 ? 0 : pair.Value.domestic_lysine / pair.Value.tons;
                f.domestic_methionine = pair.Value.tons == 0 ? 0 : pair.Value.domestic_methionine / pair.Value.tons;
                f.domestic_protein = pair.Value.tons == 0 ? 0 : pair.Value.domestic_protein / pair.Value.tons;
                f.domestic_sandsalt = pair.Value.tons == 0 ? 0 : pair.Value.domestic_sandsalt / pair.Value.tons;
                f.domestic_sour = pair.Value.tons == 0 ? 0 : pair.Value.domestic_sour / pair.Value.tons;
                f.domestic_tvn = pair.Value.tons == 0 ? 0 : pair.Value.domestic_tvn / pair.Value.tons;

                f.selfrmb = pair.Value.tons == 0 ? 0 : pair.Value.selfrmb / pair.Value.tons;
                f.salermb = pair.Value.tons == 0 ? 0 : pair.Value.salermb / pair.Value.tons;
            }

            dataGridView1.Invalidate();
        }
        protected decimal GetDecimal(object obj)
        {
            if (obj == null) return 0;
            decimal temp = 0;
            decimal.TryParse(obj.ToString(), out temp);
            return temp;
        }
    }   
}
