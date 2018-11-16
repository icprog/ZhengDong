using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCallRecordOfCompnay : FormBase
    {
        public FormCallRecordOfCompnay(string companycode )
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_CallRecordOfCompnay");

            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;
            string where = string.Format( "customercode='{0}'", companycode ) ;
            FishBll.Bll.CallRecordsBll bll = new FishBll.Bll.CallRecordsBll();
            List<FishEntity.CallRecordsEntity> list = bll.GetModelList(where);
            dataGridView1.DataSource = list;                        
        }

        private void FormCallRecordOfCompnay_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_CallRecordOfCompnay");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_CallRecordOfCompnay");
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
