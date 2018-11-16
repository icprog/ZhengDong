using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormSubProcurement : FormMenuBase
    {
        FishEntity.SubProcurementEntity _model = null;
        FishBll.Bll.SubProcurementBll _bll = null;
        public FormSubProcurement()
        {
            InitializeComponent();
        }
        public override int Query()
        {
            return base.Query();
        }
        public override int Add()
        {
            return base.Add();
        }
    }
}
