using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormPresaleRequisitionCodition : FormBase
    {
        public FormPresaleRequisitionCodition(string text,string name)
        {
            InitializeComponent();

            this . Text = text;
            label1 . Text = name;
        }
        public string GetWhereCondition
        {
            get
            {
                string where = " ";

                if (string.IsNullOrEmpty(txtcode.Text) == false)
                {
                    where += string.Format(" and code like '%{0}%'", txtcode.Text.Trim());
                }
                return where;
            }
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . OK;
        }
    }
}
