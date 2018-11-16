using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormOnepoundCondition : FormBase
    {
        //string xiaoshuo = null;
        //string caigou = null;
        public FormOnepoundCondition()
        {
            InitializeComponent();
            InitDataUtil.BindComboBoxData(cmbSpecification, FishEntity.Constant.Specification, true);
            SetButtomImage(btnOk);
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
                if (false == string.IsNullOrEmpty(txtCarnumber.Text))
                {
                    where += string.Format(" and Carnumber like '%{0}%'", txtCarnumber.Text.Trim());
                }
                if (false==string.IsNullOrEmpty(txtSerialnumber.Text))
                {
                   where += string.Format(" and Serialnumber like '%{0}%'", txtSerialnumber.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtGrossweight.Text))
                {
                    where += string.Format(" and Grossweight like '%{0}%'", txtGrossweight.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtTareweight.Text))
                {
                    where += string.Format(" and Tareweight like '%{0}%'", txtTareweight.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtCompetition.Text))
                {
                    where += string.Format(" and Competition like '%{0}%'", txtCompetition.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtGoods.Text))
                {
                    where += string.Format(" and Goods like '%{0}%'", txtGoods.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtCompetition.Text))
                {
                    where += string.Format(" and Owner like '%{0}%'", txtOwner.Text.Trim());
                }
                if (cmbSpecification.SelectedValue != null && cmbSpecification.SelectedValue.ToString() != string.Empty)
                {
                    where += string.Format(" and Qualit ='{0}'", cmbSpecification.SelectedValue.ToString());
                }
                if (false == string.IsNullOrEmpty(txtAddress.Text))
                {
                    where += string.Format(" and Address like '%{0}%'", txtAddress.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(Sellers.Text))
                {
                    where += string.Format(" and Sellers like '%{0}%'", Sellers.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(Buyers.Text))
                {
                    where += string.Format(" and Buyers like '%{0}%'", Buyers.Text.Trim());
                }
                //where += string.Format(" and Dateofmanufacture>='{0}' and Dateofmanufacture<='{1}'",
                //    dtpfactureDate.Value.ToString("yyyy-MM-dd 00:00:00"),
                //    dtpfactureDate.Value.ToString("yyyy-MM-dd 23:59:59"));
                //where += string.Format(" and IntothefactoryDate>='{0}' and IntothefactoryDate<='{1}'",
                //    dtpfactoryDate.Value.ToString("yyyy-MM-dd 00:00:00"),
                //    dtpfactoryDate.Value.ToString("yyyy-MM-dd 23:59:59"));
                return where;
             }
         }

        private void Sellers_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            Sellers.Text = form.SelectCompany.fullname;
            Sellers.Tag = form.SelectCompany;
        }

        private void Buyers_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            Buyers.Text = form.SelectCompany.fullname;
            Buyers.Tag = form.SelectCompany;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
            Buyers.Text = string.Empty;
            Sellers.Text = string.Empty;
            txtSerialnumber.Text = string.Empty;
            txtGoods.Text = string.Empty;
            txtOwner.Text = string.Empty;
            txtCarnumber.Text = string.Empty;
        }

        private void label15_Click(object sender, EventArgs e)
        {
            txtCode.Text = string.Empty;
            Buyers.Text = string.Empty;
            Sellers.Text = string.Empty;
            txtSerialnumber.Text = string.Empty; 
            txtGoods.Text = string.Empty;
            txtOwner.Text = string.Empty;
            txtCarnumber.Text = string.Empty;
        }
    }
}
