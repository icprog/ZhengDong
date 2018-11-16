using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ProductSpotVo : ProductEntity
    {
        private decimal _confirmsgsweight;
        private string _confirmsaildate;
        private string _spotdate;
        private decimal _spotweight;
        private int _spotquantity;
        private decimal _spotdollars;
        private decimal _spotrmb;
        private string _spotagentcode;
        private string _spotagent;
        private string _spotlinkmancode;
        private string _spotlinkman;
        private string _spotproductdate;
        private string _spotproductyear;
        private string _spotlife;
        private string _spotstoragedate;
        private decimal _saleremainweight;
        private string _saletradercode;
        private string _saletrader;
        private string _salelinkmancode;
        private string _salelinkman;
        private decimal _salermb;
        private string _shortname;

        public string saletradercode
        {
            get { return _saletradercode; }
            set { _saletradercode = value; }
        }
       

        public string saletrader
        {
            get { return _saletrader; }
            set { _saletrader = value; }
        }
       

        public string salelinkmancode
        {
            get { return _salelinkmancode; }
            set { _salelinkmancode = value; }
        }        

        public string salelinkman
        {
            get { return _salelinkman; }
            set { _salelinkman = value; }
        }
     
        /// <summary>
        /// 
        /// </summary>
        public decimal confirmsgsweight
        {
            set { _confirmsgsweight = value; }
            get { return _confirmsgsweight; }
        }
      
        /// <summary>
        /// 
        /// </summary>
        public string confirmsaildate
        {
            set { _confirmsaildate = value; }
            get { return _confirmsaildate; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string spotdate
        {
            set { _spotdate = value; }
            get { return _spotdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal spotweight
        {
            set { _spotweight = value; }
            get { return _spotweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int spotquantity
        {
            set { _spotquantity = value; }
            get { return _spotquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal spotdollars
        {
            set { _spotdollars = value; }
            get { return _spotdollars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal spotrmb
        {
            set { _spotrmb = value; }
            get { return _spotrmb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotagentcode
        {
            set { _spotagentcode = value; }
            get { return _spotagentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotagent
        {
            set { _spotagent = value; }
            get { return _spotagent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotlinkmancode
        {
            set { _spotlinkmancode = value; }
            get { return _spotlinkmancode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotlinkman
        {
            set { _spotlinkman = value; }
            get { return _spotlinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotproductdate
        {
            set { _spotproductdate = value; }
            get { return _spotproductdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotproductyear
        {
            set { _spotproductyear = value; }
            get { return _spotproductyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotlife
        {
            set { _spotlife = value; }
            get { return _spotlife; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string spotstoragedate
        {
            get { return _spotstoragedate; }
            set { _spotstoragedate = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal saleremainweight
        {
            set { _saleremainweight = value; }
            get { return _saleremainweight; }
        }

        public decimal Salermb
        {
            get
            {
                return _salermb;
            }

            set
            {
                _salermb = value;
            }
        }
        /// <summary>
        /// 现货简称
        /// </summary>
        public string shortname
        {
            get
            {
                return _shortname;
            }

            set
            {
                _shortname = value;
            }
        }
    }
}
