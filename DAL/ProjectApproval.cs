using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:ProjectApproval
	/// </summary>
	public partial class ProjectApproval
	{
		public ProjectApproval()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(dbamet.Model.ProjectApproval model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ProjectApproval(");
			strSql.Append("title,proposer,category,content,applydate,passdate,pass)");
			strSql.Append(" values (");
			strSql.Append("@title,@proposer,@category,@content,@applydate,@passdate,@pass)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@proposer", SqlDbType.VarChar,50),
					new SqlParameter("@category", SqlDbType.VarChar,50),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@applydate", SqlDbType.DateTime),
					new SqlParameter("@passdate", SqlDbType.DateTime),
					new SqlParameter("@pass", SqlDbType.NChar,1)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.proposer;
			parameters[2].Value = model.category;
			parameters[3].Value = model.content;
			parameters[4].Value = model.applydate;
			parameters[5].Value = model.passdate;
			parameters[6].Value = model.pass;

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
		public bool Update(dbamet.Model.ProjectApproval model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProjectApproval set ");
			strSql.Append("title=@title,");
			strSql.Append("proposer=@proposer,");
			strSql.Append("category=@category,");
			strSql.Append("content=@content,");
			strSql.Append("applydate=@applydate,");
			strSql.Append("passdate=@passdate,");
			strSql.Append("pass=@pass");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@proposer", SqlDbType.VarChar,50),
					new SqlParameter("@category", SqlDbType.VarChar,50),
					new SqlParameter("@content", SqlDbType.NText),
					new SqlParameter("@applydate", SqlDbType.DateTime),
					new SqlParameter("@passdate", SqlDbType.DateTime),
					new SqlParameter("@pass", SqlDbType.NChar,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.title;
			parameters[1].Value = model.proposer;
			parameters[2].Value = model.category;
			parameters[3].Value = model.content;
			parameters[4].Value = model.applydate;
			parameters[5].Value = model.passdate;
			parameters[6].Value = model.pass;
			parameters[7].Value = model.id;

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
			strSql.Append("delete from ProjectApproval ");
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
			strSql.Append("delete from ProjectApproval ");
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
		public dbamet.Model.ProjectApproval GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,title,proposer,category,content,applydate,passdate,pass from ProjectApproval ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			dbamet.Model.ProjectApproval model=new dbamet.Model.ProjectApproval();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["title"]!=null && ds.Tables[0].Rows[0]["title"].ToString()!="")
				{
					model.title=ds.Tables[0].Rows[0]["title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["proposer"]!=null && ds.Tables[0].Rows[0]["proposer"].ToString()!="")
				{
					model.proposer=ds.Tables[0].Rows[0]["proposer"].ToString();
				}
				if(ds.Tables[0].Rows[0]["category"]!=null && ds.Tables[0].Rows[0]["category"].ToString()!="")
				{
					model.category=ds.Tables[0].Rows[0]["category"].ToString();
				}
				if(ds.Tables[0].Rows[0]["content"]!=null && ds.Tables[0].Rows[0]["content"].ToString()!="")
				{
					model.content=ds.Tables[0].Rows[0]["content"].ToString();
				}
				if(ds.Tables[0].Rows[0]["applydate"]!=null && ds.Tables[0].Rows[0]["applydate"].ToString()!="")
				{
					model.applydate=DateTime.Parse(ds.Tables[0].Rows[0]["applydate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["passdate"]!=null && ds.Tables[0].Rows[0]["passdate"].ToString()!="")
				{
					model.passdate=DateTime.Parse(ds.Tables[0].Rows[0]["passdate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pass"]!=null && ds.Tables[0].Rows[0]["pass"].ToString()!="")
				{
					model.pass=ds.Tables[0].Rows[0]["pass"].ToString();
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
			strSql.Append("select id,title,proposer,category,content,applydate,passdate,pass ");
			strSql.Append(" FROM ProjectApproval ");
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
			strSql.Append(" id,title,proposer,category,content,applydate,passdate,pass ");
			strSql.Append(" FROM ProjectApproval ");
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
			strSql.Append("select count(1) FROM ProjectApproval ");
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
			strSql.Append(")AS Row, T.*  from ProjectApproval T ");
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
			parameters[0].Value = "ProjectApproval";
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

