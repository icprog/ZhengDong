using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class PurchaseRequisitionEntity
    {
        public PurchaseRequisitionEntity() {

        }
        private int _id;
        private string _Openbank;
        private string _accountnumber;
        private string _Numbering;
        private string _ContractNo;
        private string _supplier;
        private string _SupplierId;
        private string _DemandSide;
        private string _DemandSideId;
        private DateTime? _DateOfSigni;
        private string _PlaceOfSign;
        private string _ProductName;
        private string _Unit;
        private string _Variety;
        private string _Quantity;
        private string _UnitPrice;
        private string _AmountOfMoney;
        private string _Protein;
        private string _TVN;
        private string _Histamine;
        private string _FFA;
        private string _Fat;
        private string _Moisture;
        private string _SandAndSalt;
        private string _Sand;
        private string _Rebate;
        private string _USDollarPrice;
        private string _Country;
        private string _Brand;
        private string _TradingLocations;
        private DateTime? _TimeOfShipment;
        private DateTime? _ExpectedDate;
        private string _modifyman;
        private DateTime? _modifytime;
        private string _createman;
        private DateTime? _createtime;
        private string _Purchasingcontacts;
        private string _PurchasingcontactsId;
        private DateTime? deliverytime;
        private string _FishmealId;
        private string _Remarks;
        private string _NameOfTheShip;
        private string _BillOfLadingNumber;
        private string _DemandSideShort;
        private string _SupplierAbbreviation;
        private string _Ash;
        private string _HTprotein;
        private string _HTTVB;
        private string _HTHistamine;
        private string _HTFFA;
        private string _HTFat;
        private string _HTMoisture;
        private string _HTSandAndSalt;
        private string _HTSand;
        private string _HTUnit;
        private string _HTAsh;
        private string _Lysine;
        private string _Methionine;
        private string _MJAmount;
        private string _Specification;
        private string _validate;
            #region

        public int Id
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

        public string ContractNo
        {
            get
            {
                return _ContractNo;
            }

            set
            {
                _ContractNo = value;
            }
        }
        /// <summary>
        /// 供方
        /// </summary>
        public string Supplier
        {
            get
            {
                return _supplier;
            }

            set
            {
                _supplier = value;
            }
        }
        /// <summary>
        /// 需方
        /// </summary>
        public string DemandSide
        {
            get
            {
                return _DemandSide;
            }

            set
            {
                _DemandSide = value;
            }
        }

        public DateTime? DateOfSigni
        {
            get
            {
                return _DateOfSigni;
            }

            set
            {
                _DateOfSigni = value;
            }
        }

        public string PlaceOfSign
        {
            get
            {
                return _PlaceOfSign;
            }

            set
            {
                _PlaceOfSign = value;
            }
        }

        public string ProductName
        {
            get
            {
                return _ProductName;
            }

            set
            {
                _ProductName = value;
            }
        }

        public string Unit
        {
            get
            {
                return _Unit;
            }

            set
            {
                _Unit = value;
            }
        }

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

        public string Quantity
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

        public string UnitPrice
        {
            get
            {
                return _UnitPrice;
            }

            set
            {
                _UnitPrice = value;
            }
        }

        public string AmountOfMoney
        {
            get
            {
                return _AmountOfMoney;
            }

            set
            {
                _AmountOfMoney = value;
            }
        }

        public string Protein
        {
            get
            {
                return _Protein;
            }

            set
            {
                _Protein = value;
            }
        }

        public string TVN
        {
            get
            {
                return _TVN;
            }

            set
            {
                _TVN = value;
            }
        }

        public string Histamine
        {
            get
            {
                return _Histamine;
            }

            set
            {
                _Histamine = value;
            }
        }

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

        public string Fat
        {
            get
            {
                return _Fat;
            }

            set
            {
                _Fat = value;
            }
        }

        public string Moisture
        {
            get
            {
                return _Moisture;
            }

            set
            {
                _Moisture = value;
            }
        }

        public string SandAndSalt
        {
            get
            {
                return _SandAndSalt;
            }

            set
            {
                _SandAndSalt = value;
            }
        }

        public string Sand
        {
            get
            {
                return _Sand;
            }

            set
            {
                _Sand = value;
            }
        }

        public string Rebate
        {
            get
            {
                return _Rebate;
            }

            set
            {
                _Rebate = value;
            }
        }

        public string USDollarPrice
        {
            get
            {
                return _USDollarPrice;
            }

            set
            {
                _USDollarPrice = value;
            }
        }

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

        public string TradingLocations
        {
            get
            {
                return _TradingLocations;
            }

            set
            {
                _TradingLocations = value;
            }
        }

        public DateTime? TimeOfShipment
        {
            get
            {
                return _TimeOfShipment;
            }

            set
            {
                _TimeOfShipment = value;
            }
        }

        public DateTime? ExpectedDate
        {
            get
            {
                return _ExpectedDate;
            }

            set
            {
                _ExpectedDate = value;
            }
        }

        public string Modifyman
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

        public DateTime? Modifytime
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

        public DateTime? Createtime
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

        public string Openbank
        {
            get
            {
                return _Openbank;
            }

            set
            {
                _Openbank = value;
            }
        }

        public string Accountnumber
        {
            get
            {
                return _accountnumber;
            }

            set
            {
                _accountnumber = value;
            }
        }
        /// <summary>
        /// 供方联系人
        /// </summary>
        public string Purchasingcontacts
        {
            get
            {
                return _Purchasingcontacts;
            }

            set
            {
                _Purchasingcontacts = value;
            }
        }

        public DateTime? Deliverytime
        {
            get
            {
                return deliverytime;
            }

            set
            {
                deliverytime = value;
            }
        }
        /// <summary>
        /// 供方Id
        /// </summary>
        public string SupplierId
        {
            get
            {
                return _SupplierId;
            }

            set
            {
                _SupplierId = value;
            }
        }
        /// <summary>
        /// 供方联系人Id
        /// </summary>
        public string PurchasingcontactsId
        {
            get
            {
                return _PurchasingcontactsId;
            }

            set
            {
                _PurchasingcontactsId = value;
            }
        }
        /// <summary>
        /// 需方Id
        /// </summary>
        public string DemandSideId
        {
            get
            {
                return _DemandSideId;
            }

            set
            {
                _DemandSideId = value;
            }
        }
        /// <summary>
        /// 鱼粉Id
        /// </summary>
        public string FishmealId
        {
            get
            {
                return _FishmealId;
            }

            set
            {
                _FishmealId = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brand
        {
            get
            {
                return _Brand;
            }

            set
            {
                _Brand = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            get
            {
                return _Remarks;
            }

            set
            {
                _Remarks = value;
            }
        }
        /// <summary>
        /// 船名
        /// </summary>
        public string NameOfTheShip
        {
            get
            {
                return _NameOfTheShip;
            }

            set
            {
                _NameOfTheShip = value;
            }
        }
        /// <summary>
        /// 提单号
        /// </summary>
        public string BillOfLadingNumber
        {
            get
            {
                return _BillOfLadingNumber;
            }

            set
            {
                _BillOfLadingNumber = value;
            }
        }
        /// <summary>
        /// 需方简称
        /// 
        /// </summary>
        public string DemandSideShort
        {
            get
            {
                return _DemandSideShort;
            }

            set
            {
                _DemandSideShort = value;
            }
        }
        /// <summary>
        /// 供方简称
        /// </summary>
        public string SupplierAbbreviation
        {
            get
            {
                return _SupplierAbbreviation;
            }

            set
            {
                _SupplierAbbreviation = value;
            }
        }
        /// <summary>
        /// 灰份
        /// </summary>
        public string Ash
        {
            get
            {
                return _Ash;
            }

            set
            {
                _Ash = value;
            }
        }
        /// <summary>
        /// 合同蛋白
        /// </summary>
        public string HTprotein
        {
            get
            {
                return _HTprotein;
            }

            set
            {
                _HTprotein = value;
            }
        }
        /// <summary>
        /// 合同TVN
        /// </summary>
        public string HTTVB
        {
            get
            {
                return _HTTVB;
            }

            set
            {
                _HTTVB = value;
            }
        }
        /// <summary>
        /// 合同组胺
        /// </summary>
        public string HTHistamine
        {
            get
            {
                return _HTHistamine;
            }

            set
            {
                _HTHistamine = value;
            }
        }
        /// <summary>
        /// 合同FFA
        /// </summary>
        public string HTFFA
        {
            get
            {
                return _HTFFA;
            }

            set
            {
                _HTFFA = value;
            }
        }
        /// <summary>
        /// 合同脂肪
        /// </summary>
        public string HTFat
        {
            get
            {
                return _HTFat;
            }

            set
            {
                _HTFat = value;
            }
        }
        /// <summary>
        /// 合同水分
        /// </summary>
        public string HTMoisture
        {
            get
            {
                return _HTMoisture;
            }

            set
            {
                _HTMoisture = value;
            }
        }
        /// <summary>
        /// 合同沙和盐
        /// </summary>
        public string HTSandAndSalt
        {
            get
            {
                return _HTSandAndSalt;
            }

            set
            {
                _HTSandAndSalt = value;
            }
        }
        /// <summary>
        /// 合同沙
        /// </summary>
        public string HTSand
        {
            get
            {
                return _HTSand;
            }

            set
            {
                _HTSand = value;
            }
        }
        /// <summary>
        /// 合同酸价
        /// </summary>
        public string HTUnit
        {
            get
            {
                return _HTUnit;
            }

            set
            {
                _HTUnit = value;
            }
        }
        /// <summary>
        /// 合同脂肪
        /// </summary>
        public string HTAsh
        {
            get
            {
                return _HTAsh;
            }

            set
            {
                _HTAsh = value;
            }
        }
        /// <summary>
        /// 赖氨酸
        /// </summary>
        public string Lysine
        {
            get
            {
                return _Lysine;
            }

            set
            {
                _Lysine = value;
            }
        }
        /// <summary>
        /// 蛋氨酸
        /// </summary>
        public string Methionine
        {
            get
            {
                return _Methionine;
            }

            set
            {
                _Methionine = value;
            }
        }
        /// <summary>
        /// 美金金额
        /// </summary>
        public string MJAmount
        {
            get
            {
                return _MJAmount;
            }

            set
            {
                _MJAmount = value;
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
        /// 是否有效
        /// </summary>
        public string validate
        {
            get
            {
                return _validate;
            }

            set
            {
                _validate = value;
            }
        }
    }
    #endregion
}
