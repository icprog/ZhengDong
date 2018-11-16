using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ProductEntity
    {
        public ProductEntity()
		{}
        #region Model
        private int _id;
        private string _code;
        private string _name;
        private string _brand;
        private string _state;
        private string _statename;
        private string _nature;
        private string _origin;
        private string _type;
        private DateTime? _getinfotime;
        private DateTime? _endinfotime;
        private string _techtype;
        private string _specification;
        private string _productdate;
        private int _shelflife;
        private string _quality;
        private string _manufacturers;
        private string _factoryaddress;
        private string _remark;
        private decimal? _weight = 0.000M;
        private int? _quantity = 0;
        private decimal? _remainweight = 0.000M;
        private int? _remainquantity = 0;
        private decimal? _homemadeweight = 0.000M;
        private int? _homemadepackages = 0;
        private decimal? _homemadecost = 0.000M;
        private decimal? _homemadeunitprice = 0.000M;
        private decimal? _price;
        private string  _arriveportdate;
        private string _sailingschedule;
        private string _ownercode;
        private string _ownershortname;
        private string _ownername;
        private string _billofgoods;
        private string _agentifcompany;
        private string _customsofcompany;
        private DateTime _createtime = DateTime.Now;
        private string _createman;
        private DateTime _modifytime = DateTime.Now;
        private string _modifyman;
        private int? _isdelete = 0;
        private int _supplierid = 0;
        private string _suppliercode;
        private string _supplier;
        private int _linkmanid = 0;
        private string _linkmancode;
        private string _linkman;
        private decimal _latestquote = 0.00M;
        private decimal? _quote_protein;
        private decimal? _quote_tvn;
        private decimal? _quote_graypart;
        private decimal ?_quote_sandsalt;
        private decimal?  _quote_amine;
        private decimal? _quote_ffa;
        private decimal? _quote_fat;
        private decimal? _quote_water;
        private decimal? _quote_sand;
        private decimal _sgs_protein;
        private decimal _sgs_tvn;
        private decimal _sgs_graypart;
        private decimal _sgs_sandsalt;
        private decimal  _sgs_amine;
        private decimal _sgs_ffa;
        private decimal _sgs_fat;
        private decimal _sgs_water;
        private decimal _sgs_sand;
        private decimal _label_protein;
        private decimal  _label_tvn;
        private decimal _label_graypart;
        private decimal _label_sandsalt;
        private decimal  _label_amine;
        private decimal _label_ffa;
        private decimal _label_fat;
        private decimal _labe_water;
        private decimal _label_sand;
        private decimal _label_lysine;
        private decimal _label_methionine;
        private decimal _label_aminototal;
        private decimal _domestic_protein;
        private decimal _domestic_tvn;
        private decimal _domestic_graypart;
        private decimal _domestic_sandsalt;
        private decimal _domestic_sour;
        private decimal _domestic_lysine;
        private decimal _domestic_methionine;
        private decimal _domestic_ffa;
        private decimal _domestic_sand;
        private decimal _domestic_water;
        private decimal _label_water;
        private string _port;

        private string _goodsinfo;
        private string _shipno;
        private string _cornerno;
        private decimal? _tariffrate;
        private string _samplingtime;
        private string _warehouse;
        private decimal _sgsweight;
        private int _sgsquantity;
        private decimal _domestic_amine;
        private decimal _domestic_aminototal;
        private decimal _domestic_fat;
        private decimal? _confirmrmb;

        private int? _isdelete1 = 0;
        private string _state1;

        private int? _isdelete2 = 0;
        private string _state2;

        private int? _isdelete3 = 0;
        private string _state3;

        private int? _isdelete4 = 0;
        private string _state4;

        private int? _isdelete5 = 0;
        private string _state5;
        private string _pack;

        private string _FishMealState;
        private string _shrimpshell;
        private string _chromaticberration;
        private string _smell;
        private string _blackspot;

        private int? _display;

        private string _codeNum;
        private string _codeNumContract;
        private string _supplieruser;
        private int? _quote_id;
        private string _finishedtime;
        private decimal? _shenyu;
        private decimal? _finisheWeight;
        private string _finisheNumber;
        private string _spotlife;
        private decimal? _saleremainweight;
        private string _codenum;
        private string _counhetong;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string statename
        {
            get { return _statename; }
            set { _statename = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nature
        {
            set { _nature = value; }
            get { return _nature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string origin
        {
            set { _origin = value; }
            get { return _origin; }
        }
        ///<summary>
        ///
        /// </summary>
        public string port
        {
            set { _port = value; }
            get { return _port; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? getinfotime
        {
            set { _getinfotime = value; }
            get { return _getinfotime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? endinfotime
        {
            set { _endinfotime = value; }
            get { return _endinfotime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string techtype
        {
            set { _techtype = value; }
            get { return _techtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string specification
        {
            set { _specification = value; }
            get { return _specification; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  productdate
        {
            set { _productdate = value; }
            get { return _productdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int shelflife
        {
            set { _shelflife = value; }
            get { return _shelflife; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quality
        {
            set { _quality = value; }
            get { return _quality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string manufacturers
        {
            set { _manufacturers = value; }
            get { return _manufacturers; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string factoryaddress
        {
            set { _factoryaddress = value; }
            get { return _factoryaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? remainweight
        {
            set { _remainweight = value; }
            get { return _remainweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? remainquantity
        {
            set { _remainquantity = value; }
            get { return _remainquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? homemadeweight
        {
            set { _homemadeweight = value; }
            get { return _homemadeweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? homemadepackages
        {
            set { _homemadepackages = value; }
            get { return _homemadepackages; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? homemadecost
        {
            set { _homemadecost = value; }
            get { return _homemadecost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? homemadeunitprice
        {
            set { _homemadeunitprice = value; }
            get { return _homemadeunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string  arriveportdate
        {
            set { _arriveportdate = value; }
            get { return _arriveportdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sailingschedule
        {
            set { _sailingschedule = value; }
            get { return _sailingschedule; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ownerCode
        {
            set { _ownercode = value; }
            get { return _ownercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ownershortname
        {
            set { _ownershortname = value; }
            get { return _ownershortname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ownername
        {
            set { _ownername = value; }
            get { return _ownername; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string billofgoods
        {
            set { _billofgoods = value; }
            get { return _billofgoods; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentifcompany
        {
            set { _agentifcompany = value; }
            get { return _agentifcompany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string customsofcompany
        {
            set { _customsofcompany = value; }
            get { return _customsofcompany; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createman
        {
            set { _createman = value; }
            get { return _createman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime modifytime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string modifyman
        {
            set { _modifyman = value; }
            get { return _modifyman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? isdelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int supplierid
        {
            get { return _supplierid; }
            set { _supplierid = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string suppliercode
        {
            set { _suppliercode = value; }
            get { return _suppliercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string supplier
        {
            set { _supplier = value; }
            get { return _supplier; }
        }
        public int linkmanid
        {
            get { return _linkmanid; }
            set { _linkmanid = value; }
        }
        public string linkmancode
        {
            get { return _linkmancode; }
            set { _linkmancode = value; }
        }
        public string linkman
        {
            get { return _linkman; }
            set { _linkman = value; }
        }
        /// <summary>
        /// 最近报价
        /// </summary>
        public decimal latestquote
        {
            get { return _latestquote; }
            set { _latestquote = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_protein
        {
            set { _quote_protein = value; }
            get { return _quote_protein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_tvn
        {
            set { _quote_tvn = value; }
            get { return _quote_tvn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_graypart
        {
            set { _quote_graypart = value; }
            get { return _quote_graypart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_sandsalt
        {
            set { _quote_sandsalt = value; }
            get { return _quote_sandsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal?  quote_amine
        {
            set { _quote_amine = value; }
            get { return _quote_amine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_ffa
        {
            set { _quote_ffa = value; }
            get { return _quote_ffa; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_fat
        {
            set { _quote_fat = value; }
            get { return _quote_fat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_water
        {
            set { _quote_water = value; }
            get { return _quote_water; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quote_sand
        {
            set { _quote_sand = value; }
            get { return _quote_sand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_protein
        {
            set { _sgs_protein = value; }
            get { return _sgs_protein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_tvn
        {
            set { _sgs_tvn = value; }
            get { return _sgs_tvn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_graypart
        {
            set { _sgs_graypart = value; }
            get { return _sgs_graypart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_sandsalt
        {
            set { _sgs_sandsalt = value; }
            get { return _sgs_sandsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  sgs_amine
        {
            set { _sgs_amine = value; }
            get { return _sgs_amine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_ffa
        {
            set { _sgs_ffa = value; }
            get { return _sgs_ffa; }
        }

        public decimal sgs_fat
        {
            get { return _sgs_fat; }
            set { _sgs_fat = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_water
        {
            set { _sgs_water = value; }
            get { return _sgs_water; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgs_sand
        {
            set { _sgs_sand = value; }
            get { return _sgs_sand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_protein
        {
            set { _label_protein = value; }
            get { return _label_protein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_tvn
        {
            set { _label_tvn = value; }
            get { return _label_tvn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_graypart
        {
            set { _label_graypart = value; }
            get { return _label_graypart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_sandsalt
        {
            set { _label_sandsalt = value; }
            get { return _label_sandsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  label_amine
        {
            set { _label_amine = value; }
            get { return _label_amine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_ffa
        {
            set { _label_ffa = value; }
            get { return _label_ffa; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_fat
        {
            set { _label_fat = value; }
            get { return _label_fat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal labe_water
        {
            set { _labe_water = value; }
            get { return _labe_water; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_sand
        {
            set { _label_sand = value; }
            get { return _label_sand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_lysine
        {
            set { _label_lysine = value; }
            get { return _label_lysine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal label_methionine
        {
            set { _label_methionine = value; }
            get { return _label_methionine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_protein
        {
            set { _domestic_protein = value; }
            get { return _domestic_protein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  domestic_tvn
        {
            set { _domestic_tvn = value; }
            get { return _domestic_tvn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_graypart
        {
            set { _domestic_graypart = value; }
            get { return _domestic_graypart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_sandsalt
        {
            set { _domestic_sandsalt = value; }
            get { return _domestic_sandsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_sour
        {
            set { _domestic_sour = value; }
            get { return _domestic_sour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_lysine
        {
            set { _domestic_lysine = value; }
            get { return _domestic_lysine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_methionine
        {
            set { _domestic_methionine = value; }
            get { return _domestic_methionine; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string goodsinfo
        {
            set { _goodsinfo = value; }
            get { return _goodsinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string shipno
        {
            set { _shipno = value; }
            get { return _shipno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cornerno
        {
            set { _cornerno = value; }
            get { return _cornerno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tariffrate
        {
            set { _tariffrate = value; }
            get { return _tariffrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string samplingtime
        {
            set { _samplingtime = value; }
            get { return _samplingtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string warehouse
        {
            set { _warehouse = value; }
            get { return _warehouse; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal sgsweight
        {
            set { _sgsweight = value; }
            get { return _sgsweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int sgsquantity
        {
            set { _sgsquantity = value; }
            get { return _sgsquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_amine
        {
            set { _domestic_amine = value; }
            get { return _domestic_amine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_aminototal
        {
            set { _domestic_aminototal = value; }
            get { return _domestic_aminototal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_fat
        {
            set { _domestic_fat = value; }
            get { return _domestic_fat; }
        }

        public int? Isdelete1
        {
            get
            {
                return _isdelete1;
            }

            set
            {
                _isdelete1 = value;
            }
        }


        public int? Isdelete2
        {
            get
            {
                return _isdelete2;
            }

            set
            {
                _isdelete2 = value;
            }
        }


        public int? Isdelete3
        {
            get
            {
                return _isdelete3;
            }

            set
            {
                _isdelete3 = value;
            }
        }


        public int? Isdelete4
        {
            get
            {
                return _isdelete4;
            }

            set
            {
                _isdelete4 = value;
            }
        }


        public int? Isdelete5
        {
            get
            {
                return _isdelete5;
            }

            set
            {
                _isdelete5 = value;
            }
        }

        public string State1
        {
            get
            {
                return _state1;
            }

            set
            {
                _state1 = value;
            }
        }

        public string State2
        {
            get
            {
                return _state2;
            }

            set
            {
                _state2 = value;
            }
        }

        public string State3
        {
            get
            {
                return _state3;
            }

            set
            {
                _state3 = value;
            }
        }

        public string State4
        {
            get
            {
                return _state4;
            }

            set
            {
                _state4 = value;
            }
        }

        public string State5
        {
            get
            {
                return _state5;
            }

            set
            {
                _state5 = value;
            }
        }

        public string Pack
        {
            get
            {
                return _pack;
            }

            set
            {
                _pack = value;
            }
        }
        /// <summary>
        /// 标签氨基酸总和
        /// </summary>
        public decimal label_aminototal
        {
            get
            {
                return _label_aminototal;
            }

            set
            {
                _label_aminototal = value;
            }
        }
        /// <summary>
        /// 国检FFA
        /// </summary>
        public decimal domestic_ffa
        {
            get
            {
                return _domestic_ffa;
            }

            set
            {
                _domestic_ffa = value;
            }
        }
        /// <summary>
        /// 国检沙
        /// </summary>
        public decimal domestic_sand
        {
            get
            {
                return _domestic_sand;
            }

            set
            {
                _domestic_sand = value;
            }
        }
        /// <summary>
        /// 国检水分
        /// </summary>
        public decimal domestic_water
        {
            get
            {
                return _domestic_water;
            }

            set
            {
                _domestic_water = value;
            }
        }
        /// <summary>
        /// 鱼粉状态
        /// </summary>
        public string FishMealState
        {
            get
            {
                return _FishMealState;
            }

            set
            {
                _FishMealState = value;
            }
        }
        /// <summary>
        /// 虾壳
        /// </summary>
        public string shrimpshell
        {
            get
            {
                return _shrimpshell;
            }

            set
            {
                _shrimpshell = value;
            }
        }
        /// <summary>
        /// 色差
        /// </summary>
        public string chromaticberration
        {
            get
            {
                return _chromaticberration;
            }

            set
            {
                _chromaticberration = value;
            }
        }
        /// <summary>
        /// 气味
        /// </summary>
        public string smell
        {
            get
            {
                return _smell;
            }

            set
            {
                _smell = value;
            }
        }
        /// <summary>
        /// 黑点
        /// </summary>
        public string blackspot
        {
            get
            {
                return _blackspot;
            }

            set
            {
                _blackspot = value;
            }
        }

        public int? Display
        {
            get
            {
                return _display;
            }

            set
            {
                _display = value;
            }
        }
        /// <summary>
        /// 采购编号
        /// </summary>
        public string codeNum
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
        public string codeNumContract
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
        /// 供方联系人
        /// </summary>
        public string Supplieruser
        {
            get
            {
                return _supplieruser;
            }

            set
            {
                _supplieruser = value;
            }
        }

        public decimal? confirmrmb
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

        public int? Quote_id
        {
            get
            {
                return _quote_id;
            }

            set
            {
                _quote_id = value;
            }
        }

        public string finishedtime
        {
            get
            {
                return _finishedtime;
            }

            set
            {
                _finishedtime = value;
            }
        }

        public decimal? finisheWeight
        {
            get
            {
                return _finisheWeight;
            }

            set
            {
                _finisheWeight = value;
            }
        }

        public string finisheNumber
        {
            get
            {
                return _finisheNumber;
            }

            set
            {
                _finisheNumber = value;
            }
        }

        public string spotlife
        {
            get
            {
                return _spotlife;
            }

            set
            {
                _spotlife = value;
            }
        }

        public decimal label_water
        {
            get
            {
                return _label_water;
            }

            set
            {
                _label_water = value;
            }
        }

        public decimal? saleremainweight
        {
            get
            {
                return _saleremainweight;
            }

            set
            {
                _saleremainweight = value;
            }
        }

        public string codenum
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

        public string counhetong
        {
            get
            {
                return _counhetong;
            }

            set
            {
                _counhetong = value;
            }
        }

        public decimal? shenyu
        {
            get
            {
                return _shenyu;
            }

            set
            {
                _shenyu = value;
            }
        }




        #endregion Model


        //public string year
        //{
        //    get
        //    {
        //        if (_productdate != null)
        //        {
        //              return _productdate.Value.Year.ToString();
        //        }
        //        return string.Empty;
        //    }
        //}
    }
}
