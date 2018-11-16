using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
  public   class ProductVo :ProductEntity
    {
        private string _quotedate;
        private decimal? _quoteweight;
        private int? _quotequantity;
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
        private string _confirmdate;
        private decimal? _confirmsgsweight;
        private int? _confirmsgsquantity;
        private decimal? _confirmdollars;
        private decimal? _confirmrmb;
        private string _confirmagentcode;
        private string _confirmagent;
        private string _confirmlinkmancode;
        private string _confirmlinkman;
        private string _confirmproductyear;
        private string _confirmproductdate;
        private string _confirmlife;
        private string _confirmsaildate;
        private string _spotdate;
        private decimal? _spotweight;
        private int? _spotquantity;
        private decimal? _spotdollars;
        private decimal? _spotrmb;
        private string _spotagentcode;
        private string _spotagent;
        private string _spotlinkmancode;
        private string _spotlinkman;
        private string _spotproductdate;
        private string _spotproductyear;
        private string _spotlife;
        private string _spotstoragedate;
        private string _saledate;
        private decimal? _saleremainweight;
        private int? _saleremainquantity;
        private decimal? _saledollars;
        private decimal? _salermb;
        private string _saletradercode;
        private string _saletrader;
        private string _salelinkmancode;
        private string _salelinkman;
        private string _saleoutdate;
        private string _selfdate;
        private decimal? _selfstorageweight;
        private int? _selfstoragequantity;
        private decimal? _selfdollars;
        private decimal? _selfrmb;
        private string _selftradercode;
        private string _selftrader;
        private string _selflinkmancode;
        private string _selflinkman;
        private string _selffinishproduct;
        private string _selfstoragedate;

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
        public decimal? quoteweight
        {
            set { _quoteweight = value; }
            get { return _quoteweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? quotequantity
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
        /// 
        /// </summary>
        public string confirmdate
        {
            set { _confirmdate = value; }
            get { return _confirmdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? confirmsgsweight
        {
            set { _confirmsgsweight = value; }
            get { return _confirmsgsweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? confirmsgsquantity
        {
            set { _confirmsgsquantity = value; }
            get { return _confirmsgsquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? confirmdollars
        {
            set { _confirmdollars = value; }
            get { return _confirmdollars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? confirmrmb
        {
            set { _confirmrmb = value; }
            get { return _confirmrmb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmagentcode
        {
            set { _confirmagentcode = value; }
            get { return _confirmagentcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmagent
        {
            set { _confirmagent = value; }
            get { return _confirmagent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmlinkmancode
        {
            set { _confirmlinkmancode = value; }
            get { return _confirmlinkmancode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmlinkman
        {
            set { _confirmlinkman = value; }
            get { return _confirmlinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmproductyear
        {
            set { _confirmproductyear = value; }
            get { return _confirmproductyear; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmproductdate
        {
            set { _confirmproductdate = value; }
            get { return _confirmproductdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string confirmlife
        {
            set { _confirmlife = value; }
            get { return _confirmlife; }
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
        public decimal? spotweight
        {
            set { _spotweight = value; }
            get { return _spotweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? spotquantity
        {
            set { _spotquantity = value; }
            get { return _spotquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? spotdollars
        {
            set { _spotdollars = value; }
            get { return _spotdollars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? spotrmb
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
        public string saledate
        {
            set { _saledate = value; }
            get { return _saledate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? saleremainweight
        {
            set { _saleremainweight = value; }
            get { return _saleremainweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? saleremainquantity
        {
            set { _saleremainquantity = value; }
            get { return _saleremainquantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? saledollars
        {
            set { _saledollars = value; }
            get { return _saledollars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? salermb
        {
            set { _salermb = value; }
            get { return _salermb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saletradercode
        {
            set { _saletradercode = value; }
            get { return _saletradercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saletrader
        {
            set { _saletrader = value; }
            get { return _saletrader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string salelinkmancode
        {
            set { _salelinkmancode = value; }
            get { return _salelinkmancode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string salelinkman
        {
            set { _salelinkman = value; }
            get { return _salelinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string saleoutdate
        {
            set { _saleoutdate = value; }
            get { return _saleoutdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selfdate
        {
            set { _selfdate = value; }
            get { return _selfdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? selfstorageweight
        {
            set { _selfstorageweight = value; }
            get { return _selfstorageweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? selfstoragequantity
        {
            set { _selfstoragequantity = value; }
            get { return _selfstoragequantity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? selfdollars
        {
            set { _selfdollars = value; }
            get { return _selfdollars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? selfrmb
        {
            set { _selfrmb = value; }
            get { return _selfrmb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selftradercode
        {
            set { _selftradercode = value; }
            get { return _selftradercode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selftrader
        {
            set { _selftrader = value; }
            get { return _selftrader; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selflinkmancode
        {
            set { _selflinkmancode = value; }
            get { return _selflinkmancode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selflinkman
        {
            set { _selflinkman = value; }
            get { return _selflinkman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selffinishproduct
        {
            set { _selffinishproduct = value; }
            get { return _selffinishproduct; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string selfstoragedate
        {
            set { _selfstoragedate = value; }
            get { return _selfstoragedate; }
        }
    }
}
