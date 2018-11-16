using System;
using System . Collections . Generic;
using System . Text;

namespace FishBll . Bll
{
    public class SetReviewBll
    {
        private readonly Dao.SetReviewDao dal=new Dao.SetReviewDao();
        
        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <returns></returns>
        public List<FishEntity . SetreviewEntity> getList ( )
        {
            return dal . getList ( );
        }
        public FishEntity.ReviewEntity UserName(string Numbering)
        {
            return dal.UserName(Numbering);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        public bool Delete ( )
        {
            return dal . Delete ( );
        }

        /// <summary>
        /// 保存记录
        /// </summary>
        /// <param name="modelList"></param>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool add ( List<FishEntity . SetreviewEntity> modelList ,string userName )
        {
            return dal . add ( modelList ,userName );
        }

        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Review ( List<FishEntity . ReviewEntity> model )
        {
            return dal . Review ( model );
        }

        /// <summary>
        /// 获取提醒消息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public List<FishEntity . ReviewEntity> modelList (string userName, string strWhere )
        {
            return dal . modelList (userName, strWhere );
        }


        /// <summary>
        /// 是否审核
        /// </summary>
        /// <param name="code"></param>
        /// <param name="programId"></param>
        /// <returns></returns>
        public bool getStr ( string code ,string programId ,string userName)
        {
            return dal . getStr ( code ,programId,userName);
        }
        public bool getStr1(string code, string programId, string userName, string SingleNumber)
        {
            return dal.getStr1(code, programId, userName, SingleNumber);
        }
        public bool getStr1(string code, string programId,string SingleNumber)
        {
            return dal.getStr1(code, programId, SingleNumber);
        }
        public bool getStr(string code, string programId)
        {
            return dal.getStr(code, programId);
        }

        /// <summary>
        /// 撤审
        /// </summary>
        /// <param name="code"></param>
        /// <param name="programId"></param>
        /// <returns></returns>

        public bool examine_1(string Numbering, string programId, string SingleNumber)
        {
            return dal.examine_1(Numbering, programId, SingleNumber);
        }
        public bool examine(string Numbering, string programId)
        {
            return dal.examine(Numbering, programId);
        }
        /// <summary>
        /// 是否有审核权限
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="programId"></param>
        /// <returns></returns>
        public bool examinePow ( string userName ,string programId )
        {
            return dal . examinePow ( userName ,programId );
        }

    }
}
