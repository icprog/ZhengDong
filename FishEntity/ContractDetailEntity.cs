using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public  class ContractDetailEntity
    {
        public ContractDetailEntity()
		{}
		#region Model
		private int _id;
		private int _contractid;
		private int _no;
		private int _productid;
		private string _productno;
		private string _productname;
		private string _specification;
		private decimal  _weight;
        private decimal _quantity;
		private decimal _unitprice;
		private decimal _money;
        private decimal _getweight=0;
        private int _getquantity=0;
        private int _isfinished = 0;
        private string _remark;
        private string _nature;
        private string _ctlremark;
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
		public int contractid
		{
			set{ _contractid=value;}
			get{return _contractid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int no
		{
			set{ _no=value;}
			get{return _no;}
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
		public string productno
		{
			set{ _productno=value;}
			get{return _productno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string productname
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specification
		{
			set{ _specification=value;}
			get{return _specification;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal  weight
		{
			set{ _weight=value;}
			get{return _weight;}
		}
        public decimal quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
		/// <summary>
		/// 
		/// </summary>
		public decimal unitprice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal money
		{
			set{ _money=value;}
			get{return _money;}
		}

        /// <summary>
        /// 
        /// </summary>
        public decimal getweight
        {
            set { _getweight = value; }
            get { return _getweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int getquantity
        {
            set { _getquantity = value; }
            get { return _getquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isfinished
        {
            set { _isfinished = value; }
            get { return _isfinished; }
        }

        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                _remark = value;
            }
        }

        public string nature
        {
            get
            {
                return _nature;
            }

            set
            {
                _nature = value;
            }
        }

        public string ctlremark
        {
            get
            {
                return _ctlremark;
            }

            set
            {
                _ctlremark = value;
            }
        }
        #endregion Model

    }
}
