using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ProductConfirmDao
    {
      public DataSet GetConfirm(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.PlaceOfDelivery,a.confirmEexchangeRate,a.quotedollars,a.labe_water,a.quantity,a.id,a.code,a.name,a.brand,a.state,a.nature,a.origin,a.type,a.getinfotime,a.endinfotime,a.techtype,a.specification,a.productdate,a.shelflife,a.quality,a.manufacturers,a.factoryaddress,a.remark,a.weight,a.quality,a.remainweight,a.remainquantity,a.homemadeweight,a.homemadepackages,a.homemadecost,a.homemadeunitprice,a.price,a.arriveportdate,a.sailingschedule,a.billofgoods,a.agentifcompany,a.customsofcompany,a.quote_protein,a.quote_tvn,a.quote_graypart,a.quote_sandsalt,a.quote_amine,a.quote_ffa,a.quote_fat,a.quote_water,a.quote_sand,a.supplierid,a.suppliercode,a.supplier,a.linkmanid,a.linkmancode,a.linkman,a.latestquote,a.sgs_protein,a.sgs_tvn,a.sgs_graypart,a.sgs_sandsalt,a.sgs_amine,a.sgs_ffa,a.sgs_fat,a.sgs_water,a.sgs_sand,a.label_protein,a.label_tvn,a.label_graypart,a.label_sandsalt,a.label_amine,a.label_ffa,a.label_fat,a.label_sand,a.label_lysine,a.label_methionine,a.domestic_protein,a.domestic_tvn,a.domestic_graypart,a.domestic_sandsalt,a.domestic_sour,a.domestic_lysine,a.domestic_amine,a.domestic_aminototal,a.domestic_methionine,a.domestic_fat,ownercode,a.ownershortname,a.ownername,a.shipno,a.cornerno,a.tariffrate,a.samplingtime,a.warehouse,a.sgsweight,sgsquantity,a.goodsinfo,a.isdelete,state1,isdelete1,state2,isdelete2,state3,isdelete3,state4,isdelete4,state5,isdelete5,pack,port,a.quotedate,a.quoteweight,a.quotequantity,a.quotelife,a.quotermb,a.quotesuppliercode,a.quotesupplier,a.quotelinkmancode,a.quotelinkman,a.quoteproductyear,a.quoteproductdate,a.quotelife,a.quotesaildatefast,a.quotesaildatelate,a.confirmdate,a.confirmsgsweight,a.confirmsgsquantity,a.confirmdollars,a.confirmrmb,a.confirmagentcode,a.confirmagent,a.confirmWeight,a.confirmlinkmancode,a.confirmlinkman,a.confirmproductyear,a.confirmproductdate,a.confirmlife,a.confirmsaildate,a.createman as createmanX,a.createtime as createtimeX,a.modifyman as modifymanX,a.modifytime as modifytimeX,b.id quote_id from v_confirm  a  left join t_quote b on a.id=b.productid "); 
           
            if (false == string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where+" group by a.code  ");
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        

        public FishEntity.ProductConfirmVo DataRowToModel(DataRow row)
        {
           FishEntity.ProductConfirmVo model = new FishEntity.ProductConfirmVo();

            if (row != null)
            {
                #region product
                if (row["confirmdate"]!=null)
                {
                    model.confirmdate = row["confirmdate"].ToString();
                }
                if (row["Quote_id"] != null && row["Quote_id"].ToString() != "")
                {
                    model.Quote_id = int.Parse(row["Quote_id"].ToString());
                }
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
                if (row["state"] != null)
                {
                    model.state = row["state"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.state); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
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
                if (row["createtimeX"] != null && row["createtimeX"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtimeX"].ToString());
                }
                if (row["createmanX"] != null)
                {
                    model.createman = row["createmanX"].ToString();
                }
                if (row["modifytimeX"] != null && row["modifytimeX"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytimeX"].ToString());
                }
                if (row["modifymanX"] != null)
                {
                    model.modifyman = row["modifymanX"].ToString();
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                if (row["isdelete1"]!=null&&row["isdelete1"].ToString()!="")
                {
                    model.Isdelete1 =int.Parse( row["isdelete1"].ToString());
                }
                if (row["isdelete2"] != null && row["isdelete2"].ToString() != "")
                {
                    model.Isdelete2 = int.Parse(row["isdelete2"].ToString());
                }
                if (row["isdelete3"] != null && row["isdelete3"].ToString() != "")
                {
                    model.Isdelete3 = int.Parse(row["isdelete3"].ToString());
                }
                if (row["isdelete3"] != null && row["isdelete3"].ToString() != "")
                {
                    model.Isdelete3 = int.Parse(row["isdelete3"].ToString());
                }
                if (row["isdelete4"] != null && row["isdelete4"].ToString() != "")
                {
                    model.Isdelete4 = int.Parse(row["isdelete4"].ToString());
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
                if (row["port"] != null)
                {
                    model.port = row["port"].ToString();
                }

                #endregion


                #region Quote

                if (row["quotedate"] != null)
                {
                    model.quotedate = row["quotedate"].ToString();
                }
                if (row["PlaceOfDelivery"]!=null)
                {
                    model.PlaceOfDelivery=row["PlaceOfDelivery"].ToString();
                }
                if (row["quoteweight"] != null && row["quoteweight"].ToString() != "")
                {
                    model.quoteweight = decimal.Parse(row["quoteweight"].ToString());
                }
                if (row["quotequantity"] != null && row["quotequantity"].ToString() != "")
                {
                    model.quotequantity = int.Parse(row["quotequantity"].ToString());
                }
                if (row["quotedollars"] != null && row["quotedollars"].ToString() != "")
                {
                    model.quotedollars = decimal.Parse(row["quotedollars"].ToString());
                }
                if (row["quotermb"] != null && row["quotermb"].ToString() != "")
                {
                    model.quotermb = decimal.Parse(row["quotermb"].ToString());
                }
                if (row["quotesuppliercode"] != null)
                {
                    model.quotesuppliercode = row["quotesuppliercode"].ToString();
                }
                if (row["quotesupplier"] != null)
                {
                    model.quotesupplier = row["quotesupplier"].ToString();
                }
                if (row["quotelinkmancode"] != null)
                {
                    model.quotelinkmancode = row["quotelinkmancode"].ToString();
                }
                if (row["quotelinkman"] != null)
                {
                    model.quotelinkman = row["quotelinkman"].ToString();
                }
                if (row["quoteproductyear"] != null)
                {
                    model.quoteproductyear = row["quoteproductyear"].ToString();
                }
                if (row["quoteproductdate"] != null)
                {
                    model.quoteproductdate = row["quoteproductdate"].ToString();
                }
                if (row["quotelife"] != null)
                {
                    model.quotelife = row["quotelife"].ToString();
                }
                if (row["quotesaildatefast"] != null)
                {
                    model.quotesaildatefast = row["quotesaildatefast"].ToString();
                }
                if (row["quotesaildatelate"] != null)
                {
                    model.quotesaildatelate = row["quotesaildatelate"].ToString();
                }
                #endregion

                #region Confirm 
                if (row["confirmdate"] != null)
                {
                    model.confirmdate = row["confirmdate"].ToString();
                }
                if (row["confirmWeight"]!=null)
                {
                    model.confirmWeight = row["confirmWeight"].ToString();
                }
                if (row["confirmEexchangeRate"]!=null)
                {
                    model.confirmEexchangeRate = row["confirmEexchangeRate"].ToString();
                }
                if (row["confirmsgsweight"] != null && row["confirmsgsweight"].ToString() != "")
                {
                    model.confirmsgsweight = decimal.Parse(row["confirmsgsweight"].ToString());
                }
                if (row["confirmsgsquantity"] != null && row["confirmsgsquantity"].ToString() != "")
                {
                    model.confirmsgsquantity = int.Parse(row["confirmsgsquantity"].ToString());
                }
                if (row["confirmdollars"] != null && row["confirmdollars"].ToString() != "")
                {
                    model.confirmdollars = decimal.Parse(row["confirmdollars"].ToString());
                }
                if (row["confirmrmb"] != null && row["confirmrmb"].ToString() != "")
                {
                    model.confirmrmb = decimal.Parse(row["confirmrmb"].ToString());
                }
                if (row["confirmagentcode"] != null)
                {
                    model.confirmagentcode = row["confirmagentcode"].ToString();
                }
                if (row["confirmagent"] != null)
                {
                    model.confirmagent = row["confirmagent"].ToString();
                }
                if (row["confirmlinkmancode"] != null)
                {
                    model.confirmlinkmancode = row["confirmlinkmancode"].ToString();
                }
                if (row["confirmlinkman"] != null)
                {
                    model.confirmlinkman = row["confirmlinkman"].ToString();
                }
                if (row["confirmproductyear"] != null)
                {
                    model.confirmproductyear = row["confirmproductyear"].ToString();
                }
                if (row["confirmproductdate"] != null)
                {
                    model.confirmproductdate = row["confirmproductdate"].ToString();
                }
                if (row["confirmlife"] != null)
                {
                    model.confirmlife = row["confirmlife"].ToString();
                }
                if (row["confirmsaildate"] != null)
                {
                    model.confirmsaildate = row["confirmsaildate"].ToString();
                }
                //if (row["confirmshortname"] != null)
                //{
                //    model.confirmshortname = row["confirmshortname"].ToString();
                //}
                #endregion
            }

            return model;
        }
    
    }
}
