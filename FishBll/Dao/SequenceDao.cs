using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class SequenceDao
    {
        public SequenceDao()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_sequence");
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
        public bool Add(FishEntity.SequenceEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_sequence(");
            strSql.Append("key,prefix,separator,step,maxseq,description,createtime,createman,modifytime,modifyman,isdelete)");
            strSql.Append(" values (");
            strSql.Append("@key,@prefix,@separator,@step,@maxseq,@description,@createtime,@createman,@modifytime,@modifyman,@isdelete)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@key", MySqlDbType.VarChar,45),
					new MySqlParameter("@prefix", MySqlDbType.VarChar,45),
					new MySqlParameter("@separator", MySqlDbType.VarChar,45),
					new MySqlParameter("@step", MySqlDbType.Int32,11),
					new MySqlParameter("@maxseq", MySqlDbType.Int32,11),
					new MySqlParameter("@description", MySqlDbType.VarChar,100),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,4)};
            parameters[0].Value = model.key;
            parameters[1].Value = model.prefix;
            parameters[2].Value = model.separator;
            parameters[3].Value = model.step;
            parameters[4].Value = model.maxseq;
            parameters[5].Value = model.description;
            parameters[6].Value = model.createtime;
            parameters[7].Value = model.createman;
            parameters[8].Value = model.modifytime;
            parameters[9].Value = model.modifyman;
            parameters[10].Value = model.isdelete;

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
        public bool Update(FishEntity.SequenceEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_sequence set ");
            strSql.Append("key=@key,");
            strSql.Append("prefix=@prefix,");
            strSql.Append("separator=@separator,");
            strSql.Append("step=@step,");
            strSql.Append("maxseq=@maxseq,");
            strSql.Append("description=@description,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("isdelete=@isdelete");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@key", MySqlDbType.VarChar,45),
					new MySqlParameter("@prefix", MySqlDbType.VarChar,45),
					new MySqlParameter("@separator", MySqlDbType.VarChar,45),
					new MySqlParameter("@step", MySqlDbType.Int32,11),
					new MySqlParameter("@maxseq", MySqlDbType.Int32,11),
					new MySqlParameter("@description", MySqlDbType.VarChar,100),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,4),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.key;
            parameters[1].Value = model.prefix;
            parameters[2].Value = model.separator;
            parameters[3].Value = model.step;
            parameters[4].Value = model.maxseq;
            parameters[5].Value = model.description;
            parameters[6].Value = model.createman;
            parameters[7].Value = model.modifyman;
            parameters[8].Value = model.isdelete;
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
            strSql.Append("delete from t_sequence ");
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
            strSql.Append("delete from t_sequence ");
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
        public FishEntity.SequenceEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,key,prefix,separator,step,maxseq,description,createtime,createman,modifytime,modifyman,isdelete from t_sequence ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            FishEntity.SequenceEntity model = new FishEntity.SequenceEntity();
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
        public FishEntity.SequenceEntity DataRowToModel(DataRow row)
        {
            FishEntity.SequenceEntity model = new FishEntity.SequenceEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["key"] != null)
                {
                    model.key = row["key"].ToString();
                }
                if (row["prefix"] != null)
                {
                    model.prefix = row["prefix"].ToString();
                }
                if (row["separator"] != null)
                {
                    model.separator = row["separator"].ToString();
                }
                if (row["step"] != null && row["step"].ToString() != "")
                {
                    model.step = int.Parse(row["step"].ToString());
                }
                if (row["maxseq"] != null && row["maxseq"].ToString() != "")
                {
                    model.maxseq = int.Parse(row["maxseq"].ToString());
                }
                if (row["description"] != null)
                {
                    model.description = row["description"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["modifyman"] != null)
                {
                    model.modifyman = row["modifyman"].ToString();
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
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
            strSql.Append("select id,key,prefix,separator,step,maxseq,description,createtime,createman,modifytime,modifyman,isdelete ");
            strSql.Append(" FROM t_sequence ");
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
            strSql.Append("select count(1) FROM t_sequence ");
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
            strSql.Append(")AS Row, T.*  from t_sequence T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySqlHelper.Query(strSql.ToString());
        }


        public string GetSequence(string keyName , string procedureName )
        {
            string sequence = string.Empty;

            MySqlParameter[] parameters = new MySqlParameter[2];
            parameters[0] = new MySqlParameter("@v_keyname", MySqlDbType.VarChar, 45);
            parameters[0].Value = keyName;
            parameters[1] = new MySqlParameter("@v_sequence", MySqlDbType.VarChar, 45);
            parameters[1].Direction = ParameterDirection.Output;

            MySqlHelper.RunProcedureNull( procedureName , parameters);

            sequence = parameters[1].Value.ToString();
            return sequence;
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
            parameters[0].Value = "t_sequence";
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
