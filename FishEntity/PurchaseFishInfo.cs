using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
  public  class PurchaseFishInfo
    {
        public PurchaseFishInfo ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private string _fishid;
        private decimal? _price;
        private decimal? _weight;
        private decimal? _priceusa;
        private string _specifications;
        private string _brand;
        private string _country;
        private string _shipname;
        private string _billName;
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
        /// 采购申请单编号
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
        /// 单价
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
        /// 重量
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
        /// 美元单价
        /// </summary>
        public decimal? priceUSA
        {
            set
            {
                _priceusa = value;
            }
            get
            {
                return _priceusa;
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
                _billName = value;
            }
            get
            {
                return _billName;
            }
        }
        #endregion Model

    }
}
