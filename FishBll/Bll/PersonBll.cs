using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace FishBll.Bll
{
    public  class PersonBll
    {
        private readonly Dao.PersonDao dal=new Dao.PersonDao();
        public PersonBll()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

        public bool Exists(string username)
        {
            return dal.Exists(username);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(FishEntity.PersonEntity  model)
		{
			 return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update( FishEntity.PersonEntity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int id)
		{
			
			return dal.Delete(id);
		}

        public bool FlagDelete(int id)
        {
            return dal.FlagDelete(id);
        }
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string idlist )
		{
			return dal.DeleteList(idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public FishEntity.PersonEntity GetModel(int id)
		{
			
			return dal.GetModel(id);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        public List<FishEntity.PersonEntity> id_name()
        {
            DataSet ds = dal.id_name();
            return DataTableToList_name(ds.Tables[0]);
        }
        public FishEntity.PersonEntity Getname(string name) {
            return dal.Getname(name);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.PersonEntity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        public List<FishEntity.PersonEntity> DataTableToList_name(DataTable dt)
        {
            List<FishEntity.PersonEntity> modelList = new List<FishEntity.PersonEntity>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                FishEntity.PersonEntity model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new FishEntity.PersonEntity();
                    if (dt.Rows[n]["id"].ToString() != "")
                    {
                        model.id = int.Parse(dt.Rows[n]["id"].ToString());
                    }
                    model.username = dt.Rows[n]["username"].ToString();

                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<FishEntity.PersonEntity> DataTableToList(DataTable dt)
		{
			List<FishEntity.PersonEntity> modelList = new List< FishEntity.PersonEntity >();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FishEntity.PersonEntity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new FishEntity.PersonEntity ();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					model.username=dt.Rows[n]["username"].ToString();
					model.password=dt.Rows[n]["password"].ToString();
					model.realname=dt.Rows[n]["realname"].ToString();
					model.ename=dt.Rows[n]["ename"].ToString();
					model.sex=dt.Rows[n]["sex"].ToString();
					model.email=dt.Rows[n]["email"].ToString();
					model.phone=dt.Rows[n]["phone"].ToString();
					model.telephone=dt.Rows[n]["telephone"].ToString();
					if(dt.Rows[n]["age"].ToString()!="")
					{
						model.age=int.Parse(dt.Rows[n]["age"].ToString());
					}
					model.department=dt.Rows[n]["department"].ToString();
                    if ( dt.Rows[0]["entrytime"] != null && dt.Rows[0]["entrytime"].ToString() != "")
                    {
                       model.entrytime= DateTime.Parse( dt.Rows[n]["entrytime"].ToString());
                    }
					model.roletype=dt.Rows[n]["roletype"].ToString();
					model.roledate=dt.Rows[n]["roledate"].ToString();
                    if (dt.Rows[0]["createtime"] != null && dt.Rows[0]["createtime"].ToString() != "")
                    {
                        model.createtime= DateTime .Parse( dt.Rows[n]["createtime"].ToString());
                    }
					model.createman=dt.Rows[n]["createman"].ToString();
                    if (dt.Rows[0]["modifytime"] != null && dt.Rows[0]["modifytime"].ToString() != "")
                    {
                        model.modifytime= DateTime.Parse ( dt.Rows[n]["modifytime"].ToString());
                    }
					model.modifyman=dt.Rows[n]["modifyman"].ToString();
					if(dt.Rows[n]["isdelete"].ToString()!="")
					{
						model.isdelete=int.Parse(dt.Rows[n]["isdelete"].ToString());
					}
                    if ( dt . Rows [ n ] [ "Selection" ] . ToString ( ) != "" )
                    {
                        if ( dt . Rows [ n ] [ "Selection" ] . ToString ( ) . Equals ( "0" ) )
                            model . Selection = false;
                        else
                            model . Selection = true;

                    }
                    modelList .Add(model);
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
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method

        public FishEntity.PersonEntity Login(string userName, string password)
        {
            FishEntity.PersonEntity entity = dal.Login(userName, password);
            return entity;
        }

        public bool ModifyPassword(int id, string pwd)
        {
            return dal.ModifyPassword(id, pwd);
        }

        public List<FishEntity.PersonRole> GetPersionRoles(int userid)
        {
            return dal.GetPersionRoles(userid);
        }
        public bool ExistsUser(int userid, string funname)
        {
            return dal.ExistsUser(userid, funname);
        }
    }
}
