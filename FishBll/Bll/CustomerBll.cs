using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public  class CustomerBll
    {
        private readonly FishBll.Dao.CustomerDaoEx dal=new  Dao.CustomerDaoEx ();
        public CustomerBll()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

        public bool Exists(string code)
        {
            return dal.Exists(code);
        }

        public bool ExistsName(String name) { return dal.ExistsName(name); }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(FishEntity.CustomerEntity model)
        {
		   return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CustomerEntity model)
		{
			return dal.Update(model);
		} 

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.CustomerEntity GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.CustomerEntity > GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.CustomerEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.CustomerEntity> modelList = new List<FishEntity.CustomerEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.CustomerEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = dal.DataRowToModel(dt.Rows[n]);
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method


        public List<FishEntity.CustomerEntity> GetCustomerOfCompany(int companyId)
        {
            return dal.GetCustomerOfcompany(companyId);
        }

        public List<FishEntity.CustomerEntity> GetCustomerOfCompany(string companycode )
        {
            return dal.GetCustomerOfcompany(companycode);
        }

        public bool UpdateLinkDate(string code, DateTime  currentLinkDate , int nextLinkId , DateTime nextLinkDate)
        {
            return dal.UpdateLinkDate(code, currentLinkDate, nextLinkId, nextLinkDate);
        }

        public List<FishEntity.CustomerEntityVo> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
    }
}
