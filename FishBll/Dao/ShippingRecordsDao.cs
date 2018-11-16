using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace FishBll.Dao
{
    public class ShippingRecordsDao
    {
        public int Add(FishEntity.ShippingRecordsEntity model)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into t_shippingrecords (code,pickuptime,tonnage,NumberOfPacks,ShippingUnit,ArrivalUnit,Freight,CarNumber,ShipName,BillOfLadingNumber,Country,Brand,quality,ProductionDate,Remarks,createtime,createman,modifytime,modifyman)");
            strsql.Append("values(@code,@pickuptime,@tonnage,@NumberOfPacks,@ShippingUnit,@ArrivalUnit,@Freight,@CarNumber,@ShipName,@BillOfLadingNumber,@Country,@Brand,@quality,@ProductionDate,@Remarks,@createtime,@createman,@modifytime,@modifyman)");
            MySqlParameter[] Parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@pickuptime",MySqlDbType.DateTime),
                new MySqlParameter("@tonnage",MySqlDbType.Decimal,45),
                new MySqlParameter("@NumberOfPacks",MySqlDbType.Int32,11),
                new MySqlParameter("@ShippingUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@ArrivalUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Freight",MySqlDbType.VarChar,45),
                new MySqlParameter("@CarNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@ShipName",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@quality",MySqlDbType.VarChar,45),
                new MySqlParameter("@ProductionDate",MySqlDbType.DateTime),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            Parameters[0].Value = model.Code;
            Parameters[1].Value = model.Pickuptime;
            Parameters[2].Value = model.Tonnage;
            Parameters[3].Value = model.NumberOfPacks;
            Parameters[4].Value = model.ShippingUnit;
            Parameters[5].Value = model.ArrivalUnit;
            Parameters[6].Value = model.Freight;
            Parameters[7].Value = model.CarNumber;
            Parameters[8].Value = model.ShipName;
            Parameters[9].Value = model.BillOfLadingNumber;
            Parameters[10].Value = model.Country;
            Parameters[11].Value = model.Brand;
            Parameters[12].Value = model.Quality;
            Parameters[13].Value = model.ProductionDate;
            Parameters[14].Value = model.Remarks;
            Parameters[15].Value = model.Createtime;
            Parameters[16].Value = model.Createman;
            Parameters[17].Value = model.Modifytime;
            Parameters[18].Value = model.Modifyman;
            int id = MySqlHelper.ExecuteSqlReturnId(strsql.ToString(), Parameters);
            return id;
        }
        public bool Exists(string code)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_shippingrecords");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public DataSet GetQuery(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  t_shippingrecords ");
            if (false == string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public FishEntity.ShippingRecordsEntity DataRowToModel(DataRow row)
        {
            FishEntity.ShippingRecordsEntity model = new FishEntity.ShippingRecordsEntity();

            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.Code = row["code"].ToString();
                }
                if (row["pickuptime"] != null&&row["pickuptime"].ToString()!="")
                {
                    model.Pickuptime = DateTime.Parse(row["pickuptime"].ToString());
                }
                if (row["tonnage"] != null&&row["tonnage"].ToString()!="")
                {
                    model.Tonnage = decimal.Parse(row["tonnage"].ToString());
                }               
                if (row["NumberOfPacks"] != null&&row["NumberOfPacks"].ToString()!="")
                {
                    model.NumberOfPacks = int.Parse(row["NumberOfPacks"].ToString());
                }
                if (row["ShippingUnit"] != null)
                {
                    model.ShippingUnit = row["ShippingUnit"].ToString();
                }
                if (row["ArrivalUnit"] != null)
                {
                    model.ArrivalUnit = row["ArrivalUnit"].ToString();
                }
                if (row["Freight"] != null)
                {
                    model.Freight = row["Freight"].ToString();
                }
                if (row["CarNumber"] != null && row["CarNumber"].ToString() != "")
                {
                    model.CarNumber = row["CarNumber"].ToString();
                }
                if (row["ShipName"] != null && row["ShipName"].ToString() != "")
                {
                    model.ShipName = row["ShipName"].ToString();
                }
                if (row["BillOfLadingNumber"] != null)
                {
                    model.BillOfLadingNumber = row["BillOfLadingNumber"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Brand"] != null)
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["quality"] != null && row["quality"].ToString() != "")
                {
                    model.Quality = row["quality"].ToString();
                }
                if (row["ProductionDate"] != null&&row["ProductionDate"].ToString()!="")
                {
                    model.ProductionDate = DateTime.Parse(row["ProductionDate"].ToString());
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }                
            }

            return model;
        }
        public bool Update(FishEntity.ShippingRecordsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_shippingrecords set ");
            strSql.Append("pickuptime = @pickuptime,");
            strSql.Append("tonnage = @tonnage,");
            strSql.Append("NumberOfPacks = @NumberOfPacks,");
            strSql.Append("ShippingUnit = @ShippingUnit,");
            strSql.Append("ArrivalUnit = @ArrivalUnit,");
            strSql.Append("Freight = @Freight,");
            strSql.Append("CarNumber = @CarNumber,");
            strSql.Append("ShipName = @ShipName,");
            strSql.Append("BillOfLadingNumber = @BillOfLadingNumber,");
            strSql.Append("Country = @Country,");
            strSql.Append("Brand = @Brand,");
            strSql.Append("quality = @quality,");
            strSql.Append("ProductionDate = @ProductionDate,");
            strSql.Append("Remarks = @Remarks,");
            strSql.Append("modifytime = @modifytime,");
            strSql.Append("modifyman = @modifyman ");
            strSql.Append("where id = @id");
            MySqlParameter[] parameter = {
                new MySqlParameter("@pickuptime",MySqlDbType.DateTime),
                new MySqlParameter("@tonnage",MySqlDbType.Decimal,45),
                new MySqlParameter("@NumberOfPacks",MySqlDbType.Int32,11),
                new MySqlParameter("@ShippingUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@ArrivalUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Freight",MySqlDbType.VarChar,45),
                new MySqlParameter("@CarNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@ShipName",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@quality",MySqlDbType.VarChar,45),
                new MySqlParameter("@ProductionDate",MySqlDbType.DateTime),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
            };
            parameter[0].Value = model.Pickuptime;
            parameter[1].Value = model.Tonnage;
            parameter[2].Value = model.NumberOfPacks;
            parameter[3].Value = model.ShippingUnit;
            parameter[4].Value = model.ArrivalUnit;
            parameter[5].Value = model.Freight;
            parameter[6].Value = model.CarNumber;
            parameter[7].Value = model.ShipName;
            parameter[8].Value = model.BillOfLadingNumber;
            parameter[9].Value = model.Country;
            parameter[10].Value = model.Brand;
            parameter[11].Value = model.Quality;
            parameter[12].Value = model.ProductionDate;
            parameter[13].Value = model.Remarks;
            parameter[14].Value = model.Modifytime;
            parameter[15].Value = model.Modifyman;
            parameter[16].Value = model.Id;
            int row = MySqlHelper.ExecuteSql(strSql.ToString(), parameter);
            if (row > 0)
                return true;
            else
                return false;
        }
    }
}
