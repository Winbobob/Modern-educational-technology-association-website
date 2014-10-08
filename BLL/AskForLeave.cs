using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using dbamet.Model;
namespace dbamet.BLL
{
	/// <summary>
	/// AskForLeave
	/// </summary>
	public partial class AskForLeave
	{
		private readonly dbamet.DAL.AskForLeave dal=new dbamet.DAL.AskForLeave();
		public AskForLeave()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(dbamet.Model.AskForLeave model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.AskForLeave model)
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
		public dbamet.Model.AskForLeave GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public dbamet.Model.AskForLeave GetModelByCache(int id)
		{
			
			string CacheKey = "AskForLeaveModel-" + id;
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
			return (dbamet.Model.AskForLeave)objModel;
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
		public List<dbamet.Model.AskForLeave> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<dbamet.Model.AskForLeave> DataTableToList(DataTable dt)
		{
			List<dbamet.Model.AskForLeave> modelList = new List<dbamet.Model.AskForLeave>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				dbamet.Model.AskForLeave model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new dbamet.Model.AskForLeave();
					if(dt.Rows[n]["id"]!=null && dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["avtiveTitle"]!=null && dt.Rows[n]["avtiveTitle"].ToString()!="")
					{
					model.avtiveTitle=dt.Rows[n]["avtiveTitle"].ToString();
					}
					if(dt.Rows[n]["customId"]!=null && dt.Rows[n]["customId"].ToString()!="")
					{
					model.customId=dt.Rows[n]["customId"].ToString();
					}
					if(dt.Rows[n]["openTime"]!=null && dt.Rows[n]["openTime"].ToString()!="")
					{
						model.openTime=DateTime.Parse(dt.Rows[n]["openTime"].ToString());
					}
					if(dt.Rows[n]["submitTIme"]!=null && dt.Rows[n]["submitTIme"].ToString()!="")
					{
						model.submitTIme=DateTime.Parse(dt.Rows[n]["submitTIme"].ToString());
					}
					if(dt.Rows[n]["reason"]!=null && dt.Rows[n]["reason"].ToString()!="")
					{
					model.reason=dt.Rows[n]["reason"].ToString();
					}
					if(dt.Rows[n]["pass"]!=null && dt.Rows[n]["pass"].ToString()!="")
					{
						if((dt.Rows[n]["pass"].ToString()=="1")||(dt.Rows[n]["pass"].ToString().ToLower()=="true"))
						{
						model.pass=true;
						}
						else
						{
							model.pass=false;
						}
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

