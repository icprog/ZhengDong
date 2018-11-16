using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class ProductBll
    { 
        private readonly Dao.ProductDaoEx dal=new Dao.ProductDaoEx();
        /// <summary>
        /// 增删茶馆
        /// </summary>
        public ProductBll()
		{}
		#region  BasicMethod
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

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.ProductEntity model)
		{
			return dal.Add(model);
		}
        public int Entry_Add(FishEntity.ProductEntity model)
        {
            return dal.Entry_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FishEntity.ProductEntity model)
		{
			return dal.Update(model);
		}
        public bool Entry_Update(FishEntity.ProductEntity model)
        {
            return dal.Entry_Update(model);
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
			return dal.DeleteList( idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.ProductEntity GetModel(int id)
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
		public List<FishEntity.ProductEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public List<FishEntity.ProductEntity> Entry_GetModelList(string strWhere)
        {
            DataSet ds = dal.Entry_GetList(strWhere);
            return Entry_DataTableToList(ds.Tables[0]);
        }
        public List<FishEntity.ProductEntity> Entry_DataTableToList(DataTable dt)
        {
            List<FishEntity.ProductEntity> modelList = new List<FishEntity.ProductEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = Dao.ProductDao.Entry_DataRowToModel(dt.Rows[n]);
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
        public List<FishEntity.ProductEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.ProductEntity > modelList = new List<FishEntity.ProductEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.ProductEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = Dao.ProductDao .DataRowToModel(dt.Rows[n]);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="state"></param>
        /// <param name="quantity"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        public bool UpdateState(int productId, int state , int quantity , decimal weight )
        {
            return dal.UpdateState(productId, state , quantity , weight );
        }

        public bool UpdateHomemade(int productid, decimal weight , decimal cost, int number)
        {
            return dal.UpdateHomemade(productid, weight , cost, number);
        }

        public bool UpdateRemainWeightQuantity(int productId, decimal weight, int quantity)
        {
            return dal.UpdateRemainWeightQuantity(productId, weight, quantity);
        }

        public bool UpdateHomemadeWeightQuantity(int productId, decimal weight, int quantity)
        {
            return dal.UpdateHomemadeWeightQuantity(productId, weight, quantity);
        }

        public bool UpdateHomemadeWeightQuantityCost(int productId, decimal weight, int quantity, decimal cost)
        {
            return dal.UpdateHomemadeWeightQuantityCost(productId, weight, quantity, cost);
        }


        public List<FishEntity.ProductVo> GetModelListVo(string strWhere)
        {
            DataSet ds = dal.GetListVo(strWhere);
            return dal.DataTableToList(ds.Tables[0]);
        }

        public bool UpdateFoodOutInfo(FishEntity.FoodOutDetailEntityVO vo)
        {
            return dal.UpdateFoodOutInfo(vo);
        }

        public bool UpdateCheckRecord(FishEntity.CheckRecordEntity vo)
        {
            return dal.UpdateCheckRecord(vo);
        }

		#endregion  ExtensionMethod
    }
}
