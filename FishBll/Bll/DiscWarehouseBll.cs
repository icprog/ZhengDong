using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Bll
{
   public class DiscWarehouseBll
    {
        private readonly Dao.DiscWarehouseDao dal=new Dao.DiscWarehouseDao();
        public DiscWarehouseBll() { }
        public DataTable getTable(string strWhere)
        {
            return dal.getTable(strWhere);
        }
    }
}
