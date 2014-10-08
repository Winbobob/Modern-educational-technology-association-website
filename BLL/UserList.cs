using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// UserList
	/// </summary>
	public partial class UserList
	{
		private readonly dbamet.DAL.UserList dal=new dbamet.DAL.UserList();
		public UserList()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string customId)
		{
			return dal.Exists(customId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.UserList model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.UserList model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string customId)
		{
			
			return dal.Delete(customId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string customIdlist )
		{
			return dal.DeleteList(customIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public dbamet.Model.UserList GetModel(string customId)
		{
			
			return dal.GetModel(customId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.UserList GetModelByCache(string customId)
		{
			
			string CacheKey = "UserListModel-" + customId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(customId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (dbamet.Model.UserList)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.UserList> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.UserList> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.UserList> modelList = new List<dbamet.Model.UserList>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.UserList model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.UserList();
					if(dt.Rows[n]["customId"]!=null && dt.Rows[n]["customId"].ToString()!="")
					{
					model.customId=dt.Rows[n]["customId"].ToString();
					}
					if(dt.Rows[n]["customName"]!=null && dt.Rows[n]["customName"].ToString()!="")
					{
					model.customName=dt.Rows[n]["customName"].ToString();
					}
					if(dt.Rows[n]["birth"]!=null && dt.Rows[n]["birth"].ToString()!="")
					{
						model.birth=DateTime.Parse(dt.Rows[n]["birth"].ToString());
					}
					if(dt.Rows[n]["duty"]!=null && dt.Rows[n]["duty"].ToString()!="")
					{
					model.duty=dt.Rows[n]["duty"].ToString();
					}
					if(dt.Rows[n]["className"]!=null && dt.Rows[n]["className"].ToString()!="")
					{
					model.className=dt.Rows[n]["className"].ToString();
					}
					if(dt.Rows[n]["sex"]!=null && dt.Rows[n]["sex"].ToString()!="")
					{
					model.sex=dt.Rows[n]["sex"].ToString();
					}
					if(dt.Rows[n]["interest"]!=null && dt.Rows[n]["interest"].ToString()!="")
					{
					model.interest=dt.Rows[n]["interest"].ToString();
					}
					if(dt.Rows[n]["tel"]!=null && dt.Rows[n]["tel"].ToString()!="")
					{
					model.tel=dt.Rows[n]["tel"].ToString();
					}
					if(dt.Rows[n]["intro"]!=null && dt.Rows[n]["intro"].ToString()!="")
					{
					model.intro=dt.Rows[n]["intro"].ToString();
					}
					if(dt.Rows[n]["point"]!=null && dt.Rows[n]["point"].ToString()!="")
					{
						model.point=int.Parse(dt.Rows[n]["point"].ToString());
					}
					modelList.Add(model);
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

		#endregion  Method
	}
}

