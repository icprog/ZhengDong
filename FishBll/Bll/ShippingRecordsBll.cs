using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class ShippingRecordsBll
    {
        private readonly Dao.ShippingRecordsDao dal = new Dao.ShippingRecordsDao();
        public ShippingRecordsBll() { }
        public int add(FishEntity.ShippingRecordsEntity model) {
            return dal.Add(model);
        }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public List<FishEntity.ShippingRecordsEntity> GetQuery(string where)
        {
            DataSet dsData = dal.GetQuery(where);
            return DataTableToList(dsData.Tables[0]);
        }
        public List<FishEntity.ShippingRecordsEntity> DataTableToList(DataTable dt)
        {
            List<FishEntity.ShippingRecordsEntity> modelList = new List<FishEntity.ShippingRecordsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ShippingRecordsEntity model;
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
        public bool Update(FishEntity.ShippingRecordsEntity model)
        {
            return dal.Update(model);
        }
    }
}
