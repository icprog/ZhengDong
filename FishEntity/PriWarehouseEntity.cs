using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public class PriWarehouseEntity
    {
        public PriWarehouseEntity() { }
        #region model
        private string _fishId;
        private string _codeNum;
        private string _codeNumContract;
        private string _billName;
        private string _confirmagent;
        private string _confirmlinkman;
        private string _confirmdate;
        private string _confirmrmb;
        private string _conutry;
        private string _brand;
        private string _quaSpe;
        private string _confirmsgsweight;
        private string _height;
        private string _sgs_protein;
        private string _sgs_tvn;
        private string _sgs_fat;
        private string _sgs_water;
        private string _sgs_amine;
        private string _sgs_ffa;
        private string _sgs_sandsalt;
        private string _sgs_graypart;
        private string _sgs_sand;

        private string _domestic_protein;
        private string _domestic_amine;
        private string _domestic_tvn;
        private string _domestic_sandsalt;
        private string _domestic_graypart;
        private string _domestic_sour;
        private string _domestic_fat;
        private string _domestic_lysine;
        private string _domestic_methionine;
        private string _domestic_aminototal;

        private string _remark;
        private string _shipName;
        private string _spotdate;
        private string _warehouse;
        private string _cornerno;
        private string _samplingtime;
        private string _spotproductdate;
        private string _type;
        private string _Name;
        private string _gongfang;
        /// <summary>
        /// 生产日期
        /// </summary>
        public string Spotproductdate
        {
            get
            {
                return _spotproductdate;
            }

            set
            {
                _spotproductdate = value;
            }
        }
        /// <summary>
        /// 鱼粉ID
        /// </summary>
        public string FishId
        {
            get
            {
                return _fishId;
            }

            set
            {
                _fishId = value;
            }
        }
        /// <summary>
        /// 采购编号
        /// </summary>
        public string CodeNum
        {
            get
            {
                return _codeNum;
            }

            set
            {
                _codeNum = value;
            }
        }
        /// <summary>
        /// 采购合同号
        /// </summary>
        public string CodeNumContract
        {
            get
            {
                return _codeNumContract;
            }

            set
            {
                _codeNumContract = value;
            }
        }
        /// <summary>
        /// 取样日期
        /// </summary>
        public string Samplingtime
        {
            get
            {
                return _samplingtime;
            }

            set
            {
                _samplingtime = value;
            }
        }
        /// <summary>
        /// 桩角号
        /// </summary>
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
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string Warehouse
        {
            get
            {
                return _warehouse;
            }

            set
            {
                _warehouse = value;
            }
        }
        /// <summary>
        /// 入库日期
        /// </summary>
        public string Spotdate
        {
            get
            {
                return _spotdate;
            }

            set
            {
                _spotdate = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
            }
        }
        /// <summary>
        /// 氨基酸总和
        /// </summary>
        public string Domestic_aminototal
        {
            get
            {
                return _domestic_aminototal;
            }

            set
            {
                _domestic_aminototal = value;
            }
        }
        /// <summary>
        /// 实测蛋安酸
        /// </summary>
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
        /// <summary>
        /// 实测赖氨酸
        /// </summary>
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
        /// <summary>
        /// 实测脂肪
        /// </summary>
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
        /// <summary>
        /// 实测酸价
        /// </summary>
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
        /// <summary>
        /// 实测灰分
        /// </summary>
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
        /// <summary>
        /// 实测盐
        /// </summary>
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
        /// <summary>
        /// 实测tvn
        /// </summary>
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
        /// <summary>
        /// 实测组胺
        /// </summary>
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
        /// <summary>
        /// 实测蛋白
        /// </summary>
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
        /// <summary>
        /// SGS灰分
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
        /// <summary>
        /// SGS沙和盐
        /// </summary>
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
        /// SGSFFA
        /// </summary>
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
        /// <summary>
        /// SGS组胺
        /// </summary>
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
        /// <summary>
        /// SGS水分
        /// </summary>
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
        /// <summary>
        /// SGS脂肪
        /// </summary>
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
        /// <summary>
        /// SGSTVN
        /// </summary>
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
        /// <summary>
        /// SGS蛋白
        /// </summary>
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
        /// <summary>
        /// 剩余数量
        /// </summary>
        public string Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }
        /// <summary>
        /// SGS重量
        /// </summary>
        public string Confirmsgsweight
        {
            get
            {
                return _confirmsgsweight;
            }

            set
            {
                _confirmsgsweight = value;
            }
        }
        /// <summary>
        /// 品质
        /// </summary>
        public string QuaSpe
        {
            get
            {
                return _quaSpe;
            }

            set
            {
                _quaSpe = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand
        {
            get
            {
                return _brand;
            }

            set
            {
                _brand = value;
            }
        }
        /// <summary>
        /// 国别
        /// </summary>
        public string Conutry
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
        /// 价格RMB
        /// </summary>
        public string Confirmrmb
        {
            get
            {
                return _confirmrmb;
            }

            set
            {
                _confirmrmb = value;
            }
        }
        /// <summary>
        /// 售息日期
        /// </summary>
        public string Confirmdate
        {
            get
            {
                return _confirmdate;
            }

            set
            {
                _confirmdate = value;
            }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Confirmlinkman
        {
            get
            {
                return _confirmlinkman;
            }

            set
            {
                _confirmlinkman = value;
            }
        }
        /// <summary>
        /// 开证代理
        /// </summary>
        public string Confirmagent
        {
            get
            {
                return _confirmagent;
            }

            set
            {
                _confirmagent = value;
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
        /// <summary>
        /// 港口
        /// </summary>
        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }
        /// <summary>
        /// 品名
        /// </summary>
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }
        /// <summary>
        /// 沙
        /// </summary>
        public string Sgs_sand
        {
            get
            {
                return _sgs_sand;
            }

            set
            {
                _sgs_sand = value;
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
        #endregion
    }
}
