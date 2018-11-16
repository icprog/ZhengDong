using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class FinishedProListDao
    {
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "SELECT MAX(code) code FROM t_finishedprolist" );

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string codeNum = dt.Rows[0]["code"].ToString();
                if (string.IsNullOrEmpty(codeNum))
                    return System.DateTime.Now.Year + "P0001001";
                else
                {
                    if (codeNum.Substring(0, 4).Equals(DateTime.Now.Year.ToString()))
                    {
                        if (Convert.ToInt32(codeNum.Substring(10, 1)) == 0)
                            return codeNum.Substring(0, 8) + (Convert.ToInt32(codeNum.Substring(8, 4)) + 1000);
                        else
                            return codeNum.Substring(0, 8) + (Convert.ToInt32(codeNum.Substring(8, 4)) + 100);
                    }
                    else
                        return System.DateTime.Now.Year + "P0001001";
                }
            }
            else
                return System.DateTime.Now.Year + "P0001001";
        }
        public string getFishId()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select max(fishId) fishId from t_finishedprolist");

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string fishId = dt.Rows[0]["fishId"].ToString();
                if (string.IsNullOrEmpty(fishId))
                    return "CP" + DateTime.Now.ToString("yyyyMMdd") + "001";
                else
                {
                    if (fishId.Substring(2, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                        return "CP" + (Convert.ToInt64(fishId.Substring(2, 11)) + 1).ToString();
                    else
                        return "CP" + DateTime.Now.ToString("yyyyMMdd") + "001";
                }
            }
            else
                return "CP" + DateTime.Now.ToString("yyyyMMdd") + "001";
        }
        /// <summary>
        /// 生成合同单号
        /// </summary>
        /// <returns></returns>
        public string getCkCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("SELECT MAX(CkCode) code FROM t_finishedprolist WHERE CkCode LIKE 'CP{0}%'", DateTime.Now.ToString("yyyyMMdd"));

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string code = dt.Rows[0]["code"].ToString();
                if (string.IsNullOrEmpty(code))
                    return "CP" + DateTime.Now.ToString("yyyyMMdd") + "0001";
                else
                    return "CP" + (Convert.ToInt64(code.Substring(2, code.Length - 2)) + 1).ToString();
            }
            else
                return "CP" + DateTime.Now.ToString("yyyyMMdd") + "0001";

        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_finishedprolist where code='{0}'" ,code );

            int row = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . FinishedProListEntity model )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_finishedprolist set " );
            strSql . Append ( "plCode=@plCode," );
            strSql . Append ( "date=@date," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "fishId=@fishId," );
            strSql . Append ( "price=@price," );
            strSql . Append ( "qualitySpe=@qualitySpe," );
            strSql . Append ( "goods=@goods," );
            strSql . Append ( "tons=@tons," );
            strSql.Append("Number=@Number,");
            strSql.Append("zidingyi=@zidingyi,");
            strSql . Append ( "protein=@protein," );
            strSql.Append("FFA=@FFA,");
            strSql . Append ( "tvn=@tvn," );
            strSql.Append("CkCode=@CkCode,");
            strSql . Append ( "salt=@salt," );
            strSql . Append ( "acid=@acid," );
            strSql . Append ( "ash=@ash," );
            strSql . Append ( "histamine=@histamine," );
            strSql . Append ( "las=@las," );
            strSql . Append ( "das=@das," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "zf=@zf," );
            strSql.Append("ajs=@ajs,");
            strSql . Append ( "shipname=@shipname," );
            strSql . Append ( "zjh=@zjh," );
            strSql.Append("saleCompany=@saleCompany,");
            strSql.Append("saleLinkman=@saleLinkman,");
            strSql . Append ( "billName=@billName " );
            strSql . Append ( " where code=@code " );
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@plCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@date", MySqlDbType.Date),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@goods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tons", MySqlDbType.Decimal,10),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@acid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@las", MySqlDbType.VarChar,45),
                    new MySqlParameter("@das", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@zf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipname", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zjh", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@CkCode",MySqlDbType.VarChar,60),
                    new MySqlParameter("@FFA",MySqlDbType.VarChar,45),
                    new MySqlParameter("@ajs",MySqlDbType.VarChar,10),
                    new MySqlParameter("@Number",MySqlDbType.VarChar,45),
                    new MySqlParameter("@zidingyi",MySqlDbType.VarChar,45),
                    new MySqlParameter("@saleCompany",MySqlDbType.VarChar,45),
                    new MySqlParameter("@saleLinkman",MySqlDbType.VarChar,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . plCode;
            parameters [ 2 ] . Value = model . date;
            parameters [ 3 ] . Value = model . country;
            parameters [ 4 ] . Value = model . brand;
            parameters [ 5 ] . Value = model . fishId;
            parameters [ 6 ] . Value = model . price;
            parameters [ 7 ] . Value = model . qualitySpe;
            parameters [ 8 ] . Value = model . goods;
            parameters [ 9 ] . Value = model . tons;
            parameters [ 10 ] . Value = model . protein;
            parameters [ 11 ] . Value = model . tvn;
            parameters [ 12 ] . Value = model . salt;
            parameters [ 13 ] . Value = model . acid;
            parameters [ 14 ] . Value = model . ash;
            parameters [ 15 ] . Value = model . histamine;
            parameters [ 16 ] . Value = model . las;
            parameters [ 17 ] . Value = model . das;
            parameters [ 18 ] . Value = model . remark;
            parameters [ 19 ] . Value = model . zf;
            parameters [ 20 ] . Value = model . Shipname;
            parameters [ 21 ] . Value = model . Zjh;
            parameters [ 22 ] . Value = model . BillName;
            parameters[23].Value = model.CkCode;
            parameters[24].Value = model.FFA;
            parameters[25].Value = model.Ajs;
            parameters[26].Value = model.Number;
            parameters[27].Value = model.Zidingyi;
            parameters[28].Value = model.saleCompany;
            parameters[29].Value = model.saleLinkman;
            SQLString . Add ( strSql ,parameters );

            if ( !string . IsNullOrEmpty ( model . fishId ) )
            {
                string xsCode = Exists_xs ( model . fishId );
                if ( !string . IsNullOrEmpty ( xsCode ) )
                {
                    edit_xs ( SQLString ,strSql ,model ,xsCode );
                }
            }
            bool xid = MySqlHelper.ExecuteSqlTran(SQLString);
            if (xid)
            {
                int idx = Exists_id(model.fishId);
                if (idx>1)
                {
                    if (add_Update(model)==true)
                    {
                        if (UpdateEx(model, idx)==true)
                        {
                            return true;
                        }else return false;

                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . FinishedProListEntity model,string name )
        {
            Hashtable SQLString = new Hashtable ( );
            Hashtable SQLStringone = new Hashtable();
            SQLString =ReviewInfo . getSQLString ( name ,model . code ,string . Empty ,SQLString);
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_finishedprolist(" );
            strSql . Append ("code,plCode,date,country,brand,fishId,price,qualitySpe,goods,tons,protein,tvn,salt,acid,ash,histamine,las,das,remark,zf,shipname,zjh,billName,CkCode,FFA,ajs,Number,zidingyi,saleCompany,saleLinkman)");
            strSql . Append ( " values (" );
            strSql . Append ("@code,@plCode,@date,@country,@brand,@fishId,@price,@qualitySpe,@goods,@tons,@protein,@tvn,@salt,@acid,@ash,@histamine,@las,@das,@remark,@zf,@shipname,@zjh,@billName,@CkCode,@FFA,@ajs,@Number,@zidingyi,@saleCompany,@saleLinkman)");
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@plCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@date", MySqlDbType.Date),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@price", MySqlDbType.Decimal),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@goods", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tons", MySqlDbType.Decimal,10),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@salt", MySqlDbType.VarChar,45),
                    new MySqlParameter("@acid", MySqlDbType.VarChar,45),
                    new MySqlParameter("@ash", MySqlDbType.VarChar,45),
                    new MySqlParameter("@histamine", MySqlDbType.VarChar,45),
                    new MySqlParameter("@las", MySqlDbType.VarChar,45),
                    new MySqlParameter("@das", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@zf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shipname", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zjh", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@CkCode",MySqlDbType.VarChar,60),
                    new MySqlParameter("@FFA",MySqlDbType.VarChar,45),
                    new MySqlParameter("@ajs",MySqlDbType.VarChar,10),
                    new MySqlParameter("@Number",MySqlDbType.VarChar,45),
                    new MySqlParameter("@zidingyi",MySqlDbType.VarChar,45),
                    new MySqlParameter("@saleCompany",MySqlDbType.VarChar,45),
                    new MySqlParameter("@saleLinkman",MySqlDbType.VarChar,45)
            };
            parameters [ 0] . Value = model . code;
            parameters [ 1 ] . Value = model . plCode;
            parameters [ 2 ] . Value = model . date;
            parameters [ 3 ] . Value = model . country;
            parameters [ 4 ] . Value = model . brand;
            parameters [ 5 ] . Value = model . fishId;
            parameters [ 6 ] . Value = model . price;
            parameters [ 7 ] . Value = model . qualitySpe;
            parameters [ 8 ] . Value = model . goods;
            parameters [ 9 ] . Value = model . tons;
            parameters [ 10 ] . Value = model . protein;
            parameters [ 11 ] . Value = model . tvn;
            parameters [ 12 ] . Value = model . salt;
            parameters [ 13 ] . Value = model . acid;
            parameters [ 14 ] . Value = model . ash;
            parameters [ 15 ] . Value = model . histamine;
            parameters [ 16 ] . Value = model . las;
            parameters [ 17 ] . Value = model . das;
            parameters [ 18 ] . Value = model . remark;
            parameters [ 19 ] . Value = model . zf;
            parameters [ 20 ] . Value = model . Shipname;
            parameters [ 21 ] . Value = model . Zjh;
            parameters [ 22 ] . Value = model . BillName;
            parameters[23].Value = model.CkCode;
            parameters[24].Value = model.FFA;
            parameters[25].Value = model.Ajs;
            parameters[26].Value = model.Number;
            parameters[27].Value=model.Zidingyi;
            parameters[28].Value = model.saleCompany;
            parameters[29].Value = model.saleLinkman;
            SQLString . Add ( strSql ,parameters );
            if ( !string . IsNullOrEmpty ( model . fishId ) )
            {
                string xsCode = Exists_xs ( model . fishId );
                if ( !string . IsNullOrEmpty ( xsCode ) )
                {
                    edit_xs ( SQLString ,strSql ,model ,xsCode );
                }
            }
            bool xid= MySqlHelper.ExecuteSqlTran(SQLString);
            if (xid)
            {
                if (Exists_fish(model.fishId) == false)
                {
                    int one = add_fish(model);
                    if (one > 1)
                    {
                        if (AddEx(model, one))return true ;
                       else return false;
                    }
                    else return false;
                }
                else return false;
            }
            else return false;
        }
        //
        public bool AddEx(FishEntity.FinishedProListEntity model, int one)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_productex(finishedtime,finisheWeight,finisheNumber,id,saletrader,saleLinkman)");
            strSql.Append(" values (@finishedtime,@finisheWeight,@finisheNumber,@id,@saletrader,@saleLinkman)");
            MySqlParameter[] parameters = {
                new MySqlParameter("@finishedtime",MySqlDbType.VarChar,45),
                new MySqlParameter("@finisheWeight",MySqlDbType.Decimal,45),
                new MySqlParameter("@finisheNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
                new MySqlParameter("@saletrader",MySqlDbType.VarChar,45),
                new MySqlParameter("@saleLinkman",MySqlDbType.VarChar,45),
            };
            parameters[0].Value = model.date;
            if (model.tons!=null)
            {
                parameters[1].Value = model.tons;
            }
            else
            {
                parameters[1].Value = 0;
            }
            parameters[2].Value = model.Number;
            parameters[3].Value = one;
            parameters[4].Value = model.saleCompany;
            parameters[5].Value = model.saleLinkman;
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool UpdateEx(FishEntity.FinishedProListEntity model, int one)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_productex set ");
            strSql.Append("finishedtime=@finishedtime,");
            strSql.Append("saletrader=@saletrader,");
            strSql.Append("saleLinkman=@saleLinkman,");
            strSql.Append("finisheWeight=@finisheWeight,");
            strSql.Append("finisheNumber=@finisheNumber ");
            strSql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                new MySqlParameter("@finishedtime",MySqlDbType.VarChar,45),
                new MySqlParameter("@saletrader",MySqlDbType.VarChar,45),
                new MySqlParameter("@finisheNumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int32,11),
                new MySqlParameter("@saleLinkman",MySqlDbType.VarChar,45),
                new MySqlParameter("@finisheWeight",MySqlDbType.Decimal,45),
            };
            parameters[0].Value = model.date;
            parameters[1].Value = model.saleCompany;
            parameters[2].Value = model.Number;
            parameters[3].Value = one;
            parameters[4].Value = model.saleLinkman;
            if (model.tons!=null&& model.tons.ToString()!="")
            {
                parameters[5].Value = model.tons;
            }
            else
            {
                parameters[5].Value = 0;
            }
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        /// <summary>
        /// 销售申请单是否读取此鱼粉ID
        /// </summary>
        /// <returns></returns>
        string Exists_xs ( string fishId )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select b.NumberingOne from t_CustomStandardTable a inner join t_happening b on a.code=b.codeNumZdi and a.fishId=b.product_id" );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
                return dt . Rows [ 0 ] [ "NumberingOne" ] . ToString ( );
            else
                return string . Empty;
        }
        int add_fish(FishEntity.FinishedProListEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_product(code,specification,nature,brand,domestic_protein,domestic_tvn,domestic_ffa,domestic_sandsalt,domestic_sour,domestic_amine,domestic_fat,domestic_graypart,domestic_lysine,domestic_methionine,domestic_aminototal,remark,createman,modifyman,state5,isdelete5)");
            strSql.Append("values(@code,@specification,@nature,@brand,@domestic_protein,@domestic_tvn,@domestic_ffa,@domestic_sandsalt,@domestic_sour,@domestic_amine,@domestic_fat,@domestic_graypart,@domestic_lysine,@domestic_methionine,@domestic_aminototal,@remark,@createman,@modifyman,@state5,@isdelete5);select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@specification",MySqlDbType.VarChar,45),
                new MySqlParameter("@nature",MySqlDbType.VarChar,45),
                new MySqlParameter("@brand",MySqlDbType.VarChar,45),
                new MySqlParameter("@domestic_protein",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_tvn",MySqlDbType.Decimal,8),
                new MySqlParameter("@domestic_ffa",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_sandsalt",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_sour",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_amine",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_fat",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_graypart",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_lysine",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_methionine",MySqlDbType.Decimal,6),
                new MySqlParameter("@domestic_aminototal",MySqlDbType.Decimal,6),
                new MySqlParameter("@remark",MySqlDbType.VarChar,500),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@state5",MySqlDbType.VarChar,45),
                new MySqlParameter("@isdelete5",MySqlDbType.Int16,4),
            };
            parameters[0].Value = model.fishId;
            parameters[1].Value = model.qualitySpe;
            parameters[2].Value = model.country;
            parameters[3].Value = model.brand;

            if (model.protein != null && model.protein != "")
            {parameters[4].Value = model.protein;}else {parameters[4].Value = 0;}
            if (model.tvn != null && model.tvn != "")
            { parameters[5].Value = model.tvn; }
            else { parameters[5].Value = 0; }
            if (model.FFA != null && model.FFA != "")
            { parameters[6].Value = model.FFA; }
            else { parameters[6].Value = 0; }
            if (model.salt != null && model.salt != "")
            {
                parameters[7].Value = model.salt;
            }
            else { parameters[7].Value = 0; }

            if (model.acid != null && model.acid != "")
            {
                parameters[8].Value = model.acid;
            }
            else { parameters[8].Value = 0; }
            if (model.histamine != null && model.histamine != "")
            {
                parameters[9].Value = model.histamine;
            }
            else { parameters[9].Value = 0; }
            if (model.zf != null && model.zf != "")
            {
                parameters[10].Value = model.zf;
            }
            else { parameters[10].Value = 0; }

            if (model.ash != null && model.ash != "")
            {
                parameters[11].Value = model.ash;
            }
            else { parameters[11].Value = 0; }

            if (model.las != null && model.las != "")
            {
                parameters[12].Value = model.las;
            }
            else { parameters[12].Value = 0; }
            if (model.das != null && model.das != "")
            {
                parameters[13].Value = model.das;
            }
            else { parameters[13].Value = 0; }
            if (model.Ajs != null && model.Ajs != "")
            {
                parameters[14].Value = model.Ajs;
            }
            else { parameters[14].Value = 0; }
                parameters[15].Value = model.remark;
            parameters[16].Value = FishEntity.Variable.User.username;
            parameters[17].Value = FishEntity.Variable.User.username;
            parameters[18].Value = "6";
            parameters[19].Value = 1;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        bool add_Update(FishEntity.FinishedProListEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_product set ");
            strSql.Append("specification=@specification,");
            strSql.Append("nature=@nature,");
            strSql.Append("brand=@brand ");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@specification",MySqlDbType.VarChar,45),
                new MySqlParameter("@nature",MySqlDbType.VarChar,45),
                new MySqlParameter("@brand",MySqlDbType.VarChar,45),
            };
            parameters[0].Value = model.fishId;
            parameters[1].Value = model.qualitySpe;
            parameters[2].Value = model.country;
            parameters[3].Value = model.brand;
            
            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 修改销售申请单的数据
        /// </summary>
        void edit_xs ( Hashtable SQLString ,StringBuilder strSql ,FishEntity . FinishedProListEntity model,string code )
        {
            strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE t_happening SET " );
            strSql.Append("ffa=@ffa,");
            strSql . Append ( "productname=@productname," );
            strSql . Append ( "Variety=@Variety," );
            strSql . Append ( "Quantity=@Quantity," );
            strSql . Append ( "unitprice=@unitprice," );
            strSql . Append ( "db=@db," );
            strSql . Append ( "cdb=@db," );
            strSql . Append ( "tvnOne=@tvn," );
            strSql . Append ( "hf=@hf," );
            strSql.Append("tvn=@tvn,");
            strSql.Append("za=@za,");
            strSql.Append("zf=@zf,");
            strSql . Append ( "cm=@cm," );
            strSql . Append ( "zjh=@zjh," );
            strSql . Append ( "tdh=@tdh," );
            strSql . Append ( "pp=@pp," );
            strSql.Append("Country=@Country ");
            strSql . Append ( "WHERE product_id=@product_id AND NumberingOne=@NumberingOne" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@ffa",MySqlDbType.VarChar,45),
                    new MySqlParameter ( "@productname" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@Variety" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@Quantity" ,MySqlDbType . Decimal ,45 ),
                    new MySqlParameter ( "@unitprice" ,MySqlDbType . Decimal ,45 ),
                    new MySqlParameter ( "@db" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter( "@hf",MySqlDbType.VarChar,45),
                    new MySqlParameter ( "@tvn" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@za" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@zf" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@cm" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@zjh" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@tdh" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@pp" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@Country" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@product_id" ,MySqlDbType . VarChar ,45 ),
                    new MySqlParameter ( "@NumberingOne" ,MySqlDbType . VarChar ,45 ),
            };
            parameters[0].Value = model.FFA;
            parameters[1].Value = model.goods;
            parameters[2].Value = model.qualitySpe;
            parameters[3].Value = model.tons;
            parameters[4].Value = model.price;
            parameters[5].Value = model.protein;
            parameters[6].Value = model.ash;
            parameters[7].Value = model.tvn;
            parameters[8].Value = model.histamine;
            parameters[9].Value = model.zf;
            parameters[10].Value = model.Shipname;
            parameters[11].Value = model.Zjh;
            parameters[12].Value = model.BillName;
            parameters[13].Value = model.brand;
            parameters[14].Value = model.country;
            parameters[15].Value = model.fishId;
            parameters[16].Value = code;
            SQLString . Add ( strSql ,parameters );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public FishEntity . FinishedProListEntity getModel ( string code )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ("select id,code,plCode,date,country,brand,price,fishId,qualitySpe,goods,tons,Number,zidingyi,protein,ffa,tvn,salt,acid,ash,histamine,las,das,remark,zf,billName,saleCompany,saleLinkman,zjh,shipname,CkCode,ajs from t_finishedprolist where {0}", code );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null && dt . Rows . Count > 0 )
            {
                return getModel ( dt . Rows [ 0 ] );
            }
            else
                return null;
        }
        public DataTable getTableView(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT a.code,a.productionDate,b.fishId,b.codeNum,b.codeNumContract,b.qualitySpe,b.country,b.brand,b.goods,b.tons,b.protein,b.tvn,b.salt,b.acid,b.ash,b.histamine,b.las,b.das,b.price,b.cost,b.isSum,b.rkCode from t_batchsheet a INNER JOIN t_batchsheets b on a.code=b.code where issum=1 and a.code='"+code+"'");
            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        public FishEntity . FinishedProListEntity getModel ( DataRow row )
        {
            FishEntity . FinishedProListEntity model = new FishEntity . FinishedProListEntity ( );
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
                if (row["saleCompany"] != null)
                {
                    model.saleCompany = row["saleCompany"].ToString();
                }
                if (row["saleLinkman"] != null)
                {
                    model.saleLinkman = row["saleLinkman"].ToString();
                }
                if (row["CkCode"]!=null)
                {
                    model.CkCode = row["CkCode"].ToString();
                }
                if (row["Number"]!=null)
                {
                    model.Number = row["Number"].ToString();
                }
                if (row["zidingyi"] != null)
                {
                    model.Zidingyi = row["zidingyi"].ToString();
                }
                if (row["ajs"]!=null)
                {
                    model.Ajs=row["ajs"].ToString();
                }
                if ( row [ "plCode" ] != null )
                {
                    model . plCode = row [ "plCode" ] . ToString ( );
                }
                if ( row [ "date" ] != null && row [ "date" ] . ToString ( ) != "" )
                {
                    model . date = DateTime . Parse ( row [ "date" ] . ToString ( ) );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "price" ] != null && row["price"].ToString()!="" )
                {
                    model . price = decimal . Parse ( row [ "price" ] . ToString ( ) );
                }
                if ( row [ "fishId" ] != null )
                {
                    model . fishId = row [ "fishId" ] . ToString ( );
                }
                if ( row [ "qualitySpe" ] != null )
                {
                    model . qualitySpe = row [ "qualitySpe" ] . ToString ( );
                }
                if ( row [ "goods" ] != null )
                {
                    model . goods = row [ "goods" ] . ToString ( );
                }
                if ( row [ "tons" ] != null && row [ "tons" ] . ToString ( ) != "" )
                {
                    model . tons = decimal . Parse ( row [ "tons" ] . ToString ( ) );
                }
                if ( row [ "protein" ] != null )
                {
                    model . protein = row [ "protein" ] . ToString ( );
                }
                if (row["ffa"]!=null)
                {
                    model.FFA = row["ffa"].ToString();
                }
                if ( row [ "tvn" ] != null )
                {
                    model . tvn = row [ "tvn" ] . ToString ( );
                }
                if ( row [ "salt" ] != null )
                {
                    model . salt = row [ "salt" ] . ToString ( );
                }
                if ( row [ "acid" ] != null )
                {
                    model . acid = row [ "acid" ] . ToString ( );
                }
                if ( row [ "ash" ] != null )
                {
                    model . ash = row [ "ash" ] . ToString ( );
                }
                if ( row [ "histamine" ] != null )
                {
                    model . histamine = row [ "histamine" ] . ToString ( );
                }
                if ( row [ "las" ] != null )
                {
                    model . las = row [ "las" ] . ToString ( );
                }
                if ( row [ "das" ] != null )
                {
                    model . das = row [ "das" ] . ToString ( );
                }
                if ( row [ "remark" ] != null )
                {
                    model . remark = row [ "remark" ] . ToString ( );
                }
                if ( row [ "zf" ] != null )
                {
                    model . zf = row [ "zf" ] . ToString ( );
                }
                if ( row [ "shipname" ] != null )
                {
                    model . Shipname = row [ "shipname" ] . ToString ( );
                }
                if ( row [ "zjh" ] != null )
                {
                    model . Zjh = row [ "zjh" ] . ToString ( );
                }
                if ( row [ "billName" ] != null )
                {
                    model . BillName = row [ "billName" ] . ToString ( );
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
            strSql . Append ( "select code from t_finishedprolist" );

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
            strSql . AppendFormat ( "select count(1) from t_finishedprolist where code='{0}'" ,code );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }
        public bool Exists_fish(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_product where code='{0}'", code);

            return MySqlHelper.Exists(strSql.ToString());
        }
        public int Exists_id(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select id from t_product where code='{0}'", code);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return int.Parse(dt.Rows[0]["id"].ToString());
            }
            else
            {
                return 0;
            }
        }
        public bool Exists_fishId(string fishId) {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_finishedprolist where fishId='{0}'", fishId);

            return MySqlHelper.Exists(strSql.ToString());
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT code,CkCode,plCode,date,country,brand,fishId,price,qualitySpe,goods,tons,ffa,protein,tvn,salt,acid,ash,histamine,las,das,remark,zf,billName,saleCompany,saleLinkman,zjh,shipname,id,CkCode from t_finishedprolist ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
    }
}
