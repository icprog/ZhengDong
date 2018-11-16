using System;
using System . Collections . Generic;
using System . Text;
using System . Data;
using MySql . Data . MySqlClient;
using System . Collections;

namespace FishBll.Dao
{
    public class ImageDao
    {
        public ImageDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_image");
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
		public bool Add(FishEntity.ImageEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_image(");
			strSql.Append("recordid,title,type,extension,image,sort,remark,createman,createtime)");
			strSql.Append(" values (");
			strSql.Append("@recordid,@title,@type,@extension,@image,@sort,@remark,@createman,@createtime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@recordid", MySqlDbType.Int32,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,100),
					new MySqlParameter("@type", MySqlDbType.Int32,11),
					new MySqlParameter("@extension", MySqlDbType.VarChar,45),
					new MySqlParameter("@image", MySqlDbType.MediumBlob),
                    new MySqlParameter("@sort",MySqlDbType.Int16 , 4),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@createman", MySqlDbType.VarChar,50),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp)};
			parameters[0].Value = model.recordid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.type;
			parameters[3].Value = model.extension;
			parameters[4].Value = model.image;
            parameters[5].Value = model.sort;
			parameters[6].Value = model.remark;
			parameters[7].Value = model.createman;
			parameters[8].Value = model.createtime;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(FishEntity.ImageEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_image set ");
			strSql.Append("recordid=@recordid,");
			strSql.Append("title=@title,");
			strSql.Append("type=@type,");
			strSql.Append("extension=@extension,");
			strSql.Append("image=@image,");
			strSql.Append("remark=@remark,");
			strSql.Append("createman=@createman");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@recordid", MySqlDbType.Int32,50),
					new MySqlParameter("@title", MySqlDbType.VarChar,100),
					new MySqlParameter("@type", MySqlDbType.Int32,11),
					new MySqlParameter("@extension", MySqlDbType.VarChar,45),
					new MySqlParameter("@image", MySqlDbType.MediumBlob),
					new MySqlParameter("@remark", MySqlDbType.VarChar,255),
					new MySqlParameter("@createman", MySqlDbType.VarChar,50),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.recordid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.type;
			parameters[3].Value = model.extension;
			parameters[4].Value = model.image;
			parameters[5].Value = model.remark;
			parameters[6].Value = model.createman;
			parameters[7].Value = model.id;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_image ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_image ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=MySqlHelper.ExecuteSql(strSql.ToString());
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
            strSql.Append("delete from t_image ");
            strSql.Append(" where recordid =" +recordid +" and type=" +type );
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
		public FishEntity.ImageEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,recordid,title,type,extension,image,sort,remark,createman,createtime from t_image ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.ImageEntity model=new FishEntity.ImageEntity();
			DataSet ds=MySqlHelper.Query(strSql.ToString(),parameters);
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
		public FishEntity.ImageEntity DataRowToModel(DataRow row)
		{
			FishEntity.ImageEntity model=new FishEntity.ImageEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["recordid"]!=null && row["recordid"].ToString()!="")
				{
					model.recordid=int.Parse(row["recordid"].ToString());
				}
				if(row["title"]!=null)
				{
					model.title=row["title"].ToString();
				}
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=int.Parse(row["type"].ToString());
				}
				if(row["extension"]!=null)
				{
					model.extension=row["extension"].ToString();
				}

                 if( row["image"]!=null )
                 {
                     byte[] buffers = row["image"] as byte[];
                     model.image = buffers;
                 }

                 if (row["sort"] != null && row["sort"].ToString() !="" )
                 {
                     model.sort =int.Parse( row["sort"].ToString());
                 }

				if(row["remark"]!=null)
				{
					model.remark=row["remark"].ToString();
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
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
			strSql.Append("select id,recordid,title,type,extension,image,sort,remark,createman,createtime ");
			strSql.Append(" FROM t_image ");
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
			strSql.Append("select count(1) FROM t_image ");
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
