using MySql . Data . MySqlClient;
using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class PurchaseAppFishInfoDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseAppFishInfoEntity> getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("select id,code,fishId,specifications,country,brand,shipName,billName,Money,num,price,conProtein,conTVN,conZA,conFFA,conZF,conSF,conSHY,conS,conSJ,conHF,conLAS,conDAS,choise,fastShipDate,lastShipDate,delPort,priceMY,EexchangeRate from t_purchaseappfishinfo WHERE {0}", strWhere );

            DataTable table = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];

            if ( table != null && table . Rows . Count > 0 )
            {
                List<FishEntity . PurchaseAppFishInfoEntity> modelList = new List<FishEntity . PurchaseAppFishInfoEntity> ( );
                for ( int i = 0 ; i < table . Rows . Count ; i++ )
                {
                    modelList . Add ( getModel ( table . Rows [ i ] ) );
                }
                return modelList;
            }
            else
                return null;
        }

        public FishEntity . PurchaseAppFishInfoEntity getModelOne ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select id,code,fishId,specifications,country,brand,shipName,billName,Money,num,price,conProtein,conTVN,conZA,conFFA,conZF,conSF,conSHY,conS,conSJ,conHF,conLAS,conDAS,choise,fastShipDate,lastShipDate,delPort from t_purchaseappfishinfo WHERE {0}" ,strWhere );

            DataTable table = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];

            if ( table != null && table . Rows . Count > 0 )
                return getModel ( table . Rows [ 0 ] );
            else
                return null;
        }

        public FishEntity . PurchaseAppFishInfoEntity getModel ( DataRow row )
        {
            FishEntity . PurchaseAppFishInfoEntity model = new FishEntity . PurchaseAppFishInfoEntity ( );
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
                if ( row [ "specifications" ] != null )
                {
                    model . specifications = row [ "specifications" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "shipName" ] != null )
                {
                    model . shipName = row [ "shipName" ] . ToString ( );
                }
                if ( row [ "billName" ] != null )
                {
                    model . billName = row [ "billName" ] . ToString ( );
                }
                if ( row [ "Money" ] != null && row [ "Money" ] . ToString ( ) != "" )
                {
                    model . money = decimal . Parse ( row [ "Money" ] . ToString ( ) );
                }
                if ( row [ "num" ] != null && row [ "num" ] . ToString ( ) != "" )
                {
                    model . num = decimal . Parse ( row [ "num" ] . ToString ( ) );
                }
                if (row["priceMY"] != null && row["priceMY"].ToString() != "")
                {
                    model.priceMY = decimal.Parse(row["priceMY"].ToString());
                }
                if (row["EexchangeRate"] != null && row["EexchangeRate"].ToString() != "")
                {
                    model.EexchangeRate = decimal.Parse(row["EexchangeRate"].ToString());
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if ( row [ "conProtein" ] != null )
                {
                    model . conProtein = row [ "conProtein" ] . ToString ( );
                }
                if ( row [ "conTVN" ] != null )
                {
                    model . conTVN = row [ "conTVN" ] . ToString ( );
                }
                if ( row [ "conZA" ] != null )
                {
                    model . conZA = row [ "conZA" ] . ToString ( );
                }
                if ( row [ "conFFA" ] != null )
                {
                    model . conFFA = row [ "conFFA" ] . ToString ( );
                }
                if ( row [ "conZF" ] != null )
                {
                    model . conZF = row [ "conZF" ] . ToString ( );
                }
                if ( row [ "conSF" ] != null )
                {
                    model . conSF = row [ "conSF" ] . ToString ( );
                }
                if ( row [ "conSHY" ] != null )
                {
                    model . conSHY = row [ "conSHY" ] . ToString ( );
                }
                if ( row [ "conS" ] != null )
                {
                    model . conS = row [ "conS" ] . ToString ( );
                }
                if ( row [ "conSJ" ] != null )
                {
                    model . conSJ = row [ "conSJ" ] . ToString ( );
                }
                if ( row [ "conHF" ] != null )
                {
                    model . conHF = row [ "conHF" ] . ToString ( );
                }
                if ( row [ "conLAS" ] != null )
                {
                    model . conLAS = row [ "conLAS" ] . ToString ( );
                }
                if ( row [ "conDAS" ] != null )
                {
                    model . conDAS = row [ "conDAS" ] . ToString ( );
                }
                if ( row [ "choise" ] != null )
                {
                    model . choise = row [ "choise" ] . ToString ( );
                }
                if ( row [ "delPort" ] != null )
                {
                    model . delPort = row [ "delPort" ] . ToString ( );
                }
                if ( row [ "fastShipDate" ] != null && row [ "fastShipDate" ] . ToString ( ) != "" )
                {
                    model . fastshipdate = DateTime . Parse ( row [ "fastShipDate" ] . ToString ( ) );
                }
                if ( row [ "lastShipDate" ] != null && row [ "lastShipDate" ] . ToString ( ) != "" )
                {
                    model . lastshipdate = DateTime . Parse ( row [ "lastShipDate" ] . ToString ( ) );
                }

            }
            return model;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( FishEntity . PurchaseAppFishInfoEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM t_purchaseappfishinfo WHERE code='{0}' and fishId='{1}'" ,model . code ,model . fishId );

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Save ( FishEntity . PurchaseAppFishInfoEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM t_purchaseappfishinfo WHERE code='{0}' and fishId='{1}'" ,model . code ,model . fishId );

            int rows = 0;
            if ( MySqlHelper . Exists ( strSql . ToString ( ) ) )
                rows = Edit ( strSql ,model );
            else
                rows = Add ( strSql ,model );

            return rows > 0 ? true : false;
        }

        int Edit ( StringBuilder strSql,FishEntity.PurchaseAppFishInfoEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update t_purchaseappfishinfo set " );
            strSql . Append ( "specifications=@specifications," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "shipName=@shipName," );
            strSql . Append ( "billName=@billName," );
            strSql . Append ( "Money=@Money," );
            strSql . Append ( "num=@num," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "conProtein=@conProtein," );
            strSql . Append ( "conTVN=@conTVN," );
            strSql . Append ( "conZA=@conZA," );
            strSql . Append ( "conFFA=@conFFA," );
            strSql . Append ( "conZF=@conZF," );
            strSql . Append ( "conSF=@conSF," );
            strSql . Append ( "conSHY=@conSHY," );
            strSql . Append ( "conS=@conS," );
            strSql . Append ( "conSJ=@conSJ," );
            strSql . Append ( "conHF=@conHF," );
            strSql . Append ( "conLAS=@conLAS," );
            strSql . Append ( "conDAS=@conDAS," );
            strSql . Append ( "choise=@choise," );
            strSql . Append ( "fastShipDate=@fastShipDate," );
            strSql . Append ( "lastShipDate=@lastShipDate," );
            strSql . Append ( "modifyTime=@modifyTime," );
            strSql.Append("priceMY=@priceMY,");
            strSql.Append("EexchangeRate=@EexchangeRate,");
            strSql . Append ( "modifyMan=@modifyMan " );
            strSql . Append ( "where code=@code and " );
            strSql . Append ( "fishId=@fishId" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@specifications", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@num", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@conProtein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conTVN", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conZA", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conFFA", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conZF", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conSF", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conSHY", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conS", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conSJ", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conHF", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conLAS", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conDAS", MySqlDbType.VarChar,45),
                    new MySqlParameter("@choise", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fastShipDate", MySqlDbType.DateTime),
                    new MySqlParameter("@lastShipDate", MySqlDbType.DateTime),
                    new MySqlParameter("@modifyTime", MySqlDbType.DateTime),
                    new MySqlParameter("@modifyMan", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,10),
                    new MySqlParameter("@EexchangeRate", MySqlDbType.Decimal,10)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . specifications;
            parameters [ 3 ] . Value = model . country;
            parameters [ 4 ] . Value = model . brand;
            parameters [ 5 ] . Value = model . shipName;
            parameters [ 6 ] . Value = model . billName;
            parameters [ 7 ] . Value = model . money;
            parameters [ 8 ] . Value = model . num;
            parameters [ 9 ] . Value = model . price;
            parameters [ 10 ] . Value = model . conProtein;
            parameters [ 11 ] . Value = model . conTVN;
            parameters [ 12 ] . Value = model . conZA;
            parameters [ 13 ] . Value = model . conFFA;
            parameters [ 14 ] . Value = model . conZF;
            parameters [ 15 ] . Value = model . conSF;
            parameters [ 16 ] . Value = model . conSHY;
            parameters [ 17 ] . Value = model . conS;
            parameters [ 18 ] . Value = model . conSJ;
            parameters [ 19 ] . Value = model . conHF;
            parameters [ 20 ] . Value = model . conLAS;
            parameters [ 21 ] . Value = model . conDAS;
            parameters [ 22 ] . Value = model . choise;
            parameters [ 23 ] . Value = model . fastshipdate;
            parameters [ 24 ] . Value = model . lastshipdate;
            parameters [ 25 ] . Value = model . modifyTime;
            parameters [ 26 ] . Value = model . modifyMan;
            parameters[27].Value = model.priceMY;
            parameters[28].Value = model.EexchangeRate;

            return  MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameters );
        }

        int Add ( StringBuilder strSql ,FishEntity . PurchaseAppFishInfoEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_purchaseappfishinfo(" );
            strSql . Append ("code,fishId,specifications,country,brand,shipName,billName,Money,num,price,conProtein,conTVN,conZA,conFFA,conZF,conSF,conSHY,conS,conSJ,conHF,conLAS,conDAS,choise,fastShipDate,lastShipDate,createTime,createMan,priceMY,EexchangeRate)");
            strSql . Append ( " values (" );
            strSql . Append ("@code,@fishId,@specifications,@country,@brand,@shipName,@billName,@Money,@num,@price,@conProtein,@conTVN,@conZA,@conFFA,@conZF,@conSF,@conSHY,@conS,@conSJ,@conHF,@conLAS,@conDAS,@choise,@fastShipDate,@lastShipDate,@createTime,@createMan,@priceMY,@EexchangeRate)");
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@specifications", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@Money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@num", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@conProtein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conTVN", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conZA", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conFFA", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conZF", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conSF", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conSHY", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conS", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conSJ", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conHF", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conLAS", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conDAS", MySqlDbType.VarChar,45),
                    new MySqlParameter("@choise", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fastShipDate", MySqlDbType.DateTime),
                    new MySqlParameter("@lastShipDate", MySqlDbType.DateTime),
                    new MySqlParameter("@createTime", MySqlDbType.DateTime),
                    new MySqlParameter("@createMan", MySqlDbType.VarChar,45),
                    new MySqlParameter("@priceMY",MySqlDbType.Decimal,10),
                    new MySqlParameter("EexchangeRate",MySqlDbType.Decimal,10)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . specifications;
            parameters [ 3 ] . Value = model . country;
            parameters [ 4 ] . Value = model . brand;
            parameters [ 5 ] . Value = model . shipName;
            parameters [ 6 ] . Value = model . billName;
            parameters [ 7 ] . Value = model . money;
            parameters [ 8 ] . Value = model . num;
            parameters [ 9 ] . Value = model . price;
            parameters [ 10 ] . Value = model . conProtein;
            parameters [ 11 ] . Value = model . conTVN;
            parameters [ 12 ] . Value = model . conZA;
            parameters [ 13 ] . Value = model . conFFA;
            parameters [ 14 ] . Value = model . conZF;
            parameters [ 15 ] . Value = model . conSF;
            parameters [ 16 ] . Value = model . conSHY;
            parameters [ 17 ] . Value = model . conS;
            parameters [ 18 ] . Value = model . conSJ;
            parameters [ 19 ] . Value = model . conHF;
            parameters [ 20 ] . Value = model . conLAS;
            parameters [ 21 ] . Value = model . conDAS;
            parameters [ 22 ] . Value = model . choise;
            parameters [ 23 ] . Value = model . fastshipdate;
            parameters [ 24 ] . Value = model . lastshipdate;
            parameters [ 25 ] . Value = model . createTime;
            parameters [ 26 ] . Value = model . createMan;
            parameters[27].Value = model.priceMY;
            parameters[28].Value = model.EexchangeRate;

            return MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameters );
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsFishId(string FishId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM t_purchaseapplication WHERE fishId='{0}' and choise='报盘' ", FishId);

            return MySqlHelper.Exists(strSql.ToString());
        }
        public bool ExistsFishId1(string FishId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM t_purchaseappfishinfo  WHERE fishId='{0}'", FishId);

            return MySqlHelper.Exists(strSql.ToString());
        }
    }
}
