using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public class CompanyBll
    {
        private readonly Dao.CompanyDaoEx dal = new Dao.CompanyDaoEx();
        public CompanyBll()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

        public bool Exists(String code)
        {
            return dal.Exists(code);
        }

        public bool ExistsByFullName(String fullName)
        {
            return dal.ExistsByFullName(fullName);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(FishEntity.CompanyEntity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(FishEntity.CompanyEntity model)
		{
			return dal.Update(model);
		}

        public bool UpdateLinkMan(int companyid, string linkmancode, string linkman)
        {
            return dal.UpdateLinkMan(companyid, linkmancode, linkman);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList( idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.CompanyEntity GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

        public FishEntity.CompanyEntity GetModelByCode(string code)
        {
            return dal.GetModelByCode(code);
        }
	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.CompanyEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<FishEntity.CompanyEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.CompanyEntity> modelList = new List<FishEntity.CompanyEntity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.CompanyEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = Dao.CompanyDao.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

        public bool UpdateCompnayLinkDate(string companyCode,  string weekestimate , string monthestimate , DateTime linkDate , string  buyDate , DateTime nextDate)
        {
            return dal.UpdateCompnayLinkDate(companyCode, weekestimate , monthestimate , linkDate , buyDate, nextDate);
        }

		#endregion  ExtensionMethod
    }
}
