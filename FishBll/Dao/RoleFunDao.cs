using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace FishBll.Dao
{
    public class RoleFunDao
    {
            public RoleFunDao()
            { }
            #region  BasicMethod
            /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(int id)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_rolefun");
                strSql.Append(" where id=@id");
                MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
                parameters[0].Value = id;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }


            /// <summary>
            /// 增加一条数据
            /// </summary>
            public bool Add(FishEntity.RoleFunEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_rolefun(");
                strSql.Append("roleid,funid)");
                strSql.Append(" values (");
                strSql.Append("@roleid,@funid)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@roleid", MySqlDbType.Int32,11),
					new MySqlParameter("@funid", MySqlDbType.Int32,11)};
                parameters[0].Value = model.roleid;
                parameters[1].Value = model.funid;

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
            /// 更新一条数据
            /// </summary>
            public bool Update(FishEntity.RoleFunEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_rolefun set ");
                strSql.Append("roleid=@roleid,");
                strSql.Append("funid=@funid");
                strSql.Append(" where id=@id");
                MySqlParameter[] parameters = {
					new MySqlParameter("@roleid", MySqlDbType.Int32,11),
					new MySqlParameter("@funid", MySqlDbType.Int32,11),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
                parameters[0].Value = model.roleid;
                parameters[1].Value = model.funid;
                parameters[2].Value = model.id;

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

                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_rolefun ");
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
            public bool DeleteList(string idlist)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_rolefun ");
                strSql.Append(" where id in (" + idlist + ")  ");
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
            public FishEntity.RoleFunEntity GetModel(int id)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id,roleid,funid from t_rolefun ");
                strSql.Append(" where id=@id");
                MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
                parameters[0].Value = id;

                FishEntity.RoleFunEntity model = new FishEntity.RoleFunEntity();
                DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
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
            public FishEntity.RoleFunEntity DataRowToModel(DataRow row)
            {
                FishEntity.RoleFunEntity model = new FishEntity.RoleFunEntity();
                if (row != null)
                {
                    if (row["id"] != null && row["id"].ToString() != "")
                    {
                        model.id = int.Parse(row["id"].ToString());
                    }
                    if (row["roleid"] != null && row["roleid"].ToString() != "")
                    {
                        model.roleid = int.Parse(row["roleid"].ToString());
                    }
                    if (row["funid"] != null && row["funid"].ToString() != "")
                    {
                        model.funid = int.Parse(row["funid"].ToString());
                    }
                }
                return model;
            }

            /// <summary>
            /// 获得数据列表
            /// </summary>
            public DataSet GetList(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id,roleid,funid ");
                strSql.Append(" FROM t_rolefun ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                return MySqlHelper.Query(strSql.ToString());
            }

            /// <summary>
            /// 获取记录总数
            /// </summary>
            public int GetRecordCount(string strWhere)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) FROM t_rolefun ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
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
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT * FROM ( ");
                strSql.Append(" SELECT ROW_NUMBER() OVER (");
                if (!string.IsNullOrEmpty(orderby.Trim()))
                {
                    strSql.Append("order by T." + orderby);
                }
                else
                {
                    strSql.Append("order by T.id desc");
                }
                strSql.Append(")AS Row, T.*  from t_rolefun T ");
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
                parameters[0].Value = "t_rolefun";
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
