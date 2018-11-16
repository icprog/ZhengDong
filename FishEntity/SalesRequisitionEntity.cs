using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    [Serializable]
    public class SalesRequisitionEntity
    {
        public SalesRequisitionEntity ( )
        {
        }
        #region Model
        private string _Numbering;
        private string _product_id;
        private string _CNumbering;
        private int _id;
        private string _code;
        private bool _supplierbool;
        private string _supplier;
        private string _supplierid;
        private string _supplierAbbreviation;
        private string _supplierContact;
        private string _supplierContactId;
        private bool _demandbool;
        private string _demand;
        private string _demandid;
        private string _demandAbbreviation;
        private string _demandContact;
        private string _demandContactId;
        private DateTime? _signdate;
        private string _signplace;
        private bool _deindex;
        private decimal _rebate;
        private bool _rebatebool;
        private decimal _portprice;
        private bool _portpricebool;
        private string _country;
        private bool _countrybool;
        private string _transport;
        private DateTime? _deadline;
        private decimal _freight;
        private string _delivery;
        private decimal _dt;
        private decimal _dty;
        private decimal _lxt;
        private decimal _lxty;
        private decimal? _overflow;
        private string _settlementmethod;
        private DateTime? _payment;
        private string _bank;
        private string _receipt;
        private string _accountnumber;
        private string _remart;
        private string _WithSkin;
        private bool _WithSkinbool;
        private DateTime _createtime;
        private string _createman;
        private DateTime _modifytime;
        private string _modifyman;
        private string _HeTongDanJia;
        private bool _dbbool;
        private bool _tvnbool;
        private bool _zabool;
        private bool _ffabool;
        private bool _zfbool;
        private bool _sfbool;
        private bool _shybool;
        private bool _szbool;
        private bool _cdbbool;
        private bool _tvnOnebool;
        private bool _hfbool;
        private bool _zaOnebool;
        private bool _ffaOnebool;
        private bool _zfOnebool;
        private bool _sfOnebool;
        private bool _shyOnebool;
        private bool _szOnebool;
        private bool _informationbool;
        private bool _Stockpilebool;
        private bool _WithSkinSumbool;
        private bool _PortpriceSumBool;
        private bool _Freightbool;
        private bool _FreightSumbool;
        private bool _rebateSumBool;
        private string _Purchasingunits;
        private string _PurchasingunitsId;
        private string _Purchasingcontacts;
        private string _PurchasingcontactsId;
        private string _Purchasecontractnumber;
        private string _DemandSideBank;
        private string _PaymentUnit;
        private string _RequiredAccount;
        private string _UnitPrice;
        private string _Variety;
        private string _cm;
        private string _Quantity;
        private string _zjh;
        private string _tdh;
        private string _pp;
        private string _BillOfLadingid;
        private string _Goods;
        private string _Pileangle;
        private string _Shipno;
        private bool _rabZy;
        private bool _rabZz;
        private string _productname;
        private string _Funit;
        private string _amonut;

        private string _db;
        private string _za;
        private string _sz;
        private string _tvn;
        private string _hf;
        private string _sf;
        private string _shy;
        private string _zf;
        private string _unitprice;
        private string _pinzhi;
        private string _baoshu;

        private decimal _moneyYFK;

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
        /// 合同编号
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
        /// 供方
        /// </summary>
        public string supplier
        {
            set
            {
                _supplier = value;
            }
            get
            {
                return _supplier;
            }
        }
        /// <summary>
        /// 供方ID
        /// </summary>
        public string supplierId
        {
            set
            {
                _supplierid = value;
            }
            get
            {
                return _supplierid;
            }
        }
        /// <summary>
        /// 需方
        /// </summary>
        public string demand
        {
            set
            {
                _demand = value;
            }
            get
            {
                return _demand;
            }
        }
        /// <summary>
        /// 需方ID
        /// </summary>
        public string demandId
        {
            set
            {
                _demandid = value;
            }
            get
            {
                return _demandid;
            }
        }
        /// <summary>
        /// 签约时间
        /// </summary>
        public DateTime? Signdate
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
        /// 签约地点
        /// </summary>
        public string Signplace
        {
            set
            {
                _signplace = value;
            }
            get
            {
                return _signplace;
            }
        }
        /// <summary>
        /// 国内检测指标
        /// </summary>
        public bool deIndex
        {
            set
            {
                _deindex = value;
            }
            get
            {
                return _deindex;
            }
        }
        /// <summary>
        /// 回扣
        /// </summary>
        public decimal rebate
        {
            set
            {
                _rebate = value;
            }
            get
            {
                return _rebate;
            }
        }
        /// <summary>
        /// 是否回扣
        /// </summary>
        public bool rebateBool
        {
            set
            {
                _rebatebool = value;
            }
            get
            {
                return _rebatebool;
            }
        }
        /// <summary>
        ///  港价
        /// </summary>
        public decimal Portprice
        {
            set
            {
                _portprice = value;
            }
            get
            {
                return _portprice;
            }
        }
        /// <summary>
        /// 是否港价
        /// </summary>
        public bool PortpriceBool
        {
            set
            {
                _portpricebool = value;
            }
            get
            {
                return _portpricebool;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Country
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
        /// 是否国别
        /// </summary>
        public bool CountryBool
        {
            set
            {
                _countrybool = value;
            }
            get
            {
                return _countrybool;
            }
        }
        /// <summary>
        /// 运输方式
        /// </summary>
        public string transport
        {
            set
            {
                _transport = value;
            }
            get
            {
                return _transport;
            }
        }
        /// <summary>
        /// 交货限期
        /// </summary>
        public DateTime? deadline
        {
            set
            {
                _deadline = value;
            }
            get
            {
                return _deadline;
            }
        }
        /// <summary>
        /// 运费
        /// </summary>
        public decimal Freight
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
        /// 交货地点
        /// </summary>
        public string delivery
        {
            set
            {
                _delivery = value;
            }
            get
            {
                return _delivery;
            }
        }
        /// <summary>
        /// 吨/天
        /// </summary>
        public decimal dt
        {
            set
            {
                _dt = value;
            }
            get
            {
                return _dt;
            }
        }
        /// <summary>
        /// 吨/天(元)
        /// </summary>
        public decimal dty
        {
            set
            {
                _dty = value;
            }
            get
            {
                return _dty;
            }
        }
        /// <summary>
        /// 利息/天
        /// </summary>
        public decimal lxt
        {
            set
            {
                _lxt = value;
            }
            get
            {
                return _lxt;
            }
        }
        /// <summary>
        /// 利息/天(元)
        /// </summary>
        public decimal lxty
        {
            set
            {
                _lxty = value;
            }
            get
            {
                return _lxty;
            }
        }
        /// <summary>
        /// 结算方式以及限期
        /// </summary>
        public string Settlementmethod
        {
            set
            {
                _settlementmethod = value;
            }
            get
            {
                return _settlementmethod;
            }
        }
        /// <summary>
        /// 回款时间
        /// </summary>
        public DateTime? payment
        {
            set
            {
                _payment = value;
            }
            get
            {
                return _payment;
            }
        }
        /// <summary>
        /// 开户银行
        /// </summary>
        public string Bank
        {
            set
            {
                _bank = value;
            }
            get
            {
                return _bank;
            }
        }
        /// <summary>
        /// 收款单位
        /// </summary>
        public string Receipt
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
        /// 帐号
        /// </summary>
        public string accountnumber
        {
            set
            {
                _accountnumber = value;
            }
            get
            {
                return _accountnumber;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remart
        {
            set
            {
                _remart = value;
            }
            get
            {
                return _remart;
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
        /// 带皮扣重
        /// </summary>
        public string WithSkin
        {
            get
            {
                return _WithSkin;
            }

            set
            {
                _WithSkin = value;
            }
        }
        /// <summary>
        /// 是否带皮扣重
        /// </summary>
        public bool WithSkinbool
        {
            get
            {
                return _WithSkinbool;
            }

            set
            {
                _WithSkinbool = value;
            }
        }

        public string HeTongDanJia
        {
            get
            {
                return _HeTongDanJia;
            }

            set
            {
                _HeTongDanJia = value;
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

        public bool Supplierbool
        {
            get
            {
                return _supplierbool;
            }

            set
            {
                _supplierbool = value;
            }
        }

        public bool Demandbool
        {
            get
            {
                return _demandbool;
            }

            set
            {
                _demandbool = value;
            }
        }

        public bool Dbbool
        {
            get
            {
                return _dbbool;
            }

            set
            {
                _dbbool = value;
            }
        }

        public bool Tvnbool
        {
            get
            {
                return _tvnbool;
            }

            set
            {
                _tvnbool = value;
            }
        }

        public bool Zabool
        {
            get
            {
                return _zabool;
            }

            set
            {
                _zabool = value;
            }
        }

        public bool Ffabool
        {
            get
            {
                return _ffabool;
            }

            set
            {
                _ffabool = value;
            }
        }

        public bool Zfbool
        {
            get
            {
                return _zfbool;
            }

            set
            {
                _zfbool = value;
            }
        }

        public bool Sfbool
        {
            get
            {
                return _sfbool;
            }

            set
            {
                _sfbool = value;
            }
        }

        public bool Shybool
        {
            get
            {
                return _shybool;
            }

            set
            {
                _shybool = value;
            }
        }

        public bool Szbool
        {
            get
            {
                return _szbool;
            }

            set
            {
                _szbool = value;
            }
        }

        public bool Cdbbool
        {
            get
            {
                return _cdbbool;
            }

            set
            {
                _cdbbool = value;
            }
        }

        public bool TvnOnebool
        {
            get
            {
                return _tvnOnebool;
            }

            set
            {
                _tvnOnebool = value;
            }
        }

        public bool Hfbool
        {
            get
            {
                return _hfbool;
            }

            set
            {
                _hfbool = value;
            }
        }

        public bool ZaOnebool
        {
            get
            {
                return _zaOnebool;
            }

            set
            {
                _zaOnebool = value;
            }
        }

        public bool FfaOnebool
        {
            get
            {
                return _ffaOnebool;
            }

            set
            {
                _ffaOnebool = value;
            }
        }

        public bool ZfOnebool
        {
            get
            {
                return _zfOnebool;
            }

            set
            {
                _zfOnebool = value;
            }
        }

        public bool SfOnebool
        {
            get
            {
                return _sfOnebool;
            }

            set
            {
                _sfOnebool = value;
            }
        }

        public bool ShyOnebool
        {
            get
            {
                return _shyOnebool;
            }

            set
            {
                _shyOnebool = value;
            }
        }

        public bool SzOnebool
        {
            get
            {
                return _szOnebool;
            }

            set
            {
                _szOnebool = value;
            }
        }

        public bool Informationbool
        {
            get
            {
                return _informationbool;
            }

            set
            {
                _informationbool = value;
            }
        }

        public bool Stockpilebool
        {
            get
            {
                return _Stockpilebool;
            }

            set
            {
                _Stockpilebool = value;
            }
        }

        public bool WithSkinSumbool
        {
            get
            {
                return _WithSkinSumbool;
            }

            set
            {
                _WithSkinSumbool = value;
            }
        }

        public bool PortpriceSumBool
        {
            get
            {
                return _PortpriceSumBool;
            }

            set
            {
                _PortpriceSumBool = value;
            }
        }

        public bool Freightbool
        {
            get
            {
                return _Freightbool;
            }

            set
            {
                _Freightbool = value;
            }
        }

        public bool FreightSumbool
        {
            get
            {
                return _FreightSumbool;
            }

            set
            {
                _FreightSumbool = value;
            }
        }

        public bool RebateSumBool
        {
            get
            {
                return _rebateSumBool;
            }

            set
            {
                _rebateSumBool = value;
            }
        }
        /// <summary>
        /// 采购单位
        /// </summary>
        public string Purchasingunits
        {
            get
            {
                return _Purchasingunits;
            }

            set
            {
                _Purchasingunits = value;
            }
        }
        /// <summary>
        /// 采购联系人
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
        /// <summary>
        /// 采购合同号
        /// </summary>
        public string Purchasecontractnumber
        {
            get
            {
                return _Purchasecontractnumber;
            }

            set
            {
                _Purchasecontractnumber = value;
            }
        }
        /// <summary>
        /// 需方开户行
        /// </summary>
        public string DemandSideBank
        {
            get
            {
                return _DemandSideBank;
            }

            set
            {
                _DemandSideBank = value;
            }
        }
        /// <summary>
        /// 需方付款单位
        /// </summary>
        public string PaymentUnit
        {
            get
            {
                return _PaymentUnit;
            }

            set
            {
                _PaymentUnit = value;
            }
        }
        /// <summary>
        /// 需方账号
        /// </summary>
        public string RequiredAccount
        {
            get
            {
                return _RequiredAccount;
            }

            set
            {
                _RequiredAccount = value;
            }
        }
        /// <summary>
        /// 供方联系人
        /// </summary>
        public string SupplierContact
        {
            get
            {
                return _supplierContact;
            }

            set
            {
                _supplierContact = value;
            }
        }
        /// <summary>
        /// 需方联系人
        /// </summary>
        public string DemandContact
        {
            get
            {
                return _demandContact;
            }

            set
            {
                _demandContact = value;
            }
        }
        /// <summary>
        /// 供方联系人Id
        /// </summary>
        public string SupplierContactId
        {
            get
            {
                return _supplierContactId;
            }

            set
            {
                _supplierContactId = value;
            }
        }
        /// <summary>
        /// 需方联系人Id
        /// </summary>
        public string DemandContactId
        {
            get
            {
                return _demandContactId;
            }

            set
            {
                _demandContactId = value;
            }
        }
        /// <summary>
        /// 采购联系人Id
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
        /// 采购单位Id
        /// </summary>
        public string PurchasingunitsId
        {
            get
            {
                return _PurchasingunitsId;
            }

            set
            {
                _PurchasingunitsId = value;
            }
        }
        /// <summary>
        /// 付款申请单，单价
        /// </summary>
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
        /// <summary>
        /// 销售申请单重量
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
        /// 船名
        /// </summary>
        public string cm
        {
            get
            {
                return _cm;
            }

            set
            {
                _cm = value;
            }
        }
        /// <summary>
        /// 重量
        /// </summary>
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
        /// <summary>
        /// 桩角号
        /// </summary>
        public string zjh
        {
            get
            {
                return _zjh;
            }

            set
            {
                _zjh = value;
            }
        }
        /// <summary>
        /// 提单号
        /// </summary>
        public string tdh
        {
            get
            {
                return _tdh;
            }

            set
            {
                _tdh = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string pp
        {
            get
            {
                return _pp;
            }

            set
            {
                _pp = value;
            }
        }
        /// <summary>
        /// 提单号
        /// </summary>
        public string BillOfLadingid
        {
            get
            {
                return _BillOfLadingid;
            }

            set
            {
                _BillOfLadingid = value;
            }
        }
        /// <summary>
        /// 鱼粉
        /// </summary>
        public string Goods
        {
            get
            {
                return _Goods;
            }

            set
            {
                _Goods = value;
            }
        }
        /// <summary>
        /// 桩角号
        /// </summary>
        public string Pileangle
        {
            get
            {
                return _Pileangle;
            }

            set
            {
                _Pileangle = value;
            }
        }
        /// <summary>
        /// 船名
        /// </summary>
        public string Shipno
        {
            get
            {
                return _Shipno;
            }

            set
            {
                _Shipno = value;
            }
        }
        /// <summary>
        /// 供方简称
        /// </summary>
        public string SupplierAbbreviation
        {
            get
            {
                return _supplierAbbreviation;
            }

            set
            {
                _supplierAbbreviation = value;
            }
        }
        /// <summary>
        /// 需方简称
        /// </summary>
        public string DemandAbbreviation
        {
            get
            {
                return _demandAbbreviation;
            }

            set
            {
                _demandAbbreviation = value;
            }
        }
        /// <summary>
        /// 采购编号
        /// </summary>
        public string CNumbering
        {
            get
            {
                return _CNumbering;
            }

            set
            {
                _CNumbering = value;
            }
        }
        /// <summary>
        /// 鱼粉Id
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
        /// 自营仓库
        /// </summary>
        public bool RabZy
        {
            get
            {
                return _rabZy;
            }

            set
            {
                _rabZy = value;
            }
        }

        /// <summary>
        /// 自制仓库
        /// </summary>
        public bool RabZz
        {
            get
            {
                return _rabZz;
            }

            set
            {
                _rabZz = value;
            }
        }

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

        public string Amonut
        {
            get
            {
                return _amonut;
            }

            set
            {
                _amonut = value;
            }
        }

        public string Db
        {
            get
            {
                return _db;
            }

            set
            {
                _db = value;
            }
        }

        public string Za
        {
            get
            {
                return _za;
            }

            set
            {
                _za = value;
            }
        }

        public string Sz
        {
            get
            {
                return _sz;
            }

            set
            {
                _sz = value;
            }
        }

        public string Tvn
        {
            get
            {
                return _tvn;
            }

            set
            {
                _tvn = value;
            }
        }

        public string Hf
        {
            get
            {
                return _hf;
            }

            set
            {
                _hf = value;
            }
        }

        public string Sf
        {
            get
            {
                return _sf;
            }

            set
            {
                _sf = value;
            }
        }

        public string Shy
        {
            get
            {
                return _shy;
            }

            set
            {
                _shy = value;
            }
        }

        public string Zf
        {
            get
            {
                return _zf;
            }

            set
            {
                _zf = value;
            }
        }

        public string Unitprice
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
        /// 预付款
        /// </summary>
        public decimal MoneyYFK
        {
            get
            {
                return _moneyYFK;
            }

            set
            {
                _moneyYFK = value;
            }
        }
        /// <summary>
        /// 品质
        /// </summary>
        public string Pinzhi
        {
            get
            {
                return _pinzhi;
            }

            set
            {
                _pinzhi = value;
            }
        }
        /// <summary>
        /// 包数
        /// </summary>
        public string baoshu
        {
            get
            {
                return _baoshu;
            }

            set
            {
                _baoshu = value;
            }
        }
        /// <summary>
        /// 溢出
        /// </summary>
        public decimal? overflow
        {
            get
            {
                return _overflow;
            }

            set
            {
                _overflow = value;
            }
        }

        #endregion Model

    }
}
