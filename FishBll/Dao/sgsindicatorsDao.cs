using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class sgsindicatorsDao
    {
        //public bool Delete(int Saleid,int SGSid) {
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("delete from t_salesgs ");
        //    strSql.Append(" where Saleid=@Saleid and SGSid=@SGSid ");
        //    MySqlParameter[] parameters = {

        //            new MySqlParameter("@Saleid", MySqlDbType.Int32,11),
        //            new MySqlParameter("@SGSid", MySqlDbType.Int32,11)
        //                                  };
        //    parameters[0].Value = Saleid;
        //    parameters[1].Value = SGSid;

        //    int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public List<FishEntity.SalesRequisitionEntity> GetSalefSgs(int indexid)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_sgsindicators a inner join t_salesgs b on a.indexid=b.SGSid where b.Saleid="+ indexid);
        //    DataSet ds = MySqlHelper.Query(strSql.ToString());
        //    List<FishEntity.SalesRequisitionEntity> modelList = new List<FishEntity.SalesRequisitionEntity>();
        //    int rowsCount = ds.Tables[0].Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        FishEntity.SalesRequisitionEntity model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel(ds.Tables[0].Rows[n]);
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}
        //public DataSet GetList(string strwhere) {
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_salesorder a inner join t_sgsindicators b on a.`code`=b.index_id ");
        //    if (strwhere.Trim() != "")
        //    {
        //        strSql.Append(" where " + strwhere);
        //    }
        //    return MySqlHelper.Query(strSql.ToString());
        //}
        //public bool Find(string code)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(*) from t_sgsindicators where index_id like '" + code+"'");
        //    return MySqlHelper.Exists(strSql.ToString());
        //}
        //public bool Exists(string index_id)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from t_sgsindicators");
        //    strSql.Append(" where index_id=@index_id ");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@index_id", MySqlDbType.VarChar,45)};
        //    parameters[0].Value = index_id;

        //    return MySqlHelper.Exists(strSql.ToString(), parameters);
        //}
        //public List<FishEntity.SalesRequisitionEntity> GetSGS(int indexid)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_sgsindicators a inner join t_salesgs b on a.indexid=b.SGSid where b.Saleid=" + indexid);
        //    DataSet ds = MySqlHelper.Query(strSql.ToString());
        //    List<FishEntity.SalesRequisitionEntity> modelList = new List<FishEntity.SalesRequisitionEntity>();
        //    int rowsCount = ds.Tables[0].Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        FishEntity.SalesRequisitionEntity model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel(ds.Tables[0].Rows[n]);
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}

        ////public FishEntity.SalesRequisitionEntity DataRowToModel(DataRow row)
        ////{
        ////    FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
        ////    if (row!=null)
        ////    {
        ////        if (row["indexid"]!=null)
        ////        {
        ////            model.Indexid = int.Parse(row["indexid"].ToString());
        ////        }
        ////        if (row["index_id"] != null&&row["index_id"].ToString()!="")
        ////        {
        ////            model.Index_id = row["index_id"].ToString();
        ////        }
        ////        if (row["protein"]!=null&&row["protein"].ToString()!="")
        ////        {
        ////            model.Protein = decimal.Parse(row["protein"].ToString());
        ////        }
        ////        if (row["TVN"]!=null&&row["TVN"].ToString()!="")
        ////        {
        ////            model.TVN = decimal.Parse(row["TVN"].ToString());
        ////        }
        ////        if (row["Ash"] != null&&row["Ash"].ToString()!="")
        ////        {
        ////            model.Ash = decimal.Parse(row["Ash"].ToString());
        ////        }
        ////        if (row["histamine"]!=null&&row["histamine"].ToString()!="")
        ////        {
        ////            model.Histamine = decimal.Parse(row["histamine"].ToString());
        ////        }
        ////        if (row["FFA"]!=null&&row["FFA"].ToString()!="")
        ////        {
        ////            model.FFA = decimal.Parse(row["FFA"].ToString());
        ////        }
        ////        if (row["fat"]!=null&&row["fat"].ToString()!="")
        ////        {
        ////            model.Fat = decimal.Parse(row["fat"].ToString());
        ////        }
        ////        if (row["Moisture"]!=null&&row["Moisture"].ToString()!="")
        ////        {
        ////            model.Moisture = decimal.Parse(row["Moisture"].ToString());
        ////        }
        ////        if (row["Sandsalt"]!=null&&row["Sandsalt"].ToString()!="")
        ////        {
        ////            model.Sandsalt = decimal.Parse(row["Sandsalt"].ToString());
        ////        }
        ////        if (row["sand"]!=null&&row["sand"].ToString()!="")
        ////        {
        ////            model.Sand = decimal.Parse(row["sand"].ToString());
        ////        }
        ////    }
        ////    return model;
        ////}


        //public List<FishEntity.PresaleRequisitionEntity> GetSGS_Pres(int indexid)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_sgsindicators a inner join t_pressgs b on a.indexid=b.SGSid where b.Presid=" + indexid);
        //    DataSet ds = MySqlHelper.Query(strSql.ToString());
        //    List<FishEntity.PresaleRequisitionEntity> modelList = new List<FishEntity.PresaleRequisitionEntity>();
        //    int rowsCount = ds.Tables[0].Rows.Count;
        //    if (rowsCount > 0)
        //    {
        //        FishEntity.PresaleRequisitionEntity model;
        //        for (int n = 0; n < rowsCount; n++)
        //        {
        //            model = DataRowToModel_Pres(ds.Tables[0].Rows[n]);
        //            modelList.Add(model);
        //        }
        //    }
        //    return modelList;
        //}
        //public FishEntity.PresaleRequisitionEntity DataRowToModel_Pres(DataRow row)
        //{
        //    FishEntity.PresaleRequisitionEntity model = new FishEntity.PresaleRequisitionEntity();
        //    if (row != null)
        //    {
        //        if (row["indexid"] != null)
        //        {
        //            model.Indexid = int.Parse(row["indexid"].ToString());
        //        }
        //        if (row["index_id"] != null && row["index_id"].ToString() != "")
        //        {
        //            model.Index_id = row["index_id"].ToString();
        //        }
        //        if (row["protein"] != null && row["protein"].ToString() != "")
        //        {
        //            model.Protein = decimal.Parse(row["protein"].ToString());
        //        }
        //        if (row["TVN"] != null && row["TVN"].ToString() != "")
        //        {
        //            model.TVN = decimal.Parse(row["TVN"].ToString());
        //        }
        //        if (row["Ash"] != null && row["Ash"].ToString() != "")
        //        {
        //            model.Ash = decimal.Parse(row["Ash"].ToString());
        //        }
        //        if (row["histamine"] != null && row["histamine"].ToString() != "")
        //        {
        //            model.Histamine = decimal.Parse(row["histamine"].ToString());
        //        }
        //        if (row["FFA"] != null && row["FFA"].ToString() != "")
        //        {
        //            model.FFA = decimal.Parse(row["FFA"].ToString());
        //        }
        //        if (row["fat"] != null && row["fat"].ToString() != "")
        //        {
        //            model.Fat = decimal.Parse(row["fat"].ToString());
        //        }
        //        if (row["Moisture"] != null && row["Moisture"].ToString() != "")
        //        {
        //            model.Moisture = decimal.Parse(row["Moisture"].ToString());
        //        }
        //        if (row["Sandsalt"] != null && row["Sandsalt"].ToString() != "")
        //        {
        //            model.Sandsalt = decimal.Parse(row["Sandsalt"].ToString());
        //        }
        //        if (row["sand"] != null && row["sand"].ToString() != "")
        //        {
        //            model.Sand = decimal.Parse(row["sand"].ToString());
        //        }
        //    }
        //    return model;
        //}
        //public int Add(FishEntity.SalesRequisitionEntity model)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("insert into t_sgsindicators (indexid,index_id,protein,TVN,Ash,histamine,FFA,fat,Moisture,Sandsalt,sand) values (@indexid,@index_id,@protein,@TVN,@Ash,@histamine,@FFA,@fat,@Moisture,@Sandsalt,@sand);");
        //    strSql.Append("select LAST_INSERT_ID();");
        //    MySqlParameter[] parameter = {
        //        new MySqlParameter("@indexid",MySqlDbType.Int32,11),
        //        new MySqlParameter("@index_id",MySqlDbType.VarChar,45),
        //        new MySqlParameter("@protein",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@TVN",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@Ash",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@histamine",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@FFA",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@fat",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@Moisture",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@Sandsalt",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@sand",MySqlDbType.Decimal,45)
        //    };
        //    parameter[0].Value = model.Indexid;
        //    parameter[1].Value = model.Index_id;
        //    parameter[2].Value = model.Protein;
        //    parameter[3].Value = model.TVN;
        //    parameter[4].Value = model.Ash;
        //    parameter[5].Value = model.Histamine;
        //    parameter[6].Value = model.FFA;
        //    parameter[7].Value = model.Fat;
        //    parameter[8].Value = model.Moisture;
        //    parameter[9].Value = model.Sandsalt;
        //    parameter[10].Value = model.Sand;
        //    int rows= MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameter);
        //    return rows;

        //}
        //public bool Update(FishEntity.SalesRequisitionEntity model) {
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("update t_sgsindicators set ");
        //    strSql.Append("index_id = @index_id, ");
        //    strSql.Append("protein = @protein, ");
        //    strSql.Append("TVN = @TVN, ");
        //    strSql.Append("Ash = @Ash,");
        //    strSql.Append("histamine = @histamine,");
        //    strSql.Append("FFA = @FFA,");
        //    strSql.Append("fat = @fat, ");
        //    strSql.Append("Moisture = @Moisture, ");
        //    strSql.Append("Sandsalt = @Sandsalt, ");
        //    strSql.Append("sand = @sand ");
        //    strSql.Append("where index_id = @index_id");
        //    MySqlParameter[] parameters = {
        //        new MySqlParameter("@index_id",MySqlDbType.VarChar,45),
        //        new MySqlParameter("@protein",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@TVN",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@Ash",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@histamine",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@FFA",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@fat",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@Moisture",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@Sandsalt",MySqlDbType.Decimal,45),
        //        new MySqlParameter("@sand",MySqlDbType.Decimal,45)
        //    };
        //    parameters[0].Value = model.Index_id;
        //    parameters[1].Value = model.Protein;
        //    parameters[2].Value = model.TVN;
        //    parameters[3].Value = model.Ash;
        //    parameters[4].Value = model.Histamine;
        //    parameters[5].Value = model.FFA;
        //    parameters[6].Value = model.Fat;
        //    parameters[7].Value = model.Moisture;
        //    parameters[8].Value = model.Sandsalt;
        //    parameters[9].Value = model.Sand;
        //    int rows = MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
        //    if (rows > 0)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
