using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public  class EnterWarehouseReceipts
    {
        #region Model
        private int _id;
        private string _code;
        private string _fishid;
        private string _codenum;
        private string _codenumcontract;
        private string _deliverybills;
        private string _proname;
        private int? _numofpack;
        private string _qualityspe;
        private string _tvn;
        private string _sand;
        private string _tel;
        private string _to= "0.000";
        private string _enuntil= "0";
        private string _country= "0";
        private int? _number;
        private string _location;
        private string _protein;
        private string _fat;
        private string _water;
        private string _fax;
        private string _anti;
        private string _shipno;
        private string _brand;
        private DateTime? _downdate;
        private string _locationdis;
        private string _za;
        private string _hf;
        private string _shy;
        private string _remark;
        private DateTime _createtime;
        private string _createman;
        private string _modifyman;
        private DateTime _modifytime;
        private int _isdelete=0;
        private decimal _height;
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
        /// 进仓单号
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
        /// 采购申请单号
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
        /// 提货单
        /// </summary>
        public string deliverybills
        {
            set
            {
                _deliverybills = value;
            }
            get
            {
                return _deliverybills;
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
        /// 实际件数
        /// </summary>
        public int? numOfPack
        {
            set
            {
                _numofpack = value;
            }
            get
            {
                return _numofpack;
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
        /// TVN
        /// </summary>
        public string TVN
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
        /// TEL
        /// </summary>
        public string TEL
        {
            set
            {
                _tel = value;
            }
            get
            {
                return _tel;
            }
        }
        /// <summary>
        /// TO
        /// </summary>
        public string TO
        {
            set
            {
                _to = value;
            }
            get
            {
                return _to;
            }
        }
        /// <summary>
        /// 委托单位
        /// </summary>
        public string enUntil
        {
            set
            {
                _enuntil = value;
            }
            get
            {
                return _enuntil;
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
        /// 件数
        /// </summary>
        public int? number
        {
            set
            {
                _number = value;
            }
            get
            {
                return _number;
            }
        }
        /// <summary>
        /// 存放地点
        /// </summary>
        public string location
        {
            set
            {
                _location = value;
            }
            get
            {
                return _location;
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
        /// 脂肪
        /// </summary>
        public string fat
        {
            set
            {
                _fat = value;
            }
            get
            {
                return _fat;
            }
        }
        /// <summary>
        /// 水分
        /// </summary>
        public string water
        {
            set
            {
                _water = value;
            }
            get
            {
                return _water;
            }
        }
        /// <summary>
        /// fax
        /// </summary>
        public string fax
        {
            set
            {
                _fax = value;
            }
            get
            {
                return _fax;
            }
        }
        /// <summary>
        /// anti
        /// </summary>
        public string anti
        {
            set
            {
                _anti = value;
            }
            get
            {
                return _anti;
            }
        }
        /// <summary>
        /// 船号
        /// </summary>
        public string shipno
        {
            set
            {
                _shipno = value;
            }
            get
            {
                return _shipno;
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
        /// 拆箱日期
        /// </summary>
        public DateTime? downDate
        {
            set
            {
                _downdate = value;
            }
            get
            {
                return _downdate;
            }
        }
        /// <summary>
        /// 库存存放位置
        /// </summary>
        public string locationDis
        {
            set
            {
                _locationdis = value;
            }
            get
            {
                return _locationdis;
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
        /// 灰分
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
        /// 
        /// </summary>
        public DateTime createtime
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
        /// 
        /// </summary>
        public DateTime modifytime
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
        public int isdelete
        {
            set
            {
                _isdelete = value;
            }
            get
            {
                return _isdelete;
            }
        }
        /// <summary>
        /// 重量
        /// </summary>
        public decimal height
        {
            set
            {
                _height = value;
            }
            get
            {
                return _height;
            }
        }
        #endregion Model
    }
}
