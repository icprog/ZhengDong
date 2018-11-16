using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCallRecordsReport : FormMenuBase
    {
        private FishBll.Bll.CallRecordsBll _bll = new FishBll.Bll.CallRecordsBll();      
        protected FishEntity.CallRecordsEntity _callRecords = null; 
        public FishEntity.CallRecordsEntity CallRecords
        {
            get
            {
                return _callRecords;
            }
        }

        public FormCallRecordsReport()
        {
            InitializeComponent();

            ReadColumnConfig(dataGridView1, "Set_CallRecordsReport");
            tmiNext.Visible = tmiPrevious.Visible = tmiAdd.Visible = tmiModify.Visible = tmiDelete.Visible = false;
            tmiSave.Visible = false;
            tmiCancel.Visible = false;

            dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.AutoGenerateColumns = false;

            dtpStart.Value = DateTime.Now.AddMonths(-1);
            dtpEnd.Value = DateTime.Now;
        }
                          

        public override int Query()
        {
            string where = GetWhere();
            List<FishEntity.CallRecordsEntity> list = _bll.GetModelList(where);
            dataGridView1.DataSource = list;

            return 1;
        }

        protected string GetWhere() 
        {
            string where = " 1=1 ";

            where += string.Format(" and currentdate >='{0}' and currentdate <='{1}'", dtpStart .Value.ToString("yyyy-MM-dd 00:00:00"), dtpEnd.Value.ToString("yyyy-MM-dd 23:59:59:59") );

            if (string.IsNullOrEmpty(txtCode.Text) == false)
            {
                where += string.Format(" and code like '%{0}%'", txtCode.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtCustmer.Text) == false)
            {
                where += string.Format(" and customer like '%{0}%'", txtCustmer.Text.Trim() );
            }
            if (string.IsNullOrEmpty(txtLevel.Text) == false)
            {
                where += string.Format(" and customerlevel like '%{0}%'", txtLevel.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtlinkman.Text) == false)
            {
                where += string.Format(" and linkman like '%{0}%'", txtlinkman.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtmobile.Text) == false)
            {
                where += string.Format(" and mobile like '%{0}%'" , txtmobile.Text.Trim() );
            }
            if (string.IsNullOrEmpty(txtOfficeTel.Text) == false)
            {
                where += string.Format(" and officetel like '%{0}%'", txtOfficeTel.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtProducts.Text) == false)
            {
                where += string.Format(" and products like '%{0}%'", txtProducts.Text.Trim());
            }
            if (string.IsNullOrEmpty(txtRequired.Text) == false)
            {
                where += string.Format(" and requiredquantity like '%{0}%'", txtRequired.Text.Trim());
            }
                if (string.IsNullOrEmpty( txtTelephone.Text) == false)
            {
                where += string.Format(" and telephone like '%{0}%'", txtTelephone.Text.Trim());
            }

            return where;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if( dataGridView1.CurrentRow  ==null )
            {
                return;
            }
            this._callRecords = dataGridView1.CurrentRow.DataBoundItem as FishEntity.CallRecordsEntity;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;             
        }

        public override int Export()
        {
            List<FishEntity.CallRecordsEntity> list = dataGridView1.DataSource as List<FishEntity.CallRecordsEntity>;
            if (list == null || list.Count < 1) return 0;

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.xls|*.xls";
            if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return 0;

            string filepath = dlg.FileName;
            ExportUtil.ExportCallRecords(list, filepath);
             return 1;
        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_CallRecordsReport");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_CallRecordsReport");
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
