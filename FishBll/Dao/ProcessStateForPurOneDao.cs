using System;
using System . Collections . Generic;
using System . Text;
using System . Data;

namespace FishBll . Dao
{
    public class ProcessStateForPurOneDao
    {
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            StringBuilder strSql = new StringBuilder ( );
            //2018-7-25
            /*
            strSql . Append ( "select a.Numbering,b.product_id,a.code,a.demand,a.Signdate,a.createman,c.code code1,i.createman createman2,j.code code2,case when d.coun1=0 then 0 else 0+convert(convert(d.coun/d.coun1,decimal(11,4))*100,char) end coun,case when e.coun2=0 then 0 else 0+convert(convert(e.coun3/e.coun2,decimal(11,4))*100,char) end coun1,case when f.coun2=0 then 0 else 0+convert(convert(f.coun3/f.coun2,decimal(11,4))*100,char) end coun2,case when g.coun2=0 then 0 else 0+convert(convert(g.coun3/g.coun2,decimal(11,4))*100,char) end coun3,case when h.coun2=0 then 0 else 0+convert(convert(h.coun3/h.coun2,decimal(11,4))*100,char) end coun4,0+convert(k.ton,char) ton,0+convert(l.ton,char) ton1 " );
            strSql . Append ( "from t_salesorder a  inner join t_happening b on a.Numbering=b.NumberingOne " );
            strSql . Append ( "left join t_salesrcontract i on a.Numbering=i.Numbering " );
            strSql . Append ( "left join (select c.code from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormSalesRequisition' group by code,programId) c on a.code=c.`code` and a.programId=c.programId and a.date=c.date where a.state='审核') c inner join t_salesorder b on c.code=b.Numbering ) c on a.Numbering=c.code " );
            strSql . Append ( "left join (select c.code from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormSalesRContract' group by code,programId) c on a.code=c.`code` and a.programId=c.programId and a.date=c.date where a.state='审核') c inner join t_salesrcontract b on c.code=b.Numbering ) j on j.code=i.Numbering " );
            //strSql . Append ( "left join (select Numbering,count(f.code) coun1,(select count(a.code) from ( select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId ) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a inner join t_paymentrequisition b on a.code=b.`code`) coun from t_paymentrequisition f group by Numbering ) d on a.Numbering=d.Numbering  " );
            strSql . Append ( "left join (select a.Numbering,count(1) coun1,coun from t_paymentrequisition a inner join (select count(a.code) coun,Numbering from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a inner join t_paymentrequisition b on a.code=b.`code` group by Numbering ) b on a.Numbering=b.Numbering group by Numbering ) d on a.Numbering=d.Numbering  " );
            strSql . Append ( "left join (select Numbering,FishMealId,count(f.code) coun2,(select count(a.code) coun from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormCargoFeedbackSheet' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a inner join t_CargoFeedbackSheet b on a.code=b.code ) coun3 from t_CargoFeedbackSheet f group by Numbering,FishMealId  ) e on a.Numbering=e.Numbering and b.product_id=e.FishMealId " );
            strSql . Append ( "left join (select Numbering,FishMealId,count(f.code) coun2,(select count(a.code) coun from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormTheproblemsheet' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a  inner join t_theproblemsheet b on a.code=b.code ) coun3 from t_theproblemsheet f group by Numbering,FishMealId ) f on a.Numbering=f.Numbering and b.product_id=f.FishMealId " );
            strSql . Append ( "left join ( select codeNum,fishId,count(f.code) coun2,(select count(a.code) coun from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormReturnReceipt' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a  inner join t_ReturnReceipt b on a.code=b.code ) coun3 from t_ReturnReceipt f group by codeNum,fishId ) g  on g.codeNum=a.Numbering and g.fishId=b.product_id " );
            strSql . Append ( "left join (select Numbering,FishMealId,count(f.code) coun2,(select count(a.code) coun from (select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormReceiptRecord' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a inner join t_ReceiptRecord b on a.code=b.code ) coun3 from t_ReceiptRecord f group by Numbering,FishMealId ) h on h.Numbering=a.Numbering and h.FishMealId=b.product_id " );
            strSql . Append ( "left join (select b.NumberingOne,b.product_id,case when sum(Quantity)=0 then 0 else convert(sum(Ton)/sum(Quantity),decimal(11,2))*100 end ton from t_billoflading a right join t_happening b on a.codeContract=b.NumberingOne and a.FishMealId=b.product_id group by b.NumberingOne,b.product_id ) k on k.NumberingOne=i.Numbering and k.product_id=b.product_id " );
            strSql . Append ( "left join (select b.NumberingOne,b.product_id,case when sum(b.Quantity)=0 then 0 else convert(sum(a.Competition)/sum(b.Quantity),decimal(11,2))*100 end ton  from t_poundsalone a right join t_happening b on a.codeContract=b.NumberingOne and a.FishMealId=b.product_id group by b.NumberingOne,b.product_id) l on l.NumberingOne=i.Numbering and l.product_id=b.product_id " );
            */

