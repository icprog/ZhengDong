using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class StorageBillsEntity
    {
        public StorageBillsEntity()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _operatecode;
		private int? _delegateunitid;
		private string _delegateunitcode;
		private string _delegateunit;
		private string _deliverybills;
		private int? _productid;
		private string _productcode;
		private string _productname;
		private DateTime? _unboxdate;
		private string _place;
		private decimal? _tons=0.000M;
		private int? _number=0;
		private int? _actualnumber=0;
		private string _remark;
		private string _location;
		private DateTime _createtime= DateTime.Now;
		private string _createman;
		private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
		private int _isdelete=0;
        private string _shipno = string.Empty;
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
		public string operatecode
		{
			set{ _operatecode=value;}
			get{return _operatecode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? delegateunitid
		{
			set{ _delegateunitid=value;}
			get{return _delegateunitid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string delegateunitcode
		{
			set{ _delegateunitcode=value;}
			get{return _delegateunitcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string delegateunit
		{
			set{ _delegateunit=value;}
			get{return _delegateunit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deliverybills
		{
			set{ _deliverybills=value;}
			get{return _deliverybills;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? productid
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
		public DateTime? unboxdate
		{
			set{ _unboxdate=value;}
			get{return _unboxdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string place
		{
			set{ _place=value;}
			get{return _place;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tons
		{
			set{ _tons=value;}
			get{return _tons;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? number
		{
			set{ _number=value;}
			get{return _number;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? actualnumber
		{
			set{ _actualnumber=value;}
			get{return _actualnumber;}
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
		public string location
		{
			set{ _location=value;}
			get{return _location;}
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
        public string shipno
        {
            get { return _shipno; }
            set { _shipno = value; }
        }
		#endregion Model

	
    }
}
