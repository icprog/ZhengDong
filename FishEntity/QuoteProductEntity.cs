using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class QuoteProductEntity
    {
        #region Model
        private int _id;
        private int _no = 1;
        private string _name;
        private string _brand;
        private string _nature;
        private string _remark;
        private int _companyid;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int no
        {
            set { _no = value; }
            get { return _no; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brand
        {
            set { _brand = value; }
            get { return _brand; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nature
        {
            set { _nature = value; }
            get { return _nature; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        public int companyid
        {
            get { return _companyid; }
            set { _companyid = value; }
        }
        #endregion Model
    }
}
