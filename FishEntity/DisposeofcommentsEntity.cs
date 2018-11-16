using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class DisposeofcommentsEntity
    {
        public DisposeofcommentsEntity(){}
        private int _id;
        private string _code;
        private string _Filenumber;
        private string _Todealwith;
        private string _Treatmentmeasures;
        private string _DepartmentManagerOpinion;
        private DateTime? _Managerdate;
        private string _CompanyOpinion;
        private DateTime? _Companydate;
        private string _ResultOfDiscussion;
        private DateTime? _Discussdate;
        private string _PersonAgreesToSign;
        private string _Remarks;
        private string _createman;
        private DateTime? _createtime = DateTime.Now;
        private string _modifyman;
        private DateTime? _modifytime = DateTime.Now;

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

        public string Filenumber
        {
            get
            {
                return _Filenumber;
            }

            set
            {
                _Filenumber = value;
            }
        }

        public string Todealwith
        {
            get
            {
                return _Todealwith;
            }

            set
            {
                _Todealwith = value;
            }
        }

        public string Treatmentmeasures
        {
            get
            {
                return _Treatmentmeasures;
            }

            set
            {
                _Treatmentmeasures = value;
            }
        }

        public string DepartmentManagerOpinion
        {
            get
            {
                return _DepartmentManagerOpinion;
            }

            set
            {
                _DepartmentManagerOpinion = value;
            }
        }

        public DateTime? Managerdate
        {
            get
            {
                return _Managerdate;
            }

            set
            {
                _Managerdate = value;
            }
        }



        public DateTime? Companydate
        {
            get
            {
                return _Companydate;
            }

            set
            {
                _Companydate = value;
            }
        }

        public string ResultOfDiscussion
        {
            get
            {
                return _ResultOfDiscussion;
            }

            set
            {
                _ResultOfDiscussion = value;
            }
        }

        public DateTime? Discussdate
        {
            get
            {
                return _Discussdate;
            }

            set
            {
                _Discussdate = value;
            }
        }

        public string PersonAgreesToSign
        {
            get
            {
                return _PersonAgreesToSign;
            }

            set
            {
                _PersonAgreesToSign = value;
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

        public string CompanyOpinion
        {
            get
            {
                return _CompanyOpinion;
            }

            set
            {
                _CompanyOpinion = value;
            }
        }
    }
}
