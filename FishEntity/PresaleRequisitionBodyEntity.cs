using System;

namespace FishEntity
{
    public class PresaleRequisitionBodyEntity
    {


        /// <summary>
        /// auto_increment
        /// </summary>		
        private int _id;
        public int id
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
        /// <summary>
        /// 合同编号
        /// </summary>		
        private string _codenum;
        public string codeNum
        {
            get
            {
                return _codenum;
            }
            set
            {
                _codenum = value;
            }
        }
        /// <summary>
        /// 鱼粉ID
        /// </summary>		
        private string _yfid;
        public string yfId
        {
            get
            {
                return _yfid;
            }
            set
            {
                _yfid = value;
            }
        }
        /// <summary>
        /// 鱼粉名称
        /// </summary>		
        private string _yfname;
        public string yfName
        {
            get
            {
                return _yfname;
            }
            set
            {
                _yfname = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>		
        private string _yfunit;
        public string yfUnit
        {
            get
            {
                return _yfunit;
            }
            set
            {
                _yfunit = value;
            }
        }
        /// <summary>
        /// 品种
        /// </summary>		
        private string _yfvarieties;
        public string yfVarieties
        {
            get
            {
                return _yfvarieties;
            }
            set
            {
                _yfvarieties = value;
            }
        }
        /// <summary>
        /// 数量(吨)
        /// </summary>		
        private decimal _yfnum;
        public decimal yfNum
        {
            get
            {
                return _yfnum;
            }
            set
            {
                _yfnum = value;
            }
        }
        /// <summary>
        /// 单价(元)
        /// </summary>		
        private decimal _yfprice;
        public decimal yfPrice
        {
            get
            {
                return _yfprice;
            }
            set
            {
                _yfprice = value;
            }
        }
        /// <summary>
        /// 金额(元)
        /// </summary>		
        private decimal _weight;
        public decimal weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
            }
        }
        /// <summary>
        /// 蛋白
        /// </summary>		
        private decimal _yfdb;
        public decimal yfdb
        {
            get
            {
                return _yfdb;
            }
            set
            {
                _yfdb = value;
            }
        }
        /// <summary>
        /// TVN
        /// </summary>		
        private decimal _yftvn;
        public decimal yftvn
        {
            get
            {
                return _yftvn;
            }
            set
            {
                _yftvn = value;
            }
        }
        /// <summary>
        /// 组胺
        /// </summary>		
        private decimal _yfza;
        public decimal yfza
        {
            get
            {
                return _yfza;
            }
            set
            {
                _yfza = value;
            }
        }
        /// <summary>
        /// FFA
        /// </summary>		
        private decimal _yfffa;
        public decimal yfFFA
        {
            get
            {
                return _yfffa;
            }
            set
            {
                _yfffa = value;
            }
        }
        /// <summary>
        /// 脂肪
        /// </summary>		
        private decimal _yfzf;
        public decimal yfzf
        {
            get
            {
                return _yfzf;
            }
            set
            {
                _yfzf = value;
            }
        }
        /// <summary>
        /// 水分
        /// </summary>		
        private decimal _yfsf;
        public decimal yfsf
        {
            get
            {
                return _yfsf;
            }
            set
            {
                _yfsf = value;
            }
        }
        /// <summary>
        /// 沙和盐
        /// </summary>		
        private decimal _yfshy;
        public decimal yfshy
        {
            get
            {
                return _yfshy;
            }
            set
            {
                _yfshy = value;
            }
        }
        /// <summary>
        /// 沙
        /// </summary>		
        private decimal _yfs;
        public decimal yfs
        {
            get
            {
                return _yfs;
            }
            set
            {
                _yfs = value;
            }
        }
        /// <summary>
        /// 粗蛋白
        /// </summary>		
        private decimal _yfcdb;
        public decimal yfcdb
        {
            get
            {
                return _yfcdb;
            }
            set
            {
                _yfcdb = value;
            }
        }
        /// <summary>
        /// TNV国内检测
        /// </summary>		
        private decimal _yftvntwo;
        public decimal yftvntwo
        {
            get
            {
                return _yftvntwo;
            }
            set
            {
                _yftvntwo = value;
            }
        }
        /// <summary>
        /// 灰粉
        /// </summary>		
        private decimal _yfhf;
        public decimal yfhf
        {
            get
            {
                return _yfhf;
            }
            set
            {
                _yfhf = value;
            }
        }
        /// <summary>
        /// 船名
        /// </summary>		
        private string _yfcm;
        public string yfcm
        {
            get
            {
                return _yfcm;
            }
            set
            {
                _yfcm = value;
            }
        }
        /// <summary>
        /// 桩角号
        /// </summary>		
        private string _yfzjh;
        public string yfzjh
        {
            get
            {
                return _yfzjh;
            }
            set
            {
                _yfzjh = value;
            }
        }
        /// <summary>
        /// 提单号
        /// </summary>		
        private string _yftdh;
        public string yftdh
        {
            get
            {
                return _yftdh;
            }
            set
            {
                _yftdh = value;
            }
        }
        private string _yfCountry;
        /// <summary>
        /// 国别
        /// </summary>
        public string yfCountry
        {
            get
            {
                return _yfCountry;
            }
            set
            {
                _yfCountry = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>		
        private string _yfpp;
        public string yfpp
        {
            get
            {
                return _yfpp;
            }
            set
            {
                _yfpp = value;
            }
        }
        /// <summary>
        /// createtime
        /// </summary>		
        private DateTime _createtime;
        public DateTime createtime
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
        /// <summary>
        /// createman
        /// </summary>		
        private string _createman;
        public string createman
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
        /// <summary>
        /// modifytime
        /// </summary>		
        private DateTime _modifytime;
        public DateTime modifytime
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
        /// <summary>
        /// modifyman
        /// </summary>		
        private string _modifyman;
        public string modifyman
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

    }
}

