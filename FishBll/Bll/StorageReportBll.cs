using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class StorageReportBll
    {
        private readonly Dao.StorageReportDao _dal = new Dao.StorageReportDao();

        public List<FishEntity.ProductEntity> Report(string strwhere , out decimal weight , out int package , out decimal homeweight , out int homepackage )
        {
            return _dal.Report(strwhere , out weight ,out package ,out homeweight ,out homepackage );
        }
    }
}
