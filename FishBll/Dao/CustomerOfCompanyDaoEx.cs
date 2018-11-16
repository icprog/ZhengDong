using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public  class CustomerOfCompanyDaoEx : CustomerOfCompanyDao
    {
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int companyid, int customerid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_customerofcompany ");
            strSql.Append(" where companyid=@companyid and customerid=@customerid ");
            MySqlParameter[] parameters = {

					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@customerid", MySqlDbType.Int32,11)		
                                          };
            parameters[0].Value = companyid;
            parameters[1].Value = customerid;

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


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update( int sCompanyId , int sCustomerId , int dCompanyId , int dCustomerId )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_customerofcompany set ");
            strSql.Append("companyid=@dcompanyid,");
            strSql.Append("customerid=@dcustomerid");
            strSql.Append(" where companyid=@scompanyid and customerid=@scustomerid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@dcompanyid", MySqlDbType.Int32,11),
					new MySqlParameter("@dcustomerid", MySqlDbType.Int32,11),
					new MySqlParameter("@scompanyid", MySqlDbType.Int32,11),
                   	new MySqlParameter("@scustomerid", MySqlDbType.Int32,11),
                                          };
            parameters[0].Value = dCompanyId;
            parameters[1].Value = dCustomerId;
            parameters[2].Value = sCompanyId;
            parameters[3].Value = sCustomerId;

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
