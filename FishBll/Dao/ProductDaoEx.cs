using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ProductDaoEx : ProductDao
    {
        public bool UpdateState(int productId, int state , int quantity , decimal weight)
        {
            //底层代码
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set state=@state , quantity = quantity + @quantity , weight = weight + @weight where id=@id and isdelete=0");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@state",MySqlDbType.VarChar ,45),
                    new MySqlParameter("@quantity",MySqlDbType.Int32,8) ,
                    new MySqlParameter("@weight",MySqlDbType.Decimal,8),
                    new MySqlParameter("@id",MySqlDbType.UInt32,8)
                                        };
            parameters[0].Value = state;
            parameters[1].Value = quantity;
            parameters[2].Value = weight;
            parameters[3].Value = productId;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        public bool UpdateHomemade(int productId, decimal weight, decimal cost ,int number)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set homemadeweight= homemadeweight+@weight, homemadecost = homemadecost+ @cost ,homemadepackages=homemadepackages+ @number where id=@id and isdelete=0");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@weight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@cost",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@number",MySqlDbType.Int32,8) ,
                    new MySqlParameter("@id",MySqlDbType.Int32,8)
                                        };
            parameters[0].Value = weight;
            parameters[1].Value = cost;
            parameters[2].Value = number;
            parameters[3].Value = productId;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        public bool UpdateRemainWeightQuantity(int productId, decimal weight, int quantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set remainweight= remainweight+@remainweight, remainquantity = remainquantity+ @remainquantity  where id=@id and isdelete=0");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@remainweight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@remainquantity",MySqlDbType.Int32 , 8),             
                    new MySqlParameter("@id",MySqlDbType.Int32,8)
                                        };
            parameters[0].Value = weight;
            parameters[1].Value = quantity;
            parameters[2].Value = productId;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }


        public bool UpdateHomemadeWeightQuantity(int productId, decimal weight, int quantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set homemadeweight= homemadeweight+@homemadeweight, homemadepackages = homemadepackages+ @homemadepackages  where id=@id and isdelete=0");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@homemadeweight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@homemadepackages",MySqlDbType.Int32 , 8),             
                    new MySqlParameter("@id",MySqlDbType.Int32,8)
                                        };
            parameters[0].Value = weight;
            parameters[1].Value = quantity;
            parameters[2].Value = productId;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        public bool UpdateHomemadeWeightQuantityCost(int productId, decimal weight, int quantity, decimal cost)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set homemadeweight= homemadeweight+@homemadeweight, ");
            strSql.Append(" homemadepackages = homemadepackages+ @homemadepackages ,");
            strSql.Append(" homemadecost= homemadecost+ @homemadecost where id=@id and isdelete=0");
            MySqlParameter[] parameters ={
                    new MySqlParameter("@homemadeweight",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@homemadepackages",MySqlDbType.Int32 , 8),      
                    new MySqlParameter("@homemadecost",MySqlDbType.Decimal,8),
                    new MySqlParameter("@id",MySqlDbType.Int32,8)
                                        };
            parameters[0].Value = weight;
            parameters[1].Value = quantity;
            parameters[2].Value = cost;
            parameters[3].Value = productId;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0 ? true : false;
        }

        	/// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from v_selfmake "); 
            if (string.IsNullOrEmpty(strWhere) == false)
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.ProductVo> DataTableToList(DataTable dt)
        {
            List<FishEntity.ProductVo> modelList = new List<FishEntity.ProductVo>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ProductVo model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = DataRowToModel(dt.Rows[n]) as FishEntity.ProductVo;
                    if (model != null)
                    {
                        DataRowToVo(model, dt.Rows[n] );
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        protected void DataRowToVo(FishEntity.ProductVo model, DataRow row)
        {
            if (row != null)
            {
                #region 旧
                //if (row["quotedate"] != null)
                //{
                //    model.quotedate = row["quotedate"].ToString();
                //}
                //if (row["quoteweight"] != null && row["quoteweight"].ToString() != "")
                //{
                //    model.quoteweight = decimal.Parse(row["quoteweight"].ToString());
                //}
                //if (row["quotequantity"] != null && row["quotequantity"].ToString() != "")
                //{
                //    model.quotequantity = int.Parse(row["quotequantity"].ToString());
                //}
                //if (row["quotedollars"] != null && row["quotedollars"].ToString() != "")
                //{
                //    model.quotedollars = decimal.Parse(row["quotedollars"].ToString());
                //}
                //if (row["quotermb"] != null && row["quotermb"].ToString() != "")
                //{
                //    model.quotermb = decimal.Parse(row["quotermb"].ToString());
                //}
                //if (row["quotesuppliercode"] != null)
                //{
                //    model.quotesuppliercode = row["quotesuppliercode"].ToString();
                //}
                //if (row["quotesupplier"] != null)
                //{
                //    model.quotesupplier = row["quotesupplier"].ToString();
                //}
                //if (row["quotelinkmancode"] != null)
                //{
                //    model.quotelinkmancode = row["quotelinkmancode"].ToString();
                //}
                //if (row["quotelinkman"] != null)
                //{
                //    model.quotelinkman = row["quotelinkman"].ToString();
                //}
                //if (row["quoteproductyear"] != null)
                //{
                //    model.quoteproductyear = row["quoteproductyear"].ToString();
                //}
                //if (row["quoteproductdate"] != null)
                //{
                //    model.quoteproductdate = row["quoteproductdate"].ToString();
                //}
                //if (row["quotelife"] != null)
                //{
                //    model.quotelife = row["quotelife"].ToString();
                //}
                //if (row["quotesaildatefast"] != null)
                //{
                //    model.quotesaildatefast = row["quotesaildatefast"].ToString();
                //}
                //if (row["quotesaildatelate"] != null)
                //{
                //    model.quotesaildatelate = row["quotesaildatelate"].ToString();
                //}
                //if (row["confirmdate"] != null)
                //{
                //    model.confirmdate = row["confirmdate"].ToString();
                //}
                //if (row["confirmsgsweight"] != null && row["confirmsgsweight"].ToString() != "")
                //{
                //    model.confirmsgsweight = decimal.Parse(row["confirmsgsweight"].ToString());
                //}
                //if (row["confirmsgsquantity"] != null && row["confirmsgsquantity"].ToString() != "")
                //{
                //    model.confirmsgsquantity = int.Parse(row["confirmsgsquantity"].ToString());
                //}
                //if (row["confirmdollars"] != null && row["confirmdollars"].ToString() != "")
                //{
                //    model.confirmdollars = decimal.Parse(row["confirmdollars"].ToString());
                //}
                //if (row["confirmrmb"] != null && row["confirmrmb"].ToString() != "")
                //{
                //    model.confirmrmb = decimal.Parse(row["confirmrmb"].ToString());
                //}
                //if (row["confirmagentcode"] != null)
                //{
                //    model.confirmagentcode = row["confirmagentcode"].ToString();
                //}
                //if (row["confirmagent"] != null)
                //{
                //    model.confirmagent = row["confirmagent"].ToString();
                //}
                //if (row["confirmlinkmancode"] != null)
                //{
                //    model.confirmlinkmancode = row["confirmlinkmancode"].ToString();
                //}
                //if (row["confirmlinkman"] != null)
                //{
                //    model.confirmlinkman = row["confirmlinkman"].ToString();
                //}
                //if (row["confirmproductyear"] != null)
                //{
                //    model.confirmproductyear = row["confirmproductyear"].ToString();
                //}
                //if (row["confirmproductdate"] != null)
                //{
                //    model.confirmproductdate = row["confirmproductdate"].ToString();
                //}
                //if (row["confirmlife"] != null)
                //{
                //    model.confirmlife = row["confirmlife"].ToString();
                //}
                //if (row["confirmsaildate"] != null)
                //{
                //    model.confirmsaildate = row["confirmsaildate"].ToString();
                //}
                //if (row["pack"] != null)
                //{
                //    model.Pack = row["pack"].ToString();
                //}
                //if (row["spotdate"] != null)
                //{
                //    model.spotdate = row["spotdate"].ToString();
                //}
                //if (row["spotweight"] != null && row["spotweight"].ToString() != "")
                //{
                //    model.spotweight = decimal.Parse(row["spotweight"].ToString());
                //}
                //if (row["spotquantity"] != null && row["spotquantity"].ToString() != "")
                //{
                //    model.spotquantity = int.Parse(row["spotquantity"].ToString());
                //}
                //if (row["spotdollars"] != null && row["spotdollars"].ToString() != "")
                //{
                //    model.spotdollars = decimal.Parse(row["spotdollars"].ToString());
                //}
                //if (row["spotrmb"] != null && row["spotrmb"].ToString() != "")
                //{
                //    model.spotrmb = decimal.Parse(row["spotrmb"].ToString());
                //}
                //if (row["spotagentcode"] != null)
                //{
                //    model.spotagentcode = row["spotagentcode"].ToString();
                //}
                //if (row["spotagent"] != null)
                //{
                //    model.spotagent = row["spotagent"].ToString();
                //}
                //if (row["spotlinkmancode"] != null)
                //{
                //    model.spotlinkmancode = row["spotlinkmancode"].ToString();
                //}
                //if (row["spotlinkman"] != null)
                //{
                //    model.spotlinkman = row["spotlinkman"].ToString();
                //}
                //if (row["spotproductdate"] != null)
                //{
                //    model.spotproductdate = row["spotproductdate"].ToString();
                //}
                //if (row["spotproductyear"] != null)
                //{
                //    model.spotproductyear = row["spotproductyear"].ToString();
                //}
                //if (row["spotlife"] != null)
                //{
                //    model.spotlife = row["spotlife"].ToString();
                //}
                //if (row["spotstoragedate"] != null)
                //{
                //    model.spotstoragedate = row["spotstoragedate"].ToString();
                //}
                //if (row["saledate"] != null)
                //{
                //    model.saledate = row["saledate"].ToString();
                //}
                //if (row["saleremainweight"] != null && row["saleremainweight"].ToString() != "")
                //{
                //    model.saleremainweight = decimal.Parse(row["saleremainweight"].ToString());
                //}
                //if (row["saleremainquantity"] != null && row["saleremainquantity"].ToString() != "")
                //{
                //    model.saleremainquantity = int.Parse(row["saleremainquantity"].ToString());
                //}
                //if (row["saledollars"] != null && row["saledollars"].ToString() != "")
                //{
                //    model.saledollars = decimal.Parse(row["saledollars"].ToString());
                //}
                //if (row["salermb"] != null && row["salermb"].ToString() != "")
                //{
                //    model.salermb = decimal.Parse(row["salermb"].ToString());
                //}
                //if (row["saletradercode"] != null)
                //{
                //    model.saletradercode = row["saletradercode"].ToString();
                //}
                //if (row["saletrader"] != null)
                //{
                //    model.saletrader = row["saletrader"].ToString();
                //}
                //if (row["salelinkmancode"] != null)
                //{
                //    model.salelinkmancode = row["salelinkmancode"].ToString();
                //}
                //if (row["salelinkman"] != null)
                //{
                //    model.salelinkman = row["salelinkman"].ToString();
                //}
                //if (row["saleoutdate"] != null)
                //{
                //    model.saleoutdate = row["saleoutdate"].ToString();
                //}
                //if (row["selfdate"] != null)
                //{
                //    model.selfdate = row["selfdate"].ToString();
                //}
                //if (row["selfstorageweight"] != null && row["selfstorageweight"].ToString() != "")
                //{
                //    model.selfstorageweight = decimal.Parse(row["selfstorageweight"].ToString());
                //}
                //if (row["selfstoragequantity"] != null && row["selfstoragequantity"].ToString() != "")
                //{
                //    model.selfstoragequantity = int.Parse(row["selfstoragequantity"].ToString());
                //}
                //if (row["selfdollars"] != null && row["selfdollars"].ToString() != "")
                //{
                //    model.selfdollars = decimal.Parse(row["selfdollars"].ToString());
                //}
                //if (row["selfrmb"] != null && row["selfrmb"].ToString() != "")
                //{
                //    model.selfrmb = decimal.Parse(row["selfrmb"].ToString());
                //}
                //if (row["selftradercode"] != null)
                //{
                //    model.selftradercode = row["selftradercode"].ToString();
                //}
                //if (row["selftrader"] != null)
                //{
                //    model.selftrader = row["selftrader"].ToString();
                //}
                //if (row["selflinkmancode"] != null)
                //{
                //    model.selflinkmancode = row["selflinkmancode"].ToString();
                //}
                //if (row["selflinkman"] != null)
                //{
                //    model.selflinkman = row["selflinkman"].ToString();
                //}
                //if (row["selffinishproduct"] != null)
                //{
                //    model.selffinishproduct = row["selffinishproduct"].ToString();
                //}
                //if (row["selfstoragedate"] != null)
                //{
                //    model.selfstoragedate = row["selfstoragedate"].ToString();
                //}
                #endregion 
                #region product
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["name"] != null)
                {
                    model.name = row["name"].ToString();
                }
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }
                if (row["state4"] != null)
                {
                    model.State4 = row["state4"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.State4); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
                }
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["port"] != null)
                {
                    model.port = row["port"].ToString();
                }
                if (row["origin"] != null)
                {
                    model.origin = row["origin"].ToString();
                }
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["getinfotime"] != null && row["getinfotime"].ToString() != "")
                {
                    model.getinfotime = DateTime.Parse(row["getinfotime"].ToString());
                }
                if (row["endinfotime"] != null && row["endinfotime"].ToString() != "")
                {
                    model.endinfotime = DateTime.Parse(row["endinfotime"].ToString());
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
                if (row["quality"] != null)
                {
                    model.quality = row["quality"].ToString();
                }
                if (row["manufacturers"] != null)
                {
                    model.manufacturers = row["manufacturers"].ToString();
                }
                if (row["factoryaddress"] != null)
                {
                    model.factoryaddress = row["factoryaddress"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["weight"] != null && row["weight"].ToString() != "")
                {
                    model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = int.Parse(row["quantity"].ToString());
                }
                if (row["remainweight"] != null && row["remainweight"].ToString() != "")
                {
                    model.remainweight = decimal.Parse(row["remainweight"].ToString());
                }
                if (row["remainquantity"] != null && row["remainquantity"].ToString() != "")
                {
                    model.remainquantity = int.Parse(row["remainquantity"].ToString());
                }
                if (row["homemadeweight"] != null && row["homemadeweight"].ToString() != "")
                {
                    model.homemadeweight = decimal.Parse(row["homemadeweight"].ToString());
                }
                if (row["homemadepackages"] != null && row["homemadepackages"].ToString() != "")
                {
                    model.homemadepackages = int.Parse(row["homemadepackages"].ToString());
                }
                if (row["homemadecost"] != null && row["homemadecost"].ToString() != "")
                {
                    model.homemadecost = decimal.Parse(row["homemadecost"].ToString());
                }
                if (row["homemadeunitprice"] != null && row["homemadeunitprice"].ToString() != "")
                {
                    model.homemadeunitprice = decimal.Parse(row["homemadeunitprice"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["arriveportdate"] != null && row["arriveportdate"].ToString() != "")
                {
                    model.arriveportdate = row["arriveportdate"].ToString();
                }
                if (row["sailingschedule"] != null)
                {
                    model.sailingschedule = row["sailingschedule"].ToString();
                }
                if (row["ownerCode"] != null)
                {
                    model.ownerCode = row["ownerCode"].ToString();
                }
                if (row["ownershortname"] != null)
                {
                    model.ownershortname = row["ownershortname"].ToString();
                }
                if (row["ownername"] != null)
                {
                    model.ownername = row["ownername"].ToString();
                }
                if (row["billofgoods"] != null)
                {
                    model.billofgoods = row["billofgoods"].ToString();
                }
                if (row["agentifcompany"] != null)
                {
                    model.agentifcompany = row["agentifcompany"].ToString();
                }
                if (row["customsofcompany"] != null)
                {
                    model.customsofcompany = row["customsofcompany"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["modifyman"] != null)
                {
                    model.modifyman = row["modifyman"].ToString();
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                if (row["suppliercode"] != null)
                {
                    model.suppliercode = row["suppliercode"].ToString();
                }
                if (row["supplier"] != null)
                {
                    model.supplier = row["supplier"].ToString();
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

                if (row["supplierid"] != null && row["supplierid"].ToString() != "")
                {
                    model.supplierid = int.Parse(row["supplierid"].ToString());
                }
                if (row["linkmanid"] != null && row["linkmanid"].ToString() != "")
                {
                    model.linkmanid = int.Parse(row["linkmanid"].ToString());
                }
                if (row["linkmancode"] != null)
                {
                    model.linkmancode = row["linkmancode"].ToString();
                }
                if (row["linkman"] != null)
                {
                    model.linkman = row["linkman"].ToString();
                }
                if (row["latestquote"] != null && row["latestquote"].ToString() != "")
                {
                    model.latestquote = decimal.Parse(row["latestquote"].ToString());
                }

                if (row["goodsinfo"] != null)
                {
                    model.goodsinfo = row["goodsinfo"].ToString();
                }
                if (row["shipno"] != null)
                {
                    model.shipno = row["shipno"].ToString();
                }
                if (row["cornerno"] != null)
                {
                    model.cornerno = row["cornerno"].ToString();
                }
                if (row["tariffrate"] != null && row["tariffrate"].ToString() != "")
                {
                    model.tariffrate = decimal.Parse(row["tariffrate"].ToString());
                }
                if (row["samplingtime"] != null)
                {
                    model.samplingtime = row["samplingtime"].ToString();
                }
                if (row["warehouse"] != null)
                {
                    model.warehouse = row["warehouse"].ToString();
                }
                if (row["sgsweight"] != null && row["sgsweight"].ToString() != "")
                {
                    model.sgsweight = decimal.Parse(row["sgsweight"].ToString());
                }
                if (row["sgsquantity"] != null && row["sgsquantity"].ToString() != "")
                {
                    model.sgsquantity = int.Parse(row["sgsquantity"].ToString());
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

                #endregion


                #region 自制

                if (row["salermb"] != null && row["salermb"].ToString() != "")
                {
                    model.salermb = decimal.Parse(row["salermb"].ToString());
                }
                if (row["selfstorageweight"] != null && row["selfstorageweight"].ToString() != "")
                {
                    model.selfstorageweight = decimal.Parse(row["selfstorageweight"].ToString());
                }
                if (row["selfstoragequantity"] != null && row["selfstoragequantity"].ToString() != "")
                {
                    model.selfstoragequantity = int.Parse(row["selfstoragequantity"].ToString());
                }

                if (row["selfrmb"] != null && row["selfrmb"].ToString() != "")
                {
                    model.selfrmb = decimal.Parse(row["selfrmb"].ToString());
                }


                if (row["selfstoragedate"] != null)
                {
                    model.selfstoragedate = row["selfstoragedate"].ToString();
                }

                #endregion
            }
        }


        public bool UpdateFoodOutInfo(FishEntity.FoodOutDetailEntityVO model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_product set ");
            strSql.Append("domestic_protein=@domestic_protein,");
            strSql.Append("domestic_tvn=@domestic_tvn,");
            strSql.Append("domestic_graypart=@domestic_graypart,");
            strSql.Append("domestic_sandsalt=@domestic_sandsalt,");
            strSql.Append("domestic_sour=@domestic_sour,");
            strSql.Append("domestic_lysine=@domestic_lysine,");
            strSql.Append("domestic_methionine=@domestic_methionine,");
            strSql.Append("domestic_amine=@domestic_amine,");
            strSql.Append("domestic_aminototal=@domestic_aminototal,");
            strSql.Append("domestic_fat=@domestic_fat,");

            strSql.Append("shipno=@shipno,");
            strSql.Append("billofgoods=@billofgoods,");
            strSql.Append("remark=@remark");

            strSql.Append(" where id=@id");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_tvn", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_amine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_aminototal", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_fat", MySqlDbType.Decimal,6),                    					
                    new MySqlParameter("@shipno", MySqlDbType.VarChar,45),
                  	new MySqlParameter("@billofgoods", MySqlDbType.VarChar,45),
                 	new MySqlParameter("@remark", MySqlDbType.VarChar,500),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)
                                          };

            parameters[0].Value = model.domestic_protein;
            parameters[1].Value = model.domestic_tvn;
            parameters[2].Value = model.domestic_graypart;
            parameters[3].Value = model.domestic_sandsalt;
            parameters[4].Value = model.domestic_sour;
            parameters[5].Value = model.domestic_lysine;
            parameters[6].Value = model.domestic_methionine;
            parameters[7].Value = model.domestic_amine;
            parameters[8].Value = model.domestic_aminototal;
            parameters[9].Value = model.domestic_fat;

            parameters[10].Value = model.shipno;
            parameters[11].Value = model.billofgoods;
            parameters[12].Value = model.remark;

            parameters[13].Value = model.productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateCheckRecord(FishEntity.CheckRecordEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_product set ");
            strSql.Append("domestic_protein=@domestic_protein,");
            strSql.Append("domestic_tvn=@domestic_tvn,");
            strSql.Append("domestic_graypart=@domestic_graypart,");
            strSql.Append("domestic_sandsalt=@domestic_sandsalt,");
            strSql.Append("domestic_sour=@domestic_sour,");
            strSql.Append("domestic_lysine=@domestic_lysine,");
            strSql.Append("domestic_methionine=@domestic_methionine,");
            strSql.Append("domestic_amine=@domestic_amine,");
            strSql.Append("domestic_aminototal=@domestic_aminototal,");
            strSql.Append("domestic_fat=@domestic_fat,");
            strSql.Append("samplingtime=@samplingtime");

            strSql.Append(" where id=@id");

            MySqlParameter[] parameters = {
                    new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_tvn", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_amine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_aminototal", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_fat", MySqlDbType.Decimal,6),                    					
                    new MySqlParameter("@samplingtime", MySqlDbType.VarChar,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = model.regularindex1;
            parameters[1].Value = model.regularindex2;
            parameters[2].Value = model.regularindex4;
            parameters[3].Value = model.regularindex6;
            parameters[4].Value = model.regularindex5;
            parameters[5].Value = model.aminoindex14;
            parameters[6].Value = model.aminoindex9;
            parameters[7].Value = model.regularindex3;
            parameters[8].Value = model.aminoindex19;
            parameters[9].Value = model.regularindex8;
            parameters[10].Value = model.checkdate;
            parameters[11].Value = model.productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
