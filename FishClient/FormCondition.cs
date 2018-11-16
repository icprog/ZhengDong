using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormCondition : FormMenuBase
    {
        UIControls.CompanyCondition _ctl = null;
        public FormCondition()
        {
            InitializeComponent();

            menuStrip1.Visible = false;

            SetButtomImage(btnOk);

            _ctl = new UIControls.CompanyCondition();
            _ctl.Dock = DockStyle.Fill;
            Controls.Add(_ctl);

        }
              

        private void FormCondition_Load(object sender, EventArgs e)
        {
        }

        public string GetWhereCondition
        {
            get
            {
                return _ctl.GetQueryCondition();
            }
        }
    }
}
