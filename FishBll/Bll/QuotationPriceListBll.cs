using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class QuotationPriceListBll
    {
        Dao.QuotationPriceListDao dal=null;
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere">name</param>
        /// <returns></returns>
        public DataTable getTable(string name)
        {
            return dal.getTable(name);
        }
        public QuotationPriceListBll ( )
        {
            dal = new Dao . QuotationPriceListDao ( );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            return dal . getCode ( );
        }
        public string getfishId() {
            return dal.getfishId();
        }
        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . QuotationPriceListEntity model )
        {
            return dal . Edit ( model );
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
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . QuotationPriceListEntity model ,string name)
        {
            return dal . Add ( model ,name );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . QuotationPriceListEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
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
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }

    }
}
