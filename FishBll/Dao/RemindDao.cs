using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Dao
{
    public class RemindDao
    {
        public List<FishEntity.RemindEntity> GetRemind(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select *");
            strSql.Append(" from v_remind");
            if (string.IsNullOrEmpty(where) == false)
            {
                strSql.Append( " where " + where );
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.RemindEntity> list = new List<FishEntity.RemindEntity>();
            int rowcount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                FishEntity.RemindEntity model = DataRowToModel(ds.Tables[0].Rows[i]);
                list.Add(model);
            }
            return list;
        }

        protected FishEntity.RemindEntity DataRowToModel(DataRow row)
        {
            FishEntity.RemindEntity model = new FishEntity.RemindEntity();
            model.companycode = row["companycode"].ToString();
            model.companyid = int.Parse( row["companyid"].ToString());
            model.companyname = row["companyname"].ToString();
            model.linkman = row["linkman"].ToString();
            model.linkmancode = row["linkmancode"].ToString();
            model.linkmanid = int.Parse( row["linkmanid"].ToString());

            if (row["nextlinkdate"] != null)
            {
                DateTime date;
                DateTime.TryParse(row["nextlinkdate"].ToString(), out date);
                model.nextlinkdate = date;
            }
            else
            {
                model.nextlinkdate = DateTime.MinValue;
            }

            if (row["telephone"] != null)
            {
                model.telephone = row["telephone"].ToString();
            }
            if (row["qq"] != null)
            {
                model.qq = row["qq"].ToString();
            }
            if (row["weixin"] != null)
            {
                model.weixin = row["weixin"].ToString();
            }
            if (row["phone1"] != null)
            {
                model.phone1 = row["phone1"].ToString();
            }
            if (row["phone2"] != null)
            {
                model.phone2 = row["phone2"].ToString();
            }
            if (row["phone3"] != null)
            {
                model.phone3 = row["phone3"].ToString();
            }
            if (row["salesman"] != null)
            {
                model.salesman = row["salesman"].ToString();
            }
            if (row["salesmancode"] != null)
            {
                model.salesmancode = row["salesmancode"].ToString();
            }

                            
            return model;
        }
    }
}
