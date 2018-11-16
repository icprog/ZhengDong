using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CheckRecordEntity
    {
        public CheckRecordEntity()
		{}
		#region Model
		private int _id;
		private int _productid;
		private string _productcode;
		private string _productname;
		private int _recordno=1;
		private string _checkdate;
		private string _testdate;
		private int _testcompanyid;
		private string _testcompanycode;
		private string _testcompanyname;
		private decimal? _regularindex1;
		private decimal? _regularindex2;
		private decimal? _regularindex3;
		private decimal? _regularindex4;
		private decimal? _regularindex5;
		private decimal? _regularindex6;
		private decimal? _regularindex7;
		private decimal? _regularindex8;
		private decimal? _regularindex9;
		private decimal? _regularindex10;
		private decimal? _regularindex11;
		private decimal? _regularindex12;
		private decimal? _aminoindex1;
		private decimal? _aminoindex2;
		private decimal? _aminoindex3;
		private decimal? _aminoindex4;
		private decimal? _aminoindex5;
		private decimal? _aminoindex6;
		private decimal? _aminoindex7;
		private decimal? _aminoindex8;
		private decimal? _aminoindex9;
		private decimal? _aminoindex10;
		private decimal? _aminoindex11;
		private decimal? _aminoindex12;
		private decimal? _aminoindex13;
		private decimal? _aminoindex14;
		private decimal? _aminoindex15;
		private decimal? _aminoindex16;
		private decimal? _aminoindex17;
		private decimal? _aminoindex18;
		private decimal? _aminoindex19;
		private decimal? _aminoindex20;
		private decimal? _aminoindex21;
		private decimal? _aminoindex22;
		private decimal? _aminoindex23;
		private string _specialindex1;
		private string _specialindex2;
		private string _specialindex3;
		private string _specialindex4;
		private string _specialindex5;
        private decimal? _fee; //= 0.00M;
        private string describe;
        private string _sendsamplename;
        private decimal? _Digestibility;
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
		public int recordno
		{
			set{ _recordno=value;}
			get{return _recordno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string checkdate
		{
			set{ _checkdate=value;}
			get{return _checkdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string testdate
		{
			set{ _testdate=value;}
			get{return _testdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int testcompanyid
		{
			set{ _testcompanyid=value;}
			get{return _testcompanyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string testcompanycode
		{
			set{ _testcompanycode=value;}
			get{return _testcompanycode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string testcompanyname
		{
			set{ _testcompanyname=value;}
			get{return _testcompanyname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex1
		{
			set{ _regularindex1=value;}
			get{return _regularindex1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex2
		{
			set{ _regularindex2=value;}
			get{return _regularindex2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex3
		{
			set{ _regularindex3=value;}
			get{return _regularindex3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex4
		{
			set{ _regularindex4=value;}
			get{return _regularindex4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex5
		{
			set{ _regularindex5=value;}
			get{return _regularindex5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex6
		{
			set{ _regularindex6=value;}
			get{return _regularindex6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex7
		{
			set{ _regularindex7=value;}
			get{return _regularindex7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex8
		{
			set{ _regularindex8=value;}
			get{return _regularindex8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex9
		{
			set{ _regularindex9=value;}
			get{return _regularindex9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex10
		{
			set{ _regularindex10=value;}
			get{return _regularindex10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex11
		{
			set{ _regularindex11=value;}
			get{return _regularindex11;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? regularindex12
		{
			set{ _regularindex12=value;}
			get{return _regularindex12;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex1
		{
			set{ _aminoindex1=value;}
			get{return _aminoindex1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex2
		{
			set{ _aminoindex2=value;}
			get{return _aminoindex2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex3
		{
			set{ _aminoindex3=value;}
			get{return _aminoindex3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex4
		{
			set{ _aminoindex4=value;}
			get{return _aminoindex4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex5
		{
			set{ _aminoindex5=value;}
			get{return _aminoindex5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex6
		{
			set{ _aminoindex6=value;}
			get{return _aminoindex6;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex7
		{
			set{ _aminoindex7=value;}
			get{return _aminoindex7;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex8
		{
			set{ _aminoindex8=value;}
			get{return _aminoindex8;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex9
		{
			set{ _aminoindex9=value;}
			get{return _aminoindex9;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex10
		{
			set{ _aminoindex10=value;}
			get{return _aminoindex10;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex11
		{
			set{ _aminoindex11=value;}
			get{return _aminoindex11;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex12
		{
			set{ _aminoindex12=value;}
			get{return _aminoindex12;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex13
		{
			set{ _aminoindex13=value;}
			get{return _aminoindex13;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex14
		{
			set{ _aminoindex14=value;}
			get{return _aminoindex14;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex15
		{
			set{ _aminoindex15=value;}
			get{return _aminoindex15;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex16
		{
			set{ _aminoindex16=value;}
			get{return _aminoindex16;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex17
		{
			set{ _aminoindex17=value;}
			get{return _aminoindex17;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex18
		{
			set{ _aminoindex18=value;}
			get{return _aminoindex18;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex19
		{
			set{ _aminoindex19=value;}
			get{return _aminoindex19;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex20
		{
			set{ _aminoindex20=value;}
			get{return _aminoindex20;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex21
		{
			set{ _aminoindex21=value;}
			get{return _aminoindex21;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex22
		{
			set{ _aminoindex22=value;}
			get{return _aminoindex22;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? aminoindex23
		{
			set{ _aminoindex23=value;}
			get{return _aminoindex23;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specialindex1
		{
			set{ _specialindex1=value;}
			get{return _specialindex1;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specialindex2
		{
			set{ _specialindex2=value;}
			get{return _specialindex2;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specialindex3
		{
			set{ _specialindex3=value;}
			get{return _specialindex3;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specialindex4
		{
			set{ _specialindex4=value;}
			get{return _specialindex4;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string specialindex5
		{
			set{ _specialindex5=value;}
			get{return _specialindex5;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}

        public int testperiod
        {
            get
            {
                int period = 0;
                DateTime dt1;
                DateTime dt2;
               bool isok1 =  DateTime.TryParseExact(testdate,"yyyy.MM.dd", null, System.Globalization.DateTimeStyles.None, out dt1);
               bool isok2 = DateTime.TryParseExact(checkdate,"yyyy.MM.dd",null, System.Globalization.DateTimeStyles.None ,out dt2);
               if (isok1 && isok2)
               {
                  period = dt1.Subtract(dt2).Days;
               }

               return period ;
            }
        }

        public string Describe
        {
            get
            {
                return describe;
            }

            set
            {
                describe = value;
            }
        }

        public string Sendsamplename
        {
            get
            {
                return _sendsamplename;
            }

            set
            {
                _sendsamplename = value;
            }
        }

        public decimal? Digestibility
        {
            get
            {
                return _Digestibility;
            }

            set
            {
                _Digestibility = value;
            }
        }
        #endregion Model
    }
}
