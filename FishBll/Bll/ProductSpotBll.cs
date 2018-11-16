using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
   public   class ProductSpotBll
   {
       protected Dao.ProductSpotDao _dal = new Dao.ProductSpotDao();

       public List<FishEntity.ProductSpotVo> GetSpot(string where)
       {
           DataSet dsData = _dal.GetSpot(where);
           return DataTableToList(dsData.Tables[0]);
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public List<FishEntity.ProductSpotVo> DataTableToList(DataTable dt)
       {
           List<FishEntity.ProductSpotVo> modelList = new List<FishEntity.ProductSpotVo>();
           int rowsCount = dt.Rows.Count;
           if (rowsCount > 0)
           {
               FishEntity.ProductSpotVo model;
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
    }
}
