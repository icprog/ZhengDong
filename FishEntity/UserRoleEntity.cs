using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    [Serializable]
    public  class UserRoleEntity
    {
            public UserRoleEntity()
            { }
            #region Model
            private int _id;
            private int _userid;
            private int _roleid;
            /// <summary>
            /// 
            /// </summary>
            public int id
            {
                set { _id = value; }
                get { return _id; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int userid
            {
                set { _userid = value; }
                get { return _userid; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int roleid
            {
                set { _roleid = value; }
                get { return _roleid; }
            }
            #endregion Model

        }
    }

