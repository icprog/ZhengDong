using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class salehaEntity
    {
        private int _id;
        private int _Saleid;
        private int _Haid;
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

        public int Saleid
        {
            get
            {
                return _Saleid;
            }

            set
            {
                _Saleid = value;
            }
        }

        public int Haid
        {
            get
            {
                return _Haid;
            }

            set
            {
                _Haid = value;
            }
        }
    }
}
