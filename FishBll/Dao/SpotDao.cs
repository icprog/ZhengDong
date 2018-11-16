using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class SpotDao
    {
        public SpotDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_spot");
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
		public int Add(FishEntity.SpotEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_spot(");
			strSql.Append("no,companyid,companycode,company,customerid,customercode,customer,productid,dollars,rate,rmb,weight,quantity,spotdate,spottime,spotman,createman,createtime,modifyman,modifytime,isdelete)");
			strSql.Append(" values (");
			strSql.Append("@no,@companyid,@companycode,@company,@customerid,@customercode,@customer,@productid,@dollars,@rate,@rmb,@weight,@quantity,@spotdate,@spottime,@spotman,@createman,@createtime,@modifyman,@modifytime,@isdelete);");
            strSql.Append("select LAST_INSERT_ID();");

			MySqlParameter[] parameters = {
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@company", MySqlDbType.VarChar,255),
					new MySqlParameter("@customerid", MySqlDbType.Int32,11),
					new MySqlParameter("@customercode", MySqlDbType.VarChar,45),
					new MySqlParameter("@customer", MySqlDbType.VarChar,255),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@dollars", MySqlDbType.Decimal,12),
					new MySqlParameter("@rate", MySqlDbType.Decimal,10),
					new MySqlParameter("@rmb", MySqlDbType.Decimal,10),
					new MySqlParameter("@weight", MySqlDbType.Decimal,10),
					new MySqlParameter("@quantity", MySqlDbType.Int32,11),
					new MySqlParameter("@spotdate", MySqlDbType.Date),
					new MySqlParameter("@spottime", MySqlDbType.Time),
					new MySqlParameter("@spotman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,2)};
			parameters[0].Value = model.no;
			parameters[1].Value = model.companyid;
			parameters[2].Value = model.companycode;
			parameters[3].Value = model.company;
			parameters[4].Value = model.customerid;
			parameters[5].Value = model.customercode;
			parameters[6].Value = model.customer;
			parameters[7].Value = model.productid;
			parameters[8].Value = model.dollars;
			parameters[9].Value = model.rate;
			parameters[10].Value = model.rmb;
			parameters[11].Value = model.weight;
			parameters[12].Value = model.quantity;
            parameters[13].Value = model.spotdate.ToString("yyyy-MM-dd"); 
            parameters[14].Value = new TimeSpan(model.spotdate.Hour, model.spotdate.Minute, model.spotdate.Second);
			parameters[15].Value = model.spotman;
			parameters[16].Value = model.createman;
			parameters[17].Value = model.createtime;
			parameters[18].Value = model.modifyman;
			parameters[19].Value = model.modifytime;
			parameters[20].Value = model.isdelete;

            int rows = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return rows;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.SpotEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_spot set ");
			strSql.Append("no=@no,");
			strSql.Append("companyid=@companyid,");
			strSql.Append("companycode=@companycode,");
			strSql.Append("company=@company,");
			strSql.Append("customerid=@customerid,");
			strSql.Append("customercode=@customercode,");
			strSql.Append("customer=@customer,");
			strSql.Append("productid=@productid,");
			strSql.Append("dollars=@dollars,");
			strSql.Append("rate=@rate,");
			strSql.Append("rmb=@rmb,");
			strSql.Append("weight=@weight,");
			strSql.Append("quantity=@quantity,");
			strSql.Append("spotdate=@spotdate,");
			strSql.Append("spottime=@spottime,");
			strSql.Append("spotman=@spotman,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman,");
			strSql.Append("isdelete=@isdelete");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@company", MySqlDbType.VarChar,255),
					new MySqlParameter("@customerid", MySqlDbType.Int32,11),
					new MySqlParameter("@customercode", MySqlDbType.VarChar,45),
					new MySqlParameter("@customer", MySqlDbType.VarChar,255),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@dollars", MySqlDbType.Decimal,12),
					new MySqlParameter("@rate", MySqlDbType.Decimal,10),
					new MySqlParameter("@rmb", MySqlDbType.Decimal,10),
					new MySqlParameter("@weight", MySqlDbType.Decimal,10),
					new MySqlParameter("@quantity", MySqlDbType.Int32,11),
					new MySqlParameter("@spotdate", MySqlDbType.Date),
					new MySqlParameter("@spottime", MySqlDbType.Time),
					new MySqlParameter("@spotman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,2),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.no;
			parameters[1].Value = model.companyid;
			parameters[2].Value = model.companycode;
			parameters[3].Value = model.company;
			parameters[4].Value = model.customerid;
			parameters[5].Value = model.customercode;
			parameters[6].Value = model.customer;
			parameters[7].Value = model.productid;
			parameters[8].Value = model.dollars;
			parameters[9].Value = model.rate;
			parameters[10].Value = model.rmb;
			parameters[11].Value = model.weight;
			parameters[12].Value = model.quantity;
            parameters[13].Value = model.spotdate.ToString("yyyy-MM-dd"); ;
            parameters[14].Value = new TimeSpan(model.spotdate.Hour, model.spotdate.Minute, model.spotdate.Second);
			parameters[15].Value = model.spotman;
			parameters[16].Value = model.createman;
			parameters[17].Value = model.modifyman;
			parameters[18].Value = model.isdelete;
			parameters[19].Value = model.id;

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
			strSql.Append("delete from t_spot ");
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
        public bool Delete1(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_ssss ");
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
			strSql.Append("delete from t_spot ");
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
		public FishEntity.SpotEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,no,companyid,companycode,company,customerid,customercode,customer,productid,dollars,rate,rmb,weight,quantity,spotdate,spottime,spotman,createman,createtime,modifyman,modifytime,isdelete from t_spot ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.SpotEntity model=new FishEntity.SpotEntity();
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
		public FishEntity.SpotEntity DataRowToModel(DataRow row)
		{
			FishEntity.SpotEntity model=new FishEntity.SpotEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["no"]!=null && row["no"].ToString()!="")
				{
					model.no=int.Parse(row["no"].ToString());
				}
				if(row["companyid"]!=null && row["companyid"].ToString()!="")
				{
					model.companyid=int.Parse(row["companyid"].ToString());
				}
				if(row["companycode"]!=null)
				{
					model.companycode=row["companycode"].ToString();
				}
				if(row["company"]!=null)
				{
					model.company=row["company"].ToString();
				}
				if(row["customerid"]!=null && row["customerid"].ToString()!="")
				{
					model.customerid=int.Parse(row["customerid"].ToString());
				}
				if(row["customercode"]!=null)
				{
					model.customercode=row["customercode"].ToString();
				}
				if(row["customer"]!=null)
				{
					model.customer=row["customer"].ToString();
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["dollars"]!=null && row["dollars"].ToString()!="")
				{
					model.dollars=decimal.Parse(row["dollars"].ToString());
				}
				if(row["rate"]!=null && row["rate"].ToString()!="")
				{
					model.rate=decimal.Parse(row["rate"].ToString());
				}
				if(row["rmb"]!=null && row["rmb"].ToString()!="")
				{
					model.rmb=decimal.Parse(row["rmb"].ToString());
				}
				if(row["weight"]!=null && row["weight"].ToString()!="")
				{
					model.weight=decimal.Parse(row["weight"].ToString());
				}
				if(row["quantity"]!=null && row["quantity"].ToString()!="")
				{
					model.quantity=int.Parse(row["quantity"].ToString());
				}
				if(row["spotdate"]!=null && row["spotdate"].ToString()!="")
				{
					model.spotdate=DateTime.Parse(row["spotdate"].ToString());
				}
				if(row["spottime"]!=null && row["spottime"].ToString()!="")
				{
					model.spottime=DateTime.Parse(row["spottime"].ToString());
				}
				if(row["spotman"]!=null)
				{
					model.spotman=row["spotman"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,no,companyid,companycode,company,customerid,customercode,customer,productid,dollars,rate,rmb,weight,quantity,spotdate,spottime,spotman,createman,createtime,modifyman,modifytime,isdelete ");
			strSql.Append(" FROM t_spot ");
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
			strSql.Append("select count(1) FROM t_spot ");
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
			strSql.Append(")AS Row, T.*  from t_spot T ");
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
			parameters[0].Value = "t_spot";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        public bool UpdateSpotInfo(int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_productex a inner join ");
            strSql.Append(" ( select * from t_spot  where productid= " + productid + " order by spotdate desc , spottime desc limit 1 ) b on a.id=b.productid ");
            strSql.Append(" set a.spotdollars =b.dollars , a.spotrmb = b.rmb ,");
            strSql.Append("  a.spotagent = b.company , a.spotagentcode= b.companycode,");
            strSql.Append(" a.spotlinkman= b.customer,a.spotlinkmancode=b.customercode, ");
            strSql.Append(" a.spotweight = b.weight, a.spotquantity=b.quantity,");
            strSql.Append(" a.spotdate= CONCAT( DATE_FORMAT( b.spotdate , '%Y/%m/%d ') , TIME_FORMAT(spottime ,'%H:%i:%s') ), ");
            strSql.Append(" a.spotstoragedate= CONCAT( DATE_FORMAT( b.spotdate , '%Y/%m/%d ') , TIME_FORMAT(spottime ,'%H:%i:%s') ) ");

            int rows = MySqlHelper.ExecuteSql(strSql.ToString());
            return rows > 0 ? true : false;
        }

        public bool UpdateSpotInfo(int productid, decimal dollors, decimal rmb, string companycode,
           string company, string linkmancode, string linkman, string spotdatestr, decimal weight, int quantity,string storagedatestr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_productex ");
            strSql.Append(" set spotdollars =@spotdollars , spotrmb = @spotrmb ,");
            //strSql.Append(" spotagent = @spotagent , spotagentcode= @spotagentcode,");
            //strSql.Append(" spotlinkman= @spotlinkman,spotlinkmancode=@spotlinkmancode, ");
            strSql.Append("saletrader=@saletrader,saletradercode=@saletradercode,");
            strSql.Append("salelinkmancode=@salelinkmancode,salelinkman=@salelinkman,");
            strSql.Append(" spotweight = @spotweight, spotquantity=@spotquantity,");
            strSql.Append(" spotdate= @spotdate,spotstoragedate=@spotstoragedate, saleremainweight = saleremainweight - @saleremainweight  ");
            strSql.Append(" where id=@id");

            MySqlParameter[] parameters = {
					new MySqlParameter("@spotdollars", MySqlDbType.Decimal),
					new MySqlParameter("@spotrmb", MySqlDbType.Decimal),
					//new MySqlParameter("@spotagent", MySqlDbType.VarChar,255),
                    //new MySqlParameter("@spotagentcode", MySqlDbType.VarChar,45),
                    //new MySqlParameter("@spotlinkman", MySqlDbType.VarChar,200),
                    //new MySqlParameter("@spotlinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saletrader",MySqlDbType.VarChar,255),
                    new MySqlParameter("@saletradercode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@salelinkman",MySqlDbType.VarChar,200),
                    new MySqlParameter("@salelinkmancode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotweight", MySqlDbType.Decimal),
                    new MySqlParameter("@spotquantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@spotdate", MySqlDbType.VarChar,18),
                    new MySqlParameter("@spotstoragedate", MySqlDbType.VarChar,18),
                    new MySqlParameter("@saleremainweight",MySqlDbType.Decimal,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = dollors;
            parameters[1].Value = rmb;
            parameters[2].Value = company;
            parameters[3].Value = companycode;
            parameters[4].Value = linkman;
            parameters[5].Value = linkmancode;
            parameters[6].Value = weight;
            parameters[7].Value = quantity;
            parameters[8].Value = spotdatestr;
            parameters[9].Value = storagedatestr;
            parameters[10].Value = weight;
            parameters[11].Value = productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

		#endregion  ExtensionMethod
    }
}
