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
    public partial class FormSaleDetail : Form
    {
        string _companycode = string.Empty;
        string _customercode = string.Empty;
        int _productId = 0;
        private string _rolewhere = string.Empty;

        public event EventHandler<ProductIdEventArgs> RefreshDataEvent = null;
        FishBll.Bll.SaleBll _bll = new FishBll.Bll.SaleBll();
        public FormSaleDetail()
        {
            InitializeComponent();
        }
        public FormSaleDetail(int productId)
        {
            InitializeComponent();
            _productId = productId;
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere = string.Format(" and companyid in ( select  id from t_company where salesmancode = '{0}' ) ", FishEntity.Variable.User.id);
            }
            else
            {
                _rolewhere = string.Empty;
            }
            List<FishEntity.SaleEntity> list = _bll.GetModelList(" productid=" + _productId + _rolewhere);
            SetSale(list);
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
        protected void SetSale(List<SaleEntity> list)
        {
            dataGridView1.Rows.Clear();
            if (list == null || list.Count < 1) return;
            decimal weight = 0;
            decimal sgsweight = 0;
            decimal keshou = 0;
            foreach (SaleEntity item in list)
            {
                int idx = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[idx];
                row.Cells["id"].Value = item.id;
                row.Cells["no"].Value = item.no;
                row.Cells["companyid"].Value = item.companyid;
                row.Cells["companycode"].Value = item.companycode;
                row.Cells["company"].Value = item.company;
                row.Cells["customerid"].Value = item.customerid;
                row.Cells["customercode"].Value = item.customercode;
                row.Cells["customer"].Value = item.customer;
                row.Cells["date"].Value = item.saledate;
                row.Cells["time"].Value = item.saletime;
                row.Cells["dollars"].Value = item.saledollars;
                row.Cells["man"].Value = item.saleman;
                row.Cells["puttime"].Value = item.saletime;
                row.Cells["createman"].Value = item.createman;
                row.Cells["weight"].Value = item.weight;
                row.Cells["sgsweight"].Value = item.sgsweight;
                row.Cells["saleweight"].Value = item.saleweight;
                row.Cells["rmb"].Value = item.salermb;
                if (item.weight.ToString()!="")
                {
                    weight += item.weight;
                }
                if (item.sgsweight.ToString() != "")
                {
                    sgsweight = item.sgsweight;
                }
                if (item.saleweight.ToString() != "")
                {
                    keshou = item.saleweight;
                }
            }
            txtweight.Text = weight.ToString();
            txtsgsweight.Text = sgsweight.ToString();
            txtshenyu.Text = (sgsweight - weight).ToString();
           txtkeshou.Text=keshou.ToString();
        }
        public int Add()
        {
            dataGridView1.EndEdit();

            int idx = dataGridView1.Rows.Add();
            dataGridView1.Rows[idx].Cells["no"].Value = idx + 1;
            dataGridView1.Rows[idx].Cells["date"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["time"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["man"].Value = FishEntity.Variable.User.username;
            dataGridView1.Rows[idx].Cells["puttime"].Value = DateTime.Now;
            dataGridView1.Rows[idx].Cells["company"].Selected = true;

            return 1;
        }
        protected void Save()
        {
            if (Check() == false)
            {
                return;
            }

            dataGridView1.EndEdit();

            List<FishEntity.SaleEntity> listNews = new List<FishEntity.SaleEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.SaleEntity sale = new FishEntity.SaleEntity();
                int companyid = 0;
                int.TryParse(row.Cells["companyid"].Value == null ? "0" : row.Cells["companyid"].Value.ToString(), out companyid);
                sale.companyid = companyid;
                sale.companycode = row.Cells["companycode"].Value == null ? "" : row.Cells["companycode"].Value.ToString();
                sale.company = row.Cells["company"].Value == null ? "" : row.Cells["company"].Value.ToString();
                int customerid = 0;
                int.TryParse(row.Cells["customerid"].Value == null ? "0" : row.Cells["customerid"].Value.ToString(), out customerid);
                sale.customerid = customerid;
                sale.customercode = row.Cells["customercode"].Value == null ? "" : row.Cells["customercode"].Value.ToString(); ;
                sale.customer = row.Cells["customer"].Value == null ? "" : row.Cells["customer"].Value.ToString();

                int id = 0;
                if (row.Cells["id"].EditedFormattedValue == null)
                {
                    id = 0;
                }
                else
                {
                    int.TryParse(row.Cells["id"].EditedFormattedValue.ToString(), out id);
                }

                sale.id = id;
                sale.isdelete = 0;
                sale.productid = _productId;
                DateTime temp;
                DateTime.TryParse(row.Cells["date"].EditedFormattedValue.ToString(), out temp);
                sale.saledate = temp;
                sale.saleman = row.Cells["man"].EditedFormattedValue == null ? string.Empty : row.Cells["man"].EditedFormattedValue.ToString();

                DateTime.TryParse(row.Cells["time"].EditedFormattedValue.ToString(), out temp);
                sale.saletime = temp;

                decimal temp2;
                decimal.TryParse(row.Cells["dollars"].EditedFormattedValue.ToString(), out temp2);
                sale.saledollars = temp2;

                sale.createman = row.Cells["createman"].EditedFormattedValue == null ? string.Empty : row.Cells["createman"].EditedFormattedValue.ToString();

                decimal.TryParse(row.Cells["rmb"].EditedFormattedValue.ToString(), out temp2);
                sale.salermb = temp2;

                int no = 0;
                int.TryParse(row.Cells["no"].Value == null ? "1" : row.Cells["no"].Value.ToString(), out no);
                sale.no = no;

                decimal.TryParse(row.Cells["weight"].EditedFormattedValue == null ? "0" : row.Cells["weight"].EditedFormattedValue.ToString(), out temp2);
                sale.weight = temp2;
                decimal.TryParse(row.Cells["sgsweight"].EditedFormattedValue == null ? "0" : row.Cells["sgsweight"].EditedFormattedValue.ToString(), out temp2);
                sale.sgsweight = temp2;
                decimal.TryParse(row.Cells["saleweight"].EditedFormattedValue == null ? "0" : row.Cells["saleweight"].EditedFormattedValue.ToString(), out temp2);
                sale.saleweight = temp2;

                /////////////////

                listNews.Add(sale);
            }
            List<FishEntity.SaleEntity> listsource = _bll.GetModelList(" productid=" + _productId);
            if (listsource != null)
            {
                foreach (SaleEntity item in listsource)
                {
                    bool isExist = listNews.Exists((i) => { return i.id == item.id; });
                    if (isExist == false)
                    {
                        bool isDelte = _bll.Delete(item.id);
                    }
                }
            }

            decimal latestprice = 0;
            decimal latedollars = 0;
            decimal latermb = 0;
            decimal laterate = 0;
            decimal lateweight = 0;
            int latequantity = 0;
            DateTime latestTime = DateTime.MinValue;
            string company = string.Empty;
            string customer = string.Empty;
            foreach (SaleEntity item in listNews)
            {
                if (item.id == 0)
                {
                    item.createman = FishEntity.Variable.User.username;
                    item.createtime = DateTime.Now;
                    item.modifyman = item.createman;
                    item.modifytime = item.createtime;

                    int id = _bll.Add(item);
                    if (id > 0)
                    {
                        item.id = id;

                        string qDateStr = item.saledate.Value.ToString("yyyy-MM-dd") + " " + item.saletime.Value.ToString("HH:mm:ss");
                        DateTime qDate = DateTime.Parse(qDateStr);
                        if (qDate > latestTime)
                        {
                            latestTime = qDate;
                            latestprice = item.saledollars;
                            latedollars = item.saledollars;
                            latermb = item.salermb;
                            lateweight = item.weight;
                            company = item.company;
                            customer = item.customer;
                        }
                    }
                }
                else
                {
                    item.modifytime = DateTime.Now;
                    item.modifyman = FishEntity.Variable.User.username;
                    bool isUpdate = _bll.Update(item);
                    if (isUpdate)
                    {
                        string qTimeStr = item.saledate.Value.ToString("yyyy-MM-dd") + " " + item.saletime.Value.ToString("HH:mm:ss");
                        DateTime qTime = DateTime.Parse(qTimeStr);
                        if (qTime > latestTime)
                        {
                            latestTime = qTime;
                            latestprice = item.saledollars;
                            latedollars = item.saledollars;
                            latermb = item.salermb;
                            lateweight = item.weight;
                            company = item.company;
                            customer = item.customer;
                        }
                    }
                }
            }

            //重新刷新数据
            List<FishEntity.SaleEntity> list = _bll.GetModelList(" productid=" + _productId);
            SetSale(list);           
        }
        private bool Check()
        {

            if (dataGridView1.Rows.Count < 1) return true;

            bool isok = true;
            List<FishEntity.SaleEntity> listNews = new List<FishEntity.SaleEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                row.Cells["company"].ErrorText = "";
                row.Cells["dollars"].ErrorText = "";
                row.Cells["rmb"].ErrorText = "";

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
                if (val == null || string.IsNullOrEmpty(val.ToString()))
                {
                    isok = false;
                    row.Cells["company"].ErrorText = "请选择单位";
                }

                val = row.Cells["dollars"].EditedFormattedValue;
                if (val == null || string.IsNullOrEmpty(val.ToString()))
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
                if (val == null || string.IsNullOrEmpty(val.ToString()))
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

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["no"].Value = i + 1;
            }
            return 1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("company", StringComparison.OrdinalIgnoreCase) == true)
            {
                FormCompanyList form = new FormCompanyList();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                if (form.SelectCompany == null) return;
                dataGridView1.Rows[e.RowIndex].Cells["companyid"].Value = form.SelectCompany.id;
                dataGridView1.Rows[e.RowIndex].Cells["companycode"].Value = form.SelectCompany.code;
                dataGridView1.Rows[e.RowIndex].Cells["company"].Value = form.SelectCompany.fullname;
                dataGridView1.Rows[e.RowIndex].Cells["customerid"].Value = string.Empty;
                dataGridView1.Rows[e.RowIndex].Cells["customercode"].Value = string.Empty;
                dataGridView1.Rows[e.RowIndex].Cells["customer"].Value = string.Empty;
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("customer", StringComparison.OrdinalIgnoreCase) == true)
            {
                if (dataGridView1.Rows[e.RowIndex].Cells["company"].Value == null || string.IsNullOrEmpty(dataGridView1.Rows[e.RowIndex].Cells["company"].Value.ToString()) == true)
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
                        dataGridView1.Rows[e.RowIndex].Cells["customer"].Value = customer.name;
                        dataGridView1.Rows[e.RowIndex].Cells["customercode"].Value = customer.code;
                        dataGridView1.Rows[e.RowIndex].Cells["customerid"].Value = customer.id;
                    }
                }
            }

            
            ////
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("btnasync", StringComparison.OrdinalIgnoreCase) == true)
            {
                //
                if (Check() == false)
                {
                    return;
                }

                decimal latestprice = 0;
                decimal latedollars = 0;
                decimal latermb = 0;
                decimal lateweight = 0;
                string latedate;
                decimal laterate;
                string companycode;
                string companyname;
                string customercode;
                string customername;
                int latequantity = 0;


                DateTime latestTime = DateTime.MinValue;
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                int id = 0;
                object obj = row.Cells["id"].EditedFormattedValue;
                if (obj == null)
                {
                    id = 0;
                }
                else
                {
                    int.TryParse(obj.ToString(), out id);
                }

                decimal temp2;
                decimal.TryParse(row.Cells["dollars"].EditedFormattedValue.ToString(), out temp2);
                latedollars = temp2;

                decimal.TryParse(row.Cells["rmb"].EditedFormattedValue.ToString(), out temp2);
                latermb = temp2;

                decimal.TryParse(row.Cells["weight"].EditedFormattedValue == null ? "0" : row.Cells["weight"].EditedFormattedValue.ToString(), out temp2);
                lateweight = temp2;
                int quantity = 0;

                DateTime quotedate;
                DateTime.TryParse(row.Cells["date"].EditedFormattedValue.ToString(), out quotedate);
                DateTime quotetime;
                DateTime.TryParse(row.Cells["time"].EditedFormattedValue.ToString(), out quotetime);
                latedate = quotedate.ToString("yyyy/MM/dd") + " " + quotetime.ToString("HH:mm:ss");
                decimal rmb = 0;
                decimal.TryParse(row.Cells["rmb"].EditedFormattedValue == null ? "0" : row.Cells["rmb"].EditedFormattedValue.ToString(), out temp2);
                rmb = temp2;
                decimal shenyu = 0;
                decimal.TryParse(txtshenyu.Text == null ? "0" : txtshenyu.Text.ToString(), out temp2);
                shenyu = temp2;
                decimal weight = 0;
                decimal.TryParse(row.Cells["weight"].EditedFormattedValue == null ? "0" : row.Cells["weight"].EditedFormattedValue.ToString(), out temp2);
                weight = temp2;
                bool isok = _bll.UpdateLatestSale(_productId, latedate, rmb, shenyu, weight);
                if (isok)
                {
                    OnRefreshData(_productId, latedate, rmb, shenyu, weight);
                    MessageBox.Show("同步成功");
                }
                else
                {
                    MessageBox.Show("同步失败");
                }
            }

        }
        protected void OnRefreshData(int productid, string date, decimal rmb, decimal txtshenyu, decimal weight)
        {
            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, new ProductIdEventArgs(_productId, date, rmb, txtshenyu, weight));
            }
        }
        public class ProductIdEventArgs : EventArgs
        {
            private int _productid;
            public int productid { get { return _productid; } set { _productid = value; } }
            private decimal _latestedprice = 0;
            private decimal _dollars = 0;
            public decimal dollars { get { return _dollars; } set { _dollars = value; } }
            private decimal _rmb = 0;
            public decimal rmb { get { return _rmb; } set { _rmb = value; } }
            private decimal _rate = 0;
            public decimal rate { get { return _rate; } set { _rate = value; } }
            public decimal latestedprice { get { return _latestedprice; } set { _latestedprice = value; } }

            private string _latequotedate = "";
            public string latequotedate { get { return _latequotedate; } set { _latequotedate = value; } }

            private string _company = string.Empty;
            public string company { get { return _company; } set { _company = value; } }
            private string _customer = string.Empty;
            public string customer { get { return _customer; } set { _customer = value; } }

            private decimal _weight = 0;
            public decimal weight { get { return _weight; } set { _weight = value; } }
            private int _quantity = 0;
            public int quantity { get { return _quantity; } set { _quantity = value; } }
            private decimal _txtshenyu = 0;
            public decimal txtshenyu { get { return _txtshenyu; } set { _txtshenyu = value; } }
            private string date;
            public string _date { get { return date; } set { date = value; } }
            public ProductIdEventArgs(int productid, string date, decimal rmb, decimal txtshenyu, decimal weight)
            {
                _productid = productid;
                _date = date;
                _rmb = rmb;
                _txtshenyu = txtshenyu;
                _weight = weight;
            }
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                dataGridView1.Rows[e.RowIndex].Cells["no"].Value = e.RowIndex + 1;
            }
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row == null) return;
            e.Row.Cells["man"].Value = FishEntity.Variable.User.username;
            e.Row.Cells["puttime"].Value = DateTime.Now;
            e.Row.Cells["price"].Value = "0.00";
            e.Row.Cells["createman"].Value = FishEntity.Variable.User.username;
        }
    }
}
