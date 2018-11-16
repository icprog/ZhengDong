using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class InquiryEntity
    {
        public InquiryEntity ( )
        {
        }

        #region Model
        private int _id;
        private string _code;
        private decimal _weight;
        private int _number;
        private string _remark;
        private decimal _exchangerate;
        private decimal _rmb;
        private decimal _dollarprice;
        private DateTime _datetime;

        public int ID
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
        /// 鱼粉ID
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
            }
        }

        /// <summary>
        /// 重量
        /// </summary>
        public decimal Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
            }
        }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal Exchangerate
        {
            get
            {
                return _exchangerate;
            }
            set
            {
                _exchangerate = value;
            }
        }
        /// <summary>
        /// 人民币
        /// </summary>
        public decimal Rmb
        {
            get
            {
                return _rmb;
            }
            set
            {
                _rmb = value;
            }
        }

        /// <summary>
        /// 美元价
        /// </summary>
        public decimal Dollarprice
        {
            get
            {
                return _dollarprice;
            }
            set
            {
                _dollarprice = value;
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Datetime
        {
            get
            {
                return _datetime;
            }
            set
            {
                _datetime = value;
            }
        }
        #endregion
    }
}
