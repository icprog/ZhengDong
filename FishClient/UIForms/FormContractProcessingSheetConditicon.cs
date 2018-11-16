using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormContractProcessingSheetConditicon : FormMenuBase
    {
        public FormContractProcessingSheetConditicon()
        {
            InitializeComponent();
            SetButtomImage(btnOk);
        }
        public string GetWhereCondition
        {

            get
            {
                string where = " ";

                if (false == string.IsNullOrEmpty(txtcode.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtcode.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtcontractcode.Text))
                {
                    where += string.Format(" and contractcode like '%{0}%'", txtcontractcode.Text.Trim());
                }
                return where;
            }
        }
    }
}
