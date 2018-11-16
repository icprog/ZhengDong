using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CheckEntity
    {
        public CheckEntity()
		{}
		#region Model
		private int _id;
		private string _code;
        private DateTime _checkdate = DateTime.Now;
		private int _checkunitid;
		private string _checkunitcode;
		private string _checkunit;
		private decimal _checkfee;
		private int _productid;
		private string _productcode;
		private string _productname;
		private string _remark;
        private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
        private string _createman;
        private DateTime _createtime = DateTime.Now;
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
		public DateTime checkdate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int checkunitid
		{
			set{ _checkunitid=value;}
			get{return _checkunitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string checkunitcode
		{
			set{ _checkunitcode=value;}
			get{return _checkunitcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string checkunit
		{
			set{ _checkunit=value;}
			get{return _checkunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal checkfee
		{
			set{ _checkfee=value;}
			get{return _checkfee;}
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
		public string productname
		{
			set{ _productname=value;}
			get{return _productname;}
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
        public string modifyman
        {
            set { _modifyman = value; }
            get { return _modifyman; }
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
        public string createman
        {
            set { _createman = value; }
            get { return _createman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
		#endregion Model
    }
}
