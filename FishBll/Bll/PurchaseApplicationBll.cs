using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
  public  class PurchaseApplicationBll
    {
        private readonly  Dao.PurchaseApplicationDao dal;
        public PurchaseApplicationBll ( )
        {
            dal = new Dao . PurchaseApplicationDao ( );
        }
        public FishEntity.PurcurementContractEntity getCGSQD(string codenum) {
            return dal.getCGSQD(codenum);
        }
        /// <summary>
        /// 得到申请单编号
        /// </summary>
        /// <returns></returns>
        public string getCodeNum ( )
        {
            return dal . getCodeNum ( );
        }

        /// <summary>
        /// 是否被引用
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsCodeNumContract ( int idx )
        {
            return dal . ExistsCodeNumContract ( idx );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx,string code )
        {
            return dal . Delete ( idx ,code );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( string code)
        {
            return dal . Exists (code);
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="FishId"></param>
        /// <returns></returns>
        public bool ExistsFishId(string FishId)
        {
            return dal.ExistsFishId(FishId);
        }
        /// <summary>
        /// 新怎数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( FishEntity . PurchaseApplicationEntity model )
        {
            return dal . Add ( model );
        }


        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Edit ( FishEntity . PurchaseApplicationEntity model )
        {
            return dal . Edit ( model );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . PurchaseApplicationEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
        }

        /// <summary>
        /// 获取鱼粉资料
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseFishInfo> getFishInfoList ( string codeNum )
        {
            return dal . getFishInfoList ( codeNum );
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
        /// 获取扣减资料
        /// </summary>
        /// <param name="codeNum"></param>
        /// <returns></returns>
        public List<FishEntity . PurchaseOtherInfo> getOtherInfoList ( string codeNum )
        {
            return dal . getOtherInfoList ( codeNum );
        }

        /// <summary>
        /// 获取编号
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
        public bool SaveFishInfo ( List<FishEntity . PurchaseFishInfo> listFishInfo )
        {
            return dal . SaveFishInfo ( listFishInfo );
        }

        /// <summary>
        /// 保存减价资料
        /// </summary>
        /// <param name="listOtherInfo"></param>
        /// <returns></returns>
        public bool SaveOtherInfo ( List<FishEntity . PurchaseOtherInfo> listOtherInfo )
        {
            return dal . SaveOtherInfo ( listOtherInfo );
        }


    }
}
