using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// Admin
	/// </summary>
	public partial class Admin
	{
		private readonly dbamet.DAL.Admin dal=new dbamet.DAL.Admin();
		public Admin()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string uid)
		{
			return dal.Exists(uid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.Admin model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.Admin model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string uid)
		{
			
			return dal.Delete(uid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string uidlist )
		{
			return dal.DeleteList(uidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public dbamet.Model.Admin GetModel(string uid)
		{
			
			return dal.GetModel(uid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.Admin GetModelByCache(string uid)
		{
			
			string CacheKey = "AdminModel-" + uid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(uid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (dbamet.Model.Admin)objModel;
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
		public List<dbamet.Model.Admin> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.Admin> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.Admin> modelList = new List<dbamet.Model.Admin>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.Admin model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.Admin();
					if(dt.Rows[n]["uid"]!=null && dt.Rows[n]["uid"].ToString()!="")
					{
					model.uid=dt.Rows[n]["uid"].ToString();
					}
					if(dt.Rows[n]["upwd"]!=null && dt.Rows[n]["upwd"].ToString()!="")
					{
					model.upwd=dt.Rows[n]["upwd"].ToString();
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

