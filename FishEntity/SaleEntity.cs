using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public class SaleEntity
    {
        public SaleEntity() { }
        private int _id;
        private int _no;
        private int _companyid;
        private string _companycode;
        private string _company;
        private int _customerid;
        private string _customercode;
        private string _customer;
        private int _productid;
        private decimal _saledollars = 0.000M;
        private decimal _rate;
        private int _isdelete = 0;
        private decimal _salermb=0;
        private decimal _weight = 0;

        private decimal _sgsweight = 0;

        private decimal _saleweight = 0;
        private int _quantity = 0;
        private DateTime? _saledate;
        private DateTime? _saletime;
        private string _saleman;
        private string _createman;
        private DateTime _createtime = DateTime.Now;
        private string _modifyman;
        private DateTime _modifytime = DateTime.Now;

        public int id
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

        public int no
        {
            get
            {
                return _no;
            }

            set
            {
                _no = value;
            }
        }

        public int companyid
        {
            get
            {
                return _companyid;
            }

            set
            {
                _companyid = value;
            }
        }

        public string companycode
        {
            get
            {
                return _companycode;
            }

            set
            {
                _companycode = value;
            }
        }

        public string company
        {
            get
            {
                return _company;
            }

            set
            {
                _company = value;
            }
        }

        public int customerid
        {
            get
            {
                return _customerid;
            }

            set
            {
                _customerid = value;
            }
        }

        public string customercode
        {
            get
            {
                return _customercode;
            }

            set
            {
                _customercode = value;
            }
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

        public int productid
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

        public decimal saledollars
        {
            get
            {
                return _saledollars;
            }

            set
            {
                _saledollars = value;
            }
        }

        public decimal rate
        {
            get
            {
                return _rate;
            }

            set
            {
                _rate = value;
            }
        }

        public int isdelete
        {
            get
            {
                return _isdelete;
            }

            set
            {
                _isdelete = value;
            }
        }

        public decimal salermb
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

        public decimal weight
        {
            get
            {
                return _weight;
            }

            set
            {
                _weight = value;
            }
        }

        public int quantity
        {
            get
            {
                return _quantity;
            }

            set
            {
                _quantity = value;
            }
        }

        public DateTime? saledate
        {
            get
            {
                return _saledate;
            }

            set
            {
                _saledate = value;
            }
        }

        public DateTime? saletime
        {
            get
            {
                return _saletime;
            }

            set
            {
                _saletime = value;
            }
        }

        public string saleman
        {
            get
            {
                return _saleman;
            }

            set
            {
                _saleman = value;
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

        public DateTime createtime
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

        public string modifyman
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

        public DateTime modifytime
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

        public decimal saleweight
        {
            get
            {
                return _saleweight;
            }

            set
            {
                _saleweight = value;
            }
        }

        public decimal sgsweight
        {
            get
            {
                return _sgsweight;
            }

            set
            {
                _sgsweight = value;
            }
        }
    }
}
