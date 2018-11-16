using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class InquiryBll
    {
        private readonly Dao.InquiryDao _dao=new Dao.InquiryDao();
        public InquiryBll ( )
        {
        }

        /// <summary>
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public DataTable GetFishId ( )
        {
            return _dao . GetFishId ( );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( FishEntity . InquiryEntity _model )
        {
            return _dao . Add ( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity . InquiryEntity> GetModelList ( string strWhere )
        {
            DataSet ds = _dao . GetList ( strWhere );

            return GetDataTableToList ( ds . Tables [ 0 ] );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<FishEntity . InquiryEntity> GetDataTableToList ( DataTable dt )
        {
            List<FishEntity . InquiryEntity> _modelList = new List<FishEntity . InquiryEntity> ( );
            int rowcount = dt . Rows . Count;
            if ( rowcount > 0 )
            {
                FishEntity . InquiryEntity _model = null;
                for ( int i = 0 ; i < rowcount ; i++ )
                {
                    _model = _dao . GetRowToModel ( dt . Rows [ i ] );
                    if ( _model != null )
                        _modelList . Add ( _model );
                }
            }

            return _modelList;
        }

        /// <summary>
        /// 是否存在此鱼粉ID
        /// </summary>
        /// <param name="fishId"></param>
        /// <returns></returns>
        public bool Exists ( string fishId )
        {
            return _dao . Exists ( fishId );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( FishEntity . InquiryEntity _model )
        {
            return _dao . Update ( _model );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public bool Delete ( string ids )
        {
            return _dao . Delete ( ids );
        }
    }
}
