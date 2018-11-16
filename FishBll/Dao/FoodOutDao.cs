using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class FoodOutDao
    {
        public FoodOutDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_foodout");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists( string  code )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_foodout");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45)
			};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.FoodOutEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_foodout(");
            strSql.Append("code,productdate,outdate,productid,productcode,productlabel,weight,package,remark,createman,createtime,modifyman,modifytime,cost,deliverymanid,deliveryman,solutionid,salemanid,saleman,indate,companyid,companycode,companyname,Brand,quality)");
			strSql.Append(" values (");
            strSql.Append("@code,@productdate,@outdate,@productid,@productcode,@productlabel,@weight,@package,@remark,@createman,@createtime,@modifyman,@modifytime,@cost,@deliverymanid,@deliveryman,@solutionid,@salemanid,@saleman,@indate,@companyid,@companycode,@companyname,@Brand,@quality);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,20),
					new MySqlParameter("@productdate", MySqlDbType.Timestamp),
					new MySqlParameter("@outdate", MySqlDbType.Timestamp),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productlabel", MySqlDbType.VarChar,45),
					new MySqlParameter("@weight", MySqlDbType.Decimal,12),
					new MySqlParameter("@package", MySqlDbType.Int32,8),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@cost",MySqlDbType.Decimal ,12),
                    new MySqlParameter("@deliverymanid", MySqlDbType.Int32,11),
					new MySqlParameter("@deliveryman", MySqlDbType.VarChar,255),
					new MySqlParameter("@solutionid", MySqlDbType.Int32,11),
					new MySqlParameter("@salemanid", MySqlDbType.Int32,45),
					new MySqlParameter("@saleman", MySqlDbType.VarChar,255),
					new MySqlParameter("@indate", MySqlDbType.Timestamp),
					new MySqlParameter("@companyid", MySqlDbType.Int32,6),
					new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@companyname", MySqlDbType.VarChar,225),
                    new MySqlParameter("@Brand",MySqlDbType.VarChar,45),
                    new MySqlParameter("@quality",MySqlDbType.VarChar,45)
                                          };
			parameters[0].Value = model.code;
			parameters[1].Value = model.productdate;
			parameters[2].Value = model.outdate;
			parameters[3].Value = model.productid;
			parameters[4].Value = model.productcode;
			parameters[5].Value = model.productlabel;
			parameters[6].Value = model.weight;
			parameters[7].Value = model.package;
			parameters[8].Value = model.remark;
			parameters[9].Value = model.createman;
			parameters[10].Value = model.createtime;
			parameters[11].Value = model.modifyman;
			parameters[12].Value = model.modifytime;
            parameters[13].Value = model.cost;
            parameters[14].Value = model.deliverymanid;
            parameters[15].Value = model.deliveryman;
            parameters[16].Value = model.solutionid;
            parameters[17].Value = model.salemanid;
            parameters[18].Value = model.saleman;
            parameters[19].Value = model.indate;
            parameters[20].Value = model.companyid;
            parameters[21].Value = model.companycode;
            parameters[22].Value = model.companyname;
            parameters[23].Value = model.Brand;
            parameters[24].Value = model.Quality;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.FoodOutEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_foodout set ");
			strSql.Append("code=@code,");
			strSql.Append("productid=@productid,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("productlabel=@productlabel,");
			strSql.Append("weight=@weight,");
			strSql.Append("package=@package,");
			strSql.Append("remark=@remark,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman,");
            strSql.Append("cost=@cost,");
            strSql.Append("deliverymanid=@deliverymanid,");
            strSql.Append("deliveryman=@deliveryman,");
            strSql.Append("solutionid=@solutionid,");
            strSql.Append("salemanid=@salemanid,");
            strSql.Append("saleman=@saleman,");
            strSql.Append("indate=@indate,");
            strSql.Append("outdate=@outdate,");
            strSql.Append("companyid=@companyid,");
            strSql.Append("companycode=@companycode,");
            strSql.Append("companyname=@companyname");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,20),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productlabel", MySqlDbType.VarChar,45),
					new MySqlParameter("@weight", MySqlDbType.Decimal,12),
					new MySqlParameter("@package", MySqlDbType.Int32,8),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cost",MySqlDbType.Decimal,12),
                    new MySqlParameter("@deliverymanid", MySqlDbType.Int32,11),
					new MySqlParameter("@deliveryman", MySqlDbType.VarChar,255),
					new MySqlParameter("@solutionid", MySqlDbType.Int32,11),
					new MySqlParameter("@salemanid", MySqlDbType.Int32,45),
					new MySqlParameter("@saleman", MySqlDbType.VarChar,255),
					new MySqlParameter("@indate", MySqlDbType.Timestamp),
					new MySqlParameter("@outdate", MySqlDbType.Timestamp),
                    new MySqlParameter("@companyid", MySqlDbType.Int32,6),
                    new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@companyname", MySqlDbType.VarChar,225),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.productcode;
			parameters[3].Value = model.productlabel;
			parameters[4].Value = model.weight;
			parameters[5].Value = model.package;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.createman;
			parameters[8].Value = model.modifyman;
            parameters[9].Value = model.cost;
            parameters[10].Value = model.deliverymanid;
            parameters[11].Value = model.deliveryman;
            parameters[12].Value = model.solutionid;
            parameters[13].Value = model.salemanid;
            parameters[14].Value = model.saleman;
            parameters[15].Value = model.indate;
            parameters[16].Value = model.outdate;
            parameters[17].Value = model.companyid;
            parameters[18].Value = model.companycode;
            parameters[19].Value = model.companyname;
			parameters[20].Value = model.id;

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
			strSql.Append("delete from t_foodout ");
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
			strSql.Append("delete from t_foodout ");
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
		public FishEntity.FoodOutEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,code,productdate,outdate,productid,productcode,productlabel,weight,package,remark,createman,createtime,modifyman,modifytime,cost,deliverymanid,deliveryman,solutionid,salemanid,saleman,indate,companyid,companycode,companyname from t_foodout ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.FoodOutEntity model=new FishEntity.FoodOutEntity();
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
		public FishEntity.FoodOutEntity DataRowToModel(DataRow row)
		{
			FishEntity.FoodOutEntity model=new FishEntity.FoodOutEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["productdate"]!=null && row["productdate"].ToString()!="")
				{
					model.productdate=DateTime.Parse(row["productdate"].ToString());
				}
				if(row["outdate"]!=null && row["outdate"].ToString()!="")
				{
					model.outdate=DateTime.Parse(row["outdate"].ToString());
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["productcode"]!=null)
				{
					model.productcode=row["productcode"].ToString();
				}
				if(row["productlabel"]!=null)
				{
					model.productlabel=row["productlabel"].ToString();
				}
				if(row["weight"]!=null && row["weight"].ToString()!="")
				{
					model.weight=decimal.Parse(row["weight"].ToString());
				}
				if(row["package"]!=null && row["package"].ToString()!="")
				{
					model.package=int.Parse(row["package"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
                if (row["cost"] != null && row["cost"].ToString() != "")
                {
                    model.cost = decimal.Parse(row["cost"].ToString());
                }
                if (row["deliverymanid"] != null && row["deliverymanid"].ToString() != "")
                {
                    model.deliverymanid = int.Parse(row["deliverymanid"].ToString());
                }
                if (row["deliveryman"] != null)
                {
                    model.deliveryman = row["deliveryman"].ToString();
                }
                if (row["solutionid"] != null && row["solutionid"].ToString() != "")
                {
                    model.solutionid = int.Parse(row["solutionid"].ToString());
                }
                if (row["salemanid"] != null && row["salemanid"].ToString() != "")
                {
                    model.salemanid = int.Parse(row["salemanid"].ToString());
                }
                if (row["saleman"] != null)
                {
                    model.saleman = row["saleman"].ToString();
                }
                if (row["indate"] != null && row["indate"].ToString() != "")
                {
                    model.indate = DateTime.Parse(row["indate"].ToString());
                }
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }
                if (row["companycode"] != null)
                {
                    model.companycode = row["companycode"].ToString();
                }
                if (row["companyname"] != null)
                {
                    model.companyname = row["companyname"].ToString();
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
            strSql.Append("select id,code,productdate,outdate,productid,productcode,productlabel,weight,package,remark,createman,createtime,modifyman,modifytime,cost,deliverymanid,deliveryman,solutionid,salemanid,saleman,indate,companyid,companycode,companyname ");
			strSql.Append(" FROM t_foodout ");
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
			strSql.Append("select count(1) FROM t_foodout ");
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
			strSql.Append(")AS Row, T.*  from t_foodout T ");
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
			parameters[0].Value = "t_foodout";
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

		#endregion  ExtensionMethod
    }
}
