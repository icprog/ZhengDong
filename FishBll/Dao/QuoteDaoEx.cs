using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace FishBll.Dao
{
    public class QuoteDaoEx : QuoteDao
    {
        public List<FishEntity.QuoteEntity> Query()
        {
            return null;
        }

        public bool UpdateLatestQuote(int productid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_productex a inner join ");
            strSql.Append(" ( select * from t_quote  where productid= " + productid + " order by quotedate desc , quotetime desc limit 1 ) b on a.id=b.productid ");
            strSql.Append(" set a.quotedollars =b.quotedollars , a.quotermb = b.quotermb ,");
            strSql.Append("  a.quotesupplier = b.company , a.quotesuppliercode= b.companycode,");
            strSql.Append(" a.quotelinkman= b.customer,a.quotelinkmancode=b.customercode, ");
            strSql.Append(" a.quoteweight = b.weight, a.quotequantity=b.quantity,");
            strSql.Append(" a.quotedate= CONCAT( DATE_FORMAT( b.quotedate , '%Y/%m/%d ') , TIME_FORMAT(quotetime ,'%H:%i:%s') ) ");

            int rows = MySqlHelper.ExecuteSql(strSql.ToString());
            return rows > 0 ? true : false;
        }

        public bool UpdateLatestQuote(int productid, decimal dollors, decimal rmb, string companycode,
           string company, string linkmancode, string linkman, string quotedatestr, decimal weight, int quantity)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update t_productex ");
            strSql.Append(" set quotedollars =@quotedollars , quotermb = @quotermb ,");
            strSql.Append(" quotesupplier = @company , quotesuppliercode= @companycode,");
            strSql.Append(" quotelinkman= @customer,quotelinkmancode=@customercode, ");
            strSql.Append(" quoteweight = @weight, quotequantity=@quantity,");
            strSql.Append(" quotedate= @quotedate ");
            strSql.Append(" where id=@id");

            MySqlParameter[] parameters = {
					new MySqlParameter("@quotedollars", MySqlDbType.Decimal),
					new MySqlParameter("@quotermb", MySqlDbType.Decimal),
					new MySqlParameter("@company", MySqlDbType.VarChar,255),
                    new MySqlParameter("@companycode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@customer", MySqlDbType.VarChar,200),
                    new MySqlParameter("@customercode", MySqlDbType.VarChar,45),
                    new MySqlParameter("@weight", MySqlDbType.Decimal),
                    new MySqlParameter("@quantity", MySqlDbType.Int32,11),
                    new MySqlParameter("@quotedate", MySqlDbType.VarChar,18),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)
                                          };
            parameters[0].Value = dollors;
            parameters[1].Value = rmb;
            parameters[2].Value = company;
            parameters[3].Value = companycode; 
            parameters[4].Value = linkman;
            parameters[5].Value = linkmancode;
            parameters[6].Value = weight;
            parameters[7].Value = quantity;
            parameters[8].Value = quotedatestr;
            parameters[9].Value = productid;

            int rows = MySqlHelper.ExecuteSql(strSql.ToString(),parameters);
            return rows > 0 ? true : false;
        }

    }
}
