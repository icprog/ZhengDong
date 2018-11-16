using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections;

namespace FishBll.Dao
{
    public class PresaleRequisitionDao
    {
        /// <summary>
        /// 获取合同号
        /// </summary>
        /// <returns></returns>
        public string codeNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT MAX(code) code FROM t_presalerequisition ");

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
        public DataTable getCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from t_product order by code");

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        public DataTable getTable(string StrWhere) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT *,yfNum*yfPrice as weight	FROM	t_presalerequisition a inner join t_sgsindicators b on a.code=b.codeNum ");
            strSql.Append(" where " + StrWhere);
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            return ds.Tables[0];
        }
        public DataTable getcodeNum()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code from t_presalerequisition order by code");

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getDate()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT now() t");

            DataSet da = MySqlHelper.Query(strSql.ToString());

            return Convert.ToDateTime(da.Tables[0].Rows[0]["t"].ToString());
        }

        /// <summary>
        /// 获取单头数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)//
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,supplierid,supplier,demandid,demand,Signdate,Signplace,rebate,rebateBool,Portprice,PortpriceBool,Country,CountryBool,testIndex,ModeOfTransport,DeliveryDeadline,Freight,DeliveryPlace,Tonday,TonRMB,InteretDat,InteretRMB,BanDan,Signdt,Bond,SupAc,Suplimit,Openbank,CollectUnit,AcountNum,createtime,createman,modifytime,modifyman from t_presalerequisition ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where  1=1 " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableOne(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select code,supplier,demand,Signdate,Signplace,case when rebateBool=0 then '' else CONCAT('回扣：',rebate) end rebate,case when PortpriceBool=0 then '' else CONCAT('港价：',Portprice) end Portprice,ModeOfTransport,DeliveryDeadline,Freight,DeliveryPlace,BanDan,Openbank,CollectUnit,AcountNum,testIndex,Tonday,TonRMB,InteretDat,InteretRMB from t_presalerequisition  ");
            strSql.AppendFormat("where code='{0}'", code);

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTwo(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT yfId,yfName,yfUnit,yfNum,yfPrice,yfNum*yfPrice priceMoney FROM t_sgsindicators ");
            strSql.AppendFormat("WHERE codeNum='{0}'", code);

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTre(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT CONCAT(yfName,'SGS指标：蛋白≥',yfdb,',TVN≤',yftvn,',组胺≤',yfza,',FFA≤',yfFFA,',脂肪≤',yfzf,',水分≤',yfsf,',沙和盐≤',yfshy,',沙子≤',yfs,',国外SGS,不得发霉、有异味或掺杂其它杂物,且应符合国家质量标准。') yfName,case when b.testIndex=0 then '' else CONCAT(yfName,'国内检测指标：粗蛋白≤',yfcdb,',TVN≤',yftvntwo,',灰份≤',yfhf) end yfcdb,CONCAT(yfName,'船名：',yfcm,' 提单号：',yftdh,' 桩脚号：',yfzjh,' 国别：',yfCountry,' 品牌：',yfpp) yfcm FROM t_sgsindicators a LEFT JOIN t_presalerequisition b on a.codeNum=b.code ");
            strSql.AppendFormat("WHERE codeNum='{0}'", code);

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static FishEntity.PresaleRequisitionHeadEntity DataRowToModel(DataRow row)
        {
            FishEntity.PresaleRequisitionHeadEntity model = new FishEntity.PresaleRequisitionHeadEntity();
            if (row != null)
            {
                if (row["id"].ToString() != "" && row["id"] != null)
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["code"] != null && row["code"].ToString() != "")
                {
                    model.code = row["code"].ToString();
                }
                if (row["supplierid"] != null && row["supplierid"].ToString() != "")
                {
                    model.supplierid = row["supplierid"].ToString();
                }
                if (row["supplier"] != null && row["supplier"].ToString() != "")
                {
                    model.supplier = row["supplier"].ToString();
                }
                if (row["demandid"] != null && row["demandid"].ToString() != "")
                {
                    model.demandid = row["demandid"].ToString();
                }
                if (row["demand"] != null && row["demand"].ToString() != "")
                {
                    model.demand = row["demand"].ToString();
                }
                if (row["Signdate"] != null && row["Signdate"].ToString() != "")
                {
                    model.Signdate = DateTime.Parse(row["Signdate"].ToString());
                }
                if (row["Signplace"] != null && row["Signplace"].ToString() != "")
                {
                    model.Signplace = row["Signplace"].ToString();
                }
                if (row["rebate"] != null && row["rebate"].ToString() != "")
                {
                    model.rebate = decimal.Parse(row["rebate"].ToString());
                }
                if (row["rebateBool"] != null && row["rebateBool"].ToString() != "")
                {
                    model.rebateBool = Boolean.Parse(row["rebateBool"].ToString());
                }
                if (row["Portprice"] != null && row["Portprice"].ToString() != "")
                {
                    model.Portprice = decimal.Parse(row["Portprice"].ToString());
                }
                if (row["PortpriceBool"] != null && row["PortpriceBool"].ToString() != "")
                {
                    model.PortpriceBool = bool.Parse(row["PortpriceBool"].ToString());
                }
                if (row["Country"] != null && row["Country"].ToString() != "")
                {
                    model.Country = row["Country"].ToString();
                }
                if (row["CountryBool"] != null && row["CountryBool"].ToString() != "")
                {
                    model.CountryBool = bool.Parse(row["CountryBool"].ToString());
                }
                if (row["testIndex"] != null && row["testIndex"].ToString() != "")
                {
                    model.testIndex = bool.Parse(row["testIndex"].ToString());
                }
                if (row["ModeOfTransport"] != null && row["ModeOfTransport"].ToString() != "")
                {
                    model.ModeOfTransport = row["ModeOfTransport"].ToString();
                }
                if (row["DeliveryDeadline"] != null && row["DeliveryDeadline"].ToString() != "")
                {
                    model.DeliveryDeadline = DateTime.Parse(row["DeliveryDeadline"].ToString());
                }
                if (row["Freight"] != null && row["Freight"].ToString() != "")
                {
                    model.Freight = decimal.Parse(row["Freight"].ToString());
                }
                if (row["DeliveryPlace"] != null && row["DeliveryPlace"].ToString() != "")
                {
                    model.DeliveryPlace = row["DeliveryPlace"].ToString();
                }
                if (row["Tonday"] != null && row["Tonday"].ToString() != "")
                {
                    model.Tonday = decimal.Parse(row["Tonday"].ToString());
                }
                if (row["TonRMB"] != null && row["TonRMB"].ToString() != "")
                {
                    model.TonRMB = decimal.Parse(row["TonRMB"].ToString());
                }
                if (row["InteretDat"] != null && row["InteretDat"].ToString() != "")
                {
                    model.InteretDat = decimal.Parse(row["InteretDat"].ToString());
                }
                if (row["InteretRMB"] != null && row["InteretRMB"].ToString() != "")
                {
                    model.InteretRMB = decimal.Parse(row["InteretRMB"].ToString());
                }
                if (row["BanDan"] != null && row["BanDan"].ToString() != "")
                {
                    model.BanDan = row["BanDan"].ToString();
                }
                if (row["Signdt"].ToString() != "" && row["Signdt"] != null)
                {
                    model.Signdt = DateTime.Parse(row["Signdt"].ToString());
                }
                if (row["Bond"] != null && row["Bond"].ToString() != "")
                {
                    model.Bond = decimal.Parse(row["Bond"].ToString());
                }
                if (row["SupAc"] != null && row["SupAc"].ToString() != "")
                {
                    model.SupAc = row["SupAc"].ToString();
                }
                if (row["Suplimit"] != null && row["Suplimit"].ToString() != "")
                {
                    model.Suplimit = int.Parse(row["Suplimit"].ToString());
                }
                if (row["Openbank"] != null && row["Openbank"].ToString() != "")
                {
                    model.Openbank = row["Openbank"].ToString();
                }
                if (row["CollectUnit"] != null && row["CollectUnit"].ToString() != "")
                {
                    model.CollectUnit = row["CollectUnit"].ToString();
                }
                if (row["AcountNum"] != null && row["AcountNum"].ToString() != "")
                {
                    model.AcountNum = row["AcountNum"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["createman"] != null && row["createman"].ToString() != "")
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["modifyman"] != null && row["modifyman"].ToString() != "")
                {
                    model.modifyman = row["modifyman"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获取一表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity.PresaleRequisitionBodyEntity> GetTableOne(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.id,codeNum,yfId,yfName,yfUnit,yfVarieties,yfNum,yfPrice,yfNum*yfPrice weight FROM  t_presalerequisition a left join t_sgsindicators b on a.code=b.codeNum ");
            strSql.Append("WHERE a.id=" + id);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.PresaleRequisitionBodyEntity> modelList = new List<FishEntity.PresaleRequisitionBodyEntity>();
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["id"].ToString()))
                    return modelList;
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    FishEntity.PresaleRequisitionBodyEntity _modelOne;
                    for (int i = 0; i < count; i++)
                    {
                        _modelOne = GetTableOne(ds.Tables[0].Rows[i]);
                        modelList.Add(_modelOne);
                    }
                }
            }

            return modelList;
        }

        /// <summary>
        /// 获取一表数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public FishEntity.PresaleRequisitionBodyEntity GetTableOne(DataRow row)
        {
            FishEntity.PresaleRequisitionBodyEntity _model = new FishEntity.PresaleRequisitionBodyEntity();

            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                    _model.id = int.Parse(row["id"].ToString());
                if (row["codeNum"] != null && row["codeNum"].ToString() != "")
                    _model.codeNum = row["codeNum"].ToString();
                if (row["yfId"] != null && row["yfId"].ToString() != "")
                    _model.yfId = row["yfId"].ToString();
                if (row["yfName"] != null && row["yfName"].ToString() != "")
                    _model.yfName = row["yfName"].ToString();
                if (row["yfUnit"] != null && row["yfUnit"].ToString() != "")
                    _model.yfUnit = row["yfUnit"].ToString();
                if (row["yfVarieties"] != null && row["yfVarieties"].ToString() != "")
                    _model.yfVarieties = row["yfVarieties"].ToString();
                if (row["yfNum"] != null && row["yfNum"].ToString() != "")
                    _model.yfNum = decimal.Parse(row["yfNum"].ToString());
                if (row["yfPrice"] != null && row["yfPrice"].ToString() != "")
                    _model.yfPrice = decimal.Parse(row["yfPrice"].ToString());
                if (row["weight"] != null && row["weight"].ToString() != "")
                    _model.weight = decimal.Parse(row["weight"].ToString());
            }

            return _model;
        }

        /// <summary>
        /// 获取二表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity.PresaleRequisitionBodyEntity> GetTableTwo(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.id,codeNum,yfId,yfdb,yftvn,yfza,yfFFA,yfzf,yfsf,yfshy,yfs FROM  t_presalerequisition a left join t_sgsindicators b on a.code=b.codeNum ");
            strSql.Append("WHERE a.id=" + id);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.PresaleRequisitionBodyEntity> modelList = new List<FishEntity.PresaleRequisitionBodyEntity>();
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["id"].ToString()))
                    return modelList;
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    FishEntity.PresaleRequisitionBodyEntity _modelOne;
                    for (int i = 0; i < count; i++)
                    {
                        _modelOne = GetTableTwo(ds.Tables[0].Rows[i]);
                        modelList.Add(_modelOne);
                    }
                }
            }

            return modelList;
        }
        /// <summary>
        /// 获取二表数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public FishEntity.PresaleRequisitionBodyEntity GetTableTwo(DataRow row)
        {
            FishEntity.PresaleRequisitionBodyEntity _model = new FishEntity.PresaleRequisitionBodyEntity();

            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                    _model.id = int.Parse(row["id"].ToString());
                if (row["codeNum"] != null && row["codeNum"].ToString() != "")
                    _model.codeNum = row["codeNum"].ToString();
                if (row["yfId"] != null && row["yfId"].ToString() != "")
                    _model.yfId = row["yfId"].ToString();
                if (row["yfdb"] != null && row["yfdb"].ToString() != "")
                    _model.yfdb = decimal.Parse(row["yfdb"].ToString());
                if (row["yftvn"] != null && row["yftvn"].ToString() != "")
                    _model.yftvn = decimal.Parse(row["yftvn"].ToString());
                if (row["yfza"] != null && row["yfza"].ToString() != "")
                    _model.yfza = decimal.Parse(row["yfza"].ToString());
                if (row["yfFFA"] != null && row["yfFFA"].ToString() != "")
                    _model.yfFFA = decimal.Parse(row["yfFFA"].ToString());
                if (row["yfzf"] != null && row["yfzf"].ToString() != "")
                    _model.yfzf = decimal.Parse(row["yfzf"].ToString());
                if (row["yfsf"] != null && row["yfsf"].ToString() != "")
                    _model.yfsf = decimal.Parse(row["yfsf"].ToString());
                if (row["yfshy"] != null && row["yfshy"].ToString() != "")
                    _model.yfshy = decimal.Parse(row["yfshy"].ToString());
                if (row["yfs"] != null && row["yfs"].ToString() != "")
                    _model.yfs = decimal.Parse(row["yfs"].ToString());
            }

            return _model;
        }

        /// <summary>
        /// 获取三表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity.PresaleRequisitionBodyEntity> GetTableTre(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.id,codeNum,yfId,yfcdb,yftvntwo,yfhf FROM  t_presalerequisition a left join t_sgsindicators b on a.code=b.codeNum ");
            strSql.Append("WHERE a.id=" + id);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.PresaleRequisitionBodyEntity> modelList = new List<FishEntity.PresaleRequisitionBodyEntity>();
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["id"].ToString()))
                    return modelList;
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    FishEntity.PresaleRequisitionBodyEntity _modelOne;
                    for (int i = 0; i < count; i++)
                    {
                        _modelOne = GetTableTre(ds.Tables[0].Rows[i]);
                        modelList.Add(_modelOne);
                    }
                }
            }

            return modelList;
        }
        /// <summary>
        /// 获取三表数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public FishEntity.PresaleRequisitionBodyEntity GetTableTre(DataRow row)
        {
            FishEntity.PresaleRequisitionBodyEntity _model = new FishEntity.PresaleRequisitionBodyEntity();

            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                    _model.id = int.Parse(row["id"].ToString());
                if (row["codeNum"] != null && row["codeNum"].ToString() != "")
                    _model.codeNum = row["codeNum"].ToString();
                if (row["yfId"] != null && row["yfId"].ToString() != "")
                    _model.yfId = row["yfId"].ToString();
                if (row["yfcdb"] != null && row["yfcdb"].ToString() != "")
                    _model.yfcdb = decimal.Parse(row["yfcdb"].ToString());
                if (row["yftvntwo"] != null && row["yftvntwo"].ToString() != "")
                    _model.yftvntwo = decimal.Parse(row["yftvntwo"].ToString());
                if (row["yfhf"] != null && row["yfhf"].ToString() != "")
                    _model.yfhf = decimal.Parse(row["yfhf"].ToString());
            }

            return _model;
        }

        /// <summary>
        /// 获取四表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity.PresaleRequisitionBodyEntity> GetTableFor(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT b.id,codeNum,yfId,yfcm,yfzjh,yftdh,yfpp,yfCountry FROM  t_presalerequisition a left join t_sgsindicators b on a.code=b.codeNum ");
            strSql.Append("WHERE a.id=" + id);

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.PresaleRequisitionBodyEntity> modelList = new List<FishEntity.PresaleRequisitionBodyEntity>();
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["id"].ToString()))
                    return modelList;
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    FishEntity.PresaleRequisitionBodyEntity _modelOne;
                    for (int i = 0; i < count; i++)
                    {
                        _modelOne = GetTableFor(ds.Tables[0].Rows[i]);
                        modelList.Add(_modelOne);
                    }
                }
            }

            return modelList;
        }
        /// <summary>
        /// 获取四表数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public FishEntity.PresaleRequisitionBodyEntity GetTableFor(DataRow row)
        {
            FishEntity.PresaleRequisitionBodyEntity _model = new FishEntity.PresaleRequisitionBodyEntity();

            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                    _model.id = int.Parse(row["id"].ToString());
                if (row["codeNum"] != null && row["codeNum"].ToString() != "")
                    _model.codeNum = row["codeNum"].ToString();
                if (row["yfId"] != null && row["yfId"].ToString() != "")
                    _model.yfId = row["yfId"].ToString();
                if (row["yfcm"] != null && row["yfcm"].ToString() != "")
                    _model.yfcm = row["yfcm"].ToString();
                if (row["yfzjh"] != null && row["yfzjh"].ToString() != "")
                    _model.yfzjh = row["yfzjh"].ToString();
                if (row["yftdh"] != null && row["yftdh"].ToString() != "")
                    _model.yftdh = row["yftdh"].ToString();
                if (row["yfpp"] != null && row["yfpp"].ToString() != "")
                    _model.yfpp = row["yfpp"].ToString();
                if (row["yfCountry"] != null && row["yfCountry"].ToString() != "")
                    _model.yfCountry = row["yfCountry"].ToString();
            }

            return _model;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete(int id, string code)
        {
            ArrayList SQLString = new ArrayList();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE FROM t_presalerequisition WHERE id=" + id);
            SQLString.Add(strSql.ToString());
            strSql = new StringBuilder();
            strSql.AppendFormat("DELETE FROM t_sgsindicators WHERE codeNum='{0}'", code);
            SQLString.Add(strSql.ToString());

            return MySqlHelper.ExecuteSqlTranBool(SQLString);
        }

        /// <summary>
        /// 获取鱼粉信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity.ProductEntity> getList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CODE,NAME,specification,nature,brand,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa,sgs_fat,sgs_water,sgs_sand,shipno,billofgoods,cornerno,warehouse from t_product ");
            if (!string.IsNullOrEmpty(strWhere))
                strSql.Append("where " + strWhere);

            DataSet set = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.ProductEntity> modelList = new List<FishEntity.ProductEntity>();
            int count = set.Tables[0].Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    FishEntity.ProductEntity _model = getPerson(set.Tables[0].Rows[i]);
                    modelList.Add(_model);
                }
            }

            return modelList;
        }

        protected FishEntity.ProductEntity getPerson(DataRow row)
        {
            FishEntity.ProductEntity model = new FishEntity.ProductEntity();

            if (row != null)
            {
                if (row["code"] != null && row["code"].ToString() != "")
                    model.code = row["code"].ToString();
                if (row["name"] != null && row["name"].ToString() != "")
                    model.name = row["name"].ToString();
                if (row["specification"] != null && row["specification"].ToString() != "")
                    model.specification = row["specification"].ToString();
                if (row["brand"] != null && row["brand"].ToString() != "")
                    model.brand = row["brand"].ToString();
                if (row["nature"] != null && row["nature"].ToString() != "")
                    model.nature = row["nature"].ToString();
                if (row["sgs_protein"] != null && row["sgs_protein"].ToString() != "")
                {
                    model.sgs_protein = decimal.Parse(row["sgs_protein"].ToString());
                }
                if (row["sgs_tvn"] != null && row["sgs_tvn"].ToString() != "")
                {
                    model.sgs_tvn = decimal.Parse(row["sgs_tvn"].ToString());
                }
                if (row["sgs_graypart"] != null && row["sgs_graypart"].ToString() != "")
                {
                    model.sgs_graypart = decimal.Parse(row["sgs_graypart"].ToString());
                }
                if (row["sgs_sandsalt"] != null && row["sgs_sandsalt"].ToString() != "")
                {
                    model.sgs_sandsalt = decimal.Parse(row["sgs_sandsalt"].ToString());
                }
                if (row["sgs_amine"] != null && row["sgs_amine"].ToString() != "")
                {
                    model.sgs_amine = decimal.Parse(row["sgs_amine"].ToString());
                }
                if (row["sgs_ffa"] != null && row["sgs_ffa"].ToString() != "")
                {
                    model.sgs_ffa = decimal.Parse(row["sgs_ffa"].ToString());
                }
                if (row["sgs_fat"] != null && row["sgs_fat"].ToString() != "")
                {
                    model.sgs_fat = decimal.Parse(row["sgs_fat"].ToString());
                }
                if (row["sgs_water"] != null && row["sgs_water"].ToString() != "")
                {
                    model.sgs_water = decimal.Parse(row["sgs_water"].ToString());
                }
                if (row["sgs_sand"] != null && row["sgs_sand"].ToString() != "")
                {
                    model.sgs_sand = decimal.Parse(row["sgs_sand"].ToString());
                }
                if (row["shipno"] !=null)
                {
                    model.shipno = row["shipno"].ToString();
                }
                if (row["billofgoods"] != null)
                {
                    model.billofgoods = row["billofgoods"].ToString();
                }
                if (row["cornerno"] != null)
                {
                    model.cornerno = row["cornerno"].ToString();
                }
                if (row["warehouse"] != null)
                {
                    model.warehouse = row["warehouse"].ToString();
                }
            }

            return model;
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Add(FishEntity.PresaleRequisitionHeadEntity _model, List<FishEntity.PresaleRequisitionBodyEntity> modelList)
        {
            Hashtable SQLSting = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO t_presalerequisition (");
            strSql.Append("code,supplierid,supplier,demandid,demand,Signdate,Signplace,rebate,rebateBool,Portprice,PortpriceBool,CountryBool,testIndex,ModeOfTransport,DeliveryDeadline,Freight,DeliveryPlace,Tonday,TonRMB,InteretDat,InteretRMB,BanDan,Signdt,Bond,SupAc,Suplimit,Openbank,CollectUnit,AcountNum,createtime,createman,modifytime,modifyman) ");
            strSql.Append("VALUES (");
            strSql.Append("@code,@supplierid,@supplier,@demandid,@demand,@Signdate,@Signplace,@rebate,@rebateBool,@Portprice,@PortpriceBool,@CountryBool,@testIndex,@ModeOfTransport,@DeliveryDeadline,@Freight,@DeliveryPlace,@Tonday,@TonRMB,@InteretDat,@InteretRMB,@BanDan,@Signdt,@Bond,@SupAc,@Suplimit,@Openbank,@CollectUnit,@AcountNum,@createtime,@createman,@modifytime,@modifyman)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplierid",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@demandid",MySqlDbType.VarChar,45),
                new MySqlParameter("@demand",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdate",MySqlDbType.Date),
                new MySqlParameter("@Signplace",MySqlDbType.VarChar,45),
                new MySqlParameter("@rebate",MySqlDbType.Decimal,45),
                new MySqlParameter("@rebateBool",MySqlDbType.Bit,45),
                new MySqlParameter("@Portprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@PortpriceBool",MySqlDbType.Bit,45),
                //new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@CountryBool",MySqlDbType.Bit,45),
                new MySqlParameter("@testIndex",MySqlDbType.Bit,45),
                new MySqlParameter("@ModeOfTransport",MySqlDbType.VarChar,45),
                new MySqlParameter("@DeliveryDeadline",MySqlDbType.Date),
                new MySqlParameter("@Freight",MySqlDbType.Decimal,45),
                new MySqlParameter("@DeliveryPlace",MySqlDbType.VarChar,100),
                new MySqlParameter("@Tonday",MySqlDbType.Decimal,45),
                new MySqlParameter("@TonRMB",MySqlDbType.Decimal,45),
                new MySqlParameter("@InteretDat",MySqlDbType.Decimal,45),
                new MySqlParameter("@InteretRMB",MySqlDbType.Decimal,45),
                new MySqlParameter("@BanDan",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdt",MySqlDbType.Date),
                new MySqlParameter("@Bond",MySqlDbType.Decimal,45),
                new MySqlParameter("@SupAc",MySqlDbType.VarChar,45),
                new MySqlParameter("@Suplimit",MySqlDbType.Int32,45),
                new MySqlParameter("@Openbank",MySqlDbType.VarChar,100),
                new MySqlParameter("@CollectUnit",MySqlDbType.VarChar,100),
                new MySqlParameter("@AcountNum",MySqlDbType.VarChar,100),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = _model.code;
            parameter[1].Value = _model.supplierid;
            parameter[2].Value = _model.supplier;
            parameter[3].Value = _model.demandid;
            parameter[4].Value = _model.demand;
            parameter[5].Value = _model.Signdate;
            parameter[6].Value = _model.Signplace;
            parameter[7].Value = _model.rebate;
            parameter[8].Value = _model.rebateBool;
            parameter[9].Value = _model.Portprice;
            parameter[10].Value = _model.PortpriceBool;
            //parameter [ 11 ] . Value = _model . Country;
            parameter[11].Value = _model.CountryBool;
            parameter[12].Value = _model.testIndex;
            parameter[13].Value = _model.ModeOfTransport;
            parameter[14].Value = _model.DeliveryDeadline;
            parameter[15].Value = _model.Freight;
            parameter[16].Value = _model.DeliveryPlace;
            parameter[17].Value = _model.Tonday;
            parameter[18].Value = _model.TonRMB;
            parameter[19].Value = _model.InteretDat;
            parameter[20].Value = _model.InteretRMB;
            parameter[21].Value = _model.BanDan;
            parameter[22].Value = _model.Signdt;
            parameter[23].Value = _model.Bond;
            parameter[24].Value = _model.SupAc;
            parameter[25].Value = _model.Suplimit;
            parameter[26].Value = _model.Openbank;
            parameter[27].Value = _model.CollectUnit;
            parameter[28].Value = _model.AcountNum;
            parameter[29].Value = _model.createtime;
            parameter[30].Value = _model.createman;
            parameter[31].Value = _model.modifytime;
            parameter[32].Value = _model.modifyman;
            SQLSting.Add(strSql, parameter);//

            foreach (FishEntity.PresaleRequisitionBodyEntity list in modelList)
            {
                list.codeNum = _model.code;
                list.createtime = _model.createtime;
                list.createman = _model.createman;
                list.modifytime = _model.modifytime;
                list.modifyman = _model.modifyman;
                add(list, strSql, SQLSting);
            }

            return MySqlHelper.ExecuteSqlTran(SQLSting);
        }

        void add(FishEntity.PresaleRequisitionBodyEntity list, StringBuilder strSql, Hashtable SQLString)
        {
            strSql = new StringBuilder();
            strSql.Append("INSERT INTO t_sgsindicators (");
            strSql.Append("codeNum,yfId,yfName,yfUnit,yfVarieties,yfNum,yfPrice,yfdb,yftvn,yfza,yfFFA,yfzf,yfsf,yfshy,yfs,yfcdb,yftvntwo,yfhf,yfcm,yfzjh,yftdh,yfpp,yfCountry,createtime,createman,modifytime,modifyman) ");
            strSql.Append("VALUES (");
            strSql.Append("@codeNum,@yfId,@yfName,@yfUnit,@yfVarieties,@yfNum,@yfPrice,@yfdb,@yftvn,@yfza,@yfFFA,@yfzf,@yfsf,@yfshy,@yfs,@yfcdb,@yftvntwo,@yfhf,@yfcm,@yfzjh,@yftdh,@yfpp,@yfCountry,@createtime,@createman,@modifytime,@modifyman)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@codeNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfName",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfVarieties",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfNum",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfPrice",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfdb",MySqlDbType.Decimal,45),
                new MySqlParameter("@yftvn",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfza",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfFFA",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfzf",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfsf",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfshy",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfs",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfcdb",MySqlDbType.Decimal,45),
                new MySqlParameter("@yftvntwo",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfhf",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfcm",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfzjh",MySqlDbType.VarChar,45),
                new MySqlParameter("@yftdh",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfpp",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfCountry",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.DateTime),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = list.codeNum;
            parameter[1].Value = list.yfId;
            parameter[2].Value = list.yfName;
            parameter[3].Value = list.yfUnit;
            parameter[4].Value = list.yfVarieties;
            parameter[5].Value = list.yfNum;
            parameter[6].Value = list.yfPrice;
            parameter[7].Value = list.yfdb;
            parameter[8].Value = list.yftvn;
            parameter[9].Value = list.yfza;
            parameter[10].Value = list.yfFFA;
            parameter[11].Value = list.yfzf;
            parameter[12].Value = list.yfsf;
            parameter[13].Value = list.yfshy;
            parameter[14].Value = list.yfs;
            parameter[15].Value = list.yfcdb;
            parameter[16].Value = list.yftvntwo;
            parameter[17].Value = list.yfhf;
            parameter[18].Value = list.yfcm;
            parameter[19].Value = list.yfzjh;
            parameter[20].Value = list.yftdh;
            parameter[21].Value = list.yfpp;
            parameter[22].Value = list.yfCountry;
            parameter[23].Value = list.createtime;
            parameter[24].Value = list.createman;
            parameter[25].Value = list.modifytime;
            parameter[26].Value = list.modifyman;

            SQLString.Add(strSql, parameter);
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Edit(FishEntity.PresaleRequisitionHeadEntity _model, List<FishEntity.PresaleRequisitionBodyEntity> modelList)
        {
            Hashtable SQLSting = new Hashtable();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE t_presalerequisition SET ");
            strSql.Append("supplierid=@supplierid,");
            strSql.Append("supplier=@supplier,");
            strSql.Append("demandid=@demandid,");
            strSql.Append("demand=@demand,");
            strSql.Append("Signdate=@Signdate,");
            strSql.Append("Signplace=@Signplace,");
            strSql.Append("rebate=@rebate,");
            strSql.Append("rebateBool=@rebateBool,");
            strSql.Append("Portprice=@Portprice,");
            strSql.Append("PortpriceBool=@PortpriceBool,");
            //strSql . Append ( "Country=@Country," );
            strSql.Append("CountryBool=@CountryBool,");
            strSql.Append("testIndex=@testIndex,");
            strSql.Append("ModeOfTransport=@ModeOfTransport,");
            strSql.Append("DeliveryDeadline=@DeliveryDeadline,");
            strSql.Append("Freight=@Freight,");
            strSql.Append("DeliveryPlace=@DeliveryPlace,");
            strSql.Append("TonRMB=@TonRMB,");
            strSql.Append("InteretDat=@InteretDat,");
            strSql.Append("InteretRMB=@InteretRMB,");
            strSql.Append("BanDan=@BanDan,");
            strSql.Append("Signdt=@Signdt,");
            strSql.Append("Bond=@Bond,");
            strSql.Append("SupAc=@SupAc,");
            strSql.Append("Suplimit=@Suplimit,");
            strSql.Append("Openbank=@Openbank,");
            strSql.Append("CollectUnit=@CollectUnit,");
            strSql.Append("AcountNum=@AcountNum,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifytime=@modifytime,");
            strSql.Append("modifytime=@modifytime ");
            strSql.Append("WHERE code=@code");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplierid",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@demandid",MySqlDbType.VarChar,45),
                new MySqlParameter("@demand",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdate",MySqlDbType.Date),
                new MySqlParameter("@Signplace",MySqlDbType.VarChar,45),
                new MySqlParameter("@rebate",MySqlDbType.Decimal,45),
                new MySqlParameter("@rebateBool",MySqlDbType.Bit,45),
                new MySqlParameter("@Portprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@PortpriceBool",MySqlDbType.Bit,45),
                //new MySqlParameter("@Country",MySqlDbType.VarChar,45),
                new MySqlParameter("@CountryBool",MySqlDbType.Bit,45),
                new MySqlParameter("@testIndex",MySqlDbType.Bit,45),
                new MySqlParameter("@ModeOfTransport",MySqlDbType.VarChar,45),
                new MySqlParameter("@DeliveryDeadline",MySqlDbType.Date),
                new MySqlParameter("@Freight",MySqlDbType.Decimal,45),
                new MySqlParameter("@DeliveryPlace",MySqlDbType.VarChar,100),
                new MySqlParameter("@Tonday",MySqlDbType.Decimal,45),
                new MySqlParameter("@TonRMB",MySqlDbType.Decimal,45),
                new MySqlParameter("@InteretDat",MySqlDbType.Decimal,45),
                new MySqlParameter("@InteretRMB",MySqlDbType.Decimal,45),
                new MySqlParameter("@BanDan",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdt",MySqlDbType.Date),
                new MySqlParameter("@Bond",MySqlDbType.Decimal,45),
                new MySqlParameter("@SupAc",MySqlDbType.VarChar,45),
                new MySqlParameter("@Suplimit",MySqlDbType.Int32,45),
                new MySqlParameter("@Openbank",MySqlDbType.VarChar,100),
                new MySqlParameter("@CollectUnit",MySqlDbType.VarChar,100),
                new MySqlParameter("@AcountNum",MySqlDbType.VarChar,100),
                new MySqlParameter("@createtime",MySqlDbType.Timestamp),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.Timestamp),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = _model.code;
            parameter[1].Value = _model.supplierid;
            parameter[2].Value = _model.supplier;
            parameter[3].Value = _model.demandid;
            parameter[4].Value = _model.demand;
            parameter[5].Value = _model.Signdate;
            parameter[6].Value = _model.Signplace;
            parameter[7].Value = _model.rebate;
            parameter[8].Value = _model.rebateBool;
            parameter[9].Value = _model.Portprice;
            parameter[10].Value = _model.PortpriceBool;
            //parameter [ 11 ] . Value = _model . Country;
            parameter[11].Value = _model.CountryBool;
            parameter[12].Value = _model.testIndex;
            parameter[13].Value = _model.ModeOfTransport;
            parameter[14].Value = _model.DeliveryDeadline;
            parameter[15].Value = _model.Freight;
            parameter[16].Value = _model.DeliveryPlace;
            parameter[17].Value = _model.Tonday;
            parameter[18].Value = _model.TonRMB;
            parameter[19].Value = _model.InteretDat;
            parameter[20].Value = _model.InteretRMB;
            parameter[21].Value = _model.BanDan;
            parameter[22].Value = _model.Signdt;
            parameter[23].Value = _model.Bond;
            parameter[24].Value = _model.SupAc;
            parameter[25].Value = _model.Suplimit;
            parameter[26].Value = _model.Openbank;
            parameter[27].Value = _model.CollectUnit;
            parameter[28].Value = _model.AcountNum;
            parameter[29].Value = _model.createtime;
            parameter[30].Value = _model.createman;
            parameter[31].Value = _model.modifytime;
            parameter[32].Value = _model.modifyman;
            SQLSting.Add(strSql, parameter);

            foreach (FishEntity.PresaleRequisitionBodyEntity list in modelList)
            {
                list.codeNum = _model.code;
                list.createtime = _model.createtime;
                list.createman = _model.createman;
                list.modifytime = _model.modifytime;
                list.modifyman = _model.modifyman;
                if (Exists(list.codeNum, list.yfId) == true)
                    edit(list, strSql, SQLSting);
                else
                    add(list, strSql, SQLSting);
            }

            DataSet ds = MySqlHelper.Query("select yfId from t_sgsindicators where codeNum='" + _model.code + "'");

            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    FishEntity.PresaleRequisitionBodyEntity list = new FishEntity.PresaleRequisitionBodyEntity();
                    _model.modifyman = list.yfId = dt.Rows[i]["yfId"].ToString();

                    list = modelList.Find((k) =>
                    {
                        return k.yfId.Equals(list.yfId);
                    });

                    if (list == null)
                    {
                        delete_edit(_model.code, _model.modifyman, strSql, SQLSting);
                    }

                }
            }

            return MySqlHelper.ExecuteSqlTran(SQLSting);

        }

        bool Exists(string codeName, string yfId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) COUN FROM t_sgsindicators ");
            strSql.Append("WHERE codeNum=@codeNum AND yfId=@yfId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@codeNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = codeName;
            parameter[1].Value = yfId;

            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }

        void edit(FishEntity.PresaleRequisitionBodyEntity list, StringBuilder strSql, Hashtable SQLString)
        {
            strSql = new StringBuilder();
            strSql.Append("UPDATE t_sgsindicators SET ");
            strSql.Append("yfName=@yfName,");
            strSql.Append("yfUnit=@yfUnit,");
            strSql.Append("yfVarieties=@yfVarieties,");
            strSql.Append("yfNum=@yfNum,");
            strSql.Append("yfPrice=@yfPrice,");
            strSql.Append("yfdb=@yfdb,");
            strSql.Append("yftvn=@yftvn,");
            strSql.Append("yfza=@yfza,");
            strSql.Append("yfFFA=@yfFFA,");
            strSql.Append("yfzf=@yfzf,");
            strSql.Append("yfsf=@yfsf,");
            strSql.Append("yfshy=@yfshy,");
            strSql.Append("yfs=@yfs,");
            strSql.Append("yfcdb=@yfcdb,");
            strSql.Append("yftvntwo=@yftvntwo,");
            strSql.Append("yfhf=@yfhf,");
            strSql.Append("yfcm=@yfcm,");
            strSql.Append("yfzjh=@yfzjh,");
            strSql.Append("yftdh=@yftdh,");
            strSql.Append("yfpp=@yfpp,");
            strSql.Append("yfCountry=@yfCountry,");
            strSql.Append("createtime=@createtime,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifytime=@modifytime,");
            strSql.Append("modifyman=@modifyman ");
            strSql.Append("WHERE codeNum=@codeNum AND ");
            strSql.Append("yfId=@yfId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@codeNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfName",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfUnit",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfVarieties",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfNum",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfPrice",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfdb",MySqlDbType.Decimal,45),
                new MySqlParameter("@yftvn",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfza",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfFFA",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfzf",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfsf",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfshy",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfs",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfcdb",MySqlDbType.Decimal,45),
                new MySqlParameter("@yftvntwo",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfhf",MySqlDbType.Decimal,45),
                new MySqlParameter("@yfcm",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfzjh",MySqlDbType.VarChar,45),
                new MySqlParameter("@yftdh",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfpp",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfCountry",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.DateTime),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = list.codeNum;
            parameter[1].Value = list.yfId;
            parameter[2].Value = list.yfName;
            parameter[3].Value = list.yfUnit;
            parameter[4].Value = list.yfVarieties;
            parameter[5].Value = list.yfNum;
            parameter[6].Value = list.yfPrice;
            parameter[7].Value = list.yfdb;
            parameter[8].Value = list.yftvn;
            parameter[9].Value = list.yfza;
            parameter[10].Value = list.yfFFA;
            parameter[11].Value = list.yfzf;
            parameter[12].Value = list.yfsf;
            parameter[13].Value = list.yfshy;
            parameter[14].Value = list.yfs;
            parameter[15].Value = list.yfcdb;
            parameter[16].Value = list.yftvntwo;
            parameter[17].Value = list.yfhf;
            parameter[18].Value = list.yfcm;
            parameter[19].Value = list.yfzjh;
            parameter[20].Value = list.yftdh;
            parameter[21].Value = list.yfpp;
            parameter[22].Value = list.yfCountry;
            parameter[23].Value = list.createtime;
            parameter[24].Value = list.createman;
            parameter[25].Value = list.modifytime;
            parameter[26].Value = list.modifyman;

            SQLString.Add(strSql, parameter);
        }

        void delete_edit(string codeNum, string yfId, StringBuilder strSql, Hashtable SQLString)
        {
            strSql = new StringBuilder();
            strSql.Append("DELETE FROM t_sgsindicators ");
            strSql.Append("WHERE codeNum=@codeNum and yfId=@yfId");
            MySqlParameter[] parameter = {
                new MySqlParameter("@codeNum",MySqlDbType.VarChar,45),
                new MySqlParameter("@yfId",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = codeNum;
            parameter[1].Value = yfId;

            SQLString.Add(strSql, parameter);
        }



        /*生成预销售合同*/

        /// <summary>
        /// 是否存在此合同
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public bool Exists(string codeNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM t_presalerequisition ");
            strSql.Append("WHERE code=@code");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,20)
            };
            parameter[0].Value = codeNum;

            return MySqlHelper.Exists(strSql.ToString(), parameter);
        }

        /// <summary>
        /// 获取单头数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public FishEntity.PresaleRequisitionHeadEntity GetHeadList(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,supplierid,supplier,demandid,demand,Signdate,Signplace,rebate,rebateBool,Portprice,PortpriceBool,Country,CountryBool,testIndex,ModeOfTransport,DeliveryDeadline,Freight,DeliveryPlace,Tonday,TonRMB,InteretDat,InteretRMB,BanDan,Signdt,Bond,SupAc,Suplimit,Openbank,CollectUnit,AcountNum,createtime,createman,modifytime,modifyman,Tonday,TonRMB,InteretDat,InteretRMB  from t_presalerequisition ");
            strSql.Append("WHERE code=@code");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = code;

            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameter);
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
                return null;
        }

        /// <summary>
        /// 获取单身数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity.PresaleRequisitionBodyEntity> GetBodyList(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT codeNum,yfId,yfName,yfUnit,yfVarieties,yfNum,yfPrice,yfNum*yfPrice weight,yfdb,yftvn,yfza,yfFFA,yfzf,yfsf,yfshy,yfs,yfcdb,yftvntwo,yfhf,yfcm,yfzjh,yftdh,yfpp FROM t_sgsindicators ");

            DataSet ds = MySqlHelper.Query(strSql.ToString());
            DataTable dt = ds.Tables[0];
            List<FishEntity.PresaleRequisitionBodyEntity> modelList = new List<FishEntity.PresaleRequisitionBodyEntity>();

            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(GetBody(dt.Rows[i]));
                }
            }

            return modelList;
        }

        public FishEntity.PresaleRequisitionBodyEntity GetBody(DataRow row)
        {
            FishEntity.PresaleRequisitionBodyEntity _model = new FishEntity.PresaleRequisitionBodyEntity();

            if (row != null)
            {
                if (row["codeNum"] != null && row["codeNum"].ToString() != "")
                    _model.codeNum = row["codeNum"].ToString();
                if (row["yfId"] != null && row["yfId"].ToString() != "")
                    _model.yfId = row["yfId"].ToString();
                if (row["yfName"] != null && row["yfName"].ToString() != "")
                    _model.yfName = row["yfName"].ToString();
                if (row["yfUnit"] != null && row["yfUnit"].ToString() != "")
                    _model.yfUnit = row["yfUnit"].ToString();
                if (row["yfVarieties"] != null && row["yfVarieties"].ToString() != "")
                    _model.yfVarieties = row["yfVarieties"].ToString();
                if (row["yfNum"] != null && row["yfNum"].ToString() != "")
                    _model.yfNum = decimal.Parse(row["yfNum"].ToString());
                if (row["yfPrice"] != null && row["yfPrice"].ToString() != "")
                    _model.yfPrice = decimal.Parse(row["yfPrice"].ToString());
                if (row["weight"] != null && row["weight"].ToString() != "")
                    _model.weight = decimal.Parse(row["weight"].ToString());
                if (row["yfdb"] != null && row["yfdb"].ToString() != "")
                    _model.yfdb = decimal.Parse(row["yfdb"].ToString());
                if (row["yftvn"] != null && row["yftvn"].ToString() != "")
                    _model.yftvn = decimal.Parse(row["yftvn"].ToString());
                if (row["yfza"] != null && row["yfza"].ToString() != "")
                    _model.yfza = decimal.Parse(row["yfza"].ToString());
                if (row["yfFFA"] != null && row["yfFFA"].ToString() != "")
                    _model.yfFFA = decimal.Parse(row["yfFFA"].ToString());
                if (row["yfzf"] != null && row["yfzf"].ToString() != "")
                    _model.yfzf = decimal.Parse(row["yfzf"].ToString());
                if (row["yfsf"] != null && row["yfsf"].ToString() != "")
                    _model.yfsf = decimal.Parse(row["yfsf"].ToString());
                if (row["yfshy"] != null && row["yfshy"].ToString() != "")
                    _model.yfshy = decimal.Parse(row["yfshy"].ToString());
                if (row["yfs"] != null && row["yfs"].ToString() != "")
                    _model.yfs = decimal.Parse(row["yfs"].ToString());
                if (row["yfcdb"] != null && row["yfcdb"].ToString() != "")
                    _model.yfcdb = decimal.Parse(row["yfcdb"].ToString());
                if (row["yftvntwo"] != null && row["yftvntwo"].ToString() != "")
                    _model.yftvntwo = decimal.Parse(row["yftvntwo"].ToString());
                if (row["yfhf"] != null && row["yfhf"].ToString() != "")
                    _model.yfhf = decimal.Parse(row["yfhf"].ToString());
                if (row["yfcm"] != null && row["yfcm"].ToString() != "")
                    _model.yfcm = row["yfcm"].ToString();
                if (row["yfzjh"] != null && row["yfzjh"].ToString() != "")
                    _model.yfzjh = row["yfzjh"].ToString();
                if (row["yftdh"] != null && row["yftdh"].ToString() != "")
                    _model.yftdh = row["yftdh"].ToString();
                if (row["yfpp"] != null && row["yfpp"].ToString() != "")
                    _model.yfpp = row["yfpp"].ToString();
            }

            return _model;
        }

    }
}
