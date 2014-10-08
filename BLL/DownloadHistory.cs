using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// DownloadHistory
	/// </summary>
	public partial class DownloadHistory
	{
		private readonly dbamet.DAL.DownloadHistory dal=new dbamet.DAL.DownloadHistory();
		public DownloadHistory()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(dbamet.Model.DownloadHistory model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.DownloadHistory model)
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
		public dbamet.Model.DownloadHistory GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.DownloadHistory GetModelByCache(int id)
		{
			
			string CacheKey = "DownloadHistoryModel-" + id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (dbamet.Model.DownloadHistory)objModel;
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
		public List<dbamet.Model.DownloadHistory> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.DownloadHistory> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.DownloadHistory> modelList = new List<dbamet.Model.DownloadHistory>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.DownloadHistory model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.DownloadHistory();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["customId"]!=null && dt.Rows[n]["customId"].ToString()!="")
					{
					model.customId=dt.Rows[n]["customId"].ToString();
					}
					if(dt.Rows[n]["resourceName"]!=null && dt.Rows[n]["resourceName"].ToString()!="")
					{
					model.resourceName=dt.Rows[n]["resourceName"].ToString();
					}
					if(dt.Rows[n]["downloadTime"]!=null && dt.Rows[n]["downloadTime"].ToString()!="")
					{
						model.downloadTime=DateTime.Parse(dt.Rows[n]["downloadTime"].ToString());
					}
					if(dt.Rows[n]["resourceId"]!=null && dt.Rows[n]["resourceId"].ToString()!="")
					{
						model.resourceId=int.Parse(dt.Rows[n]["resourceId"].ToString());
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

