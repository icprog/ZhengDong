using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    /// <summary>
    /// 
    /// </summary>
    public class InventoryAccountEntity
    {
        public InventoryAccountEntity()
		{}
		#region Model
		private int _id;
        private int _mid;
		private DateTime _accountdate;
		private int _productid;
		private decimal _remainweight;
		private int _remainquantity;
		private decimal _homemadeweight;
		private int _homemadepackages;
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
        public int mid
        {
            get { return _mid; }
            set { _mid = value; }
        }
		/// <summary>
		/// 
		/// </summary>
		public DateTime accountdate
		{
			set{ _accountdate=value;}
			get{return _accountdate;}
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
		public decimal remainweight
		{
			set{ _remainweight=value;}
			get{return _remainweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int remainquantity
		{
			set{ _remainquantity=value;}
			get{return _remainquantity;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal homemadeweight
		{
			set{ _homemadeweight=value;}
			get{return _homemadeweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int homemadepackages
		{
			set{ _homemadepackages=value;}
			get{return _homemadepackages;}
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
