using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class CustomStandardTableDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT max(code) code from t_CustomStandardTable" );

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
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public string getFishId ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select max(fishId) fishId from t_CustomStandardTable" );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string fishId = dt . Rows [ 0 ] [ "fishId" ] . ToString ( );
                if ( string . IsNullOrEmpty ( fishId ) )
                    return "XY" + DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( fishId . Substring ( 2 ,8 ) . Equals ( DateTime . Now . ToString ( "yyyyMMdd" ) ) )
                        return "XY" + ( Convert . ToInt64 ( fishId . Substring ( 2 ,11 ) ) + 1 ) . ToString ( );
                    else
                        return "XY" + DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return "XY" + DateTime . Now . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_CustomStandardTable where code='{0}'" ,code );

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在鱼粉ID
        /// </summary>
        /// <param name="fishId"></param>
        /// <returns></returns>
        public bool Exists_idFishId (string fishId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM t_finishedprolist WHERE fishId='{0}'" ,fishId );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . CustomStandardTableEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_customstandardtable set " );
            strSql . Append ( "ash=@ash," );
            strSql . Append ( "protein=@protein," );
            strSql . Append ( "xd=@xd," );
            strSql . Append ( "fat=@fat," );
            strSql . Append ( "ffa=@ffa," );
            strSql . Append ( "water=@water," );
            strSql . Append ( "histamine=@histamine," );
            strSql . Append ( "shy=@shy," );
            strSql . Append ( "level=@level," );
            strSql . Append ( "fishId=@fishId," );
            strSql.Append("TVN=@TVN,");
            strSql . Append ( "xsCode=@xsCode" );
            strSql . Append ( " where code=@code" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@xd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fat", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ffa", MySqlDbType.VarChar,45),
                    new MySqlParameter("@water", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@level", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@xsCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@TVN",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . ash;
            parameters [ 2 ] . Value = model . protein;
            parameters [ 3 ] . Value = model . xd;
            parameters [ 4 ] . Value = model . fat;
            parameters [ 5 ] . Value = model . ffa;
            parameters [ 6 ] . Value = model . water;
            parameters [ 7 ] . Value = model . histamine;
            parameters [ 8 ] . Value = model . shy;
            parameters [ 9 ] . Value = model . level;
            parameters [ 10 ] . Value = model . fishId;
            parameters [ 11 ] . Value = model . xsCode;
            parameters[12].Value = model.TVN;

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
        /// 保存一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Save ( FishEntity . CustomStandardTableEntity model ,string name)
        {
            Hashtable SQLString = new Hashtable ( );
            SQLString=ReviewInfo . getSQLString ( name ,model . code ,string . Empty ,SQLString);
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_customstandardtable(" );
            strSql . Append ("code,ash,protein,xd,fat,ffa,water,histamine,shy,level,fishId,xsCode,TVN)");
            strSql . Append ( " values (" );
            strSql . Append ( "@code,@ash,@protein,@xd,@fat,@ffa,@water,@histamine,@shy,@level,@fishId,@xsCode,@TVN)" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@xd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fat", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ffa", MySqlDbType.VarChar,45),
                    new MySqlParameter("@water", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@level", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@xsCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@TVN",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . ash;
            parameters [ 2 ] . Value = model . protein;
            parameters [ 3 ] . Value = model . xd;
            parameters [ 4 ] . Value = model . fat;
            parameters [ 5 ] . Value = model . ffa;
            parameters [ 6 ] . Value = model . water;
            parameters [ 7 ] . Value = model . histamine;
            parameters [ 8 ] . Value = model . shy;
            parameters [ 9 ] . Value = model . level;
            parameters [ 10 ] . Value = model . fishId;
            parameters [ 11 ] . Value = model . xsCode;
            parameters[12].Value = model.TVN;
            SQLString.Add(strSql, parameters);
            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . CustomStandardTableEntity> getModel ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select id,code,ash,protein,xd,fat,ffa,water,histamine,shy,level,fishId,xsCode,tvn from t_customstandardtable " );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                List<FishEntity . CustomStandardTableEntity> modelList = new List<FishEntity . CustomStandardTableEntity> ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    modelList . Add ( getModel ( dt . Rows [ i ] ) );
                }
                return modelList;
            }
            else
                return null;
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public FishEntity . CustomStandardTableEntity getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select id,code,ash,protein,xd,fat,ffa,water,histamine,shy,level,fishId,xsCode,TVN from t_customstandardtable where {0}" ,strWhere );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return getModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }

        public FishEntity . CustomStandardTableEntity getModel ( DataRow row )
        {
            FishEntity . CustomStandardTableEntity model = new FishEntity . CustomStandardTableEntity ( );
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
                if (row["TVN"]!=null)
                {
                    model.TVN = row["tvn"].ToString();
                }
                if ( row [ "ash" ] != null )
                {
                    model . ash = row [ "ash" ] . ToString ( );
                }
                if ( row [ "protein" ] != null )
                {
                    model . protein = row [ "protein" ] . ToString ( );
                }
                if ( row [ "xd" ] != null )
                {
                    model . xd = row [ "xd" ] . ToString ( );
                }
                if ( row [ "fat" ] != null )
                {
                    model . fat = row [ "fat" ] . ToString ( );
                }
                if ( row [ "ffa" ] != null )
                {
                    model . ffa = row [ "ffa" ] . ToString ( );
                }
                if ( row [ "water" ] != null )
                {
                    model . water = row [ "water" ] . ToString ( );
                }
                if ( row [ "histamine" ] != null )
                {
                    model . histamine = row [ "histamine" ] . ToString ( );
                }
                if ( row [ "shy" ] != null )
                {
                    model . shy = row [ "shy" ] . ToString ( );
                }
                if ( row [ "level" ] != null )
                {
                    model . level = row [ "level" ] . ToString ( );
                }
                if ( row [ "fishId" ] != null )
                {
                    model . fishId = row [ "fishId" ] . ToString ( );
                }
                if ( row [ "xsCode" ] != null )
                {
                    model . xsCode = row [ "xsCode" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select count(1) from t_customstandardtable where code='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

    }
}
