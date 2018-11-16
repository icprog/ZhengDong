﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public  class ProductExBll
    {private readonly Dao.ProductExDaoEx dal=new Dao.ProductExDaoEx();
    public ProductExBll()
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
		public bool Add(FishEntity.ProductExEntity model)
		{
			return dal.Add(model);
		}
        public bool Entry_Add(FishEntity.ProductExEntity model)
        {
            return dal.Entry_Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Entry_Update(FishEntity.ProductExEntity model)
		{
			return dal.Entry_Update(model);
		}
        public bool Update(FishEntity.ProductExEntity model)
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
			return dal.DeleteList( idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public FishEntity.ProductExEntity GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
        public FishEntity.ProductExEntity Entry_GetModel(int id)
        {

            return dal.Entry_GetModel(id);
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
        public List<FishEntity.ProductExEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.ProductExEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.ProductExEntity> modelList = new List<FishEntity.ProductExEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.ProductExEntity model;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productid"></param>
        /// <param name="weight"></param>
        /// <param name="quantity"></param>
        /// <param name="selfPrice"></param>
        /// <param name="salePrice"></param>
        public bool UpdateHomeMadeInfo(int productid, decimal storageWeight, int storageQuantity, decimal selfPrice, decimal salePrice , string  storageTime)
        {
            return dal.UpdateHomeMadeInfo(productid, storageWeight, storageQuantity, selfPrice, salePrice, storageTime);
        }

        public bool UpdateHomeMadeInfo(int productid, decimal storageWeight, int storageQuantity)
        {
            return dal.UpdateHomeMadeInfo(productid, storageWeight, storageQuantity);
        }


        public bool UpdateFoodOutInfo(FishEntity.FoodOutDetailEntityVO vo)
        {
            return dal.UpdateFoodOutInfo(vo);
        }

        public bool UpdateSaleInfo(int productid, decimal weight, int quantity)
        {
            return dal.UpdateSaleInfo(productid, weight, quantity);
        }

		#endregion  ExtensionMethod
    }
}
