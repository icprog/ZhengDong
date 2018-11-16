using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CallRecordsDetailEntnty
    {
        public CallRecordsDetailEntnty()
		{}
		#region Model
		private int _id;
		private int _callrecordid;
		private int _no=1;
		private string _nature;
		private string _brand;
		private string _specification;
        private string _orderstate;
		private decimal _quoteprice;
		private decimal _weight;
		private decimal _saleprice;
		private string _paymethod;
		private string _payperiod;
		private decimal _domestic_protein=0.00M;
		private decimal _domestic_tvn;
		private decimal _domestic_graypart;
		private decimal _domestic_sandsalt;
		private decimal _domestic_sour;
		private decimal _domestic_lysine;
		private decimal _domestic_amine;
		private decimal _domestic_aminototal;
		private decimal _domestic_methionine;
		private decimal _domestic_fat;
        private string _customer;
        private DateTime _currentdate;
        private string _createman;

        public DateTime currentdate
        {
            get { return _currentdate; }
            set { _currentdate = value; }
        }
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
		public int callrecordid
		{
			set{ _callrecordid=value;}
			get{return _callrecordid;}
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
		public string nature
		{
			set{ _nature=value;}
			get{return _nature;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string brand
		{
			set{ _brand=value;}
			get{return _brand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specification
		{
			set{ _specification=value;}
			get{return _specification;}
		}
		/// <summary>
		/// 
		/// </summary>
        public string orderstate
		{
            set { _orderstate = value; }
            get { return _orderstate; }
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal quoteprice
		{
			set{ _quoteprice=value;}
			get{return _quoteprice;}
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
		public decimal saleprice
		{
			set{ _saleprice=value;}
			get{return _saleprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string paymethod
		{
			set{ _paymethod=value;}
			get{return _paymethod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string payperiod
		{
			set{ _payperiod=value;}
			get{return _payperiod;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_protein
		{
			set{ _domestic_protein=value;}
			get{return _domestic_protein;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_tvn
		{
			set{ _domestic_tvn=value;}
			get{return _domestic_tvn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_graypart
		{
			set{ _domestic_graypart=value;}
			get{return _domestic_graypart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_sandsalt
		{
			set{ _domestic_sandsalt=value;}
			get{return _domestic_sandsalt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_sour
		{
			set{ _domestic_sour=value;}
			get{return _domestic_sour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_lysine
		{
			set{ _domestic_lysine=value;}
			get{return _domestic_lysine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_amine
		{
			set{ _domestic_amine=value;}
			get{return _domestic_amine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_aminototal
		{
			set{ _domestic_aminototal=value;}
			get{return _domestic_aminototal;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_methionine
		{
			set{ _domestic_methionine=value;}
			get{return _domestic_methionine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal domestic_fat
		{
			set{ _domestic_fat=value;}
			get{return _domestic_fat;}
		}

        public string customer
        {
            get
            {
                return _customer;
            }

            set
            {
                _customer = value;
            }
        }

        public string createman
        {
            get
            {
                return _createman;
            }

            set
            {
                _createman = value;
            }
        }
        #endregion Model
    }
}
