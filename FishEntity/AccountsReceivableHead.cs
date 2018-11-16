using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    /// <summary>
    /// AccountsReceivableHead:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class AccountsReceivableHead
    {
        public AccountsReceivableHead ( )
        {
        }
        #region Model
        private int _id;
        private string _yfid;
        private string _province;
        private string _region;
        private string _customerid;
        private string _customer;
        private string _salesmanid;
        private string _salesman;
        private decimal? _yeararrears;
        private decimal? _monthreceivable;
        private decimal? _monthnetreceipts;
        private decimal? _yearReceivable;
        private decimal? _yearnetreceipts;
        private string _remark;
        private int? _count;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
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
        /// 鱼粉Id
        /// </summary>
        public string yfId
        {
            set
            {
                _yfid = value;
            }
            get
            {
                return _yfid;
            }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string province
        {
            set
            {
                _province = value;
            }
            get
            {
                return _province;
            }
        }
        /// <summary>
        /// 地区
        /// </summary>
        public string region
        {
            set
            {
                _region = value;
            }
            get
            {
                return _region;
            }
        }
        /// <summary>
        /// 客户编号
        /// </summary>
        public string customerId
        {
            set
            {
                _customerid = value;
            }
            get
            {
                return _customerid;
            }
        }
        /// <summary>
        /// 客户
        /// </summary>
        public string customer
        {
            set
            {
                _customer = value;
            }
            get
            {
                return _customer;
            }
        }
        /// <summary>
        /// 业务员编号
        /// </summary>
        public string salesmanId
        {
            set
            {
                _salesmanid = value;
            }
            get
            {
                return _salesmanid;
            }
        }
        /// <summary>
        /// 业务员
        /// </summary>
        public string salesman
        {
            set
            {
                _salesman = value;
            }
            get
            {
                return _salesman;
            }
        }
        /// <summary>
        /// 年初欠款
        /// </summary>
        public decimal? yearArrears
        {
            set
            {
                _yeararrears = value;
            }
            get
            {
                return _yeararrears;
            }
        }
        /// <summary>
        /// 本月应收账款
        /// </summary>
        public decimal? monthReceivable
        {
            set
            {
                _monthreceivable = value;
            }
            get
            {
                return _monthreceivable;
            }
        }
        /// <summary>
        /// 本月实收金额
        /// </summary>
        public decimal? monthNetreceipts
        {
            set
            {
                _monthnetreceipts = value;
            }
            get
            {
                return _monthnetreceipts;
            }
        }
        /// <summary>
        /// 本年实收金额
        /// </summary>
        public decimal? yearNetreceipts
        {
            set
            {
                _yearnetreceipts = value;
            }
            get
            {
                return _yearnetreceipts;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set
            {
                _remark = value;
            }
            get
            {
                return _remark;
            }
        }
        /// <summary>
        /// 计数
        /// </summary>
        public int? count
        {
            set
            {
                _count = value;
            }
            get
            {
                return _count;
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
        /// 本年应收账款
        /// </summary>
        public decimal? YearReceivable
        {
            get
            {
                return _yearReceivable;
            }

            set
            {
                _yearReceivable = value;
            }
        }
        #endregion Model

    }
}
