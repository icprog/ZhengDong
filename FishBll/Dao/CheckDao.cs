using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CheckDao
    {
        public CheckDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_check");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_check");
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
		public int Add(FishEntity.CheckEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_check(");
            strSql.Append("code,checkdate,checkunitid,checkunitcode,checkunit,checkfee,productid,productcode,productname,remark,createman,createtime,modifyman,modifytime)");
			strSql.Append(" values (");
            strSql.Append("@code,@checkdate,@checkunitid,@checkunitcode,@checkunit,@checkfee,@productid,@productcode,@productname,@remark,@createman,@createtime,@modifyman,@modifytime);");
            strSql.Append("select LAST_INSERT_ID();");

            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,20),
					new MySqlParameter("@checkdate", MySqlDbType.Timestamp),
					new MySqlParameter("@checkunitid", MySqlDbType.Int32,8),
					new MySqlParameter("@checkunitcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@checkunit", MySqlDbType.VarChar,100),
					new MySqlParameter("@checkfee", MySqlDbType.Decimal,12),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,50),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp)
                                          };
			parameters[0].Value = model.code;
			parameters[1].Value = model.checkdate;
			parameters[2].Value = model.checkunitid;
			parameters[3].Value = model.checkunitcode;
			parameters[4].Value = model.checkunit;
			parameters[5].Value = model.checkfee;
			parameters[6].Value = model.productid;
			parameters[7].Value = model.productcode;
			parameters[8].Value = model.productname;
			parameters[9].Value = model.remark;
            parameters[10].Value = model.createman;
            parameters[11].Value = model.createtime;
            parameters[12].Value = model.modifyman;
            parameters[13].Value = model.modifytime;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CheckEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_check set ");
			strSql.Append("code=@code,");
			strSql.Append("checkunitid=@checkunitid,");
			strSql.Append("checkunitcode=@checkunitcode,");
			strSql.Append("checkunit=@checkunit,");
			strSql.Append("checkfee=@checkfee,");
			strSql.Append("productid=@productid,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("productname=@productname,");
			strSql.Append("remark=@remark,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("modifytime=@modifytime");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,20),
					new MySqlParameter("@checkunitid", MySqlDbType.Int32,8),
					new MySqlParameter("@checkunitcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@checkunit", MySqlDbType.VarChar,100),
					new MySqlParameter("@checkfee", MySqlDbType.Decimal,12),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,50),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.checkunitid;
			parameters[2].Value = model.checkunitcode;
			parameters[3].Value = model.checkunit;
			parameters[4].Value = model.checkfee;
			parameters[5].Value = model.productid;
			parameters[6].Value = model.productcode;
			parameters[7].Value = model.productname;
			parameters[8].Value = model.remark;
            parameters[9].Value = model.modifyman;
            parameters[10].Value = model.modifytime;
			parameters[11].Value = model.id;

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
			strSql.Append("delete from t_check ");
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
			strSql.Append("delete from t_check ");
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
		public FishEntity.CheckEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,code,checkdate,checkunitid,checkunitcode,checkunit,checkfee,productid,productcode,productname,remark,createman,createtime,modifyman,modifytime from t_check ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.CheckEntity model=new FishEntity.CheckEntity();
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
		public FishEntity.CheckEntity DataRowToModel(DataRow row)
		{
			FishEntity.CheckEntity model=new FishEntity.CheckEntity();
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
				if(row["checkdate"]!=null && row["checkdate"].ToString()!="")
				{
					model.checkdate=DateTime.Parse(row["checkdate"].ToString());
				}
				if(row["checkunitid"]!=null && row["checkunitid"].ToString()!="")
				{
					model.checkunitid=int.Parse(row["checkunitid"].ToString());
				}
				if(row["checkunitcode"]!=null)
				{
					model.checkunitcode=row["checkunitcode"].ToString();
				}
				if(row["checkunit"]!=null)
				{
					model.checkunit=row["checkunit"].ToString();
				}
				if(row["checkfee"]!=null && row["checkfee"].ToString()!="")
				{
					model.checkfee=decimal.Parse(row["checkfee"].ToString());
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["productcode"]!=null)
				{
					model.productcode=row["productcode"].ToString();
				}
				if(row["productname"]!=null)
				{
					model.productname=row["productname"].ToString();
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,code,checkdate,checkunitid,checkunitcode,checkunit,checkfee,productid,productcode,productname,remark,createman,createtime,modifyman,modifytime ");
			strSql.Append(" FROM t_check ");
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
			strSql.Append("select count(1) FROM t_check ");
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
			strSql.Append(")AS Row, T.*  from t_check T ");
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
			parameters[0].Value = "t_check";
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
