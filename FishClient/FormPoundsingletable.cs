using System;
using System . Collections . Generic;
using System . Windows . Forms;

namespace FishClient
{
    public partial class FormPoundsingletable : FormMenuBase
    {
        private FishBll.Bll.OnepoundBll _bll = new FishBll.Bll.OnepoundBll();
        private string _where = string.Empty;
        string _orderBy = " order by id asc ";//limit 1
        private string _rolewhere = string.Empty;
        public FormPoundsingletable()
        {
            InitializeComponent(); ReadColumnConfig(dataGridView1, "Set_122");
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            InitDataUtil.BindComboBoxData(cmbName, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
        }
        public override int Query()
        {
            _where =GetWhereCondition;
            List<FishEntity.OnepoundEntityVo> list = _bll.GetModelListVo(_where + _rolewhere + _orderBy);
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

                if (false == string.IsNullOrEmpty(txtCode.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtCode.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtSerialnumber.Text))
                {
                    where += string.Format(" and Serialnumber like '%{0}%'", txtSerialnumber.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtCarnumber.Text))
                {
                    where += string.Format(" and Carnumber like '%{0}%'", txtCarnumber.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtGoods.Text))
                {
                    where += string.Format(" and Goods like '%{0}%'", txtGoods.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtSellers.Text))
                {
                    where += string.Format(" and Sellers like '%{0}%'", txtSellers.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtBuyers.Text))
                {
                    where += string.Format(" and Buyers like '%{0}%'", txtBuyers.Text.Trim());
                }
                if (cmbName.SelectedValue != null && cmbName.SelectedValue.ToString() != string.Empty)
                {
                    where += string.Format(" and PName ='{0}'", cmbName.SelectedValue.ToString());
                }
                if (cmbSpecification.SelectedValue != null && cmbSpecification.SelectedValue.ToString() != string.Empty)
                {
                    where += string.Format(" and Qualit ='{0}'", cmbSpecification.SelectedValue.ToString());
                }
                if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty)
                {
                    where += string.Format(" and Country ='{0}'", cmbCountry.SelectedValue.ToString());
                }
                //if (false == string.IsNullOrEmpty(txtGrossweight.Text))
                //{
                //    where += string.Format(" and Grossweight like '%{0}%'", txtGrossweight.Text.Trim());
                //}
                //if (false == string.IsNullOrEmpty(txtTareweight.Text))
                //{
                //    where += string.Format(" and Tareweight like '%{0}%'", txtTareweight.Text.Trim());
                //}
                //if (false == string.IsNullOrEmpty(txtCompetition.Text))
                //{
                //    where += string.Format(" and Competition like '%{0}%'", txtCompetition.Text.Trim());
                //}
                //if (false == string.IsNullOrEmpty(txtCompetition.Text))
                //{
                //    where += string.Format(" and Owner like '%{0}%'", txtOwner.Text.Trim());
                //}
                //if (false == string.IsNullOrEmpty(txtAddress.Text))
                //{
                //    where += string.Format(" and Address like '%{0}%'", txtAddress.Text.Trim());
                //}
                //where += string.Format(" and Dateofmanufacture>='{0}' and Dateofmanufacture<='{1}'",
                //    dtpfactureDate.Value.ToString("yyyy-MM-dd 00:00:00"),
                //    dtpfactureDate.Value.ToString("yyyy-MM-dd 23:59:59"));
                //where += string.Format(" and IntothefactoryDate>='{0}' and IntothefactoryDate<='{1}'",
                //    dtpfactoryDate.Value.ToString("yyyy-MM-dd 00:00:00"),
                //    dtpfactoryDate.Value.ToString("yyyy-MM-dd 23:59:59"));
                return where;
            }
        }
        private void txtSellers_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtBuyers.Text = form.SelectCompany.fullname;
            txtBuyers.Tag = form.SelectCompany;
        }

        private void txtBuyers_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtBuyers.Text = form.SelectCompany.fullname;
            txtBuyers.Tag = form.SelectCompany;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
            txtBuyers.Text = string.Empty;
            txtSellers.Text = string.Empty;
            txtSerialnumber.Text = string.Empty;
            txtGoods.Text = string.Empty;
            txtOwner.Text = string.Empty;
            txtCarnumber.Text = string.Empty;
        }

        private void FormPoundsingletable_Load ( object sender ,EventArgs e )
        {
            if ( Megres . oddNum != "" )
            {
                List<FishEntity . OnepoundEntityVo> list = _bll . GetModelListVo ( string . Empty );
                dataGridView1 . AutoGenerateColumns = false;
                dataGridView1 . DataSource = list;
                if ( list == null || list . Count < 1 )
                {
                    MessageBox . Show ( "查无数据" );
                }
            }

            Megres . oddNum = string . Empty;
        }

        private void 设置列宽toolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIForms.FormSetColumnWidth form = new UIForms.FormSetColumnWidth(dataGridView1.Columns, "Set_122");
            form.ShowDialog();

            ReadColumnConfig(dataGridView1, "Set_122");
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
