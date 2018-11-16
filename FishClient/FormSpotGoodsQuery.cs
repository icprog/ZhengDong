using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSpotGoodsQuery : FormMenuBase
    {
        private int _fishid = 0;
        FishBll.Bll.SpotBll _bll = new FishBll.Bll.SpotBll();

        public FormSpotGoodsQuery( int fishid)
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SpotGoodsQuery");
            _fishid = fishid;

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_SpotGoodsQuery");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_SpotGoodsQuery");
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
