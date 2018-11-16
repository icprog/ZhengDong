using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSalesAssessment : FormMenuBase
    {
        FishEntity.SalesAssessmentEntity model = null;
        FishBll.Bll.SalesAssessmentBll bll = null;
        public FormSalesAssessment()
        {
            InitializeComponent();

            ReadColumnConfig(dataGridView1, "Set_142");
        }
        public override int Query()
        {
            bll = new FishBll.Bll.SalesAssessmentBll();
            string where = QuertStrWhere();
            DataTable QuertyTable = bll.getTable(where);
            where = string.Empty;
            if (QuertyTable != null && QuertyTable.Rows.Count > 0)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < QuertyTable.Rows.Count; i++)
                {
                    int idx = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[idx];
                    row.Cells["Numbering"].Value = QuertyTable.Rows[i]["Numbering"].ToString();
                    row.Cells["CODE"].Value = QuertyTable.Rows[i]["CODE"].ToString();
                    row.Cells["demand"].Value = QuertyTable.Rows[i]["demand"].ToString();
                    row.Cells["Signdate"].Value = QuertyTable.Rows[i]["Signdate"].ToString();
                    row.Cells["payment"].Value = QuertyTable.Rows[i]["payment"].ToString();
                    row.Cells["Quantity"].Value = QuertyTable.Rows[i]["Quantity"].ToString();
                    row.Cells["unitprice"].Value = QuertyTable.Rows[i]["unitprice"].ToString();
                    row.Cells["Amonut"].Value = QuertyTable.Rows[i]["Amonut"].ToString();
                    row.Cells["ConfirmTheWeight"].Value = QuertyTable.Rows[i]["ConfirmTheWeight"].ToString();
                    row.Cells["Chargeback"].Value = QuertyTable.Rows[i]["Chargeback"].ToString();
                    row.Cells["fuKuandate"].Value = QuertyTable.Rows[i]["fuKuandate"].ToString();
                    row.Cells["NewRMB"].Value = QuertyTable.Rows[i]["NewRMB"].ToString();
                    row.Cells["createman"].Value = QuertyTable.Rows[i]["createman"].ToString();
                    if (QuertyTable.Rows[i]["RMB"].ToString() != "" && QuertyTable.Rows[i]["RMB"] != null)
                    {
                        row.Cells["RMB"].Value = QuertyTable.Rows[i]["RMB"].ToString();
                    }
                    if (QuertyTable.Rows[i]["ChaoJiLiXi"]!=null&&QuertyTable.Rows[i]["ChaoJiLiXi"].ToString()!="")
                    {
                        row.Cells["ChaoJiLiXi"].Value= QuertyTable.Rows[i]["ChaoJiLiXi"].ToString();
                    }
                    if (QuertyTable.Rows[i]["ConfirmTheWeight"].ToString()!=""&& QuertyTable.Rows[i]["Chargeback"].ToString()!=""&& QuertyTable.Rows[i]["ConfirmTheWeight"]!=null && QuertyTable.Rows[i]["Chargeback"]!= null) { 
                    row.Cells["YingShouJinE"].Value =decimal.Parse(QuertyTable.Rows[i]["unitprice"].ToString())* decimal.Parse(QuertyTable.Rows[i]["ConfirmTheWeight"].ToString())- decimal.Parse(QuertyTable.Rows[i]["Chargeback"].ToString());
                    }
                    if (row.Cells["YingShouJinE"] .Value!=null&& row.Cells["YingShouJinE"].ToString() != "" && row.Cells["YingShouJinE"] != null && QuertyTable.Rows[i]["RMB"].ToString() != "" && QuertyTable.Rows[i]["RMB"] != null)
                    {
                        row.Cells["ChaE"].Value = decimal.Parse(row.Cells["YingShouJinE"].Value.ToString()) - decimal.Parse(QuertyTable.Rows[i]["RMB"].ToString());
                    }
                    if (QuertyTable.Rows[i]["ChaoQiTianShu"].ToString() != "" && QuertyTable.Rows[i]["ChaoQiTianShu"] != null)
                    {
                        row.Cells["ChaoQiTianShu"].Value = QuertyTable.Rows[i]["ChaoQiTianShu"].ToString();
                        // row.Cells["ChaoQiTianShu"].Value = DateTime.Parse(QuertyTable.Rows[i]["payment"].ToString()) - DateTime.Parse(QuertyTable.Rows[i]["fuKuandate"].ToString());
                    }
                    if (QuertyTable.Rows[i]["RMB"].ToString() != "" && QuertyTable.Rows[i]["RMB"] != null && row.Cells["YingShouJinE"].Value != null && row.Cells["YingShouJinE"].ToString() != "" && row.Cells["YingShouJinE"] != null)
                    {
                        row.Cells["ChaoQiJinE"].Value = decimal.Parse(QuertyTable.Rows[i]["RMB"].ToString()) - decimal.Parse(row.Cells["YingShouJinE"].Value.ToString());
                    }
                }
            }
            else {
                MessageBox.Show("查无数据！");
            }
                return base.Query();
        }
        protected string QuertStrWhere()
        {
            string where = " 1=1 ";
            if (string.IsNullOrEmpty(txtNumbering.Text) == false)
            {
                where += string.Format(" and Numbering like '%{0}%'", txtNumbering.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtCODE.Text) == false)
            {
                where += string.Format(" and code like '%{0}%'", txtCODE.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtdemand.Text) == false)
            {
                where += string.Format(" and demand like '%{0}%'", txtdemand.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtcreateman.Text)==false)
            {
                where += string.Format(" and createman like '%{0}%'", txtcreateman.Text.Trim());
            }
            if (!string.IsNullOrEmpty(dtpSigndateStart.Text.Trim()))
            {
                where += " AND Signdate>='" + dtpSigndateStart.Text + "'";
            }
            if (!string.IsNullOrEmpty(dtpSigndateEnd.Text.Trim()))
            {
                where += " AND Signdate<='" + dtpSigndateEnd.Text + "'";
            }
            if (!string.IsNullOrEmpty(dtpfuKuandateStart.Text.Trim()))
            {
                where += " AND fuKuandate>='" + dtpfuKuandateStart.Text + "'";
            }
            if (!string.IsNullOrEmpty(dtpfuKuandateEnd.Text.Trim()))
            {
                where += " AND fuKuandate<='" + dtpfuKuandateEnd.Text + "'";
            }
            return where;
        }

        private void FormSalesAssessment_Load(object sender, EventArgs e)
        {
            this.dtpSigndateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSigndateStart.CustomFormat = "  ";
            this.dtpSigndateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpSigndateEnd.CustomFormat = "  ";

            this.dtpfuKuandateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfuKuandateStart.CustomFormat = "  ";
            this.dtpfuKuandateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpfuKuandateEnd.CustomFormat = "  ";
        }

        private void dtpSigndateStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpSigndateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpSigndateStart.CustomFormat = "  ";
            }
        }

        private void dtpSigndateStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpSigndateStart.CustomFormat = null;
        }

        private void dtpSigndateEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpSigndateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpSigndateEnd.CustomFormat = "  ";
            }
        }

        private void dtpSigndateEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpSigndateEnd.CustomFormat = null;
        }

        private void dtpfuKuandateStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpfuKuandateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpfuKuandateStart.CustomFormat = "  ";
            }
        }

        private void dtpfuKuandateStart_ValueChanged(object sender, EventArgs e)
        {
            this.dtpfuKuandateStart.CustomFormat = null;
        }

        private void dtpfuKuandateEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpfuKuandateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpfuKuandateEnd.CustomFormat = "  ";
            }
        }

        private void dtpfuKuandateEnd_ValueChanged(object sender, EventArgs e)
        {
            this.dtpfuKuandateEnd.CustomFormat = null;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_142");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_142");
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
