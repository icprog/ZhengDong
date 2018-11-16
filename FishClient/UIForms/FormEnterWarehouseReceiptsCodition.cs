using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormEnterWarehouseReceiptsCodition : FormMenuBase
    {
        public FormEnterWarehouseReceiptsCodition()
        {
            InitializeComponent();
            SetButtomImage(btnOk);
        }
        public string GetWhereCondition
        {

            get
            {
                string where = " 1=1 ";

                if (false == string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtcode.Text.Trim());
                }
                //if (false == string.IsNullOrEmpty(txtRequester.Text))
                //{
                //    where += string.Format(" and Requester like '%{0}%'", txtRequester.Text.Trim());
                //}
               
                return where;
            }
        }
        private void txtRequester_Click(object sender, EventArgs e)
        {
            //FormCompanyList form = new FormCompanyList();
            //form.StartPosition = FormStartPosition.CenterParent;
            //if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            //if (form.SelectCompany == null) return;
            //txtRequester.Text = form.SelectCompany.fullname;
            //txtRequester.Tag = form.SelectCompany;
        }
    }
}
