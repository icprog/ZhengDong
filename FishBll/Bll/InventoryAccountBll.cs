using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class InventoryAccountBll
    {
            private readonly Dao.InventoryAccountDao dal = new Dao.InventoryAccountDao();
            public InventoryAccountBll()
            { }
            
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
            public bool Add(FishEntity.InventoryAccountEntity model)
            {
                return dal.Add(model);
            }

            /// <summary>
            /// 更新一条数据
            /// </summary>
            public bool Update(FishEntity.InventoryAccountEntity model)
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
            public FishEntity.InventoryAccountEntity GetModel(int id)
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
            public List<FishEntity.InventoryAccountEntity> GetModelList(string strWhere)
            {
                DataSet ds = dal.GetList(strWhere);
                return DataTableToList(ds.Tables[0]);
            }
            /// <summary>
            /// 获得数据列表
            /// </summary>
            public List<FishEntity.InventoryAccountEntity> DataTableToList(DataTable dt)
            {
                List<FishEntity.InventoryAccountEntity> modelList = new List<FishEntity.InventoryAccountEntity>();
                int rowsCount = dt.Rows.Count;
                if (rowsCount > 0)
                {
                    FishEntity.InventoryAccountEntity model;
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
            /// <summary>
            /// 分页获取数据列表
            /// </summary>
            //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
            //{
            //return dal.GetList(PageSize,PageIndex,strWhere);
            //}

  
            #region  ExtensionMethod

            #endregion  ExtensionMethod
        }

    }
