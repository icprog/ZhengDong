using System;
using System . Collections . Generic;
using System . Text;
using System . Data;

namespace FishBll . Dao
{
    public class ProcessStateForSaleTwoDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            ////strSql . Append ( "select b.fishId,a.codeNum,a.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1,e.`code` code1,case when f.coun1=0 then 0 else 0+convert(convert(f.coun/f.coun1,decimal(11,4))*100,char) end coun,0+convert(h.weight,char) weight,case when i.count2=0 then 0 else 0+convert(convert(i.count3/i.count2,decimal(11,4))*100,char) end coun1 from t_purchaseApplication a inner join t_purchaseFishInfo b on a.codeNum=b.code  inner join t_purchasecontract d on a.codeNum=d.codeNum left join (select code,max(createTime) crea from t_review inner join t_purchaseApplication on code=codeNum where state='审核' and programId='FormPurchaseApplication'  group by code ) c  on a.codeNum=c.code left join (select code,max(createTime) crea from t_review inner join t_purchasecontract on code=codeNumContract where state='审核' and programId='FormPurcurementContract' group by code ) e on d.codeNumContract=e.code left join (select purchasecode,count(f.code) coun1,(select count(a.code) coun from t_review a inner join t_paymentrequisition b on a.code=b.code where state='审核' and programId='FormPaymentRequisition') coun from t_paymentrequisition f group by purchasecode) f  on d.codeNumContract=f.purchasecode left join (select d.codeNumContract,h.fishId,case when d.height=0 then 0 else convert(h.weight*1.0/d.height,decimal(11,2))*100 end weight from t_WarehouseReceipt h right join t_purchasecontract d on h.codeNumContract=d.codeNumContract group by h.codeNumContract,h.fishId) h  on h.codeNumContract=d.codeNumContract and h.fishId=b.fishId left JOIN (select codeNumContract,fishId,count(i.code) count2,(select count(a.code) coun3 from t_review a inner join t_StorageOfRequisition b on a.`code`=b.`code` where state='审核' and programId='FormStorageOfRequisition') count3 from t_StorageOfRequisition i group by codeNumContract ) i on i.codeNumContract=d.codeNumContract and i.fishId=b.fishId " );
            //strSql . Append ( "select b.fishId,a.codeNum,a.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1,e.`code` code1,case when f.coun1=0 then 0 else 0+convert(convert(f.coun/f.coun1,decimal(11,4))*100,char) end coun,l.`code` code2,j.`code` code3,k.`code` code4,case when i.count2=0 then 0 else 0+convert(convert(i.count3/i.count2,decimal(11,4))*100,char) end coun1 " );//0+convert(h.weight,char) weight,
            //strSql . Append ("from t_purchaseApplication a left join t_purchaseFishInfo b on a.codeNum=b.code ");
            //strSql . Append ("left join t_purchasecontract d on a.codeNum=d.codeNum ");
            //strSql . Append ( "left join (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPurchaseApplication' group by code,programId) b on a.`code`=b.code and a.date=b.date and a.programId=b.programId inner join t_purchaseApplication on a.code=codeNum where state='审核') c  on a.codeNum=c.code " );
            //strSql . Append ( "left join ( select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPurcurementContract' group by code,programId) b on a.`code`=b.code and a.date=b.date and a.programId=b.programId inner join t_purchasecontract on a.code=codeNumContract where state='审核' ) e on d.codeNumContract=e.code  " );
            ////strSql . Append ( "left join (select purchasecode,count(f.code) coun1,(select count(a.code) coun from (select a.* from t_review a inner join ( select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核') a inner join t_paymentrequisition b on a.code=b.code) coun from t_paymentrequisition f group by purchasecode) f on d.codeNumContract=f.purchasecode  " );
            //strSql . Append ( "left join ( select count(1) coun1,a.purchasecode,coun from t_paymentrequisition a inner join (select b.purchasecode,count(a.code) coun from (select a.* from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a inner join t_paymentrequisition b on a.code=b.code group by b.purchasecode) b on a.purchasecode=b.purchasecode) f on d.codeNumContract=f.purchasecode  " );
            ////strSql . Append ( "left join (select d.codeNumContract,h.fishId,case when d.height=0 then 0 else convert(h.weight/d.height,decimal(11,2))*100 end weight from t_WarehouseReceipt h right join t_purchasecontract d on h.codeNumContract=d.codeNumContract group by h.codeNumContract,h.fishId) h on h.codeNumContract=d.codeNumContract and h.fishId=b.fishId " );
            //strSql . Append ( "left join t_batchsheets l on b.fishId=l.fishId " );
            //strSql . Append ( "left join t_finishedprolist j on j.plCode=l.`code` " );
            //strSql . Append ( "left join t_CustomStandardTable k on j.fishId=k.fishId  " );
            //strSql . Append ("left JOIN (select codeNumContract,fishId,count(i.code) count2,(select count(a.code) coun from (select a.* from t_review a inner join ( select code,programId,max(date) date from t_review where programId='FormStorageOfRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核') a inner join t_StorageOfRequisition b on a.code=b.code) count3 from t_StorageOfRequisition i group by codeNumContract,fishId ) i on i.codeNumContract=d.codeNumContract and i.fishId=b.fishId ");


