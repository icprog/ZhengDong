using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormBilloftable :FormMenuBase
    {
        private FishBll.Bll.BillofladingBll _bll = new FishBll.Bll.BillofladingBll();
        private string _where = string.Empty;
        string _orderBy = " order by id asc";//limit 1
        private string _rolewhere = string.Empty; FishEntity.BillofladingEntity _fish = null;
        public FormBilloftable()
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_105");
            InitDataUtil.BindComboBoxData(cmbspecification, FishEntity.Constant.Specification, true);
            InitDataUtil.BindComboBoxData(cmbspecies, FishEntity.Constant.Goods, true);
        }
        public override int Query()
        {
            _where = GetWhereCondition;
            List<FishEntity.BillofladingEntityVo> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
            if (list == null || list.Count < 1)
            {
                MessageBox.Show("查无数据");
            }
            return base.Query();
        }
        public string GetWhereCondition
        {
            get
            {
                string where = " ";
                if (false== string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtcode.Text.ToString());
                }
                if (false == string.IsNullOrEmpty(txtcontactsunit.Text))
                {
                    where += string.Format(" and contactsunit like '%{0}%'",txtcontactsunit.Text.ToString());
                }
                if (false==string.IsNullOrEmpty(txtlistname.Text))
                {
                    where += string.Format(" and listname like '%{0}%'", txtlistname.Text.ToString());
                }
                if (false==string.IsNullOrEmpty(txtferryname.Text))
                {
                    where += string.Format(" and ferryname like '%{0}%'", txtferryname.Text.ToString());
                }
                if (false==string.IsNullOrEmpty(txtwarehouse.Text))
                {
                    where += string.Format(" and warehouse like '%{0}%'", txtwarehouse.Text.ToString());
                }
                if (cmbspecies.SelectedValue!=null&& cmbspecies.SelectedValue.ToString()!=string.Empty)
                {
                    where += string.Format(" and species like '%{0}%'", cmbspecies.SelectedValue.ToString());
                }
                if (cmbspecification.SelectedValue!=null&& cmbspecification.SelectedValue.ToString()!=string.Empty)
                {
                    where += string.Format(" and specification like '%{0}%'", cmbspecification.SelectedValue.ToString());
                }
                return where;
            }
        }
        private void txtcontactsunit_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtcontactsunit.Text = form.SelectCompany.fullname;
            txtcontactsunit.Tag = form.SelectCompany;
        }
        
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)return;
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }
            _model = new FishEntity.BillofladingEntity();
            if (dataGridView1.Rows[e.RowIndex].Cells["ferryname"].Value != null)
            {
                _model.Ferryname = dataGridView1.Rows[e.RowIndex].Cells["ferryname"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["listname"].Value != null)
            {
                _model.Listname = dataGridView1.Rows[e.RowIndex].Cells["listname"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["cornerno"].Value != null)
            {
                _model.Cornerno = dataGridView1.Rows[e.RowIndex].Cells["cornerno"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["warehouse"].Value != null)
            {
                _model.Warehouse = dataGridView1.Rows[e.RowIndex].Cells["warehouse"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["Contactsunit"].Value!=null)
            {
                _model.Contactsunit = dataGridView1.Rows[e.RowIndex].Cells["Contactsunit"].Value.ToString();
            }
            if (dataGridView1.Rows[e.RowIndex].Cells["packagenumber"].Value != null)
            {
                _model.Packagenumber = dataGridView1.Rows[e.RowIndex].Cells["packagenumber"].Value.ToString();
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        FishEntity.BillofladingEntity _model = null;
        public FishEntity.BillofladingEntity bil
        {
            get
            {
                return _model;
            }
        }

        private void FormBilloftable_Load(object sender, EventArgs e)
        {
            if ( Megres . oddNum != "" )
            {
                List<FishEntity . BillofladingEntityVo> list = _bll . GetModelListVo ( string . Empty );
                dataGridView1 . AutoGenerateColumns = false;
                dataGridView1 . DataSource = list;
                if ( list == null || list . Count < 1 )
                {
                    MessageBox . Show ( "查无数据" );
                }
            }

            Megres . oddNum = string . Empty;

            //menuStrip1.Visible = true;

            //tmiAdd.Visible = false;
            //tmiCancel.Visible = false;
            //tmiClose.Visible = false;
            //tmiDelete.Visible = false;
            //tmiExport.Visible = false;
            //tmiModify.Visible = false;
            //tmiNext.Visible = false;
            //tmiPrevious.Visible = false;
            //tmiSave.Visible = false;
            //tmiQuery.Visible = true;
            //_rolewhere = "code='" + Megres.oddNum + "'";

            //List<FishEntity.BillofladingEntityVo> list = _bll.GetModelListVo(_rolewhere);
            //if (list == null || list.Count < 1)
            //{
            //    _fish = null;
            //}
            //else
            //{
            //    _fish = list[0];
            //    //SetOnepound();
            //}
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_105");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_105");
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
