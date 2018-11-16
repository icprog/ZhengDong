using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public  class CompanyDaoEx : CompanyDao
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.CompanyEntity GetModelByCode(string code)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,code,type,fullname,shortname,generallevel,creditlevel,requiredlevel,managestandard,activelevel,loyalty,products,salesmancode,salesman,area,address,nature,manageprojects,registermoney,registertime,personnumber,zipcode,fox,website,linkmancode,linkman,currentlink,currentweekestimate,currentmonthestimate,nextlinkdate,description,validate,modifyman,modifytime,createman,createtime,isdelete,fatures,bank,account,threecard,type_customer,type_suppliers,type_quote,type_merchants,type_goods,type_agents,estimatepurchasetime,customerproperty,customergroup,cashdeposit,paymethod,competitors,requiredproduct,registerman,cooperation,province,zone,productrequire,freight,tare,yearSale,productgoods,yearproduct,supportproduct,yearsupport,cashdate,cashmethod,agentfeerate,issuingfeerate,billperiod,passfeerate,storagefee1,storagefee2,storagefee3,storagefee4,storagefee5,freight1,freight2,freight3,freight4,freight5,freight6,storageday1,storageday2,storageday3,storageday4,storageday5,paydays,requiregoods from t_company ");
            strSql.Append(" where code=@code");
            MySqlParameter[] parameters = {
					new MySqlParameter("@code", MySqlDbType.VarChar , 45)
			};
            parameters[0].Value = code;

            FishEntity.CompanyEntity model = new FishEntity.CompanyEntity();
            DataSet ds = MySqlHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel1(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        public bool UpdateCompnayLinkDate(  string companyCode , string weekestimate , string monthestimate , DateTime linkDate , string buyDate ,DateTime nextDate )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("Update t_company set currentlink=@currentlink ");
            strSql.Append(",nextlinkdate=@nextlinkdate");
            if(false == string.IsNullOrEmpty ( weekestimate ))
            {
                strSql.Append( string.Format ( " ,currentweekestimate='{0}'", weekestimate) );
            }

            if( false == string.IsNullOrEmpty( monthestimate ))
            {
               strSql.Append( string.Format (" ,currentmonthestimate='{0}'", monthestimate ));
            }
             strSql.Append("  ,estimatepurchasetime=@estimatepurchasetime where code=@code");

            MySqlParameter[] parameters = {
                                            new MySqlParameter("@currentlink" , MySqlDbType.VarChar , 45),
                                            new MySqlParameter ("@nextlinkdate",MySqlDbType.Timestamp),
                                           // new MySqlParameter("@currentmonthestimate",MySqlDbType.VarChar , 45),
                                            new MySqlParameter ("@estimatepurchasetime",MySqlDbType.VarChar , 45),
                                            new MySqlParameter("@code",MySqlDbType.VarChar,45)
                                          };
            parameters[0].Value = linkDate.ToString("yyyy-MM-dd HH:mm:ss");
            parameters[1].Value = nextDate;
            //parameters[2].Value = monthestimate;
            parameters[2].Value = buyDate;
            parameters[3].Value = companyCode;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(), parameters );
            return rows > 0 ? true : false;
        }
    }
}
