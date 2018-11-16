using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Bll
{
    public class FinishBll
    {
        private readonly Dao.FinishDao dal = new Dao.FinishDao();
        public FinishBll()
        { }
        public List<FishEntity.FinishVo> GetData(string strwhere)
        {
            return dal.GetData(strwhere);
        }
        public List<FishEntity.ProductSpotVo> Getlist(string where)
        {
            DataSet dsData = dal.GetFinish(where);
            return DataTableToList(dsData.Tables[0]);
        }
        public List<FishEntity.ProductSpotVo> DataTableToList(DataTable dt)
        {
            List<FishEntity.ProductSpotVo> modelList = new List<FishEntity.ProductSpotVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductSpotVo model;
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
        /// 有效性
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="effect"></param>
        /// <returns></returns>
        public bool update(FishEntity.ProductEntity model,string  names)
        {
            return dal.update(model, names);
        }
        public bool update(FishEntity.ProductEntity model)
        {
            return dal.update(model);
        }
    }

}
