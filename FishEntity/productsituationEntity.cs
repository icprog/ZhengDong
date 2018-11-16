using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class productsituationEntity
    {
        public productsituationEntity() { }

        #region model
        private string _id;
        private string _Numbering;
        private string _code;
        private string _product_id;
        private string _productname;
        private string _Funit;
        private string _Variety;
        private decimal? _Quantity;
        private decimal? _unitprice;
        private decimal? _Amonut;
        /// <summary>
        /// 销售编号
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
        /// 销售合同号
        /// </summary>
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
        /// <summary>
        /// 鱼粉id
        /// </summary>
        public string Product_id
        {
            get
            {
                return _product_id;
            }

            set
            {
                _product_id = value;
            }
        }
        /// <summary>
        /// 产品情况
        /// </summary>
        public string Productname
        {
            get
            {
                return _productname;
            }

            set
            {
                _productname = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Funit
        {
            get
            {
                return _Funit;
            }

            set
            {
                _Funit = value;
            }
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string Variety
        {
            get
            {
                return _Variety;
            }

            set
            {
                _Variety = value;
            }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal? Quantity
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
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? Unitprice
        {
            get
            {
                return _unitprice;
            }

            set
            {
                _unitprice = value;
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

        public string Id
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
        #endregion
    }
}