            //strSql.Append("select a.fishId,b.price,a.codeNum,d.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1, e.`code` code1,case when f.coun1 = 0 then 0 else 0 + convert(convert(f.coun / f.coun1, decimal(11, 4)) * 100, char) end coun,case when i.count2 = 0 then 0 else 0 + convert(convert(i.count3 / i.count2, decimal(11, 4)) * 100, char) end coun1, i.saWeight,i.codeNum,a.weight,fk.applyMoney,fk.codeNum from t_purchaseApplication a ");
            //strSql.Append("left join t_purchaseFishInfo b on a.codeNum = b.code left ");
            //strSql.Append("join t_purchasecontract d on a.codeNum = d.codeNum ");
            //strSql.Append("left join (select a.code from t_review a inner join (select code, programId, max(date) date from t_review where programId = 'FormPurchaseApplication' group by code, programId) b on a.`code`= b.code and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.code = codeNum where state = '审核') c on a.codeNum = c.code ");
            //strSql.Append("left join (select a.code from t_review a inner join (select code, programId, max(date) date from t_review where programId = 'FormPurcurementContract' group by code, programId) b on a.`code`= b.code and a.date = b.date and a.programId = b.programId inner join t_purchasecontract on a.code = codeNumContract where state = '审核' ) e on d.codeNumContract = e.code ");
            //strSql.Append("left join (select count(1) coun1, a.purchasecode, coun from t_paymentrequisition a inner join (select b.purchasecode, count(a.code) coun from(select a.* from t_review a inner join (select code, programId, max(date) date from t_review where programId = 'FormPaymentRequisition' group by code, programId) b on a.code = b.code and a.programId = b.programId and a.date = b.date where state = '审核' ) a inner join t_paymentrequisition b on a.code = b.code group by b.purchasecode) b on a.purchasecode = b.purchasecode) f on d.codeNumContract = f.purchasecode ");
            //strSql.Append("left JOIN (select TRUNCATE(sum(saWeight), 2) saWeight, codeNum, codeNumContract, fishId, count(i.code) count2, (select count(a.code) coun from(select a.* from t_review a inner join ( select code, programId, max(date) date from t_review where programId = 'FormStorageOfRequisition' group by code, programId) b on a.code = b.code and a.programId = b.programId and a.date = b.date where state = '审核') a inner join t_StorageOfRequisition b on a.code = b.code) count3 from t_StorageOfRequisition i group by codeNumContract,fishId ) i on i.codeNum = d.codeNum ");
            //strSql.Append("left join (select a.codeNum  from t_purchasecontract a left join t_paymentrequisition b on b.CNumbering = a.codeNum where truncate(a.bondPro, 3) = truncate(b.bond, 3)and(b.Numbering = '') group by a.codeNum)e1 on e1.codeNum = a.codeNum ");
            //strSql.Append("left join (select TRUNCATE(sum(b.applyMoney), 2) applyMoney, a.codeNum from t_purchaseApplication a inner join t_paymentrequisition b on b.CNumbering = a.codeNum where b.Numbering = '' GROUP BY b.CNumbering)fk on a.codeNum = fk.codeNum ");

