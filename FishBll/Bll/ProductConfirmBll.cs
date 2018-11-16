using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class ProductConfirmBll
    {
        protected Dao.ProductConfirmDao _dal = new Dao.ProductConfirmDao();

        public List<FishEntity.ProductConfirmVo> GetConfirm(string where)
        {
            DataSet dsData = _dal.GetConfirm(where);
            return DataTableToList(dsData.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.ProductConfirmVo> DataTableToList(DataTable dt)
        {
            List<FishEntity.ProductConfirmVo> modelList = new List<FishEntity.ProductConfirmVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductConfirmVo model;
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
