using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:UserList
	/// </summary>
	public partial class UserList
	{
		public UserList()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string customId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from UserList");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8)			};
			parameters[0].Value = customId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.UserList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into UserList(");
			strSql.Append("customId,customName,birth,duty,className,sex,interest,tel,intro,point)");
			strSql.Append(" values (");
			strSql.Append("@customId,@customName,@birth,@duty,@className,@sex,@interest,@tel,@intro,@point)");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@customName", SqlDbType.VarChar,50),
					new SqlParameter("@birth", SqlDbType.DateTime),
					new SqlParameter("@duty", SqlDbType.VarChar,50),
					new SqlParameter("@className", SqlDbType.VarChar,100),
					new SqlParameter("@sex", SqlDbType.Char,10),
					new SqlParameter("@interest", SqlDbType.VarChar,100),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@intro", SqlDbType.NText),
					new SqlParameter("@point", SqlDbType.Int,4)};
			parameters[0].Value = model.customId;
			parameters[1].Value = model.customName;
			parameters[2].Value = model.birth;
			parameters[3].Value = model.duty;
			parameters[4].Value = model.className;
			parameters[5].Value = model.sex;
			parameters[6].Value = model.interest;
			parameters[7].Value = model.tel;
			parameters[8].Value = model.intro;
			parameters[9].Value = model.point;

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
		public bool Update(dbamet.Model.UserList model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update UserList set ");
			strSql.Append("customName=@customName,");
			strSql.Append("birth=@birth,");
			strSql.Append("duty=@duty,");
			strSql.Append("className=@className,");
			strSql.Append("sex=@sex,");
			strSql.Append("interest=@interest,");
			strSql.Append("tel=@tel,");
			strSql.Append("intro=@intro,");
			strSql.Append("point=@point");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@customName", SqlDbType.VarChar,50),
					new SqlParameter("@birth", SqlDbType.DateTime),
					new SqlParameter("@duty", SqlDbType.VarChar,50),
					new SqlParameter("@className", SqlDbType.VarChar,100),
					new SqlParameter("@sex", SqlDbType.Char,10),
					new SqlParameter("@interest", SqlDbType.VarChar,100),
					new SqlParameter("@tel", SqlDbType.VarChar,100),
					new SqlParameter("@intro", SqlDbType.NText),
					new SqlParameter("@point", SqlDbType.Int,4),
					new SqlParameter("@customId", SqlDbType.Char,8)};
			parameters[0].Value = model.customName;
			parameters[1].Value = model.birth;
			parameters[2].Value = model.duty;
			parameters[3].Value = model.className;
			parameters[4].Value = model.sex;
			parameters[5].Value = model.interest;
			parameters[6].Value = model.tel;
			parameters[7].Value = model.intro;
			parameters[8].Value = model.point;
			parameters[9].Value = model.customId;

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
		public bool Delete(string customId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserList ");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8)			};
			parameters[0].Value = customId;

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
		public bool DeleteList(string customIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from UserList ");
			strSql.Append(" where customId in ("+customIdlist + ")  ");
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
		public dbamet.Model.UserList GetModel(string customId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 customId,customName,birth,duty,className,sex,interest,tel,intro,point from UserList ");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8)			};
			parameters[0].Value = customId;

			dbamet.Model.UserList model=new dbamet.Model.UserList();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["customId"]!=null && ds.Tables[0].Rows[0]["customId"].ToString()!="")
				{
					model.customId=ds.Tables[0].Rows[0]["customId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["customName"]!=null && ds.Tables[0].Rows[0]["customName"].ToString()!="")
				{
					model.customName=ds.Tables[0].Rows[0]["customName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["birth"]!=null && ds.Tables[0].Rows[0]["birth"].ToString()!="")
				{
					model.birth=DateTime.Parse(ds.Tables[0].Rows[0]["birth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["duty"]!=null && ds.Tables[0].Rows[0]["duty"].ToString()!="")
				{
					model.duty=ds.Tables[0].Rows[0]["duty"].ToString();
				}
				if(ds.Tables[0].Rows[0]["className"]!=null && ds.Tables[0].Rows[0]["className"].ToString()!="")
				{
					model.className=ds.Tables[0].Rows[0]["className"].ToString();
				}
				if(ds.Tables[0].Rows[0]["sex"]!=null && ds.Tables[0].Rows[0]["sex"].ToString()!="")
				{
					model.sex=ds.Tables[0].Rows[0]["sex"].ToString();
				}
				if(ds.Tables[0].Rows[0]["interest"]!=null && ds.Tables[0].Rows[0]["interest"].ToString()!="")
				{
					model.interest=ds.Tables[0].Rows[0]["interest"].ToString();
				}
				if(ds.Tables[0].Rows[0]["tel"]!=null && ds.Tables[0].Rows[0]["tel"].ToString()!="")
				{
					model.tel=ds.Tables[0].Rows[0]["tel"].ToString();
				}
				if(ds.Tables[0].Rows[0]["intro"]!=null && ds.Tables[0].Rows[0]["intro"].ToString()!="")
				{
					model.intro=ds.Tables[0].Rows[0]["intro"].ToString();
				}
				if(ds.Tables[0].Rows[0]["point"]!=null && ds.Tables[0].Rows[0]["point"].ToString()!="")
				{
					model.point=int.Parse(ds.Tables[0].Rows[0]["point"].ToString());
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
			strSql.Append("select customId,customName,birth,duty,className,sex,interest,tel,intro,point ");
			strSql.Append(" FROM UserList ");
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
			strSql.Append(" customId,customName,birth,duty,className,sex,interest,tel,intro,point ");
			strSql.Append(" FROM UserList ");
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
			strSql.Append("select count(1) FROM UserList ");
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
				strSql.Append("order by T.customId desc");
			}
			strSql.Append(")AS Row, T.*  from UserList T ");
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
			parameters[0].Value = "UserList";
			parameters[1].Value = "customId";
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