            strSql.Append(" select a.fishId,a.weight weight11,a.proName,a.codeNum,d.price,d.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1, e.`code` code1,case when f.coun1 = 0 then 0 else 0 + convert(convert(f.coun / f.coun1, decimal(11, 4)) * 100, char) end coun,case when i.count2 = 0 then 0 else 0 + convert(convert(i.count3 / i.count2, decimal(11, 4)) * 100, char) end coun1, i.saWeight,i.codeNum,a.weight,fk.applyMoney,fk.codeNum,fk.weight,t.realname caigou1, c.realname caigou2, ttt.realname caigou3, e.realname caigou4 ");
            strSql.Append(" from t_purchaseApplication a inner ");
            strSql.Append(" join t_user t on a.createUser = t.username ");
            strSql.Append(" left join t_purchaseFishInfo b on a.codeNum = b.code ");
            strSql.Append(" left join t_purchasecontract d on a.codeNum = d.codeNum left ");
            strSql.Append(" join t_user ttt on d.createUser = ttt.username ");
            strSql.Append(" left join t_user t1 on d.createUser = t.username ");
            strSql.Append(" left join (select a.code,t.realname from t_review a inner join (select code, programId, max(date)date from t_review where programId = 'FormPurchaseApplication' group by code, programId) b on a.`code`= b.code and a.date = b.date and a.programId = b.programId inner join t_purchaseApplication on a.Numbering = codeNum LEFT join t_user t on a.createMan = t.username where state = '审核') c on a.codeNum = c.code ");
            strSql.Append(" left join (select a.code, t.realname from t_review a inner join (select code, programId, max(date) date from t_review where programId = 'FormPurcurementContract' group by code, programId) b on a.`code`= b.code and a.date = b.date and a.programId = b.programId inner join t_purchasecontract on a.Numbering = codeNum LEFT join t_user t on a.createMan = t.username where state = '审核' ) e on d.codeNum = e.code ");
            strSql.Append(" left join (select count(1) coun1, a.purchasecode, coun from t_paymentrequisition a inner join (select b.purchasecode, count(a.code) coun from(select a.* from t_review a inner join (select code, programId, max(date) date from t_review where programId = 'FormPaymentRequisition' group by code, programId) b on a.code = b.code and a.programId = b.programId and a.date = b.date where state = '审核' ) a inner join t_paymentrequisition b on a.code = b.code group by b.purchasecode) b on a.purchasecode = b.purchasecode) f on d.codeNumContract = f.purchasecode ");
            strSql.Append(" left JOIN (select TRUNCATE(sum(saWeight), 2) saWeight, codeNum, codeNumContract, fishId, count(i.code) count2, (select count(a.code) coun from(select a.* from t_review a inner join ( select code, programId, max(date) date from t_review where programId = 'FormStorageOfRequisition' group by code, programId) b on a.code = b.code and a.programId = b.programId and a.date = b.date where state = '审核') a inner join t_StorageOfRequisition b on a.code = b.code) count3 from t_StorageOfRequisition i group by codeNumContract,fishId ) i on i.codeNum = d.codeNum ");
            strSql.Append(" left join (select a.codeNum  from t_purchasecontract a left join t_paymentrequisition b on b.CNumbering = a.codeNum where truncate(a.bondPro, 3) = truncate(b.bond, 3)and(b.Numbering = '') group by a.codeNum)e1 on e1.codeNum = a.codeNum ");
            strSql.Append(" left join (select TRUNCATE(sum(b.applyMoney), 2) applyMoney, a.codeNum, TRUNCATE(sum(b.weight), 2) weight from t_purchaseApplication a inner join t_paymentrequisition b on b.CNumbering = a.codeNum  GROUP BY b.CNumbering)fk on a.codeNum = fk.codeNum ");
            if ( !string . IsNullOrEmpty ( strWhere ) )
                strSql . AppendFormat ("where {0} GROUP BY a.codeNum", strWhere );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
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


/*
 2018-5-8
 select b.fishId,a.codeNum,a.codeNumContract,a.supplier,a.signDate,a.createUser,c.`code`,d.createUser createUser1,e.`code` code1,
case when f.coun1=0 then 0 else 0+convert(convert(f.coun/f.coun1,decimal(11,4))*100,char) end coun,
0+convert(h.weight,char) weight,i.`code` code2,j.`code` code3,k.`code` code4 
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
right join t_purchasecontract d on h.codeNumContract=d.codeNumContract group by h.codeNumContract,h.fishId) 
h on h.codeNumContract=d.codeNumContract and h.fishId=b.fishId
left join t_batchsheets i on b.fishId=i.fishId
left join t_finishedprolist j on j.plCode=i.`code`
left join t_CustomStandardTable k on j.fishId=k.fishId 
     
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