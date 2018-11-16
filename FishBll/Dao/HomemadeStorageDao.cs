using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class HomemadeStorageDao
    {
        public HomemadeStorageDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_homemadestorage");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string  code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_homemadestorage");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar ,45)
			};
            parameters[0].Value = code;

            return MySqlHelper.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.HomemadeStorageEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_homemadestorage(");
            strSql.Append("code,seq,productid,productcode,productname,intime,outtime,grossweight,tareweight,netweight,packages,unitprice,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa,sgs_fat,sgs_water,sgs_sand,label_lysine,label_methionine,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine,createman,createtime,modifyman,modifytime,isdelete,selfprice,saleprice,purchasemanid,purchaseman,storagemanid,storageman,storageweight,storagequantity,storagetime )");
			strSql.Append(" values (");
            strSql.Append("@code,@seq,@productid,@productcode,@productname,@intime,@outtime,@grossweight,@tareweight,@netweight,@packages,@unitprice,@sgs_protein,@sgs_tvn,@sgs_graypart,@sgs_sandsalt,@sgs_amine,@sgs_ffa,@sgs_fat,@sgs_water,@sgs_sand,@label_lysine,@label_methionine,@domestic_protein,@domestic_tvn,@domestic_graypart,@domestic_sandsalt,@domestic_sour,@domestic_lysine,@domestic_methionine,@createman,@createtime,@modifyman,@modifytime,@isdelete,@selfprice,@saleprice,@purchasemanid,@purchaseman,@storagemanid,@storageman,@storageweight,@storagequantity,@storagetime);");
            strSql.Append("select LAST_INSERT_ID();");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@seq", MySqlDbType.VarChar,45),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,45),
					new MySqlParameter("@intime", MySqlDbType.Timestamp),
					new MySqlParameter("@outtime", MySqlDbType.Timestamp),
					new MySqlParameter("@grossweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@tareweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@netweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@packages", MySqlDbType.Int32,11),
					new MySqlParameter("@unitprice", MySqlDbType.Decimal,12),
					new MySqlParameter("@sgs_protein", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_tvn", MySqlDbType.Int32,8),
					new MySqlParameter("@sgs_graypart", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_sandsalt", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_amine", MySqlDbType.Int32,8),
					new MySqlParameter("@sgs_ffa", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_fat", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_water", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_sand", MySqlDbType.Decimal,6),
					new MySqlParameter("@label_lysine", MySqlDbType.Decimal,6),
					new MySqlParameter("@label_methionine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_tvn", MySqlDbType.Int32,8),
					new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,6),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@createtime", MySqlDbType.Timestamp),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifytime", MySqlDbType.Timestamp),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,2),
                    new MySqlParameter("@selfprice", MySqlDbType.Decimal,20),
					new MySqlParameter("@saleprice", MySqlDbType.Decimal,20),
					new MySqlParameter("@purchasemanid", MySqlDbType.Int32,11),
					new MySqlParameter("@purchaseman", MySqlDbType.VarChar,45),
					new MySqlParameter("@storagemanid", MySqlDbType.Int32,11),
					new MySqlParameter("@storageman", MySqlDbType.VarChar,45),
					new MySqlParameter("@storageweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@storagequantity", MySqlDbType.Int32,11)   ,
                 new MySqlParameter("@storagetime", MySqlDbType.Timestamp)   
                                          };
			parameters[0].Value = model.code;
			parameters[1].Value = model.seq;
			parameters[2].Value = model.productid;
			parameters[3].Value = model.productcode;
			parameters[4].Value = model.productname;
			parameters[5].Value = model.intime;
			parameters[6].Value = model.outtime;
			parameters[7].Value = model.grossweight;
			parameters[8].Value = model.tareweight;
			parameters[9].Value = model.netweight;
			parameters[10].Value = model.packages;
			parameters[11].Value = model.unitprice;
			parameters[12].Value = model.sgs_protein;
			parameters[13].Value = model.sgs_tvn;
			parameters[14].Value = model.sgs_graypart;
			parameters[15].Value = model.sgs_sandsalt;
			parameters[16].Value = model.sgs_amine;
			parameters[17].Value = model.sgs_ffa;
			parameters[18].Value = model.sgs_fat;
			parameters[19].Value = model.sgs_water;
			parameters[20].Value = model.sgs_sand;
			parameters[21].Value = model.label_lysine;
			parameters[22].Value = model.label_methionine;
			parameters[23].Value = model.domestic_protein;
			parameters[24].Value = model.domestic_tvn;
			parameters[25].Value = model.domestic_graypart;
			parameters[26].Value = model.domestic_sandsalt;
			parameters[27].Value = model.domestic_sour;
			parameters[28].Value = model.domestic_lysine;
			parameters[29].Value = model.domestic_methionine;
			parameters[30].Value = model.createman;
			parameters[31].Value = model.createtime;
			parameters[32].Value = model.modifyman;
			parameters[33].Value = model.modifytime;
			parameters[34].Value = model.isdelete;
            parameters[35].Value = model.selfprice;
            parameters[36].Value = model.saleprice;
            parameters[37].Value = model.purchasemanid;
            parameters[38].Value = model.purchaseman;
            parameters[39].Value = model.storagemanid;
            parameters[40].Value = model.storageman;
            parameters[41].Value = model.storageweight;
            parameters[42].Value = model.storagequantity;
            parameters[43].Value = model.storagetime;

            int id = MySqlHelper.ExecuteSqlReturnId(strSql.ToString(), parameters);
            return id;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.HomemadeStorageEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_homemadestorage set ");
			strSql.Append("code=@code,");
			strSql.Append("seq=@seq,");
			strSql.Append("productid=@productid,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("productname=@productname,");
			strSql.Append("grossweight=@grossweight,");
			strSql.Append("tareweight=@tareweight,");
			strSql.Append("netweight=@netweight,");
			strSql.Append("packages=@packages,");
			strSql.Append("unitprice=@unitprice,");
			strSql.Append("sgs_protein=@sgs_protein,");
			strSql.Append("sgs_tvn=@sgs_tvn,");
			strSql.Append("sgs_graypart=@sgs_graypart,");
			strSql.Append("sgs_sandsalt=@sgs_sandsalt,");
			strSql.Append("sgs_amine=@sgs_amine,");
			strSql.Append("sgs_ffa=@sgs_ffa,");
			strSql.Append("sgs_fat=@sgs_fat,");
			strSql.Append("sgs_water=@sgs_water,");
			strSql.Append("sgs_sand=@sgs_sand,");
			strSql.Append("label_lysine=@label_lysine,");
			strSql.Append("label_methionine=@label_methionine,");
			strSql.Append("domestic_protein=@domestic_protein,");
			strSql.Append("domestic_tvn=@domestic_tvn,");
			strSql.Append("domestic_graypart=@domestic_graypart,");
			strSql.Append("domestic_sandsalt=@domestic_sandsalt,");
			strSql.Append("domestic_sour=@domestic_sour,");
			strSql.Append("domestic_lysine=@domestic_lysine,");
			strSql.Append("domestic_methionine=@domestic_methionine,");
			strSql.Append("createman=@createman,");
			strSql.Append("modifyman=@modifyman,");
			strSql.Append("isdelete=@isdelete,");
            strSql.Append("selfprice=@selfprice,");
            strSql.Append("saleprice=@saleprice,");
            strSql.Append("purchasemanid=@purchasemanid,");
            strSql.Append("purchaseman=@purchaseman,");
            strSql.Append("storagemanid=@storagemanid,");
            strSql.Append("storageman=@storageman,");
            strSql.Append("storageweight=@storageweight,");
            strSql.Append("storagequantity=@storagequantity,");
            strSql.Append("storagetime=@storagetime");

			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar,45),
					new MySqlParameter("@seq", MySqlDbType.VarChar,45),
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,45),
					new MySqlParameter("@grossweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@tareweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@netweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@packages", MySqlDbType.Int32,11),
					new MySqlParameter("@unitprice", MySqlDbType.Decimal,12),
					new MySqlParameter("@sgs_protein", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_tvn", MySqlDbType.Int32,8),
					new MySqlParameter("@sgs_graypart", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_sandsalt", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_amine", MySqlDbType.Int32,8),
					new MySqlParameter("@sgs_ffa", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_fat", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_water", MySqlDbType.Decimal,6),
					new MySqlParameter("@sgs_sand", MySqlDbType.Decimal,6),
					new MySqlParameter("@label_lysine", MySqlDbType.Decimal,6),
					new MySqlParameter("@label_methionine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_protein", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_tvn", MySqlDbType.Int32,8),
					new MySqlParameter("@domestic_graypart", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sandsalt", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_sour", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_lysine", MySqlDbType.Decimal,6),
					new MySqlParameter("@domestic_methionine", MySqlDbType.Decimal,6),
					new MySqlParameter("@createman", MySqlDbType.VarChar,45),
					new MySqlParameter("@modifyman", MySqlDbType.VarChar,45),
					new MySqlParameter("@isdelete", MySqlDbType.Int16,2),
                    new MySqlParameter("@selfprice", MySqlDbType.Decimal,10),
					new MySqlParameter("@saleprice", MySqlDbType.Decimal,6),
					new MySqlParameter("@purchasemanid", MySqlDbType.Int32,11),
					new MySqlParameter("@purchaseman", MySqlDbType.VarChar,45),
					new MySqlParameter("@storagemanid", MySqlDbType.Int32,11),
					new MySqlParameter("@storageman", MySqlDbType.VarChar,45),
					new MySqlParameter("@storageweight", MySqlDbType.Decimal,12),
					new MySqlParameter("@storagequantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@storagetime", MySqlDbType.Timestamp),
					new MySqlParameter("@id", MySqlDbType.Int32,11)};
			parameters[0].Value = model.code;
			parameters[1].Value = model.seq;
			parameters[2].Value = model.productid;
			parameters[3].Value = model.productcode;
			parameters[4].Value = model.productname;
			parameters[5].Value = model.grossweight;
			parameters[6].Value = model.tareweight;
			parameters[7].Value = model.netweight;
			parameters[8].Value = model.packages;
			parameters[9].Value = model.unitprice;
			parameters[10].Value = model.sgs_protein;
			parameters[11].Value = model.sgs_tvn;
			parameters[12].Value = model.sgs_graypart;
			parameters[13].Value = model.sgs_sandsalt;
			parameters[14].Value = model.sgs_amine;
			parameters[15].Value = model.sgs_ffa;
			parameters[16].Value = model.sgs_fat;
			parameters[17].Value = model.sgs_water;
			parameters[18].Value = model.sgs_sand;
			parameters[19].Value = model.label_lysine;
			parameters[20].Value = model.label_methionine;
			parameters[21].Value = model.domestic_protein;
			parameters[22].Value = model.domestic_tvn;
			parameters[23].Value = model.domestic_graypart;
			parameters[24].Value = model.domestic_sandsalt;
			parameters[25].Value = model.domestic_sour;
			parameters[26].Value = model.domestic_lysine;
			parameters[27].Value = model.domestic_methionine;
			parameters[28].Value = model.createman;
			parameters[29].Value = model.modifyman;
			parameters[30].Value = model.isdelete;
            parameters[31].Value = model.selfprice;
            parameters[32].Value = model.saleprice;
            parameters[33].Value = model.purchasemanid;
            parameters[34].Value = model.purchaseman;
            parameters[35].Value = model.storagemanid;
            parameters[36].Value = model.storageman;
            parameters[37].Value = model.storageweight;
            parameters[38].Value = model.storagequantity;
            parameters[39].Value = model.storagetime;
			parameters[40].Value = model.id;

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

        public bool upde(FishEntity.ProductEntity model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_product set ");
            strSql.Append("isdelete4=5 ");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
            new MySqlParameter("@code", MySqlDbType.VarChar, 45) };
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
			strSql.Append("delete from t_homemadestorage ");
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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from t_homemadestorage ");
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
        public FishEntity.HomemadeStorageEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select id,code,seq,productid,productcode,productname,intime,outtime,grossweight,tareweight,netweight,packages,unitprice,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa,sgs_fat,sgs_water,sgs_sand,label_lysine,label_methionine,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine,createman,createtime,modifyman,modifytime,isdelete,selfprice,saleprice,purchasemanid,purchaseman,storagemanid,storageman,storageweight,storagequantity,storagetime from t_homemadestorage ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

            FishEntity.HomemadeStorageEntity model = new FishEntity.HomemadeStorageEntity();
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
		public FishEntity.HomemadeStorageEntity DataRowToModel(DataRow row)
		{
            FishEntity.HomemadeStorageEntity model = new FishEntity.HomemadeStorageEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["code"]!=null)
				{
					model.code=row["code"].ToString();
				}
				if(row["seq"]!=null)
				{
					model.seq=row["seq"].ToString();
				}
				if(row["productid"]!=null && row["productid"].ToString()!="")
				{
					model.productid=int.Parse(row["productid"].ToString());
				}
				if(row["productcode"]!=null)
				{
					model.productcode=row["productcode"].ToString();
				}
				if(row["productname"]!=null)
				{
					model.productname=row["productname"].ToString();
				}
				if(row["intime"]!=null && row["intime"].ToString()!="")
				{
					model.intime=DateTime.Parse(row["intime"].ToString());
				}
				if(row["outtime"]!=null && row["outtime"].ToString()!="")
				{
					model.outtime=DateTime.Parse(row["outtime"].ToString());
				}
				if(row["grossweight"]!=null && row["grossweight"].ToString()!="")
				{
					model.grossweight=decimal.Parse(row["grossweight"].ToString());
				}
				if(row["tareweight"]!=null && row["tareweight"].ToString()!="")
				{
					model.tareweight=decimal.Parse(row["tareweight"].ToString());
				}
				if(row["netweight"]!=null && row["netweight"].ToString()!="")
				{
					model.netweight=decimal.Parse(row["netweight"].ToString());
				}
				if(row["packages"]!=null && row["packages"].ToString()!="")
				{
					model.packages=int.Parse(row["packages"].ToString());
				}
				if(row["unitprice"]!=null && row["unitprice"].ToString()!="")
				{
					model.unitprice=decimal.Parse(row["unitprice"].ToString());
				}
				if(row["sgs_protein"]!=null && row["sgs_protein"].ToString()!="")
				{
					model.sgs_protein=decimal.Parse(row["sgs_protein"].ToString());
				}
				if(row["sgs_tvn"]!=null && row["sgs_tvn"].ToString()!="")
				{
					model.sgs_tvn=int.Parse(row["sgs_tvn"].ToString());
				}
				if(row["sgs_graypart"]!=null && row["sgs_graypart"].ToString()!="")
				{
					model.sgs_graypart=decimal.Parse(row["sgs_graypart"].ToString());
				}
				if(row["sgs_sandsalt"]!=null && row["sgs_sandsalt"].ToString()!="")
				{
					model.sgs_sandsalt=decimal.Parse(row["sgs_sandsalt"].ToString());
				}
				if(row["sgs_amine"]!=null && row["sgs_amine"].ToString()!="")
				{
					model.sgs_amine=int.Parse(row["sgs_amine"].ToString());
				}
				if(row["sgs_ffa"]!=null && row["sgs_ffa"].ToString()!="")
				{
					model.sgs_ffa=decimal.Parse(row["sgs_ffa"].ToString());
				}
				if(row["sgs_fat"]!=null && row["sgs_fat"].ToString()!="")
				{
					model.sgs_fat=decimal.Parse(row["sgs_fat"].ToString());
				}
				if(row["sgs_water"]!=null && row["sgs_water"].ToString()!="")
				{
					model.sgs_water=decimal.Parse(row["sgs_water"].ToString());
				}
				if(row["sgs_sand"]!=null && row["sgs_sand"].ToString()!="")
				{
					model.sgs_sand=decimal.Parse(row["sgs_sand"].ToString());
				}
				if(row["label_lysine"]!=null && row["label_lysine"].ToString()!="")
				{
					model.label_lysine=decimal.Parse(row["label_lysine"].ToString());
				}
				if(row["label_methionine"]!=null && row["label_methionine"].ToString()!="")
				{
					model.label_methionine=decimal.Parse(row["label_methionine"].ToString());
				}
				if(row["domestic_protein"]!=null && row["domestic_protein"].ToString()!="")
				{
					model.domestic_protein=decimal.Parse(row["domestic_protein"].ToString());
				}
				if(row["domestic_tvn"]!=null && row["domestic_tvn"].ToString()!="")
				{
					model.domestic_tvn=int.Parse(row["domestic_tvn"].ToString());
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
				if(row["domestic_methionine"]!=null && row["domestic_methionine"].ToString()!="")
				{
					model.domestic_methionine=decimal.Parse(row["domestic_methionine"].ToString());
				}
				if(row["createman"]!=null)
				{
					model.createman=row["createman"].ToString();
				}
				if(row["createtime"]!=null && row["createtime"].ToString()!="")
				{
					model.createtime=DateTime.Parse(row["createtime"].ToString());
				}
				if(row["modifyman"]!=null)
				{
					model.modifyman=row["modifyman"].ToString();
				}
				if(row["modifytime"]!=null && row["modifytime"].ToString()!="")
				{
					model.modifytime=DateTime.Parse(row["modifytime"].ToString());
				}
				if(row["isdelete"]!=null && row["isdelete"].ToString()!="")
				{
					model.isdelete=int.Parse(row["isdelete"].ToString());
				}
                if (row["selfprice"] != null && row["selfprice"].ToString() != "")
                {
                    model.selfprice = decimal.Parse(row["selfprice"].ToString());
                }
                if (row["saleprice"] != null && row["saleprice"].ToString() != "")
                {
                    model.saleprice = decimal.Parse(row["saleprice"].ToString());
                }
                if (row["purchasemanid"] != null && row["purchasemanid"].ToString() != "")
                {
                    model.purchasemanid = int.Parse(row["purchasemanid"].ToString());
                }
                if (row["purchaseman"] != null)
                {
                    model.purchaseman = row["purchaseman"].ToString();
                }
                if (row["storagemanid"] != null && row["storagemanid"].ToString() != "")
                {
                    model.storagemanid = int.Parse(row["storagemanid"].ToString());
                }
                if (row["storageman"] != null)
                {
                    model.storageman = row["storageman"].ToString();
                }
                if (row["storageweight"] != null && row["storageweight"].ToString() != "")
                {
                    model.storageweight = decimal.Parse(row["storageweight"].ToString());
                }
                if (row["storagequantity"] != null && row["storagequantity"].ToString() != "")
                {
                    model.storagequantity = int.Parse(row["storagequantity"].ToString());
                }
                if (row["storagetime"] != null && row["storagetime"].ToString() != "")
                {
                    model.storagetime = DateTime.Parse(row["storagetime"].ToString());
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
            strSql.Append("select id,code,seq,productid,productcode,productname,intime,outtime,grossweight,tareweight,netweight,packages,unitprice,sgs_protein,sgs_tvn,sgs_graypart,sgs_sandsalt,sgs_amine,sgs_ffa,sgs_fat,sgs_water,sgs_sand,label_lysine,label_methionine,domestic_protein,domestic_tvn,domestic_graypart,domestic_sandsalt,domestic_sour,domestic_lysine,domestic_methionine,createman,createtime,modifyman,modifytime,isdelete,selfprice,saleprice,purchasemanid,purchaseman,storagemanid,storageman,storageweight,storagequantity,storagetime ");
			strSql.Append(" FROM t_homemadestorage ");
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
			strSql.Append("select count(1) FROM t_homemadestorage ");
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
			strSql.Append(")AS Row, T.*  from t_homemadestorage T ");
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
			parameters[0].Value = "t_homemadestorage";
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

		#endregion  ExtensionMethod
    }
}
