using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;
using System.Windows.Forms;

using FishEntity;

namespace UILibrary.UserDropDownControl
{

    public partial class UserInfoControl : UserControl
    {
        public event EventHandler CloseClick = null;
        public event EventHandler<LoginEventArgs> UserClick = null;
        public event EventHandler<LoginEventArgs> DownItem = null;
        public event EventHandler<LoginEventArgs> UpItem = null;
        public event EventHandler ResetControlBackColor = null;
        protected UserEntity _user =null;

        public UserEntity User
        {
            get
            {
                return _user;
            }
            set
            {
                _user = value;
                if (_user != value)
                {
                    tcPicture1.Image = _user.Photo;
                }
            }
        }        

        public UserInfoControl( UserEntity user )
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            InitializeComponent();

            _user = user;
            string username = _user.UserName.Length > 15 ? _user.UserName.Substring(0, 15) : _user.UserName;
            lblName.Text = username;
            string userid = _user.UserCode.Length > 15 ? _user.UserCode.Substring(0, 15) : _user.UserCode;
            lblUserID.Text = userid;
            tcPicture1.Image = _user.Photo;
          
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Up)
            {
                if (UpItem != null)
                {
                    UpItem(this, new LoginEventArgs(_user) );
                }
            }
            else if (keyData == Keys.Down)
            {
                if (DownItem != null)
                {
                    DownItem(this, new LoginEventArgs (_user ) );
                }
            }

            return base.ProcessDialogKey(keyData);
        }

        protected override void OnGotFocus(EventArgs e)
        {         
            base.OnGotFocus(e);
            this.BackColor = Color.LightSkyBlue;
        }

        protected override void OnLostFocus(EventArgs e)
        {         
            base.OnLostFocus(e);
            this.BackColor = Color.Transparent;
        }
        
        private void tcPicture2_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;
            tcPicture2.Image = Properties.Resources.close_mouseover;
        }

        private void tcPicture2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                tcPicture2.Image = Properties.Resources.close_down;
            }
        }

        private void tcPicture2_MouseHover(object sender, EventArgs e)
        {
            tcPicture2.Image = Properties.Resources.close_mouseover;
        }

        private void tcPicture2_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
            tcPicture2.Image = Properties.Resources.close_normal;
        }

        private void tcPicture2_Click(object sender, EventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, EventArgs .Empty );
            }
        }

        private void tcPanel1_MouseEnter(object sender, EventArgs e)
        {
            if (ResetControlBackColor != null)
            {
                ResetControlBackColor(this, EventArgs.Empty);
            }
            this.BackColor = Color.LightSkyBlue;
        }

        private void tcPanel1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void tcPanel1_Click(object sender, EventArgs e)
        {
            if (UserClick != null)
            {
                UserClick(this, new LoginEventArgs( _user ));
            }
        }

        private void tcPicture1_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.LightSkyBlue;
        }

        private void tcPicture1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

    }
}
