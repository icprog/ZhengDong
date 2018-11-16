using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormContractCondition : FormBase
    {
        public FormContractCondition()
        {
            InitializeComponent();

            SetButtomImage(btnOk);
        }

        public string GetWhereCondition
        {
            get
            {
                string where = " 1=1 ";
                if (false == string.IsNullOrEmpty(txtyifang.Text))
                {
                    where += string.Format(" and yifang like '%{0}%'", txtyifang.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtsigndate.Text))
                {
                    where += string.Format(" and signdate like '%{0}%'", txtsigndate.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtsignaddress.Text))
                {
                    where += string.Format(" and signaddress like '%{0}%'", txtsignaddress.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtcontractno.Text))
                {
                    where += string.Format(" and contractno like '%{0}%'  ", txtcontractno.Text.Trim() );
                }            
             
                return where;
            }
        }
    }
}
