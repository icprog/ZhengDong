using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class FinishVo : FishEntity.ProductEntity
    {
        private string _saleman;

        public string saleman
        {
            get { return _saleman; }
            set { _saleman = value; }
        }
        private string _deliveryman;

        public string deliveryman
        {
            get { return _deliveryman; }
            set { _deliveryman = value; }
        }
        private DateTime _indate;

        public DateTime indate
        {
            get { return _indate; }
            set { _indate = value; }
        }
        private DateTime _outdate;

        public DateTime outdate
        {
            get { return _outdate; }
            set { _outdate = value; }
        }
        private String _companyname;

        public String companyname
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        private string _spotproductdate;

        public string spotproductdate
        {
            get { return _spotproductdate; }
            set { _spotproductdate = value; }
        }

    }
}
