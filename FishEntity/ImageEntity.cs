using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ImageEntity
    {
        public ImageEntity()
		{}
		#region Model
		private int _id;
		private int? _recordid;
		private string _title;
		private int? _type;
		private string _extension;
		private byte[] _image;
        private int _sort;
		private string _remark;
		private string _createman;
		private DateTime? _createtime;
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
		public int? recordid
		{
			set{ _recordid=value;}
			get{return _recordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string extension
		{
			set{ _extension=value;}
			get{return _extension;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] image
		{
			set{ _image=value;}
			get{return _image;}
		}
        /// <summary>
        /// 
        /// </summary>
        public int sort
        {
            get{return _sort;}
            set{_sort=value;}
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
		public DateTime? createtime
		{
			set{ _createtime=value;}
			get{return _createtime;}
		}
		#endregion Model
    }
}
