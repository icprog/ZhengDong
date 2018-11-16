using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class CallRecordsDetailBll
    {
        private readonly Dao.CallRecordsDetailDao dal=new Dao.CallRecordsDetailDao();
        public CallRecordsDetailBll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id,decimal domestic_protein)
		{
			return dal.Exists(id,domestic_protein);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.CallRecordsDetailEntnty model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CallRecordsDetailEntnty model)
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
		public bool DeleteByCallRecordId( int callrecordid)
		{

            return dal.DeleteByCallRecordId( callrecordid );
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
		public FishEntity.CallRecordsDetailEntnty GetModel(int id)
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
		public List<FishEntity.CallRecordsDetailEntnty> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.CallRecordsDetailEntnty> DataTableToList(DataTable dt)
		{
			List<FishEntity.CallRecordsDetailEntnty> modelList = new List<FishEntity.CallRecordsDetailEntnty>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.CallRecordsDetailEntnty model;
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

        public List<FishEntity.CallRecordsDetailEntnty> GetRecordListByCompanyCode(string companycode)
        {
            return dal.GetRecordListByCompanyCode( companycode);
        }

        public List<FishEntity.CallRecordsDetailEntnty> GetRecordListByWhere(string where)
        {
            return dal.GetRecordListByWhere(where);
        }

        public List<FishEntity.CallRecordDetailEntityEx> GetRecordDetailListByWhere(string where)
        {
            return dal.GetRecordDetailListByWhere(where);
        }

		#endregion  ExtensionMethod
    }
}
