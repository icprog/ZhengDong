using MySql . Data . MySqlClient;
using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class ReturnReceiptDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT id,codeNum,codeNumContract,code,returnPartyJ,receiveJ,speci,tons,price,money,returnGoodsAdd,fishId,freight,cost,loss from t_returnreceipt ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT max(code) code from t_ReturnReceipt" );

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
            strSql . Append ( "delete from t_returnreceipt " );
            strSql . AppendFormat ( " where code='{0}' " ,code );

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
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
		/// 更新一条数据
		/// </summary>
		public bool Update ( FishEntity . ReturnReceiptEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_returnreceipt set " );
            strSql . Append ( "codeNum=@codeNum," );
            strSql . Append ( "codeNumContract=@codeNumContract," );
            strSql . Append ( "returnParty=@returnParty," );
            strSql . Append ( "receive=@receive," );
            strSql . Append ( "signDate=@signDate," );
            strSql . Append ( "varieties=@varieties," );
            strSql . Append ( "inputDate=@inputDate," );
            strSql . Append ( "returnPartyJ=@returnPartyJ," );
            strSql . Append ( "receiveJ=@receiveJ," );
            strSql . Append ( "proName=@proName," );
            strSql . Append ( "speci=@speci," );
            strSql . Append ( "tons=@tons," );
            strSql.Append("ShipmentsTons=@ShipmentsTons,");
            strSql.Append("LiNumber=@LiNumber,");
            strSql . Append ( "price=@price," );
            strSql . Append ( "money=@money," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "deliAdd=@deliAdd," );
            strSql . Append ( "fishId=@fishId," );
            strSql . Append ( "freight=@freight," );
            strSql . Append ( "cost=@cost," );
            strSql . Append ( "loss=@loss," );
            strSql . Append ( "condb=@condb," );
            strSql . Append ( "conza=@conza," );
            strSql . Append ( "cons=@cons," );
            strSql . Append ( "contvn=@contvn," );
            strSql . Append ( "conhf=@conhf," );
            strSql . Append ( "consf=@consf," );
            strSql . Append ( "conshy=@conshy," );
            strSql . Append ( "conzf=@conzf," );
            strSql . Append ( "returnGoodsAdd=@returnGoodsAdd," );
            strSql.Append("duanxuan=@duanxuan,");
            strSql . Append ( "remark=@remark" );
            strSql . Append ( " where code=@code " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@returnParty", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receive", MySqlDbType.VarChar,45),
                    new MySqlParameter("@signDate", MySqlDbType.Date),
                    new MySqlParameter("@varieties", MySqlDbType.VarChar,45),
                    new MySqlParameter("@inputDate", MySqlDbType.Date),
                    new MySqlParameter("@returnPartyJ", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receiveJ", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tons", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@deliAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@cost", MySqlDbType.Decimal,10),
                    new MySqlParameter("@loss", MySqlDbType.Decimal,10),
                    new MySqlParameter("@condb", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conza", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cons", MySqlDbType.VarChar,45),
                    new MySqlParameter("@contvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conhf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@consf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conshy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conzf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@returnGoodsAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,225),
                    new MySqlParameter("@duanxuan",MySqlDbType.VarChar,45),
                    new MySqlParameter("@LiNumber",MySqlDbType.Decimal,10),
                    new MySqlParameter("@ShipmentsTons",MySqlDbType.Decimal,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . codeNum;
            parameters [ 2 ] . Value = model . codeNumContract;
            parameters [ 3 ] . Value = model . returnParty;
            parameters [ 4 ] . Value = model . receive;
            parameters [ 5 ] . Value = model . signDate;
            parameters [ 6 ] . Value = model . varieties;
            parameters [ 7 ] . Value = model . inputDate;
            parameters [ 8 ] . Value = model . returnPartyJ;
            parameters [ 9 ] . Value = model . receiveJ;
            parameters [ 10 ] . Value = model . proName;
            parameters [ 11 ] . Value = model . speci;
            parameters [ 12 ] . Value = model . tons;
            parameters [ 13 ] . Value = model . price;
            parameters [ 14 ] . Value = model . money;
            parameters [ 15 ] . Value = model . country;
            parameters [ 16 ] . Value = model . brand;
            parameters [ 17 ] . Value = model . deliAdd;
            parameters [ 18 ] . Value = model . fishId;
            parameters [ 19 ] . Value = model . freight;
            parameters [ 20 ] . Value = model . cost;
            parameters [ 21 ] . Value = model . loss;
            parameters [ 22 ] . Value = model . condb;
            parameters [ 23 ] . Value = model . conza;
            parameters [ 24 ] . Value = model . cons;
            parameters [ 25 ] . Value = model . contvn;
            parameters [ 26 ] . Value = model . conhf;
            parameters [ 27 ] . Value = model . consf;
            parameters [ 28 ] . Value = model . conshy;
            parameters [ 29 ] . Value = model . conzf;
            parameters [ 30 ] . Value = model . returnGoodsAdd;
            parameters [ 31 ] . Value = model . remark;
            parameters[32].Value = model.duanxuan;
            parameters[33].Value = model.LiNumber;
            parameters[34].Value = model.ShipmentsTons;

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
        public bool Add ( FishEntity . ReturnReceiptEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_returnreceipt(" );
            strSql . Append ("id,code,codeNum,codeNumContract,returnParty,receive,signDate,varieties,inputDate,returnPartyJ,receiveJ,proName,speci,tons,ShipmentsTons,price,money,country,brand,deliAdd,fishId,freight,cost,loss,condb,conza,cons,contvn,conhf,consf,conshy,conzf,returnGoodsAdd,remark,duanxuan,LiNumber)");
            strSql . Append ( " values (" );
            strSql . Append ("@id,@code,@codeNum,@codeNumContract,@returnParty,@receive,@signDate,@varieties,@inputDate,@returnPartyJ,@receiveJ,@proName,@speci,@tons,@ShipmentsTons,@price,@money,@country,@brand,@deliAdd,@fishId,@freight,@cost,@loss,@condb,@conza,@cons,@contvn,@conhf,@consf,@conshy,@conzf,@returnGoodsAdd,@remark,@duanxuan,@LiNumber)");
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@returnParty", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receive", MySqlDbType.VarChar,45),
                    new MySqlParameter("@signDate", MySqlDbType.Date),
                    new MySqlParameter("@varieties", MySqlDbType.VarChar,45),
                    new MySqlParameter("@inputDate", MySqlDbType.Date),
                    new MySqlParameter("@returnPartyJ", MySqlDbType.VarChar,45),
                    new MySqlParameter("@receiveJ", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@speci", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tons", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@money", MySqlDbType.Decimal,10),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@deliAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@freight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@cost", MySqlDbType.Decimal,10),
                    new MySqlParameter("@loss", MySqlDbType.Decimal,10),
                    new MySqlParameter("@condb", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conza", MySqlDbType.VarChar,45),
                    new MySqlParameter("@cons", MySqlDbType.VarChar,45),
                    new MySqlParameter("@contvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conhf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@consf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conshy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@conzf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@returnGoodsAdd", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,225),
                    new MySqlParameter("@duanxuan",MySqlDbType.VarChar,45),
                    new MySqlParameter("@LiNumber",MySqlDbType.Decimal,10),
                    new MySqlParameter("@ShipmentsTons",MySqlDbType.Decimal,45)
            };
            parameters [ 0 ] . Value = model . id;
            parameters [ 1 ] . Value = model . code;
            parameters [ 2 ] . Value = model . codeNum;
            parameters [ 3 ] . Value = model . codeNumContract;
            parameters [ 4 ] . Value = model . returnParty;
            parameters [ 5 ] . Value = model . receive;
            parameters [ 6 ] . Value = model . signDate;
            parameters [ 7 ] . Value = model . varieties;
            parameters [ 8 ] . Value = model . inputDate;
            parameters [ 9 ] . Value = model . returnPartyJ;
            parameters [ 10 ] . Value = model . receiveJ;
            parameters [ 11 ] . Value = model . proName;
            parameters [ 12 ] . Value = model . speci;
            parameters [ 13 ] . Value = model . tons;
            parameters [ 14 ] . Value = model . price;
            parameters [ 15 ] . Value = model . money;
            parameters [ 16 ] . Value = model . country;
            parameters [ 17 ] . Value = model . brand;
            parameters [ 18 ] . Value = model . deliAdd;
            parameters [ 19 ] . Value = model . fishId;
            parameters [ 20 ] . Value = model . freight;
            parameters [ 21 ] . Value = model . cost;
            parameters [ 22 ] . Value = model . loss;
            parameters [ 23 ] . Value = model . condb;
            parameters [ 24 ] . Value = model . conza;
            parameters [ 25 ] . Value = model . cons;
            parameters [ 26 ] . Value = model . contvn;
            parameters [ 27 ] . Value = model . conhf;
            parameters [ 28 ] . Value = model . consf;
            parameters [ 29 ] . Value = model . conshy;
            parameters [ 30 ] . Value = model . conzf;
            parameters [ 31 ] . Value = model . returnGoodsAdd;
            parameters [ 32 ] . Value = model . remark;
            parameters[33].Value = model.duanxuan;
            parameters[34].Value = model.LiNumber;
            parameters[25].Value = model.ShipmentsTons;
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
		public FishEntity . ReturnReceiptEntity GetModel ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("select id,code,codeNum,codeNumContract,returnParty,receive,signDate,varieties,inputDate,returnPartyJ,receiveJ,proName,speci,tons,ShipmentsTons,LiNumber,price,money,country,brand,deliAdd,fishId,freight,cost,loss,condb,conza,cons,contvn,conhf,consf,conshy,conzf,returnGoodsAdd,remark,duanxuan from t_returnreceipt ");
            strSql . AppendFormat ( " where {0} " ,strWhere );

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
        public FishEntity.SalesRequisitionEntity GetModelzy(string codeNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Numbering,rabZy from t_salesorder ");
            strSql.AppendFormat(" where {0} ", codeNum);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                if (ds.Tables[0].Rows[0]!=null)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    if (row["Numbering"] != null)
                    {
                        model.Numbering = row["Numbering"].ToString();
                    }
                    if (row["rabZy"]!=null&&row["rabZy"].ToString()!="")
                    {
                        model.RabZy = bool.Parse(row["rabZy"].ToString());
                    }
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity . ReturnReceiptEntity DataRowToModel ( DataRow row )
        {
            FishEntity . ReturnReceiptEntity model = new FishEntity . ReturnReceiptEntity ( );
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
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
                if ( row [ "codeNumContract" ] != null )
                {
                    model . codeNumContract = row [ "codeNumContract" ] . ToString ( );
                }
                if (row["duanxuan"]!=null)
                {
                    model.duanxuan = row["duanxuan"].ToString();
                }
                if ( row [ "returnParty" ] != null )
                {
                    model . returnParty = row [ "returnParty" ] . ToString ( );
                }
                if ( row [ "receive" ] != null )
                {
                    model . receive = row [ "receive" ] . ToString ( );
                }
                if ( row [ "signDate" ] != null && row [ "signDate" ] . ToString ( ) != "" )
                {
                    model . signDate = DateTime . Parse ( row [ "signDate" ] . ToString ( ) );
                }
                if ( row [ "varieties" ] != null )
                {
                    model . varieties = row [ "varieties" ] . ToString ( );
                }
                if ( row [ "inputDate" ] != null && row [ "inputDate" ] . ToString ( ) != "" )
                {
                    model . inputDate = DateTime . Parse ( row [ "inputDate" ] . ToString ( ) );
                }
                if ( row [ "returnPartyJ" ] != null )
                {
                    model . returnPartyJ = row [ "returnPartyJ" ] . ToString ( );
                }
                if ( row [ "receiveJ" ] != null )
                {
                    model . receiveJ = row [ "receiveJ" ] . ToString ( );
                }
                if ( row [ "proName" ] != null )
                {
                    model . proName = row [ "proName" ] . ToString ( );
                }
                if ( row [ "speci" ] != null )
                {
                    model . speci = row [ "speci" ] . ToString ( );
                }
                if ( row [ "tons" ] != null && row [ "tons" ] . ToString ( ) != "" )
                {
                    model . tons = decimal . Parse ( row [ "tons" ] . ToString ( ) );
                }
                if (row["ShipmentsTons"] != null && row["ShipmentsTons"].ToString() != "")
                {
                    model.ShipmentsTons = decimal.Parse(row["ShipmentsTons"].ToString());
                }
                
                if (row["LiNumber"]!=null&&row["LiNumber"].ToString()!="")
                {
                    model.LiNumber = decimal.Parse(row["LiNumber"].ToString());
                }
                if ( row [ "price" ] != null && row [ "price" ] . ToString ( ) != "" )
                {
                    model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                }
                if ( row [ "money" ] != null && row [ "money" ] . ToString ( ) != "" )
                {
                    model . money = decimal . Parse ( row [ "money" ] . ToString ( ) );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "deliAdd" ] != null )
                {
                    model . deliAdd = row [ "deliAdd" ] . ToString ( );
                }
                if ( row [ "fishId" ] != null )
                {
                    model . fishId = row [ "fishId" ] . ToString ( );
                }
                if ( row [ "freight" ] != null && row [ "freight" ] . ToString ( ) != "" )
                {
                    model . freight = decimal . Parse ( row [ "freight" ] . ToString ( ) );
                }
                if ( row [ "cost" ] != null && row [ "cost" ] . ToString ( ) != "" )
                {
                    model . cost = decimal . Parse ( row [ "cost" ] . ToString ( ) );
                }
                if ( row [ "loss" ] != null && row [ "loss" ] . ToString ( ) != "" )
                {
                    model . loss = decimal . Parse ( row [ "loss" ] . ToString ( ) );
                }
                if ( row [ "condb" ] != null )
                {
                    model . condb = row [ "condb" ] . ToString ( );
                }
                if ( row [ "conza" ] != null )
                {
                    model . conza = row [ "conza" ] . ToString ( );
                }
                if ( row [ "cons" ] != null )
                {
                    model . cons = row [ "cons" ] . ToString ( );
                }
                if ( row [ "contvn" ] != null )
                {
                    model . contvn = row [ "contvn" ] . ToString ( );
                }
                if ( row [ "conhf" ] != null )
                {
                    model . conhf = row [ "conhf" ] . ToString ( );
                }
                if ( row [ "consf" ] != null )
                {
                    model . consf = row [ "consf" ] . ToString ( );
                }
                if ( row [ "conshy" ] != null )
                {
                    model . conshy = row [ "conshy" ] . ToString ( );
                }
                if ( row [ "conzf" ] != null )
                {
                    model . conzf = row [ "conzf" ] . ToString ( );
                }
                if ( row [ "returnGoodsAdd" ] != null )
                {
                    model . returnGoodsAdd = row [ "returnGoodsAdd" ] . ToString ( );
                }
                if ( row [ "remark" ] != null )
                {
                    model . remark = row [ "remark" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT code FROM t_returnreceipt" );

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
            strSql . AppendFormat ( "select count(1) from t_returnreceipt where code='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }
        /// <summary>
        /// 新增带入数据
        /// </summary>
        /// <param name="getname"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity getTHD(string getname)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.Numbering,a.code,a.demand,a.demandId,a.DemandAbbreviation,a.supplier,a.supplierId,a.SupplierAbbreviation,b.product_id,b.Funit,b.Country,b.pp,b.productname,b.db,b.za,b.sz,b.tvn,b.hf,b.sf,b.shy,b.zf,b.unitprice,a.delivery,a.rabZy,a.rabZz FROM	t_salesorder a INNER JOIN t_happening b ON a.Numbering = b.NumberingOne ");
            strSql.Append("where a.Numbering= '" + getname + "'");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Numbering"] != null && row["Numbering"].ToString() != "")
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                else
                {
                    return null;
                }
                if (row["CODE"] != null && row["CODE"].ToString() != "")
                {
                    model.code = row["CODE"].ToString();
                }
                else
                {
                    return null;
                }
                if (row["Funit"]!=null)
                {
                    model.Funit = row["Funit"].ToString();
                }
                if (row["rabZz"] != null)
                {
                    model.RabZz =bool.Parse( row["rabZz"].ToString());
                }
                if (row["rabZy"] != null)
                {
                    model.RabZy = bool.Parse(row["rabZy"].ToString());
                }
                if (row["demand"] != null && row["demand"].ToString() != "")
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["demandId"] != null)
                {
                    model.demandId = row["demandId"].ToString();
                }
                if (row["DemandAbbreviation"] != null)
                {
                    model.DemandAbbreviation = row["DemandAbbreviation"].ToString();
                }
                if (row["supplier"] != null && row["supplier"].ToString() != "")
                {
                    model.supplier = row["supplier"].ToString();
                }
                if (row["supplierId"] != null)
                {
                    model.supplierId = row["supplierId"].ToString();
                }
                if (row["SupplierAbbreviation"] != null )
                {
                    model.SupplierAbbreviation = row["SupplierAbbreviation"].ToString();
                }
                if (row["product_id"] != null)
                {
                    model.Product_id = row["product_id"].ToString();
                }
                if (row["Country"] != null)
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["pp"] != null)
                {
                    model.pp = row["pp"].ToString();
                }
                if (row["productname"]!=null)
                {
                    model.Productname = row["productname"].ToString();
                }
                if (row["db"] != null)
                {
                    model.Db = row["db"].ToString();
                }
                if (row["za"] != null)
                {
                    model.Za = row["za"].ToString();
                }
                if (row["sz"] != null)
                {
                    model.Sz = row["sz"].ToString();
                }
                if (row["tvn"] != null)
                {
                    model.Tvn = row["tvn"].ToString();
                }
                if (row["hf"] != null)
                {
                    model.Hf = row["hf"].ToString();
                }
                if (row["sf"] != null)
                {
                    model.Sf = row["sf"].ToString();
                }
                if (row["shy"] != null)
                {
                    model.Shy = row["shy"].ToString();
                }
                if (row["zf"] != null)
                {
                    model.Zf = row["zf"].ToString();
                }
                if (row["unitprice"] != null)
                {
                    model.HeTongDanJia = row["unitprice"].ToString();
                }
                if (row["delivery"] != null)
                {
                    model.delivery = row["delivery"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        public FishEntity.OnepoundEntity getjingz(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(Competition)as Competition from t_poundsalone ");
            strSql.Append("where Numbering= '" + Numbering + "'");
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.OnepoundEntity model = new FishEntity.OnepoundEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row["Competition"] != null && row["Competition"].ToString() != "")
                {
                    model.Competition = row["Competition"].ToString();
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
