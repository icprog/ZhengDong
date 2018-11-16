using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class FinishedProListBll
    {
        Dao.FinishedProListDao dal=null;
        public FinishedProListBll ( )
        {
            dal = new Dao . FinishedProListDao ( );
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
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public string getFishId()
        {
            return dal.getFishId();
        }
        /// <summary>
        /// 生成合同单号
        /// </summary>
        /// <returns></returns>
        public string getCkCode()
        {
            return dal.getCkCode();
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }


        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . FinishedProListEntity model )
        {
            return dal . Edit ( model );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . FinishedProListEntity model,string name )
        {
            return dal . Add ( model ,name );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public FishEntity . FinishedProListEntity getModel ( string code )
        {
            return dal . getModel ( code );
        }
        public DataTable getTableView(string code)
        {
            return dal.getTableView(code);
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
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere">strWhere</param>
        /// <returns></returns>
        public DataTable getTable(string strWhere)
        {
            return dal.getTable(strWhere);
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
        public bool Exists_fishId(string fishid) {
            return dal.Exists_fishId(fishid);
        }

        }
}
