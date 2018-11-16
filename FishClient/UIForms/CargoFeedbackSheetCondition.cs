using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class CargoFeedbackSheetCondition : FormBase
    {
        public CargoFeedbackSheetCondition()
        {
            InitializeComponent();
            SetButtomImage(btnOk);
        }
        public string GetWhereCondition
        {

            get
            {
                string where = " 1=1  ";

                if (false == string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtcode.Text.Trim());
                }
                return where;
            }
        }
    }
}
