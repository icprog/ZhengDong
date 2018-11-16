using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ContractEntity
    {
        public ContractEntity()
		{}
		#region Model
		private int _contractid;
		private int _type=1;
		private string _contractno;
		private string _signdate;
		private string _signaddress;
		private decimal _money=0M;
		private string _yifangcode;
		private string _yifang;
		private string _yiduanzhuang;
		private string _check1;
		private string _check2;
		private string _check3;
		private string _deliverytime;
		private string _address;
		private string _package;
		private string _date1;
		private string _date2;
		private string _date3;
		private string _bank;
		private string _bankaccount;
		private string _resolve;
		private string _time1;
		private string _time2;
		private string _time3;
		private string _time4;
		private string _maifangcode;
		private string _maifang;
		private string _maifangaddress;
		private string _maifangtelephone;
		private string _maifangfox;
		private string _yifangaddress;
		private string _yifangtelephone;
		private string _yifangfox;

        private int _salemanid;
        private string _saleman;

        private int _status = 0;

        private string _moneydaxie = "";
		/// <summary>
		/// auto_increment
		/// </summary>
		public int contractid
		{
			set{ _contractid=value;}
			get{return _contractid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int type
		{
			set{ _type=value;}
			get{return _type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string contractno
		{
			set{ _contractno=value;}
			get{return _contractno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string signdate
		{
			set{ _signdate=value;}
			get{return _signdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string signaddress
		{
			set{ _signaddress=value;}
			get{return _signaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal money
		{
			set{ _money=value;}
			get{return _money;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yifangcode
		{
			set{ _yifangcode=value;}
			get{return _yifangcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yifang
		{
			set{ _yifang=value;}
			get{return _yifang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yiduanzhuang
		{
			set{ _yiduanzhuang=value;}
			get{return _yiduanzhuang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string check1
		{
			set{ _check1=value;}
			get{return _check1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string check2
		{
			set{ _check2=value;}
			get{return _check2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string check3
		{
			set{ _check3=value;}
			get{return _check3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string deliverytime
		{
			set{ _deliverytime=value;}
			get{return _deliverytime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string package
		{
			set{ _package=value;}
			get{return _package;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string date1
		{
			set{ _date1=value;}
			get{return _date1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string date2
		{
			set{ _date2=value;}
			get{return _date2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string date3
		{
			set{ _date3=value;}
			get{return _date3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bank
		{
			set{ _bank=value;}
			get{return _bank;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string bankaccount
		{
			set{ _bankaccount=value;}
			get{return _bankaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string resolve
		{
			set{ _resolve=value;}
			get{return _resolve;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string time1
		{
			set{ _time1=value;}
			get{return _time1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string time2
		{
			set{ _time2=value;}
			get{return _time2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string time3
		{
			set{ _time3=value;}
			get{return _time3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string time4
		{
			set{ _time4=value;}
			get{return _time4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maifangcode
		{
			set{ _maifangcode=value;}
			get{return _maifangcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maifang
		{
			set{ _maifang=value;}
			get{return _maifang;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maifangaddress
		{
			set{ _maifangaddress=value;}
			get{return _maifangaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maifangtelephone
		{
			set{ _maifangtelephone=value;}
			get{return _maifangtelephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string maifangfox
		{
			set{ _maifangfox=value;}
			get{return _maifangfox;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yifangaddress
		{
			set{ _yifangaddress=value;}
			get{return _yifangaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yifangtelephone
		{
			set{ _yifangtelephone=value;}
			get{return _yifangtelephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string yifangfox
		{
			set{ _yifangfox=value;}
			get{return _yifangfox;}
		}

        public int salemanid
        {
            get { return _salemanid; }
            set { _salemanid = value; }
        }
        public string saleman
        {
            get { return _saleman; }
            set { _saleman = value; }
        }
        public int status
        {
            get { return _status; }
            set { _status = value; }
        }
        public string moneydaxie
        {
            get { return _moneydaxie; }
            set { _moneydaxie = value; }
        }
		#endregion Model
    }
}