            strSql . Append ("select a.overflow,a.Numbering,b.product_id,i.ContractCode,a.demand,a.Signdate,o.realname createman,c.realname code1,p.realname createman2,j.realname code2,b.Quantity,m.weight,m.Numbering,case when d.coun1=0 then 0 else 0+convert(convert(d.coun/d.coun1,decimal(11,2))*100,char) end coun,n.ConfirmTheWeight,n.Numbering Numbering4,case when e.coun2=0 then 0 else 0+convert(convert(e.coun3/e.coun2,decimal(11,2))*100,char) end coun1,0.Chargeback,o.Numbering Numbering5,case when f.coun2=0 then 0 else 0+convert(convert(f.coun4/f.coun2,decimal(11,2))*100,char) end coun2,g.code code3,p.Numbering Numbering6,p.rmb,n.ConfirmTheWeight*b.unitprice unitCon, case when h.coun2=0 then 0 else 0+convert(convert(h.coun5/h.coun2,decimal(11,2))*100,char) end coun4,k.Numbering Numbering2,k.ton,l.Numbering Numbering3,ton1 ");
            strSql . Append ("from t_salesorder a inner join t_happening b on a.Numbering=b.NumberingOne left join t_salesrcontract i on a.Numbering=i.Numbering left join t_user o on a.createman=o.username left join t_user p on i.createman=p.username left join (");
            //销售申请单审核
            strSql . Append ( "select c.code,c.createMan,d.realname from ( select createMan,code,max(date) date from t_review where programId='FormSalesRequisition' and state='审核' group by code,createMan) c inner join t_salesorder b on c.code=b.Numbering  inner join t_user d on c.createMan=d.username ) c on a.Numbering=c.code " );
            strSql . Append ( "left join (" );
            //销售合同审核
            strSql . Append ( "select c.code,c.createMan,d.realname from (select createMan,code,max(date) date from t_review where programId='FormSalesRContract' and state='审核' group by code,createMan) c inner join t_salesrcontract b on c.code=b.Numbering  inner join t_user d on c.createMan=d.username ) j on j.code=i.Numbering " );
            //付款申请单货品总重量
            strSql . Append ( "left join (select sum(weight) weight,Numbering from t_paymentrequisition group by Numbering) m on a.Numbering=m.Numbering " );
            strSql . Append ( " left join (" );
            //付款申请单审核百分比
            strSql . Append ( "select a.Numbering,count(1) coun1,count(coun) coun from t_paymentrequisition a left join (select count(SingleNumber) coun,SingleNumber from (select SingleNumber,max(date) date from t_review where programId='FormPaymentRequisition' and state='审核' group by SingleNumber ) a group by SingleNumber ) b on a.code=b.SingleNumber group by Numbering ) d on a.Numbering=d.Numbering  " );
            //货物反馈单总磅单确认数量
            strSql . Append ( "left join (select convert(sum(ConfirmTheWeight),decimal(11,2)) ConfirmTheWeight,FishMealId,Numbering from t_CargoFeedbackSheet group by FishMealId,Numbering) n on a.Numbering=n.Numbering and b.product_id=n.FishMealId " );
            //货物反馈单审核百分比
            strSql . Append ( "left join (select Numbering,FishMealId ,count(1) coun2,count(coun) coun3 from t_CargoFeedbackSheet a left join (select count(SingleNumber) coun,SingleNumber from (select SingleNumber,max(date) date from t_review where programId='FormCargoFeedbackSheet' and state='审核' group by SingleNumber) b group by SingleNumber) b on a.code=b.SingleNumber group by Numbering,FishMealId) e on a.Numbering=e.Numbering and b.product_id=e.FishMealId " );
            //问题反馈单总扣款
            strSql . Append ( " left join (select convert(sum(Chargeback),decimal(11,2)) Chargeback,FishMealId,Numbering from t_theproblemsheet group by FishMealId,Numbering) o on o.Numbering=a.Numbering and o.FishMealId=b.product_id  " );
            //问题反馈单审核百分比
            strSql . Append ( "left join (select Numbering,FishMealId,count(code) coun2,count(coun) coun4 from t_theproblemsheet a left join (select SingleNumber,count(1) coun from (select SingleNumber,max(date) date from t_review where programId='FormTheproblemsheet' and state='审核' group by SingleNumber) b group by SingleNumber) b on a.code=b.SingleNumber  group by Numbering,FishMealId) f on f.Numbering=a.Numbering and f.FishMealId=b.product_id " );
            //退货单
            strSql . Append ( "left join t_ReturnReceipt g on g.codeNum=a.Numbering and g.fishId=b.product_id " );
            //收款记录单单据  收款记录单总收款金额
            strSql . Append ( "left join (select FishMealId,Numbering,convert(SUM(RMB),decimal(11,2)) rmb from t_ReceiptRecord group by FishMealId,Numbering) p on p.FishMealId=b.product_id and p.Numbering=a.Numbering " );
            //收款记录单审核百分比
            strSql . Append ( "left join (select Numbering,FishMealId,count(code) coun2,count(coun) coun5 from t_ReceiptRecord a left join (select SingleNumber,count(SingleNumber) coun from (select SingleNumber,max(date) date from t_review where programId='FormReceiptRecord' and state='审核' group by SingleNumber) b group by SingleNumber) b on a.code=b. SingleNumber group by Numbering,FishMealId) h on h.Numbering=a.Numbering and h.FishMealId=b.product_id " );
            //提货单总重量
            strSql . Append ( "left join (select convert(sum(Ton),decimal(11,2)) ton,FishMealId,Numbering from t_billoflading group by FishMealId,Numbering) k on k.Numbering=a.Numbering and k.FishMealId=b.product_id " );
            //磅单总净重
            strSql . Append ( "left join (select convert(sum(Competition),decimal(11,2)) ton1,FishMealId,Numbering from t_poundsalone group by FishMealId,Numbering) l  on l.Numbering=a.Numbering and l.FishMealId=b.product_id " );

