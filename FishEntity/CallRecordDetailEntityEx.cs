using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CallRecordDetailEntityEx : CallRecordsDetailEntnty
    {
        private DateTime _currentdate;

        protected DateTime Currentdate
        {
            get { return _currentdate; }
            set { _currentdate = value; }
        }
        private DateTime _nextdate;

        public DateTime Nextdate
        {
            get { return _nextdate; }
            set { _nextdate = value; }
        }
        private string _linkmancode;

        public string Linkmancode
        {
            get { return _linkmancode; }
            set { _linkmancode = value; }
        }
        private string _linkman;

        public string Linkman
        {
            get { return _linkman; }
            set { _linkman = value; }
        }
        private string _communicatecontent;

        public string Communicatecontent
        {
            get { return _communicatecontent; }
            set { _communicatecontent = value; }
        }
        private string _code;

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private string _cgyx = "";

        public string Cgyx
        {
            get { return _cgyx; }
            set { _cgyx = value; }
        }

        private string _bjqk = "";

        public string Bjqk
        {
            get { return _bjqk; }
            set { _bjqk = value; }
        }

    }
}
