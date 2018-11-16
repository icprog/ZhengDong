using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSalesRequisitionCondition : FormMenuBase
    {
        public FormSalesRequisitionCondition()
        {
            InitializeComponent();
        }
        public string GetWhereCondition
        {
            get
            {
                string where = " 1=1 ";

                if (string.IsNullOrEmpty(txtcode.Text) == false)
                {
                    where += string.Format(" and code like '%{0}%'", txtcode.Text.Trim());
                    return where;
                }
                return string.Empty;
            }
        }
    }
}
