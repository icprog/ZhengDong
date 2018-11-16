using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class OutboundOrderEntity
    {
        public OutboundOrderEntity ( )
        {

        }

        #region Model
        private int _id;
        private string _senumber;
        private string _code;
        private string _unit;
        private string _type;
        private string _shipname;
        private decimal? _weight;
        private string _pilenum;
        private string _codenum;
        private string _codenumcontract;
        private DateTime? _date;
        private string _wasehouse;
        private string _speci;
        private string _billname;
        private int? _pagenum;
        private string _remark;
        private string _notice;
        private decimal? _ware;
        private string _receive;
        private string _FishMealId;
        private string _Country;
        private string _Brands;
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
        /// 序号
        /// </summary>
        public string seNumber
        {
            set
            {
                _senumber = value;
            }
            get
            {
                return _senumber;
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
        /// 种类
        /// </summary>
        public string type
        {
            set
            {
                _type = value;
            }
            get
            {
                return _type;
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
        /// 提单号
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
        /// 销售编号
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
        /// 销售合同号
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
        /// 签发时间
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
        /// 仓库
        /// </summary>
        public string waseHouse
        {
            set
            {
                _wasehouse = value;
            }
            get
            {
                return _wasehouse;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string speci
        {
            set
            {
                _speci = value;
            }
            get
            {
                return _speci;
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
        /// 包数
        /// </summary>
        public int? pageNum
        {
            set
            {
                _pagenum = value;
            }
            get
            {
                return _pagenum;
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
        /// 发货须知
        /// </summary>
        public string notice
        {
            set
            {
                _notice = value;
            }
            get
            {
                return _notice;
            }
        }
        /// <summary>
        /// 仓储费
        /// </summary>
        public decimal? ware
        {
            set
            {
                _ware = value;
            }
            get
            {
                return _ware;
            }
        }
        /// <summary>
        /// 接收人
        /// </summary>
        public string receive
        {
            set
            {
                _receive = value;
            }
            get
            {
                return _receive;
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
        /// 国别
        /// </summary>
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
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brands
        {
            get
            {
                return _Brands;
            }

            set
            {
                _Brands = value;
            }
        }
        #endregion Model

    }
}
