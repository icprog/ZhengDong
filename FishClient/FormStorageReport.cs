using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormStorageReport : FormMenuBase
    {
        protected FishBll.Bll.StorageReportBll _Bll = new FishBll.Bll.StorageReportBll();
        //UIForms.FormFishCondition _queryForm = null;

        public FormStorageReport()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_StorageReport");

            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CompanyNature, true);

            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;
            tmiAdd.Visible = tmiModify.Visible = tmiDelete.Visible = tmiPrevious.Visible = tmiNext.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            label3.Text = "0.00";
            label5.Text = "0.00";
            label7.Text = "0.00";
            label8.Text = "0.00";
            dtpStart.Value = DateTime.Now.AddYears(-1);
            dtpEnd.Value = DateTime.Now.AddYears(1);
        }

        protected string GetWhere()
        {
            string where = string.Format( " ( state ='{0}' or state='{1}') ", FishEntity.Constant.STATE_QUOTE , FishEntity.Constant.STATE_GOODS );

            where += string.Format(" and createtime >='{0}' and createtime <='{1}'" , dtpStart.Value.ToString("yyyy-MM-dd 00:00:00") , dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (false == string.IsNullOrEmpty(txtCode.Text))
            {
                where += string.Format(" and code like'%{0}%'", txtCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtName.Text))
            {
                where += string.Format(" and name like'%{0}%'", txtName.Text.Trim());
            }
            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and nature ='{0}'", cmbCountry.SelectedValue.ToString());
            }
            return where;
        }

        public override int Query()
        {
            //if (_queryForm == null)
            //{
            //    _queryForm = new UIForms.FormFishCondition();
            //    _queryForm.StartPosition = FormStartPosition.CenterParent;
            //    _queryForm.ShowInTaskbar = false;
            //}  
            //if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;  
            //string where = _queryForm.GetWhere();

            string where = GetWhere();

            decimal weight = 0;
            int package = 0;
            decimal homeweight = 0;
            int homepackage = 0;

            List<FishEntity.ProductEntity> list = _Bll.Report( where  , out weight , out package , out homeweight ,out homepackage );
            dataGridView1.DataSource = list;

            label3.Text = weight.ToString("f2");
            label5.Text = package.ToString();
            label7.Text = homeweight.ToString("f2");
            label8.Text = homepackage.ToString();

            return 1;
        }

        public override int Export()
        {
            List<FishEntity.ProductEntity> list = dataGridView1.DataSource as List<FishEntity.ProductEntity>;
            if (list == null || list.Count < 1) return 0;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            string filepath = dlg.FileName;
            ExportUtil.ExportStorageReport(list, filepath);
            return 1;
        }

        private void txtCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Query();
            }
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_StorageReport");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_StorageReport");
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
