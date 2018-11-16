using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    /// <summary>
    /// t_role:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class RoleEntity
    {            public RoleEntity()
            { }
            #region Model
            private int _roleid;
            private string _rolename;
            private string _remarks;
            /// <summary>
            /// auto_increment
            /// </summary>
            public int roleid
            {
                set { _roleid = value; }
                get { return _roleid; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string rolename
            {
                set { _rolename = value; }
                get { return _rolename; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string remarks
            {
                set { _remarks = value; }
                get { return _remarks; }
            }
            #endregion Model
        }
}
