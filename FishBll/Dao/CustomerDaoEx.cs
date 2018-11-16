using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CustomerDaoEx : CustomerDao
    {
        public List<FishEntity.CustomerEntity> GetCustomerOfcompany(int companyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.id,a.code,a.name, a.currentlinkDate,a.telephone,a.phone1,a.phone2,a.phone3,a.post,a.department1,a.department,a.email,");
            strSql.Append(" a.qq,a.weixin,a.nextlinkdate,a.nextcallrecordid,a.validate,a.remark,a.company,a.createtime,a.createman,");
            strSql.Append(" a.modifytime,a.modifyman,a.isdelete,a.flag,a.homeaddress,a.officeaddress,a.sex,a.fox ");
            strSql.Append(" FROM t_customer a inner join t_customerofcompany b on a.id =b.customerid where b.companyid= " + companyId);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.CustomerEntity> modelList = new List<FishEntity.CustomerEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.CustomerEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(ds.Tables[0].Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public List<FishEntity.CustomerEntity> GetCustomerOfcompany(string companycode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.id,a.code,a.name, a.currentlinkDate,a.telephone,a.phone1,a.phone2,a.phone3,a.post,a.department1,a.department,a.email,");
            strSql.Append(" a.qq,a.weixin,a.nextlinkdate,a.nextcallrecordid,a.validate,a.remark,a.company,a.createtime,a.createman,");
            strSql.Append(" a.modifytime,a.modifyman,a.isdelete,a.flag,a.homeaddress,a.officeaddress,a.sex,a.fox ");
            strSql.Append(" FROM t_customer a inner join t_customerofcompany b on a.id =b.customerid where a.company= " + companycode);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.CustomerEntity> modelList = new List<FishEntity.CustomerEntity>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.CustomerEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(ds.Tables[0].Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        public bool UpdateLinkDate(string code, DateTime currentLinkDate, int nextLinkId, DateTime nextLinkDate)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_customer set currentlinkDate=@currentlinkDate , nextcallrecordid=@nextcallrecordid, nextlinkdate=@nextlinkdate where code = @code");

            MySqlParameter[] parameters =
            {
                new MySqlParameter("@currentlinkDate" , MySqlDbType.Timestamp ),
                new MySqlParameter("@nextcallrecordid",MySqlDbType.Int32 , 8),
                new MySqlParameter("@nextlinkdate",MySqlDbType.Timestamp ),
                new MySqlParameter("@code",MySqlDbType.VarChar , 45)
            };
            parameters[0].Value = currentLinkDate;
            parameters[1].Value = nextLinkId;
            parameters[2].Value = nextLinkDate;
            parameters[3].Value = code;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        public List<FishEntity.CustomerEntityVo> GetModelListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from (");
            strSql.Append("select a.id,a.code, a.name, a.currentlinkDate,a.telephone,a.phone1,a.phone2,a.phone3,a.post,");
            strSql.Append(" a.department,a.email,a.qq,a.weixin,a.nextlinkdate,a.nextcallrecordid,a.validate,a.remark,");
            strSql.Append(" a.company ,a.createtime,a.createman,a.modifytime,a.modifyman,a.isdelete ,a.flag,");
            strSql.Append(" b.id as companyid , b.code as companycode , b.fullname as companyname,a.fox,");
            strSql.Append("a.homeaddress,a.officeaddress,a.sex ,a.department1, b.salesmancode, b.salesman ");
            strSql.Append(" from t_customer a inner join t_company b on a.company=b.code ) t");

            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            return DataTableToListVo(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        protected List<FishEntity.CustomerEntityVo> DataTableToListVo(DataTable dt)
        {
            List<FishEntity.CustomerEntityVo> modelList = new List<FishEntity.CustomerEntityVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.CustomerEntityVo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    DataRow row = dt.Rows[n];
                    model = new FishEntity.CustomerEntityVo();
                    if (row["id"].ToString() != "")
                    {
                        model.id = int.Parse(row["id"].ToString());
                    }
                    model.code = row["code"].ToString();
                    model.name = row["name"].ToString();
                    if (row["currentlinkDate"] != null && row["currentlinkDate"].ToString() != "")
                    {
                        model.currentlinkDate = DateTime.Parse(row["currentlinkDate"].ToString());
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

                    if (dt.Rows[n]["companyid"].ToString() != "")
                    {
                        model.companyid = int.Parse(dt.Rows[n]["companyid"].ToString());
                    }
                    model.companyName = dt.Rows[n]["companyname"].ToString();

                    if (dt.Rows[n]["fox"] != null)
                    {
                        model.fox = dt.Rows[n]["fox"].ToString();
                    }

                    if (dt.Rows[n]["homeaddress"] != null)
                    {
                        model.homeaddress = dt.Rows[n]["homeaddress"].ToString();
                    }

                    if (dt.Rows[n]["officeaddress"] != null)
                    {
                        model.officeaddress = dt.Rows[n]["officeaddress"].ToString();
                    }
                    if (dt.Rows[n]["sex"] != null)
                    {
                        model.sex = dt.Rows[n]["sex"].ToString();
                    }

                    modelList.Add(model);
                }
            }
            return modelList;
        }
    }
}
