using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:HomeWork
	/// </summary>
	public partial class HomeWork
	{
		public HomeWork()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.HomeWork model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into HomeWork(");
			strSql.Append("customId,hwId,hwName,hwPath)");
			strSql.Append(" values (");
			strSql.Append("@customId,@hwId,@hwName,@hwPath)");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@hwId", SqlDbType.Char,10),
					new SqlParameter("@hwName", SqlDbType.VarChar,200),
					new SqlParameter("@hwPath", SqlDbType.VarChar,200)};
			parameters[0].Value = model.customId;
			parameters[1].Value = model.hwId;
			parameters[2].Value = model.hwName;
			parameters[3].Value = model.hwPath;

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
		/// 更新一条数据
		/// </summary>
		public bool Update(dbamet.Model.HomeWork model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update HomeWork set ");
			strSql.Append("customId=@customId,");
			strSql.Append("hwId=@hwId,");
			strSql.Append("hwName=@hwName,");
			strSql.Append("hwPath=@hwPath");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@hwId", SqlDbType.Char,10),
					new SqlParameter("@hwName", SqlDbType.VarChar,200),
					new SqlParameter("@hwPath", SqlDbType.VarChar,200)};
			parameters[0].Value = model.customId;
			parameters[1].Value = model.hwId;
			parameters[2].Value = model.hwName;
			parameters[3].Value = model.hwPath;

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
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from HomeWork ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

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
		/// 得到一个对象实体
		/// </summary>
		public dbamet.Model.HomeWork GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 customId,hwId,hwName,hwPath from HomeWork ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			dbamet.Model.HomeWork model=new dbamet.Model.HomeWork();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["customId"]!=null && ds.Tables[0].Rows[0]["customId"].ToString()!="")
				{
					model.customId=ds.Tables[0].Rows[0]["customId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hwId"]!=null && ds.Tables[0].Rows[0]["hwId"].ToString()!="")
				{
					model.hwId=ds.Tables[0].Rows[0]["hwId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hwName"]!=null && ds.Tables[0].Rows[0]["hwName"].ToString()!="")
				{
					model.hwName=ds.Tables[0].Rows[0]["hwName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["hwPath"]!=null && ds.Tables[0].Rows[0]["hwPath"].ToString()!="")
				{
					model.hwPath=ds.Tables[0].Rows[0]["hwPath"].ToString();
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
			strSql.Append("select customId,hwId,hwName,hwPath ");
			strSql.Append(" FROM HomeWork ");
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
			strSql.Append(" customId,hwId,hwName,hwPath ");
			strSql.Append(" FROM HomeWork ");
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
			strSql.Append("select count(1) FROM HomeWork ");
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
				strSql.Append("order by T.courseId desc");
			}
			strSql.Append(")AS Row, T.*  from HomeWork T ");
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
			parameters[0].Value = "HomeWork";
			parameters[1].Value = "courseId";
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

