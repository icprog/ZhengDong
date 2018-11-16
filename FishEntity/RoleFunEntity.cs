using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    [Serializable]
    public class RoleFunEntity
    {
            public RoleFunEntity()
            { }
            #region Model
            private int _id;
            private int _roleid;
            private int _funid;
            /// <summary>
            /// auto_increment
            /// </summary>
            public int id
            {
                set { _id = value; }
                get { return _id; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int roleid
            {
                set { _roleid = value; }
                get { return _roleid; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int funid
            {
                set { _funid = value; }
                get { return _funid; }
            }
            #endregion Model

        }
    
}
