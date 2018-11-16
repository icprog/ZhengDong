using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
     public class QuoteEntity
    {
         public QuoteEntity()
		{}
		#region Model
		private int _id;
        private int _no = 1;
		private int _companyid;
        private string _companycode;
        private string _company;
		private int _customerid;
        private string _customercode;
        private string _customer;
		private int _productid;
		private decimal _quotedollars=0.000M;
        private decimal _quotermb = 0;
        private decimal _rate;
        private decimal _weight = 0;
        private int _quantity = 0;
		private DateTime? _quotedate;
		private DateTime? _quotetime;
		private string _quoteman;
		private string _createman;
        private DateTime _createtime = DateTime.Now;
		private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
		private int _isdelete=0;

        private int _Counter_offer_companyid;
        private string _Counter_offer_companycode;
        private int _Counter_offer_customerid;
        private string _Counter_offer_customercode;
        private DateTime? _Counter_offer_date;
        private DateTime? _Counter_offer_time;
        private string _Counter_offer_Company;
        private string _Counter_offer_Contacts;
        private decimal _Counter_offer_weight=0;
        private string _Counter_offer_Number;
        private decimal _Counter_offer_HuiLv;
        private decimal _Counter_offer_Dollar = 0;
        private decimal _Counter_offer_RMB;


        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
        public int no
        {
            get { return _no; }
            set { _no = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public int companyid
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int customerid
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int productid
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal quotedollars
		{
			set{ _quotedollars=value;}
			get{return _quotedollars;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? quotedate
		{
			set{ _quotedate=value;}
			get{return _quotedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? quotetime
		{
			set{ _quotetime=value;}
			get{return _quotetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string quoteman
		{
			set{ _quoteman=value;}
			get{return _quoteman;}
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
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
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
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
         /// <summary>
         /// 
         /// </summary>
        public string companycode
        {
            get { return _companycode; }
            set { _companycode = value; }
        }
         /// <summary>
         /// 
         /// </summary>
        public string customercode
        {
            get { return _customercode; }
            set { _customercode = value; }
        }

        public string customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public string company
        {
            get { return _company; }
            set { _company = value; }
        }

        public decimal weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal quotermb
        {
            get { return _quotermb; }
            set { _quotermb = value; }
        }

        public decimal rate
        {
            get { return _rate; }
            set { _rate = value; }
        }
        /// <summary>
        /// 还盘人民币
        /// </summary>
        public decimal Counter_offer_RMB
        {
            get
            {
                return _Counter_offer_RMB;
            }

            set
            {
                _Counter_offer_RMB = value;
            }
        }
        /// <summary>
        /// 还盘美金
        /// </summary>
        public decimal Counter_offer_Dollar
        {
            get
            {
                return _Counter_offer_Dollar;
            }

            set
            {
                _Counter_offer_Dollar = value;
            }
        }
        /// <summary>
        /// 还盘汇率
        /// </summary>
        public decimal Counter_offer_HuiLv
        {
            get
            {
                return _Counter_offer_HuiLv;
            }

            set
            {
                _Counter_offer_HuiLv = value;
            }
        }
        /// <summary>
        /// 还盘数量
        /// </summary>
        public string Counter_offer_Number
        {
            get
            {
                return _Counter_offer_Number;
            }

            set
            {
                _Counter_offer_Number = value;
            }
        }
        /// <summary>
        /// 还盘重量
        /// </summary>
        public decimal Counter_offer_weight
        {
            get
            {
                return _Counter_offer_weight;
            }

            set
            {
                _Counter_offer_weight = value;
            }
        }
        /// <summary>
        /// 还盘联系人
        /// </summary>
        public string Counter_offer_Contacts
        {
            get
            {
                return _Counter_offer_Contacts;
            }

            set
            {
                _Counter_offer_Contacts = value;
            }
        }
        /// <summary>
        /// 还盘单位
        /// </summary>
        public string Counter_offer_Company
        {
            get
            {
                return _Counter_offer_Company;
            }

            set
            {
                _Counter_offer_Company = value;
            }
        }
        /// <summary>
        /// 还盘时间
        /// </summary>
        public DateTime? Counter_offer_time
        {
            get
            {
                return _Counter_offer_time;
            }

            set
            {
                _Counter_offer_time = value;
            }
        }
        /// <summary>
        /// 还盘日期
        /// </summary>
        public DateTime? Counter_offer_date
        {
            get
            {
                return _Counter_offer_date;
            }

            set
            {
                _Counter_offer_date = value;
            }
        }

        public string Counter_offer_customercode
        {
            get
            {
                return _Counter_offer_customercode;
            }

            set
            {
                _Counter_offer_customercode = value;
            }
        }

        public int Counter_offer_customerid
        {
            get
            {
                return _Counter_offer_customerid;
            }

            set
            {
                _Counter_offer_customerid = value;
            }
        }

        public string Counter_offer_companycode
        {
            get
            {
                return _Counter_offer_companycode;
            }

            set
            {
                _Counter_offer_companycode = value;
            }
        }

        public int Counter_offer_companyid
        {
            get
            {
                return _Counter_offer_companyid;
            }

            set
            {
                _Counter_offer_companyid = value;
            }
        }

        #endregion Model

    }
}
