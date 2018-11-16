using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class SelfcontrolWareBll
    {
        Dao.SelfcontrolWareDao dal=null;
        public SelfcontrolWareBll ( )
        {
            dal = new Dao . SelfcontrolWareDao ( );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( )
        {
            return dal . getTableView ( );
        }
    }
}
