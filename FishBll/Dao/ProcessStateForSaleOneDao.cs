using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class ProcessStateForSaleOneDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . Append ( "select b.fishId,a.codeNum,a.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1,e.`code` code1,case when f.coun1=0 then 0 else 0+convert(convert(f.coun/f.coun1,decimal(11,4))*100,char) end coun,0+convert(h.weight,char) weight,i.`code` code2  " );
            //strSql . Append ( "from t_purchaseApplication a left join t_purchaseFishInfo b on a.codeNum=b.code " );
            //strSql . Append ("left join t_purchasecontract d on a.codeNum=d.codeNum ");
            //strSql . Append ( "left join (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPurchaseApplication' group by code,programId) b on a.`code`=b.code and a.date=b.date and a.programId=b.programId inner join t_purchaseApplication on a.code=codeNum where state='审核') c  on a.codeNum=c.code " );
            //strSql . Append ( "left join (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPurcurementContract' group by code,programId) b on a.`code`=b.code and a.date=b.date and a.programId=b.programId inner join t_purchasecontract on a.code=codeNumContract where state='审核' ) e on d.codeNumContract=e.code " );
            ////strSql . Append ( "left join (select purchasecode,count(f.code) coun1,(select count(a.code) coun from (select a.* from t_review a inner join ( select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核') a inner join t_paymentrequisition b on a.code=b.code) coun from t_paymentrequisition f group by purchasecode) f on d.codeNumContract=f.purchasecode " );
            //strSql . Append ( "left join (select count(1) coun1,a.purchasecode,coun from t_paymentrequisition a inner join (select b.purchasecode,count(a.code) coun from (select a.* from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a inner join t_paymentrequisition b on a.code=b.code group by b.purchasecode) b on a.purchasecode=b.purchasecode) f on d.codeNumContract=f.purchasecode " );
            //strSql . Append ( "left join (select d.codeNumContract,h.fishId,case when d.height=0 then 0 else convert(h.weight/d.height,decimal(11,2))*100 end weight from t_WarehouseReceipt h right join t_purchasecontract d on h.codeNumContract=d.codeNumContract group by h.codeNumContract,h.fishId) h on h.codeNumContract=d.codeNumContract and h.fishId=b.fishId " );
            //strSql . Append ( "left join t_QuotationPriceList i on b.fishId=i.fishId " );

            //strSql.Append("select a.choise,a.fishId,a.codeNum,b.codeNumContract,a.supplier,a.signDate,a.createUser,c1.Numbering,b.createUser createUser1,d1.Numbering,e1.codeNum,f1.counn/g1.counn shenhe,j1.jiangcang2/i1.jincang1 jindan1,i1.jincang1 from t_purchaseapplication a ");
            //strSql.Append("left join  t_purchaseappfishinfo a1 on a.codeNum = a1.code ");
            //strSql.Append("left join t_purchasecontract b on a.codeNum = b.codeNum ");
            //strSql.Append("left join (select a.Numbering from t_review a inner join (select Numbering, programId, max(date) date from t_review where programId = 'FormPurchaseApplication' group by Numbering, programId) b on a.Numbering = b.Numbering and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum where state = '审核') c1 on c1.Numbering = a.codeNum ");
            //strSql.Append("left join (select a.Numbering from t_review a inner join (select Numbering, programId, max(date) date from t_review where programId = 'FormPurcurementContract' group by Numbering, programId) b on a.Numbering = b.Numbering and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum where state = '审核') d1 on d1.Numbering = a.codeNum ");
            //strSql.Append("left join (select a.codeNum from t_purchasecontract a left join t_paymentrequisition b on b.CNumbering = a.codeNum where truncate(a.bondPro, 3) = truncate(b.bond, 3)and(b.Numbering ='' ) group by a.codeNum)e1 on e1.codeNum = a.codeNum ");
            //strSql.Append("left join (select c.CNumbering, count(b.Numbering) AS counn from(select distinct a.CNumbering, Numbering from t_paymentrequisition a where a.Numbering = '') c inner JOIN t_review b ON c.CNumbering = b.Numbering and b.programId = 'FormPaymentRequisition' AND b.state = '审核'GROUP BY c.CNumbering)f1 on a.codeNum = f1.CNumbering ");
            //strSql.Append("left join (SELECT a.CNumbering, count(b.CNumbering) AS counn FROM(SELECT DISTINCT CNumbering, Numbering  FROM t_paymentrequisition WHERE Numbering = '') a inner JOIN t_paymentrequisition b ON a.CNumbering = b.CNumbering and a.Numbering = '' and b.Numbering = '' where a.Numbering = '' GROUP BY a.CNumbering)g1 on a.codeNum = g1.CNumbering ");
            //strSql.Append("left join (SELECT   a.codeNum, count(b.codeNum) AS jincang1 FROM(SELECT DISTINCT    codeNum, code FROM   t_warehousereceipt) a INNER JOIN t_warehousereceipt b ON a.codeNum = b.codeNum GROUP BY a.codeNum)i1 on a.codeNum = i1.codeNum ");
            //strSql.Append("left join (SELECT   a.code, count(b.code) AS jiangcang2 FROM(SELECT DISTINCT code FROM   t_purchaseappfishinfo) a INNER JOIN t_purchaseappfishinfo b ON a.code = b.code GROUP BY a.code)j1 on a.codenum = j1.code ");

            //strSql.Append("select a.choise,a.fishId,a.codeNum,b.codeNumContract,a.supplier,a.signDate,a.createUser,c1.Numbering,b.createUser createUser1, d1.Numbering,e1.codeNum,f1.counn / g1.counn shenhe,j1.jiangcang2 / i1.jincang1 jindan1,i1.jincang1,TRUNCATE(b.price, 3) = fk.applyMoney dengyu,TRUNCATE(b.price, 3) > fk.applyMoney dayu,TRUNCATE(b.price, 3) < fk.applyMoney xiaoyu,fk.codeNum from t_purchaseapplication a ");
            //strSql.Append("left join  t_purchaseappfishinfo a1 on a.codeNum = a1.code ");
            //strSql.Append("left join t_purchasecontract b on a.codeNum = b.codeNum ");
            //strSql.Append("left join (select a.Numbering from t_review a inner join (select Numbering, programId, max(date) date from t_review where programId = 'FormPurchaseApplication' group by Numbering, programId) b on a.Numbering = b.Numbering and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum where state = '审核') c1 on c1.Numbering = a.codeNum ");
            //strSql.Append("left join (select a.Numbering from t_review a inner join (select Numbering, programId, max(date) date from t_review where programId = 'FormPurcurementContract' group by Numbering, programId) b on a.Numbering = b.Numbering and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum where state = '审核') d1 on d1.Numbering = a.codeNum ");
            //strSql.Append("left join (select a.codeNum  from t_purchasecontract a left join t_paymentrequisition b on b.CNumbering = a.codeNum where truncate(a.bondPro, 3) = truncate(b.bond, 3)and(b.Numbering = '') group by a.codeNum)e1 on e1.codeNum = a.codeNum ");
            //strSql.Append("left join (select c.CNumbering, count(b.Numbering) AS counn from(select distinct a.CNumbering, Numbering from t_paymentrequisition a where a.Numbering = '') c inner JOIN t_review b ON c.CNumbering = b.Numbering and b.programId = 'FormPaymentRequisition' AND b.state = '审核'GROUP BY c.CNumbering)f1 on a.codeNum = f1.CNumbering ");
            //strSql.Append("left join (SELECT a.CNumbering, count(b.CNumbering) AS counn FROM(SELECT DISTINCT CNumbering, Numbering  FROM t_paymentrequisition WHERE Numbering = '') a inner JOIN t_paymentrequisition b ON a.CNumbering = b.CNumbering and a.Numbering = '' and b.Numbering = '' where a.Numbering = '' GROUP BY a.CNumbering)g1 on a.codeNum = g1.CNumbering ");
            //strSql.Append("left join (SELECT   a.codeNum, count(b.codeNum) AS jincang1 FROM(SELECT DISTINCT codeNum, code FROM   t_warehousereceipt) a INNER JOIN t_warehousereceipt b ON a.codeNum = b.codeNum GROUP BY a.codeNum)i1 on a.codeNum = i1.codeNum ");
            //strSql.Append("left join (SELECT   a.code, count(b.code) AS jiangcang2 FROM(SELECT DISTINCT code FROM   t_purchaseappfishinfo) a INNER JOIN t_purchaseappfishinfo b ON a.code = b.code GROUP BY a.code)j1 on a.codenum = j1.code ");
            //strSql.Append("left join (select TRUNCATE(sum(b.applyMoney), 2) applyMoney, a.codeNum from t_purchasecontract a inner join t_paymentrequisition b on b.CNumbering = a.codeNum where b.Numbering = '' GROUP BY b.CNumbering)fk on a.codeNum = fk.codeNum ");

            strSql.Append("select a.choise,a.weight,a.proName,a.fishId,a.codeNum,b.codeNumContract,a.supplier,a.signDate,t.realname,c1.realname,t1.realname createUser1, d1.realname,e1.codeNum,f1.counn / g1.counn shenhe, i1.jincang1/j1.jiangcang2 jindan1,i1.jincang1,TRUNCATE(b.price, 3) = fk.applyMoney dengyu,TRUNCATE(b.price, 3) < fk.applyMoney dayu,TRUNCATE(b.price, 3) > fk.applyMoney xiaoyu,fk.codeNum,fk.applyMoney,fk.weight,b.height ");
            strSql.Append("from t_purchaseapplication a ");
            strSql.Append("left join t_user t on a.createUser = t.username ");
            strSql.Append("left join  t_purchaseappfishinfo a1 on a.codeNum = a1.code left join t_purchasecontract b on a.codeNum = b.codeNum left JOIN t_user t1 on b.createUser = t1.username ");
            strSql.Append("left join (select a.Numbering, t.realname from t_review a inner join (select Numbering, programId, max(date) date from t_review where programId = 'FormPurchaseApplication' group by Numbering, programId) b on a.Numbering = b.Numbering and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum inner join t_user t on a.createMan = t.username where state = '审核') c1 on c1.Numbering = a.codeNum ");
            strSql.Append("left join (select a.Numbering, t.realname from t_review a inner join (select Numbering, programId, max(date) date from t_review where programId = 'FormPurcurementContract' group by Numbering, programId) b on a.Numbering = b.Numbering and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum inner join t_user t on a.createMan = t.username where state = '审核') d1 on d1.Numbering = a.codeNum ");
            strSql.Append("left join (select a.codeNum  from t_purchasecontract a left join t_paymentrequisition b on b.CNumbering = a.codeNum where truncate(a.bondPro, 3) = truncate(b.bond, 3)and(b.Numbering = '') group by a.codeNum)e1 on e1.codeNum = a.codeNum ");
            strSql.Append("left join (select c.CNumbering, count(b.Numbering) AS counn from(select distinct a.CNumbering, Numbering from t_paymentrequisition a where a.Numbering = '') c inner JOIN t_review b ON c.CNumbering = b.Numbering and b.programId = 'FormPaymentRequisition' AND b.state = '审核'GROUP BY c.CNumbering)f1 on a.codeNum = f1.CNumbering ");
            strSql.Append("left join (SELECT a.CNumbering, count(b.CNumbering) AS counn FROM(SELECT DISTINCT CNumbering, Numbering  FROM t_paymentrequisition WHERE Numbering = '') a inner JOIN t_paymentrequisition b ON a.CNumbering = b.CNumbering and a.Numbering = '' and b.Numbering = '' where a.Numbering = '' GROUP BY a.CNumbering)g1 on a.codeNum = g1.CNumbering ");
            strSql.Append("left join (SELECT a.codeNum, count(b.codeNum) AS jincang1 FROM(SELECT DISTINCT codeNum, code FROM   t_warehousereceipt GROUP BY codeNum) a INNER JOIN t_warehousereceipt b ON a.codeNum = b.codeNum GROUP BY a.codeNum)i1 on a.codeNum = i1.codeNum ");
            strSql.Append("left join (SELECT a.code, count(b.code) AS jiangcang2 FROM(SELECT DISTINCT code FROM   t_purchaseappfishinfo) a INNER JOIN t_purchaseappfishinfo b ON a.code = b.code GROUP BY a.code)j1 on a.codenum = j1.code ");
            strSql.Append("left join (select TRUNCATE(sum(b.applyMoney), 2) applyMoney, a.codeNum,TRUNCATE(sum(b.weight), 2) weight from t_purchasecontract a inner join t_paymentrequisition b on b.CNumbering = a.codeNum GROUP BY b.CNumbering)fk on a.codeNum = fk.codeNum ");


            if ( !string . IsNullOrEmpty ( strWhere ) )
                strSql . AppendFormat ( " where {0}  GROUP BY a.codeNum ", strWhere);

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableViewzizhi(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //select a.code,a.productionDate,d.code,e.code from t_batchsheet a left join t_finishedprolist c on a.code=c.plCode
            //left join(select a.code from t_batchsheet a inner join t_batchsheets b on a.code= b.code where 1=1  GROUP BY a.code) d on a.code=d.code
            //left join(select a.code from t_batchsheet a inner join t_finishedprolist b on a.code= b.plCode where 1=1  GROUP BY a.code) e on a.code=e.code

            //strSql.Append("select a.code,a.productionDate,d.code,e.code from t_batchsheet a left join t_finishedprolist c on a.code=c.plCode ");
            //strSql.Append("left join(select a.code from t_batchsheet a inner join t_batchsheets b on a.code= b.code where 1=1  GROUP BY a.code) d on a.code=d.code ");
            //strSql.Append("left join(select a.code from t_batchsheet a inner join t_finishedprolist b on a.code= b.plCode where 1=1  GROUP BY a.code) e on a.code=e.code ");
            strSql.Append("select a.code,a.productionDate,d.code,e.code,c.goods,d.fishId,d.qualitySpe,d.codeNum,d.codeNumContract,d.tons from t_batchsheet a left join t_finishedprolist c on a.code = c.plCode ");
            strSql.Append("left join(select a.code, b.fishId, b.qualitySpe, b.codeNum, b.codeNumContract, b.tons from t_batchsheet a inner join t_batchsheets b on a.code = b.code where isSum=1  GROUP BY a.code) d on a.code = d.code ");
            strSql.Append("left join(select a.code from t_batchsheet a inner join t_finishedprolist b on a.code = b.plCode where 1 = 1  GROUP BY a.code) e on a.code = e.code");

            if (!string.IsNullOrEmpty(strWhere))
                strSql.AppendFormat(" where {0}  GROUP BY a.code ", strWhere);

            return MySqlHelper.Query(strSql.ToString()).Tables[0];
        }
        /// <summary>
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFishId ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select fishId from t_purchaseFishInfo" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 付款申请单错误：货品重量*货品单价不等于申请金额    显示黄色   审核通过正确
        /// </summary>
        /// <returns></returns>
        public DataTable getTableErrorForFK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select purchasecode,sum(weight*price-applyMoney) calcu from ( select a.* from t_review a inner join ( select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state!='审核') a inner join t_paymentrequisition b on a.code=b.code group by purchasecode having sum(weight*price-applyMoney)!=0" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //TODO: 2018-5-8  付款申请单的未完成是否与采购申请单有关联

    }
}



