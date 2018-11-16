using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class salesgsDao
    {
        public bool Delete(int Saleid, int SGSid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_salesgs ");
            strSql.Append(" where Saleid=@Saleid and SGSid=@SGSid ");
            MySqlParameter[] parameters = {

                    new MySqlParameter("@Saleid", MySqlDbType.Int32,11),
                    new MySqlParameter("@SGSid", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = Saleid;
            parameters[1].Value = SGSid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Add(FishEntity.t_salesgs model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_salesgs(");
            strSql.Append("SGSid,Saleid)");
            strSql.Append(" values (");
            strSql.Append("@SGSid,@Saleid)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@SGSid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Saleid", MySqlDbType.Int32,11)};
            parameters[0].Value = model.SGSid1;
            parameters[1].Value = model.Saleid1;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
