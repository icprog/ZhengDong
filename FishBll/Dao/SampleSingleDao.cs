using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class SampleSingleDao
    {
        public bool Exists(string code)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_SampleSingle");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.SampleSingleEntity model)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("insert into t_samplesingle(code,ferryName,BillOfLadingNumber,PileAngle,tdate,createtime,createman,modifytime,modifyman)");
            Strsql.Append("values (@code,@ferryName,@BillOfLadingNumber,@PileAngle,@tdate,@createtime,@createman,@modifytime,@modifyman);");
            Strsql.Append("select last_insert_id();");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@ferryName",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@PileAngle",MySqlDbType.VarChar,45),
                new MySqlParameter("@tdate",MySqlDbType.DateTime),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.FerryName;
            parameters[2].Value = model.BillOfLadingNumber;
            parameters[3].Value = model.PileAngle;
            parameters[4].Value = model.Tdate;
            parameters[5].Value = model.Createtime;
            parameters[6].Value = model.Createman;
            parameters[7].Value = model.Modifytime;
            parameters[8].Value = model.Modifyman;
            int id = MySqlHelper.ExecuteSqlReturnId(Strsql.ToString(), parameters); //MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return id;
        }
        public bool Update(FishEntity.SampleSingleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_samplesingle set ");
            strSql.Append("code = @code,");
            strSql.Append("ferryName = @ferryName,");
            strSql.Append("BillOfLadingNumber = @BillOfLadingNumber,");
            strSql.Append("PileAngle = @PileAngle,");
            strSql.Append("tdate = @tdate,");
            strSql.Append("modifytime = @modifytime,");
            strSql.Append("modifyman = @modifyman ");
            strSql.Append("where id = @id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@ferryName",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@PileAngle",MySqlDbType.VarChar,45),
                new MySqlParameter("@tdate",MySqlDbType.DateTime),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.FerryName;
            parameters[2].Value = model.BillOfLadingNumber;
            parameters[3].Value = model.PileAngle;
            parameters[4].Value = model.Tdate;
            parameters[5].Value = model.Modifytime;
            parameters[6].Value = model.Modifyman;
            parameters[7].Value = model.Id;
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
        public List<FishEntity.SampleSingleEntity> GetModelListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_SampleSingle ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.SampleSingleEntity> modelList = new List<FishEntity.SampleSingleEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.SampleSingleEntity model;
            for (int n = 0; n < rowsCount; n++)
            {
                DataRow row = ds.Tables[0].Rows[n];
                model = new FishEntity.SampleSingleEntity();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["ferryName"]!=null&&row["ferryName"].ToString()!="")
                {
                    model.FerryName = row["ferryName"].ToString();
                }
                if (row["BillOfLadingNumber"]!=null&&row["BillOfLadingNumber"].ToString()!="")
                {
                    model.BillOfLadingNumber = row["BillOfLadingNumber"].ToString();
                }
                if (row["PileAngle"].ToString()!=""&&row["PileAngle"]!=null)
                {
                    model.PileAngle = row["PileAngle"].ToString();
                }
                if (row["tdate"]!=null&&row["tdate"].ToString()!="")
                {
                    model.Tdate = DateTime.Parse(row["tdate"].ToString());
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
