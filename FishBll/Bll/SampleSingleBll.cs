using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class SampleSingleBll
    {
        private readonly FishBll.Dao.SampleSingleDao dal = new Dao.SampleSingleDao();
        public SampleSingleBll() { }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public int Add(FishEntity.SampleSingleEntity model)
        {
            return dal.Add(model);
        }
        public bool Update(FishEntity.SampleSingleEntity model)
        {
            return dal.Update(model);
        }
        public List<FishEntity.SampleSingleEntity> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
    }
}
