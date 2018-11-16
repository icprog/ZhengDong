using System;
using System . Collections . Generic;
using System . Text;

namespace FishBll . Bll
{
    public class CustomStandardTableBll
    {
        Dao.CustomStandardTableDao dal=null;
        public CustomStandardTableBll ( )
        {
            dal = new Dao . CustomStandardTableDao ( );
        }

        /// <summary>
        /// 获取数据列表
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
        public string getFishId ( )
        {
            return dal . getFishId ( );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }


        /// <summary>
        /// 是否存在鱼粉ID
        /// </summary>
        /// <param name="fishId"></param>
        /// <returns></returns>
        public bool Exists_idFishId ( string fishId )
        {
            return dal . Exists_idFishId ( fishId );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . CustomStandardTableEntity model )
        {
            return dal . Edit ( model );
        }

        /// <summary>
        /// 保存一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Save ( FishEntity . CustomStandardTableEntity model ,string name)
        {
            return dal . Save ( model ,name );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . CustomStandardTableEntity> getModel ( )
        {
            return dal . getModel ( );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <returns></returns>
        public FishEntity . CustomStandardTableEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
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

    }
}
