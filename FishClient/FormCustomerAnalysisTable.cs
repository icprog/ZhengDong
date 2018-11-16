using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{//
    public partial class FormCustomerAnalysisTable : FormMenuBase
    {
        FishBll.Bll.CallRecordsBll _bll = new FishBll.Bll.CallRecordsBll();

        string _rolewhere = string.Empty;
        public string customername = string.Empty;
        public FormCustomerAnalysisTable()
        {
            InitializeComponent();
            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);
            dtsky.Value = DateTime.Now.AddDays(1);
            ReadColumnConfig(dataGridView1, "Set_Client");

            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                cmbTheperson.Enabled = false;
            }
            FishBll.Bll.PersonBll bll = new FishBll.Bll.PersonBll();

            List<FishEntity.PersonEntity> list1 = bll.id_name();
            if (list1 == null)
            {
                list1 = new List<FishEntity.PersonEntity>();
            }
            FishEntity.PersonEntity tmep = new FishEntity.PersonEntity();


            tmep.username = "";
            list1.Insert(0, tmep);

            cmbTheperson.DataSource = list1;
            cmbTheperson.DisplayMember = "username";
            cmbTheperson.ValueMember = "username";
        }
        public override int Query()
        {
            String where = "";
            if (string.IsNullOrEmpty(txtCustomer.Text))
            {
                where += " 1 = 1 ";
            }
            else
            {
                where += "customer ='" + txtCustomer.Text.Trim() + "'";
            }
            string linkmanstr = "";
            foreach (Control ctl in panel2.Controls)
            {
                if (ctl is CheckBox)
                {
                    CheckBox chk = ctl as CheckBox;
                    if (chk.Checked == false) continue;
                    if (chk.Tag == null) continue;
                    FishEntity.CustomerEntity customer = chk.Tag as FishEntity.CustomerEntity;
                    if (customer == null) continue;
                    if (string.IsNullOrEmpty(linkmanstr) == false)
                    {
                        linkmanstr += ",";
                    }
                    linkmanstr += "'" + customer.code + "'";
                }
            }
            if (string.IsNullOrEmpty(linkmanstr) == false)
            {
                where += " and linkmancode in ( " + linkmanstr + " )";
            }
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                where += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
            }
            else
            {
                if (cmbTheperson.Text.ToString() !=string.Empty)
                {
                    where += string.Format(" and createman='{0}' ", cmbTheperson.SelectedValue.ToString());
                }
            }
            if (cmbStatus.Text != null && cmbStatus.Text.ToString().Trim() != "")
            {
                where += " and orderstate like  '%" + cmbStatus.Text.ToString().Trim() + "%'";
            }
            if (cmbQuote.Text == "有报价" && cmbQuote.Text != "")
            {
                where += " and LENGTH(bjqk)>11";
            }
            else if (cmbQuote.Text == "无报价" && cmbQuote.Text != "")
            {
                where += " and LENGTH(bjqk)<=11";
            }
            if (dtsky.Text.ToString() == DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))
            {
                where += string.Format(" and currentdate>='{0}' and currentdate<='{1}' ",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
            }
            else
            {
                where += string.Format(" and currentdate>='{0}' and currentdate<='{1}' ", dtsky.Value.ToString("yyyy-MM-dd 00:00:00"), dtsky.Value.ToString("yyyy-MM-dd 23:59:59"));
            }


            FishBll.Bll.CallRecordsDetailBll bll = new FishBll.Bll.CallRecordsDetailBll();
            List<FishEntity.CallRecordDetailEntityEx> records = bll.GetRecordDetailListByWhere(where + _rolewhere);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = records;
            int sum = 0;
            //for (int i = 0; i < dataGridView1.RowCount; i++)
            //{
            sum += int.Parse(this.dataGridView1.RowCount.ToString());
            // }
            txtnumber.Text = sum.ToString();
            if (records == null || records.Count < 1)
            {
                MessageBox.Show("查无数据");
            }


            return base.Query();
        }

        private void txtCustomer_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtCustomer.Text = form.SelectCompany.fullname;
            txtCustomer.Tag = form.SelectCompany.code;

            FishBll.Bll.CustomerBll bll = new FishBll.Bll.CustomerBll();
            List<FishEntity.CustomerEntity> mans = bll.GetCustomerOfCompany(form.SelectCompany.id);
            if (mans == null)
            {
                mans = new List<FishEntity.CustomerEntity>();
            }
            cmbTheperson.SelectedValue = form.SelectCompany.salesman;
            cmbTheperson.Tag = form.SelectCompany.salesmancode;


            panel2.Controls.Clear();
            foreach (FishEntity.CustomerEntity item in mans)
            {
                CheckBox chk = new CheckBox();
                chk.Text = item.name.Trim();
                chk.Tag = item;
                chk.AutoSize = true;
                chk.Checked = false;
                chk.Dock = DockStyle.Left;
                panel2.Controls.Add(chk);
            }

        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Client");//    
            form.ShowDialog();
            ReadColumnConfig(dataGridView1, "Set_Client");
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
        string where = "";
        public void Load_query() {
            string linkmanstr = "";
            foreach (Control ctl in panel2.Controls)
            {
                if (ctl is CheckBox)
                {
                    CheckBox chk = ctl as CheckBox;
                    if (chk.Checked == false) continue;
                    if (chk.Tag == null) continue;
                    FishEntity.CustomerEntity customer = chk.Tag as FishEntity.CustomerEntity;
                    if (customer == null) continue;
                    if (string.IsNullOrEmpty(linkmanstr) == false)
                    {
                        linkmanstr += ",";
                    }
                    linkmanstr += "'" + customer.code + "'";
                }
            }
            if (string.IsNullOrEmpty(linkmanstr) == false)
            {
                where += " and linkmancode in ( " + linkmanstr + " )";
            }
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                where += string.Format(" and createman='{0}' ", FishEntity.Variable.User.username);
            }
            else
            {
                if (cmbTheperson.SelectedValue.ToString() != string.Empty)
                {
                    where += string.Format(" and createman='{0}' ", cmbTheperson.SelectedValue.ToString());
                }
            }
            if (cmbStatus.Text != null && cmbStatus.Text.ToString().Trim() != "")
            {
                where += " and orderstate like  '%" + cmbStatus.Text.ToString().Trim() + "%'";
            }
            if (cmbQuote.Text == "有报价" && cmbQuote.Text != "")
            {
                where += " and LENGTH(bjqk)>11";
            }
            else if (cmbQuote.Text == "无报价" && cmbQuote.Text != "")
            {
                where += " and LENGTH(bjqk)<=11";
            }
            if (dtsky.Text.ToString() == DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"))
            {
                where += string.Format(" and currentdate>='{0}' and currentdate<='{1}' ",
                dtpStart.Value.ToString("yyyy-MM-dd 00:00:00"),
                dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));
            }
            else
            {
                where += string.Format(" and currentdate>='{0}' and currentdate<='{1}' ", dtsky.Value.ToString("yyyy-MM-dd 00:00:00"), dtsky.Value.ToString("yyyy-MM-dd 23:59:59"));
            }
            FishBll.Bll.CallRecordsDetailBll bll = new FishBll.Bll.CallRecordsDetailBll();
            List<FishEntity.CallRecordDetailEntityEx> records = bll.GetRecordDetailListByWhere(where + _rolewhere);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = records;
            int sum = 0;
            sum += int.Parse(this.dataGridView1.RowCount.ToString());
            txtnumber.Text = sum.ToString();
            if (records == null || records.Count < 1)
            {
                MessageBox.Show("查无数据");
            }
        }
        private void FormCustomerAnalysisTable_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(customername.ToString()))
            {
                
            }
            else
            {
                where += "customer ='" + customername.ToString() + "'";
                txtCustomer.Text = customername.ToString();
                Load_query();
            }
        }
    }
}
