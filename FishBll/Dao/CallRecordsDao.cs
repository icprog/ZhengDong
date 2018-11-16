using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CallRecordsDao
    {
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// 
        public DataSet GetSpot(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  from  v_callr ");
            if (false == string.IsNullOrEmpty(where))
            {
                strSql.Append(" where " + where);
            }
            return MySqlHelper.Query(strSql.ToString());
        }
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_callrecords");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }

        public bool Exists(string  code )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_callrecords");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar , 45)
			};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(FishEntity.CallRecordsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_callrecords(");
            strSql.Append("code,currentdate,nextdate,customercode,customer,customerlevel,linkmancode,linkman,address,mobile,requiredquantity,officetel,products,weekestimate,monthestimate,communicatecontent,createtime,createman,modifytime,modifyman,isdelete,telephone,buydate)");
            strSql.Append(" values (");
            strSql.Append("@code,@currentdate,@nextdate,@customercode,@customer,@customerlevel,@linkmancode,@linkman,@address,@mobile,@requiredquantity,@officetel,@products,@weekestimate,@monthestimate,@communicatecontent,@createtime,@createman,@modifytime,@modifyman,@isdelete,@telephone,@buydate);");
            strSql.Append("select LAST_INSERT_ID();");
            
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@currentdate", MySqlDbType.Timestamp),
					new MySqlParameter("@nextdate", MySqlDbType.Timestamp),
					new MySqlParameter("@customercode", MySqlDbType.VarChar,50),
					new MySqlParameter("@customer", MySqlDbType.VarChar,100),
					new MySqlParameter("@customerlevel", MySqlDbType.VarChar,45),
					new MySqlParameter("@linkmancode", MySqlDbType.VarChar,45),
					new MySqlParameter("@linkman", MySqlDbType.VarChar,45),
					new MySqlParameter("@address", MySqlDbType.VarChar,200),
					new MySqlParameter("@mobile", MySqlDbType.VarChar,100),
					new MySqlParameter("@requiredquantity", MySqlDbType.VarChar,100),
					new MySqlParameter("@officetel", MySqlDbType.VarChar,45),
					new MySqlParameter("@products", MySqlDbType.VarChar,45),
					new MySqlParameter("@weekestimate", MySqlDbType.VarChar,45),
					new MySqlParameter("@monthestimate", MySqlDbType.VarChar,45),
					new MySqlParameter("@communicatecontent", MySqlDbType.VarChar,500),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,2),  
                    new MySqlParameter("@telephone", MySqlDbType.VarChar,45) ,
                    new MySqlParameter("@buydate", MySqlDbType.VarChar,45)  
                                          };
            parameters[0].Value = model.code;
            parameters[1].Value = model.currentdate;
            parameters[2].Value = model.nextdate;
            parameters[3].Value = model.customercode;
            parameters[4].Value = model.customer;
            parameters[5].Value = model.customerlevel;
            parameters[6].Value = model.linkmancode;
            parameters[7].Value = model.linkman;
            parameters[8].Value = model.address;
            parameters[9].Value = model.mobile;
            parameters[10].Value = model.requiredquantity;
            parameters[11].Value = model.officetel;
            parameters[12].Value = model.products;
            parameters[13].Value = model.weekestimate;
            parameters[14].Value = model.monthestimate;
            parameters[15].Value = model.communicatecontent;
            parameters[16].Value = model.createtime;
            parameters[17].Value = model.createman;
            parameters[18].Value = model.modifytime;
            parameters[19].Value = model.modifyman;
            parameters[20].Value = model.isdelete;
            parameters[21].Value = model.telephone;
            parameters[22].Value = model.BuyDate;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FishEntity.CallRecordsEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_callrecords set ");
            strSql.Append("code=@code,");
            strSql.Append("customercode=@customercode,");
            strSql.Append("customer=@customer,");
            strSql.Append("customerlevel=@customerlevel,");
            strSql.Append("linkmancode=@linkmancode,");
            strSql.Append("linkman=@linkman,");
            strSql.Append("address=@address,");
            strSql.Append("mobile=@mobile,");
            strSql.Append("requiredquantity=@requiredquantity,");
            strSql.Append("officetel=@officetel,");
            strSql.Append("products=@products,");
            strSql.Append("weekestimate=@weekestimate,");
            strSql.Append("monthestimate=@monthestimate,");
            strSql.Append("communicatecontent=@communicatecontent,");
            strSql.Append("createman=@createman,");
            strSql.Append("modifyman=@modifyman,");
            strSql.Append("isdelete=@isdelete,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("buydate=@buydate,");
            strSql.Append("currentdate=@currentdate,");
            strSql.Append("nextdate=@nextdate");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@customercode", MySqlDbType.VarChar,50),
					new MySqlParameter("@customer", MySqlDbType.VarChar,100),
					new MySqlParameter("@customerlevel", MySqlDbType.VarChar,45),
					new MySqlParameter("@linkmancode", MySqlDbType.VarChar,45),
					new MySqlParameter("@linkman", MySqlDbType.VarChar,45),
					new MySqlParameter("@address", MySqlDbType.VarChar,200),
					new MySqlParameter("@mobile", MySqlDbType.VarChar,45),
					new MySqlParameter("@requiredquantity", MySqlDbType.VarChar,100),
					new MySqlParameter("@officetel", MySqlDbType.VarChar,45),
					new MySqlParameter("@products", MySqlDbType.VarChar,45),
					new MySqlParameter("@weekestimate", MySqlDbType.VarChar,45),
					new MySqlParameter("@monthestimate", MySqlDbType.VarChar,45),
					new MySqlParameter("@communicatecontent", MySqlDbType.VarChar,500),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,4),
                    new MySqlParameter("@telephone", MySqlDbType.VarChar,45),
                    new MySqlParameter("@buydate", MySqlDbType.VarChar,45),
                    new MySqlParameter("@currentdate", MySqlDbType.Timestamp),
					new MySqlParameter("@nextdate", MySqlDbType.Timestamp),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.code;
            parameters[1].Value = model.customercode;
            parameters[2].Value = model.customer;
            parameters[3].Value = model.customerlevel;
            parameters[4].Value = model.linkmancode;
            parameters[5].Value = model.linkman;
            parameters[6].Value = model.address;
            parameters[7].Value = model.mobile;
            parameters[8].Value = model.requiredquantity;
            parameters[9].Value = model.officetel;
            parameters[10].Value = model.products;
            parameters[11].Value = model.weekestimate;
            parameters[12].Value = model.monthestimate;
            parameters[13].Value = model.communicatecontent;
            parameters[14].Value = model.createman;
            parameters[15].Value = model.modifyman;
            parameters[16].Value = model.isdelete;
            parameters[17].Value = model.telephone;
            parameters[18].Value = model.BuyDate;
            parameters[19].Value = model.currentdate;
            parameters[20].Value = model.nextdate;
            parameters[21].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_callrecords ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_callrecords ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = MySqlHelper.ExecuteSql(strSql.ToString());
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
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.CallRecordsEntity GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,currentdate,nextdate,customercode,customer,customerlevel,linkmancode,linkman,address,mobile,requiredquantity,officetel,products,weekestimate,monthestimate,communicatecontent,createtime,createman,modifytime,modifyman,isdelete,telephone,buydate from t_callrecords ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
            parameters[0].Value = id;

            FishEntity.CallRecordsEntity model = new FishEntity.CallRecordsEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.CallRecordsEntity DataRowToModel(DataRow row)
        {
            FishEntity.CallRecordsEntity model = new FishEntity.CallRecordsEntity();
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
                if (row["currentdate"] != null && row["currentdate"].ToString() != "")
                {
                    model.currentdate = DateTime.Parse(row["currentdate"].ToString());
                }
                if (row["nextdate"] != null && row["nextdate"].ToString() != "")
                {
                    model.nextdate = DateTime.Parse(row["nextdate"].ToString());
                }
                if (row["customercode"] != null)
                {
                    model.customercode = row["customercode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                if (row["customerlevel"] != null)
                {
                    model.customerlevel = row["customerlevel"].ToString();
                }
                if (row["linkmancode"] != null)
                {
                    model.linkmancode = row["linkmancode"].ToString();
                }
                if (row["linkman"] != null)
                {
                    model.linkman = row["linkman"].ToString();
                }
                if (row["address"] != null)
                {
                    model.address = row["address"].ToString();
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                if (row["requiredquantity"] != null)
                {
                    model.requiredquantity = row["requiredquantity"].ToString();
                }
                if (row["officetel"] != null)
                {
                    model.officetel = row["officetel"].ToString();
                }
                if (row["products"] != null)
                {
                    model.products = row["products"].ToString();
                }
                if (row["weekestimate"] != null)
                {
                    model.weekestimate = row["weekestimate"].ToString();
                }
                if (row["monthestimate"] != null)
                {
                    model.monthestimate = row["monthestimate"].ToString();
                }
                if (row["communicatecontent"] != null)
                {
                   model.communicatecontent = row["communicatecontent"].ToString();
                }
                if (row["createtime"] != null && row["createtime"].ToString() != "")
                {
                    model.createtime = DateTime.Parse(row["createtime"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["modifytime"] != null && row["modifytime"].ToString() != "")
                {
                    model.modifytime = DateTime.Parse(row["modifytime"].ToString());
                }
                if (row["modifyman"] != null)
                {
                    model.modifyman = row["modifyman"].ToString();
                }
                if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                if (row["telephone"] != null)
                {
                    model.telephone = row["telephone"].ToString();
                }
                if (row["buydate"] != null&&row["buydate"].ToString()!="")
                {
                    model.BuyDate = row["buydate"].ToString();
                }
                
            }
            return model;
        }
        public FishEntity.CallRecordsEntity DataRowToModel22(DataRow row)
        {
            FishEntity.CallRecordsEntity model = new FishEntity.CallRecordsEntity();
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
                if (row["currentdate"] != null && row["currentdate"].ToString() != "")
                {
                    model.currentdate = DateTime.Parse(row["currentdate"].ToString());
                }
                if (row["customercode"] != null)
                {
                    model.customercode = row["customercode"].ToString();
                }
                if (row["customer"] != null)
                {
                    model.customer = row["customer"].ToString();
                }
                //if (row["customerlevel"] != null)
                //{
                //    model.customerlevel = row["customerlevel"].ToString();
                //}
                if (row["linkmancode"] != null)
                {
                    model.linkmancode = row["linkmancode"].ToString();
                }
                if (row["linkman"] != null)
                {
                    model.linkman = row["linkman"].ToString();
                }
                if (row["mobile"] != null)
                {
                    model.mobile = row["mobile"].ToString();
                }
                //if (row["isdelete"] != null && row["isdelete"].ToString() != "")
                //{
                //    model.isdelete = int.Parse(row["isdelete"].ToString());
                //}
                //if (row["telephone"] != null)
                //{
                //    model.telephone = row["telephone"].ToString();
                //}
                //if (row["buydate"] != null)
                //{
                //    model.buyDate = row["buydate"].ToString();
                //}
                if (row["callrecordid"] != null && row["callrecordid"].ToString() != "")
                {
                    model.callrecordid = int.Parse(row["callrecordid"].ToString());
                }
                if (row["no"] != null && row["no"].ToString() != "")
                {
                    model.no = int.Parse(row["no"].ToString());
                }
                if (row["nature"] != null)
                {
                    model.nature = row["nature"].ToString();
                }
                if (row["brand"] != null)
                {
                    model.brand = row["brand"].ToString();
                }
                if (row["specification"] != null)
                {
                    model.specification = row["specification"].ToString();
                }
                if (row["orderstate"] != null)
                {
                    model.orderstate = row["orderstate"].ToString();
                }
                //if (row["quoteprice"] != null && row["quoteprice"].ToString() != "")
                //{
                //    model.quoteprice = decimal.Parse(row["quoteprice"].ToString());
                //}
                 if (row["weight"] != null && row["weight"].ToString() != "")
                  {
                model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.saleprice = decimal.Parse(row["saleprice"].ToString());
                }
                if (row["paymethod"] != null)
                {
                    model.paymethod = row["paymethod"].ToString();
                }
                if (row["payperiod"] != null)
                {
                    model.payperiod = row["payperiod"].ToString();
                }
                if (row["domestic_protein"] != null && row["domestic_protein"].ToString() != "")
                {
                    model.domestic_protein = decimal.Parse(row["domestic_protein"].ToString());
                }
                if (row["domestic_tvn"] != null && row["domestic_tvn"].ToString() != "")
                {
                    model.domestic_tvn = decimal.Parse(row["domestic_tvn"].ToString());
                }
                if (row["domestic_graypart"] != null && row["domestic_graypart"].ToString() != "")
                {
                    model.domestic_graypart = decimal.Parse(row["domestic_graypart"].ToString());
                }
                if (row["domestic_sandsalt"] != null && row["domestic_sandsalt"].ToString() != "")
                {
                    model.domestic_sandsalt = decimal.Parse(row["domestic_sandsalt"].ToString());
                }
                if (row["domestic_sour"] != null && row["domestic_sour"].ToString() != "")
                {
                    model.domestic_sour = decimal.Parse(row["domestic_sour"].ToString());
                }
                if (row["domestic_lysine"] != null && row["domestic_lysine"].ToString() != "")
                {
                    model.domestic_lysine = decimal.Parse(row["domestic_lysine"].ToString());
                }
                if (row["domestic_amine"] != null && row["domestic_amine"].ToString() != "")
                {
                    model.domestic_amine = decimal.Parse(row["domestic_amine"].ToString());
                }
                if (row["domestic_aminototal"] != null && row["domestic_aminototal"].ToString() != "")
                {
                    model.domestic_aminototal = decimal.Parse(row["domestic_aminototal"].ToString());
                }
                if (row["domestic_methionine"] != null && row["domestic_methionine"].ToString() != "")
                {
                    model.domestic_methionine = decimal.Parse(row["domestic_methionine"].ToString());
                }
                if (row["createman"] != null)
                {
                    model.createman = row["createman"].ToString(); 
                }
                if (row["domestic_fat"] != null && row["domestic_fat"].ToString() != "")
                {
                    model.domestic_fat = decimal.Parse(row["domestic_fat"].ToString());
                }

            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,currentdate,nextdate,customercode,customer,customerlevel,linkmancode,linkman,address,mobile,requiredquantity,officetel,products,weekestimate,monthestimate,communicatecontent,createtime,createman,modifytime,modifyman,isdelete,telephone,buydate ");
            strSql.Append(" FROM t_callrecords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return MySqlHelper.Query(strSql.ToString());
        }


        public DataSet GetList1(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,currentdate,nextdate,customercode,customer,customerlevel,linkmancode,linkman,address,mobile,requiredquantity,officetel,products,weekestimate,monthestimate,communicatecontent,createtime,createman,modifytime,modifyman,isdelete,telephone,buydate ");
            strSql.Append(" FROM t_callrecords ");
            if (where.Trim() != "")
            {
                strSql.Append(" where " + where);
            }
            return MySqlHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_callrecords ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = MySqlHelper.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_callrecords T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return MySqlHelper.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            MySqlParameter[] parameters = {
                    new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
                    new MySqlParameter("@PageSize", MySqlDbType.Int32),
                    new MySqlParameter("@PageIndex", MySqlDbType.Int32),
                    new MySqlParameter("@IsReCount", MySqlDbType.Bit),
                    new MySqlParameter("@OrderType", MySqlDbType.Bit),
                    new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "t_callrecords";
            parameters[1].Value = "id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        public List<FishEntity.CallRecordsEntity> QueryCallRecordsTable(string where,string where1)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select temp.*, case temp.content when Length( temp.content)>500 then substr( temp.content,0,500) else temp.content end as content  ");
            strSql.Append(" , comp.generallevel");
            strSql.Append(", comp.salesmancode");
            strSql.Append(",comp.salesman");
            strSql.Append(",comp.customerproperty");
            strSql.Append(",comp.paymethod");
            strSql.Append(",comp.competitors");
            strSql.Append(",comp.requiredproduct");
            strSql.Append(",comp.cooperation");
            strSql.Append(",comp.province");
            strSql.Append(",comp.zone");
            strSql.Append(",comp.productrequire");
            strSql.Append(",comp.freight");
            strSql.Append(",comp.tare ");
            strSql.Append(",comp.id as companyid ");
            strSql.Append(" from ( ");
            strSql.Append(" select * , GROUP_CONCAT(' ■ ',CONCAT( DATE_FORMAT(currentdate,'%c.%e') ,communicatecontent,' ■ ') ORDER by currentdate desc ) as content  ");
            strSql.Append(" , max(currentdate) as  maxcurrentdate , max(nextdate) as maxnextdate from t_callrecords where   "+where1);
            strSql.Append(" group by customercode  order by currentdate desc ) temp  ");
            strSql.Append(" left join t_company comp on temp.customercode=comp.code ");
            if (string.IsNullOrEmpty(where) == false)
            {
                strSql.Append(" where " + where);
            }
          DataSet dsData =   MySqlHelper.Query(strSql.ToString());

            List<FishEntity.CallRecordsEntity> list=new List<FishEntity.CallRecordsEntity> ();

            for( int i =0;i<dsData.Tables[0].Rows.Count ;i++)
            {
                DataRow row = dsData.Tables[0].Rows[i];
                FishEntity.CallRecordsEntity model = this.DataRowToModel(row);
                     model.communicatecontent = row["content"].ToString();//

                if (row["generallevel"] != null)
                {
                    model.generallevel = row["generallevel"].ToString();
                }
                if (row["products"] != null)
                {
                    model.products = row["products"].ToString();
                }
                if (row["salesmancode"] != null)
                {
                    model.salesmancode = row["salesmancode"].ToString();
                }
                if (row["salesman"] != null)
                {
                    model.salesman = row["salesman"].ToString();
                }
                if (row["customerproperty"] != null)
                {
                    model.customerproperty = row["customerproperty"].ToString();
                } 
                if (row["paymethod"] != null)
                {
                    model.paymethod = row["paymethod"].ToString();
                }
                if (row["competitors"] != null)
                {
                    model.competitors = row["competitors"].ToString();
                }
                if (row["requiredproduct"] != null)
                {
                    model.requiredproduct = row["requiredproduct"].ToString();
                }
                if (row["cooperation"] != null)
                {
                    model.cooperation = row["cooperation"].ToString();
                }
                if (row["province"] != null)
                {
                    model.province = row["province"].ToString();
                }
                if (row["zone"] != null)
                {
                    model.zone = row["zone"].ToString();
                }
                if (row["productrequire"] != null)
                {
                    model.productrequire = row["productrequire"].ToString();
                }
                if (row["freight"] != null && row["freight"].ToString() != "")
                {
                    model.freight = decimal.Parse(row["freight"].ToString());
                }
                if (row["tare"] != null && row["tare"].ToString() != "")
                {
                    model.tare = decimal.Parse(row["tare"].ToString());
                }
                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }

                if (row["maxcurrentdate"] != null && row["maxcurrentdate"].ToString() != "")
                {
                    DateTime dt;
                    DateTime.TryParse(row["maxcurrentdate"].ToString(), out dt);
                    model.maxcurrentdate = dt;
                }
                if (row["maxnextdate"] != null && row["maxnextdate"].ToString() != "")
                {
                    DateTime dt;
                    DateTime.TryParse(row["maxnextdate"].ToString(), out dt);
                    model.maxnextdate = dt;
                }

                list.Add(model);
            }
            return list;
        }

        #endregion  ExtensionMethod
    }
}
