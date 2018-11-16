using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CustomerDao
    {
        public CustomerDao()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_customer");
			strSql.Append(" where id=@id ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)};
			parameters[0].Value = id;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_customer");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsName(string name )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_customer");
            strSql.Append(" where name=@name ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,45)};
            parameters[0].Value = name;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.CustomerEntity model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_customer(");
            strSql.Append("code,name,currentlinkDate,telephone,phone1,phone2,phone3,post,department,email,qq,weixin,nextlinkdate,nextcallrecordid,validate,remark,company,createtime,createman,modifytime,modifyman,isdelete,flag,homeaddress,officeaddress,sex,fox,department1 )");
            strSql.Append(" values (");
            strSql.Append("@code,@name,@currentlinkDate,@telephone,@phone1,@phone2,@phone3,@post,@department,@email,@qq,@weixin,@nextlinkdate,@nextcallrecordid,@validate,@remark,@company,@createtime,@createman,@modifytime,@modifyman,@isdelete,@flag,@homeaddress,@officeaddress,@sex,@fox,@department1 );");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@currentlinkDate", MySqlDbType.Timestamp),
					new MySqlParameter("@telephone", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone1", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone2", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone3", MySqlDbType.VarChar,45),
					new MySqlParameter("@post", MySqlDbType.VarChar,45),
					new MySqlParameter("@department", MySqlDbType.VarChar,45),
					new MySqlParameter("@email", MySqlDbType.VarChar,45),
					new MySqlParameter("@qq", MySqlDbType.VarChar,45),
					new MySqlParameter("@weixin", MySqlDbType.VarChar,45),
					new MySqlParameter("@nextlinkdate", MySqlDbType.Timestamp),
					new MySqlParameter("@nextcallrecordid", MySqlDbType.Int32,11),
					new MySqlParameter("@validate", MySqlDbType.Int16 ,1),
					new MySqlParameter("@remark", MySqlDbType.VarChar,200),
					new MySqlParameter("@company", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,1),
                    new MySqlParameter("@flag",MySqlDbType.UInt16,2) ,
                    new MySqlParameter("@homeaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@officeaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@sex", MySqlDbType.VarChar,8),
                    new MySqlParameter("@fox", MySqlDbType.VarChar,255),
                    new MySqlParameter("@department1",MySqlDbType.VarChar,45)
                                          };
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.currentlinkDate;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.phone1;
            parameters[5].Value = model.phone2;
            parameters[6].Value = model.phone3;
            parameters[7].Value = model.post;
            parameters[8].Value = model.department;
            parameters[9].Value = model.email;
            parameters[10].Value = model.qq;
            parameters[11].Value = model.weixin;
            parameters[12].Value = model.nextlinkdate;
            parameters[13].Value = model.nextcallrecordid;
            parameters[14].Value = model.validate;
            parameters[15].Value = model.remark;
            parameters[16].Value = model.company;
            parameters[17].Value = model.createtime;
            parameters[18].Value = model.createman;
            parameters[19].Value = model.modifytime;
            parameters[20].Value = model.modifyman;
            parameters[21].Value = model.isdelete;
            parameters[22].Value = model.flag;
            parameters[23].Value = model.homeaddress;
            parameters[24].Value = model.officeaddress;
            parameters[25].Value = model.sex;
            parameters[26].Value = model.fox;
            parameters[27].Value = model.Department1;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters); //MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary> 
		public bool Update(FishEntity.CustomerEntity model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_customer set ");
            strSql.Append("code=@code,");
            strSql.Append("name=@name,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("phone1=@phone1,");
            strSql.Append("phone2=@phone2,");
            strSql.Append("phone3=@phone3,");
            strSql.Append("post=@post,");
            strSql.Append("department=@department,");
            strSql.Append("email=@email,");
            strSql.Append("qq=@qq,");
            strSql.Append("weixin=@weixin,");
            //strSql.Append("nextcallrecordid=@nextcallrecordid,");
            strSql.Append("validate=@validate,");
            strSql.Append("remark=@remark,");
            strSql.Append("company=@company,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("isdelete=@isdelete,");
            strSql.Append("flag=@flag,");
            strSql.Append("homeaddress=@homeaddress,");
            strSql.Append("officeaddress=@officeaddress,");
            strSql.Append("sex=@sex,");
            strSql.Append("fox=@fox,");
            strSql.Append("department1=@department1");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@name", MySqlDbType.VarChar,50),
					new MySqlParameter("@telephone", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone1", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone2", MySqlDbType.VarChar,45),
					new MySqlParameter("@phone3", MySqlDbType.VarChar,45),
					new MySqlParameter("@post", MySqlDbType.VarChar,45),
					new MySqlParameter("@department", MySqlDbType.VarChar,45),
					new MySqlParameter("@email", MySqlDbType.VarChar,45),
					new MySqlParameter("@qq", MySqlDbType.VarChar,45),
					new MySqlParameter("@weixin", MySqlDbType.VarChar,45),
					//new MySqlParameter("@nextcallrecordid", MySqlDbType.Int32,11),
					new MySqlParameter("@validate", MySqlDbType.Int16,1),
					new MySqlParameter("@remark", MySqlDbType.VarChar,200),
					new MySqlParameter("@company", MySqlDbType.VarChar,45),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,1),
                    new MySqlParameter ("@flag",MySqlDbType.UInt16,2),
                    new MySqlParameter("@homeaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@officeaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@sex", MySqlDbType.VarChar,8),
                    new MySqlParameter("@fox", MySqlDbType.VarChar,255),
                    new MySqlParameter("@department1",MySqlDbType.VarChar,45),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.code;   
            parameters[1].Value = model.name;
            parameters[2].Value = model.telephone;
            parameters[3].Value = model.phone1;
            parameters[4].Value = model.phone2;
            parameters[5].Value = model.phone3;
            parameters[6].Value = model.post;
            parameters[7].Value = model.department;
            parameters[8].Value = model.email;
            parameters[9].Value = model.qq;
            parameters[10].Value = model.weixin;
            //parameters[11].Value = model.nextcallrecordid;
            parameters[11].Value = model.validate;
            parameters[12].Value = model.remark;
            parameters[13].Value = model.company;
            parameters[14].Value = model.createman;
            parameters[15].Value = model.modifyman;
            parameters[16].Value = model.isdelete;
            parameters[17].Value = model.flag;
            parameters[18].Value = model.homeaddress;
            parameters[19].Value = model.officeaddress;
            parameters[20].Value = model.sex;
            parameters[21].Value = model.fox;
            parameters[22].Value = model.Department1;
            parameters[23].Value = model.id;

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
			strSql.Append("delete from t_customer ");
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
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_customer ");
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
		public FishEntity.CustomerEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,code,name,currentlinkDate,telephone,phone1,phone2,phone3,post,department,email,qq,weixin,nextlinkdate,nextcallrecordid,validate,remark,company,createtime,createman,modifytime,modifyman,isdelete,flag,homeaddress,officeaddress,sex,fox,department1  from t_customer ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
};
			parameters[0].Value = id;

			FishEntity.CustomerEntity model=new FishEntity.CustomerEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.code=ds.Tables[0].Rows[0]["code"].ToString();
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
                if (ds.Tables[0].Rows[0]["currentlinkDate"] != null && ds.Tables[0].Rows[0]["currentlinkDate"].ToString() != "")
                {
                    model.currentlinkDate = DateTime.Parse(ds.Tables[0].Rows[0]["currentlinkDate"].ToString());
                }
                else
                {
                    model.currentlinkDate = null;
                }
				model.telephone=ds.Tables[0].Rows[0]["telephone"].ToString();
				model.phone1=ds.Tables[0].Rows[0]["phone1"].ToString();
				model.phone2=ds.Tables[0].Rows[0]["phone2"].ToString();
				model.phone3=ds.Tables[0].Rows[0]["phone3"].ToString();
				model.post=ds.Tables[0].Rows[0]["post"].ToString();
                model.Department1 = ds.Tables[0].Rows[0]["department1"].ToString();
                model.department=ds.Tables[0].Rows[0]["department"].ToString();
				model.email=ds.Tables[0].Rows[0]["email"].ToString();
				model.qq=ds.Tables[0].Rows[0]["qq"].ToString();
				model.weixin=ds.Tables[0].Rows[0]["weixin"].ToString();
                if (ds.Tables[0].Rows[0]["nextlinkdate"] != null && ds.Tables[0].Rows[0]["nextlinkdate"].ToString() != "")
                {
                    model.nextlinkdate = DateTime.Parse(ds.Tables[0].Rows[0]["nextlinkdate"].ToString());
                }
                else
                {
                    model.nextlinkdate = null;
                }
                if (ds.Tables[0].Rows[0]["nextcallrecordid"] != null && ds.Tables[0].Rows[0]["nextcallrecordid"].ToString() != "")
                {
                    model.nextcallrecordid = int.Parse(ds.Tables[0].Rows[0]["nextcallrecordid"].ToString());
                }

				if(ds.Tables[0].Rows[0]["validate"].ToString()!="")
				{
					model.validate=int.Parse(ds.Tables[0].Rows[0]["validate"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
				model.company=ds.Tables[0].Rows[0]["company"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"] != null && ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
                }
				model.createman=ds.Tables[0].Rows[0]["createman"].ToString();
                if (ds.Tables[0].Rows[0]["modifytime"] != null && ds.Tables[0].Rows[0]["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(ds.Tables[0].Rows[0]["modifytime"].ToString());
                }
				model.modifyman=ds.Tables[0].Rows[0]["modifyman"].ToString();
				if(ds.Tables[0].Rows[0]["isdelete"].ToString()!="")
				{
					model.isdelete=int.Parse(ds.Tables[0].Rows[0]["isdelete"].ToString());
				}
                if (ds.Tables[0].Rows[0]["flag"].ToString() != "")
                {
                    model.flag = int.Parse(ds.Tables[0].Rows[0]["flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["homeaddress"] != null)
                {
                    model.homeaddress = ds.Tables[0].Rows[0]["homeaddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["officeaddress"] != null)
                {
                    model.officeaddress = ds.Tables[0].Rows[0]["officeaddress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sex"] != null)
                {
                    model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["fox"] != null)
                {
                    model.fox = ds.Tables[0].Rows[0]["fox"].ToString();
                }


				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,code,name,currentlinkDate,telephone,phone1,phone2,phone3,post,department,email,qq,weixin,nextlinkdate,nextcallrecordid,validate,remark,company,createtime,createman,modifytime,modifyman,isdelete,flag,homeaddress,officeaddress,sex,fox,department1  ");
			strSql.Append(" FROM t_customer ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return MySqlHelper.Query(strSql.ToString());
		}


        public FishEntity.CustomerEntity DataRowToModel(DataRow row)
        {
            FishEntity.CustomerEntity  model = new FishEntity.CustomerEntity();
            if (row["id"].ToString() != "")
            {
                model.id = int.Parse( row["id"].ToString());
            }
            model.code = row["code"].ToString();
            model.name = row["name"].ToString();
            if ( row["currentlinkDate"] != null && row["currentlinkDate"].ToString() != "")
            {
                model.currentlinkDate = DateTime.Parse( row["currentlinkDate"].ToString());
            }
            else
            {
                model.currentlinkDate = null;
            }
            model.telephone = row["telephone"].ToString();
            model.phone1 = row["phone1"].ToString();
            model.phone2 = row["phone2"].ToString();
            model.phone3 = row["phone3"].ToString();
            model.post = row["post"].ToString();
            model.Department1 = row["department1"].ToString();
            model.department = row["department"].ToString();
            model.email = row["email"].ToString();
            model.qq = row["qq"].ToString();
            model.weixin = row["weixin"].ToString();
            if (row["nextlinkdate"] != null && row["nextlinkdate"].ToString() != "")
            {
                model.nextlinkdate = DateTime.Parse(row["nextlinkdate"].ToString());
            }
            else
            {
                model.nextlinkdate = null;
            }
            if (row["validate"].ToString() != "")
            {
                model.validate = int.Parse(row["validate"].ToString());
            }
            model.remark = row["remark"].ToString();
            model.company = row["company"].ToString();
            if (row["createtime"] != null && row["createtime"].ToString() != "")
            {
                model.createtime = DateTime.Parse(row["createtime"].ToString());
            }
            model.createman = row["createman"].ToString();
            if (row["modifytime"] != null && row["modifytime"].ToString() != "")
            {
                model.modifytime = DateTime.Parse(row["modifytime"].ToString());
            }
            model.modifyman = row["modifyman"].ToString();
            if (row["isdelete"].ToString() != "")
            {
                model.isdelete = int.Parse(row["isdelete"].ToString());
            }

            if (row["flag"].ToString() != "")
            {
                model.flag = int.Parse(row["flag"].ToString());
            }
            if (row["homeaddress"] != null)
            {
                model.homeaddress = row["homeaddress"].ToString();
            }
            if (row["officeaddress"] != null)
            {
                model.officeaddress = row["officeaddress"].ToString();
            }
            if (row["sex"] != null)
            {
                model.sex = row["sex"].ToString();
            }
            if (row["fox"] != null)
            {
                model.fox = row["fox"].ToString();
            }

            return model;
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
			parameters[0].Value = "t_customer";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
    }
}
