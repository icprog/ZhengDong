using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class LoadingBillsEntity
    {     
        public LoadingBillsEntity()
		{}
		#region Model
		private int _id;
		private string _code;
		private DateTime? _signdate;
		private int? _billmanid;
		private string _billman;
		private int? _companyid;
		private string _companycode;
		private string _company;
		private string _warehouse;
		private decimal? _storagefee=0.000M;
		private string _createman;
		private DateTime _createtime= DateTime.Now;
		private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
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
		public DateTime? signdate
		{
			set{ _signdate=value;}
			get{return _signdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? billmanid
		{
			set{ _billmanid=value;}
			get{return _billmanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string billman
		{
			set{ _billman=value;}
			get{return _billman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? companyid
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
		public string warehouse
		{
			set{ _warehouse=value;}
			get{return _warehouse;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? storagefee
		{
			set{ _storagefee=value;}
			get{return _storagefee;}
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
		#endregion Model
    }
}
