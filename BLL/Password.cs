using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// Password
	/// </summary>
	public partial class Password
	{
		private readonly dbamet.DAL.Password dal=new dbamet.DAL.Password();
		public Password()
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
		public bool Add(dbamet.Model.Password model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.Password model)
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
		public dbamet.Model.Password GetModel(string customId)
		{
			
			return dal.GetModel(customId);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.Password GetModelByCache(string customId)
		{
			
			string CacheKey = "PasswordModel-" + customId;
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
			return (dbamet.Model.Password)objModel;
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
		public List<dbamet.Model.Password> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.Password> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.Password> modelList = new List<dbamet.Model.Password>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.Password model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.Password();
					if(dt.Rows[n]["customId"]!=null && dt.Rows[n]["customId"].ToString()!="")
					{
					model.customId=dt.Rows[n]["customId"].ToString();
					}
					if(dt.Rows[n]["password"]!=null && dt.Rows[n]["password"].ToString()!="")
					{
					model.password=dt.Rows[n]["password"].ToString();
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

