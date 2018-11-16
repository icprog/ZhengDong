using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class StorageOfRequisitionDao
    {
        /// <summary>
        /// 获得单号
        /// </summary>
        /// <returns></returns>
        public string getCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(code) code FROM t_StorageOfRequisition");

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                string code = dt.Rows[0]["code"].ToString();
                if (string.IsNullOrEmpty(code))
                    return DateTime.Now.ToString("yyyyMMdd") + "001";
                else
                {
                    if (code.Substring(0, 8).Equals(DateTime.Now.ToString("yyyyMMdd")))
                        return (Convert.ToInt64(code) + 1).ToString();
                    else
                        return DateTime.Now.ToString("yyyyMMdd") + "001";
                }
            }
            else
                return DateTime.Now.ToString("yyyyMMdd") + "001";
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from t_StorageOfRequisition");

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(FishEntity.StorageOfRequisitionEntity model, string name)
        {
            Hashtable SQLString = new Hashtable();
            SQLString = ReviewInfo.getSQLString(name, model.code, string.Empty, SQLString);
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_storageofrequisition(");
            strSql.Append("code,fishId,liWeight,LiNumber,price,shipName,country,billName,proName,za,zf,sand,db,applyDate,thCodeNum,supply,saWeight,brand,pileNum,qualitySpe,tvn,hf,sf,shy,remark,codeNum,codeNumContract,jcCode)");
            strSql.Append(" values (");
            strSql.Append("@code,@fishId,@liWeight,@LiNumber,@price,@shipName,@country,@billName,@proName,@za,@zf,@sand,@db,@applyDate,@thCodeNum,@supply,@saWeight,@brand,@pileNum,@qualitySpe,@tvn,@hf,@sf,@shy,@remark,@codeNum,@codeNumContract,@jcCode);");//select LAST_INSERT_ID();
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@liWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@za", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@db", MySqlDbType.VarChar,45),
                    new MySqlParameter("@applyDate", MySqlDbType.DateTime),
                    new MySqlParameter("@thCodeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@supply", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@pileNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@hf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@jcCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@LiNumber",MySqlDbType.Decimal,45)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.fishId;
            parameters[2].Value = model.liWeight;
            parameters[3].Value = model.price;
            parameters[4].Value = model.shipName;
            parameters[5].Value = model.country;
            parameters[6].Value = model.billName;
            parameters[7].Value = model.proName;
            parameters[8].Value = model.za;
            parameters[9].Value = model.zf;
            parameters[10].Value = model.sand;
            parameters[11].Value = model.db;
            parameters[12].Value = model.applyDate;
            parameters[13].Value = model.thCodeNum;
            parameters[14].Value = model.supply;
            parameters[15].Value = model.saWeight;
            parameters[16].Value = model.brand;
            parameters[17].Value = model.pileNum;
            parameters[18].Value = model.qualitySpe;
            parameters[19].Value = model.tvn;
            parameters[20].Value = model.hf;
            parameters[21].Value = model.sf;
            parameters[22].Value = model.shy;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.codeNum;
            parameters[25].Value = model.codeNumContract;
            parameters[26].Value = model.jcCode;
            parameters[27].Value = model.LiNumber;
            SQLString.Add(strSql, parameters);
            if (MySqlHelper.ExecuteSqlTran(SQLString))
            {
                strSql = new StringBuilder();
                strSql.AppendFormat("SELECT id FROM t_storageofrequisition WHERE code='{0}'", model.code);

                DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                    return string.IsNullOrEmpty(dt.Rows[0]["id"].ToString()) == true ? 0 : Convert.ToInt32(dt.Rows[0]["id"].ToString());
                else
                    return 0;
            }
            else
                return 0;
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit(FishEntity.StorageOfRequisitionEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_storageofrequisition set ");
            strSql.Append("code=@code,");
            strSql.Append("fishId=@fishId,");
            strSql.Append("liWeight=@liWeight,");
            strSql.Append("LiNumber=@LiNumber,");
            strSql.Append("price=@price,");
            strSql.Append("shipName=@shipName,");
            strSql.Append("country=@country,");
            strSql.Append("billName=@billName,");
            strSql.Append("proName=@proName,");
            strSql.Append("za=@za,");
            strSql.Append("zf=@zf,");
            strSql.Append("sand=@sand,");
            strSql.Append("db=@db,");
            strSql.Append("applyDate=@applyDate,");
            strSql.Append("thCodeNum=@thCodeNum,");
            strSql.Append("supply=@supply,");
            strSql.Append("saWeight=@saWeight,");
            strSql.Append("brand=@brand,");
            strSql.Append("pileNum=@pileNum,");
            strSql.Append("qualitySpe=@qualitySpe,");
            strSql.Append("tvn=@tvn,");
            strSql.Append("hf=@hf,");
            strSql.Append("sf=@sf,");
            strSql.Append("shy=@shy,");
            strSql.Append("remark=@remark,");
            strSql.Append("codeNum=@codeNum,");
            strSql.Append("codeNumContract=@codeNumContract,");
            strSql.Append("jcCode=@jcCode ");
            //strSql . Append ( "createTime=@createTime," );
            //strSql . Append ( "createUser=@createUser," );
            //strSql . Append ( "modifyTime=@modifyTime," );
            //strSql . Append ( "modifyUser=@modifyUser" );
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@code", MySqlDbType.VarChar,45),
                    new MySqlParameter("@fishId", MySqlDbType.VarChar,45),
                    new MySqlParameter("@liWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@price", MySqlDbType.Decimal,10),
                    new MySqlParameter("@shipName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@country", MySqlDbType.VarChar,45),
                    new MySqlParameter("@billName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@proName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@za", MySqlDbType.VarChar,45),
                    new MySqlParameter("@zf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@db", MySqlDbType.VarChar,45),
                    new MySqlParameter("@applyDate", MySqlDbType.DateTime),
                    new MySqlParameter("@thCodeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@supply", MySqlDbType.VarChar,45),
                    new MySqlParameter("@saWeight", MySqlDbType.Decimal,10),
                    new MySqlParameter("@brand", MySqlDbType.VarChar,45),
                    new MySqlParameter("@pileNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@qualitySpe", MySqlDbType.VarChar,45),
                    new MySqlParameter("@tvn", MySqlDbType.VarChar,45),
                    new MySqlParameter("@hf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@sf", MySqlDbType.VarChar,45),
                    new MySqlParameter("@shy", MySqlDbType.VarChar,45),
                    new MySqlParameter("@remark", MySqlDbType.VarChar,255),
                    new MySqlParameter("@codeNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@codeNumContract", MySqlDbType.VarChar,45),
                    new MySqlParameter("@jcCode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@LiNumber",MySqlDbType.Decimal,45)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.fishId;
            parameters[2].Value = model.liWeight;
            parameters[3].Value = model.price;
            parameters[4].Value = model.shipName;
            parameters[5].Value = model.country;
            parameters[6].Value = model.billName;
            parameters[7].Value = model.proName;
            parameters[8].Value = model.za;
            parameters[9].Value = model.zf;
            parameters[10].Value = model.sand;
            parameters[11].Value = model.db;
            parameters[12].Value = model.applyDate;
            parameters[13].Value = model.thCodeNum;
            parameters[14].Value = model.supply;
            parameters[15].Value = model.saWeight;
            parameters[16].Value = model.brand;
            parameters[17].Value = model.pileNum;
            parameters[18].Value = model.qualitySpe;
            parameters[19].Value = model.tvn;
            parameters[20].Value = model.hf;
            parameters[21].Value = model.sf;
            parameters[22].Value = model.shy;
            parameters[23].Value = model.remark;
            parameters[24].Value = model.codeNum;
            parameters[25].Value = model.codeNumContract;
            parameters[26].Value = model.jcCode;
            parameters[27].Value = model.id;
            parameters[28].Value = model.LiNumber;
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
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(string name, string code)
        {
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_storageofrequisition ");
            strSql.AppendFormat(" where code='{0}'", code);
            SQLString.Add(strSql, null);
            strSql = new StringBuilder();
            strSql.AppendFormat("delete from t_review where programId='{0}' and code='{1}'", name, code);
            SQLString.Add(strSql, null);

            return MySqlHelper.ExecuteSqlTran(SQLString);
        }

        /// <summary>
        /// 配料单是否领取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists_isDel(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_batchsheets where rkCode='{0}'", code);

            return MySqlHelper.Exists(strSql.ToString());
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public FishEntity.StorageOfRequisitionEntity getModel(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,fishId,LiNumber,liWeight,price,shipName,country,billName,proName,za,zf,sand,db,applyDate,thCodeNum,supply,saWeight,brand,pileNum,qualitySpe,tvn,hf,sf,shy,remark,codeNum,codeNumContract,jcCode,createTime,createUser,modifyTime,modifyUser from t_storageofrequisition ");
            strSql.AppendFormat(" where {0}", strWhere);

            DataTable dt = MySqlHelper.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return getModel(dt.Rows[0]);
            }
            else
                return null;
        }
        public DataTable getTable(string name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT id,`code`,fishId,liWeight,price,shipName,country,billName,proName,za,zf,sand,db,applyDate,thCodeNum,supply,saWeight,brand,pileNum,qualitySpe,tvn,hf,sf,shy,remark,codeNum,codeNumContract,jcCode,createUser from t_storageofrequisition ");
            strSql.Append("where " + name);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        public FishEntity.StorageOfRequisitionEntity getModel(DataRow row)
        {
            FishEntity.StorageOfRequisitionEntity model = new FishEntity.StorageOfRequisitionEntity();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null)
                {
                    model.code = row["code"].ToString();
                }
                if (row["fishId"] != null)
                {
                    model.fishId = row["fishId"].ToString();
                }
                if (row["liWeight"] != null && row["liWeight"].ToString() != "")
                {
                    model.liWeight = decimal.Parse(row["liWeight"].ToString());
                }
                if (row["LiNumber"] != null && row["LiNumber"].ToString() != "")
                {
                    model.LiNumber = decimal.Parse(row["LiNumber"].ToString());
                }//LiNumber
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["shipName"] != null)
                {
                    model.shipName = row["shipName"].ToString();
                }
                if (row["country"] != null)
                {
                    model.country = row["country"].ToString();
                }
                if (row["billName"] != null)
                {
                    model.billName = row["billName"].ToString();
                }
                if (row["proName"] != null)
                {
                    model.proName = row["proName"].ToString();
                }
                if (row["za"] != null)
                {
                    model.za = row["za"].ToString();
                }
                if (row["zf"] != null)
                {
                    model.zf = row["zf"].ToString();
                }
                if (row["sand"] != null)
                {
                    model.sand = row["sand"].ToString();
                }
                if (row["db"] != null)
                {
                    model.db = row["db"].ToString();
                }
                if (row["applyDate"] != null && row["applyDate"].ToString() != "")
                {
                    model.applyDate = DateTime.Parse(row["applyDate"].ToString());
                }
                if (row["thCodeNum"] != null && row["thCodeNum"].ToString() != "")
                {
                    model.thCodeNum = row["thCodeNum"].ToString();
                }
                if (row["supply"] != null)
                {
                    model.supply = row["supply"].ToString();
                }
                if (row["saWeight"] != null && row["saWeight"].ToString() != "")
                {
                    model.saWeight = decimal.Parse(row["saWeight"].ToString());
                }
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }
                if (row["pileNum"] != null)
                {
                    model.pileNum = row["pileNum"].ToString();
                }
                if (row["qualitySpe"] != null)
                {
                    model.qualitySpe = row["qualitySpe"].ToString();
                }
                if (row["tvn"] != null)
                {
                    model.tvn = row["tvn"].ToString();
                }
                if (row["hf"] != null)
                {
                    model.hf = row["hf"].ToString();
                }
                if (row["sf"] != null)
                {
                    model.sf = row["sf"].ToString();
                }
                if (row["shy"] != null)
                {
                    model.shy = row["shy"].ToString();
                }
                if (row["remark"] != null)
                {
                    model.remark = row["remark"].ToString();
                }
                if (row["codeNum"] != null)
                {
                    model.codeNum = row["codeNum"].ToString();
                }
                if (row["codeNumContract"] != null)
                {
                    model.codeNumContract = row["codeNumContract"].ToString();
                }
                if (row["jcCode"] != null)
                {
                    model.jcCode = row["jcCode"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("select count(1) from t_storageofrequisition where code='{0}'", code);

            return MySqlHelper.Exists(strSql.ToString());
        }
        public FishEntity.PriWarehouseEntity addRK(string name)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT a.fishId,a.codeNum,a.codeNumContract,b.supplier,billofgoods,UnitPrice,confirmagent,confirmlinkman,confirmdate,confirmrmb,a.country, d.brand, a.brands,a.weight,b.varieties,sgs_protein,sgs_tvn,sgs_fat,sgs_water,sgs_amine,sgs_ffa,sgs_sandsalt,sgs_graypart,sgs_sand,domestic_protein,domestic_amine,domestic_tvn,domestic_sandsalt,domestic_graypart,domestic_sour,domestic_fat,domestic_lysine,domestic_methionine,domestic_aminototal,d.remark,d.shipno,spotdate,warehouse,cornerno,samplingtime,spotproductdate,CASE WHEN d.state = TRUE THEN	'报盘'WHEN d.state1 = TRUE THEN	'确盘'WHEN d.state2 = TRUE THEN	'现货'WHEN d.state3 = TRUE THEN	'自营'WHEN d.state4 = TRUE THEN	'自制'WHEN d.state5 THEN	'成品'END 状态, d.type 港口 FROM 	t_purchaseapplication a LEFT JOIN t_purchaseFishInfo e ON a.codeNum = e. CODE LEFT JOIN t_purchasecontract b ON a.codeNum = b.codeNum  LEFT JOIN t_product d ON a.fishId = d. CODE LEFT JOIN t_productex f ON d.id = f.id ");
            strsql.Append(name);
            DataSet ds = MySqlHelper.Query(strsql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.PriWarehouseEntity model = new FishEntity.PriWarehouseEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row!=null)
                {
                    if (row["fishId"]!=null)
                    {
                        model.FishId = row["fishId"].ToString();
                    }
                    if (row["codeNum"]!=null)
                    {
                        model.CodeNum = row["codeNum"].ToString();
                    }
                    if (row["codeNumContract"] !=null)
                    {
                        model.CodeNumContract = row["codeNumContract"].ToString();
                    }
                    if (row["supplier"] != null)
                    {
                        model.gongfang = row["supplier"].ToString();
                    }
                    //gongfang
                    if (row["billofgoods"] != null)
                    {
                        model.BillName = row["billofgoods"].ToString();
                    }
                    if (row["confirmagent"] != null)
                    {
                        model.Confirmagent = row["confirmagent"].ToString();
                    }
                    if (row["confirmlinkman"] != null)
                    {
                        model.Confirmlinkman = row["confirmlinkman"].ToString();
                    }
                    if (row["confirmdate"] != null)
                    {
                        model.Confirmdate =row["confirmdate"].ToString();
                    }
                    if (row["UnitPrice"] != null)
                    {
                        model.Confirmrmb = row["UnitPrice"].ToString();
                    }
                    if (row["country"] !=null)
                    {
                        model.Conutry = row["country"].ToString();
                    }
                    if (row["brand"] != null)
                    {
                        model.Brand = row["brand"].ToString();
                    }
                    if (row["brands"] != null)
                    {
                        model.QuaSpe = row["brands"].ToString();
                    }
                    if (row["weight"] != null)
                    {
                        model.Confirmsgsweight = row["weight"].ToString();
                    }
                    //if (row["height"] != null)
                    //{
                    //    model.Height = row["height"].ToString();
                    //}
                    if (row["varieties"] !=null)
                    {
                        model.Name = row["varieties"].ToString();
                    }
                    if (row["sgs_protein"] != null)
                    {
                        model.Sgs_protein = row["sgs_protein"].ToString();
                    }
                    if (row["sgs_tvn"] != null)
                    {
                        model.Sgs_tvn = row["sgs_tvn"].ToString();
                    }
                    if (row["sgs_fat"] != null)
                    {
                        model.Sgs_fat = row["sgs_fat"].ToString();
                    }
                    if (row["sgs_water"] != null)
                    {
                        model.Sgs_water = row["sgs_water"].ToString();
                    }
                    if (row["sgs_amine"] != null)
                    {
                        model.Sgs_amine = row["sgs_amine"].ToString();
                    }
                    if (row["sgs_ffa"] != null)
                    {
                        model.Sgs_ffa = row["sgs_ffa"].ToString();
                    }
                    if (row["sgs_sandsalt"] != null)
                    {
                        model.Sgs_sandsalt = row["sgs_sandsalt"].ToString();
                    }
                    if (row["sgs_graypart"] != null)
                    {
                        model.Sgs_graypart = row["sgs_graypart"].ToString();
                    }
                    if (row["sgs_sand"]!=null)
                    {
                        model.Sgs_sand=row["sgs_sand"].ToString();
                    }

                    if (row["domestic_protein"] != null)
                    {
                        model.Domestic_protein = row["domestic_protein"].ToString();
                    }
                    if (row["domestic_amine"] != null)
                    {
                        model.Domestic_amine = row["domestic_amine"].ToString();
                    }
                    if (row["domestic_tvn"] != null)
                    {
                        model.Domestic_tvn = row["domestic_tvn"].ToString();
                    }
                    if (row["domestic_sandsalt"] != null)
                    {
                        model.Domestic_sandsalt = row["domestic_sandsalt"].ToString();
                    }
                    if (row["domestic_graypart"] != null)
                    {
                        model.Domestic_graypart = row["domestic_graypart"].ToString();
                    }
                    if (row["domestic_sour"] != null)
                    {
                        model.Domestic_sour = row["domestic_sour"].ToString();
                    }
                    if (row["domestic_fat"] != null)
                    {
                        model.Domestic_fat = row["domestic_fat"].ToString();
                    }

                    if (row["domestic_lysine"] != null)
                    {
                        model.Domestic_lysine = row["domestic_lysine"].ToString();
                    }
                    if (row["domestic_methionine"] != null)
                    {
                        model.Domestic_methionine = row["domestic_methionine"].ToString();
                    }
                    if (row["domestic_aminototal"] != null)
                    {
                        model.Domestic_aminototal = row["domestic_aminototal"].ToString();
                    }
                    if (row["remark"] != null)
                    {
                        model.Remark = row["remark"].ToString();
                    }
                    if (row["shipno"] != null)
                    {
                        model.ShipName = row["shipno"].ToString();
                    }
                    if (row["spotdate"] != null)
                    {
                        model.Spotdate = row["spotdate"].ToString();
                    }
                    if (row["warehouse"] != null)
                    {
                        model.Warehouse = row["warehouse"].ToString();
                    }

                    if (row["cornerno"] != null)
                    {
                        model.Cornerno = row["cornerno"].ToString();
                    }
                    if (row["samplingtime"] != null)
                    {
                        model.Samplingtime = row["samplingtime"].ToString();
                    }
                    if (row["spotproductdate"] != null)
                    {
                        model.Spotproductdate = row["spotproductdate"].ToString();
                    }
                    //if (row["type"] != null)
                    //{
                    //    model.Type = row["type"].ToString();
                    //}
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

