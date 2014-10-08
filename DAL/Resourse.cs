using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:Resourse
	/// </summary>
	public partial class Resourse
	{
		public Resourse()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("resourceId", "Resourse"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int resourceId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Resourse");
			strSql.Append(" where resourceId=@resourceId");
			SqlParameter[] parameters = {
					new SqlParameter("@resourceId", SqlDbType.Int,4)
			};
			parameters[0].Value = resourceId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(dbamet.Model.Resourse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Resourse(");
			strSql.Append("customId,resourceName,resourcePath,resourceType,category,size,info,uploadTime,downloadTimes)");
			strSql.Append(" values (");
			strSql.Append("@customId,@resourceName,@resourcePath,@resourceType,@category,@size,@info,@uploadTime,@downloadTimes)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@resourceName", SqlDbType.VarChar,500),
					new SqlParameter("@resourcePath", SqlDbType.VarChar,2000),
					new SqlParameter("@resourceType", SqlDbType.VarChar,500),
					new SqlParameter("@category", SqlDbType.VarChar,50),
					new SqlParameter("@size", SqlDbType.VarChar,500),
					new SqlParameter("@info", SqlDbType.VarChar,2000),
					new SqlParameter("@uploadTime", SqlDbType.DateTime),
					new SqlParameter("@downloadTimes", SqlDbType.Int,4)};
			parameters[0].Value = model.customId;
			parameters[1].Value = model.resourceName;
			parameters[2].Value = model.resourcePath;
			parameters[3].Value = model.resourceType;
			parameters[4].Value = model.category;
			parameters[5].Value = model.size;
			parameters[6].Value = model.info;
			parameters[7].Value = model.uploadTime;
			parameters[8].Value = model.downloadTimes;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.Resourse model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Resourse set ");
			strSql.Append("customId=@customId,");
			strSql.Append("resourceName=@resourceName,");
			strSql.Append("resourcePath=@resourcePath,");
			strSql.Append("resourceType=@resourceType,");
			strSql.Append("category=@category,");
			strSql.Append("size=@size,");
			strSql.Append("info=@info,");
			strSql.Append("uploadTime=@uploadTime,");
			strSql.Append("downloadTimes=@downloadTimes");
			strSql.Append(" where resourceId=@resourceId");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@resourceName", SqlDbType.VarChar,500),
					new SqlParameter("@resourcePath", SqlDbType.VarChar,2000),
					new SqlParameter("@resourceType", SqlDbType.VarChar,500),
					new SqlParameter("@category", SqlDbType.VarChar,50),
					new SqlParameter("@size", SqlDbType.VarChar,500),
					new SqlParameter("@info", SqlDbType.VarChar,2000),
					new SqlParameter("@uploadTime", SqlDbType.DateTime),
					new SqlParameter("@downloadTimes", SqlDbType.Int,4),
					new SqlParameter("@resourceId", SqlDbType.Int,4)};
			parameters[0].Value = model.customId;
			parameters[1].Value = model.resourceName;
			parameters[2].Value = model.resourcePath;
			parameters[3].Value = model.resourceType;
			parameters[4].Value = model.category;
			parameters[5].Value = model.size;
			parameters[6].Value = model.info;
			parameters[7].Value = model.uploadTime;
			parameters[8].Value = model.downloadTimes;
			parameters[9].Value = model.resourceId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int resourceId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Resourse ");
			strSql.Append(" where resourceId=@resourceId");
			SqlParameter[] parameters = {
					new SqlParameter("@resourceId", SqlDbType.Int,4)
			};
			parameters[0].Value = resourceId;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string resourceIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Resourse ");
			strSql.Append(" where resourceId in ("+resourceIdlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public dbamet.Model.Resourse GetModel(int resourceId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 resourceId,customId,resourceName,resourcePath,resourceType,category,size,info,uploadTime,downloadTimes from Resourse ");
			strSql.Append(" where resourceId=@resourceId");
			SqlParameter[] parameters = {
					new SqlParameter("@resourceId", SqlDbType.Int,4)
			};
			parameters[0].Value = resourceId;

			dbamet.Model.Resourse model=new dbamet.Model.Resourse();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["resourceId"]!=null && ds.Tables[0].Rows[0]["resourceId"].ToString()!="")
				{
					model.resourceId=int.Parse(ds.Tables[0].Rows[0]["resourceId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["customId"]!=null && ds.Tables[0].Rows[0]["customId"].ToString()!="")
				{
					model.customId=ds.Tables[0].Rows[0]["customId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["resourceName"]!=null && ds.Tables[0].Rows[0]["resourceName"].ToString()!="")
				{
					model.resourceName=ds.Tables[0].Rows[0]["resourceName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["resourcePath"]!=null && ds.Tables[0].Rows[0]["resourcePath"].ToString()!="")
				{
					model.resourcePath=ds.Tables[0].Rows[0]["resourcePath"].ToString();
				}
				if(ds.Tables[0].Rows[0]["resourceType"]!=null && ds.Tables[0].Rows[0]["resourceType"].ToString()!="")
				{
					model.resourceType=ds.Tables[0].Rows[0]["resourceType"].ToString();
				}
				if(ds.Tables[0].Rows[0]["category"]!=null && ds.Tables[0].Rows[0]["category"].ToString()!="")
				{
					model.category=ds.Tables[0].Rows[0]["category"].ToString();
				}
				if(ds.Tables[0].Rows[0]["size"]!=null && ds.Tables[0].Rows[0]["size"].ToString()!="")
				{
					model.size=ds.Tables[0].Rows[0]["size"].ToString();
				}
				if(ds.Tables[0].Rows[0]["info"]!=null && ds.Tables[0].Rows[0]["info"].ToString()!="")
				{
					model.info=ds.Tables[0].Rows[0]["info"].ToString();
				}
				if(ds.Tables[0].Rows[0]["uploadTime"]!=null && ds.Tables[0].Rows[0]["uploadTime"].ToString()!="")
				{
					model.uploadTime=DateTime.Parse(ds.Tables[0].Rows[0]["uploadTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["downloadTimes"]!=null && ds.Tables[0].Rows[0]["downloadTimes"].ToString()!="")
				{
					model.downloadTimes=int.Parse(ds.Tables[0].Rows[0]["downloadTimes"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select resourceId,customId,resourceName,resourcePath,resourceType,category,size,info,uploadTime,downloadTimes ");
			strSql.Append(" FROM Resourse ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" resourceId,customId,resourceName,resourcePath,resourceType,category,size,info,uploadTime,downloadTimes ");
			strSql.Append(" FROM Resourse ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Resourse ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.resourceId desc");
			}
			strSql.Append(")AS Row, T.*  from Resourse T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Resourse";
			parameters[1].Value = "resourceId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

