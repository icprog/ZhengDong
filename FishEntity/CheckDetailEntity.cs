using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CheckDetailEntity
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _mid;

        public int mid
        {
            get { return _mid; }
            set { _mid = value; }
        }

        private int _line;
        public int line
        {
            get { return _line; }
            set { _line = value; }
        }

        private int _orderid;

        public int orderid
        {
            get { return _orderid; }
            set { _orderid = value; }
        }

        private string _checkkey;

        public string checkkey
        {
            get { return _checkkey; }
            set { _checkkey = value; }
        }
        private string _checkvalue;

        public string checkvalue
        {
            get { return _checkvalue; }
            set { _checkvalue = value; }
        }
    }
}
