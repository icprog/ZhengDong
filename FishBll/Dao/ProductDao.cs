using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ProductDao
    {
        public ProductDao()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_product");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_product");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar ,45)
            };
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        public bool upde(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set state4=5");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
            new MySqlParameter("@code", MySqlDbType.VarChar, 45) };
            parameters[0].Value = model.code;
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
        /// <summary>
        /// 增加一条数据
        /// </summary>////billofgoods
        public int Add(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_product(");
            strSql.Append("code,name,brand,state,nature,origin,type,getinfotime,endinfotime,techtype,specification,productdate,shelflife,quality,manufacturers,factoryaddress,remark,weight,quantity,remainweight,remainquantity,homemadeweight,homemadepackages,homemadecost,homemadeunitprice,price,arriveportdate,sailingschedule,ownerCode,ownershortname,ownername,billofgoods,agentifcompany,customsofcompany,createtime,createman,modifytime,modifyman,isdelete,suppliercode,supplier,quote_protein,quote_tvn,quote_graypart,quote_sandsalt,quote_amine,quote_ffa,quote_fat,quote_water,quote_sand,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa,sgs_fat,sgs_water,sgs_sand,label_protein,label_tvn,label_graypart,label_sandsalt,label_amine,label_ffa,label_fat,labe_water,label_sand,label_lysine,label_methionine,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine,supplierid,linkmanid,linkmancode,linkman,latestquote,goodsinfo,shipno,cornerno,tariffrate,samplingtime,warehouse,sgsweight,sgsquantity,domestic_amine,domestic_aminototal,domestic_fat,state1,state2,state3,state4,state5,isdelete1,isdelete2,isdelete3,isdelete4,isdelete5,pack,port,label_aminototal,domestic_ffa,domestic_sand,domestic_water,FishMealState,shrimpshell,chromaticberration,smell,blackspot,Display)");
            strSql.Append(" values (");
            strSql.Append("@code,@name,@brand,@state,@nature,@origin,@type,@getinfotime,@endinfotime,@techtype,@specification,@productdate,@shelflife,@quality,@manufacturers,@factoryaddress,@remark,@weight,@quantity,@remainweight,@remainquantity,@homemadeweight,@homemadepackages,@homemadecost,@homemadeunitprice,@price,@arriveportdate,@sailingschedule,@ownerCode,@ownershortname,@ownername,@billofgoods,@agentifcompany,@customsofcompany,@createtime,@createman,@modifytime,@modifyman,@isdelete,@suppliercode,@supplier,@quote_protein,@quote_tvn,@quote_graypart,@quote_sandsalt,@quote_amine,@quote_ffa,@quote_fat,@quote_water,@quote_sand,@sgs_protein,@sgs_tvn,@sgs_graypart,@sgs_sandsalt,@sgs_amine,@sgs_ffa,@sgs_fat,@sgs_water,@sgs_sand,@label_protein,@label_tvn,@label_graypart,@label_sandsalt,@label_amine,@label_ffa,@label_fat,@labe_water,@label_sand,@label_lysine,@label_methionine,@domestic_protein,@domestic_tvn,@domestic_graypart,@domestic_sandsalt,@domestic_sour,@domestic_lysine,@domestic_methionine,@supplierid,@linkmanid,@linkmancode,@linkman,@latestquote,@goodsinfo,@shipno,@cornerno,@tariffrate,@samplingtime,@warehouse,@sgsweight,@sgsquantity,@domestic_amine,@domestic_aminototal,@domestic_fat,@state1,@state2,@state3,@state4,@state5,@isdelete1,@isdelete2,@isdelete3,@isdelete4,@isdelete5,@pack,@port,@label_aminototal,@domestic_ffa,@domestic_sand,@domestic_water,@FishMealState,@shrimpshell,@chromaticberration,@smell,@blackspot,@Display );");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@state", MySqlDbType.VarChar,45),
                    new MySqlParameter("@nature", MySqlDbType.VarChar,45),
                    new MySqlParameter("@origin", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type", MySqlDbType.VarChar,45),
                    new MySqlParameter("@getinfotime", MySqlDbType.Timestamp),
                    new MySqlParameter("@endinfotime", MySqlDbType.Timestamp),
                    new MySqlParameter("@techtype", MySqlDbType.VarChar,45),
                    new MySqlParameter("@specification", MySqlDbType.VarChar,45),
                    new MySqlParameter("@productdate", MySqlDbType.VarChar,100),
                    new MySqlParameter("@shelflife", MySqlDbType.Decimal),
                    new MySqlParameter("@quality", MySqlDbType.VarChar,45),
                    new MySqlParameter("@manufacturers", MySqlDbType.VarChar,100),
                    new MySqlParameter("@factoryaddress", MySqlDbType.VarChar,500),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,500),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,12),
                    new MySqlParameter("@quantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@remainweight", MySqlDbType.Decimal,12),
                    new MySqlParameter("@remainquantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@homemadeweight", MySqlDbType.Decimal,12),
                    new MySqlParameter("@homemadepackages", MySqlDbType.Int32,11),
                    new MySqlParameter("@homemadecost", MySqlDbType.Decimal,12),
                    new MySqlParameter("@homemadeunitprice", MySqlDbType.Decimal,12),
                    new MySqlParameter("@price", MySqlDbType.Decimal,12),
                    new MySqlParameter("@arriveportdate", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@sailingschedule", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ownerCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ownershortname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ownername", MySqlDbType.VarChar,100),
                    new MySqlParameter("@billofgoods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@agentifcompany", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customsofcompany", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,50),
                    new MySqlParameter("@isdelete", MySqlDbType.Int16,4),
                    new MySqlParameter("@suppliercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@supplier", MySqlDbType.VarChar,100),
                    new MySqlParameter("@quote_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quote_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_amine", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quote_ffa", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_water", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_sand", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@sgs_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_amine", MySqlDbType.Decimal,8),
                    new MySqlParameter("@sgs_ffa", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_fat",MySqlDbType .Decimal ,6),
                    new MySqlParameter("@sgs_water", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_sand", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@label_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_amine", MySqlDbType.Decimal,8),
                    new MySqlParameter("@label_ffa", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@labe_water", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_sand", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_lysine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_methionine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@supplierid",MySqlDbType.Int32 , 8),
                    new MySqlParameter("@linkmanid",MySqlDbType.Int32,8),
                    new MySqlParameter("@linkmancode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@linkman",MySqlDbType.VarChar,45) ,
                    new MySqlParameter("@latestquote",MySqlDbType.Decimal , 8),
                    new MySqlParameter("@goodsinfo", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipno", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cornerno", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tariffrate", MySqlDbType.Decimal,8),
                    new MySqlParameter("@samplingtime", MySqlDbType.VarChar,45),
                    new MySqlParameter("@warehouse", MySqlDbType.VarChar,256),
                    new MySqlParameter("@sgsweight", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgsquantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@domestic_amine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_aminototal", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@state1",MySqlDbType.VarChar,45),
                    new MySqlParameter("@state2",MySqlDbType.VarChar,45),
                    new MySqlParameter("@state3",MySqlDbType.VarChar,45),
                    new MySqlParameter("@state4",MySqlDbType.VarChar,45),
                    new MySqlParameter("@state5",MySqlDbType.VarChar,45),
                    new MySqlParameter("@isdelete1", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete2", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete3", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete4", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete5", MySqlDbType.Int16,4),
                    new MySqlParameter("@pack",MySqlDbType.VarChar,20),
                    new MySqlParameter("@port",MySqlDbType.VarChar,50),
                    new MySqlParameter("@label_aminototal",MySqlDbType.Decimal,45),
                    new MySqlParameter("@domestic_ffa",MySqlDbType.Decimal,45),
                    new MySqlParameter("@domestic_sand",MySqlDbType.Decimal,45),
                    new MySqlParameter("@domestic_water",MySqlDbType.Decimal,45),

                    new MySqlParameter("@FishMealState",MySqlDbType.VarChar,45),
                    new MySqlParameter("@shrimpshell",MySqlDbType.VarChar,45),
                    new MySqlParameter("@chromaticberration",MySqlDbType.VarChar,45),
                    new MySqlParameter("@smell",MySqlDbType.VarChar,45),
                    new MySqlParameter("@blackspot",MySqlDbType.VarChar,45),

                    new MySqlParameter("@Display",MySqlDbType.Int32,45)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.brand;
            parameters[3].Value = model.state;
            parameters[4].Value = model.nature;
            parameters[5].Value = model.origin;
            parameters[6].Value = model.type;
            parameters[7].Value = model.getinfotime;
            parameters[8].Value = model.endinfotime;
            parameters[9].Value = model.techtype;
            parameters[10].Value = model.specification;
            parameters[11].Value = model.productdate;
            parameters[12].Value = model.shelflife;
            parameters[13].Value = model.quality;
            parameters[14].Value = model.manufacturers;
            parameters[15].Value = model.factoryaddress;
            parameters[16].Value = model.remark;
            parameters[17].Value = model.weight;
            parameters[18].Value = model.quantity;
            parameters[19].Value = model.remainweight;
            parameters[20].Value = model.remainquantity;
            parameters[21].Value = model.homemadeweight;
            parameters[22].Value = model.homemadepackages;
            parameters[23].Value = model.homemadecost;
            parameters[24].Value = model.homemadeunitprice;
            parameters[25].Value = model.price;
            parameters[26].Value = model.arriveportdate;
            parameters[27].Value = model.sailingschedule;
            parameters[28].Value = model.ownerCode;
            parameters[29].Value = model.ownershortname;
            parameters[30].Value = model.ownername;
            parameters[31].Value = model.billofgoods;
            parameters[32].Value = model.agentifcompany;
            parameters[33].Value = model.customsofcompany;
            parameters[34].Value = model.createtime;
            parameters[35].Value = model.createman;
            parameters[36].Value = model.modifytime;
            parameters[37].Value = model.modifyman;
            parameters[38].Value = model.isdelete;
            parameters[39].Value = model.suppliercode;
            parameters[40].Value = model.supplier;
            parameters[41].Value = model.quote_protein;
            parameters[42].Value = model.quote_tvn;
            parameters[43].Value = model.quote_graypart;
            parameters[44].Value = model.quote_sandsalt;
            parameters[45].Value = model.quote_amine;
            parameters[46].Value = model.quote_ffa;
            parameters[47].Value = model.quote_fat;
            parameters[48].Value = model.quote_water;
            parameters[49].Value = model.quote_sand;
            parameters[50].Value = model.sgs_protein;
            parameters[51].Value = model.sgs_tvn;
            parameters[52].Value = model.sgs_graypart;
            parameters[53].Value = model.sgs_sandsalt;
            parameters[54].Value = model.sgs_amine;
            parameters[55].Value = model.sgs_ffa;
            parameters[56].Value = model.sgs_fat;
            parameters[57].Value = model.sgs_water;
            parameters[58].Value = model.sgs_sand;
            parameters[59].Value = model.label_protein;
            parameters[60].Value = model.label_tvn;
            parameters[61].Value = model.label_graypart;
            parameters[62].Value = model.label_sandsalt;
            parameters[63].Value = model.label_amine;
            parameters[64].Value = model.label_ffa;
            parameters[65].Value = model.label_fat;
            parameters[66].Value = model.labe_water;
            parameters[67].Value = model.label_sand;
            parameters[68].Value = model.label_lysine;
            parameters[69].Value = model.label_methionine;
            parameters[70].Value = model.domestic_protein;
            parameters[71].Value = model.domestic_tvn;
            parameters[72].Value = model.domestic_graypart;
            parameters[73].Value = model.domestic_sandsalt;
            parameters[74].Value = model.domestic_sour;
            parameters[75].Value = model.domestic_lysine;
            parameters[76].Value = model.domestic_methionine;
            parameters[77].Value = model.supplierid;
            parameters[78].Value = model.linkmanid;
            parameters[79].Value = model.linkmancode;
            parameters[80].Value = model.linkman;
            parameters[81].Value = model.latestquote;

            parameters[82].Value = model.goodsinfo;
            parameters[83].Value = model.shipno;
            parameters[84].Value = model.cornerno;
            parameters[85].Value = model.tariffrate;
            parameters[86].Value = model.samplingtime;
            parameters[87].Value = model.warehouse;
            parameters[88].Value = model.sgsweight;
            parameters[89].Value = model.sgsquantity;
            parameters[90].Value = model.domestic_amine;
            parameters[91].Value = model.domestic_aminototal;
            parameters[92].Value = model.domestic_fat;
            parameters[93].Value = model.State1;
            parameters[94].Value = model.State2;
            parameters[95].Value = model.State3;
            parameters[96].Value = model.State4;
            parameters[97].Value = model.State5;
            parameters[98].Value = model.Isdelete1;
            parameters[99].Value = model.Isdelete2;
            parameters[100].Value = model.Isdelete3;
            parameters[101].Value = model.Isdelete4;
            parameters[102].Value = model.Isdelete5;
            parameters[103].Value = model.Pack;
            parameters[104].Value = model.port;

            parameters[105].Value = model.label_aminototal;
            parameters[106].Value = model.domestic_ffa;
            parameters[107].Value = model.domestic_sand;
            parameters[108].Value = model.domestic_water;

            parameters[109].Value = model.FishMealState;
            parameters[110].Value = model.shrimpshell;
            parameters[111].Value = model.chromaticberration;
            parameters[112].Value = model.smell;
            parameters[113].Value = model.blackspot;

            parameters[114].Value = model.Display;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        public int Entry_Add(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_product(code,specification,nature,brand,type,quote_protein,quote_tvn,quote_sand,quote_sandsalt,quote_amine,quote_ffa,quote_fat,quote_water,createtime,createman,modifytime,modifyman)");
            strSql.Append("values(@code,@specification,@nature,@brand,@type,@quote_protein,@quote_tvn,@quote_sand,@quote_sandsalt,@quote_amine,@quote_ffa,@quote_fat,@quote_water,@createtime,@createman,@modifytime,@modifyman);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code", MySqlDbType.VarChar,45),
                new MySqlParameter("@specification",MySqlDbType.VarChar,45),
                new MySqlParameter("@nature",MySqlDbType.VarChar,45),
                new MySqlParameter("@brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@type",MySqlDbType.VarChar,45),
                new MySqlParameter("@quote_protein",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_tvn",MySqlDbType.Decimal,8),
                new MySqlParameter("@quote_sand",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_sandsalt",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_amine",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_ffa",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_fat",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_water",MySqlDbType.Decimal,6),
                new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman", MySqlDbType.VarChar,50),
                new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                new MySqlParameter("@createman", MySqlDbType.VarChar,45),
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.specification;
            parameters[2].Value = model.nature;
            parameters[3].Value = model.brand;
            parameters[4].Value = model.type;
            parameters[5].Value = model.quote_protein;
            parameters[6].Value = model.quote_tvn;
            parameters[7].Value = model.quote_sand;
            parameters[8].Value = model.quote_sandsalt;
            parameters[9].Value = model.quote_amine;
            parameters[10].Value = model.quote_ffa;
            parameters[11].Value = model.quote_fat;
            parameters[12].Value = model.quote_water;
            parameters[13].Value = model.modifytime;
            parameters[14].Value = model.modifytime;
            parameters[15].Value = model.createtime;
            parameters[16].Value = model.createman;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>///
        public bool Update(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set ");
            strSql.Append("code=@code,");
            strSql.Append("name=@name,");
            strSql.Append("brand=@brand,");
            strSql.Append("state=@state,");
            strSql.Append("nature=@nature,");
            strSql.Append("origin=@origin,");
            strSql.Append("type=@type,");
            strSql.Append("techtype=@techtype,");
            strSql.Append("specification=@specification,");
            strSql.Append("quality=@quality,");
            strSql.Append("manufacturers=@manufacturers,");
            strSql.Append("factoryaddress=@factoryaddress,");
            strSql.Append("remark=@remark,");
            strSql.Append("weight=@weight,");
            strSql.Append("quantity=@quantity,");
            //strSql.Append("remainweight=@remainweight,");
            //strSql.Append("remainquantity=@remainquantity,");
            //strSql.Append("homemadeweight=@homemadeweight,");
            //strSql.Append("homemadepackages=@homemadepackages,");
            //strSql.Append("homemadecost=@homemadecost,");
            //strSql.Append("homemadeunitprice=@homemadeunitprice,");
            strSql.Append("price=@price,");
            strSql.Append("sailingschedule=@sailingschedule,");
            strSql.Append("ownerCode=@ownerCode,");
            strSql.Append("ownershortname=@ownershortname,");
            strSql.Append("ownername=@ownername,");
            strSql.Append("billofgoods=@billofgoods,");
            strSql.Append("agentifcompany=@agentifcompany,");
            strSql.Append("customsofcompany=@customsofcompany,");
            //strSql.Append("createman=@createman,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("isdelete=@isdelete,");
            strSql.Append("suppliercode=@suppliercode,");
            strSql.Append("supplier=@supplier,");
            strSql.Append("quote_protein=@quote_protein,");
            strSql.Append("quote_tvn=@quote_tvn,");
            strSql.Append("quote_graypart=@quote_graypart,");
            strSql.Append("quote_sandsalt=@quote_sandsalt,");
            strSql.Append("quote_amine=@quote_amine,");
            strSql.Append("quote_ffa=@quote_ffa,");
            strSql.Append("quote_fat=@quote_fat,");
            strSql.Append("quote_water=@quote_water,");
            strSql.Append("quote_sand=@quote_sand,");
            strSql.Append("sgs_protein=@sgs_protein,");
            strSql.Append("sgs_tvn=@sgs_tvn,");
            strSql.Append("sgs_graypart=@sgs_graypart,");
            strSql.Append("sgs_sandsalt=@sgs_sandsalt,");
            strSql.Append("sgs_amine=@sgs_amine,");
            strSql.Append("sgs_ffa=@sgs_ffa,");
            strSql.Append("sgs_fat=@sgs_fat,");
            strSql.Append("sgs_water=@sgs_water,");
            strSql.Append("sgs_sand=@sgs_sand,");
            strSql.Append("label_protein=@label_protein,");
            strSql.Append("label_tvn=@label_tvn,");
            strSql.Append("label_graypart=@label_graypart,");
            strSql.Append("label_sandsalt=@label_sandsalt,");
            strSql.Append("label_amine=@label_amine,");
            strSql.Append("label_ffa=@label_ffa,");
            strSql.Append("label_fat=@label_fat,");
            strSql.Append("labe_water=@labe_water,");
            strSql.Append("label_sand=@label_sand,");
            strSql.Append("label_lysine=@label_lysine,");
            strSql.Append("label_methionine=@label_methionine,");
            strSql.Append("domestic_protein=@domestic_protein,");
            strSql.Append("domestic_tvn=@domestic_tvn,");
            strSql.Append("domestic_graypart=@domestic_graypart,");
            strSql.Append("domestic_sandsalt=@domestic_sandsalt,");
            strSql.Append("domestic_sour=@domestic_sour,");
            strSql.Append("domestic_lysine=@domestic_lysine,");
            strSql.Append("domestic_methionine=@domestic_methionine,");
            strSql.Append("arriveportdate=@arriveportdate,");
            strSql.Append("productdate=@productdate,");
            strSql.Append("shelflife=@shelflife,");
            strSql.Append("getinfotime=@getinfotime,");
            strSql.Append("endinfotime=@endinfotime,");
            strSql.Append("supplierid=@supplierid,");
            strSql.Append("linkmanid=@linkmanid,");
            strSql.Append("linkmancode=@linkmancode,");
            strSql.Append("linkman=@linkman,");
            strSql.Append("latestquote=@latestquote,");

            strSql.Append("goodsinfo=@goodsinfo,");
            strSql.Append("shipno=@shipno,");
            strSql.Append("cornerno=@cornerno,");
            strSql.Append("tariffrate=@tariffrate,");
            strSql.Append("samplingtime=@samplingtime,");
            strSql.Append("warehouse=@warehouse,");
            strSql.Append("sgsweight=@sgsweight,");
            strSql.Append("sgsquantity=@sgsquantity,");
            strSql.Append("domestic_amine=@domestic_amine,");
            strSql.Append("domestic_aminototal=@domestic_aminototal,");
            strSql.Append("domestic_fat=@domestic_fat,");
            strSql.Append("state1=@state1,");
            strSql.Append("state2=@state2,");
            strSql.Append("state3=@state3,");
            strSql.Append("state4=@state4,");
            strSql.Append("state5=@state5,");
            strSql.Append("isdelete1=@isdelete1,");
            strSql.Append("isdelete2=@isdelete2,");
            strSql.Append("isdelete3=@isdelete3,");
            strSql.Append("isdelete4=@isdelete4,");
            strSql.Append("isdelete5=@isdelete5, ");
            strSql.Append("pack=@pack,");

            strSql.Append("label_aminototal=@label_aminototal,");
            strSql.Append("domestic_ffa=@domestic_ffa,");
            strSql.Append("domestic_sand=@domestic_sand,");
            strSql.Append("domestic_water=@domestic_water,");

            strSql.Append("FishMealState=@FishMealState,");
            strSql.Append("shrimpshell=@shrimpshell,");
            strSql.Append("chromaticberration=@chromaticberration,");
            strSql.Append("smell=@smell,");
            strSql.Append("blackspot=@blackspot,");
            strSql.Append("port=@port ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@state", MySqlDbType.VarChar,45),
                    new MySqlParameter("@nature", MySqlDbType.VarChar,45),
                    new MySqlParameter("@origin", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type", MySqlDbType.VarChar,45),
                    new MySqlParameter("@techtype", MySqlDbType.VarChar,45),
                    new MySqlParameter("@specification", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quality", MySqlDbType.VarChar,45),
                    new MySqlParameter("@manufacturers", MySqlDbType.VarChar,100),
                    new MySqlParameter("@factoryaddress", MySqlDbType.VarChar,500),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,500),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,12),
                    new MySqlParameter("@quantity", MySqlDbType.Int32,11),
                    //new MySqlParameter("@remainweight", MySqlDbType.Decimal,12),
                    //new MySqlParameter("@remainquantity", MySqlDbType.Int32,11),
                    //new MySqlParameter("@homemadeweight", MySqlDbType.Decimal,12),
                    //new MySqlParameter("@homemadepackages", MySqlDbType.Int32,11),
                    //new MySqlParameter("@homemadecost", MySqlDbType.Decimal,12),
                    //new MySqlParameter("@homemadeunitprice", MySqlDbType.Decimal,12),
					new MySqlParameter("@price", MySqlDbType.Decimal,12),
                    new MySqlParameter("@sailingschedule", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ownerCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ownershortname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@ownername", MySqlDbType.VarChar,100),
                    new MySqlParameter("@billofgoods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@agentifcompany", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customsofcompany", MySqlDbType.VarChar,45),
                    //new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,50),
                    new MySqlParameter("@isdelete", MySqlDbType.Int16,4),
                    new MySqlParameter("@suppliercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@supplier", MySqlDbType.VarChar,100),
                    new MySqlParameter("@quote_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quote_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_amine", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quote_ffa", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_water", MySqlDbType.Decimal,6),
                    new MySqlParameter("@quote_sand", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@sgs_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_amine", MySqlDbType.Decimal,8),
                    new MySqlParameter("@sgs_ffa", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_water", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgs_sand", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@label_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_amine", MySqlDbType.Decimal,8),
                    new MySqlParameter("@label_ffa", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@labe_water", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_sand", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_lysine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@label_methionine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_tvn", MySqlDbType.Decimal,8),
                    new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@arriveportdate",MySqlDbType .VarChar , 45),
                    new MySqlParameter("@productdate",MySqlDbType.VarChar,100),
                    new MySqlParameter("@shelflife",MySqlDbType.Decimal ),
                    new MySqlParameter("@getinfotime",MySqlDbType.Timestamp  ),
                    new MySqlParameter("@endinfotime",MySqlDbType.Timestamp),
                    new MySqlParameter("@supplierid",MySqlDbType.Int32 , 8),
                    new MySqlParameter("@linkmanid",MySqlDbType.Int32,8),
                    new MySqlParameter("@linkmancode",MySqlDbType.VarChar,45),
                    new MySqlParameter("@linkman",MySqlDbType.VarChar,45),
                    new MySqlParameter("@latestquote",MySqlDbType.Decimal,8),

                    new MySqlParameter("@goodsinfo", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipno", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cornerno", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tariffrate", MySqlDbType.Decimal,8),
                    new MySqlParameter("@samplingtime", MySqlDbType.VarChar,45),
                    new MySqlParameter("@warehouse", MySqlDbType.VarChar,256),
                    new MySqlParameter("@sgsweight", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sgsquantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@domestic_amine", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_aminototal", MySqlDbType.Decimal,6),
                    new MySqlParameter("@domestic_fat", MySqlDbType.Decimal,6),
                    new MySqlParameter("@state1", MySqlDbType.VarChar,45),
                    new MySqlParameter("@state2", MySqlDbType.VarChar,45),
                    new MySqlParameter("@state3", MySqlDbType.VarChar,45),
                    new MySqlParameter("@state4", MySqlDbType.VarChar,45),
                    new MySqlParameter("@state5", MySqlDbType.VarChar,45),
                    new MySqlParameter("@isdelete1", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete2", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete3", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete4", MySqlDbType.Int16,4),
                    new MySqlParameter("@isdelete5", MySqlDbType.Int16,4),
                    new MySqlParameter("@pack",MySqlDbType.VarChar,20),
                    new MySqlParameter("@port",MySqlDbType.VarChar,50),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@label_aminototal", MySqlDbType.Decimal,45),
                    new MySqlParameter("@domestic_ffa", MySqlDbType.Decimal,45),
                    new MySqlParameter("@domestic_sand", MySqlDbType.Decimal,45),
                    new MySqlParameter("@domestic_water", MySqlDbType.Decimal,45),

                    new MySqlParameter("@FishMealState", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shrimpshell", MySqlDbType.VarChar,45),
                    new MySqlParameter("@chromaticberration", MySqlDbType.VarChar,45),
                    new MySqlParameter("@smell", MySqlDbType.VarChar,45),
                    new MySqlParameter("@blackspot", MySqlDbType.VarChar,45)
        };
            parameters[0].Value = model.code;
            parameters[1].Value = model.name;
            parameters[2].Value = model.brand;
            parameters[3].Value = model.state;
            parameters[4].Value = model.nature;
            parameters[5].Value = model.origin;
            parameters[6].Value = model.type;
            parameters[7].Value = model.techtype;
            parameters[8].Value = model.specification;
            parameters[9].Value = model.quality;
            parameters[10].Value = model.manufacturers;
            parameters[11].Value = model.factoryaddress;
            parameters[12].Value = model.remark;
            parameters[13].Value = model.weight;
            parameters[14].Value = model.quantity;
            //parameters[15].Value = model.remainweight;
            //parameters[16].Value = model.remainquantity;
            //parameters[17].Value = model.homemadeweight;
            //parameters[18].Value = model.homemadepackages;
            //parameters[19].Value = model.homemadecost;
            //parameters[20].Value = model.homemadeunitprice;
            parameters[15].Value = model.price;
            parameters[16].Value = model.sailingschedule;
            parameters[17].Value = model.ownerCode;
            parameters[18].Value = model.ownershortname;
            parameters[19].Value = model.ownername;
            parameters[20].Value = model.billofgoods;
            parameters[21].Value = model.agentifcompany;
            //parameters[22].Value = model.customsofcompany;
            parameters[22].Value = model.createman;
            parameters[23].Value = model.modifyman;
            parameters[24].Value = model.isdelete;
            parameters[25].Value = model.suppliercode;
            parameters[26].Value = model.supplier;
            parameters[27].Value = model.quote_protein;
            parameters[28].Value = model.quote_tvn;
            parameters[29].Value = model.quote_graypart;
            parameters[30].Value = model.quote_sandsalt;
            parameters[31].Value = model.quote_amine;
            parameters[32].Value = model.quote_ffa;
            parameters[33].Value = model.quote_fat;
            parameters[34].Value = model.quote_water;
            parameters[35].Value = model.quote_sand;
            parameters[36].Value = model.sgs_protein;
            parameters[37].Value = model.sgs_tvn;
            parameters[38].Value = model.sgs_graypart;
            parameters[39].Value = model.sgs_sandsalt;
            parameters[40].Value = model.sgs_amine;
            parameters[41].Value = model.sgs_ffa;
            parameters[42].Value = model.sgs_fat;
            parameters[43].Value = model.sgs_water;
            parameters[44].Value = model.sgs_sand;
            parameters[45].Value = model.label_protein;
            parameters[46].Value = model.label_tvn;
            parameters[47].Value = model.label_graypart;
            parameters[48].Value = model.label_sandsalt;
            parameters[49].Value = model.label_amine;
            parameters[50].Value = model.label_ffa;
            parameters[51].Value = model.label_fat;
            parameters[52].Value = model.labe_water;
            parameters[53].Value = model.label_sand;
            parameters[54].Value = model.label_lysine;
            parameters[55].Value = model.label_methionine;
            parameters[56].Value = model.domestic_protein;
            parameters[57].Value = model.domestic_tvn;
            parameters[58].Value = model.domestic_graypart;
            parameters[59].Value = model.domestic_sandsalt;
            parameters[60].Value = model.domestic_sour;
            parameters[61].Value = model.domestic_lysine;
            parameters[62].Value = model.domestic_methionine;
            parameters[63].Value = model.arriveportdate;
            parameters[64].Value = model.productdate;
            parameters[65].Value = model.shelflife;
            parameters[66].Value = model.getinfotime;
            parameters[67].Value = model.endinfotime;
            parameters[68].Value = model.supplierid;
            parameters[69].Value = model.linkmanid;
            parameters[70].Value = model.linkmancode;
            parameters[71].Value = model.linkman;
            parameters[72].Value = model.latestquote;

            parameters[73].Value = model.goodsinfo;
            parameters[74].Value = model.shipno;
            parameters[75].Value = model.cornerno;
            parameters[76].Value = model.tariffrate;
            parameters[77].Value = model.samplingtime;
            parameters[78].Value = model.warehouse;
            parameters[79].Value = model.sgsweight;
            parameters[80].Value = model.sgsquantity;
            parameters[81].Value = model.domestic_amine;
            parameters[82].Value = model.domestic_aminototal;
            parameters[83].Value = model.domestic_fat;
            parameters[84].Value = model.State1;
            parameters[85].Value = model.State2;
            parameters[86].Value = model.State3;
            parameters[87].Value = model.State4;
            parameters[88].Value = model.State5;
            parameters[89].Value = model.Isdelete1;
            parameters[90].Value = model.Isdelete2;
            parameters[91].Value = model.Isdelete3;
            parameters[92].Value = model.Isdelete4;
            parameters[93].Value = model.Isdelete5;
            parameters[94].Value = model.Pack;
            parameters[95].Value = model.port;
            parameters[96].Value = model.id;


            parameters[97].Value = model.label_aminototal;
            parameters[98].Value = model.domestic_ffa;
            parameters[99].Value = model.domestic_sand;
            parameters[100].Value = model.domestic_water;

            parameters[101].Value = model.FishMealState;
            parameters[102].Value = model.shrimpshell;
            parameters[103].Value = model.chromaticberration;
            parameters[104].Value = model.smell;
            parameters[105].Value = model.blackspot;
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
        public bool Entry_Update(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set ");
            strSql.Append("code=@code,");
            strSql.Append("specification=@specification,");
            strSql.Append("nature=@nature,");
            strSql.Append("brand=@brand,");
            strSql.Append("type=@type,");
            strSql.Append("quote_protein=@quote_protein,");
            strSql.Append("quote_tvn=@quote_tvn,");
            strSql.Append("quote_sand=@quote_sand,");
            strSql.Append("quote_sandsalt=@quote_sandsalt,");
            strSql.Append("quote_amine=@quote_amine,");
            strSql.Append("quote_ffa=@quote_ffa,");
            strSql.Append("quote_fat=@quote_fat,");
            strSql.Append("quote_water=@quote_water,");
            strSql.Append("modifytime=@modifytime,");
            strSql.Append("modifyman=@modifyman ");
            strSql.Append("where id=@id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@specification",MySqlDbType.VarChar,45),
                new MySqlParameter("@nature",MySqlDbType.VarChar,45),
                new MySqlParameter("@brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@type",MySqlDbType.VarChar,45),
                new MySqlParameter("@quote_protein",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_tvn",MySqlDbType.Decimal,8),
                new MySqlParameter("@quote_sand",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_sandsalt",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_amine",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_ffa",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_fat",MySqlDbType.Decimal,6),
                new MySqlParameter("@quote_water",MySqlDbType.Decimal,6),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,50),
                new MySqlParameter("@id",MySqlDbType.UInt32,11)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.specification;
            parameters[2].Value = model.nature;
            parameters[3].Value = model.brand;
            parameters[4].Value = model.type;
            parameters[5].Value = model.quote_protein;
            parameters[6].Value = model.quote_tvn;
            parameters[7].Value = model.quote_sand;
            parameters[8].Value = model.quote_sandsalt;
            parameters[9].Value = model.quote_amine;
            parameters[10].Value = model.quote_ffa;
            parameters[11].Value = model.quote_fat;
            parameters[12].Value = model.quote_water;
            parameters[13].Value = model.modifytime;
            parameters[14].Value = model.modifyman;
            parameters[15].Value = model.id;
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

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_product ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

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
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_product ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = MySqlHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.ProductEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,name,brand,state,state1,state2,state3,state4,state5,nature,origin,type,getinfotime,endinfotime,techtype,specification,productdate,shelflife,quality,manufacturers,factoryaddress,remark,weight,quantity,remainweight,remainquantity,homemadeweight,homemadepackages,homemadecost,homemadeunitprice,price,arriveportdate,sailingschedule,ownerCode,ownershortname,ownername,billofgoods,agentifcompany,customsofcompany,createtime,createman,modifytime,modifyman,isdelete,suppliercode,supplier,quote_protein,quote_tvn,quote_graypart,quote_sandsalt,quote_amine,quote_ffa,quote_fat,quote_water,quote_sand,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa, sgs_fat,sgs_water,sgs_sand,label_protein,label_tvn,label_graypart,label_sandsalt,label_amine,label_ffa,label_fat,labe_water,label_sand,label_lysine,label_methionine,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine,supplierid,linkmanid,linkmancode,linkman,latestquote ,goodsinfo,shipno,cornerno,tariffrate,samplingtime,warehouse,sgsweight,sgsquantity,domestic_amine,domestic_aminototal,domestic_fat,isdelete1,isdelete2,isdelete3,isdelete4,isdelete5,pack  from t_product ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            FishEntity.ProductEntity model = new FishEntity.ProductEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Entry_DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static FishEntity.ProductVo DataRowToModel(DataRow row)
        {
            FishEntity.ProductVo model = new FishEntity.ProductVo();
            if (row != null)
            {
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

                if (row["FishMealState"] != null)
                {
                    model.FishMealState = row["FishMealState"].ToString();
                }
                if (row["shrimpshell"] != null)
                {
                    model.shrimpshell = row["shrimpshell"].ToString();
                }
                if (row["chromaticberration"] != null)
                {
                    model.chromaticberration = row["chromaticberration"].ToString();
                }
                if (row["smell"] != null)
                {
                    model.smell = row["smell"].ToString();
                }
                if (row["blackspot"] != null)
                {
                    model.blackspot = row["blackspot"].ToString();
                }

                if (row["state"] != null)//
                {
                    model.state = row["state"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.state); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
                }
                if (row["state1"] != null)//1
                {
                    model.State1 = row["state1"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.State1); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
                }
                if (row["state2"] != null)//2
                {
                    model.State2 = row["state2"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.State2); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
                }
                if (row["state3"] != null)//3
                {
                    model.State3 = row["state3"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.State3); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
                }
                if (row["state4"] != null)//4
                {
                    model.State4 = row["state4"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.State4); });
                    if (item != null)
                    {
                        model.statename = item.Name;
                    }
                }
                if (row["state5"] != null)//5
                {
                    model.State5 = row["state5"].ToString();
                    //查询出状态值对应的状态名称
                    FishEntity.SystemDataType item = FishEntity.Variable.StateList.Find((i) => { return i.Code.Equals(model.State5); });
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
                if (row["port"]!=null)
                {
                    model.port = row["port"].ToString();
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
                if (row["isdelete1"] != null && row["isdelete1"].ToString() != "")
                {
                    model.Isdelete1 = int.Parse(row["isdelete1"].ToString());
                }
                if (row["isdelete2"] != null && row["isdelete2"].ToString() != "")
                {
                    model.Isdelete2 = int.Parse(row["isdelete2"].ToString());
                }
                if (row["isdelete3"] != null && row["isdelete3"].ToString() != "")
                {
                    model.Isdelete3 = int.Parse(row["isdelete3"].ToString());
                }
                if (row["isdelete4"] != null && row["isdelete4"].ToString() != "")
                {
                    model.Isdelete4 = int.Parse(row["isdelete4"].ToString());
                }
                if (row["isdelete5"] != null && row["isdelete5"].ToString() != "")
                {
                    model.Isdelete5 = int.Parse(row["isdelete5"].ToString());
                }
                if (row["pack"] != null)
                {
                    model.Pack = row["pack"].ToString();
                }
                //if (row["port"] != null) {
                //    model.port = row["port"].ToString();
                //}
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

                if (row["label_aminototal"] != null && row["label_aminototal"].ToString() != "")
                {
                    model.label_aminototal = decimal.Parse(row["label_aminototal"].ToString());
                }
                if (row["domestic_ffa"] != null && row["domestic_ffa"].ToString() != "")
                {
                    model.domestic_ffa = decimal.Parse(row["domestic_ffa"].ToString());
                }
                if (row["domestic_sand"] != null && row["domestic_sand"].ToString() != "")
                {
                    model.domestic_sand = decimal.Parse(row["domestic_sand"].ToString());
                }
                if (row["domestic_water"] != null && row["domestic_water"].ToString() != "")
                {
                    model.domestic_water = decimal.Parse(row["domestic_water"].ToString());
                }
            }
            return model;
        }
        public static FishEntity.ProductVo Entry_DataRowToModel(DataRow row)
        {
            FishEntity.ProductVo model = new FishEntity.ProductVo();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }               
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }   
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["specification"] != null)
                {
                    model.specification = row["specification"].ToString();
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
                
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,name,brand,state,state1,state2,state3,state4,state5,port,nature,origin,type,getinfotime,endinfotime,techtype,specification,productdate,shelflife,quality,");
            strSql.Append(" manufacturers,factoryaddress,remark,weight,quantity,remainweight,remainquantity,homemadeweight,homemadepackages,homemadecost,homemadeunitprice,price,arriveportdate,");
            strSql.Append(" sailingschedule, billofgoods,agentifcompany,customsofcompany,createtime,createman,modifytime,modifyman, isdelete,isdelete1,isdelete2,isdelete3,isdelete4,isdelete5,pack, ");
            strSql.Append(" suppliercode,supplier,quote_protein,quote_tvn,quote_graypart,quote_sandsalt,quote_amine,quote_ffa,quote_fat,quote_water,");
            strSql.Append(" quote_sand,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa,sgs_fat,sgs_water,sgs_sand,label_protein,label_tvn,");
            strSql.Append(" label_graypart,label_sandsalt,label_amine,label_ffa,label_fat,labe_water,label_sand,label_lysine,label_methionine,");
            strSql.Append(" domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine ,ownercode,ownershortname,ownername,supplierid,linkmanid,linkmancode,linkman,latestquote, ");
            strSql.Append("goodsinfo,shipno,cornerno,tariffrate,samplingtime,warehouse,sgsweight,sgsquantity,domestic_amine,domestic_aminototal,domestic_fat,");
            strSql.Append("label_aminototal,domestic_ffa,domestic_sand,domestic_water,FishMealState,shrimpshell,chromaticberration,smell,blackspot ");
            //strSql.Append("select  id,code,name,brand,state,nature,origin,type,getinfotime,endinfotime,techtype,specification,productdate,shelflife,quality,manufacturers,factoryaddress,remark,weight,quantity,remainweight,remainquantity,homemadeweight,homemadepackages,homemadecost,homemadeunitprice,price,arriveportdate,sailingschedule,ownerCode ,ownername, billofgoods ,agentifcompany,customsofcompany,createtime,createman,modifytime,modifyman,isdelete,suppliercode,supplier,quote_protein,quote_tvn,quote_graypart,quote_sandsalt");

            strSql.Append(" FROM t_product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public DataSet Entry_GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select* from t_product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_product ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = MySqlHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from t_product T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return MySqlHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_product";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return MySqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
