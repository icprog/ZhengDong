using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public  class CustomerEntity
    {
        public CustomerEntity()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _name;
		private DateTime?  _currentlinkdate=DateTime.Now;
		private string _telephone;
		private string _phone1;
		private string _phone2;
		private string _phone3;
		private string _post;
		private string _department;
		private string _email;
		private string _qq;
		private string _weixin;
		private DateTime? _nextlinkdate;
        private int _nextcallrecordid = 0;
		private int _validate=1;
		private string _remark;
		private string _company;
		private DateTime _createtime=DateTime.Now;
		private string _createman;
		private DateTime _modifytime=DateTime.Now;
		private string _modifyman;
		private int _isdelete=0;
        private int _flag = 0;
        private string _homeaddress;
        private string _officeaddress;
        private string _sex = "男";
        private string _fox = "";
        private string _department1;

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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? currentlinkDate
		{
			set{ _currentlinkdate=value;}
			get{return _currentlinkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone1
		{
			set{ _phone1=value;}
			get{return _phone1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone2
		{
			set{ _phone2=value;}
			get{return _phone2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string phone3
		{
			set{ _phone3=value;}
			get{return _phone3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string post
		{
			set{ _post=value;}
			get{return _post;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string department
		{
			set{ _department=value;}
			get{return _department;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string qq
		{
			set{ _qq=value;}
			get{return _qq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string weixin
		{
			set{ _weixin=value;}
			get{return _weixin;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime?  nextlinkdate
		{
			set{ _nextlinkdate=value;}
			get{return _nextlinkdate;}
		}
        public int nextcallrecordid
		{
			set{ _nextcallrecordid=value;}
			get{return _nextcallrecordid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int validate
		{
			set{ _validate=value;}
			get{return _validate;}
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
		public string company
		{
			set{ _company=value;}
			get{return _company;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime  createtime
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
		public DateTime  modifytime
		{
			set{ _modifytime=value;}
			get{return _modifytime;}
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
		public int isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}

        public int flag
        {
            get { return _flag; }
            set { _flag = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string homeaddress
        {
            set { _homeaddress = value; }
            get { return _homeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string officeaddress
        {
            set { _officeaddress = value; }
            get { return _officeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }

        public string fox
        {
            get { return _fox; }
            set { _fox = value; }
        }
        public string Department1
        {
            get
            {
                return _department1;
            }

            set
            {
                _department1 = value;
            }
        }

        #endregion Model

        #region ExtensionModel

        private int _companyId;
        public int companyId { get { return _companyId; } set { _companyId = value; } }

     


        #endregion ExtensionModel
    }
}
