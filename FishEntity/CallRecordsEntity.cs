using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CallRecordsEntity:CallRecordsDetailEntnty   //callrecordsdetail
    {
        public CallRecordsEntity(){}
        #region Model
		private int _id;
		private string _code;
		private DateTime? _currentdate;
		private DateTime? _nextdate;
		private string _customercode;
		private string _customer;
		private string _customerlevel;
		private string _linkmancode;
		private string _linkman;
		private string _address;
		private string _mobile;
		private string _requiredquantity;
		private string _officetel;
		private string _products;
		private string _weekestimate;
		private string _monthestimate;
		private string _communicatecontent;
		private DateTime _createtime= DateTime.Now ;
		private string _createman;
        private DateTime _modifytime = DateTime.Now;
		private string _modifyman;
		private int _isdelete=0;
        private string _telephone = string.Empty;
        private string _buyDate = string.Empty;
        private int _companyid = 0;
        private DateTime _maxcurrentdate;

        public DateTime maxcurrentdate
        {
            get { return _maxcurrentdate; }
            set { _maxcurrentdate = value; }
        }
        private DateTime _maxnextdate;

        public DateTime maxnextdate
        {
            get { return _maxnextdate; }
            set { _maxnextdate = value; }
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
		public DateTime? currentdate
		{
			set{ _currentdate=value;}
			get{return _currentdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? nextdate
		{
			set{ _nextdate=value;}
			get{return _nextdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customercode
		{
			set{ _customercode=value;}
			get{return _customercode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string customerlevel
		{
			set{ _customerlevel=value;}
			get{return _customerlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkmancode
		{
			set{ _linkmancode=value;}
			get{return _linkmancode;}
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
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string requiredquantity
		{
			set{ _requiredquantity=value;}
			get{return _requiredquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string officetel
		{
			set{ _officetel=value;}
			get{return _officetel;}
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
		public string weekestimate
		{
			set{ _weekestimate=value;}
			get{return _weekestimate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string monthestimate
		{
			set{ _monthestimate=value;}
			get{return _monthestimate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string communicatecontent
		{
			set{ _communicatecontent=value;}
			get{return _communicatecontent;}
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
		public string createman
		{
			set{ _createman=value;}
			get{return _createman;}
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
		public string modifyman
		{
			set{ _modifyman=value;}
			get{return _modifyman;}
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
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        


        private string _quoteInfo = string.Empty;

        public string quoteInfo
        {
            get { return _quoteInfo; }
            set { _quoteInfo = value; }
        }
        private string _buyInfo = string.Empty;

        public string buyInfo
        {
            get { return _buyInfo; }
            set { _buyInfo = value; }
        }
        private string _generallevel = "";

        public string generallevel
        {
            get { return _generallevel; }
            set { _generallevel = value; }
        }
        private string _cooperation = "";

        public string cooperation
        {
            get { return _cooperation; }
            set { _cooperation = value; }
        }
        private string _paymethod = "";

        public string paymethod
        {
            get { return _paymethod; }
            set { _paymethod = value; }
        }
        private string _customerproperty = "";

        public string customerproperty
        {
            get { return _customerproperty; }
            set { _customerproperty = value; }
        }
        private decimal _freight = 0;

        public decimal freight
        {
            get { return _freight; }
            set { _freight = value; }
        }
        private decimal _tare = 0;

        public decimal tare
        {
            get { return _tare; }
            set { _tare = value; }
        }
        private string _province = "";

        public string province
        {
            get { return _province; }
            set { _province = value; }
        }
        private string _zone = "";

        public string zone
        {
            get { return _zone; }
            set { _zone = value; }
        }
        private string _competitors = "";

        public string competitors
        {
            get { return _competitors; }
            set { _competitors = value; }
        }

        private string _productrequire;

        public string productrequire
        {
            get { return _productrequire; }
            set { _productrequire = value; }
        }

        private string _salesman;
        public string salesman
        {
            get { return _salesman; }
            set { _salesman = value; }
        }

        private string _salesmancode;
        public string salesmancode
        {
            get { return _salesmancode; }
            set { _salesmancode = value; }
        }


        private string _requiredproduct;
        public string requiredproduct
        {
            get { return _requiredproduct; }
            set { _requiredproduct = value; }
        }

        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }

        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        public string BuyDate
        {
            get
            {
                return _buyDate;
            }

            set
            {
                _buyDate = value;
            }
        }



        #endregion Model
    }
}
