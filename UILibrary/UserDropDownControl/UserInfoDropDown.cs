using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Text;
using System.Drawing;

using FishEntity;

namespace UILibrary.UserDropDownControl
{
    public class UserInfoDropDown: ToolStripDropDown
    {
        public event EventHandler<LoginEventArgs> UserClick = null;

        public UserInfoDropDown(List<UserEntity> userList)
        {
            if (userList == null || userList.Count < 1) return;

            this.MaximumSize = new System.Drawing.Size(250, 500);
            foreach (UserEntity entity in userList)
            {
                UserInfoControlHost host = new UserInfoControlHost(entity);
                host.CloseClick += new EventHandler(host_CloseClick);
                host.UserClick += new EventHandler<LoginEventArgs>(host_UserClick);
                host.UpItem += new EventHandler<LoginEventArgs>(host_UpItem);
                host.DownItem += new EventHandler<LoginEventArgs>(host_DownItem);
                host.ResetControlBackColor += new EventHandler(host_ResetBackColor);
                host.ResetControlBackColor += new EventHandler(host_ResetBackColor);
                this.Items.Add(host);
            }
            (this.Items[0] as ToolStripControlHost).Focus();
        }

        void host_ResetBackColor(object sender, EventArgs e)
        {
            foreach (UserInfoControlHost item in Items)
            {
                if (item.UserInfoControl.BackColor != Color.Transparent)
                {
                    item.UserInfoControl.BackColor = Color.Transparent;
                }
            }
        }

        void host_DownItem(object sender, LoginEventArgs e)
        {
            bool isactive = (sender as UserInfoControl).SelectNextControl(this.ParentControl.GetContainerControl().ActiveControl, true, true, true, true);
           //bool isactive = this.SelectNextControl(this.GetContainerControl().ActiveControl, true, true, true, true);
            //UserInfoControlHost host = GetCurrentItem();
            //if (host != null)
            //{
            //    if (UserClick != null)
            //    {
            //        UserClick(this, new LoginEventArgs ( host .User) );
            //    }    
            //}
        }

        void host_UpItem(object sender, LoginEventArgs e)
        {
            bool isactive = (sender as UserInfoControl).SelectNextControl(this.ParentControl.GetContainerControl().ActiveControl, false, true, true, true);

            //UserInfoControlHost host = GetCurrentItem();
            //if (host != null)
            //{
            //    if (UserClick != null)
            //    {
            //        UserClick(this, new LoginEventArgs(host.User));
            //    }
            //}
        }

        void host_UserClick(object sender, LoginEventArgs e)
        {
            if (UserClick != null)
            {
                UserClick(this, e );
            }
            this.Hide();       
        }

        void host_CloseClick(object sender, EventArgs e)
        {
            UserInfoControlHost host = sender as UserInfoControlHost;           
            //UserMessage.Delete(host.User);
            this.Items.Remove(host);
            if (this.Items.Count < 1) this.Hide();
        }

        public UserControl ParentControl
        {
            get;
            set;
        }

        public void SetCurrentItem(string username)
        {
            foreach (UserInfoControlHost item in this.Items)
            {
                if (item.User.UserName == username)
                {
                    item.Focus();
                    return;
                }
            }
        }

        public UserInfoControlHost GetCurrentItem()
        {
            foreach (UserInfoControlHost item in this.Items)
            {
                if (item.Focused) return item;
            }
            return null;
        }

        public void Show(string username, Control ctl)
        {            
            this.Show ( ctl, 1 , ctl.Height + 1);
            SetCurrentItem(username);
        }
    }
}
