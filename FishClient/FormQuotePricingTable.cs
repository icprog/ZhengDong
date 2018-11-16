using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormQuotePricingTable : FormMenuBase
    {
        FishBll.Bll.QuotationPriceListBll _bll = null;
        string strWhere = string.Empty;
        public FormQuotePricingTable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_135");
        }
        public override int Query()
        {
            _bll = new FishBll.Bll.QuotationPriceListBll();
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
                    row.Cells["id"].Value = table.Rows[i]["id"].ToString();
                    row.Cells["CODE"].Value = table.Rows[i]["CODE"].ToString();
                    row.Cells["fishId"].Value = table.Rows[i]["fishId"].ToString();
                    row.Cells["priceMY"].Value = table.Rows[i]["priceMY"].ToString();
                    row.Cells["price"].Value = table.Rows[i]["price"].ToString();
                    row.Cells["country"].Value = table.Rows[i]["country"].ToString();
                    row.Cells["brand"].Value = table.Rows[i]["brand"].ToString();
                    row.Cells["qualitySpe"].Value = table.Rows[i]["qualitySpe"].ToString();
                    row.Cells["weight"].Value = table.Rows[i]["weight"].ToString();
                    row.Cells["tvn"].Value = table.Rows[i]["tvn"].ToString();
                    row.Cells["acid"].Value = table.Rows[i]["acid"].ToString();
                    row.Cells["protein"].Value = table.Rows[i]["protein"].ToString();
                    row.Cells["ash"].Value = table.Rows[i]["ash"].ToString();
                    row.Cells["histamine"].Value = table.Rows[i]["histamine"].ToString();
                    row.Cells["las"].Value = table.Rows[i]["las"].ToString();
                    row.Cells["das"].Value = table.Rows[i]["das"].ToString();
                    row.Cells["salt"].Value = table.Rows[i]["salt"].ToString();
                    row.Cells["ffa"].Value = table.Rows[i]["ffa"].ToString();
                    row.Cells["XNfishId"].Value = table.Rows[i]["XNfishId"].ToString();
                
            }
            }
            else {
                MessageBox.Show("查无数据！");
            }
            return base.Query();
        }
        FishEntity.QuotationPriceListEntity _model = null;
        public FishEntity.QuotationPriceListEntity getModel
        {
            get
            {
                return _model;
            }
        }
        public override int Add()
        {
            FormQuotationPriceList from = new FormQuotationPriceList();
            from.Show();
            return base.Add();
        }
        private void FormQuotePricingTable_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                Query ( );
            }
            //权限控制功能。
            Megres . oddNum = string . Empty;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex < 0)
                this.DialogResult = DialogResult.Cancel;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("fishId", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString() == "")
                {
                }
                FormNewFish from = new FormNewFish(dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString()); 
                from.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) == true)
            {
                FormQuotationPriceList from = new FormQuotationPriceList(dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString());
                from.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("code", StringComparison.OrdinalIgnoreCase) != true&& dataGridView1.Columns[e.ColumnIndex].Name.Equals("fishId", StringComparison.OrdinalIgnoreCase) != true)
            {
                _model = new FishEntity.QuotationPriceListEntity();

                _model.fishId = dataGridView1.Rows[e.RowIndex].Cells["fishId"].Value.ToString();
                if (_model.fishId=="")
                {

                    _model.XNfishId = dataGridView1.Rows[e.RowIndex].Cells["XNfishId"].Value.ToString();
                }
                if (dataGridView1.Rows[e.RowIndex].Cells["price"].Value!=null&& dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString()!="")
                {
                    _model.price = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells["price"].Value.ToString());
                }

                _model.country = dataGridView1.Rows[e.RowIndex].Cells["country"].Value.ToString();
                _model.brand = dataGridView1.Rows[e.RowIndex].Cells["brand"].Value.ToString();
                _model.qualitySpe = dataGridView1.Rows[e.RowIndex].Cells["qualitySpe"].Value.ToString();
                _model.protein = dataGridView1.Rows[e.RowIndex].Cells["protein"].Value.ToString();
                _model.tvn = dataGridView1.Rows[e.RowIndex].Cells["tvn"].Value.ToString();
                _model.histamine = dataGridView1.Rows[e.RowIndex].Cells["histamine"].Value.ToString();
                _model.FFA = dataGridView1.Rows[e.RowIndex].Cells["ffa"].Value.ToString();
                _model.acid = dataGridView1.Rows[e.RowIndex].Cells["acid"].Value.ToString();
                _model.ash = dataGridView1.Rows[e.RowIndex].Cells["ash"].Value.ToString();
                _model.salt = dataGridView1.Rows[e.RowIndex].Cells["salt"].Value.ToString();
                _model.las = dataGridView1.Rows[e.RowIndex].Cells["las"].Value.ToString();
                _model.das = dataGridView1.Rows[e.RowIndex].Cells["das"].Value.ToString();
                _model.code = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_135");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_135");
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
