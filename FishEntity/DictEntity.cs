using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
        /// <summary>
        /// DictEntity:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
        [Serializable]
        public partial class DictEntity
        {
            public DictEntity()
            { }
            #region Model
            private int _id;
            private string _code;
            private string _name;
            private string _pcode;
            private int? _isdelete = 0;
            private int? _orderid = 0;
            private string _remark;
            private int _issystem = 0;
            private DateTime _createtime = DateTime.Now;
            private DateTime _modifytime = DateTime.Now;
            private int _pid;
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
            public string code
            {
                set { _code = value; }
                get { return _code; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string name
            {
                set { _name = value; }
                get { return _name; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string pcode
            {
                set { _pcode = value; }
                get { return _pcode; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int? isdelete
            {
                set { _isdelete = value; }
                get { return _isdelete; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int? orderid
            {
                set { _orderid = value; }
                get { return _orderid; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string remark
            {
                set { _remark = value; }
                get { return _remark; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int issystem
            {
                set { _issystem = value; }
                get { return _issystem; }
            }
            /// <summary>
            /// 
            /// </summary>
            public DateTime createtime
            {
                set { _createtime = value; }
                get { return _createtime; }
            }
            /// <summary>
            /// 
            /// </summary>
            public DateTime modifytime
            {
                set { _modifytime = value; }
                get { return _modifytime; }
            }
            /// <summary>
            /// 
            /// </summary>
            public int pid
            {
                get { return _pid;}
                set { _pid = value; }
            }

            #endregion Model

        }
    }



