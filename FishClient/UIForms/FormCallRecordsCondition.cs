using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormCallRecordsCondition : FormBase
    {
        public FormCallRecordsCondition()
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
                
                return where;
            }
        }
    }
}