            if ( !string . IsNullOrEmpty ( strWhere ) )
                strSql . AppendFormat ( "where {0}" ,strWhere );


            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }
        
        /// <summary>
        /// 获取鱼粉id
        /// </summary>
        /// <returns></returns>
        public DataTable getFishTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select distinct product_id from t_happening" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 付款申请单错误：货品重量*货品单价不等于申请金额    显示黄色   审核通过正确
        /// </summary>
        /// <returns></returns>
        public DataTable getTableErrorForFK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select Numbering,sum(weight*price-applyMoney) calcu from ( select a.code from t_review a inner join ( select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId) b on a.code=b.code and a.programId=b.programId and a.date=b.date where state!='审核') a inner join t_paymentrequisition b on a.code=b.code group by Numbering having sum(weight*price-applyMoney)!=0" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 付款申请单：货品重量小于等于销售合同的重量 显示绿色
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWeiForFK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select Numbering,sum(weight)-sum(Quantity) calcu from t_paymentrequisition a inner join t_happening b on a.Numbering=b.NumberingOne group by  Numbering having sum(weight)<=sum(Quantity)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 货物反馈单：货物反馈单的磅单确认重量小于磅单的净重则错误   审核通过则正确
        /// </summary>
        /// <returns></returns>
        public DataTable getTabelErrorForHWFK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select Numbering,SUM(ConfirmTheWeight-NetWeight) calcu from t_CargoFeedbackSheet where code not in (select a.code from t_review a inner join (select code,max(date) date,programId from t_review where programId='FormCargoFeedbackSheet' group by code,programId ) b on a.code=b.code and a.date=b.date and a.programId=b.programId where state='审核') group by Numbering having SUM(ConfirmTheWeight-NetWeight)<0" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 问题反馈单：未完成  有了收款记录单但是没有问题反馈单
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWeiForWTFK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select a.Numbering,c.Numbering from t_salesorder a left join t_receiptrecord b on a.Numbering=b.Numbering left join t_theproblemsheet c on a.Numbering=c.Numbering where (b.Numbering!='' and b.Numbering is not null) and (c.Numbering='' or c.Numbering is null)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 问题反馈单：是否扣款  扣款不为0  审核通过则不显示
        /// </summary>
        /// <returns></returns>
        public DataTable getTableKouForWTFK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select Numbering from t_theproblemsheet where code not in (select a.code from t_review a inner join(select code,max(date) date,programId from t_review where programId='FormTheproblemsheet') b on a.code=b.code and a.date=b.date and a.programId=b.programId where a.state='审核') and Chargeback!=0" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 收款记录单：货物反馈单的磅单确认总重量*销售申请单单价-公司问题反馈单总扣款!=收款记录单的收款总金额
        /// </summary>
        /// <returns></returns>
        public DataTable getTableErrorForSK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select d.Numbering from t_happening a left join t_CargoFeedbackSheet b on a.NumberingOne=b.Numbering and a.product_id=b.FishMealId left join t_theproblemsheet c on a.NumberingOne=c.Numbering and a.product_id=c.FishMealId left join t_receiptrecord d on a.NumberingOne=d.Numbering and a.product_id=d.FishMealId group by d.Numbering,unitprice having sum(d.RMB)!=sum(ConfirmTheWeight)*unitprice-sum(Chargeback)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }


        /// <summary>
        /// 收款记录单：1.收款记录单的总货品重量小与货物反馈单的总重量    2.收款记录单的收款总金额小于 ( 货物反馈单的磅单确认总重量* 销售申请单单价-公司问题反馈单总扣款)
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWeiForSK ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select d.Numbering from t_happening a left join t_CargoFeedbackSheet b on a.NumberingOne=b.Numbering and a.product_id=b.FishMealId left join t_theproblemsheet c on a.NumberingOne=c.Numbering and a.product_id=c.FishMealId left join t_receiptrecord d on a.NumberingOne=d.Numbering and a.product_id=d.FishMealId group by d.Numbering,unitprice having sum(d.RMB)<sum(ConfirmTheWeight)*unitprice-sum(Chargeback) and sum(d.weight)<sum(ConfirmTheWeight)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

    }
}








