using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll
{
    /// <summary>
    /// C#操作MYSQL数据库基类
    /// </summary>
    public abstract class MySqlHelper
    {
        //127.0.0.1
        //数据库连接字符串(web.config来配置)
         //public static string connectionString = Utility.IniUtil.ReadIniValue
        //    (AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "MySqlString");
        protected static string _connectionString = string.Empty;

        public MySqlHelper()
        {
            string a = string.Empty;
        }

        public static string connectionString



        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    string host = Utility.IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "host");
                    string port = Utility.IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "port");
                    string dbname = Utility.IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "dbname");
                    string user = Utility.IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "user");
                    string password = Utility.IniUtil.ReadIniValue(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "Config.ini", "DB", "password");
                    string passwordEx = Utility.DesEncryptUtil.DecryptDES(password, FishEntity.Constant.KEY);
                    _connectionString = string.Format("Data Source={0};Port={1};Database={2};User Id={3};Password={4};charset=utf8;pooling=true;Connection Timeout=5", host, port, dbname, user, passwordEx);
                }
                return _connectionString;
            }
        }

        #region  执行简单SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        //try
                        //{
                        //    SaveLog(SQLString);
                        //}
                        //catch (Exception ex)
                        //{
                        //    Utility.LogHelper.WriteException(ex);
                        //    throw;
                        //}
                        //try
                        //{

                        //}
                        //catch (Exception)
                        //{

                        //    throw;
                        //}
                        return rows;
                    }
                    catch (MySqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，设置命令的执行等待时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static int ExecuteSqlByTime(string SQLString, int Times)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        cmd.CommandTimeout = Times;
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (MySqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }


        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, string content)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(SQLString, connection);
                MySqlParameter myParameter = new MySqlParameter("@content", MySqlDbType.Text);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (MySqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行带一个存储过程参数的的SQL语句。
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="content">参数内容,比如一个字段是格式复杂的文章，有特殊符号，可以通过这个方式添加</param>
        /// <returns>影响的记录数</returns>
        public static object ExecuteSqlGet(string SQLString, string content)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(SQLString, connection);
                MySqlParameter myParameter = new MySqlParameter("@content", MySqlDbType.Text);
                myParameter.Value = content;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (MySqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 向数据库里插入图像格式的字段(和上面情况类似的另一种实例)
        /// </summary>
        /// <param name="strSQL">SQL语句</param>
        /// <param name="fs">图像字节,数据库的字段类型为image的情况</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSqlInsertImg(string strSQL, byte[] fs)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(strSQL, connection);
                MySqlParameter myParameter = new MySqlParameter("@fs", MySqlDbType.Binary);
                myParameter.Value = fs;
                cmd.Parameters.Add(myParameter);
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (MySqlException E)
                {
                    throw new Exception(E.Message);
                }
                finally
                {
                    cmd.Dispose();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回MySqlDataReader(使用该方法切记要手工关闭MySqlDataReader和连接)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader ExecuteReader(string strSQL)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                return myReader;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用
            //{
            // cmd.Dispose();
            // connection.Close();
            //} 


        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter da = new MySqlDataAdapter(SQLString, connection);
                    da.Fill(ds);
                }
                catch (MySqlException ex)
                {
                    connection.Close();
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();

                }
                connection.Close();
                return ds;
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataSet,设置命令的执行等待时间
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="Times"></param>
        /// <returns></returns>
        public static DataSet Query(string SQLString, int Times)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.SelectCommand.CommandTimeout = Times;
                    command.Fill(ds, "ds");
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
                return ds;
            }
        }

        /// <summary>
        /// 获取SQL查询记录条数
        /// </summary>
        /// <param name="sqlstr">SQL语句</param>
        /// <returns></returns>
        public static int GetRowsNum(string SQLString)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    MySqlDataAdapter command = new MySqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                    return ds.Tables[0].Rows.Count;
                }
                catch (MySqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句，返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public static int ExecuteSql(string SQLString, params  Object[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        //try
                        //{
                        //    SaveLog(SQLString, cmdParms);
                        //}
                        //catch (Exception ex)
                        //{
                        //    Utility.LogHelper.WriteException(ex);
                        //    throw;
                        //}
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (MySqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行SQL语句，返回自增列值
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static int ExecuteSqlReturnId(string SQLString, params object[] cmdParams)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParams);
                        try
                        {
                            SaveLog(SQLString, cmdParams);
                        }
                        catch (Exception ex)
                        {
                            Utility.LogHelper.WriteException(ex);
                            throw;
                        }
                        object obj = cmd.ExecuteScalar();
                        
                        cmd.Parameters.Clear();
                        if (obj == null) return 0;
                        else
                        return Convert.ToInt32 ( obj);
                    }
                    catch (MySqlException E)
                    {
                        throw new Exception(E.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }



        //public static void ExecuteSqlTran(Hashtable SQLStringList)
        //{
        //    using (MySqlConnection conn = new MySqlConnection(connectionString))
        //    {
        //        conn.Open();
        //        using (MySqlTransaction trans = conn.BeginTransaction())
        //        {
        //            MySqlCommand cmd = new MySqlCommand();
        //            try
        //            {
        //                //循环
        //                foreach (DictionaryEntry myDE in SQLStringList)
        //                {
        //                    string cmdText = myDE.Key.ToString();
        //                    Object[] cmdParms = (Object[])myDE.Value;
        //                    PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
        //                    int val = cmd.ExecuteNonQuery();
        //                    cmd.Parameters.Clear();

        //                    trans.Commit();
        //                }
        //            }
        //            catch
        //            {
        //                trans.Rollback();
        //                throw;
        //            }
        //            finally
        //            {
        //                cmd.Dispose();
        //                conn.Close();
        //            }
        //        }
        //    }
        //}


        /// <summary>
        /// 执行一条计算查询结果语句，返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public static object GetSingle(string SQLString, params  Object[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (MySqlException e)
                    {
                        throw new Exception(e.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回MySqlDataReader (使用该方法切记要手工关闭MySqlDataReader和连接)
        /// </summary>
        /// <param name="strSQL">查询语句</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader ExecuteReader(string SQLString, params  Object[] cmdParms)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                MySqlDataReader myReader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (MySqlException e)
            {
                throw new Exception(e.Message);
            }
            //finally //不能在此关闭，否则，返回的对象将无法使用
            //{
            // cmd.Dispose();
            // connection.Close();
            //} 

        }

        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params  Object[] cmdParms)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (MySqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        cmd.Dispose();
                        connection.Close();
                    }
                    return ds;
                }
            }
        }

        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, string cmdText, Object[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (MySqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region 存储过程操作

        /// <summary>
        /// 执行存储过程  (使用该方法切记要手工关闭MySqlDataReader和连接)
        /// 手动关闭不了，所以少用，MySql.Data组组件还没解决该问题
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>MySqlDataReader</returns>
        public static MySqlDataReader RunProcedure(string storedProcName, Object[] parameters)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlDataReader returnReader;
            connection.Open();
            MySqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.CommandType = CommandType.StoredProcedure;
            returnReader = command.ExecuteReader();
            //Connection.Close(); 不能在此关闭，否则，返回的对象将无法使用            
            return returnReader;

        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        public static DataSet RunProcedure(string storedProcName, Object[] parameters, string tableName)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                MySqlDataAdapter sqlDA = new MySqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        public static DataSet RunProcedure(string storedProcName, Object[] parameters, string tableName, int Times)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                MySqlDataAdapter sqlDA = new MySqlDataAdapter();
                sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
                sqlDA.SelectCommand.CommandTimeout = Times;
                sqlDA.Fill(dataSet, tableName);
                connection.Close();
                return dataSet;
            }
        }

        /// <summary>
        /// 执行存储过程 
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns></returns>
        public static void RunProcedureNull(string storedProcName, Object[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                //MySqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
                MySqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="CommandText">T-SQL语句；例如："pr_shell 'dir *.exe'"或"select * from sysobjects where xtype=@xtype"</param>
        /// <param name="parameters">SQL参数</param>
        /// <returns>返回第一行第一列</returns>
        public object ExecuteScaler(string storedProcName, Object[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                object returnObjectValue;
                connection.Open();
                MySqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
                returnObjectValue = command.ExecuteScalar();
                connection.Close();
                return returnObjectValue;
            }
        }

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        private static MySqlCommand BuildQueryCommand(MySqlConnection connection, string storedProcName, Object[] parameters)
        {
            MySqlCommand command = new MySqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (MySqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }

            return command;
        }

        /// <summary>
        /// 创建 MySqlCommand 对象实例(用来返回一个整数值) 
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>MySqlCommand 对象实例</returns>
        private static MySqlCommand BuildIntCommand(MySqlConnection connection, string storedProcName, Object[] parameters)
        {
            MySqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new MySqlParameter("ReturnValue",
                MySqlDbType.Int32, 4, ParameterDirection.ReturnValue,
                false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }

        #endregion

        /// <summary>
        /// MySqlDataReader转换成DataTable
        /// </summary>
        /// <param name="dataReader"></param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(MySqlDataReader dataReader)
        {
            DataTable datatable = new DataTable();
            DataTable schemaTable = dataReader.GetSchemaTable();

            //动态添加列
            try
            {
                foreach (DataRow myRow in schemaTable.Rows)
                {
                    DataColumn myDataColumn = new DataColumn();
                    myDataColumn.DataType = myRow.GetType();
                    myDataColumn.ColumnName = myRow[0].ToString();
                    datatable.Columns.Add(myDataColumn);
                }
                //添加数据
                while (dataReader.Read())
                {
                    DataRow myDataRow = datatable.NewRow();
                    for (int i = 0; i < schemaTable.Rows.Count; i++)
                    {
                        myDataRow[i] = dataReader[i].ToString();
                    }
                    datatable.Rows.Add(myDataRow);
                    myDataRow = null;
                }
                schemaTable = null;
                dataReader.Close();
                return datatable;
            }
            catch (Exception ex)
            {
                throw new Exception("转换出错出错!", ex);
            }
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdParms"></param>
        /// <returns></returns>
        public static bool Exists(string sql , params  Object[] cmdParms )
        {
            object result = GetSingle(sql, cmdParms);
            if (result == null) return false;
            int count = 0;
            int.TryParse ( result.ToString () , out count );
            return count > 0? true : false;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句，value是该语句的 Object[]）</param>
        public static bool ExecuteSqlTran ( Hashtable SQLStringList )
        {
            bool result = false;
            using ( MySqlConnection conn = new MySqlConnection ( connectionString ) )
            {
                conn . Open ( );
                using ( MySqlTransaction trans = conn . BeginTransaction ( ) )
                {
                    MySqlCommand cmd = new MySqlCommand ( );
                    try
                    {
                        //循环
                        foreach ( DictionaryEntry myDE in SQLStringList )
                        {
                            string cmdText = myDE . Key . ToString ( );
                            Object [ ] cmdParms = ( Object [ ] ) myDE . Value;
                            PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                            int val = cmd . ExecuteNonQuery ( );
                            try
                            {
                                    SaveLog(cmdText, cmdParms);
                            }
                            catch (Exception ex)
                            {
                                Utility.LogHelper.WriteException(ex);
                                cmd.Dispose();
                                conn.Close();
                                throw;
                            }
                            cmd . Parameters . Clear ( );
                        }
                        trans . Commit ( );
                        result = true;
                    }
                    catch ( MySqlException ex )
                    {
                        trans . Rollback ( );
                        result = false;
                        Utility . LogHelper . WriteException ( ex );
                        cmd.Dispose();
                        conn.Close();
                    }
                    finally
                    {
                        cmd . Dispose ( );
                        conn . Close ( );
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>  
        public static void ExecuteSqlTran ( ArrayList SQLStringList )
        {
            using ( MySqlConnection conn = new MySqlConnection ( connectionString ) )
            {
                conn . Open ( );
                MySqlCommand cmd = new MySqlCommand ( );
                cmd . Connection = conn;
                MySqlTransaction tx = conn . BeginTransaction ( );
                cmd . Transaction = tx;
                try
                {
                    for ( int n = 0 ; n < SQLStringList . Count ; n++ )
                    {
                        string strsql = SQLStringList [ n ] . ToString ( );
                        if ( strsql . Trim ( ) . Length > 1 )
                        {
                            cmd . CommandText = strsql;
                            cmd . ExecuteNonQuery ( );
                        }
                    }
                    tx . Commit ( );
                }
                catch ( MySqlException E )
                {
                    tx . Rollback ( );
                    throw new Exception ( E . Message );
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句，实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>  
        public static bool ExecuteSqlTranBool ( ArrayList SQLStringList )
        {
            using ( MySqlConnection conn = new MySqlConnection ( connectionString ) )
            {
                conn . Open ( );
                MySqlCommand cmd = new MySqlCommand ( );
                cmd . Connection = conn;
                MySqlTransaction tx = conn . BeginTransaction ( );
                cmd . Transaction = tx;
                try
                {
                    for ( int n = 0 ; n < SQLStringList . Count ; n++ )
                    {
                        string strsql = SQLStringList [ n ] . ToString ( );
                        if ( strsql . Trim ( ) . Length > 1 )
                        {
                            cmd . CommandText = strsql;
                            cmd . ExecuteNonQuery ( );
                            try
                            {
                                SaveLog(strsql);
                            }
                            catch (Exception ex)
                            {
                                Utility.LogHelper.WriteException(ex);
                                throw;
                            }
                        }
                    }
                    tx . Commit ( );
                    return true;
                }
                catch ( MySqlException E )
                {
                    tx . Rollback ( );
                    return false;
                    throw new Exception ( E . Message );
                }
                finally
                {
                    cmd . Dispose ( );
                    conn . Close ( );
                }
            }
        }
        public static void SaveLog(string cmdText)
        {
            if (cmdText.Contains("MOXLOG"))
            {
                return;
            }
            string param = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_monitor(TODO,sqlstr,FormName,createman,createtime)");
            strSql.AppendFormat("values('{0}','{1}','{2}','{3}','{4}')", FishEntity.Variable.User.TODO, cmdText.Replace("'", "''"),FishEntity.Variable.User.ThisName, FishEntity.Variable.User.username, FishEntity.Variable.User.createtime);
            MySqlHelper.ExecuteReader(strSql.ToString());
        }
        public static void SaveLog(string cmdText, string parameters)
        {
            if (cmdText.Contains("MOXLOG"))
            {
                return;
            }
            string param = string.Empty;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_monitor(TODO,sqlstr,FormName,createman,createtime,parameters)");
            strSql.AppendFormat("values('{0}','{1}','{2}','{3}','{4}',{5})", FishEntity.Variable.User.TODO, cmdText.Replace("'", "''"), FishEntity.Variable.User.ThisName, FishEntity.Variable.User.username, FishEntity.Variable.User.createtime, param);
            MySqlHelper.ExecuteReader(strSql.ToString());
        }
        public static void SaveLog(string cmdText, params MySqlParameter[] cmdParms)
        {
            if (cmdText.Contains("MOXLOG"))
            {
                return;
            }
            string param = string.Empty;
            if (cmdParms.Length > 0)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if (param == string.Empty)
                    {
                        param = "["+parameter.ToString()+":"+parameter.Value.ToString()+"]";
                    }
                    else
                    {
                            param+= "[" + parameter.ToString() + ":" + parameter.Value.ToString() + "]";
                    }
                }                  
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_monitor(TODO,sqlstr,FormName,createman,createtime,parameters)");
            strSql.AppendFormat("values('{0}','{1}','{2}','{3}','{4}','{5}')", FishEntity.Variable.User.TODO, cmdText.Replace("'", "''"), FishEntity.Variable.User.ThisName, FishEntity.Variable.User.username, FishEntity.Variable.User.createtime, param);
            MySqlHelper.ExecuteReader(strSql.ToString());
        }
        public static void SaveLog(string cmdText, params Object[] cmdParms)
        {
            if (cmdText.Contains("t_monitor"))
            {
                return;
            }
            string param = string.Empty;
            if (cmdParms==null)
            {
                return;
            }
            if (cmdParms.Length>0)
            {
                foreach (MySqlParameter parameter in cmdParms)
                {
                    if (param == string.Empty)
                    {
                        param = "[" + parameter.ToString() + ":" + parameter.Value.ToString() + "]";
                    }
                    else
                    {
                        param += "[" + parameter.ToString() + ":" + parameter.Value.ToString() + "]";
                    }
                }                
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_monitor(TODO,sqlstr,FormName,createman,createtime,parameters)");
            strSql.AppendFormat("values('{0}','{1}','{2}','{3}','{4}','{5}')",FishEntity.Variable.User.TODO,cmdText.Replace("'","''"), FishEntity.Variable.User.ThisName, FishEntity.Variable.User.username, FishEntity.Variable.User.createtime, param);
            MySqlHelper.ExecuteReader(strSql.ToString());
        }
    }
}
