using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormLoadingBillList : FormBase
    {
        protected int _companyid = 0;
        public FormLoadingBillList( int id )
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_LoadingBillList");
            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;

            _companyid = id;

            FishBll.Bll.LoadingDetailBll bll = new FishBll.Bll.LoadingDetailBll();
            List<FishEntity.LoadingDetailVo> list = bll.GetDetailOfCompanyId(_companyid);
            dataGridView1.DataSource = list;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_LoadingBillList");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_LoadingBillList");
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
