using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PicInfoAll
    {


        #region Model
        private int _id;
        private int _tableid;
        private string _tablename;
        private byte[] _picinfo;
        private string _categroy;
        private string _remark;
        /// <summary>
        /// auto_increment
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
        /// 表id
        /// </summary>
        public int tableId
        {
            set
            {
                _tableid = value;
            }
            get
            {
                return _tableid;
            }
        }
        /// <summary>
        /// 表名
        /// </summary>
        public string tableName
        {
            set
            {
                _tablename = value;
            }
            get
            {
                return _tablename;
            }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public byte[] picInfo
        {
            set
            {
                _picinfo = value;
            }
            get
            {
                return _picinfo;
            }
        }

        /// <summary>
        /// 类别
        /// </summary>
        public string categroy
        {
            get
            {
                return _categroy;
            }

            set
            {
                _categroy = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            get
            {
                return _remark;
            }set
            {
                _remark = value;
            }
        }
        #endregion Model
    }
}
