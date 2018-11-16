using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class happeningDaoEx:happeningDao
    {
        //public List<FishEntity.SalesRequisitionEntity> Gethappinner(int productid)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_happening a inner join t_saleha b on a.productid=b.Haid where b.Saleid=" + productid);
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
        //public List<FishEntity.SalesRequisitionEntity> Gethappe(int productid)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_happening a inner join t_saleha b on a.productid = b.Haid where b.Saleid=" + productid);
        //    DataSet ds = MySqlHelper.Query(strSql.ToString());
        //    List<FishEntity.SalesRequisitionEntity> modelList = new List<FishEntity.SalesRequisitionEntity>();
        //    int rowsCount = ds.Tables[0].Rows.Count;
        //    if (rowsCount>0)
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

        //public List<FishEntity.PresaleRequisitionEntity> Gethappe_Pres(int productid)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from t_happening a inner join t_presha b on a.productid = b.Haid where b.Presid=" + productid);
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
        //public bool Exists(string product_id)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from t_happening");
        //    strSql.Append(" where product_id=@product_id ");
        //    MySqlParameter[] parameters = {
        //            new MySqlParameter("@product_id", MySqlDbType.VarChar,45)};
        //    parameters[0].Value = product_id;

        //    return MySqlHelper.Exists(strSql.ToString(), parameters);
        //}
        ////public FishEntity.SalesRequisitionEntity DataRowToModel(DataRow row)
        ////{
        ////    FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
        ////    if (row["productid"].ToString() != "")
        ////    {
        ////        model.Productid = int.Parse(row["productid"].ToString());
        ////    }
        ////    if (row["product_id"].ToString()!=""&& row["product_id"]!=null)
        ////    {
        ////        model.Product_id = row["product_id"].ToString();
        ////    }
        ////    if (row["productname"].ToString() != "" && row["productname"] != null)
        ////    {
        ////        model.Productname = row["productname"].ToString();
        ////    }
        ////    if (row["Funit"].ToString() != "" && row["Funit"] != null)
        ////    {
        ////        model.Funit = row["Funit"].ToString();
        ////    }
        ////    if (row["Variety"].ToString() != "" && row["Variety"] != null)
        ////    {
        ////        model.Variety = row["Variety"].ToString();
        ////    }
        ////    if (row["Quantity"].ToString() != "")
        ////    {
        ////        model.Quantity = decimal.Parse(row["Quantity"].ToString());
        ////    }
        ////    if (row["unitprice"].ToString() != "")
        ////    {
        ////        model.Unitprice = decimal.Parse(row["unitprice"].ToString());
        ////    }
        ////    if (row["Amountofmoney"].ToString() != "")
        ////    {
        ////        model.Amountofmoney = decimal.Parse(row["Amountofmoney"].ToString());
        ////    }


        ////    return model;
        ////}
        //public FishEntity.PresaleRequisitionEntity DataRowToModel_Pres(DataRow row)
        //{
        //    FishEntity.PresaleRequisitionEntity model = new FishEntity.PresaleRequisitionEntity();
        //    if (row["productid"].ToString() != "")
        //    {
        //        model.Productid = int.Parse(row["productid"].ToString());
        //    }
        //    if (row["product_id"].ToString() != "" && row["product_id"] != null)
        //    {
        //        model.Product_id = row["product_id"].ToString();
        //    }
        //    if (row["productname"].ToString() != "" && row["productname"] != null)
        //    {
        //        model.Productname = row["productname"].ToString();
        //    }
        //    if (row["Funit"].ToString() != "" && row["Funit"] != null)
        //    {
        //        model.Funit = row["Funit"].ToString();
        //    }
        //    if (row["Variety"].ToString() != "" && row["Variety"] != null)
        //    {
        //        model.Variety = row["Variety"].ToString();
        //    }
        //    if (row["Quantity"].ToString() != "")
        //    {
        //        model.Quantity = decimal.Parse(row["Quantity"].ToString());
        //    }
        //    if (row["unitprice"].ToString() != "")
        //    {
        //        model.Unitprice = decimal.Parse(row["unitprice"].ToString());
        //    }
        //    if (row["Amountofmoney"].ToString() != "")
        //    {
        //        model.Amountofmoney = decimal.Parse(row["Amountofmoney"].ToString());
        //    }


        //    return model;
        //}
    }
}
