using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class FoodOutEntity
    {
        public FoodOutEntity()
		{}
        #region Model
        private string _Quality;
        private string _Brand;
        private int _id;
		private string _code;
		private DateTime? _productdate;
		private DateTime? _outdate;
		private int _productid;
		private string _productcode;
		private string _productlabel;
		private decimal _weight=0.00M;
		private int _package=0;
        private decimal _cost = 0;
		private string _remark;
		private string _createman;
		private DateTime _createtime= DateTime.Now;
		private string _modifyman;
        private DateTime _modifytime = DateTime.Now;

        private int _solutionid = 0;
        private int _deliverymanid = 0;
        private string _deliveryman;
        private int _salemanid = 0;
        private string _saleman;
        private DateTime _indate;
        private int _companyid;
        private string _companycode;
        private string _companyname;

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
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? productdate
		{
			set{ _productdate=value;}
			get{return _productdate;}
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? outdate
		{
			set{ _outdate=value;}
			get{return _outdate;}
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
		public string productcode
		{
			set{ _productcode=value;}
			get{return _productcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string productlabel
		{
			set{ _productlabel=value;}
			get{return _productlabel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int package
		{
			set{ _package=value;}
			get{return _package;}
		}
        /// <summary>
        /// 
        /// </summary>
        public decimal cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
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
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime modifytime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
		}

        public int solutionid
        {
            get { return _solutionid; }
            set { _solutionid = value; }
        }
        public int deliverymanid
        {
            get { return _deliverymanid; }
            set { _deliverymanid = value; }
        }
        public string deliveryman
        {
            get { return _deliveryman; }
            set { _deliveryman = value; }
        }
        public int salemanid
        {
            get { return _salemanid; }
            set { _salemanid = value; }
        }
        public string saleman
        {
            get { return _saleman; }
            set { _saleman = value; }
        }
        public DateTime indate
        {
            get { return _indate; }
            set { _indate = value; }
        }

        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        public string companycode
        {
            get { return _companycode; }
            set { _companycode = value; }
        }
        public string companyname
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        public string Quality
        {
            get
            {
                return _Quality;
            }

            set
            {
                _Quality = value;
            }
        }

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


        #endregion Model

    }
}
