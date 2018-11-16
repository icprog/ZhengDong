using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class OnepoundBll
    {
        private readonly FishBll.Dao.OnepoundDaoEx dal = new Dao.OnepoundDaoEx();
        public OnepoundBll() { }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public bool image_Exists(string str) {

            return dal.image_Exists(str);
        }
        public bool ExistsUpdate(string code, string createman)
        {
           return dal.ExistsUpdate(code, createman);
        }
        public int Add(FishEntity.OnepoundEntity model,string name)
        {
            return dal . Add ( model ,name );
        }
        public bool Update(FishEntity.OnepoundEntity model)
        {
            return dal.Update(model);
        }
        public List<FishEntity.OnepoundEntityVo> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
        public FishEntity.SalesRequisitionEntity getBT(string getname) {
            return dal.getBT(getname);
        }
        public FishEntity.SalesRequisitionEntity getCKD(string getname)
        {
            return dal.getCKD(getname);
        }
    }
}
