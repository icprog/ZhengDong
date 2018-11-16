using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class QuotationPriceListEntity
    {
        #region Model
        private int _id;
        private string _code;
        private string _fishid;
        private decimal? _pricemy;
        private decimal? _price;
        private string _unit;
        private string _country;
        private string _brand;
        private string _qualityspe;
        private decimal? _weight;
        private string _contract;
        private DateTime? _date;
        private string _tvn;
        private string _acid;
        private string _salt;
        private string _protein;
        private string _ash;
        private string _histamine;
        private string _las;
        private string _das;
        private string _remark;
        private string _dataForm;
        private string _codeNumSales;
        private string _sgs_protein;
        private string _sgs_tvn;
        private string _sgs_fat;
        private string _sgs_water;
        private string _sgs_amine;
        private string _sgs_ffa;
        private string _sgs_sandsalt;
        private string _sgs_graypart;

        private string _domestic_protein;
        private string _domestic_amine;
        private string _domestic_tvn;
        private string _domestic_sandsalt;
        private string _domestic_graypart;
        private string _domestic_sour;
        private string _domestic_fat;
        private string _domestic_lysine;
        private string _domestic_methionine;

        private string _shipName;
        private string _cornerno;
        private string _billName;
        private string _XNfishId;
        private string _FFA;
        private string _createman;
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
        /// 鱼粉Id
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
        /// 美元单价
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
        /// 单位
        /// </summary>
        public string unit
        {
            set
            {
                _unit = value;
            }
            get
            {
                return _unit;
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
        /// 联系人
        /// </summary>
        public string contract
        {
            set
            {
                _contract = value;
            }
            get
            {
                return _contract;
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
        /// 数据来源
        /// </summary>
        public string dataForm
        {
            get
            {
                return _dataForm;
            }
            set
            {
                _dataForm = value;
            }
        }

        /// <summary>
        /// 销售申请单单号
        /// </summary>
        public string CodeNumSales
        {
            get
            {
                return _codeNumSales;
            }

            set
            {
                _codeNumSales = value;
            }
        }

        public string Sgs_protein
        {
            get
            {
                return _sgs_protein;
            }

            set
            {
                _sgs_protein = value;
            }
        }

        public string Sgs_tvn
        {
            get
            {
                return _sgs_tvn;
            }

            set
            {
                _sgs_tvn = value;
            }
        }

        public string Sgs_fat
        {
            get
            {
                return _sgs_fat;
            }

            set
            {
                _sgs_fat = value;
            }
        }

        public string Sgs_water
        {
            get
            {
                return _sgs_water;
            }

            set
            {
                _sgs_water = value;
            }
        }

        public string Sgs_amine
        {
            get
            {
                return _sgs_amine;
            }

            set
            {
                _sgs_amine = value;
            }
        }

        public string Sgs_ffa
        {
            get
            {
                return _sgs_ffa;
            }

            set
            {
                _sgs_ffa = value;
            }
        }

        public string Sgs_sandsalt
        {
            get
            {
                return _sgs_sandsalt;
            }

            set
            {
                _sgs_sandsalt = value;
            }
        }
        /// <summary>
        /// SGS灰份
        /// </summary>
        public string Sgs_graypart
        {
            get
            {
                return _sgs_graypart;
            }

            set
            {
                _sgs_graypart = value;
            }
        }

        public string Domestic_protein
        {
            get
            {
                return _domestic_protein;
            }

            set
            {
                _domestic_protein = value;
            }
        }

        public string Domestic_amine
        {
            get
            {
                return _domestic_amine;
            }

            set
            {
                _domestic_amine = value;
            }
        }

        public string Domestic_tvn
        {
            get
            {
                return _domestic_tvn;
            }

            set
            {
                _domestic_tvn = value;
            }
        }

        public string Domestic_sandsalt
        {
            get
            {
                return _domestic_sandsalt;
            }

            set
            {
                _domestic_sandsalt = value;
            }
        }

        public string Domestic_graypart
        {
            get
            {
                return _domestic_graypart;
            }

            set
            {
                _domestic_graypart = value;
            }
        }

        public string Domestic_sour
        {
            get
            {
                return _domestic_sour;
            }

            set
            {
                _domestic_sour = value;
            }
        }

        public string Domestic_fat
        {
            get
            {
                return _domestic_fat;
            }

            set
            {
                _domestic_fat = value;
            }
        }

        public string Domestic_lysine
        {
            get
            {
                return _domestic_lysine;
            }

            set
            {
                _domestic_lysine = value;
            }
        }

        public string Domestic_methionine
        {
            get
            {
                return _domestic_methionine;
            }

            set
            {
                _domestic_methionine = value;
            }
        }

        public string ShipName
        {
            get
            {
                return _shipName;
            }

            set
            {
                _shipName = value;
            }
        }

        public string Cornerno
        {
            get
            {
                return _cornerno;
            }

            set
            {
                _cornerno = value;
            }
        }

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
        /// 虚拟鱼粉id
        /// </summary>
        public string XNfishId
        {
            get
            {
                return _XNfishId;
            }

            set
            {
                _XNfishId = value;
            }
        }
        /// <summary>
        /// ffa
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
        #endregion Model
    }
}
