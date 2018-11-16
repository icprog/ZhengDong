using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Net;

namespace FishEntity
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class UserEntity : IComparable
    {
        public string UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 可登录的科室列表
        /// </summary>
        //public List<OfficeEntity> Offices { get; set; }
        /// <summary>
        /// 上一次登录的科室
        /// </summary>
        //public OfficeEntity PreviousOffice { get; set; }
        /// <summary>
        /// 当前登录的科室
        /// </summary>
        //public OfficeEntity CurrentOffice { get; set; }
        public Image Photo { get; set; }
        public bool Remember { get; set; }
        public string Signature { get; set; }
        public bool AutoLogin { get; set; }
        public DateTime LoginDate { get; set; }
        public string PhotoPath { get; set; }
        /// <summary>
        /// TGT
        /// </summary>
        public string TGT { get; set; }
        /// <summary>
        /// SSO Cookie
        /// </summary>
        public CookieContainer SsoCookie { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public CookieContainer HisCookie { get; set; }
        public string HisCookieUrl { get; set; }

        public CookieContainer CrmCookie { get; set; }
        public string CrmCookieUrl { get; set; }

        public CookieContainer ScmCookie { get; set; }
        public string ScmCookieUrl { get; set; }

        public int CompareTo(object obj)
        {
            UserEntity u1 = obj as UserEntity;
            return u1.LoginDate.CompareTo(this.LoginDate);
        }
    }  
}
