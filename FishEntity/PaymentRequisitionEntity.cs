using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PaymentRequisitionEntity
    {
        public PaymentRequisitionEntity ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private string _CNumbering;
        private string _applydepartid;
        private string _applydepart;
        private DateTime? _applydate;
        private string _applycode;
        private string _purchasecode;
        private string _unit;
        private string _unutId;
        private string _contacts;
        private string _contactsId;
        private string _backdeposit;
        private decimal? _price;
        private decimal? _weight;
        private decimal? _applymoney;
        private string _paymenttype;
        private string _paymentmethod;
        private string _paymentmethodother;
        private string _invoicetype;
        private DateTime? _paymentdate;
        private string _remark;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        private string _acountNum;
        private string _PurchasingUnit;
        private string _PurchasingUnitId;
        private string _Numbering;
        private string _codeNum;
        private decimal? _bond;
        private string _FishMealId;
        private decimal? _moneyYuk;
        private string _PricingType;
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
        /// 单号
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
        /// 单位ID
        /// </summary>
        public string applyDepartId
        {
            set
            {
                _applydepartid = value;
            }
            get
            {
                return _applydepartid;
            }
        }
        /// <summary>
        /// 申请部门
        /// </summary>
        public string applyDepart
        {
            set
            {
                _applydepart = value;
            }
            get
            {
                return _applydepart;
            }
        }
        /// <summary>
        /// 申请日期
        /// </summary>
        public DateTime? applyDate
        {
            set
            {
                _applydate = value;
            }
            get
            {
                return _applydate;
            }
        }
        /// <summary>
        /// 单位名称
        /// </summary>
        public string unit
        {
            set
            {
                _unit = value;
            }
            get
            {
                return _unit;
            }
        }
        /// <summary>
        /// 申请合同号
        /// </summary>
        public string applyCode
        {
            set
            {
                _applycode = value;
            }
            get
            {
                return _applycode;
            }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contacts
        {
            set
            {
                _contacts = value;
            }
            get
            {
                return _contacts;
            }
        }
        /// <summary>
        /// 开户行
        /// </summary>
        public string backDeposit
        {
            set
            {
                _backdeposit = value;
            }
            get
            {
                return _backdeposit;
            }
        }
        /// <summary>
        /// 货品单价
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
        /// 货品重量
        /// </summary>
        public decimal? weight
        {
            set
            {
                _weight = value;
            }
            get
            {
                return _weight;
            }
        }
        /// <summary>
        /// 申请金额
        /// </summary>
        public decimal? applyMoney
        {
            set
            {
                _applymoney = value;
            }
            get
            {
                return _applymoney;
            }
        }
        /// <summary>
        /// 付款类别
        /// </summary>
        public string paymentType
        {
            set
            {
                _paymenttype = value;
            }
            get
            {
                return _paymenttype;
            }
        }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string paymentMethod
        {
            set
            {
                _paymentmethod = value;
            }
            get
            {
                return _paymentmethod;
            }
        }
        /// <summary>
        /// 其它付款方式
        /// </summary>
        public string paymentMethodOther
        {
            set
            {
                _paymentmethodother = value;
            }
            get
            {
                return _paymentmethodother;
            }
        }
        /// <summary>
        /// 发票类型
        /// </summary>
        public string invoiceType
        {
            set
            {
                _invoicetype = value;
            }
            get
            {
                return _invoicetype;
            }
        }
        /// <summary>
        /// 付款日期
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

        /// <summary>
        /// 账号
        /// </summary>
        public string AcountNum
        {
            get
            {
                return _acountNum;
            }

            set
            {
                _acountNum = value;
            }
        }

        public string Purchasecode
        {
            get
            {
                return _purchasecode;
            }

            set
            {
                _purchasecode = value;
            }
        }

        public string PurchasingUnit
        {
            get
            {
                return _PurchasingUnit;
            }

            set
            {
                _PurchasingUnit = value;
            }
        }

        public string UnutId
        {
            get
            {
                return _unutId;
            }

            set
            {
                _unutId = value;
            }
        }
        /// <summary>
        /// 采购单位id
        /// </summary>
        public string PurchasingUnitId
        {
            get
            {
                return _PurchasingUnitId;
            }

            set
            {
                _PurchasingUnitId = value;
            }
        }
        /// <summary>
        /// 联系人Id
        /// </summary>
        public string ContactsId
        {
            get
            {
                return _contactsId;
            }

            set
            {
                _contactsId = value;
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
        /// 采购编号
        /// </summary>
        public string codeNum
        {
            get
            {
                return _codeNum;
            }

            set
            {
                _codeNum = value;
            }
        }

        /// <summary>
        /// 保证金
        /// </summary>
        public decimal? bond
        {
            get
            {
                return _bond;
            }

            set
            {
                _bond = value;
            }
        }
        /// <summary>
        /// 采购编号
        /// </summary>
        public string CNumbering
        {
            get
            {
                return _CNumbering;
            }

            set
            {
                _CNumbering = value;
            }
        }
        /// <summary>
        /// 鱼粉ID
        /// </summary>
        public string FishMealId
        {
            get
            {
                return _FishMealId;
            }

            set
            {
                _FishMealId = value;
            }
        }

        /// <summary>
        /// 预付款
        /// </summary>
        public decimal? MoneyYuk
        {
            get
            {
                return _moneyYuk;
            }

            set
            {
                _moneyYuk = value;
            }
        }
        /// <summary>
        /// 定价类型
        /// </summary>
        public string PricingType
        {
            get
            {
                return _PricingType;
            }

            set
            {
                _PricingType = value;
            }
        }
        #endregion Model

    }
}
