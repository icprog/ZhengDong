using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class SalesRequisitionBodyEntity
    {
        public SalesRequisitionBodyEntity ( )
        {
        }
        #region Model
        private int _productid;
        private string _code;
        private string _product_id;
        private string _productname;
        private string _funit;
        private string _variety;
        private decimal? _quantity;
        private decimal? _unitprice;
        private decimal? _Amonut;
        private string _db;
        private string _tvn;
        private string _za;
        private string _ffa;
        private string _zf;
        private string _sf;
        private string _shy;
        private string _sz;
        private string _cdb;
        private string _tvnone;
        private string _hf;
        private string _cm;
        private string _zjh;
        private string _tdh;
        private string _pp;
        private string _country;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        private string _zaOne;
        private string _ffaOne;
        private string _zfOne;
        private string _sfOne;
        private string _shyOne;
        private string _szOne;
        private string _NumberingOne;
        private string _codeNumZdi;
        private string _codeNumHq;

        /// <summary>
        /// auto_increment
        /// </summary>
        public int productid
        {
            set
            {
                _productid = value;
            }
            get
            {
                return _productid;
            }
        }
        /// <summary>
        /// 合同号
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
        /// 鱼粉ID
        /// </summary>
        public string product_id
        {
            set
            {
                _product_id = value;
            }
            get
            {
                return _product_id;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string productname
        {
            set
            {
                _productname = value;
            }
            get
            {
                return _productname;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Funit
        {
            set
            {
                _funit = value;
            }
            get
            {
                return _funit;
            }
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string Variety
        {
            set
            {
                _variety = value;
            }
            get
            {
                return _variety;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? Quantity
        {
            set
            {
                _quantity = value;
            }
            get
            {
                return _quantity;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? unitprice
        {
            set
            {
                _unitprice = value;
            }
            get
            {
                return _unitprice;
            }
        }
        /// <summary>
        /// 蛋白
        /// </summary>
        public string db
        {
            set
            {
                _db = value;
            }
            get
            {
                return _db;
            }
        }
        /// <summary>
        /// TVN
        /// </summary>
        public string tvn
        {
            set
            {
                _tvn = value;
            }
            get
            {
                return _tvn;
            }
        }
        /// <summary>
        /// 组胺
        /// </summary>
        public string za
        {
            set
            {
                _za = value;
            }
            get
            {
                return _za;
            }
        }
        /// <summary>
        /// FFA
        /// </summary>
        public string ffa
        {
            set
            {
                _ffa = value;
            }
            get
            {
                return _ffa;
            }
        }
        /// <summary>
        /// 脂肪
        /// </summary>
        public string zf
        {
            set
            {
                _zf = value;
            }
            get
            {
                return _zf;
            }
        }
        /// <summary>
        /// 水分
        /// </summary>
        public string sf
        {
            set
            {
                _sf = value;
            }
            get
            {
                return _sf;
            }
        }
        /// <summary>
        /// 沙和盐
        /// </summary>
        public string shy
        {
            set
            {
                _shy = value;
            }
            get
            {
                return _shy;
            }
        }
        /// <summary>
        /// 沙
        /// </summary>
        public string sz
        {
            set
            {
                _sz = value;
            }
            get
            {
                return _sz;
            }
        }
        /// <summary>
        /// 粗蛋白
        /// </summary>
        public string cdb
        {
            set
            {
                _cdb = value;
            }
            get
            {
                return _cdb;
            }
        }
        /// <summary>
        /// TVN
        /// </summary>
        public string tvnOne
        {
            set
            {
                _tvnone = value;
            }
            get
            {
                return _tvnone;
            }
        }
        /// <summary>
        /// 灰粉
        /// </summary>
        public string hf
        {
            set
            {
                _hf = value;
            }
            get
            {
                return _hf;
            }
        }
        /// <summary>
        /// 船名
        /// </summary>
        public string cm
        {
            set
            {
                _cm = value;
            }
            get
            {
                return _cm;
            }
        }
        /// <summary>
        /// 桩角号
        /// </summary>
        public string zjh
        {
            set
            {
                _zjh = value;
            }
            get
            {
                return _zjh;
            }
        }
        /// <summary>
        /// 提单号
        /// </summary>
        public string tdh
        {
            set
            {
                _tdh = value;
            }
            get
            {
                return _tdh;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string pp
        {
            set
            {
                _pp = value;
            }
            get
            {
                return _pp;
            }
        }
        /// <summary>
        /// 
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
        /// 
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
        /// 国别
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

        public string ZaOne
        {
            get
            {
                return _zaOne;
            }

            set
            {
                _zaOne = value;
            }
        }

        public string FfaOne
        {
            get
            {
                return _ffaOne;
            }

            set
            {
                _ffaOne = value;
            }
        }

        public string ZfOne
        {
            get
            {
                return _zfOne;
            }

            set
            {
                _zfOne = value;
            }
        }

        public string SfOne
        {
            get
            {
                return _sfOne;
            }

            set
            {
                _sfOne = value;
            }
        }

        public string ShyOne
        {
            get
            {
                return _shyOne;
            }

            set
            {
                _shyOne = value;
            }
        }

        public string SzOne
        {
            get
            {
                return _szOne;
            }

            set
            {
                _szOne = value;
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
        /// 编号
        /// </summary>
        public string NumberingOne
        {
            get
            {
                return _NumberingOne;
            }

            set
            {
                _NumberingOne = value;
            }
        }

        /// <summary>
        /// 自定义标准表单号
        /// </summary>
        public string CodeNumZdi
        {
            get
            {
                return _codeNumZdi;
            }

            set
            {
                _codeNumZdi = value;
            }
        }

        /// <summary>
        /// 行情定价单单号
        /// </summary>
        public string CodeNumHq
        {
            get
            {
                return _codeNumHq;
            }

            set
            {
                _codeNumHq = value;
            }
        }
        #endregion Model
    }
}
