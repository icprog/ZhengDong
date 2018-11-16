using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using FishEntity;

namespace FishBll.Dao
{
    public class ContractDao
    {
        public ContractDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int contractid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_contract");
			strSql.Append(" where contractid=@contractid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@contractid", MySqlDbType.Int32)
			};
			parameters[0].Value = contractid;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}
        public bool Exists(string  no)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_contract");
            strSql.Append(" where contractno=@no");
            MySqlParameter[] parameters = {
					new MySqlParameter("@no", MySqlDbType.VarChar,45)
			};
            parameters[0].Value = no;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.ContractEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_contract(");
			strSql.Append("type,contractno,signdate,signaddress,money,yifangcode,yifang,yiduanzhuang,check1,check2,check3,deliverytime,address,package,date1,date2,date3,bank,bankaccount,resolve,time1,time2,time3,time4,maifangcode,maifang,maifangaddress,maifangtelephone,maifangfox,yifangaddress,yifangtelephone,yifangfox,salemanid,saleman,status)");
			strSql.Append(" values (");
			strSql.Append("@type,@contractno,@signdate,@signaddress,@money,@yifangcode,@yifang,@yiduanzhuang,@check1,@check2,@check3,@deliverytime,@address,@package,@date1,@date2,@date3,@bank,@bankaccount,@resolve,@time1,@time2,@time3,@time4,@maifangcode,@maifang,@maifangaddress,@maifangtelephone,@maifangfox,@yifangaddress,@yifangtelephone,@yifangfox,@salemanid,@saleman,@status);");
            strSql.Append("select LAST_INSERT_ID();");
            
            MySqlParameter[] parameters = {
					new MySqlParameter("@type", MySqlDbType.Int32,255),
					new MySqlParameter("@contractno", MySqlDbType.VarChar,45),
					new MySqlParameter("@signdate", MySqlDbType.VarChar,45),
					new MySqlParameter("@signaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@money", MySqlDbType.Decimal,10),
					new MySqlParameter("@yifangcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@yifang", MySqlDbType.VarChar,255),
					new MySqlParameter("@yiduanzhuang", MySqlDbType.VarChar,100),
					new MySqlParameter("@check1", MySqlDbType.VarChar,255),
					new MySqlParameter("@check2", MySqlDbType.VarChar,255),
					new MySqlParameter("@check3", MySqlDbType.VarChar,255),
					new MySqlParameter("@deliverytime", MySqlDbType.VarChar,100),
					new MySqlParameter("@address", MySqlDbType.VarChar,255),
					new MySqlParameter("@package", MySqlDbType.VarChar,255),
					new MySqlParameter("@date1", MySqlDbType.VarChar,255),
					new MySqlParameter("@date2", MySqlDbType.VarChar,255),
					new MySqlParameter("@date3", MySqlDbType.VarChar,255),
					new MySqlParameter("@bank", MySqlDbType.VarChar,255),
					new MySqlParameter("@bankaccount", MySqlDbType.VarChar,255),
					new MySqlParameter("@resolve", MySqlDbType.VarChar,255),
					new MySqlParameter("@time1", MySqlDbType.VarChar,45),
					new MySqlParameter("@time2", MySqlDbType.VarChar,45),
					new MySqlParameter("@time3", MySqlDbType.VarChar,45),
					new MySqlParameter("@time4", MySqlDbType.VarChar,45),
					new MySqlParameter("@maifangcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@maifang", MySqlDbType.VarChar,255),
					new MySqlParameter("@maifangaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@maifangtelephone", MySqlDbType.VarChar,255),
					new MySqlParameter("@maifangfox", MySqlDbType.VarChar,255),
					new MySqlParameter("@yifangaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@yifangtelephone", MySqlDbType.VarChar,255),
					new MySqlParameter("@yifangfox", MySqlDbType.VarChar,255),
                    new MySqlParameter("@salemanid", MySqlDbType.Int32,6),
                    new MySqlParameter("@saleman", MySqlDbType.VarChar,255),
                    new MySqlParameter("@status",MySqlDbType.Int16,2)
                                          };
			parameters[0].Value = model.type;
			parameters[1].Value = model.contractno;
			parameters[2].Value = model.signdate;
			parameters[3].Value = model.signaddress;
			parameters[4].Value = model.money;
			parameters[5].Value = model.yifangcode;
			parameters[6].Value = model.yifang;
			parameters[7].Value = model.yiduanzhuang;
			parameters[8].Value = model.check1;
			parameters[9].Value = model.check2;
			parameters[10].Value = model.check3;
			parameters[11].Value = model.deliverytime;
			parameters[12].Value = model.address;
			parameters[13].Value = model.package;
			parameters[14].Value = model.date1;
			parameters[15].Value = model.date2;
			parameters[16].Value = model.date3;
			parameters[17].Value = model.bank;
			parameters[18].Value = model.bankaccount;
			parameters[19].Value = model.resolve;
			parameters[20].Value = model.time1;
			parameters[21].Value = model.time2;
			parameters[22].Value = model.time3;
			parameters[23].Value = model.time4;
			parameters[24].Value = model.maifangcode;
			parameters[25].Value = model.maifang;
			parameters[26].Value = model.maifangaddress;
			parameters[27].Value = model.maifangtelephone;
			parameters[28].Value = model.maifangfox;
			parameters[29].Value = model.yifangaddress;
			parameters[30].Value = model.yifangtelephone;
			parameters[31].Value = model.yifangfox;
            parameters[32].Value = model.salemanid;
            parameters[33].Value = model.saleman;
            parameters[34].Value = model.status;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// 
        public int add(FishEntity.ContractDetailVo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_ssss (productid,loadingcode,loadingdate,quantity,unitprice,state,weight,contractno,contractdate,getw,getq,yifang,saleman,cid,linkman,isdelete,companyid,createman) VALUES  ");
            strSql.Append("(@productid,@loadingcode,@loadingdate,@quantity,@unitprice,@state,@weight,@contractno,@contractdate,@getw,@getq,@yifang,@saleman,@cid,@linkman,@isdelete,@companyid,@createman) ");
            MySqlParameter[] parameters = {
                new MySqlParameter("@productid",MySqlDbType.Int32,11),
                new MySqlParameter("@loadingcode",MySqlDbType.VarChar,20),
                new MySqlParameter("@loadingdate",MySqlDbType.Date,0),
                new MySqlParameter("@quantity",MySqlDbType.Decimal,12),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,10),
                new MySqlParameter("@state",MySqlDbType.VarChar,45),
                new MySqlParameter("@weight",MySqlDbType.Decimal,45),
                new MySqlParameter("@contractno",MySqlDbType.VarChar,45),
                new MySqlParameter("@contractdate",MySqlDbType.Date,45),
                new MySqlParameter("@getw",MySqlDbType.Decimal,12),
                new MySqlParameter("@getq",MySqlDbType.Decimal,12),
                new MySqlParameter("@yifang",MySqlDbType.VarChar,45),
                new MySqlParameter("@saleman",MySqlDbType.VarChar,45),
                new MySqlParameter("@cid",MySqlDbType.Int32,11),
                new MySqlParameter("@linkman",MySqlDbType.VarChar,45),
                new MySqlParameter("@isdelete",MySqlDbType.Int32,10),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("companyid",MySqlDbType.Int32,10)
            };
            parameters[0].Value = model.productid;
            parameters[1].Value = model.loadingcode;
            parameters[2].Value = model.loadingdate;
            parameters[3].Value = model.quantity;
            parameters[4].Value = model.unitprice;
            parameters[5].Value = model.state;
            parameters[6].Value = model.weight;
            parameters[7].Value = model.contractno;
            parameters[8].Value = model.contractdate;
            parameters[9].Value = model.getw;
            parameters[10].Value = model.getq;
            parameters[11].Value = model.yifang;
            parameters[12].Value = model.saleman;
            parameters[13].Value = model.cid;
            parameters[14].Value = model.linkman;
            parameters[15].Value = model.isdelete;
            parameters[16].Value = model.createman;
            parameters[17].Value = model.companyid;
            int id= MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
        }
        public bool Update1(FishEntity.ContractDetailVo model)
        {
            StringBuilder strSsql = new StringBuilder();
            strSsql.Append(" update t_ssss set  ");
            //productid,loadingcode,loadingdate,quantity,unitprice,state,weight,contractno,contractdate,getw,getq,yifang,saleman,cid,linkman,isdelete
            strSsql.Append(" productid=@productid, ");
            strSsql.Append(" loadingcode=@loadingcode, ");
            strSsql.Append(" loadingdate=@loadingdate, ");
            strSsql.Append(" quantity=@quantity, ");
            strSsql.Append(" unitprice=@unitprice, ");
            strSsql.Append(" state=@state, ");
            strSsql.Append(" weight=@weight, ");
            strSsql.Append(" contractno=@contractno, ");
            strSsql.Append(" contractdate=@contractdate, ");
            strSsql.Append(" getw=@getw, ");
            strSsql.Append(" getq=@getq, ");
            strSsql.Append(" yifang=@yifang, ");
            strSsql.Append(" createman=@createman, ");
            strSsql.Append(" cid=@cid, ");
            strSsql.Append(" linkman=@linkman, ");
            strSsql.Append(" isdelete=@isdelete, ");
            strSsql.Append(" companyid=@companyid ");
            strSsql.Append(" where id=@id ");
            MySqlParameter[] parameters = {
                new MySqlParameter("@productid",MySqlDbType.Int32,11),
                new MySqlParameter("@loadingcode",MySqlDbType.VarChar,20),
                new MySqlParameter("@loadingdate",MySqlDbType.Date,0),
                new MySqlParameter("@quantity",MySqlDbType.Decimal,12),
                new MySqlParameter("@unitprice",MySqlDbType.Decimal,10),
                new MySqlParameter("@state",MySqlDbType.VarChar,45),
                new MySqlParameter("@weight",MySqlDbType.Decimal,45),
                new MySqlParameter("@contractno",MySqlDbType.VarChar,45),
                new MySqlParameter("@contractdate",MySqlDbType.Date,45),
                new MySqlParameter("@getw",MySqlDbType.Decimal,12),
                new MySqlParameter("@getq",MySqlDbType.Decimal,12),
                new MySqlParameter("@yifang",MySqlDbType.VarChar,45),
                new MySqlParameter("@createman",MySqlDbType.VarChar,45),
                new MySqlParameter("@cid",MySqlDbType.Int32,11),
                new MySqlParameter("@linkman",MySqlDbType.VarChar,45),
                new MySqlParameter("@isdelete",MySqlDbType.Int32,10),
                new MySqlParameter("@companyid",MySqlDbType.Int32,10),
                new MySqlParameter("@id",MySqlDbType.Int32,10)
            };
            parameters[0].Value = model.productid;
            parameters[1].Value = model.loadingcode;
            parameters[2].Value = model.loadingdate;
            parameters[3].Value = model.quantity;
            parameters[4].Value = model.unitprice;
            parameters[5].Value = model.state;
            parameters[6].Value = model.weight;
            parameters[7].Value = model.contractno;
            parameters[8].Value = model.contractdate;
            parameters[9].Value = model.getw;
            parameters[10].Value = model.getq;
            parameters[11].Value = model.yifang;
            parameters[12].Value = model.createman;
            parameters[13].Value = model.cid;
            parameters[14].Value = model.linkman;
            parameters[15].Value = model.isdelete;
            parameters[16].Value = model.companyid;
            parameters[17].Value = model.id;
            int rows = MySqlHelper.ExecuteSql(strSsql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
		public bool Update(FishEntity.ContractEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_contract set ");
			strSql.Append("type=@type,");
			strSql.Append("contractno=@contractno,");
			strSql.Append("signdate=@signdate,");
			strSql.Append("signaddress=@signaddress,");
			strSql.Append("money=@money,");
			strSql.Append("yifangcode=@yifangcode,");
			strSql.Append("yifang=@yifang,");
			strSql.Append("yiduanzhuang=@yiduanzhuang,");
			strSql.Append("check1=@check1,");
			strSql.Append("check2=@check2,");
			strSql.Append("check3=@check3,");
			strSql.Append("deliverytime=@deliverytime,");
			strSql.Append("address=@address,");
			strSql.Append("package=@package,");
			strSql.Append("date1=@date1,");
			strSql.Append("date2=@date2,");
			strSql.Append("date3=@date3,");
			strSql.Append("bank=@bank,");
			strSql.Append("bankaccount=@bankaccount,");
			strSql.Append("resolve=@resolve,");
			strSql.Append("time1=@time1,");
			strSql.Append("time2=@time2,");
			strSql.Append("time3=@time3,");
			strSql.Append("time4=@time4,");
			strSql.Append("maifangcode=@maifangcode,");
			strSql.Append("maifang=@maifang,");
			strSql.Append("maifangaddress=@maifangaddress,");
			strSql.Append("maifangtelephone=@maifangtelephone,");
			strSql.Append("maifangfox=@maifangfox,");
			strSql.Append("yifangaddress=@yifangaddress,");
			strSql.Append("yifangtelephone=@yifangtelephone,");
			strSql.Append("yifangfox=@yifangfox,");
            strSql.Append("salemanid=@salemanid,");
            strSql.Append("saleman=@saleman,");
            strSql.Append("status=@status");
			strSql.Append(" where contractid=@contractid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@type", MySqlDbType.Int32,255),
					new MySqlParameter("@contractno", MySqlDbType.VarChar,45),
					new MySqlParameter("@signdate", MySqlDbType.VarChar,45),
					new MySqlParameter("@signaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@money", MySqlDbType.Decimal,10),
					new MySqlParameter("@yifangcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@yifang", MySqlDbType.VarChar,255),
					new MySqlParameter("@yiduanzhuang", MySqlDbType.VarChar,100),
					new MySqlParameter("@check1", MySqlDbType.VarChar,255),
					new MySqlParameter("@check2", MySqlDbType.VarChar,255),
					new MySqlParameter("@check3", MySqlDbType.VarChar,255),
					new MySqlParameter("@deliverytime", MySqlDbType.VarChar,100),
					new MySqlParameter("@address", MySqlDbType.VarChar,255),
					new MySqlParameter("@package", MySqlDbType.VarChar,255),
					new MySqlParameter("@date1", MySqlDbType.VarChar,255),
					new MySqlParameter("@date2", MySqlDbType.VarChar,255),
					new MySqlParameter("@date3", MySqlDbType.VarChar,255),
					new MySqlParameter("@bank", MySqlDbType.VarChar,255),
					new MySqlParameter("@bankaccount", MySqlDbType.VarChar,255),
					new MySqlParameter("@resolve", MySqlDbType.VarChar,255),
					new MySqlParameter("@time1", MySqlDbType.VarChar,45),
					new MySqlParameter("@time2", MySqlDbType.VarChar,45),
					new MySqlParameter("@time3", MySqlDbType.VarChar,45),
					new MySqlParameter("@time4", MySqlDbType.VarChar,45),
					new MySqlParameter("@maifangcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@maifang", MySqlDbType.VarChar,255),
					new MySqlParameter("@maifangaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@maifangtelephone", MySqlDbType.VarChar,255),
					new MySqlParameter("@maifangfox", MySqlDbType.VarChar,255),
					new MySqlParameter("@yifangaddress", MySqlDbType.VarChar,255),
					new MySqlParameter("@yifangtelephone", MySqlDbType.VarChar,255),
					new MySqlParameter("@yifangfox", MySqlDbType.VarChar,255),
                    new MySqlParameter("@salemanid",MySqlDbType.Int32,6),
                    new MySqlParameter("@saleman",MySqlDbType.VarChar,255),
					new MySqlParameter("@contractid", MySqlDbType.Int32,11),
                    new MySqlParameter("@status",MySqlDbType.Int16,2)                      
                                          };
			parameters[0].Value = model.type;
			parameters[1].Value = model.contractno;
			parameters[2].Value = model.signdate;
			parameters[3].Value = model.signaddress;
			parameters[4].Value = model.money;
			parameters[5].Value = model.yifangcode;
			parameters[6].Value = model.yifang;
			parameters[7].Value = model.yiduanzhuang;
			parameters[8].Value = model.check1;
			parameters[9].Value = model.check2;
			parameters[10].Value = model.check3;
			parameters[11].Value = model.deliverytime;
			parameters[12].Value = model.address;
			parameters[13].Value = model.package;
			parameters[14].Value = model.date1;
			parameters[15].Value = model.date2;
			parameters[16].Value = model.date3;
			parameters[17].Value = model.bank;
			parameters[18].Value = model.bankaccount;
			parameters[19].Value = model.resolve;
			parameters[20].Value = model.time1;
			parameters[21].Value = model.time2;
			parameters[22].Value = model.time3;
			parameters[23].Value = model.time4;
			parameters[24].Value = model.maifangcode;
			parameters[25].Value = model.maifang;
			parameters[26].Value = model.maifangaddress;
			parameters[27].Value = model.maifangtelephone;
			parameters[28].Value = model.maifangfox;
			parameters[29].Value = model.yifangaddress;
			parameters[30].Value = model.yifangtelephone;
			parameters[31].Value = model.yifangfox;
            parameters[32].Value = model.salemanid;
            parameters[33].Value = model.saleman;
            parameters[34].Value = model.contractid;
            parameters[35].Value = model.status;

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
        public bool Delete1(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_ssss ");
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
        public bool Delete(int contractid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_contract ");
			strSql.Append(" where contractid=@contractid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@contractid", MySqlDbType.Int32)
			};
			parameters[0].Value = contractid;

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
		public bool DeleteList(string contractidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_contract ");
			strSql.Append(" where contractid in ("+contractidlist + ")  ");
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
		public FishEntity.ContractEntity GetModel(int contractid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select contractid,type,contractno,signdate,signaddress,money,yifangcode,yifang,yiduanzhuang,check1,check2,check3,deliverytime,address,package,date1,date2,date3,bank,bankaccount,resolve,time1,time2,time3,time4,maifangcode,maifang,maifangaddress,maifangtelephone,maifangfox,yifangaddress,yifangtelephone,yifangfox,salemanid,saleman,status from t_contract ");
			strSql.Append(" where contractid=@contractid");
			MySqlParameter[] parameters = {
					new MySqlParameter("@contractid", MySqlDbType.Int32)
			};
			parameters[0].Value = contractid;

			FishEntity.ContractEntity model=new FishEntity.ContractEntity();
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
		public FishEntity.ContractEntity DataRowToModel(DataRow row)
		{
			FishEntity.ContractEntity model=new FishEntity.ContractEntity();
			if (row != null)
			{
				if(row["contractid"]!=null && row["contractid"].ToString()!="")
				{
					model.contractid=int.Parse(row["contractid"].ToString());
				}
				if(row["type"]!=null && row["type"].ToString()!="")
				{
					model.type=int.Parse(row["type"].ToString());
				}
				if(row["contractno"]!=null)
				{
					model.contractno=row["contractno"].ToString();
				}
				if(row["signdate"]!=null)
				{
					model.signdate=row["signdate"].ToString();
				}
				if(row["signaddress"]!=null)
				{
					model.signaddress=row["signaddress"].ToString();
				}
				if(row["money"]!=null && row["money"].ToString()!="")
				{
					model.money=decimal.Parse(row["money"].ToString());
				}
				if(row["yifangcode"]!=null)
				{
					model.yifangcode=row["yifangcode"].ToString();
				}
				if(row["yifang"]!=null)
				{
					model.yifang=row["yifang"].ToString();
				}
                if (row["yiduanzhuang"]!=null)
				{
					model.yiduanzhuang=row["yiduanzhuang"].ToString();
				}
				if(row["check1"]!=null)
				{
					model.check1=row["check1"].ToString();
				}
				if(row["check2"]!=null)
				{
					model.check2=row["check2"].ToString();
				}
				if(row["check3"]!=null)
				{
					model.check3=row["check3"].ToString();
				}
				if(row["deliverytime"]!=null)
				{
					model.deliverytime=row["deliverytime"].ToString();
				}
				if(row["address"]!=null)
				{
					model.address=row["address"].ToString();
				}
				if(row["package"]!=null)
				{
					model.package=row["package"].ToString();
				}
				if(row["date1"]!=null)
				{
					model.date1=row["date1"].ToString();
				}
				if(row["date2"]!=null)
				{
					model.date2=row["date2"].ToString();
				}
				if(row["date3"]!=null)
				{
					model.date3=row["date3"].ToString();
				}
				if(row["bank"]!=null)
				{
					model.bank=row["bank"].ToString();
				}
				if(row["bankaccount"]!=null)
				{
					model.bankaccount=row["bankaccount"].ToString();
				}
				if(row["resolve"]!=null)
				{
					model.resolve=row["resolve"].ToString();
				}
				if(row["time1"]!=null)
				{
					model.time1=row["time1"].ToString();
				}
				if(row["time2"]!=null)
				{
					model.time2=row["time2"].ToString();
				}
				if(row["time3"]!=null)
				{
					model.time3=row["time3"].ToString();
				}
				if(row["time4"]!=null)
				{
					model.time4=row["time4"].ToString();
				}
				if(row["maifangcode"]!=null)
				{
					model.maifangcode=row["maifangcode"].ToString();
				}
				if(row["maifang"]!=null)
				{
					model.maifang=row["maifang"].ToString();
				}
				if(row["maifangaddress"]!=null)
				{
					model.maifangaddress=row["maifangaddress"].ToString();
				}
				if(row["maifangtelephone"]!=null)
				{
					model.maifangtelephone=row["maifangtelephone"].ToString();
				}
				if(row["maifangfox"]!=null)
				{
					model.maifangfox=row["maifangfox"].ToString();
				}
				if(row["yifangaddress"]!=null)
				{
					model.yifangaddress=row["yifangaddress"].ToString();
				}
				if(row["yifangtelephone"]!=null)
				{
					model.yifangtelephone=row["yifangtelephone"].ToString();
				}
				if(row["yifangfox"]!=null)
				{
					model.yifangfox=row["yifangfox"].ToString();
				}
                if (row["salemanid"] != null || row["salemanid"].ToString()!="")
                {
                    model.salemanid = int.Parse( row["salemanid"].ToString());
                }
                if (row["saleman"] != null)
                {
                    model.saleman = row["saleman"].ToString();
                }
                if (row["status"] != null || row["status"].ToString() != "")
                {
                    model.status = int.Parse(row["status"].ToString());
                }
			}
			return model;
		}
        public FishEntity.ContractDetailVo DataRowToModel1(DataRow row)
        {
            FishEntity.ContractDetailVo model = new FishEntity.ContractDetailVo();
            if (row != null)
            {
                if (row["productid"] != null && row["productid"].ToString() != "")
                {
                    model.productid = int.Parse(row["productid"].ToString());
                }
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["contractno"] != null)
                {
                    model.contractno = row["contractno"].ToString();
                }
                if (row["loadingcode"] != null)
                {
                    model.loadingcode = row["loadingcode"].ToString();
                }
                //if (row["signaddress"] != null)
                //{
                //    model.signaddress = row["signaddress"].ToString();
                //}
                if (row["quantity"] != null && row["quantity"].ToString() != "")
                {
                    model.quantity = decimal.Parse(row["quantity"].ToString());
                }

                if (row["companyid"] != null && row["companyid"].ToString() != "")
                {
                    model.companyid = int.Parse(row["companyid"].ToString());
                }
                //if (row["yifangcode"] != null)
                //{
                //    model.yifangcode = row["yifangcode"].ToString();
                //}
                //if (row["yifang"] != null)
                //{
                //    model.yifang = row["yifang"].ToString();
                //}
                //if (row["yiduanzhuang"] != null)
                //{
                //    model.yiduanzhuang = row["yiduanzhuang"].ToString();
                //}
                if (row["createman"]!=null)
                {
                    model.createman = row["createman"].ToString();
                }
                if (row["cid"] != null||row["cid"].ToString()!="")
                {
                    model.cid = int.Parse(row["cid"].ToString());
                }
                if (row["linkman"] != null || row["linkman"].ToString()!="")
                {
                    model.linkman = row["linkman"].ToString();
                }
                //if (row["check3"] != null)
                //{
                //    model.check3 = row["check3"].ToString();
                //}
                if (row["contractdate"] != null)
                {
                    model.contractdate = DateTime.Parse(row["contractdate"].ToString());
                }
                if (row["contractno"] != null)
                {
                    model.contractno = row["contractno"].ToString();
                }
                if (row["getw"] != null||row["getw"].ToString()!="")
                {
                    model.getw = decimal.Parse(row["getw"].ToString());
                }
                if (row["getq"] != null || row["getq"].ToString() != "")
                {
                    model.getq = decimal.Parse(row["getq"].ToString());
                }
                //if (row["package"] != null)
                //{
                //    model.package = row["package"].ToString();
                //}
                if (row["weight"] != null||row["weight"].ToString()!="")
                {
                    model.weight = decimal.Parse(row["weight"].ToString());
                }
                if (row["yifang"] != null)
                {
                    model.yifang = row["yifang"].ToString();
                }
                if (row["isdelete"] != null||row["isdelete"].ToString()!="")
                {
                    model.isdelete = int.Parse(row["isdelete"].ToString());
                }
                //if (row["bank"] != null)
                //{
                //    model.bank = row["bank"].ToString();
                //}
                //if (row["bankaccount"] != null)
                //{
                //    model.bankaccount = row["bankaccount"].ToString();
                //}
                //if (row["resolve"] != null)
                //{
                //    model.resolve = row["resolve"].ToString();
                //}
                //if (row["time1"] != null)
                //{
                //    model.time1 = row["time1"].ToString();
                //}
                //if (row["time2"] != null)
                //{
                //    model.time2 = row["time2"].ToString();
                //}
                //if (row["time3"] != null)
                //{
                //    model.time3 = row["time3"].ToString();
                //}
                //if (row["time4"] != null)
                //{
                //    model.time4 = row["time4"].ToString();
                //}
                //if (row["maifangcode"] != null)
                //{
                //    model.maifangcode = row["maifangcode"].ToString();
                //}
                //if (row["maifang"] != null)
                //{
                //    model.maifang = row["maifang"].ToString();
                //}
                //if (row["maifangaddress"] != null)
                //{
                //    model.maifangaddress = row["maifangaddress"].ToString();
                //}
                //if (row["maifangtelephone"] != null)
                //{
                //    model.maifangtelephone = row["maifangtelephone"].ToString();
                //}
                //if (row["maifangfox"] != null)
                //{
                //    model.maifangfox = row["maifangfox"].ToString();
                //}
                //if (row["yifangaddress"] != null)
                //{
                //    model.yifangaddress = row["yifangaddress"].ToString();
                //}
                //if (row["yifangtelephone"] != null)
                //{
                //    model.yifangtelephone = row["yifangtelephone"].ToString();
                //}
                //if (row["yifangfox"] != null)
                //{
                //    model.yifangfox = row["yifangfox"].ToString();
                //}
                if (row["loadingdate"] != null || row["loadingdate"].ToString() != "")
                {
                    model.loadingdate = DateTime.Parse(row["loadingdate"].ToString());
                }
                if (row["unitprice"] != null || row["unitprice"].ToString() != "")
                {
                    model.unitprice = decimal.Parse(row["unitprice"].ToString());
                }
                if (row["saleman"] != null)
                {
                    model.saleman = row["saleman"].ToString();
                }
                if ( row["state"].ToString() !=null)
                {
                    model.state = row["state"].ToString();
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
            strSql.Append("select contractid,type,contractno,signdate,signaddress,money,yifangcode,yifang,yiduanzhuang,check1,check2,check3,deliverytime,address,package,date1,date2,date3,bank,bankaccount,resolve,time1,time2,time3,time4,maifangcode,maifang,maifangaddress,maifangtelephone,maifangfox,yifangaddress,yifangtelephone,yifangfox,salemanid,saleman,status ");
			strSql.Append(" FROM t_contract ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
            return MySqlHelper.Query(strSql.ToString());
		}
        public DataSet GetList1(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM t_ssss ");
                strSql.Append(" where "+strWhere);
            return MySqlHelper.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM t_contract ");
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
				strSql.Append("order by T.contractid desc");
			}
			strSql.Append(")AS Row, T.*  from t_contract T ");
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
			parameters[0].Value = "t_contract";
			parameters[1].Value = "contractid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
