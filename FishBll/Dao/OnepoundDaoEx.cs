using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class OnepoundDaoEx : OnepoundDao
    {
        public List<FishEntity.OnepoundEntityVo> GetModelListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_poundsalone ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where 1=1 " + strWhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());

            List<FishEntity.OnepoundEntityVo> modelList = new List<FishEntity.OnepoundEntityVo>();


            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.OnepoundEntityVo model;
            for (int n = 0; n < rowsCount; n++)
            {
                DataRow row = ds.Tables[0].Rows[n];
                model = new FishEntity.OnepoundEntityVo();
                if (row["id"].ToString() != "")
                {
                    model.Id = int.Parse(row["id"].ToString());
                }
                if (row["FishMealId"]!=null)
                {
                    model.FishMealId = row["FishMealId"].ToString();
                }
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["TiDanCode"]!=null)
                {
                    model.TiDanCode = row["TiDanCode"].ToString();
                }
                if (row["RedemptionWeight"]!=null&&row["RedemptionWeight"].ToString()!="")
                {
                    model.RedemptionWeight =decimal.Parse( row["RedemptionWeight"].ToString());
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.Code = row["code"].ToString();
                }
                if (row["Serialnumber"] != null )
                {
                    model.Serialnumber = row["Serialnumber"].ToString();
                }
                if (row["Dateofmanufacture"] != null && row["Dateofmanufacture"].ToString() != "")
                {
                    model.Dateofmanufacture = DateTime.Parse(row["Dateofmanufacture"].ToString());
                }
                else
                {
                    model.Dateofmanufacture = null;
                }
                if (row["IntothefactoryDate"] != null && row["IntothefactoryDate"].ToString() != "")
                {
                    model.IntothefactoryDate = DateTime.Parse(row["IntothefactoryDate"].ToString());
                }
                else
                {
                    model.IntothefactoryDate = null;
                }
                if ( row["Grossweight"] != null)
                {
                    model.Carnumber = row["Carnumber"].ToString();
                }
                if (row["Grossweight"] != null )
                {
                    model.Grossweight = row["Grossweight"].ToString();
                }
                if (row["Tareweight"] != null )
                {
                    model.Tareweight = row["Tareweight"].ToString();
                }
                if (row["Competition"] != null )
                {
                    model.Competition = row["Competition"].ToString();
                }
                if (row["Goods"] != null )
                {
                    model.Goods = row["Goods"].ToString();
                }
                if (row["Remarks"] != null)
                {
                    model.Remarks = row["Remarks"].ToString();
                }
                if (row["Shipno"] != null)
                {
                    model.Shipno = row["Shipno"].ToString();
                }
                if (row["Owner"].ToString() != null)
                {
                    model.Owner = row["Owner"].ToString();
                }
                if (row["OwnerId"].ToString() != null)
                {
                    model.OwnerId = row["OwnerId"].ToString();
                }
                if (row["BuyersId"].ToString() != null)
                {
                    model.BuyersId = row["BuyersId"].ToString();
                }
                if (row["SellersId"].ToString() != null)
                {
                    model.SellersId = row["SellersId"].ToString();
                }
                if (row["Country"].ToString() != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["PName"].ToString() != null)
                {
                    model.PName = row["PName"].ToString();
                }
                if (row["Qualit"].ToString() != null)
                {
                    model.Qualit = row["Qualit"].ToString();
                }
                if (row["Buyers"] != null && row["Buyers"].ToString() != "")
                {
                    model.Buyers = row["Buyers"].ToString();
                }
                if (row["Sellers"] != null && row["Sellers"].ToString() != "")
                {
                    model.Sellers = row["Sellers"].ToString();
                }

                if (row["Quantity"].ToString() != null && row["Quantity"].ToString() != "")
                {
                    model.Quantity = row["Quantity"].ToString();
                }

                if (row["Pileangle"].ToString() != null && row["Pileangle"].ToString() != "")
                {
                    model.Pileangle = row["Pileangle"].ToString();
                }

                if (row["BillOfLadingid"].ToString() != null && row["BillOfLadingid"].ToString() != "")
                {
                    model.BillOfLadingid = row["BillOfLadingid"].ToString();
                }
                if (row["Address"].ToString() != null && row["Address"].ToString() != "")
                {
                    model.Address = row["Address"].ToString();
                }
                if (row["codeContract"].ToString() != null && row["codeContract"].ToString() != "")
                {
                    model.codeContract = row["codeContract"].ToString();
                }
                if (row["createman"].ToString() != null)
                {
                    model.Createman = row["createman"].ToString();
                }
                if (row["modifyman"].ToString() != null)
                {
                    model.Modifyman = row["modifyman"].ToString();
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
