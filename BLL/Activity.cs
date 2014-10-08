using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// Activity
	/// </summary>
	public partial class Activity
	{
		private readonly dbamet.DAL.Activity dal=new dbamet.DAL.Activity();
		public Activity()
		{}
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string courseId)
		{
			return dal.Exists(courseId);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.Activity model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.Activity model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string courseId)
		{
			
			return dal.Delete(courseId);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string courseIdlist )
		{
			return dal.DeleteList(courseIdlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public dbamet.Model.Activity GetModel(string courseId)
		{
			
			return dal.GetModel(courseId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.Activity GetModelByCache(string courseId)
		{
			
			string CacheKey = "ActivityModel-" + courseId;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(courseId);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (dbamet.Model.Activity)objModel;
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
		public List<dbamet.Model.Activity> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.Activity> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.Activity> modelList = new List<dbamet.Model.Activity>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.Activity model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.Activity();
					if(dt.Rows[n]["courseId"]!=null && dt.Rows[n]["courseId"].ToString()!="")
					{
					model.courseId=dt.Rows[n]["courseId"].ToString();
					}
					if(dt.Rows[n]["courseName"]!=null && dt.Rows[n]["courseName"].ToString()!="")
					{
					model.courseName=dt.Rows[n]["courseName"].ToString();
					}
					if(dt.Rows[n]["courseIntro"]!=null && dt.Rows[n]["courseIntro"].ToString()!="")
					{
					model.courseIntro=dt.Rows[n]["courseIntro"].ToString();
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

