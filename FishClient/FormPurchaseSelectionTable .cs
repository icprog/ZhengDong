using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPurchaseSelectionTable : FormMenuBase
    {
        FishBll.Bll.ProductQuoteBll _quoteBll = new FishBll.Bll.ProductQuoteBll();
        public event EventHandler ClickFishEvent = null;
        List<FishEntity.ProductQuoteVo> _list = null;
        protected FishEntity.ProductExEntity _entity = null;

        protected void OnClickFish()
        {
            if (ClickFishEvent != null)
            {
                ClickFishEvent(this, EventArgs.Empty);
            }
        }

        public FormPurchaseSelectionTable()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_Quote");
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
            List<FishEntity.SystemDataType> list = FishEntity.Variable.ProductDataTypeList.GetRange(0, FishEntity.Variable.ProductDataTypeList.Count);
            list.Insert(0, item);
            cmbCountry.DataSource = list;
            cmbCountry.DisplayMember = "name";
            cmbCountry.ValueMember = "code";
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);//
            InitDataUtil.BindComboBoxData(cmbPZ, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbPort, FishEntity.Constant.port, true);

            DealDataGridViewHeader();
        }

        protected void DealDataGridViewHeader()
        {
            UILibrary.TwoDimenDataGridView helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(9, 2, "船期(月)");
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(13, 9, "报盘指标");
            helper.Headers.Add(header1);
            helper.Headers.Add(header2);
        }

        void tmiQuoteImage_Click(object sender, EventArgs e)
        {

        }

        void tmiAddFish_Click(object sender, EventArgs e)
        {
            OnClickFish();
        }

        private void FormQuote_Load(object sender, EventArgs e)
        {
            dataGridView1.BackgroundColor = this.BackColor;

            dataGridView1.Columns["quote_tvn"].ValueType = typeof(string);

            cmbValidate.Text = "有效";

        }

        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtSupplier.Text))
            {
                where += string.Format(" and a.quotesupplier like '%{0}%'", txtSupplier.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtFishCode.Text))
            {
                where += string.Format(" and a.code like '%{0}%'", txtFishCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtLinkMan.Text))
            {
                where += string.Format(" and a.quotelinkman like '%{0}%'", txtLinkMan.Text.Trim());
            }
            //if (false==string.IsNullOrEmpty(txtnature.Text))
            //{
            //    where += string.Format(" and nature like '%{0}%'", txtnature.Text.Trim());
            //}
            if (false == string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                where += string.Format(" and a.nature like '%{0}%'", cmbCountry.SelectedValue.ToString().Trim());
            }

            if (false == string.IsNullOrEmpty(txtquote_protein.Text))
            {
                where += string.Format(" and a.quote_protein like '%{0}%'", txtquote_protein.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_tvn.Text))
            {
                where += string.Format(" and a.quote_tvn like '%{0}%'", txtquote_tvn.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_amine.Text))
            {
                where += string.Format(" and a.quote_amine like '%{0}%'", txtquote_amine.Text.Trim());
            }
            if (cmbPZ.SelectedValue != null && string.IsNullOrEmpty(cmbPZ.SelectedValue.ToString()) == false)
            {
                where += " and a.specification = '" + cmbPZ.SelectedValue.ToString() + "'";
            }
            if (cmbPort.SelectedValue != null && string.IsNullOrEmpty(cmbPort.SelectedValue.ToString()) == false)
            {
                where += " and a.port = '" + cmbPort.SelectedValue.ToString() + "'";
            }
            if (cmbValidate.Text.Equals("有效"))
            {
                where += string.Format(" and a.isdelete =1 ");
            }
            else if (cmbValidate.Text.Equals("无效"))
            {
                where += string.Format(" and a.isdelete= 0 ");
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
            _list = _quoteBll.GetQuote(where);

            AddGroupRow(_list);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;

            //Type tt = dataGridView1.Columns["quote_tvn"].ValueType;
            //dataGridView1.Columns["quote_tvn"].ValueType = typeof(string);
            //dataGridView1.Columns["quote_tvn"].DefaultCellStyle.Format = null;


            if (_list == null || _list.Count < 1) return 0;

            Add();

            return 1;
        }

        protected void AddGroupRow(List<FishEntity.ProductQuoteVo> list)
        {
            if (list == null || list.Count < 1) return;
            IDictionary<string, FishEntity.ProductQuoteVo> groups = new Dictionary<string, FishEntity.ProductQuoteVo>();
            string specification = list[0].specification;
            foreach (FishEntity.ProductQuoteVo vo in list)
            {
                if (groups.ContainsKey(vo.specification))
                {
                    FishEntity.ProductQuoteVo group = groups[vo.specification];
                    group.quoteweight += vo.quoteweight;
                }
                else
                {
                    FishEntity.ProductQuoteVo newvo = new FishEntity.ProductQuoteVo();
                    newvo.specification = vo.specification;
                    newvo.quoteweight = vo.quoteweight;
                    newvo.code = "分组小计";
                    groups.Add(vo.specification, newvo);
                }
            }

            foreach (KeyValuePair<string, FishEntity.ProductQuoteVo> pair in groups)
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

            string companycode = "";
            string linkmancode = "";
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

            FormQuoteDetail form = new FormQuoteDetail(productid);
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

            dataGridView1.CurrentRow.Cells["latestquote"].Value = e.latestedprice;

            dataGridView1.CurrentRow.Cells["quotedollars"].Value = e.dollars;
            dataGridView1.CurrentRow.Cells["quotermb"].Value = e.rmb;
            dataGridView1.CurrentRow.Cells["rate"].Value = e.rate;
            dataGridView1.CurrentRow.Cells["quotedate"].Value = e.latequotedate;

            dataGridView1.CurrentRow.Cells["quotesupplier"].Value = e.company;
            dataGridView1.CurrentRow.Cells["linkman"].Value = e.customer;

            dataGridView1.CurrentRow.Cells["quoteweight"].Value = e.weight;
            dataGridView1.CurrentRow.Cells["quotequantity"].Value = e.quantity;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            //Add();
        }

        public override int Export()
        {
            List<FishEntity.ProductQuoteVo> list = dataGridView1.DataSource as List<FishEntity.ProductQuoteVo>;
            if (list == null || list.Count < 1) return 0;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            string filepath = dlg.FileName;
            ExportUtil.ExportQuote(list, filepath);


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

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true)
            {
                SeeFishDetail(e.ColumnIndex, e.RowIndex);
            }
            else
            {
                string fishcode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                if (fishcode.Equals("分组小计") == false)
                {
                    num(e.ColumnIndex, e.RowIndex);
                }
            }
        }
        private void num(int colidx, int rowidx)
        {
            if (colidx < 0 || rowidx < 0) return;
            string code = dataGridView1.Rows[rowidx].Cells["code"].Value.ToString();
            FromInquiry form = new FromInquiry();
            form.StartPosition = FormStartPosition.CenterParent;
            form.MenuCode = "M417";
            form.FromInquiry1(code);
            form.ShowDialog();
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
                FormFish form = new FormFish(productid);
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            string fishcode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            if (fishcode.Equals("分组小计") == false)
            {
                SetValue(e.RowIndex, fishcode);
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

        }

        protected void SetValue(int rowidx, string code)
        {
            if (_list == null) return;
            FishEntity.ProductQuoteVo vo = _list.Find((i) => { return i.code == code; });
            if (vo == null) return;

            dataGridView1.Rows[rowidx].Cells["quote_protein"].Value = vo.quote_protein == 0 ? "" : vo.quote_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_tvn"].Value = vo.quote_tvn == 0 ? "" : vo.quote_tvn.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_amine"].Value = vo.quote_amine == 0 ? "" : vo.quote_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_sandsalt"].Value = vo.quote_sandsalt == 0 ? "" : vo.quote_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_ffa"].Value = vo.quote_ffa == 0 ? "" : vo.quote_ffa.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_graypart"].Value = vo.quote_graypart == 0 ? "" : vo.quote_graypart.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_fat"].Value = vo.quote_fat == 0 ? "" : vo.quote_fat.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_water"].Value = vo.quote_water == 0 ? "" : vo.quote_water.ToString();
            dataGridView1.Rows[rowidx].Cells["quote_sand"].Value = vo.quote_sand == 0 ? "" : vo.quote_sand.ToString();

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            string msg = e.Exception.Message;
            //e.Cancel = true;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Quote");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Quote");
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
        


        private void txtSupplier_Click_1(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtSupplier.Text = form.SelectCompany.fullname;
            txtSupplier.Tag = form.SelectCompany.code;
        }
    }
}
