using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;


namespace FishBll.Dao
{
        /// <summary>
        /// 数据访问类:DictDao
        /// </summary>
        public partial class DictDao
        {
            public DictDao()
            { }
            #region  BasicMethod
            /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(int id)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_dict");
                strSql.Append(" where id=@id");
                MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
                parameters[0].Value = id;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }

            /// <summary>
            /// 是否存在该记录
            /// </summary>
            public bool Exists(string code , string  pcode , int isSystem )
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select count(1) from t_dict");
                strSql.Append(" where code=@code and pcode=@pcode and issystem=@issystem");
                MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@pcode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@issystem",MySqlDbType.Int16,2)
			};
                parameters[0].Value = code;
                parameters[1].Value = pcode;
                parameters[2].Value = isSystem;

                return MySqlHelper.Exists(strSql.ToString(), parameters);
            }


            /// <summary>
            /// 增加一条数据
            /// </summary>
            public bool Add(FishEntity.DictEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into t_dict(");
                strSql.Append("code,name,pcode,isdelete,orderid,remark,issystem,createtime,modifytime,pid)");
                strSql.Append(" values (");
                strSql.Append("@code,@name,@pcode,@isdelete,@orderid,@remark,@issystem,@createtime,@modifytime,@pid)");
                MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@name", MySqlDbType.VarChar,100),
					new MySqlParameter("@pcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,6),
					new MySqlParameter("@orderid", MySqlDbType.Int32,11),
					new MySqlParameter("@remark", MySqlDbType.VarChar,100),
					new MySqlParameter("@issystem", MySqlDbType.Int16,6),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                     new MySqlParameter("@pid",MySqlDbType.Int32 , 8)                         
                                              };
                parameters[0].Value = model.code;
                parameters[1].Value = model.name;
                parameters[2].Value = model.pcode;
                parameters[3].Value = model.isdelete;
                parameters[4].Value = model.orderid;
                parameters[5].Value = model.remark;
                parameters[6].Value = model.issystem;
                parameters[7].Value = model.createtime;
                parameters[8].Value = model.modifytime;
                parameters[9].Value = model.pid;

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
            public bool Update(FishEntity.DictEntity model)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update t_dict set ");
                strSql.Append("code=@code,");
                strSql.Append("name=@name,");
                strSql.Append("pcode=@pcode,");
                strSql.Append("isdelete=@isdelete,");
                strSql.Append("orderid=@orderid,");
                strSql.Append("remark=@remark,");
                strSql.Append("issystem=@issystem,");
                strSql.Append("modifytime=@modifytime,");
                strSql.Append("pid=@pid");
                strSql.Append(" where id=@id");
                MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@name", MySqlDbType.VarChar,100),
					new MySqlParameter("@pcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,6),
					new MySqlParameter("@orderid", MySqlDbType.Int32,11),
					new MySqlParameter("@remark", MySqlDbType.VarChar,100),
					new MySqlParameter("@issystem", MySqlDbType.Int16,6),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@pid",MySqlDbType.Int32,8),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
                parameters[0].Value = model.code;
                parameters[1].Value = model.name;
                parameters[2].Value = model.pcode;
                parameters[3].Value = model.isdelete;
                parameters[4].Value = model.orderid;
                parameters[5].Value = model.remark;
                parameters[6].Value = model.issystem;
                parameters[7].Value = DateTime.Now; //model.modifytime;
                parameters[8].Value = model.pid;
                parameters[9].Value = model.id;

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
                strSql.Append("delete from t_dict ");
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
            /// 批量删除数据 删除产品
            /// </summary>
            public bool DeleteList(string idlist)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from t_dict ");
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
            public FishEntity.DictEntity GetModel(int id)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select id,code,name,pcode,isdelete,orderid,remark,issystem,createtime,modifytime,pid from t_dict ");
                strSql.Append(" where id=@id");
                MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
                parameters[0].Value = id;

                FishEntity.DictEntity model = new FishEntity.DictEntity();
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
            public FishEntity.DictEntity DataRowToModel(DataRow row)
            {
                FishEntity.DictEntity model = new FishEntity.DictEntity();
                if (row != null)
                {
                    if (row["id"] != null && row["id"].ToString() != "")
                    {
                        model.id = int.Parse(row["id"].ToString());
                    }
                    if (row["code"] != null)
                    {
                        model.code = row["code"].ToString();
                    }
                    if (row["name"] != null)
                    {
                        model.name = row["name"].ToString();
                    }
                    if (row["pcode"] != null)
                    {
                        model.pcode = row["pcode"].ToString();
                    }
                    if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                    {
                        model.isdelete = int.Parse(row["isdelete"].ToString());
                    }
                    if (row["orderid"] != null && row["orderid"].ToString() != "")
                    {
                        model.orderid = int.Parse(row["orderid"].ToString());
                    }
                    if (row["remark"] != null)
                    {
                        model.remark = row["remark"].ToString();
                    }
                    if (row["issystem"] != null && row["issystem"].ToString() != "")
                    {
                        model.issystem = int.Parse(row["issystem"].ToString());
                    }
                    if (row["createtime"] != null && row["createtime"].ToString() != "")
                    {
                        model.createtime = DateTime.Parse(row["createtime"].ToString());
                    }
                    if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                    {
                        model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                    }
                    if (row["pid"] != null && row["pid"].ToString() != "")
                    {
                        model.pid = int.Parse(row["pid"].ToString());
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
                strSql.Append("select id,code,name,pcode,isdelete,orderid,remark,issystem,createtime,modifytime,pid ");
                strSql.Append(" FROM t_dict ");
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
                strSql.Append("select count(1) FROM t_dict ");
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
                strSql.Append(")AS Row, T.*  from t_dict T ");
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
                parameters[0].Value = "t_dict";
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



