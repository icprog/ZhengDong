using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FishEntity;

namespace FishClient
{
    public partial class FormSelfMakeDetail : Form
    {
        string _companycode = string.Empty;
        string _customercode = string.Empty;
        int _productId = 0;
        FishBll.Bll.ContractBll _bll = new FishBll.Bll.ContractBll();
       
        public event EventHandler<ProductIdEventArgs> RefreshDataEvent = null;
        protected void OnRefreshData(int productid, decimal latestPrice , decimal latedollars , 
            decimal latermb,decimal laterate , string lateDate, string company,string customer , decimal weight , int quantity )
        {
            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, new ProductIdEventArgs(productid, latestPrice , 
                    latedollars ,latermb , laterate ,lateDate, company , customer ,weight ,quantity  ));
            }
        }


        public FormSelfMakeDetail(int productId)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SelfMakeDetail");
            dataGridView1.BackgroundColor = this.BackColor;

            _productId = productId;


            DataSet ds = _bll.GetSelfSaleDetail( _productId);


            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                dt.Columns.Add("linkman", typeof(string));
                FishBll.Bll.CompanyBll companybll = new FishBll.Bll.CompanyBll();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string companycode = ds.Tables[0].Rows[i]["yifangcode"].ToString();
                    FishEntity.CompanyEntity company = companybll.GetModelByCode(companycode);
                    if (company != null)
                    {
                        dt.Rows[i]["linkman"] = company.linkman;
                    }
                }
            }



            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ds.Tables[0];
            //SetContractDetail(list);
        }

        public void ShowMenu(bool visible)
        {
            menuStrip1.Visible = visible;
        }

        public int Add()
        {
            dataGridView1.EndEdit();

            int idx = dataGridView1.Rows.Add();
            dataGridView1.Rows[idx].Cells["no"].Value = idx+1;
            dataGridView1.Rows[idx].Cells["date"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["time"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["man"].Value = FishEntity.Variable.User.username;
            dataGridView1.Rows[idx].Cells["puttime"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["company"].Selected = true;

            return 1;
        }

        public int Delete()
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.EndEdit();

                if (dataGridView1.CurrentRow.IsNewRow)
                {
                    return 0;
                }

                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }

            for (int i = 0; i < dataGridView1.Rows.Count;i++ )
            {
                dataGridView1.Rows[i].Cells["no"].Value = i + 1;
            }

            return 1;
        }

        void tmiSave_Click(object sender, EventArgs e)
        {
            if (Check() == false)
            {
                return;
            }

            //Save();
        }

        protected void SetContractDetail(List<FishEntity.ContractDetailVo> list)
        {
            dataGridView1.Rows.Clear();
            if (list == null || list.Count < 1) return;

            foreach (ContractDetailVo item in list)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["id"].Value = item.id;
                row.Cells["contractno"].Value = item.contractno;
                row.Cells["no"].Value = item.no;
                //row.Cells["companyid"].Value = item.yifangcode;
                row.Cells["companycode"].Value = item.yifangcode;
                row.Cells["company"].Value = item.yifang;
                //row.Cells["customerid"].Value = item.customerid;
                //row.Cells["customercode"].Value = item.yi;
                //row.Cells["customer"].Value = item.customer;
                row.Cells["date"].Value = item.signdate;
                //row.Cells["time"].Value = item.spottime;
                //row.Cells["dollars"].Value = item.weight;
                //row.Cells["man"].Value = item.spotman;
                //row.Cells["puttime"].Value = item.spottime;
                //row.Cells["createman"].Value = item.createman;
                row.Cells["weight"].Value = item.weight;
                row.Cells["quantity"].Value = item.quantity;
                row.Cells["saleman"].Value = item.saleman;
                row.Cells["unitprice"].Value = item.unitprice;
                row.Cells["isfinished"].Value = item.isfinished ==1?"是":"否";
                row.Cells["getweight"].Value = item.getweight;
                row.Cells["getquantity"].Value = item.getquantity;
            }
        }

        private bool Check()
        {
          
            if (dataGridView1.Rows.Count < 1) return true;

            bool isok = true;
            List<FishEntity.QuoteEntity> listNews = new List<FishEntity.QuoteEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {             
                if (row.IsNewRow) continue;

                object val = row.Cells["date"].EditedFormattedValue;

                DateTime temp;
                bool ispass = DateTime.TryParse(val.ToString(), out temp);
                if (ispass == false)
                {
                    row.Cells["data"].ErrorText = "请输入正确的日期";
                    isok = false;
                }

                val = row.Cells["time"].EditedFormattedValue;
                ispass = DateTime.TryParse(val.ToString(), out temp);
                if (ispass == false)
                {
                    row.Cells["time"].ErrorText = "请输入正确的日期";
                    isok = false;
                }


                val = row.Cells["company"].EditedFormattedValue;
                if (val == null)
                {
                    isok = false;
                    row.Cells["company"].ErrorText = "请选择单位";
                }

                val = row.Cells["dollars"].EditedFormattedValue;
                if (val == null)
                {
                    isok = false;
                    row.Cells["dollars"].ErrorText = "请输入价格";
                }
                else
                {
                    decimal temp2;
                    ispass = decimal.TryParse(val.ToString(), out temp2);
                    if (ispass == false)
                    {
                        row.Cells["dollars"].ErrorText = "请输入正确的价格";
                        isok = false;
                    }
                }

                val = row.Cells["rmb"].EditedFormattedValue;
                if (val == null)
                {
                    isok = false;
                    row.Cells["rmb"].ErrorText = "请输入价格";
                }
                else
                {
                    decimal temp2;
                    ispass = decimal.TryParse(val.ToString(), out temp2);
                    if (ispass == false)
                    {
                        row.Cells["rmb"].ErrorText = "请输入正确的价格";
                        isok = false;
                    }
                }

            }

            return isok;
        }

        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView1.Rows[e.RowIndex].Cells["no"].Value = e.RowIndex + 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {           
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            //if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            //{
                dataGridView1.Rows[e.RowIndex].Cells["no"].Value = e.RowIndex + 1;
            //}
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SelfMakeDetail");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SelfMakeDetail");
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
