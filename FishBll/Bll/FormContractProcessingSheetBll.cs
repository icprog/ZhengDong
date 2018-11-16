using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class FormContractProcessingSheetBll
    {
        private readonly FishBll.Dao.FormContractProcessingSheetDao dal = new Dao.FormContractProcessingSheetDao();
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public int Add(FishEntity.ContractProcessingSheetEntity model)
        {
            return dal.Add(model);
        }
        public bool Update(FishEntity.ContractProcessingSheetEntity model)
        {
            return dal.Update(model);
        }
        public List<FishEntity.ContractProcessingSheetEntity> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
    }
}
