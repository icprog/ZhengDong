using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class SalesAssessmentBll
    {
        private readonly FishBll.Dao.SalesAssessmentDao dal = new Dao.SalesAssessmentDao();
        public SalesAssessmentBll() { }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="Where"></param>
        /// <returns></returns>
        public DataTable getTable(string Where)
        {
            return dal.getTable(Where);
        }
    }
}
