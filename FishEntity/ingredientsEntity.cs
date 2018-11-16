using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ingredientsEntity
    {
        public ingredientsEntity() { }
        private int _id;
        private string _code;
        private DateTime? _ProductionDate;
        private DateTime? _Outoftime;
        private string _Brand;
        private string _tlabel;
        private string _quality;
        private string _Remarks;
        private DateTime? _modifytime;
        private string _modifyman;
        private DateTime? _createtime;
        private string _createman;

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

        public DateTime? ProductionDate
        {
            get
            {
                return _ProductionDate;
            }

            set
            {
                _ProductionDate = value;
            }
        }

        public DateTime? Outoftime
        {
            get
            {
                return _Outoftime;
            }

            set
            {
                _Outoftime = value;
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

        public string Tlabel
        {
            get
            {
                return _tlabel;
            }

            set
            {
                _tlabel = value;
            }
        }

        public string Quality
        {
            get
            {
                return _quality;
            }

            set
            {
                _quality = value;
            }
        }

        public string Remarks
        {
            get
            {
                return _Remarks;
            }

            set
            {
                _Remarks = value;
            }
        }

        public DateTime? Modifytime
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

        public DateTime? Createtime
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
    }
}
