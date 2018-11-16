using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Windows.Forms;

namespace FishBll.Dao
{
    public class TheproblemsheetDao
    {


        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_Theproblemsheet");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否所属
        /// </summary>
        /// <param name="code"></param>
        /// <param name="createman"></param>
        /// <returns></returns>
        public bool ExistsUpdate(string code,string createman)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from t_Theproblemsheet");
            strSql.Append(" where code=@code and createman=@createman");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45)
            };
            parameters[0].Value = code;
            parameters[1].Value = createman;
            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.TheproblemsheetEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_theproblemsheet(Numbering,code, ContractNo, occurDate, EventName, SolvTtheProblem, Remarks, createtime, createman, modifytime, modifyman,codeContract,Chargeback,FishMealId) ");
            strSql.Append("values(@Numbering,@code, @ContractNo, @occurDate, @EventName, @SolvTtheProblem, @Remarks, @createtime, @createman, @modifytime, @modifyman,@codeContract,@Chargeback,@FishMealId); select last_insert_id();");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@ContractNo",MySqlDbType.VarChar,45),
                new MySqlParameter("@occurDate",MySqlDbType.DateTime),
                new MySqlParameter("@EventName",MySqlDbType.VarChar,500),
                new MySqlParameter("@SolvTtheProblem",MySqlDbType.VarChar,500),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@Chargeback",MySqlDbType.Decimal,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.ContractNo;
            parameters[2].Value = model.OccurDate;
            parameters[3].Value = model.EventName;
            parameters[4].Value = model.SolvTtheProblem;
            parameters[5].Value = model.Remarks;
            parameters[6].Value = model.Createtime;
            parameters[7].Value = model.Createman;
            parameters[8].Value = model.Modifytime;
            parameters[9].Value = model.Modifyman;
            parameters [ 10 ] . Value = model . codeContract;
            parameters[11].Value = model.Chargeback;
            parameters[12].Value = model.Numbering;
            parameters[13].Value = model.FishMealId;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters); 
            return id;
        }
        public int Add ( FishEntity . TheproblemsheetEntity model ,string name )
        {
            Hashtable SQLString = new Hashtable ( );
            SQLString=ReviewInfo . getSQLString ( name ,model . Code ,string . Empty ,SQLString);

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_theproblemsheet(Numbering,code, ContractNo, occurDate, EventName, SolvTtheProblem, Remarks, createtime, createman, modifytime, modifyman,codeContract,Chargeback,FishMealId) " );
            strSql . Append ( "values(@Numbering,@code, @ContractNo, @occurDate, @EventName, @SolvTtheProblem, @Remarks, @createtime, @createman, @modifytime, @modifyman,@codeContract,@Chargeback,@FishMealId); " );//select last_insert_id();
            MySqlParameter [ ] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@ContractNo",MySqlDbType.VarChar,45),
                new MySqlParameter("@occurDate",MySqlDbType.DateTime),
                new MySqlParameter("@EventName",MySqlDbType.VarChar,500),
                new MySqlParameter("@SolvTtheProblem",MySqlDbType.VarChar,500),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@Chargeback",MySqlDbType.Decimal,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50)
            };
            parameters [ 0 ] . Value = model . Code;
            parameters [ 1 ] . Value = model . ContractNo;
            parameters [ 2 ] . Value = model . OccurDate;
            parameters [ 3 ] . Value = model . EventName;
            parameters [ 4 ] . Value = model . SolvTtheProblem;
            parameters [ 5 ] . Value = model . Remarks;
            parameters [ 6 ] . Value = model . Createtime;
            parameters [ 7 ] . Value = model . Createman;
            parameters [ 8 ] . Value = model . Modifytime;
            parameters [ 9 ] . Value = model . Modifyman;
            parameters [ 10 ] . Value = model . codeContract;
            parameters [ 11 ] . Value = model . Chargeback;
            parameters [ 12 ] . Value = model . Numbering;
            parameters [ 13 ] . Value = model . FishMealId;
            SQLString . Add ( strSql ,parameters );
            if ( MySqlHelper . ExecuteSqlTran ( SQLString ) )
            {

                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "select id,code from t_theproblemsheet where code='{0}'" ,model . Code );
                DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
                if (model.Chargeback == 0 && dt.Rows[0]["code"].ToString()!="")
                {
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.AppendFormat("insert into t_review (userName,programId,SingleNumber,date,content,state,userNameReview,Numbering) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", FishEntity.Variable.User.username, name, dt.Rows[0]["code"].ToString(), DateTime.Now, "自动审核", "审核", "自动审核", model.Numbering);
                    MySqlHelper.ExecuteSqlReturnId(strSql1.ToString(), null);
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    return string.IsNullOrEmpty(dt.Rows[0]["id"].ToString()) == true ? 0 : Convert.ToInt32(dt.Rows[0]["id"].ToString());

                }
                else
                    return 0;
            }
            else
                return 0;
        }
        public bool Update(FishEntity.TheproblemsheetEntity model,string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_theproblemsheet set ");
            strSql.Append(" ContractNo = @ContractNo,");
            strSql.Append(" occurDate = @occurDate,");
            strSql.Append(" EventName = @EventName,");
            strSql.Append(" SolvTtheProblem = @SolvTtheProblem,");
            strSql.Append(" Remarks = @Remarks,");
            strSql.Append(" modifytime = @modifytime,");
            strSql.Append(" modifyman = @modifyman,");
            strSql . Append ( "codeContract=@codeContract," );
            strSql.Append("FishMealId=@FishMealId,");
            strSql.Append("Chargeback=@Chargeback");
            strSql.Append(" where id = @id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@ContractNo",MySqlDbType.VarChar,45),
                new MySqlParameter("@occurDate",MySqlDbType.DateTime),
                new MySqlParameter("@EventName",MySqlDbType.VarChar,500),
                new MySqlParameter("@SolvTtheProblem",MySqlDbType.VarChar,500),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
                new MySqlParameter("@Chargeback",MySqlDbType.Decimal,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50)
            };
            parameters[0].Value = model.ContractNo;
            parameters[1].Value = model.OccurDate;
            parameters[2].Value = model.EventName;
            parameters[3].Value = model.SolvTtheProblem;
            parameters[4].Value = model.Remarks;
            parameters[5].Value = model.Modifytime;
            parameters[6].Value = model.Modifyman;
            parameters [ 7 ] . Value = model . codeContract;
            parameters [8].Value = model.Id;
            parameters[9].Value = model.Chargeback;
            parameters[10].Value = model.FishMealId;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
            if (rows>0)
            {
                if (model.Chargeback == 0 && model.Code!="")
                {
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.AppendFormat("insert into t_review (userName,programId,SingleNumber,date,content,state,userNameReview,Numbering) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", FishEntity.Variable.User.username, name, model.Code, DateTime.Now, "自动审核", "审核", "自动审核", model.Numbering);
                    MySqlHelper.ExecuteSqlReturnId(strSql1.ToString(), null);
                }
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
