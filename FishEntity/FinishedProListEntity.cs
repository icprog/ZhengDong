using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class FinishedProListEntity
    {
        public FinishedProListEntity ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private string _plcode;
        private DateTime? _date;
        private string _country;
        private string _brand;
        private string _fishid;
        private decimal? _price;
        private string _qualityspe;
        private string _goods;
        private decimal? _tons;
        private string _protein;
        private string _tvn;
        private string _salt;
        private string _acid;
        private string _ash;
        private string _histamine;
        private string _las;
        private string _das;
        private string _remark;
        private string _zf;
        private string _shipname;
        private string _zjh;
        private string _billName;
        private string _CkCode;
        private string _FFA;
        private string _ajs;
        private string _Number;
        private string _zidingyi;
        private string _saleCompany;
        private string _saleLinkman;
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
        /// 单号
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
        /// 配料单号
        /// </summary>
        public string plCode
        {
            set
            {
                _plcode = value;
            }
            get
            {
                return _plcode;
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? date
        {
            set
            {
                _date = value;
            }
            get
            {
                return _date;
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
        /// 品质规格
        /// </summary>
        public string qualitySpe
        {
            set
            {
                _qualityspe = value;
            }
            get
            {
                return _qualityspe;
            }
        }
        /// <summary>
        /// 货品
        /// </summary>
        public string goods
        {
            set
            {
                _goods = value;
            }
            get
            {
                return _goods;
            }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal? tons
        {
            set
            {
                _tons = value;
            }
            get
            {
                return _tons;
            }
        }
        /// <summary>
        /// 蛋白
        /// </summary>
        public string protein
        {
            set
            {
                _protein = value;
            }
            get
            {
                return _protein;
            }
        }
        /// <summary>
        /// tvn
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
        /// 盐份
        /// </summary>
        public string salt
        {
            set
            {
                _salt = value;
            }
            get
            {
                return _salt;
            }
        }
        /// <summary>
        /// 酸价
        /// </summary>
        public string acid
        {
            set
            {
                _acid = value;
            }
            get
            {
                return _acid;
            }
        }
        /// <summary>
        /// 灰份
        /// </summary>
        public string ash
        {
            set
            {
                _ash = value;
            }
            get
            {
                return _ash;
            }
        }
        /// <summary>
        /// 组胺
        /// </summary>
        public string histamine
        {
            set
            {
                _histamine = value;
            }
            get
            {
                return _histamine;
            }
        }
        /// <summary>
        /// 赖氨酸
        /// </summary>
        public string las
        {
            set
            {
                _las = value;
            }
            get
            {
                return _las;
            }
        }
        /// <summary>
        /// 蛋氨酸
        /// </summary>
        public string das
        {
            set
            {
                _das = value;
            }
            get
            {
                return _das;
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
        /// 船名
        /// </summary>
        public string Shipname
        {
            get
            {
                return _shipname;
            }

            set
            {
                _shipname = value;
            }
        }

        /// <summary>
        /// 桩角号
        /// </summary>
        public string Zjh
        {
            get
            {
                return _zjh;
            }

            set
            {
                _zjh = value;
            }
        }

        /// <summary>
        /// 提单号
        /// </summary>
        public string BillName
        {
            get
            {
                return _billName;
            }

            set
            {
                _billName = value;
            }
        }
        /// <summary>
        /// 出库合同号
        /// </summary>
        public string CkCode
        {
            get
            {
                return _CkCode;
            }

            set
            {
                _CkCode = value;
            }
        }
        /// <summary>
        /// FFA
        /// </summary>
        public string FFA
        {
            get
            {
                return _FFA;
            }

            set
            {
                _FFA = value;
            }
        }
        /// <summary>
        /// 氨基酸
        /// </summary>
        public string Ajs
        {
            get
            {
                return _ajs;
            }

            set
            {
                _ajs = value;
            }
        }
        /// <summary>
        /// 件数
        /// </summary>
        public string Number
        {
            get
            {
                return _Number;
            }

            set
            {
                _Number = value;
            }
        }
        /// <summary>
        /// 自定义单号
        /// </summary>
        public string Zidingyi
        {
            get
            {
                return _zidingyi;
            }

            set
            {
                _zidingyi = value;
            }
        }
        /// <summary>
        /// 货主单位
        /// </summary>
        public string saleCompany
        {
            get
            {
                return _saleCompany;
            }

            set
            {
                _saleCompany = value;
            }
        }
        /// <summary>
        /// 货主联系人
        /// </summary>
        public string saleLinkman
        {
            get
            {
                return _saleLinkman;
            }

            set
            {
                _saleLinkman = value;
            }
        }
        #endregion Model

    }
}
