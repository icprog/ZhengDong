using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class AccountsReceivableDao
    {
        public AccountsReceivableDao ( )
        {
        }
        
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public bool Exist ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT COUNT(1) COUN FROM t_AccountsReceivableHead " );
            strSql . Append ( "WHERE yfId=@yfId" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            return MySqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }

        /// <summary>
        /// 编辑单头记录
        /// </summary>
        /// <param name="yfId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool head_one ( string yfId,string userName )
        {
            Hashtable SQLString = new Hashtable ( );
            
            DataTable da = GetDataTableCode ( yfId );
            if ( da == null || da . Rows . Count < 1 )
                return false;
            FishEntity . AccountsReceivableHead _head = new FishEntity . AccountsReceivableHead ( );
            _head . yfId = yfId;
            _head . province = da . Rows [ 0 ] [ "province" ] . ToString ( );
            _head . region = da . Rows [ 0 ] [ "zone" ] . ToString ( );
            _head . customer = da . Rows [ 0 ] [ "fullname" ] . ToString ( );
            _head . salesman = da . Rows [ 0 ] [ "salesman" ] . ToString ( );

            da = null;
            da = GetDataTableAmountOne ( yfId );
            if ( da != null && da . Rows . Count > 0 )
                _head . yearArrears = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) );
            else
                _head . yearArrears = 0;

            da = null;
            da = GetDataTableAmountTwo ( yfId );
            if ( da != null && da . Rows . Count > 0 )
                _head . monthReceivable = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) );
            else
                _head . monthReceivable = 0;

            da = null;
            da = GetDataTableAmountTre ( yfId );
            if ( da != null && da . Rows . Count > 0 )
                _head . monthNetreceipts = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) );
            else
                _head . monthNetreceipts = 0;

            da = null;
            da = GetDataTableAmountFor ( yfId );
            if( da != null && da . Rows.Count>0)
                _head . YearReceivable = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) );
            else
                _head . YearReceivable = 0;

            da = null;
            da = GetDataTableAmountFiv ( yfId );
            if ( da != null && da . Rows . Count > 0 )
                _head . yearNetreceipts = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ 0 ] [ "rmb" ] . ToString ( ) );
            else
                _head . yearNetreceipts = 0;

            da = null;
            da = count ( yfId );
            if ( da != null && da . Rows . Count > 0 )
                _head . count = string . IsNullOrEmpty ( da . Rows [ 0 ] [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ 0 ] [ "coun" ] . ToString ( ) );
            else
                _head . count = 0;

            da = null;
            da = remark ( yfId );
            if ( da != null && da . Rows . Count > 0 )
                _head . remark = da . Rows [ 0 ] [ "remark" ] . ToString ( );
            else
                _head . remark = string . Empty;

            _head . createTime = _head . modifyTime = getTime ( );
            _head . createMan = _head . modifyMan = userName;

            StringBuilder strSql = new StringBuilder ( );

            if ( Exist ( yfId ) == true )
                edit ( _head ,SQLString ,strSql );
            else
                add ( _head ,SQLString ,strSql );

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit ( FishEntity . AccountsReceivableHead _head ,Hashtable SQLString ,StringBuilder strSql)
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_AccountsReceivableHead SET " );
            strSql . Append ( "province=@province," );
            strSql . Append ( "region=@region," );
            strSql . Append ( "customer=@customer," );
            strSql . Append ( "salesman=@salesman," );
            strSql . Append ( "yearArrears=@yearArrears," );
            strSql . Append ( "monthReceivable=@monthReceivable," );
            strSql . Append ( "monthNetreceipts=@monthNetreceipts," );
            strSql . Append ( "yearReceivable=@yearReceivable," );
            strSql . Append ( "yearNetreceipts=@yearNetreceipts," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "count=@count," );
            strSql . Append ( "modifyTime=@modifyTime," );
            strSql . Append ( "modifyMan=@modifyMan " );
            strSql . Append ( "where yfId=@yfId" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@province",MySqlDbType.VarChar,45),
                new MySqlParameter("@region",MySqlDbType.VarChar,45),
                new MySqlParameter("@customer",MySqlDbType.VarChar,45),
                new MySqlParameter("@salesman",MySqlDbType.VarChar,45),
                new MySqlParameter("@yearArrears",MySqlDbType.Decimal,45),
                new MySqlParameter("@monthReceivable",MySqlDbType.Decimal,45),
                new MySqlParameter("@monthNetreceipts",MySqlDbType.Decimal,45),
                new MySqlParameter("@yearReceivable",MySqlDbType.Decimal,45),
                new MySqlParameter("@yearNetreceipts",MySqlDbType.Decimal,45),
                new MySqlParameter("@remark",MySqlDbType.VarChar,45),
                new MySqlParameter("@count",MySqlDbType.Int32),
                new MySqlParameter("@modifyTime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = _head . yfId;
            parameter [ 1 ] . Value = _head . province;
            parameter [ 2 ] . Value = _head . region;
            parameter [ 3 ] . Value = _head . customer;
            parameter [ 4 ] . Value = _head . salesman;
            parameter [ 5 ] . Value = _head . yearArrears;
            parameter [ 6 ] . Value = _head . monthReceivable;
            parameter [ 7 ] . Value = _head . monthNetreceipts;
            parameter [ 8 ] . Value = _head . YearReceivable;
            parameter [ 9 ] . Value = _head . yearNetreceipts;
            parameter [ 10 ] . Value = _head . remark;
            parameter [ 11 ] . Value = _head . count;
            parameter [ 12 ] . Value = _head . modifyTime;
            parameter [ 13 ] . Value = _head . modifyMan;

            SQLString . Add ( strSql ,parameter );
        }

        void add ( FishEntity . AccountsReceivableHead _head ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO  t_AccountsReceivableHead (" );
            strSql . Append ( "yfId,province,region,customer,salesman,yearArrears,monthReceivable,monthNetreceipts,yearReceivable,yearNetreceipts,remark,count,createTime,createMan,modifyTime,modifyMan) " );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@yfId,@province,@region,@customer,@salesman,@yearArrears,@monthReceivable,@monthNetreceipts,@yearReceivable,@yearNetreceipts,@remark,@count,@createTime,@createMan,@modifyTime,@modifyMan)" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@province",MySqlDbType.VarChar,45),
                new MySqlParameter("@region",MySqlDbType.VarChar,45),
                new MySqlParameter("@customer",MySqlDbType.VarChar,45),
                new MySqlParameter("@salesman",MySqlDbType.VarChar,45),
                new MySqlParameter("@yearArrears",MySqlDbType.Decimal,45),
                new MySqlParameter("@monthReceivable",MySqlDbType.Decimal,45),
                new MySqlParameter("@monthNetreceipts",MySqlDbType.Decimal,45),
                new MySqlParameter("@yearReceivable",MySqlDbType.Decimal,45),
                new MySqlParameter("@yearNetreceipts",MySqlDbType.Decimal,45),
                new MySqlParameter("@remark",MySqlDbType.VarChar,45),
                new MySqlParameter("@count",MySqlDbType.Int32),
                new MySqlParameter("@createTime",MySqlDbType.Timestamp),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = _head . yfId;
            parameter [ 1 ] . Value = _head . province;
            parameter [ 2 ] . Value = _head . region;
            parameter [ 3 ] . Value = _head . customer;
            parameter [ 4 ] . Value = _head . salesman;
            parameter [ 5 ] . Value = _head . yearArrears;
            parameter [ 6 ] . Value = _head . monthReceivable;
            parameter [ 7 ] . Value = _head . monthNetreceipts;
            parameter [ 8 ] . Value = _head . YearReceivable;
            parameter [ 9 ] . Value = _head . yearNetreceipts;
            parameter [ 10 ] . Value = _head . remark;
            parameter [ 11 ] . Value = _head . count;
            parameter [ 12 ] . Value = _head . createTime;
            parameter [ 13 ] . Value = _head . createMan;
            parameter [ 14 ] . Value = _head . modifyTime;
            parameter [ 15 ] . Value = _head . modifyMan;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑单身记录
        /// </summary>
        /// <param name="yfId"></param>
        /// <param name="yserName"></param>
        /// <returns></returns>
        public bool head_two ( string yfId ,string userName )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            DataTable da = new DataTable ( );
            da = GetDataTableBody ( yfId );
            if ( da != null && da . Rows . Count > 0 )
            {
                FishEntity . AccountsreceivableBody _body = new FishEntity . AccountsreceivableBody ( );
                _body . yfId = yfId;
                _body . createTime = _body . modifyTime = getTime ( );
                _body . createMan = _body . modifyMan = userName;
                DataTable de = GetExists ( yfId );
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    _body . code = da . Rows [ i ] [ "code" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "Signdate" ] . ToString ( ) ) )
                        _body . date = null;
                    else
                        _body . date = Convert . ToDateTime ( da . Rows [ i ] [ "Signdate" ] . ToString ( ) );
                    _body . num = string . IsNullOrEmpty ( da . Rows [ i ] [ "Quantity" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "Quantity" ] . ToString ( ) );
                    _body . price = string . IsNullOrEmpty ( da . Rows [ i ] [ "unitprice" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "unitprice" ] . ToString ( ) );
                    if ( string . IsNullOrEmpty ( da . Rows [ i ] [ "payment" ] . ToString ( ) ) )
                        _body . paymentDate = null;
                    else
                        _body . paymentDate = Convert . ToDateTime ( da . Rows [ i ] [ "payment" ] . ToString ( ) );
                    _body . quality = da . Rows [ i ] [ "Variety" ] . ToString ( );
                    _body . customer = da . Rows [ i ] [ "demand" ] . ToString ( );
                    _body . salesman = da . Rows [ i ] [ "createman" ] . ToString ( );
                    _body . deliveryDay = string . IsNullOrEmpty ( da . Rows [ i ] [ "dayOf" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "dayOf" ] . ToString ( ) );
                    _body . deliveryMonth = string . IsNullOrEmpty ( da . Rows [ i ] [ "monthOf" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "monthOf" ] . ToString ( ) );
                    _body . deliveryNum = string . IsNullOrEmpty ( da . Rows [ i ] [ "Competition" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "Competition" ] . ToString ( ) );
                    _body . receivablesDay = string . IsNullOrEmpty ( da . Rows [ i ] [ "dayOfE" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "dayOfE" ] . ToString ( ) );
                    _body . receivablesMonth = string . IsNullOrEmpty ( da . Rows [ i ] [ "monthOfE" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "monthOfE" ] . ToString ( ) );
                    _body . receivablesAmount = string . IsNullOrEmpty ( da . Rows [ i ] [ "rmbE" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "rmbE" ] . ToString ( ) );
                    _body . receuvablesAcountNum = da . Rows [ i ] [ "fuKuanZhangHao" ] . ToString ( );
                    if ( de . Select ( "code='" + _body . code + "'" ) . Length > 0 )
                        edit ( _body ,SQLString ,strSql );
                    else
                        add ( _body ,SQLString ,strSql );
                }

                DataTable dh = GetExists ( yfId );
                if ( dh != null && dh . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < dh . Rows . Count ; i++ )
                    {
                        _body . code = dh . Rows [ i ] [ "code" ] . ToString ( );
                        if ( da . Select ( "code='" + _body . code + "'" ) . Length < 1 )
                            delete ( yfId ,_body . code ,SQLString ,strSql );
                    }
                }

            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        void edit ( FishEntity . AccountsreceivableBody _body ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_AccountsReceivableBody SET " );
            strSql . Append ( "date=@date," );
            strSql . Append ( "num=@num," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "paymentDate=@paymentDate," );
            strSql . Append ( "quality=@quality," );
            strSql . Append ( "customer=@customer," );
            strSql . Append ( "salesman=@salesman," );
            strSql . Append ( "deliveryDay=@deliveryDay," );
            strSql . Append ( "deliveryMonth=@deliveryMonth," );
            strSql . Append ( "deliveryNum=@deliveryNum," );
            strSql . Append ( "receivablesDay=@receivablesDay," );
            strSql . Append ( "receivablesMonth=@receivablesMonth," );
            strSql . Append ( "receivablesAmount=@receivablesAmount," );
            strSql . Append ( "receuvablesAcountNum=@receuvablesAcountNum," );
            strSql . Append ( "modifyTime=@modifyTime," );
            strSql . Append ( "modifyMan=@modifyMan " );
            strSql . Append ( "WHERE yfId=@yfId AND " );
            strSql . Append ( "code=@code" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.Date),
                new MySqlParameter("@num",MySqlDbType.Decimal,45),
                new MySqlParameter("@price",MySqlDbType.Decimal,45),
                new MySqlParameter("@paymentDate",MySqlDbType.Date),
                new MySqlParameter("@quality",MySqlDbType.VarChar,45),
                new MySqlParameter("@customer",MySqlDbType.VarChar,45),
                new MySqlParameter("@salesman",MySqlDbType.VarChar,45),
                new MySqlParameter("@deliveryDay",MySqlDbType.Int32),
                new MySqlParameter("@deliveryMonth",MySqlDbType.Int32),
                new MySqlParameter("@deliveryNum",MySqlDbType.Decimal,45),
                new MySqlParameter("@receivablesDay",MySqlDbType.Int32),
                new MySqlParameter("@receivablesMonth",MySqlDbType.Int32),
                new MySqlParameter("@receivablesAmount",MySqlDbType.Decimal,45),
                new MySqlParameter("@receuvablesAcountNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = _body . yfId;
            parameter [ 1 ] . Value = _body . code;
            parameter [ 2 ] . Value = _body . date;
            parameter [ 3 ] . Value = _body . num;
            parameter [ 4 ] . Value = _body . price;
            parameter [ 5 ] . Value = _body . paymentDate;
            parameter [ 6 ] . Value = _body . quality;
            parameter [ 7 ] . Value = _body . customer;
            parameter [ 8 ] . Value = _body . salesman;
            parameter [ 9 ] . Value = _body . deliveryDay;
            parameter [ 10 ] . Value = _body . deliveryMonth;
            parameter [ 11 ] . Value = _body . deliveryNum;
            parameter [ 12 ] . Value = _body . receivablesDay;
            parameter [ 13 ] . Value = _body . receivablesMonth;
            parameter [ 14 ] . Value = _body . receivablesAmount;
            parameter [ 15 ] . Value = _body . receuvablesAcountNum;
            parameter [ 16 ] . Value = _body . modifyTime;
            parameter [ 17 ] . Value = _body . modifyMan;

            SQLString . Add ( strSql ,parameter );
        }

        void add ( FishEntity . AccountsreceivableBody _body ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO t_AccountsReceivableBody (" );
            strSql . Append ( "date,num,price,paymentDate,quality,customer,salesman,deliveryDay,deliveryMonth,deliveryNum,receivablesDay,receivablesMonth,receivablesAmount,receuvablesAcountNum,modifyTime,modifyMan,createTime,createMan,yfId,code)" );
            strSql . Append ( "VALUES (" );
            strSql . Append ( "@date,@num,@price,@paymentDate,@quality,@customer,@salesman,@deliveryDay,@deliveryMonth,@deliveryNum,@receivablesDay,@receivablesMonth,@receivablesAmount,@receuvablesAcountNum,@modifyTime,@modifyMan,@createTime,@createMan,@yfId,@code)" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.Date),
                new MySqlParameter("@num",MySqlDbType.Decimal,45),
                new MySqlParameter("@price",MySqlDbType.Decimal,45),
                new MySqlParameter("@paymentDate",MySqlDbType.Date),
                new MySqlParameter("@quality",MySqlDbType.VarChar,45),
                new MySqlParameter("@customer",MySqlDbType.VarChar,45),
                new MySqlParameter("@salesman",MySqlDbType.VarChar,45),
                new MySqlParameter("@deliveryDay",MySqlDbType.Int32),
                new MySqlParameter("@deliveryMonth",MySqlDbType.Int32),
                new MySqlParameter("@deliveryNum",MySqlDbType.Decimal,45),
                new MySqlParameter("@receivablesDay",MySqlDbType.Int32),
                new MySqlParameter("@receivablesMonth",MySqlDbType.Int32),
                new MySqlParameter("@receivablesAmount",MySqlDbType.Decimal,45),
                new MySqlParameter("@receuvablesAcountNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@createTime",MySqlDbType.Timestamp),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = _body . yfId;
            parameter [ 1 ] . Value = _body . code;
            parameter [ 2 ] . Value = _body . date;
            parameter [ 3 ] . Value = _body . num;
            parameter [ 4 ] . Value = _body . price;
            parameter [ 5 ] . Value = _body . paymentDate;
            parameter [ 6 ] . Value = _body . quality;
            parameter [ 7 ] . Value = _body . customer;
            parameter [ 8 ] . Value = _body . salesman;
            parameter [ 9 ] . Value = _body . deliveryDay;
            parameter [ 10 ] . Value = _body . deliveryMonth;
            parameter [ 11 ] . Value = _body . deliveryNum;
            parameter [ 12 ] . Value = _body . receivablesDay;
            parameter [ 13 ] . Value = _body . receivablesMonth;
            parameter [ 14 ] . Value = _body . receivablesAmount;
            parameter [ 15 ] . Value = _body . receuvablesAcountNum;
            parameter [ 16 ] . Value = _body . modifyTime;
            parameter [ 17 ] . Value = _body . modifyMan;
            parameter [ 18 ] . Value = _body . createTime;
            parameter [ 19 ] . Value = _body . createMan;

            SQLString . Add ( strSql ,parameter );
        }

        void delete ( string yfId ,string code ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_AccountsReceivableBody " );
            strSql . Append ( "where yfId=@yfId and code=@code" );
            MySqlParameter [ ] parameter = {
                 new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@code",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = yfId;
            parameter [ 1 ] . Value = code;

            SQLString . Add ( strSql ,parameter );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Add ( List<FishEntity . AccountsreceivableBody> modelList ,string userName )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );

            foreach ( FishEntity . AccountsreceivableBody _body in modelList )
            {
                _body . modifyTime = getTime ( );
                _body . modifyMan = userName;
                adds ( _body ,SQLString ,strSql );
            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        void adds ( FishEntity . AccountsreceivableBody _body ,Hashtable SQLString ,StringBuilder strSql )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_AccountsReceivableBody SET " );
            strSql . Append ( "settlementNum=@settlementNum," );
            strSql . Append ( "modifyTime=@modifyTime," );
            strSql . Append ( "modifyMan=@modifyMan " );
            strSql . Append ( "WHERE yfId=@yfId AND code=@code" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyTime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@settlementNum",MySqlDbType.Decimal,45)
            };
            parameter [ 0 ] . Value = _body . yfId;
            parameter [ 1 ] . Value = _body . code;
            parameter [ 2 ] . Value = _body . modifyTime;
            parameter [ 3 ] . Value = _body . modifyMan;
            parameter [ 4 ] . Value = _body . settlementNum;

            SQLString . Add ( strSql ,parameter );
        }

        DateTime getTime ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT NOW() t" );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            if ( ds . Tables [ 0 ] != null && ds . Tables [ 0 ] . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( ds . Tables [ 0 ] . Rows [ 0 ] [ "t" ] . ToString ( ) ) )
                    return DateTime . Now;
                else
                    return Convert . ToDateTime ( ds . Tables [ 0 ] . Rows [ 0 ] [ "t" ] . ToString ( ) );
            }
            else
                return DateTime . Now;
        }

        /// <summary>
        /// 获取鱼粉ID等信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCode ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select fullname,province,zone,salesman from t_salesorder a left join t_company b on a.demandId=b.code left join t_happening c on a.code=c.code  " );
            strSql . Append ( "where product_id=@product_id" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取年初欠款
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetDataTableAmountOne ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select SUM(b.RMB) rmb from t_salesorder a left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId  left join t_happening c on a.code=c.code " );
            strSql . Append ( "where c.product_id=@product_id and YEAR(b.date)<=YEAR(NOW())" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取本月应收账款
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetDataTableAmountTwo ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select SUM(c.Quantity*unitprice)-SUM(b.RMB) rmb from t_salesorder a LEFT JOIN t_happening c on a.code=c.code left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId " );
            strSql . Append ( "where c.product_id=@product_id and  YEAR(a.Signdate)=YEAR(NOW()) and MONTH(a.Signdate)=YEAR(NOW()) " );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ), parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取本月实收账款
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetDataTableAmountTre ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(RMB) rmb FROM t_salesorder a LEFT JOIN t_happening c on a.code=c.code left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId " );
            strSql . Append ( "where c.product_id=@product_id and YEAR(b.date)=YEAR(NOW()) and MONTH(b.date)=MONTH(NOW()) " );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取本年应收账款
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetDataTableAmountFor ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select SUM(c.Quantity*unitprice)-SUM(b.RMB) rmb from t_salesorder a LEFT JOIN t_happening c on a . code=c.code left join  t_ReceiptRecord b on a . demandId=b.fuKuanDanWeiId " );
            strSql . Append ( "where c.product_id=@product_id and YEAR(a.Signdate)=YEAR(NOW())" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取本年实收账款
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetDataTableAmountFiv ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT SUM(b.RMB) rmb FROM t_salesorder a LEFT JOIN t_happening c on a.code=c.code left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId " );
            strSql . Append ( "where c.product_id=@product_id and YEAR(b.date)=YEAR(NOW())" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 计数
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable count ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select COUNT(1) coun from t_salesorder a left join t_happening b on a.code=b.code " );
            strSql . Append ( "where  b.product_id=@product_id and YEAR(Signdate)<=YEAR(NOW())" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 备注
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable remark ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select remark from t_salesorder a LEFT JOIN t_happening c on a.code=c.code left join  t_ReceiptRecord b on a.demandId=b.fuKuanDanWeiId " );
            strSql . Append ( "where c.product_id=@product_id" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取单身记录
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetDataTableBody ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select a.code,Signdate,b.Quantity,b.unitprice,a.payment,b.Variety,a.demand,a.createman,DAY(c.createtime) dayOf,MONTH(c.createtime) monthOf,Competition,DAY(e.createTime) dayOfE,MONTH(e.createTime) monthOfE,SUM(RMB) rmbE,e.fuKuanZhangHao from t_salesorder a LEFT JOIN t_happening b on a . code=b . code LEFT JOIN t_billoflading c on b.tdh=c.code  LEFT JOIN t_poundsalone d on c.listname=d.code  LEFT JOIN t_ReceiptRecord e on a.code=e.codeOfYu " );
            strSql . Append ( "where b.product_id=@product_id" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取单身数据
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public DataTable GetExists ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_AccountsReceivableBody " );
            strSql . Append ( "WHERE yfId=@yfId" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet RData = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            return RData . Tables [ 0 ];
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public List<FishEntity . AccountsReceivableHead> getList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select yfId,province,region,customer,salesman,yearArrears,monthReceivable,monthNetreceipts,yearReceivable,yearNetreceipts,remark,count from t_accountsreceivablehead " );
            strSql . Append ( "where " + strWhere );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            List<FishEntity . AccountsReceivableHead> modelList = new List<FishEntity . AccountsReceivableHead> ( );
            if ( ds . Tables [ 0 ] != null && ds . Tables [ 0 ] . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < ds . Tables [ 0 ] . Rows . Count ; i++ )
                {
                    modelList . Add ( getModel ( ds . Tables [ 0 ] . Rows [ i ] ) );
                }
            }

            return modelList;
        }

        public FishEntity . AccountsReceivableHead getModel ( DataRow row )
        {
            FishEntity . AccountsReceivableHead _head = new FishEntity . AccountsReceivableHead ( );

            if ( row != null )
            {
                if ( row [ "yfId" ] != null )
                    _head . yfId = row [ "yfId" ] . ToString ( );
                if ( row [ "province" ] != null )
                    _head . province = row [ "province" ] . ToString ( );
                if ( row [ "region" ] != null )
                    _head . region = row [ "region" ] . ToString ( );
                if ( row [ "customer" ] != null )
                    _head . customer = row [ "customer" ] . ToString ( );
                if ( row [ "salesman" ] != null )
                    _head . salesman = row [ "salesman" ] . ToString ( );
                if ( row [ "yearArrears" ] != null && row [ "yearArrears" ] . ToString ( ) != "" )
                    _head . yearArrears = decimal . Parse ( row [ "yearArrears" ] . ToString ( ) );
                if ( row [ "monthReceivable" ] != null && row [ "monthReceivable" ] . ToString ( ) != "" )
                    _head . monthReceivable = decimal . Parse ( row [ "monthReceivable" ] . ToString ( ) );
                if ( row [ "monthNetreceipts" ] != null && row [ "monthNetreceipts" ] . ToString ( ) != "" )
                    _head . monthNetreceipts = decimal . Parse ( row [ "monthNetreceipts" ] . ToString ( ) );
                if ( row [ "yearReceivable" ] != null && row [ "yearReceivable" ] . ToString ( ) != "" )
                    _head . YearReceivable = decimal . Parse ( row [ "yearReceivable" ] . ToString ( ) );
                if ( row [ "yearNetreceipts" ] != null && row [ "yearNetreceipts" ] . ToString ( ) != "" )
                    _head . yearNetreceipts = decimal . Parse ( row [ "yearNetreceipts" ] . ToString ( ) );
                if ( row [ "remark" ] != null )
                    _head . remark = row [ "remark" ] . ToString ( );
                if ( row [ "count" ] != null && row [ "count" ] . ToString ( ) != "" )
                    _head . count = int . Parse ( row [ "count" ] . ToString ( ) );
            }

            return _head;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public List<FishEntity . AccountsreceivableBody> getLists ( string yfId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT yfId,code,date,num,price,paymentDate,quality,customer,salesman,deliveryDay,deliveryMonth,deliveryNum,settlementNum,receivablesDay,receivablesMonth,receivablesAmount,receuvablesAcountNum,remark FROM t_accountsreceivablebody " );
            strSql . Append ( "where yfId=@yfId" );

            MySqlParameter [ ] parameter = {
                new MySqlParameter("@yfId",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = yfId;

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) ,parameter );
            List<FishEntity . AccountsreceivableBody> modelList = new List<FishEntity . AccountsreceivableBody> ( );
            if ( ds . Tables [ 0 ] != null && ds . Tables [ 0 ] . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < ds . Tables [ 0 ] . Rows . Count ; i++ )
                {
                    modelList . Add ( getM ( ds . Tables [ 0 ] . Rows [ i ] ) );
                }
            }

            return modelList;
        }

        public FishEntity . AccountsreceivableBody getM ( DataRow row )
        {
            FishEntity . AccountsreceivableBody _body = new FishEntity . AccountsreceivableBody ( );

            if ( row != null )
            {
                if ( row [ "yfId" ] != null )
                    _body . yfId = row [ "yfId" ] . ToString ( );
                if ( row [ "code" ] != null )
                    _body . code = row [ "code" ] . ToString ( );
                if ( row [ "date" ] != null && row [ "date" ] . ToString ( ) != "" )
                    _body . date = DateTime . Parse ( row [ "date" ] . ToString ( ) );
                if ( row [ "num" ] != null && row [ "num" ] . ToString ( ) != "" )
                    _body . num = decimal . Parse ( row [ "num" ] . ToString ( ) );
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                    _body . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                if ( row [ "paymentDate" ] != null && row [ "paymentDate" ] . ToString ( ) != "" )
                    _body . paymentDate = DateTime . Parse ( row [ "paymentDate" ] . ToString ( ) );
                if ( row [ "quality" ] != null )
                    _body . quality = row [ "quality" ] . ToString ( );
                if ( row [ "customer" ] != null )
                    _body . customer = row [ "customer" ] . ToString ( );
                if ( row [ "salesman" ] != null )
                    _body . salesman = row [ "salesman" ] . ToString ( );
                if ( row [ "deliveryDay" ] != null && row [ "deliveryDay" ] . ToString ( ) != "" )
                    _body . deliveryDay = int . Parse ( row [ "deliveryDay" ] . ToString ( ) );
                if ( row [ "deliveryMonth" ] != null && row [ "deliveryMonth" ] . ToString ( ) != "" )
                    _body . deliveryMonth = int . Parse ( row [ "deliveryMonth" ] . ToString ( ) );
                if ( row [ "deliveryNum" ] != null && row [ "deliveryNum" ] . ToString ( ) != "" )
                    _body . deliveryNum = decimal . Parse ( row [ "deliveryNum" ] . ToString ( ) );
                if ( row [ "settlementNum" ] != null && row [ "settlementNum" ] . ToString ( ) != "" )
                    _body . settlementNum = decimal . Parse ( row [ "settlementNum" ] . ToString ( ) );
                if ( row [ "receivablesDay" ] != null && row [ "receivablesDay" ] . ToString ( ) != "" )
                    _body . receivablesDay = int . Parse ( row [ "receivablesDay" ] . ToString ( ) );
                if ( row [ "receivablesMonth" ] != null && row [ "receivablesMonth" ] . ToString ( ) != "" )
                    _body . receivablesMonth = int . Parse ( row [ "receivablesMonth" ] . ToString ( ) );
                if ( row [ "receivablesAmount" ] != null && row [ "receivablesAmount" ] . ToString ( ) != "" )
                    _body . receivablesAmount = decimal . Parse ( row [ "receivablesAmount" ] . ToString ( ) );
                if ( row [ "receuvablesAcountNum" ] != null )
                    _body . receuvablesAcountNum = row [ "receuvablesAcountNum" ] . ToString ( );
                if ( row [ "remark" ] != null )
                    _body . remark = row [ "remark" ] . ToString ( );
            }

            return _body;
        }



    }
}
