using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class CheckRecordDao
    {
        public CheckRecordDao()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from t_checkrecord");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			return MySqlHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.CheckRecordEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into t_checkrecord(");
			strSql.Append("productid,productcode,productname,recordno,checkdate,testdate,testcompanyid,testcompanycode,testcompanyname,Digestibility,regularindex1,regularindex2,regularindex3,regularindex4,regularindex5,regularindex6,regularindex7,regularindex8,regularindex9,regularindex10,regularindex11,regularindex12,aminoindex1,aminoindex2,aminoindex3,aminoindex4,aminoindex5,aminoindex6,aminoindex7,aminoindex8,aminoindex9,aminoindex10,aminoindex11,aminoindex12,aminoindex13,aminoindex14,aminoindex15,aminoindex16,aminoindex17,aminoindex18,aminoindex19,aminoindex20,aminoindex21,aminoindex22,aminoindex23,specialindex1,specialindex2,specialindex3,specialindex4,specialindex5,fee,sendsamplename,describe1)");
			strSql.Append(" values (");
			strSql.Append("@productid,@productcode,@productname,@recordno,@checkdate,@testdate,@testcompanyid,@testcompanycode,@testcompanyname,@Digestibility,@regularindex1,@regularindex2,@regularindex3,@regularindex4,@regularindex5,@regularindex6,@regularindex7,@regularindex8,@regularindex9,@regularindex10,@regularindex11,@regularindex12,@aminoindex1,@aminoindex2,@aminoindex3,@aminoindex4,@aminoindex5,@aminoindex6,@aminoindex7,@aminoindex8,@aminoindex9,@aminoindex10,@aminoindex11,@aminoindex12,@aminoindex13,@aminoindex14,@aminoindex15,@aminoindex16,@aminoindex17,@aminoindex18,@aminoindex19,@aminoindex20,@aminoindex21,@aminoindex22,@aminoindex23,@specialindex1,@specialindex2,@specialindex3,@specialindex4,@specialindex5,@fee,@sendsamplename,@describe1);");
            strSql.Append("select LAST_INSERT_ID();");

            MySqlParameter[] parameters = {
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,255),
					new MySqlParameter("@recordno", MySqlDbType.Int32,11),
					new MySqlParameter("@checkdate", MySqlDbType.VarChar,255),
					new MySqlParameter("@testdate", MySqlDbType.VarChar,255),
					new MySqlParameter("@testcompanyid", MySqlDbType.Int32,11),
					new MySqlParameter("@testcompanycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@testcompanyname", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Digestibility",MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex1", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex2", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex3", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex4", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex5", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex6", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex7", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex8", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex9", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex10", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex11", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex12", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex1", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex2", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex3", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex4", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex5", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex6", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex7", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex8", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex9", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex10", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex11", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex12", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex13", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex14", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex15", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex16", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex17", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex18", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex19", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex20", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex21", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex22", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex23", MySqlDbType.Decimal,6),
					new MySqlParameter("@specialindex1", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex2", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex3", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex4", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex5", MySqlDbType.VarChar,255),
					new MySqlParameter("@fee", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sendsamplename",MySqlDbType.VarChar,225),
                    new MySqlParameter("@describe1",MySqlDbType.VarChar,255)
            };
			parameters[0].Value = model.productid;
			parameters[1].Value = model.productcode;
			parameters[2].Value = model.productname;
			parameters[3].Value = model.recordno;
			parameters[4].Value = model.checkdate;
			parameters[5].Value = model.testdate;
			parameters[6].Value = model.testcompanyid;
			parameters[7].Value = model.testcompanycode;
			parameters[8].Value = model.testcompanyname;
            parameters[9].Value = model.Digestibility;
            parameters[10].Value = model.regularindex1;
			parameters[11].Value = model.regularindex2;
			parameters[12].Value = model.regularindex3;
			parameters[13].Value = model.regularindex4;
			parameters[14].Value = model.regularindex5;
			parameters[15].Value = model.regularindex6;
			parameters[16].Value = model.regularindex7;
			parameters[17].Value = model.regularindex8;
			parameters[18].Value = model.regularindex9;
			parameters[19].Value = model.regularindex10;
			parameters[20].Value = model.regularindex11;
			parameters[21].Value = model.regularindex12;
			parameters[22].Value = model.aminoindex1;
			parameters[23].Value = model.aminoindex2;
			parameters[24].Value = model.aminoindex3;
			parameters[25].Value = model.aminoindex4;
			parameters[26].Value = model.aminoindex5;
			parameters[27].Value = model.aminoindex6;
			parameters[28].Value = model.aminoindex7;
			parameters[29].Value = model.aminoindex8;
			parameters[30].Value = model.aminoindex9;
			parameters[31].Value = model.aminoindex10;
			parameters[32].Value = model.aminoindex11;
			parameters[33].Value = model.aminoindex12;
			parameters[34].Value = model.aminoindex13;
			parameters[35].Value = model.aminoindex14;
			parameters[36].Value = model.aminoindex15;
			parameters[37].Value = model.aminoindex16;
			parameters[38].Value = model.aminoindex17;
			parameters[39].Value = model.aminoindex18;
			parameters[40].Value = model.aminoindex19;
			parameters[41].Value = model.aminoindex20;
			parameters[42].Value = model.aminoindex21;
			parameters[43].Value = model.aminoindex22;
			parameters[44].Value = model.aminoindex23;
			parameters[45].Value = model.specialindex1;
			parameters[46].Value = model.specialindex2;
			parameters[47].Value = model.specialindex3;
			parameters[48].Value = model.specialindex4;
			parameters[49].Value = model.specialindex5;
			parameters[50].Value = model.fee;
            parameters[51].Value = model.Sendsamplename;
            parameters[52].Value = model.Describe;
        
            int rows=MySqlHelper.ExecuteSqlReturnId(strSql.ToString(),parameters);
            return rows;
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CheckRecordEntity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update t_checkrecord set ");
			strSql.Append("productid=@productid,");
			strSql.Append("productcode=@productcode,");
			strSql.Append("productname=@productname,");
			strSql.Append("recordno=@recordno,");
			strSql.Append("checkdate=@checkdate,");
			strSql.Append("testdate=@testdate,");
			strSql.Append("testcompanyid=@testcompanyid,");
			strSql.Append("testcompanycode=@testcompanycode,");
			strSql.Append("testcompanyname=@testcompanyname,");
            strSql.Append("Digestibility=@Digestibility,");
			strSql.Append("regularindex1=@regularindex1,");
			strSql.Append("regularindex2=@regularindex2,");
			strSql.Append("regularindex3=@regularindex3,");
			strSql.Append("regularindex4=@regularindex4,");
			strSql.Append("regularindex5=@regularindex5,");
			strSql.Append("regularindex6=@regularindex6,");
			strSql.Append("regularindex7=@regularindex7,");
			strSql.Append("regularindex8=@regularindex8,");
			strSql.Append("regularindex9=@regularindex9,");
			strSql.Append("regularindex10=@regularindex10,");
			strSql.Append("regularindex11=@regularindex11,");
			strSql.Append("regularindex12=@regularindex12,");
			strSql.Append("aminoindex1=@aminoindex1,");
			strSql.Append("aminoindex2=@aminoindex2,");
			strSql.Append("aminoindex3=@aminoindex3,");
			strSql.Append("aminoindex4=@aminoindex4,");
			strSql.Append("aminoindex5=@aminoindex5,");
			strSql.Append("aminoindex6=@aminoindex6,");
			strSql.Append("aminoindex7=@aminoindex7,");
			strSql.Append("aminoindex8=@aminoindex8,");
			strSql.Append("aminoindex9=@aminoindex9,");
			strSql.Append("aminoindex10=@aminoindex10,");
			strSql.Append("aminoindex11=@aminoindex11,");
			strSql.Append("aminoindex12=@aminoindex12,");
			strSql.Append("aminoindex13=@aminoindex13,");
			strSql.Append("aminoindex14=@aminoindex14,");
			strSql.Append("aminoindex15=@aminoindex15,");
			strSql.Append("aminoindex16=@aminoindex16,");
			strSql.Append("aminoindex17=@aminoindex17,");
			strSql.Append("aminoindex18=@aminoindex18,");
			strSql.Append("aminoindex19=@aminoindex19,");
			strSql.Append("aminoindex20=@aminoindex20,");
			strSql.Append("aminoindex21=@aminoindex21,");
			strSql.Append("aminoindex22=@aminoindex22,");
			strSql.Append("aminoindex23=@aminoindex23,");
			strSql.Append("specialindex1=@specialindex1,");
			strSql.Append("specialindex2=@specialindex2,");
			strSql.Append("specialindex3=@specialindex3,");
			strSql.Append("specialindex4=@specialindex4,");
			strSql.Append("specialindex5=@specialindex5,");
			strSql.Append("fee=@fee,");
            strSql.Append("sendsamplename=@sendsamplename,");
            strSql.Append("describe1=@describe1");
            strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@productid", MySqlDbType.Int32,11),
					new MySqlParameter("@productcode", MySqlDbType.VarChar,45),
					new MySqlParameter("@productname", MySqlDbType.VarChar,255),
					new MySqlParameter("@recordno", MySqlDbType.Int32,11),
					new MySqlParameter("@checkdate", MySqlDbType.VarChar,255),
					new MySqlParameter("@testdate", MySqlDbType.VarChar,255),
					new MySqlParameter("@testcompanyid", MySqlDbType.Int32,11),
					new MySqlParameter("@testcompanycode", MySqlDbType.VarChar,45),
					new MySqlParameter("@testcompanyname", MySqlDbType.VarChar,255),
                    new MySqlParameter("@Digestibility",MySqlDbType.Decimal,6),
                    new MySqlParameter("@regularindex1", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex2", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex3", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex4", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex5", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex6", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex7", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex8", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex9", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex10", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex11", MySqlDbType.Decimal,6),
					new MySqlParameter("@regularindex12", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex1", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex2", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex3", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex4", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex5", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex6", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex7", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex8", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex9", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex10", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex11", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex12", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex13", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex14", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex15", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex16", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex17", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex18", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex19", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex20", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex21", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex22", MySqlDbType.Decimal,6),
					new MySqlParameter("@aminoindex23", MySqlDbType.Decimal,6),
					new MySqlParameter("@specialindex1", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex2", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex3", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex4", MySqlDbType.VarChar,255),
					new MySqlParameter("@specialindex5", MySqlDbType.VarChar,255),
					new MySqlParameter("@fee", MySqlDbType.Decimal,6),
                    new MySqlParameter("@sendsamplename",MySqlDbType.VarChar,255),
                    new MySqlParameter("@describe1",MySqlDbType.VarChar,255),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)            };
			parameters[0].Value = model.productid;
			parameters[1].Value = model.productcode;
			parameters[2].Value = model.productname;
			parameters[3].Value = model.recordno;
			parameters[4].Value = model.checkdate;
			parameters[5].Value = model.testdate;
			parameters[6].Value = model.testcompanyid;
			parameters[7].Value = model.testcompanycode;
			parameters[8].Value = model.testcompanyname;
            parameters[9].Value = model.Digestibility;
            parameters[10].Value = model.regularindex1;
			parameters[11].Value = model.regularindex2;
			parameters[12].Value = model.regularindex3;
			parameters[13].Value = model.regularindex4;
			parameters[14].Value = model.regularindex5;
			parameters[15].Value = model.regularindex6;
			parameters[16].Value = model.regularindex7;
			parameters[17].Value = model.regularindex8;
			parameters[18].Value = model.regularindex9;
			parameters[19].Value = model.regularindex10;
			parameters[20].Value = model.regularindex11;
			parameters[21].Value = model.regularindex12;
			parameters[22].Value = model.aminoindex1;
			parameters[23].Value = model.aminoindex2;
			parameters[24].Value = model.aminoindex3;
			parameters[25].Value = model.aminoindex4;
			parameters[26].Value = model.aminoindex5;
			parameters[27].Value = model.aminoindex6;
			parameters[28].Value = model.aminoindex7;
			parameters[29].Value = model.aminoindex8;
			parameters[30].Value = model.aminoindex9;
			parameters[31].Value = model.aminoindex10;
			parameters[32].Value = model.aminoindex11;
			parameters[33].Value = model.aminoindex12;
			parameters[34].Value = model.aminoindex13;
			parameters[35].Value = model.aminoindex14;
			parameters[36].Value = model.aminoindex15;
			parameters[37].Value = model.aminoindex16;
			parameters[38].Value = model.aminoindex17;
			parameters[39].Value = model.aminoindex18;
			parameters[40].Value = model.aminoindex19;
			parameters[41].Value = model.aminoindex20;
			parameters[42].Value = model.aminoindex21;
			parameters[43].Value = model.aminoindex22;
			parameters[44].Value = model.aminoindex23;
			parameters[45].Value = model.specialindex1;
			parameters[46].Value = model.specialindex2;
			parameters[47].Value = model.specialindex3;
			parameters[48].Value = model.specialindex4;
			parameters[49].Value = model.specialindex5;
			parameters[50].Value = model.fee;
            parameters[51].Value = model.Sendsamplename;
            parameters[52].Value = model.Describe;
        
            parameters[53].Value = model.id;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_checkrecord ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			int rows=MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
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
			strSql.Append("delete from t_checkrecord ");
			strSql.Append(" where id in ("+idlist + ")  ");
			int rows=MySqlHelper.ExecuteSql(strSql.ToString());
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
		public FishEntity.CheckRecordEntity GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,productid,productcode,productname,recordno,checkdate,testdate,testcompanyid,testcompanycode,testcompanyname,Digestibility,regularindex1,regularindex2,regularindex3,regularindex4,regularindex5,regularindex6,regularindex7,regularindex8,regularindex9,regularindex10,regularindex11,regularindex12,aminoindex1,aminoindex2,aminoindex3,aminoindex4,aminoindex5,aminoindex6,aminoindex7,aminoindex8,aminoindex9,aminoindex10,aminoindex11,aminoindex12,aminoindex13,aminoindex14,aminoindex15,aminoindex16,aminoindex17,aminoindex18,aminoindex19,aminoindex20,aminoindex21,aminoindex22,aminoindex23,specialindex1,specialindex2,specialindex3,specialindex4,specialindex5,fee,sendsamplename,describe1   from t_checkrecord ");
			strSql.Append(" where id=@id");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32)
			};
			parameters[0].Value = id;

			FishEntity.CheckRecordEntity model=new FishEntity.CheckRecordEntity();
			DataSet ds=MySqlHelper.Query(strSql.ToString(),parameters);
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
		public FishEntity.CheckRecordEntity DataRowToModel(DataRow row)
		{
			FishEntity.CheckRecordEntity model=new FishEntity.CheckRecordEntity();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
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
				if(row["recordno"]!=null && row["recordno"].ToString()!="")
				{
					model.recordno=int.Parse(row["recordno"].ToString());
				}
				if(row["checkdate"]!=null)
				{
					model.checkdate=row["checkdate"].ToString();
				}
				if(row["testdate"]!=null)
				{
					model.testdate=row["testdate"].ToString();
				}
				if(row["testcompanyid"]!=null && row["testcompanyid"].ToString()!="")
				{
					model.testcompanyid=int.Parse(row["testcompanyid"].ToString());
				}
				if(row["testcompanycode"]!=null)
				{
					model.testcompanycode=row["testcompanycode"].ToString();
				}
				if(row["testcompanyname"]!=null)
				{
					model.testcompanyname=row["testcompanyname"].ToString();
				}
                if (row["Digestibility"]!=null&&row["Digestibility"].ToString()!="")
                {
                    model.Digestibility = decimal.Parse(row["Digestibility"].ToString());
                }
				if(row["regularindex1"]!=null && row["regularindex1"].ToString()!="")
				{
					model.regularindex1=decimal.Parse(row["regularindex1"].ToString());
				}
				if(row["regularindex2"]!=null && row["regularindex2"].ToString()!="")
				{
					model.regularindex2=decimal.Parse(row["regularindex2"].ToString());
				}
				if(row["regularindex3"]!=null && row["regularindex3"].ToString()!="")
				{
					model.regularindex3=decimal.Parse(row["regularindex3"].ToString());
				}
				if(row["regularindex4"]!=null && row["regularindex4"].ToString()!="")
				{
					model.regularindex4=decimal.Parse(row["regularindex4"].ToString());
				}
				if(row["regularindex5"]!=null && row["regularindex5"].ToString()!="")
				{
					model.regularindex5=decimal.Parse(row["regularindex5"].ToString());
				}
				if(row["regularindex6"]!=null && row["regularindex6"].ToString()!="")
				{
					model.regularindex6=decimal.Parse(row["regularindex6"].ToString());
				}
				if(row["regularindex7"]!=null && row["regularindex7"].ToString()!="")
				{
					model.regularindex7=decimal.Parse(row["regularindex7"].ToString());
				}
				if(row["regularindex8"]!=null && row["regularindex8"].ToString()!="")
				{
					model.regularindex8=decimal.Parse(row["regularindex8"].ToString());
				}
				if(row["regularindex9"]!=null && row["regularindex9"].ToString()!="")
				{
					model.regularindex9=decimal.Parse(row["regularindex9"].ToString());
				}
				if(row["regularindex10"]!=null && row["regularindex10"].ToString()!="")
				{
					model.regularindex10=decimal.Parse(row["regularindex10"].ToString());
				}
				if(row["regularindex11"]!=null && row["regularindex11"].ToString()!="")
				{
					model.regularindex11=decimal.Parse(row["regularindex11"].ToString());
				}
				if(row["regularindex12"]!=null && row["regularindex12"].ToString()!="")
				{
					model.regularindex12=decimal.Parse(row["regularindex12"].ToString());
				}
				if(row["aminoindex1"]!=null && row["aminoindex1"].ToString()!="")
				{
					model.aminoindex1=decimal.Parse(row["aminoindex1"].ToString());
				}
				if(row["aminoindex2"]!=null && row["aminoindex2"].ToString()!="")
				{
					model.aminoindex2=decimal.Parse(row["aminoindex2"].ToString());
				}
				if(row["aminoindex3"]!=null && row["aminoindex3"].ToString()!="")
				{
					model.aminoindex3=decimal.Parse(row["aminoindex3"].ToString());
				}
				if(row["aminoindex4"]!=null && row["aminoindex4"].ToString()!="")
				{
					model.aminoindex4=decimal.Parse(row["aminoindex4"].ToString());
				}
				if(row["aminoindex5"]!=null && row["aminoindex5"].ToString()!="")
				{
					model.aminoindex5=decimal.Parse(row["aminoindex5"].ToString());
				}
				if(row["aminoindex6"]!=null && row["aminoindex6"].ToString()!="")
				{
					model.aminoindex6=decimal.Parse(row["aminoindex6"].ToString());
				}
				if(row["aminoindex7"]!=null && row["aminoindex7"].ToString()!="")
				{
					model.aminoindex7=decimal.Parse(row["aminoindex7"].ToString());
				}
				if(row["aminoindex8"]!=null && row["aminoindex8"].ToString()!="")
				{
					model.aminoindex8=decimal.Parse(row["aminoindex8"].ToString());
				}
				if(row["aminoindex9"]!=null && row["aminoindex9"].ToString()!="")
				{
					model.aminoindex9=decimal.Parse(row["aminoindex9"].ToString());
				}
				if(row["aminoindex10"]!=null && row["aminoindex10"].ToString()!="")
				{
					model.aminoindex10=decimal.Parse(row["aminoindex10"].ToString());
				}
				if(row["aminoindex11"]!=null && row["aminoindex11"].ToString()!="")
				{
					model.aminoindex11=decimal.Parse(row["aminoindex11"].ToString());
				}
				if(row["aminoindex12"]!=null && row["aminoindex12"].ToString()!="")
				{
					model.aminoindex12=decimal.Parse(row["aminoindex12"].ToString());
				}
				if(row["aminoindex13"]!=null && row["aminoindex13"].ToString()!="")
				{
					model.aminoindex13=decimal.Parse(row["aminoindex13"].ToString());
				}
				if(row["aminoindex14"]!=null && row["aminoindex14"].ToString()!="")
				{
					model.aminoindex14=decimal.Parse(row["aminoindex14"].ToString());
				}
				if(row["aminoindex15"]!=null && row["aminoindex15"].ToString()!="")
				{
					model.aminoindex15=decimal.Parse(row["aminoindex15"].ToString());
				}
				if(row["aminoindex16"]!=null && row["aminoindex16"].ToString()!="")
				{
					model.aminoindex16=decimal.Parse(row["aminoindex16"].ToString());
				}
				if(row["aminoindex17"]!=null && row["aminoindex17"].ToString()!="")
				{
					model.aminoindex17=decimal.Parse(row["aminoindex17"].ToString());
				}
				if(row["aminoindex18"]!=null && row["aminoindex18"].ToString()!="")
				{
					model.aminoindex18=decimal.Parse(row["aminoindex18"].ToString());
				}
				if(row["aminoindex19"]!=null && row["aminoindex19"].ToString()!="")
				{
					model.aminoindex19=decimal.Parse(row["aminoindex19"].ToString());
				}
				if(row["aminoindex20"]!=null && row["aminoindex20"].ToString()!="")
				{
					model.aminoindex20=decimal.Parse(row["aminoindex20"].ToString());
				}
				if(row["aminoindex21"]!=null && row["aminoindex21"].ToString()!="")
				{
					model.aminoindex21=decimal.Parse(row["aminoindex21"].ToString());
				}
				if(row["aminoindex22"]!=null && row["aminoindex22"].ToString()!="")
				{
					model.aminoindex22=decimal.Parse(row["aminoindex22"].ToString());
				}
				if(row["aminoindex23"]!=null && row["aminoindex23"].ToString()!="")
				{
					model.aminoindex23=decimal.Parse(row["aminoindex23"].ToString());
				}
				if(row["specialindex1"]!=null)
				{
					model.specialindex1=row["specialindex1"].ToString();
				}
				if(row["specialindex2"]!=null)
				{
					model.specialindex2=row["specialindex2"].ToString();
				}
				if(row["specialindex3"]!=null)
				{
					model.specialindex3=row["specialindex3"].ToString();
				}
				if(row["specialindex4"]!=null)
				{
					model.specialindex4=row["specialindex4"].ToString();
				}
				if(row["specialindex5"]!=null)
				{
					model.specialindex5=row["specialindex5"].ToString();
				}
				if(row["fee"]!=null && row["fee"].ToString()!="")
				{
					model.fee=decimal.Parse(row["fee"].ToString());
				}
                if (row["sendsamplename"]!=null)
                {
                    model.Sendsamplename = row["sendsamplename"].ToString();
                }
                if (row["describe1"] !=null)
                {
                    model.Describe = row["describe1"].ToString();
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
			strSql.Append("select id,productid,productcode,productname,recordno,checkdate,testdate,testcompanyid,testcompanycode,testcompanyname,Digestibility,regularindex1,regularindex2,regularindex3,regularindex4,regularindex5,regularindex6,regularindex7,regularindex8,regularindex9,regularindex10,regularindex11,regularindex12,aminoindex1,aminoindex2,aminoindex3,aminoindex4,aminoindex5,aminoindex6,aminoindex7,aminoindex8,aminoindex9,aminoindex10,aminoindex11,aminoindex12,aminoindex13,aminoindex14,aminoindex15,aminoindex16,aminoindex17,aminoindex18,aminoindex19,aminoindex20,aminoindex21,aminoindex22,aminoindex23,specialindex1,specialindex2,specialindex3,specialindex4,specialindex5,fee,describe1,sendsamplename  ");
			strSql.Append(" FROM t_checkrecord ");
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
			strSql.Append("select count(1) FROM t_checkrecord ");
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
			strSql.Append(")AS Row, T.*  from t_checkrecord T ");
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
			parameters[0].Value = "t_checkrecord";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return MySqlHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
    }
}
