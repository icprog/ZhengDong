using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class DeliveredManagementEntity
    {
        public DeliveredManagementEntity() { }
        private int  _id;
        private string _cmbTJxssqd;
        private string _txtTJxssqd;
        private string _cmbSGxssqd;
        private string _txtSGxssqd;
        private string _cmbTJxsht;
        private string _txtTJxsht;
        private string _cmbSGxsht;
        private string _txtSGxsht;
        private string _cmbTJfksqd;
        private string _txtTJfksqd;
        private string _cmbSGfksqd;
        private string _txtSGfksqd;
        private string _cmbTJbd;
        private string _txtTJbd;
        private string _cmbSGbd;
        private string _txtSGbd;
        private string _cmbTJhwfkd;
        private string _txtTJhwfkd;
        private string _cmbSGhwfkd;
        private string _txtSGhwfkd;
        private string _cmbTJgswtfkd;
        private string _txtTJgswtfkd;
        private string _cmbSGgswtfkd;
        private string _txtSGgswtfkd;
        private string _cmbTJskjld;
        private string _txtTJskjld;
        private string _cmbSGskjld;
        private string _txtSGskjld;
        private DateTime _createtime = DateTime.Now;
        private string _createman;
        private DateTime _modifytime = DateTime.Now;
        private string _modifyman;

        private string _tablePro;
        private string _reviewDepart;
        private string _reviewUser;
        private string _examinDepart;
        private string _examinUser;

        public int id
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

        public string cmbTJxssqd
        {
            get
            {
                return _cmbTJxssqd;
            }

            set
            {
                _cmbTJxssqd = value;
            }
        }

        public string txtTJxssqd
        {
            get
            {
                return _txtTJxssqd;
            }

            set
            {
                _txtTJxssqd = value;
            }
        }

        public string cmbSGxssqd
        {
            get
            {
                return _cmbSGxssqd;
            }

            set
            {
                _cmbSGxssqd = value;
            }
        }

        public string txtSGxssqd
        {
            get
            {
                return _txtSGxssqd;
            }

            set
            {
                _txtSGxssqd = value;
            }
        }

        public string cmbTJxsht
        {
            get
            {
                return _cmbTJxsht;
            }

            set
            {
                _cmbTJxsht = value;
            }
        }

        public string txtTJxsht
        {
            get
            {
                return _txtTJxsht;
            }

            set
            {
                _txtTJxsht = value;
            }
        }

        public string cmbSGxsht
        {
            get
            {
                return _cmbSGxsht;
            }

            set
            {
                _cmbSGxsht = value;
            }
        }

        public string txtSGxsht
        {
            get
            {
                return _txtSGxsht;
            }

            set
            {
                _txtSGxsht = value;
            }
        }

        public string cmbTJfksqd
        {
            get
            {
                return _cmbTJfksqd;
            }

            set
            {
                _cmbTJfksqd = value;
            }
        }

        public string txtTJfksqd
        {
            get
            {
                return _txtTJfksqd;
            }

            set
            {
                _txtTJfksqd = value;
            }
        }

        public string cmbSGfksqd
        {
            get
            {
                return _cmbSGfksqd;
            }

            set
            {
                _cmbSGfksqd = value;
            }
        }

        public string txtSGfksqd
        {
            get
            {
                return _txtSGfksqd;
            }

            set
            {
                _txtSGfksqd = value;
            }
        }

        public string cmbTJbd
        {
            get
            {
                return _cmbTJbd;
            }

            set
            {
                _cmbTJbd = value;
            }
        }

        public string txtTJbd
        {
            get
            {
                return _txtTJbd;
            }

            set
            {
                _txtTJbd = value;
            }
        }

        public string cmbSGbd
        {
            get
            {
                return _cmbSGbd;
            }

            set
            {
                _cmbSGbd = value;
            }
        }

        public string txtSGbd
        {
            get
            {
                return _txtSGbd;
            }

            set
            {
                _txtSGbd = value;
            }
        }

        public string cmbTJhwfkd
        {
            get
            {
                return _cmbTJhwfkd;
            }

            set
            {
                _cmbTJhwfkd = value;
            }
        }

        public string txtTJhwfkd
        {
            get
            {
                return _txtTJhwfkd;
            }

            set
            {
                _txtTJhwfkd = value;
            }
        }

        public string cmbSGhwfkd
        {
            get
            {
                return _cmbSGhwfkd;
            }

            set
            {
                _cmbSGhwfkd = value;
            }
        }

        public string txtSGhwfkd
        {
            get
            {
                return _txtSGhwfkd;
            }

            set
            {
                _txtSGhwfkd = value;
            }
        }

        public string cmbTJgswtfkd
        {
            get
            {
                return _cmbTJgswtfkd;
            }

            set
            {
                _cmbTJgswtfkd = value;
            }
        }

        public string txtTJgswtfkd
        {
            get
            {
                return _txtTJgswtfkd;
            }

            set
            {
                _txtTJgswtfkd = value;
            }
        }

        public string cmbSGgswtfkd
        {
            get
            {
                return _cmbSGgswtfkd;
            }

            set
            {
                _cmbSGgswtfkd = value;
            }
        }

        public string txtSGgswtfkd
        {
            get
            {
                return _txtSGgswtfkd;
            }

            set
            {
                _txtSGgswtfkd = value;
            }
        }

        public string cmbTJskjld
        {
            get
            {
                return _cmbTJskjld;
            }

            set
            {
                _cmbTJskjld = value;
            }
        }

        public string txtTJskjld
        {
            get
            {
                return _txtTJskjld;
            }

            set
            {
                _txtTJskjld = value;
            }
        }

        public string cmbSGskjld
        {
            get
            {
                return _cmbSGskjld;
            }

            set
            {
                _cmbSGskjld = value;
            }
        }

        public string txtSGskjld
        {
            get
            {
                return _txtSGskjld;
            }

            set
            {
                _txtSGskjld = value;
            }
        }

        public DateTime createtime
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

        public string createman
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

        public DateTime modifytime
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

        public string modifyman
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

        /// <summary>
        /// 程序名称
        /// </summary>
        public string TablePro
        {
            get
            {
                return _tablePro;
            }

            set
            {
                _tablePro = value;
            }
        }

        /// <summary>
        /// 送审部门
        /// </summary>
        public string ReviewDepart
        {
            get
            {
                return _reviewDepart;
            }

            set
            {
                _reviewDepart = value;
            }
        }

        /// <summary>
        /// 送审人
        /// </summary>
        public string ReviewUser
        {
            get
            {
                return _reviewUser;
            }

            set
            {
                _reviewUser = value;
            }
        }

        /// <summary>
        /// 审核部门
        /// </summary>
        public string ExaminDepart
        {
            get
            {
                return _examinDepart;
            }

            set
            {
                _examinDepart = value;
            }
        }

        /// <summary>
        /// 审核人
        /// </summary>
        public string ExaminUser
        {
            get
            {
                return _examinUser;
            }

            set
            {
                _examinUser = value;
            }
        }
    }
}
