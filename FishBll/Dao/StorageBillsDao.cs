using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
        public class StorageBillsDao
    {
        public  StorageBillsDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_storagebills");
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
            strSql.Append("select count(1) from t_storagebills");
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
		public int Add(FishEntity.StorageBillsEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_storagebills(");
			strSql.Append("code,operatecode,delegateunitid,delegateunitcode,delegateunit,deliverybills,productid,productcode,productname,unboxdate,place,tons,number,actualnumber,remark,location,createtime,createman,modifyman,modifytime,isdelete,shipno)");
			strSql.Append(" values (");
			strSql.Append("@code,@operatecode,@delegateunitid,@delegateunitcode,@delegateunit,@deliverybills,@productid,@productcode,@productname,@unboxdate,@place,@tons,@number,@actualnumber,@remark,@location,@createtime,@createman,@modifyman,@modifytime,@isdelete,@shipno);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@operatecode", MySqlDbType.VarChar,45),
					new MySqlParameter("@delegateunitid", MySqlDbType.Int32,8),
					new MySqlParameter("@delegateunitcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@delegateunit", MySqlDbType.VarChar,100),
					new MySqlParameter("@deliverybills", MySqlDbType.VarChar,45),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,50),
					new MySqlParameter("@unboxdate", MySqlDbType.Timestamp),
					new MySqlParameter("@place", MySqlDbType.VarChar,100),
					new MySqlParameter("@tons", MySqlDbType.Decimal,12),
					new MySqlParameter("@number", MySqlDbType.Int32,11),
					new MySqlParameter("@actualnumber", MySqlDbType.Int32,11),
					new MySqlParameter("@remark", MySqlDbType.VarChar,200),
					new MySqlParameter("@location", MySqlDbType.VarChar,200),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@isdelete", MySqlDbType.UInt16,2),
                    new MySqlParameter("@shipno", MySqlDbType.VarChar,45),   
                                          };
			parameters[0].Value = model.code;
			parameters[1].Value = model.operatecode;
			parameters[2].Value = model.delegateunitid;
			parameters[3].Value = model.delegateunitcode;
			parameters[4].Value = model.delegateunit;
			parameters[5].Value = model.deliverybills;
			parameters[6].Value = model.productid;
			parameters[7].Value = model.productcode;
			parameters[8].Value = model.productname;
			parameters[9].Value = model.unboxdate;
			parameters[10].Value = model.place;
			parameters[11].Value = model.tons;
			parameters[12].Value = model.number;
			parameters[13].Value = model.actualnumber;
			parameters[14].Value = model.remark;
			parameters[15].Value = model.location;
			parameters[16].Value = model.createtime;
			parameters[17].Value = model.createman;
			parameters[18].Value = model.modifyman;
			parameters[19].Value = model.modifytime;
			parameters[20].Value = model.isdelete;
            parameters[21].Value = model.shipno;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.StorageBillsEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_storagebills set ");
			strSql.Append("code=@code,");
			strSql.Append("operatecode=@operatecode,");
			strSql.Append("delegateunitid=@delegateunitid,");
			strSql.Append("delegateunitcode=@delegateunitcode,");
			strSql.Append("delegateunit=@delegateunit,");
			strSql.Append("deliverybills=@deliverybills,");
			strSql.Append("productid=@productid,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("productname=@productname,");
			strSql.Append("place=@place,");
			strSql.Append("tons=@tons,");
			strSql.Append("number=@number,");
			strSql.Append("actualnumber=@actualnumber,");
			strSql.Append("remark=@remark,");
			strSql.Append("location=@location,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman,");
			strSql.Append("isdelete=@isdelete,");
            strSql.Append("shipno=@shipno");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@operatecode", MySqlDbType.VarChar,45),
					new MySqlParameter("@delegateunitid", MySqlDbType.Int32,8),
					new MySqlParameter("@delegateunitcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@delegateunit", MySqlDbType.VarChar,100),
					new MySqlParameter("@deliverybills", MySqlDbType.VarChar,45),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,50),
					new MySqlParameter("@place", MySqlDbType.VarChar,100),
					new MySqlParameter("@tons", MySqlDbType.Decimal,12),
					new MySqlParameter("@number", MySqlDbType.Int32,11),
					new MySqlParameter("@actualnumber", MySqlDbType.Int32,11),
					new MySqlParameter("@remark", MySqlDbType.VarChar,200),
					new MySqlParameter("@location", MySqlDbType.VarChar,200),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.UInt16,2),
					new MySqlParameter("@shipno", MySqlDbType.VarChar,45),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.operatecode;
			parameters[2].Value = model.delegateunitid;
			parameters[3].Value = model.delegateunitcode;
			parameters[4].Value = model.delegateunit;
			parameters[5].Value = model.deliverybills;
			parameters[6].Value = model.productid;
			parameters[7].Value = model.productcode;
			parameters[8].Value = model.productname;
			parameters[9].Value = model.place;
			parameters[10].Value = model.tons;
			parameters[11].Value = model.number;
			parameters[12].Value = model.actualnumber;
			parameters[13].Value = model.remark;
			parameters[14].Value = model.location;
			parameters[15].Value = model.createman;
			parameters[16].Value = model.modifyman;
			parameters[17].Value = model.isdelete;
            parameters[18].Value = model.shipno;
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
			strSql.Append("delete from t_storagebills ");
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
			strSql.Append("delete from t_storagebills ");
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
		public FishEntity.StorageBillsEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,code,operatecode,delegateunitid,delegateunitcode,delegateunit,deliverybills,productid,productcode,productname,unboxdate,place,tons,number,actualnumber,remark,location,createtime,createman,modifyman,modifytime,isdelete,shipno from t_storagebills ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.StorageBillsEntity model=new FishEntity.StorageBillsEntity();
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
		public FishEntity.StorageBillsEntity DataRowToModel(DataRow row)
		{
			FishEntity.StorageBillsEntity model=new FishEntity.StorageBillsEntity();
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
				if(row["operatecode"]!=null)
				{
					model.operatecode=row["operatecode"].ToString();
				}
				if(row["delegateunitid"]!=null && row["delegateunitid"].ToString()!="")
				{
					model.delegateunitid=int.Parse(row["delegateunitid"].ToString());
				}
				if(row["delegateunitcode"]!=null)
				{
					model.delegateunitcode=row["delegateunitcode"].ToString();
				}
				if(row["delegateunit"]!=null)
				{
					model.delegateunit=row["delegateunit"].ToString();
				}
				if(row["deliverybills"]!=null)
				{
					model.deliverybills=row["deliverybills"].ToString();
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
				if(row["unboxdate"]!=null && row["unboxdate"].ToString()!="")
				{
					model.unboxdate=DateTime.Parse(row["unboxdate"].ToString());
				}
				if(row["place"]!=null)
				{
					model.place=row["place"].ToString();
				}
				if(row["tons"]!=null && row["tons"].ToString()!="")
				{
					model.tons=decimal.Parse(row["tons"].ToString());
				}
				if(row["number"]!=null && row["number"].ToString()!="")
				{
					model.number=int.Parse(row["number"].ToString());
				}
				if(row["actualnumber"]!=null && row["actualnumber"].ToString()!="")
				{
					model.actualnumber=int.Parse(row["actualnumber"].ToString());
				}
				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["location"]!=null)
				{
					model.location=row["location"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
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
                if (row["shipno"] != null )
                {
                    model.shipno = row["shipno"].ToString();
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
			strSql.Append("select id,code,operatecode,delegateunitid,delegateunitcode,delegateunit,deliverybills,productid,productcode,productname,unboxdate,place,tons,number,actualnumber,remark,location,createtime,createman,modifyman,modifytime,isdelete,shipno ");
			strSql.Append(" FROM t_storagebills ");
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
			strSql.Append("select count(1) FROM t_storagebills ");
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
			strSql.Append(")AS Row, T.*  from t_storagebills T ");
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
			parameters[0].Value = "t_storagebills";
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
