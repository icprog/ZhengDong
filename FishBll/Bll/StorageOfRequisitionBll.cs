using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class StorageOfRequisitionBll
    {
        Dao.StorageOfRequisitionDao dal=null;

        public StorageOfRequisitionBll ( )
        {
            dal = new Dao . StorageOfRequisitionDao ( );
        }

        /// <summary>
        /// 获得单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            return dal . getCode ( );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT ( )
        {
            return dal . getCodeT ( );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( FishEntity . StorageOfRequisitionEntity model ,string name)
        {
            return dal . Add ( model ,name );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . StorageOfRequisitionEntity model )
        {
            return dal . Edit ( model );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( string name ,string code )
        {
            return dal . Delete ( name , code );
        }

        /// <summary>
        /// 配料单是否领取
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists_isDel ( string code )
        {
            return dal . Exists_isDel ( code );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public FishEntity . StorageOfRequisitionEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
        }
        public DataTable getTable(string name)
        {
            return dal.getTable(name);
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
        public FishEntity.PriWarehouseEntity addRK(string name)
        {
            return dal.addRK(name);
        }
    }
}
