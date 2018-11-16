using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class HomemadeStorageEntity
    {
        public HomemadeStorageEntity()
		{}
		#region Model
		private int _id;
		private string _code;
		private string _seq;
		private int? _productid;
		private string _productcode;
		private string _productname;
		private DateTime? _intime;
		private DateTime? _outtime;
		private decimal? _grossweight;
		private decimal? _tareweight;
		private decimal? _netweight;
		private int? _packages;
		private decimal? _unitprice;
		private decimal? _sgs_protein;
		private int? _sgs_tvn;
		private decimal? _sgs_graypart;
		private decimal? _sgs_sandsalt;
		private int? _sgs_amine;
		private decimal? _sgs_ffa;
		private decimal? _sgs_fat;
		private decimal? _sgs_water;
		private decimal? _sgs_sand;
		private decimal? _label_lysine;
		private decimal? _label_methionine;
		private decimal? _domestic_protein;
		private int? _domestic_tvn;
		private decimal? _domestic_graypart;
		private decimal? _domestic_sandsalt;
		private decimal? _domestic_sour;
		private decimal? _domestic_lysine;
		private decimal? _domestic_methionine;
		private string _createman;
		private DateTime _createtime= DateTime.Now;
		private string _modifyman;
        private DateTime _modifytime = DateTime.Now;
		private int? _isdelete=0;
        private DateTime? _storagetime;
        private decimal _selfprice = 0.00M;
        private decimal _saleprice = 0.00M;
        private int _purchasemanid;
        private string _purchaseman;
        private int _storagemanid;
        private string _storageman;
        private decimal _storageweight = 0.000M;
        private int _storagequantity = 0;

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
		public string seq
		{
			set{ _seq=value;}
			get{return _seq;}
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
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? intime
		{
			set{ _intime=value;}
			get{return _intime;}
		}
		/// <summary>
		/// on update CURRENT_TIMESTAMP
		/// </summary>
		public DateTime? outtime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? grossweight
		{
			set{ _grossweight=value;}
			get{return _grossweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? tareweight
		{
			set{ _tareweight=value;}
			get{return _tareweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? netweight
		{
			set{ _netweight=value;}
			get{return _netweight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? packages
		{
			set{ _packages=value;}
			get{return _packages;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? unitprice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_protein
		{
			set{ _sgs_protein=value;}
			get{return _sgs_protein;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sgs_tvn
		{
			set{ _sgs_tvn=value;}
			get{return _sgs_tvn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_graypart
		{
			set{ _sgs_graypart=value;}
			get{return _sgs_graypart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_sandsalt
		{
			set{ _sgs_sandsalt=value;}
			get{return _sgs_sandsalt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sgs_amine
		{
			set{ _sgs_amine=value;}
			get{return _sgs_amine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_ffa
		{
			set{ _sgs_ffa=value;}
			get{return _sgs_ffa;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_fat
		{
			set{ _sgs_fat=value;}
			get{return _sgs_fat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_water
		{
			set{ _sgs_water=value;}
			get{return _sgs_water;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? sgs_sand
		{
			set{ _sgs_sand=value;}
			get{return _sgs_sand;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? label_lysine
		{
			set{ _label_lysine=value;}
			get{return _label_lysine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? label_methionine
		{
			set{ _label_methionine=value;}
			get{return _label_methionine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? domestic_protein
		{
			set{ _domestic_protein=value;}
			get{return _domestic_protein;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? domestic_tvn
		{
			set{ _domestic_tvn=value;}
			get{return _domestic_tvn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? domestic_graypart
		{
			set{ _domestic_graypart=value;}
			get{return _domestic_graypart;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? domestic_sandsalt
		{
			set{ _domestic_sandsalt=value;}
			get{return _domestic_sandsalt;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? domestic_sour
		{
			set{ _domestic_sour=value;}
			get{return _domestic_sour;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? domestic_lysine
		{
			set{ _domestic_lysine=value;}
			get{return _domestic_lysine;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? domestic_methionine
		{
			set{ _domestic_methionine=value;}
			get{return _domestic_methionine;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? isdelete
		{
			set{ _isdelete=value;}
			get{return _isdelete;}
		}
        /// <summary>
        /// on update CURRENT_TIMESTAMP
        /// </summary>
        public DateTime? storagetime
        {
            set { _storagetime = value; }
            get { return _storagetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal selfprice
        {
            set { _selfprice = value; }
            get { return _selfprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal saleprice
        {
            set { _saleprice = value; }
            get { return _saleprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int purchasemanid
        {
            set { _purchasemanid = value; }
            get { return _purchasemanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string purchaseman
        {
            set { _purchaseman = value; }
            get { return _purchaseman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int storagemanid
        {
            set { _storagemanid = value; }
            get { return _storagemanid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string storageman
        {
            set { _storageman = value; }
            get { return _storageman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal storageweight
        {
            set { _storageweight = value; }
            get { return _storageweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int storagequantity
        {
            set { _storagequantity = value; }
            get { return _storagequantity; }
        }

		#endregion Model
    }
}
