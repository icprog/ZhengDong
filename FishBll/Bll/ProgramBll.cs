using System;
using System . Collections . Generic;
using System . Text;

namespace FishBll . Bll
{
    public class ProgramBll
    {
        private readonly Dao.ProgramDao dal=new Dao.ProgramDao();

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . ProgramEntity> getList ( )
        {
            return dal . getList ( );
        }


        /// <summary>
        /// 删除全部记录
        /// </summary>
        /// <returns></returns>
        public bool Delete ( )
        {
            return dal . Delete ( );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool add ( List<FishEntity . ProgramEntity> modelList ,string userName )
        {
            return dal . add ( modelList ,userName );
        }


    }
}
