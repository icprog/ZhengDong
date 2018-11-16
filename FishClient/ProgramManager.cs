using System;
using System . Collections . Generic;
using System . Text;

namespace FishClient
{
    public static class ProgramManager
    {
        private static  Dictionary<string,string> proDic;

        public static Dictionary<string ,string> setDicItem ( )
        {
            proDic = new Dictionary<string ,string> ( );
            proDic . Add ( "" ,"" );
            proDic . Add ( "FormPurchaseApplication" ,"采购申请单" );
            proDic . Add ( "FormPurcurementContract" ,"采购合同" );
            proDic . Add ( "FormPaymentRequisition" ,"付款申请单" );
            proDic . Add ( "FormNewWarehouseReceipt" ,"进仓单" );
            proDic . Add ( "FormStorageOfRequisition" ,"入库申请单" );
            proDic . Add ( "FormSalesRequisition" ,"销售申请单" );
            proDic . Add ( "FormSalesRContract" ,"现货销售合同" );
            proDic . Add ( "FormBilloflading" ,"提货单" );
            proDic . Add ( "FormOnepound" ,"磅单" );
            proDic . Add ( "FormCargoFeedbackSheet" ,"货物反馈单" );
            proDic . Add ( "FormTheproblemsheet" ,"公司问题反馈单" );
            proDic . Add ( "FormReturnReceipt" ,"退货单" );
            proDic . Add ( "FormReceiptRecord" ,"收款记录单" );
            proDic . Add ( "FormOutboundOrder" ,"出库单" );
            return proDic;
        }

    }
}
