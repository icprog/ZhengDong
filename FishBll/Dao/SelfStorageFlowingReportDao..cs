using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Dao
{
    public class SelfStorageFlowingReportDao
    {
        public List<FishEntity.SelfStorageFlowingReportVo> GetInventory(DateTime date)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_inventory ");               
            strSql.Append( string.Format( " where date='{0}'" , date.ToString("yyyy-MM-01")) );
            strSql.Append(" order by productcode asc, date asc");

            DataSet ds = MySqlHelper.Query(strSql.ToString());      
            List<FishEntity.SelfStorageFlowingReportVo> list = new List<FishEntity.SelfStorageFlowingReportVo>();
            int rowcount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                FishEntity.SelfStorageFlowingReportVo vo = DataRowToVo(ds.Tables[0].Rows[i]);      
                list.Add(vo);
            }      
            return list;
        }

        //public List<FishEntity.SelfStorageFlowingReportVo> GetDetail(DateTime startDate, DateTime endDate)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select * from v_inventory ");
        //    strSql.Append(string.Format(" where date >='{0}' and date<='{1}'", startDate.ToString("yyyy-MM-01 00:00:00") , endDate.ToString("yyyy-MM-dd 23:59:59")));
            
        //    DataSet ds = MySqlHelper.Query(strSql.ToString());
        //    List<FishEntity.SelfStorageFlowingReportVo> list = new List<FishEntity.SelfStorageFlowingReportVo>();

        //    int rowcount = ds.Tables[0].Rows.Count;
        //    for (int i = 0; i < rowcount; i++)
        //    {
        //        FishEntity.SelfStorageFlowingReportVo vo = DataRowToVo(ds.Tables[0].Rows[i]);

        //        list.Add(vo);
        //    }

        //    return list;
        //}

        public List<FishEntity.SelfStorageFlowingReportVo> Report(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_selfstorageflowingreport");
            if (string.IsNullOrEmpty(where) == false)
            {
                strSql.Append(" where "+ where );
            }

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            List<FishEntity.SelfStorageFlowingReportVo> list = new List<FishEntity.SelfStorageFlowingReportVo>();

            int rowcount = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rowcount; i++)
            {
                FishEntity.SelfStorageFlowingReportVo vo = DataRowToVo(ds.Tables[0].Rows[i]);

                list.Add(vo);
            }

            return list;
        }

        protected FishEntity.SelfStorageFlowingReportVo DataRowToVo(DataRow row)
        {
            FishEntity.SelfStorageFlowingReportVo vo = new FishEntity.SelfStorageFlowingReportVo();

            if (row["agentifcompany"] != null)
            {
                vo.agentifcompany = row["agentifcompany"].ToString();
            }
            if (row["arriveportdate"] != null)
            {
                vo.arriveportdate = row["arriveportdate"].ToString();
            }
            if (row["billcode"] != null)
            {
                vo.billcode = row["billcode"].ToString();
            }
            if (row["billtype"] != null)
            {
                vo.billtype = row["billtype"].ToString();
            }          

            if (row["brand"] != null)
            {
                vo.brand = row["brand"].ToString();
            }
            if (row["customsofcompany"] != null)
            {
                vo.customsofcompany = row["customsofcompany"].ToString();
            }

            if (row["date"] != null && row["date"].ToString() != "")
            {
                vo.date = DateTime.Parse(row["date"].ToString());
            }

            if (row["nature"] != null)
            {
                vo.nature = row["nature"].ToString();
            }
            if (row["ownername"] != null)
            {
                vo.ownername = row["ownername"].ToString();
            }

            if (row["productcode"] != null)
            {
                vo.productcode = row["productcode"].ToString();
            }

            if (row["productid"] != null && row["productid"].ToString() != "")
            {
                vo.productid = int.Parse(row["productid"].ToString());
            }
            if (row["productname"] != null)
            {
                vo.productname = row["productname"].ToString();
            }

            if (row["sgs_amine"] != null && row["sgs_amine"].ToString() != "")//
            {
                vo.sgs_amine = decimal.Parse(row["sgs_amine"].ToString());
            }
            if (row["sgs_protein"] != null && row["sgs_protein"].ToString() != "")
            {
                vo.sgs_protein = decimal.Parse(row["sgs_protein"].ToString());
            }
            if (row["sgs_tvn"] != null && row["sgs_tvn"].ToString() != "")
            {
                vo.sgs_tvn = decimal.Parse(row["sgs_tvn"].ToString());
            }

            if (row["specification"] != null)
            {

                vo.specification = row["specification"].ToString();
            }
            if (row["storagetype"] != null)
            {
                vo.storagetype = row["storagetype"].ToString();
            }
            if (row["techtype"] != null)
            {
                vo.techtype = row["techtype"].ToString();
            }

            if (row["state3"] != null)//////////////////////////////////////
            {
                vo.State3 = row["state3"].ToString();
                //查询出状态值对应的状态名称
                FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(vo.State3); });
                if (item != null)
                {
                    vo.statename = item.Name;
                }  
            }

            if (row["weight"] != null)
            {
                vo.weight = decimal.Parse(row["weight"].ToString());
            }
            if (row["package"] != null)
            {
                vo.package = int.Parse(row["package"].ToString());
            }

            return vo;
        }
    }
}
