using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class PresaleRequisitionBll
    {
        private readonly Dao.PresaleRequisitionDao dal = new Dao.PresaleRequisitionDao();


        /// <summary>
        /// 获取合同号
        /// </summary>
        /// <returns></returns>
        public string codeNum ( )
        {
            return dal . codeNum ( );
        }

        public DataTable getCode()
        {
            return dal.getCode();
        }
        public DataTable getTable(string StrWhere)
        {
            return dal.getTable(StrWhere);
        }
        public DataTable getcodeNum()
        {
            return dal.getcodeNum();
        }
        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getDate ( )
        {
            return dal . getDate ( );
        }

        /// <summary>
        /// 获取单头数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity. PresaleRequisitionHeadEntity> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<FishEntity. PresaleRequisitionHeadEntity> DataTableToList(DataTable dt)
        {
            List<FishEntity. PresaleRequisitionHeadEntity> modelList = new List<FishEntity. PresaleRequisitionHeadEntity> ();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity. PresaleRequisitionHeadEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = Dao.PresaleRequisitionDao.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }
        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableOne(string code)
        {
            return dal.printTableOne(code);
        }

        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTwo(string code)
        {
            return dal.printTableTwo(code);
        }

        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTre(string code)
        {
            return dal.printTableTre(code);
        }

        /// <summary>
        /// 获取一表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity . PresaleRequisitionBodyEntity> GetTableOne ( int id )
        {
            return dal . GetTableOne ( id );
        }

        /// <summary>
        /// 获取二表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity . PresaleRequisitionBodyEntity> GetTableTwo ( int id )
        {
            return dal . GetTableTwo ( id );
        }


        /// <summary>
        /// 获取三表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity . PresaleRequisitionBodyEntity> GetTableTre ( int id )
        {
            return dal . GetTableTre ( id );
        }

        /// <summary>
        /// 获取四表的数据列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FishEntity . PresaleRequisitionBodyEntity> GetTableFor ( int id )
        {
            return dal . GetTableFor ( id );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( int id ,string code )
        {
            return dal . Delete ( id ,code );
        }


        /// <summary>
        /// 获取鱼粉信息
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<FishEntity . ProductEntity> getList ( string strWhere )
        {
            return dal . getList ( strWhere );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . PresaleRequisitionHeadEntity _model ,List<FishEntity . PresaleRequisitionBodyEntity> modelList )
        {
            return dal . Add ( _model ,modelList );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="modelList"></param>
        /// <returns></returns>
        public bool Edit ( FishEntity . PresaleRequisitionHeadEntity _model ,List<FishEntity . PresaleRequisitionBodyEntity> modelList )
        {
            return dal . Edit ( _model ,modelList );
        }


        /*生成预销售合同*/
        public bool Exists ( string codeNum )
        {
            return dal . Exists ( codeNum );
        }
        /// <summary>
        /// 获取单头数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public FishEntity . PresaleRequisitionHeadEntity GetHeadList ( string code )
        {
            return dal . GetHeadList ( code );
        }

        /// <summary>
        /// 获取单身数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<FishEntity . PresaleRequisitionBodyEntity> GetBodyList ( string code )
        {
            return dal . GetBodyList ( code );
        }

    }
}
