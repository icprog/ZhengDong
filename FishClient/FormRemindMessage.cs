using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormRemindMessage : FormMenuBase
    {
        public event EventHandler ClickRemindEvent = null;

        public FormRemindMessage()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_RemindMessage");
            tmiAdd.Visible = false;
            tmiModify.Visible = false;
            tmiPrevious.Visible = false;
            tmiNext.Visible = false;
            tmiExport.Visible = false;
            tmiDelete.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.BackgroundColor = this.BackColor;

            Query();
        }

        public override int Query()
        {
            string _rolewhere = string.Empty;
            if (FishEntity.Variable.User.roletype.Equals(FishEntity.Constant.Role_SalesMan))
            {
                _rolewhere = string.Format(" and salesmancode ='{0}'", FishEntity.Variable.User.id);
            }             

            FishBll.Bll.RemindBll bll = new FishBll.Bll.RemindBll();
            string where = " TO_DAYS(nextlinkdate) = TO_DAYS(now())";
            List<FishEntity.RemindEntity> list = bll.GetRemind(where + _rolewhere );
            dataGridView1.DataSource = list;
            return 1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if( e.RowIndex <0 || e.ColumnIndex < 0 ) return;

            if (ClickRemindEvent != null)
            {
                ClickRemindEvent(this, EventArgs.Empty);
            }   
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_RemindMessage");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "formcallrecordstables_1");
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
