using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
   public class PackingWeightLisDao
    {
        public PackingWeightLisDao() { }
        public bool Exists(string WarehouseCode, string FishId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) coun from t_PackingWeightList ");
            strSql.Append("where WarehouseCode=@WarehouseCode and FishId=@FishId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@WarehouseCode",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishId",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = WarehouseCode;
            parameter[1].Value = FishId;

            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }
        DataTable table()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select WarehouseCode,FishId from t_PackingWeightList ");

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        public bool add(List<FishEntity.PackingWeightListEntity> modelList)
        {
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();

            foreach (FishEntity.PackingWeightListEntity list in modelList)
            {
                list.Createtime = list.Modifytime = dt();
                list.Createman = list.Modifyman = FishEntity.Variable.User.username;

                if (Exists(list.WarehouseCode, list.FishId) == true)
                    edit(list, SQLString, strSql);
                else
                    insert(list, SQLString, strSql);
            }

            DataTable tab = table();
            if (tab != null && tab.Rows.Count > 0)
            {
                FishEntity.PackingWeightListEntity list = new FishEntity.PackingWeightListEntity();
                string person = string.Empty, proId = string.Empty;
                for (int i = 0; i < tab.Rows.Count; i++)
                {
                    person = tab.Rows[i]["WarehouseCode"].ToString();
                    proId = tab.Rows[i]["FishId"].ToString();
                    list = modelList.Find((k) =>
                    {
                        return k.WarehouseCode.Equals(person) && k.FishId.Equals(proId);
                    });

                    if (list == null)
                    {
                        del(person, proId, SQLString, strSql);
                    }

                }
            }

            return MySqlHelper.ExecuteSqlTran(SQLString);
        }
        void del(string person, string proId, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("delete from t_PackingWeightList ");
            strSql.Append("where WarehouseCode=@WarehouseCode and ");
            strSql.Append("FishId=@FishId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@WarehouseCode",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishId",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = person;
            parameter[1].Value = proId;

            SQLString.Add(strSql, parameter);
        }
        void edit(FishEntity.PackingWeightListEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("update t_PackingWeightList set ");
            strSql.Append("CONTANERNO=@CONTANERNO, ");
            strSql.Append("QUANTITYOFBAGS=@QUANTITYOFBAGS, ");
            strSql.Append("GROSSWEIGHT=@GROSSWEIGHT, ");
            strSql.Append("NETWEIGHT=@NETWEIGHT, ");
            strSql.Append("modifyman=@modifyman, ");
            strSql.Append("modifytime=@modifytime ");
            strSql.Append("where WarehouseCode=@WarehouseCode and ");
            strSql.Append("FishId=@FishId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@CONTANERNO",list.CNOTANERNO),
                new MySqlParameter("@QUANTITYOFBAGS",list.QUANTITYOFBAGS),
                new MySqlParameter("@GROSSWEIGHT",list.GROSSWEIGHT),
                new MySqlParameter("@NETWEIGHT",list.NETWEIGHT),
                new MySqlParameter("@modifyman",list.Modifyman),
                new MySqlParameter("@modifytime",list.Modifytime),
                new MySqlParameter("@createman",list.Createman),
                new MySqlParameter("@createtime",list.Createtime),
                new MySqlParameter("@WarehouseCode",list.WarehouseCode),
                new MySqlParameter("@FishId",list.FishId)
            };
            SQLString.Add(strSql, parameter);

        }

        void insert(FishEntity.PackingWeightListEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("insert into t_PackingWeightList (");
            strSql.Append("WarehouseCode,FishId,CONTANERNO,QUANTITYOFBAGS,GROSSWEIGHT,NETWEIGHT,modifytime,modifyman,createman,createtime)");
            strSql.Append("values (");
            strSql.Append("@WarehouseCode,@FishId,@CONTANERNO,@QUANTITYOFBAGS,@GROSSWEIGHT,@NETWEIGHT,@modifytime,@modifyman,@createman,@createtime)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@WarehouseCode",list.WarehouseCode),
                new MySqlParameter("@FishId",list.FishId),
                new MySqlParameter("@CONTANERNO",list.CNOTANERNO),
                new MySqlParameter("@QUANTITYOFBAGS",list.QUANTITYOFBAGS),
                new MySqlParameter("@GROSSWEIGHT",list.GROSSWEIGHT),
                new MySqlParameter("@NETWEIGHT",list.NETWEIGHT),
                new MySqlParameter("@modifyman",list.Modifyman),
                new MySqlParameter("@modifytime",list.Modifytime),
                new MySqlParameter("@createman",list.Createman),
                new MySqlParameter("@createtime",list.Createtime)
            };
            SQLString.Add(strSql, parameter);
        }
        public List<FishEntity.PackingWeightListEntity> getList(string jincangdan, string yufenid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select id,WarehouseCode,FishId,CONTANERNO,QUANTITYOFBAGS,GROSSWEIGHT,NETWEIGHT from t_PackingWeightList where WarehouseCode='{0}' and FishId={1} ", jincangdan,yufenid);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            List<FishEntity.PackingWeightListEntity> modelList = new List<FishEntity.PackingWeightListEntity>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(getModel(dt.Rows[i]));
                }

                return modelList;
            }
            else
                return null;
        }
        public FishEntity.PackingWeightListEntity getModel(DataRow row)
        {
            FishEntity.PackingWeightListEntity model = new FishEntity.PackingWeightListEntity();

            if (row != null)
            {
                if (row["id"] != null&&row["id"].ToString()!="")
                    model.Id =int.Parse(row["id"].ToString());
                if (row["WarehouseCode"] != null)
                    model.WarehouseCode = row["WarehouseCode"].ToString();
                if (row["FishId"] != null)
                    model.FishId = row["FishId"].ToString();
                if (row["QUANTITYOFBAGS"] != null)
                    model.QUANTITYOFBAGS = row["QUANTITYOFBAGS"].ToString();
                if (row["GROSSWEIGHT"] != null)
                    model.GROSSWEIGHT = row["GROSSWEIGHT"].ToString();
                if (row["CONTANERNO"] != null)
                    model.CNOTANERNO = row["CONTANERNO"].ToString();
                if (row["NETWEIGHT"] != null)
                    model.NETWEIGHT = row["NETWEIGHT"].ToString();
            }

            return model;

        }
        DateTime dt()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT now() t");

            DataSet da = MySqlHelper.Query(strSql.ToString());

            return Convert.ToDateTime(da.Tables[0].Rows[0]["t"].ToString());
        }
    }    
}
