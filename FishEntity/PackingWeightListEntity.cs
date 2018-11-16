using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
   public class PackingWeightListEntity
    {
        public PackingWeightListEntity() { }
        private int _id;
        private string _WarehouseCode;
        private string _FishId;
        private string _CNOTANERNO;
        private string _QUANTITYOFBAGS;
        private string _GROSSWEIGHT;
        private string _NETWEIGHT;
        private string _modifyman;
        private DateTime? _modifytime;
        private string _createman;
        private DateTime? _createtime;
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
        /// <summary>
        /// 进仓单单号
        /// </summary>
        public string WarehouseCode
        {
            get
            {
                return _WarehouseCode;
            }

            set
            {
                _WarehouseCode = value;
            }
        }
        /// <summary>
        /// 鱼粉id
        /// </summary>
        public string FishId
        {
            get
            {
                return _FishId;
            }

            set
            {
                _FishId = value;
            }
        }

        public string CNOTANERNO
        {
            get
            {
                return _CNOTANERNO;
            }

            set
            {
                _CNOTANERNO = value;
            }
        }

        public string QUANTITYOFBAGS
        {
            get
            {
                return _QUANTITYOFBAGS;
            }

            set
            {
                _QUANTITYOFBAGS = value;
            }
        }

        public string GROSSWEIGHT
        {
            get
            {
                return _GROSSWEIGHT;
            }

            set
            {
                _GROSSWEIGHT = value;
            }
        }

        public string NETWEIGHT
        {
            get
            {
                return _NETWEIGHT;
            }

            set
            {
                _NETWEIGHT = value;
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
    }
}
