using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PaymentRequisitionDetailEntity
    {
        private int _id;
        private string _code;
        private string _codenum;
        private string _codenumcontract;
        //private decimal? _moneyofbzj;
        private decimal? _moneyofyfk;
        private string _saleUnit;
        private string _saleUser;
        private string _createman;
        private DateTime? _createtime;
        private string _modifyman;
        private DateTime? _modifytime;

        private string _fishId;
        private string _purchaseUnit;
        private string _purchaseUnitId;
        private string _saleUnitId;
        private string _saleUserId;
        private string _openBanK;
        private string _accountNumber;

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
        /// 付款申请单号
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
        /// 销售申请单号
        /// </summary>
        public string codeNum
        {
            set
            {
                _codenum = value;
            }
            get
            {
                return _codenum;
            }
        }
        /// <summary>
        /// 销售申请合同号
        /// </summary>
        public string codeNumContract
        {
            set
            {
                _codenumcontract = value;
            }
            get
            {
                return _codenumcontract;
            }
        }
        /// <summary>
        /// 保证金
        /// </summary>
        //public decimal? moneyOfBZJ
        //{
        //    set
        //    {
        //        _moneyofbzj = value;
        //    }
        //    get
        //    {
        //        return _moneyofbzj;
        //    }
        //}
        /// <summary>
        /// 预付款
        /// </summary>
        public decimal? moneyOfYFK
        {
            set
            {
                _moneyofyfk = value;
            }
            get
            {
                return _moneyofyfk;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createman
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
        public DateTime? createtime
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
        public string modifyman
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
        /// on update CURRENT_TIMESTAMP
        /// </summary>
        public DateTime? modifytime
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
        /// 销售单位
        /// </summary>
        public string SaleUnit
        {
            get
            {
                return _saleUnit;
            }

            set
            {
                _saleUnit = value;
            }
        }

        /// <summary>
        /// 销售联系人
        /// </summary>
        public string SaleUser
        {
            get
            {
                return _saleUser;
            }

            set
            {
                _saleUser = value;
            }
        }

        /// <summary>
        /// 鱼粉id
        /// </summary>
        public string FishId
        {
            get
            {
                return _fishId;
            }

            set
            {
                _fishId = value;
            }
        }

        /// <summary>
        /// 采购单位id
        /// </summary>
        public string PurchaseUnitId
        {
            get
            {
                return _purchaseUnitId;
            }

            set
            {
                _purchaseUnitId = value;
            }
        }

        /// <summary>
        /// 销售单位id
        /// </summary>
        public string SaleUnitId
        {
            get
            {
                return _saleUnitId;
            }

            set
            {
                _saleUnitId = value;
            }
        }

        /// <summary>
        /// 销售联系人id
        /// </summary>
        public string SaleUserId
        {
            get
            {
                return _saleUserId;
            }

            set
            {
                _saleUserId = value;
            }
        }

        /// <summary>
        /// 开户行
        /// </summary>
        public string OpenBanK
        {
            get
            {
                return _openBanK;
            }

            set
            {
                _openBanK = value;
            }
        }

        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }

            set
            {
                _accountNumber = value;
            }
        }
        /// <summary>
        /// 采购单位
        /// </summary>
        public string PurchaseUnit
        {
            get
            {
                return _purchaseUnit;
            }

            set
            {
                _purchaseUnit = value;
            }
        }
    }
}
