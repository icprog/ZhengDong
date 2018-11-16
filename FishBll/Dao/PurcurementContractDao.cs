using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class PurcurementContractDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.id,a.codeNum,a.codeNumContract,a.supplier,a.supplierUser,a.signDate,a.signAdd,a.bondPro,a.proName,a.choise,a.quaSpe,a.UnitPrice,a.Dollar,a.conutry,a.height,a.price,a.priceMY,a.shipDate,a.deliveryDate,a.deliveryAdd,a.conProtein,a.conTVN,a.conZA,a.conFFA,a.conSHY,a.conHF,a.conLAS,a.conDAS,b.brands,b.money,b.num from t_purchasecontract a LEFT JOIN t_purchaseotherinfo b on a.codeNum=b.code ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 生成合同单号
        /// </summary>
        /// <returns></returns>
        public string getCodeNum ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT MAX(codeNumContract) code FROM t_purchasecontract WHERE codeNumContract LIKE 'ZD{0}%' and xufang='需方'" ,DateTime . Now . ToString ( "yyyyMMdd" ) );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                string code = dt . Rows [ 0 ] [ "code" ] . ToString ( );
                if ( string . IsNullOrEmpty ( code ) )
                    return "ZD" + DateTime . Now . ToString ( "yyyyMMdd" ) + "0001";
                else
                    return "ZD" + ( Convert . ToInt64 ( code . Substring ( 2 ,code . Length - 2 ) ) + 1 ) . ToString ( );
            }
            else
                return "ZD" + DateTime . Now . ToString ( "yyyyMMdd" ) + "0001";

        }
        
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( FishEntity . PurcurementContractEntity _model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("SELECT COUNT(1) FROM t_purchasecontract WHERE codeNum='{0}'", _model . codeNum );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }
        public bool Exists(string codenuml)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT COUNT(1) FROM t_purchaseappfishinfo WHERE code='{0}'", codenuml);

            return MySqlHelper.Exists(strSql.ToString());
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="dicPic"></param>
        /// <returns></returns>
        public int Save ( FishEntity . PurcurementContractEntity _model ,Dictionary<int ,FishEntity . PicInfoAll> dicPic )
        {
            Hashtable SQLSing = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            int idx = add ( strSql ,_model );
            if ( idx > 0 )
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE t_purchaseApplication SET codeNumContract='{0}' WHERE codeNum='{1}'" ,_model . codeNumContract ,_model . codeNum );
                SQLSing . Add ( strSql ,null );
                foreach ( FishEntity . PicInfoAll model in dicPic . Values )
                {
                    model . tableId = idx;
                    addImage ( SQLSing ,strSql ,model );
                }
                if ( MySqlHelper . ExecuteSqlTran ( SQLSing ) )
                    return idx;
                else
                    return -1;
            }
            else
                return 0;
        }

        int add ( StringBuilder strSql ,FishEntity . PurcurementContractEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_purchasecontract(" );
            strSql . Append ("codeNum,codeNumContract,supplier,supplierUser,buyer,buyerUser,signDate,signAdd,bondPro,varieties,quaSpe,height,price,priceMY,conutry,shipDate,deliveryDate,deliveryAdd,conProtein,conTVN,conZA,conFFA,conZF,conSF,conSHY,conS,conSJ,conHF,conLAS,conDAS,createUser,createDate,modifyUser,modifyDate,purchase,purchaseUser,UnitPrice,Dollar,proName,choise,gongfang,xufang)");
            strSql . Append ( " values (" );
            strSql . Append ("@codeNum,@codeNumContract,@supplier,@supplierUser,@buyer,@buyerUser,@signDate,@signAdd,@bondPro,@varieties,@quaSpe,@height,@price,@priceMY,@conutry,@shipDate,@deliveryDate,@deliveryAdd,@conProtein,@conTVN,@conZA,@conFFA,@conZF,@conSF,@conSHY,@conS,@conSJ,@conHF,@conLAS,@conDAS,@createUser,@createDate,@modifyUser,@modifyDate,@purchase,@purchaseUser,@UnitPrice,@Dollar,@proName,@choise,@gongfang,@xufang);select LAST_INSERT_ID();");
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,30),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,30),
                    new MySqlParameter("@supplier", MySqlDbType.VarChar,50),
                    new MySqlParameter("@supplierUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyer", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyerUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@signDate", MySqlDbType.DateTime),
                    new MySqlParameter("@signAdd", MySqlDbType.VarChar,100),
                    new MySqlParameter("@bondPro", MySqlDbType.Decimal,18),
                    new MySqlParameter("@varieties", MySqlDbType.VarChar,50),
                    new MySqlParameter("@quaSpe", MySqlDbType.VarChar,50),
                    new MySqlParameter("@height", MySqlDbType.Decimal,18),
                    new MySqlParameter("@price", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,18),
                    new MySqlParameter("@conutry", MySqlDbType.VarChar,30),
                    new MySqlParameter("@shipDate", MySqlDbType.DateTime),
                    new MySqlParameter("@deliveryDate", MySqlDbType.DateTime),
                    new MySqlParameter("@deliveryAdd", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conProtein", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conTVN", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conZA", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conFFA", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conZF", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conSF", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conSHY", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conS", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conSJ", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conHF", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conLAS", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conDAS", MySqlDbType.VarChar,50),
                    new MySqlParameter("@createUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@createDate", MySqlDbType.DateTime),
                    new MySqlParameter("@modifyUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@modifyDate", MySqlDbType.DateTime),
                    new MySqlParameter("@purchase", MySqlDbType.VarChar,50),
                    new MySqlParameter("@purchaseUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@UnitPrice", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Dollar", MySqlDbType.VarChar,50),
                    new MySqlParameter("@proName",MySqlDbType.VarChar,45),
                    new MySqlParameter("@choise",MySqlDbType.VarChar,45),
                    new MySqlParameter("@xufang",MySqlDbType.VarChar,45),
                    new MySqlParameter("@gongfang",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . codeNum;
            parameters [ 1 ] . Value = model . codeNumContract;
            parameters [ 2 ] . Value = model . supplier;
            parameters [ 3 ] . Value = model . supplierUser;
            parameters [ 4 ] . Value = model . buyer;
            parameters [ 5 ] . Value = model . buyerUser;
            parameters [ 6 ] . Value = model . signDate;
            parameters [ 7 ] . Value = model . signAdd;
            parameters [ 8 ] . Value = model . bondPro;
            parameters [ 9 ] . Value = model . varieties;
            parameters [ 10 ] . Value = model . quaSpe;
            parameters [ 11 ] . Value = model . height;
            parameters [ 12 ] . Value = model . price;
            parameters [ 13 ] . Value = model . priceMY;
            parameters [ 14 ] . Value = model . conutry;
            parameters [ 15 ] . Value = model . shipdate;
            parameters [ 16 ] . Value = model . deliveryDate;
            parameters [ 17 ] . Value = model . deliveryAdd;
            parameters [ 18 ] . Value = model . conProtein;
            parameters [ 19 ] . Value = model . conTVN;
            parameters [ 20 ] . Value = model . conZA;
            parameters [ 21 ] . Value = model . conFFA;
            parameters [ 22 ] . Value = model . conZF;
            parameters [ 23 ] . Value = model . conSF;
            parameters [ 24 ] . Value = model . conSHY;
            parameters [ 25 ] . Value = model . conS;
            parameters [ 26 ] . Value = model . conSJ;
            parameters [ 27 ] . Value = model . conHF;
            parameters [ 28 ] . Value = model . conLAS;
            parameters [ 29 ] . Value = model . conDAS;
            parameters [ 30 ] . Value = model . createUser;
            parameters [ 31 ] . Value = model . createDate;
            parameters [ 32 ] . Value = model . modifyUser;
            parameters [ 33 ] . Value = model . modifyDate;
            parameters [ 34 ] . Value = model . purchase;
            parameters [ 35 ] . Value = model . purchaseUser;
            parameters[36].Value = model.UnitPrice;
            parameters[37].Value = model.Dollar;
            parameters[38].Value = model.ProName;
            parameters[39].Value = model.Choise;
            parameters[40].Value = model.xufang ;
            parameters[41].Value = model.gongfang;
            return MySqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameters );
        }

        void addImage (Hashtable SQLSing ,StringBuilder strSql ,FishEntity . PicInfoAll model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_picinfoall(" );
            strSql . Append ( "tableId,tableName,picInfo)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@tableId,@tableName,@picInfo)" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@tableId", MySqlDbType.Int32,11),
                    new MySqlParameter("@tableName", MySqlDbType.VarChar,255),
                    new MySqlParameter("@picInfo", MySqlDbType.LongBlob)
                    };
            parameters [ 0 ] . Value = model .tableId;
            parameters [ 1 ] . Value = model . tableName;
            parameters [ 2 ] . Value = model . picInfo;
            SQLSing . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="dicPic"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int Edit ( FishEntity . PurcurementContractEntity _model ,Dictionary<int ,FishEntity . PicInfoAll> dicPic,string tableName )
        {
            int result = 0;
            StringBuilder strSql = new StringBuilder ( );
            Hashtable SQLString = new Hashtable ( );
            edit ( SQLString ,strSql ,_model );
            if (dicPic != null)
            {
                if (MySqlHelper.ExecuteSqlTran(SQLString))
                {
                    SQLString.Clear();
                    strSql = new StringBuilder();
                    strSql.AppendFormat("SELECT COUNT(1) FROM t_picinfoall WHERE tableId={0}", _model.id);

                    if (MySqlHelper.Exists(strSql.ToString()))
                    {
                        result = 1;
                        SQLString.Clear();
                        strSql = new StringBuilder();
                        strSql.AppendFormat("UPDATE t_purchaseApplication SET codeNumContract='{0}' WHERE codeNum='{1}'", _model.codeNumContract, _model.codeNum);
                        SQLString.Add(strSql, null);
                        strSql = new StringBuilder();
                        strSql.AppendFormat("DELETE FROM t_picinfoall WHERE tableId={0} and tableName='{1}'", _model.id, tableName);
                        if (MySqlHelper.ExecuteSql(strSql.ToString()) > 0)
                        {
                            foreach (FishEntity.PicInfoAll model in dicPic.Values)
                            {
                                model.id = _model.id;
                                addImage(SQLString, strSql, model);
                            }
                        }
                        else
                            result = -1;
                    }
                    else
                    {
                        foreach (FishEntity.PicInfoAll model in dicPic.Values)
                        {
                            model.id = _model.id;
                            addImage(SQLString, strSql, model);
                        }
                    }

                    if (MySqlHelper.ExecuteSqlTran(SQLString))
                        result = 1;
                    else
                        result = -1;
                }
                else
                    result = 0;

                return result;
            }
            else
            {
                if (MySqlHelper.ExecuteSqlTran(SQLString))
                    return result = 1;
                else
                    return result = -1;
            }
        }

        void edit (Hashtable SQLString, StringBuilder strSql ,FishEntity . PurcurementContractEntity model )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "update t_purchasecontract set " );
            strSql . Append ( "codeNum=@codeNum," );
            strSql . Append ( "codeNumContract=@codeNumContract," );
            strSql . Append ( "supplier=@supplier," );
            strSql . Append ( "supplierUser=@supplierUser," );
            strSql . Append ( "buyer=@buyer," );
            strSql . Append ( "buyerUser=@buyerUser," );
            strSql . Append ( "signDate=@signDate," );
            strSql . Append ( "signAdd=@signAdd," );
            strSql . Append ( "bondPro=@bondPro," );
            strSql . Append ( "varieties=@varieties," );
            strSql . Append ( "quaSpe=@quaSpe," );
            strSql . Append ( "height=@height," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "priceMY=@priceMY," );
            strSql . Append ( "conutry=@conutry," );
            strSql . Append ( "shipDate=@shipDate," );
            strSql . Append ( "deliveryDate=@deliveryDate," );
            strSql . Append ( "deliveryAdd=@deliveryAdd," );
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
            strSql . Append ( "purchase=@purchase," );
            strSql . Append ( "purchaseUser=@purchaseUser," );
            strSql . Append ( "modifyUser=@modifyUser," );
            strSql.Append("UnitPrice=@UnitPrice,");
            strSql.Append("Dollar=@Dollar,");
            strSql.Append("proName=@proName,");
            strSql.Append("choise=@choise,");
            strSql.Append("gongfang=@gongfang,");
            strSql.Append("xufang=@xufang,");
            strSql . Append ( "modifyDate=@modifyDate" );
            strSql . Append ( " where id=@id" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,30),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,30),
                    new MySqlParameter("@supplier", MySqlDbType.VarChar,50),
                    new MySqlParameter("@supplierUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyer", MySqlDbType.VarChar,50),
                    new MySqlParameter("@buyerUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@signDate", MySqlDbType.DateTime),
                    new MySqlParameter("@signAdd", MySqlDbType.VarChar,100),
                    new MySqlParameter("@bondPro", MySqlDbType.Decimal,18),
                    new MySqlParameter("@varieties", MySqlDbType.VarChar,50),
                    new MySqlParameter("@quaSpe", MySqlDbType.VarChar,50),
                    new MySqlParameter("@height", MySqlDbType.Decimal,18),
                    new MySqlParameter("@price", MySqlDbType.Decimal,18),
                    new MySqlParameter("@priceMY", MySqlDbType.Decimal,18),
                    new MySqlParameter("@conutry", MySqlDbType.VarChar,30),
                    new MySqlParameter("@shipDate", MySqlDbType.DateTime),
                    new MySqlParameter("@deliveryDate", MySqlDbType.DateTime),
                    new MySqlParameter("@deliveryAdd", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conProtein", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conTVN", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conZA", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conFFA", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conZF", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conSF", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conSHY", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conS", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conSJ", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conHF", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conLAS", MySqlDbType.VarChar,50),
                    new MySqlParameter("@conDAS", MySqlDbType.VarChar,50),
                    new MySqlParameter("@modifyUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@modifyDate", MySqlDbType.DateTime),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@purchase", MySqlDbType.VarChar,50),
                    new MySqlParameter("@purchaseUser", MySqlDbType.VarChar,50),
                    new MySqlParameter("@UnitPrice", MySqlDbType.VarChar,50),
                    new MySqlParameter("@Dollar", MySqlDbType.VarChar,50),
                    new MySqlParameter("@proName",MySqlDbType.VarChar,45),
                    new MySqlParameter("@choise",MySqlDbType.VarChar,45),
                    new MySqlParameter("@gongfang",MySqlDbType.VarChar,45),
                    new MySqlParameter("@xufang",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . codeNum;
            parameters [ 1 ] . Value = model . codeNumContract;
            parameters [ 2 ] . Value = model . supplier;
            parameters [ 3 ] . Value = model . supplierUser;
            parameters [ 4 ] . Value = model . buyer;
            parameters [ 5 ] . Value = model . buyerUser;
            parameters [ 6 ] . Value = model . signDate;
            parameters [ 7 ] . Value = model . signAdd;
            parameters [ 8 ] . Value = model . bondPro;
            parameters [ 9 ] . Value = model . varieties;
            parameters [ 10 ] . Value = model . quaSpe;
            parameters [ 11 ] . Value = model . height;
            parameters [ 12 ] . Value = model . price;
            parameters [ 13 ] . Value = model . priceMY;
            parameters [ 14 ] . Value = model . conutry;
            parameters [ 15 ] . Value = model . shipdate;
            parameters [ 16 ] . Value = model . deliveryDate;
            parameters [ 17 ] . Value = model . deliveryAdd;
            parameters [ 18 ] . Value = model . conProtein;
            parameters [ 19 ] . Value = model . conTVN;
            parameters [ 20 ] . Value = model . conZA;
            parameters [ 21 ] . Value = model . conFFA;
            parameters [ 22 ] . Value = model . conZF;
            parameters [ 23 ] . Value = model . conSF;
            parameters [ 24 ] . Value = model . conSHY;
            parameters [ 25 ] . Value = model . conS;
            parameters [ 26 ] . Value = model . conSJ;
            parameters [ 27 ] . Value = model . conHF;
            parameters [ 28 ] . Value = model . conLAS;
            parameters [ 29 ] . Value = model . conDAS;
            parameters [ 30 ] . Value = model . modifyUser;
            parameters [ 31] . Value = model . modifyDate;
            parameters [ 32 ] . Value = model . id;
            parameters [ 33 ] . Value = model . purchase;
            parameters [ 34 ] . Value = model . purchaseUser;
            parameters[35].Value = model.UnitPrice;
            parameters[36].Value = model.Dollar;
            parameters[37].Value = model.ProName;
            parameters[38].Value = model.Choise;
            parameters[39].Value = model.gongfang ;
            parameters[40].Value = model.xufang ;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id ,string tableName )
        {
            StringBuilder strSql = new StringBuilder ( );
            Hashtable SQLString = new Hashtable ( );
            strSql . AppendFormat ( "DELETE FROM t_purchasecontract WHERE id={0}" ,id );
            SQLString . Add ( strSql . ToString ( ) ,null );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM t_picinfoall WHERE tableId={0} and tableName='{1}' " ,id ,tableName );
            SQLString . Add ( strSql . ToString ( ) ,null );

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . PurcurementContractEntity getModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("select id,codeNum,codeNumContract,UnitPrice,Dollar,supplier,supplierUser,buyer,buyerUser,signDate,signAdd,bondPro,proName,choise,varieties,quaSpe,height,price,priceMY,conutry,shipDate,deliveryDate,deliveryAdd,conProtein,conTVN,conZA,conFFA,conZF,conSF,conSHY,conS,conSJ,conHF,conLAS,conDAS,createUser,createDate,modifyUser,modifyDate,purchaseUser,purchase,gongfang,xufang from t_purchasecontract ");
            strSql . AppendFormat ( " where {0}" ,strWhere );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
                return getModel ( dt . Rows [ 0 ] );
            else
                return null;
        }
        
        FishEntity . PurcurementContractEntity getModel ( DataRow row )
        {
            FishEntity . PurcurementContractEntity model = new FishEntity . PurcurementContractEntity ( );
            if ( row != null )
            {
                if (row["gongfang"]!=null)
                {
                    model.gongfang = row["gongfang"].ToString();
                }
                if (row["xufang"] != null)
                {
                    model.xufang = row["xufang"].ToString();
                }
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
                if ( row [ "codeNumContract" ] != null )
                {
                    model . codeNumContract = row [ "codeNumContract" ] . ToString ( );
                }
                if (row["UnitPrice"] != null)
                {
                    model.UnitPrice = row["UnitPrice"].ToString();
                }
                if (row["Dollar"] != null)
                {
                    model.Dollar = row["Dollar"].ToString();
                }
                if ( row [ "supplier" ] != null )
                {
                    model . supplier = row [ "supplier" ] . ToString ( );
                }
                if ( row [ "supplierUser" ] != null )
                {
                    model . supplierUser = row [ "supplierUser" ] . ToString ( );
                }
                if ( row [ "buyer" ] != null )
                {
                    model . buyer = row [ "buyer" ] . ToString ( );
                }
                if ( row [ "buyerUser" ] != null )
                {
                    model . buyerUser = row [ "buyerUser" ] . ToString ( );
                }
                if ( row [ "signDate" ] != null && row [ "signDate" ] . ToString ( ) != "" )
                {
                    model . signDate = DateTime . Parse ( row [ "signDate" ] . ToString ( ) );
                }
                if ( row [ "signAdd" ] != null )
                {
                    model . signAdd = row [ "signAdd" ] . ToString ( );
                }
                if ( row [ "bondPro" ] != null && row [ "bondPro" ] . ToString ( ) != "" )
                {
                    model . bondPro = decimal . Parse ( row [ "bondPro" ] . ToString ( ) );
                }
                if (row["proName"]!=null)
                {
                    model.ProName = row["proName"].ToString();
                }
                if (row["choise"]!=null)
                {
                    model.Choise = row["choise"].ToString();
                }
                if ( row [ "varieties" ] != null )
                {
                    model . varieties = row [ "varieties" ] . ToString ( );
                }
                if ( row [ "quaSpe" ] != null )
                {
                    model . quaSpe = row [ "quaSpe" ] . ToString ( );
                }
                if ( row [ "height" ] != null && row [ "height" ] . ToString ( ) != "" )
                {
                    model . height = decimal . Parse ( row [ "height" ] . ToString ( ) );
                }
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                {
                    model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                }
                if ( row [ "priceMY" ] != null && row [ "priceMY" ] . ToString ( ) != "" )
                {
                    model . priceMY = decimal . Parse ( row [ "priceMY" ] . ToString ( ) );
                }
                if ( row [ "conutry" ] != null )
                {
                    model . conutry = row [ "conutry" ] . ToString ( );
                }
                if ( row [ "shipDate" ] != null && row [ "shipDate" ] . ToString ( ) != "" )
                {
                    model . shipdate = DateTime . Parse ( row [ "shipDate" ] . ToString ( ) );
                }
                if ( row [ "deliveryDate" ] != null && row [ "deliveryDate" ] . ToString ( ) != "" )
                {
                    model . deliveryDate = DateTime . Parse ( row [ "deliveryDate" ] . ToString ( ) );
                }
                if ( row [ "deliveryAdd" ] != null )
                {
                    model . deliveryAdd = row [ "deliveryAdd" ] . ToString ( );
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
                if ( row [ "purchase" ] != null )
                {
                    model . purchase = row [ "purchase" ] . ToString ( );
                }
                if ( row [ "purchaseUser" ] != null )
                {
                    model . purchaseUser = row [ "purchaseUser" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dictionary<int ,FishEntity . PicInfoAll> getImages ( int id ,string tableName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select id,tableId,tableName,picInfo from t_picinfoall " );
            strSql . Append ( " where tableId=@id and tableName=@tableName" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32),
                    new MySqlParameter("@tableName", MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = id;
            parameters [ 1 ] . Value = tableName;

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) ,parameters );
            DataTable dt = ds . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                Dictionary<int ,FishEntity . PicInfoAll> dicPic = new Dictionary<int ,FishEntity . PicInfoAll> ( );
                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    dicPic . Add ( i ,getPic ( dt . Rows [ i ] ) );
                }
                return dicPic;
            }
            else
                return null;
        }

        FishEntity . PicInfoAll getPic ( DataRow row )
        {
            FishEntity . PicInfoAll model = new FishEntity . PicInfoAll ( );
            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "tableId" ] != null && row [ "tableId" ] . ToString ( ) != "" )
                {
                    model . tableId = int . Parse ( row [ "tableId" ] . ToString ( ) );
                }
                if ( row [ "tableName" ] != null )
                {
                    model . tableName = row [ "tableName" ] . ToString ( );
                }
                if ( row [ "picInfo" ] != null && row [ "picInfo" ] . ToString ( ) != "" )
                    model . picInfo = ( byte [ ] ) row [ "picInfo" ];
                else
                    model . picInfo = new byte [ 0 ];
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeNumData ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT codeNumContract FROM t_purchasecontract" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 保存鱼粉资料
        /// </summary>
        /// <param name="listFishInfo"></param>
        /// <returns></returns>
        public bool SaveFishInfo ( List<FishEntity . PurchaseContractFishInfo> listFishInfo )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_purchaseContractfishinfo where code='{0}'" ,listFishInfo [ 0 ] . code );
            MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            foreach ( FishEntity . PurchaseContractFishInfo model in listFishInfo )
            {
                if ( !string . IsNullOrEmpty ( model . fishId ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . Append ( "insert into t_purchaseContractfishinfo(" );
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
        /// 获取鱼粉资料
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseContractFishInfo> getFishInfoList ( string codeNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT * FROM t_purchaseContractfishinfo WHERE code='{0}'" ,codeNum );

            DataSet ds = MySqlHelper . Query ( strSql . ToString ( ) );
            DataTable dt = ds . Tables [ 0 ];


            if ( dt != null && dt . Rows . Count > 0 )
            {
                List<FishEntity . PurchaseContractFishInfo> listFishInfo = new List<FishEntity . PurchaseContractFishInfo> ( );

                for ( int i = 0 ; i < dt . Rows . Count ; i++ )
                {
                    listFishInfo . Add ( getFishInfo ( dt . Rows [ i ] ) );
                }
                return listFishInfo;
            }
            else
                return null;
        }

        public FishEntity . PurchaseContractFishInfo getFishInfo ( DataRow row )
        {
            FishEntity . PurchaseContractFishInfo model = new FishEntity . PurchaseContractFishInfo ( );
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

    }
}
