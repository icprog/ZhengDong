using System;
namespace FishEntity
{
    public class ProcessStateEntity
    {
        public ProcessStateEntity ( )
        {

        }
        #region Model
        private int _id;
        private string _code;
        private bool? _xssqbool;
        private bool? _xssqexbool;
        private bool? _xshtbool;
        private bool? _xshtexbool;
        private char _fksqbool;
        private bool? _fksqexbool;
        private string _thdCode;
        private char? _thdbool;
        private string _bdCode;
        private char? _bdbool;
        private bool? _bdexbool;
        private string _hwfkCode;
        private char? _hwfkbool;
        private bool? _hwfkexbool;
        private string _wtfkCode;
        private char? _wtfkbool;
        private bool? _wtfkexbool;
        private char _skjlbool;
        private bool? _skjlexbool;
        private bool? _tchsbool;
        private bool? _tchsexbool;
        private DateTime? protime;
        private string _Numbering;
        private string _effect;
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
        /// 销售合同号
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
        /// 销售申请单
        /// </summary>
        public bool? xssqBool
        {
            set
            {
                _xssqbool = value;
            }
            get
            {
                return _xssqbool;
            }
        }
        /// <summary>
        /// 销售申请单是否审核
        /// </summary>
        public bool? xssqExBool
        {
            set
            {
                _xssqexbool = value;
            }
            get
            {
                return _xssqexbool;
            }
        }
        /// <summary>
        /// 销售合同
        /// </summary>
        public bool? xshtBool
        {
            set
            {
                _xshtbool = value;
            }
            get
            {
                return _xshtbool;
            }
        }
        /// <summary>
        /// 销售合同是否审核
        /// </summary>
        public bool? xshtExBool
        {
            set
            {
                _xshtexbool = value;
            }
            get
            {
                return _xshtexbool;
            }
        }
        /// <summary>
        /// 付款申请单
        /// </summary>
        public char fksqBool
        {
            set
            {
                _fksqbool = value;
            }
            get
            {
                return _fksqbool;
            }
        }
        /// <summary>
        /// 付款申请单是否审核
        /// </summary>
        public bool? fksqExBool
        {
            set
            {
                _fksqexbool = value;
            }
            get
            {
                return _fksqexbool;
            }
        }
        /// <summary>
        /// 提货单
        /// </summary>
        public char? thdBool
        {
            set
            {
                _thdbool = value;
            }
            get
            {
                return _thdbool;
            }
        }
        /// <summary>
        /// 磅单
        /// </summary>
        public char? bdBool
        {
            set
            {
                _bdbool = value;
            }
            get
            {
                return _bdbool;
            }
        }
        /// <summary>
        /// 磅单是否审核
        /// </summary>
        public bool? bdExBool
        {
            set
            {
                _bdexbool = value;
            }
            get
            {
                return _bdexbool;
            }
        }
        /// <summary>
        /// 货物反馈单
        /// </summary>
        public char? hwfkBool
        {
            set
            {
                _hwfkbool = value;
            }
            get
            {
                return _hwfkbool;
            }
        }
        /// <summary>
        /// 货物反馈单是否审核
        /// </summary>
        public bool? hwfkExBool
        {
            set
            {
                _hwfkexbool = value;
            }
            get
            {
                return _hwfkexbool;
            }
        }
        /// <summary>
        /// 问题反馈单
        /// </summary>
        public char? wtfkBool
        {
            set
            {
                _wtfkbool = value;
            }
            get
            {
                return _wtfkbool;
            }
        }
        /// <summary>
        /// 问题反馈单是否审核
        /// </summary>
        public bool? wtfkExBool
        {
            set
            {
                _wtfkexbool = value;
            }
            get
            {
                return _wtfkexbool;
            }
        }
        /// <summary>
        /// 收款记录单
        /// </summary>
        public char skjlBool
        {
            set
            {
                _skjlbool = value;
            }
            get
            {
                return _skjlbool;
            }
        }
        /// <summary>
        /// 收款记录单是否审核
        /// </summary>
        public bool? skjlExBool
        {
            set
            {
                _skjlexbool = value;
            }
            get
            {
                return _skjlexbool;
            }
        }
        /// <summary>
        /// 提成换算表
        /// </summary>
        public bool? tchsBool
        {
            set
            {
                _tchsbool = value;
            }
            get
            {
                return _tchsbool;
            }
        }
        /// <summary>
        /// 提成换算表是否审核
        /// </summary>
        public bool? tchsExBool
        {
            set
            {
                _tchsexbool = value;
            }
            get
            {
                return _tchsexbool;
            }
        }

        /// <summary>
        /// 提货单号
        /// </summary>
        public string ThdCode
        {
            get
            {
                return _thdCode;
            }

            set
            {
                _thdCode = value;
            }
        }

        /// <summary>
        /// 榜单
        /// </summary>
        public string BdCode
        {
            get
            {
                return _bdCode;
            }

            set
            {
                _bdCode = value;
            }
        }

        /// <summary>
        /// 获取反馈单单号
        /// </summary>
        public string HwfkCode
        {
            get
            {
                return _hwfkCode;
            }

            set
            {
                _hwfkCode = value;
            }
        }

        /// <summary>
        /// 问题反馈单号
        /// </summary>
        public string WtfkCode
        {
            get
            {
                return _wtfkCode;
            }

            set
            {
                _wtfkCode = value;
            }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? Protime
        {
            get
            {
                return protime;
            }

            set
            {
                protime = value;
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
        /// 状态
        /// </summary>
        public string Effect
        {
            get
            {
                return _effect;
            }

            set
            {
                _effect = value;
            }
        }
        #endregion Model
    }
}
