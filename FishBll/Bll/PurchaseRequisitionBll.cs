using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class PurchaseRequisitionBll
    {
        FishBll.Dao.PurchaseRequisitionDao dal = new Dao.PurchaseRequisitionDao();
        public PurchaseRequisitionBll() { }
        public List<FishEntity.PurchaseRequisitionEntity> GetList(string strwhere)
        {
            return dal.GetList(strwhere);
        }
        public string ContractNo()
        {
            return dal.ContractNo();
        }
        public DateTime getDate()
        {
            return dal.getDate();
        }
        public string code()
        {
            return dal.code();
        }
        public List<FishEntity.PurchaseRequisitionEntity> getMax()
        {
            return dal.getMax();
        }
        public bool Exists(string code) {
            return dal.Exists(code);
        }
        public int Add(FishEntity.PurchaseRequisitionEntity model) {
            return dal.Add(model);
        }
        public bool Update(FishEntity.PurchaseRequisitionEntity model) {
            return dal.Update(model);
        }
    }
}
