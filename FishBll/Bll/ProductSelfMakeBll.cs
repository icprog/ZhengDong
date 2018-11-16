using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public  class ProductSelfMakeBll
    {
        protected Dao.ProductSelfMakeDao _dal = new Dao.ProductSelfMakeDao();
        public List<FishEntity.ProductSelfMakeVo> GetSelfMake(string where)
        {
            DataSet dsData = _dal.GetSelfMake(where);
            return DataTableToList(dsData.Tables[0]);
        }
        public List<FishEntity.ProductSelfMakeVo> GetNewSelfMake(string where)
        {
            DataSet dsData = _dal.GetNewSelfMake(where);
            return NewDataTableToList(dsData.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.ProductSelfMakeVo> DataTableToList(DataTable dt)
        {
            List<FishEntity.ProductSelfMakeVo> modelList = new List<FishEntity.ProductSelfMakeVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductSelfMakeVo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = _dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public List<FishEntity.ProductSelfMakeVo> NewDataTableToList(DataTable dt)
        {
            List<FishEntity.ProductSelfMakeVo> modelList = new List<FishEntity.ProductSelfMakeVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductSelfMakeVo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = _dal.NewDataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
    }
}
