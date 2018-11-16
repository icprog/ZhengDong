using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormNewPriWarehouse : FormMenuBase
    {
        FishBll.Bll.ProductSelfSaleBll _selfsaleBll = new FishBll.Bll.ProductSelfSaleBll();
        public event EventHandler ClickFishEvent = null;
        List<FishEntity.ProductSelfSaleVo> _list = null;
        FishEntity.ProductSelfSaleVo _fish = null;
        bool boolget = false;
        public FormNewPriWarehouse()
        {
            InitializeComponent(); 
            ReadColumnConfig(dataGridView1, "Set_SS");
            //tmiModify.Visible = false;
            //tmiDelete.Visible = false;
            //tmiPrevious.Visible = false;
            //tmiNext.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            //tmiAdd.Visible = false;
            //tmiExport.Visible = false;

            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);

            UIControls.ToolStripMenuItemEx tmiQuoteImage = new UIControls.ToolStripMenuItemEx();
            tmiQuoteImage.Text = "报盘附件";
            tmiQuoteImage.FunCode = "50";
            tmiQuoteImage.Click += tmiQuoteImage_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiQuoteImage);

            UIControls.ToolStripMenuItemEx tmiAddFish = new UIControls.ToolStripMenuItemEx();
            tmiAddFish.Text = "新增鱼粉";
            tmiAddFish.FunCode = "51";
            tmiAddFish.Click += tmiAddFish_Click;
            menuStrip1.Items.Insert(menuStrip1.Items.IndexOf(tmiClose), tmiAddFish);

            FishEntity.SystemDataType item = new FishEntity.SystemDataType(string.Empty, string.Empty);
            List<FishEntity.SystemDataType> list = FishEntity.Variable.StateList.GetRange(0, FishEntity.Variable.StateList.Count);
            list.Insert(0, item);
            cmbCountry.DataSource = list;
            cmbCountry.DisplayMember = "name";
            cmbCountry.ValueMember = "code";
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);//
            InitDataUtil.BindComboBoxData(cmbPZ, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbPort, FishEntity.Constant.port, true);
            DealDataGridViewHeader();

            if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
            {
                this.dataGridView1.ReadOnly = false;
            }
            else
            {
                this.dataGridView1.ReadOnly = true;
            }
        }
        protected void DealDataGridViewHeader()
        {
            UILibrary.TwoDimenDataGridView helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(15, 8, "SGS指标");
            UILibrary.TwoDimenDataGridView.TopHeader header3 = new UILibrary.TwoDimenDataGridView.TopHeader(23, 10, "实测化验指标");
            helper.Headers.Add(header2);
            helper.Headers.Add(header3);
        }
        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtSupplier.Text))
            {
                where += string.Format(" and Supplier like '%{0}%'", txtSupplier.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtFishCode.Text))
            {
                where += string.Format(" and code like '%{0}%'", txtFishCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtLinkMan.Text))
            {
                where += string.Format(" and supplieruser like '%{0}%'", txtLinkMan.Text.Trim());
            }
            //if (false == string.IsNullOrEmpty(txtQuality.Text))
            //{
            //    where += string.Format(" and quality like '%{0}%'", txtQuality.Text.Trim());
            //}
            if (false == string.IsNullOrEmpty(txtquote_amine.Text))
            {
                where += string.Format(" and sgs_amine like '%{0}%'", txtquote_amine.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_protein.Text))
            {
                where += string.Format(" and sgs_protein like '%{0}%'", txtquote_protein.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtbillofgoods.Text))
            {
                where += string.Format(" and billofgoods like '%{0}%' ", txtbillofgoods.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_tvn.Text))
            {
                where += string.Format(" and sgs_tvn like '%{0}%'", txtquote_tvn.Text.Trim());
            }
            if (cmbPZ.SelectedValue != null && string.IsNullOrEmpty(cmbPZ.SelectedValue.ToString()) == false)
            {
                where += " and specification = '" + cmbPZ.SelectedValue.ToString() + "'";
            }
            if (cmbPort.SelectedValue != null && string.IsNullOrEmpty(cmbPort.SelectedValue.ToString()) == false)
            {
                where += " and port = '" + cmbPort.SelectedValue.ToString() + "'";
            }
            if (false == string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                where += string.Format(" and nature like '%{0}%'", cmbCountry.SelectedValue.ToString().Trim());
            }
            if (cmbValidate.Text.Equals("有效"))
            {
                where += string.Format(" and isdelete3 =1");
            }
            else if (cmbValidate.Text.Equals("无效"))
            {
                where += string.Format(" and isdelete3 = 0 ");
            }

            where += string.Format(" and createtime>='{0}' and createtime<='{1}'",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            return where;
        }
        public override int Query()
        {
            menuStrip1.Focus();
            string where = GetWhereCondition();
            //List<FishEntity.ProductEntity> list = _bll.GetModelList(where);
            _list = _selfsaleBll.ziying(where);
            huizong.Text = _list.Count.ToString();
            AddGroupRow(_list);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;
            if (!FishEntity.Variable.User.roletype.Contains("业务主管"))
            {
                dataGridView1.Columns["confirmrmb"].Visible = false;
            }
            if (_list == null || _list.Count < 1) return 0;

            //Add();

            return 1;
        }
        protected void AddGroupRow(List<FishEntity.ProductSelfSaleVo> list)
        {
            if (list == null || list.Count < 1) return;
            IDictionary<string, FishEntity.ProductSelfSaleVo> groups = new Dictionary<string, FishEntity.ProductSelfSaleVo>();
            string specification = list[0].specification;
            foreach (FishEntity.ProductSelfSaleVo vo in list)
            {
                if (groups.ContainsKey(vo.specification))
                {
                    FishEntity.ProductSelfSaleVo group = groups[vo.specification];
                    group.weight += vo.weight;
                    group.confirmsgsweight += vo.confirmsgsweight;
                    group.saleremainweight += vo.saleremainweight;
                }
                else
                {
                    FishEntity.ProductSelfSaleVo newvo = new FishEntity.ProductSelfSaleVo();
                    newvo.weight = vo.weight;
                    newvo.specification = vo.specification;
                    newvo.saleremainweight = vo.saleremainweight;
                    newvo.confirmsgsweight = vo.confirmsgsweight;
                    newvo.code = "分组小计";
                    groups.Add(vo.specification, newvo);
                }
            }

            foreach (KeyValuePair<string, FishEntity.ProductSelfSaleVo> pair in groups)
            {
                int idx = list.FindLastIndex((i) => { return i.specification.Equals(pair.Key); });
                if (idx >= 0)
                {
                    list.Insert(idx + 1, pair.Value);
                }
            }
        }
        void tmiQuoteImage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择现货记录。");
                return;
            }
        }
        void tmiAddFish_Click(object sender, EventArgs e)
        {
            //OnClickFish();
            FormNewFish form = new FormNewFish();
            form.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSupplier.Text = form.SelectCompany.fullname;
            txtSupplier.Tag = form.SelectCompany.code;
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value == null) return;
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString().Equals("分组小计"))
            {
                e.CellStyle.BackColor = Color.LightPink;
                e.CellStyle.SelectionBackColor = Color.LightPink;
                e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            }
        }
        public FishEntity.ProductSelfSaleVo fish
        {
            get
            {
                return _fish;
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("nature"))
            {
                if (e.Value != null)
                {
                    string natureid = e.Value.ToString();
                    FishEntity.DictEntity entity = InitDataUtil.DictList.Find((i) => { return i.code == natureid && i.pcode == FishEntity.Constant.CountryType; });
                    if (entity != null)
                    {
                        e.Value = entity.name;
                    }
                }
            }
            //if (dataGridView1.Rows.Count > 0)
            //    dataGridView1.Rows.Clear();
            string fishcode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            if (fishcode.Equals("分组小计") == false)
            {
                SetValue(e.RowIndex, fishcode);
            }
            return;
        }
        private void SetValue(int rowidx, string code)
        {
            if (_list == null) return;
            FishEntity.ProductSelfSaleVo vo = _list.Find((i) => { return i.code == code; });
            if (vo == null) return;
            dataGridView1.Rows[rowidx].Cells["sgs_protein"].Value = vo.sgs_protein == 0 ? "" : vo.sgs_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["sgs_tvn"].Value = vo.sgs_tvn == 0 ? "" : vo.sgs_tvn.ToString();
                dataGridView1.Rows[rowidx].Cells["sgs_fat"].Value = vo.sgs_fat == 0 ? "" : vo.sgs_fat.ToString();
                dataGridView1.Rows[rowidx].Cells["sgs_water"].Value = vo.sgs_water == 0 ? "" : vo.sgs_water.ToString();
                dataGridView1.Rows[rowidx].Cells["sgs_amine"].Value = vo.sgs_amine == 0 ? "" : vo.sgs_amine.ToString();
                dataGridView1.Rows[rowidx].Cells["sgs_ffa"].Value = vo.sgs_ffa == 0 ? "" : vo.sgs_ffa.ToString();
                dataGridView1.Rows[rowidx].Cells["sgs_sandsalt"].Value = vo.sgs_sandsalt == 0 ? "" : vo.sgs_sandsalt.ToString();
                dataGridView1.Rows[rowidx].Cells["sgs_graypart"].Value = vo.sgs_graypart == 0 ? "" : vo.sgs_graypart.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_protein"].Value = vo.domestic_protein == 0 ? "" : vo.domestic_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_tvn"].Value = vo.domestic_tvn == 0 ? "" : vo.domestic_tvn.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_amine"].Value = vo.domestic_amine == 0 ? "" : vo.domestic_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_sandsalt"].Value = vo.domestic_sandsalt == 0 ? "" : vo.domestic_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_graypart"].Value = vo.domestic_graypart == 0 ? "" : vo.domestic_graypart.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_fat"].Value = vo.domestic_fat == 0 ? "" : vo.domestic_fat.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_lysine"].Value = vo.domestic_lysine == 0 ? "" : vo.domestic_lysine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_methionine"].Value = vo.domestic_methionine == 0 ? "" : vo.domestic_methionine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_aminototal"].Value = vo.domestic_aminototal == 0 ? "" : vo.domestic_aminototal.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_sour"].Value = vo.domestic_sour == 0 ? "" : vo.domestic_sour.ToString();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Add();
            if (e.ColumnIndex < 0 && e.RowIndex < 0)
                this.DialogResult = DialogResult.Cancel;
            _model = new FishEntity.ProductQuoteVo();
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) != true)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() != "分组小计")
                {
                    _model.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                    _model.specification = dataGridView1.Rows[e.RowIndex].Cells["specification"].Value.ToString();
                    _model.nature = dataGridView1.Rows[e.RowIndex].Cells["nature"].Value.ToString();
                    _model.brand = dataGridView1.Rows[e.RowIndex].Cells["brand"].Value.ToString();
                    _model.billofgoods = dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value.ToString();
                    _model.shipno = dataGridView1.Rows[e.RowIndex].Cells["shipno"].Value.ToString();
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value != null)
                    {
                        _model.sgs_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value != null)
                    {
                        _model.sgs_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value != null)
                    {
                        _model.sgs_fat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value != null)
                    {
                        _model.sgs_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value != null)
                    {
                        _model.sgs_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value != null)
                    {
                        _model.sgs_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value != null)
                    {
                        _model.sgs_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value != null)
                    {
                        _model.sgs_graypart = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString());
                    }
                    _model.supplier = dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                    _model.Supplieruser = dataGridView1.Rows[e.RowIndex].Cells["supplieruser"].Value.ToString();
                    _model.confirmrmb = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["confirmrmb"].Value.ToString());
                    _model.codeNum= dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
                    _model.codeNumContract = dataGridView1.Rows[e.RowIndex].Cells["codeNumContract"].Value.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true)
            {
                SeeFishDetail(e.ColumnIndex, e.RowIndex);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("isdelete3", StringComparison.OrdinalIgnoreCase) == true)
            {
                boolget = true;
            }
            else
            {
                boolget = false;
            }
        }
        public override int Add()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要鱼粉记录。");
                return 0;
            }

            if (dataGridView1.CurrentRow.Cells["code"].Value != null && dataGridView1.CurrentRow.Cells["code"].Value.ToString().Equals("分组小计"))
            {
                panel2.Controls.Clear();
                return 0;
            }


            int productid = 0;

            //object obj = dataGridView1.CurrentRow.Cells["quotesuppliercode"].Value;
            //if (obj == null) return 0;
            //if ( string.IsNullOrEmpty( obj.ToString()) == true ) return 0;

            //obj = dataGridView1.CurrentRow.Cells["quotelinkmancode"].Value;
            //if (obj == null) return 0;
            //if ( string.IsNullOrEmpty( obj.ToString() ) == true ) return 0;

            object obj = dataGridView1.CurrentRow.Cells["id"].Value;
            if (obj == null) return 0;
            if (int.TryParse(obj.ToString(), out productid) == false) return 0;

            //companycode = dataGridView1.CurrentRow.Cells["quotesuppliercode"].Value.ToString();
            //linkmancode = dataGridView1.CurrentRow.Cells["quotelinkmancode"].Value.ToString();

            //string companyNameStr = dataGridView1.CurrentRow.Cells["quotesupplier"].Value.ToString();
            //string productcode = dataGridView1.CurrentRow.Cells["code"].Value.ToString();

            FormSelfSaleDetail form = new FormSelfSaleDetail(productid);
            form.RefreshDataEvent += form_RefreshDataEvent;
            //form.ShowDialog();  
            form.TopLevel = false;
            //form.CaptionHeight = 0;
            form.ControlBox = false;
            form.Dock = DockStyle.Fill;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel2.Controls.Clear();
            panel2.Controls.Add(form);
            form.Show();

            return 1;
        }
        void form_RefreshDataEvent(object sender, ProductIdEventArgs e)
        {
            //if (dataGridView1.CurrentRow == null) return;

            //if (dataGridView1.CurrentRow.Cells["id"].Value == null) return;

            //if (dataGridView1.CurrentRow.Cells["id"].Value.ToString().Equals(e.productid.ToString()) == false) return;

            ////dataGridView1.CurrentRow.Cells["latestquote"].Value = e.latestedprice;

            ////dataGridView1.CurrentRow.Cells["quotedollars"].Value = e.dollars;
            //dataGridView1.CurrentRow.Cells["spotrmb"].Value = e.rmb;
            //// dataGridView1.CurrentRow.Cells["rate"].Value = e.rate;
            //dataGridView1.CurrentRow.Cells["spotstoragedate"].Value = e.latequotedate;

            //dataGridView1.CurrentRow.Cells["spotagent"].Value = e.company;
            //dataGridView1.CurrentRow.Cells["spotlinkman"].Value = e.customer;
        }
        FishEntity.ProductQuoteVo _model = null;
        public FishEntity.ProductQuoteVo getModel
        {
            get
            {
                return _model;
            }
        }
        private void SeeFishDetail(int colidx, int rowidx)
        {
            if (colidx < 0 || rowidx < 0) return;
            if (dataGridView1.Columns[colidx].Name.Equals("code"))
            {
                string productidStr = dataGridView1.Rows[rowidx].Cells["id"].Value.ToString();
                int productid = 0;
                int.TryParse(productidStr, out productid);
                if (productid < 1) return;
                FormNewFish form = new FormNewFish(productid);
                form.MenuCode = "M007";
                form.ShowDialog();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            _fish = new FishEntity.ProductSelfSaleVo();
            if (dataGridView1.CurrentRow == null) { return; }
            if (dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["supplieruser"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["supplieruser"].Value.ToString() != "")
            {
                _fish.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                _fish.supplier = dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                _fish.Supplieruser = dataGridView1.Rows[e.RowIndex].Cells["supplieruser"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value != null)
                {
                    _fish.sgs_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value != null)
                {
                    _fish.sgs_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value != null)
                {
                    _fish.sgs_fat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value != null)
                {
                    _fish.sgs_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value != null)
                {
                    _fish.sgs_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value != null)
                {
                    _fish.sgs_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value != null)
                {
                    _fish.sgs_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value != null)
                {
                    _fish.sgs_graypart = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value != null)
                {
                    _fish.domestic_sour = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString());
                }
                _fish.billofgoods = dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value.ToString();
                _fish.confirmrmb = dataGridView1.Rows[e.RowIndex].Cells["confirmrmb"].Value.ToString();
                _fish.shipno = dataGridView1.Rows[e.RowIndex].Cells["shipno"].Value.ToString();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }
        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SS");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SS");
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
        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //    if (boolget == true)
            //    {
            //        if (e.ColumnIndex < 0 || e.RowIndex < 0) { } else { }
            //        if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() == "分组小计")
            //        {
            //            return;
            //        }
            //        if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("isdelete3", StringComparison.OrdinalIgnoreCase) == true)
            //        {
            //            if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
            //            {
            //                FishEntity.ProductEntity _fish = new FishEntity.ProductEntity();
            //                FishBll.Bll.FinishBll fishbll = new FishBll.Bll.FinishBll();
            //                _fish.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            //                System.Console.WriteLine(dataGridView1.Rows[e.RowIndex].Cells["isdelete3"].Value.ToString());
            //                if (("0").Equals(dataGridView1.Rows[e.RowIndex].Cells["isdelete3"].Value.ToString()))
            //                {
            //                    _fish.isdelete = 1;
            //                }
            //                else if (("1").Equals(dataGridView1.Rows[e.RowIndex].Cells["isdelete3"].Value.ToString()))
            //                {
            //                    _fish.isdelete = 0;
            //                }
            //                string names = "isdelete3";
            //                bool idx = fishbll.update(_fish, names);
            //                if (idx)
            //                {
            //                    MessageBox.Show("修改成功！");
            //                    boolget = false;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("修改失败！");
            //                    boolget = false;
            //                }
            //            }
            //        }
            //    }
            //    else { return; }
        }



        private void FormNewPriWarehouse_Load(object sender, EventArgs e)
        {
            //cmbValidate.Text = "有效";
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.ColumnIndex>=0 && e.RowIndex>=0)
            //MessageBox.Show(e.ColumnIndex.ToString() + e.RowIndex.ToString() + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
    }
}
