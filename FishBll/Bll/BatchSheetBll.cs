using System;
using System . Collections . Generic;
using System . Data;
using System . Text;

namespace FishBll . Bll
{
    public class BatchSheetBll
    {
        Dao.BatchSheetDao dal=null;

        public BatchSheetBll ( )
        {
            dal = new Dao . BatchSheetDao ( );
        }
        public DateTime getDate()
        {
            return dal.getDate();
        }        /// <summary>
                 /// 获取合同单号
                 /// </summary>
                 /// <returns></returns>
        public string code()
        {
            return dal.code();
        }
        public string Numbering()
        {
            return dal.Numbering();
        }
        public string fishid()
        {
            return dal.fishid();
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
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            return dal . getCode ( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }

        /// <summary>
        /// 成品出库单是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists_isDel ( string code )
        {
            return dal . Exists_isDel ( code );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="_modelsList"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . BatchSheetEntity _model ,List<FishEntity . BatchSheetsEntity> _modelsList,string name )
        {
            return dal . Add ( _model ,_modelsList ,name );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="_modelsList"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . BatchSheetEntity _model ,List<FishEntity . BatchSheetsEntity> _modelsList )
        {
            return dal . Edit ( _model ,_modelsList );
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
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeD ( )
        {
            return dal . getCodeD ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . BatchSheetEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity . BatchSheetsEntity> modelList ( string code )
        {
            return dal . modelList ( code );
        }

        }
}
