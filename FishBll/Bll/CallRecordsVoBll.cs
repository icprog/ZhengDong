using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
   public class CallRecordsVoBll
    {
        private readonly Dao.CallRecordsDao _dal = new Dao.CallRecordsDao();
        public List<FishEntity.CallRecordsEntity> GetSpot(string where)
        {
            DataSet dsData = _dal.GetSpot(where);
            return DataTableToList(dsData.Tables[0]);
        }
        public List<FishEntity.CallRecordsEntity> DataTableToList(DataTable dt)
        {
            List<FishEntity.CallRecordsEntity> modelList = new List<FishEntity.CallRecordsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.CallRecordsEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = _dal.DataRowToModel22(dt.Rows[n]);
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

