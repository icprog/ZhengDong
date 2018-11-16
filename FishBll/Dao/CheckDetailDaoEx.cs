using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CheckDetailDaoEx:CheckDetailDao
    {
        public List<FishEntity.CheckDetailEntity> GetCheckDetailVo(int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select a.productid,a.productcode,a.productname,a.checkunitid,a.checkunitcode,a.checkunit ,");
            strSql.Append(" b.id , b.mid, b.line ,b.checkkey,b.checkvalue,b.orderid ");
            strSql.Append("   from t_check a INNER join t_checkdetail b on a.id = b.mid");
            strSql.Append(" where a.productid="+productid);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            List<FishEntity.CheckDetailEntity> list = new List<FishEntity.CheckDetailEntity>();
            int rowCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                FishEntity.CheckDetailEntity model = DataRowToModel(ds.Tables[0].Rows[i]);
                list.Add(model);
            }
            return list;
        }
    }
}
