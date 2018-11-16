using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class StorageOfRequisitionEntity
    {
        public StorageOfRequisitionEntity ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private string _fishid;
        private decimal? _liweight;
        private decimal? _liNumber;
        private decimal? _price;
        private string _shipname;
        private string _country;
        private string _billname;
        private string _proname;
        private string _za;
        private string _zf;
        private string _sand;
        private string _db;
        private DateTime? _applydate;
        private string _thCodeNum;
        private string _supply;
        private decimal? _saweight;
        private string _brand;
        private string _pilenum;
        private string _qualityspe;
        private string _tvn;
        private string _hf;
        private string _sf;
        private string _shy;
        private string _remark;
        private string _codenum;
        private string _codenumcontract;
        private DateTime? _createtime;
        private string _createuser;
        private DateTime? _modifytime;
        private string _modifyuser;
        private string _jcCode;
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
        /// 入库吨位
        /// </summary>
        public decimal? liWeight
        {
            set
            {
                _liweight = value;
            }
            get
            {
                return _liweight;
            }
        }
        /// <summary>
        /// 采购单价
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
        /// 品名
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
        /// 沙
        /// </summary>
        public string sand
        {
            set
            {
                _sand = value;
            }
            get
            {
                return _sand;
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
        /// 申请日期
        /// </summary>
        public DateTime? applyDate
        {
            set
            {
                _applydate = value;
            }
            get
            {
                return _applydate;
            }
        }
        /// <summary>
        /// 退货单单号
        /// </summary>
        public string thCodeNum
        {
            set
            {
                _thCodeNum = value;
            }
            get
            {
                return _thCodeNum;
            }
        }
        /// <summary>
        /// 供方
        /// </summary>
        public string supply
        {
            set
            {
                _supply = value;
            }
            get
            {
                return _supply;
            }
        }
        /// <summary>
        /// 采购吨位
        /// </summary>
        public decimal? saWeight
        {
            set
            {
                _saweight = value;
            }
            get
            {
                return _saweight;
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
        /// 桩角号
        /// </summary>
        public string pileNum
        {
            set
            {
                _pilenum = value;
            }
            get
            {
                return _pilenum;
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
        /// 灰份
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
        /// 采购单号
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
        /// 采购合同单号
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
        /// 进仓单号
        /// </summary>
        public string jcCode
        {
            set
            {
                _jcCode = value;
            }
            get
            {
                return _jcCode;
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
        public string createUser
        {
            set
            {
                _createuser = value;
            }
            get
            {
                return _createuser;
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
        public string modifyUser
        {
            set
            {
                _modifyuser = value;
            }
            get
            {
                return _modifyuser;
            }
        }

        public decimal? LiNumber
        {
            get
            {
                return _liNumber;
            }

            set
            {
                _liNumber = value;
            }
        }
        #endregion Model
    }
}
