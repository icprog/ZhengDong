using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public  class SalesAssessmentEntity
    {
        public SalesAssessmentEntity() { }
        private string _Numbering;
        private string _code;
        private string _demand;
        private DateTime _Signdate;
        private DateTime _payment;
        private decimal? _Quantity;
        private decimal? _unitprice;
        private decimal? _Amonut;
        private decimal? _ConfirmTheWeight;
        private decimal? _Chargeback;
        private DateTime? _fuKuandate;
        private decimal? _RMB;
        /// <summary>
        /// 销售编号
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
        /// 销售合同号
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
        /// 需方单位
        /// </summary>
        public string Demand
        {
            get
            {
                return _demand;
            }

            set
            {
                _demand = value;
            }
        }
        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime Signdate
        {
            get
            {
                return _Signdate;
            }

            set
            {
                _Signdate = value;
            }
        }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime Payment
        {
            get
            {
                return _payment;
            }

            set
            {
                _payment = value;
            }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal? Quantity
        {
            get
            {
                return _Quantity;
            }

            set
            {
                _Quantity = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Unitprice
        {
            get
            {
                return _unitprice;
            }

            set
            {
                _unitprice = value;
            }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? Amonut
        {
            get
            {
                return _Amonut;
            }

            set
            {
                _Amonut = value;
            }
        }
        /// <summary>
        /// 结算重量
        /// </summary>
        public decimal? ConfirmTheWeight
        {
            get
            {
                return _ConfirmTheWeight;
            }

            set
            {
                _ConfirmTheWeight = value;
            }
        }
        /// <summary>
        /// 扣款
        /// </summary>
        public decimal? Chargeback
        {
            get
            {
                return _Chargeback;
            }

            set
            {
                _Chargeback = value;
            }
        }
        /// <summary>
        /// 收款记录金额
        /// </summary>
        public decimal? RMB
        {
            get
            {
                return _RMB;
            }

            set
            {
                _RMB = value;
            }
        }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime? FuKuandate
        {
            get
            {
                return _fuKuandate;
            }

            set
            {
                _fuKuandate = value;
            }
        }
    }
}
