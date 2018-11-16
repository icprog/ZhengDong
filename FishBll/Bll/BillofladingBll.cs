using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class BillofladingBll
    {
        private readonly FishBll.Dao.BillofladingDaoEx dal = new Dao.BillofladingDaoEx();
        public BillofladingBll() { }
        public int Add(FishEntity.BillofladingEntity model,string name)
        {
            return dal . Add ( model ,name );
        }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public bool ExistsUpdate(string code, string createman)
        {
            return dal.ExistsUpdate(code, createman);
        }
        public bool Update(FishEntity.BillofladingEntity model)
        {
            return dal.Update(model);
        }
        public List<FishEntity.BillofladingEntityVo> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
        public FishEntity.SalesRequisitionEntity getDHT(string getname)
        {
            return dal.getTHD(getname);
        }
    }
}
