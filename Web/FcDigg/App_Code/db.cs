using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Linq.Expressions;
using System.Web.Caching;
using System.Runtime.Serialization;

/// <summary>
///db 的摘要说明
/// </summary>
public partial class dbcms
{
    /// <summary>
    /// 实现查找
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="obj"></param>
    /// <returns></returns>
    public IQueryable<TEntity> Find<TEntity>(TEntity obj) where TEntity : class
    {
        //获得所有property的信息
        PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //构造初始的query

        IQueryable<TEntity> query = this.GetTable<TEntity>().AsQueryable<TEntity>();
        //遍历每个property
        foreach (PropertyInfo p in properties)
        {
            if (p != null)
            {
                Type t = p.PropertyType;
                //加入object，Binary，和XDocument， 支持sql_variant，imager 和xml等的影射。
                if (t.IsValueType || t == typeof(string) || t == typeof(System.Byte[])
                  || t == typeof(object) || t == typeof(System.Xml.Linq.XDocument)
                  || t == typeof(System.Data.Linq.Binary))
                {
                    //如果不为null才算做条件

                    if (p.GetValue(obj, null) != null)
                    {
                        if (((ColumnAttribute)(p.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).IsPrimaryKey && Convert.ToInt32(p.GetValue(obj, null)) == 0)
                        {

                        }
                        else
                        {
                            ParameterExpression param = Expression.Parameter(typeof(TEntity), "c");
                            Expression right = Expression.Constant(p.GetValue(obj, null));
                            Expression left = Expression.Property(param, p.Name);
                            Expression filter = Expression.Equal(left, right);
                            Expression<Func<TEntity, bool>> pred = Expression.Lambda<Func<TEntity, bool>>(filter, param);
                            query = query.Where(pred);
                        }
                    }
                }
            }
        }
        return query;
    }
    /// <summary>
    /// 根据主键更新
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="obj"></param>
    public void Update<TEntity>(TEntity obj) where TEntity : class
    {
        string str = "update  [" + typeof(TEntity).Name + "] set ";
        string cols = "";
        string where = "";
        //获得所有property的信息
        PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //构造初始的query

        IQueryable<TEntity> query = this.GetTable<TEntity>().AsQueryable<TEntity>();
        //遍历每个property
        foreach (PropertyInfo p in properties)
        {
            if (p != null)
            {
                Type t = p.PropertyType;
                //加入object，Binary，和XDocument， 支持sql_variant，imager 和xml等的影射。
                if (t.IsValueType || t == typeof(string) || t == typeof(System.Byte[])
                  || t == typeof(object) || t == typeof(System.Xml.Linq.XDocument)
                  || t == typeof(System.Data.Linq.Binary))
                {
                    //如果不为null才算做条件

                    if (p.GetValue(obj, null) != null)
                    {
                        if (((ColumnAttribute)(p.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).IsPrimaryKey)
                        {
                            where += " where [" + p.Name + "]=" + p.GetValue(obj, null);
                        }
                        else
                        {

                            if (!(t.ToString().ToLower().Contains("string") || t.ToString().ToLower().Contains("datetime")))
                                cols += "[" + p.Name + "]=" + p.GetValue(obj, null) + ",";
                            else
                                cols += "[" + p.Name + "]='" + p.GetValue(obj, null) + "',";
                        }
                    }
                }
            }
        }

        str += cols.Substring(0, cols.Length - 1) + where;
        HttpContext.Current.Response.Write("<br>" + str + "<br>");
        this.ExecuteCommand(str);

    }
    public void UpdateAll<TEntity>(IEnumerable<TEntity> obj) where TEntity : class
    {
        foreach (var item in obj)
        {
            this.Update<TEntity>(item);
        }
    }
    public void InsertAll<TEntity>(IEnumerable<TEntity> obj) where TEntity : class
    {
        foreach (var item in obj)
        {
            this.Insert<TEntity>(item);
        }
    }
    public void DeleteAll<TEntity>(IEnumerable<TEntity> obj) where TEntity : class
    {
        foreach (var item in obj)
        {
            this.Delete<TEntity>(item);
        }
    }
    /// <summary>
    /// 添加数据
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="obj"></param>
    public void Insert<TEntity>(TEntity obj) where TEntity : class
    {
        string str = "insert into [" + typeof(TEntity).Name + "] (";
        string cols = "";
        string vals = "";

        //获得所有property的信息
        PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //构造初始的query

        IQueryable<TEntity> query = this.GetTable<TEntity>().AsQueryable<TEntity>();
        //遍历每个property
        foreach (PropertyInfo p in properties)
        {
            if (p != null)
            {
                Type t = p.PropertyType;
                //加入object，Binary，和XDocument， 支持sql_variant，imager 和xml等的影射。
                if (t.IsValueType || t == typeof(string) || t == typeof(System.Byte[])
                  || t == typeof(object) || t == typeof(System.Xml.Linq.XDocument)
                  || t == typeof(System.Data.Linq.Binary))
                {
                    //如果不为null才算做条件

                    if (p.GetValue(obj, null) != null)
                    {
                        //if (((ColumnAttribute)(p.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).IsPrimaryKey && Convert.ToInt32(p.GetValue(obj,null))==0)
                        //{

                        //}
                        //else
                        //{
                        cols += "[" + p.Name + "],";
                        if (!(t.ToString().ToLower().Contains("string") || t.ToString().ToLower().Contains("datetime")))
                            vals += p.GetValue(obj, null) + ",";
                        else
                            vals += "'" + p.GetValue(obj, null) + "',";
                        // }
                    }
                }
            }
        }

        str += cols.Substring(0, cols.Length - 1) + ") values (" + vals.Substring(0, vals.Length - 1) + ")";
        HttpContext.Current.Response.Write("<br>" + str + "<br>");
        this.ExecuteCommand(str);

    }
    /// <summary>
    /// 删除实体
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="obj"></param>
    public void Delete<TEntity>(TEntity obj) where TEntity : class
    {
        string str = "delete  from [" + typeof(TEntity).Name + "] where ";

        string where = "";
        //获得所有property的信息
        PropertyInfo[] properties = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //构造初始的query

        IQueryable<TEntity> query = this.GetTable<TEntity>().AsQueryable<TEntity>();
        //遍历每个property
        foreach (PropertyInfo p in properties)
        {
            if (p != null)
            {
                Type t = p.PropertyType;
                //加入object，Binary，和XDocument， 支持sql_variant，imager 和xml等的影射。
                if (t.IsValueType || t == typeof(string) || t == typeof(System.Byte[])
                  || t == typeof(object) || t == typeof(System.Xml.Linq.XDocument)
                  || t == typeof(System.Data.Linq.Binary))
                {
                    //如果不为null才算做条件

                    if (p.GetValue(obj, null) != null)
                    {
                        if (((ColumnAttribute)(p.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).IsPrimaryKey && Convert.ToInt32(p.GetValue(obj, null)) == 0)
                        {

                        }
                        else
                        {

                            if (!(t.ToString().ToLower().Contains("string") || t.ToString().ToLower().Contains("datetime")))
                            {

                                where += "[" + p.Name + "]" + "=" + p.GetValue(obj, null) + " and ";
                            }
                            else
                            {
                                if (t.ToString().ToLower().Contains("datetime") && this.Connection.GetType().Name == "OleDbConnection")
                                {
                                    where += "[" + p.Name + "]" + "=#" + p.GetValue(obj, null) + "# and ";

                                }
                                else
                                    where += "[" + p.Name + "]" + "='" + p.GetValue(obj, null) + "' and ";
                            }
                        }
                    }
                }
            }
        }

        str += where.Substring(0, where.Length - 5);
        try
        {
            this.ExecuteCommand(str);
        }
        catch
        {
            HttpContext.Current.Response.Write("<br>" + str + "<br>");

        }

    }
    /// <summary>
    /// 根据主键查找实体
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public TEntity FindKey<TEntity>(object value) where TEntity : class
    {
        //获得所有property的信息
        PropertyInfo[] properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //构造初始的query
        IQueryable<TEntity> query = this.GetTable<TEntity>().AsQueryable<TEntity>();
        //遍历每个property
        foreach (PropertyInfo p in properties)
        {
            if (p != null)
            {
                Type t = p.PropertyType;
                //加入object，Binary，和XDocument， 支持sql_variant，imager 和xml等的影射。
                if (t.IsValueType || t == typeof(string) || t == typeof(System.Byte[])
                  || t == typeof(object) || t == typeof(System.Xml.Linq.XDocument)
                  || t == typeof(System.Data.Linq.Binary))
                {
                    //如果不为null才算做条件


                    if (((ColumnAttribute)(p.GetCustomAttributes(typeof(ColumnAttribute), true)[0])).IsPrimaryKey)
                    {
                        ParameterExpression param = Expression.Parameter(typeof(TEntity), "d");
                        Expression right = Expression.Constant(value);
                        Expression left = Expression.Property(param, p.Name);
                        Expression filter = Expression.Equal(left, right);

                        Expression<Func<TEntity, bool>> pred = Expression.Lambda<Func<TEntity, bool>>(filter, param);

                        query = query.Where(pred);
                        break;

                    }




                }
            }
        }
        return query.First();
    }



}

