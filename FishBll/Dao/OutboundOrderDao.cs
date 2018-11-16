using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class OutboundOrderDao
    {
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(code) code FROM t_OutboundOrder" );

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
		/// 删除一条数据
		/// </summary>
		public bool Delete ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_outboundorder " );
            strSql . Append ( " where code=@code " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = code;

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
		/// 增加一条数据
		/// </summary>
		public bool Add ( FishEntity . OutboundOrderEntity model ,string name )
        {
            Hashtable SQLString = new Hashtable ( );
            SQLString= ReviewInfo . getSQLString ( name ,model . code ,string . Empty ,SQLString );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_outboundorder(" );
            strSql . Append ( "seNumber,code,unit,type,shipName,weight,pileNum,codeNum,codeNumContract,date,waseHouse,speci,billName,pageNum,remark,notice,ware,receive,FishMealId,Country,Brands)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@seNumber,@code,@unit,@type,@shipName,@weight,@pileNum,@codeNum,@codeNumContract,@date,@waseHouse,@speci,@billName,@pageNum,@remark,@notice,@ware,@receive,@FishMealId,@Country,@Brands)" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@seNumber", MySqlDbType.VarChar,45),
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@unit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@pileNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@date", MySqlDbType.Date),
                    new MySqlParameter("@waseHouse", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@pageNum", MySqlDbType.Int32,11),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,225),
                    new MySqlParameter("@notice", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ware", MySqlDbType.Decimal,10),
                    new MySqlParameter("@receive", MySqlDbType.VarChar,45),
                    new MySqlParameter("@FishMealId", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Country", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Brands", MySqlDbType.VarChar,50)
            };
            parameters [ 0 ] . Value = model . seNumber;
            parameters [ 1 ] . Value = model . code;
            parameters [ 2 ] . Value = model . unit;
            parameters [ 3 ] . Value = model . type;
            parameters [ 4 ] . Value = model . shipName;
            parameters [ 5 ] . Value = model . weight;
            parameters [ 6 ] . Value = model . pileNum;
            parameters [ 7 ] . Value = model . codeNum;
            parameters [ 8 ] . Value = model . codeNumContract;
            parameters [ 9 ] . Value = model . date;
            parameters [ 10 ] . Value = model . waseHouse;
            parameters [ 11 ] . Value = model . speci;
            parameters [ 12 ] . Value = model . billName;
            parameters [ 13 ] . Value = model . pageNum;
            parameters [ 14 ] . Value = model . remark;
            parameters [ 15 ] . Value = model . notice;
            parameters [ 16 ] . Value = model . ware;
            parameters [ 17 ] . Value = model . receive;
            parameters [ 18 ] . Value = model . FishMealId;
            parameters [ 19 ] . Value = model . Country;
            parameters [ 20 ] . Value = model . Brands;
            SQLString . Add ( strSql ,parameters );

           return MySqlHelper . ExecuteSqlTran ( SQLString ) ;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update ( FishEntity . OutboundOrderEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_outboundorder set " );
            strSql . Append ( "seNumber=@seNumber," );
            strSql . Append ( "unit=@unit," );
            strSql . Append ( "type=@type," );
            strSql . Append ( "shipName=@shipName," );
            strSql . Append ( "weight=@weight," );
            strSql . Append ( "pileNum=@pileNum," );
            strSql . Append ( "codeNum=@codeNum," );
            strSql . Append ( "codeNumContract=@codeNumContract," );
            strSql . Append ( "date=@date," );
            strSql . Append ( "waseHouse=@waseHouse," );
            strSql . Append ( "speci=@speci," );
            strSql . Append ( "billName=@billName," );
            strSql . Append ( "pageNum=@pageNum," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "notice=@notice," );
            strSql . Append ( "ware=@ware," );
            strSql.Append("FishMealId=@FishMealId,");
            strSql.Append("Country=@Country,");
            strSql.Append("Brands=@Brands,");
            strSql . Append ( "receive=@receive" );
            strSql . Append ( " where code=@code " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@seNumber", MySqlDbType.VarChar,45),
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@unit", MySqlDbType.VarChar,45),
                    new MySqlParameter("@type", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@pileNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@date", MySqlDbType.Date),
                    new MySqlParameter("@waseHouse", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@pageNum", MySqlDbType.Int32,11),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,225),
                    new MySqlParameter("@notice", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ware", MySqlDbType.Decimal,10),
                    new MySqlParameter("@receive", MySqlDbType.VarChar,45),
                    new MySqlParameter("@FishMealId", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Country", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Brands", MySqlDbType.VarChar,50)
            };
            parameters [ 0 ] . Value = model . seNumber;
            parameters [ 1 ] . Value = model . code;
            parameters [ 2 ] . Value = model . unit;
            parameters [ 3 ] . Value = model . type;
            parameters [ 4 ] . Value = model . shipName;
            parameters [ 5 ] . Value = model . weight;
            parameters [ 6 ] . Value = model . pileNum;
            parameters [ 7 ] . Value = model . codeNum;
            parameters [ 8 ] . Value = model . codeNumContract;
            parameters [ 9 ] . Value = model . date;
            parameters [ 10 ] . Value = model . waseHouse;
            parameters [ 11 ] . Value = model . speci;
            parameters [ 12 ] . Value = model . billName;
            parameters [ 13 ] . Value = model . pageNum;
            parameters [ 14 ] . Value = model . remark;
            parameters [ 15 ] . Value = model . notice;
            parameters [ 16 ] . Value = model . ware;
            parameters [ 17 ] . Value = model . receive;
            parameters[18].Value = model.FishMealId;
            parameters[19].Value = model.Country;
            parameters[20].Value = model.Brands;

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
		/// 得到一个对象实体
		/// </summary>
		public FishEntity . OutboundOrderEntity GetModel ( string strWhere )
        {

            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("select id,seNumber,code,unit,type,shipName,weight,pileNum,codeNum,codeNumContract,date,waseHouse,speci,billName,pageNum,remark,notice,ware,receive,FishMealId,Country,Brands from t_outboundorder ");
            strSql . AppendFormat ( " where {0}" ,strWhere );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            if ( ds . Tables [ 0 ] . Rows . Count > 0 )
            {
                return DataRowToModel ( ds . Tables [ 0 ] . Rows [ 0 ] );
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity . OutboundOrderEntity DataRowToModel ( DataRow row )
        {
            FishEntity . OutboundOrderEntity model = new FishEntity . OutboundOrderEntity ( );
            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "seNumber" ] != null )
                {
                    model . seNumber = row [ "seNumber" ] . ToString ( );
                }
                if ( row [ "code" ] != null )
                {
                    model . code = row [ "code" ] . ToString ( );
                }
                if ( row [ "unit" ] != null )
                {
                    model . unit = row [ "unit" ] . ToString ( );
                }
                if ( row [ "type" ] != null )
                {
                    model . type = row [ "type" ] . ToString ( );
                }
                if ( row [ "shipName" ] != null )
                {
                    model . shipName = row [ "shipName" ] . ToString ( );
                }
                if ( row [ "weight" ] != null && row [ "weight" ] . ToString ( ) != "" )
                {
                    model . weight = decimal . Parse ( row [ "weight" ] . ToString ( ) );
                }
                if ( row [ "pileNum" ] != null )
                {
                    model . pileNum = row [ "pileNum" ] . ToString ( );
                }
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
                if ( row [ "codeNumContract" ] != null )
                {
                    model . codeNumContract = row [ "codeNumContract" ] . ToString ( );
                }
                if ( row [ "date" ] != null && row [ "date" ] . ToString ( ) != "" )
                {
                    model . date = DateTime . Parse ( row [ "date" ] . ToString ( ) );
                }
                if ( row [ "waseHouse" ] != null )
                {
                    model . waseHouse = row [ "waseHouse" ] . ToString ( );
                }
                if ( row [ "speci" ] != null )
                {
                    model . speci = row [ "speci" ] . ToString ( );
                }
                if ( row [ "billName" ] != null )
                {
                    model . billName = row [ "billName" ] . ToString ( );
                }
                if ( row [ "pageNum" ] != null && row [ "pageNum" ] . ToString ( ) != "" )
                {
                    model . pageNum = int . Parse ( row [ "pageNum" ] . ToString ( ) );
                }
                if ( row [ "remark" ] != null )
                {
                    model . remark = row [ "remark" ] . ToString ( );
                }
                if ( row [ "notice" ] != null )
                {
                    model . notice = row [ "notice" ] . ToString ( );
                }
                if ( row [ "ware" ] != null && row [ "ware" ] . ToString ( ) != "" )
                {
                    model . ware = decimal . Parse ( row [ "ware" ] . ToString ( ) );
                }
                if ( row [ "receive" ] != null )
                {
                    model . receive = row [ "receive" ] . ToString ( );
                }
                if (row["FishMealId"] !=null)
                {
                    model.FishMealId = row["FishMealId"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["Brands"] != null)
                {
                    model.Brands = row["Brands"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_outboundorder" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select count(1) from t_outboundorder where code='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,seNumber,code,unit,type,shipName,weight,pileNum,codeNum,codeNumContract,date,waseHouse,speci,billName,pageNum,remark,notice,ware,receive,FishMealId,Country,Brands from t_outboundorder ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            return ds.Tables[0];
        }
        public FishEntity.SalesRequisitionEntity getCKD(string getname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.Numbering,a.code,a.demand,a.demandId,a.Signdate,b.product_id,b.Country,b.pp,b.Quantity,b.cm,b.zjh,b.tdh,b.Funit from t_salesorder a LEFT JOIN t_happening b ON a.Numbering=b.NumberingOne ");
            strSql.Append("where " + getname + "");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Numbering"] != null)
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["product_id"] != null)
                {
                    model.Product_id = row["product_id"].ToString();
                }
                if (row["demand"] != null)
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["demandId"] != null)
                {
                    model.demandId = row["demandId"].ToString();
                }
                if (row["Signdate"] !=null)
                {
                    model.Signdate = DateTime.Parse(row["Signdate"].ToString());
                }
                if (row["cm"] != null)
                {
                    model.cm = row["cm"].ToString();
                }
                if (row["Quantity"] != null)
                {
                    model.Quantity = row["Quantity"].ToString();
                }
                if (row["zjh"] != null)
                {
                    model.zjh = row["zjh"].ToString();
                }
                if (row["tdh"] != null)
                {
                    model.tdh = row["tdh"].ToString();
                }
                if (row["Country"] !=null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["pp"]!=null)
                {
                    model.pp = row["pp"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
