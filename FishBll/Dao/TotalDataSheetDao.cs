using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Dao
{
    public class TotalDataSheetDao
    {
        public DataTable getTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select a.Numbering,a.DateOfSigni,a.supplier,a.Quantity,a.UnitPrice,a.AmountOfMoney,a.ContractNo,b.Signdate,b.demand,b.createman,b.code,b.rebate,b.Freight,c.Quantity,c.unitprice,d.Issuingtime,e.Quantity,f.code,f.applyDate,f.weight,f.applyMoney,g.fuKuandate,g.RMB,g.code,h.Shipname,h.actualnumber,h.Billnumber,h.StorageLocation,h.Zhuangjiao from t_purchaserequisition a left JOIN t_salesorder b ON a.Numbering=b.Numbering left join t_happening c ON b.code=c.code left join t_billoflading d ON b.code=d.codeContract left join t_poundsalone e ON b.code=e.codeContract left JOIN t_paymentrequisition f ON b.code=f.applyCode left JOIN t_receiptrecord g ON b.code=g.codeContract left JOIN t_enterwarehousereceipts H ON a.ContractNo=H.ContractNo ");
            strSql.Append("where " + strWhere);

            DataSet ds = MySqlHelper.Query(strSql.ToString());

            return ds.Tables[0];
        }
    }
}
