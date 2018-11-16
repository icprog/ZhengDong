using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Dao
{
    class CallRecordsDetailDao
    {
        public CallRecordsDetailDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id,decimal domestic_protein)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_callrecordsdetail");
			strSql.Append(" where id=@id and domestic_protein=@domestic_protein ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,8)			};
			parameters[0].Value = id;
			parameters[1].Value = domestic_protein;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.CallRecordsDetailEntnty model)
		{
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_callrecordsdetail(");
            strSql.Append("callrecordid,no,nature,brand,specification,orderstate,quoteprice,weight,saleprice,paymethod,payperiod,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_amine,domestic_aminototal,domestic_methionine,domestic_fat)");
            strSql.Append(" values (");
            strSql.Append("@callrecordid,@no,@nature,@brand,@specification,@orderstate,@quoteprice,@weight,@saleprice,@paymethod,@payperiod,@domestic_protein,@domestic_tvn,@domestic_graypart,@domestic_sandsalt,@domestic_sour,@domestic_lysine,@domestic_amine,@domestic_aminototal,@domestic_methionine,@domestic_fat);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@callrecordid", MySqlDbType.Int32,11),
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@nature", MySqlDbType.VarChar,255),
					new MySqlParameter("@brand", MySqlDbType.VarChar,255),
					new MySqlParameter("@specification", MySqlDbType.VarChar,255),
					new MySqlParameter("@orderstate", MySqlDbType.VarChar,255),
					new MySqlParameter("@quoteprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@weight", MySqlDbType.Decimal,8),
					new MySqlParameter("@saleprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@paymethod", MySqlDbType.VarChar,255),
					new MySqlParameter("@payperiod", MySqlDbType.VarChar,255),
					new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_tvn", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_amine", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_aminototal", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_fat", MySqlDbType.Decimal,8)};
            parameters[0].Value = model.callrecordid;
            parameters[1].Value = model.no;
            parameters[2].Value = model.nature;
            parameters[3].Value = model.brand;
            parameters[4].Value = model.specification;
            parameters[5].Value = model.orderstate;
            parameters[6].Value = model.quoteprice;
            parameters[7].Value = model.weight;
            parameters[8].Value = model.saleprice;
            parameters[9].Value = model.paymethod;
            parameters[10].Value = model.payperiod;
            parameters[11].Value = model.domestic_protein;
            parameters[12].Value = model.domestic_tvn;
            parameters[13].Value = model.domestic_graypart;
            parameters[14].Value = model.domestic_sandsalt;
            parameters[15].Value = model.domestic_sour;
            parameters[16].Value = model.domestic_lysine;
            parameters[17].Value = model.domestic_amine;
            parameters[18].Value = model.domestic_aminototal;
            parameters[19].Value = model.domestic_methionine;
            parameters[20].Value = model.domestic_fat;

            int rows = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return rows;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CallRecordsDetailEntnty model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_callrecordsdetail set ");
			strSql.Append("callrecordid=@callrecordid,");
			strSql.Append("no=@no,");
			strSql.Append("nature=@nature,");
			strSql.Append("brand=@brand,");
			strSql.Append("specification=@specification,");
            strSql.Append("orderstate=@orderstate,");
			strSql.Append("quoteprice=@quoteprice,");
			strSql.Append("weight=@weight,");
			strSql.Append("saleprice=@saleprice,");
			strSql.Append("paymethod=@paymethod,");
			strSql.Append("payperiod=@payperiod,");
			strSql.Append("domestic_tvn=@domestic_tvn,");
			strSql.Append("domestic_graypart=@domestic_graypart,");
			strSql.Append("domestic_sandsalt=@domestic_sandsalt,");
			strSql.Append("domestic_sour=@domestic_sour,");
			strSql.Append("domestic_lysine=@domestic_lysine,");
			strSql.Append("domestic_amine=@domestic_amine,");
			strSql.Append("domestic_aminototal=@domestic_aminototal,");
			strSql.Append("domestic_methionine=@domestic_methionine,");
			strSql.Append("domestic_fat=@domestic_fat");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@callrecordid", MySqlDbType.Int32,11),
					new MySqlParameter("@no", MySqlDbType.Int32,11),
					new MySqlParameter("@nature", MySqlDbType.VarChar,255),
					new MySqlParameter("@brand", MySqlDbType.VarChar,255),
					new MySqlParameter("@specification", MySqlDbType.VarChar,255),
					new MySqlParameter("@orderstate", MySqlDbType.VarChar,255),
					new MySqlParameter("@quoteprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@weight", MySqlDbType.Decimal,8),
					new MySqlParameter("@saleprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@paymethod", MySqlDbType.VarChar,255),
					new MySqlParameter("@payperiod", MySqlDbType.VarChar,255),
					new MySqlParameter("@domestic_tvn", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_amine", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_aminototal", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,8),
					new MySqlParameter("@domestic_fat", MySqlDbType.Decimal,8),
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,8)};
			parameters[0].Value = model.callrecordid;
			parameters[1].Value = model.no;
			parameters[2].Value = model.nature;
			parameters[3].Value = model.brand;
			parameters[4].Value = model.specification;
            parameters[5].Value = model.orderstate;
			parameters[6].Value = model.quoteprice;
			parameters[7].Value = model.weight;
			parameters[8].Value = model.saleprice;
			parameters[9].Value = model.paymethod;
			parameters[10].Value = model.payperiod;
			parameters[11].Value = model.domestic_tvn;
			parameters[12].Value = model.domestic_graypart;
			parameters[13].Value = model.domestic_sandsalt;
			parameters[14].Value = model.domestic_sour;
			parameters[15].Value = model.domestic_lysine;
			parameters[16].Value = model.domestic_amine;
			parameters[17].Value = model.domestic_aminototal;
			parameters[18].Value = model.domestic_methionine;
			parameters[19].Value = model.domestic_fat;
			parameters[20].Value = model.id;
			parameters[21].Value = model.domestic_protein;

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
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_callrecordsdetail ");
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
		/// 删除一条数据
		/// </summary>
        public bool DeleteByCallRecordId(int callrecordid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_callrecordsdetail ");
            strSql.Append(" where callrecordid=@callrecordid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@callrecordid", MySqlDbType.Int32,11)	};
            parameters[0].Value = callrecordid;	

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_callrecordsdetail ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public FishEntity.CallRecordsDetailEntnty GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,callrecordid,no,nature,brand,specification,orderstate,quoteprice,weight,saleprice,paymethod,payperiod,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_amine,domestic_aminototal,domestic_methionine,domestic_fat from t_callrecordsdetail ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.CallRecordsDetailEntnty model=new FishEntity.CallRecordsDetailEntnty();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public FishEntity.CallRecordsDetailEntnty DataRowToModel(DataRow row)
		{
			FishEntity.CallRecordsDetailEntnty model=new FishEntity.CallRecordsDetailEntnty();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["callrecordid"]!=null && row["callrecordid"].ToString()!="")
				{
					model.callrecordid=int.Parse(row["callrecordid"].ToString());
				}
				if(row["no"]!=null && row["no"].ToString()!="")
				{
					model.no=int.Parse(row["no"].ToString());
				}
				if(row["nature"]!=null)
				{
					model.nature=row["nature"].ToString();
				}
				if(row["brand"]!=null)
				{
					model.brand=row["brand"].ToString();
				}
				if(row["specification"]!=null)
				{
					model.specification=row["specification"].ToString();
				}
                if (row["orderstate"] != null)
				{
                    model.orderstate = row["orderstate"].ToString();
				}
				if(row["quoteprice"]!=null && row["quoteprice"].ToString()!="")
				{
					model.quoteprice=decimal.Parse(row["quoteprice"].ToString());
				}
				//if(row["weight"]!=null && row["weight"].ToString()!="")
				//{
				//	model.weight=decimal.Parse(row["weight"].ToString());
				//}
				if(row["saleprice"]!=null && row["saleprice"].ToString()!="")
				{
					model.saleprice=decimal.Parse(row["saleprice"].ToString());
				}
				if(row["paymethod"]!=null)
				{
					model.paymethod=row["paymethod"].ToString();
				}
				if(row["payperiod"]!=null)
				{
					model.payperiod=row["payperiod"].ToString();
				}
				if(row["domestic_protein"]!=null && row["domestic_protein"].ToString()!="")
				{
					model.domestic_protein=decimal.Parse(row["domestic_protein"].ToString());
				}
				if(row["domestic_tvn"]!=null && row["domestic_tvn"].ToString()!="")
				{
					model.domestic_tvn=decimal.Parse(row["domestic_tvn"].ToString());
				}
				if(row["domestic_graypart"]!=null && row["domestic_graypart"].ToString()!="")
				{
					model.domestic_graypart=decimal.Parse(row["domestic_graypart"].ToString());
				}
				if(row["domestic_sandsalt"]!=null && row["domestic_sandsalt"].ToString()!="")
				{
					model.domestic_sandsalt=decimal.Parse(row["domestic_sandsalt"].ToString());
				}
				if(row["domestic_sour"]!=null && row["domestic_sour"].ToString()!="")
				{
					model.domestic_sour=decimal.Parse(row["domestic_sour"].ToString());
				}
				if(row["domestic_lysine"]!=null && row["domestic_lysine"].ToString()!="")
				{
					model.domestic_lysine=decimal.Parse(row["domestic_lysine"].ToString());
				}
				if(row["domestic_amine"]!=null && row["domestic_amine"].ToString()!="")
				{
					model.domestic_amine=decimal.Parse(row["domestic_amine"].ToString());
				}
				if(row["domestic_aminototal"]!=null && row["domestic_aminototal"].ToString()!="")
				{
					model.domestic_aminototal=decimal.Parse(row["domestic_aminototal"].ToString());
				}
				if(row["domestic_methionine"]!=null && row["domestic_methionine"].ToString()!="")
				{
					model.domestic_methionine=decimal.Parse(row["domestic_methionine"].ToString());
				}
				if(row["domestic_fat"]!=null && row["domestic_fat"].ToString()!="")
				{
					model.domestic_fat=decimal.Parse(row["domestic_fat"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,callrecordid,no,nature,brand,specification,orderstate,quoteprice,weight,saleprice,paymethod,payperiod,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_amine,domestic_aminototal,domestic_methionine,domestic_fat ");
			strSql.Append(" FROM t_callrecordsdetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return MySqlHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_callrecordsdetail ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from t_callrecordsdetail T ");
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
			parameters[0].Value = "t_callrecordsdetail";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

        public List<FishEntity.CallRecordsDetailEntnty> GetRecordListByCompanyCode(string companyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.currentdate, b.* from t_callrecords a inner join t_callrecordsdetail b on a.id=b.callrecordid");
            strSql.Append(" where a.customercode = @customercode  order by a.currentdate desc limit 100");
            MySqlParameter[] parameters = {
					new MySqlParameter("@customercode", MySqlDbType.VarChar, 255)
                                          };
            parameters[0].Value = companyCode;

            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            List<FishEntity.CallRecordsDetailEntnty> list = new List<FishEntity.CallRecordsDetailEntnty>(); 
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    FishEntity.CallRecordsDetailEntnty item = DataRowToModel(ds.Tables[0].Rows[i]);

                    if (ds.Tables[0].Rows[i]["currentdate"] != null)
                    {
                        item.currentdate = DateTime.Parse(ds.Tables[0].Rows[i]["currentdate"].ToString());
                    }

                    list.Add(item);
                }
                return list;
            }
            else
            {
                return null;
            }

        }

        public List<FishEntity.CallRecordsDetailEntnty> GetRecordListByWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from  t_callrecordsdetail where "+ where);
            DataSet ds = MySqlHelper.Query(strSql.ToString());
            List<FishEntity.CallRecordsDetailEntnty> list = new List<FishEntity.CallRecordsDetailEntnty>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    FishEntity.CallRecordsDetailEntnty item = DataRowToModel(ds.Tables[0].Rows[i]);

                 

                    list.Add(item);
                }
                return list;
            }
            else
            {
                return null;
            }
        }


        public List<FishEntity.CallRecordDetailEntityEx> GetRecordDetailListByWhere(string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from v_customeranalysistable");
            if (string.IsNullOrEmpty(where) == false)
            {
                strSql.Append(" where " + where); 
            }

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            List<FishEntity.CallRecordDetailEntityEx> list = new List<FishEntity.CallRecordDetailEntityEx>();
            int count = ds.Tables[0].Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];
                FishEntity.CallRecordDetailEntityEx model = new FishEntity.CallRecordDetailEntityEx();

                if (row["orderstate"] != null)
                {
                    model.orderstate = row["orderstate"].ToString();
                }
                //if (row["quoteprice"] != null && row["quoteprice"].ToString() != "")
                //{
                //    model.quoteprice = decimal.Parse(row["quoteprice"].ToString());
                //}
                //if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                //{
                //    model.saleprice = decimal.Parse(row["saleprice"].ToString());
                //}
                //if (row["nature"] != null)
                //{
                //    model.nature = row["nature"].ToString();
                //}
                //if (row["brand"] != null)
                //{
                //    model.brand = row["brand"].ToString();
                //}
                if (row["customer"]!=null)
                {
                    model.customer = row["customer"].ToString();
                }
                //if(row["specification"]!=null)
				//{
				//	model.specification=row["specification"].ToString();
				//}
                //if(row["weight"]!=null && row["weight"].ToString()!="")
				//{
				//	model.weight=decimal.Parse(row["weight"].ToString());
				//}

                if (row["currentdate"] != null && row["currentdate"].ToString() != "")
                {
                    model.currentdate = DateTime.Parse(row["currentdate"].ToString());
                }
                if (row["nextdate"] != null && row["nextdate"].ToString() != "")
                {
                    model.Nextdate = DateTime.Parse(row["nextdate"].ToString());
                }
                if (row["linkmancode"] != null)
                {
                    model.Linkmancode = row["linkmancode"].ToString();
                }
                if (row["linkman"] != null)
                {
                    model.Linkman = row["linkman"].ToString();
                }
                if (row["code"] != null)
                {
                    model.Code = row["code"].ToString();
                }
                if (row["communicatecontent"] != null)
                {
                    model.Communicatecontent = row["communicatecontent"].ToString();
                }
                if (row["bjqk"] != null)
                {
                    model.Bjqk = row["bjqk"].ToString();
                }
                if (row["cgyx"] != null)
                {
                    model.Cgyx = row["cgyx"].ToString();
                }
                //if (row["createman"]!=null)
                //{
                //    model.createman = row["createman"].ToString(); 
                //}
                //model.Bjqk = model.currentdate.ToString("MM.dd") +" " + model.specification + "" + model.quoteprice + "" + model.brand;
                //model.Cgyx = model.currentdate.ToString("MM.dd") +" " + model.orderstate + ":" + model.weight + model.specification + model.saleprice;

                list.Add(model);
            }

            return list;
        }

		#endregion  ExtensionMethod
    }
}
