using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormNewSelfcontrolWare : FormMenuBase
    {
        FishBll.Bll.ProductSelfMakeBll _selfmakeBll = new FishBll.Bll.ProductSelfMakeBll();
        public event EventHandler ClickFishEvent = null;
        List<FishEntity.ProductSelfMakeVo> _list = null;
        FishEntity.ProductSelfMakeVo _fish = null;
        public FormNewSelfcontrolWare()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SelfMake");
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
            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);
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
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(11, 10, "实测化验指标");
            //UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(11, 9, "报盘指标");
            //helper.Headers.Add(header1 );
            helper.Headers.Add(header1);
        }
        void tmiAddFish_Click(object sender, EventArgs e)
        {
            //OnClickFish();
            FormNewFish form = new FormNewFish();
            form.ShowDialog();
        }
        public override int Query()
        {
            menuStrip1.Focus();
            string where = GetWhereCondition();
            //select qiuhe,b.* from  v_zlqh a INNER JOIN v_qh b on b.`code`=a.fishid GROUP BY a.fishid;
            //select *,sum(qiuhe) qiuhe from v_zizhiqiuhe GROUP BY fishid
            _list = _selfmakeBll.GetNewSelfMake(where);
            huizong.Text = _list.Count.ToString();
            AddGroupRow(_list);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;
            if (!FishEntity.Variable.User.roletype.Contains("业务主管"))
            {
                dataGridView1.Columns["selfrmb"].Visible = false;
                dataGridView1.Columns["salermb"].Visible = false;
            }
            if (_list == null || _list.Count < 1) return 0;

            Add();

            return 1;
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
        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtFishCode.Text))
            {
                where += string.Format(" and fishid like '%{0}%'", txtFishCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_amine.Text))
            {
                where += string.Format(" and za like '%{0}%'", txtquote_amine.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtbillofgoods.Text))
            {
                where += string.Format(" and qualiyspe like '%{0}%'", txtbillofgoods.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_protein.Text))
            {
                where += string.Format(" and db like '%{0}%'", txtquote_protein.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquote_tvn.Text))
            {
                where += string.Format(" and tvn like '%{0}%'", txtquote_tvn.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                where += string.Format(" and country like '%{0}%'", cmbCountry.SelectedValue.ToString().Trim());
            }
            if (cmbPZ.SelectedValue != null && string.IsNullOrEmpty(cmbPZ.SelectedValue.ToString()) == false)
            {
                where += " and qualitySpe = '" + cmbPZ.SelectedValue.ToString() + "'";
            }
            if (cmbPort.SelectedValue != null && string.IsNullOrEmpty(cmbPort.SelectedValue.ToString()) == false)
            {
                where += " and port = '" + cmbPort.SelectedValue.ToString() + "'";
            }

            where += string.Format(" and createtime>= '{0}' and createtime<= '{1}'",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            return where;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true)
            {
                SeeFishDetail(e.ColumnIndex, e.RowIndex);
            }
            if (e.ColumnIndex < 0 && e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() == "分组小计") return;
                _models = new FishEntity.BatchSheetsEntity();
            _models.fishId = dataGridView1.Rows[e.RowIndex].Cells["code"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            _models.codeNum = dataGridView1.Rows[e.RowIndex].Cells["codenum"].Value.ToString(); 
            _models.codeNumContract = dataGridView1.Rows[e.RowIndex].Cells["codenumcontract"].Value.ToString();
            _models.qualitySpe = dataGridView1.Rows[e.RowIndex].Cells["specification"].Value.ToString();
            _models.price = dataGridView1.Rows[e.RowIndex].Cells["selfrmb"].Value == null ?0 : Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["selfrmb"].Value.ToString());
            _models.country = dataGridView1.Rows[e.RowIndex].Cells["nature"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["nature"].Value.ToString();//brand
            _models.brand = dataGridView1.Rows[e.RowIndex].Cells["brand"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["brand"].Value.ToString();//brand
            _models.protein = dataGridView1.Rows[e.RowIndex].Cells["domestic_protein"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_protein"].Value.ToString();
            _models.tvn = dataGridView1.Rows[e.RowIndex].Cells["domestic_tvn"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_tvn"].Value.ToString();
            _models.salt = dataGridView1.Rows[e.RowIndex].Cells["domestic_sandsalt"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_sandsalt"].Value.ToString();
            _models.acid = dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString();
            _models.ash = dataGridView1.Rows[e.RowIndex].Cells["domestic_graypart"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_graypart"].Value.ToString();
            _models.histamine = dataGridView1.Rows[e.RowIndex].Cells["domestic_amine"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_amine"].Value.ToString();
            _models.las = dataGridView1.Rows[e.RowIndex].Cells["domestic_lysine"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_lysine"].Value.ToString();
            _models.das = dataGridView1.Rows[e.RowIndex].Cells["domestic_methionine"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["domestic_methionine"].Value.ToString();
            //_models.tons = dataGridView1.Rows[e.RowIndex].Cells["weight"].Value == null ? 0 : Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["weight"].Value);
            _models.rkCode = string.Empty;
            this.DialogResult = DialogResult.OK;
        }
        private void SeeFishDetail(int colidx, int rowidx)
        {
            if (colidx < 0 || rowidx < 0) return;
            if (dataGridView1.Columns[colidx].Name.Equals("code"))
            {
                string productidStr = dataGridView1.Rows[rowidx].Cells["code"].Value.ToString();
                //int productid = 0;
                //int.TryParse(productidStr, out productid);
                //if (productid < 1) return;
                FormNewFish form = new FormNewFish(productidStr);
                form.MenuCode = "M007";
                form.ShowDialog();
            }
        }
        FishEntity.BatchSheetsEntity _models = new FishEntity.BatchSheetsEntity();
        public FishEntity.BatchSheetsEntity getModel
        {
            get
            {
                return _models;
            }
        }
        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SelfMake");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SelfMake");
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
        protected void AddGroupRow(List<FishEntity.ProductSelfMakeVo> list)
        {
            if (list == null || list.Count < 1) return;
            IDictionary<string, FishEntity.ProductSelfMakeVo> groups = new Dictionary<string, FishEntity.ProductSelfMakeVo>();
            string specification = list[0].specification;
            foreach (FishEntity.ProductSelfMakeVo vo in list)
            {
                if (groups.ContainsKey(vo.specification))
                {
                    FishEntity.ProductSelfMakeVo group = groups[vo.specification];
                    //group.weight += vo.weight;
                }
                else
                {
                    FishEntity.ProductSelfMakeVo newvo = new FishEntity.ProductSelfMakeVo();
                    newvo.specification = vo.specification;
                    //newvo.weight = vo.weight;
                    newvo.code = "分组小计";
                    groups.Add(vo.specification, newvo);
                }
            }

            foreach (KeyValuePair<string, FishEntity.ProductSelfMakeVo> pair in groups)
            {
                int idx = list.FindLastIndex((i) => { return i.specification.Equals(pair.Key); });
                if (idx >= 0)
                {
                    list.Insert(idx + 1, pair.Value);
                }
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
            string fishcode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            if (fishcode.Equals("分组小计") == false)
            {
                SetValue(e.RowIndex, fishcode);
            }
        }
        private void SetValue(int rowidx, string code)
        {
            if (_list == null) return;
            FishEntity.ProductSelfMakeVo vo = _list.Find((i) => { return i.code == code; });
            if (vo == null) return;

            dataGridView1.Rows[rowidx].Cells["domestic_protein"].Value = vo.domestic_protein == 0 ? "" : vo.domestic_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_tvn"].Value = vo.domestic_tvn == 0 ? "" : vo.domestic_tvn.ToString();
            //dataGridView1.Rows[rowidx].Cells["domestic_ffa"].Value = vo.domestic_ffa == 0 ? "" : vo.domestic_ffa.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_amine"].Value = vo.domestic_amine == 0 ? "" : vo.domestic_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_sandsalt"].Value = vo.domestic_sandsalt == 0 ? "" : vo.domestic_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_graypart"].Value = vo.domestic_graypart == 0 ? "" : vo.domestic_graypart.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_fat"].Value = vo.domestic_fat == 0 ? "" : vo.domestic_fat.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_lysine"].Value = vo.domestic_lysine == 0 ? "" : vo.domestic_lysine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_methionine"].Value = vo.domestic_methionine == 0 ? "" : vo.domestic_methionine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_aminototal"].Value = vo.domestic_aminototal == 0 ? "" : vo.domestic_aminototal.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_sour"].Value = vo.domestic_sour == 0 ? "" : vo.domestic_sour.ToString();

        }

        private void label13_Click(object sender, EventArgs e)
        {
            Form2 from = new Form2();
            from.Show();
        }
    }
}
