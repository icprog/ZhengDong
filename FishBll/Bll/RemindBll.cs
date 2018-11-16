using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class RemindBll
    {
        protected Dao.RemindDao dao = new Dao.RemindDao();
        public List<FishEntity.RemindEntity> GetRemind(string where)
        {
            return dao.GetRemind(where);
        }
    }
}
