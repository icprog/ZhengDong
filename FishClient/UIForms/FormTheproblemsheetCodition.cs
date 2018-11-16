using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormTheproblemsheetCodition : FormBase
    {
        public FormTheproblemsheetCodition()
        {
            InitializeComponent();
            SetButtomImage(btnOk);
        }
        public string GetWhereCondition
        {
            get {

                string where = " ";
                if (false==string.IsNullOrEmpty(txtContractNo.Text))
                {
                    where += string.Format(" and ContractNo like '%{0}%' ", txtContractNo.Text.Trim());
                }
                if (false==string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like '%{0}%' ", txtcode.Text.Trim());
                }
                return where;
            }                
        }
    }
}
