using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    public class ContractProductBll
    {
        protected Dao.ContractProductDao dal = new Dao.ContractProductDao();
        public List<FishEntity.ContractPorductEntity> GetProducts(int contractid, int detailid)
        {
            return dal.GetProducts(contractid, detailid);
        }

        public int DeleteBy(int contractid, int detailid, int productid)
        {
            return dal.DeleteBy(contractid, detailid, productid);
        }

        public int Add(int contractid, int detailid, int productid)
        {
            return dal.Add(contractid, detailid, productid);
        }

        public int Update(int contractid, int detailid, int productid, int id)
        {
            return dal.Update(contractid, detailid, productid, id);
        }

        public List<FishEntity.ContractPorductEntity> GetNotSendProducts( string where )
        {
            return dal.GetNotSendProducts( where );
        }
    }
}
