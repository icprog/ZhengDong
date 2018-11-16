using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class ContractProcessingSheetEntity
    {
        private int _id;
        private string _code;
        private string _contractcode;
        private DateTime? _tdate;
        private string _TheReason;
        private string _Processing;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;

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

        public string Processing
        {
            get
            {
                return _Processing;
            }

            set
            {
                _Processing = value;
            }
        }

        public string TheReason
        {
            get
            {
                return _TheReason;
            }

            set
            {
                _TheReason = value;
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

        public string Contractcode
        {
            get
            {
                return _contractcode;
            }

            set
            {
                _contractcode = value;
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
    }
}
