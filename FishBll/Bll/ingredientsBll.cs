using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class ingredientsBll
    {
        private readonly Dao.ingredientsDao dal = new Dao.ingredientsDao();
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }
        public int Add(FishEntity.ingredientsEntity model)
        {
            return dal.Add(model);
        }
        public List<FishEntity.ingredientsEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        public List<FishEntity.ingredientsEntity> DataTableToList(DataTable dt)
        {
            List<FishEntity.ingredientsEntity> modelList = new List<FishEntity.ingredientsEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.ingredientsEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel1(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        public int Add_detail(FishEntity.ingredientsdetailEntity model)
        {
            return dal.Add_detail(model);
        }
        public List<FishEntity.ingredientsdetailEntity> GetDetailOfBill(int billId,string tcode)
        {
            return dal.GetDetailOfBill(billId, tcode);
        }
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }
        public bool Update_detail(FishEntity.ingredientsdetailEntity model)
        {
            return dal.Update_detail(model);
        }
        public bool Update(FishEntity.ingredientsEntity model)
        {
            return dal.Update(model);
        }
    }
}
