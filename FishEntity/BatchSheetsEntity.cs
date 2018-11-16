using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class BatchSheetsEntity
    {
        #region Model
        private int _id;
        private string _code;
        private string _fishid;
        private string _codenum;
        private string _codenumcontract;
        private string _qualityspe;
        private string _country;
        private string _brand;
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
        private decimal? _price;
        private decimal? _cost;
        private bool _issum;
        private string _rkCode;
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
        /// 合同号
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
        /// 吨位
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
        /// 成本
        /// </summary>
        public decimal? cost
        {
            set
            {
                _cost = value;
            }
            get
            {
                return _cost;
            }
        }
        /// <summary>
        /// 是否合计
        /// </summary>
        public bool isSum
        {
            set
            {
                _issum = value;
            }
            get
            {
                return _issum;
            }
        }

        /// <summary>
        /// 入库申请单单号
        /// </summary>
        public string rkCode
        {
            get
            {
                return _rkCode;
            }

            set
            {
                _rkCode = value;
            }
        }
        #endregion Model
    }
}
