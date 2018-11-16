using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class FormContractProcessingSheetDao
    {
        public bool Exists(string code)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_ContractProcessingSheet");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.ContractProcessingSheetEntity model)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("insert into t_ContractProcessingSheet(code,contractcode,tdate,TheReason,Processing,createtime,createman,modifytime,modifyman)");
            Strsql.Append("values(@code,@contractcode,@tdate,@TheReason,@Processing,@createtime,@createman,@modifytime,@modifyman);");
            Strsql.Append("select last_insert_id();");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@contractcode",MySqlDbType.VarChar,45),
                new MySqlParameter("@tdate",MySqlDbType.DateTime),
                new MySqlParameter("@TheReason",MySqlDbType.VarChar,200),
                new MySqlParameter("@Processing",MySqlDbType.VarChar,200),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Contractcode;
            parameters[2].Value = model.Tdate;
            parameters[3].Value = model.TheReason;
            parameters[4].Value = model.Processing;
            parameters[5].Value = model.Createtime;
            parameters[6].Value = model.Createman;
            parameters[7].Value = model.Modifytime;
            parameters[8].Value = model.Modifyman;
            int id = MySqlHelper.ExecuteSqlReturnId(Strsql.ToString(), parameters);
            return id;
        }
        public bool Update(FishEntity.ContractProcessingSheetEntity model)
        {
            StringBuilder Strsql = new StringBuilder();
            Strsql.Append("update t_ContractProcessingSheet set ");
            Strsql.Append("code=@code,");
            Strsql.Append("contractcode=@contractcode,");
            Strsql.Append("tdate=@tdate,");
            Strsql.Append("TheReason=@TheReason,");
            Strsql.Append("Processing=@Processing,");
            Strsql.Append("modifytime=@modifytime,");
            Strsql.Append("modifyman=@modifyman ");
            Strsql.Append("where id=@id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@contractcode",MySqlDbType.VarChar,45),
                new MySqlParameter("@tdate",MySqlDbType.DateTime),
                new MySqlParameter("@TheReason",MySqlDbType.VarChar,200),
                new MySqlParameter("@Processing",MySqlDbType.VarChar,200),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Contractcode;
            parameters[2].Value = model.Tdate;
            parameters[3].Value = model.TheReason;
            parameters[4].Value = model.Processing;
            parameters[5].Value = model.Modifytime;
            parameters[6].Value = model.Modifyman;
            parameters[7].Value = model.Id;
            int rows = MySqlHelper.ExecuteSql(Strsql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<FishEntity.ContractProcessingSheetEntity> GetModelListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_ContractProcessingSheet ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.ContractProcessingSheetEntity> modelList = new List<FishEntity.ContractProcessingSheetEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.ContractProcessingSheetEntity model;
            for (int n = 0; n < rowsCount; n++)
            {
                DataRow row = ds.Tables[0].Rows[n];
                model = new FishEntity.ContractProcessingSheetEntity();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["contractcode"]!=null&&row["contractcode"].ToString()!="")
                {
                    model.Contractcode = row["contractcode"].ToString();
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["tdate"] != null && row["tdate"].ToString() != "")
                {
                    model.Tdate = DateTime.Parse(row["tdate"].ToString());
                }
                if (row["TheReason"]!=null&&row["TheReason"].ToString()!="")
                {
                    model.TheReason = row["TheReason"].ToString();
                }
                if (row["Processing"]!=null&&row["Processing"].ToString()!="")
                {
                    model.Processing = row["Processing"].ToString();
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
