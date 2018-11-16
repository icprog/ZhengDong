using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class SelfStorageFlowingReportVo:ProductEntity
    {
        private int _productid;

        public int productid
        {
            get { return _productid; }
            set { _productid = value; }
        }
        private string _productcode;

        public string productcode
        {
            get { return _productcode; }
            set { _productcode = value; }
        }
        private string _productname;

        public string productname
        {
            get { return _productname; }
            set { _productname = value; }
        }

        protected string _state;

        public string state
        {
            get { return _state; }
            set { _state = value; }
        }

        protected string _statename;

        public string statename
        {
            get
            {
                return _statename;
            }
            set
            {
                _statename = value;
            }
        }

        private string _billtype;

        public string billtype
        {
            get { return _billtype; }
            set { _billtype = value; }
        }
        private string _billcode;

        public string billcode
        {
            get { return _billcode; }
            set { _billcode = value; }
        }
        private DateTime _date;

        public DateTime date
        {
            get { return _date; }
            set { _date = value; }
        }
        private string _storagetype;

        public string storagetype
        {
            get { return _storagetype; }
            set { _storagetype = value; }
        }
        private string _nature;

        public string nature
        {
            get { return _nature; }
            set { _nature = value; }
        }
        private string _techtype;

        public string techtype
        {
            get { return _techtype; }
            set { _techtype = value; }
        }
        private string _specification;

        public string specification
        {
            get { return _specification; }
            set { _specification = value; }
        }
        private string _brand;

        public string brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        private string _ownername;

        public string ownername
        {
            get { return _ownername; }
            set { _ownername = value; }
        }
        private string _arriveportdate;

        public string arriveportdate
        {
            get { return _arriveportdate; }
            set { _arriveportdate = value; }
        }
        private string _agentifcompany;

        public string agentifcompany
        {
            get { return _agentifcompany; }
            set { _agentifcompany = value; }
        }
        private string _customsofcompany;

        public string customsofcompany
        {
            get { return _customsofcompany; }
            set { _customsofcompany = value; }
        }
        private decimal _sgs_protein;

        public decimal sgs_protein
        {
            get { return _sgs_protein; }
            set { _sgs_protein = value; }
        }
        private decimal _sgs_tvn;

        public decimal sgs_tvn
        {
            get { return _sgs_tvn; }
            set { _sgs_tvn = value; }
        }
        private decimal _sgs_amine;

        public decimal sgs_amine
        {
            get { return _sgs_amine; }
            set { _sgs_amine = value; }
        }


        protected decimal _weight;
        public decimal weight
        {
            get { return _weight; }
            set { _weight = value; }
        }
        protected int _package;
        public int package
        {
            get { return _package; }
            set { _package = value; }
        }
    }
}
