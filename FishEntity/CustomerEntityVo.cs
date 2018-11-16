using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CustomerEntityVo :CustomerEntity
    {
        private string _companyName = string.Empty;
        private int _companyid = 0;
        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        public string companyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }
    }
}
