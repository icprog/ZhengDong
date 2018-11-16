using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCustomerAnalysisReport : FormMenuBase
    {
        protected FishBll.Bll.CustomerAnalysisReportBll _bll = new FishBll.Bll.CustomerAnalysisReportBll();

        public FormCustomerAnalysisReport()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_Client_S");
            tmiAdd.Visible = tmiDelete.Visible = tmiPrevious.Visible = tmiNext.Visible = tmiModify.Visible  = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiExport.Visible = false;
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns["cashdeposit"].Visible = false;
            dataGridView1.Columns["manageprojects"].Visible = false;
            dataGridView1.Columns["paymethod"].Visible = false;
            dataGridView1.Columns["products"].Visible = false;
            dataGridView1.Columns["requiredproduct"].Visible = false;
            dataGridView1.Columns["competitors"].Visible = false;
            dataGridView1.Columns["estimatepurchasetime"].Visible = false;
            dataGridView1.Columns["salesman"].Visible = false;
            dataGridView1.Columns["customerproperty"].Visible = false;
            dataGridView1.Columns["fatures"].Visible = false;
            dataGridView1.Columns["customergroup"].Visible = false;    
        }

        protected string GetWhere()
        {
            string where = "1=1 ";
            if (false == string.IsNullOrEmpty(txtCode.Text))
            {
                where += string.Format(" and code like '%{0}%'", txtCode.Text.Trim());
            }
            if( false == string.IsNullOrEmpty(txtfullname.Text.Trim()))
            {
                where +=string.Format (" and fullname like '%{0}%'",txtfullname.Text.Trim());
            }
            if( false == string.IsNullOrEmpty(txtshortname.Text.Trim()))
            {
                where +=string.Format (" and shortname like '%{0}%'",txtshortname.Text.Trim());
            }
            if (rdbAgent.Checked)
            {
                where += string.Format( " and type_agents='{0}' " , 1);
            }
            if (rdbcustomer.Checked)
            {
                where += string.Format(" and type_customer='{0}'", 1);
            }
            if (rdbgoods.Checked)
            {
                where += string.Format(" and type_goods='{0}'", 1);
            }
            if (rdbmy.Checked)
            {
                where += string.Format(" and type_merchants='{0}'", 1);
            }
            if (rdbquote.Checked)
            {
                where += string.Format(" and type_quote='{0}'", 1);
            }
            if (rdbSuppliers.Checked)
            {
                where += string.Format(" and type_suppliers='{0}'", 1);
            }

            return where;
        }

        public override int Query()
        {
            string where = GetWhere();

            List<FishEntity.CompanyEntity> list = _bll.Reports(where);
            dataGridView1.DataSource = list;

            return 1;
        }

        private void ckbAgent_CheckedChanged(object sender, EventArgs e)
        {
            
            dataGridView1.Columns["cashdeposit"].Visible = ckbAgent.Checked;
        }

        private void ckbSupplier_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["manageprojects"].Visible = ckbSupplier.Checked;
            dataGridView1.Columns["paymethod"].Visible = ckbSupplier.Checked;
            //dataGridView1.Columns["cashdeposit"].Visible = !ckbSupplier.Checked;
        }

        private void ckbmy_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["manageprojects"].Visible = ckbmy.Checked;
            dataGridView1.Columns["paymethod"].Visible = ckbmy.Checked;
            //dataGridView1.Columns["cashdeposit"].Visible = !ckbmy.Checked;
        }

        private void ckbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["products"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["requiredproduct"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["competitors"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["estimatepurchasetime"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["salesman"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["customerproperty"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["fatures"].Visible = ckbCustomer.Checked;
            dataGridView1.Columns["customergroup"].Visible = ckbCustomer.Checked;           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("operate1", StringComparison.OrdinalIgnoreCase) )
            {
                string companycode = dataGridView1.Rows[e.RowIndex].Cells["code"].Value.ToString();
                FormCallRecordOfCompnay form = new FormCallRecordOfCompnay (companycode );
                form.ShowInTaskbar = false;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name.Equals("operate2", StringComparison.OrdinalIgnoreCase))
            {       
                int companyid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["id"].Value.ToString());
                FormLoadingBillList form = new FormLoadingBillList(companyid);
                form.ShowInTaskbar = false;
                form.StartPosition = FormStartPosition.CenterParent;
                form.ShowDialog();
            }
        }

        private void rdbAgent_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["cashdeposit"].Visible = rdbAgent.Checked;

            dataGridView1.Columns["manageprojects"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["paymethod"].Visible = !rdbAgent.Checked;

            dataGridView1.Columns["products"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["requiredproduct"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["competitors"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["estimatepurchasetime"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["salesman"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["customerproperty"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["fatures"].Visible = !rdbAgent.Checked;
            dataGridView1.Columns["customergroup"].Visible = !rdbAgent.Checked;           


        }

        private void rdbSuppliers_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["manageprojects"].Visible = rdbSuppliers.Checked;
            dataGridView1.Columns["paymethod"].Visible = rdbSuppliers.Checked;

            dataGridView1.Columns["cashdeposit"].Visible = !rdbSuppliers.Checked;

            dataGridView1.Columns["products"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["requiredproduct"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["competitors"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["estimatepurchasetime"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["salesman"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["customerproperty"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["fatures"].Visible = !rdbSuppliers.Checked;
            dataGridView1.Columns["customergroup"].Visible = !rdbSuppliers.Checked;           


        }

        private void rdbmy_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["manageprojects"].Visible = rdbmy.Checked;
            dataGridView1.Columns["paymethod"].Visible = rdbmy.Checked;

            dataGridView1.Columns["cashdeposit"].Visible = !rdbmy.Checked;

            dataGridView1.Columns["products"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["requiredproduct"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["competitors"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["estimatepurchasetime"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["salesman"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["customerproperty"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["fatures"].Visible = !rdbmy.Checked;
            dataGridView1.Columns["customergroup"].Visible = !rdbmy.Checked;           

        }

        private void rdbcustomer_CheckedChanged(object sender, EventArgs e)
        {
            dataGridView1.Columns["products"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["requiredproduct"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["competitors"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["estimatepurchasetime"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["salesman"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["customerproperty"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["fatures"].Visible = rdbcustomer.Checked;
            dataGridView1.Columns["customergroup"].Visible = rdbcustomer.Checked;

            dataGridView1.Columns["manageprojects"].Visible =! rdbcustomer.Checked;
            dataGridView1.Columns["paymethod"].Visible = !rdbcustomer.Checked;

            dataGridView1.Columns["cashdeposit"].Visible = !rdbcustomer.Checked;
        }

        private void rdbquote_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbgoods_CheckedChanged(object sender, EventArgs e)
        {

        }

        public override int Export()
        {

            return 1;
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if( e.KeyCode==Keys.Enter)
            {
                Query();
            }
        }

        private void FormCustomerAnalysisReport_Load(object sender, EventArgs e)
        {

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Client_S");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Client_S");
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
