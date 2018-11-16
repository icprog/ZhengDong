using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class SpotEntity
    {
        public SpotEntity()
		{}
		#region Model
		private int _id;
		private int _no=1;
		private int _companyid;
		private string _companycode;
		private string _company;
		private int _customerid;
		private string _customercode;
		private string _customer;
		private int _productid;
		private decimal _dollars=0.000M;
		private decimal _rate=0.000M;
		private decimal _rmb=0.000M;
		private decimal _weight;
		private int _quantity;
		private DateTime _spotdate;
		private DateTime _spottime;
		private string _spotman;
		private string _createman;
        private DateTime _createtime = DateTime.Now;
		private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
		private int _isdelete=0;
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
		public int no
		{
			set{ _no=value;}
			get{return _no;}
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
		public string companycode
		{
			set{ _companycode=value;}
			get{return _companycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string company
		{
			set{ _company=value;}
			get{return _company;}
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
		public int productid
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal dollars
		{
			set{ _dollars=value;}
			get{return _dollars;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal rate
		{
			set{ _rate=value;}
			get{return _rate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal rmb
		{
			set{ _rmb=value;}
			get{return _rmb;}
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
		public int quantity
		{
			set{ _quantity=value;}
			get{return _quantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime spotdate
		{
			set{ _spotdate=value;}
			get{return _spotdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime spottime
		{
			set{ _spottime=value;}
			get{return _spottime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string spotman
		{
			set{ _spotman=value;}
			get{return _spotman;}
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
		#endregion Model
    }
}
