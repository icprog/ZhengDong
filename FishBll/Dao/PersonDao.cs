using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class PersonDao
    {
        public PersonDao()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_user");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public bool ExistsUser(int userid, string funname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from v_userrole");
            strSql.Append(" where userid=@userid and funname=@funname ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@userid", MySqlDbType.Int32),
                    new MySqlParameter("@funname",MySqlDbType.VarChar,255)
            };
            parameters[0].Value = userid;
            parameters[1].Value = funname;
            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_user");
            strSql.Append(" where username=@username ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,45)};
            parameters[0].Value = username;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(FishEntity.PersonEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_user(");
            strSql.Append("username,password,realname,ename,sex,email,phone,telephone,age,department,entrytime,roletype,roledate,createtime,createman,modifytime,modifyman,isdelete)");
            strSql.Append(" values (");
            strSql.Append("@username,@password,@realname,@ename,@sex,@email,@phone,@telephone,@age,@department,@entrytime,@roletype,@roledate,@createtime,@createman,@modifytime,@modifyman,@isdelete)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,45),
                    new MySqlParameter("@password", MySqlDbType.VarChar,45),
                    new MySqlParameter("@realname", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ename", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sex", MySqlDbType.VarChar,45),
                    new MySqlParameter("@email", MySqlDbType.VarChar,100),
                    new MySqlParameter("@phone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@telephone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@age", MySqlDbType.Int32,11),
                    new MySqlParameter("@department", MySqlDbType.VarChar,45),
                    new MySqlParameter("@entrytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@roletype", MySqlDbType.VarChar,45),
                    new MySqlParameter("@roledate", MySqlDbType.VarChar,500),
                    new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@isdelete", MySqlDbType.Int32,6)};
            parameters[0].Value = model.username;
            parameters[1].Value = model.password;
            parameters[2].Value = model.realname;
            parameters[3].Value = model.ename;
            parameters[4].Value = model.sex;
            parameters[5].Value = model.email;
            parameters[6].Value = model.phone;
            parameters[7].Value = model.telephone;
            parameters[8].Value = model.age;
            parameters[9].Value = model.department;
            parameters[10].Value = model.entrytime;
            parameters[11].Value = model.roletype;
            parameters[12].Value = model.roledate;
            parameters[13].Value = model.createtime;
            parameters[14].Value = model.createman;
            parameters[15].Value = model.modifytime;
            parameters[16].Value = model.modifyman;
            parameters[17].Value = model.isdelete;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FishEntity.PersonEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_user set ");
            strSql.Append("username=@username,");
            strSql.Append("password=@password,");
            strSql.Append("realname=@realname,");
            strSql.Append("ename=@ename,");
            strSql.Append("sex=@sex,");
            strSql.Append("email=@email,");
            strSql.Append("phone=@phone,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("age=@age,");
            strSql.Append("department=@department,");
            strSql.Append("entrytime=@entrytime,");
            strSql.Append("roletype=@roletype,");
            strSql.Append("roledate=@roledate,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifytime=@modifytime,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("isdelete=@isdelete");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@username", MySqlDbType.VarChar,45),
                    new MySqlParameter("@password", MySqlDbType.VarChar,45),
                    new MySqlParameter("@realname", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ename", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sex", MySqlDbType.VarChar,45),
                    new MySqlParameter("@email", MySqlDbType.VarChar,100),
                    new MySqlParameter("@phone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@telephone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@age", MySqlDbType.Int32,11),
                    new MySqlParameter("@department", MySqlDbType.VarChar,45),
                    new MySqlParameter("@entrytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@roletype", MySqlDbType.VarChar,45),
                    new MySqlParameter("@roledate", MySqlDbType.VarChar,500),
                    new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@isdelete", MySqlDbType.Int32,6)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.username;
            parameters[2].Value = model.password;
            parameters[3].Value = model.realname;
            parameters[4].Value = model.ename;
            parameters[5].Value = model.sex;
            parameters[6].Value = model.email;
            parameters[7].Value = model.phone;
            parameters[8].Value = model.telephone;
            parameters[9].Value = model.age;
            parameters[10].Value = model.department;
            parameters[11].Value = model.entrytime;
            parameters[12].Value = model.roletype;
            parameters[13].Value = model.roledate;
            parameters[14].Value = model.createtime;
            parameters[15].Value = model.createman;
            parameters[16].Value = model.modifytime;
            parameters[17].Value = model.modifyman;
            parameters[18].Value = model.isdelete;

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
            strSql.Append("delete from t_user ");
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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_user ");
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
        public FishEntity.PersonEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,password,realname,ename,sex,email,phone,telephone,age,department,entrytime,roletype,roledate,createtime,createman,modifytime,modifyman,isdelete from t_user ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
};
            parameters[0].Value = id;

            FishEntity.PersonEntity model = new FishEntity.PersonEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.realname = ds.Tables[0].Rows[0]["realname"].ToString();
                model.ename = ds.Tables[0].Rows[0]["ename"].ToString();
                model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                if (ds.Tables[0].Rows[0]["age"].ToString() != "")
                {
                    model.age = int.Parse(ds.Tables[0].Rows[0]["age"].ToString());
                }
                model.department = ds.Tables[0].Rows[0]["department"].ToString();
                if (ds.Tables[0].Rows[0]["entrytime"] != null && ds.Tables[0].Rows[0]["entrytime"].ToString() != "")
                {
                    model.entrytime = DateTime.Parse(ds.Tables[0].Rows[0]["entrytime"].ToString());
                }
                model.roletype = ds.Tables[0].Rows[0]["roletype"].ToString();
                model.roledate = ds.Tables[0].Rows[0]["roledate"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"] != null && ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
                }
                model.createman = ds.Tables[0].Rows[0]["createman"].ToString();
                if (ds.Tables[0].Rows[0]["modifytime"] != null && ds.Tables[0].Rows[0]["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(ds.Tables[0].Rows[0]["modifytime"].ToString());
                }
                model.modifyman = ds.Tables[0].Rows[0]["modifyman"].ToString();
                if (ds.Tables[0].Rows[0]["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(ds.Tables[0].Rows[0]["isdelete"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public DataSet id_name()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username ");
            strSql.Append(" FROM t_user ");
            return MySqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,password,realname,ename,sex,email,phone,telephone,age,department,entrytime,roletype,roledate,createtime,createman,modifytime,modifyman,isdelete,0 Selection ");
            strSql.Append(" FROM t_user ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public FishEntity.PersonEntity Getname(string name)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.AppendFormat("select username, realname from t_user where isdelete = 0 and username = @username");
            MySqlParameter[] parameter = {
                new MySqlParameter("@username",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = name;
            DataSet ds = MySqlHelper.Query(strsql.ToString(), parameter);
            FishEntity.PersonEntity model = new FishEntity.PersonEntity();
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["username"] != null)
                {
                    model.username = ds.Tables[0].Rows[0]["username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["realname"] != null)
                {
                    model.realname = ds.Tables[0].Rows[0]["realname"].ToString();
                }
                return model;
            }
            else {
                return null;
            }
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
			parameters[0].Value = "t_user";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  Method

        public bool FlagDelete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_user set isdelete=1 where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32, 8)
                                          };
            parameters[0].Value = id;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        public FishEntity.PersonEntity Login(string userName, string password)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,username,password,realname,ename,sex,email,phone,telephone,age,department,entrytime,roletype,roledate,createtime,createman,modifytime,modifyman,isdelete from t_user ");
            strSql.Append(" where username=@username and password=@password and isdelete=0");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@username", MySqlDbType.VarChar,45),
                    new MySqlParameter("@password",MySqlDbType.VarChar)
                                          };

            parameters[0].Value = userName;
            parameters[1].Value = password;

            FishEntity.PersonEntity model = new FishEntity.PersonEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                model.username = ds.Tables[0].Rows[0]["username"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.realname = ds.Tables[0].Rows[0]["realname"].ToString();
                model.ename = ds.Tables[0].Rows[0]["ename"].ToString();
                model.sex = ds.Tables[0].Rows[0]["sex"].ToString();
                model.email = ds.Tables[0].Rows[0]["email"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                if (ds.Tables[0].Rows[0]["age"].ToString() != "")
                {
                    model.age = int.Parse(ds.Tables[0].Rows[0]["age"].ToString());
                }
                model.department = ds.Tables[0].Rows[0]["department"].ToString();
                if (ds.Tables[0].Rows[0]["entrytime"] != null && ds.Tables[0].Rows[0]["entrytime"].ToString() != "")
                {
                    model.entrytime = DateTime.Parse(ds.Tables[0].Rows[0]["entrytime"].ToString());
                }
                model.roletype = ds.Tables[0].Rows[0]["roletype"].ToString();
                model.roledate = ds.Tables[0].Rows[0]["roledate"].ToString();
                if (ds.Tables[0].Rows[0]["createtime"] != null && ds.Tables[0].Rows[0]["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(ds.Tables[0].Rows[0]["createtime"].ToString());
                }
                model.createman = ds.Tables[0].Rows[0]["createman"].ToString();
                if (ds.Tables[0].Rows[0]["modifytime"] != null && ds.Tables[0].Rows[0]["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(ds.Tables[0].Rows[0]["modifytime"].ToString());
                }
                model.modifyman = ds.Tables[0].Rows[0]["modifyman"].ToString();
                if (ds.Tables[0].Rows[0]["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(ds.Tables[0].Rows[0]["isdelete"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }

        }


        public bool ModifyPassword(int userid, string pwd)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_user set password=@password where id=@id");
            MySqlParameter[] parameters = {
                                              new MySqlParameter("@password", MySqlDbType.VarChar,45),
                                              new MySqlParameter("@id", MySqlDbType.Int32, 8)
                                          };
            parameters[0].Value = pwd;
            parameters[1].Value = userid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;

        }

        public List<FishEntity.PersonRole> GetPersionRoles(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from v_userrole where userid=" + userid);
            
            DataSet ds = MySqlHelper.Query(strSql.ToString());

            List<FishEntity.PersonRole> list = new List<FishEntity.PersonRole>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                FishEntity.PersonRole model = new FishEntity.PersonRole();

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
                model.userid = userid;

                list.Add(model);
            }
            return list;
        }

    }
}
