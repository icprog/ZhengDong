using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class salehaDao
    {
        public bool Delete(int Saleid, int Haid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_saleha ");
            strSql.Append(" where Saleid=@Saleid and Haid=@Haid ");
            MySqlParameter[] parameters = {

                    new MySqlParameter("@Saleid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Haid", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = Saleid;
            parameters[1].Value = Haid;

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
        public bool Add(FishEntity.salehaEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_saleha(");
            strSql.Append("Saleid,Haid)");
            strSql.Append(" values (");
            strSql.Append("@Saleid,@Haid)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Saleid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Haid", MySqlDbType.Int32,11)};
            parameters[0].Value = model.Saleid;
            parameters[1].Value = model.Haid;

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
