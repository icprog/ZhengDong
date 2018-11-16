using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    [Serializable]
    public class FunCodeEntity
    {
        public FunCodeEntity()
        { }
        #region Model
        private int _funid;
        private string _funcode;
        private string _funname;
        private int _type = 0;
        private int _enable = 1;
        private string _remark;
        private int _pid;
        private int _sortid;

        public int sortid
        {
            get { return _sortid; }
            set { _sortid = value; }
        }
        /// <summary>
        /// auto_increment
        /// </summary>
        public int funid
        {
            set { _funid = value; }
            get { return _funid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string funcode
        {
            set { _funcode = value; }
            get { return _funcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string funname
        {
            set { _funname = value; }
            get { return _funname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int enable
        {
            set { _enable = value; }
            get { return _enable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pid
        {
            get { return _pid; }
            set { _pid = value; }
        }

        public string funCodeAndName
        {
            get
            {
                return _funname+" "+_funcode;
            }
        }
        #endregion Model
    }
}
