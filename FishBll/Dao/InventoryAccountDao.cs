using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class InventoryAccountDao
    {
        public InventoryAccountDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_inventoryaccount");
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
		public bool Add(FishEntity.InventoryAccountEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_inventoryaccount(");
			strSql.Append("accountdate,productid,remainweight,remainquantity,homemadeweight,homemadepackages,createman,createtime,modifyman,modifytime,mid)");
			strSql.Append(" values (");
			strSql.Append("@accountdate,@productid,@remainweight,@remainquantity,@homemadeweight,@homemadepackages,@createman,@createtime,@modifyman,@modifytime,@mid)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@accountdate", MySqlDbType.Date),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@remainweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@remainquantity", MySqlDbType.Int32,8),
					new MySqlParameter("@homemadeweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@homemadepackages", MySqlDbType.Int32,8),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@mid",MySqlDbType.Int32,8)
                                          };
			parameters[0].Value = model.accountdate;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.remainweight;
			parameters[3].Value = model.remainquantity;
			parameters[4].Value = model.homemadeweight;
			parameters[5].Value = model.homemadepackages;
			parameters[6].Value = model.createman;
			parameters[7].Value = model.createtime;
			parameters[8].Value = model.modifyman;
			parameters[9].Value = model.modifytime;
            parameters[10].Value = model.mid;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.InventoryAccountEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_inventoryaccount set ");
			strSql.Append("accountdate=@accountdate,");
			strSql.Append("productid=@productid,");
			strSql.Append("remainweight=@remainweight,");
			strSql.Append("remainquantity=@remainquantity,");
			strSql.Append("homemadeweight=@homemadeweight,");
			strSql.Append("homemadepackages=@homemadepackages,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman,");
            strSql.Append("mid=@mid");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@accountdate", MySqlDbType.Date),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@remainweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@remainquantity", MySqlDbType.Int32,8),
					new MySqlParameter("@homemadeweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@homemadepackages", MySqlDbType.Int32,8),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter ("@mid",MySqlDbType.Int32,8),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.accountdate;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.remainweight;
			parameters[3].Value = model.remainquantity;
			parameters[4].Value = model.homemadeweight;
			parameters[5].Value = model.homemadepackages;
			parameters[6].Value = model.createman;
			parameters[7].Value = model.modifyman;
            parameters[8].Value = model.mid;
			parameters[9].Value = model.id;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_inventoryaccount ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_inventoryaccount ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=MySqlHelper.ExecuteSql(strSql.ToString());
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
		public FishEntity.InventoryAccountEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,mid,accountdate,productid,remainweight,remainquantity,homemadeweight,homemadepackages,createman,createtime,modifyman,modifytime from t_inventoryaccount ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.InventoryAccountEntity model=new FishEntity.InventoryAccountEntity();
			DataSet ds=MySqlHelper.Query(strSql.ToString(),parameters);
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
		public FishEntity.InventoryAccountEntity DataRowToModel(DataRow row)
		{
			FishEntity.InventoryAccountEntity model=new FishEntity.InventoryAccountEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
                if (row["mid"] != null && row["mid"].ToString() != "")
                {
                    model.mid = int.Parse(row["mid"].ToString());
                }
				if(row["accountdate"]!=null && row["accountdate"].ToString()!="")
				{
					model.accountdate=DateTime.Parse(row["accountdate"].ToString());
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["remainweight"]!=null && row["remainweight"].ToString()!="")
				{
					model.remainweight=decimal.Parse(row["remainweight"].ToString());
				}
				if(row["remainquantity"]!=null && row["remainquantity"].ToString()!="")
				{
					model.remainquantity=int.Parse(row["remainquantity"].ToString());
				}
				if(row["homemadeweight"]!=null && row["homemadeweight"].ToString()!="")
				{
					model.homemadeweight=decimal.Parse(row["homemadeweight"].ToString());
				}
				if(row["homemadepackages"]!=null && row["homemadepackages"].ToString()!="")
				{
					model.homemadepackages=int.Parse(row["homemadepackages"].ToString());
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
			strSql.Append("select id,mid,accountdate,productid,remainweight,remainquantity,homemadeweight,homemadepackages,createman,createtime,modifyman,modifytime ");
			strSql.Append(" FROM t_inventoryaccount ");
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
			strSql.Append("select count(1) FROM t_inventoryaccount ");
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
			strSql.Append(")AS Row, T.*  from t_inventoryaccount T ");
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
			parameters[0].Value = "t_inventoryaccount";
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
