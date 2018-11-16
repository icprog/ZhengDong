using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class LoadingDetailDaoEx:LoadingDetailDao
    {
        public List<FishEntity.LoadingDetailEntity> GetDetailOfBill(int billId )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_loadingdetail where mid=@mid");
            MySqlParameter[] parameters = {
					new MySqlParameter("@mid", MySqlDbType.Int32)
			};
            parameters[0].Value = billId;

           DataSet ds= MySqlHelper.Query(strSql.ToString(), parameters);
           List<FishEntity.LoadingDetailEntity> modelList = new List<FishEntity.LoadingDetailEntity>();
           int rowsCount = ds.Tables[0].Rows.Count;
           if (rowsCount > 0)
           {
               FishEntity.LoadingDetailEntity model;
               for (int n = 0; n < rowsCount; n++)
               {
                   model = DataRowToModel(ds.Tables[0].Rows[n]);

                   if (ds.Tables[0].Rows[n]["contractweight"] != null)
                   {
                       decimal temp = 0;
                        decimal.TryParse(ds.Tables[0].Rows[n]["contractweight"].ToString(),out temp );
                        model.contractweight = temp;
                   }
                   if (ds.Tables[0].Rows[n]["contractquantity"] != null)
                   {
                       int tempint = 0;
                       int.TryParse(ds.Tables[0].Rows[n]["contractquantity"].ToString(), out tempint);
                       model.contractquantity = tempint;
                   }
                   if (ds.Tables[0].Rows[n]["getweight"] != null)
                   {
                       decimal temp = 0;
                       decimal.TryParse(ds.Tables[0].Rows[n]["getweight"].ToString(), out temp);
                       model.getweight = temp;
                   }
                   if (ds.Tables[0].Rows[n]["getquantity"] != null)
                   {
                       int tempint = 0;
                       int.TryParse(ds.Tables[0].Rows[n]["getquantity"].ToString(), out tempint);
                       model.getquantity = tempint;
                   }
                   modelList.Add(model);
               }
           }
           return modelList;
        }

        public List<FishEntity.LoadingDetailVo> GetDetailOfCompanyId(int companyid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select b.signdate , c.nature,c.specification, a.tons , a.packages, c.sgs_protein ,c.sgs_tvn , a.unitprice , c.brand");
            strSql.Append(" from t_loadingdetail a inner join t_loadingbills b on a.mid= b.id left join t_product c on a.productid =c.id ");
            strSql.Append("where b.companyid="+ companyid );
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            int rowcount = ds.Tables[0].Rows.Count;
            List<FishEntity.LoadingDetailVo> list = new List<FishEntity.LoadingDetailVo>();
            for (int i = 0; i < rowcount; i++)
            {
                FishEntity.LoadingDetailVo vo = new FishEntity.LoadingDetailVo();
                vo = DataRowToVo(ds.Tables[0].Rows[i]);
                list.Add(vo);
            }
            return list;
        }

        protected FishEntity.LoadingDetailVo DataRowToVo(DataRow row)
        {
            FishEntity.LoadingDetailVo vo = new FishEntity.LoadingDetailVo();
            if (row["brand"] != null)
            {
                vo.brand = row["brand"].ToString();
            }
            if (row["nature"] != null)
            {
                vo.nature = row["nature"].ToString();
            }
            if (row["packages"] != null && row["packages"].ToString() != "")
            {
                vo.packages = int.Parse ( row["packages"].ToString());
            }
            if (row["sgs_protein"] != null && row["sgs_protein"].ToString () != "" )
            {
                vo.sgs_protein =decimal.Parse ( row["sgs_protein"].ToString());
            }
            if (row["sgs_tvn"] != null&&row["sgs_tvn"].ToString()!="")
            {
                vo.sgs_tvn =int.Parse( row["sgs_tvn"].ToString());
            }
            if (row["signdate"] != null && row["signdate"].ToString()!="" )
            {
                vo.signdate = DateTime.Parse( row["signdate"].ToString());
            }
            if (row["specification"] != null)
            {
                vo.specification = row["specification"].ToString();
            }
             if (row["tons"] != null&& row["tons"].ToString() !="")
            {
                vo.tons = decimal.Parse( row["tons"].ToString());
            }
                if (row["unitprice"] != null&& row["unitprice"].ToString() !="")
            {
                vo.unitprice = decimal.Parse( row["unitprice"].ToString());
            }
            return vo;
        }
    }
}