/*
 * 
 * 2018-5-5
 * 
 select a.Numbering,b.product_id,a.code,a.demand,a.Signdate,a.createman,c.code code1,
case when d.coun1=0 then 0 else 0+convert(convert(d.coun/d.coun1,decimal(11,4))*100,char) end coun,
case when e.coun2=0 then 0 else 0+convert(convert(e.coun3/e.coun2,decimal(11,4))*100,char) end coun1,
case when f.coun2=0 then 0 else 0+convert(convert(f.coun3/f.coun2,decimal(11,4))*100,char) end coun2,
case when g.coun2=0 then 0 else 0+convert(convert(g.coun3/g.coun2,decimal(11,4))*100,char) end coun3,
case when h.coun2=0 then 0 else 0+convert(convert(h.coun3/h.coun2,decimal(11,4))*100,char) end coun4
from t_salesorder a  inner join t_happening b on a.Numbering=b.NumberingOne 
left join (select c.code,MAX(c.createTime) from t_review c inner join t_salesorder b on c.code=b.Numbering where c.state='审核' and c.programId='FormSalesRequisition' group by c.`code`) c on a.Numbering=c.code 
left join (select Numbering,count(f.code) coun1,
(select count(a.code) coun from t_review a inner join t_paymentrequisition b on a.code=b.code where state='审核' and programId='FormPaymentRequisition') 
coun from t_paymentrequisition f group by Numbering ) d on a.Numbering=d.Numbering
left join (select Numbering,FishMealId,count(f.code) coun2,
(select count(a.code) coun from t_review a inner join t_CargoFeedbackSheet b on a.code=b.code where state='审核' and programId='FormCargoFeedbackSheet') 
coun3 from t_CargoFeedbackSheet f group by Numbering,FishMealId
) e on a.Numbering=e.Numbering and b.product_id=e.FishMealId
left join (
select Numbering,FishMealId,count(f.code) coun2,
(select count(a.code) coun from t_review a inner join t_theproblemsheet b on a.code=b.code where state='审核' and programId='FormTheproblemsheet') 
coun3 from t_theproblemsheet f group by Numbering,FishMealId
) f on a.Numbering=f.Numbering and b.product_id=f.FishMealId
left join (select codeNum,fishId,count(f.code) coun2,
(select count(a.code) coun from t_review a inner join t_ReturnReceipt b on a.code=b.code where state='审核' and programId='FormReturnReceipt') 
coun3 from t_ReturnReceipt f group by codeNum,fishId) g on g.codeNum=a.Numbering and g.fishId=b.product_id
left join (
select Numbering,FishMealId,count(f.code) coun2,
(select count(a.code) coun from t_review a inner join t_ReceiptRecord b on a.code=b.code where state='审核' and programId='FormReceiptRecord') 
coun3 from t_ReceiptRecord f group by Numbering,FishMealId
) h on h.Numbering=a.Numbering and h.FishMealId=b.product_id
;
*/


