using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class QuoteDao
    {      
        public QuoteDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_quote");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.QuoteEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_quote(");
			strSql.Append("companyid,companycode,customerid, customercode, productid,quotedollars,quotedate,quotetime,quoteman,createman,createtime,modifyman,modifytime,isdelete,no,company,customer,weight,quantity,quotermb,rate,Counter_offer_companyid,Counter_offer_companycode,Counter_offer_customerid,Counter_offer_customercode,Counter_offer_date,Counter_offer_time,Counter_offer_Company,Counter_offer_Contacts,Counter_offer_weight,Counter_offer_Number,Counter_offer_HuiLv,Counter_offer_Dollar,Counter_offer_RMB)");
			strSql.Append(" values (");
            strSql.Append("@companyid,@companycode ,@customerid,@customercode,@productid,@quotedollars,@quotedate,@quotetime,@quoteman,@createman,@createtime,@modifyman,@modifytime,@isdelete,@no,@company,@customer,@weight,@quantity,@quotermb,@rate,@Counter_offer_companyid,@Counter_offer_companycode,@Counter_offer_customerid,@Counter_offer_customercode,@Counter_offer_date,@Counter_offer_time,@Counter_offer_Company,@Counter_offer_Contacts,@Counter_offer_weight,@Counter_offer_Number,@Counter_offer_HuiLv,@Counter_offer_Dollar,@Counter_offer_RMB);");
            strSql.Append("select LAST_INSERT_ID();");
			MySqlParameter[] parameters = {
					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
                    new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@customerid", MySqlDbType.Int32,11),
                    new MySqlParameter("@customercode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@quotedollars", MySqlDbType.Decimal,12),
					new MySqlParameter("@quotedate", MySqlDbType.Date),
					new MySqlParameter("@quotetime", MySqlDbType.Time),
					new MySqlParameter("@quoteman", MySqlDbType.VarChar,45),
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
                   new MySqlParameter("@quotermb", MySqlDbType.Decimal,12),
					new MySqlParameter("@rate", MySqlDbType.Decimal,12),

                    new MySqlParameter("@Counter_offer_companyid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Counter_offer_companycode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_customerid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Counter_offer_customercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_date", MySqlDbType.Date),
                    new MySqlParameter("@Counter_offer_time", MySqlDbType.Time),
                    new MySqlParameter("@Counter_offer_Company", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_Contacts", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_weight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Counter_offer_Number", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_HuiLv", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Counter_offer_Dollar", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Counter_offer_RMB", MySqlDbType.Decimal,45),
                                          };
			parameters[0].Value = model.companyid;
            parameters[1].Value = model.companycode;
			parameters[2].Value = model.customerid;
            parameters[3].Value = model.customercode;
			parameters[4].Value = model.productid;
			parameters[5].Value = model.quotedollars;
			parameters[6].Value = model.quotedate.Value.ToString("yyyy-MM-dd");
            parameters[7].Value = new TimeSpan(model.quotetime.Value.Hour, model.quotetime.Value.Minute, model.quotetime.Value.Second);// model.quotetime.Value.ToString("HH:mm:ss");
			parameters[8].Value = model.quoteman;
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
            parameters[19].Value = model.quotermb;
            parameters[20].Value = model.rate;


            parameters[21].Value = model.Counter_offer_companyid;
            parameters[22].Value = model.Counter_offer_companycode;
            parameters[23].Value = model.Counter_offer_customerid;
            parameters[24].Value = model.Counter_offer_customercode;
            parameters[25].Value = model.Counter_offer_date.Value.ToString("yyyy-MM-dd");
            parameters[26].Value = new TimeSpan(model.Counter_offer_time.Value.Hour, model.Counter_offer_time.Value.Minute, model.Counter_offer_time.Value.Second);// model.Counter_offer_time.Value.ToString("HH:mm:ss");
            parameters[27].Value = model.Counter_offer_Company;
            parameters[28].Value = model.Counter_offer_Contacts;
            parameters[29].Value = model.Counter_offer_weight;
            parameters[30].Value = model.Counter_offer_Number;
            parameters[31].Value = model.Counter_offer_HuiLv;
            parameters[32].Value = model.Counter_offer_Dollar;
            parameters[33].Value = model.Counter_offer_RMB;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.QuoteEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_quote set ");
            strSql.Append("companyid=@companyid,");
			strSql.Append("customerid=@customerid,");
			strSql.Append("productid=@productid,");
			strSql.Append("quotedollars=@quotedollars,");
			strSql.Append("quotedate=@quotedate,");
			strSql.Append("quotetime=@quotetime,");
			strSql.Append("quoteman=@quoteman,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman,");
			strSql.Append("isdelete=@isdelete,");
            strSql.Append("companycode=@companycode,");
            strSql.Append("customercode=@customercode,");
            strSql.Append("company=@company,");
            strSql.Append("customer=@customer,");
            strSql.Append("weight=@weight,");
            strSql.Append("quantity=@quantity,");
            strSql.Append("quotermb=@quotermb,");
            strSql.Append("rate=@rate,");


            strSql.Append("Counter_offer_companyid=@Counter_offer_companyid,");
            strSql.Append("Counter_offer_companycode=@Counter_offer_companycode,");
            strSql.Append("Counter_offer_customerid=@Counter_offer_customerid,");
            strSql.Append("Counter_offer_customercode=@Counter_offer_customercode,");
            strSql.Append("Counter_offer_date=@Counter_offer_date,");
            strSql.Append("Counter_offer_time=@Counter_offer_time,");
            strSql.Append("Counter_offer_Company=@Counter_offer_Company,");
            strSql.Append("Counter_offer_Contacts=@Counter_offer_Contacts,");
            strSql.Append("Counter_offer_weight=@Counter_offer_weight,");
            strSql.Append("Counter_offer_Number=@Counter_offer_Number,");
            strSql.Append("Counter_offer_HuiLv=@Counter_offer_HuiLv,");
            strSql.Append("Counter_offer_Dollar=@Counter_offer_Dollar,");
            strSql.Append("Counter_offer_RMB=@Counter_offer_RMB ");

            strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@customerid", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@quotedollars", MySqlDbType.Decimal,12),
					new MySqlParameter("@quotedate", MySqlDbType.Date),
					new MySqlParameter("@quotetime", MySqlDbType.Time),
					new MySqlParameter("@quoteman", MySqlDbType.VarChar,45),
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
                   new MySqlParameter("@quotermb", MySqlDbType.Decimal,12),
					new MySqlParameter("@rate", MySqlDbType.Decimal,12),
					new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@Counter_offer_companyid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Counter_offer_companycode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_customerid", MySqlDbType.Int32,11),
                    new MySqlParameter("@Counter_offer_customercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_date", MySqlDbType.Date),
                    new MySqlParameter("@Counter_offer_time", MySqlDbType.Time),
                    new MySqlParameter("@Counter_offer_Company", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_Contacts", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_weight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Counter_offer_Number", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Counter_offer_HuiLv", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Counter_offer_Dollar", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Counter_offer_RMB", MySqlDbType.Decimal,45),};
			parameters[0].Value = model.companyid;
			parameters[1].Value = model.customerid;
			parameters[2].Value = model.productid;
			parameters[3].Value = model.quotedollars;
			parameters[4].Value = model.quotedate.Value.ToString("yyyy-MM-dd");
			parameters[5].Value = new TimeSpan( model.quotetime.Value.Hour , model.quotetime.Value.Minute , model.quotetime.Value.Second );
			parameters[6].Value = model.quoteman;
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
            parameters[17].Value = model.quotermb;
            parameters[18].Value = model.rate;

			parameters[19].Value = model.id;

            parameters[20].Value = model.Counter_offer_companyid;
            parameters[21].Value = model.Counter_offer_companycode;
            parameters[22].Value = model.Counter_offer_customerid;
            parameters[23].Value = model.Counter_offer_customercode;
            parameters[24].Value = model.Counter_offer_date.Value.ToString("yyyy-MM-dd");
            parameters[25].Value = new TimeSpan(model.Counter_offer_time.Value.Hour, model.Counter_offer_time.Value.Minute, model.Counter_offer_time.Value.Second);// model.Counter_offer_time.Value.ToString("HH:mm:ss");
            parameters[26].Value = model.Counter_offer_Company;
            parameters[27].Value = model.Counter_offer_Contacts;
            parameters[28].Value = model.Counter_offer_weight;
            parameters[29].Value = model.Counter_offer_Number;
            parameters[30].Value = model.Counter_offer_HuiLv;
            parameters[31].Value = model.Counter_offer_Dollar;
            parameters[32].Value = model.Counter_offer_RMB;

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

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_quote ");
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
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_quote ");
			strSql.Append(" where id in ("+idlist + ")  ");
            int rows = MySqlHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.QuoteEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid,companycode,customerid,customercode,productid,quotedollars,quotedate,quotetime,quoteman,createman,createtime,modifyman,modifytime,isdelete, no ,company,customer,weight,quantity,quotermb,rate,Counter_offer_companyid,Counter_offer_companycode,Counter_offer_customerid,Counter_offer_customercode,Counter_offer_date,Counter_offer_time,Counter_offer_Company,Counter_offer_Contacts,Counter_offer_weight,Counter_offer_Number,Counter_offer_HuiLv,Counter_offer_Dollar,Counter_offer_RMB from t_quote ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.QuoteEntity model=new FishEntity.QuoteEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.QuoteEntity DataRowToModel(DataRow row)
		{
			FishEntity.QuoteEntity model=new FishEntity.QuoteEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["companyid"]!=null && row["companyid"].ToString()!="")
				{
					model.companyid=int.Parse(row["companyid"].ToString());
				}
				if(row["customerid"]!=null && row["customerid"].ToString()!="")
				{
					model.customerid=int.Parse(row["customerid"].ToString());
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["quotedollars"]!=null && row["quotedollars"].ToString()!="")
				{
					model.quotedollars=decimal.Parse(row["quotedollars"].ToString());
				}
				if(row["quotedate"]!=null && row["quotedate"].ToString()!="")
				{
					model.quotedate=DateTime.Parse(row["quotedate"].ToString());
				}
				if(row["quotetime"]!=null && row["quotetime"].ToString()!="")
				{
					model.quotetime=DateTime.Parse(row["quotetime"].ToString());
				}
				if(row["quoteman"]!=null)
				{
					model.quoteman=row["quoteman"].ToString();
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["modifyman"]!=null)
				{
					model.modifyman=row["modifyman"].ToString();
				}
				if(row["modifytime"]!=null && row["modifytime"].ToString()!="")
				{
					model.modifytime=DateTime.Parse(row["modifytime"].ToString());
				}
				if(row["isdelete"]!=null && row["isdelete"].ToString()!="")
				{
					model.isdelete=int.Parse(row["isdelete"].ToString());
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

                if (row["no"] != null && row["no"].ToString() !="" )
                {
                    model.no = int.Parse ( row["no"].ToString());
                }

                if (row["weight"] != null && row["weight"].ToString() != "")
                {
                    model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(row["quantity"].ToString());
                }
                if (row["quotermb"] != null && row["quotermb"].ToString() != "")
                {
                    model.quotermb = decimal.Parse(row["quotermb"].ToString());
                }
                if (row["rate"] != null && row["rate"].ToString() != "")
                {
                    model.rate = decimal.Parse(row["rate"].ToString());
                }
                //,Counter_offer_companyid,Counter_offer_companycode,Counter_offer_customerid,Counter_offer_customercode,Counter_offer_date,Counter_offer_time,Counter_offer_Company,Counter_offer_Contacts,Counter_offer_weight,Counter_offer_Number,Counter_offer_HuiLv,Counter_offer_Dollar,Counter_offer_RMB
                if (row["Counter_offer_companyid"]!=null&&row["Counter_offer_companyid"].ToString()!="")
                {
                    model.Counter_offer_companyid =int.Parse( row["Counter_offer_companyid"].ToString());
                }
                if (row["Counter_offer_companycode"]!=null)
                {
                    model.Counter_offer_companycode = row["Counter_offer_companycode"].ToString();
                }
                if (row["Counter_offer_customerid"] != null && row["Counter_offer_customerid"].ToString() != "")
                {
                    model.Counter_offer_customerid = int.Parse(row["Counter_offer_customerid"].ToString());
                }
                if (row["Counter_offer_customercode"] != null)
                {
                    model.Counter_offer_customercode = row["Counter_offer_customercode"].ToString();
                }
                if (row["Counter_offer_date"] != null&&row["Counter_offer_date"].ToString()!="")
                {
                    model.Counter_offer_date =DateTime.Parse( row["Counter_offer_date"].ToString());
                }
                if (row["Counter_offer_time"] != null && row["Counter_offer_time"].ToString() != "")
                {
                    model.Counter_offer_time = DateTime.Parse(row["Counter_offer_time"].ToString());
                }
                if (row["Counter_offer_Company"] != null)
                {
                    model.Counter_offer_Company = row["Counter_offer_Company"].ToString();
                }
                if (row["Counter_offer_Contacts"] != null)
                {
                    model.Counter_offer_Contacts = row["Counter_offer_Contacts"].ToString();
                }
                if (row["Counter_offer_weight"] != null && row["Counter_offer_weight"].ToString() != "")
                {
                    model.Counter_offer_weight = decimal.Parse(row["Counter_offer_weight"].ToString());
                }
                if (row["Counter_offer_Number"] != null)
                {
                    model.Counter_offer_Number = row["Counter_offer_Number"].ToString();
                }
                if (row["Counter_offer_HuiLv"] != null && row["Counter_offer_HuiLv"].ToString() != "")
                {
                    model.Counter_offer_HuiLv = decimal.Parse(row["Counter_offer_HuiLv"].ToString());
                }
                if (row["Counter_offer_Dollar"] != null && row["Counter_offer_Dollar"].ToString() != "")
                {
                    model.Counter_offer_Dollar = decimal.Parse(row["Counter_offer_Dollar"].ToString());
                }
                if (row["Counter_offer_RMB"] != null && row["Counter_offer_RMB"].ToString() != "")
                {
                    model.Counter_offer_RMB = decimal.Parse(row["Counter_offer_RMB"].ToString());
                }
            }
            return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,companyid, companycode, customerid ,customercode,productid,quotedollars,quotedate,quotetime,quoteman,createman,createtime,modifyman,modifytime,isdelete,company,customer,no,quotermb,rate,weight,quantity,Counter_offer_companyid,Counter_offer_companycode,Counter_offer_customerid,Counter_offer_customercode,Counter_offer_date,Counter_offer_time,Counter_offer_Company,Counter_offer_Contacts,Counter_offer_weight,Counter_offer_Number,Counter_offer_HuiLv,Counter_offer_Dollar,Counter_offer_RMB ");
			strSql.Append(" FROM t_quote ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return MySqlHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_quote ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            object obj = MySqlHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from t_quote T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySqlHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_quote";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
