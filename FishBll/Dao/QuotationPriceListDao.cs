using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class QuotationPriceListDao
    {        
        /// <summary>
             /// 获取数据列表
             /// </summary>
             /// <param name="name"></param>
             /// <returns></returns>
        public DataTable getTable(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT XNfishId,ffa,id,code,fishId,priceMY,price,country,brand,qualitySpe,weight,tvn,acid,protein,ash,histamine,las,das,salt FROM	t_quotationpricelist ");
            strSql.Append("where " + name);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select max(code) code from t_QuotationPriceList " );
            
            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string code = dt . Rows [ 0 ] [ "code" ] . ToString ( );
                if ( string . IsNullOrEmpty ( code ) )
                    return DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( code . Substring ( 0 ,8 ) . Equals ( DateTime . Now . ToString ( "yyyyMMdd" ) ) )
                        return ( Convert . ToInt64 ( code ) + 1 ) . ToString ( );
                    else
                        return DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
        }
        /// <summary>
        /// 获取虚拟鱼粉
        /// </summary>
        /// <returns></returns>
        public string getfishId()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(fishId) fishId from t_QuotationPriceList ");

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string code = dt.Rows[0]["fishId"].ToString();
                if (string.IsNullOrEmpty(code))
                    return DateTime.Now.ToString("yyyy") + "00001";
                else
                {
                    if (code.Substring(0, 6).Equals(DateTime.Now.ToString("yyyy")))
                        return (Convert.ToInt64(code) + 1).ToString();
                    else
                        return DateTime.Now.ToString("yyyy") + "00001";
                }
            }
            else
                return DateTime.Now.ToString("yyyy") + "00001";
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . QuotationPriceListEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_quotationpricelist set " );
            strSql . Append ( "fishId=@fishId," );
            strSql.Append("XNfishId=@XNfishId,");
            strSql.Append("ffa=@ffa,");
            strSql . Append ( "priceMY=@priceMY," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "unit=@unit," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "qualitySpe=@qualitySpe," );
            strSql . Append ( "weight=@weight," );
            strSql . Append ( "contract=@contract," );
            strSql . Append ( "date=@date," );
            strSql . Append ( "tvn=@tvn," );
            strSql . Append ( "acid=@acid," );
            strSql . Append ( "salt=@salt," );
            strSql . Append ( "protein=@protein," );
            strSql . Append ( "ash=@ash," );
            strSql . Append ( "histamine=@histamine," );
            strSql . Append ( "las=@las," );
            strSql . Append ( "das=@das," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "dataForm=@dataForm," );
            strSql . Append ( "codeNumSales=@codeNumSales " );
            strSql . Append ( " where code=@code " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@unit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@contract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@date", MySqlDbType.Date),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@acid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@las", MySqlDbType.VarChar,45),
                    new MySqlParameter("@das", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,225),
                    new MySqlParameter("@dataForm", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumSales", MySqlDbType.VarChar,45),
                    new MySqlParameter("@XNfishId",MySqlDbType.VarChar,45),
                    new MySqlParameter("@ffa",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . priceMY;
            parameters [ 3 ] . Value = model . price;
            parameters [ 4 ] . Value = model . unit;
            parameters [ 5 ] . Value = model . country;
            parameters [ 6 ] . Value = model . brand;
            parameters [ 7 ] . Value = model . qualitySpe;
            parameters [ 8 ] . Value = model . weight;
            parameters [ 9 ] . Value = model . contract;
            parameters [ 10 ] . Value = model . date;
            parameters [ 11 ] . Value = model . tvn;
            parameters [ 12 ] . Value = model . acid;
            parameters [ 13 ] . Value = model . salt;
            parameters [ 14 ] . Value = model . protein;
            parameters [ 15 ] . Value = model . ash;
            parameters [ 16 ] . Value = model . histamine;
            parameters [ 17 ] . Value = model . las;
            parameters [ 18 ] . Value = model . das;
            parameters [ 19 ] . Value = model . remark;
            parameters [ 20 ] . Value = model . dataForm;
            parameters [ 21 ] . Value = model . CodeNumSales;
            parameters[22].Value = model.XNfishId;
            parameters[23].Value = model.FFA;

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameters );
            if ( rows > 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . QuotationPriceListEntity model ,string name)
        {
            Hashtable SQLString = new Hashtable ( );
            SQLString=ReviewInfo . getSQLString ( name ,model . code ,string . Empty ,SQLString );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_quotationpricelist(" );
            strSql . Append ("code,fishId,priceMY,price,unit,country,brand,qualitySpe,weight,contract,date,tvn,acid,salt,protein,ash,histamine,las,das,remark,dataForm,codeNumSales,XNfishId,ffa)");
            strSql . Append ( " values (" );
            strSql . Append ("@code,@fishId,@priceMY,@price,@unit,@country,@brand,@qualitySpe,@weight,@contract,@date,@tvn,@acid,@salt,@protein,@ash,@histamine,@las,@das,@remark,@dataForm,@codeNumSales,@XNfishId,@ffa)");
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@unit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@contract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@date", MySqlDbType.Date),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@acid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@las", MySqlDbType.VarChar,45),
                    new MySqlParameter("@das", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,225),
                    new MySqlParameter("@dataForm", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumSales", MySqlDbType.VarChar,45),
                    new MySqlParameter("@XNfishId",MySqlDbType.VarChar,45),
                    new MySqlParameter("@ffa",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . priceMY;
            parameters [ 3 ] . Value = model . price;
            parameters [ 4 ] . Value = model . unit;
            parameters [ 5 ] . Value = model . country;
            parameters [ 6 ] . Value = model . brand;
            parameters [ 7 ] . Value = model . qualitySpe;
            parameters [ 8 ] . Value = model . weight;
            parameters [ 9 ] . Value = model . contract;
            parameters [ 10 ] . Value = model . date;
            parameters [ 11 ] . Value = model . tvn;
            parameters [ 12 ] . Value = model . acid;
            parameters [ 13 ] . Value = model . salt;
            parameters [ 14 ] . Value = model . protein;
            parameters [ 15 ] . Value = model . ash;
            parameters [ 16 ] . Value = model . histamine;
            parameters [ 17 ] . Value = model . las;
            parameters [ 18 ] . Value = model . das;
            parameters [ 19 ] . Value = model . remark;
            parameters [ 20 ] . Value = model . dataForm;
            parameters [ 21 ] . Value = model . CodeNumSales;
            parameters[22].Value = model.XNfishId;
            parameters[23].Value = model.FFA;
            SQLString . Add ( strSql ,parameters );
            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select count(1) from t_quotationpricelist where code='{0}' " ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . QuotationPriceListEntity getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("select ffa,XNfishId,id,code,fishId,priceMY,price,unit,country,brand,qualitySpe,weight,contract,date,tvn,acid,salt,protein,ash,histamine,las,das,remark,dataForm,codeNumSales from t_quotationpricelist where {0}", strWhere );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return getModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        public FishEntity . QuotationPriceListEntity getModel ( DataRow row )
        {
            FishEntity . QuotationPriceListEntity model = new FishEntity . QuotationPriceListEntity ( );
            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "code" ] != null )
                {
                    model . code = row [ "code" ] . ToString ( );
                }
                if ( row [ "fishId" ] != null )
                {
                    model . fishId = row [ "fishId" ] . ToString ( );
                }
                if (row["ffa"]!=null)
                {
                    model.FFA = row["ffa"].ToString();
                }
                if (row["XNfishId"]!=null)
                {
                    model.XNfishId = row["XNfishId"].ToString();
                }
                if ( row [ "priceMY" ] != null && row [ "priceMY" ] . ToString ( ) != "" )
                {
                    model . priceMY = decimal . Parse ( row [ "priceMY" ] . ToString ( ) );
                }
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                {
                    model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                }
                if ( row [ "unit" ] != null )
                {
                    model . unit = row [ "unit" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "qualitySpe" ] != null )
                {
                    model . qualitySpe = row [ "qualitySpe" ] . ToString ( );
                }
                if ( row [ "weight" ] != null && row [ "weight" ] . ToString ( ) != "" )
                {
                    model . weight = decimal . Parse ( row [ "weight" ] . ToString ( ) );
                }
                if ( row [ "contract" ] != null )
                {
                    model . contract = row [ "contract" ] . ToString ( );
                }
                if ( row [ "date" ] != null && row [ "date" ] . ToString ( ) != "" )
                {
                    model . date = DateTime . Parse ( row [ "date" ] . ToString ( ) );
                }
                if ( row [ "tvn" ] != null )
                {
                    model . tvn = row [ "tvn" ] . ToString ( );
                }
                if ( row [ "acid" ] != null )
                {
                    model . acid = row [ "acid" ] . ToString ( );
                }
                if ( row [ "salt" ] != null )
                {
                    model . salt = row [ "salt" ] . ToString ( );
                }
                if ( row [ "protein" ] != null )
                {
                    model . protein = row [ "protein" ] . ToString ( );
                }
                if ( row [ "ash" ] != null )
                {
                    model . ash = row [ "ash" ] . ToString ( );
                }
                if ( row [ "histamine" ] != null )
                {
                    model . histamine = row [ "histamine" ] . ToString ( );
                }
                if ( row [ "las" ] != null )
                {
                    model . las = row [ "las" ] . ToString ( );
                }
                if ( row [ "das" ] != null )
                {
                    model . das = row [ "das" ] . ToString ( );
                }
                if ( row [ "remark" ] != null )
                {
                    model . remark = row [ "remark" ] . ToString ( );
                }
                if ( row [ "dataForm" ] != null )
                {
                    model . dataForm = row [ "dataForm" ] . ToString ( );
                }
                if ( row [ "codeNumSales" ] != null )
                {
                    model . CodeNumSales = row [ "codeNumSales" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_quotationpricelist" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete (string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM t_QuotationPriceList where code='{0}'" ,code );

            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

    }
}
