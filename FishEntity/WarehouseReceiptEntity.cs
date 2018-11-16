using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class WarehouseReceiptEntity
    {
        public WarehouseReceiptEntity ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private string _codenumcontract;
        private string _codenum;
        private string _fishid;
        private string _quaiden;
        private string _commoditytons;
        private decimal? _commoditypack;
        private string _commodity;
        private string _speci;
        private string _countryoforigin;
        private string _billname;
        private string _sign;
        private string _shipment;
        private string _shipmentuser;
        private string _checkadddate;
        private string _sampling;
        private decimal? _db;
        private decimal? _water;
        private decimal? _zf;
        private decimal? _freshness;
        private decimal? _sy;
        private string _oxi;
        private decimal? _weight;
        private string _package;
        private decimal? _avgweight;
        private string _shipper;
        private string _shippernum;
        private string _billnames;
        private string _contractnum;
        private string _goodsnum;
        private string _consi;
        private string _preship;
        private string _oceanship;
        private string _navnum;
        private string _agent;
        private string _receipt;
        private string _shiphar;
        private string _unshophar;
        private string _desti;
        private string _lastdesti;
        private decimal? _num;
        private string _containnum;
        private string _paper;
        private decimal? _conweight;
        private decimal? _pakeweight;
        private string _seal;
        private decimal? _freight;
        private string _freightadd;
        private string _shipname;
        private decimal? _price;
        private string _forUnit;
        private string _supCom;
        private string _receive;
        private string _receiveAdd;
        private string _quaIndex;
        private string _contractNums;
        private decimal? _priceMJ;
        private decimal? _FOB;
        private decimal? _CFR;

        private string _AnalysisUnit;
        private string _AnalysisAddress;
        private string _AnalysisWebsite;
        private DateTime? _ReportingTime;
        private string _Telephone;
        private string _Mailbox;
        private string _ReportAddress;
        private string _Fax;
        private string _ProductionProcess;
        private string _StartingCountry;
        private string _StartingCity;
        private string _DestinationCountry;
        private string _DestinationCity;
        private string _forwardingUnit;
        private DateTime? _TestTime;
        private DateTime? _shipmentdate;
        private string _CheckAddress;
        private string _SamplingContent;
        private string _InspectionUnit;
        private decimal? _SGS_TVN;
        private decimal? _SGS_Sand;
        private decimal? _SGS_Histamine;
        private string _WeighingMethod;
        private decimal? _AverageNetWeight;
        private decimal? _AverageSkinWeight;
        private decimal? _TotalWeight;
        private decimal? _TotalSkinWeight;
        private decimal? _PackingUumber;
        private decimal? _NetWeightPerBox;
        private string _FumigationAddress;
        private string _ChemicalConcentration;
        private DateTime? _FumigationDate;
        private string _FumigationTime;
        private string _FumigatingTemperature;
        private decimal? _Label_Antioxidant;
        private decimal? _Quote_FFA;
        private decimal? _Quote_SandSalt;
        private decimal? _Quote_Sand;
        private decimal? _ContractAntioxidant;
        private decimal? _Label_Protein;
        private decimal? _Label_Water;
        private decimal? _Label_Fat;
        private decimal? _Label_FFA;
        private decimal? _Label_SandSalt;
        private string _Band;
        private DateTime? _date;
        private string _Specification;
        private string _Warehousing;
        private string _Port;
        private string _spotEexchangeRate;
        private decimal? _SgsWeight;
        private string _SgsQuantity;
        private string _cornerno;

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
        /// 采购合同号
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
        /// 质量鉴定
        /// </summary>
        public string quaIden
        {
            set
            {
                _quaiden = value;
            }
            get
            {
                return _quaiden;
            }
        }
        /// <summary>
        /// 商品(吨)
        /// </summary>
        public string commodityTons
        {
            set
            {
                _commoditytons = value;
            }
            get
            {
                return _commoditytons;
            }
        }
        /// <summary>
        /// 商品(包)
        /// </summary>
        public decimal? commodityPack
        {
            set
            {
                _commoditypack = value;
            }
            get
            {
                return _commoditypack;
            }
        }
        /// <summary>
        /// 商品
        /// </summary>
        public string commodity
        {
            set
            {
                _commodity = value;
            }
            get
            {
                return _commodity;
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
        /// 原产地
        /// </summary>
        public string countryOfOrigin
        {
            set
            {
                _countryoforigin = value;
            }
            get
            {
                return _countryoforigin;
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
        /// 标记
        /// </summary>
        public string sign
        {
            set
            {
                _sign = value;
            }
            get
            {
                return _sign;
            }
        }
        /// <summary>
        /// 装运
        /// </summary>
        public string shipMent
        {
            set
            {
                _shipment = value;
            }
            get
            {
                return _shipment;
            }
        }
        /// <summary>
        /// 装运人
        /// </summary>
        public string shipMentUser
        {
            set
            {
                _shipmentuser = value;
            }
            get
            {
                return _shipmentuser;
            }
        }
        /// <summary>
        /// 检验地点和时间
        /// </summary>
        public string checkAddDate
        {
            set
            {
                _checkadddate = value;
            }
            get
            {
                return _checkadddate;
            }
        }
        /// <summary>
        /// 取样
        /// </summary>
        public string sampling
        {
            set
            {
                _sampling = value;
            }
            get
            {
                return _sampling;
            }
        }
        /// <summary>
        /// 蛋白
        /// </summary>
        public decimal? db
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
        /// 水分
        /// </summary>
        public decimal? water
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
        /// 脂肪
        /// </summary>
        public decimal? zf
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
        /// 新鲜度
        /// </summary>
        public decimal? freshness
        {
            set
            {
                _freshness = value;
            }
            get
            {
                return _freshness;
            }
        }
        /// <summary>
        /// 沙盐
        /// </summary>
        public decimal? sy
        {
            set
            {
                _sy = value;
            }
            get
            {
                return _sy;
            }
        }
        /// <summary>
        /// 抗氧化剂
        /// </summary>
        public string oxi
        {
            set
            {
                _oxi = value;
            }
            get
            {
                return _oxi;
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
        /// 集装箱/重量
        /// </summary>
        public string package
        {
            set
            {
                _package = value;
            }
            get
            {
                return _package;
            }
        }
        /// <summary>
        /// 平均重量
        /// </summary>
        public decimal? avgWeight
        {
            set
            {
                _avgweight = value;
            }
            get
            {
                return _avgweight;
            }
        }
        /// <summary>
        /// 托运人
        /// </summary>
        public string shipper
        {
            set
            {
                _shipper = value;
            }
            get
            {
                return _shipper;
            }
        }
        /// <summary>
        /// 托运号
        /// </summary>
        public string shipperNum
        {
            set
            {
                _shippernum = value;
            }
            get
            {
                return _shippernum;
            }
        }
        /// <summary>
        /// 提单号
        /// </summary>
        public string billNames
        {
            set
            {
                _billnames = value;
            }
            get
            {
                return _billnames;
            }
        }
        /// <summary>
        /// 服务合同号
        /// </summary>
        public string contractNum
        {
            set
            {
                _contractnum = value;
            }
            get
            {
                return _contractnum;
            }
        }
        /// <summary>
        /// 货品号
        /// </summary>
        public string goodsNum
        {
            set
            {
                _goodsnum = value;
            }
            get
            {
                return _goodsnum;
            }
        }
        /// <summary>
        /// 收货人
        /// </summary>
        public string consi
        {
            set
            {
                _consi = value;
            }
            get
            {
                return _consi;
            }
        }
        /// <summary>
        /// 预载船
        /// </summary>
        public string preShip
        {
            set
            {
                _preship = value;
            }
            get
            {
                return _preship;
            }
        }
        /// <summary>
        /// 远洋泊船
        /// </summary>
        public string oceanShip
        {
            set
            {
                _oceanship = value;
            }
            get
            {
                return _oceanship;
            }
        }
        /// <summary>
        /// 航海号
        /// </summary>
        public string navNum
        {
            set
            {
                _navnum = value;
            }
            get
            {
                return _navnum;
            }
        }
        /// <summary>
        /// 代理商
        /// </summary>
        public string agent
        {
            set
            {
                _agent = value;
            }
            get
            {
                return _agent;
            }
        }
        /// <summary>
        /// 收据地
        /// </summary>
        public string receipt
        {
            set
            {
                _receipt = value;
            }
            get
            {
                return _receipt;
            }
        }
        /// <summary>
        /// 裝船港
        /// </summary>
        public string shipHar
        {
            set
            {
                _shiphar = value;
            }
            get
            {
                return _shiphar;
            }
        }
        /// <summary>
        /// 卸船港
        /// </summary>
        public string unShopHar
        {
            set
            {
                _unshophar = value;
            }
            get
            {
                return _unshophar;
            }
        }
        /// <summary>
        /// 目的地
        /// </summary>
        public string desTi
        {
            set
            {
                _desti = value;
            }
            get
            {
                return _desti;
            }
        }
        /// <summary>
        /// 最终目的地
        /// </summary>
        public string lastDesTi
        {
            set
            {
                _lastdesti = value;
            }
            get
            {
                return _lastdesti;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public decimal? num
        {
            set
            {
                _num = value;
            }
            get
            {
                return _num;
            }
        }
        /// <summary>
        /// 集装箱号
        /// </summary>
        public string containNum
        {
            set
            {
                _containnum = value;
            }
            get
            {
                return _containnum;
            }
        }
        /// <summary>
        /// 封条
        /// </summary>
        public string paper
        {
            set
            {
                _paper = value;
            }
            get
            {
                return _paper;
            }
        }
        /// <summary>
        /// 封条重量
        /// </summary>
        public decimal? conWeight
        {
            set
            {
                _conweight = value;
            }
            get
            {
                return _conweight;
            }
        }
        /// <summary>
        /// 包装重量
        /// </summary>
        public decimal? pakeWeight
        {
            set
            {
                _pakeweight = value;
            }
            get
            {
                return _pakeweight;
            }
        }
        /// <summary>
        /// 印章
        /// </summary>
        public string seal
        {
            set
            {
                _seal = value;
            }
            get
            {
                return _seal;
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
        /// 运费预付地点
        /// </summary>
        public string freightAdd
        {
            set
            {
                _freightadd = value;
            }
            get
            {
                return _freightadd;
            }
        }
        /// <summary>
        /// 船名
        /// </summary>
        public string shipName
        {
            get
            {
                return _shipname;
            }set
            {
                _shipname = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal? price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }

        /// <summary>
        /// 发货单位
        /// </summary>
        public string ForUnit
        {
            get
            {
                return _forUnit;
            }

            set
            {
                _forUnit = value;
            }
        }

        /// <summary>
        /// 供应方公司
        /// </summary>
        public string SupCom
        {
            get
            {
                return _supCom;
            }

            set
            {
                _supCom = value;
            }
        }

        /// <summary>
        /// 接收方
        /// </summary>
        public string Receive
        {
            get
            {
                return _receive;
            }

            set
            {
                _receive = value;
            }
        }

        /// <summary>
        /// 接收方地址
        /// </summary>
        public string ReceiveAdd
        {
            get
            {
                return _receiveAdd;
            }

            set
            {
                _receiveAdd = value;
            }
        }

        /// <summary>
        /// 质量指标
        /// </summary>
        public string QuaIndex
        {
            get
            {
                return _quaIndex;
            }

            set
            {
                _quaIndex = value;
            }
        }

        /// <summary>
        /// 合同号
        /// </summary>
        public string ContractNums
        {
            get
            {
                return _contractNums;
            }

            set
            {
                _contractNums = value;
            }
        }

        /// <summary>
        /// 美金单价
        /// </summary>
        public decimal? PriceMJ
        {
            get
            {
                return _priceMJ;
            }

            set
            {
                _priceMJ = value;
            }
        }

        /// <summary>
        /// F.O.B金额
        /// </summary>
        public decimal? FOB
        {
            get
            {
                return _FOB;
            }

            set
            {
                _FOB = value;
            }
        }

        /// <summary>
        /// CFR金额
        /// </summary>
        public decimal? CFR
        {
            get
            {
                return _CFR;
            }

            set
            {
                _CFR = value;
            }
        }
        //-------------------------------------------------------------
        /// <summary>
        /// 分析机构单位
        /// </summary>
        public string AnalysisUnit
        {
            get
            {
                return _AnalysisUnit;
            }

            set
            {
                _AnalysisUnit = value;
            }
        }
        /// <summary>
        /// 分析地址
        /// </summary>
        public string AnalysisAddress
        {
            get
            {
                return _AnalysisAddress;
            }

            set
            {
                _AnalysisAddress = value;
            }
        }
        /// <summary>
        /// 分析网址
        /// </summary>
        public string AnalysisWebsite
        {
            get
            {
                return _AnalysisWebsite;
            }

            set
            {
                _AnalysisWebsite = value;
            }
        }
        /// <summary>
        /// 报告时间
        /// </summary>
        public DateTime? ReportingTime
        {
            get
            {
                return _ReportingTime;
            }

            set
            {
                _ReportingTime = value;
            }
        }
        /// <summary>
        /// 分析电话
        /// </summary>
        public string Telephone
        {
            get
            {
                return _Telephone;
            }

            set
            {
                _Telephone = value;
            }
        }
        /// <summary>
        /// E-mail
        /// </summary>
        public string Mailbox
        {
            get
            {
                return _Mailbox;
            }

            set
            {
                _Mailbox = value;
            }
        }
        /// <summary>
        /// 报告地址
        /// </summary>
        public string ReportAddress
        {
            get
            {
                return _ReportAddress;
            }

            set
            {
                _ReportAddress = value;
            }
        }
        /// <summary>
        /// 分析传真
        /// </summary>
        public string Fax
        {
            get
            {
                return _Fax;
            }

            set
            {
                _Fax = value;
            }
        }
        /// <summary>
        /// 生产工艺
        /// </summary>
        public string ProductionProcess
        {
            get
            {
                return _ProductionProcess;
            }

            set
            {
                _ProductionProcess = value;
            }
        }
        /// <summary>
        /// 起运港：国别
        /// </summary>
        public string StartingCountry
        {
            get
            {
                return _StartingCountry;
            }

            set
            {
                _StartingCountry = value;
            }
        }
        /// <summary>
        /// 起运港：城市
        /// </summary>
        public string StartingCity
        {
            get
            {
                return _StartingCity;
            }

            set
            {
                _StartingCity = value;
            }
        }
        /// <summary>
        /// 目的港：国别
        /// </summary>
        public string DestinationCountry
        {
            get
            {
                return _DestinationCountry;
            }

            set
            {
                _DestinationCountry = value;
            }
        }
        /// <summary>
        /// 目的港：城市
        /// </summary>
        public string DestinationCity
        {
            get
            {
                return _DestinationCity;
            }

            set
            {
                _DestinationCity = value;
            }
        }
        /// <summary>
        /// 发货后/工厂
        /// </summary>
        public string ForwardingUnit
        {
            get
            {
                return _forwardingUnit;
            }

            set
            {
                _forwardingUnit = value;
            }
        }
        /// <summary>
        /// 检验时间
        /// </summary>
        public DateTime? TestTime
        {
            get
            {
                return _TestTime;
            }

            set
            {
                _TestTime = value;
            }
        }
        /// <summary>
        /// 检验地址
        /// </summary>
        public string CheckAddress
        {
            get
            {
                return _CheckAddress;
            }

            set
            {
                _CheckAddress = value;
            }
        }
        /// <summary>
        /// 取样内容
        /// </summary>
        public string SamplingContent
        {
            get
            {
                return _SamplingContent;
            }

            set
            {
                _SamplingContent = value;
            }
        }
        /// <summary>
        /// 分析单位
        /// </summary>
        public string InspectionUnit
        {
            get
            {
                return _InspectionUnit;
            }

            set
            {
                _InspectionUnit = value;
            }
        }
        /// <summary>
        /// SGSTVN
        /// </summary>
        public decimal? SGS_TVN
        {
            get
            {
                return _SGS_TVN;
            }

            set
            {
                _SGS_TVN = value;
            }
        }
        /// <summary>
        /// 沙
        /// </summary>
        public decimal? SGS_Sand
        {
            get
            {
                return _SGS_Sand;
            }

            set
            {
                _SGS_Sand = value;
            }
        }
        /// <summary>
        /// SGS_组胺
        /// </summary>
        public decimal? SGS_Histamine
        {
            get
            {
                return _SGS_Histamine;
            }

            set
            {
                _SGS_Histamine = value;
            }
        }
        /// <summary>
        /// 称重方法
        /// </summary>
        public string WeighingMethod
        {
            get
            {
                return _WeighingMethod;
            }

            set
            {
                _WeighingMethod = value;
            }
        }
        /// <summary>
        /// 平均净重
        /// </summary>
        public decimal? AverageNetWeight
        {
            get
            {
                return _AverageNetWeight;
            }

            set
            {
                _AverageNetWeight = value;
            }
        }
        /// <summary>
        /// 平均皮重
        /// </summary>
        public decimal? AverageSkinWeight
        {
            get
            {
                return _AverageSkinWeight;
            }

            set
            {
                _AverageSkinWeight = value;
            }
        }
        /// <summary>
        /// 总净重
        /// </summary>
        public decimal? TotalWeight
        {
            get
            {
                return _TotalWeight;
            }

            set
            {
                _TotalWeight = value;
            }
        }
        /// <summary>
        /// 总皮重
        /// </summary>
        public decimal? TotalSkinWeight
        {
            get
            {
                return _TotalSkinWeight;
            }

            set
            {
                _TotalSkinWeight = value;
            }
        }
        /// <summary>
        /// 装箱包数
        /// </summary>
        public decimal? PackingUumber
        {
            get
            {
                return _PackingUumber;
            }

            set
            {
                _PackingUumber = value;
            }
        }
        /// <summary>
        /// 重量单每箱净重
        /// </summary>
        public decimal? NetWeightPerBox
        {
            get
            {
                return _NetWeightPerBox;
            }

            set
            {
                _NetWeightPerBox = value;
            }
        }
        /// <summary>
        /// 熏蒸地址
        /// </summary>
        public string FumigationAddress
        {
            get
            {
                return _FumigationAddress;
            }

            set
            {
                _FumigationAddress = value;
            }
        }
        /// <summary>
        /// 化学和浓度使用
        /// </summary>
        public string ChemicalConcentration
        {
            get
            {
                return _ChemicalConcentration;
            }

            set
            {
                _ChemicalConcentration = value;
            }
        }
        /// <summary>
        /// 熏蒸日期
        /// </summary>
        public DateTime? FumigationDate
        {
            get
            {
                return _FumigationDate;
            }

            set
            {
                _FumigationDate = value;
            }
        }
        /// <summary>
        /// 熏蒸时间
        /// </summary>
        public string FumigationTime
        {
            get
            {
                return _FumigationTime;
            }

            set
            {
                _FumigationTime = value;
            }
        }
        /// <summary>
        /// 熏蒸温度
        /// </summary>
        public string FumigatingTemperature
        {
            get
            {
                return _FumigatingTemperature;
            }

            set
            {
                _FumigatingTemperature = value;
            }
        }
        /// <summary>
        /// 标签抗氧化剂
        /// </summary>
        public decimal? Label_Antioxidant
        {
            get
            {
                return _Label_Antioxidant;
            }

            set
            {
                _Label_Antioxidant = value;
            }
        }
        /// <summary>
        /// 报盘FFA
        /// </summary>
        public decimal? Quote_FFA
        {
            get
            {
                return _Quote_FFA;
            }

            set
            {
                _Quote_FFA = value;
            }
        }
        /// <summary>
        /// 沙盐
        /// </summary>
        public decimal? Quote_SandSalt
        {
            get
            {
                return _Quote_SandSalt;
            }

            set
            {
                _Quote_SandSalt = value;
            }
        }
        /// <summary>
        /// 沙
        /// </summary>
        public decimal? Quote_Sand
        {
            get
            {
                return _Quote_Sand;
            }

            set
            {
                _Quote_Sand = value;
            }
        }
        /// <summary>
        /// 报盘抗氧化剂
        /// </summary>
        public decimal? ContractAntioxidant
        {
            get
            {
                return _ContractAntioxidant;
            }

            set
            {
                _ContractAntioxidant = value;
            }
        }
        /// <summary>
        /// 标签蛋白
        /// </summary>
        public decimal? Label_Protein
        {
            get
            {
                return _Label_Protein;
            }

            set
            {
                _Label_Protein = value;
            }
        }
        /// <summary>
        /// 标签水分
        /// </summary>
        public decimal? Label_Water
        {
            get
            {
                return _Label_Water;
            }

            set
            {
                _Label_Water = value;
            }
        }
        /// <summary>
        /// 标签脂肪
        /// </summary>
        public decimal? Label_Fat
        {
            get
            {
                return _Label_Fat;
            }

            set
            {
                _Label_Fat = value;
            }
        }
        /// <summary>
        /// 标签FFA
        /// </summary>
        public decimal? Label_FFA
        {
            get
            {
                return _Label_FFA;
            }

            set
            {
                _Label_FFA = value;
            }
        }
        /// <summary>
        /// 标签沙盐
        /// </summary>
        public decimal? Label_SandSalt
        {
            get
            {
                return _Label_SandSalt;
            }

            set
            {
                _Label_SandSalt = value;
            }
        }
        /// <summary>
        /// 装船日期
        /// </summary>
        public DateTime? shipmentdate
        {
            get
            {
                return _shipmentdate;
            }

            set
            {
                _shipmentdate = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Band
        {
            get
            {
                return _Band;
            }

            set
            {
                _Band = value;
            }
        }
        /// <summary>
        /// 入库日期
        /// </summary>
        public DateTime? Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }
        /// <summary>
        /// 品质规格
        /// </summary>
        public string Specification
        {
            get
            {
                return _Specification;
            }

            set
            {
                _Specification = value;
            }
        }
        /// <summary>
        /// 入库包数
        /// </summary>
        public string Warehousing
        {
            get
            {
                return _Warehousing;
            }

            set
            {
                _Warehousing = value;
            }
        }
        /// <summary>
        /// 入库港口
        /// </summary>
        public string port
        {
            get
            {
                return _Port;
            }

            set
            {
                _Port = value;
            }
        }
        /// <summary>
        /// 入库汇率
        /// </summary>
        public string spotEexchangeRate
        {
            get
            {
                return _spotEexchangeRate;
            }

            set
            {
                _spotEexchangeRate = value;
            }
        }
        /// <summary>
        /// sgs重量
        /// </summary>
        public decimal? SgsWeight
        {
            get
            {
                return _SgsWeight;
            }

            set
            {
                _SgsWeight = value;
            }
        }
        /// <summary>
        /// sgs包数
        /// </summary>
        public string SgsQuantity
        {
            get
            {
                return _SgsQuantity;
            }

            set
            {
                _SgsQuantity = value;
            }
        }
        /// <summary>
        /// 桩角号
        /// </summary>
        public string cornerno
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


        #endregion Model

    }
}
