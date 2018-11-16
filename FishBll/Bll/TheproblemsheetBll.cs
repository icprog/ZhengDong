using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class TheproblemsheetBll
    {
        private readonly FishBll.Dao.TheproblemsheetDaoEx dal = new Dao.TheproblemsheetDaoEx();
        public List<FishEntity.TheproblemsheetEntityVo> GetModelListVo(string where)
        {
            return dal.GetModelListVo(where);
        }
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public bool ExistsUpdate(string code,string createman) {
            return dal.ExistsUpdate(code, createman);
        }
        public int Add(FishEntity.TheproblemsheetEntity model)
        {
            return dal.Add(model);
        }
        public int Add ( FishEntity . TheproblemsheetEntity model,string name )
        {
            return dal . Add ( model ,name );
        }
        public bool Update(FishEntity.TheproblemsheetEntity model,string name)
        {
            return dal.Update(model,name);
        }
    }
}
