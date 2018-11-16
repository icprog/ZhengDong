using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
    public class SalesAssessmentDao
    {
        public SalesAssessmentDao() { }
        public DataTable getTable(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_salesassessment  ");
            strSql.Append("where " + where);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
    }
}
