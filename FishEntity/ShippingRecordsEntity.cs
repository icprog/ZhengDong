using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ShippingRecordsEntity
    {
        public ShippingRecordsEntity() { }
        private int _id;
        private string _code;
        private DateTime? _pickuptime;
        private decimal? _tonnage;
        private int _NumberOfPacks;
        private string _ShippingUnit;
        private string _ArrivalUnit;
        private string _Freight;
        private string _CarNumber;
        private string _ShipName;
        private string _BillOfLadingNumber;
        private string _Country;
        private string _Brand;
        private string _quality;
        private DateTime? _ProductionDate;
        private string _Remarks;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;

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

        public DateTime? Pickuptime
        {
            get
            {
                return _pickuptime;
            }

            set
            {
                _pickuptime = value;
            }
        }

        public decimal? Tonnage
        {
            get
            {
                return _tonnage;
            }

            set
            {
                _tonnage = value;
            }
        }

        public int NumberOfPacks
        {
            get
            {
                return _NumberOfPacks;
            }

            set
            {
                _NumberOfPacks = value;
            }
        }

        public string ShippingUnit
        {
            get
            {
                return _ShippingUnit;
            }

            set
            {
                _ShippingUnit = value;
            }
        }

        public string ArrivalUnit
        {
            get
            {
                return _ArrivalUnit;
            }

            set
            {
                _ArrivalUnit = value;
            }
        }

        public string Freight
        {
            get
            {
                return _Freight;
            }

            set
            {
                _Freight = value;
            }
        }

        public string CarNumber
        {
            get
            {
                return _CarNumber;
            }

            set
            {
                _CarNumber = value;
            }
        }

        public string ShipName
        {
            get
            {
                return _ShipName;
            }

            set
            {
                _ShipName = value;
            }
        }

        public string BillOfLadingNumber
        {
            get
            {
                return _BillOfLadingNumber;
            }

            set
            {
                _BillOfLadingNumber = value;
            }
        }

        public string Country
        {
            get
            {
                return _Country;
            }

            set
            {
                _Country = value;
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
    }
}
