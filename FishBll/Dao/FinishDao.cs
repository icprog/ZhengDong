using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class FinishDao
    {
        public List<FishEntity.FinishVo> GetData(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from v_finish ");
            if (false ==string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }

            DataSet dsData=  MySqlHelper.Query(strSql.ToString());
            List<FishEntity.FinishVo> list = new List<FishEntity.FinishVo>();
            for (int i = 0; i < dsData.Tables[0].Rows.Count; i++)
            {
                FishEntity.FinishVo vo = DataRowToVo(dsData.Tables[0].Rows[i]);
                list.Add(vo);
            }
            return list;
        }
        public DataSet GetFinish(string where)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select a.id,a.code,a.name,a.brand,a.state,a.nature,a.origin,a.type,a.getinfotime,a.endinfotime,a.techtype,a.specification,a.productdate,a.shelflife,a.quality,a.manufacturers,a.factoryaddress,a.remark,a.weight,a.quantity,a.remainweight,a.remainquantity,a.homemadeweight,a.homemadepackages,a.homemadecost,a.homemadeunitprice,a.price,a.arriveportdate,a.sailingschedule,a.billofgoods,a.agentifcompany,a.customsofcompany,a.createtime,a.createman,a.modifytime,a.modifyman,a.quote_protein,a.quote_tvn,a.quote_graypart,a.quote_sandsalt,a.quote_amine,a.quote_ffa,a.quote_fat,a.quote_water,a.quote_sand,a.supplierid,a.suppliercode,a.supplier,a.linkmanid,a.linkmancode,a.linkman,a.latestquote,a.sgs_protein,a.sgs_tvn,a.sgs_graypart,a.sgs_sandsalt,a.sgs_amine,a.sgs_ffa,a.sgs_fat,a.sgs_water,a.sgs_sand,a.label_protein,a.label_tvn,a.label_graypart,a.label_sandsalt,a.label_amine,a.label_ffa,a.label_fat,a.labe_water,a.label_sand,a.label_lysine,a.label_methionine,a.domestic_protein,a.domestic_tvn,a.domestic_graypart,a.domestic_sandsalt,a.domestic_sour,a.domestic_lysine,a.domestic_amine,a.domestic_aminototal,a.domestic_methionine,a.domestic_fat,a.ownercode,a.ownershortname,a.ownername,a.shipno,a.cornerno,a.tariffrate,a.samplingtime,a.warehouse,a.sgsweight,a.sgsquantity,a.goodsinfo,a.isdelete,a.state1,a.isdelete1,a.state2,a.isdelete2,a.state3,a.isdelete3,a.state4,a.isdelete4,a.state5,a.isdelete5,a.pack,a.port,a.confirmsgsweight,a.confirmsaildate,a.saleremainweight,a.spotdate,a.spotweight,a.spotquantity,a.spotdollars,a.spotrmb,a.salermb,a.spotagentcode,a.spotagent,a.spotlinkmancode,a.spotlinkman,a.spotproductdate,a.spotproductyear,a.spotlife,a.spotstoragedate,a.saletradercode,a.saletrader,a.salelinkmancode,a.salelinkman,a.nature from v_spot a   ");
            //strSql.Append("select CODE,finishedtime,specification,finisheNumber,nature,brand,domestic_protein,domestic_tvn,domestic_ffa,domestic_sandsalt,domestic_sour,domestic_amine,domestic_fat,domestic_graypart,domestic_lysine,domestic_methionine,domestic_aminototal,label_protein,label_tvn,label_sandsalt,label_amine,label_ffa,label_fat,labe_water,label_sand,label_graypart,label_lysine,label_methionine,label_aminototal,spotlife,remark,sum(finisheWeight) as finisheWeight from(select * from v_chengpin UNION select *from v_cp) a ");
            strSql.Append("select *,sum(qiuhe)qiuhe from ( ");
            strSql.Append("select * from v_chengpinruku ");
            strSql.Append("UNION ALL ");
            strSql.Append("select *from v_chengpintuihuo ");
            strSql.Append("UNION ALL ");
            strSql.Append("select *from v_chengpinxiaoshou ");
            strSql.Append(") a ");

            if (false == string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where+ " group by code ORDER BY specification DESC , code ASC ");
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public FishEntity.ProductSpotVo DataRowToModel(DataRow row)
        {
            FishEntity.ProductSpotVo model = new FishEntity.ProductSpotVo();

            if (row != null)
            {
                #region product
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["code1"] != null)
                {
                    model.codeNum = row["code1"].ToString();
                }
                if (row["ckcode"] != null)
                {
                    model.codeNumContract = row["ckcode"].ToString();
                }
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["spotlife"] != null)
                {
                    model.spotlife = row["spotlife"].ToString();
                }
                if (row["finishedtime"]!=null)
                {
                    model.finishedtime = row["finishedtime"].ToString();
                }
                if (row["specification"] != null)
                {
                    model.specification = row["specification"].ToString();
                }
                if (row["tons"] != null && row["tons"].ToString()!="")
                {
                    model.finisheWeight =decimal.Parse( row["tons"].ToString());
                }
                if (row["qiuhe1"] != null && row["qiuhe1"].ToString() != "")
                {
                    model.shenyu = decimal.Parse(row["qiuhe1"].ToString());
                }
                if (row["finisheNumber"] != null)
                {
                    model.finisheNumber = row["finisheNumber"].ToString();
                }
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["domestic_ffa"] != null&& row["domestic_ffa"].ToString()!="")
                {
                    model.domestic_ffa =decimal.Parse( row["domestic_ffa"].ToString());
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
                if (row["label_aminototal"] != null && row["label_aminototal"].ToString() != "")
                {
                    model.label_aminototal = decimal.Parse(row["label_aminototal"].ToString());
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
                

                #endregion
            }

            return model;
        }
        public bool update(FishEntity.ProductEntity model,string names) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set  ");
            strSql.Append(names+ "=@isdelete  ");
            strSql.Append("  where code=@code ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@isdelete",model.isdelete),
                new MySqlParameter("@code",model.code)
            };
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameter);
            if (rows > 0)
            {
                return true;
            }   
            else
            {
                return false;
            }

        }
        public bool update(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set  ");
            strSql.Append(" Display=@Display  ");
            strSql.Append("  where code=@code ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Display",model.Display),
                new MySqlParameter("@code",model.code)
            };
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameter);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        private FishEntity.FinishVo DataRowToVo(DataRow row)
        {
            FishEntity.FinishVo model = new FishEntity.FinishVo();

            if (row != null)
            {
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

                #region out
                if (row["saleman"] != null)
                {
                    model.saleman = row["saleman"].ToString();
                }
                if (row["deliveryman"] != null)
                {
                    model.deliveryman = row["deliveryman"].ToString();
                }
                if (row["indate"] != null)
                {
                    model.indate = DateTime.Parse( row["indate"].ToString());
                }

                if (row["outdate"] != null)
                {
                    model.outdate = DateTime.Parse(row["outdate"].ToString());
                }
                if (row["companyname"] != null)
                {
                    model.companyname = row["companyname"].ToString();
                }
                
                #endregion 
            }
            return model;

        }


    }
}
