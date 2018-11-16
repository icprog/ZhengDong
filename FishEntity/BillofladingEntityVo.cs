using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class BillofladingEntityVo:BillofladingEntity
    {
        private int _id;
        private string _code;
        private string _listname;

        public int Id1
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

        public string Code1
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

        public string Listname1
        {
            get
            {
                return _listname;
            }

            set
            {
                _listname = value;
            }
        }
    }
}
