using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class TheproblemsheetEntity
    {
        public TheproblemsheetEntity() { }
        private int _id;
        private string _code;
        private string _ContractNo;
        private DateTime? _occurDate;
        private string _EventName;
        private string _SolvTtheProblem;
        private string _Remarks;
        private string _codeContract;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        private decimal _Chargeback;
        private string _Numbering;
        private string _FishMealId;
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

        public string codeContract
        {
            get
            {
                return _codeContract;
            }
            set
            {
                _codeContract = value;
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

        public string ContractNo
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

        public DateTime? OccurDate
        {
            get
            {
                return _occurDate;
            }

            set
            {
                _occurDate = value;
            }
        }

        public string EventName
        {
            get
            {
                return _EventName;
            }

            set
            {
                _EventName = value;
            }
        }

        public string SolvTtheProblem
        {
            get
            {
                return _SolvTtheProblem;
            }

            set
            {
                _SolvTtheProblem = value;
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
        /// <summary>
        /// 扣款
        /// </summary>
        public decimal Chargeback
        {
            get
            {
                return _Chargeback;
            }

            set
            {
                _Chargeback = value;
            }
        }
        /// <summary>
        /// 编号
        /// </summary>
        public string Numbering
        {
            get
            {
                return _Numbering;
            }

            set
            {
                _Numbering = value;
            }
        }
        /// <summary>
        /// 鱼粉Id
        /// </summary>
        public string FishMealId
        {
            get
            {
                return _FishMealId;
            }

            set
            {
                _FishMealId = value;
            }
        }
    }
}
