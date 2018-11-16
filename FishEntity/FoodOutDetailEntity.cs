using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class FoodOutDetailEntity
    {

        public FoodOutDetailEntity()
		{}
		#region Model
		private int _id;
		private int _mid;
		private int _productid;
		private decimal _tons=0.00M;
		private int _package=0;
        private decimal _cost = 0.00M;
        private decimal _unitprice = 0.00M;
        private int _no = 1;
        private int _solutionid = 1;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int mid
		{
			set{ _mid=value;}
			get{return _mid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int productid
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal tons
		{
			set{ _tons=value;}
			get{return _tons;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int package
		{
			set{ _package=value;}
			get{return _package;}
		}
        /// <summary>
        /// 
        /// </summary>
        public decimal cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal unitprice
        {
            get { return _unitprice; }
            set { _unitprice = value; }
        }
        public int no
        {
            get { return _no; }
            set { _no = value; }
        }
        public int solutionid
        {
            get { return _solutionid; }
            set { _solutionid = value; }
        }
		#endregion Model
    }
}
