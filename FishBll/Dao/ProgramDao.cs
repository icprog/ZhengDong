using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class ProgramDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . ProgramEntity> getList ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select programId,programName,programTable from t_program" );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );

            DataTable dt = ds . Tables [ 0 ];

            List<FishEntity . ProgramEntity> modelList = new List<FishEntity . ProgramEntity> ( );

            if ( dt != null && dt . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    modelList . Add ( getModel ( dt . Rows [ i ] ) );
                }

                return modelList;
            }
            else
                return null;
            
        }

        public FishEntity . ProgramEntity getModel ( DataRow row )
        {
            FishEntity . ProgramEntity model = new FishEntity . ProgramEntity ( );

            if ( row != null )
            {
                if ( row [ "programId" ] != null )
                    model . programId = row [ "programId" ] . ToString ( );
                if ( row [ "programName" ] != null )
                    model . programName = row [ "programName" ] . ToString ( );
                if ( row [ "programTable" ] != null && row [ "programTable" ] . ToString ( ) != "" )
                    model . programTable = row [ "programTable" ] . ToString ( );
            }


            return model;
        }

        /// <summary>
        /// 删除全部记录
        /// </summary>
        /// <returns></returns>
        public bool Delete ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_program" );

            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        DateTime dt ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT now() t" );

            DataSet da = MySqlHelper . Query ( strSql . ToString ( ) );

            return Convert . ToDateTime ( da . Tables [ 0 ] . Rows [ 0 ] [ "t" ] . ToString ( ) );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool add ( List<FishEntity . ProgramEntity> modelList,string userName )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            foreach ( FishEntity . ProgramEntity list in modelList )
            {
                list . createMan = list . modifyMan = userName;
                list . createTime = list . modifyTime = dt ( );

                if ( Exists ( list . programId ) == false )
                    add_pro ( list ,SQLString ,strSql );
                else
                    edit_pro ( list ,SQLString ,strSql );
            }

            DataTable tab = table ( );
            if ( tab != null && tab . Rows . Count > 0 )
            {
                string id = string . Empty;
                FishEntity . ProgramEntity list = new FishEntity . ProgramEntity ( );
                for ( int i = 0 ; i < tab . Rows . Count ; i++ )
                {
                    id = list . programId = tab . Rows [ i ] [ "programId" ] . ToString ( );
                    list = modelList . Find ( ( t ) =>
                    {
                        return t . programId . Equals ( list . programId );
                    } );

                    if ( list == null )
                    {
                        delete_pro ( id ,SQLString ,strSql );
                    }
                }
            }


            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        public bool Exists ( string programId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select count(1) coun from t_program " );
            strSql . Append ( "where programId=@programId" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@programId",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = programId;

            return MySqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        void add_pro ( FishEntity . ProgramEntity list ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_program (" );
            strSql . Append ( "programId,programName,programTable,createTime,createMan,modifyTime,modifyMan) " );
            strSql . Append ( "values (" );
            strSql . Append ( "@programId,@programName,@programTable,@createTime,@createMan,@modifyTime,@modifyMan) " );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@programName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programTable",MySqlDbType.VarChar,45),
                new MySqlParameter("@createTime",MySqlDbType.DateTime),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = list . programId;
            parameter [ 1 ] . Value = list . programName;
            parameter [ 2 ] . Value = list . programTable;
            parameter [ 3 ] . Value = list . createTime;
            parameter [ 4 ] . Value = list . createMan;
            parameter [ 5 ] . Value = list . modifyTime;
            parameter [ 6 ] . Value = list . modifyMan;

            SQLString . Add ( strSql ,parameter );
        }

        void edit_pro ( FishEntity . ProgramEntity list ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update t_program set " );
            strSql . Append ( "programName=@programName," );
            strSql . Append ( "programTable=@programTable," );
            strSql . Append ( "modifyTime=@modifyTime," );
            strSql . Append ( "modifyMan=@modifyMan " );
            strSql . Append ( "where programId=@programId" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@programId",MySqlDbType.VarChar,45),
                new MySqlParameter("@programName",MySqlDbType.VarChar,45),
                new MySqlParameter("@programTable",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = list . programId;
            parameter [ 1 ] . Value = list . programName;
            parameter [ 2 ] . Value = list . programTable;
            parameter [ 3 ] . Value = list . modifyTime;
            parameter [ 4 ] . Value = list . modifyMan;

            SQLString . Add ( strSql ,parameter );
        }

        public DataTable table ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select programId from t_program" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        void delete_pro ( string id ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_program " );
            strSql . Append ( "where programId=@programId" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@programId",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = id;

            SQLString . Add ( strSql ,parameter );
        }

    }
}
