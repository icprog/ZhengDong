using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class WainAllEntity
    {
        private int _id;
        private string _proId;
        private string _userId;
        private string _state;
        private int _count;

        /// <summary>
        /// 编号
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
        /// <summary>
        /// 程序编号
        /// </summary>
        public string ProId
        {
            get
            {
                return _proId;
            }

            set
            {
                _proId = value;
            }
        }
        /// <summary>
        /// 人员编号
        /// </summary>
        public string UserId
        {
            get
            {
                return _userId;
            }

            set
            {
                _userId = value;
            }
        }
        /// <summary>
        /// 状态  0:需要审核的单据   1:表示前面单据审核,此单据需要录入
        /// </summary>
        public string State
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count
        {
            get
            {
                return _count;
            }

            set
            {
                _count = value;
            }
        }
    }
}
