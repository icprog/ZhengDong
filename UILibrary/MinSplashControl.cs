using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UILibrary
{
    public partial class MinSplashControl : UserControl
    {
        public event CancelEventHandler CancelEvent = null;

        public MinSplashControl()
        {
            InitializeComponent();

            if (TCHISEntity.Variable.User != null && TCHISEntity.Variable.User.Photo != null)
            {
                avatarControl1.SetAvatar(TCHISEntity.Variable.User.Photo);
                avatarControl1.SetPictureSize();
            }

            btnCancel.Visible = false;
        }

        public void ShowTitle(string msg)
        {
            label1.Text = msg;
        }

        public void ShowMessage(string msg, int precent)
        {
            label2.Text = msg;
            System.Threading.Thread.Sleep(100);
        }

        private void MinControl_SizeChanged(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        protected void ChangeLocation()
        {
            Point p = new Point();
            p.X = (this.Width - avatarControl1.Width) / 2;
            p.Y = 25;
            avatarControl1.Location = p;

            panel1.Width = this.Width - 5;
            p.X = (this.Width - panel1.Width) / 2;
            p.Y = p.Y + avatarControl1.Height + 20;
            panel1.Height = this.Height - avatarControl1.Height - 20 - 20;
            panel1.Location = p;

            p = new Point ();
            p.X = ( panel1.Width - progressBar1.Width )/2;
            p.Y = 10;
            progressBar1.Location = p;

            label1.Width = panel1.Width - 5;
            p.X = (panel1.Width - label1.Width) / 2;
            p.Y += progressBar1.Height + 20;
            label1.Location = p;

            label2.Width = panel1.Width - 5;
            p.X = (panel1.Width - label2.Width) / 2;
            p.Y += label1.Height + 20;
            label2.Location = p;

            p.X = (panel1.Width - btnCancel.Width) / 2;
            p.Y += label2.Height + 20;
            btnCancel.Location = p;
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
