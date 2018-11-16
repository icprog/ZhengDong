using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class BatchSheetDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.id,b.id as id1,a.isSum,b.code,b.productionDate,a.code,a.fishId,a.codeNum,a.codeNumContract,a.qualitySpe,a.country,a.brand,a.goods,a.tons,a.protein,a.tvn,a.salt,a.acid,a.ash,a.histamine,a.las,a.das,a.price,a.cost,a.rkCode from t_batchsheets a LEFT JOIN t_batchsheet b on a.code=b.code ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        public string code()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(codeNumContract) codeNumContract FROM t_batchsheets where length(codeNumContract)=13 ");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["codeNumContract"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["codeNumContract"].ToString();
            }
            else
                return string.Empty;
        }
        public string fishid()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(right(fishId,8)) fishId FROM t_batchsheets where length(fishId)=10 ");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["fishId"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["fishId"].ToString();
            }
            else
                return string.Empty;
        }
        public string Numbering()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max(substring_index(codeNum,'P',-1))as codeNum FROM t_batchsheets where substring_index(codeNum,'P',1)=DATE_FORMAT(NOW(),'%Y')");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["codeNum"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["codeNum"].ToString();
            }
            else
                return string.Empty;
        }
        public DateTime getDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NOW() t");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["t"].ToString()))
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(ds.Tables[0].Rows[0]["t"].ToString());
            }
            else
                return DateTime.Now;
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(code) code FROM t_batchsheet" );

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
        /// 删除记录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM t_batchsheet WHERE code='{0}'" ,code );
            SQLString . Add ( strSql ,null );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM t_batchsheets WHERE code='{0}'" ,code );
            SQLString . Add ( strSql ,null );

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="_modelsList"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . BatchSheetEntity _model ,List<FishEntity . BatchSheetsEntity> _modelsList ,string name )
        {
            Hashtable SQLString = new Hashtable ( );
            SQLString = ReviewInfo . getSQLString ( name ,_model . code ,string . Empty ,SQLString );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_batchsheet(" );
            strSql . Append ( "code,productionDate)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@code,@productionDate)" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@productionDate", MySqlDbType.Date)};
            parameters [ 0 ] . Value = _model . code;
            parameters [ 1 ] . Value = _model . productionDate;
            SQLString . Add ( strSql ,parameters );

            foreach ( FishEntity . BatchSheetsEntity model in _modelsList )
            {
                add ( SQLString ,strSql ,model );
            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }
        
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="_modelsList"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . BatchSheetEntity _model ,List<FishEntity . BatchSheetsEntity> _modelsList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_batchsheet SET productionDate=@productionDate where code=@code" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@productionDate", MySqlDbType.Date)
            };
            parameters [ 0 ] . Value = _model . code;
            parameters [ 1 ] . Value = _model . productionDate;
            SQLString . Add ( strSql ,parameters );

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT id FROM t_batchsheets where code='{0}'" ,_model . code );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];

            foreach ( FishEntity . BatchSheetsEntity model in _modelsList )
            {
                if ( dt != null && dt . Rows . Count > 0 && dt . Select ( "id='" + model . id + "'" ) . Length > 0 )
                {
                    edit ( SQLString ,strSql ,model );
                }
                else
                {
                    add ( SQLString ,strSql ,model );
                }
            }

            if ( Exists_isDel ( _model . code ) == false )
            {
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    int id = 0;
                    FishEntity . BatchSheetsEntity model = new FishEntity . BatchSheetsEntity ( );
                    for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                    {
                        id = string . IsNullOrEmpty ( dt . Rows [ i ] [ "id" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dt . Rows [ i ] [ "id" ] . ToString ( ) );

                        model = _modelsList . Find ( x =>
                        {
                            return x . id == id;
                        } );
                        if ( model == null )
                        {
                            delete ( SQLString ,strSql ,id );
                        }
                    }
                }
            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );

        }

        void add ( Hashtable SQLString ,StringBuilder strSql ,FishEntity . BatchSheetsEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_batchsheets(" );
            strSql . Append ( "code,fishId,codeNum,codeNumContract,qualitySpe,country,brand,goods,tons,protein,tvn,salt,acid,ash,histamine,las,das,price,cost,isSum)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@code,@fishId,@codeNum,@codeNumContract,@qualitySpe,@country,@brand,@goods,@tons,@protein,@tvn,@salt,@acid,@ash,@histamine,@las,@das,@price,@cost,@isSum)" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@goods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tons", MySqlDbType.Decimal,10),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@acid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@las", MySqlDbType.VarChar,45),
                    new MySqlParameter("@das", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@cost", MySqlDbType.Decimal,10),
                    new MySqlParameter("@isSum", MySqlDbType.Bit)};
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . codeNum;
            parameters [ 3 ] . Value = model . codeNumContract;
            parameters [ 4 ] . Value = model . qualitySpe;
            parameters [ 5 ] . Value = model . country;
            parameters [ 6 ] . Value = model . brand;
            parameters [ 7 ] . Value = model . goods;
            parameters [ 8 ] . Value = model . tons;
            parameters [ 9 ] . Value = model . protein;
            parameters [ 10 ] . Value = model . tvn;
            parameters [ 11 ] . Value = model . salt;
            parameters [ 12 ] . Value = model . acid;
            parameters [ 13 ] . Value = model . ash;
            parameters [ 14 ] . Value = model . histamine;
            parameters [ 15 ] . Value = model . las;
            parameters [ 16 ] . Value = model . das;
            parameters [ 17 ] . Value = model . price;
            parameters [ 18 ] . Value = model . cost;
            parameters [ 19 ] . Value = model . isSum;
            SQLString . Add ( strSql ,parameters );
        }

        void edit ( Hashtable SQLString ,StringBuilder strSql ,FishEntity . BatchSheetsEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update t_batchsheets set " );
            strSql . Append ( "code=@code," );
            strSql . Append ( "fishId=@fishId," );
            strSql . Append ( "codeNum=@codeNum," );
            strSql . Append ( "codeNumContract=@codeNumContract," );
            strSql . Append ( "qualitySpe=@qualitySpe," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "goods=@goods," );
            strSql . Append ( "tons=@tons," );
            strSql . Append ( "protein=@protein," );
            strSql . Append ( "tvn=@tvn," );
            strSql . Append ( "salt=@salt," );
            strSql . Append ( "acid=@acid," );
            strSql . Append ( "ash=@ash," );
            strSql . Append ( "histamine=@histamine," );
            strSql . Append ( "las=@las," );
            strSql . Append ( "das=@das," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "cost=@cost," );
            strSql . Append ( "isSum=@isSum" );
            strSql . Append ( " where id=@id" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@goods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tons", MySqlDbType.Decimal,10),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@acid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@las", MySqlDbType.VarChar,45),
                    new MySqlParameter("@das", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@cost", MySqlDbType.Decimal,10),
                    new MySqlParameter("@isSum", MySqlDbType.Bit),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . codeNum;
            parameters [ 3 ] . Value = model . codeNumContract;
            parameters [ 4 ] . Value = model . qualitySpe;
            parameters [ 5 ] . Value = model . country;
            parameters [ 6 ] . Value = model . brand;
            parameters [ 7 ] . Value = model . goods;
            parameters [ 8 ] . Value = model . tons;
            parameters [ 9 ] . Value = model . protein;
            parameters [ 10 ] . Value = model . tvn;
            parameters [ 11 ] . Value = model . salt;
            parameters [ 12 ] . Value = model . acid;
            parameters [ 13 ] . Value = model . ash;
            parameters [ 14 ] . Value = model . histamine;
            parameters [ 15 ] . Value = model . las;
            parameters [ 16 ] . Value = model . das;
            parameters [ 17 ] . Value = model . price;
            parameters [ 18 ] . Value = model . cost;
            parameters [ 19 ] . Value = model . isSum;
            parameters [ 20 ] . Value = model . id;

            SQLString . Add ( strSql ,parameters );
        }

        void delete ( Hashtable SQLString ,StringBuilder strSql ,int id )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_batchsheets where id={0}" , id );

            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select count(1) from t_batchsheet where code='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeD ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_batchsheet " );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . BatchSheetEntity getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT id,code,productionDate from t_batchsheet " );
            strSql . AppendFormat ( "WHERE {0}" ,strWhere );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return getModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        public FishEntity . BatchSheetEntity getModel ( DataRow row )
        {
            FishEntity . BatchSheetEntity model = new FishEntity . BatchSheetEntity ( );
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
                if ( row [ "productionDate" ] != null && row [ "productionDate" ] . ToString ( ) != "" )
                {
                    model . productionDate = DateTime . Parse ( row [ "productionDate" ] . ToString ( ) );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity . BatchSheetsEntity> modelList ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select id,code,fishId,codeNum,codeNumContract,qualitySpe,country,brand,goods,tons,protein,tvn,salt,acid,ash,histamine,las,das,price,cost,isSum from t_batchsheets " );
            strSql . AppendFormat ( " where code='{0}'" ,code );
            
            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                List<FishEntity . BatchSheetsEntity> modelList = new List<FishEntity . BatchSheetsEntity> ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    modelList . Add ( getModels ( dt . Rows [ i ] ) );
                }
                return modelList;
            }
            else
                return null;
        }

        public FishEntity . BatchSheetsEntity getModels ( DataRow row )
        {
            FishEntity . BatchSheetsEntity model = new FishEntity . BatchSheetsEntity ( );
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
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
                if ( row [ "codeNumContract" ] != null )
                {
                    model . codeNumContract = row [ "codeNumContract" ] . ToString ( );
                }
                if ( row [ "qualitySpe" ] != null )
                {
                    model . qualitySpe = row [ "qualitySpe" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "goods" ] != null )
                {
                    model . goods = row [ "goods" ] . ToString ( );
                }
                if ( row [ "tons" ] != null && row [ "tons" ] . ToString ( ) != "" )
                {
                    model . tons = decimal . Parse ( row [ "tons" ] . ToString ( ) );
                }
                if ( row [ "protein" ] != null )
                {
                    model . protein = row [ "protein" ] . ToString ( );
                }
                if ( row [ "tvn" ] != null )
                {
                    model . tvn = row [ "tvn" ] . ToString ( );
                }
                if ( row [ "salt" ] != null )
                {
                    model . salt = row [ "salt" ] . ToString ( );
                }
                if ( row [ "acid" ] != null )
                {
                    model . acid = row [ "acid" ] . ToString ( );
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
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                {
                    model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                }
                if ( row [ "cost" ] != null && row [ "cost" ] . ToString ( ) != "" )
                {
                    model . cost = decimal . Parse ( row [ "cost" ] . ToString ( ) );
                }
                if ( row [ "isSum" ] != null && row [ "isSum" ] . ToString ( ) != "" )
                {
                    if ( ( row [ "isSum" ] . ToString ( ) == "1" ) || ( row [ "isSum" ] . ToString ( ) . ToLower ( ) == "true" ) )
                    {
                        model . isSum = true;
                    }
                    else
                    {
                        model . isSum = false;
                    }
                }
            }
            return model;
        }

        /// <summary>
        /// 成品出库单是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists_isDel ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select count(1) from t_finishedprolist where plCode='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}
