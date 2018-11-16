using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
   public  class CustomerAnalysisReportBll
    {
       protected Dao.CustomerAnalysisReportDao _dal = new Dao.CustomerAnalysisReportDao();
       public List<FishEntity.CompanyEntity> Reports(string where)
       {
           return _dal.Reports(where);
       }
    }
}
