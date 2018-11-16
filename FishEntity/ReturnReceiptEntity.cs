using System;

namespace FishEntity
{
    public class ReturnReceiptEntity
    {
        #region Model
        private int _id;
        private string _code;
        private string _codenum;
        private string _codenumcontract;
        private string _returnparty;
        private string _receive;
        private DateTime? _signdate;
        private string _varieties;
        private DateTime? _inputdate;
        private string _returnpartyj;
        private string _receivej;
        private string _proname;
        private string _speci;
        private decimal? _tons;
        private decimal? _LiNumber;
        private decimal? _price;
        private decimal? _money;
        private string _country;
        private string _brand;
        private string _deliadd;
        private string _fishid;
        private decimal? _freight;
        private decimal? _cost;
        private decimal? _loss;
        private string _condb;
        private string _conza;
        private string _cons;
        private string _contvn;
        private string _conhf;
        private string _consf;
        private string _conshy;
        private string _conzf;
        private string _returngoodsadd;
        private string _remark;
        private string _ziying;
        private string _zizhi;
        private string _chengpin;
        private string _duanxuan;
        private decimal? _ShipmentsTons;
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
        /// 销售合同编号
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
        /// 退货方
        /// </summary>
        public string returnParty
        {
            set
            {
                _returnparty = value;
            }
            get
            {
                return _returnparty;
            }
        }
        /// <summary>
        /// 接收方
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
        /// 签订日期
        /// </summary>
        public DateTime? signDate
        {
            set
            {
                _signdate = value;
            }
            get
            {
                return _signdate;
            }
        }
        /// <summary>
        /// 品种
        /// </summary>
        public string varieties
        {
            set
            {
                _varieties = value;
            }
            get
            {
                return _varieties;
            }
        }
        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? inputDate
        {
            set
            {
                _inputdate = value;
            }
            get
            {
                return _inputdate;
            }
        }
        /// <summary>
        /// 退货方简称
        /// </summary>
        public string returnPartyJ
        {
            set
            {
                _returnpartyj = value;
            }
            get
            {
                return _returnpartyj;
            }
        }
        /// <summary>
        /// 接收方简称
        /// </summary>
        public string receiveJ
        {
            set
            {
                _receivej = value;
            }
            get
            {
                return _receivej;
            }
        }
        /// <summary>
        /// 产品名称
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
        /// 品质规格
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
        /// 金额
        /// </summary>
        public decimal? money
        {
            set
            {
                _money = value;
            }
            get
            {
                return _money;
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
        /// 交货地点
        /// </summary>
        public string deliAdd
        {
            set
            {
                _deliadd = value;
            }
            get
            {
                return _deliadd;
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
        /// 运费
        /// </summary>
        public decimal? freight
        {
            set
            {
                _freight = value;
            }
            get
            {
                return _freight;
            }
        }
        /// <summary>
        /// 费用
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
        /// 损耗
        /// </summary>
        public decimal? loss
        {
            set
            {
                _loss = value;
            }
            get
            {
                return _loss;
            }
        }
        /// <summary>
        /// 合同蛋白
        /// </summary>
        public string condb
        {
            set
            {
                _condb = value;
            }
            get
            {
                return _condb;
            }
        }
        /// <summary>
        /// 合同组胺
        /// </summary>
        public string conza
        {
            set
            {
                _conza = value;
            }
            get
            {
                return _conza;
            }
        }
        /// <summary>
        /// 合同沙
        /// </summary>
        public string cons
        {
            set
            {
                _cons = value;
            }
            get
            {
                return _cons;
            }
        }
        /// <summary>
        /// 合同tvn
        /// </summary>
        public string contvn
        {
            set
            {
                _contvn = value;
            }
            get
            {
                return _contvn;
            }
        }
        /// <summary>
        /// 合同灰份
        /// </summary>
        public string conhf
        {
            set
            {
                _conhf = value;
            }
            get
            {
                return _conhf;
            }
        }
        /// <summary>
        /// 合同水分
        /// </summary>
        public string consf
        {
            set
            {
                _consf = value;
            }
            get
            {
                return _consf;
            }
        }
        /// <summary>
        /// 合同沙和盐
        /// </summary>
        public string conshy
        {
            set
            {
                _conshy = value;
            }
            get
            {
                return _conshy;
            }
        }
        /// <summary>
        /// 合同脂肪
        /// </summary>
        public string conzf
        {
            set
            {
                _conzf = value;
            }
            get
            {
                return _conzf;
            }
        }
        /// <summary>
        /// 退货地址
        /// </summary>
        public string returnGoodsAdd
        {
            set
            {
                _returngoodsadd = value;
            }
            get
            {
                return _returngoodsadd;
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
        /// 自营
        /// </summary>
        public string ziying
        {
            get
            {
                return _ziying;
            }

            set
            {
                _ziying = value;
            }
        }
        /// <summary>
        /// 自制
        /// </summary>
        public string zizhi
        {
            get
            {
                return _zizhi;
            }

            set
            {
                _zizhi = value;
            }
        }
        /// <summary>
        /// 成品
        /// </summary>
        public string chengpin
        {
            get
            {
                return _chengpin;
            }

            set
            {
                _chengpin = value;
            }
        }

        public string duanxuan
        {
            get
            {
                return _duanxuan;
            }

            set
            {
                _duanxuan = value;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? LiNumber
        {
            get
            {
                return _LiNumber;
            }

            set
            {
                _LiNumber = value;
            }
        }
        /// <summary>
        /// 发货净重
        /// </summary>
        public decimal? ShipmentsTons
        {
            get
            {
                return _ShipmentsTons;
            }

            set
            {
                _ShipmentsTons = value;
            }
        }
        #endregion Model
    }
}
