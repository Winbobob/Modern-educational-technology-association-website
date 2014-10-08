using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:Activity
	/// </summary>
	public partial class Activity
	{
		public Activity()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string courseId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Activity");
			strSql.Append(" where courseId=@courseId ");
			SqlParameter[] parameters = {
					new SqlParameter("@courseId", SqlDbType.Char,10)			};
			parameters[0].Value = courseId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.Activity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Activity(");
			strSql.Append("courseId,courseName,courseIntro)");
			strSql.Append(" values (");
			strSql.Append("@courseId,@courseName,@courseIntro)");
			SqlParameter[] parameters = {
					new SqlParameter("@courseId", SqlDbType.Char,10),
					new SqlParameter("@courseName", SqlDbType.VarChar,50),
					new SqlParameter("@courseIntro", SqlDbType.VarChar,200)};
			parameters[0].Value = model.courseId;
			parameters[1].Value = model.courseName;
			parameters[2].Value = model.courseIntro;

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
		public bool Update(dbamet.Model.Activity model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Activity set ");
			strSql.Append("courseName=@courseName,");
			strSql.Append("courseIntro=@courseIntro");
			strSql.Append(" where courseId=@courseId ");
			SqlParameter[] parameters = {
					new SqlParameter("@courseName", SqlDbType.VarChar,50),
					new SqlParameter("@courseIntro", SqlDbType.VarChar,200),
					new SqlParameter("@courseId", SqlDbType.Char,10)};
			parameters[0].Value = model.courseName;
			parameters[1].Value = model.courseIntro;
			parameters[2].Value = model.courseId;

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
		public bool Delete(string courseId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Activity ");
			strSql.Append(" where courseId=@courseId ");
			SqlParameter[] parameters = {
					new SqlParameter("@courseId", SqlDbType.Char,10)			};
			parameters[0].Value = courseId;

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
		public bool DeleteList(string courseIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Activity ");
			strSql.Append(" where courseId in ("+courseIdlist + ")  ");
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
		public dbamet.Model.Activity GetModel(string courseId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 courseId,courseName,courseIntro from Activity ");
			strSql.Append(" where courseId=@courseId ");
			SqlParameter[] parameters = {
					new SqlParameter("@courseId", SqlDbType.Char,10)			};
			parameters[0].Value = courseId;

			dbamet.Model.Activity model=new dbamet.Model.Activity();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["courseId"]!=null && ds.Tables[0].Rows[0]["courseId"].ToString()!="")
				{
					model.courseId=ds.Tables[0].Rows[0]["courseId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["courseName"]!=null && ds.Tables[0].Rows[0]["courseName"].ToString()!="")
				{
					model.courseName=ds.Tables[0].Rows[0]["courseName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["courseIntro"]!=null && ds.Tables[0].Rows[0]["courseIntro"].ToString()!="")
				{
					model.courseIntro=ds.Tables[0].Rows[0]["courseIntro"].ToString();
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
			strSql.Append("select courseId,courseName,courseIntro ");
			strSql.Append(" FROM Activity ");
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
			strSql.Append(" courseId,courseName,courseIntro ");
			strSql.Append(" FROM Activity ");
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
			strSql.Append("select count(1) FROM Activity ");
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
			strSql.Append(")AS Row, T.*  from Activity T ");
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
			parameters[0].Value = "Activity";
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

