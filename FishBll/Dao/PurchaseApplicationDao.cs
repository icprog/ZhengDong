using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class PurchaseApplicationDao
    {
        /// <summary>
        /// 得到申请单编号
        /// </summary>
        /// <returns></returns>
        public string getCodeNum ( )
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT max(substring_index(codeNum,'C',-1))as codeNum FROM t_purchaseApplication where substring_index(codeNum,'C',1)=DATE_FORMAT(NOW(),'%Y')");

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

            //StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT MAX(codeNum) codeNum FROM t_purchaseApplication" );

            //DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            //DataTable dt = ds . Tables [ 0 ];
            //if ( dt != null && dt . Rows . Count > 0 )
            //{
            //    string codeNum = dt . Rows [ 0 ] [ "codeNum" ] . ToString ( );
            //    if ( string . IsNullOrEmpty ( codeNum ) )
            //        return System . DateTime . Now . Year + "C0001001";
            //    else
            //    {
            //        if ( codeNum . Substring ( 0 ,4 ) . Equals ( DateTime . Now . Year . ToString ( ) ) )
            //        {
            //            if ( Convert . ToInt32 ( codeNum . Substring ( 10 ,1 ) ) == 0 )
            //                return codeNum . Substring ( 0 ,8 ) + ( Convert . ToInt32 ( codeNum . Substring ( 8 ,4 ) ) + 1000 );
            //            else
            //                return codeNum . Substring ( 0 ,8 ) + ( Convert . ToInt32 ( codeNum . Substring ( 8 ,4 ) ) + 100 );
            //        }
            //        else
            //            return System . DateTime . Now . Year + "C0001001";
            //    }
            //}
            //else
            //    return System . DateTime . Now . Year + "C0001001";
        }

        /// <summary>
        /// 是否被引用
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsCodeNumContract ( int idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT codeNumContract FROM t_purchaseapplication WHERE id={0} " ,idx );
            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            DataTable dt = ds . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "codeNumContract" ] . ToString ( ) ) == true ? false : true;
            else
                return false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string code)
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_purchaseapplication " );
            strSql . Append ( " where id=@id" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters [ 0 ] . Value = idx;
            SQLString . Add ( strSql ,parameters );
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_purchasefishinfo " );
            strSql . AppendFormat ( " where code='{0}'" ,code );
            SQLString . Add ( strSql ,null );
            strSql = new StringBuilder ( );
            strSql . Append ( "delete from t_purchaseotherinfo " );
            strSql . AppendFormat ( " where code='{0}'" ,code );
            SQLString . Add ( strSql ,null );

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM t_purchaseapplication WHERE codeNum='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsFishId(string FishId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM t_purchaseapplication WHERE fishId='{0}'", FishId);

            return MySqlHelper.Exists(strSql.ToString());
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( FishEntity . PurchaseApplicationEntity model )
        {
            //
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_purchaseapplication(" );
            strSql . Append ("codeNum,codeNumContract,supplier,supplierAbb,supplierUser,buyer,buyerAbb,buyerUser,purchase,purchaseAbb,purchaseUser,danjia,weight,fishId,rebate,brands,country,proName,bondPro,varieties,signDate,signAdd,amountOfMoney,priceMY,remark,createUser,createDate,modifyUser,modifyDate,Process,choise,EexchangeRate,Money,Dollarjine,account,Bank)");
            strSql . Append ( " values (" );
            strSql . Append ("@codeNum,@codeNumContract,@supplier,@supplierAbb,@supplierUser,@buyer,@buyerAbb,@buyerUser,@purchase,@purchaseAbb,@purchaseUser,@danjia,@weight,@fishId,@rebate,@brands,@country,@proName,@bondPro,@varieties,@signDate,@signAdd,@amountOfMoney,@priceMY,@remark,@createUser,@createDate,@modifyUser,@modifyDate,@Process,@choise,@EexchangeRate,@Money,@Dollarjine,@account,@Bank);select last_insert_id();");
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,30),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,30),
                    new MySqlParameter("@supplier", MySqlDbType.VarChar,50),
                    new MySqlParameter("@supplierAbb", MySqlDbType.VarChar,50),
                    new MySqlParameter("@supplierUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyer", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyerAbb", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyerUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@purchase", MySqlDbType.VarChar,45),
                    new MySqlParameter("@purchaseAbb", MySqlDbType.VarChar,45),
                    new MySqlParameter("@purchaseUser", MySqlDbType.VarChar,45),
                    new MySqlParameter("@danjia", MySqlDbType.Decimal,18),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,18),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@rebate", MySqlDbType.Decimal,18),
                    new MySqlParameter("@brands", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@bondPro", MySqlDbType.Decimal,18),
                    new MySqlParameter("@varieties", MySqlDbType.VarChar,50),
                    new MySqlParameter("@signDate", MySqlDbType.DateTime),
                    new MySqlParameter("@signAdd", MySqlDbType.VarChar,100),
                    new MySqlParameter("@amountOfMoney", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,18),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@createUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@createDate", MySqlDbType.DateTime),
                    new MySqlParameter("@modifyUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@modifyDate", MySqlDbType.DateTime),
                    new MySqlParameter("@Process",MySqlDbType.VarChar,45),
                    new MySqlParameter("@choise",MySqlDbType.VarChar,45),
                    new MySqlParameter("@EexchangeRate",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Money",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Dollarjine",MySqlDbType.VarChar,45),
                    new MySqlParameter("@account",MySqlDbType.VarChar,200),
                    new MySqlParameter("@Bank",MySqlDbType.VarChar,200)
            };
            parameters [ 0 ] . Value = model . codeNum;
            parameters [ 1 ] . Value = model . codeNumContract;
            parameters [ 2 ] . Value = model . supplier;
            parameters [ 3 ] . Value = model . supplierAbb;
            parameters [ 4 ] . Value = model . supplierUser;
            parameters [ 5 ] . Value = model . buyer;
            parameters [ 6 ] . Value = model . buyerAbb;
            parameters [ 7 ] . Value = model . buyerUser;
            parameters [ 8 ] . Value = model . purchase;
            parameters [ 9 ] . Value = model . purchaseAbb;
            parameters [ 10 ] . Value = model . purchaseUser;
            parameters [ 11 ] . Value = model . danjia;
            parameters [ 12 ] . Value = model . Weight;
            parameters [ 13 ] . Value = model . FishId;
            parameters [ 14 ] . Value = model . rebate;
            parameters [ 15 ] . Value = model . brands;
            parameters [ 16 ] . Value = model . conutry;
            parameters [ 17 ] . Value = model . proName;
            parameters [ 18 ] . Value = model . bondPro;
            parameters [ 19 ] . Value = model . varieties;
            parameters [ 20 ] . Value = model . signDate;
            parameters [ 21 ] . Value = model . signAdd;
            parameters [ 22 ] . Value = model . AmountOfMoney;
            parameters [ 23 ] . Value = model . priceMY;
            parameters [ 24 ] . Value = model . remark;
            parameters [ 25 ] . Value = model . createUser;
            parameters [ 26 ] . Value = model . createDate;
            parameters [ 27 ] . Value = model . modifyUser;
            parameters [ 28 ] . Value = model . modifyDate;
            parameters[29].Value=model.Process;
            parameters[30].Value = model.choise;
            parameters[31].Value = model.EexchangeRate;
            parameters[32].Value = model.Money;
            parameters[33].Value = model.Dollarjine;

            parameters[34].Value = model.account;
            parameters[35].Value = model.Bank;
            return MySqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameters );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit ( FishEntity . PurchaseApplicationEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_purchaseapplication set " );
            strSql . Append ( "codeNum=@codeNum," );
            strSql . Append ( "codeNumContract=@codeNumContract," );
            strSql . Append ( "supplier=@supplier," );
            strSql . Append ( "supplierAbb=@supplierAbb," );
            strSql . Append ( "supplierUser=@supplierUser," );
            strSql . Append ( "buyer=@buyer," );
            strSql . Append ( "buyerAbb=@buyerAbb," );
            strSql . Append ( "buyerUser=@buyerUser," );
            strSql . Append ( "purchase=@purchase," );
            strSql . Append ( "purchaseAbb=@purchaseAbb," );
            strSql . Append ( "purchaseUser=@purchaseUser," );
            strSql . Append ( "danjia=@danjia," );
            strSql . Append ( "weight=@weight," );
            strSql . Append ( "fishId=@fishId," );
            strSql . Append ( "rebate=@rebate," );
            strSql . Append ( "brands=@brands," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "proName=@proName," );
            strSql . Append ( "bondPro=@bondPro," );
            strSql.Append("choise=@choise,");
            strSql . Append ( "varieties=@varieties," );
            strSql . Append ( "signDate=@signDate," );
            strSql . Append ( "signAdd=@signAdd," );
            strSql . Append ( "amountOfMoney=@amountOfMoney," );
            strSql . Append ( "priceMY=@priceMY," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "modifyUser=@modifyUser," );
            strSql.Append("process=@process,");
            strSql.Append("Money=@Money,");
            strSql.Append("Dollarjine=@Dollarjine,");
            strSql.Append("EexchangeRate=@EexchangeRate,");
            strSql.Append("account=@account,");
            strSql.Append("Bank=@Bank,");
            strSql . Append ( "modifyDate=@modifyDate" );
            strSql . Append ( " where id=@id" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,30),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,30),
                    new MySqlParameter("@supplier", MySqlDbType.VarChar,50),
                    new MySqlParameter("@supplierAbb", MySqlDbType.VarChar,50),
                    new MySqlParameter("@supplierUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyer", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyerAbb", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyerUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@purchase", MySqlDbType.VarChar,45),
                    new MySqlParameter("@purchaseAbb", MySqlDbType.VarChar,45),
                    new MySqlParameter("@purchaseUser", MySqlDbType.VarChar,45),
                    new MySqlParameter("@danjia", MySqlDbType.Decimal,18),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,18),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@rebate", MySqlDbType.Decimal,18),
                    new MySqlParameter("@brands", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@bondPro", MySqlDbType.Decimal,18),
                    new MySqlParameter("@varieties", MySqlDbType.VarChar,50),
                    new MySqlParameter("@signDate", MySqlDbType.DateTime),
                    new MySqlParameter("@signAdd", MySqlDbType.VarChar,100),
                    new MySqlParameter("@amountOfMoney", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,18),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@modifyUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@modifyDate", MySqlDbType.DateTime),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@process",MySqlDbType.VarChar,45),
                    new MySqlParameter("@choise",MySqlDbType.VarChar,45),
                    new MySqlParameter("@EexchangeRate",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Money",MySqlDbType.VarChar,45),
                    new MySqlParameter("@Dollarjine",MySqlDbType.VarChar,45),
                    new MySqlParameter("@account",MySqlDbType.VarChar,200),
                    new MySqlParameter("@Bank",MySqlDbType.VarChar,200)
            };
            parameters [ 0 ] . Value = model . codeNum;
            parameters [ 1 ] . Value = model . codeNumContract;
            parameters [ 2 ] . Value = model . supplier;
            parameters [ 3 ] . Value = model . supplierAbb;
            parameters [ 4 ] . Value = model . supplierUser;
            parameters [ 5 ] . Value = model . buyer;
            parameters [ 6 ] . Value = model . buyerAbb;
            parameters [ 7 ] . Value = model . buyerUser;
            parameters [ 8 ] . Value = model . purchase;
            parameters [ 9 ] . Value = model . purchaseAbb;
            parameters [ 10 ] . Value = model . purchaseUser;
            parameters [ 11 ] . Value = model . danjia;
            parameters [ 12 ] . Value = model . Weight;
            parameters [ 13 ] . Value = model . FishId;
            parameters [ 14 ] . Value = model . rebate;
            parameters [ 15 ] . Value = model . brands;
            parameters [ 16 ] . Value = model . conutry;
            parameters [ 17 ] . Value = model . proName;
            parameters [ 18 ] . Value = model . bondPro;
            parameters [ 19 ] . Value = model . varieties;
            parameters [ 20 ] . Value = model . signDate;
            parameters [ 21 ] . Value = model . signAdd;
            parameters [ 22 ] . Value = model . AmountOfMoney;
            parameters [ 23 ] . Value = model . priceMY;
            parameters [ 24 ] . Value = model . remark;
            parameters [ 25 ] . Value = model . modifyUser;
            parameters [ 26 ] . Value = model . modifyDate;
            parameters [ 27 ] . Value = model . id;
            parameters[28].Value = model.Process;
            parameters[29].Value = model.choise;
            parameters[30].Value = model.EexchangeRate;
            parameters[31].Value = model.Money;
            parameters[32].Value = model.Dollarjine;
            parameters[33].Value = model.account;
            parameters[34].Value = model.Bank;
            return MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameters );
        }
        public FishEntity.PurcurementContractEntity getCGSQD(string code) {
            StringBuilder strsql = new StringBuilder();
            //strsql.AppendFormat("SELECT codeNum,codeNumContract,bondPro,height,supplier,account,Bank FROM t_purchasecontract a left JOIN t_purchaseapplication b on a.codeNum=b.codeNum "+ code);
            strsql.AppendFormat("SELECT a.codeNum,a.codeNumContract,a.bondPro,a.height,a.supplier,b.account,b.Bank FROM t_purchasecontract a left JOIN t_purchaseapplication b on a.codeNum = b.codeNum " + code);
            DataSet ds = MySqlHelper.Query(strsql.ToString());
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                FishEntity.PurcurementContractEntity model = new FishEntity.PurcurementContractEntity();
                if (row != null)
                {
                    if (row["codeNumContract"] != null)
                    {
                        model.codeNumContract = row["codeNumContract"].ToString();
                    }
                    if (row["codeNum"] != null)
                    {
                        model.codeNum = row["codeNum"].ToString();
                    }
                    if (row["supplier"] != null)
                    {
                        model.supplier = row["supplier"].ToString();
                    }
                    if (row["bondPro"] != null&& row["bondPro"].ToString() !="")
                    {
                        model.bondPro =decimal.Parse( row["bondPro"].ToString());
                    }
                    if (row["height"] != null && row["height"].ToString() != "")
                    {
                        model.height = decimal.Parse(row["height"].ToString());
                    }
                    if (row["Account"] != null)
                    {
                        model.Account = row["Account"].ToString();
                    }
                    if (row["Bank"] != null)
                    {
                        model.Bank = row["Bank"].ToString();
                    }
                    return model;
                }
                else return null; 
            }
            else
                return null;
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . PurchaseApplicationEntity getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("SELECT id,codeNum,createUser,modifyUser,modifyDate,createDate,process,codeNumContract,supplier,supplierAbb,supplierUser,buyer,buyerAbb,buyerUser,purchase,purchaseAbb,purchaseUser,danjia,weight,fishId,rebate,brands,country,proName,bondPro,varieties,signDate,signAdd,amountOfMoney,priceMY,remark,choise,EexchangeRate,Money,Dollarjine,account,Bank FROM t_purchaseapplication WHERE {0}", strWhere );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            DataTable dt = ds . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0) {
                    return getModel(dt.Rows[0]);
            }
            else
                return null;
        }

        private FishEntity . PurchaseApplicationEntity getModel ( DataRow row )
        {
            FishEntity . PurchaseApplicationEntity  model = new FishEntity . PurchaseApplicationEntity  ( );
            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if (row["process"]!=null)
                {
                    model.Process = row["process"].ToString();
                }
                if (row["Money"]!=null)
                {
                    model.Money = row["Money"].ToString();
                }
                if (row["Dollarjine"]!=null&&row["Dollarjine"].ToString()!="")
                {
                    model.Dollarjine =decimal.Parse(row["Dollarjine"].ToString());
                }
                if (row["choise"]!=null)
                {
                    model.choise = row["choise"].ToString();
                }
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
                if ( row [ "codeNumContract" ] != null )
                {
                    model . codeNumContract = row [ "codeNumContract" ] . ToString ( );
                }
                if ( row [ "supplier" ] != null )
                {
                    model . supplier = row [ "supplier" ] . ToString ( );
                }
                if ( row [ "supplierAbb" ] != null )
                {
                    model . supplierAbb = row [ "supplierAbb" ] . ToString ( );
                }
                if ( row [ "supplierUser" ] != null )
                {
                    model . supplierUser = row [ "supplierUser" ] . ToString ( );
                }
                if ( row [ "buyer" ] != null )
                {
                    model . buyer = row [ "buyer" ] . ToString ( );
                }
                if ( row [ "buyerAbb" ] != null )
                {
                    model . buyerAbb = row [ "buyerAbb" ] . ToString ( );
                }
                if ( row [ "buyerUser" ] != null )
                {
                    model . buyerUser = row [ "buyerUser" ] . ToString ( );
                }
                if ( row [ "purchase" ] != null )
                {
                    model . purchase = row [ "purchase" ] . ToString ( );
                }
                if ( row [ "purchaseAbb" ] != null )
                {
                    model . purchaseAbb = row [ "purchaseAbb" ] . ToString ( );
                }
                if ( row [ "purchaseUser" ] != null )
                {
                    model . purchaseUser = row [ "purchaseUser" ] . ToString ( );
                }
                if ( row [ "danjia" ] != null && row [ "danjia" ] . ToString ( ) != "" )
                {
                    model . danjia = decimal . Parse ( row [ "danjia" ] . ToString ( ) );
                }
                if ( row [ "weight" ] != null && row [ "weight" ] . ToString ( ) != "" )
                {
                    model . Weight = decimal . Parse ( row [ "weight" ] . ToString ( ) );
                }
                if (row["EexchangeRate"] != null && row["EexchangeRate"].ToString() != "")
                {
                    model.EexchangeRate = decimal.Parse(row["EexchangeRate"].ToString());
                }
                if ( row [ "fishId" ] != null )
                {   
                    model . FishId = row [ "fishId" ] . ToString ( );
                }
                if ( row [ "rebate" ] != null && row [ "rebate" ] . ToString ( ) != "" )
                {
                    model . rebate = decimal . Parse ( row [ "rebate" ] . ToString ( ) );
                }
                if ( row [ "brands" ] != null )
                {
                    model . brands = row [ "brands" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . conutry = row [ "country" ] . ToString ( );
                }
                if ( row [ "proName" ] != null )
                {
                    model . proName = row [ "proName" ] . ToString ( );
                }
                if ( row [ "bondPro" ] != null && row [ "bondPro" ] . ToString ( ) != "" )
                {
                    model . bondPro = decimal . Parse ( row [ "bondPro" ] . ToString ( ) );
                }
                if ( row [ "varieties" ] != null )
                {
                    model . varieties = row [ "varieties" ] . ToString ( );
                }
                if ( row [ "signDate" ] != null && row [ "signDate" ] . ToString ( ) != "" )
                {
                    model . signDate = DateTime . Parse ( row [ "signDate" ] . ToString ( ) );
                }
                if ( row [ "signAdd" ] != null )
                {
                    model . signAdd = row [ "signAdd" ] . ToString ( );
                }
                if ( row [ "amountOfMoney" ] != null && row [ "amountOfMoney" ] . ToString ( ) != "" )
                {
                    model . AmountOfMoney = decimal . Parse ( row [ "amountOfMoney" ] . ToString ( ) );
                }
                if ( row [ "priceMY" ] != null && row [ "priceMY" ] . ToString ( ) != "" )
                {
                    model . priceMY = decimal . Parse ( row [ "priceMY" ] . ToString ( ) );
                }
                if ( row [ "remark" ] != null )
                {
                    model . remark = row [ "remark" ] . ToString ( );
                }
                if (row["account"] != null)
                {
                    model.account = row["account"].ToString();
                }
                if (row["Bank"] != null)
                {
                    model.Bank = row["Bank"].ToString();
                }
                if ( row [ "createUser" ] != null )
                {
                    model . createUser = row [ "createUser" ] . ToString ( );
                }
                if ( row [ "createDate" ] != null && row [ "createDate" ] . ToString ( ) != "" )
                {
                    model . createDate = DateTime . Parse ( row [ "createDate" ] . ToString ( ) );
                }
                if ( row [ "modifyUser" ] != null )
                {
                    model . modifyUser = row [ "modifyUser" ] . ToString ( );
                }
                if ( row [ "modifyDate" ] != null && row [ "modifyDate" ] . ToString ( ) != "" )
                {
                    model . modifyDate = DateTime . Parse ( row [ "modifyDate" ] . ToString ( ) );
                }
                return model;
            }else {
                return null;
            }
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.id,a.createUser,a.codeNum,a.bondPro,a.codeNumContract,a.supplier,a.supplierAbb,a.supplierUser,a.buyer,a.buyerAbb,a.buyerUser,a.signDate,a.signAdd,a.proName,a.choise,a.varieties,a.rebate,a.priceMY,a.purchase,a.purchaseAbb,a.purchaseUser,b.fishId,b.specifications,b.country,b.brand,b.shipName,b.billName,b.Money,b.num,b.conProtein,b.conTVN,b.conZA,b.conFFA,b.conZF,b.conSF,b.conSHY,b.conS,b.conSJ,b.conHF,b.conLAS,b.conDAS,b.choise,a.danjia,a.process from t_purchaseapplication a left join t_purchaseappfishinfo b on a.codeNum=b.code ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 获取鱼粉资料
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseFishInfo> getFishInfoList ( string codeNum )
        { 
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT * FROM t_purchasefishinfo WHERE code='{0}'" ,codeNum );
            
            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            DataTable dt = ds . Tables [ 0 ];


            if ( dt != null && dt . Rows . Count > 0 )
            {
                List<FishEntity . PurchaseFishInfo> listFishInfo = new List<FishEntity . PurchaseFishInfo> ( );

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    listFishInfo . Add ( getFishInfo ( dt . Rows [ i ] ) );
                }
                return listFishInfo;
            }
            else
                return null;
        }

        public FishEntity . PurchaseFishInfo getFishInfo ( DataRow row )
        {
            FishEntity . PurchaseFishInfo model = new FishEntity . PurchaseFishInfo ( );
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
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                {
                    model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                }
                if ( row [ "weight" ] != null && row [ "weight" ] . ToString ( ) != "" )
                {
                    model . weight = decimal . Parse ( row [ "weight" ] . ToString ( ) );
                }
                if ( row [ "priceUSA" ] != null && row [ "priceUSA" ] . ToString ( ) != "" )
                {
                    model . priceUSA = decimal . Parse ( row [ "priceUSA" ] . ToString ( ) );
                }
                if ( row [ "specifications" ] != null )
                {
                    model . specifications = row [ "specifications" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "shipName" ] != null )
                {
                    model . shipName = row [ "shipName" ] . ToString ( );
                }
                if ( row [ "billName" ] != null )
                {
                    model . billName = row [ "billName" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取扣减资料
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseOtherInfo> getOtherInfoList ( string codeNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select * from t_purchaseotherinfo where code='{0}'" ,codeNum );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            DataTable dt = ds . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                List<FishEntity . PurchaseOtherInfo> otherInfoList = new List<FishEntity . PurchaseOtherInfo> ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    otherInfoList . Add ( getOtherInfo ( dt . Rows [ i ] ) );
                }
                return otherInfoList;
            }
            else
                return null;
        }

        public FishEntity . PurchaseOtherInfo getOtherInfo ( DataRow row )
        {
            FishEntity . PurchaseOtherInfo model = new FishEntity . PurchaseOtherInfo ( );
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
                if ( row [ "brands" ] != null )
                {
                    model . brand = row [ "brands" ] . ToString ( );
                }
                if ( row [ "money" ] != null && row [ "money" ] . ToString ( ) != "" )
                {
                    model . money = decimal . Parse ( row [ "money" ] . ToString ( ) );
                }
                if ( row [ "num" ] != null && row [ "num" ] . ToString ( ) != "" )
                {
                    model . num = decimal . Parse ( row [ "num" ] . ToString ( ) );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取编号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeNumData ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT codeNum FROM t_purchaseapplication ORDER BY codeNum" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 保存鱼粉资料
        /// </summary>
        /// <param name="listFishInfo"></param>
        /// <returns></returns>
        public bool SaveFishInfo ( List<FishEntity . PurchaseFishInfo> listFishInfo )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_purchaseFishInfo where code='{0}'" ,listFishInfo [ 0 ] . code );
            MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            foreach ( FishEntity . PurchaseFishInfo model in listFishInfo )
            {
                if ( !string . IsNullOrEmpty ( model . fishId ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . Append ( "insert into t_purchasefishinfo(" );
                    strSql . Append ( "code,fishId,price,weight,priceUSA,specifications,brand,country,shipName,billName)" );
                    strSql . Append ( " values (" );
                    strSql . Append ( "@code,@fishId,@price,@weight,@priceUSA,@specifications,@brand,@country,@shipName,@billName)" );
                    MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@weight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@priceUSA", MySqlDbType.Decimal,10),
                    new MySqlParameter("@specifications", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45)};
                    parameters [ 0 ] . Value = model . code;
                    parameters [ 1 ] . Value = model . fishId;
                    parameters [ 2 ] . Value = model . price;
                    parameters [ 3 ] . Value = model . weight;
                    parameters [ 4 ] . Value = model . priceUSA;
                    parameters [ 5 ] . Value = model . specifications;
                    parameters [ 6 ] . Value = model . brand;
                    parameters [ 7 ] . Value = model . country;
                    parameters [ 8 ] . Value = model . shipName;
                    parameters [ 9 ] . Value = model . billName;

                    SQLString . Add ( strSql ,parameters );
                }
            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 保存减价资料
        /// </summary>
        /// <param name="listOtherInfo"></param>
        /// <returns></returns>
        public bool SaveOtherInfo ( List<FishEntity . PurchaseOtherInfo> listOtherInfo )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_purchaseotherinfo where code='{0}'" ,listOtherInfo [ 0 ] . code );
            MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            foreach ( FishEntity . PurchaseOtherInfo model in listOtherInfo )
            {
                strSql = new StringBuilder ( );
                strSql . Append ( "insert into t_purchaseotherinfo(" );
                strSql . Append ( "code,brand,money,num)" );
                strSql . Append ( " values (" );
                strSql . Append ( "@code,@brand,@money,@num)" );
                MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@num", MySqlDbType.Decimal,10)};
                parameters [ 0 ] . Value = model . code;
                parameters [ 1 ] . Value = model . brand;
                parameters [ 2 ] . Value = model . money;
                parameters [ 3 ] . Value = model . num;
                SQLString . Add ( strSql ,parameters );
            }
            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }


    }
}
