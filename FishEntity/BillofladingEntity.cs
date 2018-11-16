using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class BillofladingEntity
    {
        public BillofladingEntity() { }
        private string _FishMealId;
        private string _Country;
        private string _Brands;
        private int _id;
        private string _code;
        private DateTime? _Issuingtime;
        private string _contactsunit;
        private string _contactsunitId;
        private string _warehouse;
        private string _species;
        private string _specification;
        private string _ferryname;
        private string _listname;
        private string _Ton;
        private string _packagenumber;
        private string _Remarks;
        private string _ShipNotice;
        private string _Storagecosts;
        private DateTime? _createtime;
        private string _createman;
        private DateTime? _modifytime;
        private string _modifyman;
        private string _codeContract;
        private string _recipient;
        private string _cornerno;
        private string _SerialNumber;
        private string _Numbering;
        private decimal? _RedemptionWeight;
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

        public DateTime? Issuingtime
        {
            get
            {
                return _Issuingtime;
            }

            set
            {
                _Issuingtime = value;
            }
        }
        /// <summary>
        /// 提货单位
        /// </summary>
        public string Contactsunit
        {
            get
            {
                return _contactsunit;
            }

            set
            {
                _contactsunit = value;
            }
        }

        public string Warehouse
        {
            get
            {
                return _warehouse;
            }

            set
            {
                _warehouse = value;
            }
        }

        public string Species
        {
            get
            {
                return _species;
            }

            set
            {
                _species = value;
            }
        }

        public string Specification
        {
            get
            {
                return _specification;
            }

            set
            {
                _specification = value;
            }
        }

        public string Ferryname
        {
            get
            {
                return _ferryname;
            }

            set
            {
                _ferryname = value;
            }
        }

        public string Listname
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

        public string Ton
        {
            get
            {
                return _Ton;
            }

            set
            {
                _Ton = value;
            }
        }

        public string Packagenumber
        {
            get
            {
                return _packagenumber;
            }

            set
            {
                _packagenumber = value;
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

        public string ShipNotice
        {
            get
            {
                return _ShipNotice;
            }

            set
            {
                _ShipNotice = value;
            }
        }

        public string Storagecosts
        {
            get
            {
                return _Storagecosts;
            }

            set
            {
                _Storagecosts = value;
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

        public string Recipient
        {
            get
            {
                return _recipient;
            }

            set
            {
                _recipient = value;
            }
        }

        public string Cornerno
        {
            get
            {
                return _cornerno;
            }

            set
            {
                _cornerno = value;
            }
        }
        /// <summary>
        /// 提货单位Id
        /// </summary>
        public string ContactsunitId
        {
            get
            {
                return _contactsunitId;
            }

            set
            {
                _contactsunitId = value;
            }
        }
        /// <summary>
        /// 序号
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return _SerialNumber;
            }

            set
            {
                _SerialNumber = value;
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
        /// <summary>
        /// 国别
        /// </summary>
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
        /// <summary>
        /// 品牌
        /// </summary>
        public string Brands
        {
            get
            {
                return _Brands;
            }

            set
            {
                _Brands = value;
            }
        }
        /// <summary>
        /// 赎单重量
        /// </summary>
        public decimal? RedemptionWeight
        {
            get
            {
                return _RedemptionWeight;
            }

            set
            {
                _RedemptionWeight = value;
            }
        }
    }
}
