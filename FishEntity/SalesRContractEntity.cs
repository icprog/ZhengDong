using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class SalesRContractEntity
    {
        public SalesRContractEntity() { }
        private int _id;
        private string _product_id;
        /// <summary>
        /// id
        /// </summary>
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
        private string _Numbering;
        /// <summary>
        /// 销售编号
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
        private DateTime _Signdate;
        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime Signdate
        {
            get
            {
                return _Signdate;
            }

            set
            {
                _Signdate = value;
            }
        }
        private string _ContractCode;
        /// <summary>
        /// 销售合同编号
        /// </summary>
        public string ContractCode
        {
            get
            {
                return _ContractCode;
            }

            set
            {
                _ContractCode = value;
            }
        }

        private string _Signplace;
        /// <summary>
        /// 签订地址
        /// </summary>
        public string Signplace
        {
            get
            {
                return _Signplace;
            }

            set
            {
                _Signplace = value;
            }
        }


        private string _supplier;
        /// <summary>
        /// 供方
        /// </summary>
        public string Supplier
        {
            get
            {
                return _supplier;
            }

            set
            {
                _supplier = value;
            }
        }
        private string _demand;
        /// <summary>
        /// 需方
        /// </summary>
        public string Demand
        {
            get
            {
                return _demand;
            }

            set
            {
                _demand = value;
            }
        }
        private string _createman;
        /// <summary>
        /// 创建人
        /// </summary>
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

        private DateTime createtime;
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Createtime
        {
            get
            {
                return createtime;
            }

            set
            {
                createtime = value;
            }
        }

        public DateTime Modifytime
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

        public string Product_id
        {
            get
            {
                return _product_id;
            }

            set
            {
                _product_id = value;
            }
        }

        private DateTime _modifytime;
        private string _modifyman;
    }
}
