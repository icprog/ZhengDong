using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{    
    public class CargoFeedbackSheetBll
    {
        private readonly FishBll.Dao.CargoFeedbackSheetDao dal = new Dao.CargoFeedbackSheetDao();
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public bool ExistsUpdate(string code, string createman)
        {
            return dal.ExistsUpdate(code, createman);
        }
        public int Add(FishEntity.CargoFeedbackSheetEntity model)
        {
            return dal.Add(model);
        }
        public int Add ( FishEntity . CargoFeedbackSheetEntity model ,string name)
        {
            return dal . Add ( model ,name );
        }
        public bool Update(FishEntity.CargoFeedbackSheetEntity model,string name)
        {
            return dal.Update(model,name);
        }
        public List<FishEntity.CargoFeedbackSheetEntity> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
    }
}
