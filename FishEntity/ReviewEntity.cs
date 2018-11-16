using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    /// <summary>
	/// ReviewEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class ReviewEntity
    {
        public ReviewEntity ( )
        {
        }
        #region Model
        private int _id=0;
        private string _username;
        private string _realname;
        private string _programid;
        private string _programName;
        private string _code;
        private DateTime? _date;
        private string _content;
        private string _state;
        private string _userNameReview;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        private string _Numbering;
        private string _SingleNumber;
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
        /// 送审人编号
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
        /// 送审人名称
        /// </summary>
        public string realName
        {
            set
            {
                _realname = value;
            }
            get
            {
                return _realname;
            }
        }
        /// <summary>
        /// 程序编号
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
        /// 程序编号
        /// </summary>
        public string programName
        {
            set
            {
                _programName = value;
            }
            get
            {
                return _programName;
            }
        }
        /// <summary>
        /// 单号(流水号)
        /// </summary>
        public string code
        {
            set
            {
                _code = value;
            }
            get
            {
                return _code;
            }
        }
        /// <summary>
        /// 送审时间
        /// </summary>
        public DateTime? date
        {
            set
            {
                _date = value;
            }
            get
            {
                return _date;
            }
        }
        /// <summary>
        /// 送审意见
        /// </summary>
        public string content
        {
            set
            {
                _content = value;
            }
            get
            {
                return _content;
            }
        }
        /// <summary>
        /// 送审状态
        /// </summary>
        public string state
        {
            set
            {
                _state = value;
            }
            get
            {
                return _state;
            }
        }
        /// <summary>
        /// 送审对象
        /// </summary>
        public string userNameReview
        {
            get
            {
                return _userNameReview;
            }
            set
            {
                _userNameReview = value;
            }
        }
        /// <summary>
        /// on update CURRENT_TIMESTAMP
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
        /// on update CURRENT_TIMESTAMP
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
        /// 编号
        /// </summary>
        public string Numbering
        {
            get
            {
                return _Numbering;
            }

            set
            {
                _Numbering = value;
            }
        }
        /// <summary>
        /// 表单单号
        /// </summary>
        public string SingleNumber
        {
            get
            {
                return _SingleNumber;
            }

            set
            {
                _SingleNumber = value;
            }
        }
        #endregion Model

    }
}
