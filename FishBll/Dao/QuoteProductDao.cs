using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class QuoteProductDao
    {
        public QuoteProductDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_quoteproduct");
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
		public int Add(FishEntity.QuoteProductEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_quoteproduct(");
            strSql.Append("no,name,brand,nature,remark,companyid)");
			strSql.Append(" values (");
            strSql.Append("@no,@name,@brand,@nature,@remark,@companyid);");
            strSql.Append("select LAST_INSERT_ID();");

			MySqlParameter[] parameters = {
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@brand", MySqlDbType.VarChar,255),
					new MySqlParameter("@nature", MySqlDbType.VarChar,255),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@companyid", MySqlDbType.Int32,11)
                                          };
			parameters[0].Value = model.no;
			parameters[1].Value = model.name;
			parameters[2].Value = model.brand;
			parameters[3].Value = model.nature;
			parameters[4].Value = model.remark;
            parameters[5].Value = model.companyid;

            int rows = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return rows;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.QuoteProductEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_quoteproduct set ");
			strSql.Append("no=@no,");
			strSql.Append("name=@name,");
			strSql.Append("brand=@brand,");
			strSql.Append("nature=@nature,");
			strSql.Append("remark=@remark,");
            strSql.Append("companyid=@companyid");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@brand", MySqlDbType.VarChar,255),
					new MySqlParameter("@nature", MySqlDbType.VarChar,255),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.no;
			parameters[1].Value = model.name;
			parameters[2].Value = model.brand;
			parameters[3].Value = model.nature;
			parameters[4].Value = model.remark;
            parameters[5].Value = model.companyid;
			parameters[6].Value = model.id;

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
			strSql.Append("delete from t_quoteproduct ");
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
			strSql.Append("delete from t_quoteproduct ");
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
		public FishEntity.QuoteProductEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,no,name,brand,nature,remark,companyid from t_quoteproduct ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.QuoteProductEntity model=new FishEntity.QuoteProductEntity();
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
		public FishEntity.QuoteProductEntity DataRowToModel(DataRow row)//
		{
			FishEntity.QuoteProductEntity model=new FishEntity.QuoteProductEntity();
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
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["brand"]!=null)
				{
					model.brand=row["brand"].ToString();
				}
				if(row["nature"]!=null)
				{
					model.nature=row["nature"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
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
			strSql.Append("select id,no,name,brand,nature,remark,companyid ");
			strSql.Append(" FROM t_quoteproduct ");
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
			strSql.Append("select count(1) FROM t_quoteproduct ");
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
			strSql.Append(")AS Row, T.*  from t_quoteproduct T ");
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
			parameters[0].Value = "t_quoteproduct";
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
