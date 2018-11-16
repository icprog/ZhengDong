using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
   public class SaleDaoEx
    {
        public SaleDaoEx() { }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,companyid, companycode, customerid ,customercode,productid,saledollars,saledate,saletime,saleman,createman,createtime,modifyman,modifytime,isdelete,company,customer,no,salermb,weight,sgsweight,saleweight,rate,quantity ");
            strSql.Append(" FROM t_sale ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public FishEntity.SaleEntity DataRowToModel(DataRow row)
        {
            FishEntity.SaleEntity model = new FishEntity.SaleEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }
                if (row["customerid"] != null && row["customerid"].ToString() != "")
                {
                    model.customerid = int.Parse(row["customerid"].ToString());
                }
                if (row["productid"] != null && row["productid"].ToString() != "")
                {
                    model.productid = int.Parse(row["productid"].ToString());
                }
                if (row["saledollars"] != null && row["saledollars"].ToString() != "")
                {
                    model.saledollars = decimal.Parse(row["saledollars"].ToString());
                }
                if (row["saledate"] != null && row["saledate"].ToString() != "")
                {
                    model.saledate = DateTime.Parse(row["saledate"].ToString());
                }
                if (row["saletime"] != null && row["saletime"].ToString() != "")
                {
                    model.saletime = DateTime.Parse(row["saletime"].ToString());
                }
                if (row["saleman"] != null)
                {
                    model.saleman = row["saleman"].ToString();
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["modifyman"] != null)
                {
                    model.modifyman = row["modifyman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                if (row["companycode"] != null)
                {
                    model.companycode = row["companycode"].ToString();
                }
                if (row["customercode"] != null)
                {
                    model.customercode = row["customercode"].ToString();
                }
                if (row["company"] != null)
                {
                    model.company = row["company"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }

                if (row["no"] != null && row["no"].ToString() != "")
                {
                    model.no = int.Parse(row["no"].ToString());
                }

                if (row["weight"] != null && row["weight"].ToString() != "")
                {
                    model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["sgsweight"] != null && row["sgsweight"].ToString() != "")
                {
                    model.sgsweight = decimal.Parse(row["sgsweight"].ToString());
                }
                if (row["saleweight"] != null && row["saleweight"].ToString() != "")
                {
                    model.saleweight = decimal.Parse(row["saleweight"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(row["quantity"].ToString());
                }
                if (row["salermb"] != null && row["salermb"].ToString() != "")
                {
                    model.salermb = decimal.Parse(row["salermb"].ToString());
                }
                if (row["rate"] != null && row["rate"].ToString() != "")
                {
                    model.rate = decimal.Parse(row["rate"].ToString());
                }               
            }
            return model;
        }
        public int Add(FishEntity.SaleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_sale(");
            strSql.Append("companyid,companycode,customerid, customercode, productid,saledollars,saledate,saletime,saleman,createman,createtime,modifyman,modifytime,isdelete,no,company,customer,weight,sgsweight,saleweight,quantity,salermb,rate)");
            strSql.Append(" values (");
            strSql.Append("@companyid,@companycode ,@customerid,@customercode,@productid,@saledollars,@saledate,@saletime,@saleman,@createman,@createtime,@modifyman,@modifytime,@isdelete,@no,@company,@customer,@weight,@sgsweight,@saleweight,@quantity,@salermb,@rate);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@companyid", MySqlDbType.Int32,11),
                    new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customerid", MySqlDbType.Int32,11),
                    new MySqlParameter("@customercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@productid", MySqlDbType.Int32,11),
                    new MySqlParameter("@saledollars", MySqlDbType.Decimal,12),
                    new MySqlParameter("@saledate", MySqlDbType.Date),
                    new MySqlParameter("@saletime", MySqlDbType.Time),
                    new MySqlParameter("@saleman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@isdelete", MySqlDbType.Int16,2),
                       new MySqlParameter("@no", MySqlDbType.Int16,2),
                    new MySqlParameter("@company", MySqlDbType.VarChar,225),
                    new MySqlParameter("@customer", MySqlDbType.VarChar,225),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,12),
                   new MySqlParameter("@quantity", MySqlDbType.Int32,6),
                   new MySqlParameter("@salermb", MySqlDbType.Decimal,12),
                    new MySqlParameter("@rate", MySqlDbType.Decimal,12),
                    new MySqlParameter("@sgsweight", MySqlDbType.Decimal,12),
                    new MySqlParameter("@saleweight", MySqlDbType.Decimal,12),
                                          };
            parameters[0].Value = model.companyid;
            parameters[1].Value = model.companycode;
            parameters[2].Value = model.customerid;
            parameters[3].Value = model.customercode;
            parameters[4].Value = model.productid;
            parameters[5].Value = model.saledollars;
            parameters[6].Value = model.saledate.Value.ToString("yyyy-MM-dd");
            parameters[7].Value = new TimeSpan(model.saletime.Value.Hour, model.saletime.Value.Minute, model.saletime.Value.Second);// model.saletime.Value.ToString("HH:mm:ss");
            parameters[8].Value = model.saleman;
            parameters[9].Value = model.createman;
            parameters[10].Value = model.createtime;
            parameters[11].Value = model.modifyman;
            parameters[12].Value = model.modifytime;
            parameters[13].Value = model.isdelete;
            parameters[14].Value = model.no;
            parameters[15].Value = model.company;
            parameters[16].Value = model.customer;
            parameters[17].Value = model.weight;
            parameters[18].Value = model.quantity;
            parameters[19].Value = model.salermb;
            parameters[20].Value = model.rate;
            parameters[21].Value = model.sgsweight;
            parameters[22].Value = model.saleweight;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        public bool Update(FishEntity.SaleEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_sale set ");
            strSql.Append("companyid=@companyid,");
            strSql.Append("customerid=@customerid,");
            strSql.Append("productid=@productid,");
            strSql.Append("saledollars=@saledollars,");
            strSql.Append("saledate=@saledate,");
            strSql.Append("saletime=@saletime,");
            strSql.Append("saleman=@saleman,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("isdelete=@isdelete,");
            strSql.Append("companycode=@companycode,");
            strSql.Append("customercode=@customercode,");
            strSql.Append("company=@company,");
            strSql.Append("customer=@customer,");
            strSql.Append("weight=@weight,");
            strSql.Append("sgsweight=@sgsweight,");
            strSql.Append("saleweight=@saleweight,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("salermb=@salermb,");
            strSql.Append("rate=@rate ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@companyid", MySqlDbType.Int32,11),
                    new MySqlParameter("@customerid", MySqlDbType.Int32,11),
                    new MySqlParameter("@productid", MySqlDbType.Int32,11),
                    new MySqlParameter("@saledollars", MySqlDbType.Decimal,12),
                    new MySqlParameter("@saledate", MySqlDbType.Date),
                    new MySqlParameter("@saletime", MySqlDbType.Time),
                    new MySqlParameter("@saleman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@isdelete", MySqlDbType.Int16,2),
                    new MySqlParameter("@companycode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@customercode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@no", MySqlDbType.Int16,2),
                    new MySqlParameter("@company", MySqlDbType.VarChar,225),
                    new MySqlParameter("@customer", MySqlDbType.VarChar,225),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,12),
                   new MySqlParameter("@quantity", MySqlDbType.Int32,6),
                   new MySqlParameter("@salermb", MySqlDbType.Decimal,12),
                    new MySqlParameter("@rate", MySqlDbType.Decimal,12),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@sgsweight", MySqlDbType.Decimal,12),
                    new MySqlParameter("@saleweight", MySqlDbType.Decimal,12),
            };
            parameters[0].Value = model.companyid;
            parameters[1].Value = model.customerid;
            parameters[2].Value = model.productid;
            parameters[3].Value = model.saledollars;
            parameters[4].Value = model.saledate.Value.ToString("yyyy-MM-dd");
            parameters[5].Value = new TimeSpan(model.saletime.Value.Hour, model.saletime.Value.Minute, model.saletime.Value.Second);
            parameters[6].Value = model.saleman;
            parameters[7].Value = model.createman;
            parameters[8].Value = model.modifyman;
            parameters[9].Value = model.isdelete;
            parameters[10].Value = model.companycode;
            parameters[11].Value = model.customercode;
            parameters[12].Value = model.no;
            parameters[13].Value = model.company;
            parameters[14].Value = model.customer;
            parameters[15].Value = model.weight;
            parameters[16].Value = model.quantity;
            parameters[17].Value = model.salermb;
            parameters[18].Value = model.rate;
            parameters[19].Value = model.id;
            parameters[20].Value = model.sgsweight;
            parameters[21].Value = model.saleweight;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_sale ");
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
        public bool UpdateLatestSale(int productid,string Saletime,decimal salermb,decimal saleremainweight,decimal SaleNumWeight)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_productex ");
            strSql.Append(" set Saletime =@Saletime , salermb = @salermb ,");
            strSql.Append(" saleremainweight = @saleremainweight , SaleNumWeight= @SaleNumWeight ");
            strSql.Append(" where id=@id");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@Saletime", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salermb", MySqlDbType.Decimal),
                    new MySqlParameter("@saleremainweight", MySqlDbType.Decimal),
                    new MySqlParameter("@SaleNumWeight", MySqlDbType.Decimal),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = Saletime;
            parameters[1].Value = salermb;
            parameters[2].Value = saleremainweight;
            parameters[3].Value = SaleNumWeight;
            parameters[4].Value = productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }
    }
}
