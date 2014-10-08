using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:Password
	/// </summary>
	public partial class Password
	{
		public Password()
		{}
		#region  Method

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string customId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Password");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8)			};
			parameters[0].Value = customId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(dbamet.Model.Password model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Password(");
			strSql.Append("customId,password)");
			strSql.Append(" values (");
			strSql.Append("@customId,@password)");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@password", SqlDbType.Char,20)};
			parameters[0].Value = model.customId;
			parameters[1].Value = model.password;

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
		public bool Update(dbamet.Model.Password model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Password set ");
			strSql.Append("password=@password");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@password", SqlDbType.Char,20),
					new SqlParameter("@customId", SqlDbType.Char,8)};
			parameters[0].Value = model.password;
			parameters[1].Value = model.customId;

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
			strSql.Append("delete from Password ");
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
			strSql.Append("delete from Password ");
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
		public dbamet.Model.Password GetModel(string customId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 customId,password from Password ");
			strSql.Append(" where customId=@customId ");
			SqlParameter[] parameters = {
					new SqlParameter("@customId", SqlDbType.Char,8)			};
			parameters[0].Value = customId;

			dbamet.Model.Password model=new dbamet.Model.Password();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["customId"]!=null && ds.Tables[0].Rows[0]["customId"].ToString()!="")
				{
					model.customId=ds.Tables[0].Rows[0]["customId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["password"]!=null && ds.Tables[0].Rows[0]["password"].ToString()!="")
				{
					model.password=ds.Tables[0].Rows[0]["password"].ToString();
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
			strSql.Append("select customId,password ");
			strSql.Append(" FROM Password ");
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
			strSql.Append(" customId,password ");
			strSql.Append(" FROM Password ");
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
			strSql.Append("select count(1) FROM Password ");
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
			strSql.Append(")AS Row, T.*  from Password T ");
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
			parameters[0].Value = "Password";
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

