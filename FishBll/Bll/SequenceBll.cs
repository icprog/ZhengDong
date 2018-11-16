using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class SequenceUtil
    {
        static object lockObject = new object();

        public static string GetCustomerSequence()//
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetCustomerSequence(FishEntity.Constant.CustomerSequence);
                return code;
            }
        }
        public static string SGSIndicators()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.SGSIndicators(FishEntity.Constant.SGSIndicators);
                return code;
            }
        }
        public static string GetProductSituation()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetProductSituation(FishEntity.Constant.ProductSituation);
                return code;
            }
        }
        public static string GetSalesSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetSalesSequence(FishEntity.Constant.SalesSequence);
                return code;
            }
        }

        public static string GerLadingNumber()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GerLadingNumber(FishEntity.Constant.LadingNumber);
                return code;
            }
        }
        public static string GerShippingRecords()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GerShippingRecords(FishEntity.Constant.ShippingRecords);
                return code;
            }
        }
        public static string GetPurchaseRequisitionSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetPurchaseRequisitionSequence(FishEntity.Constant.PurchaseRequisition);
                return code;
            }
        }
        //Theproblemsheet
        public static string GetDisposeofcomments()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GerDisposeofcomments(FishEntity.Constant.Disposeofcomments);
                return code;
            }
        }
        public static string GetTheproblemsheet()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetTheproblemsheet(FishEntity.Constant.Theproblemsheet);
                return code;
            }
        }
        public static string GetBillofladingnumber()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetBillofladingnumber(FishEntity.Constant.Billofladingnumber);
                return code;
            }
        }
        public static string GetCompnaySequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetCompanySequence(FishEntity.Constant.CompanySequence);
                return code;
            }
        }
        public static string GetSampleSingleSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetSampleSingleSequence(FishEntity.Constant.SampleSingle);
                return code;
            }
        }
        public static string GetCargoFeedbackSheetSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetCargoFeedbackSheetSequence(FishEntity.Constant.CargoFeedbackSheet);
                return code;
            }
        }
        public static string GetContractProcessingSheetquence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetContractProcessingSheetSequence(FishEntity.Constant.ContractProcessingSheet);
                return code;
            }
        }


        public static string GetFishSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetFishSequence(FishEntity.Constant.FishSequence);
                return code;
            }
        }
        public static string GetingredientsSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetingredientsSequence(FishEntity.Constant.FishSequence);
                return code;
            }
        }

        public static string GetCallRecordSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetCallRecordSequence(FishEntity.Constant.CallRecordSequence);
                return code;
            }
        }

        public static string GetStorageBillSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetStorageBillSequence(FishEntity.Constant.StorageBillSequence);
                return code;
            }
        }

        public static string GetHomemadeStorageSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetHomemadeStorageSequence(FishEntity.Constant.HomemadeStorageSequence);
                return code;
            }
        }

        public static string GetFoodOutSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetFoodOutSequence(FishEntity.Constant.FoodOutSequence);
                return code;
            }
        }

        public static string GetEnterWarehouseReceipts()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetEnterWarehouseReceipts(FishEntity.Constant.LoadingBillSequence);
                return code;
            }
        }
        public static string GetLoadingBillSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetLoadingBillSequence(FishEntity.Constant.LoadingBillSequence);
                return code;
            }
        }

        public static string GetCheckSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetCheckSequence(FishEntity.Constant.CheckSequence);
                return code;
            }
        }

        public static string GetContractSequence()
        {
            lock (lockObject)
            {
                SequenceBll bll = new SequenceBll();
                string code = bll.GetContractSequence(FishEntity.Constant.ContractSequence);
                return code;
            }
        }
    }


    public class SequenceBll
    {
        private readonly Dao.SequenceDao dal = new Dao.SequenceDao();
        public SequenceBll()
        { }

        //private static  SequenceBll _single = new SequenceBll();

        //public static SequenceBll Single
        //{
        //    get
        //    {
        //        return _single;
        //    }
        //}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(FishEntity.SequenceEntity model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(FishEntity.SequenceEntity model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {

            return dal.Delete(id);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity.SequenceEntity GetModel(int id)
        {

            return dal.GetModel(id);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.SequenceEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.SequenceEntity> DataTableToList(DataTable dt)
        {
            List<FishEntity.SequenceEntity> modelList = new List<FishEntity.SequenceEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.SequenceEntity model;
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

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        public string GetCustomerSequence(string keyName)//SGSIndicators
        {
            return dal.GetSequence(keyName, "p_getcustomersequence");
        }
        public string SGSIndicators(string keyName)
        {
            return dal.GetSequence(keyName, "p_getcustomersequence");
        }
        public string GerLadingNumber(string keyName)
        {
            return dal.GetSequence(keyName, "p_getcustomersequence");
        }
        public string GerShippingRecords(string keyName)
        {
            return dal.GetSequence(keyName, "p_getShippingRecordsquence");
        }
        public string GerDisposeofcomments(string keyName)
        {
            return dal.GetSequence(keyName, "p_getDisposeofcomments");
        }

        public string GetSalesSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getcustomersequence");
        }
        public string GetProductSituation(string KeyName)
        {
            return dal.GetSequence(KeyName, "p_getcustomersequence"); //ProductSituation
        }
        public string GetBillofladingnumber(string keyName)
        {
            return dal.GetSequence(keyName, "p_getcustomersequence");
        }
        public string GetTheproblemsheet(string keyName)//
        {
            return dal.GetSequence(keyName, "p_getTheproblemsheetquence");
        }
        public string GetCompanySequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getcompanysequence");
        }
        public string GetSampleSingleSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getSampleSinglequence");
        }
        public string GetCargoFeedbackSheetSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getSampleSinglequence");
        }
        public string GetContractProcessingSheetSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getSampleSinglequence");
        }

        public string GetFishSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getfishsequence");
        }
        public string GetingredientsSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getingredientsquence");
        }


        public string GetCallRecordSequence(string keyName)
        {
            return dal.GetSequence(keyName, "p_getcallrecordsequence");
        }

        public string GetStorageBillSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_getstoragebillsequence");
        }

        public string GetHomemadeStorageSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_gethomemadestoragesequence");
        }
        public string GetPurchaseRequisitionSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_getPurchaseRequisitionquence");
        }
        public string GetFoodOutSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_getfoodoutsequence");
        }

        public string GetLoadingBillSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_getloadingbillsequence");
        }
        public string GetEnterWarehouseReceipts(string keyname)
        {
            return dal.GetSequence(keyname, "p_getloadingbillsequence");
        }


        public string GetCheckSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_getchecksequence");
        }
        public string GetContractSequence(string keyname)
        {
            return dal.GetSequence(keyname, "p_getcontractsequence");
        }
    }
}