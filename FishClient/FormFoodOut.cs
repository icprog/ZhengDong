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
    /// 配料出库
    /// </summary>
    public partial class FormFoodOut : FormMenuBase
    {
        protected FishBll.Bll.FoodOutBll _bll = new FishBll.Bll.FoodOutBll();
        protected FishBll.Bll.FoodOutDetailBll _detailBll = new FishBll.Bll.FoodOutDetailBll();
        protected FishEntity.FoodOutEntity _entity = null;
        protected List<FishEntity.FoodOutDetailEntityVO> _details = null;
        protected string _where = string.Empty;
        UILibrary.TwoDimenDataGridView _dgvHelper = null;
        private int FinishNo = 8;

        public FormFoodOut()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_FoodOut");
            //tmiExport.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            //tmiDelete.Visible = false;

            dataGridView1.BackgroundColor = this.BackColor;

            lblTons.Text = string.Empty;
            lblPackage.Text = string.Empty;
            lblcost.Text = string.Empty;
            lbl_protein.Text = string.Empty;
            lbl_tvn.Text = string.Empty;
            lblunitprice.Text = string.Empty;

            _dgvHelper = new UILibrary.TwoDimenDataGridView( dataGridView1 );
            _dgvHelper.MergeColumnNames = new List<string>();
            _dgvHelper.MergeColumnNames.Add("solutionid");
            UILibrary.TwoDimenDataGridView.TopHeader header = new UILibrary.TwoDimenDataGridView.TopHeader(10, 10, "实测化验指标");
            //_dgvHelper.Headers.Add(header);

            InitSolutions();
        }

        protected void InitSolutions()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id",typeof(int));
            dt.Columns.Add("name",typeof(String));
            DataRow row = dt.NewRow();
            row["id"] = 0;
            row["name"] = "请选择方案";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["id"] = 1;
            row["name"] = "1";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["id"] = 2;
            row["name"] = "2";
            dt.Rows.Add(row);
            row = dt.NewRow();
            row["id"] = 3;
            row["name"] = "3";
            dt.Rows.Add(row);

            cmbSolution.DataSource = dt;
            cmbSolution.DisplayMember = "name";
            cmbSolution.ValueMember = "id";
        }

        public override int Query()
        {
            //TODO
            _entity = null;

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
                whereEx += " and code " + operate + "'"+_entity.code+"'";
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

        public override int Delete()
        {
            //if (_entity == null) return 0;

            //string msg = string.Format("你确定要删除提货单号为【{0}】的记录吗?", _entity.code);
            //if (MessageBox.Show(msg, "询问", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return 0;
            
            //减少 成品资料 自制仓吨位和包数,成本= 各明细鱼粉的成本之和
            //FishBll.Bll.ProductBll prodouctBll = new FishBll.Bll.ProductBll();
            //prodouctBll.UpdateHomemadeWeightQuantityCost(_entity.productid, -_entity.weight.Value, -_entity.package.Value, -_entity.);



            return 1;
        }

        protected void SetEntity()
        {
            if (_entity == null) return;

            txtCode.Text = _entity.code;
            dtpProductDate.Value = _entity.productdate.Value;
            dtpOutDate.Value = _entity.outdate.Value;
            txtFishLabel.Text = _entity.productlabel;

            txtProductId.Text = _entity.productcode;
            txtProductId.Tag = _entity.productid;
            txtWeight.Text = _entity.weight.ToString();
            txtPackages.Text = _entity.package.ToString();
            txtRemark.Text = _entity.remark;

            cmbSolution.SelectedValue = _entity.solutionid;
            dtpindate.Value = _entity.indate;
            txtsaleman.Text = _entity.saleman;
            txtsaleman.Tag = _entity.salemanid;
            txtdeliveryman.Text = _entity.deliveryman;
            txtdeliveryman.Tag = _entity.deliverymanid;
            txtcompany.Text = _entity.companyname;
            txtcompany.Tag = _entity.companyid;
        }

        protected void SetDetail()
        {
            int mid = _entity.id;
            _details = _detailBll.GetDetailByMid(mid);
            SetDetail(_details);
        }

        protected void SetDetail(List<FishEntity.FoodOutDetailEntityVO> details )
        {
            dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.Rows.Clear();
            dataGridView1.DataSource = null;

            if (details == null || details.Count < 1) return;

            _details = details;

            dataGridView1.DataSource = details;


            //foreach (FishEntity.FoodOutDetailEntityVO item in details)
            //{
            //    int idx = dataGridView1.Rows.Add();
            //    DataGridViewRow row = dataGridView1.Rows[idx];
            //    row.Cells["id"].Value = item.id;
            //    row.Cells["solutionid"].Value = item.solutionid;
            //    row.Cells["no"].Value = item.no;
            //    row.Cells["productname"].Value = item.productname;
            //    row.Cells["productcode"].Value = item.productcode;
            //    row.Cells["productid"].Value = item.productid;
            //    row.Cells["tons"].Value = item.tons;
            //    row.Cells["packages"].Value = item.package;

            //    row.Cells["domestic_protein"].Value = item.domestic_protein;
            //    row.Cells["domestic_tvn"].Value = item.domestic_tvn;
            //    row.Cells["domestic_graypart"].Value = item.domestic_graypart;
            //    row.Cells["domestic_sandsalt"].Value = item.domestic_sandsalt;
            //    row.Cells["domestic_sour"].Value = item.domestic_sour;
            //    row.Cells["domestic_lysine"].Value = item.domestic_lysine;
            //    row.Cells["domestic_methionine"].Value = item.domestic_methionine;
            //    //row.Cells["sgs_amine"].Value = item.sgs_amine;
            //    //row.Cells["sgs_ffa"].Value = item.sgs_ffa;
            //    row.Cells["domestic_amine"].Value = item.domestic_amine;
            //    row.Cells["domestic_aminototal"].Value = item.domestic_aminototal;
            //    row.Cells["domestic_fat"].Value = item.domestic_fat;
            //    row.Cells["remark"].Value = item.remark;
            //    row.Cells["shipno"].Value = item.shipno;
            //    row.Cells["billofgoods"].Value = item.billofgoods;
            //    row.Cells["nature"].Value = item.nature;
            //    row.Cells["brand"].Value = item.brand;
            //    row.Cells["selfrmb"].Value = item.selfrmb;
            //    row.Cells["salermb"].Value = item.salermb;

            //    //row.Cells["homemadeunitprice"].Value = item.homemadeunitprice;

            //    //decimal costDec =0;
            //    //costDec = item.tons * item.homemadeunitprice;
            //    //row.Cells["cost"].Value = costDec;
            //}

            //Calc();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;  
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("productcode", StringComparison.OrdinalIgnoreCase) == false) return;

            int no = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["no"].Value == null) no = 0;
            int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["no"].Value.ToString(), out no);

            int state= FishEntity.Constant.STATE_SELFMAKE;
            if (no == FinishNo ) state = FishEntity.Constant.STATE_SELFBUY;

            UIForms.FormSelectFish form = new UIForms.FormSelectFish( state );
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

            if (no == FinishNo ) return;

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

                int no = GetInt(row.Cells["no"].Value);
                if (no == FinishNo ) { continue; }

                tons = GetDecimal(row.Cells["tons"].EditedFormattedValue);
                tons_hj += tons;
                finishM.tons += tons;

                packages = GetInt(row.Cells["package"].EditedFormattedValue);
                finishM.package += packages;
               
                decimal idx = 0;               
                idx = GetDecimal( row.Cells["domestic_graypart"].Value);                
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

            foreach (System.Collections.Generic.KeyValuePair<int , FishEntity.FoodOutDetailEntityVO> pair in groups)
            {
                FishEntity.FoodOutDetailEntityVO f = _details.Find((i) => { return i.solutionid == pair.Key && i.no == FinishNo ; });
                if (f == null) continue;

                f.tons = pair.Value.tons;
                f.package = pair.Value.package;
                
                f.domestic_amine = pair.Value.tons ==0? 0: pair.Value.domestic_amine / pair.Value.tons;
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


            lblTons.Text = "吨位："+ tons_hj.ToString("f2");
            lblPackage.Text = "包数:" + packages.ToString();
            decimal lb = tons_hj == 0 ? 0 : protein / tons_hj;
            lbl_protein.Text = "蛋白:"+ lb.ToString("f2");
            lb = tons_hj == 0 ? 0 : tvn / tons_hj;
            lbl_tvn.Text = "TVN:"+ lb.ToString("f2");
            lb = tons_hj == 0 ? 0 : cost_hj / tons_hj;
            lblunitprice.Text = "单价:" + lb.ToString("f2");
            lblcost.Text = "成本:"+ cost_hj.ToString("f2");

            dataGridView1.Invalidate();
        }

        protected decimal GetDecimal(object obj)
        {
            if (obj == null) return 0;
            decimal temp = 0;
            decimal.TryParse(obj.ToString(), out temp);
            return temp;
        }

        protected int GetInt(object obj)
        {
            if (obj == null) return 0;
            int temp = 0;
            int.TryParse(obj.ToString(), out temp);
            return temp;
        }

        protected bool Check()
        {
            errorProvider1.Clear();
            bool isok = true;

            if (cmbSolution.SelectedValue == null || cmbSolution.SelectedValue.ToString() == "0")
            {
                errorProvider1.SetError(cmbSolution, "请选择方案。");
                isok = false;
            }
            int solutionid = 0;
            int.TryParse(cmbSolution.SelectedValue.ToString(), out solutionid);

            //if (string.IsNullOrEmpty(txtProductId.Text))
            //{
            //    errorProvider1.SetError(txtProductId, "请选择成品ID。");
            //    isok = false;
            //}

            //decimal fee = 0;
            //if (false == string.IsNullOrEmpty(txtWeight.Text))
            //{
            //    if (false == decimal.TryParse(txtWeight.Text, out fee))
            //    {
            //        isok = false;
            //        errorProvider1.SetError(txtWeight, "请输入正确的数字。");
            //    }
            //    else
            //    {
            //        if (fee <= 0)
            //        {
            //            isok = false;
            //            errorProvider1.SetError(txtWeight, "请输入大于零的重量。");
            //        }
            //    }
            //}
            //else
            //{
            //    isok = false;
            //    errorProvider1.SetError(txtWeight, "请输入重量。");
            //}

            //int num = 0;
            //if (string.IsNullOrEmpty(txtPackages.Text))
            //{
            //    isok = false;
            //    errorProvider1.SetError(txtPackages, "请输入包数。");
            //}
            //else
            //{
            //    if (int.TryParse(txtPackages.Text, out num) == false)
            //    {
            //        isok = false;
            //        errorProvider1.SetError(txtPackages, "请输入正确的包数。");
            //    }
            //    else
            //    {
            //        if (num <= 0)
            //        {
            //            isok = false;
            //            errorProvider1.SetError(txtPackages, "请输入大于零的包数。");
            //        }
            //    }
            //}

            if (dataGridView1.Rows.Count < 1)
            {
                isok = false;
                errorProvider1.SetError(dataGridView1, "请输入明细。");
            }
            
            bool hasDetail = false;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                object temp = row.Cells["productid"].Value;
                object tempnostr = row.Cells["no"].Value;
                int tempno = 0;
                int.TryParse(tempnostr.ToString(), out tempno);
                int tempsolutionid = 0;
                int.TryParse(row.Cells["solutionid"].Value.ToString(), out tempsolutionid);
                int tempInt = 0;
                if (temp == null) { tempInt = 0; }
                else { int.TryParse(temp.ToString(), out tempInt); }

                //if (tempsolutionid == solutionid && tempno ==FinishNo  && tempInt ==0 )
                //{
                //    isok = false;
                //    row.Cells["productcode"].ErrorText = "请选择成品鱼粉";
                //}

                if ( tempInt >0 )
                {
                    hasDetail = true;
                    temp = row.Cells["tons"].EditedFormattedValue.ToString();
                    decimal tempDec = 0;
                    if (decimal.TryParse(temp.ToString(), out tempDec) == false)
                    {
                        isok = false;
                        row.Cells["tons"].ErrorText = "请输入正确的吨位。";
                    }
                    //else if( tempDec <=0)
                    //{
                    //    isok = false;
                    //    row.Cells["tons"].ErrorText = "请输入大于零的吨位。";
                    //}
                    temp = row.Cells["package"].EditedFormattedValue.ToString();
                    if (int.TryParse(temp.ToString(), out tempInt) == false)
                    {
                        isok = false;
                        row.Cells["package"].ErrorText = "请输入正确的包数。";
                    }
                    //else if (tempInt <= 0) 
                    //{
                    //    isok = false;
                    //    row.Cells["packages"].ErrorText = "请输入大于零的包数。";
                    //}
                }
            }
            if (hasDetail == false)
            {
                isok = false;
                MessageBox.Show("请设置明细记录。");
            }

            return isok;
        }

        protected void GetEntity()
        {
            if (_entity == null) return;

            _entity.outdate = dtpOutDate.Value;
            int package = 0;
            int.TryParse(txtPackages.Text, out package);
            _entity.package = package;

            int solutionid = 0;
            int.TryParse(cmbSolution.SelectedValue.ToString(), out solutionid);
            _entity.solutionid = solutionid;

            //int productid = 0;           
            //int.TryParse( txtProductId.Tag.ToString(), out productid );                                
            //_entity.productid = productid;
            //_entity.productcode = txtProductId.Text.Trim();

            _entity.productid = 0;
            _entity.productcode = string.Empty;
            if (_details != null)
            {
                FishEntity.FoodOutDetailEntityVO vo = _details.Find((i) => { return i.solutionid == solutionid && i.no == FinishNo ; });
                if (vo != null)
                {
                    _entity.productid = vo.productid;
                    _entity.productcode = vo.productcode;
                }
             
            }

            _entity.productdate = dtpProductDate.Value;
            _entity.productlabel = txtFishLabel.Text.Trim();
            _entity.remark = txtRemark.Text.Trim();
            decimal weight = 0;
            decimal.TryParse(txtWeight.Text , out weight );
            _entity.weight = weight;

           

            int salemanid = 0;
            if (txtsaleman.Tag == null) salemanid = 0;
            else
            {
                int.TryParse(txtsaleman.Tag.ToString(), out salemanid);
            }
            _entity.salemanid = salemanid;
            _entity.saleman = txtsaleman.Text.Trim();

            int deliverymanid = 0;
            if (txtdeliveryman.Tag == null) deliverymanid = 0;
            else
            {
                int.TryParse(txtdeliveryman.Tag.ToString(), out deliverymanid);
            }
            _entity.deliverymanid = deliverymanid;
            _entity.deliveryman = txtdeliveryman.Text.Trim();

            _entity.indate = dtpindate.Value;

            int companyid = 0;
            if (txtcompany.Tag == null) companyid = 0;
            else
            {
                int.TryParse(txtcompany.Tag.ToString(), out companyid);
            }
            _entity.companyid = companyid;
            _entity.companyname = txtcompany.Text.Trim();

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
                int no = 0;
                if (row.Cells["no"].Value != null)
                {
                    int.TryParse(row.Cells["no"].Value.ToString(), out no);
                }
                product.no = no;

                int pid = 0;
                if (row.Cells["productid"].Value != null)
                {
                    int.TryParse(row.Cells["productid"].Value.ToString(), out pid);
                }
                product.productid = pid;
                product.productname = row.Cells["productname"].Value == null ? string.Empty : row.Cells["productname"].Value.ToString();
                product.productcode = row.Cells["productcode"].Value == null ? string.Empty : row.Cells["productcode"].Value.ToString();
                product.nature =  row.Cells["nature"].Value == null ? string.Empty : row.Cells["nature"].Value.ToString ();
                 product.brand =  row.Cells["brand"].Value == null ? string.Empty : row.Cells["brand"].Value.ToString ();
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

                product.domestic_graypart = row.Cells["domestic_graypart"].Value == null ? 0 : decimal.Parse( row.Cells["domestic_graypart"].Value.ToString().Trim());
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

        protected void AddDetails( int mid , bool isAdd ,out decimal cost_hj , int n_solutionid , int s_solutionid )
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

                    List<FishEntity.FoodOutDetailEntityVO> solution = listsource.FindAll( (i)=>{ return i.solutionid== s_solutionid;});
                    if (solution != null)
                    {
                        foreach (FishEntity.FoodOutDetailEntityVO detail in solution)
                        {
                            if (detail.no < FinishNo && detail.productid > 0)
                            {
                                productExBll.UpdateHomeMadeInfo(detail.productid, detail.tons,  detail.package);
                            }
                            else if (detail.no == FinishNo  && detail.productid > 0)
                            {
                                productExBll.UpdateHomeMadeInfo(detail.productid, -detail.tons, -detail.package);
                            }
                        }
                        _detailBll.DeleteByMid( mid);
                    }                        
                }
            }

            foreach (FishEntity.FoodOutDetailEntityVO item in listNews)
            {
                cost_hj += item.cost;

                //if (item.id == 0)
                //{
                    int detailId = _detailBll.Add(item );
                    if (detailId > 0 && item.solutionid == n_solutionid )
                    {
                        //减少 明细中鱼粉自制仓 吨位，包数,成本
                        //productBll.UpdateHomemadeWeightQuantityCost(item.productid, -item.tons, -item.package , -item.tons * item.homemadeunitprice );
                        item.id = detailId;
                        if (item.no < FinishNo  && item.productid > 0)
                        {
                                productExBll.UpdateHomeMadeInfo(item.productid, -item.tons, -item.package);                            
                        }
                        else if( item.no ==FinishNo  && item.productid >0 )
                        {
                            productExBll.UpdateHomeMadeInfo(item.productid, item.tons, item.package);
                        }
                    }
                //}
                //else
                //{
                //    decimal sWeight = 0;
                //    int sPackage = 0;
                //    if (listsource != null)
                //    {
                //        FishEntity.FoodOutDetailEntityVO sRecord = listsource.Find((i) => { return i.id == item.id; });
                //        if (sRecord != null)
                //        {
                //            sWeight = sRecord.tons;
                //            sPackage = sRecord.package;
                //        }
                //    }

                //    decimal dWeight = item.tons;
                //    int dPackage = item.package;

                //    decimal weight = dWeight - sWeight;
                //    int package = dPackage - sPackage;
                //    decimal cost = weight * item.homemadeunitprice;                

                //    productBll.UpdateHomemadeWeightQuantityCost(item.productid, -weight, -package , -cost );

                //    _detailBll.Update(item);
                //}
            }

            SetDetail(listNews);
        }
    
        public override void Save()
        {
            if (Check() == false) return;

            _entity = new FishEntity.FoodOutEntity();

            GetEntity();

            _entity.createman = FishEntity.Variable.User.username;
            _entity.createtime = DateTime.Now;
            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = _entity.createtime;

            _entity.code = FishBll.Bll.SequenceUtil.GetFoodOutSequence();
            while (_bll.Exists(_entity.code))
            {
                _entity.code = FishBll.Bll.SequenceUtil.GetFoodOutSequence();
            }

            int id = _bll.Add(_entity);
            if (id > 0)
            {
                _entity.id = id;
                decimal cost_hj =0;
                AddDetails(id, true , out cost_hj, _entity.solutionid , 0 );
                //增加 成品资料 自制仓吨位和包数,成本= 各明细鱼粉的成本之和
                //FishBll.Bll.ProductBll prodouctBll = new FishBll.Bll.ProductBll();
                //prodouctBll.UpdateHomemadeWeightQuantityCost(_entity.productid, _entity.weight, _entity.package , cost_hj );
                //回写 出库单的 成本字段
                //_entity.cost = cost_hj;
                //_bll.Update(_entity); 
                
                //回写成品的 国检指标，和其他一些信息
                if (_details != null)
                {
                    FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                    FishEntity.FoodOutDetailEntityVO finishVo = _details.Find((i) => { return i.solutionid == _entity.solutionid && i.no == FinishNo ; });
                    if (finishVo != null)
                    {
                        productBll.UpdateFoodOutInfo(finishVo);
                    }

                    FishBll.Bll.ProductExBll productexBll = new FishBll.Bll.ProductExBll();
                   bool isupdate=  productexBll.UpdateFoodOutInfo(finishVo);                   
                    
                }

                txtCode.Text = _entity.code;
               

                FishEntity.FoodOutDetailEntityVO vo= _details.Find((i) => { return i.solutionid == _entity.solutionid && i.no == FinishNo ; });
                if (vo != null)
                {
                    txtProductId.Tag = vo.productid;
                    txtProductId.Text = vo.productname;
                }

                //tmiAdd.Visible = true;
                //tmiModify.Visible = true;
                ////tmiDelete.Visible = true;
                //tmiQuery.Visible = true;
                //tmiPrevious.Visible = true;
                //tmiNext.Visible = true;
                //tmiSave.Visible = false;
                //tmiCancel.Visible = false;

                ControlButtomRoles();

                MessageBox.Show("新增成功。");
            }
            else
            {
                MessageBox.Show("新增失败。");
            }                    
        }

        public override int Add()
        {
            tmiSave.Visible = true;
            tmiCancel.Visible = true;
            tmiAdd.Visible = false;
            tmiDelete.Visible = false;
            tmiModify.Visible = false;
            tmiQuery.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;

            txtCode.Text = string.Empty;
            txtFishLabel.Text = string.Empty;
            txtPackages.Text = string.Empty;
            txtProductId.Text = string.Empty;
            txtProductId.Tag = string.Empty;
            txtRemark.Text = string.Empty;
            txtWeight.Text = string.Empty;
            dtpOutDate.Value = DateTime.Now;
            dtpProductDate.Value = DateTime.Now;
            cmbSolution.SelectedValue = 0;
            dtpindate.Value = DateTime.Now;
            txtsaleman.Text = string.Empty;
            txtsaleman.Tag = 0;
            txtdeliveryman.Text = string.Empty;
            txtdeliveryman.Tag = 0;
            txtcompany.Text = string.Empty;
            txtcompany.Tag = 0;

            if (_details != null)
            {
                _details.Clear();
            }
            dataGridView1.DataSource = _details;

            _entity = null;

            InitDetails();

            errorProvider1.Clear();            

            return 1;
        }

        protected void InitDetails()
        {
            _details = new List<FishEntity.FoodOutDetailEntityVO>();
            dataGridView1.AutoGenerateColumns = false;

            for( int i=1;i<=3 ;i++)
            {
                for (int k = 1; k <= FinishNo ; k++)
                {
                    FishEntity.FoodOutDetailEntityVO item = new FishEntity.FoodOutDetailEntityVO();
                    item.solutionid = i;
                    item.no = k;
                    _details.Add(item);
                }            
            }

            dataGridView1.DataSource = _details;
        }

        public override void Cancel()
        {
            //tmiAdd.Visible = true;
            //tmiModify.Visible = true;
            //tmiQuery.Visible = true;
            ////tmiDelete.Visible = true;
            //tmiPrevious.Visible = true;
            //tmiNext.Visible = true;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            ControlButtomRoles();

            errorProvider1.Clear();

            dataGridView1.DataSource = null;
            _details = null;
            _entity = null;
        }

        public override int Modify()
        {
            if (Check() == false) return 0;

            decimal s_tons = _entity.weight;
            int s_package = _entity.package;
            decimal s_cost = _entity.cost;
            int s_solutionid=_entity.solutionid;

            GetEntity();

            _entity.modifyman = FishEntity.Variable.User.username;
            _entity.modifytime = DateTime.Now;

            decimal d_tons = _entity.weight;
            int d_pacakges = _entity.package;

            bool isok = _bll.Update(_entity);
            if (isok)
            {
                decimal cost_hj = 0;
                AddDetails(_entity.id, false , out cost_hj , _entity.solutionid , s_solutionid );
                
                //更新 成品资料 的 自制仓 吨位和包数, 成本=各明细鱼粉的成本之和
                //decimal tons = d_tons - s_tons;
                //int package = d_pacakges - s_package;
                //decimal cost = cost_hj - s_cost;
                //FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                //productBll.UpdateHomemadeWeightQuantityCost(_entity.productid, tons, package, cost );
                //回写 出库单的 成本字段
                //_entity.cost = cost_hj;
                //_bll.Update(_entity);

                //回写成品的 国检指标，和其他一些信息
                if (_details != null)
                {
                    FishBll.Bll.ProductBll productBll = new FishBll.Bll.ProductBll();
                    FishEntity.FoodOutDetailEntityVO finishVo = _details.Find((i) => { return i.solutionid == _entity.solutionid && i.no == FinishNo ; });
                    if (finishVo != null)
                    {
                        productBll.UpdateFoodOutInfo(finishVo);
                    }

                    FishBll.Bll.ProductExBll productexBll = new FishBll.Bll.ProductExBll();
                    bool isupdate = productexBll.UpdateFoodOutInfo(finishVo);

                    txtProductId.Tag = finishVo.productid;
                    txtProductId.Text = finishVo.productname;
                }

                MessageBox.Show("修改成功。");
            }   
            else
            {
                MessageBox.Show("修改失败。");
            }
            return 1;
        }

        private void txtProductId_Click(object sender, EventArgs e)
        {
            UIForms.FormSelectFish form = new UIForms.FormSelectFish( FishEntity.Constant.STATE_SELFMAKE );
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectedProduct == null) return;

            txtProductId.Text = form.SelectedProduct.code;
            txtProductId.Tag = form.SelectedProduct.id;
            //txtproductname.Text = form.SelectedProduct.name;
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

        private void txtcompany_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtcompany.Tag = form.SelectCompany.code;
            txtcompany.Text = form.SelectCompany.fullname; 
        }

        private void txtsaleman_Click(object sender, EventArgs e)
        {
            SelectMan(txtsaleman);
        }

        protected void SelectMan(TextBox txt)
        {
            FormUserList form = new FormUserList(true);
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowInTaskbar = false;
            DialogResult result = form.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                FishEntity.PersonEntity person = form.SelectedPersion;
                if (person != null)
                {
                    txt.Text = person.realname;
                    txt.Tag = person.id;
                }
            }
        }

        private void txtdeliveryman_Click(object sender, EventArgs e)
        {
            SelectMan(txtdeliveryman);
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if( e.RowIndex <0 || e.ColumnIndex<0) return;
            if( dataGridView1.Columns[e.ColumnIndex].Name.Equals("solutionid"))return;

            int no = 0;
            if (dataGridView1.Rows[e.RowIndex].Cells["no"].Value == null) no = 0;
            else
            {
                int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["no"].Value.ToString(), out no);
            }
            if (no == FinishNo )
            {
              // dataGridView1.Rows[e.RowIndex].Cells[e..DefaultCellStyle.BackColor = SystemColors.Control;
                e.CellStyle.BackColor = SystemColors.ControlDark;
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if( dataGridView1.Columns[e.ColumnIndex].Name.Equals("remark" , StringComparison.OrdinalIgnoreCase) ==false 
                && dataGridView1.Columns[e.ColumnIndex].Name.Equals("shipno" , StringComparison.OrdinalIgnoreCase) ==false 
                && dataGridView1.Columns[e.ColumnIndex].Name.Equals ("billofgoods" , StringComparison.OrdinalIgnoreCase )==false ) return ;

            int no=0;
            if( dataGridView1.Rows[e.RowIndex].Cells["no"].Value ==null ) {no=0;}
            else {int.TryParse ( dataGridView1.Rows[e.RowIndex].Cells["no"].Value.ToString (),out no);}
            if(  no== FinishNo  )
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            }
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_FoodOut");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_FoodOut");
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
