using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    /// <summary>
	/// ProgramEntity:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class ProgramEntity
    {
        public ProgramEntity ( )
        {
        }
        #region Model
        private int _id=0;
        private string _programid;
        private string _programname;
        private string _programtable;
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
        /// 程序编码
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
        /// 程序名称
        /// </summary>
        public string programName
        {
            set
            {
                _programname = value;
            }
            get
            {
                return _programname;
            }
        }
        /// <summary>
        /// 程序用表
        /// </summary>
        public string programTable
        {
            set
            {
                _programtable = value;
            }
            get
            {
                return _programtable;
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
        #endregion Model

    }
}
