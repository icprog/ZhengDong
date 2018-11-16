using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormNewFinish : FormMenuBase
    {
        FishBll.Bll.FinishBll bll = new FishBll.Bll.FinishBll();
        public event EventHandler ClickFishEvent = null;
        List<FishEntity.ProductSpotVo> _list = null;
        FishEntity.ProductSpotVo _fish = null;
        public FormNewFinish()
        {
            InitializeComponent();

            ReadColumnConfig(dataGridView1, "Set_chengpin");
            FishEntity.SystemDataType item = new FishEntity.SystemDataType(string.Empty, string.Empty);
            List<FishEntity.SystemDataType> list = FishEntity.Variable.StateList.GetRange(0, FishEntity.Variable.StateList.Count);
            list.Insert(0, item);
            cmbCountry.DataSource = list;
            cmbCountry.DisplayMember = "name";
            cmbCountry.ValueMember = "code";
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);//
            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);
            DealDataGridViewHeader();
        }
        protected void DealDataGridViewHeader()
        {
            UILibrary.TwoDimenDataGridView helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(10, 11, "实测化验指标");
            UILibrary.TwoDimenDataGridView.TopHeader header3 = new UILibrary.TwoDimenDataGridView.TopHeader(21, 12, "标签指标");
            helper.Headers.Add(header2);
            helper.Headers.Add(header3);
        }

        FishEntity.ProductQuoteVo _model = null;
        public FishEntity.ProductQuoteVo getModel
        {
            get
            {
                return _model;
            }
        }
        public override int Query()
        {
            menuStrip1.Focus();
            string where = GetWhereCondition();
            _list = bll.Getlist(where);
            huizong.Text = _list.Count.ToString();
            AddGroupRow(_list);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _list;
            
            if (_list == null || _list.Count < 1) return 0;

            Add();

            return 1;
        }
        protected string GetWhereCondition()
        {
            string where = string.Format(" 1= 1 ");
            if (false == string.IsNullOrEmpty(txtFishCode.Text))
            {
                where += string.Format(" and a.code like '%{0}%'", txtFishCode.Text.Trim());
            }
            if (cmbPZ.SelectedValue != null && string.IsNullOrEmpty(cmbPZ.SelectedValue.ToString()) == false)
            {
                where += " and specification = '" + cmbPZ.SelectedValue.ToString() + "'";
            }
            if (false == string.IsNullOrEmpty(cmbCountry.SelectedValue.ToString()))
            {
                where += string.Format(" and nature like '%{0}%'", cmbCountry.SelectedValue.ToString().Trim());
            }
            if (cmbValidate.Text.Equals("有效"))
            {
                where += string.Format(" and a.isdelete5 =1 ");
            }
            else if (cmbValidate.Text.Equals("无效"))
            {
                where += string.Format(" and a.isdelete5 = 0 ");
            }

            where += string.Format(" and finishedtime>='{0}' and finishedtime<='{1}'",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            return where;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex < 0)
                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true)
                {
                    SeeFishDetail(e.ColumnIndex, e.RowIndex);
                }
        }
        private void SeeFishDetail(int colidx, int rowidx)
        {
            if (colidx < 0 || rowidx < 0) return;
            if (dataGridView1.Columns[colidx].Name.Equals("code"))
            {
                string productidStr = dataGridView1.Rows[rowidx].Cells["code"].Value.ToString();
                FormNewFish form = new FormNewFish(productidStr);
                form.MenuCode = "M007";
                form.ShowDialog();
            }
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_chengpin");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_chengpin");
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

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("finishedtime", StringComparison.InvariantCultureIgnoreCase))
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
            dataGridView1.Rows[rowidx].Cells["label_protein"].Value = vo.label_protein == 0 ? "" : vo.label_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["label_tvn"].Value = vo.label_tvn == 0 ? "" : vo.label_tvn.ToString();
            dataGridView1.Rows[rowidx].Cells["label_fat"].Value = vo.label_fat == 0 ? "" : vo.label_fat.ToString();
            dataGridView1.Rows[rowidx].Cells["labe_water"].Value = vo.labe_water == 0 ? "" : vo.labe_water.ToString();
            dataGridView1.Rows[rowidx].Cells["label_amine"].Value = vo.label_amine == 0 ? "" : vo.label_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["label_ffa"].Value = vo.label_ffa == 0 ? "" : vo.label_ffa.ToString();
            dataGridView1.Rows[rowidx].Cells["label_sandsalt"].Value = vo.label_sandsalt == 0 ? "" : vo.label_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["label_graypart"].Value = vo.label_graypart == 0 ? "" : vo.label_graypart.ToString();

            dataGridView1.Rows[rowidx].Cells["domestic_protein"].Value = vo.domestic_protein == 0 ? "" : vo.domestic_protein.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_tvn"].Value = vo.domestic_tvn == 0 ? "" : vo.domestic_tvn.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_ffa"].Value = vo.domestic_ffa == 0 ? "" : vo.domestic_ffa.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_amine"].Value = vo.domestic_amine == 0 ? "" : vo.domestic_amine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_sandsalt"].Value = vo.domestic_sandsalt == 0 ? "" : vo.domestic_sandsalt.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_graypart"].Value = vo.domestic_graypart == 0 ? "" : vo.domestic_graypart.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_fat"].Value = vo.domestic_fat == 0 ? "" : vo.domestic_fat.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_lysine"].Value = vo.domestic_lysine == 0 ? "" : vo.domestic_lysine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_methionine"].Value = vo.domestic_methionine == 0 ? "" : vo.domestic_methionine.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_aminototal"].Value = vo.domestic_aminototal == 0 ? "" : vo.domestic_aminototal.ToString();
            dataGridView1.Rows[rowidx].Cells["domestic_sour"].Value = vo.domestic_sour == 0 ? "" : vo.domestic_sour.ToString();

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
                    //group.confirmsgsweight += vo.confirmsgsweight;
                    group.finisheWeight += vo.finisheWeight;
                }
                else
                {
                    FishEntity.ProductSpotVo newvo = new FishEntity.ProductSpotVo();
                    newvo.specification = vo.specification;
                    //newvo.confirmsgsweight = vo.confirmsgsweight;
                    newvo.finisheWeight = vo.finisheWeight;
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

        private void dataGridView1_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex < 0)

                if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true) return;
                    this.DialogResult = DialogResult.Cancel;
            _model = new FishEntity.ProductQuoteVo();
            if (dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString() != "分组小计")
            {
                _model.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                _model.specification = dataGridView1.Rows[e.RowIndex].Cells["specification"].Value.ToString();
                _model.nature = dataGridView1.Rows[e.RowIndex].Cells["nature"].Value.ToString();
                _model.brand = dataGridView1.Rows[e.RowIndex].Cells["brand"].Value.ToString();
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_protein"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_protein"].Value != null)
                {
                    _model.domestic_protein = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_protein"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_tvn"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_tvn"].Value != null)
                {
                    _model.domestic_tvn = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_tvn"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_ffa"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_ffa"].Value != null)
                {
                    _model.domestic_ffa = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_ffa"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_sandsalt"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_sandsalt"].Value != null)
                {
                    _model.domestic_sandsalt = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_sandsalt"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value != null)
                {
                    _model.domestic_sour = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_sour"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_amine"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_amine"].Value != null)
                {
                    _model.domestic_amine = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_amine"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_fat"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_fat"].Value != null)
                {
                    _model.domestic_fat = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_fat"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["domestic_graypart"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["domestic_graypart"].Value != null)
                {
                    _model.domestic_graypart = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["domestic_graypart"].Value.ToString());
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["finisheWeight"].Value.ToString() != "" && dataGridView1.Rows[e.RowIndex].Cells["finisheWeight"].Value != null)
                {
                    _model.finisheWeight = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["finisheWeight"].Value.ToString());
                }

                //_model.supplier = dataGridView1.Rows[e.RowIndex].Cells["supplier"].Value.ToString();
                //_model.Supplieruser = dataGridView1.Rows[e.RowIndex].Cells["supplieruser"].Value.ToString();
                //_model.confirmrmb = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["confirmrmb"].Value.ToString());
                _model.codeNum = dataGridView1.Rows[e.RowIndex].Cells["codeNum"].Value.ToString();
                _model.codeNumContract = dataGridView1.Rows[e.RowIndex].Cells["codeNumContract"].Value.ToString();
                this.DialogResult = DialogResult.OK;
        }
    }
    }
}
