using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ContractDaoEx : ContractDao
    {
        public List<FishEntity.ContractDetailVo> GetContractDetail(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_contract");
            if (string.IsNullOrEmpty(where) == false)
            {
                strSql.Append(" where " + where);
            }

            DataSet dsData = MySqlHelper.Query(strSql.ToString());
            return DataTableToList(dsData.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.ContractDetailVo> DataTableToList(DataTable dt)
        {
            List<FishEntity.ContractDetailVo> modelList = new List<FishEntity.ContractDetailVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ContractDetailVo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToDetail(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        public int UpdateContractStatus(int id, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_contract set status=@status where contractid=@contractid ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@status", MySqlDbType.Int32),
					new MySqlParameter("@contractid", MySqlDbType.Int32)
			};
            parameters[0].Value = status;
            parameters[1].Value = id;

            return MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        protected FishEntity.ContractDetailVo DataRowToDetail(DataRow row)
        {
            FishEntity.ContractDetailVo model = new FishEntity.ContractDetailVo();

            if (row != null)
            {
                if (row["contractid"] != null && row["contractid"].ToString() != "")
                {
                    model.contractid = int.Parse(row["contractid"].ToString());
                }
                if (row["type"] != null && row["type"].ToString() != "")
                {
                    model.type = int.Parse(row["type"].ToString());
                }
                if (row["contractno"] != null)
                {
                    model.contractno = row["contractno"].ToString();
                }
                if (row["signdate"] != null)
                {
                    model.signdate = row["signdate"].ToString();
                }
                if (row["signaddress"] != null)
                {
                    model.signaddress = row["signaddress"].ToString();
                }
                if (row["money"] != null && row["money"].ToString() != "")
                {
                    model.money = decimal.Parse(row["money"].ToString());
                }
                if (row["yifangcode"] != null)
                {
                    model.yifangcode = row["yifangcode"].ToString();
                }
                if (row["yifang"] != null)
                {
                    model.yifang = row["yifang"].ToString();
                }
                if (row["yiduanzhuang"] != null)
                {
                    model.yiduanzhuang = row["yiduanzhuang"].ToString();
                }
                if (row["check1"] != null)
                {
                    model.check1 = row["check1"].ToString();
                }
                if (row["check2"] != null)
                {
                    model.check2 = row["check2"].ToString();
                }
                if (row["check3"] != null)
                {
                    model.check3 = row["check3"].ToString();
                }
                if (row["deliverytime"] != null)
                {
                    model.deliverytime = row["deliverytime"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["package"] != null)
                {
                    model.package = row["package"].ToString();
                }
                if (row["date1"] != null)
                {
                    model.date1 = row["date1"].ToString();
                }
                if (row["date2"] != null)
                {
                    model.date2 = row["date2"].ToString();
                }
                if (row["date3"] != null)
                {
                    model.date3 = row["date3"].ToString();
                }
                if (row["bank"] != null)
                {
                    model.bank = row["bank"].ToString();
                }
                if (row["bankaccount"] != null)
                {
                    model.bankaccount = row["bankaccount"].ToString();
                }
                if (row["resolve"] != null)
                {
                    model.resolve = row["resolve"].ToString();
                }
                if (row["time1"] != null)
                {
                    model.time1 = row["time1"].ToString();
                }
                if (row["time2"] != null)
                {
                    model.time2 = row["time2"].ToString();
                }
                if (row["time3"] != null)
                {
                    model.time3 = row["time3"].ToString();
                }
                if (row["time4"] != null)
                {
                    model.time4 = row["time4"].ToString();
                }
                if (row["maifangcode"] != null)
                {
                    model.maifangcode = row["maifangcode"].ToString();
                }
                if (row["maifang"] != null)
                {
                    model.maifang = row["maifang"].ToString();
                }
                if (row["maifangaddress"] != null)
                {
                    model.maifangaddress = row["maifangaddress"].ToString();
                }
                if (row["maifangtelephone"] != null)
                {
                    model.maifangtelephone = row["maifangtelephone"].ToString();
                }
                if (row["maifangfox"] != null)
                {
                    model.maifangfox = row["maifangfox"].ToString();
                }
                if (row["yifangaddress"] != null)
                {
                    model.yifangaddress = row["yifangaddress"].ToString();
                }
                if (row["yifangtelephone"] != null)
                {
                    model.yifangtelephone = row["yifangtelephone"].ToString();
                }
                if (row["yifangfox"] != null)
                {
                    model.yifangfox = row["yifangfox"].ToString();
                }
                if (row["salemanid"] != null || row["salemanid"].ToString() != "")
                {
                    model.salemanid = int.Parse(row["salemanid"].ToString());
                }
                if (row["saleman"] != null)
                {
                    model.saleman = row["saleman"].ToString();
                }


                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["contractid"] != null && row["contractid"].ToString() != "")
                {
                    model.contractid = int.Parse(row["contractid"].ToString());
                }
                if (row["no"] != null && row["no"].ToString() != "")
                {
                    model.no = int.Parse(row["no"].ToString());
                }
                if (row["productid"] != null && row["productid"].ToString() != "")
                {
                    model.productid = int.Parse(row["productid"].ToString());
                }
                if (row["productno"] != null)
                {
                    model.productno = row["productno"].ToString();
                }
                if (row["productname"] != null)
                {
                    model.productname = row["productname"].ToString();
                }
                if (row["specification"] != null)
                {
                    model.specification = row["specification"].ToString();
                }
                if (row["weight"] != null && row["weight"].ToString() != "")
                {
                    model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(row["quantity"].ToString());
                }
                if (row["unitprice"] != null && row["unitprice"].ToString() != "")
                {
                    model.unitprice = decimal.Parse(row["unitprice"].ToString());
                }
                if (row["productmoney"] != null && row["productmoney"].ToString() != "")
                {
                    model.productmoney = decimal.Parse(row["productmoney"].ToString());
                }
                if (row["getweight"] != null && row["getweight"].ToString() != "")
                {
                    model.getweight = decimal.Parse(row["getweight"].ToString());
                }
                if (row["getquantity"] != null && row["getquantity"].ToString() != "")
                {
                    model.getquantity = int.Parse(row["getquantity"].ToString());
                }
                if (row["isfinished"] != null && row["isfinished"].ToString() != "")
                {
                    model.isfinished = int.Parse(row["isfinished"].ToString());
                }
                if (row["status"] != null && row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
            }

            return model;
        }

        
        public DataSet GetSelfSaleDetail(int productid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" select * from v_selfsaledetail where productid= "+ productid );

            DataSet ds = MySqlHelper.Query(strsql.ToString());
            return ds;
        }

        public DataSet GetSelfSaleDetail1(int productid)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append(" select * from t_ssss where productid= " + productid);

            DataSet ds = MySqlHelper.Query(strsql.ToString());
            return ds;
        }

    }
}
