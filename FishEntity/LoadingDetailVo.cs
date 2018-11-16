using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class LoadingDetailVo :LoadingDetailEntity
    {
        private DateTime _signdate;
        private string _nature;
        private decimal  _sgs_protein;
        private int _sgs_tvn;
        private string _brand;

        public DateTime signdate
        {
            get { return _signdate; }
            set { _signdate = value; }
        }
        public string nature
        {
            get { return _nature; }
            set { _nature = value; }
        }
        public decimal sgs_protein
        {
            get { return _sgs_protein; }
            set { _sgs_protein = value; }
        }
        public int sgs_tvn
        {
            get { return _sgs_tvn; }
            set { _sgs_tvn = value; }
        }
        public string brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

    }
}
