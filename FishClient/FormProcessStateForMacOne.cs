using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;
namespace FishClient
{
    public partial class FormProcessStateForMacOne : FormMenuBase
    {
        FishBll.Bll.ProcessStateForSaleOneBll _bll = null; ProcessControl Authority = null; DataTable tableView = null, table = null, tableErrorFK = null;
        string strWhere = " 1=1 ";
        public FormProcessStateForMacOne()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_126");
            _bll = new FishBll.Bll.ProcessStateForSaleOneBll();
            tableView = new DataTable();
            Authority = new ProcessControl();
            tableErrorFK = new DataTable();
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";
        }
        string billNum = string.Empty, path = string.Empty;

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpStart.CustomFormat = null;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpEnd.CustomFormat = null;
        }

        public override int Query()
        {
            strWhere = "1=1  ";

            if (!string.IsNullOrEmpty(txtpeiliao.Text.Trim()))
                strWhere = strWhere + " and a.code like '%" + txtpeiliao.Text + "%'";
            if (!string.IsNullOrEmpty(cmbCodeNumUser.Text.Trim()))
                strWhere = strWhere + " and a.createUser='" + cmbCodeNumUser.Text + "'";
            if (!string.IsNullOrEmpty(txtfishId.Text.Trim()))
                strWhere = strWhere + " and d.fishId like'%" + txtfishId.Text + "%'";
            if (!string.IsNullOrEmpty(txtqualitySpe.Text.Trim()))
                strWhere = strWhere + " and d.qualitySpe like'%" + txtqualitySpe.Text + "%'";
            if (!string.IsNullOrEmpty(txtcodeNum.Text.Trim()))
                strWhere = strWhere + " and d.codeNum like'%" + txtcodeNum.Text + "%'";
            if (!string.IsNullOrEmpty(txtcodeNumContract.Text.Trim()))
                strWhere = strWhere + " and d.codeNumContract like'%" + txtcodeNumContract.Text + "%'";
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                strWhere = strWhere + " AND a.productionDate>='" + dtpStart.Text + "'";
            if (!string.IsNullOrEmpty(dtpEnd.Text.Trim()))
                strWhere = strWhere + " AND a.productionDate<='" + dtpEnd.Text + "'";
            tableView = _bll.getTableViewzizhi(strWhere);
            dataGridView1.Rows.Clear();
            if (tableView == null || tableView.Rows.Count < 1)
                return 0;
            setValue();
            return base.Query();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormBatchSheet form = new FormBatchSheet();
            form.ShowDialog();
        }
        void setValue()
        {
            string codeNumContract = string.Empty, errorValue = string.Empty;

            int idx = 0;
            for (int i = 0; i < tableView.Rows.Count; i++)
            {
                idx = dataGridView1.Rows.Add();

                dataGridView1.Rows[idx].Cells["code"].Value = tableView.Rows[i]["code"].ToString();
                dataGridView1.Rows[idx].Cells["productionDate"].Value = Convert.ToDateTime(tableView.Rows[i]["productionDate"]).ToString("yyyy-MM-dd");
                //dataGridView1.Rows[idx].Cells["code1"].Value = tableView.Rows[i]["code1"].ToString();
                //dataGridView1.Rows[idx].Cells["code2"].Value = tableView.Rows[i]["code2"].ToString();
                if (string.IsNullOrEmpty(tableView.Rows[i]["code1"].ToString()))
                    dataGridView1.Rows[i].Cells["code1"].Style.BackColor = Color.FromName("LightBlue");
                else
                {
                    dataGridView1.Rows[i].Cells["code1"].Style.BackColor = Color.FromName("LightPink");
                }
                if (string.IsNullOrEmpty(tableView.Rows[i]["code2"].ToString()))
                    dataGridView1.Rows[i].Cells["code2"].Style.BackColor = Color.FromName("LightBlue");
                else
                {
                    dataGridView1.Rows[i].Cells["code2"].Style.BackColor = Color.FromName("LightPink");
                }
                dataGridView1.Rows[idx].Cells["fishId"].Value = tableView.Rows[i]["fishId"].ToString();
                dataGridView1.Rows[idx].Cells["tons"].Value = tableView.Rows[i]["tons"].ToString();
                dataGridView1.Rows[idx].Cells["qualitySpe"].Value = tableView.Rows[i]["qualitySpe"].ToString();
                dataGridView1.Rows[idx].Cells["codeNum"].Value = tableView.Rows[i]["codeNum"].ToString();
                dataGridView1.Rows[idx].Cells["codeNumContract"].Value = tableView.Rows[i]["codeNumContract"].ToString();
                dataGridView1.Rows[idx].Cells["goods"].Value = tableView.Rows[i]["goods"].ToString();
            }
        }
        FormBatchSheet IngredientTable = null;

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_126");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_126");
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

        FormFinishedProductAssociation FinishedTable = null;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            billNum=path = string.Empty;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code1", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("配料单") == true)
                {
                    if (IngredientTable == null || IngredientTable.IsDisposed)
                    {
                        IngredientTable = new FormBatchSheet(dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString());
                        IngredientTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        IngredientTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code2", StringComparison.OrdinalIgnoreCase))
            {
                if (Authority.ProcessControText("成品出库单") == true)
                {
                    if (FinishedTable == null || FinishedTable.IsDisposed)
                    {
                        FinishedTable = new FormFinishedProductAssociation(dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString());
                        FinishedTable.Show();//未打开，直接打开。
                    }
                    else
                    {
                        FinishedTable.Activate();//已打开，获得焦点，置顶。
                    }
                }
            }
            if (!string.IsNullOrEmpty(path))
                Reflected(path);
        }
        void Reflected(string path)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            Form doc = (Form)asm.CreateInstance(path);
            Megres.oddNum = billNum;
            doc.ShowDialog();
        }
    }
}
