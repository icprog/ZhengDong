using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public  class ContractPorductEntity: ProductEntity
    {
        private int _cpid = 0;

        public int cpid
        {
            get { return _cpid; }
            set { _cpid = value; }
        }

        private decimal _getweight;
        public decimal getweight
        {
            get { return _getweight; }
            set { _getweight = value; }
        }
        private int _getquantity = 0;
        public int getquantity
        {
            get { return _getquantity; }
            set { _getquantity = value; }
        }

        private decimal _contractweight;
        public decimal contractweight
        {
            get { return _contractweight; }
            set { _contractweight = value; }
        }
        private int _contractquantity;
        public int contractquantity
        {
            get { return _contractquantity; }
            set { _contractquantity = value; }
        }
        private string _yifang;
        public string yifang
        {
            get { return _yifang; }
            set { _yifang = value; }
        }
        private string _yifangcode;
        public string yifangcode
        {
            get { return _yifangcode; }
            set { _yifangcode = value; }
        }
        private string _signdate;
        public string signdate
        {
            get { return _signdate; }
            set { _signdate = value; }
        }

        private int _no;
        public int no
        {
            get { return _no; }
            set { _no = value; }
        }
        private int _contractid;
        public int contractid
        {
            get { return _contractid; }
            set { _contractid= value; }
        }

        private string _contractno;
        public string contractno
        {
            get { return _contractno; }
            set { _contractno = value; }
        }

        private int _contractdetailid;
        public int contractdetailid
        {
            get { return _contractdetailid; }
            set { _contractdetailid = value; }
        }

        private int _contracttype;
        public int contracttype
        {
            get { return _contracttype; }
            set { _contracttype = value; }
        }

        public string contracttypename
        {
            get
            {
                if (_contracttype == (int)ContractTypeEnum.FuturesContract)
                {
                    return "期货预售合同";
                }
                else if (_contracttype == (int)ContractTypeEnum.ProductContract1)
                {
                    return "现货销售合同1";
                }
                else if (_contracttype == (int)ContractTypeEnum.ProductContract2)
                {
                    return "现货销售合同2";
                }
                return "";
            }
        }

    }
}
