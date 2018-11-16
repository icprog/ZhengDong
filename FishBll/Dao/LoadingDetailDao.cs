using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class LoadingDetailDao
    {
        public LoadingDetailDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_loadingdetail");
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
		public int Add(FishEntity.LoadingDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_loadingdetail(");
            strSql.Append("mid,productid,productcode,product,specification,shipname,billofgoods,tons,packages,remark,unitprice,contractid,contractno,contractseq,contractdetailid)");
			strSql.Append(" values (");
            strSql.Append("@mid,@productid,@productcode,@product,@specification,@shipname,@billofgoods,@tons,@packages,@remark,@unitprice,@contractid,@contractno,@contractseq,@contractdetailid);");
            strSql.Append("select LAST_INSERT_ID();");
			MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@product", MySqlDbType.VarChar,50),
					new MySqlParameter("@specification", MySqlDbType.VarChar,45),
					new MySqlParameter("@shipname", MySqlDbType.VarChar,50),
					new MySqlParameter("@billofgoods", MySqlDbType.VarChar,45),
					new MySqlParameter("@tons", MySqlDbType.Decimal,12),
					new MySqlParameter("@packages", MySqlDbType.Int32,11),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                     new MySqlParameter("@unitprice",MySqlDbType.Decimal ,12),
                     new MySqlParameter("@contractid",MySqlDbType.Int32 ,8),
                     new MySqlParameter("@contractno",MySqlDbType.VarChar ,45),
                     new MySqlParameter("@contractseq",MySqlDbType.Int32 ,10),
                      new MySqlParameter("@contractdetailid",MySqlDbType.Int32 ,10)
                     
                                          };
			parameters[0].Value = model.mid;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.productcode;
			parameters[3].Value = model.product;
			parameters[4].Value = model.specification;
			parameters[5].Value = model.shipname;
			parameters[6].Value = model.billofgoods;
			parameters[7].Value = model.tons;
			parameters[8].Value = model.packages;
			parameters[9].Value = model.remark;
            parameters[10].Value = model.unitprice;
            parameters[11].Value = model.contractid;
            parameters[12].Value = model.contractno;
            parameters[13].Value = model.contractseq;
            parameters[14].Value = model.contractdetailid;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.LoadingDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_loadingdetail set ");
			strSql.Append("mid=@mid,");
			strSql.Append("productid=@productid,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("product=@product,");
			strSql.Append("specification=@specification,");
			strSql.Append("shipname=@shipname,");
			strSql.Append("billofgoods=@billofgoods,");
			strSql.Append("tons=@tons,");
			strSql.Append("packages=@packages,");
			strSql.Append("remark=@remark,");
            strSql.Append("unitprice=@unitprice,");
            strSql.Append("contractid=@contractid,");
            strSql.Append("contractno=@contractno,");
            strSql.Append("contractseq=@contractseq,");
            strSql.Append("contractdetailid=@contractdetailid");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@product", MySqlDbType.VarChar,50),
					new MySqlParameter("@specification", MySqlDbType.VarChar,45),
					new MySqlParameter("@shipname", MySqlDbType.VarChar,50),
					new MySqlParameter("@billofgoods", MySqlDbType.VarChar,45),
					new MySqlParameter("@tons", MySqlDbType.Decimal,12),
					new MySqlParameter("@packages", MySqlDbType.Int32,11),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@unitprice",MySqlDbType.Decimal ,12),
                    new MySqlParameter("@contractid",MySqlDbType.Int32 ,12),
                    new MySqlParameter("@contractno",MySqlDbType.VarChar ,45),
                    new MySqlParameter("@contractseq",MySqlDbType.Int32 ,12),
                    new MySqlParameter("@contractdetailid",MySqlDbType.Int32,11),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.mid;
			parameters[1].Value = model.productid;
			parameters[2].Value = model.productcode;
			parameters[3].Value = model.product;
			parameters[4].Value = model.specification;
			parameters[5].Value = model.shipname;
			parameters[6].Value = model.billofgoods;
			parameters[7].Value = model.tons;
			parameters[8].Value = model.packages;
			parameters[9].Value = model.remark;
            parameters[10].Value = model.unitprice;
            parameters[11].Value = model.contractid;
            parameters[12].Value = model.contractno;
            parameters[13].Value = model.contractseq;
            parameters[14].Value = model.contractdetailid;
			parameters[15].Value = model.id;

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
			strSql.Append("delete from t_loadingdetail ");
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
            strSql.Append("delete from t_loadingdetail ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_loadingdetail ");
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
		public FishEntity.LoadingDetailEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,mid,productid,productcode,product,specification,shipname,billofgoods,tons,packages,remark,unitprice,contractid,contractno,contractseq,contractdetailid from t_loadingdetail ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.LoadingDetailEntity model=new FishEntity.LoadingDetailEntity();
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
		public FishEntity.LoadingDetailEntity DataRowToModel(DataRow row)
		{
			FishEntity.LoadingDetailEntity model=new FishEntity.LoadingDetailEntity();
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
				if(row["productcode"]!=null)
				{
					model.productcode=row["productcode"].ToString();
				}
				if(row["product"]!=null)
				{
					model.product=row["product"].ToString();
				}
				if(row["specification"]!=null)
				{
					model.specification=row["specification"].ToString();
				}
				if(row["shipname"]!=null)
				{
					model.shipname=row["shipname"].ToString();
				}
				if(row["billofgoods"]!=null)
				{
					model.billofgoods=row["billofgoods"].ToString();
				}
				if(row["tons"]!=null && row["tons"].ToString()!="")
				{
					model.tons=decimal.Parse(row["tons"].ToString());
				}
				if(row["packages"]!=null && row["packages"].ToString()!="")
				{
					model.packages=int.Parse(row["packages"].ToString());
				}
                if (row["unitprice"] != null && row["unitprice"].ToString() != "")
				{
                    model.unitprice = decimal.Parse(row["unitprice"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
                if (row["contractid"] != null && row["contractid"].ToString() !="" )
                {
                    model.contractid = int.Parse ( row["contractid"].ToString());
                }
                if (row["contractno"] != null)
                {
                    model.contractno = row["contractno"].ToString();
                }
                if (row["contractseq"] != null && row["contractseq"].ToString() !="" )
                {
                    model.contractseq =int.Parse ( row["contractseq"].ToString());
                }
                if (row["contractdetailid"] != null && row["contractdetailid"].ToString() != "")
                {
                    model.contractdetailid = int.Parse(row["contractdetailid"].ToString());
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
            strSql.Append("select id,mid,productid,productcode,product,specification,shipname,billofgoods,tons,packages,remark,unitprice,contractid,contractno,contractseq,contractdetailid ");
			strSql.Append(" FROM t_loadingdetail ");
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
			strSql.Append("select count(1) FROM t_loadingdetail ");
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
			strSql.Append(")AS Row, T.*  from t_loadingdetail T ");
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
			parameters[0].Value = "t_loadingdetail";
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
