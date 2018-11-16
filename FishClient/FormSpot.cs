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
    /// 现货 界面
    /// </summary>
    public partial class FormSpot : FormMenuBase
    {
        FishBll.Bll.ProductSpotBll _spotBll = new FishBll.Bll.ProductSpotBll();
        public event EventHandler ClickFishEvent = null;
        List<FishEntity.ProductSpotVo> _list = null;
        FishEntity.ProductSpotVo _fish = null;

        bool boolget = false;
        protected void OnClickFish()
        {
            if (ClickFishEvent != null)
            {
                ClickFishEvent(this, EventArgs.Empty);
            }
        }

        public FormSpot()
        {
            InitializeComponent();

            ReadColumnConfig(dataGridView1, "Set_Spot");
            //tmiModify.Visible = false;
            //tmiDelete.Visible = false;
            //tmiPrevious.Visible = false;
            //tmiNext.Visible = false;
            //tmiSave.Visible = false;
            //tmiCancel.Visible = false;
            //tmiAdd.Visible = false;

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
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(1,5, "现货");
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(13, 8, "SGS指标");
            UILibrary.TwoDimenDataGridView.TopHeader header3 = new UILibrary.TwoDimenDataGridView.TopHeader(21,9, "国内实测化验指标");
            helper.Headers.Add(header1);
            helper.Headers.Add(header2);
            helper.Headers.Add(header3);
        }


        void tmiQuoteImage_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择现货记录。");
                return;
            }

            int productid = 0;
            object obj = dataGridView1.CurrentRow.Cells["id"].Value;
            if (obj == null) return;
            if (int.TryParse(obj.ToString(), out productid) == false) return;

            FormImage form = new FormImage(productid, FishEntity.ImageTypeEnum.SGS);
            form.StartPosition = FormStartPosition.CenterParent;
            form.SetData(productid, FishEntity.ImageTypeEnum.SGS);
            form.ShowDialog();
        }

        void tmiAddFish_Click(object sender, EventArgs e)
        {
            FormNewFish form = new FormNewFish();
            form.ShowDialog();
            //OnClickFish();
        }

        private void FormQuote_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = this.BackColor;
            cmbValidate.Text = "有效";
        }

        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtSupplier.Text))
            {
                where += string.Format(" and spotagent like '%{0}%'", txtSupplier.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtFishCode.Text))
            {
                where += string.Format(" and a.code like '%{0}%'", txtFishCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtLinkMan.Text))
            {
                where += string.Format(" and salelinkman like '%{0}%'", txtLinkMan.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtQuality.Text))
            {
                where += string.Format(" and quality like '%{0}%'", txtQuality.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_amine.Text))
            {
                where += string.Format(" and quote_amine like '%{0}%'", txtquote_amine.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_protein.Text))
            {
                where += string.Format(" and quote_protein like '%{0}%'", txtquote_protein.Text.Trim());
            }
            if (false==string.IsNullOrEmpty(txtbillofgoods.Text))
            {
                where += string.Format(" and billofgoods like '%{0}%' ", txtbillofgoods.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_tvn.Text))
            {
                where += string.Format(" and quote_tvn like '%{0}%'", txtquote_tvn.Text.Trim());
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
                where += string.Format(" and a.isdelete2 =1 ");
            }
            else if (cmbValidate.Text.Equals("无效"))
            {
                where += string.Format(" and a.isdelete2 = 0 ");
            }

            where += string.Format(" and a.createtime>='{0}' and a.createtime<='{1}'",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            return where;
        }

        public override int Query()
        {
            menuStrip1.Focus();
            panel2.Controls.Clear();
            string where = GetWhereCondition();
            //List<FishEntity.ProductEntity> list = _bll.GetModelList(where);
           _list = _spotBll.GetSpot(where);
            huizong.Text = _list.Count.ToString();
            AddGroupRow(_list);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;

            if (_list == null || _list.Count < 1) return 0;

            Add();

            return 1;
        }

        protected void AddGroupRow(List<FishEntity.ProductSpotVo> list)
        {
            if (list == null || list.Count < 1) return;
            IDictionary<string, FishEntity.ProductSpotVo> groups = new Dictionary<string, FishEntity.ProductSpotVo>();
            string specification = list[0].specification;
            foreach (FishEntity.ProductSpotVo vo in list)
            {
                if (groups.ContainsKey(vo.specification))
                {
                    FishEntity.ProductSpotVo group = groups[vo.specification];
                    group.spotweight += vo.spotweight;
                    group.saleremainweight += vo.saleremainweight;
                }
                else
                {
                    FishEntity.ProductSpotVo newvo = new FishEntity.ProductSpotVo();
                    newvo.specification = vo.specification;
                    newvo.spotweight = vo.spotweight;
                    newvo.saleremainweight = vo.saleremainweight;
                    newvo.code = "分组小计";
                    groups.Add(vo.specification, newvo);
                }
            }

            foreach (KeyValuePair<string, FishEntity.ProductSpotVo> pair in groups)
            {
                int idx = list.FindLastIndex((i) => { return i.specification.Equals(pair.Key); });
                if (idx >= 0)
                {
                    list.Insert(idx + 1, pair.Value);
                }
            }
        }


        public override int Add()
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("请选择要报盘的记录。");
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

            FormSpotDetail form = new FormSpotDetail(productid);
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
            if (dataGridView1.CurrentRow == null) return;

            if (dataGridView1.CurrentRow.Cells["id"].Value == null) return;

            if (dataGridView1.CurrentRow.Cells["id"].Value.ToString().Equals(e.productid.ToString()) == false) return;

            //dataGridView1.CurrentRow.Cells["latestquote"].Value = e.latestedprice;

            //dataGridView1.CurrentRow.Cells["quotedollars"].Value = e.dollars;
            dataGridView1.CurrentRow.Cells["salermb"].Value = e.rmb;
            // dataGridView1.CurrentRow.Cells["rate"].Value = e.rate;
            dataGridView1.CurrentRow.Cells["spotstoragedate"].Value = e.latequotedate;

           // dataGridView1.CurrentRow.Cells["spotagent"].Value = e.company;
           // dataGridView1.CurrentRow.Cells["spotlinkman"].Value = e.customer;
            dataGridView1.CurrentRow.Cells["saletrader"].Value = e.company;
            dataGridView1.CurrentRow.Cells["salelinkman"].Value = e.customer;

        }
        public FishEntity.ProductSpotVo fish
        {
            get
            {
                return _fish;
            }
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex<0)
            {
                return;
            }
            _fish =new  FishEntity.ProductSpotVo();
            if (dataGridView1.CurrentRow==null)
            {
                return;
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["saletrader"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["saletrader"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["salelinkman"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["salelinkman"].Value.ToString() != "")
            {
                _fish.code= dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                _fish.saletrader = dataGridView1.Rows[e.RowIndex].Cells["saletrader"].Value.ToString();
                _fish.salelinkman = dataGridView1.Rows[e.RowIndex].Cells["salelinkman"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString() != "")
                {
                    _fish.sgs_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString() != "")
                {
                    _fish.sgs_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString() != "")
                {
                    _fish.sgs_fat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString() != "")
                {
                    _fish.sgs_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString() != "")
                {
                    _fish.sgs_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString() != "")
                {
                    _fish.sgs_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString() != "")
                {
                    _fish.sgs_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString() != "")
                {
                    _fish.sgs_graypart = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString() != "")
                {
                    _fish.domestic_sour = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString());
                }                    
                    _fish.billofgoods = dataGridView1.Rows[e.RowIndex].Cells["billofgoods"].Value.ToString();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        public override int Export()
        {          
            return 1;
        }

        private void txtSupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Add();
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

                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString() != "")
                    {
                        _model.sgs_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_protein"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString() != "")
                    {
                        _model.sgs_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_tvn"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString() != "")
                    {
                        _model.sgs_fat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_fat"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString() != "")
                    {
                        _model.sgs_water = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_water"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString() != "")
                    {
                        _model.sgs_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_amine"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString() != "")
                    {
                        _model.sgs_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_ffa"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString() != "")
                    {
                        _model.sgs_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_sandsalt"].Value.ToString());
                    }
                    if (dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value != null && dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString() != "")
                    {
                        _model.sgs_graypart = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["sgs_graypart"].Value.ToString());
                    }

                    _model.quotesupplier = dataGridView1.Rows[e.RowIndex].Cells["saletrader"].Value.ToString();
                    _model.linkman = dataGridView1.Rows[e.RowIndex].Cells["salelinkman"].Value.ToString();
                    _model.quotermb = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["spotrmb"].Value.ToString());
                    //_model.quotedollars = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["quotedollars"].Value.ToString());
                    this.DialogResult = DialogResult.OK;
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true)
            {
                SeeFishDetail(e.ColumnIndex, e.RowIndex);
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("isdelete2", StringComparison.OrdinalIgnoreCase) == true)
            {
                boolget = true;
            }
            else
            {
                boolget = false;
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("spotstoragedate", StringComparison.InvariantCultureIgnoreCase))
            {
                if (e.Value != null)
                {
                    try
                    {
                        DateTime dt = DateTime.Parse(e.Value.ToString());
                        e.Value = dt.ToString("yyyy.MM.dd");
                    }
                    catch { }
                }
            }

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

            string fishcode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            if (fishcode.Equals("分组小计") == false)
            {
                SetValue(e.RowIndex, fishcode);
            }
        }
        private void SetValue(int rowidx, string code)
        {
            if (_list == null) return;
            FishEntity.ProductSpotVo vo = _list.Find((i) => { return i.code == code; });
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

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Spot");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Spot");
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

        private void txtSupplier_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSupplier.Text = form.SelectCompany.fullname;
            txtSupplier.Tag = form.SelectCompany.code;
        }
        FishEntity.ProductQuoteVo _model = null;
        public FishEntity.ProductQuoteVo getModel
        {
            get
            {
                return _model;
            }
        }

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (boolget == true)
            {
                if (e.ColumnIndex < 0 || e.RowIndex < 0) { } else { }
                if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() == "分组小计")
                {
                    return;
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("isdelete2", StringComparison.OrdinalIgnoreCase) == true)
                {
                    if (FishEntity.Variable.User.username == "admin" || FishEntity.Variable.User.username == "ceo" || FishEntity.Variable.User.username == "zd_lyk")
                    {
                        FishEntity.ProductEntity _fish = new FishEntity.ProductEntity();
                        FishBll.Bll.FinishBll fishbll = new FishBll.Bll.FinishBll();
                        _fish.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                        System.Console.WriteLine(dataGridView1.Rows[e.RowIndex].Cells["isdelete2"].Value.ToString());
                        if (("0").Equals(dataGridView1.Rows[e.RowIndex].Cells["isdelete2"].Value.ToString()))
                        {
                            _fish.isdelete = 1;
                        }
                        else if (("1").Equals(dataGridView1.Rows[e.RowIndex].Cells["isdelete2"].Value.ToString()))
                        {
                            _fish.isdelete = 0;
                        }
                        string names = "isdelete2";
                        bool idx = fishbll.update(_fish, names);
                        if (idx)
                        {
                            MessageBox.Show("修改成功！");
                            boolget = false;
                        }
                        else
                        {
                            MessageBox.Show("修改失败！");
                            boolget = false;
                        }
                    }
                }
            }
            else { return; }
        }
    }
}
