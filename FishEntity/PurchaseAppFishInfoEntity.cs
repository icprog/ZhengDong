using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PurchaseAppFishInfoEntity
    { 
        private int _id;
        private string _code;
        private string _fishid;
        private string _specifications;
        private string _country;
        private string _brand;
        private string _shipname;
        private string _billname;
        private decimal? _money;
        private decimal? _num;
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
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        private decimal? _price;
        private DateTime? _fastshipdate;
        private DateTime? _lastshipdate;
        private string _delPort;
        private decimal? _EexchangeRate;
        private decimal? _priceMY;
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
        /// 采购申请单单号
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
        /// 鱼粉id
        /// </summary>
        public string fishId
        {
            set
            {
                _fishid = value;
            }
            get
            {
                return _fishid;
            }
        }
        /// <summary>
        /// 品质规格
        /// </summary>
        public string specifications
        {
            set
            {
                _specifications = value;
            }
            get
            {
                return _specifications;
            }
        }
        /// <summary>
        /// 国别
        /// </summary>
        public string country
        {
            set
            {
                _country = value;
            }
            get
            {
                return _country;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string brand
        {
            set
            {
                _brand = value;
            }
            get
            {
                return _brand;
            }
        }
        /// <summary>
        /// 船名
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
        /// 提单号
        /// </summary>
        public string billName
        {
            set
            {
                _billname = value;
            }
            get
            {
                return _billname;
            }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? money
        {
            set
            {
                _money = value;
            }
            get
            {
                return _money;
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
        /// 合同tvn
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
        /// 合同灰份
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
        /// conDAS
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
        /// 鱼粉来源
        /// </summary>
        public string choise
        {
            set
            {
                _choise = value;
            }
            get
            {
                return _choise;
            }
        }
        /// <summary>
        /// 
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
        /// 
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
        /// 价格
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
        }
        /// <summary>
        /// 最快船期
        /// </summary>
        public DateTime? fastshipdate
        {
            get
            {
                return _fastshipdate;
            }

            set
            {
                _fastshipdate = value;
            }
        }
        /// <summary>
        /// 最慢船期
        /// </summary>
        public DateTime? lastshipdate
        {
            get
            {
                return _lastshipdate;
            }

            set
            {
                _lastshipdate = value;
            }
        }
        /// <summary>
        /// 交货港口
        /// </summary>
        public string delPort
        {
            get
            {
                return _delPort;
            }

            set
            {
                _delPort = value;
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
        /// 美金单价
        /// </summary>
        public decimal? priceMY
        {
            get
            {
                return _priceMY;
            }

            set
            {
                _priceMY = value;
            }
        }
    }
}
