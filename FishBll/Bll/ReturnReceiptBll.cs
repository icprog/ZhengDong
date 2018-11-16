using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class ReturnReceiptBll
    {
        Dao.ReturnReceiptDao dal=null;
        public ReturnReceiptBll ( )
        {
            dal = new Dao . ReturnReceiptDao ( );
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <returns></returns>
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
        /// 更新一条数据
        /// </summary>
        public bool Update ( FishEntity . ReturnReceiptEntity model )
        {
            return dal . Update ( model );
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add ( FishEntity . ReturnReceiptEntity model )
        {
            return dal . Add ( model );
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public FishEntity . ReturnReceiptEntity GetModel ( string strWhere )
        {
            return dal . GetModel ( strWhere );
        }
        public FishEntity.SalesRequisitionEntity GetModelzy(string codeNum)
        {
            return dal.GetModelzy(codeNum);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeT ( )
        {
            return dal . getCodeT ( );
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
        /// 新增带入数据
        /// </summary>
        /// <param name="getname"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity getTHD(string getname)
        {
            return dal.getTHD(getname);
        }

        public FishEntity.OnepoundEntity getjingz(string Numbering) {
            return dal.getjingz(Numbering);
        }
    }
}
