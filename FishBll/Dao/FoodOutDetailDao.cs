using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class FoodOutDetailDao
    {
        public FoodOutDetailDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_foodoutdetail");
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
		public int Add(FishEntity.FoodOutDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_foodoutdetail(");
			strSql.Append("mid,productid,tons,package,unitprice,cost,no,solutionid)");
			strSql.Append(" values (");
            strSql.Append("@mid,@productid,@tons,@package,@unitprice,@cost,@no,@solutionid);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,8),
					new MySqlParameter("@tons", MySqlDbType.Decimal,12),
					new MySqlParameter("@package", MySqlDbType.Int32,8),
                    new MySqlParameter("@unitprice",MySqlDbType.Decimal,12),
                    new MySqlParameter("@cost",MySqlDbType.Decimal ,12),
                    new MySqlParameter("@no",MySqlDbType.Int32 ,6),
                    new MySqlParameter("@solutionid",MySqlDbType.Int32 ,6)
                                          };
			parameters[0].Value = model.mid;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.tons;
			parameters[3].Value = model.package;
            parameters[4].Value = model.unitprice;
            parameters[5].Value = model.cost;
            parameters[6].Value = model.no;
            parameters[7].Value = model.solutionid;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.FoodOutDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_foodoutdetail set ");
			strSql.Append("mid=@mid,");
			strSql.Append("productid=@productid,");
			strSql.Append("tons=@tons,");
			strSql.Append("package=@package,");
            strSql.Append("unitprice=@unitprice,");
            strSql.Append("cost=@cost,");
            strSql.Append("no=@no,");
            strSql.Append("solutionid=@solutionid");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,8),
					new MySqlParameter("@tons", MySqlDbType.Decimal,12),
					new MySqlParameter("@package", MySqlDbType.Int32,8),
                    new MySqlParameter("@unitprice",MySqlDbType.Decimal ,12),
                    new MySqlParameter("@cost",MySqlDbType.Decimal ,12),
                     new MySqlParameter("@no",MySqlDbType.Int32 ,6),
                    new MySqlParameter("@solutionid",MySqlDbType.Int32 ,6),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.mid;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.tons;
			parameters[3].Value = model.package;
            parameters[4].Value = model.unitprice;
            parameters[5].Value = model.cost;
            parameters[6].Value = model.no;
            parameters[7].Value = model.solutionid;
			parameters[8].Value = model.id;

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
			strSql.Append("delete from t_foodoutdetail ");
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
        public bool DeleteByMid(int mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_foodoutdetail ");
            strSql.Append(" where mid ="+ mid);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_foodoutdetail ");
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
		public FishEntity.FoodOutDetailEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,mid,productid,tons,package,unitprice,cost,no,solutionid from t_foodoutdetail ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.FoodOutDetailEntity model=new FishEntity.FoodOutDetailEntity();
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
		public FishEntity.FoodOutDetailEntity DataRowToModel(DataRow row)
		{
			FishEntity.FoodOutDetailEntity model=new FishEntity.FoodOutDetailEntity();
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
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["tons"]!=null && row["tons"].ToString()!="")
				{
					model.tons=decimal.Parse(row["tons"].ToString());
				}
				if(row["package"]!=null && row["package"].ToString()!="")
				{
					model.package=int.Parse(row["package"].ToString());
				}
                if (row["unitprice"] != null && row["unitprice"].ToString() != "")
                {
                    model.unitprice = decimal.Parse(row["unitprice"].ToString());
                }
                if (row["cost"] != null && row["cost"].ToString() != "")
                {
                    model.cost = decimal.Parse(row["cost"].ToString());
                }
                if (row["no"] != null && row["no"].ToString() != "")
                {
                    model.no = int.Parse(row["no"].ToString());
                }
                if (row["solutionid"] != null && row["solutionid"].ToString() != "")
                {
                    model.solutionid = int.Parse(row["solutionid"].ToString());
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
            strSql.Append("select id,mid,productid,tons,package,unitprice,cost,no,solutionid ");
			strSql.Append(" FROM t_foodoutdetail ");
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
			strSql.Append("select count(1) FROM t_foodoutdetail ");
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
			strSql.Append(")AS Row, T.*  from t_foodoutdetail T ");
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
			parameters[0].Value = "t_foodoutdetail";
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
