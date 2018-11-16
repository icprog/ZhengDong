using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormCustomerCondition : FormBase
    {
        public FormCustomerCondition()
        {
            InitializeComponent();

            SetButtomImage(btnOk);
        }

        public string GetWhereCondition
        {
            get
            {
                string where = " 1=1 ";
                if (false == string.IsNullOrEmpty(txtCode.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtCode.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtName.Text))
                {
                    where += string.Format(" and name like '%{0}%'",txtName.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtTelephone.Text))
                {
                    where += string.Format(" and telephone like '%{0}%'", txtTelephone.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtPhone1.Text))
                {
                    where += string.Format(" and ( phone1 like '%{0}%' or phone2 like '%{1}%' or phone3 like '%{2}%' ) ", txtPhone1.Text.Trim(),txtPhone1.Text.Trim(), txtPhone1.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtEmail.Text))
                {
                    where += string.Format(" and email like '%{0}%'", txtEmail.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtQQ.Text))
                {
                    where += string.Format(" and qq like '%{0}%'", txtQQ.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtWeixin.Text))
                {
                    where += string.Format(" and weixin like '%{0}%'", txtWeixin.Text.Trim());  
                }
                if (false == string.IsNullOrEmpty(txtCompanyCode.Text))
                {
                    where += string.Format(" and companycode like '%{0}%'", txtCompanyCode.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtCompany.Text))
                {
                    where += string.Format(" and companyname like '%{0}%'", txtCompany.Text.Trim());
                }

                return where;
            }
        }
    }
}
