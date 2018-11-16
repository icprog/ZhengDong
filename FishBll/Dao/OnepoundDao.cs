using System;
using System . Collections . Generic;
using System . Text;
using System . Data;
using MySql . Data . MySqlClient;
using System . Collections;

namespace FishBll.Dao
{
    public class OnepoundDao
    {
        public OnepoundDao() { }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_poundsalone");
            strSql.Append(" where id=@Id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Id", MySqlDbType.Int32)};
            parameters[0].Value = id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_poundsalone");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public bool image_Exists(string str)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_image");
            strSql.Append(" where "+str );

            return MySqlHelper.Exists(strSql.ToString(), null);
        }

        /// <summary>
        /// 是否所属
        /// </summary>
        /// <param name="code"></param>
        /// <param name="createman"></param>
        /// <returns></returns>
        public bool ExistsUpdate(string code,string createman)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) from t_poundsalone");
            strSql.Append(" where code=@code and createman=@createman");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45)
            };
            parameters[0].Value = code;
            parameters[1].Value = createman;
            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsName(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_poundsalone");
            strSql.Append(" where Serialnumber=@Serialnumber ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Serialnumber", MySqlDbType.VarChar,45)};
            parameters[0].Value = name;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 磅单
        /// </summary>
        /// <param name="getname"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity getBT(string getname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.Numbering,a.code,a.demand,a.demandId,a.Purchasingunits,a.PurchasingunitsId,b.pp,b.Country,listname,Species,Cornerno,ferryname,b.product_id from t_salesorder a inner join t_happening b on a.Numbering =b.NumberingOne inner join t_billoflading c on a.Numbering=c.Numbering ");
            strSql.Append("where a.Numbering= '" + getname + "'");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Numbering"]!=null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["product_id"]!=null)
                {
                    model.Product_id = row["product_id"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["demand"] != null)
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["demandId"] != null)
                {
                    model.demandId = row["demandId"].ToString();
                }
                if (row["Purchasingunits"]!=null)
                {
                    model.Purchasingunits = row["Purchasingunits"].ToString();
                }
                if (row["PurchasingunitsId"] != null)
                {
                    model.PurchasingunitsId = row["PurchasingunitsId"].ToString();
                }
                if (row["pp"] !=null)
                {
                    model.pp = row["pp"].ToString();
                }
                if (row["Country"]!=null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["listname"] !=null)
                {
                    model.tdh = row["listname"].ToString();
                }
                if (row["Species"] !=null)
                {
                    model.Goods = row["Species"].ToString();
                }
                if (row["Cornerno"] !=null)
                {
                    model.zjh = row["Cornerno"].ToString();
                }
                if (row["ferryname"] !=null)
                {
                    model.cm = row["ferryname"].ToString();
                }
                return model;
            }
            else {
                return null;
            }
        }
        /// <summary>
        /// 出库单
        /// </summary>
        /// <param name="getname"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity getCKD(string getname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.Numbering,a.code,a.demand,a.demandId,a.Purchasingunits,a.PurchasingunitsId,c.Brands,c.Country,c.speci,c.pageNum,c.billName,pileNum,shipName,b.product_id from t_salesorder a inner join t_happening b on a.Numbering =b.NumberingOne inner join t_outboundorder c on a.Numbering=c.codenum ");
            strSql.Append("where a.Numbering= '" + getname + "'");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Numbering"] != null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["product_id"] != null)
                {
                    model.Product_id = row["product_id"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["demand"] != null)
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["demandId"] != null)
                {
                    model.demandId = row["demandId"].ToString();
                }
                if (row["Purchasingunits"] != null)
                {
                    model.Purchasingunits = row["Purchasingunits"].ToString();
                }
                if (row["PurchasingunitsId"] != null)
                {
                    model.PurchasingunitsId = row["PurchasingunitsId"].ToString();
                }
                if (row["Brands"] != null)
                {
                    model.pp = row["Brands"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                //if (row["billName"] != null)
                //{
                //    model.Goods = row["billName"].ToString();
                //}
                if (row["speci"] != null)
                {
                    model.Pinzhi = row["speci"].ToString();
                }
                if (row["pageNum"] != null)
                {
                    model.baoshu = row["pageNum"].ToString();
                }
                if (row["pileNum"] != null)
                {
                    model.zjh = row["pileNum"].ToString();
                }
                if (row["billName"] != null)
                {
                    model.tdh = row["billName"].ToString();
                }
                
                if (row["shipName"] != null)
                {
                    model.cm = row["shipName"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public int Add(FishEntity.OnepoundEntity model,string name)
        {
            Hashtable SQLString = new Hashtable ( );

            SQLString= ReviewInfo . getSQLString ( name ,model . Code ,string . Empty ,SQLString );

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_poundsalone(");
            strSql.Append("FishMealId,Numbering,code,Dateofmanufacture,IntothefactoryDate,Carnumber,Grossweight,Tareweight,Competition,TiDanCode,RedemptionWeight,Goods,Remarks,Shipno,Owner,OwnerId,createtime,createman,modifytime,modifyman,Address,Buyers,BuyersId,Sellers,SellersId,Country,PName,Qualit,Quantity,Pileangle,BillOfLadingid,Serialnumber,codeContract)");
            strSql.Append("values(");
            strSql.Append("@FishMealId,@Numbering,@code,@Dateofmanufacture,@Intothefactorydate,@Carnumber,@Grossweight,@Tareweight,@Competition,@TiDanCode,@RedemptionWeight,@Goods,@Remarks,@Shipno,@Owner,@OwnerId,@createtime,@createman,@modifytime,@modifyman,@Address,@Buyers,@BuyersId,@Sellers,@SellersId,@Country,@PName,@Qualit,@Quantity,@Pileangle,@BillOfLadingid,@Serialnumber,@codeContract);");
            //strSql.Append("select last_insert_id();");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@Dateofmanufacture",MySqlDbType.Timestamp),
                new MySqlParameter("@IntothefactoryDate",MySqlDbType.Timestamp),
                new MySqlParameter("@Carnumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Grossweight",MySqlDbType.VarChar,45),
                new MySqlParameter("@Tareweight",MySqlDbType.VarChar,45),
                new MySqlParameter("@Competition",MySqlDbType.VarChar,45),
                new MySqlParameter("@Goods",MySqlDbType.VarChar,45),
                new MySqlParameter("@Owner",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@Address",MySqlDbType.VarChar,100),
                new MySqlParameter("@Serialnumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Buyers",MySqlDbType.VarChar,45),
                new MySqlParameter("@Sellers",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@PName",MySqlDbType.VarChar,45),
                new MySqlParameter("@Qualit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.VarChar,45),
                new MySqlParameter("@Pileangle",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingid",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@Shipno",MySqlDbType.VarChar,45),
                new MySqlParameter("@OwnerId",MySqlDbType.VarChar,45),
                new MySqlParameter("@BuyersId",MySqlDbType.VarChar,45),
                new MySqlParameter("@SellersId",MySqlDbType.VarChar,45),
                new MySqlParameter ("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50),
                new MySqlParameter("@TiDanCode",MySqlDbType.VarChar,45),
                new MySqlParameter("@RedemptionWeight",MySqlDbType.Decimal,45)
            };
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Dateofmanufacture;
            parameters[2].Value = model.IntothefactoryDate;
            parameters[3].Value = model.Carnumber;
            parameters[4].Value = model.Grossweight;
            parameters[5].Value = model.Tareweight;
            parameters[6].Value = model.Competition;
            parameters[7].Value = model.Goods;
            parameters[8].Value = model.Owner;
            parameters[9].Value = model.Createtime;
            parameters[10].Value = model.Createman;
            parameters[11].Value = model.Modifytime;
            parameters[12].Value = model.Modifyman;
            parameters[13].Value = model.Address;
            parameters[14].Value = model.Serialnumber;
            parameters[15].Value = model.Buyers;
            parameters[16].Value = model.Sellers;
            parameters[17].Value = model.Country;
            parameters[18].Value = model.PName;
            parameters[19].Value = model.Qualit;
            parameters[20].Value = model.Quantity;
            parameters[21].Value = model.Pileangle;
            parameters[22].Value = model.BillOfLadingid;
            parameters[23].Value = model.codeContract;
            parameters[24].Value = model.Remarks;
            parameters[25].Value = model.Shipno;
            parameters[26].Value = model.OwnerId;
            parameters[27].Value = model.BuyersId;
            parameters[28].Value = model.SellersId;
            parameters[29].Value = model.Numbering;
            parameters[30].Value = model.FishMealId;
            parameters[31].Value = model.TiDanCode;
            parameters[32].Value = model.RedemptionWeight;
            SQLString . Add ( strSql ,parameters );
            if ( MySqlHelper . ExecuteSqlTran ( SQLString ) )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "select id from t_poundsalone where code='{0}'" ,model . Code );

                DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
                if ( dt != null && dt . Rows . Count > 0 )
                    return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "id" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ 0 ] [ "id" ] . ToString ( ) );
                else
                    return 0;
            }
            else
                return 0;
        }
        public bool Update(FishEntity.OnepoundEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_poundsalone set ");
            strSql.Append("Dateofmanufacture = @Dateofmanufacture,");
            strSql.Append("FishMealId=@FishMealId,");
            strSql.Append("IntothefactoryDate = @IntothefactoryDate,");
            strSql.Append("Carnumber = @Carnumber,");
            strSql.Append("Grossweight = @Grossweight,");
            strSql.Append("Tareweight = @Tareweight,");
            strSql.Append("Competition = @Competition,");
            strSql.Append("TiDanCode=@TiDanCode,");
            strSql.Append("RedemptionWeight=@RedemptionWeight,");
            strSql.Append("Goods = @Goods,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("Shipno=@Shipno,");
            strSql.Append("Owner = @Owner,");
            strSql.Append("OwnerId = @OwnerId,");
            strSql.Append("modifytime = @modifytime,");
            strSql.Append("modifyman = @modifyman,");
            strSql.Append("BuyersId = @BuyersId,");
            strSql.Append("Address = @Address,code = @code,");
            strSql.Append("Serialnumber = @Serialnumber,Buyers = @Buyers,");
            strSql.Append("Sellers = @Sellers,Country = @Country,");
            strSql.Append("PName = @PName,Qualit = @Qualit,");
            strSql.Append("Quantity = @Quantity,Pileangle = @Pileangle,");
            strSql.Append("BillOfLadingid = @BillOfLadingid,");
            strSql.Append("codeContract = @codeContract, ");
            strSql.Append("SellersId = @SellersId ");
            strSql.Append(" where id = @id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@Dateofmanufacture",MySqlDbType.Timestamp),
                new MySqlParameter("@IntothefactoryDate",MySqlDbType.Timestamp),
                new MySqlParameter("@Carnumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Grossweight",MySqlDbType.VarChar,45),
                new MySqlParameter("@Tareweight",MySqlDbType.VarChar,45),
                new MySqlParameter("@Competition",MySqlDbType.VarChar,45),
                new MySqlParameter("@Goods",MySqlDbType.VarChar,45),
                new MySqlParameter("@Owner",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@Address",MySqlDbType.VarChar,100),
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@Serialnumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@Buyers",MySqlDbType.VarChar,45),
                new MySqlParameter("@Sellers",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@PName",MySqlDbType.VarChar,45),
                new MySqlParameter("@Qualit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.VarChar,45),
                new MySqlParameter("@Pileangle",MySqlDbType.VarChar,45),
                new MySqlParameter("@BillOfLadingid",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@id",MySqlDbType.Int16,11),
                new MySqlParameter("@Remarks",MySqlDbType.VarChar,500),
                new MySqlParameter("@Shipno",MySqlDbType.VarChar,45),
                new MySqlParameter("@OwnerId",MySqlDbType.VarChar,45),
                new MySqlParameter("@BuyersId",MySqlDbType.VarChar,45),
                new MySqlParameter("@SellersId",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50),
                new MySqlParameter("@TiDanCode",MySqlDbType.VarChar,45),
                new MySqlParameter("@RedemptionWeight",MySqlDbType.Decimal,45)
            };
            parameters[0].Value = model.Dateofmanufacture;
            parameters[1].Value = model.IntothefactoryDate;
            parameters[2].Value = model.Carnumber;
            parameters[3].Value = model.Grossweight;
            parameters[4].Value = model.Tareweight;
            parameters[5].Value = model.Competition;
            parameters[6].Value = model.Goods;
            parameters[7].Value = model.Owner;
            parameters[8].Value = model.Modifytime;
            parameters[9].Value = model.Modifyman;
            parameters[10].Value = model.Address;
            parameters[11].Value = model.Code;
            parameters[12].Value = model.Serialnumber;
            parameters[13].Value = model.Buyers;
            parameters[14].Value = model.Sellers;
            parameters[15].Value = model.Country;
            parameters[16].Value = model.PName;
            parameters[17].Value = model.Qualit;
            parameters[18].Value = model.Quantity;
            parameters[19].Value = model.Pileangle;
            parameters[20].Value = model.BillOfLadingid;
            parameters[21].Value = model.codeContract;
            parameters[22].Value = model.Id;
            parameters[23].Value = model.Remarks;
            parameters[24].Value = model.Shipno;
            parameters[25].Value = model.OwnerId;
            parameters[26].Value = model.BuyersId;
            parameters[27].Value = model.SellersId;
            parameters[28].Value = model.FishMealId;
            parameters[29].Value = model.TiDanCode;
            parameters[30].Value = model.RedemptionWeight;
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
