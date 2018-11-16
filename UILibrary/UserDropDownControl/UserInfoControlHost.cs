using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Text;
using System.Drawing;

using FishEntity;

namespace UILibrary.UserDropDownControl
{
    public class UserInfoControlHost : ToolStripControlHost
    {
        public event EventHandler CloseClick = null;
        public event EventHandler<LoginEventArgs> UserClick = null;
        public event EventHandler<LoginEventArgs> DownItem = null;
        public event EventHandler<LoginEventArgs> UpItem = null;
        public event EventHandler ResetControlBackColor = null;
        protected UserEntity _user = null;

        public UserEntity User
        {
            get { return _user; }
        }

        public UserInfoControlHost(UserEntity user) :base ( new UserInfoControl(user ))
        {
            _user = user;
            this.AutoSize = false;
            this.UserInfoControl.CloseClick +=new EventHandler(UserInfoControl_CloseClick);
            this.UserInfoControl.UserClick += new EventHandler<LoginEventArgs>(UserInfoControl_UserClick);
            this.UserInfoControl.DownItem += new EventHandler<LoginEventArgs>(UserInfoControl_DownItem);
            this.UserInfoControl.UpItem += new EventHandler<LoginEventArgs>(UserInfoControl_UpItem);
            this.UserInfoControl.ResetControlBackColor += new EventHandler(UserInfoControl_ResetBackColor);
            this.KeyDown += new KeyEventHandler(UserInfoControlHost_KeyDown);            
        }

        void UserInfoControl_ResetBackColor(object sender, EventArgs e)
        {
            if (ResetControlBackColor != null)
            {
                ResetControlBackColor(this, e);
            }
        }

        void UserInfoControlHost_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (UserClick != null)
                {
                    UserClick(this, new LoginEventArgs ( _user ) );
                }
            }
        }

        void UserInfoControl_UpItem(object sender, LoginEventArgs e)
        {
            if (UpItem != null)
            {
                UpItem(sender , e);
            }
        }

        void UserInfoControl_DownItem(object sender, LoginEventArgs e)
        {
            if (DownItem != null)
            {
                DownItem(sender , e);
            }
        }

        void UserInfoControl_UserClick(object sender, LoginEventArgs e)
        {
            if (UserClick != null)
            {
                UserClick(this, e );
            }
        }

        void  UserInfoControl_CloseClick(object sender, EventArgs e)
        {
            if (CloseClick != null)
            {
                CloseClick(this, e);
            }
        }
        
        public UserInfoControl UserInfoControl
        {
            get
            {
                return this.Control as UserInfoControl;
            }
        }

    }
}
