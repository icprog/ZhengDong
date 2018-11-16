using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PurchaseApplicationEntity
    {
        public PurchaseApplicationEntity ( )
        {
            
        }
        #region Model
        private int _id;
        private string _codenum;
        private string _codenumcontract;
        private string _supplier;
        private string _supplierabb;
        private string _supplieruser;
        private string _buyer;
        private string _buyerabb;
        private string _buyeruser;
        private string _purchase;
        private string _purchaseAbb;
        private string _purchaseUser;
        private decimal? _danjia;
        private decimal? _weight;
        private string _fishId;
        private decimal? _rebate;
        private string _brands;

        private string _shipname;
        private string _conutry;

        private decimal? _height;
        private string _proname;
        private decimal? _brandPro;
        private string _varieties;
        private DateTime? _deliverydate;
        private string _deliveryadd;
        private DateTime? _signdate;
        private string _signadd;
        private decimal? amountOfMoney;
        private decimal? _pricemy;
        private string _remark;
        private string _createuser;
        private DateTime? _createdate;
        private string _modifyuser;
        private DateTime? _modifydate;
        private string _process;

        private decimal _billnum;
        private decimal? _price;
        private string _UnitPrice;
        private string _Dollar;
        private DateTime? _shipdate;

        private string _conprotein;
        private string _contvn;
        private string _conza;
        private string _conffa;
        private string _conzf;
        private string _consf;
        private string _conshy;
        private string _cons;
        private string _consj;
        private string _conhf;
        private string _conlas;
        private string _condas;

        private string _choise;
        private decimal? _EexchangeRate;
        private string _Money;
        private decimal? _Dollarjine;

        private string  _account;
        private string _Bank;
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
        /// 采购编号
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
        /// 采购合同编号
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
        /// 供方
        /// </summary>
        public string supplier
        {
            set
            {
                _supplier = value;
            }
            get
            {
                return _supplier;
            }
        }
        /// <summary>
        /// 供方简称
        /// </summary>
        public string supplierAbb
        {
            set
            {
                _supplierabb = value;
            }
            get
            {
                return _supplierabb;
            }
        }
        /// <summary>
        /// 供方联系人
        /// </summary>
        public string supplierUser
        {
            set
            {
                _supplieruser = value;
            }
            get
            {
                return _supplieruser;
            }
        }
        /// <summary>
        /// 需方
        /// </summary>
        public string buyer
        {
            set
            {
                _buyer = value;
            }
            get
            {
                return _buyer;
            }
        }
        /// <summary>
        /// 需方简称
        /// </summary>
        public string buyerAbb
        {
            set
            {
                _buyerabb = value;
            }
            get
            {
                return _buyerabb;
            }
        }
        /// <summary>
        /// 需方联系人
        /// </summary>
        public string buyerUser
        {
            set
            {
                _buyeruser = value;
            }
            get
            {
                return _buyeruser;
            }
        }
        /// <summary>
        /// 需求方单位
        /// </summary>
        public string purchase
        {
            get
            {
                return _purchase;
            }

            set
            {
                _purchase = value;
            }
        }
        /// <summary>
        /// 需求方单位简称
        /// </summary>
        public string purchaseAbb
        {
            get
            {
                return _purchaseAbb;
            }

            set
            {
                _purchaseAbb = value;
            }
        }
        /// <summary>
        /// 需求方联系人
        /// </summary>
        public string purchaseUser
        {
            get
            {
                return _purchaseUser;
            }

            set
            {
                _purchaseUser = value;
            }
        }    
        /// <summary>
                    /// 交货地点
                    /// </summary>
        public string deliveryAdd
        {
            set
            {
                _deliveryadd = value;
            }
            get
            {
                return _deliveryadd;
            }
        }
        /// <summary>
        /// 交货时间
        /// </summary>
        public DateTime? deliveryDate
        {
            set
            {
                _deliverydate = value;
            }
            get
            {
                return _deliverydate;
            }
        }
        /// <summary>
        /// 裝船时间
        /// </summary>
        public DateTime? shipDate
        {
            set
            {
                _shipdate = value;
            }
            get
            {
                return _shipdate;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? danjia
        {
            get
            {
                return _danjia;
            }

            set
            {
                _danjia = value;
            }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal? Weight
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
        /// 鱼粉ID
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
        /// 佣金回扣
        /// </summary>
        public decimal? rebate
        {
            set
            {
                _rebate = value;
            }
            get
            {
                return _rebate;
            }
        }
        /// <summary>
        /// 品质规格
        /// </summary>
        public string brands
        {
            set
            {
                _brands = value;
            }
            get
            {
                return _brands;
            }
        }
        /// <summary>
        /// 国别
        /// </summary>
        public string conutry
        {
            set
            {
                _conutry = value;
            }
            get
            {
                return _conutry;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string proName
        {
            set
            {
                _proname = value;
            }
            get
            {
                return _proname;
            }
        }
        /// <summary>
        /// 保证金比例
        /// </summary>
        public decimal? bondPro
        {
            set
            {
                _brandPro = value;
            }
            get
            {
                return _brandPro;
            }
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string varieties
        {
            set
            {
                _varieties = value;
            }
            get
            {
                return _varieties;
            }
        }
        /// <summary>
        /// 签约日期
        /// </summary>
        public DateTime? signDate
        {
            set
            {
                _signdate = value;
            }
            get
            {
                return _signdate;
            }
        }
        /// <summary>
        /// 签约地点
        /// </summary>
        public string signAdd
        {
            set
            {
                _signadd = value;
            }
            get
            {
                return _signadd;
            }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? AmountOfMoney
        {
            get
            {
                return amountOfMoney;
            }

            set
            {
                amountOfMoney = value;
            }
        }
        /// <summary>
        /// 美金单价
        /// </summary>
        public decimal? priceMY
        {
            set
            {
                _pricemy = value;
            }
            get
            {
                return _pricemy;
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
        /// 创建人
        /// </summary>
        public string createUser
        {
            set
            {
                _createuser = value;
            }
            get
            {
                return _createuser;
            }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? createDate
        {
            set
            {
                _createdate = value;
            }
            get
            {
                return _createdate;
            }
        }
        /// <summary>
        /// 修改人
        /// </summary>
        public string modifyUser
        {
            set
            {
                _modifyuser = value;
            }
            get
            {
                return _modifyuser;
            }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? modifyDate
        {
            set
            {
                _modifydate = value;
            }
            get
            {
                return _modifydate;
            }
        }
        /// <summary>
        /// 采购流程
        /// </summary>
        public string Process
        {
            get
            {
                return _process;
            }

            set
            {
                _process = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal billNum
        {
            set
            {
                _billnum = value;
            }
            get
            {
                return _billnum;
            }
        }
        /// <summary>
        /// 合同金额
        /// </summary>
        public decimal? price
        {
            get
            {
                return _price;
            }

            set
            {
                _price = value;
            }
        }        /// <summary>
                 /// 单价
                 /// </summary>
        public string UnitPrice
        {
            get
            {
                return _UnitPrice;
            }

            set
            {
                _UnitPrice = value;
            }
        }        /// <summary>
                 /// 美元单价
                 /// </summary>
        public string Dollar
        {
            get
            {
                return _Dollar;
            }

            set
            {
                _Dollar = value;
            }
        }
        /// <summary>
        /// 合同蛋白
        /// </summary>
        public string conProtein
        {
            set
            {
                _conprotein = value;
            }
            get
            {
                return _conprotein;
            }
        }
        /// <summary>
        /// 合同TVN
        /// </summary>
        public string conTVN
        {
            set
            {
                _contvn = value;
            }
            get
            {
                return _contvn;
            }
        }
        /// <summary>
        /// 合同组胺
        /// </summary>
        public string conZA
        {
            set
            {
                _conza = value;
            }
            get
            {
                return _conza;
            }
        }
        /// <summary>
        /// 合同FFA
        /// </summary>
        public string conFFA
        {
            set
            {
                _conffa = value;
            }
            get
            {
                return _conffa;
            }
        }
        /// <summary>
        /// 合同脂肪
        /// </summary>
        public string conZF
        {
            set
            {
                _conzf = value;
            }
            get
            {
                return _conzf;
            }
        }
        /// <summary>
        /// 合同水分
        /// </summary>
        public string conSF
        {
            set
            {
                _consf = value;
            }
            get
            {
                return _consf;
            }
        }
        /// <summary>
        /// 合同沙和盐
        /// </summary>
        public string conSHY
        {
            set
            {
                _conshy = value;
            }
            get
            {
                return _conshy;
            }
        }
        /// <summary>
        /// 合同沙
        /// </summary>
        public string conS
        {
            set
            {
                _cons = value;
            }
            get
            {
                return _cons;
            }
        }
        /// <summary>
        /// 合同酸价
        /// </summary>
        public string conSJ
        {
            set
            {
                _consj = value;
            }
            get
            {
                return _consj;
            }
        }
        /// <summary>
        /// 合同灰分
        /// </summary>
        public string conHF
        {
            set
            {
                _conhf = value;
            }
            get
            {
                return _conhf;
            }
        }
        /// <summary>
        /// 合同赖氨酸
        /// </summary>
        public string conLAS
        {
            set
            {
                _conlas = value;
            }
            get
            {
                return _conlas;
            }
        }
        /// <summary>
        /// 合同蛋氨酸
        /// </summary>
        public string conDAS
        {
            set
            {
                _condas = value;
            }
            get
            {
                return _condas;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? height
        {
            set
            {
                _height = value;
            }
            get
            {
                return _height;
            }
        }   
        /// <summary>
                 /// 
                 /// </summary>
        public string shipName
        {
            set
            {
                _shipname = value;
            }
            get
            {
                return _shipname;
            }
        }
        /// <summary>
        /// 鱼粉来源
        /// </summary>
        public string choise
        {
            get
            {
                return _choise;
            }

            set
            {
                _choise = value;
            }
        }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal? EexchangeRate
        {
            get
            {
                return _EexchangeRate;
            }

            set
            {
                _EexchangeRate = value;
            }
        }
        /// <summary>
        /// 款项
        /// </summary>
        public string Money
        {
            get
            {
                return _Money;
            }

            set
            {
                _Money = value;
            }
        }
        /// <summary>
        /// 美金金额
        /// </summary>
        public decimal? Dollarjine
        {
            get
            {
                return _Dollarjine;
            }

            set
            {
                _Dollarjine = value;
            }
        }
        /// <summary>
        /// 供方账户
        /// </summary>
        public string account
        {
            get
            {
                return _account;
            }

            set
            {
                _account = value;
            }
        }
        /// <summary>
        /// 供方银行
        /// </summary>
        public string Bank
        {
            get
            {
                return _Bank;
            }

            set
            {
                _Bank = value;
            }
        }
        #endregion Model
    }
}
