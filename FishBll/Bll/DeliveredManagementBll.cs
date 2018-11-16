using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class DeliveredManagementBll
    {
        FishBll.Dao.DeliveredManagementDao dal = new Dao.DeliveredManagementDao();
        public DeliveredManagementBll() { }
        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }
        public FishEntity.DeliveredManagementEntity getList(string strWhere)
        {
            return dal.getList(strWhere);
        }


        public List<FishEntity . DeliveredManagementEntity> getModelList ( )
        {
            return dal . getModelList ( );
        }

        public bool Add(FishEntity.DeliveredManagementEntity _list)
        {
            return dal.Add(_list);
        }
        public bool Update(FishEntity.DeliveredManagementEntity _list)
        {
            return dal.Update(_list);
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Add ( List<FishEntity . DeliveredManagementEntity> modelList )
        {
            return dal . Add ( modelList );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Update ( List<FishEntity . DeliveredManagementEntity> modelList )
        {
            return dal . Update ( modelList );
        }

    }
}
