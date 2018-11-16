using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class SampleSingleEntity
    {
        private int _id;
        private string code;
        private string _ferryName;
        private string _BillOfLadingNumber;
        private string _PileAngle;
        private DateTime? _tdate;
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

        public string FerryName
        {
            get
            {
                return _ferryName;
            }

            set
            {
                _ferryName = value;
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

        public string PileAngle
        {
            get
            {
                return _PileAngle;
            }

            set
            {
                _PileAngle = value;
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

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public DateTime? Tdate
        {
            get
            {
                return _tdate;
            }

            set
            {
                _tdate = value;
            }
        }
    }
}
