using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class DisposeofcommentsBll
    {
        private readonly FishBll.Dao.DisposeofcommentsDao dal = new Dao.DisposeofcommentsDao();
        public List<FishEntity.DisposeofcommentsEntity> GetModelList(string where)
        {
            return dal.GetModelList(where);
        }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public int Add(FishEntity.DisposeofcommentsEntity model)
        {
            return dal.Add(model);
        }
        public bool Update(FishEntity.DisposeofcommentsEntity model)
        {
            return dal.Update(model);
        }
    }
}
