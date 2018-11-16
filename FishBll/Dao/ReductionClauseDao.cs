using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class ReductionClauseDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity . ReductionClauseEntity> getModelList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("SELECT id,proName,country,brand,speci,ratio,priceMY,priceBase,priceDiff,exRate,priceRMB,codeNum FROM t_reductionclause ");
            strSql . AppendFormat ( "WHERE {0}" ,strWhere );

            DataTable table = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( table != null && table . Rows . Count > 0 )
            {

                List<FishEntity . ReductionClauseEntity> modelList = new List<FishEntity . ReductionClauseEntity> ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    modelList . Add ( getModel ( table . Rows [ i ] ) );
                }
                return modelList;
            }
            else
                return null;
        }

        public FishEntity . ReductionClauseEntity getModel ( DataRow row )
        {
            FishEntity . ReductionClauseEntity model = new FishEntity . ReductionClauseEntity ( );
            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "proName" ] != null )
                {
                    model . proName = row [ "proName" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "speci" ] != null && row [ "speci" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "speci" ] . ToString ( ) == "1" ) || ( row [ "speci" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . speci = true;
                    }
                    else
                    {
                        model . speci = false;
                    }
                }
                if ( row [ "ratio" ] != null )
                {
                    model . ratio = row [ "ratio" ] . ToString ( );
                }
                if ( row [ "priceMY" ] != null && row [ "priceMY" ] . ToString ( ) != "" )
                {
                    model . priceMY = decimal . Parse ( row [ "priceMY" ] . ToString ( ) );
                }
                if ( row [ "priceBase" ] != null && row [ "priceBase" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "priceBase" ] . ToString ( ) == "1" ) || ( row [ "priceBase" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . priceBase = true;
                    }
                    else
                    {
                        model . priceBase = false;
                    }
                }
                if ( row [ "priceDiff" ] != null && row [ "priceDiff" ] . ToString ( ) != "" )
                {
                    model . priceDiff = decimal . Parse ( row [ "priceDiff" ] . ToString ( ) );
                }
                if ( row [ "exRate" ] != null && row [ "exRate" ] . ToString ( ) != "" )
                {
                    model . exRate = decimal . Parse ( row [ "exRate" ] . ToString ( ) );
                }
                if ( row [ "priceRMB" ] != null && row [ "priceRMB" ] . ToString ( ) != "" )
                {
                    model . priceRMB = decimal . Parse ( row [ "priceRMB" ] . ToString ( ) );
                }
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Save ( List<FishEntity . ReductionClauseEntity> modelList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            foreach ( FishEntity . ReductionClauseEntity model in modelList )
            {
                if ( model . id < 1 )
                    Add ( SQLString ,strSql ,model );
                else
                    Edit ( SQLString ,strSql ,model );
            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        void Add ( Hashtable SQLString ,StringBuilder strSql ,FishEntity.ReductionClauseEntity model)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_reductionclause(" );
            strSql . Append ( "proName,country,brand,speci,ratio,priceMY,priceBase,priceDiff,exRate,priceRMB,codeNum)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@proName,@country,@brand,@speci,@ratio,@priceMY,@priceBase,@priceDiff,@exRate,@priceRMB,@codeNum)" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@proName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.Bit),
                    new MySqlParameter("@ratio", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceBase", MySqlDbType.Bit),
                    new MySqlParameter("@priceDiff", MySqlDbType.Decimal,18),
                    new MySqlParameter("@exRate", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceRMB", MySqlDbType.Decimal,18),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . proName;
            parameters [ 1 ] . Value = model . country;
            parameters [ 2 ] . Value = model . brand;
            parameters [ 3 ] . Value = model . speci;
            parameters [ 4 ] . Value = model . ratio;
            parameters [ 5 ] . Value = model . priceMY;
            parameters [ 6 ] . Value = model . priceBase;
            parameters [ 7 ] . Value = model . priceDiff;
            parameters [ 8 ] . Value = model . exRate;
            parameters [ 9 ] . Value = model . priceRMB;
            parameters [ 10 ] . Value = model . codeNum;
            SQLString . Add ( strSql ,parameters );
        }

        void Edit ( Hashtable SQLString ,StringBuilder strSql ,FishEntity . ReductionClauseEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update t_reductionclause set " );
            strSql . Append ( "proName=@proName," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "speci=@speci," );
            strSql . Append ( "ratio=@ratio," );
            strSql . Append ( "priceMY=@priceMY," );
            strSql . Append ( "priceBase=@priceBase," );
            strSql . Append ( "priceDiff=@priceDiff," );
            strSql . Append ( "exRate=@exRate," );
            strSql . Append ( "priceRMB=@priceRMB," );
            strSql . Append ( "codeNum=@codeNum" );
            strSql . Append ( " where id=@id " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@proName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.Bit),
                    new MySqlParameter("@ratio", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceBase", MySqlDbType.Bit),
                    new MySqlParameter("@priceDiff", MySqlDbType.Decimal,18),
                    new MySqlParameter("@exRate", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceRMB", MySqlDbType.Decimal,18),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters [ 0 ] . Value = model . proName;
            parameters [ 1 ] . Value = model . country;
            parameters [ 2 ] . Value = model . brand;
            parameters [ 3 ] . Value = model . speci;
            parameters [ 4 ] . Value = model . ratio;
            parameters [ 5 ] . Value = model . priceMY;
            parameters [ 6 ] . Value = model . priceBase;
            parameters [ 7 ] . Value = model . priceDiff;
            parameters [ 8 ] . Value = model . exRate;
            parameters [ 9 ] . Value = model . priceRMB;
            parameters [ 10 ] . Value = model . codeNum;
            parameters [ 11 ] . Value = model . id;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 删除出数据
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_reductionclause " );
            strSql . Append ( " where id=@id " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters [ 0 ] . Value = id;

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

    }
}
