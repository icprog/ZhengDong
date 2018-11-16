using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class ReductionClauseEntity
    {
        private int _id;
        private string _proname;
        private string _country;
        private string _brand;
        private bool _speci;
        private string _ratio;
        private decimal? _pricemy;
        private bool _pricebase;
        private decimal? _pricediff;
        private decimal? _exrate;
        private decimal? _pricermb;
        private string _codenum;


        /// <summary>
        /// 
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
        /// brand
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
        /// speci
        /// </summary>
        public bool speci
        {
            set
            {
                _speci = value;
            }
            get
            {
                return _speci;
            }
        }
        /// <summary>
        /// ratio
        /// </summary>
        public string ratio
        {
            set
            {
                _ratio = value;
            }
            get
            {
                return _ratio;
            }
        }
        /// <summary>
        /// priceMY
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
        /// 基价
        /// </summary>
        public bool priceBase
        {
            set
            {
                _pricebase = value;
            }
            get
            {
                return _pricebase;
            }
        }
        /// <summary>
        /// 美金差价
        /// </summary>
        public decimal? priceDiff
        {
            set
            {
                _pricediff = value;
            }
            get
            {
                return _pricediff;
            }
        }
        /// <summary>
        /// 汇率
        /// </summary>
        public decimal? exRate
        {
            set
            {
                _exrate = value;
            }
            get
            {
                return _exrate;
            }
        }
        /// <summary>
        /// 人民币单价
        /// </summary>
        public decimal? priceRMB
        {
            set
            {
                _pricermb = value;
            }
            get
            {
                return _pricermb;
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
    }
}