//2018-5-8  
/*select b.fishId,a.codeNum,a.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1,e.`code` code1,
case when f.coun1=0 then 0 else 0+convert(convert(f.coun/f.coun1,decimal(11,4))*100,char) end coun,
0+convert(h.weight,char) weight ,i.`code` code2 
from t_purchaseApplication a inner join t_purchaseFishInfo b on a.codeNum=b.code 
inner join t_purchasecontract d on a.codeNum=d.codeNum 
left join (select a.code from t_review a inner join 
(select code,programId,max(date) date from t_review where programId='FormPurchaseApplication' group by code,programId) b
on a.`code`=b.code and a.date=b.date and a.programId=b.programId
inner join t_purchaseApplication on a.code=codeNum where state='审核') c  on a.codeNum=c.code 
left join (
select a.code from t_review a inner join 
(select code,programId,max(date) date from t_review where programId='FormPurcurementContract' group by code,programId) b
on a.`code`=b.code and a.date=b.date and a.programId=b.programId
inner join t_purchasecontract on a.code=codeNumContract where state='审核' ) e on d.codeNumContract=e.code 
left join (select purchasecode,count(f.code) coun1,(select count(a.code) coun from 
(select a.* from t_review a inner join ( 
select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核') a 
inner join t_paymentrequisition b on a.code=b.code) coun 
from t_paymentrequisition f group by purchasecode) f on d.codeNumContract=f.purchasecode 
left join (select d.codeNumContract,h.fishId,case when d.height=0 then 0 else convert(h.weight/d.height,decimal(11,2))*100 end weight from t_WarehouseReceipt h 
right join t_purchasecontract d on h.codeNumContract=d.codeNumContract group by h.codeNumContract,h.fishId) h on h.codeNumContract=d.codeNumContract and h.fishId=b.fishId  left join t_QuotationPriceList i on b.fishId=i.fishId
 */


/*
付款申请单错误：货品重量*货品单价不等于申请金额    显示黄色   审核通过正确
select purchasecode,sum(weight*price-applyMoney) calcu from 
(
select a.* from t_review a inner join ( 
select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date where state!='审核'
) a 
inner join t_paymentrequisition b on a.code=b.code
group by purchasecode
having sum(weight*price-applyMoney)!=0

 */
