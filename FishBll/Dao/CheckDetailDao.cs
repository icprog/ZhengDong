using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CheckDetailDao
    {
        public CheckDetailDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_checkdetail");
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
		public int Add(FishEntity.CheckDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_checkdetail(");
            strSql.Append("mid,line,checkkey,checkvalue,orderid)");
			strSql.Append(" values (");
            strSql.Append("@mid,@line,@checkkey,@checkvalue,@orderid);");
            strSql.Append("select LAST_INSERT_ID();");

			MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32,11),
					new MySqlParameter("@line", MySqlDbType.Int32,11),
					new MySqlParameter("@checkkey", MySqlDbType.VarChar,100),
					new MySqlParameter("@checkvalue", MySqlDbType.VarChar,20),
					new MySqlParameter("@orderid", MySqlDbType.Int32,4)};
			parameters[0].Value = model.mid;
			parameters[1].Value = model.line;
            parameters[2].Value = model.checkkey;
            parameters[3].Value = model.checkvalue;
			parameters[4].Value = model.orderid;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CheckDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_checkdetail set ");
			strSql.Append("mid=@mid,");
			strSql.Append("line=@line,");
            strSql.Append("checkkey=@checkkey,");
            strSql.Append("checkvalue=@checkvalue,");
			strSql.Append("orderid=@orderid");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32,11),
					new MySqlParameter("@line", MySqlDbType.Int32,11),
					new MySqlParameter("@checkkey", MySqlDbType.VarChar,100),
					new MySqlParameter("@checkvalue", MySqlDbType.VarChar,20),
					new MySqlParameter("@orderid", MySqlDbType.Int32,4),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.mid;
			parameters[1].Value = model.line;
			parameters[2].Value = model.checkkey;
            parameters[3].Value = model.checkvalue;
			parameters[4].Value = model.orderid;
			parameters[5].Value = model.id;

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
        public bool DeleteByMid(int mid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_checkdetail ");
			strSql.Append(" where mid=@mid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32)
			};
			parameters[0].Value = mid;

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
			strSql.Append("delete from t_checkdetail ");
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
			strSql.Append("delete from t_checkdetail ");
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
		public FishEntity.CheckDetailEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,mid,line,checkkey,checkvalue,orderid from t_checkdetail ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.CheckDetailEntity model=new FishEntity.CheckDetailEntity();
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
		public FishEntity.CheckDetailEntity DataRowToModel(DataRow row)
		{
			FishEntity.CheckDetailEntity model=new FishEntity.CheckDetailEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["mid"]!=null && row["mid"].ToString()!="")
				{
					model.mid=int.Parse(row["mid"].ToString());
				}
				if(row["line"]!=null && row["line"].ToString()!="")
				{
					model.line=int.Parse(row["line"].ToString());
				}
                if (row["checkkey"] != null)
				{
                    model.checkkey = row["checkkey"].ToString();
				}
                if (row["checkvalue"] != null)
				{
                    model.checkvalue = row["checkvalue"].ToString();
				}
				if(row["orderid"]!=null && row["orderid"].ToString()!="")
				{
					model.orderid=int.Parse(row["orderid"].ToString());
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
            strSql.Append("select id,mid,line,checkkey,checkvalue,orderid ");
			strSql.Append(" FROM t_checkdetail ");
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
			strSql.Append("select count(1) FROM t_checkdetail ");
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
			strSql.Append(")AS Row, T.*  from t_checkdetail T ");
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
			parameters[0].Value = "t_checkdetail";
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
