using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class InventoryDaoEx:InventoryDao
    {
        public DateTime GetInventoryDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select max(accountdate) from t_inventory");

            object result = MySqlHelper.GetSingle(strSql.ToString());
            if (result == null)
            {
                DateTime dd = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1,0,0,0);
                return dd;
            }
            return DateTime.Parse(result.ToString());
        }

        public bool IsInventory( DateTime date , int isAccount )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select count(1) from t_inventory where accountdate=@date and isaccount=@isaccount");
            MySqlParameter[] parameters ={
                                             new MySqlParameter("@date",MySqlDbType.Date ),
                                             new MySqlParameter("@isaccount",MySqlDbType.VarChar,45)
                                         };
            parameters[0].Value = date;
            parameters[1].Value = isAccount;

            object result = MySqlHelper.GetSingle(strSql.ToString(),parameters );
            if (result == null) return false;
            int rows = 0;
            int.TryParse( result.ToString() , out rows );
            return rows > 0 ? true : false;
        }

        public int Inventory(DateTime date, string man)
        {
            MySqlParameter [] parameters={
                                             new MySqlParameter("@v_date",MySqlDbType.Date ),
                                             new MySqlParameter("@v_man",MySqlDbType.VarChar,45),  
                                             new MySqlParameter("@v_result",MySqlDbType.Int32,8)
                                         };
            parameters[0].Value = date;
            parameters[1].Value = man;
            parameters[2].Direction = System.Data.ParameterDirection.Output;

            MySqlHelper.RunProcedureNull("p_inventory", parameters);

            int temp = 0;
            if (parameters[2].Value != null)
            {
                int.TryParse(parameters[2].Value.ToString(), out temp);
            }
            return temp;
        }
        public int InventoryBack(DateTime date, string man)
        {
            MySqlParameter[] parameters ={
                                             new MySqlParameter("@v_date",MySqlDbType.Date ),
                                             new MySqlParameter("@v_man",MySqlDbType.VarChar,45),  
                                             new MySqlParameter("@v_result",MySqlDbType.Int32,8)
                                         };
            parameters[0].Value = date;
            parameters[1].Value = man;
            parameters[2].Direction = System.Data.ParameterDirection.Output;

            MySqlHelper.RunProcedureNull("p_inventoryback", parameters);

            int temp = 0;
            if (parameters[2].Value != null)
            {
                int.TryParse(parameters[2].Value.ToString(), out temp);
            }
            return temp;
        }
    }
}
