using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class PurchaseOtherInfo
    {
        public PurchaseOtherInfo ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private string _brand;
        private decimal? _money;
        private decimal? _num;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 采购申请单编号
        /// </summary>
        public string code
        {
            set
            {
                _code = value;
            }
            get
            {
                return _code;
            }
        }
        /// <summary>
        /// 减价规格
        /// </summary>
        public string brand
        {
            set
            {
                _brand = value;
            }
            get
            {
                return _brand;
            }
        }
        /// <summary>
        /// 减价金额
        /// </summary>
        public decimal? money
        {
            set
            {
                _money = value;
            }
            get
            {
                return _money;
            }
        }
        /// <summary>
        /// 减价重量
        /// </summary>
        public decimal? num
        {
            set
            {
                _num = value;
            }
            get
            {
                return _num;
            }
        }
        #endregion Model

    }
}
