using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CompanyEntity
    {
        public CompanyEntity()
		{}
		private int _id;
		private string _code;
		private string _type;
		private string _fullname;
		private string _shortname;
		private string _generallevel;
		private string _creditlevel;
		private string _requiredlevel;
		private string _managestandard;
		private string _activelevel;
		private string _loyalty;
		private string _products;
		private string _salesmancode;
		private string _salesman;
		private string _area;
		private string _address;
		private string _nature;
		private string _manageprojects;
		private string _registermoney;
		private DateTime? _registertime= DateTime.Now;
		private int _personnumber=1;
		private string _zipcode;
		private string _fox;
		private string _website;
        private string _linkmancode;
		private string _linkman;
		private string _currentlink;
		private string _currentweekestimate;
		private string _currentmonthestimate;
		private DateTime? _nextlinkdate;
		private string _description;
		private int? _validate=1;
		private string _modifyman;
		private DateTime _modifytime=DateTime.Now;
		private string _createman;
		private DateTime _createtime= DateTime .Now;
		private int _isdelete=0;
		private int? _fatures=0;
		private string _bank;
		private string _account;
		private string _threecard;
		private string _type_customer;
		private string _type_suppliers;
		private string _type_quote;
		private string _type_merchants;
		private string _type_goods;
		private string _type_agents;
		private string _estimatepurchasetime;
		private string _customerproperty;
		private string _customergroup;
        private string _cashdeposit;
        private string _paymethod;
        private string _competitors;
        private string _requiredproduct;

        private string _registerman;
        private string _cooperation;
        private string _province;
        private string _zone;
        private string _productrequire;
        private decimal _freight = 0.00M;
        private decimal _tare = 0.00M;

        private string _yearsale;
        private string _productgoods;
        private string _yearproduct;
        private string _supportproduct;
        private string _yearsupport;
        private string _cashdate;
        private string _cashmethod;
        private string _agentfeerate;
        private string _issuingfeerate;
        private int _billperiod;
        private string _passfeerate;
        private decimal? _storagefee1;
        private decimal? _storagefee2;
        private decimal? _storagefee3;
        private decimal? _storagefee4;
        private decimal? _storagefee5;
        private decimal? _freight1;
        private decimal? _freight2;
        private decimal? _freight3;
        private decimal? _freight4;
        private decimal? _freight5;
        private decimal? _freight6;
        private string _storageday1;
        private string _storageday2;
        private string _storageday3;
        private string _storageday4;
        private string _storageday5;
        private int? _paydays;
        private string _requiregoods;

        private string _Fishmaterial;
        private string _Shrimpmaterial;
        private string _Poultrymaterial;
        private string _Special;
        private string _Specialwater;
        private string _Logistics;
        public string cashdeposit
        {
            get { return _cashdeposit; }
            set { _cashdeposit = value; }
        }
        public string paymethod
        {
            get { return _paymethod; }
            set { _paymethod = value; }
        }
        public string competitors
        {
            get { return _competitors; }
            set { _competitors = value; }
        }
        public string requiredproduct
        {
            get { return _requiredproduct; }
            set { _requiredproduct = value; }
        }
        
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fullname
		{
			set{ _fullname=value;}
			get{return _fullname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string shortname
		{
			set{ _shortname=value;}
			get{return _shortname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string generallevel
		{
			set{ _generallevel=value;}
			get{return _generallevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string creditlevel
		{
			set{ _creditlevel=value;}
			get{return _creditlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string requiredlevel
		{
			set{ _requiredlevel=value;}
			get{return _requiredlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string managestandard
		{
			set{ _managestandard=value;}
			get{return _managestandard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string activelevel
		{
			set{ _activelevel=value;}
			get{return _activelevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string loyalty
		{
			set{ _loyalty=value;}
			get{return _loyalty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string products
		{
			set{ _products=value;}
			get{return _products;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string salesmancode
		{
			set{ _salesmancode=value;}
			get{return _salesmancode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string salesman
		{
			set{ _salesman=value;}
			get{return _salesman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string area
		{
			set{ _area=value;}
			get{return _area;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string nature
		{
			set{ _nature=value;}
			get{return _nature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string manageprojects
		{
			set{ _manageprojects=value;}
			get{return _manageprojects;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string registermoney
		{
			set{ _registermoney=value;}
			get{return _registermoney;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? registertime
		{
			set{ _registertime=value;}
			get{return _registertime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int personnumber
		{
			set{ _personnumber=value;}
			get{return _personnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string zipcode
		{
			set{ _zipcode=value;}
			get{return _zipcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fox
		{
			set{ _fox=value;}
			get{return _fox;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string website
		{
			set{ _website=value;}
			get{return _website;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string linkmancode
        {
            set { _linkmancode = value; }
            get { return _linkmancode; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string linkman
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string currentlink
		{
			set{ _currentlink=value;}
			get{return _currentlink;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string currentweekestimate
		{
			set{ _currentweekestimate=value;}
			get{return _currentweekestimate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string currentmonthestimate
		{
			set{ _currentmonthestimate=value;}
			get{return _currentmonthestimate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? nextlinkdate
		{
			set{ _nextlinkdate=value;}
			get{return _nextlinkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? validate
		{
			set{ _validate=value;}
			get{return _validate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string modifyman
		{
			set{ _modifyman=value;}
			get{return _modifyman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime modifytime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string createman
		{
			set{ _createman=value;}
			get{return _createman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? fatures
		{
			set{ _fatures=value;}
			get{return _fatures;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bank
		{
			set{ _bank=value;}
			get{return _bank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string account
		{
			set{ _account=value;}
			get{return _account;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string threecard
		{
			set{ _threecard=value;}
			get{return _threecard;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_customer
		{
			set{ _type_customer=value;}
			get{return _type_customer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_suppliers
		{
			set{ _type_suppliers=value;}
			get{return _type_suppliers;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_quote
		{
			set{ _type_quote=value;}
			get{return _type_quote;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_merchants
		{
			set{ _type_merchants=value;}
			get{return _type_merchants;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_goods
		{
			set{ _type_goods=value;}
			get{return _type_goods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string type_agents
		{
			set{ _type_agents=value;}
			get{return _type_agents;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string estimatepurchasetime
		{
			set{ _estimatepurchasetime=value;}
			get{return _estimatepurchasetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customerproperty
		{
			set{ _customerproperty=value;}
			get{return _customerproperty;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customergroup
		{
			set{ _customergroup=value;}
			get{return _customergroup;}
		}

        // <summary>
        /// 
        /// </summary>
        public string registerman
        {
            set { _registerman = value; }
            get { return _registerman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cooperation
        {
            set { _cooperation = value; }
            get { return _cooperation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zone
        {
            set { _zone = value; }
            get { return _zone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productrequire
        {
            set { _productrequire = value; }
            get { return _productrequire; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal freight
        {
            set { _freight = value; }
            get { return _freight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal tare
        {
            set { _tare = value; }
            get { return _tare; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string yearSale
        {
            set { _yearsale = value; }
            get { return _yearsale; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productgoods
        {
            set { _productgoods = value; }
            get { return _productgoods; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yearproduct
        {
            set { _yearproduct = value; }
            get { return _yearproduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string supportproduct
        {
            set { _supportproduct = value; }
            get { return _supportproduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yearsupport
        {
            set { _yearsupport = value; }
            get { return _yearsupport; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cashdate
        {
            set { _cashdate = value; }
            get { return _cashdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string cashmethod
        {
            set { _cashmethod = value; }
            get { return _cashmethod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agentfeerate
        {
            set { _agentfeerate = value; }
            get { return _agentfeerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string issuingfeerate
        {
            set { _issuingfeerate = value; }
            get { return _issuingfeerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int billperiod
        {
            set { _billperiod = value; }
            get { return _billperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string passfeerate
        {
            set { _passfeerate = value; }
            get { return _passfeerate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? storagefee1
        {
            set { _storagefee1 = value; }
            get { return _storagefee1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? storagefee2
        {
            set { _storagefee2 = value; }
            get { return _storagefee2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? storagefee3
        {
            set { _storagefee3 = value; }
            get { return _storagefee3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? storagefee4
        {
            set { _storagefee4 = value; }
            get { return _storagefee4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? storagefee5
        {
            set { _storagefee5 = value; }
            get { return _storagefee5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freight1
        {
            set { _freight1 = value; }
            get { return _freight1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freight2
        {
            set { _freight2 = value; }
            get { return _freight2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freight3
        {
            set { _freight3 = value; }
            get { return _freight3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freight4
        {
            set { _freight4 = value; }
            get { return _freight4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freight5
        {
            set { _freight5 = value; }
            get { return _freight5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? freight6
        {
            set { _freight6 = value; }
            get { return _freight6; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string storageday1
        {
            set { _storageday1 = value; }
            get { return _storageday1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storageday2
        {
            set { _storageday2 = value; }
            get { return _storageday2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storageday3
        {
            set { _storageday3 = value; }
            get { return _storageday3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storageday4
        {
            set { _storageday4 = value; }
            get { return _storageday4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storageday5
        {
            set { _storageday5 = value; }
            get { return _storageday5; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? paydays
        {
            set { _paydays = value; }
            get { return _paydays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string requiregoods
        {
            set { _requiregoods = value; }
            get { return _requiregoods; }
        }

        public string Fishmaterial
        {
            get
            {
                return _Fishmaterial;
            }

            set
            {
                _Fishmaterial = value;
            }
        }

        public string Shrimpmaterial
        {
            get
            {
                return _Shrimpmaterial;
            }

            set
            {
                _Shrimpmaterial = value;
            }
        }

        public string Poultrymaterial
        {
            get
            {
                return _Poultrymaterial;
            }

            set
            {
                _Poultrymaterial = value;
            }
        }

        public string Special
        {
            get
            {
                return _Special;
            }

            set
            {
                _Special = value;
            }
        }

        public string Specialwater
        {
            get
            {
                return _Specialwater;
            }

            set
            {
                _Specialwater = value;
            }
        }
        /// <summary>
        /// 运输物流
        /// </summary>
        public string Logistics
        {
            get
            {
                return _Logistics;
            }

            set
            {
                _Logistics = value;
            }
        }
    }
}
