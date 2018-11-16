using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace FishBll.Bll
{
    public class SaleBll
    {
        private readonly Dao.SaleDaoEx dal = new Dao.SaleDaoEx();
        public SaleBll() { }
        public List<FishEntity.SaleEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        public int Add(FishEntity.SaleEntity model)
        {
            return dal.Add(model);
        }
        public bool Update(FishEntity.SaleEntity model)
        {
            return dal.Update(model);
        }
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        public List<FishEntity.SaleEntity> DataTableToList(DataTable dt)
        {
            List<FishEntity.SaleEntity> modelList = new List<FishEntity.SaleEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.SaleEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        //public bool UpdateLatestSale(int productid, decimal dollors, decimal rmb, string companycode,
        //   string company, string linkmancode, string linkman, string quotedatestr, decimal weight, int quantity)
        //{
        //    return dal.UpdateLatestSale(productid, dollors, rmb, companycode, company, linkmancode, linkman, quotedatestr, weight, quantity);
        //}
        public bool UpdateLatestSale(int productid, string date, decimal rmb, decimal txtshenyu, decimal weight)
        {
            return dal.UpdateLatestSale(productid, date, rmb, txtshenyu, weight);
        }
    }
}
