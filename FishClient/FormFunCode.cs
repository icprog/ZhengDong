using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormFunCode : FormMenuBase
    {
        public FormFunCode()
        {
            InitializeComponent();
        }

        public override int Modify()
        {



            return base.Modify();
        }

        public override int Add()
        {

            FormAddFunCode form = new FormAddFunCode(null);
            form.RefreshData += form_RefreshData;
            form.ShowDialog();
            return base.Add();
        }

        void form_RefreshData(object sender, EventArgs e)
        {
            Query();
        }
    }
}
