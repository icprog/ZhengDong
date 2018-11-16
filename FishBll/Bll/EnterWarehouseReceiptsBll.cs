using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class EnterWarehouseReceiptsBll
    {
        private readonly FishBll.Dao.EnterWarehouseReceiptsDao dal = new Dao.EnterWarehouseReceiptsDao();
        public EnterWarehouseReceiptsBll() { }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public int Add(FishEntity.EnterWarehouseReceipts model)
        {
            return dal.Add(model);
        }
        public bool Update(FishEntity.EnterWarehouseReceipts model)
        {
            return dal.Update(model);
        }
        public List<FishEntity.EnterWarehouseReceipts> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
    }
}
