using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class AccountsReceivableBll
    {
        private readonly Dao.AccountsReceivableDao _dao=new Dao.AccountsReceivableDao();
        public AccountsReceivableBll ( )
        {
        }


        /// <summary>
        /// 编辑单头记录
        /// </summary>
        /// <param name="yfId"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool head_one ( string yfId ,string userName )
        {
            return _dao . head_one ( yfId ,userName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public List<FishEntity . AccountsReceivableHead> getList ( string strWhere )
        {
            return _dao . getList ( strWhere );
        }

        /// <summary>
        /// 编辑单身记录
        /// </summary>
        /// <param name="yfId"></param>
        /// <param name="yserName"></param>
        /// <returns></returns>
        public bool head_two ( string yfId ,string userName )
        {
            return _dao . head_two ( yfId ,userName );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool Add ( List<FishEntity . AccountsreceivableBody> modelList ,string userName )
        {
            return _dao . Add ( modelList ,userName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="yfId"></param>
        /// <returns></returns>
        public List<FishEntity . AccountsreceivableBody> getLists ( string yfId )
        {
            return _dao . getLists ( yfId );
        }

    }
}
