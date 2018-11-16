using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    /// <summary>
    /// 需求预测表
    /// </summary>
    public partial class FormRequredForecastReport : FormMenuBase
    {
        private FishBll.Bll.CompanyBll _bll = new FishBll.Bll.CompanyBll();
        private string _where = string.Empty;
        FormCondition _queryForm = null;

        public FormRequredForecastReport()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_RequredForecastReport");
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;
            tmiAdd.Visible = tmiDelete.Visible = tmiModify.Visible = tmiPrevious.Visible = tmiNext.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            label3.Text = "0.00";
            label5.Text = "0.00";
        }

        public override int Query()
        {
            if (_queryForm == null)
            {
                _queryForm = new FormCondition();
            }

            if (_queryForm.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            _where = _queryForm.GetWhereCondition;

            List<FishEntity.CompanyEntity> list = _bll.GetModelList(_where );
            dataGridView1.DataSource = list;

            CalcTotal(list);

            return 1;
        }

        public override int Export()
        {
            List<FishEntity.CompanyEntity> list = dataGridView1.DataSource as List<FishEntity.CompanyEntity>;
            if (list == null || list.Count < 1) return 0;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            string filepath = dlg.FileName;
            ExportUtil.ExportRequreForecast(list, filepath);
            return 0;
        }

        protected void CalcTotal(List<FishEntity.CompanyEntity> list)
        {
            label5.Text = "0.00";
            label3.Text = "0.00";

            if( list == null ) return;
            decimal w = 0;
            decimal m = 0;
            foreach (FishEntity.CompanyEntity item in list)
            {
                decimal temp = 0;
                decimal.TryParse(item.currentweekestimate, out temp);
                w += temp;
                decimal.TryParse(item.currentmonthestimate, out temp);
                m += temp;
            }

            label3.Text = w.ToString("f2");
            label5.Text = m.ToString("f2");
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_RequredForecastReport");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_RequredForecastReport");
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
