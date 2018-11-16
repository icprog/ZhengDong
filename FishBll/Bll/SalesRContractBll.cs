using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class SalesRContractBll
    {
        private readonly FishBll.Dao.SalesRContractDao Dao = new FishBll.Dao.SalesRContractDao();
        public SalesRContractBll() { }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Exists(string code) {
            return Dao.Exists(code);
        }
        /// <summary>
        /// 编号是否存在
        /// </summary>
        public bool ExistsNumbering(string Numbering)
        {
            return Dao.ExistsNumbering(Numbering);
        }
        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="modeList"></param>
        /// <returns></returns>
        public int Add(FishEntity.SalesRContractEntity _model, List<FishEntity.productsituationEntity> modeList) {
            return Dao.Add(_model,modeList);
        }
        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modeList"></param>
        /// <returns></returns>
        public bool Update(FishEntity.SalesRContractEntity model, List<FishEntity.productsituationEntity> modeList)
        {
            return Dao.Update(model, modeList);
        }
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="_where"></param>
        /// <returns></returns>
        public FishEntity.SalesRContractEntity GetList(string _where)
        {
            return Dao.GetList(_where);
        }
        public List<FishEntity.productsituationEntity>modellist(string Numbering) {
            return Dao.modellist(Numbering);
        }
        /// <summary>
        /// 新增带入
        /// </summary>
        /// <param name="Numbering"></param>
        /// <returns></returns>
        public DataTable getxxsqd(string Numbering) {
            return Dao.getxxsqd(Numbering);
        }
        public bool ExistCode(string Numbering)
        {
            return Dao.ExistCode(Numbering);
        }
    }
}
