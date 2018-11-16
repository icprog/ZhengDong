using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
   public class ImageS_Dao
    {
        public ImageS_Dao() { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_image_s");
            strSql.Append(" where Fid=@Fid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Fid", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(FishEntity.t_image_S model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_image_s(");
            strSql.Append("Fid,Iid,Image_name,type,path,path_name,date_,state)");
            strSql.Append(" values (");
            strSql.Append("@Fid,@Iid,@Image_name,@type,@path,@path_name,@date_,@state)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Fid", MySqlDbType.Int32,15),
                    new MySqlParameter("@Iid", MySqlDbType.Int32,15),
                    new MySqlParameter("@Image_name", MySqlDbType.VarChar,100),
                    new MySqlParameter("@type", MySqlDbType.Int32,20),
                    new MySqlParameter("@path", MySqlDbType.VarChar,100),
                    new MySqlParameter("@path_name",MySqlDbType.VarChar ,200),
                    new MySqlParameter("@date_", MySqlDbType.Date,50),
                    new MySqlParameter("@state", MySqlDbType.Int32,10)};
            parameters[0].Value = model.Fid1;
            parameters[1].Value = model.Iid1;
            parameters[2].Value = model.Image_name1;
            parameters[3].Value = model.Type;
            parameters[4].Value = model.Path;
            parameters[5].Value = model.Path_name;
            parameters[6].Value = model.Date_;
            parameters[7].Value = model.State;

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
        public bool Update(FishEntity.t_image_S model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_image_s set ");
            strSql.Append("Fid=@Fid,");
            strSql.Append("Image_name=@Image_name,");
            strSql.Append("type=@type,");
            strSql.Append("path=@path,");
            strSql.Append("path_name=@path_name,");
            strSql.Append("date_=@date_,");
            strSql.Append("state=@state");
            strSql.Append(" where Iid=@Iid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Fid", MySqlDbType.Int32,15),
                    new MySqlParameter("@Image_name", MySqlDbType.VarChar,100),
                    new MySqlParameter("@type", MySqlDbType.Int32,20),
                    new MySqlParameter("@path", MySqlDbType.VarChar,100),
                    new MySqlParameter("@path_name", MySqlDbType.VarChar,200),
                    new MySqlParameter("@date_", MySqlDbType.Date,50),
                    new MySqlParameter("@state", MySqlDbType.Int32,10),
                    new MySqlParameter("@Iid", MySqlDbType.Int32,15)};
            parameters[0].Value = model.Fid1;
            parameters[1].Value = model.Image_name1;
            parameters[2].Value = model.Type;
            parameters[3].Value = model.Path;
            parameters[4].Value = model.Path_name;
            parameters[5].Value = model.Date_;
            parameters[6].Value = model.State;
            parameters[7].Value = model.Iid1;

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
            strSql.Append("delete from t_image_s ");
            strSql.Append(" where Iid=@Iid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Iid", MySqlDbType.Int32,15)
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
            strSql.Append("delete from t_image_s ");
            strSql.Append(" where Fid in (" + idlist + ")  ");
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

        public bool DeleteByRecordIdAndType(int recordid, int type)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_image_s ");
            strSql.Append(" where Fid =" + recordid );
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
        public FishEntity.t_image_S GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Fid,Iid,Image_name,type,path,path_name,date_,state from t_image_s ");
            strSql.Append(" where Fid=@Fid");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Fid", MySqlDbType.Int32,15)
            };
            parameters[0].Value = id;

            FishEntity.t_image_S model = new FishEntity.t_image_S();
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
        public FishEntity.t_image_S DataRowToModel(DataRow row)
        {
            FishEntity.t_image_S model = new FishEntity.t_image_S();
            if (row != null)
            {
                if (row["Iid"] != null && row["Iid"].ToString() != "")
                {
                    model.Iid1 = int.Parse(row["Iid"].ToString());
                }
                if (row["Fid"] != null && row["Fid"].ToString() != "")
                {
                    model.Fid1 = int.Parse(row["Fid"].ToString());
                }
                if (row["Image_name"] != null)
                {
                    model.Image_name1 = row["Image_name"].ToString();
                }
                if (row["type"] != null&& row["type"].ToString()!="")
                {
                    model.Type = int.Parse(row["type"].ToString());
                }
                if (row["path"] != null)
                {
                    model.Path = row["path"].ToString();
                }

                if (row["path_name"] != null)
                {
                    byte[] buffers = row["path_name"] as byte[];
                    model.Path_name = row["path_name"].ToString();
                }

                if (row["date_"] != null)
                {
                    model.Date_ = DateTime.Parse(row["date_"].ToString());
                }

                if (row["state"] != null&& row["state"].ToString()!="")
                {
                    model.State = int.Parse(row["state"].ToString());
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
            strSql.Append("select Fid,id,recordid,title,type,extension,image,sort,remark,createman,createtime ");
            strSql.Append(" FROM t_image_s ");
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
            strSql.Append("select count(1) FROM t_image_s ");
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
            strSql.Append(")AS Row, T.*  from t_image T ");
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
			parameters[0].Value = "t_image";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return MySqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}
