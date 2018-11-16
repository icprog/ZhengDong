using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
namespace FishBll.Dao
{
    public class TheproblemsheetDaoEx:TheproblemsheetDao
    {
        public List<FishEntity.TheproblemsheetEntityVo> GetModelListVo(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_theproblemsheet ");
            if (where.Trim() != "")
            {
                strSql.Append(" where 1=1 " + where);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.TheproblemsheetEntityVo> modelList = new List<FishEntity.TheproblemsheetEntityVo>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.TheproblemsheetEntityVo model;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                model = new FishEntity.TheproblemsheetEntityVo();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["ContractNo"] != null && row["ContractNo"].ToString() != "")
                {
                    model.ContractNo = row["ContractNo"].ToString();
                }
                if (row["occurDate"] != null && row["occurDate"].ToString() != "")
                {
                    model.OccurDate = DateTime.Parse(row["occurDate"].ToString());
                }
                if (row["EventName"] != null && row["EventName"].ToString() != "")
                {
                    model.EventName = row["EventName"].ToString();
                }
                if (row["Chargeback"]!=null&&row["Chargeback"].ToString()!="")
                {
                    model.Chargeback =decimal.Parse(row["Chargeback"].ToString());
                }
                if (row["SolvTtheProblem"] != null && row["SolvTtheProblem"].ToString() != "")
                {
                    model.SolvTtheProblem = row["SolvTtheProblem"].ToString();
                }
                if (row["Remarks"] != null && row["Remarks"].ToString() != "")
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if ( row [ "codeContract" ] != null && row [ "codeContract" ] . ToString ( ) != "" )
                {
                    model . codeContract = row [ "codeContract" ] . ToString ( );
                }
                if (row["createman"]!=null)
                {
                    model.Createman = row["createman"].ToString();
                }
                if (row["modifyman"]!=null)
                {
                    model.Modifyman = row["modifyman"].ToString();
                }
                if (row["FishMealId"]!=null)
                {
                    model.FishMealId = row["FishMealId"].ToString();
                }
                modelList .Add(model);
            }
            return modelList;
        }
    }
}
