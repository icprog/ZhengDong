using System;
using System . Collections . Generic;
using System . Text;

namespace FishBll . Bll
{
    public class ReductionClauseBll
    {
        private readonly Dao.ReductionClauseDao dal=null;
        public ReductionClauseBll ( )
        {
            dal = new Dao . ReductionClauseDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity . ReductionClauseEntity> getModelList ( string strWhere )
        {
            return dal . getModelList ( strWhere );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Save ( List<FishEntity . ReductionClauseEntity> modelList )
        {
            return dal . Save ( modelList );
        }

        /// <summary>
        /// 删除出数据
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id )
        {
            return dal . Delete ( id );
        }

    }
    
}
