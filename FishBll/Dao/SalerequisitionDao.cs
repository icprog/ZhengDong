using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace FishBll.Dao
{
    public class SalerequisitionDao
    {
        ///<summary>
        ///合同编号是否存在
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from t_salesorder where code=@code");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = code;
            return MySqlHelper.Exists(strsql.ToString(), parameter);
        }
        /// <summary>
        /// 编号是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExistsNumbering(string Numbering)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from t_salesorder where Numbering=@Numbering");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = Numbering;
            return MySqlHelper.Exists(strsql.ToString(), parameter);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Numbering,id,code,supplier,SupplierContact,SupplierContactId,DemandContact,DemandContactId,DemandSideBank,PaymentUnit,RequiredAccount,Purchasingunits,PurchasingunitsId,Purchasingcontacts,PurchasingcontactsId,Purchasecontractnumber,supplierId,demand,demandId,Signdate,Signplace,SupplierAbbreviation,DemandAbbreviation,deIndex,rebate,overflow,rebateBool,Portprice,PortpriceBool,Country,CountryBool,transport,deadline,Freight,CNumbering,delivery,dt,dty,lxt,lxty,Settlementmethod,payment,Bank,Receipt,accountnumber,remart,dt,dty,lxt,lxty,WithSkin,WithSkinbool,Numbering,Supplierbool,Demandbool,dbbool,tvnbool,zabool,ffabool,zfbool,sfbool,shybool,szbool,cdbbool,tvnOnebool,hfbool,zaOnebool,ffaOnebool,zfOnebool,sfOnebool,shyOnebool,szOnebool,informationbool,Stockpilebool,Freightbool,rebateSumBool,WithSkinSumbool,RebateSumBool,PortpriceSumBool,FreightSumbool,createman,modifyman,rabZy,rabZz from t_salesorder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
                return null;
        }
        public FishEntity.SalesRequisitionEntity createmanGet(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select createman,demand,Signdate,Purchasecontractnumber from t_salesorder ");
            if (code.Trim() != "")
            {
                strSql.Append(" where Numbering='" + code + "'");
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return createmanGetModelModel(ds.Tables[0].Rows[0]);
            }
            else
                return null;
        }
        public FishEntity.SalesRequisitionEntity Getname(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.code,Numbering,b.product_id from t_salesorder a inner join t_happening b on a.Numbering=b.NumberingOne ");
            if (Numbering.Trim() != "")
            {
                strSql.Append(" where Numbering='" + Numbering + "'");
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();
                DataRow row = ds.Tables[0].Rows[0];
                if (row!=null)
                {
                    if (row["Numbering"] != null)
                    {
                        model.Numbering = row["Numbering"].ToString();
                    }
                    if (row["code"] != null)
                    {
                        model.code = row["code"].ToString();
                    }
                    if (row["Product_id"]!=null)
                    {
                        model.Product_id = row["Product_id"].ToString();
                    }
                }
                return model;
            }
            else { 
                return null;
            }
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableOne(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code,supplier,Purchasingunits,Purchasingcontacts,payment,Purchasecontractnumber,demand,Signdate,Signplace,case when rebateBool=0 then '' else CONCAT('回扣：',rebate) end rebate,case when PortpriceBool=0 then '' else CONCAT('港价：',Portprice) end Portprice,transport,deadline,case when Freightbool=0 then'' else concat('运费:',Freight) end Freight,delivery,Settlementmethod,Bank,Receipt,accountnumber,case when Stockpilebool=0 then '' else CONCAT('堆存费:',dt,' 元/吨/天。') end dt,case when WithSkinbool=0 then'' else concat('带皮扣重:',WithSkin) end WithSkin,Supplierbool,Demandbool,dbbool,tvnbool,zabool,ffabool,zfbool,sfbool,shybool,szbool,cdbbool,tvnOnebool,hfbool,zaOnebool,ffaOnebool,zfOnebool,sfOnebool,shyOnebool,szOnebool,informationbool from t_salesorder ");
            strSql.AppendFormat("WHERE code='{0}'", code);
            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTwo(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select product_id,productname,Funit,Quantity,unitprice,Amonut sumPrice from t_happening ");
            strSql.AppendFormat("WHERE code='{0}'", code);

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>//不明白
        public DataTable printTableTre(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CONCAT(productname,'SGS指标:',case when b.dbbool=0 then''else concat('蛋白≥',db,'%,')end,case when b.tvnbool=0 then''else concat('TVN≤',tvn,'%,')end,		case when b.zabool=0 then''else concat('组胺≤',za,'%,')end,case when b.ffabool=0 then''else concat('FFA≤',ffa,'%,')end,case when b.zfbool=0 then''else concat('脂肪≤',zf,'%,')end,	case when b.sfbool=0 then''else concat('水分≤',sf,'%,')end,case when b.shybool=0 then''else concat('沙和盐≤',shy,'%,')end,case when b.szbool=0 then''else concat('沙子≤',sz,'%,')end,'国外SGS,不得发霉、有异味或掺杂其它杂物,且应符合国家质量标准。') yfName,CASE WHEN b.deIndex = 0 THEN''ELSE CONCAT(productname,'国内检测指标:',case when b.cdbbool = 0 then''else concat('粗蛋白≤', cdb,'%,')end,case when b.tvnOnebool = 0 then''else concat('TVN≤', tvnOne,'%,')end,case when b.hfbool = 0 then''else concat('灰份≤', hfbool,'%,')end,case when b.zaOnebool = 0 then''else concat('组胺≤', zaOne,'%,')end,case when b.ffaOnebool = 0 then''else concat('FFA≤', ffaOne,'%,')end,case when b.zfOnebool = 0 then''else concat('脂肪≤', zfOne,'%,')end,case when b.sfOnebool = 0 then''else concat('水分≤', sfOne,'%,')end,case when b.shyOnebool = 0 then''else concat('沙和盐≤', shyOne,'%,')end,case when b.szOnebool = 0 then''else concat('沙子≤', szOne,'%,')end, '国内检测指标平均值。')END yfcdb,case when b.informationbool=0 then''else CONCAT(productname,'船名',cm,'提单号:',tdh,'桩脚号:',zjh,'国别:',a.Country,'品牌:',pp)end yfcm FROM t_happening a LEFT JOIN t_salesorder b ON a. CODE = b. CODE ");
            strSql.AppendFormat("WHERE a.code='{0}'", code);

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        public static FishEntity.SalesRequisitionEntity createmanGetModelModel(DataRow row)
        {
            FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();

            if (row != null)
            {
                if (row["createman"] != null && row["createman"].ToString() != "")
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["demand"] != null && row["demand"].ToString() != "")
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["Signdate"] != null)
                {
                    model.Signdate = DateTime.Parse(row["Signdate"].ToString());
                }
                if (row["Purchasecontractnumber"]!=null)
                {
                    model.Purchasecontractnumber = row["Purchasecontractnumber"].ToString();
                }
            }
            return model;
        }
        public static FishEntity.SalesRequisitionEntity DataRowToModel(DataRow row)
        {
            FishEntity.SalesRequisitionEntity model = new FishEntity.SalesRequisitionEntity();

            if ( row != null )
            {
                if ( row [ "Numbering" ] != null && row [ "Numbering" ] . ToString ( ) != "" )
                {
                    model . Numbering = row [ "Numbering" ] . ToString ( );
                }
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "code" ] != null )
                {
                    model . code = row [ "code" ] . ToString ( );
                }
                if ( row [ "SupplierContact" ] != null )
                {
                    model . SupplierContact = row [ "SupplierContact" ] . ToString ( );
                }
                if ( row [ "SupplierContactId" ] != null )
                {
                    model . SupplierContactId = row [ "SupplierContactId" ] . ToString ( );
                }
                if ( row [ "DemandContact" ] != null )
                {
                    model . DemandContact = row [ "DemandContact" ] . ToString ( );
                }
                if ( row [ "DemandContactId" ] != null )
                {
                    model . DemandContactId = row [ "DemandContactId" ] . ToString ( );
                }
                if ( row [ "supplier" ] != null )
                {
                    model . supplier = row [ "supplier" ] . ToString ( );
                }
                if ( row [ "DemandSideBank" ] != null )
                {
                    model . DemandSideBank = row [ "DemandSideBank" ] . ToString ( );
                }
                if ( row [ "PaymentUnit" ] != null )
                {
                    model . PaymentUnit = row [ "PaymentUnit" ] . ToString ( );
                }
                if ( row [ "RequiredAccount" ] != null )
                {
                    model . RequiredAccount = row [ "RequiredAccount" ] . ToString ( );
                }
                if ( row [ "Purchasecontractnumber" ] != null )
                {
                    model . Purchasecontractnumber = row [ "Purchasecontractnumber" ] . ToString ( );
                }
                if ( row [ "Createman" ] != null )
                {
                    model . createman = row [ "Createman" ] . ToString ( );
                }
                if ( row [ "modifyman" ] != null )
                {
                    model . modifyman = row [ "modifyman" ] . ToString ( );
                }
                if ( row [ "Purchasingcontacts" ] != null )
                {
                    model . Purchasingcontacts = row [ "Purchasingcontacts" ] . ToString ( );
                }
                if ( row [ "PurchasingcontactsId" ] != null )
                {
                    model . PurchasingcontactsId = row [ "PurchasingcontactsId" ] . ToString ( );
                }
                if ( row [ "Purchasingunits" ] != null )
                {
                    model . Purchasingunits = row [ "Purchasingunits" ] . ToString ( );
                }
                if ( row [ "PurchasingunitsId" ] != null )
                {
                    model . PurchasingunitsId = row [ "PurchasingunitsId" ] . ToString ( );
                }
                if ( row [ "supplierId" ] != null )
                {
                    model . supplierId = row [ "supplierId" ] . ToString ( );
                }
                if ( row [ "demand" ] != null )
                {
                    model . demand = row [ "demand" ] . ToString ( );
                }
                if ( row [ "demandId" ] != null )
                {
                    model . demandId = row [ "demandId" ] . ToString ( );
                }
                if ( row [ "Signdate" ] != null && row [ "Signdate" ] . ToString ( ) != "" )
                {
                    model . Signdate = DateTime . Parse ( row [ "Signdate" ] . ToString ( ) );
                }
                if ( row [ "Signplace" ] != null )
                {
                    model . Signplace = row [ "Signplace" ] . ToString ( );
                }
                if ( row [ "SupplierAbbreviation" ] != null )
                {
                    model . SupplierAbbreviation = row [ "SupplierAbbreviation" ] . ToString ( );
                }
                if ( row [ "DemandAbbreviation" ] != null )
                {
                    model . DemandAbbreviation = row [ "DemandAbbreviation" ] . ToString ( );
                }
                if ( row [ "deIndex" ] != null && row [ "deIndex" ] . ToString ( ) != "" )
                {
                    model . deIndex = bool . Parse ( row [ "deIndex" ] . ToString ( ) );
                }
                if ( row [ "rebate" ] != null && row [ "rebate" ] . ToString ( ) != "" )
                {
                    model . rebate = decimal . Parse ( row [ "rebate" ] . ToString ( ) );
                }
                if (row["overflow"]!=null&&row["overflow"].ToString()!="")
                {
                    model.overflow = decimal.Parse(row["overflow"].ToString());
                }
                if ( row [ "rebateBool" ] != null && row [ "rebateBool" ] . ToString ( ) != "" )
                {
                    model . rebateBool = bool . Parse ( row [ "rebateBool" ] . ToString ( ) );
                }
                if ( row [ "WithSkin" ] != null && row [ "WithSkin" ] . ToString ( ) != "" )
                {
                    model . WithSkin = row [ "WithSkin" ] . ToString ( );
                }
                if ( row [ "supplierbool" ] != null && row [ "supplierbool" ] . ToString ( ) != "" )
                {
                    model . Supplierbool = bool . Parse ( row [ "supplierbool" ] . ToString ( ) );
                }
                if ( row [ "Demandbool" ] != null && row [ "Demandbool" ] . ToString ( ) != "" )
                {
                    model . Demandbool = bool . Parse ( row [ "Demandbool" ] . ToString ( ) );
                }
                if ( row [ "dbbool" ] != null && row [ "dbbool" ] . ToString ( ) != "" )
                {
                    model . Dbbool = bool . Parse ( row [ "dbbool" ] . ToString ( ) );
                }
                if ( row [ "tvnbool" ] != null && row [ "tvnbool" ] . ToString ( ) != "" )
                {
                    model . Tvnbool = bool . Parse ( row [ "tvnbool" ] . ToString ( ) );
                }
                if ( row [ "zabool" ] != null && row [ "zabool" ] . ToString ( ) != "" )
                {
                    model . Zabool = bool . Parse ( row [ "zabool" ] . ToString ( ) );
                }
                if ( row [ "ffabool" ] != null && row [ "ffabool" ] . ToString ( ) != "" )
                {
                    model . Ffabool = bool . Parse ( row [ "ffabool" ] . ToString ( ) );
                }
                if ( row [ "zfbool" ] != null && row [ "zfbool" ] . ToString ( ) != "" )
                {
                    model . Zfbool = bool . Parse ( row [ "zfbool" ] . ToString ( ) );
                }
                if ( row [ "sfbool" ] != null && row [ "sfbool" ] . ToString ( ) != "" )
                {
                    model . Sfbool = bool . Parse ( row [ "sfbool" ] . ToString ( ) );
                }
                if ( row [ "shybool" ] != null && row [ "shybool" ] . ToString ( ) != "" )
                {
                    model . Shybool = bool . Parse ( row [ "shybool" ] . ToString ( ) );
                }
                if ( row [ "szbool" ] != null && row [ "szbool" ] . ToString ( ) != "" )
                {
                    model . Szbool = bool . Parse ( row [ "szbool" ] . ToString ( ) );
                }
                if ( row [ "cdbbool" ] != null && row [ "cdbbool" ] . ToString ( ) != "" )
                {
                    model . Cdbbool = bool . Parse ( row [ "cdbbool" ] . ToString ( ) );
                }
                if ( row [ "tvnOnebool" ] != null && row [ "tvnOnebool" ] . ToString ( ) != "" )
                {
                    model . TvnOnebool = bool . Parse ( row [ "tvnOnebool" ] . ToString ( ) );
                }
                if ( row [ "hfbool" ] != null && row [ "hfbool" ] . ToString ( ) != "" )
                {
                    model . Hfbool = bool . Parse ( row [ "hfbool" ] . ToString ( ) );
                }
                if ( row [ "zaOnebool" ] != null && row [ "zaOnebool" ] . ToString ( ) != "" )
                {
                    model . ZaOnebool = bool . Parse ( row [ "zaOnebool" ] . ToString ( ) );
                }
                if ( row [ "ffaOnebool" ] != null && row [ "ffaOnebool" ] . ToString ( ) != "" )
                {
                    model . FfaOnebool = bool . Parse ( row [ "ffaOnebool" ] . ToString ( ) );
                }
                if ( row [ "zfOnebool" ] != null && row [ "zfOnebool" ] . ToString ( ) != "" )
                {
                    model . ZfOnebool = bool . Parse ( row [ "zfOnebool" ] . ToString ( ) );
                }
                if ( row [ "sfOnebool" ] != null && row [ "sfOnebool" ] . ToString ( ) != "" )
                {
                    model . SfOnebool = bool . Parse ( row [ "sfOnebool" ] . ToString ( ) );
                }
                if ( row [ "shyOnebool" ] != null && row [ "shyOnebool" ] . ToString ( ) != "" )
                {
                    model . ShyOnebool = bool . Parse ( row [ "shyOnebool" ] . ToString ( ) );
                }
                if ( row [ "szOnebool" ] != null && row [ "szOnebool" ] . ToString ( ) != "" )
                {
                    model . SzOnebool = bool . Parse ( row [ "szOnebool" ] . ToString ( ) );
                }
                if ( row [ "informationbool" ] != null && row [ "informationbool" ] . ToString ( ) != "" )
                {
                    model . Informationbool = bool . Parse ( row [ "informationbool" ] . ToString ( ) );
                }
                if ( row [ "Portprice" ] != null && row [ "Portprice" ] . ToString ( ) != "" )
                {
                    model . Portprice = decimal . Parse ( row [ "Portprice" ] . ToString ( ) );
                }
                if ( row [ "PortpriceBool" ] != null && row [ "PortpriceBool" ] . ToString ( ) != "" )
                {
                    model . PortpriceBool = bool . Parse ( row [ "PortpriceBool" ] . ToString ( ) );
                }
                if ( row [ "Stockpilebool" ] != null && row [ "Stockpilebool" ] . ToString ( ) != "" )
                {
                    model . Stockpilebool = bool . Parse ( row [ "Stockpilebool" ] . ToString ( ) );
                }
                if ( row [ "WithSkinBool" ] != null && row [ "WithSkinBool" ] . ToString ( ) != "" )
                {
                    model . WithSkinbool = bool . Parse ( row [ "WithSkinBool" ] . ToString ( ) );
                }
                if ( row [ "Freightbool" ] != null && row [ "Freightbool" ] . ToString ( ) != "" )
                {
                    model . Freightbool = bool . Parse ( row [ "Freightbool" ] . ToString ( ) );
                }
                if ( row [ "rebateSumBool" ] != null && row [ "rebateSumBool" ] . ToString ( ) != "" )
                {
                    model . RebateSumBool = bool . Parse ( row [ "rebateSumBool" ] . ToString ( ) );
                }
                if ( row [ "WithSkinSumbool" ] != null && row [ "WithSkinSumbool" ] . ToString ( ) != "" )
                {
                    model . WithSkinSumbool = bool . Parse ( row [ "WithSkinSumbool" ] . ToString ( ) );
                }
                if ( row [ "PortpriceSumBool" ] != null && row [ "PortpriceSumBool" ] . ToString ( ) != "" )
                {
                    model . PortpriceSumBool = bool . Parse ( row [ "PortpriceSumBool" ] . ToString ( ) );
                }
                if ( row [ "FreightSumbool" ] != null && row [ "FreightSumbool" ] . ToString ( ) != "" )
                {
                    model . FreightSumbool = bool . Parse ( row [ "FreightSumbool" ] . ToString ( ) );
                }
                if ( row [ "Country" ] != null )
                {
                    model . Country = row [ "Country" ] . ToString ( );
                }
                if ( row [ "CountryBool" ] != null && row [ "CountryBool" ] . ToString ( ) != "" )
                {
                    model . CountryBool = bool . Parse ( row [ "CountryBool" ] . ToString ( ) );
                }
                if ( row [ "transport" ] != null )
                {
                    model . transport = row [ "transport" ] . ToString ( );
                }
                if ( row [ "deadline" ] != null )
                {
                    model . deadline = DateTime . Parse ( row [ "deadline" ] . ToString ( ) );
                }
                if ( row [ "Freight" ] != null && row [ "Freight" ] . ToString ( ) != "" )
                {
                    model . Freight = decimal . Parse ( row [ "Freight" ] . ToString ( ) );
                }
                if ( row [ "CNumbering" ] != null )
                {
                    model . CNumbering = row [ "CNumbering" ] . ToString ( );
                }
                if ( row [ "dt" ] != null && row [ "dt" ] . ToString ( ) != "" )
                {
                    model . dt = decimal . Parse ( row [ "dt" ] . ToString ( ) );
                }
                if ( row [ "dty" ] != null && row [ "dty" ] . ToString ( ) != "" )
                {
                    model . dty = decimal . Parse ( row [ "dty" ] . ToString ( ) );
                }
                if ( row [ "lxt" ] != null && row [ "lxt" ] . ToString ( ) != "" )
                {
                    model . lxt = decimal . Parse ( row [ "lxt" ] . ToString ( ) );
                }
                if ( row [ "lxty" ] != null && row [ "lxty" ] . ToString ( ) != "" )
                {
                    model . lxty = decimal . Parse ( row [ "lxty" ] . ToString ( ) );
                }
                if ( row [ "Settlementmethod" ] != null )
                {
                    model . Settlementmethod = row [ "Settlementmethod" ] . ToString ( );
                }
                if ( row [ "payment" ] != null )
                {
                    model . payment = DateTime . Parse ( row [ "payment" ] . ToString ( ) );
                }
                if ( row [ "Bank" ] != null )//
                {
                    model . Bank = row [ "Bank" ] . ToString ( );
                }
                if ( row [ "Receipt" ] != null )
                {
                    model . Receipt = row [ "Receipt" ] . ToString ( );
                }
                if ( row [ "accountnumber" ] != null )
                {
                    model . accountnumber = row [ "accountnumber" ] . ToString ( );
                }
                if ( row [ "remart" ] != null )
                {
                    model . remart = row [ "remart" ] . ToString ( );
                }
                if ( row [ "delivery" ] != null )
                {
                    model . delivery = row [ "delivery" ] . ToString ( );
                }
                if ( row [ "Numbering" ] != null )
                {
                    model . Numbering = row [ "Numbering" ] . ToString ( );
                }
                if ( row [ "rabZy" ] != null && row [ "rabZy" ] . ToString ( ) != "" )
                {
                    model . RabZy = bool . Parse ( row [ "rabZy" ] . ToString ( ) );
                }
                if ( row [ "rabZz" ] != null && row [ "rabZz" ] . ToString ( ) != "" )
                {
                    model . RabZz = bool . Parse ( row [ "rabZz" ] . ToString ( ) );
                }
                //if ( row [ "moneyYFK" ] != null && row [ "moneyYFK" ] . ToString ( ) != "" )
                //{
                //    model . MoneyYFK = decimal . Parse ( row [ "moneyYFK" ] . ToString ( ) );
                //}
            }
            return model;
        }

        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select NOW() t");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["t"].ToString()))
                    return DateTime.Now;
                else
                    return Convert.ToDateTime(ds.Tables[0].Rows[0]["t"].ToString());
            }
            else
                return DateTime.Now;
        }
        public string Numbering()
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("SELECT max(substring_index(Numbering,'C',-1))as Numbering FROM t_PurchaseRequisition where substring_index(Numbering,'C',1)=DATE_FORMAT(NOW(),'%Y')");
            strSql.Append("SELECT max(substring_index(Numbering,'X',-1))as Numbering FROM t_salesorder where substring_index(Numbering,'X',1)=DATE_FORMAT(NOW(),'%Y')");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Numbering"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["Numbering"].ToString();
            }
            else
                return string.Empty;
        }
        /// <summary>
        /// 获取合同单号
        /// </summary>
        /// <returns></returns>
        public string code()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(code) code FROM t_salesorder where length(code)=13 and supplierbool=1 ");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["code"].ToString()))
                    return string.Empty;
                else
                    return ds.Tables[0].Rows[0]["code"].ToString();
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete(string code,string Numbering)
        {
            Hashtable SQLString = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM t_salesorder ");
            strSql.AppendFormat("WHERE code='{0}' and Numbering='{1}' ", code, Numbering);
            SQLString.Add(strSql.ToString(), null);
            strSql = new StringBuilder();
            strSql.Append("DELETE FROM t_happening ");
            strSql.AppendFormat("WHERE code='{0}' and NumberingOne='{1} '", code, Numbering);
            SQLString.Add(strSql.ToString(), null);

            return MySqlHelper.ExecuteSqlTran(SQLString);
        }

        /// <summary>
        /// 新增一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . SalesRequisitionEntity model ,List<FishEntity . SalesRequisitionBodyEntity> modeList )
        {
            Hashtable SQLString = new Hashtable ( );
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ("insert into t_salesorder(code,supplier,SupplierContact,SupplierContactId,DemandContact,DemandContactId,DemandSideBank,PaymentUnit,RequiredAccount,Purchasingunits,PurchasingunitsId,Purchasingcontacts,PurchasingcontactsId,Purchasecontractnumber,supplierId,demand,demandId,Signdate,Signplace,SupplierAbbreviation,DemandAbbreviation,deIndex,rebate,overflow,rebateBool,Portprice,PortpriceBool,CountryBool,transport,deadline,Freight,CNumbering,delivery,dt,dty,lxt,lxty,Settlementmethod,payment,Bank,Receipt,accountnumber,remart,createtime,createman,modifytime,modifyman,WithSkin,WithSkinbool,Numbering,Supplierbool,Demandbool,dbbool,tvnbool,zabool,ffabool,zfbool,sfbool,shybool,szbool,cdbbool,tvnOnebool,hfbool,zaOnebool,ffaOnebool,zfOnebool,sfOnebool,shyOnebool,szOnebool,informationbool,Stockpilebool,Freightbool,rebateSumBool,WithSkinSumbool,PortpriceSumBool,FreightSumbool,rabZy,rabZz )");
            strSql . Append ("values(@code,@supplier,@SupplierContact,@SupplierContactId,@DemandContact,@DemandContactId,@DemandSideBank,@PaymentUnit,@RequiredAccount,@Purchasingunits,@PurchasingunitsId,@Purchasingcontacts,@PurchasingcontactsId,@Purchasecontractnumber,@supplierId,@demand,@demandId,@Signdate,@Signplace,@DemandAbbreviation,@SupplierAbbreviation,@deIndex,@rebate,@overflow,@rebateBool,@Portprice,@PortpriceBool,@CountryBool,@transport,@deadline,@Freight,@CNumbering,@delivery,@dt,@dty,@lxt,@lxty,@Settlementmethod,@payment,@Bank,@Receipt,@accountnumber,@remart,@createtime,@createman,@modifytime,@modifyman,@WithSkin,@WithSkinbool,@Numbering,@Supplierbool,@Demandbool,@dbbool,@tvnbool,@zabool,@ffabool,@zfbool,@sfbool,@shybool,@szbool,@cdbbool,@tvnOnebool,@hfbool,@zaOnebool,@ffaOnebool,@zfOnebool,@sfOnebool,@shyOnebool,@szOnebool,@informationbool,@Stockpilebool,@Freightbool,@rebateSumBool,@WithSkinSumbool,@PortpriceSumBool,@FreightSumbool,@rabZy,@rabZz  )");

            MySqlParameter [ ] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,200),
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplierId",MySqlDbType.VarChar,45),
                new MySqlParameter("@demand",MySqlDbType.VarChar,45),
                new MySqlParameter("@demandId",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdate",MySqlDbType.DateTime),
                new MySqlParameter("@Signplace",MySqlDbType.VarChar,45),
                new MySqlParameter("@deIndex",MySqlDbType.Bit,45),
                new MySqlParameter("@rebate",MySqlDbType.Decimal,45),
                new MySqlParameter("@rebateBool",MySqlDbType.Bit,45),
                new MySqlParameter("@Portprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@PortpriceBool",MySqlDbType.Bit,45),
                new MySqlParameter("@CountryBool",MySqlDbType.Bit,45),
                new MySqlParameter("@transport",MySqlDbType.VarChar,150),
                new MySqlParameter("@deadline",MySqlDbType.Date),
                new MySqlParameter("@Freight",MySqlDbType.Decimal,45),
                new MySqlParameter("@delivery",MySqlDbType.VarChar,45),
                new MySqlParameter("@dt",MySqlDbType.Decimal,45),
                new MySqlParameter("@dty",MySqlDbType.Decimal,45),
                new MySqlParameter("@lxt",MySqlDbType.Decimal,45),
                new MySqlParameter("@lxty",MySqlDbType.Decimal,45),
                new MySqlParameter("@Settlementmethod",MySqlDbType.VarChar,50),
                new MySqlParameter("@payment",MySqlDbType.Date),
                new MySqlParameter("@Bank",MySqlDbType.VarChar,100),
                new MySqlParameter("@Receipt",MySqlDbType.VarChar,100),
                new MySqlParameter("@accountnumber",MySqlDbType.VarChar,100),
                new MySqlParameter("@remart",MySqlDbType.VarChar,100),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@WithSkin",MySqlDbType.VarBinary,45),
                new MySqlParameter("@WithSkinbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplierbool",MySqlDbType.Bit,45),
                new MySqlParameter("@dbbool",MySqlDbType.Bit,45),
                new MySqlParameter("@tvnbool",MySqlDbType.Bit,45),
                new MySqlParameter("@zabool",MySqlDbType.Bit,45),
                new MySqlParameter("@ffabool",MySqlDbType.Bit,45),
                new MySqlParameter("@zfbool",MySqlDbType.Bit,45),
                new MySqlParameter("@sfbool",MySqlDbType.Bit,45),
                new MySqlParameter("@shybool",MySqlDbType.Bit,45),
                new MySqlParameter("@szbool",MySqlDbType.Bit,45),
                new MySqlParameter("@cdbbool",MySqlDbType.Bit,45),
                new MySqlParameter("@tvnOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@hfbool",MySqlDbType.Bit,45),
                new MySqlParameter("@zaOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@ffaOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@zfOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@sfOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@shyOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@szOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@informationbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Stockpilebool",MySqlDbType.Bit,45),
                new MySqlParameter("@Freightbool",MySqlDbType.Bit,45),
                new MySqlParameter("@rebateSumBool",MySqlDbType.Bit,45),
                new MySqlParameter("@WithSkinSumbool",MySqlDbType.Bit,45),
                new MySqlParameter("@PortpriceSumBool",MySqlDbType.Bit,45),
                new MySqlParameter("@FreightSumbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Purchasingunits",MySqlDbType.VarChar,45),
                new MySqlParameter("@Purchasingcontacts",MySqlDbType.VarChar,45),
                new MySqlParameter("@Purchasecontractnumber",MySqlDbType.VarChar,45),
                new MySqlParameter ("@Demandbool",MySqlDbType.Bit,45),
                new MySqlParameter("@DemandSideBank",MySqlDbType.VarChar,100),
                new MySqlParameter("@PaymentUnit",MySqlDbType.VarChar,100),
                new MySqlParameter("@RequiredAccount",MySqlDbType.VarChar,100),
                new MySqlParameter("@SupplierContact",MySqlDbType.VarChar,45),
                new MySqlParameter("@SupplierContactId",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandContact",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandContactId",MySqlDbType.VarChar,45),
                new MySqlParameter("@PurchasingunitsId",MySqlDbType.VarChar,45),
                new MySqlParameter("@PurchasingcontactsId",MySqlDbType.VarChar,45),
                new MySqlParameter("@SupplierAbbreviation",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandAbbreviation",MySqlDbType.VarChar,45),
                new MySqlParameter("@CNumbering",MySqlDbType.VarChar,100),
                new MySqlParameter("@rabZy",MySqlDbType.Bit),
                new MySqlParameter("@rabZz",MySqlDbType.Bit),
                new MySqlParameter("@overflow",MySqlDbType.Decimal,45)
            };
            parameters [ 0 ] . Value = model . code;
            parameters [ 1 ] . Value = model . supplier;
            parameters [ 2 ] . Value = model . supplierId;
            parameters [ 3 ] . Value = model . demand;
            parameters [ 4 ] . Value = model . demandId;
            parameters [ 5 ] . Value = model . Signdate;
            parameters [ 6 ] . Value = model . Signplace;
            parameters [ 7 ] . Value = model . deIndex;
            parameters [ 8 ] . Value = model . rebate;
            parameters [ 9 ] . Value = model . rebateBool;
            parameters [ 10 ] . Value = model . Portprice;
            parameters [ 11 ] . Value = model . PortpriceBool;
            parameters [ 12 ] . Value = model . CountryBool;
            parameters [ 13 ] . Value = model . transport;
            parameters [ 14 ] . Value = model . deadline;
            parameters [ 15 ] . Value = model . Freight;
            parameters [ 16 ] . Value = model . delivery;
            parameters [ 17 ] . Value = model . dt;
            parameters [ 18 ] . Value = model . dty;
            parameters [ 19 ] . Value = model . lxt;
            parameters [ 20 ] . Value = model . lxty;
            parameters [ 21 ] . Value = model . Settlementmethod;
            parameters [ 22 ] . Value = model . payment;
            parameters [ 23 ] . Value = model . Bank;
            parameters [ 24 ] . Value = model . Receipt;
            parameters [ 25 ] . Value = model . accountnumber;
            parameters [ 26 ] . Value = model . remart;
            parameters [ 27 ] . Value = model . createtime;
            parameters [ 28 ] . Value = model . createman;
            parameters [ 29 ] . Value = model . modifytime;
            parameters [ 30 ] . Value = model . modifyman;
            parameters [ 31 ] . Value = model . WithSkin;
            parameters [ 32 ] . Value = model . WithSkinbool;
            parameters [ 33 ] . Value = model . Numbering;
            parameters [ 34 ] . Value = model . Supplierbool;
            parameters [ 35 ] . Value = model . Dbbool;
            parameters [ 36 ] . Value = model . Tvnbool;
            parameters [ 37 ] . Value = model . Zabool;
            parameters [ 38 ] . Value = model . Ffabool;
            parameters [ 39 ] . Value = model . Zfbool;
            parameters [ 40 ] . Value = model . Sfbool;
            parameters [ 41 ] . Value = model . Shybool;
            parameters [ 42 ] . Value = model . Szbool;
            parameters [ 43 ] . Value = model . Cdbbool;
            parameters [ 44 ] . Value = model . TvnOnebool;
            parameters [ 45 ] . Value = model . Hfbool;
            parameters [ 46 ] . Value = model . ZaOnebool;
            parameters [ 47 ] . Value = model . FfaOnebool;
            parameters [ 48 ] . Value = model . ZfOnebool;
            parameters [ 49 ] . Value = model . SfOnebool;
            parameters [ 50 ] . Value = model . ShyOnebool;
            parameters [ 51 ] . Value = model . SzOnebool;
            parameters [ 52 ] . Value = model . Informationbool;
            parameters [ 53 ] . Value = model . Stockpilebool;
            parameters [ 54 ] . Value = model . Freightbool;
            parameters [ 55 ] . Value = model . RebateSumBool;
            parameters [ 56 ] . Value = model . WithSkinSumbool;
            parameters [ 57 ] . Value = model . PortpriceSumBool;
            parameters [ 58 ] . Value = model . FreightSumbool;
            parameters [ 59 ] . Value = model . Purchasingunits;
            parameters [ 60 ] . Value = model . Purchasingcontacts;
            parameters [ 61 ] . Value = model . Purchasecontractnumber;
            parameters [ 62 ] . Value = model . Demandbool;
            parameters [ 63 ] . Value = model . DemandSideBank;
            parameters [ 64 ] . Value = model . PaymentUnit;
            parameters [ 65 ] . Value = model . RequiredAccount;
            parameters [ 66 ] . Value = model . SupplierContact;
            parameters [ 67 ] . Value = model . SupplierContactId;
            parameters [ 68 ] . Value = model . DemandContact;
            parameters [ 69 ] . Value = model . DemandContactId;
            parameters [ 70 ] . Value = model . PurchasingunitsId;
            parameters [ 71 ] . Value = model . PurchasingcontactsId;
            parameters [ 72 ] . Value = model . SupplierAbbreviation;
            parameters [ 73 ] . Value = model . DemandAbbreviation;
            parameters [ 74 ] . Value = model . CNumbering;
            parameters [ 75 ] . Value = model . RabZy;
            parameters [ 76 ] . Value = model . RabZz;
            parameters[77].Value = model.overflow;
            //parameters [ 77 ] . Value = model . MoneyYFK;
            SQLString . Add ( strSql . ToString ( ) ,parameters );

            foreach ( FishEntity . SalesRequisitionBodyEntity list in modeList )
            {
                add_body ( list ,SQLString ,strSql );
                if ( !string . IsNullOrEmpty ( list . CodeNumZdi ) )
                    edit_zdi ( SQLString ,strSql ,list );
                if ( !string . IsNullOrEmpty ( list . CodeNumHq ) )
                    edit_hq ( SQLString ,strSql ,list );
            }

            return MySqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 回写销售单号到自定义标准表
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="list"></param>
        void edit_zdi ( Hashtable SQLString ,StringBuilder strSql ,FishEntity . SalesRequisitionBodyEntity list )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE t_CustomStandardTable SET xsCode='{0}' WHERE code='{1}'" ,list . NumberingOne ,list . CodeNumZdi );
            SQLString . Add ( strSql ,null );
        }

        /// <summary>
        /// 回写行情定价单表
        /// </summary>
        /// <param name="SQLString"></param>
        /// <param name="strSql"></param>
        /// <param name="list"></param>
        void edit_hq ( Hashtable SQLString ,StringBuilder strSql ,FishEntity . SalesRequisitionBodyEntity list )
        {
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE t_QuotationPriceList SET codeNumSales='{0}' WHERE code='{1}'" ,list . NumberingOne ,list . CodeNumZdi );
            SQLString . Add ( strSql ,null );
        }

        public bool Exists_code(string code)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from t_processstate where Numbering=@Numbering and xssqExBool=1 ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = code;
            return MySqlHelper.Exists(strsql.ToString(), parameter);
        }
        /// <summary>
        /// 是否所属
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="createman"></param>
        /// <returns></returns>
        public bool ExistsUpdateOrDelete(string Numbering, string createman)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from t_salesorder where Numbering=@Numbering and createman=@createman ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = Numbering;
            parameter[1].Value = createman;
            return MySqlHelper.Exists(strsql.ToString(), parameter);
        }
        void add_body(FishEntity.SalesRequisitionBodyEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("INSERT INTO t_happening (");
            strSql.Append( "NumberingOne,code,product_id,productname,Funit,Variety,Quantity,Amonut,unitprice,db,tvn,za,ffa,zf,sf,shy,sz,cdb,tvnOne,hf,cm,zjh,tdh,pp,Country,zaOne,ffaOne,zfOne,sfOne,shyOne,szOne,codeNumZdi,codeNumHq) " );
            strSql.Append("VALUES (");
            strSql.Append( "@NumberingOne,@code,@product_id,@productname,@Funit,@Variety,@Quantity,@Amonut,@unitprice,@db,@tvn,@za,@ffa,@zf,@sf,@shy,@sz,@cdb,@tvnOne,@hf,@cm,@zjh,@tdh,@pp,@Country,@zaOne,@ffaOne,@zfOne,@sfOne,@shyOne,@szOne,@codeNumZdi,@codeNumHq)" );
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,200),
                new MySqlParameter("@product_id",MySqlDbType.VarChar,45),
                new MySqlParameter("@productname",MySqlDbType.VarChar,45),
                new MySqlParameter("@Funit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Variety",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.Decimal,45),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@db",MySqlDbType.VarChar,45),
                new MySqlParameter("@tvn",MySqlDbType.VarChar,45),
                new MySqlParameter("@za",MySqlDbType.VarChar,45),
                new MySqlParameter("@ffa",MySqlDbType.VarChar,45),
                new MySqlParameter("@zf",MySqlDbType.VarChar,45),
                new MySqlParameter("@sf",MySqlDbType.VarChar,45),
                new MySqlParameter("@shy",MySqlDbType.VarChar,45),
                new MySqlParameter("@sz",MySqlDbType.VarChar,45),
                new MySqlParameter("@cdb",MySqlDbType.VarChar,45),
                new MySqlParameter("@tvnOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@hf",MySqlDbType.VarChar,45),
                new MySqlParameter("@cm",MySqlDbType.VarChar,45),
                new MySqlParameter("@zjh",MySqlDbType.VarChar,45),
                new MySqlParameter("@tdh",MySqlDbType.VarChar,45),
                new MySqlParameter("@pp",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@zaOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@ffaOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@zfOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@sfOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@shyOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@szOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@Amonut",MySqlDbType.Decimal,45),
                new MySqlParameter("@NumberingOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeNumZdi",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeNumHq",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = list.code;
            parameter[1].Value = list.product_id;
            parameter[2].Value = list.productname;
            parameter[3].Value = list.Funit;
            parameter[4].Value = list.Variety;
            parameter[5].Value = list.Quantity;
            parameter[6].Value = list.unitprice;
            parameter[7].Value = list.db;
            parameter[8].Value = list.tvn;
            parameter[9].Value = list.za;
            parameter[10].Value = list.ffa;
            parameter[11].Value = list.zf;
            parameter[12].Value = list.sf;
            parameter[13].Value = list.shy;
            parameter[14].Value = list.sz;
            parameter[15].Value = list.cdb;
            parameter[16].Value = list.tvnOne;
            parameter[17].Value = list.hf;
            parameter[18].Value = list.cm;
            parameter[19].Value = list.zjh;
            parameter[20].Value = list.tdh;
            parameter[21].Value = list.pp;
            parameter[22].Value = list.Country;
            parameter[23].Value = list.ZaOne;
            parameter[24].Value = list.FfaOne;
            parameter[25].Value = list.ZfOne;
            parameter[26].Value = list.SfOne;
            parameter[27].Value = list.ShyOne;
            parameter[28].Value = list.SzOne;
            parameter[29].Value = list.Amonut;
            parameter[30].Value = list.NumberingOne;
            parameter [ 31 ] . Value = list . CodeNumZdi;
            parameter [ 32 ] . Value = list . CodeNumHq;
            SQLString .Add(strSql, parameter);
        }

        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modeList"></param>
        /// <returns></returns>
        public bool Update(FishEntity.SalesRequisitionEntity model, List<FishEntity.SalesRequisitionBodyEntity> modeList)
        {
            Hashtable SQLString = new Hashtable();
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_salesorder set ");
            strSql.Append("code=@code,");
            strSql.Append("supplier = @supplier,");
            strSql.Append("SupplierContact = @SupplierContact,");
            strSql.Append("SupplierContactId = @SupplierContactId,");
            strSql.Append("DemandContact = @DemandContact,");
            strSql.Append("DemandContactId = @DemandContactId,");
            strSql.Append("DemandSideBank = @DemandSideBank,");
            strSql.Append("PaymentUnit = @PaymentUnit,");
            strSql.Append("RequiredAccount = @RequiredAccount,");
            strSql.Append("Purchasingunits = @Purchasingunits,");
            strSql.Append("PurchasingunitsId=@PurchasingunitsId,");
            strSql.Append("Purchasingcontacts = @Purchasingcontacts,");
            strSql.Append("PurchasingcontactsId=@PurchasingcontactsId,");
            strSql.Append("Purchasecontractnumber = @Purchasecontractnumber,");
            strSql.Append("supplierId = @supplierId,");
            strSql.Append("demand = @demand,");
            strSql.Append("demandId = @demandId,");
            strSql.Append("Signdate = @Signdate,");
            strSql.Append("Signplace = @Signplace,");
            strSql.Append("SupplierAbbreviation=@SupplierAbbreviation,");
            strSql.Append("DemandAbbreviation=@DemandAbbreviation,");
            strSql.Append("deIndex = @deIndex,");
            strSql.Append("rebate = @rebate,");
            strSql.Append("overflow=@overflow,");
            strSql.Append("rebateBool = @rebateBool,");
            strSql.Append("Portprice = @Portprice,");
            strSql.Append("PortpriceBool = @PortpriceBool,");
            strSql.Append("CountryBool = @CountryBool,");
            strSql.Append("transport = @transport,");
            strSql.Append("deadline = @deadline,");
            strSql.Append("Freight = @Freight,");
            strSql.Append("CNumbering = @CNumbering,");
            strSql.Append("delivery = @delivery,");
            strSql.Append("dt = @dt,");
            strSql.Append("dty = @dty,");
            strSql.Append("lxt = @lxt,");
            strSql.Append("lxty = @lxty,");
            strSql.Append("Settlementmethod = @Settlementmethod,");
            strSql.Append("payment = @payment,");
            strSql.Append("Bank = @Bank,");
            strSql.Append("Settlementmethod = @Settlementmethod,");
            strSql.Append("Bank = @Bank,");
            strSql.Append("Receipt = @Receipt,");
            strSql.Append("accountnumber = @accountnumber,");
            strSql.Append("remart = @remart,");
            strSql.Append("modifytime = @modifytime,");
            strSql.Append("modifyman = @modifyman, ");
            strSql.Append("WithSkin=@WithSkin,");
            strSql.Append("WithSkinbool=@WithSkinbool, ");
            strSql.Append("Supplierbool=@Supplierbool,");
            strSql.Append("Demandbool=@Demandbool, ");
            strSql.Append("dbbool=@dbbool, ");
            strSql.Append("tvnbool=@tvnbool, ");
            strSql.Append("zabool=@zabool, ");
            strSql.Append("ffabool=@ffabool, ");
            strSql.Append("zfbool=@zfbool, ");
            strSql.Append("sfbool=@sfbool, ");
            strSql.Append("shybool=@shybool, ");
            strSql.Append("szbool=@szbool, ");
            strSql.Append("cdbbool=@cdbbool, ");
            strSql.Append("tvnOnebool=@tvnOnebool, ");
            strSql.Append("hfbool=@hfbool, ");
            strSql.Append("zaOnebool=@zaOnebool, ");
            strSql.Append("ffaOnebool=@ffaOnebool, ");
            strSql.Append("zfOnebool=@zfOnebool, ");
            strSql.Append("sfOnebool=@sfOnebool, ");
            strSql.Append("shyOnebool=@shyOnebool, ");
            strSql.Append("szOnebool=@szOnebool, ");
            strSql.Append("informationbool=@informationbool, ");
            strSql.Append("Stockpilebool=@Stockpilebool, ");
            strSql.Append("Freightbool=@Freightbool, ");
            strSql.Append("rebateSumBool=@rebateSumBool, ");
            strSql.Append("WithSkinSumbool=@WithSkinSumbool, ");
            strSql.Append("PortpriceSumBool=@PortpriceSumBool, ");
            strSql . Append ( "FreightSumbool=@FreightSumbool," );
            strSql . Append ( "rabZy=@rabZy," );
            strSql . Append ( "rabZz=@rabZz " );
            strSql . Append ( " where id = @id" );
            MySqlParameter[] parameters = {
                new MySqlParameter("@code",MySqlDbType.VarChar,200),
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplierId",MySqlDbType.VarChar,45),
                new MySqlParameter("@demand",MySqlDbType.VarChar,45),
                new MySqlParameter("@demandId",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdate",MySqlDbType.DateTime),
                new MySqlParameter("@Signplace",MySqlDbType.VarChar,45),
                new MySqlParameter("@deIndex",MySqlDbType.Bit,45),
                new MySqlParameter("@rebate",MySqlDbType.Decimal,45),
                new MySqlParameter("@rebateBool",MySqlDbType.Bit,45),
                new MySqlParameter("@Portprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@PortpriceBool",MySqlDbType.Bit,45),
                new MySqlParameter("@CountryBool",MySqlDbType.Bit,45),
                new MySqlParameter("@transport",MySqlDbType.VarChar,150),
                new MySqlParameter("@deadline",MySqlDbType.Date),
                new MySqlParameter("@Freight",MySqlDbType.Decimal,45),
                new MySqlParameter("@delivery",MySqlDbType.VarChar,45),
                new MySqlParameter("@dt",MySqlDbType.Decimal,45),
                new MySqlParameter("@dty",MySqlDbType.Decimal,45),
                new MySqlParameter("@lxt",MySqlDbType.Decimal,45),
                new MySqlParameter("@lxty",MySqlDbType.Decimal,45),
                new MySqlParameter("@Settlementmethod",MySqlDbType.VarChar,50),
                new MySqlParameter("@payment",MySqlDbType.Date),
                new MySqlParameter("@Bank",MySqlDbType.VarChar,100),
                new MySqlParameter("@Receipt",MySqlDbType.VarChar,100),
                new MySqlParameter("@accountnumber",MySqlDbType.VarChar,100),
                new MySqlParameter("@remart",MySqlDbType.VarChar,100),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@WithSkin",MySqlDbType.VarChar,45),
                new MySqlParameter("@WithSkinbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Supplierbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Demandbool",MySqlDbType.Bit,45),
                new MySqlParameter("@dbbool",MySqlDbType.Bit,45),
                new MySqlParameter("@tvnbool",MySqlDbType.Bit,45),
                new MySqlParameter("@zabool",MySqlDbType.Bit,45),
                new MySqlParameter("@ffabool",MySqlDbType.Bit,45),
                new MySqlParameter("@zfbool",MySqlDbType.Bit,45),
                new MySqlParameter("@sfbool",MySqlDbType.Bit,45),
                new MySqlParameter("@shybool",MySqlDbType.Bit,45),
                new MySqlParameter("@szbool",MySqlDbType.Bit,45),
                new MySqlParameter("@cdbbool",MySqlDbType.Bit,45),
                new MySqlParameter("@tvnOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@hfbool",MySqlDbType.Bit,45),
                new MySqlParameter("@zaOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@ffaOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@zfOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@sfOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@shyOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@szOnebool",MySqlDbType.Bit,45),
                new MySqlParameter("@informationbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Stockpilebool",MySqlDbType.Bit,45),
                new MySqlParameter("@Freightbool",MySqlDbType.Bit,45),
                new MySqlParameter("@rebateSumBool",MySqlDbType.Bit,45),
                new MySqlParameter("@WithSkinSumbool",MySqlDbType.Bit,45),
                new MySqlParameter("@PortpriceSumBool",MySqlDbType.Bit,45),
                new MySqlParameter("@FreightSumbool",MySqlDbType.Bit,45),
                new MySqlParameter("@Purchasingunits",MySqlDbType.VarChar,45),
                new MySqlParameter("@Purchasingcontacts",MySqlDbType.VarChar,45),
                new MySqlParameter("@Purchasecontractnumber",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandSideBank",MySqlDbType.VarChar,100),
                new MySqlParameter("@PaymentUnit",MySqlDbType.VarChar,100),
                new MySqlParameter("@RequiredAccount",MySqlDbType.VarChar,100),
                new MySqlParameter("@SupplierContact",MySqlDbType.VarChar,45),
                new MySqlParameter("@SupplierContactId",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandContact",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandContactId",MySqlDbType.VarChar,45),
                new MySqlParameter("@PurchasingunitsId",MySqlDbType.VarChar,45),
                new MySqlParameter("@PurchasingcontactsId",MySqlDbType.VarChar,45),
                new MySqlParameter("@id",MySqlDbType.Int64,11),
                new MySqlParameter("@SupplierAbbreviation",MySqlDbType.VarChar,45),
                new MySqlParameter("@DemandAbbreviation",MySqlDbType.VarChar,45),
                new MySqlParameter("@CNumbering",MySqlDbType.VarChar,100),
                new MySqlParameter("@rabZy",MySqlDbType.Bit),
                new MySqlParameter("@rabZz",MySqlDbType.Bit),
                new MySqlParameter("@overflow",MySqlDbType.Decimal,45)
            };
            parameters[0].Value = model.code;
            parameters[1].Value = model.supplier;
            parameters[2].Value = model.supplierId;
            parameters[3].Value = model.demand;
            parameters[4].Value = model.demandId;
            parameters[5].Value = model.Signdate;
            parameters[6].Value = model.Signplace;
            parameters[7].Value = model.deIndex;
            parameters[8].Value = model.rebate;
            parameters[9].Value = model.rebateBool;
            parameters[10].Value = model.Portprice;
            parameters[11].Value = model.PortpriceBool;
            parameters[12].Value = model.CountryBool;
            parameters[13].Value = model.transport;
            parameters[14].Value = model.deadline;
            parameters[15].Value = model.Freight;
            parameters[16].Value = model.delivery;
            parameters[17].Value = model.dt;
            parameters[18].Value = model.dty;
            parameters[19].Value = model.lxt;
            parameters[20].Value = model.lxty;
            parameters[21].Value = model.Settlementmethod;
            parameters[22].Value = model.payment;
            parameters[23].Value = model.Bank;
            parameters[24].Value = model.Receipt;
            parameters[25].Value = model.accountnumber;
            parameters[26].Value = model.remart;
            parameters[27].Value = model.modifytime;
            parameters[28].Value = model.modifyman;
            parameters[29].Value = model.WithSkin;
            parameters[30].Value = model.WithSkinbool;
            parameters[32 - 1].Value = model.Supplierbool;
            parameters[33 - 1].Value = model.Demandbool;
            parameters[34 - 1].Value = model.Dbbool;
            parameters[35 - 1].Value = model.Tvnbool;
            parameters[36 - 1].Value = model.Zabool;
            parameters[37 - 1].Value = model.Ffabool;
            parameters[38 - 1].Value = model.Zfbool;
            parameters[39 - 1].Value = model.Sfbool;
            parameters[40 - 1].Value = model.Shybool;
            parameters[41 - 1].Value = model.Szbool;
            parameters[42 - 1].Value = model.Cdbbool;
            parameters[43 - 1].Value = model.TvnOnebool;
            parameters[44 - 1].Value = model.Hfbool;
            parameters[45 - 1].Value = model.ZaOnebool;
            parameters[46 - 1].Value = model.FfaOnebool;
            parameters[47 - 1].Value = model.ZfOnebool;
            parameters[48 - 1].Value = model.SfOnebool;
            parameters[49 - 1].Value = model.ShyOnebool;
            parameters[50 - 1].Value = model.SzOnebool;
            parameters[51 - 1].Value = model.Informationbool;
            parameters[52 - 1].Value = model.Stockpilebool;
            parameters[53 - 1].Value = model.Freightbool;
            parameters[54 - 1].Value = model.RebateSumBool;
            parameters[55 - 1].Value = model.WithSkinSumbool;
            parameters[56 - 1].Value = model.PortpriceSumBool;
            parameters[57 - 1].Value = model.FreightSumbool;
            parameters[58 - 1].Value = model.Purchasingunits;
            parameters[59 - 1].Value = model.Purchasingcontacts;
            parameters[60 - 1].Value = model.Purchasecontractnumber;
            parameters[61 - 1].Value = model.DemandSideBank;
            parameters[62 - 1].Value = model.PaymentUnit;
            parameters[63 - 1].Value = model.RequiredAccount;
            parameters[64 - 1].Value = model.SupplierContact;
            parameters[65 - 1].Value = model.SupplierContactId;
            parameters[66 - 1].Value = model.DemandContact;
            parameters[67 - 1].Value = model.DemandContactId;
            parameters[68 - 1].Value = model.PurchasingunitsId;
            parameters[69 - 1].Value = model.PurchasingcontactsId;
            parameters[70 - 1].Value = model.id;
            parameters[71-1].Value = model.SupplierAbbreviation;
            parameters[72-1].Value = model.DemandAbbreviation;
            parameters[73 - 1].Value = model.CNumbering;
            parameters [ 73 ] . Value = model . RabZy;
            parameters [ 74 ] . Value = model . RabZz;
            parameters[75].Value = model.overflow;
            //parameters [ 75 ] . Value = model . MoneyYFK;
            SQLString .Add(strSql.ToString(), parameters);


            foreach (FishEntity.SalesRequisitionBodyEntity list in modeList)
            {
                if (Exists(list.NumberingOne, list.product_id) == false)
                    add_body(list, SQLString, strSql);
                else
                    edit_body(list, SQLString, strSql);

                if ( !string . IsNullOrEmpty ( list . CodeNumZdi ) )
                    edit_zdi ( SQLString ,strSql ,list );
                if ( !string . IsNullOrEmpty ( list . CodeNumHq ) )
                    edit_hq ( SQLString ,strSql ,list );

            }

            DataSet ds = MySqlHelper.Query("SELECT product_id FROM t_happening WHERE code='" + model.code + "' and NumberingOne='"+model.Numbering+"'");
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                FishEntity.SalesRequisitionBodyEntity list = new FishEntity.SalesRequisitionBodyEntity();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.Bank = list.product_id = dt.Rows[i]["product_id"].ToString();
                    list = modeList.Find((k) =>
                {
                    return k.product_id.Equals(model.Bank);
                });
                    if (list == null)
                    {
                        delete_body(model.Numbering, model.Bank, SQLString, strSql);
                    }
                }
            }

            return MySqlHelper.ExecuteSqlTran(SQLString);
        }

        void edit_body(FishEntity.SalesRequisitionBodyEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("UPDATE t_happening SET ");
            strSql.Append("code=@code,");
            strSql.Append("productname=@productname,");
            strSql.Append("Funit=@Funit,");
            strSql.Append("Variety=@Variety,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("Amonut=@Amonut,");
            strSql.Append("unitprice=@unitprice,");
            strSql.Append("db=@db,");
            strSql.Append("tvn=@tvn,");
            strSql.Append("za=@za,");
            strSql.Append("ffa=@ffa,");
            strSql.Append("zf=@zf,");
            strSql.Append("sf=@sf,");
            strSql.Append("shy=@shy,");
            strSql.Append("sz=@sz,");
            strSql.Append("cdb=@cdb,");
            strSql.Append("tvnOne=@tvnOne,");
            strSql.Append("hf=@hf,");
            strSql.Append("cm=@cm,");
            strSql.Append("zjh=@zjh,");
            strSql.Append("tdh=@tdh,");
            strSql.Append("pp=@pp,");
            strSql.Append("Country=@Country, ");
            strSql.Append("zaOne=@zaOne, ");
            strSql.Append("ffaOne=@ffaOne, ");
            strSql.Append("zfOne=@zfOne, ");
            strSql.Append("sfOne=@sfOne, ");
            strSql.Append("shyOne=@shyOne, ");
            strSql.Append("szOne=@szOne,");
            strSql . Append ( "codeNumZdi=@codeNumZdi, " );
            strSql . Append ( "codeNumHq=@codeNumHq " );
            strSql .Append("WHERE NumberingOne=@NumberingOne AND ");
            strSql.Append("product_id=@product_id");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,200),
                new MySqlParameter("@product_id",MySqlDbType.VarChar,45),
                new MySqlParameter("@productname",MySqlDbType.VarChar,45),
                new MySqlParameter("@Funit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Variety",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.Decimal,45),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@db",MySqlDbType.VarChar,45),
                new MySqlParameter("@tvn",MySqlDbType.VarChar,45),
                new MySqlParameter("@za",MySqlDbType.VarChar,45),
                new MySqlParameter("@ffa",MySqlDbType.VarChar,45),
                new MySqlParameter("@zf",MySqlDbType.VarChar,45),
                new MySqlParameter("@sf",MySqlDbType.VarChar,45),
                new MySqlParameter("@shy",MySqlDbType.VarChar,45),
                new MySqlParameter("@sz",MySqlDbType.VarChar,45),
                new MySqlParameter("@cdb",MySqlDbType.VarChar,45),
                new MySqlParameter("@tvnOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@hf",MySqlDbType.VarChar,45),
                new MySqlParameter("@cm",MySqlDbType.VarChar,45),
                new MySqlParameter("@zjh",MySqlDbType.VarChar,45),
                new MySqlParameter("@tdh",MySqlDbType.VarChar,45),
                new MySqlParameter("@pp",MySqlDbType.VarChar,45),
                new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@zaOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@ffaOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@zfOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@sfOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@shyOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@szOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@Amonut",MySqlDbType.Decimal,45),
                new MySqlParameter("@NumberingOne",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeNumZdi",MySqlDbType.VarChar,45),
                new MySqlParameter("@codeNumHq",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = list.code;
            parameter[1].Value = list.product_id;
            parameter[2].Value = list.productname;
            parameter[3].Value = list.Funit;
            parameter[4].Value = list.Variety;
            parameter[5].Value = list.Quantity;
            parameter[6].Value = list.unitprice;
            parameter[7].Value = list.db;
            parameter[8].Value = list.tvn;
            parameter[9].Value = list.za;
            parameter[10].Value = list.ffa;
            parameter[11].Value = list.zf;
            parameter[12].Value = list.sf;
            parameter[13].Value = list.shy;
            parameter[14].Value = list.sz;
            parameter[15].Value = list.cdb;
            parameter[16].Value = list.tvnOne;
            parameter[17].Value = list.hf;
            parameter[18].Value = list.cm;
            parameter[19].Value = list.zjh;
            parameter[20].Value = list.tdh;
            parameter[21].Value = list.pp;
            parameter[22].Value = list.Country;
            parameter[23].Value = list.ZaOne;
            parameter[24].Value = list.FfaOne;
            parameter[25].Value = list.ZfOne;
            parameter[26].Value = list.SfOne;
            parameter[27].Value = list.ShyOne;
            parameter[28].Value = list.SzOne;
            parameter[29].Value = list.Amonut;
            parameter[30].Value = list.NumberingOne;
            parameter [ 31 ] . Value = list . CodeNumZdi;
            parameter [ 32 ] . Value = list . CodeNumHq;

            SQLString .Add(strSql, parameter);
        }

        void delete_body(string NumberingOne, string id, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("DELETE FROM t_happening ");
            strSql.Append("WHERE NumberingOne=@NumberingOne AND product_id=@product_id");
            MySqlParameter[] parameter = {
                new MySqlParameter("@NumberingOne",MySqlDbType.VarChar,200),
                new MySqlParameter("@product_id",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = NumberingOne;
            parameter[1].Value = id;

            SQLString.Add(strSql, parameter);
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string NumberingOne, string product_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_happening");
            strSql.Append(" where NumberingOne=@NumberingOne and product_id=@product_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@NumberingOne", MySqlDbType.VarChar,200),
            new MySqlParameter("@product_id", MySqlDbType.VarChar,45)};
            parameters[0].Value = NumberingOne;
            parameters[1].Value = product_id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在此预售合同
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool Exist(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM t_salesorder ");
            strSql.Append("WHERE Numbering=@Numbering");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = Numbering;

            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }
        public bool ExistCode(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT count(1) FROM t_salesrcontract ");
            strSql.Append("WHERE Numbering=@Numbering");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = Numbering;

            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }

        /*销售数据表*/
        /// <summary>
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public DataTable getCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from t_product order by code");

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }

        /// <summary>
        /// 获取采购合同编号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from t_salesorder order by code");

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append( "select a.delivery,a.Numbering,CNumbering,a.createman,product_id,a.code,date_format(Signdate,'%Y%m%d')as Signdate,Purchasingunits,d.shortname as GFshortname,c.shortname as XFshortname,PurchasingunitsId,Purchasingcontacts,PurchasingcontactsId,Purchasecontractnumber,Signplace,SupplierAbbreviation,DemandAbbreviation,supplier,SupplierContact,SupplierContactId,DemandContact,DemandContactId,supplierId,DemandSideBank,PaymentUnit,RequiredAccount,demand,demandId,productname,Funit,Variety,Quantity,unitprice,Amonut,a.Freight,db,tvn,za,ffa,zf,sf,shy,sz,cdb,zaOne,ffaOne,zfOne,sfOne,shyOne,szOne,tvnOne,hf,cm,zjh,tdh,rebate,WithSkin,Portprice,b.Country,pp,transport,date_format(deadline,'%Y%m%d')as deadline,Settlementmethod,date_format(payment,'%Y%m%d')as payment,a.Bank,Receipt,accountnumber from t_salesorder a left join t_happening b on a.code=b.code inner JOIN t_company c on a.demand=c.fullname inner JOIN t_company d on a.supplier=d.fullname " );
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }

        /// <summary>
        /// 获取剩余预付款
        /// </summary>
        /// <param name="codeNumContract"></param>
        /// <returns></returns>
        public decimal getMoneyYFK ( string codeNumContract )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( " select sum(ifnull(a.moneyYuk,0))-sum(ifnull(b.moneyOfYFK,0)) money from t_paymentrequisition a left join t_paymentrequisitiondetail b on a.`code`=b.`code`  where a.purchasecode='{0}'" ,codeNumContract );

            DataTable dt = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( dt != null || dt . Rows . Count > 0 )
                return string . IsNullOrEmpty ( dt . Rows [ 0 ] [ "money" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( dt . Rows [ 0 ] [ "money" ] . ToString ( ) );
            else
                return 0;
        }

    }
}
