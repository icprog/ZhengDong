using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class OutboundOrderBll
    {
        Dao.OutboundOrderDao dal=null;
        public OutboundOrderBll ( )
        {
            dal = new Dao . OutboundOrderDao ( );
        }
        public DataTable getTable(string strWhere)
        {
            return dal.getTable(strWhere);
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
        /// 删除一条数据
        /// </summary>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add ( FishEntity . OutboundOrderEntity model ,string name)
        {
            return dal . Add ( model ,name );
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
        /// 更新一条数据
        /// </summary>
        public bool Update ( FishEntity . OutboundOrderEntity model )
        {
            return dal . Update ( model );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity . OutboundOrderEntity GetModel ( string strWhere )
        {
            return dal . GetModel ( strWhere );
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
        /// 新增带入
        /// </summary>
        /// <param name="getname"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity getCKD(string getname)
        {
            return dal.getCKD(getname);
        }
    }
}
