using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
    public class WarehouseReceiptDao
    {
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(code) code from t_WarehouseReceipt");

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string code = dt.Rows[0]["code"].ToString();
                if (string.IsNullOrEmpty(code))
                    return DateTime.Now.ToString("yyyyMMdd").ToString() + "001";
                else
                {
                    if (code.Substring(0, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                        return (Convert.ToInt64(code) + 1).ToString();
                    else
                        return DateTime.Now.ToString("yyyyMMdd") + "001";
                }
            }
            else
                return DateTime.Now.ToString("yyyyMMdd") + "001";
        }

        /// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.WarehouseReceiptEntity model, string name)
        {
            Hashtable SQLString = new Hashtable();
            SQLString = ReviewInfo.getSQLString(name, model.code, string.Empty, SQLString);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_warehousereceipt(");
            strSql.Append("code,codeNumContract,fishId,quaIden,commodityTons,commodityPack,commodity,speci,countryOfOrigin,billName,sign,shipMent,shipMentUser,checkAddDate,sampling,db,water,zf,freshness,sy,oxi,weight,package,avgWeight,shipper,shipperNum,billNames,contractNum,goodsNum,consi,preShip,oceanShip,navNum,agent,receipt,shipHar,unShopHar,desTi,lastDesTi,num,containNum,paper,conWeight,pakeWeight,seal,freight,freightAdd,shipName,price,forUnit,supCom,receive,receiveAdd,quaIndex,contractNums,priceMJ,FOB,CFR,codeNum,AnalysisUnit,AnalysisAddress,AnalysisWebsite,ReportingTime,Telephone,Mailbox,ReportAddress,Fax,ProductionProcess,StartingCountry,StartingCity,DestinationCountry,DestinationCity,forwardingUnit,TestTime,CheckAddress,SamplingContent,InspectionUnit,SGS_TVN,SGS_Sand,SGS_Histamine,WeighingMethod,AverageNetWeight,AverageSkinWeight,TotalWeight,TotalSkinWeight,FumigationAddress,ChemicalConcentration,FumigationDate,FumigationTime,FumigatingTemperature,Label_Antioxidant,Quote_FFA,Quote_SandSalt,Quote_Sand,ContractAntioxidant,Label_Protein,Label_Water,Label_Fat,Label_FFA,Label_SandSalt,cornerno,SgsQuantity,SgsWeight,spotEexchangeRate,port,Warehousing,Specification,Date,Band,shipmentdate)");
            strSql.Append(" values (");
            strSql.Append("@code,@codeNumContract,@fishId,@quaIden,@commodityTons,@commodityPack,@commodity,@speci,@countryOfOrigin,@billName,@sign,@shipMent,@shipMentUser,@checkAddDate,@sampling,@db,@water,@zf,@freshness,@sy,@oxi,@weight,@package,@avgWeight,@shipper,@shipperNum,@billNames,@contractNum,@goodsNum,@consi,@preShip,@oceanShip,@navNum,@agent,@receipt,@shipHar,@unShopHar,@desTi,@lastDesTi,@num,@containNum,@paper,@conWeight,@pakeWeight,@seal,@freight,@freightAdd,@shipName,@price,@forUnit,@supCom,@receive,@receiveAdd,@quaIndex,@contractNums,@priceMJ,@FOB,@CFR,@codeNum,@AnalysisUnit,@AnalysisAddress,@AnalysisWebsite,@ReportingTime,@Telephone,Mailbox,@ReportAddress,@Fax,@ProductionProcess,@StartingCountry,@StartingCity,@DestinationCountry,@DestinationCity,@forwardingUnit,@TestTime,@CheckAddress,@SamplingContent,@InspectionUnit,@SGS_TVN,@SGS_Sand,@SGS_Histamine,@WeighingMethod,@AverageNetWeight,@AverageSkinWeight,@TotalWeight,@TotalSkinWeight,@FumigationAddress,@ChemicalConcentration,@FumigationDate,@FumigationTime,@FumigatingTemperature,@Label_Antioxidant,@Quote_FFA,@Quote_SandSalt,@Quote_Sand,@ContractAntioxidant,@Label_Protein,@Label_Water,@Label_Fat,@Label_FFA,@Label_SandSalt,@cornerno,@SgsQuantity,@SgsWeight,@spotEexchangeRate,@port,Warehousing,@Specification,@Date,@Band,@shipmentdate);select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quaIden", MySqlDbType.VarChar,225),
                    new MySqlParameter("@commodityTons", MySqlDbType.VarChar,50),
                    new MySqlParameter("@commodityPack", MySqlDbType.Decimal,11),
                    new MySqlParameter("@commodity", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.VarChar,225),
                    new MySqlParameter("@countryOfOrigin", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sign", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipMent", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipMentUser", MySqlDbType.VarChar,45),
                    new MySqlParameter("@checkAddDate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sampling", MySqlDbType.VarChar,45),
                    new MySqlParameter("@db", MySqlDbType.Decimal,45),
                    new MySqlParameter("@water", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freshness", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@oxi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@package", MySqlDbType.VarChar,45),
                    new MySqlParameter("@avgWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@shipper", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipperNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billNames", MySqlDbType.VarChar,45),
                    new MySqlParameter("@contractNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@goodsNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@consi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@preShip", MySqlDbType.VarChar,45),
                    new MySqlParameter("@oceanShip", MySqlDbType.VarChar,45),
                    new MySqlParameter("@navNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@agent", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receipt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipHar", MySqlDbType.VarChar,45),
                    new MySqlParameter("@unShopHar", MySqlDbType.VarChar,45),
                    new MySqlParameter("@desTi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@lastDesTi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@num", MySqlDbType.Decimal,10),
                    new MySqlParameter("@containNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@paper", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@pakeWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@seal", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@freightAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@forUnit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@supCom", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receive", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receiveAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quaIndex", MySqlDbType.VarChar,45),
                    new MySqlParameter("@contractNums", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMJ", MySqlDbType.Decimal,10),
                    new MySqlParameter("@FOB", MySqlDbType.Decimal,10),
                    new MySqlParameter("@CFR", MySqlDbType.Decimal,10),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),


                    new MySqlParameter("@AnalysisUnit", MySqlDbType.VarChar,100),
                    new MySqlParameter("@AnalysisAddress", MySqlDbType.VarChar,150),
                    new MySqlParameter("@AnalysisWebsite", MySqlDbType.VarChar,150),
                    new MySqlParameter("@ReportingTime", MySqlDbType.DateTime),

                new MySqlParameter("@Telephone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Mailbox", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ReportAddress", MySqlDbType.VarChar,150),
                    new MySqlParameter("@Fax", MySqlDbType.VarChar,150),
                    new MySqlParameter("@ProductionProcess", MySqlDbType.VarChar,45),
                    new MySqlParameter("@StartingCountry", MySqlDbType.VarChar,45),

                new MySqlParameter("@StartingCity", MySqlDbType.VarChar,45),
                    new MySqlParameter("@DestinationCountry", MySqlDbType.VarChar,45),
                    new MySqlParameter("@DestinationCity", MySqlDbType.VarChar,45),
                    new MySqlParameter("@forwardingUnit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@TestTime", MySqlDbType.DateTime),

                new MySqlParameter("@CheckAddress", MySqlDbType.VarChar,45),
                    new MySqlParameter("@SamplingContent", MySqlDbType.VarChar,200),
                    new MySqlParameter("@InspectionUnit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@SGS_TVN", MySqlDbType.Decimal,10),
                    new MySqlParameter("@SGS_Sand", MySqlDbType.Decimal,10),

                new MySqlParameter("@SGS_Histamine", MySqlDbType.Decimal,10),
                    new MySqlParameter("@WeighingMethod", MySqlDbType.VarChar,150),
                    new MySqlParameter("@AverageNetWeight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@AverageSkinWeight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@TotalWeight", MySqlDbType.Decimal,45),

                    new MySqlParameter("@TotalSkinWeight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@FumigationAddress", MySqlDbType.VarChar,200),
                    new MySqlParameter("@ChemicalConcentration", MySqlDbType.VarChar,200),
                    new MySqlParameter("@FumigationDate", MySqlDbType.DateTime),
                    new MySqlParameter("@FumigationTime", MySqlDbType.VarChar,45),

                    new MySqlParameter("@FumigatingTemperature", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Label_Antioxidant", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Quote_FFA", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Quote_SandSalt", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Quote_Sand", MySqlDbType.Decimal,45),

                    new MySqlParameter("@ContractAntioxidant", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_Protein", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_Water", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_Fat", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_FFA", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_SandSalt", MySqlDbType.Decimal,45),
                    new MySqlParameter("@cornerno",MySqlDbType.VarChar,45),
                    new MySqlParameter("@SgsQuantity",MySqlDbType.VarChar,45),
                    new MySqlParameter("@SgsWeight",MySqlDbType.Decimal,45),
                    new MySqlParameter("@spotEexchangeRate",MySqlDbType.VarChar,45),
                    new MySqlParameter("@port",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Warehousing",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Specification",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Date",MySqlDbType.DateTime),
                    new MySqlParameter("@Band",MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipmentdate",MySqlDbType.DateTime),
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.codeNumContract;
            parameters[2].Value = model.fishId;
            parameters[3].Value = model.quaIden;
            parameters[4].Value = model.commodityTons;
            parameters[5].Value = model.commodityPack;
            parameters[6].Value = model.commodity;
            parameters[7].Value = model.speci;
            parameters[8].Value = model.countryOfOrigin;
            parameters[9].Value = model.billName;
            parameters[10].Value = model.sign;
            parameters[11].Value = model.shipMent;
            parameters[12].Value = model.shipMentUser;
            parameters[13].Value = model.checkAddDate;
            parameters[14].Value = model.sampling;
            parameters[15].Value = model.db;
            parameters[16].Value = model.water;
            parameters[17].Value = model.zf;
            parameters[18].Value = model.freshness;
            parameters[19].Value = model.sy;
            parameters[20].Value = model.oxi;
            parameters[21].Value = model.weight;
            parameters[22].Value = model.package;
            parameters[23].Value = model.avgWeight;
            parameters[24].Value = model.shipper;
            parameters[25].Value = model.shipperNum;
            parameters[26].Value = model.billNames;
            parameters[27].Value = model.contractNum;
            parameters[28].Value = model.goodsNum;
            parameters[29].Value = model.consi;
            parameters[30].Value = model.preShip;
            parameters[31].Value = model.oceanShip;
            parameters[32].Value = model.navNum;
            parameters[33].Value = model.agent;
            parameters[34].Value = model.receipt;
            parameters[35].Value = model.shipHar;
            parameters[36].Value = model.unShopHar;
            parameters[37].Value = model.desTi;
            parameters[38].Value = model.lastDesTi;
            parameters[39].Value = model.num;
            parameters[40].Value = model.containNum;
            parameters[41].Value = model.paper;
            parameters[42].Value = model.conWeight;
            parameters[43].Value = model.pakeWeight;
            parameters[44].Value = model.seal;
            parameters[45].Value = model.freight;
            parameters[46].Value = model.freightAdd;
            parameters[47].Value = model.shipName;
            parameters[48].Value = model.price;
            parameters[49].Value = model.ForUnit;
            parameters[50].Value = model.SupCom;
            parameters[51].Value = model.Receive;
            parameters[52].Value = model.ReceiveAdd;
            parameters[53].Value = model.QuaIndex;
            parameters[54].Value = model.ContractNums;
            parameters[55].Value = model.PriceMJ;
            parameters[56].Value = model.FOB;
            parameters[57].Value = model.CFR;
            parameters[58].Value = model.codeNum;

            parameters[59].Value = model.AnalysisUnit;
            parameters[60].Value = model.AnalysisAddress;
            parameters[61].Value = model.AnalysisWebsite;
            parameters[62].Value = model.ReportingTime;
            parameters[63].Value = model.Telephone;

            parameters[64].Value = model.Mailbox;
            parameters[65].Value = model.ReportAddress;
            parameters[66].Value = model.Fax;
            parameters[67].Value = model.ProductionProcess;
            parameters[68].Value = model.StartingCountry;

            parameters[69].Value = model.StartingCity;
            parameters[70].Value = model.DestinationCountry;
            parameters[71].Value = model.DestinationCity;
            parameters[72].Value = model.ForwardingUnit;
            parameters[73].Value = model.TestTime;

            parameters[74].Value = model.CheckAddress;
            parameters[75].Value = model.SamplingContent;
            parameters[76].Value = model.InspectionUnit;
            parameters[77].Value = model.SGS_TVN;
            parameters[78].Value = model.SGS_Sand;

            parameters[79].Value = model.SGS_Histamine;
            parameters[80].Value = model.WeighingMethod;
            parameters[81].Value = model.AverageNetWeight;
            parameters[82].Value = model.AverageSkinWeight;
            parameters[83].Value = model.TotalWeight;

            parameters[84].Value = model.TotalSkinWeight;
            parameters[85].Value = model.FumigationAddress;
            parameters[86].Value = model.ChemicalConcentration;
            parameters[87].Value = model.FumigationDate;
            parameters[88].Value = model.FumigationTime;

            parameters[89].Value = model.FumigatingTemperature;
            parameters[90].Value = model.Label_Antioxidant;
            parameters[91].Value = model.Quote_FFA;
            parameters[92].Value = model.Quote_SandSalt;
            parameters[93].Value = model.Quote_Sand;

            parameters[94].Value = model.ContractAntioxidant;
            parameters[95].Value = model.Label_Protein;
            parameters[96].Value = model.Label_Water;
            parameters[97].Value = model.Label_Fat;
            parameters[98].Value = model.Label_FFA;
            parameters[99].Value = model.Label_SandSalt;

            parameters[100].Value = model.cornerno;
            parameters[101].Value = model.SgsQuantity;
            parameters[102].Value = model.SgsWeight;
            parameters[103].Value = model.spotEexchangeRate;
            parameters[104].Value = model.port;
            parameters[105].Value = model.Warehousing;
            parameters[106].Value = model.Specification;
            parameters[107].Value = model.Date;
            parameters[108].Value = model.Band;
            parameters[109].Value = model.shipmentdate;


            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            if (id > 0)
            {
                ;//回写
                //if (dicPic != null && dicPic.Count > 0)
                //{
                //    foreach (FishEntity.PicInfoAll entity in dicPic)
                //    {
                //        entity.tableId = id;
                //        addImage(SQLString, strSql, entity);//新增图片
                //    }
                //}
                if (FishUpdate(SQLString, strSql, model)==true) { 
                    return 1;
                }
                else
                    return -1;
            }
            else
                return 0;
        }
        public int Add(string id,List<FishEntity.PicInfoAll> dicPic, string name)
        {
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();
                if (dicPic != null && dicPic.Count > 0)
                {
                    foreach (FishEntity.PicInfoAll entity in dicPic)
                    {
                        entity.tableId =int.Parse(id);
                        addImage(SQLString, strSql, entity);//新增图片
                    }
                }
                if (MySqlHelper.ExecuteSqlTran(SQLString))
                {
                    return int.Parse(id);
                }
                else
                    return -1;
        }

        void addImage(Hashtable SQLString, StringBuilder strSql, FishEntity.PicInfoAll model)
        {
            strSql = new StringBuilder();
            strSql.Append("insert into t_picinfoall(");
            strSql.Append("tableId,tableName,picInfo,categroy,remark)");
            strSql.Append(" values (");
            strSql.Append("@tableId,@tableName,@picInfo,@categroy,@remark)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tableId", MySqlDbType.Int32,11),
                    new MySqlParameter("@tableName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@picInfo", MySqlDbType.LongBlob),
                    new MySqlParameter("@categroy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,45)
            };
            parameters[0].Value = model.tableId;
            parameters[1].Value = model.tableName;
            parameters[2].Value = model.picInfo;
            parameters[3].Value = model.categroy;
            parameters[4].Value = model.remark;
            SQLString.Add(strSql, parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(FishEntity.WarehouseReceiptEntity model, string tableName)
        {
            int result = 0;
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_warehousereceipt set ");
            strSql.Append("codeNum=@codeNum,");
            strSql.Append("codeNumContract=@codeNumContract,");
            strSql.Append("fishId=@fishId,");
            strSql.Append("quaIden=@quaIden,");
            strSql.Append("commodityTons=@commodityTons,");
            strSql.Append("commodityPack=@commodityPack,");
            strSql.Append("commodity=@commodity,");
            strSql.Append("speci=@speci,");
            strSql.Append("countryOfOrigin=@countryOfOrigin,");
            strSql.Append("billName=@billName,");
            strSql.Append("sign=@sign,");
            strSql.Append("shipMent=@shipMent,");
            strSql.Append("shipMentUser=@shipMentUser,");
            strSql.Append("checkAddDate=@checkAddDate,");
            strSql.Append("sampling=@sampling,");
            strSql.Append("db=@db,");
            strSql.Append("water=@water,");
            strSql.Append("zf=@zf,");
            strSql.Append("freshness=@freshness,");
            strSql.Append("sy=@sy,");
            strSql.Append("oxi=@oxi,");
            strSql.Append("weight=@weight,");
            strSql.Append("package=@package,");
            strSql.Append("avgWeight=@avgWeight,");
            strSql.Append("shipper=@shipper,");
            strSql.Append("shipperNum=@shipperNum,");
            strSql.Append("billNames=@billNames,");
            strSql.Append("contractNum=@contractNum,");
            strSql.Append("goodsNum=@goodsNum,");
            strSql.Append("consi=@consi,");
            strSql.Append("preShip=@preShip,");
            strSql.Append("oceanShip=@oceanShip,");
            strSql.Append("navNum=@navNum,");
            strSql.Append("agent=@agent,");
            strSql.Append("receipt=@receipt,");
            strSql.Append("shipHar=@shipHar,");
            strSql.Append("unShopHar=@unShopHar,");
            strSql.Append("desTi=@desTi,");
            strSql.Append("lastDesTi=@lastDesTi,");
            strSql.Append("num=@num,");
            strSql.Append("containNum=@containNum,");
            strSql.Append("paper=@paper,");
            strSql.Append("conWeight=@conWeight,");
            strSql.Append("pakeWeight=@pakeWeight,");
            strSql.Append("seal=@seal,");
            strSql.Append("freight=@freight,");
            strSql.Append("freightAdd=@freightAdd,");
            strSql.Append("shipName=@shipName,");
            strSql.Append("price=@price,");
            strSql.Append("forUnit=@forUnit,");
            strSql.Append("supCom=@supCom,");
            strSql.Append("receive=@receive,");
            strSql.Append("receiveAdd=@receiveAdd,");
            strSql.Append("quaIndex=@quaIndex,");
            strSql.Append("contractNums=@contractNums,");
            strSql.Append("priceMJ=@priceMJ,");
            strSql.Append("FOB=@FOB,");
            strSql.Append("CFR=@CFR,");

            strSql.Append("AnalysisUnit=@AnalysisUnit,");
            strSql.Append("AnalysisAddress=@AnalysisAddress,");
            strSql.Append("AnalysisWebsite=@AnalysisWebsite,");
            strSql.Append("ReportingTime=@ReportingTime,");
            strSql.Append("Telephone=@Telephone,");
            strSql.Append("Mailbox=@Mailbox,");
            strSql.Append("ReportAddress=@ReportAddress,");
            strSql.Append("Fax=@Fax,");

            strSql.Append("ProductionProcess=@ProductionProcess,");
            strSql.Append("StartingCountry=@StartingCountry,");
            strSql.Append("StartingCity=@StartingCity,");
            strSql.Append("DestinationCountry=@DestinationCountry,");
            strSql.Append("DestinationCity=@DestinationCity,");
            strSql.Append("forwardingUnit=@forwardingUnit,");
            strSql.Append("TestTime=@TestTime,");
            strSql.Append("CheckAddress=@CheckAddress,");

            strSql.Append("SamplingContent=@SamplingContent,");
            strSql.Append("InspectionUnit=@InspectionUnit,");
            strSql.Append("SGS_TVN=@SGS_TVN,");
            strSql.Append("SGS_Sand=@SGS_Sand,");
            strSql.Append("SGS_Histamine=@SGS_Histamine,");
            strSql.Append("WeighingMethod=@WeighingMethod,");
            strSql.Append("AverageNetWeight=@AverageNetWeight,");
            strSql.Append("AverageSkinWeight=@AverageSkinWeight,");

            strSql.Append("TotalWeight=@TotalWeight,");
            strSql.Append("TotalSkinWeight=@TotalSkinWeight,");
            strSql.Append("FumigationAddress=@FumigationAddress,");
            strSql.Append("ChemicalConcentration=@ChemicalConcentration,");
            strSql.Append("FumigationDate=@FumigationDate,");
            strSql.Append("FumigationTime=@FumigationTime,");

            strSql.Append("cornerno=@cornerno,");
            strSql.Append("SgsQuantity=@SgsQuantity,");
            strSql.Append("SgsWeight=@SgsWeight,");
            strSql.Append("spotEexchangeRate=@spotEexchangeRate,");
            strSql.Append("port=@port,");
            strSql.Append("Warehousing=@Warehousing,");
            strSql.Append("Specification=@Specification,");
            strSql.Append("Date=@Date,");
            strSql.Append("Band=@Band,");
            strSql.Append("shipmentdate=@shipmentdate,");

            strSql.Append("FumigatingTemperature=@FumigatingTemperature,");
            strSql.Append("Label_Antioxidant=@Label_Antioxidant,");

            strSql.Append("Quote_FFA=@Quote_FFA,");
            strSql.Append("Quote_SandSalt=@Quote_SandSalt,");
            strSql.Append("Quote_Sand=@Quote_Sand,");
            strSql.Append("ContractAntioxidant=@ContractAntioxidant,");
            strSql.Append("Label_Protein=@Label_Protein,");
            strSql.Append("Label_Water=@Label_Water,");
            strSql.Append("Label_Fat=@Label_Fat,");
            strSql.Append("Label_FFA=@Label_FFA,");
            strSql.Append("Label_SandSalt=@Label_SandSalt");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quaIden", MySqlDbType.VarChar,225),
                    new MySqlParameter("@commodityTons", MySqlDbType.VarChar,50),
                    new MySqlParameter("@commodityPack", MySqlDbType.Decimal,11),
                    new MySqlParameter("@commodity", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.VarChar,225),
                    new MySqlParameter("@countryOfOrigin", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sign", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipMent", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipMentUser", MySqlDbType.VarChar,45),
                    new MySqlParameter("@checkAddDate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sampling", MySqlDbType.VarChar,45),
                    new MySqlParameter("@db", MySqlDbType.Decimal,45),
                    new MySqlParameter("@water", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freshness", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@oxi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@package", MySqlDbType.VarChar,45),
                    new MySqlParameter("@avgWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@shipper", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipperNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billNames", MySqlDbType.VarChar,45),
                    new MySqlParameter("@contractNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@goodsNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@consi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@preShip", MySqlDbType.VarChar,45),
                    new MySqlParameter("@oceanShip", MySqlDbType.VarChar,45),
                    new MySqlParameter("@navNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@agent", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receipt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipHar", MySqlDbType.VarChar,45),
                    new MySqlParameter("@unShopHar", MySqlDbType.VarChar,45),
                    new MySqlParameter("@desTi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@lastDesTi", MySqlDbType.VarChar,45),
                    new MySqlParameter("@num", MySqlDbType.Decimal,10),
                    new MySqlParameter("@containNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@paper", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@pakeWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@seal", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@freightAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@forUnit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@supCom", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receive", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receiveAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quaIndex", MySqlDbType.VarChar,45),
                    new MySqlParameter("@contractNums", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMJ", MySqlDbType.Decimal,10),
                    new MySqlParameter("@FOB", MySqlDbType.Decimal,10),
                    new MySqlParameter("@CFR", MySqlDbType.Decimal,10),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),

                    new MySqlParameter("@AnalysisUnit", MySqlDbType.VarChar,100),
                    new MySqlParameter("@AnalysisAddress", MySqlDbType.VarChar,150),
                    new MySqlParameter("@AnalysisWebsite", MySqlDbType.VarChar,150),
                    new MySqlParameter("@ReportingTime", MySqlDbType.DateTime),

                new MySqlParameter("@Telephone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Mailbox", MySqlDbType.VarChar,100),
                    new MySqlParameter("@ReportAddress", MySqlDbType.VarChar,150),
                    new MySqlParameter("@Fax", MySqlDbType.VarChar,150),
                    new MySqlParameter("@ProductionProcess", MySqlDbType.VarChar,45),
                    new MySqlParameter("@StartingCountry", MySqlDbType.VarChar,45),

                new MySqlParameter("@StartingCity", MySqlDbType.VarChar,45),
                    new MySqlParameter("@DestinationCountry", MySqlDbType.VarChar,45),
                    new MySqlParameter("@DestinationCity", MySqlDbType.VarChar,45),
                    new MySqlParameter("@forwardingUnit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@TestTime", MySqlDbType.DateTime),

                new MySqlParameter("@CheckAddress", MySqlDbType.VarChar,45),
                    new MySqlParameter("@SamplingContent", MySqlDbType.VarChar,200),
                    new MySqlParameter("@InspectionUnit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@SGS_TVN", MySqlDbType.Decimal,10),
                    new MySqlParameter("@SGS_Sand", MySqlDbType.Decimal,10),

                new MySqlParameter("@SGS_Histamine", MySqlDbType.Decimal,10),
                    new MySqlParameter("@WeighingMethod", MySqlDbType.VarChar,150),
                    new MySqlParameter("@AverageNetWeight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@AverageSkinWeight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@TotalWeight", MySqlDbType.Decimal,45),

                    new MySqlParameter("@TotalSkinWeight", MySqlDbType.Decimal,45),
                    new MySqlParameter("@FumigationAddress", MySqlDbType.VarChar,200),
                    new MySqlParameter("@ChemicalConcentration", MySqlDbType.VarChar,200),
                    new MySqlParameter("@FumigationDate", MySqlDbType.DateTime),
                    new MySqlParameter("@FumigationTime", MySqlDbType.VarChar,45),

                    new MySqlParameter("@FumigatingTemperature", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Label_Antioxidant", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Quote_FFA", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Quote_SandSalt", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Quote_Sand", MySqlDbType.Decimal,45),

                    new MySqlParameter("@ContractAntioxidant", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_Protein", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_Water", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_Fat", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_FFA", MySqlDbType.Decimal,45),
                    new MySqlParameter("@Label_SandSalt", MySqlDbType.Decimal,45),


            new MySqlParameter("@cornerno", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@SgsQuantity", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@SgsWeight", MySqlDbType.Decimal, 45),
                    new MySqlParameter("@spotEexchangeRate", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@port", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@Warehousing", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@Specification", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@Date", MySqlDbType.DateTime),
                    new MySqlParameter("@Band", MySqlDbType.VarChar, 45),
                    new MySqlParameter("@shipmentdate", MySqlDbType.DateTime),
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.codeNumContract;
            parameters[2].Value = model.fishId;
            parameters[3].Value = model.quaIden;
            parameters[4].Value = model.commodityTons;
            parameters[5].Value = model.commodityPack;
            parameters[6].Value = model.commodity;
            parameters[7].Value = model.speci;
            parameters[8].Value = model.countryOfOrigin;
            parameters[9].Value = model.billName;
            parameters[10].Value = model.sign;
            parameters[11].Value = model.shipMent;
            parameters[12].Value = model.shipMentUser;
            parameters[13].Value = model.checkAddDate;
            parameters[14].Value = model.sampling;
            parameters[15].Value = model.db;
            parameters[16].Value = model.water;
            parameters[17].Value = model.zf;
            parameters[18].Value = model.freshness;
            parameters[19].Value = model.sy;
            parameters[20].Value = model.oxi;
            parameters[21].Value = model.weight;
            parameters[22].Value = model.package;
            parameters[23].Value = model.avgWeight;
            parameters[24].Value = model.shipper;
            parameters[25].Value = model.shipperNum;
            parameters[26].Value = model.billNames;
            parameters[27].Value = model.contractNum;
            parameters[28].Value = model.goodsNum;
            parameters[29].Value = model.consi;
            parameters[30].Value = model.preShip;
            parameters[31].Value = model.oceanShip;
            parameters[32].Value = model.navNum;
            parameters[33].Value = model.agent;
            parameters[34].Value = model.receipt;
            parameters[35].Value = model.shipHar;
            parameters[36].Value = model.unShopHar;
            parameters[37].Value = model.desTi;
            parameters[38].Value = model.lastDesTi;
            parameters[39].Value = model.num;
            parameters[40].Value = model.containNum;
            parameters[41].Value = model.paper;
            parameters[42].Value = model.conWeight;
            parameters[43].Value = model.pakeWeight;
            parameters[44].Value = model.seal;
            parameters[45].Value = model.freight;
            parameters[46].Value = model.freightAdd;
            parameters[47].Value = model.shipName;
            parameters[48].Value = model.price;
            parameters[49].Value = model.ForUnit;
            parameters[50].Value = model.SupCom;
            parameters[51].Value = model.Receive;
            parameters[52].Value = model.ReceiveAdd;
            parameters[53].Value = model.QuaIndex;
            parameters[54].Value = model.ContractNums;
            parameters[55].Value = model.PriceMJ;
            parameters[56].Value = model.FOB;
            parameters[57].Value = model.CFR;
            parameters[58].Value = model.codeNum;


            parameters[59].Value = model.AnalysisUnit;
            parameters[60].Value = model.AnalysisAddress;
            parameters[61].Value = model.AnalysisWebsite;
            parameters[62].Value = model.ReportingTime;
            parameters[63].Value = model.Telephone;

            parameters[64].Value = model.Mailbox;
            parameters[65].Value = model.ReportAddress;
            parameters[66].Value = model.Fax;
            parameters[67].Value = model.ProductionProcess;
            parameters[68].Value = model.StartingCountry;

            parameters[69].Value = model.StartingCity;
            parameters[70].Value = model.DestinationCountry;
            parameters[71].Value = model.DestinationCity;
            parameters[72].Value = model.ForwardingUnit;
            parameters[73].Value = model.TestTime;

            parameters[74].Value = model.CheckAddress;
            parameters[75].Value = model.SamplingContent;
            parameters[76].Value = model.InspectionUnit;
            parameters[77].Value = model.SGS_TVN;
            parameters[78].Value = model.SGS_Sand;

            parameters[79].Value = model.SGS_Histamine;
            parameters[80].Value = model.WeighingMethod;
            parameters[81].Value = model.AverageNetWeight;
            parameters[82].Value = model.AverageSkinWeight;
            parameters[83].Value = model.TotalWeight;

            parameters[84].Value = model.TotalSkinWeight;
            parameters[85].Value = model.FumigationAddress;
            parameters[86].Value = model.ChemicalConcentration;
            parameters[87].Value = model.FumigationDate;
            parameters[88].Value = model.FumigationTime;

            parameters[89].Value = model.FumigatingTemperature;
            parameters[90].Value = model.Label_Antioxidant;
            parameters[91].Value = model.Quote_FFA;
            parameters[92].Value = model.Quote_SandSalt;
            parameters[93].Value = model.Quote_Sand;

            parameters[94].Value = model.ContractAntioxidant;
            parameters[95].Value = model.Label_Protein;
            parameters[96].Value = model.Label_Water;
            parameters[97].Value = model.Label_Fat;
            parameters[98].Value = model.Label_FFA;
            parameters[99].Value = model.Label_SandSalt;
            parameters[100].Value = model.cornerno;
            parameters[101].Value = model.SgsQuantity;
            parameters[102].Value = model.SgsWeight;
            parameters[103].Value = model.spotEexchangeRate;
            parameters[104].Value = model.port;
            parameters[105].Value = model.Warehousing;
            parameters[106].Value = model.Specification;
            parameters[107].Value = model.Date;
            parameters[108].Value = model.Band;
            parameters[109].Value = model.shipmentdate;



            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                    if (FishUpdate(SQLString, strSql, model)==true)
                    {
                        return 1;
                    }
                    else
                        return 0;
            }
            else
                result = 0;

            return result;
        }
        public int Update(string id, List<FishEntity.PicInfoAll> dicPic, string tableName)
        {
            int result = 0;
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();
                strSql = new StringBuilder();
                strSql.AppendFormat("DELETE FROM t_picinfoall WHERE tableId={0} and tableName='{1}'", int.Parse(id), tableName);
                if (MySqlHelper.ExecuteSql(strSql.ToString()) > 0)
                {
                    foreach (FishEntity.PicInfoAll entity in dicPic)
                    {
                    entity.tableId =int.Parse(id);
                        addImage(SQLString, strSql, entity);
                    }
                }
                else
                    result = -1;

                if (MySqlHelper.ExecuteSqlTran(SQLString))
                    result = 1;
                else
                    result = -1;

            return result;
        }
        bool FishUpdate(Hashtable SQLString, StringBuilder strSql, FishEntity.WarehouseReceiptEntity list)
        {
            strSql= new StringBuilder();
            //commodityTons,ProductionProcess,CountryOfOrigin,Quote_FFA,Quote_SandSalt,Quote_Sand,db,water,zf,freshness,sy,SGS_TVN,SGS_Sand,SGS_Histamine,Label_Protein ,Label_Water,Label_Fat,Label_FFA,Label_SandSalt
            strSql.AppendFormat("UPDATE t_product SET ");
            strSql.AppendFormat("name='" + list.commodityTons + "',");
            strSql.AppendFormat("techtype='" + list.ProductionProcess + "',");
            strSql.AppendFormat("cornerno='" + list.cornerno + "',");
            strSql.AppendFormat("port='" + list.port + "',");
            strSql.AppendFormat("Specification='" + list.Specification + "',");
            strSql.AppendFormat("brand='" + list.Band + "',");
            strSql.AppendFormat("nature='" + list.countryOfOrigin + "',");
            strSql.AppendFormat("sgs_protein=" + list.db + ",");
            strSql.AppendFormat("sgs_water=" + list.water + ",");
            strSql.AppendFormat("sgs_fat=" + list.zf + ",");
            strSql.AppendFormat("sgs_sandsalt=" + list.sy + ",");
            strSql.AppendFormat("sgs_tvn=" + list.SGS_TVN + ",");
            strSql.AppendFormat("sgs_sand=" + list.SGS_Sand + ",");
            strSql.AppendFormat("sgs_amine=" + list.SGS_Histamine + ",");
            strSql.AppendFormat("label_protein=" + list.Label_Protein + ",");
            strSql.AppendFormat("labe_water=" + list.Label_Water + ",");
            strSql.AppendFormat("label_fat=" + list.Label_Fat + ",");
            strSql.AppendFormat("label_ffa=" + list.Label_FFA + ",");
            strSql.AppendFormat("label_sandsalt=" + list.Label_SandSalt + " ");
            strSql.AppendFormat("WHERE code='" + list.fishId + "'");
            int rows = MySqlHelper.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                StringBuilder strsqlex = new StringBuilder();
                strsqlex.AppendFormat("UPDATE t_productex set ");
                strsqlex.AppendFormat("spotEexchangeRate='" + list.spotEexchangeRate + "',"); 
                strsqlex.AppendFormat("spotstoragedate='" + list.Date + "',");
                strsqlex.AppendFormat("confirmsgsquantity='" + list.SgsQuantity + "',");
                strsqlex.AppendFormat("confirmsgsweight='" + list.SgsWeight + "',");
                strsqlex.AppendFormat("spotweight='" + list.ContractAntioxidant + "',");
                strsqlex.AppendFormat("confirmsaildate='" + list.shipmentdate + "' ");
                strsqlex.AppendFormat("WHERE id = (select id from t_product where code ='"+ list.fishId + "' )");
                if (MySqlHelper.ExecuteSql(strsqlex.ToString())>0)
                {
                    return true;
                }
                else
                {

                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id, string tableName, string code)
        {
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_warehousereceipt ");
            strSql.AppendFormat(" where id={0}", id);
            SQLString.Add(strSql.ToString(), null);
            strSql = new StringBuilder();
            strSql.AppendFormat("delete from t_picinfoall where tableId={0} and tableName='{1}'", id, tableName);
            SQLString.Add(strSql.ToString(), null);
            strSql = new StringBuilder();
            strSql.AppendFormat("delete from t_review where programId='{0}' and code='{1}'", tableName, code);
            SQLString.Add(strSql.ToString(), null);

            return MySqlHelper.ExecuteSqlTran(SQLString);
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM t_WarehouseReceipt where code='{0}'", code);

            return MySqlHelper.Exists(strSql.ToString());
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExistsCaigou(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM t_purchaseappfishinfo where code='{0}'", code);

            return MySqlHelper.Exists(strSql.ToString());
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from t_WarehouseReceipt");

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        public FishEntity.WarehouseReceiptEntity ADDmodel(string codenum)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.AppendFormat("select codeNum,codeNumContract from t_purchaseApplication where {0} ", codenum);
            DataSet ds = MySqlHelper.Query(strsql.ToString());
            FishEntity.WarehouseReceiptEntity model = new FishEntity.WarehouseReceiptEntity();
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];
                if (row != null)
                {
                    if (row["codeNum"] != null)
                    {
                        model.codeNum = row["codeNum"].ToString();
                    }
                    if (row["codeNumContract"] != null)
                    {
                        model.codeNumContract = row["codeNumContract"].ToString();
                    }
                }
            }
            return model;
        }
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.WarehouseReceiptEntity GetModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FumigationTime,id,code,codeNumContract,codeNum,fishId,quaIden,commodityTons,commodityPack,commodity,speci,countryOfOrigin,billName,sign,shipMent,shipMentUser,checkAddDate,sampling,db,water,zf,freshness,sy,oxi,weight,package,avgWeight,shipper,shipperNum,billNames,contractNum,goodsNum,consi,preShip,oceanShip,navNum,agent,receipt,shipHar,unShopHar,desTi,lastDesTi,num,containNum,paper,conWeight,pakeWeight,seal,freight,freightAdd,shipName,price,forUnit,supCom,receive,receiveAdd,quaIndex,contractNums,priceMJ,FOB,CFR,AnalysisUnit,AnalysisAddress,AnalysisWebsite,ReportingTime,Telephone,Mailbox,ReportAddress,Fax,ProductionProcess,StartingCountry,StartingCity,DestinationCountry,DestinationCity,forwardingUnit,TestTime,CheckAddress,SamplingContent,InspectionUnit,SGS_TVN,SGS_Sand,SGS_Histamine,WeighingMethod,AverageNetWeight,AverageSkinWeight,TotalWeight,TotalSkinWeight,FumigationAddress,ChemicalConcentration,FumigationDate,FumigationTime,FumigatingTemperature,Label_Antioxidant,Quote_FFA,Quote_SandSalt,Quote_Sand,ContractAntioxidant,Label_Protein,Label_Water,Label_Fat,Label_FFA,Label_SandSalt,cornerno,SgsQuantity,SgsWeight,spotEexchangeRate,port,Warehousing,Specification,Date,Band,shipmentdate from t_warehousereceipt ");
            strSql.AppendFormat(" where {0} ", strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT id,`code`,codeNumContract,codeNum,fishId,quaIden,commodityTons,commodityPack,commodity,speci,countryOfOrigin,billName,sign,shipMent,shipMentUser,checkAddDate,sampling,db,water,zf,freshness,sy,oxi,weight,package,avgWeight,shipper,shipperNum,billNames,contractNum,goodsNum,consi,preShip,oceanShip,navNum,agent,receipt,shipHar,unShopHar,desTi,lastDesTi,num,containNum,paper,conWeight,pakeWeight,seal,freight,freightAdd,shipName,price,forUnit,supCom,receive,receiveAdd,quaIndex,contractNums,priceMJ,FOB,CFR from t_warehousereceipt ");
            strSql.AppendFormat(" where {0} ", strWhere);
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            return ds.Tables[0];
        }
        public List<FishEntity.WarehouseReceiptEntity> GetModelList(string strwhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select codeNumContract,codeNum,fishId,code,commodityTons,commodityPack,commodity,shipname,billName,StartingCountry,StartingCity,DestinationCountry,DestinationCity,forwardingUnit,shipMent,shipMentUser,Label_Protein,Label_Water,Label_Fat,Label_FFA,Label_SandSalt,Label_Antioxidant,supCom,receive,receiveAdd,contractNums,priceMJ,FOB,CFR from t_warehousereceipt  "+ strwhere);
            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                List<FishEntity.WarehouseReceiptEntity> modelList = new List<FishEntity.WarehouseReceiptEntity>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FishEntity.WarehouseReceiptEntity model = new FishEntity.WarehouseReceiptEntity();
                    DataRow row = dt.Rows[i];
                    if (row != null)
                    {
                        if (row["codeNumContract"]!=null)
                        {
                            model.codeNumContract = row["codeNumContract"].ToString();
                        }
                        if (row["codeNum"] != null)
                        {
                            model.codeNum = row["codeNum"].ToString();
                        }
                        if (row["fishId"] != null)
                        {
                            model.fishId= row["fishId"].ToString();
                        }
                        if (row["code"] != null)
                        {
                            model.code = row["code"].ToString();
                        }
                        if (row["commodityTons"] != null)
                        {
                            model.commodityTons = row["commodityTons"].ToString();
                        }
                        if (row["commodityPack"] != null&&row["commodityPack"].ToString()!="")
                        {
                            model.commodityPack =decimal.Parse(row["commodityPack"].ToString());
                        }
                        if (row["commodity"] != null)
                        {
                            model.commodity = row["commodity"].ToString();
                        }

                        if (row["shipname"] != null)
                        {
                            model.shipName = row["shipname"].ToString();
                        }
                        if (row["billName"] != null)
                        {
                            model.billName = row["billName"].ToString();
                        }
                        if (row["StartingCountry"] != null)
                        {
                            model.StartingCountry = row["StartingCountry"].ToString();
                        }
                        if (row["StartingCity"] != null)
                        {
                            model.StartingCity = row["StartingCity"].ToString();
                        }
                        if (row["DestinationCountry"] != null)
                        {
                            model.DestinationCountry = row["DestinationCountry"].ToString();
                        }
                        if (row["DestinationCity"] != null)
                        {
                            model.DestinationCity = row["DestinationCity"].ToString();
                        }
                        if (row["forwardingUnit"] != null)
                        {
                            model.ForwardingUnit = row["forwardingUnit"].ToString();
                        }

                        if (row["shipMent"] != null)
                        {
                            model.shipMent = row["shipMent"].ToString();
                        }
                        if (row["shipMentUser"] != null)
                        {
                            model.shipMentUser = row["shipMentUser"].ToString();
                        }
                        if (row["Label_Protein"] != null&& row["Label_Protein"].ToString()!="")
                        {
                            model.Label_Protein =decimal.Parse(row["Label_Protein"].ToString());
                        }
                        if (row["Label_Water"] != null&& row["Label_Water"].ToString()!="")
                        {
                            model.Label_Water =decimal.Parse(row["Label_Water"].ToString());
                        }
                        if (row["Label_Fat"] != null&&row["Label_Fat"].ToString()!="")
                        {
                            model.Label_Fat =decimal.Parse( row["Label_Fat"].ToString());
                        }
                        if (row["Label_FFA"] != null && row["Label_FFA"].ToString() != "")
                        {
                            model.Label_FFA =decimal.Parse( row["Label_FFA"].ToString());
                        }
                        if (row["Label_SandSalt"] != null && row["Label_SandSalt"].ToString() != "")
                        {
                            model.Label_SandSalt =decimal.Parse( row["Label_SandSalt"].ToString());
                        }

                        if (row["Label_Antioxidant"] != null&&row["Label_Antioxidant"].ToString()!="")
                        {
                            model.Label_Antioxidant =decimal.Parse( row["Label_Antioxidant"].ToString());
                        }
                        if (row["supCom"] != null)
                        {
                            model.SupCom =row["supCom"].ToString();
                        }
                        if (row["receive"] != null)
                        {
                            model.Receive = row["receive"].ToString();
                        }
                        if (row["receiveAdd"] != null)
                        {
                            model.ReceiveAdd = row["receiveAdd"].ToString();
                        }
                        if (row["contractNums"] != null)
                        {
                            model.ContractNums = row["contractNums"].ToString();
                        }
                        if (row["priceMJ"] != null&& row["priceMJ"].ToString()!="")
                        {
                            model.PriceMJ =decimal.Parse( row["priceMJ"].ToString());
                        }
                        if (row["FOB"] != null&& row["FOB"].ToString()!="")
                        {
                            model.FOB =decimal.Parse( row["FOB"].ToString());
                        }

                        if (row["CFR"] != null&& row["CFR"].ToString()!="")
                        {
                            model.CFR =decimal.Parse( row["CFR"].ToString());
                        }
                        modelList.Add(model);
                    }
                }
                return modelList;
            }
            else
                return null;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.WarehouseReceiptEntity DataRowToModel(DataRow row)
        {
            FishEntity.WarehouseReceiptEntity model = new FishEntity.WarehouseReceiptEntity();
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
                if (row["codeNumContract"] != null)
                {
                    model.codeNumContract = row["codeNumContract"].ToString();
                }
                if (row["codeNum"] != null)
                {
                    model.codeNum = row["codeNum"].ToString();
                }
                if (row["fishId"] != null)
                {
                    model.fishId = row["fishId"].ToString();
                }
                if (row["quaIden"] != null)
                {
                    model.quaIden = row["quaIden"].ToString();
                }
                if (row["commodityTons"] != null )
                {
                    model.commodityTons = row["commodityTons"].ToString();
                }
                if (row["commodityPack"] != null && row["commodityPack"].ToString() != "")
                {
                    model.commodityPack = decimal.Parse(row["commodityPack"].ToString());
                }
                if (row["commodity"] != null)
                {
                    model.commodity = row["commodity"].ToString();
                }
                if (row["speci"] != null)
                {
                    model.speci = row["speci"].ToString();
                }
                if (row["countryOfOrigin"] != null)
                {
                    model.countryOfOrigin = row["countryOfOrigin"].ToString();
                }
                if (row["billName"] != null)
                {
                    model.billName = row["billName"].ToString();
                }
                if (row["sign"] != null)
                {
                    model.sign = row["sign"].ToString();
                }
                if (row["shipMent"] != null)
                {
                    model.shipMent = row["shipMent"].ToString();
                }
                if (row["shipMentUser"] != null)
                {
                    model.shipMentUser = row["shipMentUser"].ToString();
                }
                if (row["checkAddDate"] != null)
                {
                    model.checkAddDate = row["checkAddDate"].ToString();
                }
                if (row["sampling"] != null)
                {
                    model.sampling = row["sampling"].ToString();
                }
                if (row["db"] != null&&row["db"].ToString() !="")
                {
                    model.db =decimal.Parse( row["db"].ToString());
                }
                if (row["water"] != null && row["water"].ToString() != "")
                {
                    model.water =decimal.Parse( row["water"].ToString());
                }
                if (row["zf"] != null && row["zf"].ToString() != "")
                {
                    model.zf =decimal.Parse( row["zf"].ToString());
                }
                if (row["freshness"] != null && row["freshness"].ToString() != "")
                {
                    model.freshness =decimal.Parse( row["freshness"].ToString());
                }
                if (row["sy"] != null && row["sy"].ToString() != "")
                {
                    model.sy =decimal.Parse( row["sy"].ToString());
                }
                if (row["oxi"] != null)
                {
                    model.oxi = row["oxi"].ToString();
                }
                if (row["weight"] != null && row["weight"].ToString() != "")
                {
                    model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["package"] != null)
                {
                    model.package = row["package"].ToString();
                }
                if (row["avgWeight"] != null && row["avgWeight"].ToString() != "")
                {
                    model.avgWeight = decimal.Parse(row["avgWeight"].ToString());
                }
                if (row["shipper"] != null)
                {
                    model.shipper = row["shipper"].ToString();
                }
                if (row["shipperNum"] != null)
                {
                    model.shipperNum = row["shipperNum"].ToString();
                }
                if (row["billNames"] != null)
                {
                    model.billNames = row["billNames"].ToString();
                }
                if (row["contractNum"] != null)
                {
                    model.contractNum = row["contractNum"].ToString();
                }
                if (row["goodsNum"] != null)
                {
                    model.goodsNum = row["goodsNum"].ToString();
                }
                if (row["consi"] != null)
                {
                    model.consi = row["consi"].ToString();
                }
                if (row["preShip"] != null)
                {
                    model.preShip = row["preShip"].ToString();
                }
                if (row["oceanShip"] != null)
                {
                    model.oceanShip = row["oceanShip"].ToString();
                }
                if (row["navNum"] != null)
                {
                    model.navNum = row["navNum"].ToString();
                }
                if (row["agent"] != null)
                {
                    model.agent = row["agent"].ToString();
                }
                if (row["receipt"] != null)
                {
                    model.receipt = row["receipt"].ToString();
                }
                if (row["shipHar"] != null)
                {
                    model.shipHar = row["shipHar"].ToString();
                }
                if (row["unShopHar"] != null)
                {
                    model.unShopHar = row["unShopHar"].ToString();
                }
                if (row["desTi"] != null)
                {
                    model.desTi = row["desTi"].ToString();
                }
                if (row["lastDesTi"] != null)
                {
                    model.lastDesTi = row["lastDesTi"].ToString();
                }
                if (row["num"] != null && row["num"].ToString() != "")
                {
                    model.num = decimal.Parse(row["num"].ToString());
                }
                if (row["containNum"] != null)
                {
                    model.containNum = row["containNum"].ToString();
                }
                if (row["paper"] != null)
                {
                    model.paper = row["paper"].ToString();
                }
                if (row["conWeight"] != null && row["conWeight"].ToString() != "")
                {
                    model.conWeight = decimal.Parse(row["conWeight"].ToString());
                }
                if (row["pakeWeight"] != null && row["pakeWeight"].ToString() != "")
                {
                    model.pakeWeight = decimal.Parse(row["pakeWeight"].ToString());
                }
                if (row["seal"] != null)
                {
                    model.seal = row["seal"].ToString();
                }
                if (row["freight"] != null && row["freight"].ToString() != "")
                {
                    model.freight = decimal.Parse(row["freight"].ToString());
                }
                if (row["freightAdd"] != null)
                {
                    model.freightAdd = row["freightAdd"].ToString();
                }
                if (row["shipName"] != null)
                {
                    model.shipName = row["shipName"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["forUnit"] != null)
                {
                    model.ForUnit = row["forUnit"].ToString();
                }
                if (row["supCom"] != null)
                {
                    model.SupCom = row["supCom"].ToString();
                }
                if (row["receive"] != null)
                {
                    model.Receive = row["receive"].ToString();
                }
                if (row["receiveAdd"] != null)
                {
                    model.ReceiveAdd = row["receiveAdd"].ToString();
                }
                if (row["quaIndex"] != null)
                {
                    model.QuaIndex = row["quaIndex"].ToString();
                }
                if (row["contractNums"] != null)
                {
                    model.ContractNums = row["contractNums"].ToString();
                }
                if (row["priceMJ"] != null && row["priceMJ"].ToString() != "")
                {
                    model.PriceMJ = decimal.Parse(row["priceMJ"].ToString());
                }
                if (row["FOB"] != null && row["FOB"].ToString() != "")
                {
                    model.FOB = decimal.Parse(row["FOB"].ToString());
                }
                if (row["CFR"] != null && row["CFR"].ToString() != "")
                {
                    model.CFR = decimal.Parse(row["CFR"].ToString());
                }
                ////11111111111111111111111111111
                if (row["AnalysisUnit"] != null)
                {
                    model.AnalysisUnit = row["AnalysisUnit"].ToString();
                }
                if (row["AnalysisAddress"] != null)
                {
                    model.AnalysisAddress = row["AnalysisAddress"].ToString();
                }
                if (row["AnalysisWebsite"] != null)
                {
                    model.AnalysisWebsite = row["AnalysisWebsite"].ToString();
                }
                if (row["ReportingTime"] != null && row["ReportingTime"].ToString() != "")
                {
                    model.ReportingTime = DateTime.Parse(row["ReportingTime"].ToString());
                }
                if (row["Telephone"] != null)
                {
                    model.Telephone = row["Telephone"].ToString();
                }
                if (row["Mailbox"] != null)
                {
                    model.Mailbox = row["Mailbox"].ToString();
                }
                if (row["ReportAddress"] != null)
                {
                    model.ReportAddress = row["ReportAddress"].ToString();
                }
                if (row["Fax"] != null)
                {
                    model.Fax = row["Fax"].ToString();
                }
                if (row["ProductionProcess"] != null)
                {
                    model.ProductionProcess = row["ProductionProcess"].ToString();
                }
                if (row["StartingCountry"] != null)
                {
                    model.StartingCountry = row["StartingCountry"].ToString();
                }
                if (row["StartingCity"] != null)
                {
                    model.StartingCity = row["StartingCity"].ToString();
                }
                if (row["DestinationCountry"] != null)
                {
                    model.DestinationCountry = row["DestinationCountry"].ToString();
                }
                if (row["DestinationCity"] != null)
                {
                    model.DestinationCity = row["DestinationCity"].ToString();
                }
                if (row["forwardingUnit"] != null)
                {
                    model.ForwardingUnit = row["forwardingUnit"].ToString();
                }
                if (row["TestTime"] != null && row["TestTime"].ToString() != "")
                {
                    model.TestTime = DateTime.Parse(row["TestTime"].ToString());
                }
                if (row["CheckAddress"] != null)
                {
                    model.CheckAddress = row["CheckAddress"].ToString();
                }
                if (row["SamplingContent"] != null)
                {
                    model.SamplingContent = row["SamplingContent"].ToString();
                }
                if (row["InspectionUnit"] != null)
                {
                    model.InspectionUnit = row["InspectionUnit"].ToString();
                }
                if (row["SGS_TVN"] != null && row["SGS_TVN"].ToString() != "")
                {
                    model.SGS_TVN = decimal.Parse(row["SGS_TVN"].ToString());
                }
                if (row["SGS_Sand"] != null && row["SGS_Sand"].ToString() != "")
                {
                    model.SGS_Sand = decimal.Parse(row["SGS_Sand"].ToString());
                }
                if (row["SGS_Histamine"] != null && row["SGS_Histamine"].ToString() != "")
                {
                    model.SGS_Histamine = decimal.Parse(row["SGS_Histamine"].ToString());
                }
                if (row["WeighingMethod"] != null)
                {
                    model.WeighingMethod = row["WeighingMethod"].ToString();
                }
                if (row["AverageNetWeight"] != null && row["AverageNetWeight"].ToString() != "")
                {
                    model.AverageNetWeight = decimal.Parse(row["AverageNetWeight"].ToString());
                }
                if (row["AverageSkinWeight"] != null && row["AverageSkinWeight"].ToString() != "")
                {
                    model.AverageSkinWeight = decimal.Parse(row["AverageSkinWeight"].ToString());
                }
                if (row["TotalWeight"] != null && row["TotalWeight"].ToString() != "")
                {
                    model.TotalWeight = decimal.Parse(row["TotalWeight"].ToString());
                }
                if (row["TotalSkinWeight"] != null && row["TotalSkinWeight"].ToString() != "")
                {
                    model.TotalSkinWeight = decimal.Parse(row["TotalSkinWeight"].ToString());
                }
                if (row["FumigationAddress"] != null)
                {
                    model.FumigationAddress = row["FumigationAddress"].ToString();
                }
                if (row["ChemicalConcentration"] != null)
                {
                    model.ChemicalConcentration = row["ChemicalConcentration"].ToString();
                }
                if (row["FumigationDate"] != null && row["FumigationDate"].ToString() != "")
                {
                    model.FumigationDate = DateTime.Parse(row["FumigationDate"].ToString());
                }
                if (row["FumigationTime"] != null )
                {
                    model.FumigationTime = row["FumigationTime"].ToString();
                }
                if (row["cornerno"] != null)
                {
                    model.cornerno = row["cornerno"].ToString();
                }
                if (row["SgsQuantity"] != null)
                {
                    model.SgsQuantity = row["SgsQuantity"].ToString();
                }
                if (row["SgsWeight"] != null&& row["SgsWeight"].ToString()!="")
                {
                    model.SgsWeight =decimal.Parse( row["SgsWeight"].ToString());
                }
                if (row["spotEexchangeRate"] != null)
                {
                    model.spotEexchangeRate = row["spotEexchangeRate"].ToString();
                }
                if (row["port"] != null)
                {
                    model.port = row["port"].ToString();
                }
                if (row["Warehousing"] != null)
                {
                    model.Warehousing = row["Warehousing"].ToString();
                }
                if (row["Specification"] != null)
                {
                    model.Band = row["Specification"].ToString();
                }
                if (row["Specification"] != null)
                {
                    model.Band = row["Band"].ToString();
                }
                if (row["Date"] != null && row["Date"].ToString() != "")
                {
                    model.Date = DateTime.Parse(row["Date"].ToString());
                }
                if (row["shipmentdate"] != null && row["shipmentdate"].ToString() != "")
                {
                    model.shipmentdate = DateTime.Parse(row["shipmentdate"].ToString());
                }

                if (row["FumigatingTemperature"] != null)
                {
                    model.FumigatingTemperature = row["FumigatingTemperature"].ToString();
                }
                if (row["Label_Antioxidant"] != null && row["Label_Antioxidant"].ToString() != "")
                {
                    model.Label_Antioxidant = decimal.Parse(row["Label_Antioxidant"].ToString());
                }
                if (row["Quote_FFA"] != null && row["Quote_FFA"].ToString() != "")
                {
                    model.Quote_FFA = decimal.Parse(row["Quote_FFA"].ToString());
                }
                if (row["Quote_SandSalt"] != null && row["Quote_SandSalt"].ToString() != "")
                {
                    model.Quote_SandSalt = decimal.Parse(row["Quote_SandSalt"].ToString());
                }
                if (row["Quote_Sand"] != null && row["Quote_Sand"].ToString() != "")
                {
                    model.Quote_Sand = decimal.Parse(row["Quote_Sand"].ToString());
                }
                if (row["ContractAntioxidant"] != null && row["ContractAntioxidant"].ToString() != "")
                {
                    model.ContractAntioxidant = decimal.Parse(row["ContractAntioxidant"].ToString());
                }
                if (row["Label_Protein"] != null && row["Label_Protein"].ToString() != "")
                {
                    model.Label_Protein = decimal.Parse(row["Label_Protein"].ToString());
                }
                if (row["Label_Water"] != null && row["Label_Water"].ToString() != "")
                {
                    model.Label_Water = decimal.Parse(row["Label_Water"].ToString());
                }
                if (row["Label_Fat"] != null && row["Label_Fat"].ToString() != "")
                {
                    model.Label_Fat = decimal.Parse(row["Label_Fat"].ToString());
                }
                if (row["Label_FFA"] != null && row["Label_FFA"].ToString() != "")
                {
                    model.Label_FFA = decimal.Parse(row["Label_FFA"].ToString());
                }
                if (row["Label_SandSalt"] != null && row["Label_SandSalt"].ToString() != "")
                {
                    model.Label_SandSalt = decimal.Parse(row["Label_SandSalt"].ToString());
                }
            }
            return model;
        }

        /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public List<FishEntity.PicInfoAll> GetModel(int id, string tableName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,tableId,tableName,picInfo,categroy,remark from t_picinfoall ");
            strSql.Append(" where tableId=@tableId and tableName=@tableName");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tableId", MySqlDbType.Int32),
                    new MySqlParameter("@tableName", MySqlDbType.VarChar,45)
            };
            parameters[0].Value = id;
            parameters[1].Value = tableName;

            List<FishEntity.PicInfoAll> modelList = new List<FishEntity.PicInfoAll>();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(DataRowToModelImg(dt.Rows[i]));
                }
                return modelList;
            }
            else
                return null;
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.PicInfoAll DataRowToModelImg(DataRow row)
        {
            FishEntity.PicInfoAll model = new FishEntity.PicInfoAll();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["tableId"] != null && row["tableId"].ToString() != "")
                {
                    model.tableId = int.Parse(row["tableId"].ToString());
                }
                if (row["tableName"] != null)
                {
                    model.tableName = row["tableName"].ToString();
                }
                if (row["picInfo"] != null && row["picInfo"].ToString() != "")
                    model.picInfo = (byte[])row["picInfo"];
                else
                    model.picInfo = new byte[0];
                if (row["categroy"] != null)
                {
                    model.categroy = row["categroy"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 入库申请单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists_rksqd(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_storageofrequisition where jcCode='{0}'", code);

            return MySqlHelper.Exists(strSql.ToString());
        }

    }
}
