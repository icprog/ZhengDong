using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
   public class DiscWarehouseDao
    {
       public DiscWarehouseDao() {}
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select d.type,d.code,d.billofgoods,d.quotesupplier,d.quotelinkman,d.nature,d.specification,d.quotedate,d.quotesaildatefast,d.quotesaildatelate,d.quote_protein,d.quote_tvn,d.quote_amine,d.confirmagent,d.confirmlinkman,d.quotedollars,d.quotermb,c.conProtein,c.conTVN,c.conZA,c.conFFA,c.conZF,c.conSF,c.conSHY,c.conS,c.conSJ,c.conHF,c.conLAS,c.conDAS,d.PlaceOfDelivery,d.confirmWeight from t_purchaseapplication a INNER join t_purchaseappfishinfo b on a.codeNum=b.code LEFT JOIN t_purchasecontract c on a.codeNum=c.codeNum INNER JOIN v_quote d on d.code=b.fishId ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
    }
}