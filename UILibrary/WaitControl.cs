using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using Utility;

using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    /// <summary>
    /// 
    /// </summary>
    public partial class WaitControl : UserControl
    {
        public event CancelEventHandler CancelEvent = null;

        string _msg = "";
        public WaitControl(string msg)
        {
            InitializeComponent();

            Image img = ImageUtil.GetImage("blue_button_down.png");
            if (img != null)
            {
                btnCancel.DownBack = img;
            }
            img = ImageUtil.GetImage("blue_button_hover.png");
            if (img != null)
            {
                btnCancel.MouseBack = img;
            }
            //imagePath = path + "\\Images\\blue_button_normal.png";
            img = ImageUtil.GetImage("blue_button_normal.png");
            if (img != null)
            {
                btnCancel.NormlBack = img;
                btnCancel.ForeColor = Color.White;
            }    

            _msg = msg;
            lblMsg.Text = _msg;
        }

        public void SetMessage(string msg, int precent)
        {
            lblMsg.Text = msg;
        }

        protected void LayoutControls()
        {
            Point p = new Point();
            p.X = (this.Width - this.progressBar1.Width) / 2;
            p.Y = (this.Height - this.progressBar1.Height - lblMsg.Height - btnCancel.Height - 60) / 2;
            progressBar1.Location = p;

            p.Y = p.Y + progressBar1.Height + 30;
            lblMsg.Location = p;

            p.X = (this.Width - btnCancel.Width) / 2;
            p.Y = p.Y + lblMsg.Height + 40;
            btnCancel.Location = p;
        }

        private void WaitControl_SizeChanged(object sender, EventArgs e)
        {
            LayoutControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (CancelEvent != null)
            {
                CancelEvent(this, new CancelEventArgs());
            }
        }
    }
}
