using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class FoodOutDetailEntityVO : FoodOutDetailEntity
    {
        private string _productcode;
        private string _productname;
        private string _state;
        private decimal _weight = 0.000M;
        private int _quantity = 0;
        private decimal _remainweight = 0.000M;
        private int _remainquantity = 0;
        private decimal _homemadeweight = 0.000M;
        private int? _homemadepackages = 0;
        private decimal _homemadecost = 0.000M;
        private decimal _homemadeunitprice = 0.000M;
        private decimal _price;
        private decimal? _sgs_protein;
        private int? _sgs_tvn;
        private decimal? _sgs_graypart;
        private decimal? _sgs_sandsalt;
        private int? _sgs_amine;
        private decimal? _sgs_ffa;
        private decimal? _sgs_fat;
        private decimal? _sgs_water;
        private decimal? _sgs_sand;
        private decimal _domestic_protein;
        private decimal  _domestic_tvn;
        private decimal _domestic_graypart;
        private decimal _domestic_sandsalt;
        private decimal _domestic_sour;
        private decimal _domestic_lysine;
        private decimal _domestic_methionine;
        private decimal _domestic_fat;
        private decimal _domestic_aminototal;
        private decimal _domestic_amine;
        private string _nature;
        private string _brand;
        private string _remark;
        private string _shipno;
        private string _billofgoods;
        private decimal _selfrmb;
        private decimal _salermb;

        private decimal _cost = 0;
      
        public string productcode
        {
            get { return _productcode; }
            set { _productcode = value; }
        }
        public string productname
        {
            get { return _productname; }
            set { _productname = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal weight
        {
            set { _weight = value; }
            get { return _weight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal remainweight
        {
            set { _remainweight = value; }
            get { return _remainweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int remainquantity
        {
            set { _remainquantity = value; }
            get { return _remainquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal homemadeweight
        {
            set { _homemadeweight = value; }
            get { return _homemadeweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? homemadepackages
        {
            set { _homemadepackages = value; }
            get { return _homemadepackages; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal homemadecost
        {
            set { _homemadecost = value; }
            get { return _homemadecost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal homemadeunitprice
        {
            set { _homemadeunitprice = value; }
            get { return _homemadeunitprice; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string state
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sgs_protein
        {
            set { _sgs_protein = value; }
            get { return _sgs_protein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sgs_tvn
        {
            set { _sgs_tvn = value; }
            get { return _sgs_tvn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sgs_graypart
        {
            set { _sgs_graypart = value; }
            get { return _sgs_graypart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sgs_sandsalt
        {
            set { _sgs_sandsalt = value; }
            get { return _sgs_sandsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? sgs_amine
        {
            set { _sgs_amine = value; }
            get { return _sgs_amine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sgs_ffa
        {
            set { _sgs_ffa = value; }
            get { return _sgs_ffa; }
        }

        public decimal? sgs_fat
        {
            get { return _sgs_fat; }
            set { _sgs_fat = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sgs_water
        {
            set { _sgs_water = value; }
            get { return _sgs_water; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? sgs_sand
        {
            set { _sgs_sand = value; }
            get { return _sgs_sand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_protein
        {
            set { _domestic_protein = value; }
            get { return _domestic_protein; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal  domestic_tvn
        {
            set { _domestic_tvn = value; }
            get { return _domestic_tvn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_graypart
        {
            set { _domestic_graypart = value; }
            get { return _domestic_graypart; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_sandsalt
        {
            set { _domestic_sandsalt = value; }
            get { return _domestic_sandsalt; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_sour
        {
            set { _domestic_sour = value; }
            get { return _domestic_sour; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_lysine
        {
            set { _domestic_lysine = value; }
            get { return _domestic_lysine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal domestic_methionine
        {
            set { _domestic_methionine = value; }
            get { return _domestic_methionine; }
        }

        public decimal domestic_aminototal
        {
            get { return _domestic_aminototal; }
            set { _domestic_aminototal = value; }
        }

        public decimal domestic_fat
        {
            get { return _domestic_fat; }
            set { _domestic_fat = value; }
        }

        public decimal domestic_amine
        {
            get { return _domestic_amine; }
            set { _domestic_amine = value; }
        }

        public decimal cost
        {
            get { return _cost; }
            set { _cost = value; }
        }

        public string nature
        {
            get { return _nature; }
            set { _nature = value; }
        }
        public string brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string shipno
        {
            get { return _shipno; }
            set { _shipno = value; }
        }
        public string billofgoods
        {
            get { return _billofgoods; }
            set { _billofgoods = value; }
        }
        public string remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        public decimal selfrmb
        {
            get { return _selfrmb; }
            set { _selfrmb = value; }
        }
        public decimal salermb
        {
            get { return _salermb; }
            set { _salermb = value; }
        }
    }
}
