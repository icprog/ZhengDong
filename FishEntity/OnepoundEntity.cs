using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class OnepoundEntity
    {
        public OnepoundEntity()
        { }
        private string _FishMealId;
        private int _id;
        private string _code;
        private string _Serialnumber;
        private DateTime? _Dateofmanufacture;
        private DateTime? _IntothefactoryDate;
        private string _Carnumber;
        private string _Grossweight;
        private string _Tareweight;
        private string _Competition;
        private string _Goods;
        private string _Owner;
        private string _OwnerId;
        private string _Buyers;
        private string _BuyersId;
        private string _Sellers;
        private string _SellersId;
        private string _Country;
        private string _PName;
        private string _Qualit;
        private string _Quantity;
        private string _Pileangle;
        private string _BillOfLadingid;
        private string _Address;
        private string _codeContract;
        private string _createman;
        private string _Remarks;
        private string _shipno;
        private DateTime _createtime = DateTime.Now;
        private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
        private string _Numbering;
        private string _TiDanCode;
        private decimal? _RedemptionWeight;
        public int Id
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

        public string Serialnumber
        {
            get
            {
                return _Serialnumber;
            }

            set
            {
                _Serialnumber = value;
            }
        }

        public DateTime? Dateofmanufacture
        {
            get
            {
                return _Dateofmanufacture;
            }

            set
            {
                _Dateofmanufacture = value;
            }
        }

        public DateTime? IntothefactoryDate
        {
            get
            {
                return _IntothefactoryDate;
            }

            set
            {
                _IntothefactoryDate = value;
            }
        }

        public string Carnumber
        {
            get
            {
                return _Carnumber;
            }

            set
            {
                _Carnumber = value;
            }
        }

        public string Grossweight
        {
            get
            {
                return _Grossweight;
            }

            set
            {
                _Grossweight = value;
            }
        }

        public string Tareweight
        {
            get
            {
                return _Tareweight;
            }

            set
            {
                _Tareweight = value;
            }
        }

        public string Competition
        {
            get
            {
                return _Competition;
            }

            set
            {
                _Competition = value;
            }
        }

        public string Goods
        {
            get
            {
                return _Goods;
            }

            set
            {
                _Goods = value;
            }
        }
        /// <summary>
        /// 货运公司
        /// </summary>
        public string Owner
        {
            get
            {
                return _Owner;
            }

            set
            {
                _Owner = value;
            }
        }

        public string Address
        {
            get
            {
                return _Address;
            }

            set
            {
                _Address = value;
            }
        }

        public string Createman
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

        public DateTime Createtime
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

        public DateTime Modifytime
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

        public string Modifyman
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
        /// <summary>
        /// 采购商
        /// </summary>
        public string Buyers
        {
            get
            {
                return _Buyers;
            }

            set
            {
                _Buyers = value;
            }
        }
        /// <summary>
        /// 销售商
        /// </summary>
        public string Sellers
        {
            get
            {
                return _Sellers;
            }

            set
            {
                _Sellers = value;
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }

            set
            {
                _Country = value;
            }
        }

        public string Qualit
        {
            get
            {
                return _Qualit;
            }

            set
            {
                _Qualit = value;
            }
        }

        public string Quantity
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

        public string Pileangle
        {
            get
            {
                return _Pileangle;
            }

            set
            {
                _Pileangle = value;
            }
        }

        public string BillOfLadingid
        {
            get
            {
                return _BillOfLadingid;
            }

            set
            {
                _BillOfLadingid = value;
            }
        }

        public string PName
        {
            get
            {
                return _PName;
            }

            set
            {
                _PName = value;
            }
        }

        public string Remarks
        {
            get
            {
                return _Remarks;
            }

            set
            {
                _Remarks = value;
            }
        }

        public string Shipno
        {
            get
            {
                return _shipno;
            }

            set
            {
                _shipno = value;
            }
        }
        /// <summary>
        /// 货运公司Id
        /// </summary>
        public string OwnerId
        {
            get
            {
                return _OwnerId;
            }

            set
            {
                _OwnerId = value;
            }
        }
        /// <summary>
        /// 采购商Id
        /// </summary>
        public string BuyersId
        {
            get
            {
                return _BuyersId;
            }

            set
            {
                _BuyersId = value;
            }
        }
        /// <summary>
        /// 销售商Id
        /// </summary>
        public string SellersId
        {
            get
            {
                return _SellersId;
            }

            set
            {
                _SellersId = value;
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
        /// <summary>
        /// 提单号
        /// </summary>
        public string TiDanCode
        {
            get
            {
                return _TiDanCode;
            }

            set
            {
                _TiDanCode = value;
            }
        }

        /// <summary>
        /// 磅单
        /// </summary>

        public decimal? RedemptionWeight
        {
            get
            {
                return _RedemptionWeight;
            }

            set
            {
                _RedemptionWeight = value;
            }
        }
    }
}
