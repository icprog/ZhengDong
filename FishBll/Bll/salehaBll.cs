using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public  class salehaBll
    {
        private readonly FishBll.Dao.salehaDao dal = new FishBll.Dao.salehaDao();
        public bool Delete(int Saleid, int Haid)
        {
            return dal.Delete(Saleid, Haid);
        }
        public bool Add(FishEntity.salehaEntity model)
        {
            return dal.Add(model);
        }
    }
}
