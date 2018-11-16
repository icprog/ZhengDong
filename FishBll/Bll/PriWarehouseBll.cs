using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class PriWarehouseBll
    {
        Dao.PriWarehouseDao dal=null;
        public PriWarehouseBll ( )
        {
            dal = new Dao . PriWarehouseDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            return dal . getTableView ( );
        }
        public DataTable mx()
        {
            return dal.mx();
        }
        public DataTable zzmx()
        {
            return dal.zzmx();
        }
    }
}
