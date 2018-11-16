using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class ProductExDao
    {
        public ProductExDao()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_productex");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(FishEntity.ProductExEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_productex(");
            strSql.Append("id,quotedate,quoteweight,quotequantity,quotedollars,quotermb,quotesuppliercode,quotesupplier,quotelinkmancode,quotelinkman,quoteproductyear,quoteproductdate,quotelife,quotesaildatefast,quotesaildatelate,confirmdate,confirmsgsweight,confirmsgsquantity,confirmdollars,confirmrmb,confirmagentcode,confirmagent,confirmlinkmancode,confirmlinkman,confirmproductyear,confirmproductdate,confirmlife,confirmsaildate,spotdate,Saletime,spotweight,spotquantity,spotdollars,spotrmb,spotagentcode,spotagent,spotlinkmancode,spotlinkman,spotproductdate,spotproductyear,spotlife,spotstoragedate,saledate,saleremainweight,saleremainquantity,saledollars,salermb,SaleNumWeight,saletradercode,saletrader,salelinkmancode,salelinkman,saleoutdate,selfdate,selfstorageweight,selfstoragequantity,selfdollars,selfrmb,selftradercode,selftrader,selflinkmancode,selflinkman,selffinishproduct,selfstoragedate,confirmarrivedate,quotEexchangeRate,confirmEexchangeRate,SpotEexchangeRate,confirmWeight,PlaceOfDelivery,finishedtime,finisheWeight,finisheNumber)");
            strSql.Append(" values (");
            strSql.Append("@id,@quotedate,@quoteweight,@quotequantity,@quotedollars,@quotermb,@quotesuppliercode,@quotesupplier,@quotelinkmancode,@quotelinkman,@quoteproductyear,@quoteproductdate,@quotelife,@quotesaildatefast,@quotesaildatelate,@confirmdate,@confirmsgsweight,@confirmsgsquantity,@confirmdollars,@confirmrmb,@confirmagentcode,@confirmagent,@confirmlinkmancode,@confirmlinkman,@confirmproductyear,@confirmproductdate,@confirmlife,@confirmsaildate,@spotdate,@Saletime,@spotweight,@spotquantity,@spotdollars,@spotrmb,@spotagentcode,@spotagent,@spotlinkmancode,@spotlinkman,@spotproductdate,@spotproductyear,@spotlife,@spotstoragedate,@saledate,@saleremainweight,@saleremainquantity,@saledollars,@salermb,SaleNumWeight,@saletradercode,@saletrader,@salelinkmancode,@salelinkman,@saleoutdate,@selfdate,@selfstorageweight,@selfstoragequantity,@selfdollars,@selfrmb,@selftradercode,@selftrader,@selflinkmancode,@selflinkman,@selffinishproduct,@selfstoragedate,@confirmarrivedate,@quotEexchangeRate,@confirmEexchangeRate,@SpotEexchangeRate,@confirmWeight,@PlaceOfDelivery,@finishedtime,@finisheWeight,@finisheNumber)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@quotedate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quoteweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@quotequantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@quotedollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@quotermb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@quotesuppliercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotesupplier", MySqlDbType.VarChar,255),
                    new MySqlParameter("@quotelinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotelinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@quoteproductyear", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quoteproductdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotelife", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotesaildatefast", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotesaildatelate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmsgsweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@confirmsgsquantity", MySqlDbType.VarChar,11),
                    new MySqlParameter("@confirmdollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@confirmrmb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@confirmagentcode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmagent", MySqlDbType.VarChar,255),
                    new MySqlParameter("@confirmlinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmlinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@confirmproductyear", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmproductdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmlife", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmsaildate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@spotquantity", MySqlDbType.Int32,255),
                    new MySqlParameter("@spotdollars", MySqlDbType.Decimal,8),
                    new MySqlParameter("@spotrmb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@spotagentcode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotagent", MySqlDbType.VarChar,255),
                    new MySqlParameter("@spotlinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotlinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@spotproductdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotproductyear", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotlife", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotstoragedate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saledate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saleremainweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@saleremainquantity", MySqlDbType.Int32,255),
                    new MySqlParameter("@saledollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@salermb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@saletradercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saletrader", MySqlDbType.VarChar,255),
                    new MySqlParameter("@salelinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salelinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@saleoutdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selfdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selfstorageweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@selfstoragequantity", MySqlDbType.Int32,255),
                    new MySqlParameter("@selfdollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@selfrmb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@selftradercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selftrader", MySqlDbType.VarChar,255),
                    new MySqlParameter("@selflinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selflinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@selffinishproduct", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selfstoragedate", MySqlDbType.VarChar,45),
                     new MySqlParameter("@confirmarrivedate",MySqlDbType.VarChar,45),
                     new MySqlParameter("@quotEexchangeRate",MySqlDbType.VarChar,45),
                     new MySqlParameter("@confirmEexchangeRate",MySqlDbType.VarChar,45),
                     new MySqlParameter("@SpotEexchangeRate",MySqlDbType.VarChar,45),
                     new MySqlParameter("@confirmWeight",MySqlDbType.VarChar,45),
                     new MySqlParameter("@PlaceOfDelivery",MySqlDbType.VarChar,45),
                     new MySqlParameter("@SaleNumWeight",MySqlDbType.Decimal,45),
                     new MySqlParameter("@Saletime",MySqlDbType.VarChar,45),
                     new MySqlParameter("@finishedtime",MySqlDbType.VarChar,45),
                     new MySqlParameter("@finisheWeight",MySqlDbType.Decimal,45),
                     new MySqlParameter("@finisheNumber",MySqlDbType.VarChar,45)
                                          };
            parameters[0].Value = model.id;
            parameters[1].Value = model.quotedate;
            parameters[2].Value = model.quoteweight;
            parameters[3].Value = model.quotequantity;
            parameters[4].Value = model.quotedollars;
            parameters[5].Value = model.quotermb;
            parameters[6].Value = model.quotesuppliercode;
            parameters[7].Value = model.quotesupplier;
            parameters[8].Value = model.quotelinkmancode;
            parameters[9].Value = model.quotelinkman;
            parameters[10].Value = model.quoteproductyear;
            parameters[11].Value = model.quoteproductdate;
            parameters[12].Value = model.quotelife;
            parameters[13].Value = model.quotesaildatefast;
            parameters[14].Value = model.quotesaildatelate;
            parameters[15].Value = model.confirmdate;
            parameters[16].Value = model.confirmsgsweight;
            parameters[17].Value = model.confirmsgsquantity;
            parameters[18].Value = model.confirmdollars;
            parameters[19].Value = model.confirmrmb;
            parameters[20].Value = model.confirmagentcode;
            parameters[21].Value = model.confirmagent;
            parameters[22].Value = model.confirmlinkmancode;
            parameters[23].Value = model.confirmlinkman;
            parameters[24].Value = model.confirmproductyear;
            parameters[25].Value = model.confirmproductdate;
            parameters[26].Value = model.confirmlife;
            parameters[27].Value = model.confirmsaildate;
            parameters[28].Value = model.spotdate;
            parameters[29].Value = model.spotweight;
            parameters[30].Value = model.spotquantity;
            parameters[31].Value = model.spotdollars;
            parameters[32].Value = model.spotrmb;
            parameters[33].Value = model.spotagentcode;
            parameters[34].Value = model.spotagent;
            parameters[35].Value = model.spotlinkmancode;
            parameters[36].Value = model.spotlinkman;
            parameters[37].Value = model.spotproductdate;
            parameters[38].Value = model.spotproductyear;
            parameters[39].Value = model.spotlife;
            parameters[40].Value = model.spotstoragedate;
            parameters[41].Value = model.saledate;
            parameters[42].Value = model.saleremainweight;
            parameters[43].Value = model.saleremainquantity;
            parameters[44].Value = model.saledollars;
            parameters[45].Value = model.salermb;
            parameters[46].Value = model.saletradercode;
            parameters[47].Value = model.saletrader;
            parameters[48].Value = model.salelinkmancode;
            parameters[49].Value = model.salelinkman;
            parameters[50].Value = model.saleoutdate;
            parameters[51].Value = model.selfdate;
            parameters[52].Value = model.selfstorageweight;
            parameters[53].Value = model.selfstoragequantity;
            parameters[54].Value = model.selfdollars;
            parameters[55].Value = model.selfrmb;
            parameters[56].Value = model.selftradercode;
            parameters[57].Value = model.selftrader;
            parameters[58].Value = model.selflinkmancode;
            parameters[59].Value = model.selflinkman;
            parameters[60].Value = model.selffinishproduct;
            parameters[61].Value = model.selfstoragedate;
            parameters[62].Value = model.confirmarrivedate;
            parameters[63].Value = model.quotEexchangeRate;
            parameters[64].Value = model.confirmEexchangeRate;
            parameters[65].Value = model.spotEexchangeRate;
            parameters[66].Value = model.confirmWeight;
            parameters[67].Value = model.PlaceOfDelivery;
            parameters[68].Value = model.SaleNumWeight;
            parameters[69].Value = model.Saletime;
            parameters[70].Value = model.finishedtime;
            parameters[71].Value = model.finisheWeight;
            parameters[72].Value = model.finisheNumber;
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
        public bool Entry_Add(FishEntity.ProductExEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_productex(id,quotedate,quoteweight,quotequantity,quotedollars,quotermb,quotesupplier,quotesuppliercode,quotelinkman,quotelinkmancode,quoteproductyear,quoteproductdate,quotelife,quotesaildatefast,quotesaildatelate)");
            strSql.Append("values(@id,@quotedate,@quoteweight,@quotequantity,@quotedollars,@quotermb,@quotesupplier,@quotesuppliercode,@quotelinkman,@quotelinkmancode,@quoteproductyear,@quoteproductdate,@quotelife,@quotesaildatefast,@quotesaildatelate)");
            MySqlParameter[] parameters = {
                new MySqlParameter("@id",MySqlDbType.Int32,11),
                new MySqlParameter("@quotedate",MySqlDbType.VarChar,45),
                new MySqlParameter("@quoteweight",MySqlDbType.Decimal,8),
                new MySqlParameter("@quotequantity",MySqlDbType.Int32,11),
                new MySqlParameter("@quotedollars",MySqlDbType.Int32,10),
                new MySqlParameter("@quotermb",MySqlDbType.Int32,10),
                new MySqlParameter("@quotesuppliercode",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotesupplier",MySqlDbType.VarChar,255),
                new MySqlParameter("@quotelinkman",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotelinkmancode",MySqlDbType.VarChar,255),
                new MySqlParameter("@quoteproductyear",MySqlDbType.VarChar,45),
                new MySqlParameter("@quoteproductdate",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotelife",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotesaildatefast",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotesaildatelate",MySqlDbType.VarChar,45)
            };
            parameters[0].Value = model.id;
            parameters[1].Value = model.quotedate;
            parameters[2].Value = model.quoteweight;
            parameters[3].Value = model.quotequantity;
            parameters[4].Value = model.quotedollars;
            parameters[5].Value = model.quotermb;
            parameters[6].Value = model.quotesuppliercode;
            parameters[7].Value = model.quotesupplier;
            parameters[8].Value = model.quotelinkman;
            parameters[9].Value = model.quotelinkmancode;
            parameters[10].Value = model.quoteproductyear;
            parameters[11].Value = model.quoteproductdate;
            parameters[12].Value = model.quotelife;
            parameters[13].Value = model.quotesaildatefast;
            parameters[14].Value = model.quotesaildatelate;
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
        /// 更新一条数据
        /// </summary>
        public bool Update(FishEntity.ProductExEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_productex set ");
            strSql.Append("quotedate=@quotedate,");
            strSql.Append("quoteweight=@quoteweight,");
            strSql.Append("quotequantity=@quotequantity,");
            strSql.Append("quotedollars=@quotedollars,");
            strSql.Append("quotermb=@quotermb,");
            strSql.Append("quotesuppliercode=@quotesuppliercode,");
            strSql.Append("quotesupplier=@quotesupplier,");
            strSql.Append("quotelinkmancode=@quotelinkmancode,");
            strSql.Append("quotelinkman=@quotelinkman,");
            strSql.Append("quoteproductyear=@quoteproductyear,");
            strSql.Append("quoteproductdate=@quoteproductdate,");
            strSql.Append("quotelife=@quotelife,");
            strSql.Append("quotesaildatefast=@quotesaildatefast,");
            strSql.Append("quotesaildatelate=@quotesaildatelate,");
            strSql.Append("confirmdate=@confirmdate,");
            strSql.Append("confirmsgsweight=@confirmsgsweight,");
            strSql.Append("confirmsgsquantity=@confirmsgsquantity,");
            strSql.Append("confirmdollars=@confirmdollars,");
            strSql.Append("confirmrmb=@confirmrmb,");
            strSql.Append("confirmagentcode=@confirmagentcode,");
            strSql.Append("confirmagent=@confirmagent,");
            strSql.Append("confirmlinkmancode=@confirmlinkmancode,");
            strSql.Append("confirmlinkman=@confirmlinkman,");
            strSql.Append("confirmproductyear=@confirmproductyear,");
            strSql.Append("confirmproductdate=@confirmproductdate,");
            strSql.Append("confirmlife=@confirmlife,");
            strSql.Append("confirmsaildate=@confirmsaildate,");
            strSql.Append("spotdate=@spotdate,");
            strSql.Append("Saletime=@Saletime,");
            strSql.Append("finishedtime=@finishedtime,");
            strSql.Append("finisheWeight= @finisheWeight,");
            strSql.Append("finisheNumber=@finisheNumber,");
            strSql.Append("spotweight=@spotweight,");
            strSql.Append("spotquantity=@spotquantity,");
            strSql.Append("spotdollars=@spotdollars,");
            strSql.Append("spotrmb=@spotrmb,");
            strSql.Append("spotagentcode=@spotagentcode,");
            strSql.Append("spotagent=@spotagent,");
            strSql.Append("spotlinkmancode=@spotlinkmancode,");
            strSql.Append("spotlinkman=@spotlinkman,");
            strSql.Append("spotproductdate=@spotproductdate,");
            strSql.Append("spotproductyear=@spotproductyear,");
            strSql.Append("spotlife=@spotlife,");
            strSql.Append("spotstoragedate=@spotstoragedate,");
            strSql.Append("saledate=@saledate,");
            strSql.Append("saleremainweight=@saleremainweight,");
            strSql.Append("saleremainquantity=@saleremainquantity,");
            strSql.Append("saledollars=@saledollars,");
            strSql.Append("salermb=@salermb,");
            strSql.Append("SaleNumWeight=@SaleNumWeight,");
            strSql.Append("saletradercode=@saletradercode,");
            strSql.Append("saletrader=@saletrader,");
            strSql.Append("salelinkmancode=@salelinkmancode,");
            strSql.Append("salelinkman=@salelinkman,");
            strSql.Append("saleoutdate=@saleoutdate,");
            strSql.Append("selfdate=@selfdate,");
            strSql.Append("selfstorageweight=@selfstorageweight,");
            strSql.Append("selfstoragequantity=@selfstoragequantity,");
            strSql.Append("selfdollars=@selfdollars,");
            strSql.Append("selfrmb=@selfrmb,");
            strSql.Append("selftradercode=@selftradercode,");
            strSql.Append("selftrader=@selftrader,");
            strSql.Append("selflinkmancode=@selflinkmancode,");
            strSql.Append("selflinkman=@selflinkman,");
            strSql.Append("selffinishproduct=@selffinishproduct,");
            strSql.Append("quotEexchangeRate=@quotEexchangeRate,");
            strSql.Append("confirmEexchangeRate=@confirmEexchangeRate,");
            strSql.Append("spotEexchangeRate=@spotEexchangeRate,");
            strSql.Append("confirmWeight=@confirmWeight,");
            strSql.Append("selfstoragedate=@selfstoragedate,");
            strSql.Append("PlaceOfDelivery=@PlaceOfDelivery,");
            strSql.Append("confirmarrivedate=@confirmarrivedate");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@quotedate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quoteweight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@quotequantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@quotedollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@quotermb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@quotesuppliercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotesupplier", MySqlDbType.VarChar,255),
                    new MySqlParameter("@quotelinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotelinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@quoteproductyear", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quoteproductdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotelife", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotesaildatefast", MySqlDbType.VarChar,45),
                    new MySqlParameter("@quotesaildatelate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmsgsweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@confirmsgsquantity", MySqlDbType.VarChar,11),
                    new MySqlParameter("@confirmdollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@confirmrmb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@confirmagentcode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmagent", MySqlDbType.VarChar,255),
                    new MySqlParameter("@confirmlinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmlinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@confirmproductyear", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmproductdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmlife", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmsaildate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@spotquantity", MySqlDbType.Int32,255),
                    new MySqlParameter("@spotdollars", MySqlDbType.Decimal,8),
                    new MySqlParameter("@spotrmb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@spotagentcode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotagent", MySqlDbType.VarChar,255),
                    new MySqlParameter("@spotlinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotlinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@spotproductdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotproductyear", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotlife", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotstoragedate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saledate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saleremainweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@saleremainquantity", MySqlDbType.Int32,255),
                    new MySqlParameter("@saledollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@salermb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@saletradercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saletrader", MySqlDbType.VarChar,255),
                    new MySqlParameter("@salelinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salelinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@saleoutdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selfdate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selfstorageweight", MySqlDbType.Decimal,8),
                    new MySqlParameter("@selfstoragequantity", MySqlDbType.Int32,255),
                    new MySqlParameter("@selfdollars", MySqlDbType.Decimal,10),
                    new MySqlParameter("@selfrmb", MySqlDbType.Decimal,10),
                    new MySqlParameter("@selftradercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selftrader", MySqlDbType.VarChar,255),
                    new MySqlParameter("@selflinkmancode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selflinkman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@selffinishproduct", MySqlDbType.VarChar,45),
                    new MySqlParameter("@selfstoragedate", MySqlDbType.VarChar,45),

                    new MySqlParameter("@confirmarrivedate",MySqlDbType.VarChar ,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),

                    new MySqlParameter("@quotEexchangeRate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmEexchangeRate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@spotEexchangeRate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@confirmWeight", MySqlDbType.VarChar,45),
                    new MySqlParameter("@PlaceOfDelivery",MySqlDbType.VarChar,45),
                    new MySqlParameter("@SaleNumWeight",MySqlDbType.Decimal,45),
                    new MySqlParameter("@Saletime",MySqlDbType.VarChar,45),
                    new MySqlParameter("@finishedtime",MySqlDbType.VarChar,45),
                    new MySqlParameter("@finisheWeight",MySqlDbType.Decimal,45),
                    new MySqlParameter("@finisheNumber",MySqlDbType.VarChar,45),
            };
            parameters[0].Value = model.quotedate;
            parameters[1].Value = model.quoteweight;
            parameters[2].Value = model.quotequantity;
            parameters[3].Value = model.quotedollars;
            parameters[4].Value = model.quotermb;
            parameters[5].Value = model.quotesuppliercode;
            parameters[6].Value = model.quotesupplier;
            parameters[7].Value = model.quotelinkmancode;
            parameters[8].Value = model.quotelinkman;
            parameters[9].Value = model.quoteproductyear;
            parameters[10].Value = model.quoteproductdate;
            parameters[11].Value = model.quotelife;
            parameters[12].Value = model.quotesaildatefast;
            parameters[13].Value = model.quotesaildatelate;
            parameters[14].Value = model.confirmdate;
            parameters[15].Value = model.confirmsgsweight;
            parameters[16].Value = model.confirmsgsquantity;
            parameters[17].Value = model.confirmdollars;
            parameters[18].Value = model.confirmrmb;
            parameters[19].Value = model.confirmagentcode;
            parameters[20].Value = model.confirmagent;
            parameters[21].Value = model.confirmlinkmancode;
            parameters[22].Value = model.confirmlinkman;
            parameters[23].Value = model.confirmproductyear;
            parameters[24].Value = model.confirmproductdate;
            parameters[25].Value = model.confirmlife;
            parameters[26].Value = model.confirmsaildate;
            parameters[27].Value = model.spotdate;
            parameters[28].Value = model.spotweight;
            parameters[29].Value = model.spotquantity;
            parameters[30].Value = model.spotdollars;
            parameters[31].Value = model.spotrmb;
            parameters[32].Value = model.spotagentcode;
            parameters[33].Value = model.spotagent;
            parameters[34].Value = model.spotlinkmancode;
            parameters[35].Value = model.spotlinkman;
            parameters[36].Value = model.spotproductdate;
            parameters[37].Value = model.spotproductyear;
            parameters[38].Value = model.spotlife;
            parameters[39].Value = model.spotstoragedate;
            parameters[40].Value = model.saledate;
            parameters[41].Value = model.saleremainweight;
            parameters[42].Value = model.saleremainquantity;
            parameters[43].Value = model.saledollars;
            parameters[44].Value = model.salermb;
            parameters[45].Value = model.saletradercode;
            parameters[46].Value = model.saletrader;
            parameters[47].Value = model.salelinkmancode;
            parameters[48].Value = model.salelinkman;
            parameters[49].Value = model.saleoutdate;
            parameters[50].Value = model.selfdate;
            parameters[51].Value = model.selfstorageweight;
            parameters[52].Value = model.selfstoragequantity;
            parameters[53].Value = model.selfdollars;
            parameters[54].Value = model.selfrmb;
            parameters[55].Value = model.selftradercode;
            parameters[56].Value = model.selftrader;
            parameters[57].Value = model.selflinkmancode;
            parameters[58].Value = model.selflinkman;
            parameters[59].Value = model.selffinishproduct;
            parameters[60].Value = model.selfstoragedate;
            parameters[61].Value = model.confirmarrivedate;
            parameters[62].Value = model.id;

            parameters[63].Value = model.quotEexchangeRate;
            parameters[64].Value = model.confirmEexchangeRate;
            parameters[65].Value = model.spotEexchangeRate;
            parameters[66].Value = model.confirmWeight;
            parameters[67].Value = model.PlaceOfDelivery;
            parameters[68].Value = model.SaleNumWeight;
            parameters[69].Value = model.Saletime;
            parameters[70].Value = model.finishedtime;
            parameters[71].Value = model.finisheWeight;
            parameters[72].Value = model.finisheNumber;
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
        public bool Entry_Update(FishEntity.ProductExEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_productex set ");
            strSql.Append("quotedate=@quotedate,");
            strSql.Append("quoteweight=@quoteweight,");
            strSql.Append("quotequantity=@quotequantity,");
            strSql.Append("quotedollars=@quotedollars,");
            strSql.Append("quotermb=@quotermb,");
            strSql.Append("quotesupplier=@quotesupplier,");
            strSql.Append("quotesuppliercode=@quotesuppliercode,");
            strSql.Append("quotelinkman=@quotelinkman,");
            strSql.Append("quotelinkmancode=@quotelinkmancode,");
            strSql.Append("quoteproductyear=@quoteproductyear,");
            strSql.Append("quoteproductdate=@quoteproductdate,");
            strSql.Append("quotelife=@quotelife,");
            strSql.Append("quotesaildatefast=@quotesaildatefast,");
            strSql.Append("quotesaildatelate=@quotesaildatelate ");
            strSql.Append("where id=@id ");
            MySqlParameter[] parameters = {
                new MySqlParameter("@quotedate",MySqlDbType.VarChar,45),
                new MySqlParameter("@quoteweight",MySqlDbType.Decimal,8),
                new MySqlParameter("@quotequantity",MySqlDbType.Int32,11),
                new MySqlParameter("@quotedollars",MySqlDbType.Decimal,10),
                new MySqlParameter("@quotermb",MySqlDbType.Decimal,10),
                new MySqlParameter("@quotesupplier",MySqlDbType.VarChar,255),
                new MySqlParameter("@quotesuppliercode",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotelinkman",MySqlDbType.VarChar,255),
                new MySqlParameter("@quotelinkmancode",MySqlDbType.VarChar,45),
                new MySqlParameter("@quoteproductyear",MySqlDbType.VarChar,45),
                new MySqlParameter("@quoteproductdate",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotelife",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotesaildatefast",MySqlDbType.VarChar,45),
                new MySqlParameter("@quotesaildatelate",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11)
            };
            parameters[0].Value = model.quotedate;
            parameters[1].Value = model.quoteweight;
            parameters[2].Value = model.quotequantity;
            parameters[3].Value = model.quotedollars;
            parameters[4].Value = model.quotermb;
            parameters[5].Value = model.quotesupplier;
            parameters[6].Value = model.quotesuppliercode;
            parameters[7].Value = model.quotelinkman;
            parameters[8].Value = model.quotelinkmancode;
            parameters[9].Value = model.quoteproductyear;
            parameters[10].Value = model.quoteproductdate;
            parameters[11].Value = model.quotelife;
            parameters[12].Value = model.quotesaildatefast;
            parameters[13].Value = model.quotesaildatelate;
            parameters[14].Value = model.id;
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
            strSql.Append("delete from t_productex ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11)			};
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
            strSql.Append("delete from t_productex ");
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
        public FishEntity.ProductExEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,quotedate,quoteweight,quotequantity,quotedollars,quotermb,quotesuppliercode,quotesupplier,quotelinkmancode,quotelinkman,quoteproductyear,quoteproductdate,quotelife,quotesaildatefast,quotesaildatelate,confirmdate,confirmsgsweight,confirmsgsquantity,confirmdollars,confirmrmb,confirmagentcode,confirmagent,confirmlinkmancode,confirmlinkman,confirmproductyear,confirmproductdate,confirmlife,confirmsaildate,spotdate,spotweight,spotquantity,spotdollars,spotrmb,spotagentcode,spotagent,spotlinkmancode,spotlinkman,spotproductdate,spotproductyear,spotlife,spotstoragedate,saledate,saleremainweight,SaleNumWeight,saleremainquantity,saledollars,salermb,Saletime,saletradercode,saletrader,salelinkmancode,salelinkman,saleoutdate,selfdate,selfstorageweight,selfstoragequantity,selfdollars,selfrmb,selftradercode,selftrader,selflinkmancode,selflinkman,selffinishproduct,selfstoragedate,confirmarrivedate,quotEexchangeRate,confirmEexchangeRate,spotEexchangeRate,confirmWeight,PlaceOfDelivery,finishedtime,finisheWeight,finisheNumber from t_productex ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = id;

            FishEntity.ProductExEntity model = new FishEntity.ProductExEntity();
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
        public FishEntity.ProductExEntity Entry_GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_productex ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = id;

            FishEntity.ProductExEntity model = new FishEntity.ProductExEntity();
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
        public FishEntity.ProductExEntity DataRowToModel(DataRow row)
        {
            FishEntity.ProductExEntity model = new FishEntity.ProductExEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["quotedate"] != null)
                {
                    model.quotedate = row["quotedate"].ToString();
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
                if (row["confirmdate"] != null)
                {
                    model.confirmdate = row["confirmdate"].ToString();
                }
                if (row["confirmsgsweight"] != null && row["confirmsgsweight"].ToString() != "")
                {
                    model.confirmsgsweight = decimal.Parse(row["confirmsgsweight"].ToString());
                }
                if (row["confirmsgsquantity"] != null )
                {
                    model.confirmsgsquantity = row["confirmsgsquantity"].ToString();
                }
                if (row["confirmdollars"] != null && row["confirmdollars"].ToString() != "")
                {
                    model.confirmdollars = decimal.Parse(row["confirmdollars"].ToString());
                }
                if (row["confirmrmb"] != null && row["confirmrmb"].ToString() != "")
                {
                    model.confirmrmb = decimal.Parse(row["confirmrmb"].ToString());
                }
                if (row["PlaceOfDelivery"]!=null&&row["PlaceOfDelivery"].ToString()!="")
                {
                    model.PlaceOfDelivery = row["PlaceOfDelivery"].ToString();
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
                if (row["spotdate"] != null)
                {
                    model.spotdate = row["spotdate"].ToString();
                }
                if (row["Saletime"]!=null)
                {
                    model.Saletime = row["Saletime"].ToString();
                }

                if (row["finishedtime"] != null)
                {
                    model.finishedtime = row["finishedtime"].ToString();
                }
                if (row["finisheWeight"] != null&& row["finisheWeight"].ToString()!="")
                {
                    model.finisheWeight =decimal.Parse( row["finisheWeight"].ToString());
                }
                if (row["finisheNumber"] != null)
                {
                    model.finisheNumber = row["finisheNumber"].ToString();
                }

                if (row["spotweight"] != null && row["spotweight"].ToString() != "")
                {
                    model.spotweight = decimal.Parse(row["spotweight"].ToString());
                }
                if (row["spotquantity"] != null && row["spotquantity"].ToString() != "")
                {
                    model.spotquantity = int.Parse(row["spotquantity"].ToString());
                }
                if (row["spotdollars"] != null && row["spotdollars"].ToString() != "")
                {
                    model.spotdollars = decimal.Parse(row["spotdollars"].ToString());
                }
                if (row["spotrmb"] != null && row["spotrmb"].ToString() != "")
                {
                    model.spotrmb = decimal.Parse(row["spotrmb"].ToString());
                }
                if (row["spotagentcode"] != null)
                {
                    model.spotagentcode = row["spotagentcode"].ToString();
                }
                if (row["spotagent"] != null)
                {
                    model.spotagent = row["spotagent"].ToString();
                }
                if (row["spotlinkmancode"] != null)
                {
                    model.spotlinkmancode = row["spotlinkmancode"].ToString();
                }
                if (row["spotlinkman"] != null)
                {
                    model.spotlinkman = row["spotlinkman"].ToString();
                }
                if (row["spotproductdate"] != null)
                {
                    model.spotproductdate = row["spotproductdate"].ToString();
                }
                if (row["spotproductyear"] != null)
                {
                    model.spotproductyear = row["spotproductyear"].ToString();
                }
                if (row["spotlife"] != null)
                {
                    model.spotlife = row["spotlife"].ToString();
                }
                if (row["spotstoragedate"] != null)
                {
                    model.spotstoragedate = row["spotstoragedate"].ToString();
                }
                if (row["saledate"] != null)
                {
                    model.saledate = row["saledate"].ToString();
                }
                if (row["saleremainweight"] != null && row["saleremainweight"].ToString() != "")
                {
                    model.saleremainweight = decimal.Parse(row["saleremainweight"].ToString());
                }
                if (row["saleremainquantity"] != null && row["saleremainquantity"].ToString() != "")
                {
                    model.saleremainquantity = int.Parse(row["saleremainquantity"].ToString());
                }
                if (row["saledollars"] != null && row["saledollars"].ToString() != "")
                {
                    model.saledollars = decimal.Parse(row["saledollars"].ToString());
                }
                if (row["salermb"] != null && row["salermb"].ToString() != "")
                {
                    model.salermb = decimal.Parse(row["salermb"].ToString());
                }
                if (row["SaleNumWeight"]!=null&&row["SaleNumWeight"].ToString()!="")
                {
                    model.SaleNumWeight = decimal.Parse(row["SaleNumWeight"].ToString());
                }
                if (row["saletradercode"] != null)
                {
                    model.saletradercode = row["saletradercode"].ToString();
                }
                if (row["saletrader"] != null)
                {
                    model.saletrader = row["saletrader"].ToString();
                }
                if (row["salelinkmancode"] != null)
                {
                    model.salelinkmancode = row["salelinkmancode"].ToString();
                }
                if (row["salelinkman"] != null)
                {
                    model.salelinkman = row["salelinkman"].ToString();
                }
                if (row["saleoutdate"] != null)
                {
                    model.saleoutdate = row["saleoutdate"].ToString();
                }
                if (row["selfdate"] != null)
                {
                    model.selfdate = row["selfdate"].ToString();
                }
                if (row["selfstorageweight"] != null && row["selfstorageweight"].ToString() != "")
                {
                    model.selfstorageweight = decimal.Parse(row["selfstorageweight"].ToString());
                }
                if (row["selfstoragequantity"] != null && row["selfstoragequantity"].ToString() != "")
                {
                    model.selfstoragequantity = int.Parse(row["selfstoragequantity"].ToString());
                }
                if (row["selfdollars"] != null && row["selfdollars"].ToString() != "")
                {
                    model.selfdollars = decimal.Parse(row["selfdollars"].ToString());
                }
                if (row["selfrmb"] != null && row["selfrmb"].ToString() != "")
                {
                    model.selfrmb = decimal.Parse(row["selfrmb"].ToString());
                }
                if (row["selftradercode"] != null)
                {
                    model.selftradercode = row["selftradercode"].ToString();
                }
                if (row["selftrader"] != null)
                {
                    model.selftrader = row["selftrader"].ToString();
                }
                if (row["selflinkmancode"] != null)
                {
                    model.selflinkmancode = row["selflinkmancode"].ToString();
                }
                if (row["selflinkman"] != null)
                {
                    model.selflinkman = row["selflinkman"].ToString();
                }
                if (row["selffinishproduct"] != null)
                {
                    model.selffinishproduct = row["selffinishproduct"].ToString();
                }
                if (row["selfstoragedate"] != null)
                {
                    model.selfstoragedate = row["selfstoragedate"].ToString();
                }
                if (row["confirmarrivedate"] != null)
                {
                    model.confirmarrivedate = row["confirmarrivedate"].ToString();
                }
                if (row["quotEexchangeRate"] != null)
                {
                    model.quotEexchangeRate = row["quotEexchangeRate"].ToString();
                }
                if (row["confirmEexchangeRate"] != null)
                {
                    model.confirmEexchangeRate = row["confirmEexchangeRate"].ToString();
                }
                if (row["spotEexchangeRate"] != null)
                {
                    model.spotEexchangeRate = row["spotEexchangeRate"].ToString();
                }
                if (row["confirmWeight"] != null)
                {
                    model.confirmWeight = row["confirmWeight"].ToString();
                }

            }
            return model;
        }
        public FishEntity.ProductExEntity Entry_DataRowToModel(DataRow row)
        {
            FishEntity.ProductExEntity model = new FishEntity.ProductExEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["quotedate"] != null)
                {
                    model.quotedate = row["quotedate"].ToString();
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
                
            }
            return model;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,quotedate,quoteweight,quotequantity,quotedollars,quotermb,quotesuppliercode,quotesupplier,quotelinkmancode,quotelinkman,quoteproductyear,quoteproductdate,quotelife,quotesaildatefast,quotesaildatelate,confirmdate,confirmsgsweight,confirmsgsquantity,confirmdollars,confirmrmb,confirmagentcode,confirmagent,confirmlinkmancode,confirmlinkman,confirmproductyear,confirmproductdate,confirmlife,confirmsaildate,spotdate,spotweight,spotquantity,spotdollars,spotrmb,spotagentcode,spotagent,spotlinkmancode,spotlinkman,spotproductdate,spotproductyear,spotlife,spotstoragedate,saledate,saleremainweight,saleremainquantity,saledollars,salermb,saletradercode,saletrader,salelinkmancode,salelinkman,saleoutdate,selfdate,selfstorageweight,selfstoragequantity,selfdollars,selfrmb,selftradercode,selftrader,selflinkmancode,selflinkman,selffinishproduct,selfstoragedate,confirmarrivedate ");
            strSql.Append(" FROM t_productex ");
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
            strSql.Append("select count(1) FROM t_productex ");
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
            strSql.Append(")AS Row, T.*  from t_productex T ");
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
			parameters[0].Value = "t_productex";
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
