using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    
    public class WarnBll
    {
        readonly private Dao.WarnDao dal=null;
        public WarnBll ( )
        {
            dal = new Dao . WarnDao ( );
        }

        /// <summary>
        /// 获取职位角色信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePosition ( string proName )
        {
            return dal . getTablePosition ( proName );
        }

        /// <summary>
        /// 根据职位获取人员信息
        /// </summary>
        /// <param name="realname"></param>
        /// <returns></returns>
        public DataTable getTableUser ( string realname )
        {
            return dal . getTableUser ( realname );
        }

        /// <summary>
        /// 根据人员信息获取程序名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getTablePro ( string id )
        {
            return dal . getTablePro ( id );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( FishEntity . WarnEntity model )
        {
            return dal . Exists ( model );
        }


        public bool Exists_Edit ( FishEntity . WarnEntity model )
        {
            return dal . Exists_Edit ( model );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Save ( FishEntity . WarnEntity model )
        {
            return dal . Save ( model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . WarnEntity model )
        {
            return dal . Edit ( model );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id )
        {
            return dal . Delete ( id );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . WarnEntity> getList ( )
        {
            return dal . getList ( );
        }

        /// <summary>
        /// 获取送审单据数量
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public DataTable getTable ( int id )
        {
            return dal . getTable ( id );
        }

        //把得到的提醒事项写入表中
        public DataTable getWarnInfo ( int id ,Dictionary<string ,string> proManager )
        {
            return dal . getWarnInfo ( id ,proManager );
        }

    }
}
