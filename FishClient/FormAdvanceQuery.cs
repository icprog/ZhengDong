using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FishClient
{
    public partial class FormAdvanceQuery : Form
    {
        public FormAdvanceQuery()
        {
            InitializeComponent();
        }

        private void FormAdvanceQuery_Load(object sender, EventArgs e)
        {
            UIControls.FilterItem item = new UIControls.FilterItem();
            item.Column = "name";
            item.ControlType = UIControls.ControlTypeEnum.ComboBox;
            item.DataType = UIControls.DataTypeEnum.Number;
            List<UIControls.FilterItem> list = new List<UIControls.FilterItem>();
            list.Add(item);
            item = new UIControls.FilterItem();
            item.Column = "age";
            item.ControlType = UIControls.ControlTypeEnum.Text;
            item.DataType = UIControls.DataTypeEnum.String;
            list.Add(item);
                                       
            UIControls.FilterItemControl ctl = new UIControls.FilterItemControl( list );

            this.Controls.Add(ctl);
        }
    }
}
