using System;

namespace FishEntity
{

    public class PresaleRequisitionHeadEntity
    {
        /// <summary>
        /// auto_increment
        /// </summary>		
        private int _id;
        public int id
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
        	
        private string _code;
        /// <summary>
        /// 合同编号
        /// </summary>	
        public string code
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
        		
        private string _supplierid;
        /// <summary>
        /// 供方ID
        /// </summary>
        public string supplierid
        {
            get
            {
                return _supplierid;
            }
            set
            {
                _supplierid = value;
            }
        }
        	
        private string _supplier;
        /// <summary>
        /// 供方
        /// </summary>	
        public string supplier
        {
            get
            {
                return _supplier;
            }
            set
            {
                _supplier = value;
            }
        }
        	
        private string _demandid;
        /// <summary>
        /// 需方ID
        /// </summary>	
        public string demandid
        {
            get
            {
                return _demandid;
            }
            set
            {
                _demandid = value;
            }
        }
        	
        private string _demand;
        /// <summary>
        /// 需方
        /// </summary>	
        public string demand
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
        	
        private DateTime _signdate;
        /// <summary>
        /// 签订日期
        /// </summary>	
        public DateTime Signdate
        {
            get
            {
                return _signdate;
            }
            set
            {
                _signdate = value;
            }
        }
        	
        private string _signplace;
        /// <summary>
        /// 签约地点
        /// </summary>	
        public string Signplace
        {
            get
            {
                return _signplace;
            }
            set
            {
                _signplace = value;
            }
        }
        	
        private decimal _rebate;
        /// <summary>
        /// 回扣
        /// </summary>	
        public decimal rebate
        {
            get
            {
                return _rebate;
            }
            set
            {
                _rebate = value;
            }
        }
        		
        private bool _rebatebool;
        /// <summary>
        /// 是否回扣
        /// </summary>
        public bool rebateBool
        {
            get
            {
                return _rebatebool;
            }
            set
            {
                _rebatebool = value;
            }
        }
       	
        private decimal _portprice;
        /// <summary>
        /// 港价
        /// </summary>	
        public decimal Portprice
        {
            get
            {
                return _portprice;
            }
            set
            {
                _portprice = value;
            }
        }
        	
        private bool _portpricebool;
        /// <summary>
        /// 是否港价
        /// </summary>	
        public bool PortpriceBool
        {
            get
            {
                return _portpricebool;
            }
            set
            {
                _portpricebool = value;
            }
        }
        	
        private string _country;
        /// <summary>
        /// 
        /// </summary>	
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
            }
        }
        	
        private bool _countrybool;
        /// <summary>
        /// 是否国别
        /// </summary>	
        public bool CountryBool
        {
            get
            {
                return _countrybool;
            }
            set
            {
                _countrybool = value;
            }
        }
        
        private bool _testindex;
        /// <summary>
        /// 是否检测指标
        /// </summary>		
        public bool testIndex
        {
            get
            {
                return _testindex;
            }
            set
            {
                _testindex = value;
            }
        }
        		
        private string _modeoftransport;
        /// <summary>
        /// 运输方式
        /// </summary>
        public string ModeOfTransport
        {
            get
            {
                return _modeoftransport;
            }
            set
            {
                _modeoftransport = value;
            }
        }
        	
        private DateTime _deliverydeadline;
        /// <summary>
        /// 交货期限
        /// </summary>	
        public DateTime DeliveryDeadline
        {
            get
            {
                return _deliverydeadline;
            }
            set
            {
                _deliverydeadline = value;
            }
        }
        	
        private decimal _freight;
        /// <summary>
        /// 运费
        /// </summary>	
        public decimal Freight
        {
            get
            {
                return _freight;
            }
            set
            {
                _freight = value;
            }
        }
        	
        private string _deliveryplace;
        /// <summary>
        /// 交货地点
        /// </summary>	
        public string DeliveryPlace
        {
            get
            {
                return _deliveryplace;
            }
            set
            {
                _deliveryplace = value;
            }
        }
        	
        private decimal _tonday;
        /// <summary>
        /// 吨/天
        /// </summary>	
        public decimal Tonday
        {
            get
            {
                return _tonday;
            }
            set
            {
                _tonday = value;
            }
        }
        	
        private decimal _tonrmb;
        /// <summary>
        /// 吨/天(元)
        /// </summary>	
        public decimal TonRMB
        {
            get
            {
                return _tonrmb;
            }
            set
            {
                _tonrmb = value;
            }
        }
        	
        private decimal _interetdat;
        /// <summary>
        /// 利息/天
        /// </summary>	
        public decimal InteretDat
        {
            get
            {
                return _interetdat;
            }
            set
            {
                _interetdat = value;
            }
        }
        	
        private decimal _interetrmb;
        /// <summary>
        /// 利息(元)
        /// </summary>	
        public decimal InteretRMB
        {
            get
            {
                return _interetrmb;
            }
            set
            {
                _interetrmb = value;
            }
        }
        	
        private string _bandan;
        /// <summary>
        /// 结算方式及期限
        /// </summary>	
        public string BanDan
        {
            get
            {
                return _bandan;
            }
            set
            {
                _bandan = value;
            }
        }
        	
        private DateTime _signdt;
        /// <summary>
        /// 签订后什么日期
        /// </summary>	
        public DateTime Signdt
        {
            get
            {
                return _signdt;
            }
            set
            {
                _signdt = value;
            }
        }
        	
        private decimal _bond;
        /// <summary>
        /// 保证金
        /// </summary>	
        public decimal Bond
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
        		
        private string _supac;
        /// <summary>
        /// 供方账户
        /// </summary>
        public string SupAc
        {
            get
            {
                return _supac;
            }
            set
            {
                _supac = value;
            }
        }
        	
        private int _suplimit;
        /// <summary>
        /// 限定天数
        /// </summary>	
        public int Suplimit
        {
            get
            {
                return _suplimit;
            }
            set
            {
                _suplimit = value;
            }
        }
       		
        private string _openbank;
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Openbank
        {
            get
            {
                return _openbank;
            }
            set
            {
                _openbank = value;
            }
        }
        	
        private string _collectunit;
        /// <summary>
        /// 收款单位
        /// </summary>	
        public string CollectUnit
        {
            get
            {
                return _collectunit;
            }
            set
            {
                _collectunit = value;
            }
        }
        	
        private string _acountnum;
        /// <summary>
        /// 账户
        /// </summary>	
        public string AcountNum
        {
            get
            {
                return _acountnum;
            }
            set
            {
                _acountnum = value;
            }
        }
        	
        private DateTime _createtime;
        /// <summary>
        /// 创建时间
        /// </summary>	
        public DateTime createtime
        {
            get
            {
                return _createtime;
            }
            set
            {
                _createtime = value;
            }
        }
        		
        private string _createman;
        /// <summary>
        /// 创建人
        /// </summary>
        public string createman
        {
            get
            {
                return _createman;
            }
            set
            {
                _createman = value;
            }
        }
        	
        private DateTime _modifytime;
        /// <summary>
        /// 维护时间
        /// </summary>	
        public DateTime modifytime
        {
            get
            {
                return _modifytime;
            }
            set
            {
                _modifytime = value;
            }
        }
        		
        private string _modifyman;
        /// <summary>
        /// 维护人
        /// </summary>
        public string modifyman
        {
            get
            {
                return _modifyman;
            }
            set
            {
                _modifyman = value;
            }
        }

    }
}

