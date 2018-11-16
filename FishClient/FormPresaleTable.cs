using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPresaleTable : FormMenuBase
    {
        FishBll.Bll.PresaleRequisitionBll _bll = new FishBll.Bll.PresaleRequisitionBll();
        public FormPresaleTable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_123");
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            tmiClose.Visible = false;
        }
        public override int Query()
        {
            string StrWhere = " 1=1 ";
            if (txtdemand.Tag != null && !string.IsNullOrEmpty(txtdemand.Tag.ToString()))
                StrWhere = StrWhere + " AND demandId='" + txtdemand.Tag.ToString() + "'";
            if (!string.IsNullOrEmpty(cmbcode.Text))
                StrWhere = StrWhere + " AND code='" + cmbcode.Text + "'";
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                StrWhere = StrWhere + " AND Signdate>='" + dtpStart.Text + "'";
            if (!string.IsNullOrEmpty(dtpStart.Text.Trim()))
                StrWhere = StrWhere + " AND Signdate<='" + dtpEnd.Text + "'";
            DataTable ds = _bll.getTable(StrWhere);
            if (ds != null && ds.Rows.Count > 0)
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = ds;
                //dataGridView1.Rows.Clear();
                //for (int i = 0; i < ds.Rows.Count; i++)
                //{
                //    int num = dataGridView1.Rows.Add();
                //    DataGridViewRow row = dataGridView1.Rows[num];
                //    row.Cells["id"].Value=
                //}
            }
            else {
                MessageBox.Show("查无数据！");
            }

            return base.Query();
        }

        private void FormPresaleTable_Load(object sender, EventArgs e)
        {
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.CustomFormat = "  ";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.CustomFormat = "  ";
            cmbid.DataSource = _bll.getCode();
            cmbid.DisplayMember = "code";
            cmbcode.DataSource = _bll.getcodeNum();
            cmbcode.DisplayMember = "code";

            cmbid.SelectedIndex = -1;
            cmbcode.SelectedIndex = -1;
            DealDataGridViewHeader();
        }
        void DealDataGridViewHeader()
        {
            UILibrary.TwoDimenDataGridView helper = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header1 = new UILibrary.TwoDimenDataGridView.TopHeader(11, 8, "SGS指标");
            UILibrary.TwoDimenDataGridView.TopHeader header2 = new UILibrary.TwoDimenDataGridView.TopHeader(19, 3, "国内检测指标");
            helper.Headers.Add(header1);
            helper.Headers.Add(header2);
        }

        private void txtdemand_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            if (form.SelectCompany == null)
                return;
            txtdemand.Text = form.SelectCompany.fullname;
            txtdemand.Tag = form.SelectCompany.code;
        }

        private void dtpStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpStart.CustomFormat = "  ";
            }
        }

        private void dtpEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x8)
            {
                this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
                this.dtpEnd.CustomFormat = "  ";
            }
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_123");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_123");
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
