using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class LoadingBillsDao
    {            
        public LoadingBillsDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_loadingbills");
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
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_loadingbills");
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
		public int Add(FishEntity.LoadingBillsEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_loadingbills(");
			strSql.Append("code,signdate,billmanid,billman,companyid,companycode,company,warehouse,storagefee,createman,createtime,modifyman,modifytime)");
			strSql.Append(" values (");
			strSql.Append("@code,@signdate,@billmanid,@billman,@companyid,@companycode,@company,@warehouse,@storagefee,@createman,@createtime,@modifyman,@modifytime);");
            strSql.Append("select LAST_INSERT_ID();");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,20),
					new MySqlParameter("@signdate", MySqlDbType.Timestamp),
					new MySqlParameter("@billmanid", MySqlDbType.Int32,11),
					new MySqlParameter("@billman", MySqlDbType.VarChar,45),
					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@company", MySqlDbType.VarChar,100),
					new MySqlParameter("@warehouse", MySqlDbType.VarChar,100),
					new MySqlParameter("@storagefee", MySqlDbType.Decimal,12),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.signdate;
			parameters[2].Value = model.billmanid;
			parameters[3].Value = model.billman;
			parameters[4].Value = model.companyid;
			parameters[5].Value = model.companycode;
			parameters[6].Value = model.company;
			parameters[7].Value = model.warehouse;
			parameters[8].Value = model.storagefee;
			parameters[9].Value = model.createman;
			parameters[10].Value = model.createtime;
			parameters[11].Value = model.modifyman;
			parameters[12].Value = model.modifytime;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.LoadingBillsEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_loadingbills set ");
			strSql.Append("code=@code,");
			strSql.Append("billmanid=@billmanid,");
			strSql.Append("billman=@billman,");
			strSql.Append("companyid=@companyid,");
			strSql.Append("companycode=@companycode,");
			strSql.Append("company=@company,");
			strSql.Append("warehouse=@warehouse,");
			strSql.Append("storagefee=@storagefee,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,20),
					new MySqlParameter("@billmanid", MySqlDbType.Int32,11),
					new MySqlParameter("@billman", MySqlDbType.VarChar,45),
					new MySqlParameter("@companyid", MySqlDbType.Int32,11),
					new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@company", MySqlDbType.VarChar,100),
					new MySqlParameter("@warehouse", MySqlDbType.VarChar,100),
					new MySqlParameter("@storagefee", MySqlDbType.Decimal,12),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.billmanid;
			parameters[2].Value = model.billman;
			parameters[3].Value = model.companyid;
			parameters[4].Value = model.companycode;
			parameters[5].Value = model.company;
			parameters[6].Value = model.warehouse;
			parameters[7].Value = model.storagefee;
			parameters[8].Value = model.createman;
			parameters[9].Value = model.modifyman;
			parameters[10].Value = model.id;

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
			strSql.Append("delete from t_loadingbills ");
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
			strSql.Append("delete from t_loadingbills ");
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
		public FishEntity.LoadingBillsEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,code,signdate,billmanid,billman,companyid,companycode,company,warehouse,storagefee,createman,createtime,modifyman,modifytime from t_loadingbills ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.LoadingBillsEntity model=new FishEntity.LoadingBillsEntity();
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
		public FishEntity.LoadingBillsEntity DataRowToModel(DataRow row)
		{
			FishEntity.LoadingBillsEntity model=new FishEntity.LoadingBillsEntity();
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
				if(row["signdate"]!=null && row["signdate"].ToString()!="")
				{
					model.signdate=DateTime.Parse(row["signdate"].ToString());
				}
				if(row["billmanid"]!=null && row["billmanid"].ToString()!="")
				{
					model.billmanid=int.Parse(row["billmanid"].ToString());
				}
				if(row["billman"]!=null)
				{
					model.billman=row["billman"].ToString();
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
				if(row["warehouse"]!=null)
				{
					model.warehouse=row["warehouse"].ToString();
				}
				if(row["storagefee"]!=null && row["storagefee"].ToString()!="")
				{
					model.storagefee=decimal.Parse(row["storagefee"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,code,signdate,billmanid,billman,companyid,companycode,company,warehouse,storagefee,createman,createtime,modifyman,modifytime ");
			strSql.Append(" FROM t_loadingbills ");
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
			strSql.Append("select count(1) FROM t_loadingbills ");
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
			strSql.Append(")AS Row, T.*  from t_loadingbills T ");
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
			parameters[0].Value = "t_loadingbills";
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
