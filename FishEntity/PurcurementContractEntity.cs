using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PurcurementContractEntity
    {
        public PurcurementContractEntity ( )
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
        private DateTime? _signdate;
        private string _signadd;
        private string _proname;
        private decimal? _bondpro;
        private string _varieties;
        private string _quaspe;
        private decimal? _height;
        private decimal? _price;
        private decimal? _rebate;
        private decimal? _pricemy;
        private DateTime? _shipdate;
        private DateTime? _arrivedate;
        private DateTime? _deliverydate;
        private string _deliveryadd;
        private DateTime? _deliverylast;
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
        private string _remark;
        private string _conutry;
        private string _createuser;
        private DateTime? _createdate;
        private string _modifyuser;
        private DateTime? _modifydate;
        private string _purchase;
        private string _purchaseUser;
        private string _UnitPrice;
        private string _Dollar;
        private string _proName;
        private string _choise;

        private string _gongfang;
        private string _xufang;

        private string _account;
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
        /// 保证金
        /// </summary>
        public decimal? bondPro
        {
            set
            {
                _bondpro = value;
            }
            get
            {
                return _bondpro;
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
        /// 开证单位
        /// </summary>
        public string quaSpe
        {
            set
            {
                _quaspe = value;
            }
            get
            {
                return _quaspe;
            }
        }
        /// <summary>
        /// 总重量
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
        /// 总金额
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
        /// 美元总金额
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
        /// 开证联系人
        /// </summary>
        public string conutry
        {
            get
            {
                return _conutry;
            }

            set
            {
                _conutry = value;
            }
        }

        /// <summary>
        /// 裝船时间
        /// </summary>
        public DateTime? shipdate
        {
            get
            {
                return _shipdate;
            }

            set
            {
                _shipdate = value;
            }
        }

        /// <summary>
        /// 采购方
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
        /// 采购人
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
        }
        /// <summary>
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
        /// 产品名称
        /// </summary>
        public string ProName
        {
            get
            {
                return _proName;
            }

            set
            {
                _proName = value;
            }
        }
        /// <summary>
        /// 鱼粉分别
        /// </summary>
        public string Choise
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
        /// 供方
        /// </summary>
        public string gongfang
        {
            get
            {
                return _gongfang;
            }

            set
            {
                _gongfang = value;
            }
        }
        /// <summary>
        /// 需方
        /// </summary>
        public string xufang
        {
            get
            {
                return _xufang;
            }

            set
            {
                _xufang = value;
            }
        }

        public string Account
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
