using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class SequenceEntity
    {
        public SequenceEntity()
        { }
        #region Model
        private int _id;
        private string _key;
        private string _prefix;
        private string _separator;
        private int _step = 1;
        private int _maxseq = 0;
        private string _description;
        private DateTime _createtime = DateTime.Now;
        private string _createman;
        private DateTime _modifytime = DateTime.Now;
        private string _modifyman;
        private int _isdelete = 0;
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
        public string key
        {
            set { _key = value; }
            get { return _key; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string prefix
        {
            set { _prefix = value; }
            get { return _prefix; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string separator
        {
            set { _separator = value; }
            get { return _separator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int step
        {
            set { _step = value; }
            get { return _step; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int maxseq
        {
            set { _maxseq = value; }
            get { return _maxseq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime createtime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string createman
        {
            set { _createman = value; }
            get { return _createman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime modifytime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string modifyman
        {
            set { _modifyman = value; }
            get { return _modifyman; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int isdelete
        {
            set { _isdelete = value; }
            get { return _isdelete; }
        }
        #endregion Model

    }
}

