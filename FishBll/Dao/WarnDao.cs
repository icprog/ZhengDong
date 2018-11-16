using MySql . Data . MySqlClient;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Dao
{
    public class WarnDao
    {
        /// <summary>
        /// 根据程序名称获取职位
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePosition ( string proName )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select rolename from t_role a inner join t_rolefun b on a.roleid=b.roleid inner join t_funcode c on b.funid=c.funid where funname='{0}'" ,proName );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }
        /// <summary>
        /// 根据职位获取人员信息
        /// </summary>
        /// <param name="realname"></param>
        /// <returns></returns>
        public DataTable getTableUser ( string realname )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select distinct a.realname,a.id from t_user a inner join v_userrole b on a.id=b.userid inner join t_rolefun c on b.funid=c.funid inner join t_role d on c.roleid=d.roleid where d . rolename = '{0}'" ,realname );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 根据人员信息获取程序名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getTablePro ( string id )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select distinct funname from v_userrole a inner join t_user b on a.userid=b.id where type=0 and userid='{0}'" ,id );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( FishEntity . WarnEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM t_warn where orderNum='{0}' and reviewUserNum='{1}' and examineUserNum='{2}' " ,model . orderNum ,model . reviewUserNum ,model . examineUserNum );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

        public bool Exists_Edit ( FishEntity . WarnEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1)  FROM t_warn where orderNum='{0}' and reviewUserNum='{1}' and examineUserNum='{2}' and id!={3} " ,model . orderNum ,model . reviewUserNum ,model . examineUserNum ,model . id );

            return MySqlHelper . Exists ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Save ( FishEntity . WarnEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_warn(" );
            strSql . Append ( "orderName,orderNum,position,reviewUserName,reviewUserNum,examineUserName,examineUserNum,order1Name,order1Num,order2Name,order2Num,order3Name,order3Num,order4Name,order4Num,order5Name,order5Num)" );
            strSql . Append ( " values (" );
            strSql . Append ( "@orderName,@orderNum,@position,@reviewUserName,@reviewUserNum,@examineUserName,@examineUserNum,@order1Name,@order1Num,@order2Name,@order2Num,@order3Name,@order3Num,@order4Name,@order4Num,@order5Name,@order5Num)" );
            strSql . Append ( ";select @@IDENTITY; " );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@orderName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@orderNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@position", MySqlDbType.VarChar,45),
                    new MySqlParameter("@reviewUserName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@reviewUserNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@examineUserName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@examineUserNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order1Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order1Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order2Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order2Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order3Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order3Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order4Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order4Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order5Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order5Num", MySqlDbType.VarChar,45)};
            parameters [ 0 ] . Value = model . orderName;
            parameters [ 1 ] . Value = model . orderNum;
            parameters [ 2 ] . Value = model . position;
            parameters [ 3 ] . Value = model . reviewUserName;
            parameters [ 4 ] . Value = model . reviewUserNum;
            parameters [ 5 ] . Value = model . examineUserName;
            parameters [ 6 ] . Value = model . examineUserNum;
            parameters [ 7 ] . Value = model . order1Name;
            parameters [ 8 ] . Value = model . order1Num;
            parameters [ 9 ] . Value = model . order2Name;
            parameters [ 10 ] . Value = model . order2Num;
            parameters [ 11 ] . Value = model . order3Name;
            parameters [ 12 ] . Value = model . order3Num;
            parameters [ 13 ] . Value = model . order4Name;
            parameters [ 14 ] . Value = model . order4Num;
            parameters [ 15 ] . Value = model . order5Name;
            parameters [ 16 ] . Value = model . order5Num;

            return MySqlHelper . ExecuteSqlReturnId ( strSql . ToString ( ) ,parameters );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . WarnEntity model )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "update t_warn set " );
            strSql . Append ( "orderName=@orderName," );
            strSql . Append ( "orderNum=@orderNum," );
            strSql . Append ( "position=@position," );
            strSql . Append ( "reviewUserName=@reviewUserName," );
            strSql . Append ( "reviewUserNum=@reviewUserNum," );
            strSql . Append ( "examineUserName=@examineUserName," );
            strSql . Append ( "examineUserNum=@examineUserNum," );
            strSql . Append ( "order1Name=@order1Name," );
            strSql . Append ( "order1Num=@order1Num," );
            strSql . Append ( "order2Name=@order2Name," );
            strSql . Append ( "order2Num=@order2Num," );
            strSql . Append ( "order3Name=@order3Name," );
            strSql . Append ( "order3Num=@order3Num," );
            strSql . Append ( "order4Name=@order4Name," );
            strSql . Append ( "order4Num=@order4Num," );
            strSql . Append ( "order5Name=@order5Name," );
            strSql . Append ( "order5Num=@order5Num" );
            strSql . Append ( " where id=@id" );
            MySqlParameter [ ] parameters = {
                    new MySqlParameter("@orderName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@orderNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@position", MySqlDbType.VarChar,45),
                    new MySqlParameter("@reviewUserName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@reviewUserNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@examineUserName", MySqlDbType.VarChar,45),
                    new MySqlParameter("@examineUserNum", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order1Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order1Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order2Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order2Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order3Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order3Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order4Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order4Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order5Name", MySqlDbType.VarChar,45),
                    new MySqlParameter("@order5Num", MySqlDbType.VarChar,45),
                    new MySqlParameter("@id", MySqlDbType.Int32,10)};
            parameters [ 0 ] . Value = model . orderName;
            parameters [ 1 ] . Value = model . orderNum;
            parameters [ 2 ] . Value = model . position;
            parameters [ 3 ] . Value = model . reviewUserName;
            parameters [ 4 ] . Value = model . reviewUserNum;
            parameters [ 5 ] . Value = model . examineUserName;
            parameters [ 6 ] . Value = model . examineUserNum;
            parameters [ 7 ] . Value = model . order1Name;
            parameters [ 8 ] . Value = model . order1Num;
            parameters [ 9 ] . Value = model . order2Name;
            parameters [ 10 ] . Value = model . order2Num;
            parameters [ 11 ] . Value = model . order3Name;
            parameters [ 12 ] . Value = model . order3Num;
            parameters [ 13 ] . Value = model . order4Name;
            parameters [ 14 ] . Value = model . order4Num;
            parameters [ 15 ] . Value = model . order5Name;
            parameters [ 16 ] . Value = model . order5Num;
            parameters [ 17 ] . Value = model . id;

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) ,parameters );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM t_warn where id={0}" ,id );

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );
            return rows > 0 ? true : false;
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . WarnEntity> getList ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select id,orderName,orderNum,position,reviewUserName,reviewUserNum,examineUserName,examineUserNum,order1Name,order1Num,order2Name,order2Num,order3Name,order3Num,order4Name,order4Num,order5Name,order5Num from t_warn" );

            List<FishEntity . WarnEntity> modelList = new List<FishEntity . WarnEntity> ( );
            DataTable table = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( table == null || table . Rows . Count < 1 )
                return null;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    modelList . Add ( getModel ( row ) );
                }
                return modelList;
            }
        }

        public FishEntity . WarnEntity getModel ( DataRow row )
        {
            FishEntity . WarnEntity model = new FishEntity . WarnEntity ( );
            if ( row != null )
            {
                if ( row [ "id" ] != null && row [ "id" ] . ToString ( ) != "" )
                {
                    model . id = int . Parse ( row [ "id" ] . ToString ( ) );
                }
                if ( row [ "orderName" ] != null )
                {
                    model . orderName = row [ "orderName" ] . ToString ( );
                }
                if ( row [ "orderNum" ] != null )
                {
                    model . orderNum = row [ "orderNum" ] . ToString ( );
                }
                if ( row [ "position" ] != null )
                {
                    model . position = row [ "position" ] . ToString ( );
                }
                if ( row [ "reviewUserName" ] != null )
                {
                    model . reviewUserName = row [ "reviewUserName" ] . ToString ( );
                }
                if ( row [ "reviewUserNum" ] != null )
                {
                    model . reviewUserNum = row [ "reviewUserNum" ] . ToString ( );
                }
                if ( row [ "examineUserName" ] != null )
                {
                    model . examineUserName = row [ "examineUserName" ] . ToString ( );
                }
                if ( row [ "examineUserNum" ] != null )
                {
                    model . examineUserNum = row [ "examineUserNum" ] . ToString ( );
                }
                if ( row [ "order1Name" ] != null )
                {
                    model . order1Name = row [ "order1Name" ] . ToString ( );
                }
                if ( row [ "order1Num" ] != null )
                {
                    model . order1Num = row [ "order1Num" ] . ToString ( );
                }
                if ( row [ "order2Name" ] != null )
                {
                    model . order2Name = row [ "order2Name" ] . ToString ( );
                }
                if ( row [ "order2Num" ] != null )
                {
                    model . order2Num = row [ "order2Num" ] . ToString ( );
                }
                if ( row [ "order3Name" ] != null )
                {
                    model . order3Name = row [ "order3Name" ] . ToString ( );
                }
                if ( row [ "order3Num" ] != null )
                {
                    model . order3Num = row [ "order3Num" ] . ToString ( );
                }
                if ( row [ "order4Name" ] != null )
                {
                    model . order4Name = row [ "order4Name" ] . ToString ( );
                }
                if ( row [ "order4Num" ] != null )
                {
                    model . order4Num = row [ "order4Num" ] . ToString ( );
                }
                if ( row [ "order5Name" ] != null )
                {
                    model . order5Name = row [ "order5Name" ] . ToString ( );
                }
                if ( row [ "order5Num" ] != null )
                {
                    model . order5Num = row [ "order5Num" ] . ToString ( );
                }
            }
            return model;
        }

        /// <summary>
        /// 获取送审单据数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable getTable ( int id )
        {
            StringBuilder strSql = new StringBuilder ( );
            //if ( id != 8 )
                strSql . AppendFormat ( " select c.programId,count(1) coun from t_review c inner join t_user b on c.userName=b.username inner join t_warn d  on b.id=d.reviewUserNum and d.orderNum=c.programId where d.examineUserNum='{0}' and (select count(1) from (select programId,Numbering,max(date) m from t_review where Numbering!='' and state='审核' group by programId,Numbering) a where c.programId=a.programId and c.Numbering=a.Numbering)=0 group by c.programId;" ,id );
            //else if(id==8)
            //    strSql . AppendFormat ( " select c.programId,count(1) coun from t_review c inner join t_user b on c.userName=b.username inner join t_warn d  on b.id=d.reviewUserNum and d.orderNum=c.programId where (select count(1) from (select programId,Numbering,max(date) m from t_review where Numbering!='' and state='审核' group by programId,Numbering) a where c.programId=a.programId and c.Numbering=a.Numbering)=0 group by c.programId;" ,id );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //根据登录人信息，得到登录人权限
        public Dictionary<string ,string> dicPower ( int id ,Dictionary<string ,string> proManager )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select distinct funname from v_userrole where type=0 and userid={0}" ,id );

            DataTable table = MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
            if ( table == null || table . Rows . Count < 1 )
                return null;
            else
            {
                Dictionary<string ,string> dicPro = new Dictionary<string ,string> ( );
                foreach ( DataRow row in table . Rows )
                {
                    foreach ( string key in proManager . Keys )
                    {
                        if ( proManager [ key ] . Equals ( row [ "funname" ] ) )
                            dicPro . Add ( key ,row [ "funname" ] . ToString ( ) );
                    }
                }
                return dicPro;
            }
        }

        //根据权限和流程，遍历登录人需要提醒的事项

        //采购申请单有单据时,提示审核  t_purchaseApplication:采购申请单(FormPurchaseApplication)
        public DataTable table12 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormPurchaseApplication' programId,count(1) coun,0 state from t_purchaseApplication where codeNum not in (SELECT a.codeNum FROM t_purchaseApplication a inner join t_review b on a.codeNum=b.Numbering where state = '审核' and programId = 'FormPurchaseApplication' )" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //采购申请单已录入有单据时，提醒录入采购合同  t_purchasecontract:采购合同(FormPurcurementContract)
        public DataTable table13 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select 'FormPurcurementContract' programId,count(1) coun,1 state from t_purchasecontract where codeNum not in (select codeNum from t_purchaseApplication)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //采购合同录入之后,提示采购合同审核
        public DataTable table1 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormPurcurementContract' programId,count(1) coun,0 state from t_purchasecontract where codeNum not in (SELECT a.codeNum FROM t_purchasecontract a inner join t_review b on a.codeNum=b.Numbering where state = '审核' and programId = 'FormPurcurementContract')" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //付款申请单有数据时，提醒付款申请单审核，一直付款申请单审核完  t_paymentrequisition:付款申请单(FormPaymentRequisition)
        public DataTable table2 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "SELECT programId,count(1) coun FROM t_purchasecontract a inner join t_review b on a.codeNum=b.Numbering where state='审核' AND programId='FormPurcurementContract' AND (SELECT COUNT(1) FROM t_paymentrequisition c where a.codeNum=c.CNumbering)=0 group by programId" );

            strSql . Append ( "select 'FormPaymentRequisition' programId,count(1) coun,0 state from t_paymentrequisition where code not in (select a.`code` from t_paymentrequisition a inner join t_review b on a.`code`=b.SingleNumber where state='审核' AND programId='FormPaymentRequisition')" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //销售申请单录入之后，提醒销售申请单审核    t_salesorder:销售申请单(FormSalesRequisition)
        public DataTable table14 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select 'FormSalesRequisition' programId,count(1) coun,0 state from t_salesorder where Numbering not in (select a.Numbering from t_salesorder a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormSalesRequisition');" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //销售申请单已录入有单据时，提醒录入销售合同    t_salesrcontract:销售合同(FormSalesRContract)
        public DataTable table15 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select 'FormSalesRContract' programId,count(1) coun,1 state from t_salesrcontract where Numbering not in (select Numbering from t_salesorder);" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //销售合同录入完之后，提醒销售合同审核       
        public DataTable table3 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql.AppendFormat( "select 'FormSalesRContract' programId,count(1) coun,0 state from t_salesrcontract where Numbering not in (select a.Numbering from t_salesrcontract a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormSalesRContract')" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //付款申请单审核之后，提醒提货单录入，每审核一次就要增加一个提醒，付款申请单已审核数据等于提货单数据
        //                                             t_billoflading:提货单(FormBilloflading)
        public DataTable table5 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "select 'FormBilloflading' programId,count(1) coun from t_billoflading where Numbering not in (select a.Numbering from t_paymentrequisition a inner join t_review b on a.code=b.SingleNumber where state='审核' and programId='FormPaymentRequisition');");

            strSql . AppendFormat ( "select 'FormBilloflading' programId,count(1) coun,1 state from (select distinct a.Numbering from t_paymentrequisition a inner join t_review b on a.code=b.SingleNumber where state='审核' and programId='FormPaymentRequisition') a left join t_billoflading b on a.Numbering=b.Numbering where b.Numbering is null and a.Numbering!=''" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //提货单录入之后，提醒磅单录入                t_poundsalone:磅单(FormOnepound)
        public DataTable table6 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormOnepound' programId,count(1) coun,1 state from t_poundsalone where Numbering not in (select Numbering from t_billoflading)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //磅单录入之后提醒货物反馈单录入，磅单与货物反馈单一对一    t_CargoFeedbackSheet:货物反馈单(FormCargoFeedbackSheet)
        public DataTable table7 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormCargoFeedbackSheet' programId,count(1) coun,1 state from t_CargoFeedbackSheet where PoundBillNumber not in (select code from t_poundsalone)" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //货物反馈单录入之后，提醒货物反馈单审核，一直到货物反馈单全部审核
        public DataTable table16 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select 'FormCargoFeedbackSheet' programId,count(1) coun,0 state from t_CargoFeedbackSheet where code not in (select a.code from t_CargoFeedbackSheet a inner join t_review b on a.code=b.SingleNumber where state='审核' and programId='FormCargoFeedbackSheet')" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //货物反馈单审核之后，提醒问题反馈单录入     t_theproblemsheet:问题反馈单(FormTheproblemsheet)
        public DataTable table8 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormTheproblemsheet' programId,count(1) coun,1 state from t_theproblemsheet where Numbering not in (select a.Numbering from t_CargoFeedbackSheet a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormTheproblemsheet');" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //问题反馈单录入之后，提醒问题反馈单审核，一直到问题反馈单单据全部审核  
        public DataTable table17 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select 'FormTheproblemsheet' programId,count(1) coun,0 state from t_theproblemsheet where code not in (select a.code from t_theproblemsheet a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormTheproblemsheet')" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //销售申请单回款时间小于当天收款记录单的时间并且收款总金额与应收总金额不符且小与应收总金额提醒录入
        //t_ReceiptRecord:收款记录单(FormReceiptRecord)
        public DataTable table9 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormReceiptRecord' programId,count(1) coun,1 state from (select payment,fuKuandate,sum(c.Quantity*c.unitprice) sum1,sum(RMB) sum2 from t_ReceiptRecord a inner join t_salesorder b on a.Numbering=b.Numbering inner join t_happening c on b.Numbering=c.NumberingOne group by payment,fuKuandate) a where date(payment)<date(fuKuandate) and sum1!=sum2" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //收款记录单录入之后，提醒收款记录单审核，一直到收款记录单单据全部审核  
        public DataTable table18 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "select 'FormReceiptRecord' programId,count(1) coun,0 state from t_ReceiptRecord where `code` not in (select a.code from t_ReceiptRecord a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormReceiptRecord');" );
            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //出库单录入之后，提醒磅单录入      t_OutboundOrder:出库单(FormOutboundOrder)
        public DataTable table10 ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormOnepound' programId,count(1) coun,1 state from (select distinct codeNum,Numbering from t_OutboundOrder a left join t_poundsalone b on a.codeNum=b.Numbering) a where Numbering is null;" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        public DataTable tableAll ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select 'FormPurchaseApplication' programId,count(1) coun,0 state from t_purchaseApplication where codeNum not in (SELECT a.codeNum FROM t_purchaseApplication a inner join t_review b on a.codeNum=b.Numbering where state = '审核' and programId = 'FormPurchaseApplication')" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormPurcurementContract' programId,count(1) coun,1 state  from t_purchasecontract where codeNum not in (select codeNum from t_purchaseApplication)" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormPurcurementContract' programId,count(1) coun,0 state from t_purchasecontract where codeNum not in (SELECT a.codeNum FROM t_purchasecontract a inner join t_review b on a.codeNum=b.Numbering where state = '审核' and programId = 'FormPurcurementContract')" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormPaymentRequisition' programId,count(1) coun,0 state from t_paymentrequisition where code not in (select a.`code` from t_paymentrequisition a inner join t_review b on a.`code`=b.SingleNumber where state='审核' AND programId='FormPaymentRequisition')" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormSalesRequisition' programId,count(1) coun,0 state from t_salesorder where Numbering not in (select a.Numbering from t_salesorder a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormSalesRequisition')" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormSalesRContract' programId,count(1) coun,1 state from t_salesrcontract where Numbering not in (select Numbering from t_salesorder)" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormSalesRContract' programId,count(1) coun,0 state from t_salesrcontract where Numbering not in (select a.Numbering from t_salesrcontract a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormSalesRContract')" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormBilloflading' programId,count(1) coun,1 state from (select distinct a.Numbering from t_paymentrequisition a inner join t_review b on a.code=b.SingleNumber where state='审核' and programId='FormPaymentRequisition') a left join t_billoflading b on a.Numbering=b.Numbering where b.Numbering is null and a.Numbering!=''" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormOnepound' programId,count(1) coun,1 state from t_poundsalone where Numbering not in (select Numbering from t_billoflading)" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormCargoFeedbackSheet' programId,count(1) coun,1 state from t_CargoFeedbackSheet where PoundBillNumber not in (select code from t_poundsalone)" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormCargoFeedbackSheet' programId,count(1) coun,0 state from t_CargoFeedbackSheet where code not in (select a.code from t_CargoFeedbackSheet a inner join t_review b on a.code=b.SingleNumber where state='审核' and programId='FormCargoFeedbackSheet')" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormTheproblemsheet' programId,count(1) coun,1 state from t_theproblemsheet where Numbering not in (select a.Numbering from t_CargoFeedbackSheet a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormTheproblemsheet')" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormTheproblemsheet' programId,count(1) coun,0 state from t_theproblemsheet where code not in (select a.code from t_theproblemsheet a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormTheproblemsheet')" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormReceiptRecord' programId,count(1) coun,1 state from (select payment,fuKuandate,sum(c.Quantity*c.unitprice) sum1,sum(RMB) sum2 from t_ReceiptRecord a inner join t_salesorder b on a.Numbering=b.Numbering inner join t_happening c on b.Numbering=c.NumberingOne group by payment,fuKuandate) a where date(payment)<date(fuKuandate) and sum1!=sum2" );
            strSql . Append ( " union all " );
            strSql . Append ( "select 'FormReceiptRecord' programId,count(1) coun,0 state from t_ReceiptRecord where `code` not in (select a.code from t_ReceiptRecord a inner join t_review b on a.Numbering=b.Numbering where state='审核' and programId='FormReceiptRecord')" );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select 'FormOnepound' programId,count(1) coun,1 state from (select distinct codeNum,Numbering from t_OutboundOrder a left join t_poundsalone b on a.codeNum=b.Numbering) a where Numbering is null" );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        //把得到的提醒事项写入表中
        public DataTable getWarnInfo ( int id ,Dictionary<string ,string> proManager )
        {
            Hashtable SQLString = new Hashtable ( );
            
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "delete from t_warnAll" ,id );

            int rows = MySqlHelper . ExecuteSql ( strSql . ToString ( ) );

            FishEntity . WainAllEntity model = new FishEntity . WainAllEntity ( );

            DataTable table = null;

            Dictionary<string ,string> proDic = dicPower ( id ,proManager );
            if ( proDic != null && proDic . Count > 0 )
            {

                #region
                /*

                #region  采购申请单有单据时,提示审核  t_purchaseApplication:采购申请单(FormPurchaseApplication)
                if ( proDic . ContainsKey ( "FormPurchaseApplication" ) )
                {
                    table = table12 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 采购申请单已录入有单据时，提醒录入采购合同  t_purchasecontract:采购合同(FormPurcurementContract)
                if ( proDic . ContainsKey ( "FormPurcurementContract" ) )
                {
                    table = table13 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 采购合同录入之后,提示采购合同审核
                if ( proDic . ContainsKey ( "FormPurcurementContract" ) )
                {
                    table = table1 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 付款申请单有数据时，提醒付款申请单审核，一直付款申请单审核完  t_paymentrequisition:付款申请单(FormPaymentRequisition)
                if ( proDic . ContainsKey ( "FormPaymentRequisition" ) )
                {
                    table = table2 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 销售申请单录入之后，提醒销售申请单审核    t_salesorder:销售申请单(FormSalesRequisition)
                if ( proDic . ContainsKey ( "FormSalesRequisition" ) )
                {
                    table = table14 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 销售申请单已录入有单据时，提醒录入销售合同    t_salesrcontract:销售合同(FormSalesRContract)
                if ( proDic . ContainsKey ( "FormSalesRContract" ) )
                {
                    table = table15 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 销售合同录入完之后，提醒销售合同审核       
                if ( proDic . ContainsKey ( "FormSalesRContract" ) )
                {
                    table = table3 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 付款申请单审核之后，提醒提货单录入，每审核一次就要增加一个提醒，付款申请单已审核数据等于提货单数据  t_billoflading:提货单(FormBilloflading)
                if ( proDic . ContainsKey ( "FormBilloflading" ) )
                {
                    table = table5 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 提货单录入之后，提醒磅单录入                t_poundsalone:磅单(FormOnepound)
                if ( proDic . ContainsKey ( "FormOnepound" ) )
                {
                    table = table6 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 磅单录入之后提醒货物反馈单录入，磅单与货物反馈单一对一    t_CargoFeedbackSheet:货物反馈单(FormCargoFeedbackSheet)
                if ( proDic . ContainsKey ( "FormCargoFeedbackSheet" ) )
                {
                    table = table7 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 货物反馈单录入之后，提醒 货物反馈单审核，一直到货物反馈单全部审核
                if ( proDic . ContainsKey ( "FormCargoFeedbackSheet" ) )
                {
                    table = table16 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 货物反馈单审核之后，提醒问题反馈单录入     t_theproblemsheet:问题反馈单(FormTheproblemsheet)
                if ( proDic . ContainsKey ( "FormTheproblemsheet" ) )
                {
                    table = table8 ( );
                    if ( table != null && table . Rows . Count > 0  )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 问题反馈单录入之后，提醒问题反馈单审核，一直到问题反馈单单据全部审核  
                if ( proDic . ContainsKey ( "FormTheproblemsheet" ) )
                {
                    table = table17 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 销售申请单回款时间小于当天收款记录单的时间并且收款总金额与应收总金额不符且小与应收总金额提醒录入  t_ReceiptRecord:收款记录单(FormReceiptRecord)
                if ( proDic . ContainsKey ( "FormReceiptRecord" ) )
                {
                    table = table9 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 收款记录单录入之后，提醒收款记录单审核，一直到收款记录单单据全部审核  
                if ( proDic . ContainsKey ( "FormReceiptRecord" ) )
                {
                    table = table18 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "0";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion

                #region 出库单录入之后，提醒磅单录入      t_OutboundOrder:出库单(FormOutboundOrder)
                if ( proDic . ContainsKey ( "FormOutboundOrder" ) )
                {
                    table = table10 ( );
                    if ( table != null && table . Rows . Count > 0 )
                    {
                        model . State = "1";
                        model . UserId = id . ToString ( );
                        foreach ( DataRow row in table . Rows )
                        {
                            model . ProId = row [ "programId" ] . ToString ( );
                            model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                            addWain ( model ,SQLString );
                        }
                    }
                }
                #endregion
                
                */
#endregion

                table = tableAll ( );
                if ( table != null && table . Rows . Count > 0 )
                {
                    model . UserId = id . ToString ( );
                    foreach ( DataRow row in table . Rows )
                    {
                        model . State = row [ "state" ] . ToString ( );
                        model . ProId = row [ "programId" ] . ToString ( );
                        model . Count = string . IsNullOrEmpty ( row [ "coun" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "coun" ] . ToString ( ) );
                        addWain ( model ,SQLString );
                    }
                }

            }

            //从表中查询并显示
            MySqlHelper . ExecuteSqlTran ( SQLString );

            strSql = new StringBuilder ( );
            //查询非审核提醒
            strSql . Append ( "select programId,sum(count) coun from (" );
            strSql . Append ( "select proId programId,sum(count) count from t_warnAll where state='1' group by proId " );
            strSql . Append ( " union all " );
            strSql . AppendFormat ( "select distinct proId,count from t_warn a inner join t_warnAll b on a.orderNum=b.proId where state='0' and examineUserNum='{0}') a where count!=0 group by programId" ,id );

            return MySqlHelper . Query ( strSql . ToString ( ) ) . Tables [ 0 ];
        }

        void addWain ( FishEntity . WainAllEntity model ,Hashtable SQLString )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "insert into t_warnAll( " );
            strSql . Append ( "proId,state,count) " );
            strSql . Append ( "values (" );
            strSql . Append ( "@proId,@state,@count) " );
            MySqlParameter [ ] parameter = {
                new MySqlParameter("@proId",MySqlDbType.VarChar,45),
                new MySqlParameter("@state",MySqlDbType.VarChar,45),
                new MySqlParameter("@count",MySqlDbType.Int32,4)
            };
            parameter [ 0 ] . Value = model . ProId;
            parameter [ 1 ] . Value = model . State;
            parameter [ 2 ] . Value = model . Count;
            SQLString . Add ( strSql ,parameter );
        }

    }
}
