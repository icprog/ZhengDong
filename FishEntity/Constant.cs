using System;
using System.Collections.Generic;
using System.Text;

namespace FishEntity
{
    public class Constant
    {
        public const string KEY = "JINXINAGDONG";

        public const string GeneralLevel = "100";
        public const string CreditLevel = "101";
        public const string RequiredLevel="102";
        public const string ManageSpecificateDegree = "103";
        public const string ActiveLevel = "104";
        public const string Loyalty = "105";
        public const string Products = "106";
        public const string CompanyNature = "107";
        public const string ManageProjects = "108";
        public const string Type = "109";
        public const string CustomerProperty = "110";
        public const string Paymethod = "111";
        public const string RequiredProduct = "112";
        public const string Cooperation = "113";//合作认识
        public const string Province = "114";//省份
        public const string GoodsInfo = "115";//货物情况
        public const string Area ="116";//地区

        
        public const string CountryType = "200";//国别
        public const string Quality = "201";//品质
        public const string TechClass = "202";
        public const string FishClass="203";
        public const string CheckItem = "204";//检测项目
        public const string Brand = "205";//
        public const string packk = "300";
        public const string port = "213";//港口

        public const string Origin = "206";
        public const string FishmealClass ="207";
        public const string GoodsEvaluation = "208";//品质评判
        public const string Goods = "209";//产品
        public const string Manufacturers = "210";//生产厂家
        public const string Specification = "211";//品质规格
        public const string Warehouse="212";//仓库
        public const string Modeoftransport = "214";//销售运输方式
        public const string ModeOfTransport = "215";//预售运输方式

        public const string CargoFeedbackSheet = "货物反馈ID";
        public const string ContractProcessingSheet = "处理结果ID";
        public const string SampleSingle = "取样ID";
        public const string EnterWarehouseReceipts = "进仓单ID";
        public const string SalesSequence = "销售申请单";
        public const string LadingNumber = "磅单编号";
        public const string Billofladingnumber = "提货单号";
        public const string CustomerSequence = "联系人编号";
        public const string CompanySequence = "单位ID";
        public const string FishSequence = "鱼粉ID";
        public const string CallRecordSequence = "通话记录ID";
        public const string StorageBillSequence = "进仓单号";
        public const string HomemadeStorageSequence = "自制仓入库单号";
        public const string FoodOutSequence = "配料单号";
        public const string LoadingBillSequence = "提货单号";
        public const string CheckSequence = "检测单号";
        public const string ContractSequence = "合同编号";
        public const string ProductSituation = "产品情况";
        public const string SGSIndicators ="SGS指标";
        public const string Theproblemsheet = "问题反馈编号";
        public const string Disposeofcomments = "意见处理编号";
        public const string ShippingRecords = "发货记录单号";
        public const string PurchaseRequisition = "采购申请单";

        public const string Role_SalesMan = "业务员";
        public const string Role_SalesManager = "业务主管";
        public const string Role_Admin = "管理员";
        public const string Role_Finance = "财务员";
        public const string Role_FinancialOfficer = "财务主管";
        public const string Role_LogisticsStaff = "后勤员";
        public const string Role_LogisticsDirector = "后勤主管";

        /// <summary>
        /// 报盘
        /// </summary>
        public const int STATE_QUOTE = 1;
        /// <summary>
        /// 确盘
        /// </summary>
        public const int STATE_CONFIRM = 2;
        /// <summary>
        /// 现货
        /// </summary>
        public const int STATE_GOODS = 3; 
        /// <summary>
        /// 自营
        /// </summary>
        public const int STATE_SELFBUY = 4;
        /// <summary>
        /// 自制
        /// </summary>
        public const int STATE_SELFMAKE = 5;
        /// <summary>
        ///// 售完
        /// </summary>
        public const int STATE_SALEOUT = 6;
        /// <summary>
        /// 成品
        /// </summary>
        public const int STATE_FINISHED = 7;

    }
}
