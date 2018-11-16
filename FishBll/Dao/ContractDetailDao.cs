using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Dao
{
    public class ContractDetailDao
    {
        public ContractDetailDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_contractdetail");
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
		public int Add(FishEntity.ContractDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_contractdetail(");
            strSql.Append("contractid,no,productid,productno,productname,specification,weight,quantity, unitprice,money,getweight,getquantity,isfinished,nature,remark )");
			strSql.Append(" values (");
            strSql.Append("@contractid,@no,@productid,@productno,@productname,@specification,@weight,@quantity,@unitprice,@money,@getweight,@getquantity,@isfinished,@nature,@remark );");
            strSql.Append("select LAST_INSERT_ID();");

            MySqlParameter[] parameters = {
					new MySqlParameter("@contractid", MySqlDbType.Int32,11),
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productno", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,255),
					new MySqlParameter("@specification", MySqlDbType.VarChar,255),
					new MySqlParameter("@weight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quantity", MySqlDbType.Int32,6),
					new MySqlParameter("@unitprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@nature",MySqlDbType.VarChar,225),
                    new MySqlParameter("@remark",MySqlDbType.VarChar,200),
                    new MySqlParameter("@getweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@getquantity", MySqlDbType.Int32,6),
                    new MySqlParameter("@isfinished", MySqlDbType.Int32,2)
                                          };
			parameters[0].Value = model.contractid;
			parameters[1].Value = model.no;
			parameters[2].Value = model.productid;
			parameters[3].Value = model.productno;
			parameters[4].Value = model.productname;
			parameters[5].Value = model.specification;
            parameters[6].Value = model.weight;
			parameters[7].Value = model.quantity;
			parameters[8].Value = model.unitprice;
			parameters[9].Value = model.money;
            parameters[10].Value = model.nature;
            parameters[11].Value = model.remark;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.ContractDetailEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_contractdetail set ");
			strSql.Append("contractid=@contractid,");
			strSql.Append("no=@no,");
			strSql.Append("productid=@productid,");
			strSql.Append("productno=@productno,");
			strSql.Append("productname=@productname,");
			strSql.Append("specification=@specification,");
			strSql.Append("weight=@weight,");
            strSql.Append("quantity=@quantity,");
			strSql.Append("unitprice=@unitprice,");
			strSql.Append("money=@money,");
            strSql.Append("getweight=@getweight,");
            strSql.Append("getquantity=@getquantity,");
            strSql.Append("isfinished=@isfinished, ");
            strSql.Append("nature=@nature, ");
            strSql.Append("remark=@remark ");
            strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@contractid", MySqlDbType.Int32,11),
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productno", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,255),
					new MySqlParameter("@specification", MySqlDbType.VarChar,255),
					new MySqlParameter("@weight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quantity",MySqlDbType.Int32,6),
					new MySqlParameter("@unitprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@getweight", MySqlDbType.Decimal,8),
					new MySqlParameter("@getquantity", MySqlDbType.Int32,6),
					new MySqlParameter("@isfinished", MySqlDbType.Int16 ,2),
                    new MySqlParameter("@nature",MySqlDbType.VarChar,225),
                    new MySqlParameter("@remark",MySqlDbType.VarChar,200),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.contractid;
			parameters[1].Value = model.no;
			parameters[2].Value = model.productid;
			parameters[3].Value = model.productno;
			parameters[4].Value = model.productname;
			parameters[5].Value = model.specification;
			parameters[6].Value = model.weight;
            parameters[7].Value = model.quantity;
			parameters[8].Value = model.unitprice;
			parameters[9].Value = model.money;
            parameters[10].Value = model.getweight;
            parameters[11].Value = model.getquantity;
            parameters[12].Value = model.isfinished;
            parameters[13].Value = model.nature;
            parameters[14].Value = model.remark;
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
			strSql.Append("delete from t_contractdetail ");
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
			strSql.Append("delete from t_contractdetail ");
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
		public FishEntity.ContractDetailEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,contractid,no,productid,productno,productname,specification,weight,quantity,unitprice,money,getweight,getquantity,isfinished from t_contractdetail ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.ContractDetailEntity model=new FishEntity.ContractDetailEntity();
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
		public FishEntity.ContractDetailEntity DataRowToModel(DataRow row)
		{
			FishEntity.ContractDetailEntity model=new FishEntity.ContractDetailEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["contractid"]!=null && row["contractid"].ToString()!="")
				{
					model.contractid=int.Parse(row["contractid"].ToString());
				}
				if(row["no"]!=null && row["no"].ToString()!="")
				{
					model.no=int.Parse(row["no"].ToString());
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["productno"]!=null)
				{
					model.productno=row["productno"].ToString();
				}
				if(row["productname"]!=null)
				{
					model.productname=row["productname"].ToString();
				}
				if(row["specification"]!=null)
				{
					model.specification=row["specification"].ToString();
				}
                if (row["weight"] != null && row["weight"].ToString() != "")
				{
                    model.weight = decimal.Parse(row["weight"].ToString());
				}
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity =int.Parse( row["quantity"].ToString());
                }
				if(row["unitprice"]!=null && row["unitprice"].ToString()!="")
				{
					model.unitprice=decimal.Parse(row["unitprice"].ToString());
				}
				if(row["money"]!=null && row["money"].ToString()!="")
				{
					model.money=decimal.Parse(row["money"].ToString());
				}
                if (row["getweight"] != null && row["getweight"].ToString() != "")
                {
                    model.getweight = decimal.Parse(row["getweight"].ToString());
                }
                if (row["getquantity"] != null && row["getquantity"].ToString() != "")
                {
                    model.getquantity = int.Parse(row["getquantity"].ToString());
                }
                if (row["isfinished"] != null && row["isfinished"].ToString() != "")
                {
                    model.isfinished = int.Parse(row["isfinished"].ToString());
                }
                if (row["nature"] != null )
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
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
			strSql.Append("select id,contractid,no,productid,productno,productname,specification,weight,quantity,unitprice,money,getweight,getquantity,isfinished,nature,remark ");
			strSql.Append(" FROM t_contractdetail ");
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
			strSql.Append("select count(1) FROM t_contractdetail ");
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
			strSql.Append(")AS Row, T.*  from t_contractdetail T ");
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
			parameters[0].Value = "t_contractdetail";
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

        public bool UpdateContractWeight(int contractid, int detailid, decimal weight, int quantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_contractdetail set ");
            strSql.Append(" getweight=getweight + @getweight , getquantity=getquantity+@getquantity ");
            strSql.Append(" where contractid=@contractid and id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@getweight", MySqlDbType.Decimal),
					new MySqlParameter("@getquantity", MySqlDbType.Int32),
					new MySqlParameter("@contractid", MySqlDbType.Int32),
					new MySqlParameter("@id", MySqlDbType.Int32)
                                          };
            parameters[0].Value = weight;
            parameters[1].Value = quantity;
            parameters[2].Value = contractid;
            parameters[3].Value = detailid;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

		#endregion  ExtensionMethod
	
    }
}
