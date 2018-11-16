using System;
using System . Collections . Generic;
using System . Text;

namespace FishBll . Bll
{
    public class PurchaseAppFishInfoBll
    {
        private readonly Dao.PurchaseAppFishInfoDao dal=null;
        public PurchaseAppFishInfoBll ( )
        {
            dal = new Dao . PurchaseAppFishInfoDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseAppFishInfoEntity> getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . PurchaseAppFishInfoEntity getModelOne ( string strWhere )
        {
            return dal . getModelOne ( strWhere );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( FishEntity . PurchaseAppFishInfoEntity model )
        {
            return dal . Delete ( model );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Save ( FishEntity . PurchaseAppFishInfoEntity model )
        {
            return dal . Save ( model );
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="FishId"></param>
        /// <returns></returns>
        public bool ExistsFishId(string FishId)
        {
            return dal.ExistsFishId(FishId);
        }        /// <summary>
                 /// 是否存在
                 /// </summary>
                 /// <param name="FishId"></param>
                 /// <returns></returns>
        public bool ExistsFishId1(string FishId)
        {
            return dal.ExistsFishId1(FishId);
        }
    }
}
