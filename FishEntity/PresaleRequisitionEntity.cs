using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class PresaleRequisitionEntity
    {
        public PresaleRequisitionEntity() { }
        private int _id;
        private string _code;
        private string _supplier;
        private string _demand;
        private DateTime? _Signdate;
        private string _Signplace;
        private string _Shipname;
        private string _Shipname1;
        private string _Pileangle;
        private string _Pileangle1;
        private string _Billoflading;
        private string _Billoflading1;
        private decimal? _rebate;
        private string _rebate1;
        private decimal? _Portprice;
        private string _Portprice1;
        private string _Country;
        private string _Country1;
        private string _Brand;
        private string _Brand1;
        private string _ModeOfTransport;
        private string _DeliveryDeadline;
        private decimal? _RMBday;
        private string _Margin;
        private string _date;
        private string _Notice;
        private string _TheDollar;
        private string _Bank;
        private string _Receipt;
        private int _accountnumber;
        private string _createman;
        private DateTime _createtime = DateTime.Now;
        private string _modifyman;
        private DateTime _modifytime = DateTime.Now;

        private int _productid;
        private string _product_id;
        private string _productname;
        private string _Funit;
        private string _Variety;
        private decimal? _Quantity;
        private decimal? _unitprice;
        private decimal? _Amountofmoney;

        private int _indexid;
        private string _index_id;
        private decimal? _protein;
        private decimal? _TVN;
        private decimal? _Ash;
        private decimal? _histamine;
        private decimal? _FFA;
        private decimal? _fat;
        private decimal? _Moisture;
        private decimal? _Sandsalt;
        private decimal? _sand;
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Code
        {
            get
            {
                return _code;
            }

            set
            {
                _code = value;
            }
        }

        public string Supplier
        {
            get
            {
                return _supplier;
            }

            set
            {
                _supplier = value;
            }
        }

        public string Demand
        {
            get
            {
                return _demand;
            }

            set
            {
                _demand = value;
            }
        }

        public DateTime? Signdate
        {
            get
            {
                return _Signdate;
            }

            set
            {
                _Signdate = value;
            }
        }

        public string Signplace
        {
            get
            {
                return _Signplace;
            }

            set
            {
                _Signplace = value;
            }
        }

        public string Shipname
        {
            get
            {
                return _Shipname;
            }

            set
            {
                _Shipname = value;
            }
        }

        public string Shipname1
        {
            get
            {
                return _Shipname1;
            }

            set
            {
                _Shipname1 = value;
            }
        }

        public string Pileangle
        {
            get
            {
                return _Pileangle;
            }

            set
            {
                _Pileangle = value;
            }
        }

        public string Pileangle1
        {
            get
            {
                return _Pileangle1;
            }

            set
            {
                _Pileangle1 = value;
            }
        }

        public string Billoflading
        {
            get
            {
                return _Billoflading;
            }

            set
            {
                _Billoflading = value;
            }
        }

        public string Billoflading1
        {
            get
            {
                return _Billoflading1;
            }

            set
            {
                _Billoflading1 = value;
            }
        }

        public decimal? Rebate
        {
            get
            {
                return _rebate;
            }

            set
            {
                _rebate = value;
            }
        }

        public string Rebate1
        {
            get
            {
                return _rebate1;
            }

            set
            {
                _rebate1 = value;
            }
        }

        public decimal? Portprice
        {
            get
            {
                return _Portprice;
            }

            set
            {
                _Portprice = value;
            }
        }

        public string Portprice1
        {
            get
            {
                return _Portprice1;
            }

            set
            {
                _Portprice1 = value;
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }

            set
            {
                _Country = value;
            }
        }

        public string Country1
        {
            get
            {
                return _Country1;
            }

            set
            {
                _Country1 = value;
            }
        }

        public string Brand
        {
            get
            {
                return _Brand;
            }

            set
            {
                _Brand = value;
            }
        }

        public string Brand1
        {
            get
            {
                return _Brand1;
            }

            set
            {
                _Brand1 = value;
            }
        }

        public string ModeOfTransport
        {
            get
            {
                return _ModeOfTransport;
            }

            set
            {
                _ModeOfTransport = value;
            }
        }

        public string DeliveryDeadline
        {
            get
            {
                return _DeliveryDeadline;
            }

            set
            {
                _DeliveryDeadline = value;
            }
        }

        public decimal? RMBday
        {
            get
            {
                return _RMBday;
            }

            set
            {
                _RMBday = value;
            }
        }

        public string Margin
        {
            get
            {
                return _Margin;
            }

            set
            {
                _Margin = value;
            }
        }

        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public string Notice
        {
            get
            {
                return _Notice;
            }

            set
            {
                _Notice = value;
            }
        }

        public string TheDollar
        {
            get
            {
                return _TheDollar;
            }

            set
            {
                _TheDollar = value;
            }
        }

        public string Bank
        {
            get
            {
                return _Bank;
            }

            set
            {
                _Bank = value;
            }
        }

        public string Receipt
        {
            get
            {
                return _Receipt;
            }

            set
            {
                _Receipt = value;
            }
        }



        public string Createman
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

        public DateTime Createtime
        {
            get
            {
                return _createtime;
            }

            set
            {
                _createtime = value;
            }
        }

        public string Modifyman
        {
            get
            {
                return _modifyman;
            }

            set
            {
                _modifyman = value;
            }
        }

        public DateTime Modifytime
        {
            get
            {
                return _modifytime;
            }

            set
            {
                _modifytime = value;
            }
        }

        public int Accountnumber
        {
            get
            {
                return _accountnumber;
            }

            set
            {
                _accountnumber = value;
            }
        }

        public int Productid
        {
            get
            {
                return _productid;
            }

            set
            {
                _productid = value;
            }
        }

        public string Product_id
        {
            get
            {
                return _product_id;
            }

            set
            {
                _product_id = value;
            }
        }

        public string Productname
        {
            get
            {
                return _productname;
            }

            set
            {
                _productname = value;
            }
        }

        public string Funit
        {
            get
            {
                return _Funit;
            }

            set
            {
                _Funit = value;
            }
        }

        public string Variety
        {
            get
            {
                return _Variety;
            }

            set
            {
                _Variety = value;
            }
        }

        public decimal? Quantity
        {
            get
            {
                return _Quantity;
            }

            set
            {
                _Quantity = value;
            }
        }

        public decimal? Unitprice
        {
            get
            {
                return _unitprice;
            }

            set
            {
                _unitprice = value;
            }
        }

        public decimal? Amountofmoney
        {
            get
            {
                return Amountofmoney1;
            }

            set
            {
                Amountofmoney1 = value;
            }
        }

        public decimal? Amountofmoney1
        {
            get
            {
                return _Amountofmoney;
            }

            set
            {
                _Amountofmoney = value;
            }
        }

        public int Indexid
        {
            get
            {
                return _indexid;
            }

            set
            {
                _indexid = value;
            }
        }

        public string Index_id
        {
            get
            {
                return _index_id;
            }

            set
            {
                _index_id = value;
            }
        }

        public decimal? Protein
        {
            get
            {
                return _protein;
            }

            set
            {
                _protein = value;
            }
        }

        public decimal? TVN
        {
            get
            {
                return _TVN;
            }

            set
            {
                _TVN = value;
            }
        }

        public decimal? Ash
        {
            get
            {
                return _Ash;
            }

            set
            {
                _Ash = value;
            }
        }

        public decimal? Histamine
        {
            get
            {
                return _histamine;
            }

            set
            {
                _histamine = value;
            }
        }

        public decimal? FFA
        {
            get
            {
                return _FFA;
            }

            set
            {
                _FFA = value;
            }
        }

        public decimal? Fat
        {
            get
            {
                return _fat;
            }

            set
            {
                _fat = value;
            }
        }

        public decimal? Moisture
        {
            get
            {
                return _Moisture;
            }

            set
            {
                _Moisture = value;
            }
        }

        public decimal? Sandsalt
        {
            get
            {
                return _Sandsalt;
            }

            set
            {
                _Sandsalt = value;
            }
        }

        public decimal? Sand
        {
            get
            {
                return _sand;
            }

            set
            {
                _sand = value;
            }
        }
    }
}
