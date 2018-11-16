using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormDisposeofcommentsCodition : FormBase
    {
        public FormDisposeofcommentsCodition()
        {
            InitializeComponent();
            SetButtomImage(btnOk);
        }
        public string GetWhereCondition
        {
            get {
                string where = " ";
                if (false==string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like '%{0}%' ", txtcode.Text.Trim());
                }
                if (false==string.IsNullOrEmpty(txtFilenumber.Text))
                {
                    where += string.Format(" and Filenumber like '%{0}%' ", txtFilenumber.Text.Trim());
                }
                return where;
            }
        }
    }
}
