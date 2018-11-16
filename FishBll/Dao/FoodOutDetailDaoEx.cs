using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class FoodOutDetailDaoEx : FoodOutDetailDao
    {
        public List<FishEntity.FoodOutDetailEntityVO> GetDetailByMid(int mid)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select code as productcode ,name as productname ,state,");
            //strSql.Append(" weight,quantity,remainweight,remainquantity,homemadeweight,homemadepackages,homemadecost,homemadeunitprice,price,");
            //strSql.Append(" sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa, sgs_fat,sgs_water,sgs_sand,");
            //strSql.Append(" domestic_protein,domestic_tvn,domestic_graypart,"); 
            //strSql.Append(" domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine,supplierid,linkmanid,linkmancode,linkman,");
            //strSql.Append(" b.productid , b.id , b.mid, b.tons , b.package , b.unitprice ,b.cost ");
            //strSql.Append(" from t_product a inner join t_foodoutdetail b on a.id = b.productid where b.mid=@mid");

            strSql.Append(" select * from v_foodoutdetail ");
            strSql.Append(" where mid=@mid");

            MySqlParameter[] parameters ={
                                             new MySqlParameter("@mid",MySqlDbType.Int32  , 8)
                                         };
            parameters[0].Value = mid;

            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            List<FishEntity.FoodOutDetailEntityVO> modelList = new List<FishEntity.FoodOutDetailEntityVO>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.FoodOutDetailEntityVO model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToVo(ds.Tables[0].Rows[n]);
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.FoodOutDetailEntityVO DataRowToVo(DataRow row)
        {
            FishEntity.FoodOutDetailEntityVO model = new FishEntity.FoodOutDetailEntityVO();
            if (row != null)
            {
                if (row["no"] != null && row["no"].ToString() != "")
                {
                    model.no = int.Parse(row["no"].ToString());
                }

                if (row["solutionid"] != null && row["solutionid"].ToString() != "")
                {
                    model.solutionid = int.Parse(row["solutionid"].ToString());
                }

                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["mid"] != null && row["mid"].ToString() != "")
                {
                    model.mid = int.Parse(row["mid"].ToString());
                }
                if (row["productid"] != null && row["productid"].ToString() != "")
                {
                    model.productid = int.Parse(row["productid"].ToString());
                }
                if (row["productcode"] != null )
                {
                    model.productcode = row["productcode"].ToString();
                }
                if (row["productname"] != null)
                {
                    model.productname = row["productname"].ToString();
                }             

                if (row["tons"] != null && row["tons"].ToString() != "")
                {
                    model.tons = decimal.Parse(row["tons"].ToString());
                }
                if (row["package"] != null && row["package"].ToString() != "")
                {
                    model.package = int.Parse(row["package"].ToString());
                }

                if (row["state"] != null)
                {
                    model.state = row["state"].ToString();
                }
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["shipno"] != null)
                {
                    model.shipno = row["shipno"].ToString();
                }
                if (row["billofgoods"] != null)
                {
                    model.billofgoods = row["billofgoods"].ToString();
                }
                if (row["selfrmb"] != null && row["selfrmb"].ToString () !="" )
                {
                    model.selfrmb = decimal.Parse( row["selfrmb"].ToString());
                }
                if (row["salermb"] != null && row["salermb"].ToString() != "")
                {
                    model.salermb = decimal.Parse(row["salermb"].ToString());
                }

                //if (row["weight"] != null && row["weight"].ToString() != "")
                //{
                //    model.weight = decimal.Parse(row["weight"].ToString());
                //}
                //if (row["quantity"] != null && row["quantity"].ToString() != "")
                //{
                //    model.quantity = int.Parse(row["quantity"].ToString());
                //}
                //if (row["remainweight"] != null && row["remainweight"].ToString() != "")
                //{
                //    model.remainweight = decimal.Parse(row["remainweight"].ToString());
                //}
                //if (row["remainquantity"] != null && row["remainquantity"].ToString() != "")
                //{
                //    model.remainquantity = int.Parse(row["remainquantity"].ToString());
                //}
                //if (row["homemadeweight"] != null && row["homemadeweight"].ToString() != "")
                //{
                //    model.homemadeweight = decimal.Parse(row["homemadeweight"].ToString());
                //}
                //if (row["homemadepackages"] != null && row["homemadepackages"].ToString() != "")
                //{
                //    model.homemadepackages = int.Parse(row["homemadepackages"].ToString());
                //}
                //if (row["homemadecost"] != null && row["homemadecost"].ToString() != "")
                //{
                //    model.homemadecost = decimal.Parse(row["homemadecost"].ToString());
                //}
                //if (row["homemadeunitprice"] != null && row["homemadeunitprice"].ToString() != "")
                //{
                    //model.homemadeunitprice = decimal.Parse(row["homemadeunitprice"].ToString());                     
                //}

                //if (model.homemadeweight == 0) model.homemadeunitprice = 0;
                //else
                //{
                //    model.homemadeunitprice = model.homemadecost / model.homemadeweight;
                //}

                //if (row["price"] != null && row["price"].ToString() != "")
                //{
                //    model.price = decimal.Parse(row["price"].ToString());
                //}
                //if (row["sgs_protein"] != null && row["sgs_protein"].ToString() != "")
                //{
                //    model.sgs_protein = decimal.Parse(row["sgs_protein"].ToString());
                //}
                //if (row["sgs_tvn"] != null && row["sgs_tvn"].ToString() != "")
                //{
                //    model.sgs_tvn = int.Parse(row["sgs_tvn"].ToString());
                //}
                //if (row["sgs_graypart"] != null && row["sgs_graypart"].ToString() != "")
                //{
                //    model.sgs_graypart = decimal.Parse(row["sgs_graypart"].ToString());
                //}
                //if (row["sgs_sandsalt"] != null && row["sgs_sandsalt"].ToString() != "")
                //{
                //    model.sgs_sandsalt = decimal.Parse(row["sgs_sandsalt"].ToString());
                //}
                //if (row["sgs_amine"] != null && row["sgs_amine"].ToString() != "")
                //{
                //    model.sgs_amine = int.Parse(row["sgs_amine"].ToString());
                //}
                //if (row["sgs_ffa"] != null && row["sgs_ffa"].ToString() != "")
                //{
                //    model.sgs_ffa = decimal.Parse(row["sgs_ffa"].ToString());
                //}
                //if (row["sgs_fat"] != null && row["sgs_fat"].ToString() != "")
                //{
                //    model.sgs_fat = decimal.Parse(row["sgs_fat"].ToString());
                //}
                //if (row["sgs_water"] != null && row["sgs_water"].ToString() != "")
                //{
                //    model.sgs_water = decimal.Parse(row["sgs_water"].ToString());
                //}
                //if (row["sgs_sand"] != null && row["sgs_sand"].ToString() != "")
                //{
                //    model.sgs_sand = decimal.Parse(row["sgs_sand"].ToString());
                //}
                if (row["domestic_protein"] != null && row["domestic_protein"].ToString() != "")
                {
                    model.domestic_protein = decimal.Parse(row["domestic_protein"].ToString());
                }
                if (row["domestic_tvn"] != null && row["domestic_tvn"].ToString() != "")
                {
                    model.domestic_tvn = decimal.Parse(row["domestic_tvn"].ToString());
                }
                if (row["domestic_graypart"] != null && row["domestic_graypart"].ToString() != "")
                {
                    model.domestic_graypart = decimal.Parse(row["domestic_graypart"].ToString());
                }
                if (row["domestic_sandsalt"] != null && row["domestic_sandsalt"].ToString() != "")
                {
                    model.domestic_sandsalt = decimal.Parse(row["domestic_sandsalt"].ToString());
                }
                if (row["domestic_sour"] != null && row["domestic_sour"].ToString() != "")
                {
                    model.domestic_sour = decimal.Parse(row["domestic_sour"].ToString());
                }
                if (row["domestic_lysine"] != null && row["domestic_lysine"].ToString() != "")
                {
                    model.domestic_lysine = decimal.Parse(row["domestic_lysine"].ToString());
                }
                if (row["domestic_methionine"] != null && row["domestic_methionine"].ToString() != "")
                {
                    model.domestic_methionine = decimal.Parse(row["domestic_methionine"].ToString());
                }
                if (row["domestic_amine"] != null && row["domestic_amine"].ToString() != "")
                {
                    model.domestic_amine = decimal.Parse(row["domestic_amine"].ToString());
                }
                if (row["domestic_aminototal"] != null && row["domestic_aminototal"].ToString() != "")
                {
                    model.domestic_aminototal = decimal.Parse(row["domestic_aminototal"].ToString());
                }
                if (row["domestic_fat"] != null && row["domestic_fat"].ToString() != "")
                {
                    model.domestic_fat = decimal.Parse(row["domestic_fat"].ToString());
                }
            }
            return model;
        }
    
    }
}
