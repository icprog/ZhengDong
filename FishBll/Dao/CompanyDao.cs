using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CompanyDao
    {
        public CompanyDao()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_company");
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
            strSql.Append("select count(1) from t_company");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)
            };
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        public bool ExistsByFullName(string fullName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_company");
            strSql.Append(" where fullname=@fullname");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@fullname", MySqlDbType.VarChar,100)
            };
            parameters[0].Value = fullName;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(FishEntity.CompanyEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_company(");
            strSql.Append("code,type,fullname,shortname,generallevel,creditlevel,requiredlevel,managestandard,activelevel,loyalty,products,salesmancode,salesman,area,address,nature,manageprojects,registermoney,registertime,personnumber,zipcode,fox,website,linkmancode,linkman,currentlink,currentweekestimate,currentmonthestimate,nextlinkdate,description,validate,modifyman,modifytime,createman,createtime,isdelete,fatures,bank,account,threecard,type_customer,type_suppliers,type_quote,Logistics,type_merchants,type_goods,type_agents,estimatepurchasetime,customerproperty,customergroup,cashdeposit,paymethod,competitors,requiredproduct,registerman,cooperation,province,zone,productrequire,freight,tare,");
            strSql.Append(" yearSale,productgoods,yearproduct,supportproduct,yearsupport,cashdate,cashmethod,agentfeerate,issuingfeerate,billperiod,passfeerate,storagefee1,storagefee2,storagefee3,storagefee4,storagefee5,freight1,freight2,freight3,freight4,freight5,freight6,storageday1,storageday2,storageday3,storageday4,storageday5,paydays,requiregoods,Fishmaterial,Shrimpmaterial,Poultrymaterial,Special,Specialwater )");
            strSql.Append(" values (");
            strSql.Append("@code,@type,@fullname,@shortname,@generallevel,@creditlevel,@requiredlevel,@managestandard,@activelevel,@loyalty,@products,@salesmancode,@salesman,@area,@address,@nature,@manageprojects,@registermoney,@registertime,@personnumber,@zipcode,@fox,@website,@linkmancode,@linkman,@currentlink,@currentweekestimate,@currentmonthestimate,@nextlinkdate,@description,@validate,@modifyman,@modifytime,@createman,@createtime,@isdelete,@fatures,@bank,@account,@threecard,@type_customer,@type_suppliers,@type_quote,@Logistics,@type_merchants,@type_goods,@type_agents,@estimatepurchasetime,@customerproperty,@customergroup,@cashdeposit,@paymethod,@competitors,@requiredproduct,@registerman,@cooperation,@province,@zone,@productrequire,@freight,@tare,");
            strSql.Append(" @yearSale,@productgoods,@yearproduct,@supportproduct,@yearsupport,@cashdate,@cashmethod,@agentfeerate,@issuingfeerate,@billperiod,@passfeerate,@storagefee1,@storagefee2,@storagefee3,@storagefee4,@storagefee5,@freight1,@freight2,@freight3,@freight4,@freight5,@freight6 , @storageday1,@storageday2,@storageday3,@storageday4,@storageday5,@paydays,@requiregoods,@Fishmaterial,@Shrimpmaterial,@Poultrymaterial,@Special,@Specialwater  );");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fullname", MySqlDbType.VarChar,100),
                    new MySqlParameter("@shortname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@generallevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@creditlevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@requiredlevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@managestandard", MySqlDbType.VarChar,45),
                    new MySqlParameter("@activelevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@loyalty", MySqlDbType.VarChar,45),
                    new MySqlParameter("@products", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salesmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salesman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@area", MySqlDbType.VarChar,45),
                    new MySqlParameter("@address", MySqlDbType.VarChar,200),
                    new MySqlParameter("@nature", MySqlDbType.VarChar,45),
                    new MySqlParameter("@manageprojects", MySqlDbType.VarChar,45),
                    new MySqlParameter("@registermoney", MySqlDbType.VarChar,45),
                    new MySqlParameter("@registertime", MySqlDbType.Timestamp),
                    new MySqlParameter("@personnumber", MySqlDbType.Int32,11),
                    new MySqlParameter("@zipcode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fox", MySqlDbType.VarChar,100),
                    new MySqlParameter("@website", MySqlDbType.VarChar,200),
                    new MySqlParameter("@linkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@linkman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@currentlink", MySqlDbType.VarChar,45),
                    new MySqlParameter("@currentweekestimate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@currentmonthestimate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@nextlinkdate", MySqlDbType.Timestamp),
                    new MySqlParameter("@description", MySqlDbType.VarChar,500),
                    new MySqlParameter("@validate", MySqlDbType.Int32,2),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                    new MySqlParameter("@isdelete", MySqlDbType.Int32,6),
                    new MySqlParameter("@fatures", MySqlDbType.Int32,6),
                    new MySqlParameter("@bank", MySqlDbType.VarChar,45),
                    new MySqlParameter("@account", MySqlDbType.VarChar,45),
                    new MySqlParameter("@threecard", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_customer", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_suppliers", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_quote", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_merchants", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_goods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_agents", MySqlDbType.VarChar,45),
                    new MySqlParameter("@estimatepurchasetime", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customerproperty", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customergroup", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cashdeposit", MySqlDbType.VarChar,100),
                    new MySqlParameter("@paymethod", MySqlDbType.VarChar,100),
                    new MySqlParameter("@competitors", MySqlDbType.VarChar,100),
                    new MySqlParameter("@requiredproduct", MySqlDbType.VarChar,100),
                    new MySqlParameter("@registerman", MySqlDbType.VarChar,10),
                    new MySqlParameter("@cooperation", MySqlDbType.VarChar,45),
                    new MySqlParameter("@province", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@productrequire", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freight", MySqlDbType.Decimal,6),
                    new MySqlParameter("@tare", MySqlDbType.Decimal,8),

                    new MySqlParameter("@yearSale", MySqlDbType.VarChar,255),
                    new MySqlParameter("@productgoods", MySqlDbType.VarChar,255),
                    new MySqlParameter("@yearproduct", MySqlDbType.VarChar,255),
                    new MySqlParameter("@supportproduct", MySqlDbType.VarChar,255),
                    new MySqlParameter("@yearsupport", MySqlDbType.VarChar,255),
                    new MySqlParameter("@cashdate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@cashmethod", MySqlDbType.VarChar,255),
                    new MySqlParameter("@agentfeerate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@issuingfeerate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@billperiod", MySqlDbType.Int32,11),
                    new MySqlParameter("@passfeerate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storagefee1", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee2", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee3", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee4", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee5", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight1", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight2", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight3", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight4", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight5", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight6", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storageday1", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday2", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday3", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday4", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday5", MySqlDbType.VarChar,255),
                    new MySqlParameter("@paydays", MySqlDbType.Int32,6),
                    new MySqlParameter("@requiregoods", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Fishmaterial",MySqlDbType.VarChar,45),
                    new MySqlParameter("Shrimpmaterial",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Poultrymaterial",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Special",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Specialwater",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Logistics",MySqlDbType.VarChar,45)
                                              };
            parameters[0].Value = model.code;
            parameters[1].Value = model.type;
            parameters[2].Value = model.fullname;
            parameters[3].Value = model.shortname;
            parameters[4].Value = model.generallevel;
            parameters[5].Value = model.creditlevel;
            parameters[6].Value = model.requiredlevel;
            parameters[7].Value = model.managestandard;
            parameters[8].Value = model.activelevel;
            parameters[9].Value = model.loyalty;
            parameters[10].Value = model.products;
            parameters[11].Value = model.salesmancode;
            parameters[12].Value = model.salesman;
            parameters[13].Value = model.area;
            parameters[14].Value = model.address;
            parameters[15].Value = model.nature;
            parameters[16].Value = model.manageprojects;
            parameters[17].Value = model.registermoney;
            parameters[18].Value = model.registertime;
            parameters[19].Value = model.personnumber;
            parameters[20].Value = model.zipcode;
            parameters[21].Value = model.fox;
            parameters[22].Value = model.website;
            parameters[23].Value = model.linkmancode;
            parameters[24].Value = model.linkman;
            parameters[25].Value = model.currentlink;
            parameters[26].Value = model.currentweekestimate;
            parameters[27].Value = model.currentmonthestimate;
            parameters[28].Value = model.nextlinkdate;
            parameters[29].Value = model.description;
            parameters[30].Value = model.validate;
            parameters[31].Value = model.modifyman;
            parameters[32].Value = model.modifytime;
            parameters[33].Value = model.createman;
            parameters[34].Value = model.createtime;
            parameters[35].Value = model.isdelete;
            parameters[36].Value = model.fatures;
            parameters[37].Value = model.bank;
            parameters[38].Value = model.account;
            parameters[39].Value = model.threecard;
            parameters[40].Value = model.type_customer;
            parameters[41].Value = model.type_suppliers;
            parameters[42].Value = model.type_quote;
            parameters[43].Value = model.type_merchants;
            parameters[44].Value = model.type_goods;
            parameters[45].Value = model.type_agents;
            parameters[46].Value = model.estimatepurchasetime;
            parameters[47].Value = model.customerproperty;
            parameters[48].Value = model.customergroup;
            parameters[49].Value = model.cashdeposit;
            parameters[50].Value = model.paymethod;
            parameters[51].Value = model.competitors;
            parameters[52].Value = model.requiredproduct;
            parameters[53].Value = model.registerman;
            parameters[54].Value = model.cooperation;
            parameters[55].Value = model.province;
            parameters[56].Value = model.zone;
            parameters[57].Value = model.productrequire;
            parameters[58].Value = model.freight;
            parameters[59].Value = model.tare;

            parameters[60].Value = model.yearSale;
            parameters[61].Value = model.productgoods;
            parameters[62].Value = model.yearproduct;
            parameters[63].Value = model.supportproduct;
            parameters[64].Value = model.yearsupport;
            parameters[65].Value = model.cashdate;
            parameters[66].Value = model.cashmethod;
            parameters[67].Value = model.agentfeerate;
            parameters[68].Value = model.issuingfeerate;
            parameters[69].Value = model.billperiod;
            parameters[70].Value = model.passfeerate;
            parameters[71].Value = model.storagefee1;
            parameters[72].Value = model.storagefee2;
            parameters[73].Value = model.storagefee3;
            parameters[74].Value = model.storagefee4;
            parameters[75].Value = model.storagefee5;
            parameters[76].Value = model.freight1;
            parameters[77].Value = model.freight2;
            parameters[78].Value = model.freight3;
            parameters[79].Value = model.freight4;
            parameters[80].Value = model.freight5;
            parameters[81].Value = model.freight6;
            parameters[82].Value = model.storageday1;
            parameters[83].Value = model.storageday2;
            parameters[84].Value = model.storageday3;
            parameters[85].Value = model.storageday4;
            parameters[86].Value = model.storageday5;
            parameters[87].Value = model.paydays;
            parameters[88].Value = model.requiregoods;
            parameters[89].Value = model.Fishmaterial;
            parameters[90].Value = model.Shrimpmaterial;
            parameters[91].Value = model.Poultrymaterial;
            parameters[92].Value = model.Special;
            parameters[93].Value = model.Specialwater;
            parameters[94].Value = model.Logistics;
            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FishEntity.CompanyEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_company set ");
            strSql.Append("code=@code,");
            strSql.Append("type=@type,");
            strSql.Append("fullname=@fullname,");
            strSql.Append("shortname=@shortname,");
            strSql.Append("generallevel=@generallevel,");
            strSql.Append("creditlevel=@creditlevel,");
            strSql.Append("requiredlevel=@requiredlevel,");
            strSql.Append("managestandard=@managestandard,");
            strSql.Append("activelevel=@activelevel,");
            strSql.Append("loyalty=@loyalty,");
            strSql.Append("products=@products,");
            strSql.Append("salesmancode=@salesmancode,");
            strSql.Append("salesman=@salesman,");
            strSql.Append("area=@area,");
            strSql.Append("address=@address,");
            strSql.Append("nature=@nature,");
            strSql.Append("manageprojects=@manageprojects,");
            strSql.Append("registermoney=@registermoney,");
            strSql.Append("personnumber=@personnumber,");
            strSql.Append("zipcode=@zipcode,");
            strSql.Append("fox=@fox,");
            strSql.Append("website=@website,");
            strSql.Append("linkmancode=@linkmancode,");
            strSql.Append("linkman=@linkman,");
            //strSql.Append("currentlink=@currentlink,");          
            strSql.Append("description=@description,");
            strSql.Append("validate=@validate,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("createman=@createman,");
            strSql.Append("isdelete=@isdelete,");
            strSql.Append("fatures=@fatures,");
            strSql.Append("bank=@bank,");
            strSql.Append("account=@account,");
            strSql.Append("threecard=@threecard,");
            strSql.Append("type_customer=@type_customer,");
            strSql.Append("type_suppliers=@type_suppliers,");
            strSql.Append("type_quote=@type_quote,");
            strSql.Append("Logistics=@Logistics,");
            strSql.Append("type_merchants=@type_merchants,");
            strSql.Append("type_goods=@type_goods,");
            strSql.Append("type_agents=@type_agents,");
            //strSql.Append("estimatepurchasetime=@estimatepurchasetime,");
            strSql.Append("customerproperty=@customerproperty,");
            strSql.Append("customergroup=@customergroup,");
            strSql.Append("cashdeposit=@cashdeposit,");
            strSql.Append("paymethod=@paymethod,");
            strSql.Append("competitors=@competitors,");
            strSql.Append("requiredproduct=@requiredproduct,");
            strSql.Append("registerman=@registerman,");
            strSql.Append("cooperation=@cooperation,");
            strSql.Append("province=@province,");
            strSql.Append("zone=@zone,");
            strSql.Append("productrequire=@productrequire,");
            strSql.Append("freight=@freight,");
            strSql.Append("tare=@tare,");
            strSql.Append("currentweekestimate=@currentweekestimate,");
            strSql.Append("currentmonthestimate=@currentmonthestimate,");
            strSql.Append("modifytime=@modifytime,");

            strSql.Append("yearSale=@yearSale,");
            strSql.Append("productgoods=@productgoods,");
            strSql.Append("yearproduct=@yearproduct,");
            strSql.Append("supportproduct=@supportproduct,");
            strSql.Append("yearsupport=@yearsupport,");
            strSql.Append("cashdate=@cashdate,");
            strSql.Append("cashmethod=@cashmethod,");
            strSql.Append("agentfeerate=@agentfeerate,");
            strSql.Append("issuingfeerate=@issuingfeerate,");
            strSql.Append("billperiod=@billperiod,");
            strSql.Append("passfeerate=@passfeerate,");
            strSql.Append("storagefee1=@storagefee1,");
            strSql.Append("storagefee2=@storagefee2,");
            strSql.Append("storagefee3=@storagefee3,");
            strSql.Append("storagefee4=@storagefee4,");
            strSql.Append("storagefee5=@storagefee5,");
            strSql.Append("freight1=@freight1,");
            strSql.Append("freight2=@freight2,");
            strSql.Append("freight3=@freight3,");
            strSql.Append("freight4=@freight4,");
            strSql.Append("freight5=@freight5,");
            strSql.Append("freight6=@freight6,");
            strSql.Append("storageday1=@storageday1,");
            strSql.Append("storageday2=@storageday2,");
            strSql.Append("storageday3=@storageday3,");
            strSql.Append("storageday4=@storageday4,");
            strSql.Append("storageday5=@storageday5,");
            strSql.Append("paydays=@paydays,");
            strSql.Append("requiregoods=@requiregoods,");
            strSql.Append("Fishmaterial=@Fishmaterial,");
            strSql.Append("Shrimpmaterial=@Shrimpmaterial,");
            strSql.Append("Poultrymaterial=@Poultrymaterial,");
            strSql.Append("Special=@Special,");
            strSql.Append("Specialwater=@Specialwater ");

            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fullname", MySqlDbType.VarChar,100),
                    new MySqlParameter("@shortname", MySqlDbType.VarChar,50),
                    new MySqlParameter("@generallevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@creditlevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@requiredlevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@managestandard", MySqlDbType.VarChar,45),
                    new MySqlParameter("@activelevel", MySqlDbType.VarChar,45),
                    new MySqlParameter("@loyalty", MySqlDbType.VarChar,45),
                    new MySqlParameter("@products", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salesmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salesman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@area", MySqlDbType.VarChar,45),
                    new MySqlParameter("@address", MySqlDbType.VarChar,200),
                    new MySqlParameter("@nature", MySqlDbType.VarChar,45),
                    new MySqlParameter("@manageprojects", MySqlDbType.VarChar,45),
                    new MySqlParameter("@registermoney", MySqlDbType.VarChar,45),
                    new MySqlParameter("@personnumber", MySqlDbType.Int32,11),
                    new MySqlParameter("@zipcode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fox", MySqlDbType.VarChar,100),
                    new MySqlParameter("@website", MySqlDbType.VarChar,200),
                    new MySqlParameter("@linkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@linkman", MySqlDbType.VarChar,45),
					//new MySqlParameter("@currentlink", MySqlDbType.VarChar,45),				
					new MySqlParameter("@description", MySqlDbType.VarChar,500),
                    new MySqlParameter("@validate", MySqlDbType.Int32,2),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@isdelete", MySqlDbType.Int32,6),
                    new MySqlParameter("@fatures", MySqlDbType.Int32,6),
                    new MySqlParameter("@bank", MySqlDbType.VarChar,45),
                    new MySqlParameter("@account", MySqlDbType.VarChar,45),
                    new MySqlParameter("@threecard", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_customer", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_suppliers", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_quote", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_merchants", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_goods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type_agents", MySqlDbType.VarChar,45),
					//new MySqlParameter("@estimatepurchasetime", MySqlDbType.VarChar,45),
					new MySqlParameter("@customerproperty", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customergroup", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cashdeposit", MySqlDbType.VarChar,100),
                    new MySqlParameter("@paymethod", MySqlDbType.VarChar,100),
                    new MySqlParameter("@competitors", MySqlDbType.VarChar,100),
                    new MySqlParameter("@requiredproduct", MySqlDbType.VarChar,100),
                    new MySqlParameter("@registerman", MySqlDbType.VarChar,10),
                    new MySqlParameter("@cooperation", MySqlDbType.VarChar,45),
                    new MySqlParameter("@province", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zone", MySqlDbType.VarChar,100),
                    new MySqlParameter("@productrequire", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freight", MySqlDbType.Decimal,6),
                    new MySqlParameter("@tare", MySqlDbType.Decimal,8),
                    new MySqlParameter("@currentweekestimate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@currentmonthestimate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),

                    new MySqlParameter("@yearSale", MySqlDbType.VarChar,255),
                    new MySqlParameter("@productgoods", MySqlDbType.VarChar,255),
                    new MySqlParameter("@yearproduct", MySqlDbType.VarChar,255),
                    new MySqlParameter("@supportproduct", MySqlDbType.VarChar,255),
                    new MySqlParameter("@yearsupport", MySqlDbType.VarChar,255),
                    new MySqlParameter("@cashdate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@cashmethod", MySqlDbType.VarChar,255),
                    new MySqlParameter("@agentfeerate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@issuingfeerate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@billperiod", MySqlDbType.Int32,11),
                    new MySqlParameter("@passfeerate", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storagefee1", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee2", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee3", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee4", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storagefee5", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight1", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight2", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight3", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight4", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight5", MySqlDbType.Decimal,8),
                    new MySqlParameter("@freight6", MySqlDbType.Decimal,8),
                    new MySqlParameter("@storageday1", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday2", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday3", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday4", MySqlDbType.VarChar,255),
                    new MySqlParameter("@storageday5", MySqlDbType.VarChar,255),
                    new MySqlParameter("@paydays", MySqlDbType.Int32,6),
                    new MySqlParameter("@requiregoods", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Fishmaterial",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Shrimpmaterial",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Poultrymaterial",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Special",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Specialwater",MySqlDbType.VarChar,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@Logistics",MySqlDbType.VarChar,45)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.type;
            parameters[2].Value = model.fullname;
            parameters[3].Value = model.shortname;
            parameters[4].Value = model.generallevel;
            parameters[5].Value = model.creditlevel;
            parameters[6].Value = model.requiredlevel;
            parameters[7].Value = model.managestandard;
            parameters[8].Value = model.activelevel;
            parameters[9].Value = model.loyalty;
            parameters[10].Value = model.products;
            parameters[11].Value = model.salesmancode;
            parameters[12].Value = model.salesman;
            parameters[13].Value = model.area;
            parameters[14].Value = model.address;
            parameters[15].Value = model.nature;
            parameters[16].Value = model.manageprojects;
            parameters[17].Value = model.registermoney;
            parameters[18].Value = model.personnumber;
            parameters[19].Value = model.zipcode;
            parameters[20].Value = model.fox;
            parameters[21].Value = model.website;
            parameters[22].Value = model.linkmancode;
            parameters[23].Value = model.linkman;
            //parameters[24].Value = model.currentlink;
            //parameters[25].Value = model.currentweekestimate;
            //parameters[26].Value = model.currentmonthestimate;
            parameters[24].Value = model.description;
            parameters[25].Value = model.validate;
            parameters[26].Value = model.modifyman;
            parameters[27].Value = model.createman;
            parameters[28].Value = model.isdelete;
            parameters[29].Value = model.fatures;
            parameters[30].Value = model.bank;
            parameters[31].Value = model.account;
            parameters[32].Value = model.threecard;
            parameters[33].Value = model.type_customer;
            parameters[34].Value = model.type_suppliers;
            parameters[35].Value = model.type_quote;
            parameters[36].Value = model.type_merchants;
            parameters[37].Value = model.type_goods;
            parameters[38].Value = model.type_agents;
            //parameters[39].Value = model.estimatepurchasetime;
            parameters[39].Value = model.customerproperty;
            parameters[40].Value = model.customergroup;
            parameters[41].Value = model.cashdeposit;
            parameters[42].Value = model.paymethod;
            parameters[43].Value = model.competitors;
            parameters[44].Value = model.requiredproduct;
            parameters[45].Value = model.registerman;
            parameters[46].Value = model.cooperation;
            parameters[47].Value = model.province;
            parameters[48].Value = model.zone;
            parameters[49].Value = model.productrequire;
            parameters[50].Value = model.freight;
            parameters[51].Value = model.tare;
            parameters[52].Value = model.currentweekestimate;
            parameters[53].Value = model.currentmonthestimate;
            parameters[54].Value = DateTime.Now;//model.modifytime;

            parameters[55].Value = model.yearSale;
            parameters[56].Value = model.productgoods;
            parameters[57].Value = model.yearproduct;
            parameters[58].Value = model.supportproduct;
            parameters[59].Value = model.yearsupport;
            parameters[60].Value = model.cashdate;
            parameters[61].Value = model.cashmethod;
            parameters[62].Value = model.agentfeerate;
            parameters[63].Value = model.issuingfeerate;
            parameters[64].Value = model.billperiod;
            parameters[65].Value = model.passfeerate;
            parameters[66].Value = model.storagefee1;
            parameters[67].Value = model.storagefee2;
            parameters[68].Value = model.storagefee3;
            parameters[69].Value = model.storagefee4;
            parameters[70].Value = model.storagefee5;
            parameters[71].Value = model.freight1;
            parameters[72].Value = model.freight2;
            parameters[73].Value = model.freight3;
            parameters[74].Value = model.freight4;
            parameters[75].Value = model.freight5;
            parameters[76].Value = model.freight6;
            parameters[77].Value = model.storageday1;
            parameters[78].Value = model.storageday2;
            parameters[79].Value = model.storageday3;
            parameters[80].Value = model.storageday4;
            parameters[81].Value = model.storageday5;
            parameters[82].Value = model.paydays;
            parameters[83].Value = model.requiregoods;
            parameters[84].Value = model.Fishmaterial;
            parameters[85].Value = model.Shrimpmaterial;
            parameters[86].Value = model.Poultrymaterial;
            parameters[87].Value = model.Special;
            parameters[88].Value = model.Specialwater;
            parameters[89].Value = model.id;
            parameters[90].Value = model.Logistics;

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

        public bool UpdateLinkMan(int compnayid, string linkmancode, string linkman)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_company set linkmancode=@linkmancode , linkman=@linkman where id=@id");
            MySqlParameter[] parameters = {
                                              new MySqlParameter("@linkmancode", MySqlDbType.VarChar,45),
                                              new MySqlParameter("@linkman",MySqlDbType.VarChar,45),
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = linkmancode;
            parameters[1].Value = linkman;
            parameters[2].Value = compnayid;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_company ");
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
            strSql.Append("delete from t_company ");
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
        public FishEntity.CompanyEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,type,fullname,shortname,generallevel,creditlevel,requiredlevel,managestandard,activelevel,loyalty,products,salesmancode,salesman,area,address,nature,manageprojects,registermoney,registertime,personnumber,zipcode,fox,website,linkmancode,linkman,currentlink,currentweekestimate,currentmonthestimate,nextlinkdate,description,validate,modifyman,modifytime,createman,createtime,isdelete,fatures,bank,account,threecard,type_customer,type_suppliers,type_quote,Logistics,type_merchants,type_goods,type_agents,estimatepurchasetime,customerproperty,customergroup,cashdeposit,paymethod,competitors,requiredproduct ,registerman,cooperation,province,zone,productrequire,freight,tare , yearSale,productgoods,yearproduct,supportproduct,yearsupport,cashdate,cashmethod,agentfeerate,issuingfeerate,billperiod,passfeerate,storagefee1,storagefee2,storagefee3,storagefee4,storagefee5,freight1,freight2,freight3,freight4,freight5,freight6,storageday1,storageday2,storageday3,storageday4,storageday5,paydays,requiregoods,Fishmaterial,Shrimpmaterial,Poultrymaterial,Special,Specialwater,Logistics  from t_company ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            FishEntity.CompanyEntity model = new FishEntity.CompanyEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }




        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static FishEntity.CompanyEntity DataRowToModel(DataRow row)
        {
            FishEntity.CompanyEntity model = new FishEntity.CompanyEntity();
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
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["fullname"] != null)
                {
                    model.fullname = row["fullname"].ToString();
                }
                if (row["shortname"] != null)
                {
                    model.shortname = row["shortname"].ToString();
                }
                if (row["generallevel"] != null)
                {
                    model.generallevel = row["generallevel"].ToString();
                }
                if (row["creditlevel"] != null)
                {
                    model.creditlevel = row["creditlevel"].ToString();
                }
                if (row["requiredlevel"] != null)
                {
                    model.requiredlevel = row["requiredlevel"].ToString();
                }
                if (row["managestandard"] != null)
                {
                    model.managestandard = row["managestandard"].ToString();
                }
                if (row["activelevel"] != null)
                {
                    model.activelevel = row["activelevel"].ToString();
                }
                if (row["loyalty"] != null)
                {
                    model.loyalty = row["loyalty"].ToString();
                }
                if (row["products"] != null)
                {
                    model.products = row["products"].ToString();
                }
                if (row["salesmancode"] != null)
                {
                    model.salesmancode = row["salesmancode"].ToString();
                }
                if (row["salesman"] != null)
                {
                    model.salesman = row["salesman"].ToString();
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["manageprojects"] != null)
                {
                    model.manageprojects = row["manageprojects"].ToString();
                }
                if (row["registermoney"] != null)
                {
                    model.registermoney = row["registermoney"].ToString();
                }
                if (row["registertime"] != null && row["registertime"].ToString() != "")
                {
                    model.registertime = DateTime.Parse(row["registertime"].ToString());
                }
                if (row["personnumber"] != null && row["personnumber"].ToString() != "")
                {
                    model.personnumber = int.Parse(row["personnumber"].ToString());
                }
                if (row["zipcode"] != null)
                {
                    model.zipcode = row["zipcode"].ToString();
                }
                if (row["fox"] != null)
                {
                    model.fox = row["fox"].ToString();
                }
                if (row["website"] != null)
                {
                    model.website = row["website"].ToString();
                }
                if (row["linkmancode"] != null)
                {
                    model.linkmancode = row["linkmancode"].ToString();
                }
                if (row["linkman"] != null)
                {
                    model.linkman = row["linkman"].ToString();
                }
                if (row["currentlink"] != null)
                {
                    model.currentlink = row["currentlink"].ToString();
                }
                if (row["currentweekestimate"] != null)
                {
                    model.currentweekestimate = row["currentweekestimate"].ToString();
                }
                if (row["currentmonthestimate"] != null)
                {
                    model.currentmonthestimate = row["currentmonthestimate"].ToString();
                }
                if (row["nextlinkdate"] != null && row["nextlinkdate"].ToString() != "")
                {
                    model.nextlinkdate = DateTime.Parse(row["nextlinkdate"].ToString());
                }
                if (row["description"] != null)
                {
                    model.description = row["description"].ToString();
                }
                if (row["validate"] != null && row["validate"].ToString() != "")
                {
                    model.validate = int.Parse(row["validate"].ToString());
                }
                if (row["modifyman"] != null)
                {
                    model.modifyman = row["modifyman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                if (row["fatures"] != null && row["fatures"].ToString() != "")
                {
                    model.fatures = int.Parse(row["fatures"].ToString());
                }
                if (row["bank"] != null)
                {
                    model.bank = row["bank"].ToString();
                }
                if (row["account"] != null)
                {
                    model.account = row["account"].ToString();
                }
                if (row["threecard"] != null)
                {
                    model.threecard = row["threecard"].ToString();
                }
                if (row["type_customer"] != null)
                {
                    model.type_customer = row["type_customer"].ToString();
                }
                if (row["type_suppliers"] != null)
                {
                    model.type_suppliers = row["type_suppliers"].ToString();
                }
                if (row["type_quote"] != null)
                {
                    model.type_quote = row["type_quote"].ToString();
                }
                if (row["Logistics"] != null)
                {
                    model.Logistics = row["Logistics"].ToString();
                }
                if (row["type_merchants"] != null)
                {
                    model.type_merchants = row["type_merchants"].ToString();
                }
                if (row["type_goods"] != null)
                {
                    model.type_goods = row["type_goods"].ToString();
                }
                if (row["type_agents"] != null)
                {
                    model.type_agents = row["type_agents"].ToString();
                }
                if (row["estimatepurchasetime"] != null)
                {
                    model.estimatepurchasetime = row["estimatepurchasetime"].ToString();
                }
                if (row["customerproperty"] != null)
                {
                    model.customerproperty = row["customerproperty"].ToString();
                }
                if (row["customergroup"] != null)
                {
                    model.customergroup = row["customergroup"].ToString();
                }
                if (row["cashdeposit"] != null)
                {
                    model.cashdeposit = row["cashdeposit"].ToString();
                }
                if (row["paymethod"] != null)
                {
                    model.paymethod = row["paymethod"].ToString();
                }
                if (row["competitors"] != null)
                {
                    model.competitors = row["competitors"].ToString();
                }
                if (row["requiredproduct"] != null)
                {
                    model.requiredproduct = row["requiredproduct"].ToString();
                }
                if (row["registerman"] != null)
                {
                    model.registerman = row["registerman"].ToString();
                }
                if (row["cooperation"] != null)
                {
                    model.cooperation = row["cooperation"].ToString();
                }
                if (row["province"] != null)
                {
                    model.province = row["province"].ToString();
                }
                if (row["zone"] != null)
                {
                    model.zone = row["zone"].ToString();
                }
                if (row["productrequire"] != null)
                {
                    model.productrequire = row["productrequire"].ToString();
                }
                if (row["freight"] != null && row["freight"].ToString() != "")
                {
                    model.freight = decimal.Parse(row["freight"].ToString());
                }
                if (row["tare"] != null && row["tare"].ToString() != "")
                {
                    model.tare = decimal.Parse(row["tare"].ToString());
                }

                if (row["yearSale"] != null)
                {
                    model.yearSale = row["yearSale"].ToString();
                }
                if (row["productgoods"] != null)
                {
                    model.productgoods = row["productgoods"].ToString();
                }
                if (row["yearproduct"] != null)
                {
                    model.yearproduct = row["yearproduct"].ToString();
                }
                if (row["supportproduct"] != null)
                {
                    model.supportproduct = row["supportproduct"].ToString();
                }
                if (row["yearsupport"] != null)
                {
                    model.yearsupport = row["yearsupport"].ToString();
                }
                if (row["cashdate"] != null)
                {
                    model.cashdate = row["cashdate"].ToString();
                }
                if (row["cashmethod"] != null)
                {
                    model.cashmethod = row["cashmethod"].ToString();
                }
                if (row["agentfeerate"] != null)
                {
                    model.agentfeerate = row["agentfeerate"].ToString();
                }
                if (row["issuingfeerate"] != null)
                {
                    model.issuingfeerate = row["issuingfeerate"].ToString();
                }
                if (row["billperiod"] != null && row["billperiod"].ToString() != "")
                {
                    model.billperiod = int.Parse(row["billperiod"].ToString());
                }
                if (row["passfeerate"] != null)
                {
                    model.passfeerate = row["passfeerate"].ToString();
                }
                if (row["storagefee1"] != null && row["storagefee1"].ToString() != "")
                {
                    model.storagefee1 = decimal.Parse(row["storagefee1"].ToString());
                }
                if (row["storagefee2"] != null && row["storagefee2"].ToString() != "")
                {
                    model.storagefee2 = decimal.Parse(row["storagefee2"].ToString());
                }
                if (row["storagefee3"] != null && row["storagefee3"].ToString() != "")
                {
                    model.storagefee3 = decimal.Parse(row["storagefee3"].ToString());
                }
                if (row["storagefee4"] != null && row["storagefee4"].ToString() != "")
                {
                    model.storagefee4 = decimal.Parse(row["storagefee4"].ToString());
                }
                if (row["storagefee5"] != null && row["storagefee5"].ToString() != "")
                {
                    model.storagefee5 = decimal.Parse(row["storagefee5"].ToString());
                }
                if (row["freight1"] != null && row["freight1"].ToString() != "")
                {
                    model.freight1 = decimal.Parse(row["freight1"].ToString());
                }
                if (row["freight2"] != null && row["freight2"].ToString() != "")
                {
                    model.freight2 = decimal.Parse(row["freight2"].ToString());
                }
                if (row["freight3"] != null && row["freight3"].ToString() != "")
                {
                    model.freight3 = decimal.Parse(row["freight3"].ToString());
                }
                if (row["freight4"] != null && row["freight4"].ToString() != "")
                {
                    model.freight4 = decimal.Parse(row["freight4"].ToString());
                }
                if (row["freight5"] != null && row["freight5"].ToString() != "")
                {
                    model.freight5 = decimal.Parse(row["freight5"].ToString());
                }
                if (row["freight6"] != null && row["freight6"].ToString() != "")
                {
                    model.freight6 = decimal.Parse(row["freight6"].ToString());
                }

                if (row["storageday1"] != null)
                {
                    model.storageday1 = row["storageday1"].ToString();
                }
                if (row["storageday2"] != null)
                {
                    model.storageday2 = row["storageday2"].ToString();
                }
                if (row["storageday3"] != null)
                {
                    model.storageday3 = row["storageday3"].ToString();
                }
                if (row["storageday4"] != null)
                {
                    model.storageday4 = row["storageday4"].ToString();
                }
                if (row["storageday5"] != null)
                {
                    model.storageday5 = row["storageday5"].ToString();
                }
                if (row["paydays"] != null && row["paydays"].ToString() != "")
                {
                    model.paydays = int.Parse(row["paydays"].ToString());
                }
                if (row["requiregoods"] != null)
                {
                    model.requiregoods = row["requiregoods"].ToString();
                }
                if (row["Fishmaterial"] != null && row["Fishmaterial"].ToString() != "")
                {
                    model.Fishmaterial = row["Fishmaterial"].ToString();
                }
                if (row["Shrimpmaterial"] != null && row["Shrimpmaterial"].ToString() != "")
                {
                    model.Shrimpmaterial = row["Shrimpmaterial"].ToString();
                }
                if (row["Poultrymaterial"] != null && row["Poultrymaterial"].ToString() != "")
                {
                    model.Poultrymaterial = row["Poultrymaterial"].ToString();
                }
                if (row["Special"] != null && row["Special"].ToString() != "")
                {
                    model.Special = row["Special"].ToString();
                }
                if (row["Specialwater"] != null && row["Specialwater"].ToString() != "")
                {
                    model.Specialwater = row["Specialwater"].ToString();
                }
                if (row["account"] != null)
                {
                    model.account = row["account"].ToString();
                }
                if (row["bank"] != null)
                {
                    model.bank = row["bank"].ToString();
                }

            }
            return model;
        }
        public static FishEntity.CompanyEntity DataRowToModel1(DataRow row)
        {
            FishEntity.CompanyEntity model = new FishEntity.CompanyEntity();
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
                if (row["type"] != null)
                {
                    model.type = row["type"].ToString();
                }
                if (row["fullname"] != null)
                {
                    model.fullname = row["fullname"].ToString();
                }
                if (row["shortname"] != null)
                {
                    model.shortname = row["shortname"].ToString();
                }
                if (row["generallevel"] != null)
                {
                    model.generallevel = row["generallevel"].ToString();
                }
                if (row["creditlevel"] != null)
                {
                    model.creditlevel = row["creditlevel"].ToString();
                }
                if (row["requiredlevel"] != null)
                {
                    model.requiredlevel = row["requiredlevel"].ToString();
                }
                if (row["managestandard"] != null)
                {
                    model.managestandard = row["managestandard"].ToString();
                }
                if (row["activelevel"] != null)
                {
                    model.activelevel = row["activelevel"].ToString();
                }
                if (row["loyalty"] != null)
                {
                    model.loyalty = row["loyalty"].ToString();
                }
                if (row["products"] != null)
                {
                    model.products = row["products"].ToString();
                }
                if (row["salesmancode"] != null)
                {
                    model.salesmancode = row["salesmancode"].ToString();
                }
                if (row["salesman"] != null)
                {
                    model.salesman = row["salesman"].ToString();
                }
                if (row["area"] != null)
                {
                    model.area = row["area"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["manageprojects"] != null)
                {
                    model.manageprojects = row["manageprojects"].ToString();
                }
                if (row["registermoney"] != null)
                {
                    model.registermoney = row["registermoney"].ToString();
                }
                if (row["registertime"] != null && row["registertime"].ToString() != "")
                {
                    model.registertime = DateTime.Parse(row["registertime"].ToString());
                }
                if (row["personnumber"] != null && row["personnumber"].ToString() != "")
                {
                    model.personnumber = int.Parse(row["personnumber"].ToString());
                }
                if (row["zipcode"] != null)
                {
                    model.zipcode = row["zipcode"].ToString();
                }
                if (row["fox"] != null)
                {
                    model.fox = row["fox"].ToString();
                }
                if (row["website"] != null)
                {
                    model.website = row["website"].ToString();
                }
                if (row["linkmancode"] != null)
                {
                    model.linkmancode = row["linkmancode"].ToString();
                }
                if (row["linkman"] != null)
                {
                    model.linkman = row["linkman"].ToString();
                }
                if (row["currentlink"] != null)
                {
                    model.currentlink = row["currentlink"].ToString();
                }
                if (row["currentweekestimate"] != null)
                {
                    model.currentweekestimate = row["currentweekestimate"].ToString();
                }
                if (row["currentmonthestimate"] != null)
                {
                    model.currentmonthestimate = row["currentmonthestimate"].ToString();
                }
                if (row["nextlinkdate"] != null && row["nextlinkdate"].ToString() != "")
                {
                    model.nextlinkdate = DateTime.Parse(row["nextlinkdate"].ToString());
                }
                if (row["description"] != null)
                {
                    model.description = row["description"].ToString();
                }
                if (row["validate"] != null && row["validate"].ToString() != "")
                {
                    model.validate = int.Parse(row["validate"].ToString());
                }
                if (row["modifyman"] != null)
                {
                    model.modifyman = row["modifyman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                if (row["fatures"] != null && row["fatures"].ToString() != "")
                {
                    model.fatures = int.Parse(row["fatures"].ToString());
                }
                if (row["bank"] != null)
                {
                    model.bank = row["bank"].ToString();
                }
                if (row["account"] != null)
                {
                    model.account = row["account"].ToString();
                }
                if (row["threecard"] != null)
                {
                    model.threecard = row["threecard"].ToString();
                }
                if (row["type_customer"] != null)
                {
                    model.type_customer = row["type_customer"].ToString();
                }
                if (row["type_suppliers"] != null)
                {
                    model.type_suppliers = row["type_suppliers"].ToString();
                }
                if (row["type_quote"] != null)
                {
                    model.type_quote = row["type_quote"].ToString();
                }
                if (row["type_merchants"] != null)
                {
                    model.type_merchants = row["type_merchants"].ToString();
                }
                if (row["type_goods"] != null)
                {
                    model.type_goods = row["type_goods"].ToString();
                }
                if (row["type_agents"] != null)
                {
                    model.type_agents = row["type_agents"].ToString();
                }
                if (row["estimatepurchasetime"] != null)
                {
                    model.estimatepurchasetime = row["estimatepurchasetime"].ToString();
                }
                if (row["customerproperty"] != null)
                {
                    model.customerproperty = row["customerproperty"].ToString();
                }
                if (row["customergroup"] != null)
                {
                    model.customergroup = row["customergroup"].ToString();
                }
                if (row["cashdeposit"] != null)
                {
                    model.cashdeposit = row["cashdeposit"].ToString();
                }
                if (row["paymethod"] != null)
                {
                    model.paymethod = row["paymethod"].ToString();
                }
                if (row["competitors"] != null)
                {
                    model.competitors = row["competitors"].ToString();
                }
                if (row["requiredproduct"] != null)
                {
                    model.requiredproduct = row["requiredproduct"].ToString();
                }
                if (row["registerman"] != null)
                {
                    model.registerman = row["registerman"].ToString();
                }
                if (row["cooperation"] != null)
                {
                    model.cooperation = row["cooperation"].ToString();
                }
                if (row["province"] != null)
                {
                    model.province = row["province"].ToString();
                }
                if (row["zone"] != null)
                {
                    model.zone = row["zone"].ToString();
                }
                if (row["productrequire"] != null)
                {
                    model.productrequire = row["productrequire"].ToString();
                }
                if (row["freight"] != null && row["freight"].ToString() != "")
                {
                    model.freight = decimal.Parse(row["freight"].ToString());
                }
                if (row["tare"] != null && row["tare"].ToString() != "")
                {
                    model.tare = decimal.Parse(row["tare"].ToString());
                }

                if (row["yearSale"] != null)
                {
                    model.yearSale = row["yearSale"].ToString();
                }
                if (row["productgoods"] != null)
                {
                    model.productgoods = row["productgoods"].ToString();
                }
                if (row["yearproduct"] != null)
                {
                    model.yearproduct = row["yearproduct"].ToString();
                }
                if (row["supportproduct"] != null)
                {
                    model.supportproduct = row["supportproduct"].ToString();
                }
                if (row["yearsupport"] != null)
                {
                    model.yearsupport = row["yearsupport"].ToString();
                }
                if (row["cashdate"] != null)
                {
                    model.cashdate = row["cashdate"].ToString();
                }
                if (row["cashmethod"] != null)
                {
                    model.cashmethod = row["cashmethod"].ToString();
                }
                if (row["agentfeerate"] != null)
                {
                    model.agentfeerate = row["agentfeerate"].ToString();
                }
                if (row["issuingfeerate"] != null)
                {
                    model.issuingfeerate = row["issuingfeerate"].ToString();
                }
                if (row["billperiod"] != null && row["billperiod"].ToString() != "")
                {
                    model.billperiod = int.Parse(row["billperiod"].ToString());
                }
                if (row["passfeerate"] != null)
                {
                    model.passfeerate = row["passfeerate"].ToString();
                }
                if (row["storagefee1"] != null && row["storagefee1"].ToString() != "")
                {
                    model.storagefee1 = decimal.Parse(row["storagefee1"].ToString());
                }
                if (row["storagefee2"] != null && row["storagefee2"].ToString() != "")
                {
                    model.storagefee2 = decimal.Parse(row["storagefee2"].ToString());
                }
                if (row["storagefee3"] != null && row["storagefee3"].ToString() != "")
                {
                    model.storagefee3 = decimal.Parse(row["storagefee3"].ToString());
                }
                if (row["storagefee4"] != null && row["storagefee4"].ToString() != "")
                {
                    model.storagefee4 = decimal.Parse(row["storagefee4"].ToString());
                }
                if (row["storagefee5"] != null && row["storagefee5"].ToString() != "")
                {
                    model.storagefee5 = decimal.Parse(row["storagefee5"].ToString());
                }
                if (row["freight1"] != null && row["freight1"].ToString() != "")
                {
                    model.freight1 = decimal.Parse(row["freight1"].ToString());
                }
                if (row["freight2"] != null && row["freight2"].ToString() != "")
                {
                    model.freight2 = decimal.Parse(row["freight2"].ToString());
                }
                if (row["freight3"] != null && row["freight3"].ToString() != "")
                {
                    model.freight3 = decimal.Parse(row["freight3"].ToString());
                }
                if (row["freight4"] != null && row["freight4"].ToString() != "")
                {
                    model.freight4 = decimal.Parse(row["freight4"].ToString());
                }
                if (row["freight5"] != null && row["freight5"].ToString() != "")
                {
                    model.freight5 = decimal.Parse(row["freight5"].ToString());
                }
                if (row["freight6"] != null && row["freight6"].ToString() != "")
                {
                    model.freight6 = decimal.Parse(row["freight6"].ToString());
                }

                if (row["storageday1"] != null)
                {
                    model.storageday1 = row["storageday1"].ToString();
                }
                if (row["storageday2"] != null)
                {
                    model.storageday2 = row["storageday2"].ToString();
                }
                if (row["storageday3"] != null)
                {
                    model.storageday3 = row["storageday3"].ToString();
                }
                if (row["storageday4"] != null)
                {
                    model.storageday4 = row["storageday4"].ToString();
                }
                if (row["storageday5"] != null)
                {
                    model.storageday5 = row["storageday5"].ToString();
                }
                if (row["paydays"] != null && row["paydays"].ToString() != "")
                {
                    model.paydays = int.Parse(row["paydays"].ToString());
                }
                if (row["requiregoods"] != null)
                {
                    model.requiregoods = row["requiregoods"].ToString();
                }
                //if (row["Fishmaterial"] != null && row["Fishmaterial"].ToString() != "")
                //{
                //    model.Fishmaterial = row["Fishmaterial"].ToString();
                //}
                //if (row["Shrimpmaterial"] != null && row["Shrimpmaterial"].ToString() != "")
                //{
                //    model.Shrimpmaterial = row["Shrimpmaterial"].ToString();
                //}
                //if (row["Poultrymaterial"] != null && row["Poultrymaterial"].ToString() != "")
                //{
                //    model.Poultrymaterial = row["Poultrymaterial"].ToString();
                //}
                //if (row["Special"] != null && row["Special"].ToString() != "")
                //{
                //    model.Special = row["Special"].ToString();
                //}
                //if (row["Specialwater"] != null && row["Specialwater"].ToString() != "")
                //{
                //    model.Specialwater = row["Specialwater"].ToString();
                //}

            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,type,fullname,shortname,generallevel,creditlevel,requiredlevel,managestandard,activelevel,loyalty,products,salesmancode,salesman,area,address,nature,manageprojects,registermoney,registertime,personnumber,zipcode,fox,website,linkmancode,linkman,currentlink,currentweekestimate,currentmonthestimate,nextlinkdate,description,validate,modifyman,modifytime,createman,createtime,isdelete,fatures,bank,account,threecard,type_customer,type_suppliers,type_quote,Logistics,type_merchants,type_goods,type_agents,estimatepurchasetime,customerproperty,customergroup,cashdeposit,paymethod,competitors,requiredproduct ,registerman,cooperation,province,zone,productrequire,freight,tare , yearSale,productgoods,yearproduct,supportproduct,yearsupport,cashdate,cashmethod,agentfeerate,issuingfeerate,billperiod,passfeerate,storagefee1,storagefee2,storagefee3,storagefee4,storagefee5,freight1,freight2,freight3,freight4,freight5,freight6,storageday1,storageday2,storageday3,storageday4,storageday5,paydays,requiregoods,Fishmaterial,Shrimpmaterial,Poultrymaterial,Special,Specialwater,bank,account,modifyman ");
            strSql.Append(" FROM t_company ");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_company ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_company T ");
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
            parameters[0].Value = "t_company";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod


        #endregion  ExtensionMethod

    }
}
