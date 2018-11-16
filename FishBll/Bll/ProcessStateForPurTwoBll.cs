using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class ProcessStateForPurTwoBll
    {
        Dao.ProcessStateForPurTwoDao dal=null;
        public ProcessStateForPurTwoBll ( )
        {
            dal = new Dao . ProcessStateForPurTwoDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dal . getTableView ( strWhere );
        }

        /// <summary>
        /// 获取鱼粉id
        /// </summary>
        /// <returns></returns>
        public DataTable getFishTable ( )
        {
            return dal . getFishTable ( );
        }

        /// <summary>
        /// 货物反馈单：货物反馈单的磅单确认重量小于磅单的净重则错误   审核通过则正确
        /// </summary>
        /// <returns></returns>
        public DataTable getTabelErrorForHWFK ( )
        {
            return dal . getTabelErrorForHWFK ( );
        }

        /// <summary>
        /// 问题反馈单：未完成  有了收款记录单但是没有问题反馈单
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWeiForWTFK ( )
        {
            return dal . getTableWeiForWTFK ( );
        }

        /// <summary>
        /// 问题反馈单：是否扣款  扣款不为0  审核通过则不显示
        /// </summary>
        /// <returns></returns>
        public DataTable getTableKouForWTFK ( )
        {
            return dal . getTableKouForWTFK ( );
        }


        /// <summary>
        /// 收款记录单：货物反馈单的磅单确认总重量*销售申请单单价-公司问题反馈单总扣款!=收款记录单的收款总金额
        /// </summary>
        /// <returns></returns>
        public DataTable getTableErrorForSK ( )
        {
            return dal . getTableErrorForSK ( );
        }


        /// <summary>
        /// 收款记录单：1.收款记录单的总货品重量小与货物反馈单的总重量    2.收款记录单的收款总金额小于 ( 货物反馈单的磅单确认总重量* 销售申请单单价-公司问题反馈单总扣款)
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWeiForSK ( )
        {
            return dal . getTableWeiForSK ( );
        }


    }
}
