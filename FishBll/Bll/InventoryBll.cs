using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class InventoryBll
    {
        private readonly Dao.InventoryDaoEx dal=new Dao.InventoryDaoEx();
        public InventoryBll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(FishEntity.InventoryEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.InventoryEntity model)
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
		public FishEntity.InventoryEntity GetModel(int id)
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
		public List<FishEntity.InventoryEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.InventoryEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.InventoryEntity> modelList = new List<FishEntity.InventoryEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.InventoryEntity model;
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

        public DateTime GetInventoryDate()
        {
            return dal.GetInventoryDate();
        }

        /// <summary>
        /// 判断是否已经月结
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool IsInventory( DateTime date , int isaccount )
        {
            return dal.IsInventory(date , isaccount );
        }

        /// <summary>
        /// 月结
        /// </summary>
        /// <param name="data"></param>
        /// <param name="man"></param>
        /// <returns></returns>
        public int Inventory( DateTime data , string man )
        {
            return  dal.Inventory(data, man);
        }

        /// <summary>
        /// 反月结
        /// </summary>
        /// <param name="data"></param>
        /// <param name="man"></param>
        /// <returns></returns>
        public int InventoryBack(DateTime data, string man)
        {
            return dal.InventoryBack(data, man);
        }

		#endregion  ExtensionMethod
    }
}
