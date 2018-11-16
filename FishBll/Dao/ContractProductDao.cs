using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ContractProductDao
    {
        public List<FishEntity.ContractPorductEntity> GetProducts(int contractid, int detailid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.id as cpid , b.* from t_contractproduct a inner join t_product b on a.productid=b.id where ");
            strSql.Append(" a.contractid=" + contractid + " and a.contractdetailid="+ detailid );

            DataSet dsData = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.ContractPorductEntity> list = new List<FishEntity.ContractPorductEntity>();

            for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
            {
                FishEntity.ProductEntity entity = ProductDao.DataRowToModel(dsData.Tables[0].Rows[i]);

                FishEntity.ContractPorductEntity model = new FishEntity.ContractPorductEntity();
                if( dsData.Tables[0].Rows[i]["cpid"]!=null )
                {
                    model.cpid = int.Parse(dsData.Tables[0].Rows[i]["cpid"].ToString());
                }
                model.id = entity.id;
                model.code = entity.code;
                model.name = entity.name;
                model.specification = entity.specification;

                list.Add( model );
            }
            return list;
        }

        public int DeleteBy(int contractid, int detailid, int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append( string.Format ( " delete from t_contractproduct where contractid={0} and contractdetailid={1} and productid={2}", contractid,detailid,productid ) );

            return MySqlHelper.ExecuteSql(strSql.ToString());
        }

        public int Add(int contractid, int detailid, int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_contractproduct(");
            strSql.Append("productid,contractid,contractdetailid)");
            strSql.Append(" values (");
            strSql.Append("@productid,@contractid,@contractdetailid);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@contractid", MySqlDbType.Int32,11),
					new MySqlParameter("@contractdetailid", MySqlDbType.Int32,11)};
            parameters[0].Value = productid;
            parameters[1].Value = contractid;
            parameters[2].Value = detailid;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }

        public int Update(int contractid, int detailid, int productid, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_contractproduct set ");
            strSql.Append("productid=@productid,");
            strSql.Append("contractid=@contractid,");
            strSql.Append("contractdetailid=@contractdetailid");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@contractid", MySqlDbType.Int32,11),
					new MySqlParameter("@contractdetailid", MySqlDbType.Int32,11),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = productid;
            parameters[1].Value = contractid;
            parameters[2].Value = detailid;
            parameters[3].Value = id;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        public List<FishEntity.ContractPorductEntity> GetNotSendProducts( string where )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_notsend");
            if (string.IsNullOrEmpty(where) == false)
            {
                strSql.Append(" where "+ where );
            }

            DataSet dsData = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.ContractPorductEntity> list = new List<FishEntity.ContractPorductEntity>();
            for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
            {
                FishEntity.ContractPorductEntity model = DataRowToModel(dsData.Tables[0].Rows[i]);              

                list.Add(model );
            }
            return list;
        }


        protected FishEntity.ContractPorductEntity DataRowToModel(DataRow row)
        {
            FishEntity.ContractPorductEntity model = new FishEntity.ContractPorductEntity();
            if (row["contractid"] != null)
            {
                model.contractid = int.Parse(row["contractid"].ToString());
            }
            if (row["contractno"] != null)
            {
                model.contractno = row["contractno"].ToString();
            }
            if (row["no"] != null)
            {
                model.no = int.Parse(row["no"].ToString());
            }
            if (row["yifang"] != null)
            {
                model.yifang = row["yifang"].ToString();
            }
            if (row["code"] != null)
            {
                model.code = row["code"].ToString();
            }
            if (row["yifangcode"] != null)
            {
                model.yifangcode = row["yifangcode"].ToString();
            }

            if (row["signdate"] != null)
            {
                model.signdate = row["signdate"].ToString();
            }

            if (row["contracttype"] != null)
            {
                model.contracttype =int.Parse ( row["contracttype"].ToString());
            }

            if (row["contractdetailid"] != null)
            {
                model.contractdetailid =int.Parse ( row["contractdetailid"].ToString());
            }
            if (row["contractweight"] != null)
            {
                model.contractweight = decimal.Parse(row["contractweight"].ToString());
            }
            if (row["contractquantity"] != null)
            {
                model.contractquantity = int.Parse(row["contractquantity"].ToString());
            }
            if (row["getweight"] != null)
            {
                model.getweight = decimal.Parse(row["getweight"].ToString());
            }
            if (row["getquantity"] != null)
            {
                model.getquantity = int.Parse(row["getquantity"].ToString());
            }
            if (row["name"] != null)
            {
                model.name = row["name"].ToString();
            }
            if (row["id"] != null && row["id"].ToString() != "")
            {
                model.id = int.Parse(row["id"].ToString());
            }
            if (row["brand"] != null)
            {
                model.brand = row["brand"].ToString();
            }
            if (row["nature"] != null)
            {
                model.nature = row["nature"].ToString();
            }
            if (row["origin"] != null)
            {
                model.origin = row["origin"].ToString();
            }
            if (row["type"] != null)
            {
                model.type = row["type"].ToString();
            }
            if (row["techtype"] != null)
            {
                model.techtype = row["techtype"].ToString();
            }
            if (row["specification"] != null)
            {
                model.specification = row["specification"].ToString();
            }
            if (row["productdate"] != null)
            {
                model.productdate = row["productdate"].ToString();
            }
            if (row["shelflife"] != null && row["shelflife"].ToString() != "")
            {
                model.shelflife = int.Parse(row["shelflife"].ToString());
            }
            
            if (row["billofgoods"] != null && row["billofgoods"].ToString() != "")
            {
                model.billofgoods = row["billofgoods"].ToString();
            }

            if (row["shipno"] != null)
            {
                model.shipno = row["shipno"].ToString();
            }
            if (row["cornerno"] != null)
            {
                model.cornerno = row["cornerno"].ToString();
            }

            if (row["quote_protein"] != null && row["quote_protein"].ToString() != "")
            {
                model.quote_protein = decimal.Parse(row["quote_protein"].ToString());
            }
            if (row["quote_tvn"] != null && row["quote_tvn"].ToString() != "")
            {
                model.quote_tvn = decimal.Parse(row["quote_tvn"].ToString());
            }
            if (row["quote_graypart"] != null && row["quote_graypart"].ToString() != "")
            {
                model.quote_graypart = decimal.Parse(row["quote_graypart"].ToString());
            }
            if (row["quote_sandsalt"] != null && row["quote_sandsalt"].ToString() != "")
            {
                model.quote_sandsalt = decimal.Parse(row["quote_sandsalt"].ToString());
            }
            if (row["quote_amine"] != null && row["quote_amine"].ToString() != "")
            {
                model.quote_amine = decimal.Parse(row["quote_amine"].ToString());
            }
            if (row["quote_ffa"] != null && row["quote_ffa"].ToString() != "")
            {
                model.quote_ffa = decimal.Parse(row["quote_ffa"].ToString());
            }
            if (row["quote_fat"] != null && row["quote_fat"].ToString() != "")
            {
                model.quote_fat = decimal.Parse(row["quote_fat"].ToString());
            }
            if (row["quote_water"] != null && row["quote_water"].ToString() != "")
            {
                model.quote_water = decimal.Parse(row["quote_water"].ToString());
            }
            if (row["quote_sand"] != null && row["quote_sand"].ToString() != "")
            {
                model.quote_sand = decimal.Parse(row["quote_sand"].ToString());
            }
            if (row["sgs_protein"] != null && row["sgs_protein"].ToString() != "")
            {
                model.sgs_protein = decimal.Parse(row["sgs_protein"].ToString());
            }
            if (row["sgs_tvn"] != null && row["sgs_tvn"].ToString() != "")
            {
                model.sgs_tvn = decimal.Parse(row["sgs_tvn"].ToString());
            }
            if (row["sgs_graypart"] != null && row["sgs_graypart"].ToString() != "")
            {
                model.sgs_graypart = decimal.Parse(row["sgs_graypart"].ToString());
            }
            if (row["sgs_sandsalt"] != null && row["sgs_sandsalt"].ToString() != "")
            {
                model.sgs_sandsalt = decimal.Parse(row["sgs_sandsalt"].ToString());
            }
            if (row["sgs_amine"] != null && row["sgs_amine"].ToString() != "")
            {
                model.sgs_amine = decimal.Parse(row["sgs_amine"].ToString());
            }
            if (row["sgs_ffa"] != null && row["sgs_ffa"].ToString() != "")
            {
                model.sgs_ffa = decimal.Parse(row["sgs_ffa"].ToString());
            }
            if (row["sgs_fat"] != null && row["sgs_fat"].ToString() != "")
            {
                model.sgs_fat = decimal.Parse(row["sgs_fat"].ToString());
            }
            if (row["sgs_water"] != null && row["sgs_water"].ToString() != "")
            {
                model.sgs_water = decimal.Parse(row["sgs_water"].ToString());
            }
            if (row["sgs_sand"] != null && row["sgs_sand"].ToString() != "")
            {
                model.sgs_sand = decimal.Parse(row["sgs_sand"].ToString());
            }
            if (row["label_protein"] != null && row["label_protein"].ToString() != "")
            {
                model.label_protein = decimal.Parse(row["label_protein"].ToString());
            }
            if (row["label_tvn"] != null && row["label_tvn"].ToString() != "")
            {
                model.label_tvn = decimal.Parse(row["label_tvn"].ToString());
            }
            if (row["label_graypart"] != null && row["label_graypart"].ToString() != "")
            {
                model.label_graypart = decimal.Parse(row["label_graypart"].ToString());
            }
            if (row["label_sandsalt"] != null && row["label_sandsalt"].ToString() != "")
            {
                model.label_sandsalt = decimal.Parse(row["label_sandsalt"].ToString());
            }
            if (row["label_amine"] != null && row["label_amine"].ToString() != "")
            {
                model.label_amine = decimal.Parse(row["label_amine"].ToString());
            }
            if (row["label_ffa"] != null && row["label_ffa"].ToString() != "")
            {
                model.label_ffa = decimal.Parse(row["label_ffa"].ToString());
            }
            if (row["label_fat"] != null && row["label_fat"].ToString() != "")
            {
                model.label_fat = decimal.Parse(row["label_fat"].ToString());
            }
            if (row["labe_water"] != null && row["labe_water"].ToString() != "")
            {
                model.labe_water = decimal.Parse(row["labe_water"].ToString());
            }
            if (row["label_sand"] != null && row["label_sand"].ToString() != "")
            {
                model.label_sand = decimal.Parse(row["label_sand"].ToString());
            }
            if (row["label_lysine"] != null && row["label_lysine"].ToString() != "")
            {
                model.label_lysine = decimal.Parse(row["label_lysine"].ToString());
            }
            if (row["label_methionine"] != null && row["label_methionine"].ToString() != "")
            {
                model.label_methionine = decimal.Parse(row["label_methionine"].ToString());
            }
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

            return model;

        }

    }
}
