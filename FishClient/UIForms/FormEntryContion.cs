using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormEntryContion : FormBase
    {
        public FormEntryContion()
        {
            InitializeComponent();
            InitDataUtil.BindComboBoxData(cmbBand, FishEntity.Constant.Brand, true);
            InitDataUtil.BindComboBoxData(cmbCountry, FishEntity.Constant.CountryType, true);
            this.SetButtomImage(btnQuery);
        }
        public string GetWhere()
        {
            string where = " 1=1 ";

            if (false == string.IsNullOrEmpty(txtCode.Text))
            {
                where += string.Format(" and code like'%{0}%'", txtCode.Text.Trim());
            }

            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and nature='{0}'", cmbCountry.SelectedValue.ToString());
            }
            if (cmbBand.SelectedValue != null && cmbBand.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and brand='{0}'", cmbBand.SelectedValue.ToString());
            }
            if (cmbCountry.SelectedValue != null && cmbCountry.SelectedValue.ToString() != string.Empty)
            {
                where += string.Format(" and nature ='{0}'", cmbCountry.SelectedValue.ToString());
            }
            if (false == string.IsNullOrEmpty(txtquotesuppliercode.Text))
            {
                where += string.Format(" and supplier like'%{0}%'", txtquotesuppliercode.Text.Trim());
            }
            if (false == string.IsNullOrEmpty(txtquotesuppliercode.Text))
            {
                where += string.Format(" and supplier like'%{0}%'", txtquotesuppliercode.Text.Trim());
            }
            return where;
        }

        private void txtquotesuppliercode_Click(object sender, EventArgs e)
        {
            FormCompanyList form = new FormCompanyList();
            form.StartPosition = FormStartPosition.CenterParent;
            if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            if (form.SelectCompany == null) return;
            txtquotesuppliercode.Text = form.SelectCompany.fullname;
            txtquotesuppliercode.Tag = form.SelectCompany.code;
        }
    }
}
