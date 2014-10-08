using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace dbamet.DAL
{
	/// <summary>
	/// 数据访问类:AskForLeave
	/// </summary>
	public partial class AskForLeave
	{
		public AskForLeave()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(dbamet.Model.AskForLeave model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into AskForLeave(");
			strSql.Append("avtiveTitle,customId,openTime,submitTIme,reason,pass)");
			strSql.Append(" values (");
			strSql.Append("@avtiveTitle,@customId,@openTime,@submitTIme,@reason,@pass)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@avtiveTitle", SqlDbType.VarChar,50),
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@openTime", SqlDbType.DateTime),
					new SqlParameter("@submitTIme", SqlDbType.DateTime),
					new SqlParameter("@reason", SqlDbType.NText),
					new SqlParameter("@pass", SqlDbType.Bit,1)};
			parameters[0].Value = model.avtiveTitle;
			parameters[1].Value = model.customId;
			parameters[2].Value = model.openTime;
			parameters[3].Value = model.submitTIme;
			parameters[4].Value = model.reason;
			parameters[5].Value = model.pass;

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
		public bool Update(dbamet.Model.AskForLeave model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update AskForLeave set ");
			strSql.Append("avtiveTitle=@avtiveTitle,");
			strSql.Append("customId=@customId,");
			strSql.Append("openTime=@openTime,");
			strSql.Append("submitTIme=@submitTIme,");
			strSql.Append("reason=@reason,");
			strSql.Append("pass=@pass");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@avtiveTitle", SqlDbType.VarChar,50),
					new SqlParameter("@customId", SqlDbType.Char,8),
					new SqlParameter("@openTime", SqlDbType.DateTime),
					new SqlParameter("@submitTIme", SqlDbType.DateTime),
					new SqlParameter("@reason", SqlDbType.NText),
					new SqlParameter("@pass", SqlDbType.Bit,1),
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = model.avtiveTitle;
			parameters[1].Value = model.customId;
			parameters[2].Value = model.openTime;
			parameters[3].Value = model.submitTIme;
			parameters[4].Value = model.reason;
			parameters[5].Value = model.pass;
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
			strSql.Append("delete from AskForLeave ");
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
			strSql.Append("delete from AskForLeave ");
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
		public dbamet.Model.AskForLeave GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 id,avtiveTitle,customId,openTime,submitTIme,reason,pass from AskForLeave ");
			strSql.Append(" where id=@id");
			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
			parameters[0].Value = id;

			dbamet.Model.AskForLeave model=new dbamet.Model.AskForLeave();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"]!=null && ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["avtiveTitle"]!=null && ds.Tables[0].Rows[0]["avtiveTitle"].ToString()!="")
				{
					model.avtiveTitle=ds.Tables[0].Rows[0]["avtiveTitle"].ToString();
				}
				if(ds.Tables[0].Rows[0]["customId"]!=null && ds.Tables[0].Rows[0]["customId"].ToString()!="")
				{
					model.customId=ds.Tables[0].Rows[0]["customId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["openTime"]!=null && ds.Tables[0].Rows[0]["openTime"].ToString()!="")
				{
					model.openTime=DateTime.Parse(ds.Tables[0].Rows[0]["openTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["submitTIme"]!=null && ds.Tables[0].Rows[0]["submitTIme"].ToString()!="")
				{
					model.submitTIme=DateTime.Parse(ds.Tables[0].Rows[0]["submitTIme"].ToString());
				}
				if(ds.Tables[0].Rows[0]["reason"]!=null && ds.Tables[0].Rows[0]["reason"].ToString()!="")
				{
					model.reason=ds.Tables[0].Rows[0]["reason"].ToString();
				}
				if(ds.Tables[0].Rows[0]["pass"]!=null && ds.Tables[0].Rows[0]["pass"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["pass"].ToString()=="1")||(ds.Tables[0].Rows[0]["pass"].ToString().ToLower()=="true"))
					{
						model.pass=true;
					}
					else
					{
						model.pass=false;
					}
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
			strSql.Append("select id,avtiveTitle,customId,openTime,submitTIme,reason,pass ");
			strSql.Append(" FROM AskForLeave ");
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
			strSql.Append(" id,avtiveTitle,customId,openTime,submitTIme,reason,pass ");
			strSql.Append(" FROM AskForLeave ");
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
			strSql.Append("select count(1) FROM AskForLeave ");
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
			strSql.Append(")AS Row, T.*  from AskForLeave T ");
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
			parameters[0].Value = "AskForLeave";
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