/*
 * 2018-5-8
 select a.Numbering,b.product_id,a.code,a.demand,a.Signdate,a.createman,c.code code1,i.createman createman2,j.code code2,
case when d.coun1=0 then 0 else 0+convert(convert(d.coun/d.coun1,decimal(11,4))*100,char) end coun,
case when e.coun2=0 then 0 else 0+convert(convert(e.coun3/e.coun2,decimal(11,4))*100,char) end coun1,
case when f.coun2=0 then 0 else 0+convert(convert(f.coun3/f.coun2,decimal(11,4))*100,char) end coun2,
case when g.coun2=0 then 0 else 0+convert(convert(g.coun3/g.coun2,decimal(11,4))*100,char) end coun3,
case when h.coun2=0 then 0 else 0+convert(convert(h.coun3/h.coun2,decimal(11,4))*100,char) end coun4,
0+convert(k.ton,char) ton,
0+convert(l.ton,char) ton1
from t_salesorder a  inner join t_happening b on a.Numbering=b.NumberingOne
left join t_salesrcontract i on a.Numbering=i.Numbering
left join (

select c.code from (select a.code from t_review a inner join 
(select code,programId,max(date) date from t_review where programId='FormSalesRequisition' group by code,programId) c on a.code=c.`code` and a.programId=c.programId and a.date=c.date
where a.state='审核') c
inner join t_salesorder b on c.code=b.Numbering 
) c on a.Numbering=c.code 

left join (

select c.code from (select a.code from t_review a inner join 
(select code,programId,max(date) date from t_review where programId='FormSalesRContract' group by code,programId) c on a.code=c.`code` and a.programId=c.programId and a.date=c.date
where a.state='审核') c
inner join t_salesrcontract b on c.code=b.Numbering 
) j on j.code=i.Numbering

left join (

select Numbering,count(f.code) coun1,(select count(a.code) from (
select a.code from t_review a inner join 
(select code,programId,max(date) date from t_review where programId='FormPaymentRequisition' group by code,programId ) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date
where state='审核'
) a inner join t_paymentrequisition b on a.code=b.`code`) coun from t_paymentrequisition f group by Numbering 

) d on a.Numbering=d.Numbering 

left join (

select Numbering,FishMealId,count(f.code) coun2,(select count(a.code) coun from 
(select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormCargoFeedbackSheet' group by code,programId) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a 
inner join t_CargoFeedbackSheet b 
on a.code=b.code ) coun3 from t_CargoFeedbackSheet f group by Numbering,FishMealId  ) 
e on a.Numbering=e.Numbering and b.product_id=e.FishMealId


left join (

select Numbering,FishMealId,count(f.code) coun2,(select count(a.code) coun from 
(select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormTheproblemsheet' group by code,programId) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a 
inner join t_theproblemsheet b 
on a.code=b.code ) coun3 from t_theproblemsheet f group by Numbering,FishMealId 

) f 
on a.Numbering=f.Numbering and b.product_id=f.FishMealId

left join (

select codeNum,fishId,count(f.code) coun2,(select count(a.code) coun from 
(select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormReturnReceipt' group by code,programId) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a 
inner join t_ReturnReceipt b 
on a.code=b.code ) coun3 from t_ReturnReceipt f group by codeNum,fishId 
) g 
on g.codeNum=a.Numbering and g.fishId=b.product_id

left join (

select Numbering,FishMealId,count(f.code) coun2,(select count(a.code) coun from 
(select a.code from t_review a inner join (select code,programId,max(date) date from t_review where programId='FormReceiptRecord' group by code,programId) b 
on a.code=b.code and a.programId=b.programId and a.date=b.date where state='审核' ) a 
inner join t_ReceiptRecord b 
on a.code=b.code ) coun3 from t_ReceiptRecord f group by Numbering,FishMealId 

) h on h.Numbering=a.Numbering and h.FishMealId=b.product_id

left join (select b.NumberingOne,b.product_id,case when sum(Quantity)=0 then 0 else convert(sum(Ton)/sum(Quantity),decimal(11,2))*100 end ton 
from t_billoflading a right join t_happening b on a.codeContract=b.NumberingOne and a.FishMealId=b.product_id
group by b.NumberingOne,b.product_id
) k on k.NumberingOne=i.Numbering and k.product_id=b.product_id

left join (select b.NumberingOne,b.product_id,case when sum(b.Quantity)=0 then 0 else convert(sum(a.Competition)/sum(b.Quantity),decimal(11,2))*100 end ton 
from t_poundsalone a right join t_happening b on a.codeContract=b.NumberingOne and a.FishMealId=b.product_id
group by b.NumberingOne,b.product_id) l on l.NumberingOne=i.Numbering and l.product_id=b.product_id
*/
