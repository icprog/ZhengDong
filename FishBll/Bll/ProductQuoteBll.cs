using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Bll
{
    public class ProductQuoteBll
    {
        protected Dao.ProductQuoteDao _dal = new Dao.ProductQuoteDao();

        public List<FishEntity.ProductQuoteVo> GetQuote(string where)
        {
            DataSet dsData = _dal.GetQuote(where);
            return DataTableToList(dsData.Tables[0]);
        }

        /// <summary>
		/// 获得数据列表
		/// </summary>
        public List<FishEntity.ProductQuoteVo> DataTableToList(DataTable dt)
        {
            List<FishEntity.ProductQuoteVo> modelList = new List<FishEntity.ProductQuoteVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductQuoteVo model;
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
