using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    /// <summary>
	/// Accountsreceivablebody:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public partial class AccountsreceivableBody
    {
        public AccountsreceivableBody ( )
        {
        }
        #region Model
        private int _id;
        private string _yfid;
        private string _code;
        private DateTime? _date;
        private decimal? _num;
        private decimal? _price;
        private DateTime? _paymentdate;
        private string _quality;
        private string _customerid;
        private string _customer;
        private string _salesman;
        private int? _deliveryday;
        private int? _deliverymonth;
        private decimal? _deliverynum;
        private decimal? _settlementnum;
        private int? _receivablesday;
        private int? _receivablesmonth;
        private decimal? _receivablesamount;
        private string _receuvablesacountnum;
        private string _remark;
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
        /// 合同编号
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
        /// 签订日期
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
        /// 数量
        /// </summary>
        public decimal? num
        {
            set
            {
                _num = value;
            }
            get
            {
                return _num;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? price
        {
            set
            {
                _price = value;
            }
            get
            {
                return _price;
            }
        }
        /// <summary>
        /// paymentDate
        /// </summary>
        public DateTime? paymentDate
        {
            set
            {
                _paymentdate = value;
            }
            get
            {
                return _paymentdate;
            }
        }
        /// <summary>
        ///品质 
        /// </summary>
        public string quality
        {
            set
            {
                _quality = value;
            }
            get
            {
                return _quality;
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
        /// 发货日
        /// </summary>
        public int? deliveryDay
        {
            set
            {
                _deliveryday = value;
            }
            get
            {
                return _deliveryday;
            }
        }
        /// <summary>
        /// 发货月
        /// </summary>
        public int? deliveryMonth
        {
            set
            {
                _deliverymonth = value;
            }
            get
            {
                return _deliverymonth;
            }
        }
        /// <summary>
        /// 榜单净重
        /// </summary>
        public decimal? deliveryNum
        {
            set
            {
                _deliverynum = value;
            }
            get
            {
                return _deliverynum;
            }
        }
        /// <summary>
        /// 结算数量
        /// </summary>
        public decimal? settlementNum
        {
            set
            {
                _settlementnum = value;
            }
            get
            {
                return _settlementnum;
            }
        }
        /// <summary>
        /// 收款日
        /// </summary>
        public int? receivablesDay
        {
            set
            {
                _receivablesday = value;
            }
            get
            {
                return _receivablesday;
            }
        }
        /// <summary>
        /// 收款月
        /// </summary>
        public int? receivablesMonth
        {
            set
            {
                _receivablesmonth = value;
            }
            get
            {
                return _receivablesmonth;
            }
        }
        /// <summary>
        /// 收款金额
        /// </summary>
        public decimal? receivablesAmount
        {
            set
            {
                _receivablesamount = value;
            }
            get
            {
                return _receivablesamount;
            }
        }
        /// <summary>
        /// 账号
        /// </summary>
        public string receuvablesAcountNum
        {
            set
            {
                _receuvablesacountnum = value;
            }
            get
            {
                return _receuvablesacountnum;
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
