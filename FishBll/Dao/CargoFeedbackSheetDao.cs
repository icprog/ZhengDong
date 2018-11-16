using System;
using System . Collections . Generic;
using System . Text;
using System . Data;
using MySql . Data . MySqlClient;
using System . Collections;

namespace FishBll.Dao
{
    public class CargoFeedbackSheetDao
    {
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_CargoFeedbackSheet");
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
            strSql.Append("select count(*) from t_CargoFeedbackSheet");
            strSql.Append(" where code=@code and createman=@createman ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45)
            };
            parameters[0].Value = code;
            parameters[1].Value = createman;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.CargoFeedbackSheetEntity model)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("insert into t_CargoFeedbackSheet(Numbering,code,sponsor,acceptor,processresult,evaluation,attendance,review,remarks,modifytime,modifyman,createtime,createman,ConfirmTheWeight,FishMealId,PoundDifference,NetWeight,PoundBillNumber,codeContract)");
            Strsql.Append("values(@Numbering,@code,@sponsor,@acceptor,@processresult,@evaluation,@attendance,@review,@remarks,@modifytime,@modifyman,@createtime,@createman,@ConfirmTheWeight,@FishMealId,@PoundDifference,@NetWeight,@PoundBillNumber,@codeContract);");
            Strsql.Append("select last_insert_id();");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@sponsor",MySqlDbType.VarChar,45),
                new MySqlParameter("@acceptor",MySqlDbType.VarChar,45),
                new MySqlParameter("@processresult",MySqlDbType.VarChar,200),
                new MySqlParameter("@evaluation",MySqlDbType.VarChar,200),
                new MySqlParameter("@attendance",MySqlDbType.VarChar,120),
                new MySqlParameter("@review",MySqlDbType.VarChar,45),
                new MySqlParameter("@remarks",MySqlDbType.VarChar,200),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@ConfirmTheWeight",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50),
                new MySqlParameter("@PoundDifference",MySqlDbType.VarChar,50),
                new MySqlParameter("@NetWeight",MySqlDbType.VarChar,50),
                new MySqlParameter("@PoundBillNumber",MySqlDbType.VarChar,50)
            };
            parameter[0].Value = model.Code;
            parameter[1].Value = model.Sponsor;
            parameter[2].Value = model.Acceptor;
            parameter[3].Value = model.Processresult;
            parameter[4].Value = model.Evaluation;
            parameter[5].Value = model.Attendance;
            parameter[6].Value = model.Review;
            parameter[7].Value = model.Remarks;
            parameter[8].Value = model.Modifytime;
            parameter[9].Value = model.Modifyman;
            parameter[10].Value = model.Createtime;
            parameter[11].Value = model.Createman;
            parameter[12].Value = model.ConfirmTheWeight;
            parameter [ 13 ] . Value = model . codeContract;
            parameter[14].Value = model.Numbering;
            parameter[15].Value = model.FishMealId;
            parameter[16].Value = model.PoundDifference;
            parameter[17].Value = model.NetWeight;
            parameter[18].Value = model.PoundBillNumber;
            int id = MySqlHelper.ExecuteSqlReturnId(Strsql.ToString(), parameter);
            return id;
        }
        public int Add ( FishEntity . CargoFeedbackSheetEntity model ,string name )
        {
            Hashtable SQLString = new Hashtable ( );
            SQLString=ReviewInfo . getSQLString ( name ,model . codeContract ,string . Empty, SQLString);
            StringBuilder Strsql = new StringBuilder ( );
            Strsql . Append ( "insert into t_CargoFeedbackSheet(Numbering,code,sponsor,acceptor,processresult,evaluation,attendance,review,remarks,modifytime,modifyman,createtime,createman,ConfirmTheWeight,FishMealId,PoundDifference,NetWeight,PoundBillNumber,codeContract)" );
            Strsql . Append ( "values(@Numbering,@code,@sponsor,@acceptor,@processresult,@evaluation,@attendance,@review,@remarks,@modifytime,@modifyman,@createtime,@createman,@ConfirmTheWeight,@FishMealId,@PoundDifference,@NetWeight,@PoundBillNumber,@codeContract);" );
            //Strsql . Append ( "select last_insert_id();" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@sponsor",MySqlDbType.VarChar,45),
                new MySqlParameter("@acceptor",MySqlDbType.VarChar,45),
                new MySqlParameter("@processresult",MySqlDbType.VarChar,200),
                new MySqlParameter("@evaluation",MySqlDbType.VarChar,200),
                new MySqlParameter("@attendance",MySqlDbType.VarChar,120),
                new MySqlParameter("@review",MySqlDbType.VarChar,45),
                new MySqlParameter("@remarks",MySqlDbType.VarChar,200),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@ConfirmTheWeight",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50),
                new MySqlParameter("@PoundDifference",MySqlDbType.VarChar,50),
                new MySqlParameter("@NetWeight",MySqlDbType.VarChar,50),
                new MySqlParameter("@PoundBillNumber",MySqlDbType.VarChar,50)
            };
            parameter [ 0 ] . Value = model . Code;
            parameter [ 1 ] . Value = model . Sponsor;
            parameter [ 2 ] . Value = model . Acceptor;
            parameter [ 3 ] . Value = model . Processresult;
            parameter [ 4 ] . Value = model . Evaluation;
            parameter [ 5 ] . Value = model . Attendance;
            parameter [ 6 ] . Value = model . Review;
            parameter [ 7 ] . Value = model . Remarks;
            parameter [ 8 ] . Value = model . Modifytime;
            parameter [ 9 ] . Value = model . Modifyman;
            parameter [ 10 ] . Value = model . Createtime;
            parameter [ 11 ] . Value = model . Createman;
            parameter [ 12 ] . Value = model . ConfirmTheWeight;
            parameter [ 13 ] . Value = model . codeContract;
            parameter [ 14 ] . Value = model . Numbering;
            parameter [ 15 ] . Value = model . FishMealId;
            parameter [ 16 ] . Value = model . PoundDifference;
            parameter [ 17 ] . Value = model . NetWeight;
            parameter [ 18 ] . Value = model . PoundBillNumber;
            SQLString . Add ( Strsql ,parameter );
            if ( MySqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                Strsql = new StringBuilder ( );
                Strsql . AppendFormat ( "select id from t_CargoFeedbackSheet where code='{0}'" ,model . Code );
                if (Convert.ToDecimal(model.NetWeight.ToString()) == Convert.ToDecimal(model.ConfirmTheWeight.ToString())&& model.Code!="")
                {
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.AppendFormat("insert into t_review (userName,programId,SingleNumber,date,content,state,userNameReview,Numbering) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", FishEntity.Variable.User.username, name, model.Code, DateTime.Now, "自动审核", "审核", "自动审核", model.Numbering);
                   int qq= MySqlHelper.ExecuteSqlReturnId(strSql1.ToString(), null);
                }
                DataTable dt = MySqlHelper . Query ( Strsql . ToString ( ) ) . Tables [ 0 ];
                if ( dt != null && dt . Rows . Count > 0 )
                    return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "id" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "id" ] . ToString ( ) );
                else
                    return 0;
            }
            else
                return 0;
        }
        public bool Update(FishEntity.CargoFeedbackSheetEntity model,string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_CargoFeedbackSheet set ");
            strSql.Append("code = @code,");
            strSql.Append("sponsor=@sponsor,");
            strSql.Append("acceptor=@acceptor,");
            strSql.Append("processresult=@processresult,");
            strSql.Append("evaluation=@evaluation,");
            strSql.Append("attendance=@attendance,");
            strSql.Append("review=@review,");
            strSql.Append("remarks=@remarks,");
            strSql.Append("modifytime = @modifytime,");
            strSql.Append("modifyman = @modifyman, ");
            strSql.Append("ConfirmTheWeight=@ConfirmTheWeight,");
            strSql.Append("FishMealId=@FishMealId,");
            strSql.Append("PoundDifference=@PoundDifference,");
            strSql.Append("NetWeight=@NetWeight,");
            strSql.Append("PoundBillNumber=@PoundBillNumber,");
            strSql . Append ( "codeContract=@codeContract " );
            strSql.Append(" where id = @id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@sponsor",MySqlDbType.VarChar,45),
                new MySqlParameter("@acceptor",MySqlDbType.VarChar,45),
                new MySqlParameter("@processresult",MySqlDbType.VarChar,200),
                new MySqlParameter("@evaluation",MySqlDbType.VarChar,200),
                new MySqlParameter("@attendance",MySqlDbType.VarChar,120),
                new MySqlParameter("@review",MySqlDbType.VarChar,45),
                new MySqlParameter("@remarks",MySqlDbType.VarChar,200),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@ConfirmTheWeight",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50),
                new MySqlParameter("@PoundDifference",MySqlDbType.VarChar,50),
                new MySqlParameter("@NetWeight",MySqlDbType.VarChar,50),
                new MySqlParameter("@PoundBillNumber",MySqlDbType.VarChar,50),
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Sponsor;
            parameters[2].Value = model.Acceptor;
            parameters[3].Value = model.Processresult;
            parameters[4].Value = model.Evaluation;
            parameters[5].Value = model.Attendance;
            parameters[6].Value = model.Review;
            parameters[7].Value = model.Remarks;
            parameters[8].Value = model.Modifytime;
            parameters[9].Value = model.Modifyman;
            parameters[10].Value = model.ConfirmTheWeight;
            parameters [ 11 ] . Value = model . codeContract;
            parameters [12].Value = model.Id;
            parameters[13].Value = model.FishMealId;
            parameters[14].Value = model.PoundDifference;
            parameters[15].Value = model.NetWeight;
            parameters[16].Value = model.PoundBillNumber;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                if (Convert.ToDecimal(model.NetWeight.ToString()) == Convert.ToDecimal(model.ConfirmTheWeight.ToString()) && model.Code != "")
                {
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.AppendFormat("insert into t_review (userName,programId,SingleNumber,date,content,state,userNameReview,Numbering) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", FishEntity.Variable.User.username, name, model.Code, DateTime.Now, "自动审核", "审核", "自动审核", model.Numbering);
                    int qq = MySqlHelper.ExecuteSqlReturnId(strSql1.ToString(), null);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<FishEntity.CargoFeedbackSheetEntity> GetModelListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_CargoFeedbackSheet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.CargoFeedbackSheetEntity> modelList = new List<FishEntity.CargoFeedbackSheetEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.CargoFeedbackSheetEntity model;
            for (int n = 0; n < rowsCount; n++)
            {
                DataRow row = ds.Tables[0].Rows[n];
                model = new FishEntity.CargoFeedbackSheetEntity();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["sponsor"]!=null&&row["sponsor"].ToString()!="")
                {
                    model.Sponsor = row["sponsor"].ToString();
                }
                if (row["acceptor"] !=null&&row["acceptor"].ToString()!="")
                {
                    model.Acceptor = row["acceptor"].ToString();
                }
                if (row["processresult"]!=null&&row["processresult"].ToString()!="")
                {
                    model.Processresult = row["processresult"].ToString();
                }
                if (row["evaluation"]!=null&&row["evaluation"].ToString()!="")
                {
                    model.Evaluation = row["evaluation"].ToString();
                }
                if (row["attendance"]!=null&&row["attendance"].ToString()!="")
                {
                    model.Attendance = row["attendance"].ToString();
                }
                if (row["review"]!=null&&row["review"].ToString()!="")
                {
                    model.Review = row["review"].ToString();
                }
                if (row["remarks"]!=null&&row["remarks"].ToString()!="")
                {
                    model.Remarks = row["remarks"].ToString();
                }
                if ( row [ "codeContract" ] != null && row [ "codeContract" ] . ToString ( ) != "" )
                {
                    model . codeContract = row [ "codeContract" ] . ToString ( );
                }
                if (row["ConfirmTheWeight"]!=null)
                {
                    model.ConfirmTheWeight =row["ConfirmTheWeight"].ToString();
                }
                if (row["createman"]!=null)
                {
                    model.Createman = row["createman"].ToString();
                }
                if (row["modifyman"] != null)
                {
                    model.Modifyman = row["modifyman"].ToString();
                }
                if (row["FishMealId"]!=null)
                {
                    model.FishMealId = row["FishMealId"].ToString();
                }
                if (row["PoundDifference"]!=null)
                {
                    model.PoundDifference = row["PoundDifference"].ToString();
                }
                if (row["NetWeight"]!=null)
                {
                    model.NetWeight = row["NetWeight"].ToString();
                }
                if (row["PoundBillNumber"]!=null)
                {
                    model.PoundBillNumber = row["PoundBillNumber"].ToString();
                }
                modelList .Add(model);
            }
            return modelList;
        }
    }
}
