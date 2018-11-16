using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class CustomerOfCompanyEntity
    {  
		public CustomerOfCompanyEntity()
		{}
		#region Model
		private int _id;
		private int _companyid;
		private int _customerid;
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
		public int companyid
		{
			set{ _companyid=value;}
			get{return _companyid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int customerid
		{
			set{ _customerid=value;}
			get{return _customerid;}
		}
		#endregion Model

	}    
}
