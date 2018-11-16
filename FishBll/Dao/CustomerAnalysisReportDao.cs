using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Dao
{
    public class CustomerAnalysisReportDao
    {
        public List<FishEntity.CompanyEntity> Reports(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_company ");
            if (false == string.IsNullOrEmpty(where))
            {
                strSql.Append( " where  " +where);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            int rowcount = ds.Tables[0].Rows.Count;
            List<FishEntity.CompanyEntity> list = new List<FishEntity.CompanyEntity>();
            for (int i = 0; i < rowcount; i++)
            {
                FishEntity.CompanyEntity model = new FishEntity.CompanyEntity();
                DataRow row = ds.Tables[0].Rows[i];
                model = CompanyDao.DataRowToModel ( row );
                list.Add(model);
            }
            return list;
        }
    }
}
