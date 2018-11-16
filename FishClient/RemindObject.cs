using System;
using System.Collections.Generic;
using System.Text;

namespace FishClient
{
   public static class RemindObject
    {
        private static Dictionary<string, string> proDIC;
        public static Dictionary<string, string> setDicItem() {
            proDIC = new Dictionary<string, string>();

            proDIC.Add("采购申请单", "FormPurchaseApplication");
            proDIC.Add("采购合同", "FormPurcurementContract");
            proDIC.Add("付款申请单", "FormPaymentRequisition");
            proDIC.Add("销售申请单", "FormSalesRequisition");
            proDIC.Add("现货销售合同", "FormSalesRContract");
            proDIC.Add("提货单", "FormBilloflading");
            proDIC.Add("出库单", "FormOutboundOrder");
            proDIC.Add("磅单", "FormOnepound");
            proDIC.Add("货物反馈单", "FormCargoFeedbackSheet");
            proDIC.Add("公司问题反馈单", "FormTheproblemsheet");
            proDIC.Add("收款记录单", "FormReceiptRecord");
            proDIC.Add("成品出库单", "FormFinishedProList");
            return proDIC;
        }

        //proDicDuiXiang.Add("", "ceo");//采购申请单//FormPurchaseApplication
        //proDicDuiXiang.Add("zd_wxj", "ceo");//采购合同//FormPurcurementContract
        //proDicDuiXiang.Add("zd_wxj", "ceo");//付款申请单//FormPaymentRequisition
        //proDicDuiXiang.Add("", "ceo");//销售申请单//FormSalesRequisition
        //proDicDuiXiang.Add("zd_wxj", "ceo");//现货销售合同//FormSalesRContract
        //proDicDuiXiang.Add("zd_lyk", "");//提货单//FormBilloflading
        //proDicDuiXiang.Add("zd_lyk", "");//出库单//FormOutboundOrder
        //proDicDuiXiang.Add("zd_lyk", "");//磅单//FormOnepound
        //proDicDuiXiang.Add("", "ceo");//货物反馈单//FormCargoFeedbackSheet
        //proDicDuiXiang.Add("", "ceo");//公司问题反馈单//FormTheproblemsheet
        //proDicDuiXiang.Add("zd_zwl", "ceo");//收款记录单//FormReceiptRecord
        //proDicDuiXiang.Add("zd_lyk", "");//成品出库单//FormFinishedProList
    }
}
