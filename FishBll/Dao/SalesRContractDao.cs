using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
    public class SalesRContractDao
    {
        public SalesRContractDao() { }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select count(*) from t_SalesRContract where ContractCode=@ContractCode");
            MySqlParameter[] parameter = {
                new MySqlParameter("@ContractCode",MySqlDbType.VarChar,200)
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
            strsql.Append("select count(*) from t_SalesRContract where Numbering=@Numbering");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200)
            };
            parameter[0].Value = Numbering;
            return MySqlHelper.Exists(strsql.ToString(), parameter);
        }
        public int Add(FishEntity.SalesRContractEntity model, List<FishEntity.productsituationEntity> modeList) {
            StringBuilder strsql = new StringBuilder();            Hashtable SQLString = new Hashtable();
            strsql.Append("insert into t_salesrcontract(Numbering,Signdate,Signplace,supplier,demand,createman,createtime,modifyman,modifytime,ContractCode)values(@Numbering,@Signdate,@Signplace,@supplier,@demand,@createman,@createtime,@modifyman,@modifytime,@ContractCode)");
            MySqlParameter[] parameters ={
                new MySqlParameter("@ContractCode",MySqlDbType.VarChar,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@Signdate",MySqlDbType.DateTime),
                new MySqlParameter("@Signplace",MySqlDbType.VarChar,45),
                new MySqlParameter("@supplier",MySqlDbType.VarChar,45),
                new MySqlParameter("@demand",MySqlDbType.VarChar,45),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@createtime",MySqlDbType.DateTime),
                new MySqlParameter("@modifyman",MySqlDbType.VarChar,45),
                new MySqlParameter("@modifytime",MySqlDbType.DateTime)
            };
            parameters[0].Value = model.ContractCode;
            parameters[1].Value = model.Numbering;
            parameters[2].Value = model.Signdate;
            parameters[3].Value = model.Signplace;
            parameters[4].Value = model.Supplier;
            parameters[5].Value = model.Demand;
            parameters[6].Value = model.Createman;
            parameters[7].Value = model.Createtime;
            parameters[8].Value = model.Modifyman;
            parameters[9].Value = model.Modifytime;
            SQLString.Add(strsql.ToString(), parameters);
            foreach (FishEntity.productsituationEntity list in modeList)
            {
                add_body(list, SQLString, strsql);
            }
            if (MySqlHelper.ExecuteSqlTran(SQLString))
            {
                strsql = new StringBuilder();
                strsql.AppendFormat("select id from t_SalesRContract where ContractCode='{0}' and Numbering='{1}'", model.ContractCode,model.Numbering);

                DataTable dt = MySqlHelper.Query(strsql.ToString()).Tables[0];
                if (dt != null && dt.Rows.Count > 0)
                    return string.IsNullOrEmpty(dt.Rows[0]["id"].ToString()) == true ? 0 : Convert.ToInt32(dt.Rows[0]["id"].ToString());
                else
                    return 0;
            }
            else
                return 0;
        }
        void add_body(FishEntity.productsituationEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("INSERT INTO t_productsituation (");
            strSql.Append("Numbering,code,product_id,productname,Funit,Variety,Quantity,Amonut,unitprice) ");
            strSql.Append("VALUES (");
            strSql.Append("@Numbering,@code,@product_id,@productname,@Funit,@Variety,@Quantity,@Amonut,@unitprice)");
            MySqlParameter[] parameter = {
                new MySqlParameter("@product_id",MySqlDbType.VarChar,45),
                new MySqlParameter("@productname",MySqlDbType.VarChar,45),
                new MySqlParameter("@Funit",MySqlDbType.VarChar,45),
                new MySqlParameter("@Variety",MySqlDbType.VarChar,45),
                new MySqlParameter("@Quantity",MySqlDbType.Decimal,45),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,45),
                new MySqlParameter("@Amonut",MySqlDbType.Decimal,45),
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45),
                new MySqlParameter("@code",MySqlDbType.VarChar,45),
            };
            parameter[0].Value = list.Product_id;
            parameter[1].Value = list.Productname;
            parameter[2].Value = list.Funit;
            parameter[3].Value = list.Variety;
            parameter[4].Value = list.Quantity;
            parameter[5].Value = list.Unitprice;
            parameter[6].Value = list.Amonut;
            parameter[7].Value = list.Numbering;
            parameter[8].Value = list.Code;
            SQLString.Add(strSql, parameter);
        }
        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modeList"></param>
        /// <returns></returns>
        public bool Update(FishEntity.SalesRContractEntity model, List<FishEntity.productsituationEntity> modeList)
        {
            Hashtable SQLString = new Hashtable();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_salesrcontract set ");
            strSql.Append("ContractCode=@ContractCode,");
            strSql.Append("Signdate=@Signdate,");
            strSql.Append("Signplace=@Signplace,");
            strSql.Append("supplier=@supplier,");
            strSql.Append("demand=@demand,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("modifytime=@modifytime ");
            strSql.Append(" where id = @id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@ContractCode",model.ContractCode),
                new MySqlParameter("@Signdate",model.Signdate),
                new MySqlParameter("@Signplace",model.Signplace),
                new MySqlParameter("@supplier",model.Supplier),
                new MySqlParameter("@demand",model.Demand),
                new MySqlParameter("@modifyman",model.Modifyman),
                new MySqlParameter("@modifytime",model.Modifytime),
                new MySqlParameter("@id",model.Id),
            };
            SQLString.Add(strSql.ToString(), parameters);


            foreach (FishEntity.productsituationEntity list in modeList)
            {
                if (Exists(list.Numbering, list.Product_id) == false)
                    add_body(list, SQLString, strSql);
                else
                    edit_body(list, SQLString, strSql);
            }
            DataSet ds = MySqlHelper.Query("SELECT product_id FROM t_productsituation WHERE code='" + model.ContractCode + "'"+ " and Numbering='"+model.Numbering+"'");
            DataTable dt = ds.Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                FishEntity.productsituationEntity list = new FishEntity.productsituationEntity();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model.Product_id = list.Product_id = dt.Rows[i]["product_id"].ToString();
                    list = modeList.Find((k) =>
                    {
                        return k.Product_id.Equals(model.Product_id);
                    });
                    if (list == null)
                    {
                        delete_body(model.Numbering, model.Product_id, SQLString, strSql);
                    }
                }
            }
            return MySqlHelper.ExecuteSqlTran(SQLString);
        }
        void delete_body(string NumberingOne, string id, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("DELETE FROM t_productsituation ");
            strSql.Append("WHERE Numbering=@Numbering AND product_id=@product_id");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,200),
                new MySqlParameter("@product_id",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = NumberingOne;
            parameter[1].Value = id;

            SQLString.Add(strSql, parameter);
        }
        void edit_body(FishEntity.productsituationEntity list, Hashtable SQLString, StringBuilder strSql)
        {
            strSql = new StringBuilder();
            strSql.Append("UPDATE t_productsituation SET ");
            strSql.Append("code=@code,");
            strSql.Append("product_id=@product_id,");
            strSql.Append("productname=@productname,");
            strSql.Append("Funit=@Funit,");
            strSql.Append("Variety=@Variety,");
            strSql.Append("Quantity=@Quantity,");
            strSql.Append("unitprice=@unitprice,");
            strSql.Append("amonut=@amonut ");
            strSql.Append("WHERE Numbering=@Numbering ");
            MySqlParameter[] parameter = {
                new MySqlParameter("@code",list.Code),
                new MySqlParameter("@product_id",list.Product_id),
                new MySqlParameter("@productname",list.Productname),
                new MySqlParameter("@Funit",list.Funit),
                new MySqlParameter("@Variety",list.Variety),
                new MySqlParameter("@Quantity",list.Quantity),
                new MySqlParameter("@unitprice",list.Unitprice),
                new MySqlParameter("@amonut",list.Amonut),
                new MySqlParameter("@Numbering",list.Numbering),
            };

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
            strSql.Append("select count(1) from t_productsituation");
            strSql.Append(" where Numbering=@Numbering and product_id=@product_id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@Numbering", MySqlDbType.VarChar,200),
            new MySqlParameter("@product_id", MySqlDbType.VarChar,45)};
            parameters[0].Value = NumberingOne;
            parameters[1].Value = product_id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_where"></param>
        /// <returns></returns>
        public FishEntity.SalesRContractEntity GetList(string _where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,Numbering,Signdate,Signplace,supplier,demand,ContractCode  from t_salesrcontract ");
            if (_where.Trim() != "")
            {
                strSql.Append(" where " + _where);
            }
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            if (ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
                return null;
        }
        public static FishEntity.SalesRContractEntity DataRowToModel(DataRow row)
        {
            FishEntity.SalesRContractEntity model = new FishEntity.SalesRContractEntity();

            if (row != null)
            {
                if (row["Numbering"] != null && row["Numbering"].ToString() != "")
                {
                    model.Numbering = row["Numbering"].ToString();
                }
                if (row["ContractCode"] != null && row["ContractCode"].ToString() != "")
                {
                    model.ContractCode = row["ContractCode"].ToString();
                }
                if (row["demand"] != null && row["demand"].ToString() != "")
                {
                    model.Demand = row["demand"].ToString();
                }
                if (row["supplier"] != null && row["supplier"].ToString() != "")
                {
                    model.Supplier = row["supplier"].ToString();
                }
                if (row["Signplace"] != null && row["Signplace"].ToString() != "")
                {
                    model.Signplace = row["Signplace"].ToString();
                }
                if (row["Signdate"] != null && row["Signdate"].ToString() != "")
                {
                    model.Signdate =DateTime.Parse(row["Signdate"].ToString());
                }
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.Id =int.Parse(row["id"].ToString());
                }
            }
            return model;
        }
        public List<FishEntity.productsituationEntity> modellist(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM t_productsituation ");
            strSql.Append("WHERE Numbering=@Numbering");
            MySqlParameter[] parameter = {
                new MySqlParameter("@Numbering",MySqlDbType.VarChar,45)
            };
            parameter[0].Value = Numbering;

            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameter);
            DataTable dt = ds.Tables[0];
            List<FishEntity.productsituationEntity> modelList = new List<FishEntity.productsituationEntity>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    modelList.Add(getModel(dt.Rows[i]));
                }
                return modelList;
            }
            else
                return null;
        }
        public FishEntity.productsituationEntity getModel(DataRow row)
        {
            FishEntity.productsituationEntity _model = new FishEntity.productsituationEntity();

            if (row != null)
            {
                if (row["id"]!=null&row["id"].ToString()!="")
                {
                    _model.Id = row["id"].ToString();
                }
                if (row["Numbering"] != null)
                {
                    _model.Numbering = row["Numbering"].ToString();
                }
                if (row["code"] != null & row["code"].ToString() != "")
                {
                    _model.Code = row["code"].ToString();
                }
                if (row["product_id"] != null & row["product_id"].ToString() != "")
                {
                    _model.Product_id = row["product_id"].ToString();
                }
                if (row["productname"] != null & row["productname"].ToString() != "")
                {
                    _model.Productname = row["productname"].ToString();
                }
                if (row["Funit"] != null & row["Funit"].ToString() != "")
                {
                    _model.Funit = row["Funit"].ToString();
                }
                if (row["Variety"] != null & row["Variety"].ToString() != "")
                {
                    _model.Variety = row["Variety"].ToString();
                }
                if (row["Quantity"] != null && row["Quantity"].ToString() != "")
                {
                    _model.Quantity = decimal.Parse(row["Quantity"].ToString());
                }
                if (row["unitprice"] != null && row["unitprice"].ToString() != "")
                {
                    _model.Unitprice = decimal.Parse(row["unitprice"].ToString());
                }
                if (row["Amonut"] != null && row["Amonut"].ToString() != "")
                {
                    _model.Amonut = decimal.Parse(row["Amonut"].ToString());
                }
            }
            return _model;
        }
        /// <summary>
        /// 新增自动带入
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public DataTable getxxsqd(string Numbering)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.id,a.Numbering,a.Signdate,a.Signplace,a.supplier,a.demand,a.code,b.product_id,b.productname,b.Funit,b.Variety,b.Quantity,b.unitprice,b.Amonut FROM	t_salesorder a LEFT JOIN t_happening b ON a.Numbering = b.NumberingOne ");
            strSql.Append("where " + Numbering);
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            return ds.Tables[0];
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
    }
}
