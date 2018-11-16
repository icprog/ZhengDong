using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
   public class PackingWeightListBll
    {
        private readonly Dao.PackingWeightLisDao dal = new Dao.PackingWeightLisDao();
        public PackingWeightListBll() { }
        public bool add(List<FishEntity.PackingWeightListEntity> modelList)
        {
            return dal.add(modelList);
        }
        public List<FishEntity.PackingWeightListEntity> getList(string jincangdan, string yufenid)
        {
            return dal.getList(jincangdan,yufenid);
        }
    }
}
