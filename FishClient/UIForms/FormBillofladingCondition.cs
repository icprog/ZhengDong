using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient.UIForms
{
    public partial class FormBillofladingCondition : FormBase
    {
        public FormBillofladingCondition()
        {
            InitializeComponent();
            SetButtomImage(btnOk);
        }
        public string GetWhereCondition
        {
            get
            {
                string where = " ";
                if (false == string.IsNullOrEmpty(txtNumbering.Text))
                {
                    where += string.Format(" and code like '%{0}%'", txtNumbering.Text.Trim());
                }
                if (false == string.IsNullOrEmpty(txtlistname.Text))
                {
                    where += string.Format(" and code listname '%{0}%'", txtlistname.Text.Trim());
                }
                return where;
                }
            }
        }
    }
