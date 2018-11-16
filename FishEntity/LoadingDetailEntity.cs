using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class LoadingDetailEntity
    {
        public LoadingDetailEntity()
		{}
		#region Model
		private int _id;
		private int _mid;
		private int _productid;
		private string _productcode;
		private string _product;
		private string _specification;
		private string _shipname;
		private string _billofgoods;
		private decimal _tons=0.000M;
		private int _packages=0;
        private decimal _unitprice = 0.000M;
		private string _remark;

        private int _contractid = 0;
        private int _contractdetailid = 0;
        private string _contractno = "";
        private int _contractseq = 0;
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
		public int mid
		{
			set{ _mid=value;}
			get{return _mid;}
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
		public string product
		{
			set{ _product=value;}
			get{return _product;}
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
		public string shipname
		{
			set{ _shipname=value;}
			get{return _shipname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string billofgoods
		{
			set{ _billofgoods=value;}
			get{return _billofgoods;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal tons
		{
			set{ _tons=value;}
			get{return _tons;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int packages
		{
			set{ _packages=value;}
			get{return _packages;}
		}
        /// <summary>
        /// 
        /// </summary>
        public decimal unitprice
        {
            get { return _unitprice; }
            set { _unitprice = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}

        public int contractid
        {
            get { return _contractid; }
            set { _contractid = value; }
        }
        public int contractdetailid
        {
            get { return _contractdetailid; }
            set { _contractdetailid = value; }
        }
        public string contractno
        {
            get { return _contractno; }
            set { _contractno = value; }
        }
        public int contractseq
        {
            get { return _contractseq; }
            set { _contractseq = value; }
        }
		#endregion Model

        private decimal _contractweight = 0;

        public decimal contractweight
        {
            get { return _contractweight; }
            set { _contractweight = value; }
        }

        private int _contractquantity = 0;

        public int contractquantity
        {
            get { return _contractquantity; }
            set { _contractquantity = value; }
        }
        private decimal _getweight = 0;

        public decimal getweight
        {
            get { return _getweight; }
            set { _getweight = value; }
        }
        private int _getquantity = 0;

        public int getquantity
        {
            get { return _getquantity; }
            set { _getquantity = value; }
        }

    }
}
