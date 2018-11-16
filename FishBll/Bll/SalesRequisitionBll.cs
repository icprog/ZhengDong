using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace FishBll.Bll
{
    public class SalerequisitionBll
    {
        private readonly Dao. SalerequisitionDao dal=new Dao.SalerequisitionDao();
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code) {
            return dal.Exists(code);
        }
        /// <summary>
        /// 编号是否存在
        /// </summary>
        public bool ExistsNumbering(string Numbering)
        {
            return dal.ExistsNumbering(Numbering);
        }
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public FishEntity.SalesRequisitionEntity Getname(string Numbering)
        {
            return dal.Getname(Numbering);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public FishEntity . SalesRequisitionEntity GetList ( string strWhere )
        {
            return dal . GetList ( strWhere );
        }
        public FishEntity.SalesRequisitionEntity createmanGet(string code)
        {
            return dal.createmanGet(code);
        }
        //createmanGet


        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime getDate ( )
        {
            return dal . getDate ( );
        }
        /// <summary>
        /// 获取合同单号
        /// </summary>
        /// <returns></returns>
        public string code ( )
        {
            return dal . code ( );
        }
        public string Numbering()
        {
            return dal.Numbering();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code,string Numbering)
        {
            return dal . Delete ( code, Numbering);
        }

        /// <summary>
        /// 新增一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( FishEntity . SalesRequisitionEntity model ,List<FishEntity . SalesRequisitionBodyEntity> modeList )
        {
            return dal . Add ( model ,modeList );
        }
        public bool Exists_code(string code)
        {
            return dal.Exists_code(code);
        }
        public bool ExistsUpdateOrDelete(string Numbering, string createman)
        {
            return dal.ExistsUpdateOrDelete(Numbering, createman);
        }
        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modeList"></param>
        /// <returns></returns>
        public bool Update ( FishEntity .SalesRequisitionEntity model ,List<FishEntity . SalesRequisitionBodyEntity> modeList )
        {
            return dal . Update ( model ,modeList );
        }

        /// <summary>
        /// 是否存在此预售合同
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public bool Exist ( string Numbering)
        {
            return dal . Exist (Numbering);
        }
        public bool ExistCode(string Numbering)
        {
            return dal.ExistCode(Numbering);
        }

        /// <summary>
        /// 获取鱼粉ID
        /// </summary>
        /// <returns></returns>
        public DataTable getCode ( )
        {
            return dal . getCode ( );
        }

        /// <summary>
        /// 获取采购合同编号
        /// </summary>
        /// <returns></returns>
        public DataTable getCodeNum ( )
        {
            return dal . getCodeNum ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTable ( string strWhere )
        {
            return dal . getTable ( strWhere );
        }
        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableOne(string code)
        {
            return dal.printTableOne(code);
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTwo(string code)
        {
            return dal.printTableTwo(code);
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable printTableTre(string code)
        {
            return dal.printTableTre(code);
        }

        /// <summary>
        /// 获取剩余预付款
        /// </summary>
        /// <param name="codeNumContract"></param>
        /// <returns></returns>
        public decimal getMoneyYFK ( string codeNumContract )
        {
            return dal . getMoneyYFK ( codeNumContract );
        }

    }
}
