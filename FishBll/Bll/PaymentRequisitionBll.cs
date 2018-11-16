using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class PaymentRequisitionBll
    {
        private readonly Dao.PaymentRequisitionDao dal=new Dao.PaymentRequisitionDao();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity .PaymentRequisitionEntity getList ( string strWhere )
        {
            return dal . getList ( strWhere );
        }
        public FishEntity.SalesRequisitionEntity getXSSQD(string getname) {
            return dal.getXSSQD(getname);
        }
        public DataTable getTable(string strWhere)
        {
            return dal.getTable(strWhere);
        }
        /// <summary>
        /// 获取合同单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            return dal . getCode ( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . PaymentRequisitionEntity _list )
        {
            return dal . Add ( _list );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            return dal . Exists ( code );
        }
        public bool ExistsUpdate(string code, string createman)
        {
            return dal.ExistsUpdate(code, createman);
        }
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . PaymentRequisitionEntity _list )
        {
            return dal . Edit ( _list );
        }

        /// <summary>
        /// 获取申请部门
        /// </summary>
        /// <returns></returns>
        public DataTable getDepart ( )
        {
            return dal . getDepart ( );
        }

    }
}
