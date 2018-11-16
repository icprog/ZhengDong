using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class BatchSheetEntity
    {
        public BatchSheetEntity ( )
        {

        }

        #region Model
        private int _id;
        private string _code;
        private DateTime? _productiondate;
        /// <summary>
        /// auto_increment
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
        /// 单号
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
        /// 生产时间
        /// </summary>
        public DateTime? productionDate
        {
            set
            {
                _productiondate = value;
            }
            get
            {
                return _productiondate;
            }
        }
        #endregion Model

    }
}
