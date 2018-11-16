using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ProductQuoteVo : ProductEntity
    {
        private string _quotedate;
        private decimal _quoteweight;
        private int _quotequantity;
        private decimal? _quotedollars;
        private decimal? _quotermb;
        private string _quotesuppliercode;
        private string _quotesupplier;
        private string _quotelinkmancode;
        private string _quotelinkman;
        private string _quoteproductyear;
        private string _quoteproductdate;
        private string _quotelife;
        private string _quotesaildatefast;
        private string _quotesaildatelate;
        private string _quoteshortname;
        private string _shortname;
        private string _quotEexchangeRate;
        private string _PlaceOfDelivery;

        /// <summary>
        /// 
        /// </summary>
        public string quotedate
        {
            set { _quotedate = value; }
            get { return _quotedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal quoteweight
        {
            set { _quoteweight = value; }
            get { return _quoteweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int quotequantity
        {
            set { _quotequantity = value; }
            get { return _quotequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quotedollars
        {
            set { _quotedollars = value; }
            get { return _quotedollars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? quotermb
        {
            set { _quotermb = value; }
            get { return _quotermb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotesuppliercode
        {
            set { _quotesuppliercode = value; }
            get { return _quotesuppliercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotesupplier
        {
            set { _quotesupplier = value; }
            get { return _quotesupplier; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotelinkmancode
        {
            set { _quotelinkmancode = value; }
            get { return _quotelinkmancode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotelinkman
        {
            set { _quotelinkman = value; }
            get { return _quotelinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quoteproductyear
        {
            set { _quoteproductyear = value; }
            get { return _quoteproductyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quoteproductdate
        {
            set { _quoteproductdate = value; }
            get { return _quoteproductdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotelife
        {
            set { _quotelife = value; }
            get { return _quotelife; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotesaildatefast
        {
            set { _quotesaildatefast = value; }
            get { return _quotesaildatefast; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string quotesaildatelate
        {
            set { _quotesaildatelate = value; }
            get { return _quotesaildatelate; }
        }
        /// <summary>
        /// 报盘简称
        /// </summary>
        public string quoteshortname
        {
            get
            {
                return _quoteshortname;
            }

            set
            {
                _quoteshortname = value;
            }
        }
        /// <summary>
        /// 单位简称
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

        public string QuotEexchangeRate
        {
            get
            {
                return _quotEexchangeRate;
            }

            set
            {
                _quotEexchangeRate = value;
            }
        }

        public string PlaceOfDelivery
        {
            get
            {
                return _PlaceOfDelivery;
            }

            set
            {
                _PlaceOfDelivery = value;
            }
        }
    }
}
