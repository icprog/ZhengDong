using System;
using System . Data;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormFinishedInventoryTable : FormMenuBase
    {
        FishEntity.FinishedProListEntity _fish = new FishEntity.FinishedProListEntity();
        FishBll.Bll.FinishedProListBll _bll = null;
        string strWhere = string.Empty;
        public FishEntity.FinishedProListEntity getModel
        {
            get
            {
                return _fish;
            }
        }
        public FormFinishedInventoryTable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_109");
        }
        public override int Query()
        {
            _bll = new FishBll.Bll.FinishedProListBll();
            strWhere = " 1=1 ";
            DataTable table = _bll.getTable(strWhere);
            strWhere = string.Empty;
            if (table != null && table.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["CODE"].Value = table.Rows[i]["CODE"].ToString();
                    row.Cells["plCode"].Value = table.Rows[i]["plCode"].ToString();
                    row.Cells["date"].Value = table.Rows[i]["date"].ToString();
                    row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                    row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();
                    row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                    row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                    row.Cells["qualitySpe"].Value = table.Rows[i]["qualitySpe"].ToString();
                    row.Cells["goods"].Value = table.Rows[i]["goods"].ToString();
                    row.Cells["tons"].Value = table.Rows[i]["tons"].ToString();
                    row.Cells["protein"].Value = table.Rows[i]["protein"].ToString();
                    row.Cells["tvn"].Value = table.Rows[i]["tvn"].ToString();
                    row.Cells["salt"].Value = table.Rows[i]["salt"].ToString();
                    row.Cells["acid"].Value = table.Rows[i]["acid"].ToString();
                    row.Cells["ash"].Value = table.Rows[i]["ash"].ToString();
                    row.Cells["histamine"].Value = table.Rows[i]["histamine"].ToString();
                    row.Cells["las"].Value = table.Rows[i]["las"].ToString();
                    row.Cells["das"].Value = table.Rows[i]["das"].ToString();
                    row.Cells["remark"].Value = table.Rows[i]["remark"].ToString();
                    row.Cells["zf"].Value = table.Rows[i]["zf"].ToString();
                    row.Cells["billName"].Value = table.Rows[i]["billName"].ToString();
                    row.Cells["zjh"].Value = table.Rows[i]["zjh"].ToString();
                    row.Cells["shipname"].Value = table.Rows[i]["shipname"].ToString();
                    row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                    row.Cells["CkCode"].Value = table.Rows[i]["CkCode"].ToString();
                    row.Cells["ffa"].Value = table.Rows[i]["ffa"].ToString();
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }            return base.Query();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex < 0)
                return;
            _fish = new FishEntity.FinishedProListEntity();
            _fish.qualitySpe= dataGridView1.Rows[e.RowIndex].Cells["qualitySpe"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["qualitySpe"].Value.ToString();
            _fish.CkCode=dataGridView1.Rows[e.RowIndex].Cells["CkCode"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["CkCode"].Value.ToString();
            _fish.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
            _fish.protein=dataGridView1.Rows[e.RowIndex].Cells["protein"].Value== null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["protein"].Value.ToString();
            _fish.tons= dataGridView1.Rows[e.RowIndex].Cells["tons"].Value == null ? 0 : decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["tons"].Value.ToString());
            _fish.price=dataGridView1.Rows[e.RowIndex].Cells["price"].Value == null ? 0 : decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
            _fish.fishId= dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString();
            _fish.tvn= dataGridView1.Rows[e.RowIndex].Cells["tvn"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["tvn"].Value.ToString();
            _fish.histamine= dataGridView1.Rows[e.RowIndex].Cells["histamine"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["histamine"].Value.ToString();
            _fish.zf= dataGridView1.Rows[e.RowIndex].Cells["zf"].Value == null ? string.Empty : dataGridView1.Rows[e.RowIndex].Cells["zf"].Value.ToString();
            this.DialogResult = DialogResult.OK;
        }

        private void FormFinishedInventoryTable_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                Query ( );
            }

            Megres . oddNum = string . Empty;

        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_109");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_109");
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
