using System;
using System . Collections . Generic;
using System . Text;

namespace FishEntity
{
    public class CustomStandardTableEntity
    {
        #region Model
        private int _id;
        private string _code;
        private string _ash;
        private string _protein;
        private string _xd;
        private string _fat;
        private string _ffa;
        private string _water;
        private string _histamine;
        private string _shy;
        private string _level;
        private string _fishId;
        private string _xsCode;
        private string _TVN; 

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
        /// 灰份
        /// </summary>
        public string ash
        {
            set
            {
                _ash = value;
            }
            get
            {
                return _ash;
            }
        }
        /// <summary>
        /// 蛋白
        /// </summary>
        public string protein
        {
            set
            {
                _protein = value;
            }
            get
            {
                return _protein;
            }
        }
        /// <summary>
        /// 鲜度
        /// </summary>
        public string xd
        {
            set
            {
                _xd = value;
            }
            get
            {
                return _xd;
            }
        }
        /// <summary>
        /// 脂肪
        /// </summary>
        public string fat
        {
            set
            {
                _fat = value;
            }
            get
            {
                return _fat;
            }
        }
        /// <summary>
        /// FFA
        /// </summary>
        public string ffa
        {
            set
            {
                _ffa = value;
            }
            get
            {
                return _ffa;
            }
        }
        /// <summary>
        /// 水分
        /// </summary>
        public string water
        {
            set
            {
                _water = value;
            }
            get
            {
                return _water;
            }
        }
        /// <summary>
        /// 组胺
        /// </summary>
        public string histamine
        {
            set
            {
                _histamine = value;
            }
            get
            {
                return _histamine;
            }
        }
        /// <summary>
        /// 沙和盐
        /// </summary>
        public string shy
        {
            set
            {
                _shy = value;
            }
            get
            {
                return _shy;
            }
        }
        /// <summary>
        /// 级别
        /// </summary>
        public string level
        {
            set
            {
                _level = value;
            }
            get
            {
                return _level;
            }
        }

        /// <summary>
        /// 鱼粉ID
        /// </summary>
        public string fishId
        {
            get
            {
                return _fishId;
            }

            set
            {
                _fishId = value;
            }
        }

        /// <summary>
        /// 销售申请单单号
        /// </summary>
        public string xsCode
        {
            get
            {
                return _xsCode;
            }

            set
            {
                _xsCode = value;
            }
        }

        public string TVN
        {
            get
            {
                return _TVN;
            }

            set
            {
                _TVN = value;
            }
        }
        #endregion Model
    }
}
