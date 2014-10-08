using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// Resourse
	/// </summary>
	public partial class Resourse
	{
		private readonly dbamet.DAL.Resourse dal=new dbamet.DAL.Resourse();
		public Resourse()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int resourceId)
		{
			return dal.Exists(resourceId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(dbamet.Model.Resourse model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.Resourse model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int resourceId)
		{
			
			return dal.Delete(resourceId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string resourceIdlist )
		{
			return dal.DeleteList(resourceIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public dbamet.Model.Resourse GetModel(int resourceId)
		{
			
			return dal.GetModel(resourceId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.Resourse GetModelByCache(int resourceId)
		{
			
			string CacheKey = "ResourseModel-" + resourceId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(resourceId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (dbamet.Model.Resourse)objModel;
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
		public List<dbamet.Model.Resourse> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.Resourse> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.Resourse> modelList = new List<dbamet.Model.Resourse>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.Resourse model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.Resourse();
					if(dt.Rows[n]["resourceId"]!=null && dt.Rows[n]["resourceId"].ToString()!="")
					{
						model.resourceId=int.Parse(dt.Rows[n]["resourceId"].ToString());
					}
					if(dt.Rows[n]["customId"]!=null && dt.Rows[n]["customId"].ToString()!="")
					{
					model.customId=dt.Rows[n]["customId"].ToString();
					}
					if(dt.Rows[n]["resourceName"]!=null && dt.Rows[n]["resourceName"].ToString()!="")
					{
					model.resourceName=dt.Rows[n]["resourceName"].ToString();
					}
					if(dt.Rows[n]["resourcePath"]!=null && dt.Rows[n]["resourcePath"].ToString()!="")
					{
					model.resourcePath=dt.Rows[n]["resourcePath"].ToString();
					}
					if(dt.Rows[n]["resourceType"]!=null && dt.Rows[n]["resourceType"].ToString()!="")
					{
					model.resourceType=dt.Rows[n]["resourceType"].ToString();
					}
					if(dt.Rows[n]["category"]!=null && dt.Rows[n]["category"].ToString()!="")
					{
					model.category=dt.Rows[n]["category"].ToString();
					}
					if(dt.Rows[n]["size"]!=null && dt.Rows[n]["size"].ToString()!="")
					{
					model.size=dt.Rows[n]["size"].ToString();
					}
					if(dt.Rows[n]["info"]!=null && dt.Rows[n]["info"].ToString()!="")
					{
					model.info=dt.Rows[n]["info"].ToString();
					}
					if(dt.Rows[n]["uploadTime"]!=null && dt.Rows[n]["uploadTime"].ToString()!="")
					{
						model.uploadTime=DateTime.Parse(dt.Rows[n]["uploadTime"].ToString());
					}
					if(dt.Rows[n]["downloadTimes"]!=null && dt.Rows[n]["downloadTimes"].ToString()!="")
					{
						model.downloadTimes=int.Parse(dt.Rows[n]["downloadTimes"].ToString());
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

