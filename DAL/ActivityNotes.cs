using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:ActivityNotes
	/// </summary>
	public partial class ActivityNotes
	{
		public ActivityNotes()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(dbamet.Model.ActivityNotes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ActivityNotes(");
			strSql.Append("activityid,title,place,leader,Content,openTime)");
			strSql.Append(" values (");
			strSql.Append("@activityid,@title,@place,@leader,@Content,@openTime)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@activityid", SqlDbType.Char,10),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@place", SqlDbType.VarChar,100),
					new SqlParameter("@leader", SqlDbType.VarChar,100),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@openTime", SqlDbType.DateTime)};
			parameters[0].Value = model.activityid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.place;
			parameters[3].Value = model.leader;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.openTime;

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
		public bool Update(dbamet.Model.ActivityNotes model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ActivityNotes set ");
			strSql.Append("activityid=@activityid,");
			strSql.Append("title=@title,");
			strSql.Append("place=@place,");
			strSql.Append("leader=@leader,");
			strSql.Append("Content=@Content,");
			strSql.Append("openTime=@openTime");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@activityid", SqlDbType.Char,10),
					new SqlParameter("@title", SqlDbType.NVarChar,50),
					new SqlParameter("@place", SqlDbType.VarChar,100),
					new SqlParameter("@leader", SqlDbType.VarChar,100),
					new SqlParameter("@Content", SqlDbType.NText),
					new SqlParameter("@openTime", SqlDbType.DateTime),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.activityid;
			parameters[1].Value = model.title;
			parameters[2].Value = model.place;
			parameters[3].Value = model.leader;
			parameters[4].Value = model.Content;
			parameters[5].Value = model.openTime;
			parameters[6].Value = model.id;

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
		public bool Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityNotes ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

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
		public bool DeleteList(string idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ActivityNotes ");
			strSql.Append(" where id in ("+idlist + ")  ");
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
		public dbamet.Model.ActivityNotes GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,activityid,title,place,leader,Content,openTime from ActivityNotes ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			dbamet.Model.ActivityNotes model=new dbamet.Model.ActivityNotes();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["activityid"]!=null && ds.Tables[0].Rows[0]["activityid"].ToString()!="")
				{
					model.activityid=ds.Tables[0].Rows[0]["activityid"].ToString();
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["place"]!=null && ds.Tables[0].Rows[0]["place"].ToString()!="")
				{
					model.place=ds.Tables[0].Rows[0]["place"].ToString();
				}
				if(ds.Tables[0].Rows[0]["leader"]!=null && ds.Tables[0].Rows[0]["leader"].ToString()!="")
				{
					model.leader=ds.Tables[0].Rows[0]["leader"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Content"]!=null && ds.Tables[0].Rows[0]["Content"].ToString()!="")
				{
					model.Content=ds.Tables[0].Rows[0]["Content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["openTime"]!=null && ds.Tables[0].Rows[0]["openTime"].ToString()!="")
				{
					model.openTime=DateTime.Parse(ds.Tables[0].Rows[0]["openTime"].ToString());
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
			strSql.Append("select id,activityid,title,place,leader,Content,openTime ");
			strSql.Append(" FROM ActivityNotes ");
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
			strSql.Append(" id,activityid,title,place,leader,Content,openTime ");
			strSql.Append(" FROM ActivityNotes ");
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
			strSql.Append("select count(1) FROM ActivityNotes ");
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
				strSql.Append("order by T.id desc");
			}
			strSql.Append(")AS Row, T.*  from ActivityNotes T ");
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
			parameters[0].Value = "ActivityNotes";
			parameters[1].Value = "id";
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

