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
    public partial class FormSelfSaleDetail : Form
    {

        string _companycode = string.Empty;
        string _customercode = string.Empty;
        int _productId = 0;
        FishBll.Bll.ContractBll _bll = new FishBll.Bll.ContractBll();
        private string _rolewhere = string.Empty;
        public event EventHandler<ProductIdEventArgs> RefreshDataEvent = null;
        protected void OnRefreshData(int productid, decimal latestPrice , decimal latedollars , 
            decimal latermb,decimal laterate , string lateDate, string company,string customer, decimal weight , int quantity )
        {
            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, new ProductIdEventArgs(productid, latestPrice , 
                    latedollars ,latermb , laterate ,lateDate, company , customer ,weight ,quantity  ));
            }
        }


        public FormSelfSaleDetail(int productId)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SSD");
            dataGridView1.BackgroundColor = this.BackColor;
            ContractDetailVo model = new ContractDetailVo();
            _productId = productId;  
            // _productId = productId;


            //DataSet ds = _bll.GetSelfSaleDetail(_productId);

            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    DataTable dt = ds.Tables[0];
            //    dt.Columns.Add("linkman", typeof(string));

            //    FishBll.Bll.CompanyBll companybll = new FishBll.Bll.CompanyBll();
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        string companycode = ds.Tables[0].Rows[i]["yifangcode"].ToString();
            //        FishEntity.CompanyEntity company = companybll.GetModelByCode(companycode);
            //        if (company != null)
            //        {
            //            dt.Rows[i]["linkman"] = company.linkman;
            //        }
            //    }
            //}

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = ds.Tables[0];
            //ds.Tables[0].Rows.Add();



            //_productId = productId;
            _rolewhere = "1=1  and ";
            if (_productId!=0)//FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan)
            {
                _rolewhere = string.Format(" productid= '{0}'  ", _productId);
            }
            else
            {
                _rolewhere = string.Empty;
            }

            //DataSet ds = _bll.GetSelfSaleDetail1(_productId);
            //if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            //{
            //    DataTable dt = ds.Tables[0];
            //}
            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = ds;
            //ds.Tables[0].Rows.Add();
            List<FishEntity.ContractDetailVo> list=_bll.GetModelList1(_rolewhere);
            SetContractDetail(list);
            //decimal num1 = 0;
            //decimal num2 = 0;
            //decimal num3 = 0;
            //decimal num4 = 0;
            //decimal num5 = 0;
            //this.dataGridView1.Rows.Add();
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[0].Value = "合计";
            //for (int i = 0; i < this.dataGridView1.RowCount; i++)
            //{
            //    if ( this.dataGridView1.Rows[i].Cells[i].Value!=null)
            //    {
            //        num1 += decimal.Parse(this.dataGridView1.Rows[i].Cells[6].Value.ToString());
            //        num2 += decimal.Parse(this.dataGridView1.Rows[i].Cells[7].Value.ToString());
            //        num3 += decimal.Parse(this.dataGridView1.Rows[i].Cells[9].Value.ToString());
            //        num4 += decimal.Parse(this.dataGridView1.Rows[i].Cells[11].Value.ToString());
            //        num5 += decimal.Parse(this.dataGridView1.Rows[i].Cells[12].Value.ToString());
            //    }
            //}
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[6].Value = num1.ToString();
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[7].Value = num2.ToString();
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[9].Value = num3.ToString();
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[11].Value = num4.ToString();
            //this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[12].Value = num5.ToString();
            //txtTotal.Text = sum.ToString();
        }

        public void ShowMenu(bool visible)
        {
            menuStrip1.Visible = visible;
        }

        public int Add()
        {
            DataSet ds = new DataSet();
            //dataGridView1.DataSource = ds.Tables[0];
            //ds.Tables[0].Rows.Add();
            dataGridView1.EndEdit();
            int idx = dataGridView1.Rows.Add();
            dataGridView1.Rows[idx].Cells["no"].Value = idx+1;
            dataGridView1.Rows[idx].Cells["contractdate"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["loadingdate"].Value = DateTime.Now;
            //dataGridView1.Rows[idx].Cells["time"].Value = DateTime.Now;
            //dataGridView1.Rows[idx].Cells["man"].Value = FishEntity.Variable.User.username;
            //dataGridView1.Rows[idx].Cells["puttime"].Value = DateTime.Now;
            //dataGridView1.Rows[idx].Cells["yifang"].Selected = true;
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
                row.Cells["no"].Value = item.cid;
                row.Cells["contractno"].Value = item.contractno;
                row.Cells["id"].Value = item.id;
                //row.Cells["productid"].Value = item.productid;
                //row.Cells["companycode"].Value = item.yifangcode;
                row.Cells["yifang"].Value = item.yifang;
                row.Cells["linkman"].Value = item.linkman;
                row.Cells["companyid"].Value = item.companyid;
                //row.Cells["customerid"].Value = item.customerid;
                //row.Cells["customercode"].Value = item.yi;
                //row.Cells["customer"].Value = item.customer;
                row.Cells["contractdate"].Value = item.contractdate;
                //row.Cells["time"].Value = item.spottime;
                //row.Cells["dollars"].Value = item.weight;
                row.Cells["loadingdate"].Value = item.loadingdate ;
                row.Cells["loadingcode"].Value = item.loadingcode;
                //row.Cells["createman"].Value = item.createman;
                row.Cells["weight"].Value = item.weight;
                row.Cells["quantity"].Value = item.quantity;
                row.Cells["saleman"].Value = item.saleman;
                row.Cells["unitprice"].Value = item.unitprice;
                row.Cells["isdelete"].Value = item.isfinished ==1?"是":"否";
                row.Cells["getw"].Value = item.getw;
                row.Cells["getq"].Value = item.getq;
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

                object val = row.Cells["contractdate"].EditedFormattedValue;

                DateTime temp;
                bool ispass = DateTime.TryParse(val.ToString(), out temp);
                if (ispass == false)
                {
                    row.Cells["contractdate"].ErrorText = "请输入正确的日期";
                    isok = false;
                }

                //val = row.Cells["time"].EditedFormattedValue;
                //ispass = DateTime.TryParse(val.ToString(), out temp);
                //if (ispass == false)
                //{
                //    row.Cells["time"].ErrorText = "请输入正确的日期";
                //    isok = false;
                //}


                val = row.Cells["yifang"].EditedFormattedValue;
                if (val == null)
                {
                    isok = false;
                    row.Cells["yifang"].ErrorText = "请选择单位";
                }

                val = row.Cells["unitprice"].EditedFormattedValue;
                if (val == null)
                {
                    isok = false;
                    row.Cells["unitprice"].ErrorText = "请输入价格";
                //}
                //else
                //{
                //    decimal temp2;
                //    ispass = decimal.TryParse(val.ToString(), out temp2);
                //    if (ispass == false)
                //    {
                //        row.Cells["dollars"].ErrorText = "请输入正确的价格";
                //        isok = false;
                //    }
                }

                //val = row.Cells["rmb"].EditedFormattedValue;
                //if (val == null)
                //{
                //    isok = false;
                //    row.Cells["rmb"].ErrorText = "请输入价格";
                //}
                //else
                //{
                //    decimal temp2;
                //    ispass = decimal.TryParse(val.ToString(), out temp2);
                //    if (ispass == false)
                //    {
                //        row.Cells["rmb"].ErrorText = "请输入正确的价格";
                //        isok = false;
                //    }
                //}

            }

            return isok;
        }
        protected void Save()
        {
            if (Check() == false)
            {
                return;
            }

            dataGridView1.EndEdit();

            List<FishEntity.ContractDetailVo> listNews = new List<FishEntity.ContractDetailVo>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.ContractDetailVo quote = new FishEntity.ContractDetailVo();
                int productid = 0;
                int packages = 0;
                //quote.productid = _productId;
                quote.loadingcode = row.Cells["loadingcode"].Value == null ? "" : row.Cells["loadingcode"].Value.ToString();

                int id = 0;
                if (row.Cells["id"].EditedFormattedValue == null)
                {
                    id = 0;
                }
                else
                {
                    int.TryParse(row.Cells["id"].EditedFormattedValue.ToString(), out id);
                }
                quote.id = id;
                quote.productid = _productId;
                quote.isfinished = 0;
                quote.saleman = row.Cells["saleman"].Value == null ? "" : row.Cells["saleman"].ToString();
                quote.state = row.Cells["state"].EditedFormattedValue == null ? string.Empty : row.Cells["state"].EditedFormattedValue.ToString();
                int companyid = 0;
                int.TryParse(row.Cells["companyid"].Value == null ? "0" : row.Cells["companyid"].Value.ToString(), out companyid);
                quote.companyid = companyid;
                //quote.yifang = row.Cells["yifang"].Value == null ? string.Empty : row.Cells["yifang"].ToString();
                quote.yifang = row.Cells["yifang"].EditedFormattedValue == null ? string.Empty : row.Cells["yifang"].EditedFormattedValue.ToString();
                quote.contractno = row.Cells["contractno"].EditedFormattedValue == null ? "" : row.Cells["contractno"].EditedFormattedValue.ToString();
                quote.linkman = row.Cells["linkman"].EditedFormattedValue == null ? string.Empty : row.Cells["linkman"].EditedFormattedValue.ToString();
                int no = 0;
                int.TryParse(row.Cells["no"].Value == null ? "1" : row.Cells["no"].Value.ToString(), out no);
                quote.cid = no;
                DateTime temp;
                DateTime.TryParse(row.Cells["contractdate"].EditedFormattedValue.ToString(), out temp);
                quote.contractdate = temp;
                DateTime.TryParse(row.Cells["loadingdate"].EditedFormattedValue.ToString(), out temp);
                quote.loadingdate = temp;
                decimal temp2;
                decimal.TryParse(row.Cells["quantity"].EditedFormattedValue == null ? "0" : row.Cells["quantity"].EditedFormattedValue.ToString(), out temp2);
                //decimal.TryParse(row.Cells["quantity"].EditedFormattedValue.ToString(), out temp2);
                quote.quantity = temp2;
                decimal.TryParse(row.Cells["unitprice"].EditedFormattedValue.ToString(), out temp2);
                quote.unitprice = temp2;
                decimal.TryParse(row.Cells["weight"].EditedFormattedValue == null ? "0" : row.Cells["weight"].EditedFormattedValue.ToString(), out temp2);
                quote.weight = temp2;
                decimal.TryParse(row.Cells["getw"].EditedFormattedValue == null ? "0" : row.Cells["getw"].EditedFormattedValue.ToString(), out temp2);
                quote.getw = temp2;
                decimal.TryParse(row.Cells["getq"].EditedFormattedValue == null ? "0" : row.Cells["getq"].EditedFormattedValue.ToString(), out temp2);
                quote.getq = temp2;

                if (row.Cells["isdelete"].Value == null || row.Cells["isdelete"].Value.ToString() == "")
                {
                    quote.isdelete = 0;
                }
                else
                {
                    quote.isdelete = row.Cells["isdelete"].Value.ToString().Equals("有效") ? 0 : 1;
                }

                listNews.Add(quote);
            }

            List<FishEntity.ContractDetailVo> listsource = _bll.GetModelList1(" productid = " +_productId);
            if (listsource != null)
            {
                foreach (ContractDetailVo item in listsource)
                {
                    bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                    if (isExist == false)
                    {
                       bool isDelte = _bll.Delete1(item.id);
                    }
                    //break;
                }
            }
            DateTime loadingdate ;
            decimal getw = 0;
            decimal unitprice = 0;
            decimal quantity = 0;
            decimal weight = 0;
            int latequantity = 0;
            DateTime latestTime = DateTime.MinValue;
            string company = string.Empty;
            string customer = string.Empty;
            foreach (ContractDetailVo item in listNews)
            {
                if (item.id == 0)
                {//createman
                    item.saleman = FishEntity.Variable.User.username;
                    item.createman = item.saleman;
                    item.loadingdate =  item.loadingdate;
                    item.weight = item.weight;
                    item.companyid = item.companyid;
                    item.linkman = item.linkman;
                    item.unitprice = item.unitprice;
                    item.quantity = item.quantity;
                    //item.packages = item.packages;
                    item.state = item.state;
                    item.contractno = item.contractno;
                    item.contractdate = item.contractdate;
                    item.getw = item.getw;
                    item.getq = item.getq;
                    item.yifang = item.yifang;
                    item.loadingcode = item.loadingcode;
                    item.cid = item.cid;
                    //company = item.company;
                    int id = _bll.add(item);
                    if (id > 0)
                    {
                        item.id = id;

                        string qDateStr = item.loadingdate.ToString("yyyy-MM-dd");
                        DateTime qDate = DateTime.Parse(qDateStr);
                        if (qDate > latestTime)
                        {
                            latestTime = qDate;
                            getw = item.getw;
                            unitprice = item.unitprice;
                            quantity = item.quantity;
                            weight = item.weight;
                            //latequantity = item.quantity;
                            company = item.company;
                            //customer = item.customer;
                        }
                    }
                }
                else
                {
                    item.saleman = FishEntity.Variable.User.username;
                    item.loadingdate = item.loadingdate;
                    item.weight = item.weight;
                    item.linkman = item.linkman;
                    item.unitprice = item.unitprice;
                    item.quantity = item.quantity;
                    item.companyid = item.companyid;
                    //item.packages = item.packages;
                    item.state = item.state;
                    item.contractno = item.contractno;
                    item.contractdate = item.contractdate;
                    item.getw = item.getw;
                    item.getq = item.getq;
                    item.yifang = item.yifang;
                    item.loadingcode = item.loadingcode;
                    item.cid = item.cid;
                    //item.linkman = FishEntity.Variable.User.username;
                    bool isUpdate = _bll.Update1(item);
                    //if (isUpdate)
                    //{
                    //    string qTimeStr = item.spotdate.ToString("yyyy-MM-dd") + " " + item.spottime.ToString("HH:mm:ss");
                    //    DateTime qTime = DateTime.Parse(qTimeStr);
                    //    if (qTime > latestTime)
                    //    {
                    //        latestTime = qTime;
                    //        latestprice = item.dollars;
                    //        latedollars = item.dollars;
                    //        latermb = item.rmb;
                    //        laterate = item.rate;
                    //        lateweight = item.weight;
                    //        latequantity = item.quantity;
                    //        company = item.company;
                    //        customer = item.customer;
                    //    }
                    //}
                }
            }

            //重新刷新数据
            List<FishEntity.ContractDetailVo> list = _bll.GetModelList1(" productid=" + _productId);
            SetContractDetail(list);
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row == null) return;
            //e.Row.Cells["man"].Value = FishEntity.Variable.User.username;
            //e.Row.Cells["puttime"].Value = DateTime.Now;
            //e.Row.Cells["price"].Value = "0.00";
            //e.Row.Cells["createman"].Value = FishEntity.Variable.User.username;
            //e.Row.Cells["isdelete"].Value = "有效";
          
             e.Row.Cells["no"].Value = e.Row.Index + 1;
           
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
            Save();
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
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("yifang", StringComparison.OrdinalIgnoreCase) == true)
            {
                FormCompanyList form = new FormCompanyList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                if (form.SelectCompany == null) return;
                dataGridView1.Rows[e.RowIndex].Cells["companyid"].Value = form.SelectCompany.id;
                //dataGridView1.Rows[e.RowIndex].Cells["companycode"].Value = form.SelectCompany.code;
                dataGridView1.Rows[e.RowIndex].Cells["yifang"].Value = form.SelectCompany.fullname;
                //dataGridView1.Rows[e.RowIndex].Cells["customerid"].Value = string.Empty;
                //dataGridView1.Rows[e.RowIndex].Cells["customercode"].Value = string.Empty;
                //dataGridView1.Rows[e.RowIndex].Cells["customer"].Value = string.Empty;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("linkman", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["yifang"].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells["yifang"].Value.ToString()) == true)
                {
                    MessageBox.Show("请先选择单位,再操作。");
                    return;
                }
                int companyId = 0;
                int.TryParse(dataGridView1.Rows[e.RowIndex].Cells["companyid"].Value.ToString(), out companyId);
                UIForms.FormSelectCustomer form = new UIForms.FormSelectCustomer(companyId);
                form.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = form.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    FishEntity.CustomerEntity customer = form.SelectedCustomer;
                    if (customer != null)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["linkman"].Value = customer.name;
                        //dataGridView1.Rows[e.RowIndex].Cells["customercode"].Value = customer.code;
                        //dataGridView1.Rows[e.RowIndex].Cells["customerid"].Value = customer.id;
                    }
                }
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex < 0 ) return;
            //if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            //{
                dataGridView1.Rows[e.RowIndex].Cells["no"].Value = e.RowIndex + 1;
            //}
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            string a = "0";
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SSD");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SSD");
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
