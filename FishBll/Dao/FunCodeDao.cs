using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace FishBll.Dao
{    
    /// <summary>
        /// 数据访问类:t_funcode
        /// </summary>
    public class FunCodeDao
    {
            public FunCodeDao()
            { }
            #region  BasicMethod
            /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(int funid)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_funcode");
                strSql.Append(" where funid=@funid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@funid", MySqlDbType.Int32)
			};
                parameters[0].Value = funid;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }

         /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(String  funcode )
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_funcode");
                strSql.Append(" where funcode=@funcode");
                MySqlParameter[] parameters = {
					new MySqlParameter("@funcode", MySqlDbType.VarChar,45)
			};
                parameters[0].Value = funcode;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }


            /// <summary>
            /// 增加一条数据
            /// </summary>
            public bool Add(FishEntity.FunCodeEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_funcode(");
                strSql.Append("funcode,funname,type,enable,remark,pid,sortid)");
                strSql.Append(" values (");
                strSql.Append("@funcode,@funname,@type,@enable,@remark,@pid,@sortid)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@funcode", MySqlDbType.VarChar,255),
					new MySqlParameter("@funname", MySqlDbType.VarChar,255),
					new MySqlParameter("@type", MySqlDbType.Int32,4),
					new MySqlParameter("@enable", MySqlDbType.Int32,4),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@pid",MySqlDbType.Int32,4) ,
                    new MySqlParameter("@sortid",MySqlDbType.Int32,4) 
                                              };
                parameters[0].Value = model.funcode;
                parameters[1].Value = model.funname;
                parameters[2].Value = model.type;
                parameters[3].Value = model.enable;
                parameters[4].Value = model.remark;
                parameters[5].Value = model.pid;
                parameters[6].Value = model.sortid;

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
            public bool Update(FishEntity.FunCodeEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_funcode set ");
                strSql.Append("funcode=@funcode,");
                strSql.Append("funname=@funname,");
                strSql.Append("type=@type,");
                strSql.Append("enable=@enable,");
                strSql.Append("remark=@remark,");
                strSql.Append("pid=@pid,");
                strSql.Append("sortid=@sortid");
                strSql.Append(" where funid=@funid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@funcode", MySqlDbType.VarChar,255),
					new MySqlParameter("@funname", MySqlDbType.VarChar,255),
					new MySqlParameter("@type", MySqlDbType.Int32,4),
					new MySqlParameter("@enable", MySqlDbType.Int32,4),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@pid",MySqlDbType.Int32,4),
                    new MySqlParameter("@sortid",MySqlDbType.Int32,4),
					new MySqlParameter("@funid", MySqlDbType.Int32,11)};
                parameters[0].Value = model.funcode;
                parameters[1].Value = model.funname;
                parameters[2].Value = model.type;
                parameters[3].Value = model.enable;
                parameters[4].Value = model.remark;
                parameters[5].Value = model.pid;
                parameters[6].Value = model.sortid;
                parameters[7].Value = model.funid;

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
            public bool Delete(int funid)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_funcode ");
                strSql.Append(" where funid=@funid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@funid", MySqlDbType.Int32)
			};
                parameters[0].Value = funid;

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
            public bool DeleteList(string funidlist)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_funcode ");
                strSql.Append(" where funid in (" + funidlist + ")  ");
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
            public FishEntity.FunCodeEntity GetModel(int funid)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select funid,funcode,funname,type,enable,remark,pid,sortid from t_funcode ");
                strSql.Append(" where funid=@funid");
                MySqlParameter[] parameters = {
					new MySqlParameter("@funid", MySqlDbType.Int32)
			};
                parameters[0].Value = funid;

                FishEntity.FunCodeEntity model = new FishEntity.FunCodeEntity();
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
            public FishEntity.FunCodeEntity DataRowToModel(DataRow row)
            {
                FishEntity.FunCodeEntity model = new FishEntity.FunCodeEntity();
                if (row != null)
                {
                    if (row["funid"] != null && row["funid"].ToString() != "")
                    {
                        model.funid = int.Parse(row["funid"].ToString());
                    }
                    if (row["funcode"] != null)
                    {
                        model.funcode = row["funcode"].ToString();
                    }
                    if (row["funname"] != null)
                    {
                        model.funname = row["funname"].ToString();
                    }
                    if (row["type"] != null && row["type"].ToString() != "")
                    {
                        model.type = int.Parse(row["type"].ToString());
                    }
                    if (row["enable"] != null && row["enable"].ToString() != "")
                    {
                        model.enable = int.Parse(row["enable"].ToString());
                    }
                    if (row["remark"] != null)
                    {
                        model.remark = row["remark"].ToString();
                    }
                    if (row["pid"] != null && row["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(row["pid"].ToString());
                    }
                    if (row["sortid"] != null && row["sortid"].ToString() != "")
                    {
                        model.sortid = int.Parse(row["sortid"].ToString());
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
                strSql.Append("select funid,funcode,funname,type,enable,remark,pid,sortid ");
                strSql.Append(" FROM t_funcode ");
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
                strSql.Append("select count(1) FROM t_funcode ");
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
                    strSql.Append("order by T.funid desc");
                }
                strSql.Append(")AS Row, T.*  from t_funcode T ");
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
                parameters[0].Value = "t_funcode";
                parameters[1].Value = "funid";
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
