using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace FishBll.Dao
{        /// <summary>
    /// 数据访问类:t_role
    /// </summary>
    public class RoleDao
    {
            public RoleDao()
            { }
            #region  BasicMethod
            /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(int roleid)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_role");
                strSql.Append(" where roleid=@roleid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@roleid", MySqlDbType.Int32)
			};
                parameters[0].Value = roleid;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }
          /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(string rolename)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_role");
                strSql.Append(" where rolename=@rolename");
                MySqlParameter[] parameters = {
					new MySqlParameter("@rolename", MySqlDbType.VarChar,200)
			};
                parameters[0].Value = rolename;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }

            /// <summary>
            /// 增加一条数据
            /// </summary>
            public bool Add(FishEntity.RoleEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_role(");
                strSql.Append("rolename,remarks)");
                strSql.Append(" values (");
                strSql.Append("@rolename,@remarks)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@rolename", MySqlDbType.VarChar,255),
					new MySqlParameter("@remarks", MySqlDbType.VarChar,255)};
                parameters[0].Value = model.rolename;
                parameters[1].Value = model.remarks;

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
            public bool Update(FishEntity.RoleEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_role set ");
                strSql.Append("rolename=@rolename,");
                strSql.Append("remarks=@remarks");
                strSql.Append(" where roleid=@roleid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@rolename", MySqlDbType.VarChar,255),
					new MySqlParameter("@remarks", MySqlDbType.VarChar,255),
					new MySqlParameter("@roleid", MySqlDbType.Int32,11)};
                parameters[0].Value = model.rolename;
                parameters[1].Value = model.remarks;
                parameters[2].Value = model.roleid;

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
            public bool Delete(int roleid)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_role ");
                strSql.Append(" where roleid=@roleid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@roleid", MySqlDbType.Int32)
			};
                parameters[0].Value = roleid;

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
            public bool DeleteList(string roleidlist)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_role ");
                strSql.Append(" where roleid in (" + roleidlist + ")  ");
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
            public FishEntity.RoleEntity GetModel(int roleid)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select roleid,rolename,remarks from t_role ");
                strSql.Append(" where roleid=@roleid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@roleid", MySqlDbType.Int32)
			};
                parameters[0].Value = roleid;

                FishEntity.RoleEntity model = new FishEntity.RoleEntity();
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
            public FishEntity.RoleEntity DataRowToModel(DataRow row)
            {
                FishEntity.RoleEntity model = new FishEntity.RoleEntity();
                if (row != null)
                {
                    if (row["roleid"] != null && row["roleid"].ToString() != "")
                    {
                        model.roleid = int.Parse(row["roleid"].ToString());
                    }
                    if (row["rolename"] != null)
                    {
                        model.rolename = row["rolename"].ToString();
                    }
                    if (row["remarks"] != null)
                    {
                        model.remarks = row["remarks"].ToString();
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
                strSql.Append("select roleid,rolename,remarks ");
                strSql.Append(" FROM t_role ");
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
                strSql.Append("select count(1) FROM t_role ");
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
                    strSql.Append("order by T.roleid desc");
                }
                strSql.Append(")AS Row, T.*  from t_role T ");
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
                parameters[0].Value = "t_role";
                parameters[1].Value = "roleid";
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
