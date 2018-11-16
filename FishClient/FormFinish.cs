using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormFinish : FormMenuBase
    {
        private int _status = FishEntity.Constant.STATE_FINISHED;
        private FishBll.Bll.FinishBll _bll = new FishBll.Bll.FinishBll();
        private UILibrary.TwoDimenDataGridView _dgvHelper1 = null;
        private UILibrary.TwoDimenDataGridView _dgvHelper2 = null;

        public FormFinish()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_Finish_1");
            ReadColumnConfig(dataGridView2, "Set_Finish_2");
            InitData();
        }

        private void InitData()
        {
            InitDataUtil.BindComboBoxData(cmbBrand, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(cmbNature, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbspeccification, FishEntity.Constant.Specification, true);
            dtpstart.Value = DateTime.Now.AddMonths(-2);
            dtpend.Value = DateTime.Now;
        }

        private string getWhere()
        {
            string where = " state ='"+ _status+"'";
            if( String.IsNullOrEmpty( txtfishcode.Text ) ==false ){
                where += " and code like '%"+ txtfishcode.Text.Trim () +"%'";
            }
            if ( cmbNature.SelectedValue !=null && string.IsNullOrEmpty( cmbNature.SelectedValue.ToString()) ==false )
            {
                where += " and  nature ='"+ cmbNature.SelectedValue.ToString()+"'";
            }
            if (cmbBrand.SelectedValue != null && string.IsNullOrEmpty( cmbBrand.SelectedValue.ToString())==false )
            {
                where += " and brand='" + cmbBrand.SelectedValue.ToString()+"'";
            }
            if (cmbspeccification.SelectedValue != null &&string.IsNullOrEmpty( cmbspeccification.SelectedValue.ToString())==false )
            {
                where += " and specification='" + cmbspeccification.SelectedValue.ToString()+"'";
            }
            if (false==string.IsNullOrEmpty(txtbillofgoods.Text))
            {
                where += string.Format(" and billofgoods like '%{0}%' ",txtbillofgoods.Text.Trim());
            }
            if( string.IsNullOrEmpty( txtsaleman.Text) ==false )
            {
                where += " and saleman like '%"+ txtsaleman.Text.Trim() +"%'";
            }


            if( string.IsNullOrEmpty( txtcustomer.Text )==false )
            {
                where += " and companyname like '%" + txtcustomer.Text.Trim() + "%'";
            }
            where += " and outdate>='"+ dtpstart.Value.ToString("yyyy-MM-dd 00:00:00")+"'";
            where += " and outdate<='"+ dtpend.Value.ToString("yyyy-MM-dd 23:59:59")+"'";

            if (cmbValidate.Text.Equals("有效"))
            {
                where += string.Format(" and isdelete =1");
            }
            else if (cmbValidate.Text.Equals("无效"))
            {
                where += string.Format(" and isdelete= 0 ");
            }

            return where;
        }

        public override int Query()
        {
            string where  =getWhere ();
            List<FishEntity.FinishVo> list = _bll.GetData(where);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.DataSource = list;

            return base.Query();
        }

        private void FormFinish_Load(object sender, EventArgs e)
        {
            tmiAdd.Visible = false;
            tmiCancel.Visible = false;
            tmiDelete.Visible = false;
            tmiExport.Visible = false;
            tmiModify.Visible = false;
            tmiNext.Visible = false;
            tmiPrevious.Visible = false;
            tmiSave.Visible = false;

            _dgvHelper1 = new UILibrary.TwoDimenDataGridView(dataGridView1);
            UILibrary.TwoDimenDataGridView.TopHeader header = new UILibrary.TwoDimenDataGridView.TopHeader();
            header.Index = 7;
            header.Span = 9;
            header.Text = "SGS指标";
            _dgvHelper1.Headers.Add(header);

            _dgvHelper2 = new UILibrary.TwoDimenDataGridView(dataGridView2);
            header = new UILibrary.TwoDimenDataGridView.TopHeader();
            header.Index = 4;
            header.Span = 10;
            header.Text = "实测化验指标";
            _dgvHelper2.Headers.Add(header);

            cmbValidate.Text = "有效";

        }

        private void 设置列宽ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Finish_1");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Finish_1");
        }

        private void 设置列宽ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Finish_2");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Finish_2");
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
