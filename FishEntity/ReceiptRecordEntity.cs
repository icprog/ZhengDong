using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class ReceiptRecordEntity
    {
        private string _ShouKuanZhuangTai;
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
        /// 单号
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
        	
        private string _departnum;
        /// <summary>
        /// 申请部门编号
        /// </summary>	
        public string departNum
        {
            get
            {
                return _departnum;
            }
            set
            {
                _departnum = value;
            }
        }
       	
        private string _departname;
        /// <summary>
        /// 申请部门名称
        /// </summary>	
        public string departName
        {
            get
            {
                return _departname;
            }
            set
            {
                _departname = value;
            }
        }
        	
        private DateTime _date;
        /// <summary>
        /// 申请日期
        /// </summary>	
        public DateTime date
        {
            get
            {
                return _date;
            }
            set
            {
                _date = value;
            }
        }
        
        private string _codeofyu;
        /// <summary>
        /// 预售合同编号
        /// </summary>		
        public string codeOfYu
        {
            get
            {
                return _codeofyu;
            }
            set
            {
                _codeofyu = value;
            }
        }
        
        private decimal _codeprice;
        /// <summary>
        /// 预售合同单价
        /// </summary>		
        public decimal codePrice
        {
            get
            {
                return _codeprice;
            }
            set
            {
                _codeprice = value;
            }
        }
       	
        private decimal _codeyunfei;
        /// <summary>
        /// 预售合同运费
        /// </summary>	
        public decimal codeYunFei
        {
            get
            {
                return _codeyunfei;
            }
            set
            {
                _codeyunfei = value;
            }
        }
       	
        private decimal _codehuikou;
        /// <summary>
        /// 预售合同回扣
        /// </summary>	
        public decimal codeHuiKou
        {
            get
            {
                return _codehuikou;
            }
            set
            {
                _codehuikou = value;
            }
        }
        	
        private string _fukuandanweiid;
        /// <summary>
        /// 付款单位ID
        /// </summary>	
        public string fuKuanDanWeiId
        {
            get
            {
                return _fukuandanweiid;
            }
            set
            {
                _fukuandanweiid = value;
            }
        }
       	
        private string _fukuandanwei;
        /// <summary>
        /// 付款单位
        /// </summary>	
        public string fuKuanDanWei
        {
            get
            {
                return _fukuandanwei;
            }
            set
            {
                _fukuandanwei = value;
            }
        }
        
        private string _fukuanzhanghao;
        /// <summary>
        /// 付款账号
        /// </summary>		
        public string fuKuanZhangHao
        {
            get
            {
                return _fukuanzhanghao;
            }
            set
            {
                _fukuanzhanghao = value;
            }
        }
        	
        private decimal _weight;
        /// <summary>
        /// 货物重量
        /// </summary>	
        public decimal weight
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
       
        private decimal _price;
        /// <summary>
        /// 货物单价
        /// </summary>		
        public decimal price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        	
        private decimal _rmb;
        /// <summary>
        /// 申请金额
        /// </summary>	
        public decimal RMB
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
       	
        private string _fukuantype;
        /// <summary>
        /// 付款类别
        /// </summary>	
        public string fuKuanType
        {
            get
            {
                return _fukuantype;
            }
            set
            {
                _fukuantype = value;
            }
        }
       
        private string _fukuanmethod;
        /// <summary>
        /// 付款方式
        /// </summary>		
        public string fuKuanMethod
        {
            get
            {
                return _fukuanmethod;
            }
            set
            {
                _fukuanmethod = value;
            }
        }
        	
        private string _fukuanother;
        /// <summary>
        /// 付款方式为其它的方式
        /// </summary>	
        public string fuKuanOther
        {
            get
            {
                return _fukuanother;
            }
            set
            {
                _fukuanother = value;
            }
        }
        	
        private string _invoicetype;
        /// <summary>
        /// 发票类别
        /// </summary>	
        public string invoiceType
        {
            get
            {
                return _invoicetype;
            }
            set
            {
                _invoicetype = value;
            }
        }
       		
        private DateTime _fukuandate;
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime fuKuandate
        {
            get
            {
                return _fukuandate;
            }
            set
            {
                _fukuandate = value;
            }
        }
       	
        private string _remark;
        /// <summary>
        /// 备注
        /// </summary>	
        public string remark
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
        		
        private DateTime _createtime;
        /// <summary>
        /// createTime
        /// </summary>
        public DateTime createTime
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
        /// createMan
        /// </summary>	
        public string createMan
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
       	
        private DateTime _modeifytime;
        /// <summary>
        /// modeifyTime
        /// </summary>	
        public DateTime modeifyTime
        {
            get
            {
                return _modeifytime;
            }
            set
            {
                _modeifytime = value;
            }
        }
        	
        private string _modeifyman;
        /// <summary>
        /// modeifyMan
        /// </summary>	
        public string modeifyMan
        {
            get
            {
                return _modeifyman;
            }
            set
            {
                _modeifyman = value;
            }
        }


        private string _codeContract;
        /// <summary>
        /// 销售合同号
        /// </summary>
        public string codeContract
        {
            get
            {
                return _codeContract;
            }
            set
            {
                _codeContract = value;
            }
        }
        private string _DemaUndnit;
        /// <summary>
        /// 需方单位
        /// </summary>
        public string DemaUndnit
        {
            get
            {
                return _DemaUndnit;
            }

            set
            {
                _DemaUndnit = value;
            }
        }
        private string _DemaUndnitId;
        /// <summary>
        /// 需方联系人
        /// </summary>
        public string DemandSideContact
        {
            get
            {
                return _DemandSideContact;
            }

            set
            {
                _DemandSideContact = value;
            }
        }
        /// <summary>
        /// 需方单位ID
        /// </summary>
        public string DemaUndnitId
        {
            get
            {
                return _DemaUndnitId;
            }

            set
            {
                _DemaUndnitId = value;
            }
        }
        /// <summary>
        /// 需方联系人ID
        /// </summary>
        public string DemandSideContactId
        {
            get
            {
                return _DemandSideContactId;
            }

            set
            {
                _DemandSideContactId = value;
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

        public string ShouKuanZhuangTai
        {
            get
            {
                return _ShouKuanZhuangTai;
            }

            set
            {
                _ShouKuanZhuangTai = value;
            }
        }
        /// <summary>
        /// 鱼粉Id
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

        private string _DemandSideContact;
        private string _DemandSideContactId;
        private string _Numbering;
        private string _FishMealId;
    }
}
