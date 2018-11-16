using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public class InventoryEntity
    {
       public InventoryEntity()
		{}
		#region Model
		private int _id;
		private DateTime _accountdate;
		private int _isaccount;
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
		public DateTime accountdate
		{
			set{ _accountdate=value;}
			get{return _accountdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int isaccount
		{
			set{ _isaccount=value;}
			get{return _isaccount;}
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
