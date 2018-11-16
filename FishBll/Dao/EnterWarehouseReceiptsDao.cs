using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class EnterWarehouseReceiptsDao
    {
        public bool Exists(string code)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_enterwarehousereceipts");
            strSql.Append(" where code=@code ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45)};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        public int Add(FishEntity.EnterWarehouseReceipts model)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_enterwarehousereceipts(" );
            strSql . Append ( "code,fishId,codeNum,codeNumContract,deliverybills,proName,numOfPack,qualitySpe,TVN,sand,TEL,TO,enUntil,country,number,location,protein,fat,water,fax,anti,shipno,brand,downDate,locationDis,za,hf,shy,remark,createtime,createman,modifyman,modifytime,height))" );
            strSql . Append ( " values (" );
            strSql . Append ( "@code,@fishId,@codeNum,@codeNumContract,@deliverybills,@proName,@numOfPack,@qualitySpe,@TVN,@sand,@TEL,@TO,@enUntil,@country,@number,@location,@protein,@fat,@water,@fax,@anti,@shipno,@brand,@downDate,@locationDis,@za,@hf,@shy,@remark,@createtime,@createman,@modifyman,@modifytime,@height);" );
            strSql . Append ( "select LAST_INSERT_ID();" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,50),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@deliverybills", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@numOfPack", MySqlDbType.Int32,11),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@TVN", MySqlDbType.VarChar,50),
                    new MySqlParameter("@sand", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TEL", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TO", MySqlDbType.VarChar,50),
                    new MySqlParameter("@enUntil", MySqlDbType.VarChar,50),
                    new MySqlParameter("@country", MySqlDbType.VarChar,50),
                    new MySqlParameter("@number", MySqlDbType.Int32,11),
                    new MySqlParameter("@location", MySqlDbType.VarChar,200),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,50),
                    new MySqlParameter("@fat", MySqlDbType.VarChar,50),
                    new MySqlParameter("@water", MySqlDbType.VarChar,50),
                    new MySqlParameter("@fax", MySqlDbType.VarChar,50),
                    new MySqlParameter("@anti", MySqlDbType.VarChar,50),
                    new MySqlParameter("@shipno", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,50),
                    new MySqlParameter("@downDate", MySqlDbType.Date),
                    new MySqlParameter("@locationDis", MySqlDbType.VarChar,50),
                    new MySqlParameter("@za", MySqlDbType.VarChar,50),
                    new MySqlParameter("@hf", MySqlDbType.VarChar,50),
                    new MySqlParameter("@shy", MySqlDbType.VarChar,50),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,50),
                    new MySqlParameter("@createtime", MySqlDbType.Timestamp),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
                    new MySqlParameter("@height", MySqlDbType.Decimal)
                                          };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . codeNum;
            parameters [ 3 ] . Value = model . codeNumContract;
            parameters [ 4 ] . Value = model . deliverybills;
            parameters [ 5 ] . Value = model . proName;
            parameters [ 6 ] . Value = model . numOfPack;
            parameters [ 7 ] . Value = model . qualitySpe;
            parameters [ 8 ] . Value = model . TVN;
            parameters [ 9 ] . Value = model . sand;
            parameters [ 10 ] . Value = model . TEL;
            parameters [ 11 ] . Value = model . TO;
            parameters [ 12 ] . Value = model . enUntil;
            parameters [ 13 ] . Value = model . country;
            parameters [ 14 ] . Value = model . number;
            parameters [ 15 ] . Value = model . location;
            parameters [ 16 ] . Value = model . protein;
            parameters [ 17 ] . Value = model . fat;
            parameters [ 18 ] . Value = model . water;
            parameters [ 19 ] . Value = model . fax;
            parameters [ 20 ] . Value = model . anti;
            parameters [ 21 ] . Value = model . shipno;
            parameters [ 22 ] . Value = model . brand;
            parameters [ 23 ] . Value = model . downDate;
            parameters [ 24 ] . Value = model . locationDis;
            parameters [ 25 ] . Value = model . za;
            parameters [ 26 ] . Value = model . hf;
            parameters [ 27 ] . Value = model . shy;
            parameters [ 28 ] . Value = model . remark;
            parameters [ 29 ] . Value = model . createtime;
            parameters [ 30 ] . Value = model . createman;
            parameters [ 31 ] . Value = model . modifyman;
            parameters [ 32 ] . Value = model . modifytime;
            parameters [ 33 ] . Value = model . height;

            int id = MySqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameters );
            return id;
        }
        public bool Update(FishEntity.EnterWarehouseReceipts model)
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_enterwarehousereceipts set " );
            strSql . Append ( "code=@code," );
            strSql . Append ( "fishId=@fishId," );
            strSql . Append ( "codeNum=@codeNum," );
            strSql . Append ( "codeNumContract=@codeNumContract," );
            strSql . Append ( "deliverybills=@deliverybills," );
            strSql . Append ( "proName=@proName," );
            strSql . Append ( "numOfPack=@numOfPack," );
            strSql . Append ( "qualitySpe=@qualitySpe," );
            strSql . Append ( "TVN=@TVN," );
            strSql . Append ( "sand=@sand," );
            strSql . Append ( "TEL=@TEL," );
            strSql . Append ( "TO=@TO," );
            strSql . Append ( "enUntil=@enUntil," );
            strSql . Append ( "country=@country," );
            strSql . Append ( "number=@number," );
            strSql . Append ( "location=@location," );
            strSql . Append ( "protein=@protein," );
            strSql . Append ( "fat=@fat," );
            strSql . Append ( "water=@water," );
            strSql . Append ( "fax=@fax," );
            strSql . Append ( "anti=@anti," );
            strSql . Append ( "shipno=@shipno," );
            strSql . Append ( "brand=@brand," );
            strSql . Append ( "downDate=@downDate," );
            strSql . Append ( "locationDis=@locationDis," );
            strSql . Append ( "za=@za," );
            strSql . Append ( "hf=@hf," );
            strSql . Append ( "shy=@shy," );
            strSql . Append ( "remark=@remark," );
            strSql . Append ( "height=@height," );
            strSql . Append ( "createman=@createman," );
            strSql . Append ( "modifyman=@modifyman " );
            strSql . Append ( " where id=@id" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,50),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@deliverybills", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,100),
                    new MySqlParameter("@numOfPack", MySqlDbType.Int32,11),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@TVN", MySqlDbType.VarChar,50),
                    new MySqlParameter("@sand", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TEL", MySqlDbType.VarChar,50),
                    new MySqlParameter("@TO", MySqlDbType.VarChar,50),
                    new MySqlParameter("@enUntil", MySqlDbType.VarChar,50),
                    new MySqlParameter("@country", MySqlDbType.VarChar,50),
                    new MySqlParameter("@number", MySqlDbType.Int32,11),
                    new MySqlParameter("@location", MySqlDbType.VarChar,200),
                    new MySqlParameter("@protein", MySqlDbType.VarChar,50),
                    new MySqlParameter("@fat", MySqlDbType.VarChar,50),
                    new MySqlParameter("@water", MySqlDbType.VarChar,50),
                    new MySqlParameter("@fax", MySqlDbType.VarChar,50),
                    new MySqlParameter("@anti", MySqlDbType.VarChar,50),
                    new MySqlParameter("@shipno", MySqlDbType.VarChar,45),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,50),
                    new MySqlParameter("@downDate", MySqlDbType.Date),
                    new MySqlParameter("@locationDis", MySqlDbType.VarChar,50),
                    new MySqlParameter("@za", MySqlDbType.VarChar,50),
                    new MySqlParameter("@hf", MySqlDbType.VarChar,50),
                    new MySqlParameter("@shy", MySqlDbType.VarChar,50),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,50),
                    new MySqlParameter("@createman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
                    new MySqlParameter("@height", MySqlDbType.Decimal,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . fishId;
            parameters [ 2 ] . Value = model . codeNum;
            parameters [ 3 ] . Value = model . codeNumContract;
            parameters [ 4 ] . Value = model . deliverybills;
            parameters [ 5 ] . Value = model . proName;
            parameters [ 6 ] . Value = model . numOfPack;
            parameters [ 7 ] . Value = model . qualitySpe;
            parameters [ 8 ] . Value = model . TVN;
            parameters [ 9 ] . Value = model . sand;
            parameters [ 10 ] . Value = model . TEL;
            parameters [ 11 ] . Value = model . TO;
            parameters [ 12 ] . Value = model . enUntil;
            parameters [ 13 ] . Value = model . country;
            parameters [ 14 ] . Value = model . number;
            parameters [ 15 ] . Value = model . location;
            parameters [ 16 ] . Value = model . protein;
            parameters [ 17 ] . Value = model . fat;
            parameters [ 18 ] . Value = model . water;
            parameters [ 19 ] . Value = model . fax;
            parameters [ 20 ] . Value = model . anti;
            parameters [ 21 ] . Value = model . shipno;
            parameters [ 22 ] . Value = model . brand;
            parameters [ 23 ] . Value = model . downDate;
            parameters [ 24 ] . Value = model . locationDis;
            parameters [ 25 ] . Value = model . za;
            parameters [ 26 ] . Value = model . hf;
            parameters [ 27 ] . Value = model . shy;
            parameters [ 28 ] . Value = model . remark;
            parameters [ 29 ] . Value = model . createman;
            parameters [ 30 ] . Value = model . modifyman;
            parameters [ 31 ] . Value = model . height;
            parameters [ 32 ] . Value = model . id;

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
        public List<FishEntity.EnterWarehouseReceipts> GetModelListVo(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append( "select * from t_enterwarehousereceipts " );
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.EnterWarehouseReceipts> modelList = new List<FishEntity.EnterWarehouseReceipts>();
            int rowsCount = ds.Tables[0].Rows.Count;
            FishEntity.EnterWarehouseReceipts model;
            for (int n = 0; n < rowsCount; n++)
            {
                DataRow row = ds.Tables[0].Rows[n];
                model = new FishEntity.EnterWarehouseReceipts();
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
                if ( row [ "codeNum" ] != null )
                {
                    model . codeNum = row [ "codeNum" ] . ToString ( );
                }
                if ( row [ "codeNumContract" ] != null )
                {
                    model . codeNumContract = row [ "codeNumContract" ] . ToString ( );
                }
                if ( row [ "deliverybills" ] != null )
                {
                    model . deliverybills = row [ "deliverybills" ] . ToString ( );
                }
                if ( row [ "proName" ] != null )
                {
                    model . proName = row [ "proName" ] . ToString ( );
                }
                if ( row [ "numOfPack" ] != null && row [ "numOfPack" ] . ToString ( ) != "" )
                {
                    model . numOfPack = int . Parse ( row [ "numOfPack" ] . ToString ( ) );
                }
                if ( row [ "qualitySpe" ] != null )
                {
                    model . qualitySpe = row [ "qualitySpe" ] . ToString ( );
                }
                if ( row [ "TVN" ] != null )
                {
                    model . TVN = row [ "TVN" ] . ToString ( );
                }
                if ( row [ "sand" ] != null )
                {
                    model . sand = row [ "sand" ] . ToString ( );
                }
                if ( row [ "TEL" ] != null )
                {
                    model . TEL = row [ "TEL" ] . ToString ( );
                }
                if ( row [ "TO" ] != null )
                {
                    model . TO = row [ "TO" ] . ToString ( );
                }
                if ( row [ "enUntil" ] != null )
                {
                    model . enUntil = row [ "enUntil" ] . ToString ( );
                }
                if ( row [ "country" ] != null )
                {
                    model . country = row [ "country" ] . ToString ( );
                }
                if ( row [ "number" ] != null && row [ "number" ] . ToString ( ) != "" )
                {
                    model . number = int . Parse ( row [ "number" ] . ToString ( ) );
                }
                if ( row [ "height" ] != null && row [ "height" ] . ToString ( ) != "" )
                {
                    model . height = decimal . Parse ( row [ "height" ] . ToString ( ) );
                }
                if ( row [ "location" ] != null )
                {
                    model . location = row [ "location" ] . ToString ( );
                }
                if ( row [ "protein" ] != null )
                {
                    model . protein = row [ "protein" ] . ToString ( );
                }
                if ( row [ "fat" ] != null )
                {
                    model . fat = row [ "fat" ] . ToString ( );
                }
                if ( row [ "water" ] != null )
                {
                    model . water = row [ "water" ] . ToString ( );
                }
                if ( row [ "fax" ] != null )
                {
                    model . fax = row [ "fax" ] . ToString ( );
                }
                if ( row [ "anti" ] != null )
                {
                    model . anti = row [ "anti" ] . ToString ( );
                }
                if ( row [ "shipno" ] != null )
                {
                    model . shipno = row [ "shipno" ] . ToString ( );
                }
                if ( row [ "brand" ] != null )
                {
                    model . brand = row [ "brand" ] . ToString ( );
                }
                if ( row [ "downDate" ] != null && row [ "downDate" ] . ToString ( ) != "" )
                {
                    model . downDate = DateTime . Parse ( row [ "downDate" ] . ToString ( ) );
                }
                if ( row [ "locationDis" ] != null )
                {
                    model . locationDis = row [ "locationDis" ] . ToString ( );
                }
                if ( row [ "za" ] != null )
                {
                    model . za = row [ "za" ] . ToString ( );
                }
                if ( row [ "hf" ] != null )
                {
                    model . hf = row [ "hf" ] . ToString ( );
                }
                if ( row [ "shy" ] != null )
                {
                    model . shy = row [ "shy" ] . ToString ( );
                }
                if ( row [ "remark" ] != null )
                {
                    model . remark = row [ "remark" ] . ToString ( );
                }
                if ( row [ "createtime" ] != null && row [ "createtime" ] . ToString ( ) != "" )
                {
                    model . createtime = DateTime . Parse ( row [ "createtime" ] . ToString ( ) );
                }
                if ( row [ "createman" ] != null )
                {
                    model . createman = row [ "createman" ] . ToString ( );
                }
                if ( row [ "modifyman" ] != null )
                {
                    model . modifyman = row [ "modifyman" ] . ToString ( );
                }
                if ( row [ "modifytime" ] != null && row [ "modifytime" ] . ToString ( ) != "" )
                {
                    model . modifytime = DateTime . Parse ( row [ "modifytime" ] . ToString ( ) );
                }
                if ( row [ "isdelete" ] != null && row [ "isdelete" ] . ToString ( ) != "" )
                {
                    model . isdelete = int . Parse ( row [ "isdelete" ] . ToString ( ) );
                }
                modelList .Add(model);
            }
                return modelList;
        }
    }
}
