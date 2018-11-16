using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ingredientsDao
    {
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_ingredients");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar ,45)
            };
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.ingredientsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_ingredients(code,ProductionDate,Outoftime,Brand,tlabel,quality,Remarks,modifytime,modifyman,createtime,createman)");
            strSql.Append("values(@code,@ProductionDate,@Outoftime,@Brand,@tlabel,@quality,@Remarks,@modifytime,@modifyman,@createtime,@createman);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] Parameters = {
                new MySqlParameter ("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@ProductionDate",MySqlDbType.DateTime),
                new MySqlParameter("@Outoftime",MySqlDbType.DateTime),
                new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@tlabel",MySqlDbType.VarChar,45),
                new MySqlParameter("@quality",MySqlDbType.VarChar,45),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman", MySqlDbType.VarChar,50)
            };
            Parameters[0].Value = model.Code;
            Parameters[1].Value = model.ProductionDate;
            Parameters[2].Value = model.Outoftime;
            Parameters[3].Value = model.Brand;
            Parameters[4].Value = model.Tlabel;
            Parameters[5].Value = model.Quality;
            Parameters[6].Value = model.Remarks;
            Parameters[7].Value = model.Createtime;
            Parameters[8].Value = model.Createman;
            Parameters[9].Value = model.Modifytime;
            Parameters[10].Value = model.Modifyman;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), Parameters);
            return id;
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_ingredients ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public FishEntity.ingredientsEntity DataRowToModel1(DataRow row)
        {
            FishEntity.ingredientsEntity model =new FishEntity.ingredientsEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["ProductionDate"] != null && row["ProductionDate"].ToString() != "")
                {
                    model.ProductionDate = DateTime.Parse(row["ProductionDate"].ToString());
                }
                if (row["Outoftime"] != null && row["Outoftime"].ToString() != "")
                {
                    model.Outoftime = DateTime.Parse(row["Outoftime"].ToString());
                }
                if (row["Brand"] != null && row["Brand"].ToString() != "")
                {
                    model.Brand = row["Brand"].ToString();
                }
                if (row["tlabel"] != null && row["tlabel"].ToString() != "")
                {
                    model.Tlabel = row["tlabel"].ToString();
                }
                if (row["quality"] != null && row["quality"].ToString() != "")
                {
                    model.Quality = row["quality"].ToString();
                }
                if (row["Remarks"] != null && row["Remarks"].ToString() != "")
                {
                    model.Remarks = row["Remarks"].ToString();
                }
            }
            return model;
        }
        public int Add_detail(FishEntity.ingredientsdetailEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_ingredientsdetail(code,Goods,tonnage,protein,TVN,acid,Ash,histamine,Lysine,Methionine,Finishedproduct,unitprice,cost,salt)");
            strSql.Append("values(@code,@Goods,@tonnage,@protein,@TVN,@acid,@Ash,@histamine,@Lysine,@Methionine,@Finishedproduct,@unitprice,@cost,@salt)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@Goods",MySqlDbType.VarChar,45),
                new MySqlParameter("@tonnage",MySqlDbType.Decimal,45),
                new MySqlParameter("@protein",MySqlDbType.Decimal,45),
                new MySqlParameter("@TVN",MySqlDbType.Decimal,45),
                new MySqlParameter("@acid",MySqlDbType.Decimal,45),
                new MySqlParameter("@Ash",MySqlDbType.Decimal,45),
                new MySqlParameter("@histamine",MySqlDbType.Decimal,45),
                new MySqlParameter("@Lysine",MySqlDbType.Decimal,45),
                new MySqlParameter("@Methionine",MySqlDbType.Decimal,45),
                new MySqlParameter("@Finishedproduct",MySqlDbType.VarChar,45),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@cost",MySqlDbType.Decimal,45),
                new MySqlParameter("@salt",MySqlDbType.Decimal,45),
            };
            parameter[0].Value = model.Code;
            parameter[1].Value = model.Goods;
            parameter[2].Value = model.Tonnage;
            parameter[3].Value = model.Protein;
            parameter[4].Value = model.TVN;
            parameter[5].Value = model.Acid;
            parameter[6].Value = model.Ash;
            parameter[7].Value = model.Histamine;
            parameter[8].Value = model.Lysine;
            parameter[9].Value = model.Methionine;
            parameter[10].Value = model.Finishedproduct;
            parameter[11].Value = model.Unitprice;
            parameter[12].Value = model.Cost;
            parameter[13].Value = model.Salt;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameter);
            return id;
        }
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_ingredientsdetail ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

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
        public List<FishEntity.ingredientsdetailEntity> GetDetailOfBill(int billId, string tcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_ingredients where code=@code");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar)
            };
            parameters[0].Value = tcode;
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            List<FishEntity.ingredientsdetailEntity> modelList = new List<FishEntity.ingredientsdetailEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {

                FishEntity.ingredientsdetailEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(ds.Tables[0].Rows[n]);
                    if (ds.Tables[0].Rows[n]["tonnage"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["tonnage"].ToString(), out temp);
                        model.Tonnage = temp;
                    }
                    if (ds.Tables[0].Rows[n]["protein"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["protein"].ToString(), out temp);
                        model.Protein = temp;
                    }
                    if (ds.Tables[0].Rows[n]["TVN"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["TVN"].ToString(), out temp);
                        model.TVN = temp;
                    }
                    if (ds.Tables[0].Rows[n]["salt"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["salt"].ToString(), out temp);
                        model.Salt = temp;
                    }
                    if (ds.Tables[0].Rows[n]["acid"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["acid"].ToString(), out temp);
                        model.Acid = temp;
                    }
                    if (ds.Tables[0].Rows[n]["Ash"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["Ash"].ToString(), out temp);
                        model.Ash = temp;
                    }
                    if (ds.Tables[0].Rows[n]["histamine"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["histamine"].ToString(), out temp);
                        model.Histamine = temp;
                    }
                    if (ds.Tables[0].Rows[n]["Lysine"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["Lysine"].ToString(), out temp);
                        model.Lysine = temp;
                    }
                    if (ds.Tables[0].Rows[n]["Methionine"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["Methionine"].ToString(), out temp);
                        model.Methionine = temp;
                    }
                    if (ds.Tables[0].Rows[n]["unitprice"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["unitprice"].ToString(), out temp);
                        model.Unitprice = temp;
                    }
                    if (ds.Tables[0].Rows[n]["cost"] != null)
                    {
                        decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["cost"].ToString(), out temp);
                        model.Cost = temp;
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        public FishEntity.ingredientsdetailEntity DataRowToModel(DataRow row)
        {
            FishEntity.ingredientsdetailEntity model = new FishEntity.ingredientsdetailEntity();
            if (row != null)
            {
                if (row["tid"] != null && row["tid"].ToString() != "")
                {
                    model.Id = int.Parse(row["tid"].ToString());
                }
                if (row["tcode"] != null && row["tcode"].ToString() != "")
                {
                    model.Code = row["tcode"].ToString();
                }
                if (row["Goods"] != null && row["Goods"].ToString() != "")
                {
                    model.Goods = row["Goods"].ToString();
                }
                if (row["tonnage"] != null && row["tonnage"].ToString() != "")
                {
                    model.Tonnage = decimal.Parse(row["tonnage"].ToString());
                }
                if (row["protein"] != null && row["protein"].ToString() != "")
                {
                    model.Protein = decimal.Parse(row["protein"].ToString());
                }
                if (row["TVN"] != null && row["TVN"].ToString() != "")
                {
                    model.TVN = decimal.Parse(row["TVN"].ToString());
                }
                if (row["salt"] != null && row["salt"].ToString() != "")
                {
                    model.Salt = decimal.Parse(row["salt"].ToString());
                }
                if (row["acid"] != null && row["acid"].ToString() != "")
                {
                    model.Acid = decimal.Parse(row["acid"].ToString());
                }
                if (row["Ash"] != null && row["Ash"].ToString() != "")
                {
                    model.Ash = decimal.Parse(row["Ash"].ToString());
                }
                if (row["histamine"] != null && row["histamine"].ToString() != "")
                {
                    model.Histamine = decimal.Parse(row["histamine"].ToString());
                }
                if (row["Lysine"] != null && row["Lysine"].ToString() != "")
                {
                    model.Lysine = decimal.Parse(row["Lysine"].ToString());
                }
                if (row["Methionine"] != null && row["Methionine"].ToString() != "")
                {
                    model.Methionine = decimal.Parse(row["Methionine"].ToString());
                }
                if (row["Finishedproduct"] != null && row["Finishedproduct"].ToString() != "")
                {
                    model.Finishedproduct = row["Finishedproduct"].ToString();
                }
                if (row["unitprice"] != null && row["unitprice"].ToString() != "")
                {
                    model.Unitprice = decimal.Parse(row["unitprice"].ToString());
                }
                if (row["unitprice"] != null && row["unitprice"].ToString() != "")
                {
                    model.Unitprice = decimal.Parse(row["unitprice"].ToString());
                }
                if (row["cost"] != null && row["cost"].ToString() != "")
                {
                    model.Cost = decimal.Parse(row["cost"].ToString());
                }

            }
            return model;
        }
        public bool Update_detail(FishEntity.ingredientsdetailEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_ingredientsdetail set ");
            strSql.Append("code=@code,");
            strSql.Append("Goods=@Goods,");
            strSql.Append("tonnage=@tonnage,");
            strSql.Append("protein=@protein,");
            strSql.Append("TVN=@TVN,");
            strSql.Append("acid=@acid,");
            strSql.Append("Ash=@Ash,");
            strSql.Append("histamine=@histamine,");
            strSql.Append("Lysine=@Lysine,");
            strSql.Append("Methionine=@Methionine,");
            strSql.Append("Finishedproduct=@Finishedproduct,");
            strSql.Append("unitprice=@unitprice,");
            strSql.Append("cost=@cost,");
            strSql.Append("salt=@salt ");
            strSql.Append("where id=@id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@Goods",MySqlDbType.VarChar,45),
                new MySqlParameter("@tonnage",MySqlDbType.Decimal,45),
                new MySqlParameter("@protein",MySqlDbType.Decimal,45),
                new MySqlParameter("@TVN",MySqlDbType.Decimal,45),
                new MySqlParameter("@acid",MySqlDbType.Decimal,45),
                new MySqlParameter("@Ash",MySqlDbType.Decimal,45),
                new MySqlParameter("@histamine",MySqlDbType.Decimal,45),
                new MySqlParameter("@Lysine",MySqlDbType.Decimal,45),
                new MySqlParameter("@Methionine",MySqlDbType.Decimal,45),
                new MySqlParameter("@Finishedproduct",MySqlDbType.VarChar,45),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@cost",MySqlDbType.Decimal,45),
                new MySqlParameter("@salt",MySqlDbType.Decimal,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Goods;
            parameters[2].Value = model.Tonnage;
            parameters[3].Value = model.Protein;
            parameters[4].Value = model.TVN;
            parameters[5].Value = model.Acid;
            parameters[6].Value = model.Ash;
            parameters[7].Value = model.Histamine;
            parameters[8].Value = model.Lysine;
            parameters[9].Value = model.Methionine;
            parameters[10].Value = model.Finishedproduct;
            parameters[11].Value = model.Unitprice;
            parameters[12].Value = model.Cost;
            parameters[13].Value = model.Salt;
            parameters[14].Value = model.Id;
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
        public bool Update(FishEntity.ingredientsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_ingredients set ");
            strSql.Append("code=@code,");
            strSql.Append("ProductionDate=@ProductionDate,");
            strSql.Append("Outoftime=@Outoftime,");
            strSql.Append("Brand=@Brand,");
            strSql.Append("tlabel=@tlabel,");
            strSql.Append("quality=@quality,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("modifytime=@modifytime,");
            strSql.Append("modifyman=@modifyman ");
            strSql.Append("where id=@id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@ProductionDate",MySqlDbType.DateTime),
                new MySqlParameter("@Outoftime",MySqlDbType.DateTime),
                new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@tlabel",MySqlDbType.VarChar,45),
                new MySqlParameter("@quality",MySqlDbType.VarChar,45),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.ProductionDate;
            parameters[2].Value = model.Outoftime;
            parameters[3].Value = model.Brand;
            parameters[4].Value = model.Tlabel;
            parameters[5].Value = model.Quality;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.Modifytime;
            parameters[8].Value = model.Modifyman;
            parameters[9].Value = model.Id;
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
