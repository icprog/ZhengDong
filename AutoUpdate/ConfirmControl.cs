using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AutoUpdate
{
    /// <summary>
    /// 发现最新版本时，如果没有强制升级，则提示用户确认是否升级 控件
    /// </summary>
    public partial class ConfirmControl : UserControl
    {
        public event  EventHandler UpdateEventHandler=null;

        public ConfirmControl()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateEventHandler != null)
            {
                UpdateEventHandler(this, EventArgs.Empty);
            }
        }

        private void btnOver_Click(object sender, EventArgs e)
        {           
            Application.Exit();
        }
    }
}
