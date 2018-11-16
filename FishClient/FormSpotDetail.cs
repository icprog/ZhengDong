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
    public partial class FormSpotDetail : Form
    {
        string _companycode = string.Empty;
        string _customercode = string.Empty;
        int _productId = 0;
        FishBll.Bll.SpotBll _bll = new FishBll.Bll.SpotBll();
        public event EventHandler<ProductIdEventArgs> RefreshDataEvent = null;
        private string _rolewhere = string.Empty;

        protected void OnRefreshData(int productid, decimal latestPrice , decimal latedollars , 
            decimal latermb,decimal laterate , string lateDate, string company,string customer, decimal weight ,int quantity)
        {
            if (RefreshDataEvent != null)
            {
                RefreshDataEvent(this, new ProductIdEventArgs(productid, latestPrice , 
                    latedollars ,latermb , laterate ,lateDate, company , customer  ,weight ,quantity ));
            }
        }

        public FormSpotDetail(int productId)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_Sp");
            dataGridView1.BackgroundColor = this.BackColor;

            //_companyId = companyId;
            //_customerId = customerId;
            //_companycode = companycode;
            //_customercode = customercode;

            _productId = productId;

            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere = string.Format(" and companyid in ( select  id from t_company where salesmancode = '{0}' ) ", FishEntity.Variable.User.id);
            }
            else
            {
                _rolewhere = string.Empty;
            }

            List<FishEntity.SpotEntity> list = _bll.GetModelList(" productid=" + _productId+ _rolewhere );
            SetSpot(list);
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

            Save();
        }

        protected void SetSpot(List<SpotEntity> list)
        {
            dataGridView1.Rows.Clear();
            if (list == null || list.Count < 1) return;

            foreach (SpotEntity item in list)
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
                row.Cells["date"].Value = item.spotdate;
                row.Cells["time"].Value = item.spottime;
                row.Cells["dollars"].Value = item.dollars;
                row.Cells["man"].Value = item.spotman;
                row.Cells["puttime"].Value = item.spottime;
                row.Cells["createman"].Value = item.createman;
                row.Cells["weight"].Value = item.weight;
                row.Cells["quantity"].Value = item.quantity;
                row.Cells["rmb"].Value = item.rmb;
                row.Cells["rate"].Value = item.rate;
                row.Cells["isdelete"].Value = item.isdelete == 0 ? "有效" : "无效" ;
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

        protected void Save()
        {
            if (Check() == false)
            {
                return;
            }

            dataGridView1.EndEdit();

            List<FishEntity.SpotEntity> listNews = new List<FishEntity.SpotEntity>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                FishEntity.SpotEntity quote = new FishEntity.SpotEntity();
                int companyid = 0;
                int.TryParse(row.Cells["companyid"].Value == null ? "0" : row.Cells["companyid"].Value.ToString(),out companyid );               
                quote.companyid = companyid;
                quote.companycode = row.Cells["companycode"].Value ==null ? "": row.Cells["companycode"].Value.ToString() ;
                quote.company = row.Cells["company"].Value == null ? "" : row.Cells["company"].Value.ToString();
                int customerid = 0;
                int.TryParse(row.Cells["customerid"].Value == null ? "0" : row.Cells["customerid"].Value.ToString(), out customerid);             
                quote.customerid = customerid;
                quote.customercode = row.Cells["customercode"].Value == null ? "" : row.Cells["customercode"].Value.ToString(); ;
                quote.customer = row.Cells["customer"].Value == null ? "" : row.Cells["customer"].Value.ToString();

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
                quote.isdelete = 0;
                quote.productid = _productId;
                DateTime temp;
                DateTime.TryParse(row.Cells["date"].EditedFormattedValue.ToString(), out temp);
                quote.spotdate = temp;
                quote.spotman = row.Cells["man"].EditedFormattedValue == null ? string.Empty : row.Cells["man"].EditedFormattedValue.ToString();

                DateTime.TryParse(row.Cells["time"].EditedFormattedValue.ToString(), out temp);
                quote.spottime = temp;

                decimal temp2;
                decimal.TryParse(row.Cells["dollars"].EditedFormattedValue.ToString(), out temp2);
                quote.dollars = temp2;

                quote.createman = row.Cells["createman"].EditedFormattedValue == null ? string.Empty : row.Cells["createman"].EditedFormattedValue.ToString();

                decimal.TryParse(row.Cells["rmb"].EditedFormattedValue.ToString(), out temp2);
                quote.rmb = temp2;

                int no = 0;
                int.TryParse(row.Cells["no"].Value == null ? "1" : row.Cells["no"].Value.ToString(), out no);
                quote.no = no;

                decimal.TryParse ( row.Cells["weight"].EditedFormattedValue ==null ? "0": row.Cells["weight"].EditedFormattedValue.ToString () , out temp2 );
                quote.weight = temp2;

                int quantity=0;
                int.TryParse ( row .Cells["quantity"].EditedFormattedValue ==null ? "0": row.Cells["quantity"].EditedFormattedValue .ToString(),out quantity );
                quote.quantity=quantity;

                decimal.TryParse( row.Cells["rate"].EditedFormattedValue ==null ? "0": row.Cells ["rate"].EditedFormattedValue .ToString(), out temp2);
                quote.rate = temp2;

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


            List<FishEntity.SpotEntity> listsource = _bll.GetModelList(" productid=" + _productId);
            if (listsource != null)
            {
                foreach (SpotEntity item in listsource)
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
            DateTime latestTime = DateTime.Now;//MinValue;
            string company = string.Empty;
            string customer = string.Empty;
            foreach (SpotEntity item in listNews)
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

                        string qDateStr = item.spotdate.ToString("yyyy-MM-dd") + " " + item.spottime.ToString("HH:mm:ss");                        
                        DateTime qDate = DateTime.Parse(qDateStr);
                        if (qDate > latestTime)
                        {
                            latestTime = qDate;
                            latestprice = item.dollars;
                            latedollars = item.dollars;
                            latermb = item.rmb;
                            laterate = item.rate;
                            lateweight = item.weight;
                            latequantity = item.quantity;
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
                        string qTimeStr = item.spotdate.ToString("yyyy-MM-dd") + " " + item.spottime.ToString("HH:mm:ss");
                        DateTime qTime = DateTime.Parse(qTimeStr);
                        if (qTime > latestTime)
                        {
                            latestTime = qTime;
                            latestprice = item.dollars;
                            latedollars = item.dollars;
                            latermb = item.rmb;
                            laterate = item.rate;
                            lateweight = item.weight;
                            latequantity = item.quantity;
                            company = item.company;
                            customer = item.customer;
                        }
                    }
                }
            }

            //重新刷新数据
            List<FishEntity.SpotEntity> list = _bll.GetModelList(" productid=" + _productId);
            SetSpot(list);

            //bool isok = _bll.UpdateSpotInfo(_productId);
            //if (isok)
            //{
            //    OnRefreshData(_productId, latestprice,latedollars , latermb ,
            //        laterate, latestTime.ToString("yyyy/MM/dd HH:mm:ss"), company , customer ,lateweight,latequantity);
            //}
        }



        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (e.Row == null) return;
            e.Row.Cells["man"].Value = FishEntity.Variable.User.username;
            e.Row.Cells["puttime"].Value = DateTime.Now;
            e.Row.Cells["price"].Value = "0.00";
            e.Row.Cells["createman"].Value = FishEntity.Variable.User.username;
            e.Row.Cells["isdelete"].Value = "有效";
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
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("btnasync", StringComparison.OrdinalIgnoreCase) == true)
            {
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

                DateTime latestTime = DateTime.Now;//MinValue;
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

                companycode = row.Cells["companycode"].Value == null ? "" : row.Cells["companycode"].Value.ToString();
                companyname = row.Cells["company"].Value == null ? "" : row.Cells["company"].Value.ToString();

                customercode = row.Cells["customercode"].Value == null ? "" : row.Cells["customercode"].Value.ToString(); ;
                customername = row.Cells["customer"].Value == null ? "" : row.Cells["customer"].Value.ToString();
                 //重量
                decimal.TryParse(row.Cells["weight"].EditedFormattedValue == null ? "0" : row.Cells["weight"].EditedFormattedValue.ToString(), out temp2);
                lateweight = temp2;

                int quantity = 0;
                int.TryParse(row.Cells["quantity"].EditedFormattedValue == null ? "0" : row.Cells["quantity"].EditedFormattedValue.ToString(), out quantity);
                latequantity = quantity;

                DateTime quotedate;
                DateTime.TryParse(row.Cells["date"].EditedFormattedValue.ToString(), out quotedate);
                DateTime quotetime;
                DateTime.TryParse(row.Cells["time"].EditedFormattedValue.ToString(), out quotetime);
                latedate = quotedate.ToString("yyyy/MM/dd") + " " + quotetime.ToString("HH:mm:ss");

                decimal.TryParse(row.Cells["rate"].EditedFormattedValue == null ? "0" : row.Cells["rate"].EditedFormattedValue.ToString(), out temp2);
                laterate = temp2;

                bool isok = _bll.UpdateSpotInfo(_productId, latedollars, latermb, companycode, companyname,
                    customercode, customername, latedate, lateweight, latequantity, latedate );
                if (isok)
                {
                    OnRefreshData(_productId, latestprice, latedollars, latermb,laterate, latestTime.ToString("yyyy/MM/dd HH:mm:ss"), companyname, customername, lateweight, latequantity);
                    MessageBox.Show("同步成功");
                }
                else
                {
                    MessageBox.Show("同步失败");
                }
            }

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Sp");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Sp");
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
