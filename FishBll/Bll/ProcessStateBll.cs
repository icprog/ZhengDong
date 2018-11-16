using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class ProcessStateBll
    {
        private readonly Dao.ProcessStateDo dal=new Dao.ProcessStateDo();

        /// <summary>
        /// 获取销售申请单的合同编号
        /// </summary>
        /// <returns></returns>
        public DataTable getCode ( )
        {
            return dal . getCode ( );
        }
        public DataTable getNumbering()
        {
            return dal.getNumbering();
        }

        /// <summary>
        /// 预售申请单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormSalesRequisition ( string Numbering)
        {
            return dal . GetFormSalesRequisition (Numbering);
        }

        /// <summary>
        /// 销售合同
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool GetFormSalesRContract ( string Numbering)
        {
            return dal . GetFormSalesRContract (Numbering);

        }

        /// <summary>
        /// 付款申请单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormPaymentRequisition ( string code )
        {
            return dal . GetFormPaymentRequisition ( code );
        }

        /// <summary>
        /// 提货单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormBilloflading ( string code )
        {
            return dal . GetFormBilloflading ( code );
        }
        public List<FishEntity.BillofladingEntity> GetBillofladingListOne(string Numbering)
        {
            return dal.GetBillofladingListOne(Numbering);
        }
        public List<FishEntity.CargoFeedbackSheetEntity> GetCargoFeedbackSheetList(string Numbering) {
            return dal.GetCargoFeedbackSheetList(Numbering);
        }
        public bool ExistsNumbering(string Numbering, string status) {
            return dal.ExistsNumbering(Numbering, status);
        }
        public List<FishEntity.TheproblemsheetEntity> GetTheproblemsheetList(string Numbering) {
            return dal.GetTheproblemsheetList(Numbering);
        }

        /// <summary>
        /// 磅单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormOnepound ( string code )
        {
            return dal . GetFormOnepound ( code );
        }
        public List<FishEntity.OnepoundEntity> GetFormOnepoundList(string Numbering)
        {
            return dal.GetFormOnepoundList(Numbering);
        }
        public DataTable getdataset(string where)
        {
            return dal.getdataset(where);
        }
        /// <summary>
        /// 货物反馈单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormCargoFeedbackSheet ( string Numbering)
        {
            return dal . GetFormCargoFeedbackSheet (Numbering);
        }

        /// <summary>
        /// 问题反馈单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormTheproblemsheet ( string Numbering)
        {
            return dal . GetFormTheproblemsheet (Numbering);
        }

        /// <summary>
        /// 收款记录单  提成换算表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool GetFormReceiptRecord ( string Numbering)
        {
            return dal . GetFormReceiptRecord (Numbering);
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . ProcessStateEntity> getList ( string strWhere )
        {
            return dal . getList ( strWhere );
        }
        /// <summary>
        /// 有效性
        /// </summary>
        /// <param name="Numbering"></param>
        /// <param name="effect"></param>
        /// <returns></returns>
        public bool update(string effect, string Numbering)
        {
            return dal.update(effect, Numbering);
        }
        /// <summary>
        /// 付款申请单数据查询
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity . PaymentRequisitionEntity> GetListOne ( string code )
        {
            return dal . GetListOne ( code );
        }

        /// <summary>
        /// 收款记录单数据查询
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity . ReceiptRecordEntity> GetListTwo ( string Numbering)
        {
            return dal . GetListTwo (Numbering);
        }

    }
}
