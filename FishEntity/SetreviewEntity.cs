using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    /// <summary>
    /// SetreviewEntity:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class SetreviewEntity
    {
        public SetreviewEntity ( )
        {
        }
        #region Model
        private int _id=0;
        private string _username;
        private string _realname;
        private string _programid;
        private string _programName;
        private bool _level;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string userName
        {
            set
            {
                _username = value;
            }
            get
            {
                return _username;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string programId
        {
            set
            {
                _programid = value;
            }
            get
            {
                return _programid;
            }
        }
        /// <summary>
        /// 审核权限
        /// </summary>
        public bool level
        {
            set
            {
                _level = value;
            }
            get
            {
                return _level;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? createTime
        {
            set
            {
                _createtime = value;
            }
            get
            {
                return _createtime;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createMan
        {
            set
            {
                _createman = value;
            }
            get
            {
                return _createman;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? modifyTime
        {
            set
            {
                _modifytime = value;
            }
            get
            {
                return _modifytime;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string modifyMan
        {
            set
            {
                _modifyman = value;
            }
            get
            {
                return _modifyman;
            }
        }

        /// <summary>
        /// 真实姓名
        /// </summary>
        public string Realname
        {
            get
            {
                return _realname;
            }

            set
            {
                _realname = value;
            }
        }

        /// <summary>
        /// 程序名称
        /// </summary>
        public string ProgramName
        {
            get
            {
                return _programName;
            }

            set
            {
                _programName = value;
            }
        }
        #endregion Model

    }
}
