using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class StorageRecordEntity
    {
        public StorageRecordEntity()
		{}
		#region Model
		private int _id;
		private string _type;
        private int? _fid;
		private int? _productid;
		private decimal? _price;
		private string _remark;
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
		public string type
		{
			set{ _type=value;}
			get{return _type;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int? fid
        {
            set { _fid = value; }
            get { return _fid; }
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
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model
    }
}
