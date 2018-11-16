using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormSelectFish : FormBase
    {
        private int _state = -1;
        private string _condition = string.Empty;

        public FormSelectFish(int state):this(state,string.Empty)
        {

        }
        public FormSelectFish( int state , string where )
        {
            InitializeComponent();
            ReadColumnConfig(dataGridView1, "Set_SelectFish_s");
            _state = state;
            _condition = where;

            dataGridView1.BackgroundColor = this.BackColor;
            InitDataUtil.BindComboBoxData(cmbBand, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CompanyNature, true);
            InitDataUtil.BindComboBoxData(cmbFishType, FishEntity.Constant.FishClass, true);
            InitDataUtil.BindComboBoxData(cmborigin, FishEntity.Constant.Origin, true);
            InitDataUtil.BindComboBoxData(cmbquality, FishEntity.Constant.GoodsEvaluation, true);
            InitDataUtil.BindComboBoxData(cmbTechClass, FishEntity.Constant.TechClass, true);

            this.SetButtomImage(btnQuery);
        }

        protected string GetWhere()
        {
            string where = " 1=1 ";
            if (_state != -1)
            {
                where += " and state4 = " + _state.ToString();
            }
            if (string.IsNullOrEmpty(_condition) == false)
            {
                where += " and ( " + _condition +" )";
            }
            
            if (false == string.IsNullOrEmpty(txtCode.Text))
            {
                where += string.Format(" and code like'%{0}%'", txtCode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtName.Text))
            {
                where += string.Format(" and name like'%{0}%'", txtName.Text.Trim());
            }

            if (cmbBand.SelectedValue != null && cmbBand.SelectedValue .ToString () !=string.Empty )
            {
                where += string.Format(" and brand='{0}'", cmbBand.SelectedValue.ToString());
            }

            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty )
            {
                where += string.Format(" and nature ='{0}'", cmbCountry.SelectedValue.ToString());
            }
            if (cmborigin.SelectedValue != null && cmborigin.SelectedValue.ToString() !=string.Empty  )
            {
                where += string.Format(" and origin ='{0}'", cmborigin.SelectedValue.ToString());
            }
            if (cmbFishType.SelectedValue != null && cmbFishType.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and type ='{0}'", cmbFishType.SelectedValue.ToString());
            }
            if (cmbTechClass.SelectedValue != null && cmbTechClass.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and techtype ='{0}'", cmbTechClass.SelectedValue.ToString());
            }
            if (cmbquality.SelectedValue != null && cmbquality.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and quality ='{0}'", cmbquality.SelectedValue.ToString());
            }

            if (false == string.IsNullOrEmpty(txtSpecifacation.Text))
            {
                where += string.Format(" and specification like'%{0}%'", txtSpecifacation.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtmanufacturers.Text))
            {
                where += string.Format(" and manufacturers like'%{0}%'", txtmanufacturers.Text.Trim());
            }

            return where; 
        }

        protected void Query()
        {
            FishBll.Bll.ProductBll bll = new FishBll.Bll.ProductBll();
            string where = GetWhere ();
            //List<FishEntity.ProductEntity> list = bll.GetModelList(where);
            List<FishEntity.ProductVo> list = bll.GetModelListVo(where);
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = list;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            Query();
        }

        public FishEntity.ProductVo SelectedProduct
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return dataGridView1.CurrentRow.DataBoundItem as FishEntity.ProductVo;
                }
                return null;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_Set_SelectFish_s");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_Set_SelectFish_s");
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
