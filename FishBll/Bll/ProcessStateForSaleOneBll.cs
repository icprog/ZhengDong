using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class ProcessStateForSaleOneBll
    {
        private readonly  Dao. ProcessStateForSaleOneDao dal=null;
        public ProcessStateForSaleOneBll ( )
        {
            dal = new Dao . ProcessStateForSaleOneDao ( );
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
        public DataTable getTableViewzizhi(string strWhere)
        {
            return dal.getTableViewzizhi(strWhere);
        }


        /// <summary>
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFishId ( )
        {
            return dal . getTableFishId ( );
        }

        /// <summary>
        /// 付款申请单错误：货品重量*货品单价不等于申请金额    显示黄色   审核通过正确
        /// </summary>
        /// <returns></returns>
        public DataTable getTableErrorForFK ( )
        {
            return dal . getTableErrorForFK ( );
        }

    }
}
