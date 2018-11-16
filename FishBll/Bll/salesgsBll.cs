using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class salesgsBll
    {
        private readonly FishBll.Dao.salesgsDao dal = new FishBll.Dao.salesgsDao();
        public bool Delete(int Saleid, int SGSid)
        {
            return dal.Delete(Saleid, SGSid);
        }
        public bool Add(FishEntity.t_salesgs model)
        {
            return dal.Add(model);
        }
    }
}
