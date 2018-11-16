using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class PurcurementContractBll
    {
        private readonly Dao.PurcurementContractDao dal=null;
        public PurcurementContractBll ( )
        {
            dal = new Dao . PurcurementContractDao ( );
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
        /// 生成合同单号
        /// </summary>
        /// <returns></returns>
        public string getCodeNum ( )
        {
            return dal . getCodeNum ( );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( FishEntity . PurcurementContractEntity _model )
        {
            return dal . Exists ( _model );
        }
        public bool Exists(string codenum)
        {
            return dal.Exists(codenum);
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="dicPic"></param>
        /// <returns></returns>
        public int Save ( FishEntity . PurcurementContractEntity _model ,Dictionary<int ,FishEntity . PicInfoAll> dicPic )
        {
            return dal . Save ( _model ,dicPic );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="dicPic"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public int Edit ( FishEntity . PurcurementContractEntity _model ,Dictionary<int ,FishEntity . PicInfoAll> dicPic ,string tableName )
        {
            return dal . Edit ( _model ,dicPic ,tableName );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete ( int id ,string tableName)
        {
            return dal . Delete ( id ,tableName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . PurcurementContractEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
        }

        /// <summary>
        /// 获取图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Dictionary<int ,FishEntity . PicInfoAll> getImages ( int id ,string tableName)
        {
            return dal . getImages ( id ,tableName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeNumData ( )
        {
            return dal . getCodeNumData ( );
        }

        /// <summary>
        /// 保存鱼粉资料
        /// </summary>
        /// <param name="listFishInfo"></param>
        /// <returns></returns>
        public bool SaveFishInfo ( List<FishEntity . PurchaseContractFishInfo> listFishInfo )
        {
            return dal . SaveFishInfo ( listFishInfo );
        }


        /// <summary>
        /// 获取鱼粉资料
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseContractFishInfo> getFishInfoList ( string codeNum )
        {
            return dal . getFishInfoList ( codeNum );
        }


    }
}
