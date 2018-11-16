using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class ReceiptRecordBll
    {
        private readonly Dao.ReceiptRecordDao dal=new Dao.ReceiptRecordDao();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . ReceiptRecordEntity getList ( string strWhere )
        {
            return dal . getList ( strWhere );
        }
        public FishEntity.SalesRequisitionEntity getFKSQD(string getname)
        {
            return dal.getFKSQD(getname);
        }
        public DataTable getTable(string strWhere) {
            return dal.getTable(strWhere);
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string GetCode ( )
        {
            return dal . GetCode ( );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . ReceiptRecordEntity _list )
        {
            return dal . Add ( _list );
        }

        /// <summary>
        /// 是否存在合同
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            return dal . Exists ( code );
        }
        /// <summary>
        /// 是否所属
        /// </summary>
        /// <param name="code"></param>
        /// <param name="createman"></param>
        /// <returns></returns>
        public bool ExistsUpdateOrDelete(string code,string createman)
        {
            return dal.ExistsUpdateOrDelete(code, createman);
        }
        
        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . ReceiptRecordEntity _list )
        {
            return dal . Edit ( _list );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="codeOddNum"></param>
        /// <returns></returns>
        public bool Delete ( string codeOddNum )
        {
            return dal . Delete ( codeOddNum );
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
