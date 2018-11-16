using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class DisposeofcommentsDao
    {
        public List<FishEntity.DisposeofcommentsEntity> GetModelList(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_disposeofcomments ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.DisposeofcommentsEntity> modelList = new List<FishEntity.DisposeofcommentsEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.DisposeofcommentsEntity model;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                model = new FishEntity.DisposeofcommentsEntity();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["code"]!=null&&row["code"].ToString()!="")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["Filenumber"] != null&&row["Filenumber"].ToString()!="")
                {
                    model.Filenumber = row["Filenumber"].ToString();
                }
                if (row["Todealwith"]!=null&&row["Todealwith"].ToString()!="")
                {
                    model.Todealwith = row["Todealwith"].ToString();
                }
                if (row["Treatmentmeasures"]!=null&&row["Treatmentmeasures"].ToString()!="")
                {
                    model.Treatmentmeasures = row["Treatmentmeasures"].ToString();
                }
                if (row["DepartmentManagerOpinion"]!=null&&row["DepartmentManagerOpinion"].ToString()!="")
                {
                    model.DepartmentManagerOpinion = row["DepartmentManagerOpinion"].ToString();
                }
                if (row["Managerdate"] != null && row["Managerdate"].ToString()!="")
                {
                    model.Managerdate = DateTime.Parse(row["Managerdate"].ToString());
                }
                if (row["CompanyOpinion"] != null&&row["CompanyOpinion"].ToString()!="")
                {
                    model.CompanyOpinion = row["CompanyOpinion"].ToString();
                }
                if (row["Companydate"].ToString()!=""&&row["Companydate"]!=null)
                {
                    model.Companydate = DateTime.Parse(row["Companydate"].ToString());
                }
                if (row["ResultOfDiscussion"].ToString()!=""&&row["ResultOfDiscussion"]!=null)
                {
                    model.ResultOfDiscussion = row["ResultOfDiscussion"].ToString();
                }
                if (row["Discussdate"]!=null&&row["Discussdate"].ToString()!="")
                {
                    model.Discussdate = DateTime.Parse(row["Discussdate"].ToString());
                }
                if (row["PersonAgreesToSign"]!=null&&row["PersonAgreesToSign"].ToString()!="")
                {
                    model.PersonAgreesToSign = row["PersonAgreesToSign"].ToString();
                }
                if (row["Remarks"]!=null&&row["Remarks"].ToString()!="")
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                modelList.Add(model);
            }
            return modelList;
        }
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_disposeofcomments");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.DisposeofcommentsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_disposeofcomments(code,Filenumber, Todealwith, Treatmentmeasures, DepartmentManagerOpinion, Managerdate, CompanyOpinion, Companydate, ResultOfDiscussion, Discussdate, PersonAgreesToSign, Remarks, createtime, createman, modifytime, modifyman)");
            strSql.Append("values(@code,@Filenumber, @Todealwith, @Treatmentmeasures, @DepartmentManagerOpinion, @Managerdate, @CompanyOpinion, @Companydate, @ResultOfDiscussion, @Discussdate, @PersonAgreesToSign, @Remarks, @createtime, @createman, @modifytime, @modifyman); select last_insert_id();");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@Filenumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Todealwith",MySqlDbType.VarChar,500),
                new MySqlParameter("@Treatmentmeasures",MySqlDbType.VarChar,500),
                new MySqlParameter("@DepartmentManagerOpinion",MySqlDbType.VarChar,500),
                new MySqlParameter("@Managerdate",MySqlDbType.DateTime),
                new MySqlParameter("@CompanyOpinion",MySqlDbType.VarChar,500),
                new MySqlParameter("@Companydate",MySqlDbType.DateTime),
                new MySqlParameter("@ResultOfDiscussion",MySqlDbType.VarChar,500),
                new MySqlParameter("@Discussdate",MySqlDbType.DateTime),
                new MySqlParameter("@PersonAgreesToSign",MySqlDbType.VarChar,500),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = model.Code;
            parameter[1].Value = model.Filenumber;
            parameter[2].Value = model.Todealwith;
            parameter[3].Value = model.Treatmentmeasures;
            parameter[4].Value = model.DepartmentManagerOpinion;
            parameter[5].Value = model.Managerdate;
            parameter[6].Value = model.CompanyOpinion;
            parameter[7].Value = model.Companydate;
            parameter[8].Value = model.ResultOfDiscussion;
            parameter[9].Value = model.Discussdate;
            parameter[10].Value = model.PersonAgreesToSign;
            parameter[11].Value = model.Remarks;
            parameter[12].Value = model.Createtime;
            parameter[13].Value = model.Createman;
            parameter[14].Value = model.Modifytime;
            parameter[15].Value = model.Modifyman;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameter);
            return id;
        }
        public bool Update(FishEntity.DisposeofcommentsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_disposeofcomments ");
            strSql.Append(" set Filenumber = @Filenumber,");
            strSql.Append("Todealwith = @Todealwith,");
            strSql.Append("Treatmentmeasures = @Treatmentmeasures,");
            strSql.Append("DepartmentManagerOpinion = @DepartmentManagerOpinion,");
            strSql.Append("Managerdate = @Managerdate,");
            strSql.Append("CompanyOpinion = @CompanyOpinion,");
            strSql.Append("Companydate = @Companydate,");
            strSql.Append("ResultOfDiscussion = @ResultOfDiscussion,");
            strSql.Append("Discussdate = @Discussdate,");
            strSql.Append("PersonAgreesToSign = @PersonAgreesToSign,");
            strSql.Append("Remarks = @Remarks,");
            strSql.Append("modifytime = @modifytime,");
            strSql.Append("modifyman = @modifyman ");
            strSql.Append("where id = @id");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Filenumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Todealwith",MySqlDbType.VarChar,500),
                new MySqlParameter("@Treatmentmeasures",MySqlDbType.VarChar,500),
                new MySqlParameter("@DepartmentManagerOpinion",MySqlDbType.VarChar,500),
                new MySqlParameter("@Managerdate",MySqlDbType.DateTime),
                new MySqlParameter("@CompanyOpinion",MySqlDbType.VarChar,500),
                new MySqlParameter("@Companydate",MySqlDbType.DateTime),
                new MySqlParameter("@ResultOfDiscussion",MySqlDbType.VarChar,500),
                new MySqlParameter("@Discussdate",MySqlDbType.DateTime),
                new MySqlParameter("@PersonAgreesToSign",MySqlDbType.VarChar,500),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
            };
            parameter[0].Value = model.Filenumber;
            parameter[1].Value = model.Todealwith;
            parameter[2].Value = model.Treatmentmeasures;
            parameter[3].Value = model.DepartmentManagerOpinion;
            parameter[4].Value = model.Managerdate;
            parameter[5].Value = model.CompanyOpinion;
            parameter[6].Value = model.Companydate;
            parameter[7].Value = model.ResultOfDiscussion;
            parameter[8].Value = model.Discussdate;
            parameter[9].Value = model.PersonAgreesToSign;
            parameter[10].Value = model.Remarks;
            parameter[11].Value = model.Modifytime;
            parameter[12].Value = model.Modifyman;
            parameter[13].Value = model.Id;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameter);
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
