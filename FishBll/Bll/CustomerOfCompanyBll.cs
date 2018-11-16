using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class CustomerOfCompanyBll
    {
        private readonly FishBll.Dao.CustomerOfCompanyDaoEx dal=new FishBll.Dao.CustomerOfCompanyDaoEx();
        public CustomerOfCompanyBll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id,int companyid,int customerid)
		{
			return dal.Exists(id,companyid,customerid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FishEntity.CustomerOfCompanyEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CustomerOfCompanyEntity model)
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
		public bool Delete(int id,int companyid,int customerid)
		{
			
			return dal.Delete(id,companyid,customerid);
		}

        public bool Delete(int companyid, int customerid)
        {
            return dal.Delete(companyid, customerid);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList( idlist  );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.CustomerOfCompanyEntity GetModel(int id)
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
		public List<FishEntity.CustomerOfCompanyEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.CustomerOfCompanyEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.CustomerOfCompanyEntity> modelList = new List<FishEntity.CustomerOfCompanyEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.CustomerOfCompanyEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod


        public bool Update(int sCompanyId, int sCustomerId,int dCompanyId, int dCustomerId )
        {
            return dal.Update(sCompanyId, sCustomerId, dCompanyId, dCustomerId);
        }

		#endregion  ExtensionMethod
    }
}
