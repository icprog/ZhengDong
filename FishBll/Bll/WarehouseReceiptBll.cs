using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class WarehouseReceiptBll
    {
        Dao.WarehouseReceiptDao dal=null;
        public WarehouseReceiptBll ( )
        {
            dal = new Dao . WarehouseReceiptDao ( );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            return dal . getCode ( );
        }
        /// <summary>
        /// 进仓单数据表
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public List<FishEntity.WarehouseReceiptEntity> GetModelList(string strwhere)
        {
            return dal.GetModelList(strwhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add ( FishEntity . WarehouseReceiptEntity model ,string name )
        {
            return dal . Add ( model  ,name );
        }
        public int Add(string id, List<FishEntity.PicInfoAll> dicPic, string name)
        {
            return dal.Add(id ,dicPic, name);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update ( FishEntity . WarehouseReceiptEntity modelstring, string tableName )
        {
            return dal . Update (modelstring, tableName );
        }
        public int Update(string id, List<FishEntity.PicInfoAll> dicPic, string tableName)
        {
            return dal.Update(id, dicPic, tableName);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete ( int idx,string tableName,string code )
        {
            return dal . Delete ( idx ,tableName ,code );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists ( string code )
        {
            return dal . Exists ( code );  
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool ExistsCaigou(string code)
        {
            return dal.ExistsCaigou(code);
        }
        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT ( )
        {
            return dal . getCodeT ( );
        }
        public FishEntity.WarehouseReceiptEntity ADDModel(string codenum) {
            return dal.ADDmodel(codenum);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity . WarehouseReceiptEntity GetModel ( string strWhere )
        {
            return dal . GetModel ( strWhere );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public List<FishEntity . PicInfoAll> GetModel ( int id ,string tableName )
        {
            return dal . GetModel ( id ,tableName );
        }

        /// <summary>
        /// 入库申请单
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists_rksqd ( string code )
        {
            return dal . Exists_rksqd ( code );
        }
        public DataTable getTable(string strWhere)
        {
            return dal.getTable(strWhere);
        }
    }
}
