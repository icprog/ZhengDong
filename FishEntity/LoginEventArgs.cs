using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    /// <summary>
    /// 登录事件参数类
    /// </summary>
    public class LoginEventArgs : EventArgs 
    {
        /// <summary>
        /// 用户信息类
        /// </summary>
        public UserEntity User { get; set; }
        public LoginEventArgs(UserEntity user) { User = user; }
    }
}
