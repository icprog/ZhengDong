using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormSalesRContractQuery : FormMenuBase
    {
        public FormSalesRContractQuery()
        {
            InitializeComponent();
        }
        public string GetWhereCondition
        {

            get
            {
                string where = " 1=1 ";

                if (false == string.IsNullOrEmpty(txtContractCode.Text))
                {
                    where += string.Format(" and ContractCode like '%{0}%'", txtContractCode.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtNumbering.Text))
                {
                    where += string.Format(" and Numbering like '%{0}%'", txtNumbering.Text.Trim());
                }
                return where;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {

        }
    }
}
