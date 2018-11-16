using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class TheproblemsheetEntityVo:TheproblemsheetEntity
    {
        private int _id;
        private string _code;
        private string _ContractNo;
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

        public string ContractNo1
        {
            get
            {
                return _ContractNo;
            }

            set
            {
                _ContractNo = value;
            }
        }
    }
}
