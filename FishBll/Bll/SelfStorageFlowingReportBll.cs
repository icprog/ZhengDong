using System;
using System.Collections.Generic;
using System.Text;

namespace FishBll.Bll
{
    /// <summary>
    /// 自营自制库存流水账
    /// </summary>
    public class SelfStorageFlowingReportBll
    {
        private readonly Dao.SelfStorageFlowingReportDao dal = new Dao.SelfStorageFlowingReportDao();

        public SelfStorageFlowingReportBll()
        {
        }
        /// <summary>
        /// 获得期初数据
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        protected List<FishEntity.SelfStorageFlowingReportVo> GetInventory(DateTime date)
        {
            return dal.GetInventory(date);
        }
        /// <summary>
        /// 获得期初某个时间点的明细
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endStart"></param>
        /// <returns></returns>
        protected List<FishEntity.SelfStorageFlowingReportVo> GetDetail(DateTime startDate, DateTime endDate)
        {
            string where = string.Format(" date >='{0}' and date<'{1}'" , startDate.ToString("yyyy-MM-01 00:00:00") , endDate.ToString("yyyy-MM-dd 00:00:00"));   
            List<FishEntity.SelfStorageFlowingReportVo> list = dal.Report(where);
            return list;
        }
        /// <summary>
        /// 合计 期初记录和流水记录
        /// </summary>
        /// <param name="list_qc"></param>
        /// <param name="list_st"></param>
        protected void Calc_QC(List<FishEntity.SelfStorageFlowingReportVo> list_qc, List<FishEntity.SelfStorageFlowingReportVo> list_st)
        {            
            foreach (FishEntity.SelfStorageFlowingReportVo item in list_st)
            {
                FishEntity.SelfStorageFlowingReportVo group = list_qc.Find((i) => { return i.productid == item.productid; });
                if (group == null)
                {
                    group = new FishEntity.SelfStorageFlowingReportVo();
                    group.productid = item.productid;
                    group.productcode = item.productcode;
                    group.productname = item.productname;
                    group.storagetype = "期初";
                    if (item.storagetype.Equals("入库"))
                    {
                        group.weight = item.weight;
                        group.package = item.package;
                    }
                    else
                    {
                        group.weight = -item.weight;
                        group.package = -item.package;
                    }
                    list_qc.Add(group);
                }
                else
                {
                    if (item.storagetype.Equals("入库"))
                    {
                        group.weight += item.weight;
                        group.package += item.package;
                    }
                    else
                    {
                        group.weight -= item.weight;
                        group.package -= item.package;   
                    }
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="where"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="weight"></param>
        /// <param name="package"></param>
        /// <returns></returns>
        public List<FishEntity.SelfStorageFlowingReportVo> Report(string where , DateTime startDate , DateTime endDate ,out decimal weight , out int package )
        {
            weight = 0;
            package = 0;

            string dateStr = string.Format(" date >='{0}' and date<='{1}'" , startDate.ToString("yyyy-MM-dd 00:00:00") , endDate.ToString("yyyy-MM-dd 23:59:59"));
             //获得时间段的流水记录
             List<FishEntity.SelfStorageFlowingReportVo> list = dal.Report(dateStr );
             //获得期初
             List<FishEntity.SelfStorageFlowingReportVo> list_QC = dal.GetInventory(startDate);
             //获得期初到某个时间点的流水记录
             List<FishEntity.SelfStorageFlowingReportVo> list_start = GetDetail(startDate, startDate);
             //合计期初到某个时间点的数据
             Calc_QC(list_QC, list_start);

             list.InsertRange(0, list_QC);

             List<FishEntity.SelfStorageFlowingReportVo> subTotalList = new List<FishEntity.SelfStorageFlowingReportVo>();
             List<FishEntity.SelfStorageFlowingReportVo> newList = new List<FishEntity.SelfStorageFlowingReportVo>();   
             foreach (FishEntity.SelfStorageFlowingReportVo item in list)
             {                                                                
                 FishEntity.SelfStorageFlowingReportVo group = subTotalList.Find ( (i)=>{return i.productid== item.productid; });
                 if( group == null )
                 {
                     group = new FishEntity.SelfStorageFlowingReportVo ();
                     group.productid = item.productid;
                     group.productcode = "小计";
                     group.productname = "";
                     group.statename = "";
                     if (item.storagetype.Equals("入库") || item.storagetype.Equals("期初"))
                     {
                         group.weight = item.weight;
                         group.package = item.package;
                         weight += item.weight;
                         package += item.package;
                     }
                     else
                     {
                         group.weight = -item.weight;
                         group.package = -item.package;
                         weight -= item.weight;
                         package -= item.package;
                     }

                     subTotalList.Add ( group );
                     newList.Add(group); 
                     //int groupIdx = newList.IndexOf ( group ); 
                     //newList.Insert(groupIdx, item); 
                 }
                 else
                 {
                     if (item.storagetype.Equals("出库"))
                     {
                         group.weight -= item.weight;
                         group.package -= item.package;
                         weight -= item.weight;
                         package -= item.package;
                     }
                     else if( item.storagetype.Equals("入库")|| item.storagetype.Equals("期初"))
                     {
                         group.weight += item.weight;
                         group.package += item.package;
                         weight += item.weight;
                         package += item.package;
                     }                                                        
                 }
               
                 //FishEntity.SelfStorageFlowingReportVo qc = list_QC.Find( (i)=>{return i.productid==item.productid; });
                 //if (qc != null)
                 //{
                 //    group.weight += qc.weight;
                 //    group.package += qc.package;
                 //}

                 int groupIdx = newList.IndexOf(group);
                 newList.Insert(groupIdx, item);
             }

             subTotalList.Clear();
             subTotalList = null;
             list.Clear();
             list = null;
             return newList;
        }

    }
}
