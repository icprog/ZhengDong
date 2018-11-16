using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class TotalDataSheetbll
    {
        private readonly Dao.TotalDataSheetDao dal = new Dao.TotalDataSheetDao();
        public DataTable getTable(string strWhere)
        {
            return dal.getTable(strWhere);
        }
    }
}
