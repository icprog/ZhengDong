using System;
using System . Collections . Generic;
using System . Data . SqlClient;
using System . Text;
using MySql . Data . MySqlClient;
using System . Data;

namespace FishBll . Dao
{
    public class ReceiptRecordDao
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . ReceiptRecordEntity getList ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("select Numbering,code,departNum,departName,date,codeOfYu,codePrice,codeYunFei,codeHuiKou,fuKuanDanWeiId,fuKuanDanWei,DemaUndnit,DemaUndnitId,DemandSideContact,DemandSideContactId,fuKuanZhangHao,weight,price,RMB,fuKuanType,fuKuanMethod,fuKuanOther ,invoiceType ,fuKuandate ,remark ,createTime ,createMan ,modeifyTime ,modeifyMan,codeContract,FishMealId from t_receiptrecord ");
            strSql . Append ( "where 1=1 " + strWhere );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            if ( ds . Tables [ 0 ] != null && ds . Tables [ 0 ] . Rows . Count > 0 )
            {
                return GetDataRow ( ds . Tables [ 0 ] . Rows [ 0 ] );
            }
            else
                return null;
        }
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from t_receiptrecord ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        public FishEntity.SalesRequisitionEntity getFKSQD(string getname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select b.Product_id,a.code,a.Numbering,a.demand,a.demandId,a.DemandContact,a.DemandContactId,a.supplier,a.supplierId,a.accountnumber,a.Freight,a.rebate,b.unitprice from t_salesorder a inner join t_happening b on a.Numbering=b.NumberingOne ");
            strSql.Append("where a.Numbering= '" + getname + "'");
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
                if (row["demand"]!=null)
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["demandId"]!=null)
                {
                    model.demandId = row["demandId"].ToString();
                }
                if (row["DemandContact"]!=null)
                {
                    model.DemandContact = row["DemandContact"].ToString();
                }
                if (row["DemandContactId"]!=null)
                {
                    model.DemandContactId = row["DemandContactId"].ToString();
                }
                if (row["supplier"] !=null)
                {
                    model.supplier = row["supplier"].ToString();
                }
                if (row["supplierId"] != null)
                {
                    model.supplierId = row["supplierId"].ToString();
                }
                if (row["accountnumber"]!=null)
                {
                    model.accountnumber = row["accountnumber"].ToString();
                }
                if (row["Freight"]!=null&&row["Freight"].ToString()!="")
                {
                    model.Freight =decimal.Parse(row["Freight"].ToString());
                }
                if (row["rebate"]!=null&&row["rebate"].ToString()!="")
                {
                    model.rebate =decimal.Parse(row["rebate"].ToString());
                }
                if (row["unitprice"]!=null&&row["unitprice"].ToString()!="")
                {
                    model.Portprice =decimal.Parse(row["unitprice"].ToString());
                }
                if (row["Product_id"] !=null)
                {
                    model.Product_id = row["Product_id"].ToString();
                }
                return model;
            }
            else {
                return null;
            }
        }
        public FishEntity . ReceiptRecordEntity GetDataRow ( DataRow row )
        {
            FishEntity . ReceiptRecordEntity _model = new FishEntity . ReceiptRecordEntity ( );

            if ( row != null )
            {
                if (row["Numbering"]!=null)
                {
                    _model.Numbering = row["Numbering"].ToString();
                }
                if ( row [ "code" ] != null && row [ "code" ] . ToString ( ) != "" )
                    _model . code = row [ "code" ] . ToString ( );
                if ( row [ "departNum" ] != null && row [ "departNum" ] . ToString ( ) != "" )
                    _model . departNum = row [ "departNum" ] . ToString ( );
                if ( row [ "departName" ] != null && row [ "departName" ] . ToString ( ) != "" )
                    _model . departName = row [ "departName" ] . ToString ( );
                if ( row [ "date" ] != null && row [ "date" ] . ToString ( ) != "" )
                    _model . date = DateTime . Parse ( row [ "date" ] . ToString ( ) );
                if ( row [ "codeOfYu" ] != null && row [ "codeOfYu" ] . ToString ( ) != "" )
                    _model . codeOfYu = row [ "codeOfYu" ] . ToString ( );
                if ( row [ "codePrice" ] != null && row [ "codePrice" ] . ToString ( ) != "" )
                    _model . codePrice = decimal . Parse ( row [ "codePrice" ] . ToString ( ) );
                if ( row [ "codeYunFei" ] != null && row [ "codeYunFei" ] . ToString ( ) != "" )
                    _model . codeYunFei = decimal . Parse ( row [ "codeYunFei" ] . ToString ( ) );
                if ( row [ "codeHuiKou" ] != null && row [ "codeHuiKou" ] . ToString ( ) != "" )
                    _model . codeHuiKou = decimal . Parse ( row [ "codeHuiKou" ] . ToString ( ) );
                if ( row [ "fuKuanDanWeiId" ] != null )
                    _model . fuKuanDanWeiId = row [ "fuKuanDanWeiId" ] . ToString ( );
                if ( row [ "fuKuanDanWei" ] != null && row [ "fuKuanDanWei" ] . ToString ( ) != "" )
                    _model . fuKuanDanWei = row [ "fuKuanDanWei" ] . ToString ( );
                if (row["DemaUndnit"]!=null&&row["DemaUndnit"].ToString()!="")
                {
                    _model.DemaUndnit = row["DemaUndnit"].ToString();
                }
                if (row["DemaUndnitId"] != null)
                {
                    _model.DemaUndnitId = row["DemaUndnitId"].ToString();
                }
                if (row["DemandSideContact"] != null && row["DemandSideContact"].ToString() != "")
                {
                    _model.DemandSideContact = row["DemandSideContact"].ToString();
                }
                if (row["DemandSideContactId"] != null)
                {
                    _model.DemandSideContactId = row["DemandSideContactId"].ToString();
                }
                if ( row [ "fuKuanZhangHao" ] != null && row [ "fuKuanZhangHao" ] . ToString ( ) != "" )
                    _model . fuKuanZhangHao = row [ "fuKuanZhangHao" ] . ToString ( );
                if ( row [ "weight" ] != null && row [ "weight" ] . ToString ( ) != "" )
                    _model . weight = decimal . Parse ( row [ "weight" ] . ToString ( ) );
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                    _model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                if ( row [ "RMB" ] != null && row [ "RMB" ] . ToString ( ) != "" )
                    _model . RMB = decimal . Parse ( row [ "RMB" ] . ToString ( ) );
                if ( row [ "fuKuanType" ] != null && row [ "fuKuanType" ] . ToString ( ) != "" )
                    _model . fuKuanType = row [ "fuKuanType" ] . ToString ( );
                if ( row [ "fuKuanMethod" ] != null && row [ "fuKuanMethod" ] . ToString ( ) != "" )
                    _model . fuKuanMethod = row [ "fuKuanMethod" ] . ToString ( );
                if ( row [ "fuKuanOther" ] != null && row [ "fuKuanOther" ] . ToString ( ) != "" )
                    _model . fuKuanOther = row [ "fuKuanOther" ] . ToString ( );
                if ( row [ "invoiceType" ] != null && row [ "invoiceType" ] . ToString ( ) != "" )
                    _model . invoiceType = row [ "invoiceType" ] . ToString ( );
                if ( row [ "fuKuandate" ] != null && row [ "fuKuandate" ] . ToString ( ) != "" )
                    _model . fuKuandate = DateTime . Parse ( row [ "fuKuandate" ] . ToString ( ) );
                if ( row [ "remark" ] != null && row [ "remark" ] . ToString ( ) != "" )
                    _model . remark = row [ "remark" ] . ToString ( );
                if ( row [ "codeContract" ] != null && row [ "codeContract" ] . ToString ( ) != "" )
                    _model . codeContract = row [ "codeContract" ] . ToString ( );
                if (row["modeifyMan"] !=null)
                {
                    _model.modeifyMan = row["modeifyMan"].ToString();
                }
                if (row["createMan"] != null)
                {
                    _model.createMan = row["createMan"].ToString();
                }
                if (row["FishMealId"]!=null)
                {
                    _model.FishMealId = row["FishMealId"].ToString();
                }
            }

            return _model;
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getDate ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT now() t" );

            DataSet da = MySqlHelper . Query ( strSql . ToString ( ) );

            return Convert . ToDateTime ( da . Tables [ 0 ] . Rows [ 0 ] [ "t" ] . ToString ( ) );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string GetCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(code) code FROM t_receiptrecord" );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            DataTable dt = ds . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "code" ] . ToString ( ) ) )
                    return getDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                else
                {
                    if ( dt . Rows [ 0 ] [ "code" ] . ToString ( ) . Substring ( 0 ,8 ) == getDate ( ) . ToString ( "yyyyMMdd" ) )
                        return ( Convert . ToInt64 ( dt . Rows [ 0 ] [ "code" ] . ToString ( ) ) + 1 ) . ToString ( );
                    else
                        return getDate ( ) . ToString ( "yyyyMMdd" ) + "001";
                }
            }
            else
                return getDate ( ) . ToString ( "yyyyMMdd" ) + "001";
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . ReceiptRecordEntity _list)
        {
            _list . createTime = _list . modeifyTime = getDate ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "INSERT INTO t_ReceiptRecord (" );
            strSql. Append ("Numbering,code,departNum,departName,date,codeOfYu,codePrice,codeYunFei,codeHuiKou,fuKuanDanWeiId,fuKuanDanWei,DemaUndnit,DemaUndnitId,DemandSideContact,DemandSideContactId,fuKuanZhangHao,weight,price,RMB,fuKuanType,fuKuanMethod,fuKuanOther ,invoiceType ,fuKuandate ,remark ,createTime ,createMan ,modeifyTime ,modeifyMan,codeContract,FishMealId) ");
            strSql . Append ( "VALUES (" );
            strSql . Append ("@Numbering,@code,@departNum,@departName,@date,@codeOfYu,@codePrice,@codeYunFei,@codeHuiKou,@fuKuanDanWeiId,@fuKuanDanWei,@DemaUndnit,@DemaUndnitId,@DemandSideContact,@DemandSideContactId,@fuKuanZhangHao,@weight,@price,@RMB,@fuKuanType,@fuKuanMethod,@fuKuanOther ,@invoiceType ,@fuKuandate ,@remark ,@createTime ,@createMan ,@modeifyTime ,@modeifyMan,@codeContract,@FishMealId)");
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@departNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@departName",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.DateTime),
                new MySqlParameter("@codeOfYu",MySqlDbType.VarChar,45),
                new MySqlParameter("@codePrice",MySqlDbType.Decimal,45),
                new MySqlParameter("@codeYunFei",MySqlDbType.Decimal,45),
                new MySqlParameter("@codeHuiKou",MySqlDbType.Decimal,45),
                new MySqlParameter("@fuKuanDanWeiId",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanDanWei",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanZhangHao",MySqlDbType.VarChar,45),
                new MySqlParameter("@weight",MySqlDbType.Decimal,45),
                new MySqlParameter("@price",MySqlDbType.Decimal,45),
                new MySqlParameter("@RMB",MySqlDbType.Decimal,45),
                new MySqlParameter("@fuKuanType",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanMethod",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanOther",MySqlDbType.VarChar,45),
                new MySqlParameter("@invoiceType",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuandate",MySqlDbType.Date),
                new MySqlParameter("@remark",MySqlDbType.VarChar,500),
                new MySqlParameter("@createTime",MySqlDbType.DateTime),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modeifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modeifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@DemaUndnit",MySqlDbType.VarChar,100),
                new MySqlParameter("@DemaUndnitId",MySqlDbType.VarChar,100),
                new MySqlParameter("@DemandSideContact",MySqlDbType.VarChar,100),
                new MySqlParameter("@DemandSideContactId",MySqlDbType.VarChar,100),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50)
            };
            parameter [ 0 ] . Value = _list . code;
            parameter [ 1 ] . Value = _list . departNum;
            parameter [ 2 ] . Value = _list . departName;
            parameter [ 3 ] . Value = _list . date;
            parameter [ 4 ] . Value = _list . codeOfYu;
            parameter [ 5 ] . Value = _list . codePrice;
            parameter [ 6 ] . Value = _list . codeYunFei;
            parameter [ 7 ] . Value = _list . codeHuiKou;
            parameter [ 8 ] . Value = _list . fuKuanDanWeiId;
            parameter [ 9 ] . Value = _list . fuKuanDanWei;
            parameter [ 10 ] . Value = _list . fuKuanZhangHao;
            parameter [ 11 ] . Value = _list . weight;
            parameter [ 12 ] . Value = _list . price;
            parameter [ 13 ] . Value = _list . RMB;
            parameter [ 14 ] . Value = _list . fuKuanType;
            parameter [ 15 ] . Value = _list . fuKuanMethod;
            parameter [ 16 ] . Value = _list . fuKuanOther;
            parameter [ 17 ] . Value = _list . invoiceType;
            parameter [ 18 ] . Value = _list . fuKuandate;
            parameter [ 19 ] . Value = _list . remark;
            parameter [ 20 ] . Value = _list . createTime;
            parameter [ 21 ] . Value = _list . createMan;
            parameter [ 22 ] . Value = _list . modeifyTime;
            parameter [ 23 ] . Value = _list . modeifyMan;
            parameter [ 24 ] . Value = _list . codeContract;
            parameter[25].Value = _list.DemaUndnit;
            parameter[26].Value = _list.DemaUndnitId;
            parameter[27].Value = _list.DemandSideContact;
            parameter[28].Value = _list.DemandSideContactId;
            parameter[29].Value = _list.Numbering;
            parameter[30].Value = _list.FishMealId;
            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 是否存在合同
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_ReceiptRecord " );
            strSql . Append ( "WHERE code=@code" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45)
            };
            parameter [ 0 ] . Value = code;

            return MySqlHelper . Exists ( strSql . ToString ( ) ,parameter );
        }
        /// <summary>
        /// 是否所属
        /// </summary>
        /// <param name="code"></param>
        /// <param name="createman"></param>
        /// <returns></returns>
        public bool ExistsUpdateOrDelete(string code,string createman)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(*) FROM t_ReceiptRecord ");
            strSql.Append("WHERE code=@code and createman=@createman ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = code;
            parameter[1].Value = createman;
            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . ReceiptRecordEntity _list )
        {
            _list . modeifyTime = getDate ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_ReceiptRecord SET " );         
            strSql . Append ( "departNum=@departNum," );
            strSql . Append ( "departName=@departName," );
            strSql . Append ( "date=@date," );
            strSql . Append ( "codeOfYu=@codeOfYu," );
            strSql . Append ( "codePrice=@codePrice," );
            strSql . Append ( "codeYunFei=@codeYunFei," );
            strSql . Append ( "codeHuiKou=@codeHuiKou," );
            strSql . Append ( "fuKuanDanWeiId=@fuKuanDanWeiId," );
            strSql. Append ( "fuKuanDanWei=@fuKuanDanWei," );
            strSql.Append("DemaUndnit=@DemaUndnit,");
            strSql.Append("DemaUndnitId=@DemaUndnitId,");
            strSql.Append("DemandSideContact=@DemandSideContact,");
            strSql.Append("DemandSideContactId=@DemandSideContactId,");
            strSql . Append ( "fuKuanZhangHao=@fuKuanZhangHao," );
            strSql . Append ( "weight=@weight," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "RMB=@RMB," );
            strSql . Append ( "fuKuanType=@fuKuanType," );
            strSql . Append ( "fuKuanMethod=@fuKuanMethod," );
            strSql . Append ( "fuKuanOther=@fuKuanOther," );
            strSql . Append ( "invoiceType=@invoiceType," );
            strSql . Append ( "fuKuandate=@fuKuandate," );
            strSql . Append ( "remark=@remark," );
            strSql.Append("FishMealId=@FishMealId,");
            strSql . Append ( "modeifyTime=@modeifyTime," );
            strSql . Append ( "modeifyMan=@modeifyMan," );
            strSql . Append ( "codeContract=@codeContract " );
            strSql . Append ( "WHERE code=@code" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@departNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@departName",MySqlDbType.VarChar,45),
                new MySqlParameter("@date",MySqlDbType.DateTime),
                new MySqlParameter("@codeOfYu",MySqlDbType.VarChar,45),
                new MySqlParameter("@codePrice",MySqlDbType.Decimal,45),
                new MySqlParameter("@codeYunFei",MySqlDbType.Decimal,45),
                new MySqlParameter("@codeHuiKou",MySqlDbType.Decimal,45),
                new MySqlParameter("@fuKuanDanWeiId",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanDanWei",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanZhangHao",MySqlDbType.VarChar,45),
                new MySqlParameter("@weight",MySqlDbType.Decimal,45),
                new MySqlParameter("@price",MySqlDbType.Decimal,45),
                new MySqlParameter("@RMB",MySqlDbType.Decimal,45),
                new MySqlParameter("@fuKuanType",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanMethod",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuanOther",MySqlDbType.VarChar,45),
                new MySqlParameter("@invoiceType",MySqlDbType.VarChar,45),
                new MySqlParameter("@fuKuandate",MySqlDbType.Date),
                new MySqlParameter("@remark",MySqlDbType.VarChar,500),
                new MySqlParameter("@createTime",MySqlDbType.DateTime),
                new MySqlParameter("@createMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@modeifyTime",MySqlDbType.DateTime),
                new MySqlParameter("@modeifyMan",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeContract",MySqlDbType.VarChar,200),
                new MySqlParameter("@DemaUndnit",MySqlDbType.VarChar,100),
                new MySqlParameter("@DemaUndnitId",MySqlDbType.VarChar,100),
                new MySqlParameter("@DemandSideContact",MySqlDbType.VarChar,100),
                new MySqlParameter("@DemandSideContactId",MySqlDbType.VarChar,100),
                new MySqlParameter("@FishMealId",MySqlDbType.VarChar,50)
            };
            parameter [ 0 ] . Value = _list . code;
            parameter [ 1 ] . Value = _list . departNum;
            parameter [ 2 ] . Value = _list . departName;
            parameter [ 3 ] . Value = _list . date;
            parameter [ 4 ] . Value = _list . codeOfYu;
            parameter [ 5 ] . Value = _list . codePrice;
            parameter [ 6 ] . Value = _list . codeYunFei;
            parameter [ 7 ] . Value = _list . codeHuiKou;
            parameter [ 8 ] . Value = _list . fuKuanDanWeiId;
            parameter [ 9 ] . Value = _list . fuKuanDanWei;
            parameter [ 10 ] . Value = _list . fuKuanZhangHao;
            parameter [ 11 ] . Value = _list . weight;
            parameter [ 12 ] . Value = _list . price;
            parameter [ 13 ] . Value = _list . RMB;
            parameter [ 14 ] . Value = _list . fuKuanType;
            parameter [ 15 ] . Value = _list . fuKuanMethod;
            parameter [ 16 ] . Value = _list . fuKuanOther;
            parameter [ 17 ] . Value = _list . invoiceType;
            parameter [ 18 ] . Value = _list . fuKuandate;
            parameter [ 19 ] . Value = _list . remark;
            parameter [ 20 ] . Value = _list . createTime;
            parameter [ 21 ] . Value = _list . createMan;
            parameter [ 22 ] . Value = _list . modeifyTime;
            parameter [ 23 ] . Value = _list . modeifyMan;
            parameter [ 24 ] . Value = _list . codeContract;
            parameter[25].Value = _list.DemaUndnit;
            parameter[26].Value = _list.DemaUndnitId;
            parameter[27].Value = _list.DemandSideContact;
            parameter[28].Value = _list.DemandSideContactId;
            parameter[29].Value = _list.FishMealId;
            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="codeOddNum"></param>
        /// <returns></returns>
        public bool Delete ( string codeOddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "DELETE FROM t_ReceiptRecord " );
            strSql . Append ( "WHERE code=@code" );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,20)
            };
            parameter [ 0 ] . Value = codeOddNum;

            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameter );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 获取申请部门
        /// </summary>
        /// <returns></returns>
        public DataTable getDepart ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select roleid,rolename from t_role" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

    }
}
